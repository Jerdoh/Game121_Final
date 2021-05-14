using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamage
{
    public int health = 50;
    public GameObject enemy;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy has taken damage. Health remaining: " + health);
    }

    void Update() {
        if(health <= 0) {
            Destroy(enemy);
            Debug.Log("Enemy has died!");
        }
    }
}
