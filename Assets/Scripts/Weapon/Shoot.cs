using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject redBulletPrefab;
    public GameObject blueBulletPrefab;
    public float shootForce = 2000f;
    public ParticleSystem particles;

    private Animator weaponAnimator;
    private AudioSource audioSource;
    private float shootRateTime = 0f;
    private float shootCooldown = 0.5f;

    void Start()
    {
        weaponAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        HandleShooting();
    }

    void HandleShooting()
    {
        if (Time.time > shootRateTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                ShootBullet(redBulletPrefab, Color.red);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                ShootBullet(blueBulletPrefab, Color.blue);
            }
        }
    }

    void ShootBullet(GameObject bulletPrefab, Color particleColor)
    {
        weaponAnimator.SetTrigger("Shoot");

        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        Vector3 direction = spawnPoint.forward;

        if (Physics.Raycast(ray, out hit))
        {
            direction = (hit.point - spawnPoint.position).normalized;
        }

        GameObject newBullet = Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
        newBullet.GetComponent<Rigidbody>().AddForce(direction * shootForce);

        particles.startColor = particleColor;
        particles.Play();

        audioSource.Play();

        shootRateTime = Time.time + shootCooldown;
        Destroy(newBullet, 2f);
    }
}
