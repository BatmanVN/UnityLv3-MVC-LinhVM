using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void PlayGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
