using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class Diamond : MonoBehaviour
{

    //public float velocity = 5f;
    public static Diamond diamond;
    public Rigidbody rb;
    public Transform child;
    public GameObject[] explosion;
    //public GameObject soundexplosion;
    //public GameObject soundClick;
    public int speed = 10, indice;
    MeshRenderer mr;
    

    public static Color lastColorClick;
    public bool isDragged;

    public Color[] colorDiamond; 
    
    int totalColor;
    public float rotationX, x;


    // Start is called before the first frame update
/*
    void Awake()
    {
        
        colorDiamond[0] = new Color(1, 1, 1, 1);
        colorDiamond[1] = new Color(1.0f, 1.0f, 0f, 1.0f);
        colorDiamond[2] = new Color(0f, 0f, 1f, 1.0f);
        colorDiamond[3] = new Color(0f, 1.0f, 0f, 1.0f);
        colorDiamond[4] = new Color(1.0f, 0f, 0f, 1.0f);
        colorDiamond[5] = new Color(0.937f, 0.490f, 0.043f, 1.0f);

        
    }*/

    void Start()
    {
        diamond = this;
        totalColor = colorDiamond.Length;

        child = this.gameObject.transform.GetChild(1);
        mr = child.GetComponent<MeshRenderer>();
        //Color mrColor = mr.material.color;

        indice = Random.Range(0, totalColor);
        mr.material.color = colorDiamond[indice];

        x = Random.Range(-rotationX, rotationX);

    }

    void Update()
    {
        //transform.RotateAround(transform.position, Vector3.back, speed * Time.deltaTime);
        //transform.Rotate(new Vector3(60f, 30f, 0f) * Time.deltaTime);
        transform.Rotate(new Vector3(x, x, 0f) * Time.deltaTime);

        if (transform.position.y < -5)   Destroy(gameObject);

        if (Puntaje1.puntajeActual.bomb) DestroyDiamond();
        if (Puntaje1.puntajeActual.power2) DestroyColor(Puntaje1.puntajeActual.colorDestroyPower2);
        if (Puntaje1.puntajeActual.power3) DestroyColor(Puntaje1.puntajeActual.colorDestroyPower3);
        if (Puntaje1.puntajeActual.power4) DestroyColumn(Puntaje1.puntajeActual.transformDestroyPower4);
    }



    void OnMouseDown()
    {
        
        Puntaje1.puntajeActual.ControlarColorPower4(mr.material.color, child);
        Puntaje1.puntajeActual.ControlarColorBomb(mr.material.color);
        Puntaje1.puntajeActual.ControlarColorPower2(mr.material.color);
        Puntaje1.puntajeActual.ControlarColorPower3(mr.material.color);

        
        Efectos();
        Destroy(gameObject);

        Puntaje1.puntajeActual.ActualizarPuntaje ();
            
        Puntaje1.diamondInScreen--;
        //Handheld.Vibrate();
    }

    /*void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "limits") // escena31
        {
                //Vida.vidaPlayer.Danio();
                Destroy(gameObject);
                Puntaje1.puntajeActual.RestarPuntaje();
        }
    }*/

/*
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "limits") // escena31
        {
                //Vida.vidaPlayer.Danio();
                Destroy(gameObject);
                Puntaje1.puntajeActual.RestarPuntaje();
        }

        /*

        if (collision.gameObject.tag == "border" && Perder1.perder1.escenaActual() == 1) // escena1
        {
            //DestroySphere();
            //Debug.Log("colision");
            //collision.SendMessage ("Colision", SendMessageOptions.DontRequireReceiver);
            //Puntaje.puntajeActual.ActualizarPuntaje ();
            //SendMessage ("perder1", SendMessageOptions.DontRequireReceiver);
 
        }*/
        /*
        if (collision.gameObject.name == "Up")
        {
            //DestroySphere();
        }

    }
*/


    public void DestroyDiamond()
    {
        Destroy(Instantiate(explosion[indice], transform.position, Quaternion.identity), 2f);
        Destroy(gameObject);
        Puntaje1.puntajeActual.ActualizarPuntaje ();
        Puntaje1.diamondInScreen--;
        
        /*
        
        Instantiate(soundexplosion);
        
        */
    }



    public void DestroyColor(Color colorDestroy)
    {
        //Debug.Log(colorDestroy+"   "+mr.material.color);
        if (colorDestroy == mr.material.color)
        {
            DestroyDiamond();
        }
    }


    public void DestroyColumn(float transformDiamond4)
    {
        if (gameObject.transform.position.x <= (transformDiamond4 +1) && gameObject.transform.position.x >= (transformDiamond4 -1))
        {
            DestroyDiamond();
        }
    }


    public void Efectos()
    {
        Destroy(Instantiate(explosion[indice], transform.position, Quaternion.identity), 2f);
        /*
        Instantiate(soundClick);
        */
    }


}
