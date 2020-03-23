using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class datos_juego : MonoBehaviour
{
    public int cantidad_vidas;
    public AudioSource ganaste, herido, muerto, proyectil, proyectil2, salto, sonidoMoneda, ambientelava, pausa, acelerador;

    // Start is called before the first frame update

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        cantidad_vidas=3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
