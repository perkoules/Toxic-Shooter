using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Wave", menuName ="SO/Enemy")]
public class EnemySO : ScriptableObject
{
    public int amountToSpawn;
    public int health;
    public int enemyProjectileDamage;
    public float fireRate;
}
