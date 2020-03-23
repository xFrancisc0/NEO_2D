using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControladorCanvas : MonoBehaviour
{
    public Text textoPantalla;
    public Text textoContador;
    public Color colorTexto;

    // Start is called before the first frame update
    void Start()
    {
        textoPantalla.text = "TEXTO DESDE EL START";
        textoPantalla.color = colorTexto;
    }

    public int contadorF = 0;

    // Update is called once per frame
    void Update()
    {
        contadorF++;
        
        textoPantalla.text = (contadorF/60).ToString();
    }

    public int contadorClic = 0;

    public void ClicBotonEjemplo(/*GameObject obj*/)
    {
        contadorClic++;
        textoContador.text = "Contador clic: " + contadorClic;
    }

    public void ClicToggleEjemplo(Toggle toggleEjemplo)
    {
        Debug.Log("EL TOGGLE CAMBIO");
        if (toggleEjemplo.isOn == true)
            Debug.Log("Y ES TRUE!");
    }

    public void CambioValorLista(Dropdown dropdownLista)
    {
        //switch(dropdownLista.value)
        //{
        //    case 0:
        //        Debug.Log("EL VALOR SELECCIONADO ES: 0");
        //        break;
        //    case 1:
        //        Debug.Log("EL VALOR SELECCIONADO ES: 1");
        //        break;
        //    case 2:
        //        Debug.Log("EL VALOR SELECCIONADO ES: 2");
        //        break;
        //    case 3:
        //        Debug.Log("EL VALOR SELECCIONADO ES: 3");
        //        break;
        //    default:
        //        break;
        //}

        Debug.Log("EL VALOR SELECCIONADO ES: " + dropdownLista.options[dropdownLista.value].text);
    }
}
