using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceController : MonoBehaviour
{
    public float speed;
    public GameObject _cam;

    private Rigidbody _rb;
    private GameObject _gm;
    private float horizontal;
    private float vertical;
    private Vector3 move;
    private float doubleMove = 1f;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            doubleMove = 2;
        }

        move = new Vector3(horizontal, 0, vertical);
    }

    void FixedUpdate()
    {
        _rb.AddForce(move * speed * Time.deltaTime * doubleMove, ForceMode.VelocityChange);
    }
}
