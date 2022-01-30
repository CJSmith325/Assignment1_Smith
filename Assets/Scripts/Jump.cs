using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;
using System.Globalization;
using System;

public class Jump : MonoBehaviour
{
    [SerializeField] float movementSpeed = 6f;
    

    public Rigidbody2D reggiebody;
    public float jumpForce;
    bool isGrounded = false;
    public float groundRayLength;
    public LayerMask layers;

   
    

    void Update()
    {
        
        GameObject arm = GameObject.Find("arm");
        GameObject player = GameObject.Find("Player");

        isGrounded = Physics2D.Raycast(transform.position, -transform.up, groundRayLength, layers);
        Debug.DrawRay(transform.position, -transform.up * groundRayLength, Color.red);
       
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Debug.Log("Jump is pressed");
            reggiebody.AddForce(Vector2.up * jumpForce);
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        reggiebody.velocity = new Vector2((horizontalInput * movementSpeed) + (verticalInput * movementSpeed), reggiebody.velocity.y);
        
        if (reggiebody.velocity.x > 0)
        {
            arm.transform.rotation = Quaternion.Euler(0, 180, 0);
            //gun.transform.rotation = Quaternion.Euler(0, 180, 0);
            player.transform.rotation = Quaternion.Euler(0, 180, 0);
            //gunTip.transform.rotation = Quaternion.Euler(0, 180, 0);
            //gunPivot.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (reggiebody.velocity.x < 0)
        {
            arm.transform.rotation = Quaternion.Euler(0, 0, 0);
            //gun.transform.rotation = Quaternion.Euler(0, 0, 0);
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            //gunTip.transform.rotation = Quaternion.Euler(0, 0, 0);
            //gunPivot.transform.rotation = Quaternion.Euler(0, 0, 0);
            
        }

       
    }
}
