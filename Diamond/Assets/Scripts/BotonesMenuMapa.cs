using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonesMenuMapa : MonoBehaviour
{
    public string escena;

    void OnMouseDown()
    {
        Debug.Log("CLCK");
        SceneManager.LoadScene(escena);
    }
}
