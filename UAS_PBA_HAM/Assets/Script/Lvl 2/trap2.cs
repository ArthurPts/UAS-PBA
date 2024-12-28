using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public GameObject duri1;
    public GameObject duri2;
    public GameObject duri3;
    public GameObject duri4;
    Boolean obj = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && obj == false)
        {
            SpawnObj();
        }
    }

    public void SpawnObj()
    {
        Instantiate(duri1, duri1.transform.position, Quaternion.identity);
        Instantiate(duri2, duri2.transform.position, Quaternion.identity);
        Instantiate(duri3, duri3.transform.position, Quaternion.identity);
        Instantiate(duri4, duri4.transform.position, Quaternion.identity);
        obj = true;

    }
}
