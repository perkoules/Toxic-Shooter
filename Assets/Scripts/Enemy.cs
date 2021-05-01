using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float rotattingSpeed = 5f;
    public Transform gunJoint, gun, barrel;
    public GameObject enemyProjectile, enemyProjectile2;
    private GameObject player;
    public int health, enemyDamage;
    private Rigidbody2D rb;
    private float fireRate;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Fire", 5f, fireRate);
    }

    void Update()
    {
        if (player != null)
        {
            Vector2 lookDir = (Vector2)player.transform.position - rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle; 
        }
    }

    public void SetUp(EnemySO enemySO)
    {
        health = enemySO.health;
        enemyDamage = enemySO.enemyProjectileDamage;
        fireRate = enemySO.fireRate;
    }

    private void Fire()
    {
        GameObject go = null;
        if (Random.Range(0, 100) > 50)
        {
            go = Instantiate(enemyProjectile, barrel.position, barrel.transform.rotation);
        }
        else
        {
            go = Instantiate(enemyProjectile2, barrel.position, barrel.transform.rotation);
        }
        go.transform.SetParent(null);
        go.GetComponent<Rigidbody2D>().AddForce(barrel.up * 20f, ForceMode2D.Impulse);
        go.GetComponent<EnemyProjectile>().SetDamage(enemyDamage);
    }

    public void DealWithDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
