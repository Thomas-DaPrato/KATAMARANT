using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public static Vector3 coordinates = new Vector3();

    public Room currentRoom;

    public Camera camera;


    public void movePlayer(String direction){
        switch(direction){
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

    }

    public void Start(){
        currentRoom = GameObject.Find("Sol").GetComponent<Room>();
        coordinates = new Vector3(currentRoom.widthRoom/2,0);
    }

    public void Update(){

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

        gameObject.transform.position = coordinates;
        camera.transform.position = new Vector3(coordinates.x,coordinates.y,-10);

    }
}
