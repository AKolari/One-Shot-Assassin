using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

     public float speed = 1500.0f;
     public Rigidbody2D _rigidbody;
     public bool isBlank = false;
    



     private void Awake()
     {
          _rigidbody = GetComponent<Rigidbody2D>();
     }

    

     public void AddBulletForce(Vector2 force)
     {
          _rigidbody.AddForce(force*this.speed);
     }

    

    // Update is called once per frame
    void Update()
    {
        
    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            if(isBlank)
            {
                _rigidbody.Sleep();
            }
            else
            {
                Destroy(this.gameObject);
            }
            
        }
    }
}
