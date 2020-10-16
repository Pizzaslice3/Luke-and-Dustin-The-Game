using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldPlayerMovement : MonoBehaviour
{

    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;

    public Sprite doomerFront;
    public Sprite doomerBack;

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

        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }

        if(Input.GetAxisRaw("Vertical") == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = doomerFront;
        }

        if (Input.GetAxisRaw("Vertical") == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = doomerBack;
        }

        if (change != Vector3.zero)
        {
            MoveCharacter();
        }

    }


    void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + change * speed * Time.deltaTime);
    }



    public void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Door"))
        {
            SceneManager.LoadScene(1);
        }
    }
}
