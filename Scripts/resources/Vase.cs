using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vase : MonoBehaviour {

    private Inventory inventory;
    private GameObject collectBtn;
    private UIManager uimanager;

    public bool harden;
   
	void Start () {
        inventory = GameObject.Find("InventoryManager").GetComponent("Inventory") as Inventory;
        uimanager = GameObject.Find("UIManager").GetComponent("UIManager") as UIManager;
    }

    private void OnMouseDown()
    {
        if (harden)
        {
            inventory.collectPage.SetActive(true);
        }
        else
        {
            Destroy(gameObject);
            inventory.cantCollectPage.SetActive(true);
        }

    }
    public void Harden()
    {
        if (GameObject.Find("Fire(Clone)"))
        {
            harden = true;
        }
        uimanager.nextDay = false;
    }
    private void Update()
    {
        if(uimanager.nextDay)
        {
            Harden();
        }
    }
}
