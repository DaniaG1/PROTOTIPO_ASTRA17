using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovCam : MonoBehaviour
{
    public GameObject Heroe;

    //La camara se horixontalmente con el Heroe.
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Heroe.transform.position.x;
        transform.position = position;
    }
}
