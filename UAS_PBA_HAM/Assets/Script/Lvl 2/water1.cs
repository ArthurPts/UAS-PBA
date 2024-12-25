using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water1 : MonoBehaviour
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
        int spawnZ = Random.Range(1, 10);
        Vector3 SpawnPos = new Vector3(1, 1, spawnZ);
        GameObject temp = (GameObject)Instantiate(myobstacle, SpawnPos, Quaternion.identity);

        temp.GetComponent<obstacle>().force = new Vector3(20, 0, 0);    

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SpawnObj();
        }
    }

}
