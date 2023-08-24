using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool runningTimer;
    public float maxTime = 50;

    private float currentTime;
    private Health playerHealth; // Refer�ncia ao componente de sa�de do jogador

    // Propriedade para acessar currentTime de outros scripts
    public float CurrentTime
    {
        get { return currentTime; }
    }

    void Start()
    {
        currentTime = maxTime;
        runningTimer = true;

        // Obtenha a refer�ncia ao componente de sa�de do jogador
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
    }

    void Update()
    {
        // Verificar se o componente de sa�de do jogador � nulo. Se for, tente encontr�-lo novamente.
        if (playerHealth == null)
        {
            playerHealth = GameObject.FindGameObjectWithTag("Player")?.GetComponent<Health>();

            // Se ainda n�o encontrarmos o jogador, simplesmente retornamos e n�o executamos o restante do c�digo Update.
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

            // Se o player ainda estiver vivo, mat�-lo.
            playerHealth.Damage(playerHealth.MaxHealth);
        }
    }
}