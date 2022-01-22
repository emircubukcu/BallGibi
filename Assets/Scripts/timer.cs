using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class timer : MonoBehaviour
{
    private GameObject GameOver;
    public GameObject player;
    public  GameObject PauseMenu;
    private bool pauseMenuFlag=false;

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
        if(!pauseMenuFlag && Input.GetAxis("Cancel")>0.0f){
            Pause();
            pauseMenuFlag=true;
        }
        if(Input.GetAxis("Cancel") == 0.0f)
        {
            pauseMenuFlag = false;
        }

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
    void Pause(){
        if(PauseMenu.activeSelf==false){
            PauseMenu.SetActive(true);
            Time.timeScale=0.001f;
        }
        else if(PauseMenu.activeSelf==true){
            PauseMenu.SetActive(false);
            Time.timeScale=1.0f;
        }
    }
    public void ContinueButton(){
        PauseMenu.SetActive(false);
        Time.timeScale=1.0f;
    }
    public void RestartButton(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenuButton(){
        //Position
        PlayerPrefs.SetFloat("posX",player.transform.position.x);
        PlayerPrefs.SetFloat("posY",player.transform.position.y);
        PlayerPrefs.SetFloat("posZ",player.transform.position.z);
        //Rotation
        PlayerPrefs.SetFloat("rotX",player.transform.rotation.x);
        PlayerPrefs.SetFloat("rotY",player.transform.rotation.y);
        PlayerPrefs.SetFloat("rotZ",player.transform.rotation.z);
        //Scale
        PlayerPrefs.SetFloat("scaleX",player.transform.localScale.x);
        PlayerPrefs.SetFloat("scaleY",player.transform.localScale.y);
        PlayerPrefs.SetFloat("scaleZ",player.transform.localScale.z);
        //SceneIndex 
        PlayerPrefs.SetInt("scene",SceneManager.GetActiveScene().buildIndex);

        SceneManager.LoadScene(0);
    }
    public void NextLevelButton(){
        StartCoroutine("NextLevel");
    }
    IEnumerator NextLevel(){
        AsyncOperation asyncOperation=SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex+1);
        while(asyncOperation.isDone==false){
            yield return null;
        }
    }
}
