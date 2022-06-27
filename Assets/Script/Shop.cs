using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    //GameObject.FindGameObjectWithTag("Chest").GetComponent<MeshRenderer>().material=MATERİAL BURA GELCEK
    //Materials
    public Material Material1;
    public Material Material2;
    public Material Material3;
    public Material Material4;
    public Material Material5;
    public Material Material6;

    //WING MATERIAL
    
    public Material wingMaterial2;
    


    //FAN MATERIAL
    
    public Material fanMaterial2;
    
    
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

    //Material Items
    public GameObject materialItem1;
    public GameObject materialItem2;
    public GameObject materialItem3;
    public GameObject materialItem4;
    public GameObject materialItem5;
    public GameObject materialItem6;

    //Locks

    public GameObject lock1;
    public GameObject lock2;
    public GameObject lock3;
    public GameObject lock4;

    //MATERIAL LOCKS
    public GameObject materialLock1;
    public GameObject materialLock2;
    public GameObject materialLock3;
    public GameObject materialLock4;
    public GameObject materialLock5;


    public void Awake()
    {
        //TAIL
        if (PlayerPrefs.HasKey("itemSelect") == false)
            PlayerPrefs.SetInt("itemSelect", 0);

        if (PlayerPrefs.GetInt("itemSelect") == 0)
            ItemOpen();

        else if (PlayerPrefs.GetInt("itemSelect") == 1)
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

        //MATERIAL
        if (PlayerPrefs.HasKey("materialItemSelect") == false)
            PlayerPrefs.SetInt("materialItemSelect", 0);

        if (PlayerPrefs.GetInt("materialItemSelect") == 0)
            MaterialItemOpen();

        else if (PlayerPrefs.GetInt("materialItemSelect") == 1)
            MaterialItemOpen2();

        else if (PlayerPrefs.GetInt("materialItemSelect") == 2)
            MaterialItemOpen3();

        else if (PlayerPrefs.GetInt("materialItemSelect") == 3)
            MaterialItemOpen4();

        else if (PlayerPrefs.GetInt("materialItemSelect") == 4)
            MaterialItemOpen5();

        else if (PlayerPrefs.GetInt("materialItemSelect") == 5)
            MaterialItemOpen6();


        if (PlayerPrefs.HasKey("materialControlLock1") == false)
            PlayerPrefs.SetInt("materialControlLock1", 0);

        if (PlayerPrefs.HasKey("materialControlLock2") == false)
            PlayerPrefs.SetInt("materialControlLock2", 0);

        if (PlayerPrefs.HasKey("materialControlLock3") == false)
            PlayerPrefs.SetInt("materialControlLock3", 0);

        if (PlayerPrefs.HasKey("materialControlLock4") == false)
            PlayerPrefs.SetInt("materialControlLock4", 0);

        if (PlayerPrefs.HasKey("materialControlLock5") == false)
            PlayerPrefs.SetInt("materialControlLock5", 0);


        if (PlayerPrefs.GetInt("materialControlLock1") == 1)
           materialLock1.SetActive(false);

        if (PlayerPrefs.GetInt("materialControlLock2") == 1)
            materialLock2.SetActive(false);

        if (PlayerPrefs.GetInt("materialControlLock3") == 1)
            materialLock3.SetActive(false);

        if (PlayerPrefs.GetInt("materialControlLock4") == 1)
            materialLock4.SetActive(false);

        if (PlayerPrefs.GetInt("materialControlLock4") == 1)
            materialLock5.SetActive(false);



    }

    public void MaterialItemOpenDeneme(int i)
    {
        List<GameObject> materialItemList = new List<GameObject>()
        {
            materialItem1,
            materialItem2,
            materialItem3,
            materialItem4,
            materialItem5,
            materialItem6
        };
        for (int a = 0; a < materialItemList.Count - 1; i++)
        {
            materialItemList[a].GetComponent<Image>().sprite = Yellow;
            if (a == i) materialItemList[a].GetComponent<Image>().sprite = Green;
        }

        if (i == 0)
        {
            GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material1;

            wingMaterial2.color = new Color32(225, 183, 108, 255);
            fanMaterial2.color = new Color32(225, 183, 108, 255);
            PlayerPrefs.SetInt("materialItemSelect", 0);
        }

        else if (i == 1)
        {
            GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material2;
            wingMaterial2.color = new Color32(225, 183, 108, 255);
            fanMaterial2.color = new Color32(225,183,108,255);
            PlayerPrefs.SetInt("materialItemSelect", 1);
        }
        else if (i == 2)
        {
            GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material3;
            wingMaterial2.color = Color.grey;
            fanMaterial2.color = new Color32(212, 232, 240, 255);
            PlayerPrefs.SetInt("materialItemSelect", 2);
        }else if (i == 3)
        {
            GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material4;
            wingMaterial2.color = Color.yellow;
            fanMaterial2.color = new Color32(226, 213, 42, 255);
            PlayerPrefs.SetInt("materialItemSelect", 3);

        }else if (i == 4)
        {
            GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material5;
            wingMaterial2.color = new Color32(141, 41, 186, 255);
            fanMaterial2.color = new Color32(200, 127, 184, 255);
            PlayerPrefs.SetInt("materialItemSelect", 4);

        }else if (i == 5)
        {
            GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material6;
            wingMaterial2.color = Color.white;
            fanMaterial2.color = Color.white;
            PlayerPrefs.SetInt("materialItemSelect", 4);

        }
    }
    //Material Items
    public void MaterialItemOpen()
    {
        GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material1;
        wingMaterial2.color = new Color32(225, 183, 108, 255);
        fanMaterial2.color = new Color32(225,183,108,255);
        materialItem1.GetComponent<Image>().sprite = Green;
        materialItem2.GetComponent<Image>().sprite = Yellow;
        materialItem3.GetComponent<Image>().sprite = Yellow;
        materialItem4.GetComponent<Image>().sprite = Yellow;
        materialItem5.GetComponent<Image>().sprite = Yellow;
        materialItem6.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("materialItemSelect", 0);

    }

    public void MaterialItemOpen2()
    {
        GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material2;
        wingMaterial2.color = Color.red;
        fanMaterial2.color = Color.red;
        materialItem1.GetComponent<Image>().sprite = Yellow;
        materialItem2.GetComponent<Image>().sprite = Green;
        materialItem3.GetComponent<Image>().sprite = Yellow;
        materialItem4.GetComponent<Image>().sprite = Yellow;
        materialItem5.GetComponent<Image>().sprite = Yellow;
        materialItem6.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("materialItemSelect", 1);
    }

    public void MaterialItemOpen3()
    {
        GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material3;
        wingMaterial2.color = Color.grey;
        fanMaterial2.color = new Color32(212, 232, 240, 255);
        materialItem1.GetComponent<Image>().sprite = Yellow;
        materialItem2.GetComponent<Image>().sprite = Yellow;
        materialItem3.GetComponent<Image>().sprite = Green;
        materialItem4.GetComponent<Image>().sprite = Yellow;
        materialItem5.GetComponent<Image>().sprite = Yellow;
        materialItem6.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("materialItemSelect", 2);
    }

    public void MaterialItemOpen4()
    {
        GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material4;
        wingMaterial2.color = Color.yellow;
        fanMaterial2.color = new Color32(226, 213, 42, 255);
        materialItem1.GetComponent<Image>().sprite = Yellow;
        materialItem2.GetComponent<Image>().sprite = Yellow;
        materialItem3.GetComponent<Image>().sprite = Yellow;
        materialItem4.GetComponent<Image>().sprite = Green;
        materialItem5.GetComponent<Image>().sprite = Yellow;
        materialItem6.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("materialItemSelect", 3);
    }

    public void MaterialItemOpen5()
    {
        GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material5;
        wingMaterial2.color = new Color32(141, 41, 186, 255);
        fanMaterial2.color = new Color32(200, 127, 184, 255);
        materialItem1.GetComponent<Image>().sprite = Yellow;
        materialItem2.GetComponent<Image>().sprite = Yellow;
        materialItem3.GetComponent<Image>().sprite = Yellow;
        materialItem4.GetComponent<Image>().sprite = Yellow;
        materialItem5.GetComponent<Image>().sprite = Green;
        materialItem6.GetComponent<Image>().sprite = Yellow;
        PlayerPrefs.SetInt("materialItemSelect", 4);
    }

    public void MaterialItemOpen6()
    {
        GameObject.FindGameObjectWithTag("refObj").GetComponent<MeshRenderer>().material = Material6;
        wingMaterial2.color = Color.white;
        fanMaterial2.color = Color.white;
        materialItem1.GetComponent<Image>().sprite = Yellow;
        materialItem2.GetComponent<Image>().sprite = Yellow;
        materialItem3.GetComponent<Image>().sprite = Yellow;
        materialItem4.GetComponent<Image>().sprite = Yellow;
        materialItem5.GetComponent<Image>().sprite = Yellow;
        materialItem6.GetComponent<Image>().sprite = Green;
        PlayerPrefs.SetInt("materialItemSelect", 5);
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

    //MATERIAL LOCKS
    public void MaterialLock1Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int materialControlLock1 = PlayerPrefs.GetInt("materialControlLock1");
        if (coin >= 500 && materialControlLock1 == 0)
        {
            materialLock1.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 500);
            PlayerPrefs.SetInt("materialControlLock1", 1);
            MaterialItemOpen2();
            UIManager._instance.CoinUpdate();
        }

    }

    public void MaterialLock2Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int materialControlLock2 = PlayerPrefs.GetInt("materialControlLock2");
        if (coin >= 500 && materialControlLock2 == 0)
        {
            materialLock2.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 500);
            PlayerPrefs.SetInt("materialControlLock2", 1);
            MaterialItemOpen3();
            UIManager._instance.CoinUpdate();
        }

    }

    public void MaterialLock3Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int materialControlLock3 = PlayerPrefs.GetInt("materialControlLock3");
        if (coin >= 500 && materialControlLock3 == 0)
        {
            materialLock3.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 500);
            PlayerPrefs.SetInt("materialControlLock3", 1);
            MaterialItemOpen4();
            UIManager._instance.CoinUpdate();
        }

    }

    public void MaterialLock4Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int materialControlLock4 = PlayerPrefs.GetInt("materialControlLock4");
        if (coin >= 500 && materialControlLock4 == 0)
        {
            materialLock4.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 500);
            PlayerPrefs.SetInt("materialControlLock4", 1);
            MaterialItemOpen5();
            UIManager._instance.CoinUpdate();
        }

    }

    public void MaterialLock5Open()
    {
        int coin = PlayerPrefs.GetInt("coinn");
        int materialControlLock5 = PlayerPrefs.GetInt("materialControlLock5");
        if (coin >= 500 && materialControlLock5 == 0)
        {
            materialLock5.SetActive(false);
            PlayerPrefs.SetInt("coinn", coin - 500);
            PlayerPrefs.SetInt("materialControlLock5", 1);
            MaterialItemOpen6();
            UIManager._instance.CoinUpdate();
        }

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
