using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetromino : MonoBehaviour
{
    private float previousTime;
    public float fallSpeed = 1;
    public static int height = 20;
    public static int width = 10;

    void Start()
    {
        
    }

    void Update()
    {
        UserInput();
    }

    void UserInput()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1, 0, 0);
            if(!checkMove())
            {
                transform.position -= new Vector3(1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0);
            if (!checkMove())
            {
                transform.position -= new Vector3(-1, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z))
        {
            transform.Rotate(0, 0, 90);
            if (!checkMove())
            {
                transform.Rotate(0, 0, -90);
            }
        }
        else if (Time.time - previousTime > (Input.GetKey(KeyCode.DownArrow) ? fallSpeed / 10 : fallSpeed))
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
            if (borderX >= width || borderX < 0 || borderY <= 0)
            {
                return false;
            }
        }
        return true;
    }
}
