using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if( damageDealer != null )
        {
            takeDamage(damageDealer.getDamage());
            playHitEffect();
            shakeCamera();
            damageDealer.hit();
        }
    }

    void shakeCamera()
    {
        if (cameraShake != null && applyCameraShake) 
        { 
            cameraShake.Play();
        }
    }
    void takeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void playHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate (hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
