using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float velDisparo = 5.0f;
    public GameObject bloog;
    private Rigidbody2D Rigbody;
    public GameObject astronauta;
    private float Horizontal;

    void Start()
    {
        Rigbody = GetComponent<Rigidbody2D>();
        Horizontal = Input.GetAxisRaw("Horizontal");
    }


    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Rigbody.velocity = new Vector2(Horizontal * velDisparo, Rigbody.velocity.y);
        Rigbody.transform.Translate (Vector3.right * velDisparo * Time.deltaTime);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "hero")
        {
            Destroy(this.gameObject, -.5f);
        }
    }
}