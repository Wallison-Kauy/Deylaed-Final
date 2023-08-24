using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("endGame", 6f);

    }

    //

    void endGame()
    {
        SceneManager.LoadScene("Main_Menu");
    }


}
