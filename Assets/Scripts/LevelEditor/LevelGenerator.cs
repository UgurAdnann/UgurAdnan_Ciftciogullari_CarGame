
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public Texture2D map;

    public ColorToPrefab[] colorMappings;
    public PlayerPosHolder[] playerPoses;

    public GameObject playablePlayerPrefab, followablePlayerPrefab, targetIconPrefab;
    private GameObject currentPlayer;

    public int playerCounter;

    private void OnEnable()
    {
        SetPlayerPoses();
    }

    void Start()
    {
        GenerateLevel();
    }

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
                Vector2 position = new Vector2(x - 9, y - 20);
                Instantiate(colorMapping.Prefab, position, Quaternion.identity, transform);
            }
        }


    }

    void SetPlayerPoses()
    {
        if (playerCounter < playerPoses.Length)
        {
            for (int i = 0; i <= playerCounter; i++)
            {
                if (i < playerCounter)
                    currentPlayer = Instantiate(playablePlayerPrefab);

                if (i == playerCounter)
                {
                    Instantiate(targetIconPrefab, playerPoses[i].endPos, Quaternion.identity, transform);
                    currentPlayer = Instantiate(followablePlayerPrefab);
                }

                currentPlayer.transform.SetParent(transform);
                currentPlayer.transform.position = playerPoses[i].startPos;
                currentPlayer.transform.rotation = playerPoses[i].rot;
            }
            playerCounter++;
        }

    }


}
