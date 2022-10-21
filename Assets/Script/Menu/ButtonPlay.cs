using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonPlay : MonoBehaviour
{
    public void Play(){
        GameObject donjonManager = Instantiate(Resources.Load("Prefabs/Donjon/DonjonManager") as GameObject);
        donjonManager.name = "DonjonManager";
        DontDestroyOnLoad(donjonManager);
        DonjonManager.currentRoom = "Room1";
        SceneManager.LoadScene("Room");
    }
}
