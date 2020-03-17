using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    public int daño;
    public Tipo tipoObstaculo;

    public enum Tipo { madera, metal, fuego, hielo, toxico, piedra};

    // Start is called before the first frame update
    void Start()
    {
        if (this.gameObject.name == "lava_suelo")
        {
            daño = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
