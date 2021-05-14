using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int damage = 10;
    public int range = 20;
    private GameObject player;

    void Start() {
        player = gameObject;
    }

    void Update()
    {
        int playerHealth = player.GetComponent<Player>().health;
        
        if(Input.GetMouseButtonDown(0) &&  playerHealth > 0)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray, out hit))
            {
                Transform objectHit = hit.transform;
                
                MonoBehaviour[] mono;
                mono = objectHit.gameObject.GetComponents<MonoBehaviour>();

                foreach(MonoBehaviour item in mono)
                {
                    if(item is IDamage && item)
                    {
                        IDamage temp = item as IDamage;
                        temp.TakeDamage(damage);
                        return;
                    }
                }
            }
        } else if(playerHealth < 0) {
            Debug.Log("Sorry, you have died and can't shoot.");
        }
    }
}
