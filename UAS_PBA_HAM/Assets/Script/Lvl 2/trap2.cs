using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public GameObject push;
    public GameObject pull;

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
        if (other.tag == "Player")
        {
            SpawnObj();
        }
    }

    public void SpawnObj()
    {
        Vector3 SpawnPos1 = new Vector3(36f, 0.5f, 25f);
        GameObject temp1 = (GameObject)Instantiate(push, SpawnPos1, Quaternion.identity);

        temp1.GetComponent<obstacle>().force = new Vector3(-50, 0, 0);

        Vector3 SpawnPos2 = new Vector3(26f, 2f, 25f);
        GameObject temp2 = (GameObject)Instantiate(pull, SpawnPos2, Quaternion.identity);

        temp2.GetComponent<obstacle>().force = new Vector3(70, 0, 0);

    }
}
