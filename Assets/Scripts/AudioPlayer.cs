using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField][Range(0f, 1f)] float damageVolume = 1f;

    static AudioPlayer instance; // pure way of singleton
    //public AudioPlayer getInstance()
    //{  return instance; }

    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
       //int instanceCount = FindObjectsOfType(GetType()).Length; first option of singleton
       //if (instanceCount > 1)

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void playShootingClip()
    {
        playClip(shootingClip, shootingVolume);
    }
    public void playDamageClip()
    {
        playClip(damageClip, damageVolume);
    }

    void playClip(AudioClip clip, float volume)
    {
        if (clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }
}
