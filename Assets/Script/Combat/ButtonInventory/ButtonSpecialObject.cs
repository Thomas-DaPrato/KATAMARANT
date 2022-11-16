using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpecialObject : MonoBehaviour
{
    public void DisplayInventory(){
        FightManager1Vs1.inventoryBag.SetActive(false);
        FightManager1Vs1.inventorySpecialObject.SetActive(true);
    }
}
