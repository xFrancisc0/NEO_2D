using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int puntosOtorgados = 5;
    public int tiempoDuracion;
    public AudioSource sonidoMoneda;
    public CapsuleCollider collider;
    public Tipo tipoMoneda = Tipo.bronce;

    public List<Material> materialesCoin;

    public enum Tipo { bronce, plata, oro };

    // Constructor de la clase
    public Moneda(Tipo tipoCoin)
    {
        this.tipoMoneda = tipoCoin;
    }

    // Start is called before the first frame update
    void Start()
    {
        switch (tipoMoneda)
        {
            case Tipo.bronce:
                puntosOtorgados = 5;
                this.gameObject.GetComponent<MeshRenderer>().material = materialesCoin[0];
                break;
            case Tipo.plata:
                puntosOtorgados = 10;
                this.gameObject.GetComponent<MeshRenderer>().material = materialesCoin[1];
                break;
            case Tipo.oro:
                puntosOtorgados = 20;
                this.gameObject.GetComponent<MeshRenderer>().material = materialesCoin[2];
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
