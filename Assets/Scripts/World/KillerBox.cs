using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillerBox : MonoBehaviour
{
    public Vector3 pointA;
    public Vector3 pointB; 
    public float speed = 1.0f; 

    private Vector3 targetA;
    private Vector3 targetB;

    void Start()
    {
        targetA = transform.position + pointA;
        targetB = transform.position + pointB;
    }

    void Update()
    {
        MoveObject();
    }

    void MoveObject()
    {
        float t = Mathf.PingPong(Time.time * speed, 1.0f);
        transform.position = Vector3.Lerp(targetA, targetB, t);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ResetLevel();
        }
    }

    void ResetLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
