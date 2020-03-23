using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlador_menu : MonoBehaviour
{
    public AudioSource pausa;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void opcion_elegida()
    {
        pausa.Play();
    }
}
