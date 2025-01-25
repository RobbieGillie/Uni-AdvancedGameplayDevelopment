using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class MyMethods : MonoBehaviour
{
    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    
    public void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
    
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    public void Pause()
    {
        Time.timeScale = 0;
    }
    
    public void Unpause()
    {
        Time.timeScale = 1;
    }
    
    public void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    
    public void DisableMenu(GameObject menu)
    {
        menu.gameObject.SetActive(false);
    }
    
    public void EnableMenu(GameObject menu)
    {
        menu.gameObject.SetActive(true);
    }

    public void OutOfBounds(GameObject player)
    {
        player.transform.position = new Vector3(9, 1, 0);
    }
}
