using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Diamond : MonoBehaviour
{

    //public float velocity = 5f;
    public static Diamond diamond;
    public Rigidbody rb;
    public GameObject explosion;
    public GameObject soundexplosion;
    public GameObject soundClick;
    public int speed = 10;
    MeshRenderer mr;
    

    public static Color lastColorClick;
    public bool isDragged;

    public Color[] colorDiamond; 
    int totalColor;

    // Start is called before the first frame update
    void Start()
    {
        diamond = this;
        totalColor = colorDiamond.Length;

        Transform child = this.gameObject.transform.GetChild(1);
        mr = child.GetComponent<MeshRenderer>();
        //Color mrColor = mr.material.color;
        mr.material.color = colorDiamond[Random.Range(0, totalColor)];

        //Debug.Log(mrColor);

        //rb.velocity = new Vector3 ( Random.Range(-5,5), Random.Range(-5,5), 0);

        //rb.transform.rotation.x = 45;
    }

    void Update()
    {
        //transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
        transform.Rotate(new Vector3(0f, 30f, 0f) * Time.deltaTime);
        
        if (Puntaje1.puntajeActual.bomb)
        {
            DestroyAll();
        }
    }


    void LastUpdate()
    {
        //transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
        /*
        if (Puntaje1.puntajeActual.bomb)
        {
            Puntaje1.puntajeActual.bomb = false;
        }*/
    }

    void OnMouseDown()
    {
        Puntaje1.puntajeActual.ControlarColorBomb(mr.material.color);
        Puntaje1.puntajeActual.ControlarColorPower2(mr.material.color);
        Puntaje1.puntajeActual.ControlarColorPower3(mr.material.color);
        Efectos();
        Destroy(gameObject);

        Puntaje1.puntajeActual.ActualizarPuntaje ();
            
        Puntaje1.diamondInScreen--;
        //Handheld.Vibrate();
    }

    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "limits") // escena31
        {
                //Vida.vidaPlayer.Danio();
                Destroy(gameObject);
                Puntaje1.puntajeActual.RestarPuntaje();
        }
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "limits") // escena31
        {
                //Vida.vidaPlayer.Danio();
                Destroy(gameObject);
                Puntaje1.puntajeActual.RestarPuntaje();
        }

        if (collision.gameObject.tag == "border" && Perder1.perder1.escenaActual() == 1) // escena1
        {
            //DestroySphere();
            //Debug.Log("colision");
            //collision.SendMessage ("Colision", SendMessageOptions.DontRequireReceiver);
            //Puntaje.puntajeActual.ActualizarPuntaje ();
            //SendMessage ("perder1", SendMessageOptions.DontRequireReceiver);
 
        }
        if (collision.gameObject.name == "Up")
        {
            //DestroySphere();
        }

    }


    void DestroySphere()
    {
        /*
        Instantiate(explosion, transform.position, Quaternion.identity);
        Instantiate(soundexplosion);
        Destroy(gameObject);
        Vida.vidaPlayer.Danio();
        */
    }


    public void DestroyDiamond()
    {
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 2f);
        Destroy(gameObject);
        Puntaje1.puntajeActual.ActualizarPuntaje ();
            
        Puntaje1.diamondInScreen--;
        Puntaje1.puntajeActual.bomb = false;
        /*
        
        Instantiate(soundexplosion);
        
        */
    }


    public void DestroyAll()
    {
        DestroyDiamond();
    }


    public void DestroyColor(Color colorDestroy)
    {
        if (colorDestroy == mr.material.color)
        {
            DestroyDiamond();
        }
    }




    public void Efectos()
    {
        Destroy(Instantiate(explosion, transform.position, Quaternion.identity), 2f);
        /*
        Instantiate(soundClick);
        */
    }

}
