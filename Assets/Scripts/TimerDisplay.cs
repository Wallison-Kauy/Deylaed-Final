using UnityEngine;
using UnityEngine.UI;
using Text = UnityEngine.UI.Text;

using static System.Net.Mime.MediaTypeNames;

public class TimerDisplay : MonoBehaviour
{
    private Text timerText;  // ReferÍncia ao componente Text
    private Timer timer;     // ReferÍncia ao script Timer

    void Start()
    {
        timerText = GetComponent<Text>();
        timer = FindObjectOfType<Timer>();
    }

    void Update()
    {
        if (timer != null)
        {
            // Aqui, formatamos o tempo para mostrar apenas duas casas decimais
            timerText.text = "Time: " + timer.CurrentTime.ToString("F2");
        }
    }
}