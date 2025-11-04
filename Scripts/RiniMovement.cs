using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RiniMovement : MonoBehaviour
{
    Vector3 movementInput;
    Rigidbody riniRB;

    private bool Saltar = false;

    void Awake()
    {
        //Time.timeScale se asegura que la escena cargue correctamente después de la pantalla de derrota
        //donde cambio el Time.timeScale = 0 para dar un efecto de pausa en el juego
        riniRB = GetComponent<Rigidbody>();
        Time.timeScale = 1;
    }

    void Update()
    {
        movementInput = Vector3.zero;

        if (Input.GetKey(KeyCode.D))
        {
            movementInput.z = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movementInput.z = -1;
        }
        Salto();
    }

    protected void FixedUpdate()
    {
        Move(movementInput);
    }

    //MovePosition, su objetivo es mover el objeto fisicamente, pero de forma cinematica controlada.
    //No se empuja con fuerza (como el proyecto RiniRollABall) ni altera la velocidad del rigidbody
    //Pero si que respeta su posición en el sistema de física, respetando colisiones, choques o interpolaciones

    //Las desventajas, es que no puede deslizarse manualmente y se siente artificial al no respetar el movimiento con la gravedad
    //Problemas de sicronización con el FixedUpdate, en entornos como WebGL


    void Move(Vector3 direction)
    {
        riniRB.MovePosition(riniRB.position + direction.normalized * 5 * Time.fixedDeltaTime);

    }

    //Varios problemas para que corra tanto en Destkop como WEBgl, tuve que cambiarlo a 6f para que funciones en WEBgl 
    private void Salto()
    {
        if (Saltar)
        {
            if (Input.GetKey(KeyCode.W))
            {
                riniRB.AddForce(Vector3.up * 0.7f, ForceMode.VelocityChange);
            }
        }
    }

    //Debe estár tocando "Suelo" para habilitar el salto
    public void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Suelo"))
        {
            Saltar = true;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            Saltar = false;
        }
    }
}
