using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Vida : MonoBehaviour
{
    public static Vida vidaPlayer;
    public static int cantidadDeVidas;
    
    //public ParticleSystem choque;
    //public GameObject efectoSanar;
    //public SpriteRenderer sr;

    public Transform camera;
    public float magnitudeShake;
    //public Image mascaraRoja;

    public Text textoVidas;
    public Image corazon;

    public GameObject panelWin;

    // Start is called before the first frame update
    void Start()
    {
        vidaPlayer = this;
        cantidadDeVidas = 5;

        //textoVidas.text = cantidadDeVidas.ToString();
        //corazon.color = Color.green;

        //panelWin.SetActive(false);
    }

    public void Danio()
    {
        if (Perder1.enJuego)
        {
            cantidadDeVidas--;
            textoVidas.text = cantidadDeVidas.ToString();

            //Instantiate(choque, transform.position, Quaternion.identity);
            CameraShake(2f);
            Handheld.Vibrate();


            if (cantidadDeVidas>=3)
            {
                //textoVidas.color = Color.green;
                //corazon.color = Color.green;
                
            }else 
            {
                //textoVidas.color = Color.red;
                //corazon.color = Color.white;

                //if (cantidadDeVidas<=0)
                    //SendMessage ("perder", SendMessageOptions.DontRequireReceiver);
                
            }
        }
        
    }

    public void Sanar()
    {
        if (Perder1.enJuego)
        {
            cantidadDeVidas++;
            //textoVidas.text = cantidadDeVidas.ToString();

            //Instantiate(efectoSanar, transform.position, Quaternion.identity);
            

            if (cantidadDeVidas>=10 || Puntaje1.puntajeActual.puntaje >=50)
            {
                InstantiatorDiamond.instantiatorDiamond.Deactivate();
                //panelWin.SetActive(true);
                
            }

            if (cantidadDeVidas>=3)
            {
                //textoVidas.color = Color.green;
                //corazon.color = Color.green;

            }else if (cantidadDeVidas==2)
            {
                //img.sprite = dosVidas; 
                //sr.color = new Color(0.6F, 0.6F, 0.6F, 0.8F);

                //textoVidas.color = Color.red;
                //corazon.color = Color.white;

            }else // (cantidadDeVidas==1)
            {
                //img.sprite = unaVida;
                //sr.color = new Color(0.6F, 0.6F, 0.6F, 0.4F);

                //textoVidas.color = Color.red;
                //corazon.color = Color.white;
            }
        }
        
    }

    private void FixedUpdate()
    {
        //mascara roja (energia)
        float valorAlpha = 1f/3f * (3f-cantidadDeVidas);
        //Debug.Log(valorAlpha);
        //mascaraRoja.color = new Color(1,1,1, valorAlpha);

        //sacudir camara
        if (magnitudeShake > .01f){
            
            camera.rotation = Quaternion.Euler(
                Random.Range(-magnitudeShake, magnitudeShake),
                Random.Range(-magnitudeShake, magnitudeShake),
                Random.Range(-magnitudeShake, magnitudeShake)
            );
            magnitudeShake *= .9f;
            
        }
    }

    public void CameraShake(float max)
    {
        magnitudeShake = max;
    }


}
