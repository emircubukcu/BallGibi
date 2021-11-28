using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class game_control : MonoBehaviour
{
    [SerializeField]
    public TMPro.TMP_Text score;
    public int scoree = 0;
    [SerializeField]
    private GameObject ballPrefab;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject RefCube;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   

        private void OnTriggerEnter(Collider other)
    {
        //Check to see if the tag on the collider is equal to Enemy

        if (other.tag == "Player" && gameObject.tag == "Start"&&!GameObject.FindWithTag("ball"))
        {    
            //Vector3 position = new Vector3(23, 2, -23);
            Vector3 position=RefCube.transform.position;
            GameObject ball=Instantiate(ballPrefab, position, Quaternion.identity);
            ball.transform.parent = player.transform;
                
            Debug.Log("Triggered by Start");
            
        }
        
        if(other.tag == "Player" && gameObject.tag == "Finish"&&GameObject.FindWithTag("ball"))
        {
            Destroy(GameObject.FindWithTag("ball"));
            scoree = 1 + scoree;   
            score.text = "Score : "+scoree.ToString();
            
            Debug.Log("Triggered by Finish");
        }
    }
}


