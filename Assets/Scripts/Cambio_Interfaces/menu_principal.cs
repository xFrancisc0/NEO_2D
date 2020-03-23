using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu_principal : MonoBehaviour
{
    public GameObject controlador_datos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void empezarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Volver_al_menu()
    {
        SceneManager.LoadScene(0);
    }

    public void cerrarJuego()
    {
        Application.Quit();
    }


}
