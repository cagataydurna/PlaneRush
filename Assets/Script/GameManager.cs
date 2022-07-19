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
    public float sizeOfWing;//oyun sonundaki kanat uzunluğu
    public bool isFailFinish;//çarpınca oyun bitişi
    GameObject blowParticle,chest;
    public int finishPanelCount;//oyun sonundaki her toplanan panelde artar
    public bool isVibrationOff;
    void Awake()
    {   
        if(_instance == null)
        {
            _instance = this;
        }
        
        isFinish = false;
        isFailFinish = false;
        GameObject.FindWithTag("particleLeft").GetComponent<ParticleSystem>().Stop();
       // GameObject.FindWithTag("particleTurbo").GetComponent<ParticleSystem>().Stop();
       // GameObject.FindWithTag("finishPanelParticle").GetComponent<ParticleSystem>().Stop();
        sizeOfWing = GameObject.FindGameObjectWithTag("wing").GetComponent<Renderer>().localBounds.size.z;
        blowParticle = GameObject.FindGameObjectWithTag("blowParticle");
        blowParticle.SetActive(false);
        chest=GameObject.FindWithTag("Chest");
        Vibration.Init();
        
        
            if (PlayerPrefs.HasKey("LevelCounter") == false)
            {
                PlayerPrefs.SetInt("LevelCounter", 0);
            }
        
    }

    public void Start()
    {
        CoinCalculator(0.0f);
        Debug.Log(PlayerPrefs.GetFloat("coinn"));
    }

    void Update()
    {

        if (isFailFinish)
        {
            if (PlayerPrefs.GetInt("NoAds") == 0)
            {
                AdManager._instance.RequestInterstitial();
            }

            FailFinish();


        }
    }
    public void CoinCalculator(float coin)
    {
        if (PlayerPrefs.HasKey("coinn"))
        {
            float oldCoin = PlayerPrefs.GetFloat("coinn");
            if(finishPanelCount == 1)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 1.2f));
            }
            else if (finishPanelCount == 2)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 1.4f));
            }
            else if (finishPanelCount == 3)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 1.6f));
            }
            else if (finishPanelCount == 4)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 1.8f));
            }
            else if (finishPanelCount == 5)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 2.0f));
            }
            else if (finishPanelCount == 6)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 2.2f));
            }
            else if (finishPanelCount == 7)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 2.4f));
            }
            else if (finishPanelCount == 8)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 2.6f));
            }
            else if (finishPanelCount == 9)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 2.8f));
            }
            else if (finishPanelCount == 10)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 3.0f));
            }
            else if (finishPanelCount == 11)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 3.2f));
            }
            else if (finishPanelCount == 12)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 3.4f));
            }
            else if (finishPanelCount == 13)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 3.6f));
            }
            else if (finishPanelCount == 14)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 3.8f));
            }
            else if (finishPanelCount == 15)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 4.0f));
            }
            else if (finishPanelCount == 16)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 4.2f));
            }
            else if (finishPanelCount == 17)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 4.4f));
            }
            else if (finishPanelCount == 18)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 4.6f));
            }
            else if (finishPanelCount == 19)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 4.8f));
            }
            else if (finishPanelCount == 20)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 5.0f));
            }
            else if (finishPanelCount == 21)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 5.2f));
            }
            else if (finishPanelCount == 22)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 5.4f));
            }
            else if (finishPanelCount == 23)
            {
                PlayerPrefs.SetFloat("coinn", oldCoin + (coin * 5.6f));

            }



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

    public void WingColorInit()
    {
        wingColor = wingMat.color;

    }

    public void FailFinish()
    {
        AdManager._instance.RequestRewardedAd();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        blowParticle.SetActive(true);
        chest.SetActive(false);
        blowParticle.GetComponent<ParticleSystem>().Play();
        UIManager._instance.FinishScreen();
        CoinCalculator(20);
        UIManager._instance.CoinUpdate();
        PlayerPrefs.SetInt("LevelCounter", PlayerPrefs.GetInt("LevelCounter") + 1);
        Debug.Log(PlayerPrefs.GetInt("LevelCounter"));
        isFailFinish = false;
    }

   
}
