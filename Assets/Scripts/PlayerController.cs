using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    string axisName = "PlayerDirection";
    float movespeed = 10;

    void Start()
    {
        
    }

    void Update()
    {
   
    }

    void FixedUpdate()
    {
        Movement();
    }
    protected void Movement()
    {
        float moveAxis = Input.GetAxis(axisName) * movespeed;
        GetComponent<Rigidbody2D>().velocity = new Vector2(moveAxis, 0);
    }

}
