using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KatamarrantTransform : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player"){
            gameObject.GetComponent<Animator>().SetBool("transform", true);
            StartCoroutine(LaunchEndGame());
        }
    }

    public IEnumerator LaunchEndGame(){
        yield return new WaitForSeconds(5);
        Destroy(DonjonManager.player);
        Destroy(GameObject.Find("DonjonManager"));
        SceneManager.LoadScene("EndScene");
    }
}
