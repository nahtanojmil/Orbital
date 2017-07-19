using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text countDay;
    public Text diary, random, dead;
    public Text countActions;
    public GameObject diaryPage, sprungTrap, RandomPage, yesbtn, closebtn, nobtn, deadpage;
    public Player PlayerScript;
    public bool nextDay;

    private DiaryGenerator diaryGenerator;
    private int count, actions, consequence;
    private Inventory inventory;

    private void Awake()
    {
        HideDiary();
        RandomPage.SetActive(false);
        deadpage.SetActive(false);
        diaryGenerator = GetComponent<DiaryGenerator>();
        inventory = GameObject.Find("InventoryManager").GetComponent("Inventory") as Inventory;
    }
    private void Start()
    {
        nextDay = false;
        actions = 5;
        count = 1;
        consequence = 0;
        countActions.text = "Actions left: " + actions.ToString();
        countDay.text = "Day " + count.ToString();
    }


    public void NextDay ()
    {
        nextDay = true;
        count += 1;
        actions = 5;
        countDay.text = "Day " + count.ToString();
        countActions.text = "Actions left: " + actions.ToString();
        diaryPage.SetActive(true);
        if (GameObject.Find("Fire(Clone)"))
        {
            Destroy(GameObject.Find("Fire(Clone)"));
        }
        if (GameObject.Find("Trap(Clone)"))
        {
            int rand = Random.Range(0,100);
            if (rand <= 30)
            {
                Destroy(GameObject.Find("Trap(Clone)"));
                Instantiate(sprungTrap, new Vector2(-3, -2.2f), Quaternion.identity);
            }
        }
        UpdatePlayerandDiary(count);
        Debug.Log("Satiety " + PlayerScript.satiety);
        Debug.Log("Warmth " + PlayerScript.warmth);
        Debug.Log("Hydration " + PlayerScript.hydration);
        Debug.Log("Health" + PlayerScript.health);
        CheckIfDead();

    }


    private void GenerateMsgs()
    {
        
    }


    public void HideDiary()
    {
        diaryPage.SetActive(false);
    }


    public void UpdatePlayerandDiary(int count)
    {
        Consume();
        PlayerScript.Decrement(5, 0, 0, 15);
        int satiety = PlayerScript.satiety;
        int warmth = PlayerScript.warmth;
        int health = PlayerScript.health;
        int hydration = PlayerScript.hydration;
        diary.text = "Dear diary, today is day " + count + ". \r\n"  + diaryGenerator.generateDiary(satiety, warmth, health, hydration);
    }
    public void Consume()
    {
        while (PlayerScript.satiety < 50 && inventory.foodCount != 0)
        {
            PlayerScript.satiety += 5;
            inventory.AddFood(-1);
        }
        while (PlayerScript.hydration < 60 && inventory.waterCount != 0)
        {
            PlayerScript.hydration += 10;
            inventory.AddWater(-1);
        }
        if (PlayerScript.satiety > 50)
            PlayerScript.satiety = 50;
        if (PlayerScript.hydration > 50)
            PlayerScript.hydration = 50;
        if (GameObject.Find("Fire(Clone)"))
        {
            PlayerScript.warmth = 50;
        }
    }


    private void Update()
    {
        if (actions == 0)
            NextDay();
    }
    public void TakeAction()
    {
        int chance = 0;
        actions -= 1;
        countActions.text = "Actions left: " + actions.ToString();
        chance = Random.Range(0, 100);
        if (chance <= 30) // 30% chance of random event being generated
        {
            consequence = Random.Range(0, 5);
            RandomPage.SetActive(true);
            if (consequence <= 2) // yes no situation
            {
                yesbtn.SetActive(true);
                nobtn.SetActive(true);
                closebtn.SetActive(false);
            }
            else
            {
                yesbtn.SetActive(false);
                nobtn.SetActive(false);
            }
            random.text = diaryGenerator.generateRandomEvent(consequence);
        }
    }
    public void ifYes()
    {
        int con = diaryGenerator.riskyEvent(consequence);
        yesbtn.SetActive(false);
        nobtn.SetActive(false);
        closebtn.SetActive(true);
        if (con == 0)
            random.text = "Nothing happened";
        else
        {
            if (con > 0)
            {
                PlayerScript.satiety += con;
                random.text = "You feel fuller.";
            }
            else
            {
                PlayerScript.health += con;
                random.text = "You lose some health.";
            }
        }
    }
    public void ifNo()
    {
        int con = diaryGenerator.riskyEvent(consequence);
        yesbtn.SetActive(false);
        nobtn.SetActive(false);
        closebtn.SetActive(true);
        if (con == 0)
            random.text = "Nothing happened";
        else
        {
            if (con > 0)
            {
                PlayerScript.satiety += con;
                random.text = "You feel fuller.";
            }
            else
            {
                PlayerScript.health += con;
                random.text = "You lose some health.";
            }
        }
    }
    public void closeRandomPage()
    {
        RandomPage.SetActive(false);
    }
    private void CheckIfDead()
    {
        if (PlayerScript.hydration <= 0 || PlayerScript.warmth <= 0 || PlayerScript.health <= 0 || PlayerScript.satiety <= 0)
        {
            deadpage.SetActive(true);
            dead.text = "You are dead mother fucker";
        }
    }
}
