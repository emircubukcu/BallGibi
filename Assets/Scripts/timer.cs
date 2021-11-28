using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    private GameObject GameOver;
    [SerializeField]
    public TMP_Text timerr;
    float currentTime = 0f;
    float startingTime = 60f;
    int holdTime;
    // Start is called before the first frame update
    void Start()
    {
        GameOver=GameObject.FindWithTag("GameOver");
        currentTime = startingTime;
        GameOver.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        holdTime = (int)currentTime;
        
        if (holdTime == 0)
        {
            timerr.text = "Time : " + holdTime.ToString();
            GameOver.SetActive(true);
        }
        else{
            currentTime = currentTime - 1 * Time.deltaTime;
            timerr.text = "Time : " + holdTime.ToString();
        }
    }
    public void RestartButton(){
        SceneManager.LoadScene(1);
    }
    public void MainMenuButton(){
        SceneManager.LoadScene(0);
    }
}
