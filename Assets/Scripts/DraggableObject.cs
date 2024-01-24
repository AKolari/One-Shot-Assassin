using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DraggableObject : MonoBehaviour
{
    protected bool beingDragged = false;
    public bool snapToCenter = false;
    private bool triggerType;
    private bool validPosition = true;
    protected Rigidbody2D myBody;
    protected Collider2D myCollider;
    private Vector3 lastValidPosition;
    private Quaternion lastValidRotation;
    public bool isSpawner=false;
    private bool aboveSpawner;

    
    // Start is called before the first frame update
    void Awake()
    {
        beingDragged = false;
        myBody = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();
        lastValidPosition = transform.position;
        lastValidRotation = transform.rotation;
        triggerType = myCollider.isTrigger;
    }

    // Update is called once per frame
    void Update()
    {
        
       
        if (beingDragged)
        {
            if (Input.GetMouseButtonDown(1))
            {
                myBody.transform.Rotate(0, 0, 90);
            }
            //Get the current mouse position in 2D screen coordinates
            Vector2 mousePos2D = Input.mousePosition;
            
            Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
            mousePos3D.z = 0;
            myBody.transform.position = mousePos3D;
        }
    }



    private void OnMouseDown()
    {

        
        if (GameManager.CURRENT_PHASE() == GamePhase.Prep)
        {
            
            beingDragged = true;
            //gameObject.layer = 6;
            myCollider.isTrigger = true;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Foreground";
            isSpawner = false;
        }
            
        
    }

   
    private void OnMouseUp()
    {
        if (GameManager.CURRENT_PHASE() == GamePhase.Prep)
        {
            beingDragged = false;
            //gameObject.layer = 0;
            myCollider.isTrigger = triggerType;
            gameObject.GetComponent<SpriteRenderer>().sortingLayerName = "Midground";

            if (aboveSpawner)
            {
                Destroy(gameObject);
            }

            if (!validPosition)
            {
                

                myBody.transform.position = lastValidPosition;
                myBody.transform.rotation = lastValidRotation;
                return;
            }



            //Get the current position of the gameObject
            Vector3 tempPos = gameObject.transform.position;

            //Based on our grid, for an object to be in the center of the grid, it's position needs to be a non-integer multiple of .5
            //To ensure it is in the center, we will floor the position, and then add .5
            //This only applies if snapToCenter is true. Otherwise, our object needs to snap to the side of a block
            if (snapToCenter)
            {
                tempPos.x = Mathf.Floor(tempPos.x) + .5f;
                tempPos.y = Mathf.Floor(tempPos.y) + .5f;
                tempPos.z = 0;
                gameObject.transform.position = tempPos;
                lastValidPosition = myBody.transform.position;
                lastValidRotation = myBody.transform.rotation;
            }
            else//If not, then we need to check the objects rotation, to see if it is aligned vertical or horizontal. If it is alligned vertical, we need to snap to the left or right
            {//Otherwise, we need to snap up or down

                //If rotation is +90 or +270, then it is aligned vertically. So snap to the left or right
              
                if ((Mathf.Round(gameObject.transform.rotation.eulerAngles.z) / 90) % 2 == 0)
                {
                    tempPos.x = Mathf.Round(tempPos.x);
                    tempPos.y = Mathf.Floor(tempPos.y) + .5f;
                    tempPos.z = 0;
                    gameObject.transform.position = tempPos;
                    lastValidPosition = myBody.transform.position;
                    lastValidRotation = myBody.transform.rotation;
                }
                else//We are alligned horizontally. Snap up or down
                {
                    tempPos.x = Mathf.Floor(tempPos.x) + .5f;
                    tempPos.y = Mathf.Round(tempPos.y);
                    tempPos.z = 0;
                    gameObject.transform.position = tempPos;
                    lastValidPosition = myBody.transform.position;
                    lastValidRotation = myBody.transform.rotation;
                }

            }

        }
    }                             




    private void OnTriggerStay2D(Collider2D collision)
    {
        DraggableObject drag = collision.GetComponent<DraggableObject>();

        if (drag)
        {
            if (drag.isSpawner)
            {
                aboveSpawner = true;
            }
        }

        if (beingDragged)
        {

             
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            validPosition = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        
        
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1);
            validPosition = true;
            aboveSpawner = false;
        
        
    }


}
