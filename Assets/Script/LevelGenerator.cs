using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private int counterRoad = 2;
    public GameObject[] road;
    public GameObject finalLine;
    public GameObject finalPanel;
     void Awake()
    {
        Random.InitState(2);
        for (int i = 0; i < 12; i++)
        {
            Instantiate(road[Random.Range(0, road.Length - 1)], new Vector3(0, 0, counterRoad * 16),
                Quaternion.Euler(0,90,0));
            counterRoad++;
            
        }

        
    }
}
