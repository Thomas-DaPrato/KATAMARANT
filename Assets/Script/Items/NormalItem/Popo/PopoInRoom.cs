using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoInRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            Player.inventoryBag.Add("popo");
            DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
