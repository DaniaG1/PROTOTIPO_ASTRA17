using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloog : MonoBehaviour
{
    private Rigidbody2D Rigbody;

    public Astronauta Astronauta;

    private Animator Animator;

    public GameObject PoisonB;

    private float distancia;

    private float difVertical;

    //Determina el tiempo entre ataques.
    private float lastPoisonB;

    // Start is called before the first frame update
    void Start()
    {
        Rigbody = GetComponent<Rigidbody2D>();

        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Calcula la distancia horizontal con la ubicacion del Astronauta.
        if(transform.position.x < 0.0f)
        {
            distancia = Mathf.Abs(Astronauta.transform.position.x - (transform.position.x*-1));
        }
        else { distancia = Mathf.Abs(Astronauta.transform.position.x - transform.position.x); }

        //Determina la diferencia con la ubicación vertical del Astronauta.
        if(transform.position.y < 0.0f && Astronauta.transform.position.y > 0.0f)
        {
            difVertical = Mathf.Abs(Astronauta.transform.position.y - (transform.position.y*-1));
        }
        else { difVertical = Mathf.Abs(Astronauta.transform.position.y - transform.position.y); }
    }

    void FixedUpdate()
    {
        //Cambiar la direccion horizontal de acuerdo a la posicion del Astronauta.
        Vector3 direccion = Astronauta.transform.position - transform.position;
        if(direccion.x >= 0.0f) { transform.localScale = new Vector3(-1.8f, 1.8f, 1f);}
        else { transform.localScale = new Vector3(1.8f, 1.8f, 1f);}
        
        //Ataca al Astronauta cuando este lo suficientemente cerca.
        if( distancia >= 7.3f && distancia <= 28.02f)
        {
           Animator.SetBool("attack", difVertical <= 1.11f);
           StartCoroutine(Atacar());
        }
    }

    public float distanciaAstronauta()
    {
        return distancia;
    }

    IEnumerator Atacar()
    {
        yield return new WaitForSeconds (2.5f);
        if(Animator.GetBool("attack") == true && Time.time > lastPoisonB)
        {
            //Determina la direccion del laser con respecto al Bloog.
            Vector3 direccion = Vector3.left;
            float x = -1.7f;
            if(transform.localScale.x == -1.8f)
            {
                direccion = Vector3.right;
                x = 1.7f;
            }

            lastPoisonB = Time.time + 3.3f;
        
            //Lanza el liquido toxico por defefcto del Bloog.
            GameObject poisonDefecto = Instantiate(PoisonB, transform.position + new Vector3(x, -0.2f, 0), Quaternion.identity);
            //Cambia la direccion del laser con respecto al mostruo Bloog.
            poisonDefecto.GetComponent<PoisonBloog>().Setdireccion(direccion);
            Debug.Log(lastPoisonB + "   time.time:" + Time.time);
        }
    }

    
}
