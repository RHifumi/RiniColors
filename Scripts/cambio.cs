using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambio : MonoBehaviour
{
    //El cambio de colores funciona como, "Trajes" que aparecen sobre rini
    //1, 2 y 3 para activar uno de estós trajes, y desactivar el resto
    //Se asegura que si está en contacto con un objeto cuya etiqueta se "Elemento" no pueda cambiar de color hasta que termine ese contacto
    public GameObject Arma1;
    public GameObject Arma2;
    public GameObject Arma3;

    public bool CambioPermitido;

    void Start()
    {
        Arma1.SetActive(false);
        Arma2.SetActive(false);
        Arma3.SetActive(false);

        CambioPermitido = true;
    }

    void Update()
    {

        if (CambioPermitido)
        {
            ControlArmas();
        }
    }


    void OnTriggerEnter(Collider otro)
    {
        if (otro.CompareTag("Elemento"))
        {
            CambioPermitido = false;
        }

    }

    void OnTriggerStay(Collider otro)
    {
        if (otro.CompareTag("Elemento"))
        {
            CambioPermitido = true;
        }

    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elemento"))
        {
            CambioPermitido = true;
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Elemento"))
        {
            CambioPermitido = false;
        }

    }

    private void ControlArmas()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Arma1.SetActive(true);
            Arma2.SetActive(false);
            Arma3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Arma1.SetActive(false);
            Arma2.SetActive(true);
            Arma3.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Arma1.SetActive(false);
            Arma2.SetActive(false);
            Arma3.SetActive(true);
        }


    }
}
