using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{

    //Set bulletSpawnPoint in the
    private Transform bulletSpawnPoint;
    public GameObject BulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        bulletSpawnPoint = gameObject.transform.Find("Barrel");
          
        //myBullet.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 mousePos2D = Input.mousePosition;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        mousePos3D.z = 0;

        Vector2 direction = new Vector2(mousePos3D.x - gameObject.transform.position.x, mousePos3D.y - gameObject.transform.position.y);
        transform.up = -direction;

        if (Input.GetKeyDown(KeyCode.Space)) {
            GameObject myBullet = Instantiate(BulletPrefab);
            myBullet.transform.position = bulletSpawnPoint.position;
            myBullet.transform.rotation = bulletSpawnPoint.rotation;
            myBullet.GetComponent<Bullet>().AddBulletForce(direction.normalized);
        }


          


    }
}
