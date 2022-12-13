using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayEndText : MonoBehaviour
{
    public static bool gameOver;

    public GameObject gameOverText;
    public GameObject gameWinText;

    public void Start(){
        if (gameOver)
            gameOverText.SetActive(true);
        else
            gameWinText.SetActive(true);
    }
}
