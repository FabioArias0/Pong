using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Bola : MonoBehaviour
{
    [SerializeField] private GameObject  MenuGanar;
    
    
     public AudioSource AudioJuego;
     public Text textoGanar;

    // Velocidad
    public float velocidad = 30.0f;
    //Contadores de puntos
    public int golesIzquierda = 0;
    public int golesDerecha = 0;

    //Cajas texto contadores
    public Text contadorIzquierda;
    public Text contadorDerecha;
    
    //Audio source
    AudioSource fuenteDeAudio;

    //Clips de audio
    public AudioClip audioGol, audioRaqueta, audioRebote, audioGanar; 

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale=1;
        GetComponent<Rigidbody2D>().velocity=Vector2.right*velocidad;
        //Contadores en 0
        contadorIzquierda.text=golesIzquierda.ToString();
        contadorDerecha.text=golesDerecha.ToString();

        //REcupero el componente audio source
        fuenteDeAudio= GetComponent<AudioSource>();

        settextoGanar();
        
    }


    void OnCollisionEnter2D(Collision2D micolision) {
        //si la bola colisiona con la raqueta:
        //micolision.gameObject es la raqueta
        // micolision.transform.position es la posicion de la raqueta

        //si choca con la raqueta izquierda
        if (micolision.gameObject.name=="RaquetaIzquierda")
        {
            //valor x
            int x = 1;
            
            //valor y
            int y = direccionY(transform.position,micolision.transform.position);

            //calculo direccion
            Vector2 direccion = new Vector2(x,y);

            //aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;
            
            //reproducir audio
            fuenteDeAudio.clip=audioRaqueta;
            fuenteDeAudio.Play();

            
        }

        //Si choca con la raqueta derecha
        if (micolision.gameObject.name=="RaquetaDerecha")
        {
            //valor x
            int x = -1;
            
            //valor y
            int y = direccionY(transform.position,micolision.transform.position);

            //calculo direccion
            Vector2 direccion = new Vector2(x,y);

            //aplico velocidad
            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            //Reproducir audio
            fuenteDeAudio.clip=audioRaqueta;
            fuenteDeAudio.Play();

             
        
        
        }

        if (micolision.gameObject.name=="Arriba"|| micolision.gameObject.name=="Abajo"){
            fuenteDeAudio.clip=audioRebote;
            fuenteDeAudio.Play();
        }
        
            
        
    }

    //Direccion y
    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta){
        if (posicionBola.y > posicionRaqueta.y)
        {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y){
            return -1;
        }
        else
        {
            return 0;
        
        }
    }

    //Reinicio la posicion de la bola
    public void reiniciarBola(string direccion){
        //posicion 0 de la bola
        transform.position=Vector2.zero;
        
        //velocidad inicial de la bola
        velocidad=30;

        //velocidad y direccion
        if (direccion=="izquierda")
        {
            //Incremento de goles a la derecha
            golesIzquierda++;
            contadorIzquierda.text = golesIzquierda.ToString();
            //Reinicio la bola
            GetComponent<Rigidbody2D>().velocity=Vector2.right * velocidad;
            //Debug.Log("Ha anotado un gol izquierda");
        }
        
        
        if (direccion=="Derecha")
        {
            golesDerecha++;
            contadorDerecha.text=golesDerecha.ToString();
            //reiniciar bola
            GetComponent<Rigidbody2D>().velocity=Vector2.left*velocidad;
            //Debug.Log("Ha marcado un gol Derecha");
        }
        
            
        //reproducir audio gol
        fuenteDeAudio.clip=audioGol;
        fuenteDeAudio.Play();
        
        if (golesDerecha>=5||golesIzquierda>=5)
        {
            fuenteDeAudio.clip=audioGanar;
            fuenteDeAudio.Play();
            AudioJuego.mute=true;
        }

        if (golesDerecha>=5||golesIzquierda>=5)
        {
            fuenteDeAudio.clip=audioGanar;
            fuenteDeAudio.Play();
            AudioJuego.mute=true;
        }

       

       
       
    }

    

    void settextoGanar(){
        if (golesDerecha>=5)
        {
            Time.timeScale=0;
            textoGanar.text="HAS GANADO JUGADOR 2";
            MenuGanar.SetActive(true);
            

        }
        else if (golesIzquierda>=5)
        {
            Time.timeScale=0;
            textoGanar.text="HAS GANADO JUGADOR 1";
            MenuGanar.SetActive(true);
            
       
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        

        settextoGanar();
       if (golesDerecha>=1 || golesIzquierda>=1)
       {
        velocidad = velocidad +0.01f;
       }

       
    }
}
