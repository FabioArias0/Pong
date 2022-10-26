using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameWin : MonoBehaviour
{
   public void reiniciar(){
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   Time.timeScale=1;
   }

   public void mainMenu(string nombre){
    SceneManager.LoadScene(nombre);
   }
}
