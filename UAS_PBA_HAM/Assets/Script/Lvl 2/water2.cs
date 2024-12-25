using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water2 : MonoBehaviour
{
    public GameObject myobstacle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SpawnObj()
    {
        Vector3 SpawnPos = new Vector3(40f, 0.5f, 15.5f);
        GameObject temp = (GameObject)Instantiate(myobstacle, SpawnPos, Quaternion.identity);

        temp.GetComponent<obstacle>().force = new Vector3(-50, 0, 0);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SpawnObj();

        }
    }

}
