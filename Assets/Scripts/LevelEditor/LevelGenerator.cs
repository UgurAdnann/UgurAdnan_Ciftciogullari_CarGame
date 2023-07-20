
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    #region Variables for General
    private GameManager gameManager;
    #endregion

    #region Variables for Map Sprite
    public Texture2D map;
    public ColorToPrefab[] colorMappings;
    private Transform obstacles, golds;
    private GameObject  currentObject;
    #endregion

    #region Variables for Other Object
    public PlayerPosHolder[] playerPoses;
    private Transform levels;
    public GameObject playablePlayerPrefab, followablePlayerPrefab, targetIconPrefab;
    private GameObject currentPlayer;
    public int playerCounter;
    #endregion


    void Start()
    {
        //Assigments
        gameManager = ObjectManager.GameManager;
        levels = GameObject.FindGameObjectWithTag("Levels").transform;
        obstacles = GameObject.FindGameObjectWithTag("Obstacles").transform;
        golds = GameObject.FindGameObjectWithTag("Golds").transform;

        SetPlayerPoses();
        GenerateLevel();
    }

    #region Map Sprite
    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0)
        {
            //Pixel is transparent, null pixell
            return;
        }

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                //Setting Pos
                Vector2 position = new Vector2(x - 9, y - 20);

                //Get Instantiated object
                currentObject = Instantiate(colorMapping.Prefab, position, Quaternion.identity);

                //Settings depend on object type
                if (currentObject.GetComponent<ObjectTypeHolder>().objectType.Equals(ObjectType.Obstacle))
                    currentObject.transform.SetParent(obstacles);
                if (currentObject.GetComponent<ObjectTypeHolder>().objectType.Equals(ObjectType.Gold))
                    currentObject.transform.SetParent(golds);
            }
        }


    }
    #endregion

    #region Instantiate Other Objects
    void SetPlayerPoses()
    {
        if (playerCounter < playerPoses.Length)
        {
            for (int i = 0; i <= playerCounter; i++)
            {
                //Instantiate Previous Cars
                if (i < playerCounter)
                    currentPlayer = gameManager.cars[i];

                //Instantiate Current Car and Target
                if (i == playerCounter)
                {
                    Instantiate(targetIconPrefab, playerPoses[i].endPos, Quaternion.identity, levels);
                    currentPlayer = Instantiate(playablePlayerPrefab);
                    gameManager.cars.Add(currentPlayer);
                }

                //Car Settings
                currentPlayer.transform.SetParent(levels);
                currentPlayer.transform.position = playerPoses[i].startPos;
                currentPlayer.transform.localRotation = playerPoses[i].rot;
            }
            playerCounter++;
            gameManager.isCanStart = true;
        }
    }
    #endregion

}
