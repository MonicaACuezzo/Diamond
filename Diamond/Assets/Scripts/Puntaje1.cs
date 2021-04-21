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

    //public static float velocidadAsteroide = 2;
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

    //PODER1  --------   BOMBA
    public bool bomb = false; // indica si todos los diamond in screen deben destruirse
    public Color colorBomb; // indica que color de diamante activa la bomba
    public int cantColorBomb= 0; // cuenta los cristales del color indicado
    public float stopBomb;  //lapso que debe estar activo el poder
    public int totColorBomb= 0; // cuenta los cristales del color indicado
    public GameObject imagenBomb; // barra que indica el nivel acumulado  del poder


    //PODER2     ------ rompiendo el color que da el poder ROMPE TODOS LOS DE UN COLOR INDICADO
    public bool power2 = false; // indica si el poder esta activo
    public Color colorPower2; // indica que color de diamante activa el poder
    public Color colorDestroyPower2; // indica  color a destruir
    public int cantColorPower2= 0; // cuenta los cristales que se van rompiendo
    public float stopPower2; //lapso que debe estar activo el poder
    public int totPower2= 0; // total de cristales para activar el poder
    public GameObject imagenPower2;  // barra que indica el nivel acumulado  del poder


    //PODER3
    public bool power3 = false; // indica si todos los diamond in screen deben destruirse
    public Color colorPower3; // indica que color de diamante activa la bomba
    public Color colorDestroyPower3; // indica  color a destruir
    public int cantColorPower3= 0;
    public float stopPower3;
    public int totPower3= 0; // total de cristales para activar el poder
    public GameObject imagenPower3;  // barra que indica el nivel acumulado  del poder


    //PODER4   ----- COLOR destruye  COLUMNA
    public bool power4 = false; // indica si el poder esta activo
    public Color colorPower4; // indica que color de diamante activa el poder
    public float  transformDestroyPower4; // indica  columna a destruir
    public int cantColorPower4= 0;  // contador de cristales que activan el poder
    public float stopPower4;  //lapso que debe estar activo el poder
    public int totPower4= 0; // total de cristales para activar el poder
    public GameObject imagenPower4;  // barra que indica el nivel acumulado  del poder




    //public Color[] lastColors; // guarda los ultimos tres colores tocados


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

        //lastColors = new Color[3];
        
        
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

        if (bomb)   if (Time.time > stopBomb)   bomb = false;
        if (power2)   if (Time.time > stopPower2)   power2 = false;
        if (power3)   if (Time.time > stopPower3)   power3 = false;
        if (power4)   if (Time.time > stopPower4)   power4 = false;

        if ((Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(0)) && panelInicio.activeInHierarchy)
        {
            panelInicio.SetActive(false);
            Activate();
        }


    }


   
    public void ActualizarPuntaje()
    {
        puntaje+=5;  //puntaje++;
        muestraPuntaje.text = puntaje.ToString();
    }

    public void RestarPuntaje()
    {
        puntaje--;
        if (puntaje <= 0)   puntaje = 0;
        muestraPuntaje.text = puntaje.ToString();
    }


    public void ControlarColorBomb(Color colorObject)  // poder BOMBA
    {
        if (colorObject == colorBomb)
        {
            cantColorBomb++;
            barraIndicadoraPoder(imagenBomb, cantColorBomb*10, colorBomb);
            if (cantColorBomb >= totColorBomb)
            {
                bomb = true;
                stopBomb = Time.time + 1.0f;
                cantColorBomb = 0;
                barraIndicadoraPoder(imagenBomb, cantColorBomb*10, colorBomb);
            }
        }
    }




   public void ControlarColorPower2(Color colorObject)  // poder COLOR mata a COLOR
    {
        if (colorObject == colorPower2)
        {
            cantColorPower2++;
            barraIndicadoraPoder(imagenPower2, cantColorPower2*10, colorPower2);
            if (cantColorPower2 >= totPower2)
            {
                power2 = true;
                stopPower2 = Time.time + 1.0f;
                cantColorPower2 = 0;
                barraIndicadoraPoder(imagenPower2, cantColorPower2*10, colorPower2);
            }
        }
    }


   public void ControlarColorPower3(Color colorObject)
    {
        if (colorObject == colorPower3)
        {
            cantColorPower3++;
            barraIndicadoraPoder(imagenPower3, cantColorPower3*10, colorPower3);
            if (cantColorPower3 >= totPower3)
            {
                power3 = true;
                stopPower3 = Time.time + 1.0f;
                cantColorPower3 = 0;
                barraIndicadoraPoder(imagenPower3, cantColorPower3*10, colorPower3);
            }
        }
    }

   public void ControlarColorPower4(Color colorObject, Transform transformObject)   // poder COLUMNA
    {
        //Debug.Log(transformObject.position);

        if (colorObject == colorPower4)
        {
            cantColorPower4++;
            barraIndicadoraPoder(imagenPower4, cantColorPower4*10, colorPower4);
            
            if (cantColorPower4 >= totPower4)
            {
                transformDestroyPower4 = transformObject.position.x;
                
                power4 = true;
                stopPower4 = Time.time + 1.0f;
                cantColorPower4 = 0;
                barraIndicadoraPoder(imagenPower4, cantColorPower4*10, colorPower4);
            }
        }
    }


   public void RestarPoderes()   // perder los  PODERES por matar un enemigo
    {
        cantColorBomb = cantColorPower2 = cantColorPower3 = cantColorPower4 = 0;

        barraIndicadoraPoder(imagenBomb, 0, colorBomb);
        barraIndicadoraPoder(imagenPower2, 0, colorPower2);
        barraIndicadoraPoder(imagenPower3, 0, colorPower3);
        barraIndicadoraPoder(imagenPower4, 0, colorPower4);
    }


    public void barraIndicadoraPoder(GameObject imagen, int valorPoder, Color colorBarra)
    {

        float valor =  (valorPoder/100f);
        float texto = valor *100f;
        if (texto <= 0)  
        {
            texto = 0;
        
            imagen.transform.localScale = new Vector3(.5f,0.5f,0);
            imagen.GetComponent<Image>().color = new Color(1f, 1f, 1f, 0.39f);
        }else{
            imagen.transform.localScale = new Vector3(valor,0.5f,0);
            imagen.GetComponent<Image>().color = colorBarra;
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
