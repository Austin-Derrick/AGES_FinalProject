using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBallThrow : MonoBehaviour
{
    [SerializeField]
    Transform[] Stack_SpawnPoints = new Transform[3];

    [SerializeField]
    GameObject[] Stacks = new GameObject[3];

    [SerializeField]
    Transform ballSpawnPoint;

    [SerializeField]
    GameObject balls;

    private void Start()
    {
        ResetArea();
    }

    public void ResetArea()
    {
        for (int i = 0; i < Stack_SpawnPoints.Length; i++)
        {
            if (Stack_SpawnPoints[i].childCount > 0)
            {
                for (int j = 0; j < Stack_SpawnPoints[i].childCount; j++)
                {
                    Destroy(Stack_SpawnPoints[i].GetChild(j).gameObject);
                }
            }
        }
        SpawnBalls();
        Invoke("SpawnStacks", 0.5f);
    }

    private void SpawnStacks()
    {
        for (int i = 0; i < 3; i++)
        {
            Instantiate(Stacks[i], Stack_SpawnPoints[i].position, Stacks[i].transform.rotation, Stack_SpawnPoints[i]);

        }
    }

    private void SpawnBalls()
    {
        Instantiate(balls, ballSpawnPoint.position, balls.transform.rotation, ballSpawnPoint);
    }
}