using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenucontroller : MonoBehaviour
{
   public void PlayGame(){
    int selectedCharacter=
        int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

    gameManager.instance.CharIndex=selectedCharacter;
    
    SceneManager.LoadScene("Gameplay");
   }
}
