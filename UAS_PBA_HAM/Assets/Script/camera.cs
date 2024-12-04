using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject target; //target diisi : player, target adalah obyek yang dipantau oleh camera, followcamera
    float damping = 5.0f; //memperhalus agar gerakan teredam
    Vector3 offset; //vektor posisi antara camera dan player

    // Start is called before the first frame update
    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float sudutawal = transform.eulerAngles.y;
        float sudutakhir = target.transform.eulerAngles.y;

        float sudut = Mathf.LerpAngle(sudutawal, sudutakhir, Time.deltaTime * damping); //interpolasi linier
        Quaternion rot = Quaternion.Euler(0, sudut, 0);

        //posisi kamera yang baru, mengikuti target
        transform.position = target.transform.position - (rot * offset);
        //rotasi kamera yang baru, melihat target
        transform.LookAt(target.transform);
    }
}
