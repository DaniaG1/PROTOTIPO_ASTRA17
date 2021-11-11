using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float velDisparo = 5.0f;
    private Rigidbody2D Rigbody;
    private float Horizontal;

    private Vector3 direccion = Vector3.right;

    void Start()
    {
        Rigbody = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Rigbody.velocity = new Vector2(Horizontal * velDisparo, Rigbody.velocity.y);
        Rigbody.transform.Translate (direccion * velDisparo * Time.deltaTime);    
    }

    public void Setdireccion(Vector3 direc)
    {
        if(direc == Vector3.left)
        {
            transform.localScale = new Vector3(-2.4283f, 2.6403f, 1f);
        }
        direccion = direc;
    }

    private void  OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "bloog")
        {
            Destroy(this.gameObject);
        }
    }
}