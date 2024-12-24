using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class tempatKunci : MonoBehaviour
{
    private bool win = false;
    public GameObject lastTembok;
    public GameObject lastTembokBuild;
    Vector3 objectPosition;
    Quaternion objectRotation;


    // Start is called before the first frame update
    void Start()
    {
        objectPosition = lastTembok.transform.position;
        objectRotation = lastTembok.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (win)
        {
            Destroy(lastTembok);
        }
        else
        {
            if(lastTembok == null)
            {
                //instantiate 
                lastTembok = Instantiate(lastTembokBuild, objectPosition, objectRotation);

            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            win = true;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            win = false;
        }
    }
}
