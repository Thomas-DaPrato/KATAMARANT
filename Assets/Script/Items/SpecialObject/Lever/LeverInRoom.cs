using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverInRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player"){
            Player.inventorySpecialObject.Add("lever");
            DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
