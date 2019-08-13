using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> tilePrefabs;

    public GameObject[,] grid;

    public int numCols;
    public int numRows;

    public float tileWidth = 5f;
    public float tileHeight = 5f;

    public bool levelOfTheDay = false;

    public int numOfEnemies = 4;
    public List<int> enemyType;

    public int seedNumber;

    public Spawner spawner;

    public List<GameObject> mapList;

    public bool randomLevel;

    GameManager gm = GameManager.instance;


    void Start()
    {
        //if level of the day is true
        if (levelOfTheDay)
        {
            //Set the seed to be the month, day and year of the day's date
            int date = (System.DateTime.Now.Month) + (System.DateTime.Now.Day) + (System.DateTime.Now.Year);
            Random.InitState(date);
        }
        else
        {
            Random.InitState(seedNumber);
        }
        

        CreateMap();

       
    }

    void CreateMap()
    {
        //create the 2D array
        grid = new GameObject[numCols, numRows];

        for (int currentCol = 0; currentCol < numCols; currentCol++)
        {
            for (int currentRow = 0; currentRow < numRows; currentRow++)
            {
                //Instantiate Room
                GameObject tempRoom = Instantiate(RandomRoom());

                //Add it to the grid array
                grid[currentCol, currentRow] = tempRoom;

                //Move it into position
                tempRoom.transform.position = new Vector3(currentCol * tileWidth, 0, -currentRow * tileHeight);

                //name the tile
                tempRoom.name = "Tile_" + currentRow + "_" + currentCol;

                //make the tile a child of this object
                tempRoom.GetComponent<Transform>().parent = this.gameObject.GetComponent<Transform>();

                //Remove the appropriate walls depending on where the room is
                Room roomScript = tempRoom.GetComponent<Room>();

                //if the tile is not in the first column
                if (currentCol > 0)
                {
                    roomScript.wallWest.SetActive(false);
                }

                //if the tile is not in the last column
                if (currentCol < numCols - 1)
                {
                    roomScript.wallEast.SetActive(false);
                }
                //if the tile is not in the first row
                if (currentRow != 0)
                {
                    roomScript.wallNorth.SetActive(false);
                }
                //if the tile is not in the last row
                if (currentRow < numRows - 1)
                {
                    roomScript.wallSouth.SetActive(false);
                }

                mapList.Add(tempRoom);
            }
        }

        while (gm.Enemies.Count < 4)
        {
            
            spawner.SpawnEnemy(Random.Range(0, enemyType.Count));
            
        }

       

    }

    private GameObject RandomRoom()
    {
        int roomIndex = Random.Range(0, tilePrefabs.Count);
        return tilePrefabs[roomIndex];
    }
}
