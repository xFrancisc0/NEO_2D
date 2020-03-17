using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sigue : MonoBehaviour
{
    public Transform seguido;
    public Vector3 vectorDiferencia;
    public Vector3 vectorDiferenciaAngulos;
    public int checkpoint=0;
    // Start is called before the first frame update
    void Start()
    {
        //Si el modo de camara es frontal
        //this.transform.position = seguido.position - new Vector3(1f, 1f, 1f);

        //Quaternion target = Quaternion.Euler(13.958f, -55.416f, 0);
        //this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, 5.0f);

        //vectorDiferencia = seguido.position - this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.checkpoint==1)
        {
            //Si el modo de camara es frontal
            this.transform.position = seguido.position - new Vector3(-23.51f, -12.46743f, -6.29789f);

            Quaternion target = Quaternion.Euler(13.958f, -55.416f, 0);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, 5.0f);

            vectorDiferencia = seguido.position - this.transform.position;


            this.transform.position = seguido.position - vectorDiferencia;
        }
        else if(this.checkpoint==2)
        {
            //Si el modo de camara es reverso
            this.transform.position = seguido.position - new Vector3(28.60585f, -23.40843f, -17.7179f);

            Quaternion target = Quaternion.Euler(28.053f, -231.154f, 0);
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, target, 5.0f);

            vectorDiferencia = seguido.position - this.transform.position;


            this.transform.position = seguido.position - vectorDiferencia;
        }

    }
}
