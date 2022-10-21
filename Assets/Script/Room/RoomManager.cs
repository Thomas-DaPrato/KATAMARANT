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
    


    public void InitRoom(){
        for(int i = 0; i < gameObject.transform.childCount; i +=1 ){
            componentsInRoom.Add(gameObject.transform.GetChild(i).gameObject);
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
