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

    public void Start(){
        if(!isInitiate){
            DontDestroyOnLoad(gameObject);
            GameObject player = Resources.Load("Prefabs/Entities/Player/Player") as GameObject;
            player = Instantiate(player);
            player.name = "Player";
            player.transform.SetParent(gameObject.transform);
            player.GetComponent<Player>().initPlayer(this);

            for(int i = 0; i < gameObject.transform.childCount; i +=1 ){
                componentsInRoom.Add(gameObject.transform.GetChild(i).gameObject);
            }
            isInitiate = true;
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
