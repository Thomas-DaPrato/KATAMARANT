using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Vector3 coordinates = new Vector3();

    public Enemies(int x, int y){
        coordinates.x = x;
        coordinates.y = y;
    }

    void OnTriggerEnter2D(Collider2D col){
        print(col.name);
        if(col.name == "Player")
            print("combat");
    }
}
