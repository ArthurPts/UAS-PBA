using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class tempatKunci : MonoBehaviour
{
    //pintu akan ada animasi buka & tutup
    public Transform door; // Objek pintu (Cube9)
    public Vector3 openPositionOffset; // Posisi offset saat pintu terbuka
    public float moveSpeed = 2f; // Kecepatan gerakan pintu
    public float closeDelay = 2f; // Waktu sebelum pintu menutup otomatis

    private Vector3 closedPosition; // Posisi awal (tertutup)
    private Vector3 openPosition; // Posisi akhir (terbuka)
    private bool isOpening = false; // Status membuka pintu
    private bool isClosing = false; // Status menutup pintu
    private float closeTimer = 0f; // Timer untuk menutup pintu

    // Start is called before the first frame update
    void Start()
    {
        // Tetapkan posisi awal dan hitung posisi terbuka
        closedPosition = door.position;
        openPosition = closedPosition + openPositionOffset;

    }

    // Update is called once per frame
    void Update()
    {
        // Buka pintu
        if (isOpening)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition, moveSpeed * Time.deltaTime);
            if (door.position == openPosition)
            {
                isOpening = false; // Berhenti membuka saat posisi tercapai
                closeTimer = closeDelay; // Mulai timer untuk menutup
            }
        }

        // Tutup pintu
        if (isClosing)
        {
            door.position = Vector3.MoveTowards(door.position, closedPosition, moveSpeed * Time.deltaTime);
            if (door.position == closedPosition)
            {
                isClosing = false; // Berhenti menutup saat posisi tercapai
            }
        }

        // Hitung mundur timer dan mulai menutup jika waktu habis
        if (closeTimer > 0)
        {
            closeTimer -= Time.deltaTime;
            if (closeTimer <= 0)
            {
                StartClosing();
            }
        }

    }
    public void OpenDoor()
    {
        isOpening = true;
        isClosing = false;
    }

    public void StartClosing()
    {
        isClosing = true;
        isOpening = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Buka pintu saat player menginjak silinder biru
        if (other.CompareTag("Player"))
        {
            OpenDoor();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Mulai timer untuk menutup pintu saat player keluar dari trigger
        if (other.CompareTag("Player"))
        {
            closeTimer = closeDelay;
        }
    }

    /* (KPintu hanya destroy)
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
    */
}
