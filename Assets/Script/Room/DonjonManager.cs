using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonjonManager : MonoBehaviour
{
    public static Dictionary<String, GameObject> rooms = new Dictionary<string, GameObject>();

    public void Start(){
            rooms.Add("room1",Instantiate(Resources.Load("Prefabs/Donjon/Rooms/Room1") as GameObject));
            rooms["room1"].name = "Room1";
    }
}
