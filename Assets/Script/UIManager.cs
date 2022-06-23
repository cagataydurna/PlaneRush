using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager _instance;

    public Animator LayoutAnimator;
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
        Time.timeScale = 1f;

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
