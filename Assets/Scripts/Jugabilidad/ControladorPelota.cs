using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControladorPelota : MonoBehaviour
{
    public int vida = 100;
    public int cantidad_vidas;
    public int puntos = 0;
    public float velocidad = 20f;
    public float velocidad_final;
    [Range(10f, 30f)]
    public float fuerzaSalto;
    public bool isCoroutineExecuting = false;
    public GameObject camara, controlador_datos, HUD;
    public GameObject panel_pausa, panel_vida, panel_vidas, panel_puntos;
    public GameObject valor_vida, valor_vidas, valor_puntos;
    public GameObject[] menuPanels;
    public int modo_camara;
    // Start is called before the first frame update
    void Start()
    {
        controlador_datos = GameObject.Find("controlador_datos");
        cantidad_vidas = controlador_datos.GetComponent<datos_juego>().cantidad_vidas;

        valor_vida = GameObject.Find("valor_vida");
        valor_vidas = GameObject.Find("valor_vidas");
        valor_puntos = GameObject.Find("valor_puntos");


        panel_pausa = GameObject.Find("panel_pausa");
        panel_vida = GameObject.Find("panel_vida");
        panel_vidas = GameObject.Find("panel_vidas");
        panel_puntos = GameObject.Find("panel_puntos");
        menuPanels = GameObject.FindGameObjectsWithTag("panel");

        foreach (GameObject panel in menuPanels)
        {
            panel.gameObject.SetActive(false);
        }

        panel_vida.SetActive(true);
        panel_vidas.SetActive(true);
        panel_puntos.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        //HUD
        //======================
        //Vida
        valor_vida.GetComponent<TextMeshProUGUI>().text = this.vida.ToString();

        //Numero de vidas
        controlador_datos = GameObject.Find("controlador_datos");
        cantidad_vidas = controlador_datos.GetComponent<datos_juego>().cantidad_vidas;
        valor_vidas.GetComponent<TextMeshProUGUI>().text = this.cantidad_vidas.ToString();
        //=======================

        //Puntos
        valor_puntos.GetComponent<TextMeshProUGUI>().text = this.puntos.ToString();
        //=======================


        //Movimiento
        //============================================================
        float vel = this.GetComponent<Rigidbody>().velocity.z;

        Debug.Log("Velocidad vertical: " + -velocidad * Input.GetAxis("Vertical"));
        Debug.Log("Velocidad horizontal: " + velocidad * Input.GetAxis("Horizontal"));
        Debug.Log("this.vida: " + this.vida);
        Debug.Log("Mathf.Abs(vel): " + Mathf.Abs(vel));
        Debug.Log("modo_camara: " + modo_camara);






        //Velocidad limitada a un maximo de 10
        if (this.vida > 0 && Mathf.Abs(vel) <= 15 && modo_camara == 1)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 20 : 0f), velocidad * Input.GetAxis("Horizontal")));

            if (Input.GetButtonDown("Jump") && esNivelSuelo == true)
            {

                controlador_datos.GetComponent<datos_juego>().salto.Play();
            }

        }

        if (this.vida > 0 && Mathf.Abs(vel) <= 15 && modo_camara == 2)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3(0, (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 20 : 0f), -velocidad * Input.GetAxis("Horizontal")));

            if (Input.GetButtonDown("Jump") && esNivelSuelo == true)
            {

                controlador_datos.GetComponent<datos_juego>().salto.Play();
            }

        }

        if (this.vida > 0 && Mathf.Abs(vel) <= 15 && modo_camara == 3)
        {
            this.GetComponent<Rigidbody>().AddForce(new Vector3((-velocidad*Input.GetAxis("Vertical")), (Input.GetButtonDown("Jump") && esNivelSuelo == true ? fuerzaSalto * 20 : 0f), velocidad * Input.GetAxis("Horizontal")));

            if (Input.GetButtonDown("Jump") && esNivelSuelo == true)
            {

                controlador_datos.GetComponent<datos_juego>().salto.Play();
            }
        }
        if(this.vida > 0)
        {
            if (Input.GetButtonDown("Pausa"))
            {
                Debug.Log("esc key was pressed");

                foreach (GameObject panel in menuPanels)
                {
                    panel.gameObject.SetActive(false);
                    Debug.Log(panel.name);
                }
                controlador_datos = GameObject.Find("controlador_datos");
                controlador_datos.GetComponent<datos_juego>().pausa.Play();
                panel_pausa.SetActive(true);

            }
        }

        if(this.vida <= 0)
        {
            if (cantidad_vidas == 1)
            {
                //El jugador perdio
                controlador_datos = GameObject.Find("controlador_datos");
                controlador_datos.GetComponent<datos_juego>().cantidad_vidas = 3;

                SceneManager.LoadScene(3);
                Debug.Log("Jugador perdio: " + SceneManager.GetActiveScene().buildIndex);
            }
            if(cantidad_vidas > 1)
            {
                //Se le resta al jugador una vida y se reinicia la escena actual
                controlador_datos = GameObject.Find("controlador_datos");
                controlador_datos.GetComponent<datos_juego>().cantidad_vidas--;

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Debug.Log("Jugador no perdio: " + SceneManager.GetActiveScene().buildIndex);
            }
        }

    }
    public bool esNivelSuelo = true;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "acelerador")
        {
            controlador_datos = GameObject.Find("controlador_datos");
            controlador_datos.GetComponent<datos_juego>().acelerador.Play();
          
        }
        if (collision.gameObject.tag == "acelerador_inverso")
        {
            controlador_datos = GameObject.Find("controlador_datos");
            controlador_datos.GetComponent<datos_juego>().acelerador.Play();
        }
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
            controlador_datos = GameObject.Find("controlador_datos");
            controlador_datos.GetComponent<datos_juego>().acelerador.Play();
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

        if (col.gameObject.tag == "checkpoint_lado")
        {
            camara = GameObject.Find("Main_Camera");
            camara.GetComponent<Sigue>().checkpoint = 3;
            modo_camara = 3;
        }

        if (col.gameObject.tag == "checkpoint_meta")
        {
            

            if(SceneManager.GetActiveScene().buildIndex + 1 == 3)
            {
                //El jugador gano
                controlador_datos = GameObject.Find("controlador_datos");
                controlador_datos.GetComponent<datos_juego>().cantidad_vidas = 3;
                controlador_datos.GetComponent<datos_juego>().ganaste.Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
            else
            {
                controlador_datos = GameObject.Find("controlador_datos");
                controlador_datos.GetComponent<datos_juego>().ganaste.Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }


    }

    public void FinalizaMoneda(Collider colider)
    {
        StartCoroutine(_FinalizaMoneda(colider));
    }

    IEnumerator _FinalizaMoneda(Collider colider)
    {
        this.puntos += colider.gameObject.GetComponent<Moneda>().puntosOtorgados;
        controlador_datos = GameObject.Find("controlador_datos");
        controlador_datos.GetComponent<datos_juego>().sonidoMoneda.Play();
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

        controlador_datos = GameObject.Find("controlador_datos");
        controlador_datos.GetComponent<datos_juego>().herido.Play();

        yield return new WaitForSeconds(1);

        isCoroutineExecuting = false;

    }
}

