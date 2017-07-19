using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprung : MonoBehaviour {

    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.Find("InventoryManager").GetComponent("Inventory") as Inventory;
    }
    public void OnMouseDown()
    {
        Destroy(gameObject);
        inventory.AddFood(3);
    }
}
