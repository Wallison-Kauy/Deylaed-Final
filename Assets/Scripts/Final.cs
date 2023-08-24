using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Final : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Invoke("callCredits", 6f);

    }

    //

    void callCredits()
    {
        SceneManager.LoadScene("Creditos");
    }


}
