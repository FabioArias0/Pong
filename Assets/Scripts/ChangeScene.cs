using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // si pulsa la tecla P o hace clic izquierdo empieza el juego
        if (Input.GetKeyDown(KeyCode.P)|| Input.GetKeyDown("space"))
        {
            //cargo la escena del juego 
            //nombre de la scena del juego
            SceneManager.LoadScene("Juego");
        }
    }
}
