using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    public void RestartGame()
    {
        Debug.Log("Scene Reloaded");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
    }
}
