using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Botones : MonoBehaviour
{
    
    public void Next()
    {
        SceneManager.LoadScene(1);
    }

    
    public void Prev()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        
        Application.Quit();
    }

}
