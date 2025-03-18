using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Animator animator;
    public Transform fireSocket;
    public ParticleSystem fireFX;
    public float rotationRate = 90.0f;

    public int numProjectiles = 0;

    void Update()
    {
        float aimInput = Input.GetAxis("Horizontal");
        aimInput *= rotationRate * Time.deltaTime;
        transform.Rotate(Vector3.right * aimInput, Space.Self);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }

    void Fire()
    {
        fireFX.Play();
        animator.SetTrigger("Fire");
        Instantiate(projectilePrefab, fireSocket.position, fireSocket.rotation);
        numProjectiles++;
    }
}
