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
    public bool enemies = false;

    public GameObject spawnLever;

    public List<GameObject> componentsInRoom = new List<GameObject>();
    


    public void InitRoom(){
        for(int i = 0; i < gameObject.transform.childCount; i +=1 ){
            componentsInRoom.Add(gameObject.transform.GetChild(i).gameObject);
        }
        if(GameObject.Find("Spawn") != null){
            print(gameObject.name);
            for (int i = 0; i < GameObject.Find("Spawn").transform.childCount; i += 1)
                GameObject.Find("Spawn").transform.GetChild(i).GetComponent<SpawnPassifMob>().Spawn();
        }
            
             
    }


}
