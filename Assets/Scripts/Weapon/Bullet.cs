using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    public enum BulletColor
    {
        Red,
        Blue
    }

    public BulletColor bulletColor;
    public float penaltyTime = 2f;
    public AudioClip wrongHitSound; 

    private Timer timer;
    private AudioSource audioSource;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
        audioSource.playOnAwake = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject collidedObject = collision.gameObject;

        bool isCorrectHit = (collidedObject.CompareTag("Red") && bulletColor == BulletColor.Red) ||
                            (collidedObject.CompareTag("Blue") && bulletColor == BulletColor.Blue);

        if (isCorrectHit)
        {
            Debug.Log(bulletColor == BulletColor.Red ? "ROJO" : "AZUL");
            Destroy(collidedObject);
            Destroy(gameObject);
        }
        else if (collidedObject.CompareTag("Red") || collidedObject.CompareTag("Blue"))
        {
            PlayWrongHitSound();
            timer.SubtractTime(penaltyTime);
            Destroy(gameObject);
        }
    }

    private void PlayWrongHitSound()
    {
        Debug.Log("Playing wrong hit sound.");
        audioSource.clip = wrongHitSound;
        audioSource.Play();
    }
}