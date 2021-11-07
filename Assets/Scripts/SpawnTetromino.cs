using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTetromino : MonoBehaviour
{
    public GameObject[] Tetromino;

    // Start is called before the first frame update
    void Start()
    {
        NewTetromino();
    }

    public void NewTetromino()
    {
        Instantiate(Tetromino[Random.Range(0, Tetromino.Length)],
            transform.position, Quaternion.identity);
    }
}
