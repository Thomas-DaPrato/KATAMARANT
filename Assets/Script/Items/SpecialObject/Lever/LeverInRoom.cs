using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player"){
            print("prise de l'objet");
            Player.inventorySpecialObject.Add("lever");
            DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom.Remove(gameObject);
            Destroy(gameObject);
            print(Player.inventorySpecialObject[0]);
        }
    }
}
