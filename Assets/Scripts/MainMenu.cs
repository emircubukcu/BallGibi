using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public AudioClip clip;

    public GameObject LoadSaveButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadScene(){
        
        Time.timeScale=1.0f;
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
        
    }
    public void SaveContinue(){
       
        PlayerPrefs.SetInt("save",1);
        Time.timeScale=1.0f;
        SceneManager.LoadScene(PlayerPrefs.GetInt("scene"));
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
