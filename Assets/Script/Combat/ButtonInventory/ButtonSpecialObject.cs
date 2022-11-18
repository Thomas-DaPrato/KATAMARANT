using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSpecialObject : MonoBehaviour
{
    public void DisplayInventory(){
        FightManager.inventoryBag.SetActive(false);
        FightManager.inventorySpecialObject.SetActive(true);
    }
}
