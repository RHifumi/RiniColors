using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victoria3 : MonoBehaviour
{
    //Una versión menos prolija de event, pidiendo un objeto de canvas, y activandolo cuando se de las condiciones
    //Tanto la pantalla de victoria como derrota tienen esté funcionamiento.
    public bool VictoriaU;
    public GameObject panelVictoria;

    void Start()
    {
        VictoriaU = false;
        panelVictoria.SetActive(false);
    }


    void Update()
    {
        GameOver();
    }

    public void GameOver()
    {
        if (VictoriaU) 
        {
            panelVictoria.SetActive(true);
            VictoriaU = false;
            Time.timeScale = 0;
        }
    }

    void OnTriggerEnter(Collider otro)
    {
            VictoriaU = true;
    }
}