using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proyectil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("hola");
        this.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -100));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "paredFisica")
        {
            this.transform.position = new Vector3(-50f, 200f, 200f);
        }
    }
}
