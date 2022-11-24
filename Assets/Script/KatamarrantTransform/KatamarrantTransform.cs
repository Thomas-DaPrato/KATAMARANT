using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatamarrantTransform : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player"){
            print("merde");
            gameObject.GetComponent<Animator>().SetBool("transform", true);
        }
    }
}
