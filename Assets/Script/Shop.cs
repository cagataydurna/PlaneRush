using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{


    //Skills
    public GameObject ParticleEffect1;
    public GameObject ParticleEffect2;
    public GameObject ParticleEffect3;
    public GameObject ParticleEffect4;

    public Sprite Green;
    public Sprite Yellow;

    //Items
    public GameObject itemFree;
    public GameObject item;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    //Locks

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;

    public void Awake()
    {
        if (PlayerPrefs.HasKey("itemSelect") == false)
            PlayerPrefs.SetInt("itemSelect", 0);


        if (PlayerPrefs.GetInt("itemSelect") == 1)
            Item1Open();

        else if (PlayerPrefs.GetInt("itemSelect") == 2)
            Item2Open();

        else if (PlayerPrefs.GetInt("itemSelect") == 3)
            Item3Open();

        else if (PlayerPrefs.GetInt("itemSelect") == 4)
            Item4Open();




        if (PlayerPrefs.HasKey("controlLock1") == false)
            PlayerPrefs.SetInt("controlLock1", 0);
        
        if (PlayerPrefs.HasKey("controlLock2") == false)
            PlayerPrefs.SetInt("controlLock2", 0);

        if (PlayerPrefs.HasKey("controlLock3") == false)
            PlayerPrefs.SetInt("controlLock3", 0);

        if (PlayerPrefs.HasKey("controlLock4") == false)
            PlayerPrefs.SetInt("controlLock4", 0);

        if (PlayerPrefs.GetInt("controlLock1") == 1)
            lock1.SetActive(false);

        if (PlayerPrefs.GetInt("controlLock2") == 1)
            lock2.SetActive(false);

        if (PlayerPrefs.GetInt("controlLock3") == 1)
            lock3.SetActive(false);

        if (PlayerPrefs.GetInt("controlLock4") == 1)
            lock4.SetActive(false);
    }

    //ITEMS
    public void ItemOpen()
    {
        ParticleEffect1.SetActive(false);
        ParticleEffect2.SetActive(false);
        ParticleEffect3.SetActive(false);
        ParticleEffect4.SetActive(false);
        itemFree.GetComponent<Image>().sprite = Green;
        item.GetComponent<Image>().sprite = Yellow;
        item2.GetComponent<Image>().sprite = Yellow;
        item3.GetComponent<Image>().sprite = Yellow;
        item4.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("itemSelect", 0);
    }

    public void Item1Open()
    {
        ParticleEffect1.SetActive(true);
        ParticleEffect2.SetActive(false);
        ParticleEffect3.SetActive(false);
        ParticleEffect4.SetActive(false);
        itemFree.GetComponent<Image>().sprite = Yellow;
        item.GetComponent<Image>().sprite = Green;
        item2.GetComponent<Image>().sprite = Yellow;
        item3.GetComponent<Image>().sprite = Yellow;
        item4.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("itemSelect", 1);
    }
    public void Item2Open()
    {

        ParticleEffect1.SetActive(false);
        ParticleEffect2.SetActive(true);
        ParticleEffect3.SetActive(false);
        ParticleEffect4.SetActive(false);
        itemFree.GetComponent<Image>().sprite = Yellow;
        item2.GetComponent<Image>().sprite = Green;
        item.GetComponent<Image>().sprite = Yellow;
        item3.GetComponent<Image>().sprite = Yellow;
        item4.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("itemSelect", 2);
    }
    public void Item3Open()
    {

        ParticleEffect1.SetActive(false);
        ParticleEffect2.SetActive(false);
        ParticleEffect3.SetActive(true);
        ParticleEffect4.SetActive(false);
        itemFree.GetComponent<Image>().sprite = Yellow;
        item2.GetComponent<Image>().sprite = Yellow;
        item.GetComponent<Image>().sprite = Yellow;
        item3.GetComponent<Image>().sprite = Green;
        item4.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("itemSelect", 3);
    }

    public void Item4Open()
    {

        ParticleEffect1.SetActive(false);
        ParticleEffect2.SetActive(false);
        ParticleEffect3.SetActive(false);
        ParticleEffect4.SetActive(true);
        itemFree.GetComponent<Image>().sprite = Yellow;
        item2.GetComponent<Image>().sprite = Yellow;
        item.GetComponent<Image>().sprite = Yellow;
        item3.GetComponent<Image>().sprite = Yellow;
        item4.GetComponent<Image>().sprite = Green;
        PlayerPrefs.SetInt("itemSelect", 4);
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

    public void Lock3Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int controlLock3 = PlayerPrefs.GetInt("controlLock3");
        if (coin >= 1000 && controlLock3 == 0)
        {
            lock3.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 1000);
            PlayerPrefs.SetInt("controlLock3", 1);
            Item3Open();
            UIManager._instance.CoinUpdate();
        }

    }

    public void Lock4Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int controlLock4 = PlayerPrefs.GetInt("controlLock4");
        if (coin >= 1000 && controlLock4 == 0)
        {
            lock4.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 1000);
            PlayerPrefs.SetInt("controlLock4", 1);
            Item4Open();
            UIManager._instance.CoinUpdate();
        }

    }

}
