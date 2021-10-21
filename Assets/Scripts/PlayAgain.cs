using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayAgain : MonoBehaviour
{

    public string sceneName;
   

    public void playAgain()
    {
        SceneManager.LoadScene(sceneName);
    }
}
