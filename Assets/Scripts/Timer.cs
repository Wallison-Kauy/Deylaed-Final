using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool runningTimer;
    public float maxTime = 50;

    private float currentTime;
    private Health playerHealth; // Referência ao componente de saúde do jogador

    // Propriedade para acessar currentTime de outros scripts
    public float CurrentTime
    {
        get { return currentTime; }
    }

    void Start()
    {
        currentTime = maxTime;
        runningTimer = true;

        // Obtenha a referência ao componente de saúde do jogador
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        // Verificar se o componente de saúde do jogador é nulo. Se for, tente encontrá-lo novamente.
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

            // Se ainda não encontrarmos o jogador, simplesmente retornamos e não executamos o restante do código Update.
            if (playerHealth == null)
            {
                return;
            }
        }

        currentTime -= Time.deltaTime;
        UnityEngine.Debug.Log(currentTime);

        if (currentTime <= 0 && runningTimer)
        {
            runningTimer = false;

            // Se o player ainda estiver vivo, matá-lo.
            playerHealth.Damage(playerHealth.MaxHealth);
        }
    }
}