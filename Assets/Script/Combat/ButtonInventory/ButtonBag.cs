using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBag : MonoBehaviour
{
    public void DisplayInventory(){
        FightManager1Vs1.inventoryBag.SetActive(true);
        FightManager1Vs1.inventorySpecialObject.SetActive(false);
    }
}
