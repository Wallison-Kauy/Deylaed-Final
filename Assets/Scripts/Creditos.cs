using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Creditos : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("callEndGameScene", 42f);
    }

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Main_Menu");
        }
    }

    void callEndGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
