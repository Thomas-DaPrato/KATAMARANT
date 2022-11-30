using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeStatus : MonoBehaviour { 

    public Sprite buff;
    public Sprite stunt;

    public void ChangeStatusToStunt(){
        gameObject.GetComponent<Image>().sprite = stunt;
    }

    public void ChangeStatusToBuff(){
        gameObject.GetComponent<Image>().sprite = buff;
    }

    public void DisableStatus(){
        gameObject.SetActive(false);
    }

    public void EnableStatus(){
        gameObject.SetActive(true);
    }

}
