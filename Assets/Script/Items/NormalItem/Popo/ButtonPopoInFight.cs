using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPopoInFight : MonoBehaviour
{
    public GameObject playerDislpay;

    public void Start()
    {
        playerDislpay = GameObject.Find("PlayerDisplay");
    }
    public void PopoInFight()
    {
        if(FightManager.endOfFightTuto && FightManager.canClickOnButton){
            FightManager.actions.Insert(0,new PopoInFight(playerDislpay));
            Destroy(gameObject);
        }
        
    }

    
}
