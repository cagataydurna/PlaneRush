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
    public bool isVibrationOff;
    void Awake()
    {   
        isFinish = false;
        if (_instance == null) _instance = this;
        GameObject.FindWithTag("particleLeft").GetComponent<ParticleSystem>().Stop();
       // GameObject.FindWithTag("particleTurbo").GetComponent<ParticleSystem>().Stop();
       // GameObject.FindWithTag("finishPanelParticle").GetComponent<ParticleSystem>().Stop();
        sizeOfWing = GameObject.FindGameObjectWithTag("wing").GetComponent<Renderer>().localBounds.size.z;
        blowParticle = GameObject.FindGameObjectWithTag("blowParticle");
        blowParticle.SetActive(false);
        chest=GameObject.FindWithTag("Chest");
        Vibration.Init();

    }

    public void Start()
    {
        CoinCalculator(0);
        Debug.Log(PlayerPrefs.GetInt("coinn"));
    }

    void Update()
    {
         if (isFailFinish)
         {
            AdManager._instance.RequestInterstitial();
            AdManager._instance.RequestRewardedAd();
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
            blowParticle.SetActive(true);
            chest.SetActive(false);
            blowParticle.GetComponent<ParticleSystem>().Play();
            UIManager._instance.FinishScreen();
            CoinCalculator(30);
            UIManager._instance.CoinUpdate();
            isFailFinish = false;
            
            
            
        }
    }
    public void CoinCalculator(int coin)
    {
        if (PlayerPrefs.HasKey("coinn"))
        {
            int oldCoin = PlayerPrefs.GetInt("coinn");
            PlayerPrefs.SetInt("coinn", oldCoin + coin);
        }
        else
        {
            PlayerPrefs.SetInt("coinn", 0);
        }
    }

    public void ParticleStop()
    {
        //GameObject.FindWithTag("particleLeft").GetComponent<ParticleSystem>().Stop();
        //GameObject.FindWithTag("particleTurbo").GetComponent<ParticleSystem>().Stop();
    }

    public void DamageEffectWing()
    {
        wingMat.DOColor(Color.red, 0.2f).OnStepComplete(()=> wingMat.DOColor(wingColor, 0.2f));
       ;
    }

    public void VibrationPopGame()
    {
        if(!isVibrationOff)Vibration.VibratePop();
        
    }
}
