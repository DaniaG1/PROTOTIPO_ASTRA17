
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeysR : MonoBehaviour
{
    public Sprite[] spriteList;

    private SpriteRenderer spriteRenderer; 

    public GameObject Astronauta;

    // Start is called before the first frame update
    void Start()
    {
       spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        int c = Astronauta.GetComponent<Astronauta>().CantKeys();
        spriteRenderer.sprite = spriteList [c];
    }
}
