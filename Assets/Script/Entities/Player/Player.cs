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

    public static List<string> inventoryBag = new List<string>(3);
    public static List<string> inventorySpecialObject = new List<string>(3);
    public static bool canMove = true;


    public Camera camera;

    public GameObject reaction;

    public GameObject map;

    public RuntimeAnimatorController animatorInRoom;

    public void movePlayer(String direction){
        StartCoroutine(WalkAnimation());
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
        currentRoom = myCurrentRoom;
        coordinates = new Vector2(x,y);
        gameObject.transform.position = coordinates;
        gameObject.GetComponent<Animator>().runtimeAnimatorController = animatorInRoom;

    }

    public void Update(){

        if(Input.GetKey(KeyCode.Z)){
            canMove = false;
            movePlayer("up");
        }

        if(Input.GetKey(KeyCode.S)){
            canMove = false;
            movePlayer("down");
        }

        if(Input.GetKey(KeyCode.D)){
            canMove = false;
            movePlayer("right");
        }

        if(Input.GetKey(KeyCode.Q)){
            canMove = false;
            movePlayer("left");
        }
        

    }

    public IEnumerator WalkAnimation(){
        print("yolo");
        gameObject.GetComponent<Animator>().SetBool("walking", true);
        yield return new WaitForSeconds(0.3f);
        gameObject.GetComponent<Animator>().SetBool("walking", false);
        canMove = true;
    }

}
