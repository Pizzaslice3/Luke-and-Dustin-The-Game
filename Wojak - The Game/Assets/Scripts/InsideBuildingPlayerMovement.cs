using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InsideBuildingPlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    public float shrinkSpeed;

    public Sprite doomerBack;
    public Sprite doomerFront;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (change != Vector3.zero)
        {
            MoveDoomer();
        }

    }


    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }

    void MoveDoomer()
    {
        //moves the rigidbody from 1. where it currently is plus 
        if(change.y == 1)
        {
            Debug.Log("happening");
            myRigidbody.MovePosition(transform.position + new Vector3(change.y, 0, 0) * speed * Time.deltaTime);
            gameObject.transform.localScale -= gameObject.transform.localScale * .8f * shrinkSpeed * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().sprite = doomerBack;
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(change.y == -1)
        {

            myRigidbody.MovePosition(transform.position - new Vector3(-change.y, 0, 0) * speed * Time.deltaTime);
            gameObject.transform.localScale += gameObject.transform.localScale * .8f * shrinkSpeed * Time.deltaTime;
            gameObject.GetComponent<SpriteRenderer>().sprite = doomerFront;
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }   
        
    }
}
