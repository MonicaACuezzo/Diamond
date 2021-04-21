using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject explosion;


    void Update()
    {
        if (transform.position.y < -4)   Destroy(gameObject);
    }



    void OnMouseDown()
    {
        
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 2f);

        Destroy(gameObject);
        Vida.vidaPlayer.CameraShake(2f);
        //Handheld.Vibrate();

        Puntaje1.puntajeActual.RestarPuntaje ();
            
        Puntaje1.puntajeActual.RestarPoderes ();
    }

 
}
