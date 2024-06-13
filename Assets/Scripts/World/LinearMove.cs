using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMove : MonoBehaviour
{
    public Transform puntoInicio; 
    public Transform puntoFin; 
    public float velocidad = 3f; 

    void Update()
    {
        Vector3 direccion = puntoFin.position - transform.position;
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, puntoFin.position) < 0.2f)
        {
            Transform temp = puntoInicio;
            puntoInicio = puntoFin;
            puntoFin = temp;
        }
    }
}
