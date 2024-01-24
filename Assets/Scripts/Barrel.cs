using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{

     public AudioClip explode_SFX;
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
               Destroy(this.gameObject); 
          }
    }
}
