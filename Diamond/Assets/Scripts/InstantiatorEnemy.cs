using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatorEnemy : MonoBehaviour
{
    public static InstantiatorEnemy instantiatorEnemy;

    public float InstantiateRate = 3f; // lo reemplazo por "frecuencia"

    public float begin; // para range de frecuencia
    public int rangoX = 0; //para escenas 9 y 10 = 7
    public int rangoY = 0; //para escenas 9 y 10 = 3

    public GameObject[] enemyPrefab;
    int total ; //enemyPrefab.size;

    
    IEnumerator Start()
    {
        instantiatorEnemy = this;
        total = enemyPrefab.Length;
       

        while (true)
        {

                 Instantiate (enemyPrefab[Random.Range(0,total)], new Vector2(transform.position.x+ Random.Range(-rangoX,rangoX), transform.position.y+ Random.Range(-rangoY,rangoY)), Quaternion.identity);
                //Puntaje1.enemyInScreen++;
                //if (Puntaje1.enemyInScreen >= 80) Puntaje1.puntajeActual.VerificarFinal();
                
              
                float end = Puntaje1.frecuencia;
                yield return new WaitForSeconds (Random.Range(begin, end)); // lo reemplazo por "frecuencia"

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
