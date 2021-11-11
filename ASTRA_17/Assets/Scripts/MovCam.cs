using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCam : MonoBehaviour
{
    public GameObject Astronauta;

    //La camara se mueve con el Astronauta.
    void Update()
    {
        //Posición de la cámara.
        Vector3 position = transform.position;
        //Posición vertical de de acuerdo al movimiento horixontal del astronauta.
        position.x = Astronauta.transform.position.x;
        //Posición horizontal.
        position.y = Astronauta.transform.position.y;
        //Cambia la pisición de la camara.
        transform.position = position;
    }
}
