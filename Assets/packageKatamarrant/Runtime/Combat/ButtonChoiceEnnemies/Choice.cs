using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public GameObject buttonChoiceEnemy1;
    public GameObject buttonChoiceEnemy2;
    public GameObject buttonChoiceEnemy3;
    public void InitChoice(){
        if(buttonChoiceEnemy1 != null)
            buttonChoiceEnemy1.GetComponent<Image>().sprite = FightManager.enemies[0].GetComponent<SpriteRenderer>().sprite;
        if(buttonChoiceEnemy2 != null)
            buttonChoiceEnemy2.GetComponent<Image>().sprite = FightManager.enemies[1].GetComponent<SpriteRenderer>().sprite;
        if(buttonChoiceEnemy3 != null)
            buttonChoiceEnemy3.GetComponent<Image>().sprite = FightManager.enemies[2].GetComponent<SpriteRenderer>().sprite;
    }

    public void DisableChoice(int i){
        if (i == 0 && buttonChoiceEnemy1 != null)
            buttonChoiceEnemy1.SetActive(false);
        if (i == 1 && buttonChoiceEnemy2 != null)
            buttonChoiceEnemy2.SetActive(false);
        if (i == 2 && buttonChoiceEnemy3 != null)
            buttonChoiceEnemy3.SetActive(false);
    }
    
}
