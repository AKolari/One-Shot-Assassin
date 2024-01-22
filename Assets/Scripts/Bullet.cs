using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

     public float speed = 1500.0f;
     public Rigidbody2D _rigidbody;
     public float start_x = 0;
     public float start_y = 1;



     private void Awake()
     {
          _rigidbody = GetComponent<Rigidbody2D>();
     }

     // Start is called before the first frame update
     void Start()
     {
         // AddStartingForce();
     }

     private void AddStartingForce()
     {
          //Chooses a force to fire in (will depend on Player direction)
          


          //Puts starting x and y in a vector called direction
          Vector2 direction = new Vector2(-start_x, -start_y);

          //Applies direction and force to ball
          _rigidbody.AddForce(direction * this.speed);
     }

     public void AddBulletForce(Vector2 force)
     {
          _rigidbody.AddForce(force*this.speed);
     }

     // Update is called once per frame
     void Update()
    {
        
    }
}
