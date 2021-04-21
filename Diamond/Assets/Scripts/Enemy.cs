using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody rb;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        //rb.velocity = new Vector3 ( Random.Range(-5,5), Random.Range(-5,5), 0);
    }

    void Update()
    {
        if (transform.position.y < -4)   Destroy(gameObject);
    }



    void OnMouseDown()
    {
        
        //Efectos();

        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 2f);

        Destroy(gameObject);
        Vida.vidaPlayer.CameraShake(2f);
        //Handheld.Vibrate();

        Puntaje1.puntajeActual.RestarPuntaje ();
            
        Puntaje1.diamondInScreen--;
    }

 
}
