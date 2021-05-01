using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    public Rigidbody2D rb;
    public int damage = 0;
    private void Start()
    {
        Destroy(gameObject, 2f);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().DealWithDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDamage(int enemyDamage)
    {
        damage = enemyDamage;
    }
}
