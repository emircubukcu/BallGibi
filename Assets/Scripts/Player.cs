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
