using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int wGrid = 20;
    public static int hGrid = 10;
    public static Transform[,] grid = new Transform[wGrid, hGrid];

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void gridUpdate(Tetromino tetromino)
    {
        for(int i = 0; i < hGrid; i++)
        {
            for (int j = 0; j < wGrid; j++)
            {
                if(grid[j, i] != null)
                {
                    if(grid[j, i].parent == tetromino.transform)
                    {
                        grid[j, i] = null;
                    }
                }
            }
        }
        foreach (Transform block in tetromino.transform)
        {
            
        }
    }
}
