using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string roomBehind;
    public Vector2 coordinatesBehind;

    public void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player" ){
            if(!DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().enemies){
                DonjonManager.rooms[DonjonManager.currentRoom].SetActive(false);
                DonjonManager.currentRoom = roomBehind;
                DonjonManager.rooms[DonjonManager.currentRoom].SetActive(true);
                Player.coordinates = coordinatesBehind;
                Player.currentRoom = DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>();
                DonjonManager.player.transform.position = Player.coordinates;
            }
            else
                print("porte fermé. battez tous les ennemis de la salle pour la dévérouillée");
            
        }
    }
}
