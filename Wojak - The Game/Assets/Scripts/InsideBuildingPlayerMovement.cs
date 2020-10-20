using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBuildingPlayerMovement : MonoBehaviour
{

    public float doomerSpeed = 1;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    private float movementShrinkSpeed = .8f;
    private float shrinkSpeed = .18f;

    public Sprite doomerBack;
    public Sprite doomerFront;

    public bool canMove = true;


    public SpawnPlayerOverWorld SPOW;


    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero && canMove)
        {
            MoveDoomer();
        }

    }


    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * movementShrinkSpeed * Time.deltaTime);
    }

    void MoveDoomer()
    {
        //moves the rigidbody from 1. where it currently is plus 
        if(change.y == 1)
        {
            myRigidbody.MovePosition(transform.position + new Vector3(change.y, 0, 0) * movementShrinkSpeed * doomerSpeed * Time.deltaTime);
            gameObject.transform.localScale -= gameObject.transform.localScale * .8f * shrinkSpeed * doomerSpeed * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().sprite = doomerBack;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(change.y == -1)
        {

            myRigidbody.MovePosition(transform.position - new Vector3(-change.y, 0, 0) * movementShrinkSpeed * doomerSpeed *  Time.deltaTime);
            gameObject.transform.localScale += gameObject.transform.localScale * .8f * shrinkSpeed * doomerSpeed *  Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().sprite = doomerFront;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }   
        
    }
}
