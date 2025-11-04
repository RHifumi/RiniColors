using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonPress : MonoBehaviour
{
    //Creado con la intención de ser configurado desde el editor
    //Le asigno un número de etiqueta en realción a que color tiene la jugadora
    //Le asigno un objeto que se destruira, como una puerta u obstaculo
    public string Etiqueta = "0";
    private Rigidbody RiniRb;

    public GameObject puerta;

    bool Limite = true;

    private void Start()
    {
        RiniRb = GetComponent<Rigidbody>();

    }

    //Si nos tocá la jugadora, destruimos el objeto asociado, simulando un botón precionado, se encoge en y para que parezca precionado
    //Aunque no es lo más optimo una bool para saber cuando fue precionado y no pueda volver a interactuarse
    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag(Etiqueta))
        {
            if (Limite)
            {
                Destroy(puerta);
                RiniRb.transform.localScale = new Vector3(RiniRb.transform.localScale.x, RiniRb.transform.localScale.y / 2, RiniRb.transform.localScale.z);
                Limite = false;
            }

        }
    }
}
