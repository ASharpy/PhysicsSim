using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charControl : MonoBehaviour {

    CharacterController cc;
    Vector3 direction;
    public float speed = 20.0f;
    public float gravity = 20.0f;
    float yAxis;
    Vector3 jump;
    Rigidbody RB;
    bool isGrounded;

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
        direction.y -= gravity * Time.deltaTime;



        
            direction = new Vector3(0,0, Input.GetAxis("Vertical"));
            direction = transform.TransformDirection(direction);
            direction *= speed;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(jump * 10.0f, ForceMode.Impulse);
            }
        


        yAxis = Input.GetAxis("Horizontal");
        transform.Rotate(new Vector3(0, yAxis * 2, 0), Space.Self);


        cc.Move(direction * Time.deltaTime);
        
        
       
	}

    private void OnCollisionStay()
    {
        isGrounded = true;
    }
}
