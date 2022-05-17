using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    public float speed;
    public float doubleSpeed;

    private float horizontal;
    private float vertical;
    private Vector3 move;
    private bool doubleMove = false;


    private float cheat;

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if(Input.GetKey(KeyCode.Z))
        {
          cheat = 3f;
        } else { cheat = 0f; }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            doubleMove = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            doubleMove = false;
        }

        move = new Vector3(horizontal, cheat, vertical);
    }

    void FixedUpdate()
    {
      if(!doubleMove)
      {
        transform.position = transform.position + move * speed * Time.deltaTime;
      } else {
        transform.position = transform.position + move * speed * doubleSpeed * Time.deltaTime;
      }
    }
}
