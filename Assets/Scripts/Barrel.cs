using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

     public AudioClip explode_SFX;
    public GameObject explosionPrefab;
    private GameObject explosion;
     // Start is called before the first frame update
     void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
          if (GameManager.CURRENT_PHASE() == GamePhase.Fire) 
          {
            AudioManager.Instance.playSound(explode_SFX);
            explosion =Instantiate(explosionPrefab);
            explosion.transform.position=gameObject.transform.position;
            Destroy(gameObject);
            
               
          }
    }


    
}
