
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
    private GameObject currentObject;
    #endregion

    #region Variables for Other Object
    public PlayerPosHolder[] playerPoses;
    private Transform levels;
    public GameObject playablePlayerPrefab, followablePlayerPrefab, targetIconPrefab;
    private GameObject currentPlayer, currentTarget;
    public int playerCounter;
    #endregion

    private void Awake()
    {
        ObjectManager.LevelGenerator = this;
    }

    void Start()
    {
        //Assigments
        gameManager = ObjectManager.GameManager;
        levels = GameObject.FindGameObjectWithTag("Levels").transform;
        obstacles = GameObject.FindGameObjectWithTag("Obstacles").transform;
        golds = GameObject.FindGameObjectWithTag("Golds").transform;

        SetCurrentPlayer();
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
    private void SetCurrentPlayer()
    {
        //Instantiate Current Car and Target
        currentTarget = Instantiate(targetIconPrefab, playerPoses[playerCounter].endPos, Quaternion.identity, levels);
        currentPlayer = Instantiate(playablePlayerPrefab);

        SetPlayerSettings(playerCounter);
        gameManager.isCanStart = true;
    }

    public void SetLastPlayer()
    {
        currentPlayer = Instantiate(followablePlayerPrefab);
        foreach (var item in gameManager.lastPathList)
        {
            currentPlayer.GetComponent<PlayerFollowable>().pathList.Add(item);
        }
        SetPlayerSettings(playerCounter - 1);
    }

    private void SetPlayerSettings(int num)
    {
        gameManager.cars.Add(currentPlayer);

        currentPlayer.transform.SetParent(levels);
        currentPlayer.transform.position = playerPoses[num].startPos;
        currentPlayer.transform.localRotation = playerPoses[num].rot;
    }

    public void SetTarget()
    {
        currentTarget.transform.position=playerPoses[playerCounter].endPos;
    }
    #endregion

}
