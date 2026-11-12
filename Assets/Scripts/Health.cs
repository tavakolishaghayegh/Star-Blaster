using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health=50;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;
    AudioManager audioManager;
   

        
    
     void Start() {
        cameraShake=Camera.main.GetComponent<CameraShake>();
        audioManager=FindAnyObjectByType<AudioManager>();
        
    }

     void OnTriggerEnter2D(Collider2D other) 
     {
        DamageDealar damageDealar = other.GetComponent<DamageDealar>();
        if(damageDealar != null)
        {
            TakeDamage(damageDealar.GetDamage());
            PlayHitParticles();
            damageDealar.Hit();
            audioManager.playdamageSFX();
            
            
        }

        
    }
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
        
    }
    void PlayHitParticles()
    {
        if (hitParticles != null)
        {
           ParticleSystem particles= Instantiate(hitParticles,transform.position,Quaternion.identity);
           Destroy(particles,particles.main.duration+particles.main.startLifetime.constantMax);
        }
        if (applyCameraShake)
        {
            cameraShake.play();
        }
        
        
    }
    
}
