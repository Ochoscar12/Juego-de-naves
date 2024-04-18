using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparonave : MonoBehaviour
{
    [SerializeField] private Transform controladordeDisparo;
    [SerializeField] private GameObject bala;
    private void Update()
    {
        if (Input.GetButtonDown("Disparo1"))
        {
            Disparito();
        }
    }
    private void Disparito()
    {
        Instantiate(bala, controladordeDisparo.position, controladordeDisparo.rotation);
    }
}
