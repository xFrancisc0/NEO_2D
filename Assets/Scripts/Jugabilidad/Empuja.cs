using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empuja : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody>().AddForce(5 * Input.GetAxis("Horizontal"), (Input.GetButtonDown("Jump") ? 500 : 0), 5 * Input.GetAxis("Vertical"));
    }
}
