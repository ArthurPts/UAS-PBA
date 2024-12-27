using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backtoHome : MonoBehaviour
{
    public void goHomeMenu()
    {
        SceneManager.LoadScene(0);
    }
}
