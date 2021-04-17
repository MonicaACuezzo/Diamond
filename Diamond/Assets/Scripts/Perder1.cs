using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Perder1 : MonoBehaviour
{
    public static Perder1 perder1;

    public GameObject menuPerder;
    public static bool enJuego ;
    
    void Start()
    {
        perder1 = this;
        //menuPerder.SetActive(false);
        enJuego = true;
    }

    public void Reiniciar()
    {
        Activate();
        SceneManager.LoadScene(escenaActual());
    }

    
    public void perder()
    {
        Puntaje1.diamondInScreen = 0;
        enJuego = false;
        Deactivate();
        //menuPerder.SetActive(true);
    }

    public int escenaActual()
    {
        return SceneManager.GetActiveScene().buildIndex;
        //     SceneManager.GetActiveScene().name
    }

    public void Activate()
    {
        Time.timeScale = 1;
    }
    public void Deactivate()
    {
        Time.timeScale = 0;
    }

}
