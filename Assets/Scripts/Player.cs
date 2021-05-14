using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamage
{
    public int health = 500;
    
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Player has taken damage. Health remaining :" + health);
    }

    void Update() {
        if(health <= 0) {
            Debug.Log("Player has died!");
        }
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("PickUp")) {
            GameObject pickup = other.gameObject;
            Debug.Log(health);
            Debug.Log("Hit something");
            Debug.Log("That something was a box.");
            health += 20;
            Debug.Log(health);
            Destroy(pickup);
        }
    }
}
