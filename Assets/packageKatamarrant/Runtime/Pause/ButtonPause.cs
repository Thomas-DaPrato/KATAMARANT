using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPause : MonoBehaviour
{
    public GameObject pause;

    public void Pause(){
        Player.isInPause = false;
        pause.SetActive(false);
    }
}
