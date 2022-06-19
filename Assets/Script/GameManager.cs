using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public bool isFinish;
    //crossmaterial for cut script
    public Material crossSectionMat;
    void Awake()
    {
        isFinish = false;
        if (_instance == null) _instance = this;
        GameObject.FindWithTag("particleLeft").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("particleTurbo").GetComponent<ParticleSystem>().Stop();
    }

    void Update()
    {
        
    }

    public void ParticleStop()
    {
        GameObject.FindWithTag("particleLeft").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("particleTurbo").GetComponent<ParticleSystem>().Stop();

    }
}
