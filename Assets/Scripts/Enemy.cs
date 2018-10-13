using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour {

    [SerializeField] float health = 100;
    [SerializeField] int scoreValue = 150;
    [Header("Laser")]
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.05f;
    [SerializeField] float maxTimeBetweenShots = .5f;
    [SerializeField] float projectileSpeed = 15f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] AudioClip laserSound;
    [SerializeField] [Range(0,1)] float laserSoundVolume = .35f;
    [Header("Death")]
    [SerializeField] GameObject explosionPrefab;
    [SerializeField] float explosionTime = 1f;
    [SerializeField] AudioClip deathSound;
    [SerializeField] [Range(0,1)] float deathSoundVolume = .75f;

    void Start(){
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update(){
        CountAndShoot();
    }

    private void CountAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if(shotCounter <= 0f)
        {
            Fire();
            AudioSource.PlayClipAtPoint(laserSound, Camera.main.transform.position, laserSoundVolume);
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(
            laserPrefab, 
            transform.position, 
            Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer)
        {
            ProcessHit(damageDealer);
            damageDealer.Hit();
        }

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Destroy(gameObject);
        GameObject explosion = Instantiate(
            explosionPrefab,
            transform.position,
            transform.rotation) as GameObject;
        Destroy(explosion, explosionTime);

        AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position, deathSoundVolume);
    }
}
