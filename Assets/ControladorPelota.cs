using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorPelota : MonoBehaviour
{
    public int vida = 100;
    public int puntos = 0;
    public float velocidad = 1f;
    [Range(10f, 30f)]
    public float fuerzaSalto;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.vida > 0)
            this.GetComponent<Rigidbody>().AddForce(new Vector3(velocidad * Input.GetAxis("Horizontal"), (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 15 : 0f), velocidad * Input.GetAxis("Vertical")));
    }

    public bool esNivelSuelo = true;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "obstaculo")
        {
            if (this.vida > 0)
                this.vida -= collision.gameObject.GetComponent<Obstaculo>().daño;
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            Debug.Log("CHOCANDO CON SUELO");
            esNivelSuelo = true;
        }
        else if(collision.gameObject.tag != "obstaculo")
        {
            Debug.Log("NO ENCUENTRO EL SUELO!");
            esNivelSuelo = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            Debug.Log("DEJE DE CHOCHAR CON SUELO");
            esNivelSuelo = false;
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "moneda")
        {
            FinalizaMoneda(col);
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
}
