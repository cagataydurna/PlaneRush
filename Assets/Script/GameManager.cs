using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public bool isFinish;
    //crossmaterial for cut script
    public Material crossSectionMat,wingMat;
    public Color wingColor;
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

    public void DamageEffectWing()
    {
        wingMat.DOColor(Color.red, 0.2f).OnStepComplete(()=> wingMat.DOColor(wingColor, 0.2f));
       ;
    }
}
