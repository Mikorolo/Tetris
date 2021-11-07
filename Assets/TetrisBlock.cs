using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisBlock : MonoBehaviour
{
    private float previousTime;
    public Vector3 rotationPoint;
    public float fallTime = 0.8f;
    public static int height = 20;
    public static int width = 10;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            if(Time.time - previousTime > fallTime / 10)
            {
                transform.position += new Vector3(-1, 0, 0);
                if (!checkMove())
                {
                    transform.position -= new Vector3(-1, 0, 0);
                }
                previousTime = Time.time;
            }
        }
        else if(Input.GetKey(KeyCode.RightArrow))
        {
            if (Time.time - previousTime > fallTime / 10)
            {
                transform.position += new Vector3(1, 0, 0);
                if (!checkMove())
                {
                    transform.position -= new Vector3(1, 0, 0);
                }
                previousTime = Time.time;
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!checkMove())
            {
                transform.position -= new Vector3(0, -1, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
            if(!checkMove())
            {
                transform.Rotate(0, 0, -90);
            }
        }

        if(Time.time - previousTime > 
            (Input.GetKey(KeyCode.DownArrow)
            ? fallTime / 10 : fallTime))
        {
            transform.position += new Vector3(0, -1, 0);
            if (!checkMove())
            {
                transform.position -= new Vector3(0, -1, 0);
                this.enabled = false;
                FindObjectOfType<SpawnTetromino>().NewTetromino();
            }
            previousTime = Time.time;
        }
    }

    bool checkMove()
    {
        foreach (Transform blocks in transform)
        {
            int borderX = Mathf.RoundToInt(blocks.transform.position.x);
            int borderY = Mathf.RoundToInt(blocks.transform.position.y);
            if (borderX >= width || borderX < 0 || borderY >= height || borderY < 0)
            {
                return false;
            }
        }
        return true;
    }
}
