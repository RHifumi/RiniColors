using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo1 : Existencia //Hereda de la clase base Existencia, metodos de move() y colorChange()
{
    //2 vairbales publicas de GameObject, aunque objetivo la determino por codigo buscando un objeto con etiqueta exacta "Rini"
    //y el otro obtengo mi componente Renderer para cambiar el color, podría ser más optimizado.
    //velocidad de desplazamiento, y un tiempo antes de ejecutar el Destroy()
    public GameObject objetivo;
    private float velocidadEnemigo1;
    public GameObject ColorObj;
    private float num1;

    public void Start()
    {
        objetivo = GameObject.Find("Rini");
        velocidadEnemigo1 = 1f;
        num1 = 2f;
    }

    public void Update()
    {
        move();
        colorChange(num1);
    }

    //El comportamiento de esté script funciona, como buscar a "Rini", persiguiendo de fomra directa
    //Una vez se esté lo suficientemente cerca, <2m, cambia su color y se destruira en 2s después
    //Comportamiento basico y un estimulo visual para comprender los cambios de comportamiento, debes acercarte y alejarte para que esté objeto se detone a si mismo

    public override void move()
    {
        transform.LookAt(objetivo.transform);

        transform.Translate(velocidadEnemigo1 * Vector3.forward * Time.deltaTime);
    }

    public override void colorChange(float num)
    {
        if (Vector3.Distance(transform.position, objetivo.transform.position) < 2)
        {
            Color color = new Color(r: 1f, g: 0.5f, b: 1f);
            ColorObj.GetComponent<Renderer>().material.color = color;

            Destroy(gameObject,num);
        }
    }
}
