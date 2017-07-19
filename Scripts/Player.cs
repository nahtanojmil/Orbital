using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{

    public LayerMask treeLayer;
    public Inventory inventory;
    public GameObject fire, vase, trap;
    public UIManager uimanager;
    public bool idle, choppingWood, choppingClay;
    public int health, satiety, hydration, warmth;

    private int timer = 0;
    private Vector3 move;
    private Vector2 target;

    // Use this for initialization
    void Start()
    {
        health = 50;
        satiety = 50;
        hydration = 31;
        warmth = 50;
        move = new Vector3(0.5f,0,0);
        idle = true;
        choppingWood = false;
        choppingClay = false;
        target = transform.position;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            idle = false;
            target = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        }
        if (!idle)
        {
            target.y = transform.position.y;
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime);
        }
        if (transform.position.x == target.x)
        {
            
                idle = true;
        }
        buildStuff();
        if (idle) IdleMove();
    }

    private void IdleMove()
    {
        transform.Translate(move * Time.deltaTime);
        timer++;
        if (timer == 60)
        {
            int rand = Random.Range(0, 7);
            if (rand <= 2)
                move *= -1;
            timer = 0;
        }
    }
    private void buildStuff()
    {
        if (inventory.makeFire)
        {
            if (inventory.woodCount <= 1 || GameObject.Find("Fire(Clone)")) //create speech bubble, I already have a fire
            {
                idle = true;
                inventory.makeFire = false;
                return;
            }
            Instantiate(fire, new Vector2(1f, -2.3f), Quaternion.identity);
            inventory.AddWood(-2);
            inventory.makeFire = false;
            uimanager.TakeAction();
        }
        if (inventory.makeVase)
        {
            if (inventory.clayCount <= 0 || GameObject.Find("Vase(Clone)")) //create speech bubble
            {
                idle = true;
                inventory.makeVase = false;
                return;
            }
            Instantiate(vase, new Vector2(2f, -2.35f), Quaternion.identity);
            inventory.AddClay(-1);
            inventory.makeVase = false;
            uimanager.TakeAction();
        }
        if (inventory.makeTrap)
        {
            if (inventory.woodCount <= 1 || GameObject.Find("Trap(Clone)")) //create speech bubble
            {
                idle = true;
                inventory.makeTrap = false;
                return;
            }
            Instantiate(trap, new Vector2(-3f, -2.2f), Quaternion.identity);
            inventory.AddWood(-2);
            inventory.makeTrap = false;
            uimanager.TakeAction();
        }
    }

    public void isChoppingWood()
    {
        choppingWood = true;
        Debug.Log("choppingWood = true");
    }
    public void isChoppingClay()
    {
        choppingClay = true;
        Debug.Log("choppingClay = true");
    }

    //methods to access player's stats
    public void Decrement(int i, int j, int k, int l)
    {
        satiety -= i;
        warmth -= j;
        health -= k;
        hydration -= l;
        Debug.Log("satiety minus " + i);
        Debug.Log("warmth minus " + j);
        Debug.Log("health minus " + k);
        Debug.Log("hydration minus " + l);
    }
}
