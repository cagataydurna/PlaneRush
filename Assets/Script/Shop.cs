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

    //ITEMS
    public void Item1Open()
    {
        ParticleEffect1.SetActive(true);
        ParticleEffect2.SetActive(false);
        item.GetComponent<Image>().sprite = Green;
        item2.GetComponent<Image>().sprite = Yellow;
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
        if (coin >= 500)
        {
            lock1.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 500);
            Item1Open();
            UIManager._instance.CoinUpdate();
        }
        
    }
    public void Lock2Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        if (coin >= 1000)
        {
            lock2.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 1000);
            Item2Open();
            UIManager._instance.CoinUpdate();
        }

    }

}
