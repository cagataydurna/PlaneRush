using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;
    
    public Animator LayoutAnimator;
    public Image FillBar;
    public GameObject Ramp;
    public GameObject Settings_Open;
    public GameObject Settings_Close;
    public GameObject Sound_On;
    public GameObject Sound_Off;
    public GameObject Vibration_On;
    public GameObject Vibration_Off;
    public GameObject Information;
    public GameObject Shop;
    public GameObject Ads;
    public GameObject Panel;
    public GameObject TapToPlay;
    public Button playButton;
    public TextMeshProUGUI CoinText;
    public TextMeshProUGUI RewardCoinText;

    //Finish Screen Objects
    public GameObject FinishScreenObject;
    public GameObject Background;
    public GameObject Backgroundwin;
    public GameObject Complete;
    public GameObject NoThanks;
    public GameObject RadialShine;
    private bool radial_shine;
    public GameObject Coin;
    public GameObject Claim;
    public GameObject Gift;

    public GameObject NextLevelButton;

    public bool isStarted;

    public void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        Time.timeScale = 0;
    }

    public void Start()
    {
        if (!PlayerPrefs.HasKey("Sound"))
        {
            PlayerPrefs.SetInt("Sound", 0);
        }
        if (!PlayerPrefs.HasKey("Vibration"))
        {
            PlayerPrefs.SetInt("Vibration", 0);
        }
        
        if (PlayerPrefs.GetInt("NoAds") == 1)
        {
            RemoveAds();
        }

        PlayerMovement._instance.isStart = false;

        CoinUpdate();

    }
    public void Update()
    {
        if (Ramp == null) GameObject.FindWithTag("ramp");
        if (radial_shine == true)
        {
            RadialShine.GetComponent<RectTransform>().Rotate(new Vector3(0, 0, 15f * Time.deltaTime));
        }
        FillBar.fillAmount = (PlayerMovement._instance.transform.position.z) / (Ramp.transform.position.z);
        if (PlayerMovement._instance.isStart)
        {
            CloseUI();
        }
    }


    public void CloseUI()
    {
        Shop.SetActive(false);
        Ads.SetActive(false);
        Settings_Open.SetActive(false);
        Settings_Close.SetActive(false);
        Sound_On.SetActive(false);
        Sound_Off.SetActive(false);
        Vibration_On.SetActive(false);
        Vibration_Off.SetActive(false);
        Information.SetActive(false);
        Panel.SetActive(false);
        TapToPlay.SetActive(false);

    }
    public void RemoveAds()
    {
        Ads.SetActive(false);
    }

    public void CoinUpdate()
    {
        CoinText.text = PlayerPrefs.GetFloat("coinn").ToString();
    }

    public void PlayButton()
    {
        PlayerMovement._instance.isStart = true;
        Time.timeScale = 1f;
    }

    public void FinishScreen()
    {
        StartCoroutine("FinishScreenLaunch");
    }

    public void nextScene()
    {
        PlayerMovement._instance.isStart = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }

    public IEnumerator AfterRewardScreen()
    {
        NoThanks.SetActive(false);
        Claim.SetActive(false);
        NextLevelButton.SetActive(true);
        RewardCoinText.gameObject.SetActive(true);
        for(int i =0; i< 101; i++)
        {
            RewardCoinText.text = "+" + i.ToString();
            yield return new WaitForSeconds(0.0001f);
        }
        

    }

    public IEnumerator FinishScreenLaunch()
    {
        
        Time.timeScale = 0.6f;
        radial_shine = true;
        FinishScreenObject.SetActive(true);
        Background.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        Backgroundwin.SetActive(true);
        yield return new WaitForSecondsRealtime(0.8f);
        Complete.SetActive(true);
        RadialShine.SetActive(true);
        Gift.SetActive(true);
        Coin.SetActive(true);
        RewardCoinText.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(0.4f);
        Claim.SetActive(true);
        yield return new WaitForSecondsRealtime(3);
        NoThanks.SetActive(true);
    }

    public void SettingsOpenButton()
    {
        Settings_Open.SetActive(false);
        Settings_Close.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_in");
        

        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Sound_On.SetActive(true);
            Sound_Off.SetActive(false);
            AudioListener.volume = 1;
        }
        else if (PlayerPrefs.GetInt("Sound") == 1)
        {
            Sound_On.SetActive(false);
            Sound_Off.SetActive(true);
            AudioListener.volume = 0;
        }
        if (PlayerPrefs.GetInt("Vibration") == 0)
        {
            Vibration_On.SetActive(true);
            Vibration_Off.SetActive(false);

        }
        else if (PlayerPrefs.GetInt("Vibration") == 1)
        {
            Vibration_On.SetActive(false);
            Vibration_Off.SetActive(true);
            
        }
    }

    public void SettingCloseButton()
    {
        Settings_Close.SetActive(false);
        Settings_Open.SetActive(true);
        LayoutAnimator.SetTrigger("Slide_out");
       
        
    }

    public void SoundOn()
    {
        Sound_On.SetActive(false);
        Sound_Off.SetActive(true);
        AudioListener.volume = 0;
        PlayerPrefs.SetInt("Sound", 1);
    }

    public void SoundOff()
    {
        Sound_On.SetActive(true);
        Sound_Off.SetActive(false);
        AudioListener.volume = 1;
        PlayerPrefs.SetInt("Sound", 0);
    }

    public void VibrationOn()
    {
        Vibration_On.SetActive(false);
        Vibration_Off.SetActive(true);
        PlayerPrefs.SetInt("Vibration", 1);
    }

    public void VibrationOff()
    {
        Vibration_On.SetActive(true);
        Vibration_Off.SetActive(false);
        PlayerPrefs.SetInt("Vibration", 0);
    }

}
