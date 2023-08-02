using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapisBullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 15;
    [SerializeField]
    private int damage = 5;
    [SerializeField]
    public float lifespan = 3f;
    private Vector2 dir;


    // Start is called before the first frame update
    void Start()
    {
        dir = GameObject.Find("Dir").transform.position;
        transform.position = GameObject.Find("FirePoint").transform.position;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        LookAt2D(dir);

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }

    private void LookAt2D(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 180, Vector3.forward);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        UnityEngine.Debug.Log("Entrou para dar dano");

        // Ignora colisões com o objeto que lançou a bala
        if (collision.gameObject == this.gameObject)
        {
            return;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            return; // Retorna sem aplicar o dano ao objeto do jogador
        }

        if (collision.gameObject.GetComponent<Health>() != null)
        {
            collision.gameObject.GetComponent<Health>().Damage(damage);
            Destroy(gameObject);
        }
    }



}


