using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Player : MonoBehaviour
{
    public static Vector2 coordinates = new Vector2();

    public static RoomManager currentRoom;

    public int maxHp;

    public static List<string> inventoryBag;
    public static List<string> inventorySpecialObject;
    public static bool canMove;
    public static bool isInPause;


    public Camera camera;

    public GameObject reaction;

    public GameObject map;

    public GameObject pause;

    public RuntimeAnimatorController animatorInRoom;

    public void movePlayer(String direction){
        switch (direction){
            case "down" :
                if (coordinates.y - 1 >= 0)
                    coordinates.y = coordinates.y -1;
                break;
            case "up" :
                if (coordinates.y + 1 < currentRoom.heightRoom)
                    coordinates.y = coordinates.y +1;
                break;
            case "left" :
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
                if (coordinates.x - 1 >= 0)
                    coordinates.x = coordinates.x -1;
                break;
            case "right" :
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
                if (coordinates.x + 1 < currentRoom.widthRoom)
                    coordinates.x = coordinates.x +1;
                break;
        }



        gameObject.transform.position = coordinates;
        camera.transform.position = new Vector3(coordinates.x,coordinates.y,-10);
        

    }

    public void initPlayer(RoomManager myCurrentRoom, int x, int y){
        inventoryBag = new List<string>(3);
        inventorySpecialObject = new List<string>(3);
        currentRoom = myCurrentRoom;
        coordinates = new Vector2(x,y);
        gameObject.transform.position = coordinates;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = animatorInRoom;
        pause.SetActive(false);
        isInPause = false;
    }

    public void Update(){
        if (!isInPause){
            if(Input.GetKeyDown(KeyCode.Z)){
                movePlayer("up");
            }

            if(Input.GetKeyDown(KeyCode.S)){
                movePlayer("down");
            }

            if(Input.GetKeyDown(KeyCode.D)){
                movePlayer("right");
            }

            if(Input.GetKeyDown(KeyCode.Q)){
                movePlayer("left");
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape)){
            isInPause = !isInPause;
            pause.SetActive(!pause.activeSelf);
        }
        
        

    }


}
