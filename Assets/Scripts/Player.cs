using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    //Set bulletSpawnPoint in the
    private Transform bulletSpawnPoint;
    public GameObject BulletPrefab;
    public GameObject AimLinePrefab;
    private GameObject currentLine;
    private GameObject lastLine;
    private GameObject firedShot;
     // Start is called before the first frame update 

     //Sounds 
     public AudioClip fire_SFX;
     void Start()
    {
        bulletSpawnPoint = gameObject.transform.Find("Barrel");
          
        //myBullet.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.CURRENT_PHASE() == GamePhase.Aim)
        {
            Vector2 mousePos2D = Input.mousePosition;

            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
            mousePos3D.z = 0;

            Vector2 direction = new Vector2(mousePos3D.x - gameObject.transform.position.x, mousePos3D.y - gameObject.transform.position.y);
            transform.up = -direction;
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {


                if (lastLine != null)
                {
                    Destroy(lastLine.gameObject);

                }

                GameObject myBullet = Instantiate(BulletPrefab);
                myBullet.transform.position = bulletSpawnPoint.position;
                myBullet.transform.rotation = bulletSpawnPoint.rotation;
                myBullet.GetComponent<Bullet>().AddBulletForce(direction.normalized);
                GameManager.ADVANCE_PHASE();  
                AudioManager.Instance.playSound(fire_SFX);
            }
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                if(lastLine != null)
                {
                    Destroy(lastLine.gameObject);
                    
                }
                GameObject myBullet = Instantiate(BulletPrefab);
                myBullet.transform.position = bulletSpawnPoint.position;
                myBullet.transform.rotation = bulletSpawnPoint.rotation;
                myBullet.GetComponent<Bullet>().AddBulletForce(direction.normalized);
                myBullet.GetComponent <Bullet>().isBlank = true;
                currentLine = Instantiate(AimLinePrefab, myBullet.transform);
                currentLine.GetComponent<AimLine>().blank = myBullet.GetComponent<Bullet>();
                lastLine = myBullet;


            }

            if(Input.GetKeyDown(KeyCode.F)) 
            {
                if (lastLine != null)
                {
                    Destroy(lastLine.gameObject);

                }
            }
        }

       


          


    }
}
