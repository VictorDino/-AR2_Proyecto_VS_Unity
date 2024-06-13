using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsMovement : MonoBehaviour
{
    public Vector3 centroDelEspacio; 
    public float rangoX = 5f; 
    public float rangoZ = 5f; 
    public float rangoY = 5f; 
    public float velocidad = 3f; 

    private Rigidbody rb;
    private Vector3 direccion;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ObtenerNuevoObjetivo();
    }

    void Update()
    {
        if (rb.velocity.magnitude < 0.1f)
        {
            ObtenerNuevoObjetivo();
        }
    }

    void ObtenerNuevoObjetivo()
    {
        float randomX = Random.Range(-rangoX, rangoX);
        float randomZ = Random.Range(-rangoZ, rangoZ);
        float randomY = Random.Range(-rangoY, rangoY);
        direccion = new Vector3(randomX, randomY, randomZ).normalized;
        rb.velocity = direccion * velocidad;
    }

    void OnCollisionEnter(Collision collision)
    {
        Vector3 normal = collision.contacts[0].normal;
        Vector3 nuevaDireccion = Vector3.Reflect(direccion, normal).normalized;

        direccion = nuevaDireccion;
        rb.velocity = nuevaDireccion * velocidad;
    }
}
