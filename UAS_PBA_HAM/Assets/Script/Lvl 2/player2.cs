using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class player2 : MonoBehaviour
{
    //untuk player gerak
    private Rigidbody rb;
    public float speed;
    public float rotate;
    public float jumpForce;

    public bool sentuhTanah = true;
    Vector3 moveDirection;
    float verticalInput;
    float horizontalInput;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MyInput();

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            sentuhTanah = true;
        }
        else if (collision.gameObject.tag == "Respawn")
        {
            GameObject newPlayer = Instantiate(gameObject,new Vector3(47,1,6),Quaternion.identity);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }


    private void MyInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && sentuhTanah)
        {
            Jump();
        }
    }

    private void MovePlayer()
    {
        moveDirection = transform.forward * verticalInput;
        if (sentuhTanah)
        {
            rb.AddForce(moveDirection.normalized * speed, ForceMode.VelocityChange);
        }   
        else if (!sentuhTanah)
        {
            rb.AddForce(moveDirection.normalized * speed * 0.4f, ForceMode.VelocityChange);

        }
        transform.Rotate(transform.up * horizontalInput * rotate);

    }

    private void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        sentuhTanah = false;
    }
}
