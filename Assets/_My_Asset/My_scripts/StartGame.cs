using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private string sceneName;
    private void Start()
    {
        button.onClick?.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1.0f;
    }
}
