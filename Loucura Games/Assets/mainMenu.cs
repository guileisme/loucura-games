using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public AudioSource music;

    private void Start()
    {
        music = GetComponent<AudioSource>();
        music.Play();
    }
    public void startButton()
    {
        SceneManager.LoadScene("MenuPersonagens");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
