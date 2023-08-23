using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void PlayGame()
    {
        //Ativando a cena de jogo
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main_Menu");

    }

        public void QuitGame()
    {
        //Saindo do jogo
        Application.Quit();
    }
}
