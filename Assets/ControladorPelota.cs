using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPelota : MonoBehaviour
{
    public int vida = 100;
    public int puntos = 0;
    public float velocidad = 20f;
    public float velocidad_final;
    [Range(10f, 30f)]
    public float fuerzaSalto;
    public bool isCoroutineExecuting = false;
    public GameObject camara;
    public int modo_camara;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        float vel = this.GetComponent<Rigidbody>().velocity.z;

        //Velocidad limitada a un maximo de 10
        if (this.vida > 0 && Mathf.Abs(vel) <= 15 && modo_camara == 1)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 15 : 0f), velocidad * Input.GetAxis("Horizontal")));
        }

        if (this.vida > 0 && Mathf.Abs(vel) <= 15 && modo_camara == 2)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 15 : 0f), -velocidad * Input.GetAxis("Horizontal")));
        }
    }
    public bool esNivelSuelo = true;



    private void OnCollisionEnter(Collision collision)
    {

    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            Debug.Log("CHOCANDO CON SUELO");
            esNivelSuelo = true;
        }
        if (collision.gameObject.tag == "lava")
        {
            esNivelSuelo = true;
            DanoLava(collision);
        }

        if (collision.gameObject.tag == "obstaculo")
        {
            Debug.Log("NO ENCUENTRO EL SUELO!");
            esNivelSuelo = false;
        }
        if(collision.gameObject.tag == "acelerador")
        {
            Debug.Log("Se encontro un acelerador");
            esNivelSuelo = true;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 15 : 0f), 40));
        }
        if (collision.gameObject.tag == "acelerador_inverso")
        {
            Debug.Log("Se encontro un acelerador inverso");
            esNivelSuelo = true;
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 15 : 0f), -40));
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            Debug.Log("DEJE DE CHOCHAR CON SUELO");
            esNivelSuelo = false;
        }

        if (collision.gameObject.tag == "lava")
        {
            esNivelSuelo = false;
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "moneda")
        {
            FinalizaMoneda(col);
        }

        if (col.gameObject.tag == "checkpoint_frontal")
        {
            camara = GameObject.Find("Main_Camera");
            camara.GetComponent<Sigue>().checkpoint = 1;
            modo_camara = 1;
        }

        if (col.gameObject.tag == "checkpoint_reverso")
        {
            camara = GameObject.Find("Main_Camera");
            camara.GetComponent<Sigue>().checkpoint = 2;
            modo_camara = 2;
        }


    }

    public void FinalizaMoneda(Collider colider)
    {
        StartCoroutine(_FinalizaMoneda(colider));
    }

    IEnumerator _FinalizaMoneda(Collider colider)
    {
        this.puntos += colider.gameObject.GetComponent<Moneda>().puntosOtorgados;
        colider.GetComponent<Moneda>().sonidoMoneda.Play();
        colider.transform.parent.GetComponent<Animator>().SetTrigger("desaparece");
        //colider.transform.parent.GetComponent<Animator>().SetFloat("saludPersonaje", 3.4f);
        //colider.transform.parent.GetComponent<Animator>().SetInteger("contador", 5);
        //colider.transform.parent.GetComponent<Animator>().SetBool("hayPan", false);

        yield return new WaitForSeconds(1f);

        //colider.transform.parent.gameObject.SetActive(false);
        GameObject.Destroy(colider.transform.parent.gameObject);
    }


    //Funcion que permite que la lava queme 10 puntos de vida cada segundo
    public void DanoLava(Collision collision)
    {
        StartCoroutine(_DanoLava(collision));
    }

    IEnumerator _DanoLava(Collision collision)
    {
        if (isCoroutineExecuting)
            yield break;

        isCoroutineExecuting = true;

        this.vida -= 10;

        yield return new WaitForSeconds(1);

        isCoroutineExecuting = false;

    }
}
