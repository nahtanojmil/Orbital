using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour {


    private Inventory inventory;
    private int hp;
    private Player player;
    private UIManager uimanager;

    private void Start()
    {
        hp = 3;
        player = GameObject.Find("Player").GetComponent("Player") as Player;
        inventory = GameObject.Find("InventoryManager").GetComponent("Inventory") as Inventory;
        uimanager = GameObject.Find("UIManager").GetComponent("UIManager") as UIManager;
    }

    void OnMouseDown()
    {
        player.isChoppingWood();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (player.choppingWood)
            {
                hp -= 1;
                uimanager.TakeAction();
                player.choppingWood = false;
            }
        }
        if (hp == 0)
        {
            gameObject.SetActive(false);
            inventory.AddWood(3);
        }
    }
}
