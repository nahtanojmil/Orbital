using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int woodCount, stoneCount, clayCount, leatherCount, waterCount, foodCount;

    //crafting page
    public GameObject woodPage, stonePage, clayPage, leatherPage, collectPage, cantCollectPage;

    public Text woodDisplay, stoneDisplay, clayDisplay, leatherDisplay, waterDisplay, foodDisplay;

    public bool makeFire, makeVase, makeTrap;

    private void Awake()
    {
        woodPage.SetActive(false);
        clayPage.SetActive(false);
        collectPage.SetActive(false);
        cantCollectPage.SetActive(false);
        //stonePage.SetActive(false);
        //leatherPage.SetActive(false);
    }

    private void Start()
    {
        makeFire = false;
        makeVase = false;
        makeTrap = false;
        woodCount = 0;
        stoneCount = 0;
        clayCount = 0;
        leatherCount = 0;
        waterCount = 0;
        foodCount = 0;
        foodDisplay.text = foodCount.ToString() + " Food";
        waterDisplay.text = waterCount.ToString() + " Water";
        woodDisplay.text = woodCount.ToString() + " Wood";
        stoneDisplay.text = woodCount.ToString() + " Stone";
        clayDisplay.text = woodCount.ToString() + " Clay";
        leatherDisplay.text = woodCount.ToString() + " Leather";
    }

    public void AddWood(int count)
    {
        woodCount += count;
        woodDisplay.text = woodCount.ToString() + " Wood";
    }
    public void AddStone(int count)
    {
        stoneCount += count;
        stoneDisplay.text = stoneCount.ToString() + " Stone";
    }
    public void AddClay(int count)
    {
        clayCount += count;
        clayDisplay.text = clayCount.ToString() + " Clay";
    }
    public void AddLeather(int count)
    {
        leatherCount += count;
        leatherDisplay.text = leatherCount.ToString() + " Leather";
    }
    public void CollectWater()
    {
        waterCount += 3;
        waterDisplay.text = waterCount.ToString() + " Water";
    }
    public void AddWater(int count)
    {
        waterCount += count;
        waterDisplay.text = waterCount.ToString() + " Water";
    }
    public void AddFood(int count)
    {
        foodCount += count;
        foodDisplay.text = foodCount.ToString() + " Food";
    }


    public void SelectWood()
    {
        woodPage.SetActive(true);
    }
    public void SelectStone()
    {
        stonePage.SetActive(true);
    }
    public void SelectClay()
    {
        clayPage.SetActive(true);
    }
    public void SelectLeather()
    {
        leatherPage.SetActive(true);
    }


    public void MakeFire()
    {
        woodPage.SetActive(false);
        makeFire = true;
    }
    public void MakeVase()
    {
        clayPage.SetActive(false);
        makeVase = true;

    }
    public void MakeTrap()
    {
        woodPage.SetActive(false);
        makeTrap = true;
    }


    IEnumerator Deselect(bool item)
    {
        yield return new WaitForSecondsRealtime(3);
        Debug.Log("unselected");
    }


    public void closeWoodPage()
    {
        woodPage.SetActive(false);
    }
    public void closeStonePage()
    {
        stonePage.SetActive(false);
    }
    public void closeClayPage()
    {
        clayPage.SetActive(false);
    }
    public void closeLeatherPage()
    {
        leatherPage.SetActive(false);
    }
    public void closeCollectPage()
    {
        collectPage.SetActive(false);
    }
    public void closeCantCollectPage()
    {
        cantCollectPage.SetActive(false);
    }
}