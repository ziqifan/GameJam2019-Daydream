using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using FMODUnity;
public class PauseGame : MonoBehaviour
{
    public GameObject audio;
    public GameObject pauseScreen;
    public GameObject particle;

    public static bool isPause = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A) && !isPause)
        {
            pause();
        }
    }

    public void pause()
    {
        pauseScreen.SetActive(true) ;
        Time.timeScale = 0.0f;
        isPause = true;
        //particle.SetActive(true);
    }

    public void resume()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        isPause = false;
        //particle.SetActive(false);
    }

    public void goManu()
    {
        audio.SetActive(false);
        SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        Time.timeScale = 1.0f;
    }
}
