using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raqueta : MonoBehaviour
{
    //Velodidad de la raqueta
    public float velocidad=30.0f;

    //Eje Vertical
    public string ejeHorizontal;
    public string ejeVertical;

    public BoxCollider2D centroCollider;
    
    


   

   
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Captop el valor del eje vertical y horizontal de la raqueta
        float x=Input.GetAxisRaw(ejeHorizontal);
        float y = Input.GetAxisRaw(ejeVertical);
        //Modifico la velocidad de la raqueta
       Vector3 movimiento = new Vector3 (velocidad*x , velocidad*y, 0);

       movimiento*= Time.deltaTime;

       transform.Translate(movimiento);
       
    }


    public void OnTriggerEnter2D(Collider2D col) 
    {
        if (col.tag=="block")
        {
            col.isTrigger=false;
        
           Debug.Log("Ha entrado");

           

        }

       
        
    }

    public void OnTriggerExit2D(Collider2D other) {
        if (other.tag=="key")
        {
            centroCollider.isTrigger=true;
            Debug.Log("saliste de un collider");
        }
    }

    
}
