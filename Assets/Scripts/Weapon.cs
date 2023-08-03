using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject

{
    public Sprite currentWeaponSpr;
    public GameObject bulletPrefab;
    [SerializeField]
    public float fireRate = 1;
    [SerializeField]
    public int damage = 20;
    [SerializeField]
    private float lastShotTime = 2f;
    public void Shoot()
    {       // Dispara uma bala
            Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);

            // Atualiza o último horário de disparo para o horário atual
            lastShotTime = Time.time;

    }

}
