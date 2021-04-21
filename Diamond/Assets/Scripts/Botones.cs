using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    
    public void Next()
    {
        SceneManager.LoadScene("prueba002");
    }

    
    public void Prev()
    {
        SceneManager.LoadScene("prueba001");
    }

    public void Exit()
    {
        
        Application.Quit();
    }

}
