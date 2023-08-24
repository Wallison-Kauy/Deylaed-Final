using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class vitoria : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se o objeto colidido tem a tag "Player" ou é o próprio objeto.
        if (collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Colidiu");
            Invoke("callEndGameScene", 0.5f);
        }
    }

    void callEndGameScene()
    {
        SceneManager.LoadScene("Vitoria");
    }

}
