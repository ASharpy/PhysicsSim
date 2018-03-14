using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControl : MonoBehaviour
{

    CharacterController cc;
    Vector3 direction;
    public float speed = 20.0f;
    public float gravity = 20.0f;
    float yAxis;
    Vector3 jump;
    Rigidbody RB;
    bool isGrounded;
    Ray ray;

	// Use this for initialization
	void Start ()
    {
        cc = GetComponent<CharacterController>();
        direction = Vector3.zero;
        jump = new Vector3(0f, 2.0f, 0f);
        RB = GetComponent<Rigidbody>();
       
	}
	
	// Update is called once per frame
	void Update ()
    {


       


        Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.down)*1.1f, Color.green);

        direction = new Vector3(0, 0, Input.GetAxis("Vertical"));
        direction = transform.TransformDirection(direction);
        direction *= speed;

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(jump * 10.0f, ForceMode.Impulse);
            }
        }








        direction.y -= 9.8f;
        cc.Move(direction * Time.deltaTime);
        transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * 2, 0), Space.Self);


    }

    
}
