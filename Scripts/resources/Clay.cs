using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clay : MonoBehaviour {

    private Inventory inventory;
    private Player player;
    private UIManager uimanager;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent("Player") as Player;
        inventory = GameObject.Find("InventoryManager").GetComponent("Inventory") as Inventory;
        uimanager = GameObject.Find("UIManager").GetComponent("UIManager") as UIManager;
    }

    void OnMouseDown()
    {
        player.isChoppingClay();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.choppingClay)
            {
                gameObject.SetActive(false);
                inventory.AddClay(3);
                uimanager.TakeAction();
                player.choppingClay = false;
            }
        }
    }
}
