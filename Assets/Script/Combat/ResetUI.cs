using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetUI : MonoBehaviour
{
    public GameObject choiceEnemy;

    public void ResetDisplayUI(){
        if(choiceEnemy != null){
            choiceEnemy.SetActive(false);
        }

        FightManager.listOffensiveAttack.SetActive(false);
        FightManager.listSecretTechnic.SetActive(false);
        FightManager.listInventory.SetActive(false);
        FightManager.inventoryBag.SetActive(false);
        FightManager.inventorySpecialObject.SetActive(false);
    }
}
