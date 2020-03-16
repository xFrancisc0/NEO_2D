using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigue : MonoBehaviour
{
    public Transform seguido;
    public Vector3 vectorDiferencia;
    public Vector3 vectorDiferenciaAngulos;
    // Start is called before the first frame update
    void Start()
    {
        vectorDiferencia = seguido.position - this.transform.position;
        //vectorDiferenciaAngulos = seguido.eulerAngles - this.transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = seguido.position - vectorDiferencia;
        //this.transform.eulerAngles = seguido.eulerAngles - vectorDiferenciaAngulos;
    }
}
