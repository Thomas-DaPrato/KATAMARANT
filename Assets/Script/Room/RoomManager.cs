using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public int widthRoom = 11;
    public int heightRoom = 11;

    public static bool isInitiate = false;

    public static List<GameObject> componentsInRoom = new List<GameObject>();
    public static GameObject player;

    public void Awake(){
        RoomManager[] allRoomManager = GameObject.FindObjectsOfType<RoomManager>();
        print("go size " + allRoomManager.Length);
        foreach(RoomManager roomManager in allRoomManager){
            if(isInitiate && !roomManager.name.Contains("Original")){
                print(roomManager.name +  " : destroy");
                Destroy(roomManager.gameObject);
            }
                
        }
        InitRoom();
    }

    public void InitRoom(){
            print("start");
            if(!isInitiate){
                print("init");
                gameObject.name = gameObject.name + "Original";
                DontDestroyOnLoad(gameObject);

                player = GameObject.Find("Player");
                player.GetComponent<Player>().initPlayer(this);
                DontDestroyOnLoad(player);

                for(int i = 0; i < gameObject.transform.childCount; i +=1 ){
                    if(gameObject.transform.GetChild(i).gameObject.name != "Player")
                        componentsInRoom.Add(gameObject.transform.GetChild(i).gameObject);
                }
                isInitiate = true; 
            }
            else{
                print("enable");   
                EnableComponentsInRoom();
                Destroy(GameObject.FindGameObjectWithTag("ToFight"));
                foreach(GameObject go in componentsInRoom)
                    if(go.tag == "ToFight"){
                        componentsInRoom.Remove(go);
                        break;
                    }
                        
                player.SetActive(true);
            } 
    }

    public static void EnableComponentsInRoom(){
        foreach(GameObject go in componentsInRoom)
            go.SetActive(true);
    }

    public static void DisableComponentsInRoom(){
        foreach(GameObject go in componentsInRoom)
            go.SetActive(false);   
    } 
}
