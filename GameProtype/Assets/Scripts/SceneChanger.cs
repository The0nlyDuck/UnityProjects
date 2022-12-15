using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /// <summary>
    /// A scene changer for buttons
    /// </summary>
    /// <param name="load">The Next level to load in</param>
    public void ChangeScene(string load)
    {
        SceneManager.LoadScene(load);
    }

    /// <summary>
    /// Closes the Game
    /// </summary>
    public void CloseGame()
    {
        Application.Quit();
    }
}
