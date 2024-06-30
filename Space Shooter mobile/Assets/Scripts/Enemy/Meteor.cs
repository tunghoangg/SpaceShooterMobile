using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : Enemy
{
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private SpawnerScriptableObject powerUpSpawner;
    private float speed; 
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        rb.velocity = Vector2.down * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, rotateSpeed * Time.deltaTime);
    }
    public override void HurtSequence()
    {
        base.HurtSequence();    
    }
    public override void DeathSequence()
    {
        base.DeathSequence();
        Instantiate(explosionPrefab, transform.position, transform.rotation);
        if(powerUpSpawner!= null)
        {
            powerUpSpawner.SpawnPowerUp(transform.position);
        }
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //Destroy(collision.gameObject);
            PlayerStats player = collision.GetComponent<PlayerStats>();
            player.PlayerTakeDamage(damage);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
