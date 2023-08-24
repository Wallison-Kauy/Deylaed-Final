using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] private int health = 100;
    [SerializeField] private float ResetColorAfterDamage = 0.2f;

    private int MAX_HEALTH = 100;

    public static event Action OnPlayerDeath;
    private SpriteRenderer spriteRenderer;

    // Getter para MAX_HEALTH
    public int MaxHealth
    {
        get { return MAX_HEALTH; }
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            // Damage(10);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            // Heal(10);
        }
    }

    public void SetHealth(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }
        UnityEngine.Debug.Log("Aplicando dano ao objeto: " + gameObject.name + ". A vida estava: " + this.health + " agora está: " + (this.health - amount) + ". Foi aplicado um total de: " + amount);
        this.health -= amount;

        Color softRed = new Color(1f, 0.5f, 0.5f, 1f); // Esta cor é um vermelho mais claro

        // Mude a cor do objeto para vermelho ao receber dano
        spriteRenderer.color = softRed;
        // Comece a coroutine para reverter a cor após 1 segundo.
        StartCoroutine(ResetColorAfterDelay(ResetColorAfterDamage));

        if (health <= 0)
        {
            Die();
        }
    }

    private IEnumerator ResetColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.color = Color.white;
    }


    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

        bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health = MAX_HEALTH;
        }
        else
        {
            this.health += amount;
        }
    }

    private void Die()
    {
        if (this.CompareTag("Player"))
        {
            Destroy(gameObject);
            OnPlayerDeath?.Invoke();
        }else
        {
            UnityEngine.Debug.Log("I am Dead!");
            Destroy(gameObject);
        }
        
    }
}