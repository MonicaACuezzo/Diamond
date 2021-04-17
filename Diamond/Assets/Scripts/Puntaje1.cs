using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Puntaje1 : MonoBehaviour
{
    public static Puntaje1 puntajeActual;

    public Text muestraPuntaje;
    public int puntaje;
    public static int frecuencia = 4;
    public static float begin = 1;

    public static float velocidadAsteroide = 2;
    public static int diamondInScreen; //cuenta la cant de perlas en pantalla para nivel 8


    public float incrementoVelocidad = 1;
    public float lapso = 10;
    public float incrementoLapso = 10;

    //GameObject diamondAnterior = null;
    //public GameObject diamondAnterior;
    //SpriteRenderer srAnterior;

    public GameObject panelInicio;

    Color colorAnterior= Color.black;
    public static Color colorTablero= Color.black;

    public static Color colorControl;
    Color[] excluirColor = {Color.blue, Color.red, Color.white, new Color(1f, 1f, 0f, 1f), Color.green};
    int excluirLength;
    public Image imgColor;
    public GameObject boxColor;

    public bool secuencia;
    int x ; //indice  para controlar secuencia de colores 

    //PODER1
    public bool bomb = false; // indica si todos los diamond in screen deben destruirse
    public Color colorBomb; // indica que color de diamante activa la bomba
    public int cantColorBomb= 0;


    //PODER2
    public bool power2 = false; // indica si todos los diamond in screen deben destruirse
    public Color colorPower2; // indica que color de diamante activa la bomba
    public Color colorDestroyPower2; // indica  color a destruir
    public int cantColorPower2= 0;


    //PODER3
    public bool power3 = false; // indica si todos los diamond in screen deben destruirse
    public Color colorPower3; // indica que color de diamante activa la bomba
    public Color colorDestroyPower3; // indica  color a destruir
    public int cantColorPower3= 0;



    public Color[] lastColors; // guarda los ultimos tres colores tocados


    // Start is called before the first frame update
    void Start()
    {
        puntajeActual = this;

        puntaje = 0;
        frecuencia = 4;
        lapso = 10;
        begin = 1;

        Deactivate();
        panelInicio.SetActive(true);
        excluirLength = excluirColor.Length;
        //excluirElColor();
        colorAnterior= Color.black;

        secuencia = true;
        x = 0;
        diamondInScreen = 0;

        bomb = false; 
        cantColorBomb = 0;

        lastColors = new Color[3];
        
        
    }



    void Update()
    {
        /*
        if (Time.time > lapso)
        {
            velocidadAsteroide += incrementoVelocidad;
            
            lapso += incrementoLapso;
            
            frecuencia -= 1;
            if (frecuencia <= 1) frecuencia = 1;
        }*/

        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) && panelInicio.activeInHierarchy)
        {
            //panelInicio.SetActive(false);
            Activate();
        }


    }


   
    public void ActualizarPuntaje()
    {
        //puntaje++;
        puntaje+=5;
        muestraPuntaje.text = puntaje.ToString();
        if (puntaje % 10 == 0)
        {
            Vida.vidaPlayer.Sanar();
        }
    }

    public void RestarPuntaje()
    {
        puntaje--;
        if (puntaje <= 0)
        {
            puntaje = 0;
        }
        muestraPuntaje.text = puntaje.ToString();
    }


    public void ControlarColorBomb(Color colorObject)
    {
        if (colorObject == colorBomb)
        {
            cantColorBomb++;
            if (cantColorBomb >= 3)
            {
                //Diamond.diamond.DestroyAll();
                bomb = true;
                cantColorBomb = 0;
            }
        }

    }


   public void ControlarColorPower2(Color colorObject)
    {
        if (colorObject == colorPower2)
        {
            cantColorPower2++;
            if (cantColorPower2 >= 3)
            {
                //Diamond.diamond.DestroyColor(colorPower2);
                power2 = true;
                cantColorPower2 = 0;
            }
        }

    }


   public void ControlarColorPower2(Color colorObject)
    {
        if (colorObject == colorPower2)
        {
            cantColorPower2++;
            if (cantColorPower2 >= 3)
            {
                //Diamond.diamond.DestroyColor(colorPower2);
                power2 = true;
                cantColorPower2 = 0;
            }
        }

    }



    public void VerificarPar(Color colorObject)
    {
        if (colorObject == colorAnterior)
        {
                       
            ActualizarPuntaje();
        }
        colorAnterior = colorObject;
    }

    public void VerificarColor(Color colorObject)
    {
        if (colorObject == colorControl)
        {
            Vida.vidaPlayer.Danio();
        }else{
            Diamond.diamond.Efectos();
            ActualizarPuntaje();
        }
    }

    void excluirElColor()
    {
        colorControl = excluirColor[Random.Range(1,excluirLength)];
        
        imgColor.color = colorControl;
    }

    void changeBoxColor()
    {
        colorControl = excluirColor[Random.Range(1,excluirLength)];
        boxColor.GetComponent<SpriteRenderer>().color = colorControl;
    }

    void changeBorderCanasto()
    {
        colorControl = excluirColor[Random.Range(1,excluirLength)];

        for (int i = 0; i < boxColor.transform.childCount; i++)
        {
            boxColor.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = colorControl;
        }
        
    }

    void changeBarreras()
    {
        for (int i = 0; i < boxColor.transform.childCount; i++)
        {
            colorControl = excluirColor[Random.Range(1,excluirLength)];

            boxColor.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().color = colorControl;
        }
        
    }

    public void VerificarCoincidencia(Color colorObject)
    {
        
        if (colorObject == colorControl)
        {
            ActualizarPuntaje();
            
        }else{
            Vida.vidaPlayer.Danio();
        }
    }

    public void Verificar5(Color colorObject)
    {
        if (colorObject == excluirColor[x])
        {
            secuencia = true;
            x++;
            if (x == excluirColor.Length)
            {
                Diamond.diamond.Efectos();
                x = 0;
                for (int i = 0; i < 5; i++)
                {
                    ActualizarPuntaje();
                }
                
            }
        }else{
            secuencia = false;
            x = 0;
            Vida.vidaPlayer.Danio();
        }
    }


    public void VerificarFinal()
    {
        if (Perder1.perder1.escenaActual() == 8)  Perder1.perder1.perder();
    }


    public void VerificarCanasto(GameObject perla)
    {
        if ((perla.GetComponent<SpriteRenderer>().color == Color.blue && !(perla.transform.position.x <0 && perla.transform.position.y > 0))
            || (perla.GetComponent<SpriteRenderer>().color == Color.red && !(perla.transform.position.x >0 && perla.transform.position.y > 0))
            || (perla.GetComponent<SpriteRenderer>().color == new Color(1f, 1f, 0f, 1f) && !(perla.transform.position.x < -4 && perla.transform.position.y < 0))
            || (perla.GetComponent<SpriteRenderer>().color == Color.white && !(perla.transform.position.x >-2.5 && perla.transform.position.x <2.5 && perla.transform.position.y < 0))
            || (perla.GetComponent<SpriteRenderer>().color == Color.green && !(perla.transform.position.x >4 && perla.transform.position.y < 0)))
        {
            ActualizarPuntaje();
            Destroy(perla);
        }else{
            Vida.vidaPlayer.Danio();
        }
    }

    public void VerSiResta(GameObject perla)
    {
        if ((perla.GetComponent<SpriteRenderer>().color == Color.blue && !(perla.transform.position.x <0 && perla.transform.position.y > 0))
            || (perla.GetComponent<SpriteRenderer>().color == Color.red && !(perla.transform.position.x >0 && perla.transform.position.y > 0))
            || (perla.GetComponent<SpriteRenderer>().color == new Color(1f, 1f, 0f, 1f) && !(perla.transform.position.x < -4 && perla.transform.position.y < 0))
            || (perla.GetComponent<SpriteRenderer>().color == Color.white && !(perla.transform.position.x >-2.5 && perla.transform.position.x <2.5 && perla.transform.position.y < 0))
            || (perla.GetComponent<SpriteRenderer>().color == Color.green && !(perla.transform.position.x >4 && perla.transform.position.y < 0)))
        {
            Vida.vidaPlayer.Danio();
            Destroy(perla);
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
