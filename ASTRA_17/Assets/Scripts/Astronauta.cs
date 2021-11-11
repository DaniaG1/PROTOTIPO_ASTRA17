using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astronauta : MonoBehaviour
{
    private Rigidbody2D Rigbody;

    private Animator Animator;

    //Movimiento horizontal.
    private float Horizontal;

    //Movimiento vertial.
    private float Vertical;

    //Fuerza del salto del Astronauta.
    public float Jumpforce;

    //Velocidad de desplazamiento del Astronauta.
    public float speed;

    //Variable que determina si el Astronauta toca el suelo o no.
    private bool Grounded;

    public GameObject Laser1;

    private int cantK;

    // Start is called before the first frame update
    void Start()
    {
        Rigbody = GetComponent<Rigidbody2D>();

        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Captura el desplazamiento en x.
        Horizontal = Input.GetAxisRaw("Horizontal");

        //Activa la animación walk del Astronauta si existe un movimiento Horizontal.
        Animator.SetBool("movement", Horizontal != 0.0f);

        //Disparo del laser con la tecla espacio.
        if (Input.GetKeyUp(KeyCode.Space))
        { 
            disparoPersonaje();
        }

        //Impulso vertical (salto) con la tecla W.
        if( Input.GetKeyUp(KeyCode.W))
        {
           Jump();
        }
       
    }

    public void FixedUpdate()
    {   
        //Captura el valor del movimiento horizontal.
        float h = Horizontal;
        //Si el astronauta se mueve a la derecha, transforma su posicion para que gire en esa direccion en caso de que lo requiera.
        if (h > 0.1f) {transform.localScale = new Vector3(0.5157091f, 0.5486222f, 1f); }
        //Si el astronauta se mueve a la izquiera, transforma su posicion para que gire en esa direccion en caso de que lo requiera.
        else if (h < -0.1f) {transform.localScale = new Vector3(-0.5157091f, 0.5486222f, 1f);}
        else {  }

        //Velocidad con la que se desplaza el Astronauta (x,y).
        Rigbody.velocity = new Vector2(Horizontal * speed, Rigbody.velocity.y);

       
        
    }

    //Retorna la cantidad de llaves que ha recogido el Astronauta en el nivel.
    public int CantKeys ()
    {
        return cantK;
    } 

    //Permite que el Astronauta salte.
    private void Jump()
    {
        Rigbody.AddForce(Vector2.up * Jumpforce);   
    }
    
    private void disparoPersonaje()
    {
        //Determina la direccion del laser con respecto al astronauta.
        Vector3 direccion = Vector3.right;
        float x = 1.5f;
        if(transform.localScale.x < -0.1f)
        {
            direccion = Vector3.left;
            x = -1.5f;
        }
        
        //Dispara el laser por defefcto del astronauta.
        GameObject laserDefecto = Instantiate(Laser1, transform.position + new Vector3(x, -0.04f, 0), Quaternion.identity);
        //Cambia la direccion del laser con respecto al astronauta.
        laserDefecto.GetComponent<Laser>().Setdireccion(direccion);
    }

    //Realiza acciones de acuerdo a los objetos con los que colisione el Astronauta.
    private void  OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        //Aumenta la cantidad de llaves y elimina la llave recogida por el Astronauta.
        if(collision.gameObject.name == "Key")
        {
            cantK = cantK + 1;
            Destroy(collision.gameObject);
        }
        //Elimina el portal de salida.
        if(collision.gameObject.name == "PortalS(Clone)")
        {
           StartCoroutine(CerrarPortal(collision.gameObject));
        }
    }

    //Cierra el portal de salida por el que atravezo el Astronauta.
    IEnumerator CerrarPortal(GameObject portal)
    {
        yield return new WaitForSeconds (0.32f);
        Destroy(portal.gameObject);
    }

}
