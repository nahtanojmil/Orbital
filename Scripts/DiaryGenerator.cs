using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DiaryGenerator : MonoBehaviour {
    string[] misc = new string[2];
    string[] warning = new string[13];
    string[] penalty = new string[2];
    string[] random = new string[5];

	void Start () {
        misc[0] = "I'm so bored. ";
        misc[1] = "Gotta get outta this place... ";

        penalty[0] = "Last night was really cold. \r\n";
        penalty[1] = "it was warm. \r\n";

        //water warning
        warning[0] = "Getting abit thirsty. \r\n";
        warning[1] = "Yearning for some water... \r\n";
        warning[2] = "My throat feels parch. ";
        warning[3] = "I need water.";
        warning[4] = "I won’t last any longer if I don’t drink soon. \r\n";

        //warmth warning
        warning[5] ="Tonight feels chilly. ";
        warning[6] = "Should get a fire started… \r\n";
        warning[7] = "Barely survived the cold last night. \r\n";
        warning[8] = "Going to die of hypothermia. \r\n";

        //food warning
        warning[9] = "I got the munchies. \r\n";
        warning[10] = "Damn I need a burger.. \r\n";
        warning[11] = "I really need to catch some animals. \r\n";
        warning[12] = "If I don't eat soon I won't survive the night. \r\n";

        //for random event
        // 0 -> 2 add food or lose health
        random[0] = "Found many of orange-yellow berries on a  \r\n woody vine. Should I eat? [Y/N]";
        random[1] = "Found strawberry like berries.. Eat? \r\n [Y/N]";
        random[2] = "Found a beehive. Attempt to Collect? \r\n [Y/N]";
        random[3] = "Monkeys have stolen my food!"; //remove all food
        random[4] = "Vase got broken by falling branch!"; //lose vase and water
    }
    public string generateDiary(int satiety, int warmth, int health, int hydration)
    {
        string diaryEntry;
        diaryEntry = generateWarning(satiety, hydration, warmth) + generateRambling();
        return diaryEntry;
    }
    public string generateRandomEvent(int consequence)
    {
        return random[consequence];
    }
    //if option == 1, YES. if option == 0, NO
    //if this func return 0 to YES or No btn, nothing happens
    public int riskyEvent(int consequence)
    {
        int num = 0, chance = 0;
        if (consequence <= 2)
        {
            chance = Random.Range(0, 100);
            if (chance <= 30)
                num = Random.Range(10, 16); //gain food
            else num = Random.Range(-10, -16); // lose health
        }
        return num;
    }
	
    private string generateWarning(int satiety, int hydration, int warmth)
    {
        string message = null;
        //should do a switch case for this...
        if (satiety <= 5)
        {
            message += warning[12];
        }
        else if (satiety <= 15)
        {
            message += warning[11];
        }
        else if (satiety <= 35)
        {
            message += warning[10];
        }
        else message += warning[9];

        if (hydration <= 5)
        {
            message += warning[4];
        }
        else if (hydration <= 15)
        {
            message += warning[3];
        }
        else if (hydration <= 35)
        {
            message += warning[1];
        }
        else message += warning[0];

        if (warmth <= 5)
        {
            message += warning[8];
        }
        else if (warmth <= 15)
        {
            message += warning[7];
        }
        else if (warmth <= 35)
        {
            message += warning[6];
        }
        else message += warning[5];
        return message;
    }

    private string generateRambling()
    {
        return misc[Random.Range(0, 2)];
    }

 /*   private string generatePenalty()
    {

    } */
} 
