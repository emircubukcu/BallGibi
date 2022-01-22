using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float rotSpeed = 20.0f;
    private Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if(PlayerPrefs.GetInt("save")==1){
            transform.position=new Vector3(
                PlayerPrefs.GetFloat("posX"),
                PlayerPrefs.GetFloat("posY"),
                PlayerPrefs.GetFloat("posZ")
            );
            transform.rotation=new Quaternion(
                PlayerPrefs.GetFloat("rotX"),
                PlayerPrefs.GetFloat("rotY"),
                PlayerPrefs.GetFloat("rotZ"),
                0
            );
            transform.localScale=new Vector3(
                PlayerPrefs.GetFloat("scaleX"),
                PlayerPrefs.GetFloat("scaleY"),
                PlayerPrefs.GetFloat("scaleZ")
            );
        }
    }

    // Update is called once per frame
    void Update()
    {
        float rotX = Input.GetAxis("Mouse X") * rotSpeed;
        transform.rotation = transform.rotation * Quaternion.Euler(0, rotX, 0);
    }
    private void FixedUpdate()
    {
        Vector3 hareketVektoru = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rigidbody.AddRelativeForce(hareketVektoru.normalized * speed);
        //rigidbody.velocity = hareketVekt�r� * speed;
    }
}
