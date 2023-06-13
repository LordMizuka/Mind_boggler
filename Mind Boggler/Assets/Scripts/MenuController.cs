using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public AudioSource playButtonFX;
    public AudioSource quitButtonFX;

    public void Play()

    {
        SceneManager.LoadSceneAsync("Game");
    }




    public void PlayButton()

    {
        playButtonFX.Play();
        Invoke(nameof(Play), 1);
    }




    // Start is called before the first frame update
    void Start()
    {


    }



    public void Quit()
    {
        Application.Quit();
    }


    public void QuitButton()
    {
        quitButtonFX.Play();
        Invoke(nameof(Quit), 1);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
