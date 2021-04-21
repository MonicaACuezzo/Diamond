using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public GameObject[] canciones; // canciones a reproducir durante la escena
    public float[] duracion; // duracion en segundos de cada camcion
    float  horaInicio, horaFinal; 
    int totalCanciones, indice;


    // Start is called before the first frame update
    void Start()
    {
        totalCanciones = canciones.Length;
        ReproducirTema();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > horaFinal)
        {
            ReproducirTema();
        }
    }

    void ReproducirTema()
    {
        indice = Random.Range(0, totalCanciones);
        horaInicio = Time.time;
        horaFinal = horaInicio + duracion[indice]+1;
        Destroy(Instantiate(canciones[indice]), duracion[indice]+2);
    }
}
