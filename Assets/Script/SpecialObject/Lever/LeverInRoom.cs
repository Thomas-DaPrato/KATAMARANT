using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player"){
            print("prise de l'objet");
            Player.inventorySpecialObject.Add("lever");
            Destroy(gameObject);
            foreach(GameObject go in RoomManager.componentsInRoom)
                if(go.name == "Lever"){
                    RoomManager.componentsInRoom.Remove(go);
                    break;
                }
            print(Player.inventorySpecialObject[0]);
        }
    }
}
