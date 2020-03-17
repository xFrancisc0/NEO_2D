using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seguir : MonoBehaviour
{
    public Transform objetoASeguir;
    public float distancia = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = new Vector3(objetoASeguir.position.x, objetoASeguir.position.y + 4, objetoASeguir.position.z - distancia);


        //this.transform.eulerAngles = new Vector3(this.transform.eulerAngles.x, objetoASeguir.eulerAngles.y, objetoASeguir.eulerAngles.z);
        //this.transform.LookAt(objetoASeguir);
    }
}
