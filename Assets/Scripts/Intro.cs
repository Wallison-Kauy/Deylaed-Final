using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        Invoke("callGameScene", 54f);

    }

    void Update()
    {
        if (Input.anyKey)
        {
            SceneManager.LoadScene("fase_2");
        }
    }

    void callGameScene()
    {
        SceneManager.LoadScene("fase_2");
    }

    
}
