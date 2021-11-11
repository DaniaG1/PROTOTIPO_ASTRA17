using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBloog : MonoBehaviour
{
    [SerializeField]
    private float velPoison = 5.0f;
    private Rigidbody2D Rigbody;
    private float Horizontal;

    private Vector3 direccion = Vector3.left;

    // Start is called before the first frame update
    void Start()
    {
        Rigbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        Rigbody.velocity = new Vector2(Horizontal * velPoison, Rigbody.velocity.y);
        Rigbody.transform.Translate (direccion * velPoison* Time.deltaTime);
    }

    public void Setdireccion(Vector3 direc)
    {
        if(direc == Vector3.right)
        {
            transform.localScale = new Vector3(-2f, 2f, 1f);
        }
        direccion = direc;
    }

    private void  OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (collision.gameObject.name == "Astronauta")
        {
            Destroy(this.gameObject);
        }
    }
}
