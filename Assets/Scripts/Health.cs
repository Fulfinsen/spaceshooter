using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50; //how many points we get when we kill an enemy
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }

    public int getHealth()
    {
        return health;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();

        if( damageDealer != null )
        {
            takeDamage(damageDealer.getDamage());
            playHitEffect();
            audioPlayer.playDamageClip();
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
            Die();
        }
    }

    private void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(score);
        }
        else
        {
            levelManager.loadGameOver();
        }
        Destroy(gameObject);
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
