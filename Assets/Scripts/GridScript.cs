using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridScript : MonoBehaviour
{
    public GameObject fruitPrefab;

    float TopLeftX = -1.4f;
    float TopLeftY = 1.4f;
    float GridWidthX = 0.4f;
    float GridWidthY = 0.4f;
    public int differentElements = 6;
    // Start is called before the first frame update

    public int[,] gridContent = new int[8,8];
    
    private GameObject[,] fruitsprefab = new GameObject[8,8];

    void Start()
    {
        fillGrid();
        while (3 >= checkMoves())
        { // Not enough possible moves, regenerating again
            fillGrid();
        }
        printLog();
        fillPrefabs();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void fillGrid()
    {
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                int[] forbidden = new int[2] { -1, -1 };
                if (i > 1 && gridContent[i - 1, j] == gridContent[i - 2, j])
                {
                    forbidden[0] = gridContent[i - 1, j];
                }
                if (j > 1 && gridContent[i, j - 1] == gridContent[i, j - 2])
                {
                    forbidden[1] = gridContent[i, j - 1];
                }
                int gridValue = Random.Range(0, differentElements);
                while (gridValue == forbidden[0] || gridValue == forbidden[1])
                {
                    gridValue = Random.Range(0, differentElements);
                }
                gridContent[i, j] = gridValue;
            }
        }
    }

    int checkMoves()
    {
        int moves = 0;
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                if (i == 0 && j == 0) { continue; }

                if (i > 1 && gridContent[i - 1, j] == gridContent[i - 2, j])
                { // Vertical Chance
                    if (i < 7 && gridContent[i - 1, j] == gridContent[i + 1, j])
                    { // Is the below one
                        moves++;
                        Debug.Log("Total possible on Down: " + i + "-" + j);
                    }
                    else if (i > 5 && gridContent[i - 1, j] == gridContent[i - 4, j])
                    { // Is the upper one
                        moves++;
                        Debug.Log("Total possible on Up(Far): " + i + "-" + j);
                    }
                    else if (j < 7 && gridContent[i - 1, j] == gridContent[i, j + 1])
                    { // Is the right one
                        moves++;
                        Debug.Log("Total possible on Right: " + i + "-" + j);
                    }
                    else if (j > 0 && gridContent[i - 1, j] == gridContent[i, j - 1])
                    { // Is the left one 
                        moves++;
                        Debug.Log("Total possible on Left: " + i + "-" + j);
                    }

                }
                if (j > 1 && gridContent[i, j - 1] == gridContent[i, j - 2])
                { // Horizontal chance
                    if (j < 7 && gridContent[i, j - 1] == gridContent[i, j + 1])
                    { // Is the right one X|X|here|X
                        moves++;
                        Debug.Log("Total possible on Right: " + i + "-" + j);
                    }
                    else if (i > 0 && gridContent[i - 1, j] == gridContent[i, j - 1]) 
                    { // Is the upper one
                        moves++;
                        Debug.Log("Total possible on Up: " + i + "-" + j);
                    }
                    else if (i < 7 && gridContent[i + 1, j] == gridContent[i, j - 1])
                    { // Is the bottom one
                        moves++;
                        Debug.Log("Total possible on Down: " + i + "-" + j);
                    }
                    else if (j > 5 && gridContent[i, j - 1] == gridContent[i, j - 4])
                    { // Is the left one X|Y|X|X|here
                        moves++;
                        Debug.Log("Total possible on Left(Far): " + i + "-" + j);
                    }
                }

            }
        }
        return moves;
    }

    void printLog()
    {
        string log = "";
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                log += ("|" + gridContent[i, j]);
            }
            log += ("|\n");
        }
        log += ("\n");
        Debug.Log(log);
    }

    void fillPrefabs()
    {
        for (int i = 0; i < 8; ++i)
        {
            for (int j = 0; j < 8; ++j)
            {
                // Instantiate at position () and zero rotation.
                GameObject newObject = Instantiate(fruitPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                newObject.transform.localScale = new Vector3(0.07f, 0.07f, 1.0f);
                newObject.transform.position = new Vector3(TopLeftX + j * GridWidthX, TopLeftY - i * GridWidthY, 0);
                newObject.GetComponent<Fruit>().repaint(gridContent[i, j]);
                fruitsprefab[i, j] = newObject;
            }
        }
    }

}