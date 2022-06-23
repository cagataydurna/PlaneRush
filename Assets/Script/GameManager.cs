using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public bool isFinish;
    public Material crossSectionMat,wingMat;
    public Color wingColor;
    public ParticleSystem finishParticle;
    public float sizeOfWing;//oyun sonundaki kanat uzunluğu
    public bool isFailFinish;//çarpınca oyun bitişi
    GameObject blowParticle,chest;
    public int finishPanelCount;//oyun sonundaki her toplanan panelde artar
    void Awake()
    {
        isFinish = false;
        if (_instance == null) _instance = this;
        GameObject.FindWithTag("particleLeft").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("particleTurbo").GetComponent<ParticleSystem>().Stop();
        GameObject.FindWithTag("finishPanelParticle").GetComponent<ParticleSystem>().Stop();
        sizeOfWing = GameObject.FindGameObjectWithTag("wing").GetComponent<Renderer>().localBounds.size.z;
        blowParticle = GameObject.FindGameObjectWithTag("blowParticle");
        blowParticle.SetActive(false);
        chest=GameObject.FindWithTag("Chest");

    }

    void Update()
    {
         if (isFailFinish)
         {
             GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            blowParticle.SetActive(true);
            chest.SetActive(false);
            blowParticle.GetComponent<ParticleSystem>().Play();
        }
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
