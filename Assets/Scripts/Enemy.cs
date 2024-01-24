using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health=1;
    void Awake()
    {
        health = 1;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.CURRENT_PHASE() == GamePhase.Fire)
        {
            Debug.Log(collision.gameObject);



            health--;
            if (health <= 0)
            {
                GameManager.ENEMY_KILLED();
                Destroy(this.gameObject);
            }


        }
        
    }

   





}
