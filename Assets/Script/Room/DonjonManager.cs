using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonjonManager : MonoBehaviour
{
    public static Dictionary<String, GameObject> rooms = new Dictionary<string, GameObject>();

    public  static string currentRoom = "";

    public static GameObject player;

    public void Start(){

        for(int i = 1; i < 11; i+=1)
            AddRoom("Room"+i);


        player = Instantiate(Resources.Load("Prefabs/Entities/Player/Player") as GameObject);
        player.name = "Player";
        player.GetComponent<Player>().initPlayer(rooms[currentRoom].GetComponent<RoomManager>(),rooms[currentRoom].GetComponent<RoomManager>().widthRoom/2,0);
        DontDestroyOnLoad(player);
        

    }

    public void AddRoom(String nameRoom){
        rooms.Add(nameRoom, Instantiate(Resources.Load("Prefabs/Donjon/Rooms/" + nameRoom) as GameObject));
        rooms[nameRoom].name = nameRoom;
        rooms[nameRoom].transform.SetParent(gameObject.transform);
        rooms[nameRoom].GetComponent<RoomManager>().InitRoom();
        rooms[nameRoom].SetActive(false);
    }
}
