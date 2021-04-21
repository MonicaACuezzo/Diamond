using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    
    public void irMenu()
    {
        SceneManager.LoadScene("pruebaMapa");
    }

    public void Relax()
    {
        SceneManager.LoadScene("pruebaRelax");
    }


    public void Play()
    {
        SceneManager.LoadScene("prueba001");
    }


    public void Exit()
    {
        Application.Quit();
    }
}
