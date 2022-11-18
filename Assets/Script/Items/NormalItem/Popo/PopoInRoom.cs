using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopoInRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "Player")
        {
            print("prise de l'objet");
            Player.inventoryBag.Add("popo");
            Destroy(gameObject);
            foreach (GameObject go in DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom)
                if (go.name == "PopoInRoom")
                {
                    DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().componentsInRoom.Remove(go);
                    break;
                }
            print(Player.inventoryBag[0]);
        }
    }
}
