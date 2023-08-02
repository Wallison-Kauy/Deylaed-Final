using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class Weapon : ScriptableObject

{
    public Sprite currentWeaponSpr;
    public GameObject bulletPrefab;
    public float fireRate = 1;
    public int damage = 20;
    private float lastShotTime = 5f;
    public void Shoot()
    {
        if (Time.time >= lastShotTime + fireRate)
        {
            // Dispara uma bala
            Instantiate(bulletPrefab, GameObject.Find("FirePoint").transform.position, Quaternion.identity);

            // Atualiza o último horário de disparo para o horário atual
            lastShotTime = Time.time;
        }

    }

}
