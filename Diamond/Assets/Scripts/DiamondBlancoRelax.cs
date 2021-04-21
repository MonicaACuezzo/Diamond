using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
//using UnityEngine.SceneManagement;

public class DiamondBlancoRelax : MonoBehaviour
{

    //public float velocity = 5f;
    public static DiamondBlancoRelax diamond;
    public Rigidbody rb;
    public Transform child;
    public GameObject smallDiamond;
    public GameObject[] explosion;
    public int indice;
    //public GameObject soundexplosion;
    
    public bool diamanteGrande;
    //public int speed = 10;
    MeshRenderer mr;
    //float speed = 10f;
    

    public Color[] colorDiamond; 
    
    int totalColor;

    public GameObject  videoParticulas;
    public float rotationX, x;
    


    void Start()
    {
        diamond = this;

        indice = Random.Range(0, colorDiamond.Length);
        
        child = this.gameObject.transform.GetChild(1);
        mr = child.GetComponent<MeshRenderer>();
        
        mr.material.color = colorDiamond[indice]; // siempre es blanco

        x = Random.Range(-rotationX, rotationX);
    }

    void Update()
    {
        transform.Rotate(new Vector3(x, x, 0f) * Time.deltaTime);

        if (transform.position.y < -5)   Destroy(gameObject);
    }



    void OnMouseDown()
    {
        DestroyDiamond();
    }



    public void DestroyDiamond()
    {
        Destroy(Instantiate(explosion[indice], transform.position, Quaternion.identity), 2f);

        if (diamanteGrande)
        {
            //Handheld.Vibrate();
            
            Instantiate (smallDiamond, transform.position + Random.onUnitSphere * 1f, Quaternion.identity);
            Instantiate (smallDiamond, transform.position + Random.onUnitSphere * .7f, Quaternion.identity);
            Instantiate (smallDiamond, transform.position + Random.onUnitSphere * 1f, Quaternion.identity);
            Instantiate (smallDiamond, transform.position + Random.onUnitSphere * .7f, Quaternion.identity);
            Instantiate (smallDiamond, transform.position + Random.onUnitSphere * 1f, Quaternion.identity);
        }
        Destroy(gameObject);
        Puntaje1.puntajeActual.ActualizarPuntaje ();
        Puntaje1.diamondInScreen--;
        
        /*
        
        Instantiate(soundexplosion);
        
        */
    }




}
