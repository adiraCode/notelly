using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitGame : MonoBehaviour
{
    // Exits the applicaiton
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }
}
