using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Door : MonoBehaviour
{
    public string roomBehind;
    public Vector2 coordinatesBehind;

    public void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player" ){
            if(!DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>().enemies){
                GameObject.Find("Player").GetComponent<Player>().map.GetComponent<Map>().ChangeColor(roomBehind);
                DonjonManager.rooms[DonjonManager.currentRoom].SetActive(false);
                DonjonManager.currentRoom = roomBehind;
                DonjonManager.rooms[DonjonManager.currentRoom].SetActive(true);
                Player.coordinates = coordinatesBehind;
                Player.currentRoom = DonjonManager.rooms[DonjonManager.currentRoom].GetComponent<RoomManager>();
                DonjonManager.player.transform.position = Player.coordinates;
                
            }
            else{
                StartCoroutine(DislayMsgDoorBlocked());
            }
            
    
            
        }
    }

    public IEnumerator DislayMsgDoorBlocked(){
        GameObject.Find("Player").GetComponent<Animator>().SetBool("isKnocking", true);
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").GetComponent<Animator>().SetBool("isKnocking", false);
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(true);
        GameObject.Find("Player").GetComponent<Player>().reaction.GetComponentInChildren<TextMeshProUGUI>().text = "Je dois battre tous les ennemis pour ouvrir la porte";
        yield return new WaitForSeconds(1);
        GameObject.Find("Player").GetComponent<Player>().reaction.SetActive(false);
    }
}
