using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 0;
    private void Start()
    {
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<Player>().DealWithDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int enemyDamage)
    {
        damage = enemyDamage;
    }
}
