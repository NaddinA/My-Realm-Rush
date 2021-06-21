using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;
    [SerializeField] ParticleSystem hitParticlePrefab;
    [SerializeField] ParticleSystem deathParticlePrefab;
    [SerializeField] AudioClip hitSFX;
    [SerializeField] AudioClip deathSFX;

    AudioSource myAudioSource;
    private void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }
    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
        if (hitPoints <= 0)
        {
            KillEnemy();
        }
    }
    
    void ProcessHit()
    {
        hitPoints--;
        myAudioSource.PlayOneShot(hitSFX);
        hitParticlePrefab.Play();
    }

    private void KillEnemy()
    {
        // important to instantiate before destroying this object
        var vfx = Instantiate(deathParticlePrefab, transform.position, Quaternion.identity);
        vfx.Play();
        
        Destroy(vfx.gameObject, vfx.main.duration); //destroy death particle for its duration
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position);
        Destroy(gameObject); // the enemy
    }
}
