using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    float laju = 5.0f;
    float putar = 60.0f;
    public float speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) //This controls forward
        {
            GetComponent<Rigidbody>().transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.A)) //This controls left
        {
            GetComponent<Rigidbody>().transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.S))//This controls back
        {
            GetComponent<Rigidbody>().transform.Translate(Vector3.back * Time.deltaTime * speed);
        }

        if (Input.GetKey(KeyCode.D))//This controls right
        {
            GetComponent<Rigidbody>().transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        //putar kiri - kanan
        float hor = Input.GetAxis("Horizontal") * putar * Time.deltaTime;
        transform.Rotate(0, hor, 0);

        //putar maju - mundur
        float ver = Input.GetAxis("Vertical") * laju * Time.deltaTime;
        transform.Translate(0, 0, ver);

    }
}
