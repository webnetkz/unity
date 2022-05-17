using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

public GameObject MainCamera;
public GameObject Player;

public float jumpForce;

public AudioSource audioJump;
public AudioSource audioIsJump;
 
public float speed;
private Rigidbody rb;
private bool grounded;
private bool moveForward; 
private bool moveBack; 
private bool moveRight; 
private bool moveLeft; 

private bool isJumped = false;
 
void Start()
{
  grounded = false;
  rb = Player.GetComponent<Rigidbody>();
  moveForward = false;
  moveBack = false;
  moveRight = false;
  moveLeft = false;
}
 
 
void OnCollisionEnter(Collision collision)
{
  grounded = true;
  audioJump.Play();
}

void OnCollisionStay(Collision collision)
{
  grounded = true;
}

void OnCollisionExit(Collision collision)
{
  StartCoroutine( IsGrounded() );
}
IEnumerator IsGrounded()
{
  yield return new WaitForSeconds(0.2f);
  grounded = false;
}


void Update()
{

  if(Input.GetAxis("Vertical") > 0.0f & grounded == true)
  {
    moveForward = true;
  } else {
    moveForward = false;
  }

  if(Input.GetAxis("Vertical") < 0.0f & grounded == true)
  {
    moveBack = true;
  } else {
    moveBack = false;
  }

  if(Input.GetAxis("Horizontal") > 0.0f & grounded == true)
  {
    moveLeft = true;
  } else {
    moveLeft = false;
  }

  if(Input.GetAxis("Horizontal") < 0.0f & grounded == true) 
  {
    moveRight = true;
  } else {
    moveRight = false;
  }

  if(Input.GetKeyDown(KeyCode.Space) & isJumped == false & grounded == true )
  {
    audioIsJump.Play();
    isJumped = true;
  }
}
 
void FixedUpdate()
{
  if(isJumped == true & grounded == true)
  {
    isJumped = false;
    rb.AddForce(new Vector3(0f, jumpForce, 0f));
  }

  if(moveForward)
  {
    rb.AddForce(MainCamera.transform.forward * speed * Time.deltaTime);
  }

  if(moveBack)
  {
    rb.AddForce(-MainCamera.transform.forward * (speed / 2 ) * Time.deltaTime);
  }

  if(moveLeft)
  {
    rb.AddForce(MainCamera.transform.right * (speed / 2) * Time.deltaTime);
  }

  if(moveRight)
  {
    rb.AddForce(-MainCamera.transform.right * (speed / 2) * Time.deltaTime);
  }
}
     
}
