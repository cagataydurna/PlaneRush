using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{


    //Skills
    public GameObject ParticleEffect1;
    public GameObject ParticleEffect2;

    public Sprite Green;
    public Sprite Yellow;

    //Items
    public GameObject item;
    public GameObject item2;

    //Locks
    public GameObject lock1;
    public GameObject lock2;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("itemSelect") == false)
            PlayerPrefs.SetInt("itemSelect", 0);
        if(PlayerPrefs.GetInt("itemSelect") == 0)
        {
            Item1Open();
        }


        if (PlayerPrefs.HasKey("controlLock1") == false)
            PlayerPrefs.SetInt("controlLock1", 0);
        
        if (PlayerPrefs.HasKey("controlLock2") == false)
            PlayerPrefs.SetInt("controlLock2", 0);
        
        if (PlayerPrefs.GetInt("controlLock1") == 1)
            lock1.SetActive(false);

        if (PlayerPrefs.GetInt("controlLock2") == 1)
            lock2.SetActive(false);
    }

    //ITEMS
    public void Item1Open()
    {
        ParticleEffect1.SetActive(true);
        ParticleEffect2.SetActive(false);
        item.GetComponent<Image>().sprite = Green;
        item2.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("itemSelect", 0);
    }
    public void Item2Open()
    {

        ParticleEffect1.SetActive(false);
        ParticleEffect2.SetActive(true);
        item2.GetComponent<Image>().sprite = Green;
        item.GetComponent<Image>().sprite = Yellow;
    }

    //LOCKS
    public void Lock1Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int controlLock1 = PlayerPrefs.GetInt("controlLock1");
        if (coin >= 500 && controlLock1 == 0)
        {
            lock1.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 500);
            PlayerPrefs.SetInt("controlLock1", 1);
            Item1Open();
            UIManager._instance.CoinUpdate();
        }
        
    }
    public void Lock2Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int controlLock2 = PlayerPrefs.GetInt("controlLock2");
        if (coin >= 1000 && controlLock2 == 0)
        {
            lock2.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 1000);
            PlayerPrefs.SetInt("controlLock2", 1);
            Item2Open();
            UIManager._instance.CoinUpdate();
        }

    }

}
