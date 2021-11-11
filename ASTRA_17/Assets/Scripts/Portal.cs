using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject PortalS;
    public GameObject Astronauta;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D (Collider2D collision)
    {
        if(collision.gameObject.name == "Astronauta")
        {
            GameObject portal = Instantiate(PortalS, new Vector3(-4.658f, 3.534f,0), Quaternion.identity);
            StartCoroutine (Teleport());
        }
    }

    IEnumerator Teleport()
    {
        yield return new WaitForSeconds (0.1f);
        Astronauta.transform.position = new Vector2(PortalS.transform.position.x, PortalS.transform.position.y - 0.5f);
    }
}
