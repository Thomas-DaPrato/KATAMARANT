using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonMenu : MonoBehaviour
{
    
    public void Menu(){
        if (Player.isInPause){
            Destroy(DonjonManager.player);
            Destroy(GameObject.Find("DonjonManager"));
        }
            
        SceneManager.LoadScene("Menu");
    }

}
