using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public string roomBehind;
    public Vector2 coordinatesBehind;

    public void OnTriggerEnter2D(Collider2D col){
        if(col.name == "Player"){
            SceneManager.LoadScene(roomBehind);
        }
    }
}
