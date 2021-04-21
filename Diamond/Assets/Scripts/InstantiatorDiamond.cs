using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorDiamond : MonoBehaviour
{
    public static InstantiatorDiamond instantiatorDiamond;

    //public float InstantiateRate = 3f; // lo reemplazo por "frecuencia"

    public float begin; // para demora inicial
    public float end; // es la frecuencia de emision
    public int rangoX = 0; //para escenas 9 y 10 = 7
    public int rangoY = 0; //para escenas 9 y 10 = 3

    public GameObject[] diamondPrefab;
    int total ; //diamondPrefab.size;

    
    IEnumerator Start()
    {
        instantiatorDiamond = this;
        total = diamondPrefab.Length;
       

        while (true)
        {

            //Instantiate (diamondPrefab, new Vector2(transform.position.x+ Random.Range(-7,7),transform.position.y ), Quaternion.identity);
            yield return new WaitForSeconds (begin);

                //Instantiate (diamondPrefab[Random.Range(0,total)], transform.position, Quaternion.identity);
                //Instantiate (diamondPrefab[Random.Range(0,total)], new Vector2(transform.position.x+ Random.Range(-rangoX,rangoX), transform.position.y+ Random.Range(-rangoY,rangoY)), Quaternion.identity);
                
                Instantiate (diamondPrefab[Random.Range(0,total)], new Vector2(transform.position.x+ Random.Range(-rangoX,rangoX), transform.position.y), Quaternion.identity);
            //Instantiate (diamondPrefab[Random.Range(0,total)], transform.position + Random.onUnitSphere * .3f, Quaternion.identity);
                Puntaje1.diamondInScreen++;
                if (Puntaje1.diamondInScreen >= 80) Puntaje1.puntajeActual.VerificarFinal();
                
                
                //float end = Puntaje1.frecuencia;
                //yield return new WaitForSeconds (Random.Range(begin, end)); // lo reemplazo por "frecuencia"
                yield return new WaitForSeconds (end); // lo reemplazo por "frecuencia"

                //yield return new WaitForSeconds (.6f); // lo reemplazo por "frecuencia"


        }
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
