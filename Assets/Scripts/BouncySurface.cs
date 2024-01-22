using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncySurface : MonoBehaviour
{
     public float BounceStrength;

     private void OnCollisionEnter2D(Collision2D collision) //When colliding with another object...
     {

          Bullet bullet = collision.gameObject.GetComponent<Bullet>(); //Stores the (ball) game object the surface collides with  
          /*
               -Ball is an instance of the Ball class in the Ball.cs script 
               -collision.gameObject checks the gameObject you collided with
           */

          if (bullet != null) //If collided object is not null (a ball)
          {
            
               Vector2 normal = collision.GetContact(0).normal;
               //The normal vector of a surface is the vector perpendicular to it 
               //GetContact(0) is simply the first contact point 
               
               bullet.AddBulletForce(-normal * this.BounceStrength);
          }

     }
}
