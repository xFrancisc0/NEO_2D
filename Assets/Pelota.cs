using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pelota : MonoBehaviour
{



    // Start is called before the first frame update
    void Start()
    {
        // PARTE 1
        //Debug.Log("HOLA, ESTOY EN START");
        //Debug.Log("EL NOMBRE DEL OBJETO ES: " + caja.name);

        //caja.GetComponent<Rigidbody>().useGravity = false;
        //rigidbodyCaja.useGravity = false;

        //if (caja.GetComponent<Camera>() == null)
        //{
        //    //Debug.Log("NO HAY CAMARA IDIOTA!");
        //}

        //rigidbodyPelota = this.GetComponent<Rigidbody>();
        //arregloAudios = this.GetComponents<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButton("Fire1") == true)
        //if(Input.GetAxis(")
        //{
        //    this.GetComponent<Rigidbody>().AddForce(5, 0, 0);
        //}

        //Debug.Log("EJE HORIZONTAL: " + Input.GetAxis("Horizontal"));
        //this.GetComponent<Rigidbody>().AddForce(5*Input.GetAxis("Horizontal"), 0, 0);
        this.GetComponent<Rigidbody>().AddForce(5 * Input.GetAxis("Horizontal"), (Input.GetButtonDown("Jump") ? 500 : 0), 5 * Input.GetAxis("Vertical"));
        //if(Input.GetButtonDown("Jump") == true)
        //    this.GetComponent<Rigidbody>().AddForce(0, 100, 0);

        //rigidbodyPelota.AddForce(new Vector3(1, 0, 0));

        //this.transform.GetChild(0);
        //this.transform.position = new Vector3(1, 0, 0);
        //this.transform.Translate(new Vector3(1, 0, 0));
        //this.transform.eulerAngles = new Vector3(45, 0, 0);
        //this.transform.Rotate(45, 0, 0);

        //this.transform.SetParent(null);

        //RotaPelota(new Vector3(1, 0, 0));

        // PARTE 2
        //Debug.Log("... Y AHORA ESTOY EN UPDATE");

        // PARTE 3
        //if(gatillo == true)
        //{
        //    //Debug.Log("SE ACTIVO GATILLO!");

        //    Debug.Log("LA PELOTA ES DE MARCA " + marcaPelota);
        //}



    }

    public void RotaPelota()
    {
        this.transform.Rotate(1f, 0f, 0f);
    }

    public void RotaPelota(Vector3 rotacionNueva)
    {
        this.transform.Rotate(rotacionNueva);
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "paredFisica")
        {
            Debug.Log("CHOQUE CON FIN DEL MUNDO EN " + col.gameObject.name);
        }

        switch(col.gameObject.tag)
        {
            case "paredFisica":
                break;

            case "sueloFisico":
                break;

            default:
                break;
        }
    }

    //void OnCollisionStay(Collision col)
    //{
    //    Debug.Log("ESTOY CHOCANDO CON " + col.gameObject.name);
    //}

    //void OnCollisionExit(Collision col)
    //{
    //    Debug.Log("DEJE DE CHOCHAR CON " + col.gameObject.name);
    //}

    //void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("ESTOY DETECTANDO A " + other.gameObject.name);
    //}

    //private void OnTriggerStay(Collider other)
    //{
    //    Debug.Log("ESTOY DENTRO DE " + other.gameObject.name);
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    Debug.Log("SALI DE DETECTAR " + other.gameObject.name);
    //}

}
