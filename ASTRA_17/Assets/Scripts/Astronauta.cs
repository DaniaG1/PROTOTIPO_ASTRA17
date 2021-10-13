using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronauta : MonoBehaviour
{
    //
    private Rigidbody2D Rigbody;

 
    private float Horizontal;

    //Fuerza del salto del Heroe.
    public float Jumforce;

    //Velocidad de salto del Heroe.
    public float speed;

    //Variable que determina si el Heroe toca el suelo o no.
    private bool Grounded;

    private bool movement = true;
    public GameObject disparoL;

    // Start is called before the first frame update
    void Start()
    {
        Rigbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        Horizontal = Input.GetAxisRaw("Horizontal");

        //
        Debug.DrawRay(transform.position, Vector3.down * 100f, Color.red);

        //Determina si el Heroe está en el suelo para poder saltar al precionar la tecla W.
        if ( Input.GetKeyDown(KeyCode.W))
        {
            Jump();
        }
        disparoPersonaje();
    }

    public void FixedUpdate()
    {


        float h = Input.GetAxis("Horizontal");
        if (!movement) h = 0;

        Rigbody.velocity = new Vector2(Horizontal, Rigbody.velocity.y);

        float limitedSpeed = Mathf.Clamp(Rigbody.velocity.x, -1f, 1f);
        Rigbody.velocity = new Vector2(limitedSpeed, Rigbody.velocity.y);

        if (h > 0.1f)
        {
            transform.localScale = new Vector3(0.5157091f, 0.5486222f, 1f);
        }
        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-0.5157091f, 0.5486222f, 1f);
        }
    }

    private void Jump()
    {
        Rigbody.AddForce(Vector2.up * Jumforce);
    }
    void disparoPersonaje()
    {
        //Disparo de una bala con la tecla espacio
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Instantiate(disparoL, transform.position + new Vector3(1.5f, -0.05f, 0), Quaternion.identity);

        }
    }

}
