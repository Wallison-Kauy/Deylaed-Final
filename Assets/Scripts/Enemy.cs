using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    private float speed = 1.5f;
    private float damageCooldown = 0.5f; // Tempo em segundos entre cada aplicação de dano.
    private float nextDamageTime = 0;    // Quando o próximo dano pode ser aplicado.

    [SerializeField]
    private bool isLethal = false;

    [SerializeField]
    private EnemyData data;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLethal)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLethal)
        {
            Swarm();
        }
    }

    private void SetEnemyValues()
    {
        Health healthComponent = GetComponent<Health>();

        if (healthComponent == null)
        {
            // Se o componente Health não existir, adicioná-lo ao GameObject.
            healthComponent = gameObject.AddComponent<Health>();

            // Defina a vida padrão como 10.
            healthComponent.SetHealth(10, 10);
        }
        else
        {
            healthComponent.SetHealth(data.hp, data.hp);
        }

        damage = data.damage;
        speed = data.speed;
    }

    

    private void Swarm()
    {
        if(player.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

   

    void OnCollisionStay2D(Collision2D collision)
    {
        // Se não for hora de aplicar dano ainda, saia do método.
        if (Time.time < nextDamageTime)
        {
            return;
        }

        // Verifica se o objeto colidido tem a tag "Enemy" ou é o próprio objeto.
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject == this.gameObject || collision.gameObject.CompareTag("Car"))
        {
            return; // Se for verdade, sai sem aplicar dano.
        }

        if (isLethal && collision.gameObject.CompareTag("Player"))
        {
            UnityEngine.Debug.Log("Inimigo letal atingiu o jogador!");
            Health playerHealth = collision.gameObject.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.Damage(playerHealth.MaxHealth); // Use o getter MaxHealth como mencionado anteriormente.
            }
            return;
        }

        // Continua com a aplicação do dano.
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            UnityEngine.Debug.Log("Aplicando dano");
            collision.gameObject.GetComponent<Health>().Damage(damage);
            nextDamageTime = Time.time + damageCooldown; // Define a próxima vez que o dano pode ser aplicado.
        }
    }


}