using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class karakter : MonoBehaviour
{
    float hiz=5f;
    public float ziplamaGücü;
    private bool karakterYerde;
    public Rigidbody rb;
    private float Hareket;

    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        
    }    
    void Update()
    {
        Hareket = Input.GetAxis("Horizontal");
        rb.velocity=new Vector2 (Hareket*hiz, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetButtonDown("Jump") && karakterYerde == true)
        {
            rb.AddForce(Vector2.up * ziplamaGücü, ForceMode.Impulse);
            karakterYerde = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("animasyon 1 baþlat");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("animasyon 2 baþlat");
        }
    }
    private void OnCollisionEnter(Collision yerTemasi)
    {
        if (yerTemasi.gameObject.tag=="zemin")
        {
            karakterYerde = true;
        }
    }
  
}
