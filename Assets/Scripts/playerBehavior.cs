using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{

    public float speed;
    public float smoothing;
    public float jumpHeight;

    private Rigidbody rb;
    private bool started;
    private GameObject obstacle1;
    private float mousePos;

    public double thisPos;
    public bool gameStartGlobal;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        started = true;

        if(obstacle1 == null)
        {
            obstacle1 = GameObject.FindWithTag("obstacle1");
        }

        gameStartGlobal = FindObjectOfType<ScoreScript>().gameStart;
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        mousePos = Input.GetAxis("Mouse X") * smoothing;
        Debug.Log("MousePos =  " + mousePos);

        Debug.Log("gamestarted = " + gameStartGlobal);
        

        SetPos();

        if (gameStartGlobal == true)
        {
            started = true;
        }

        if (started)
        {
            rb.AddForce(mousePos, 0, 0, ForceMode.Impulse);

            float moveHorizontal = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(moveHorizontal * smoothing, 0, 0);

            //Controls left to right motion
            //rb.AddForce(movement * speed);
            //Controls forward motion
            rb.AddForce(0, 0, speed, ForceMode.Impulse);

        }
        else
        {
            //press space to start

        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "jumper" && started == true)
        {
            Debug.Log("You touched jumper");
            rb.AddForce(Vector3.up * jumpHeight, ForceMode.VelocityChange);
            Invoke("settle", 0.5f);

        }

        if(collision.gameObject.tag == "obstacle1")
        {
            //Debug.Log("You ded m8");
        }
    }

    public void SetPos()
    {
        thisPos = this.transform.position.z;
    }

    public double ReturnPos()
    {
        return thisPos;
    }

    void settle()
    {
        rb.AddForce(Vector3.down * jumpHeight * 0.5f, ForceMode.VelocityChange);
    }

}