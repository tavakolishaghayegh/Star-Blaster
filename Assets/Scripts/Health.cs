using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int scoreValue=50;
    [SerializeField] int health=50;
    [SerializeField] ParticleSystem hitParticles;
    [SerializeField] bool applyCameraShake;
    [SerializeField] bool playDamageSFX;
    CameraShake cameraShake;
    AudioManager audioManager;
    ScoreKeeper scoreKeeper;
   

        
    
     void Start() {
        cameraShake=Camera.main.GetComponent<CameraShake>();
        audioManager=FindAnyObjectByType<AudioManager>();
        scoreKeeper=FindAnyObjectByType<ScoreKeeper>();
        
    }

     void OnTriggerEnter2D(Collider2D other) 
     {
        DamageDealar damageDealar = other.GetComponent<DamageDealar>();
        if(damageDealar != null)
        {
            TakeDamage(damageDealar.GetDamage());
            PlayHitParticles();
            damageDealar.Hit();
            if (playDamageSFX)
            {
              audioManager.playdamageSFX();
            }
           
            
            
        }

        
    }
    
    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
            
        }
        
    }
    void Die()
    {
        if (!isPlayer)
            {
                scoreKeeper.ModifyScore(scoreValue);
            }
            Destroy(gameObject);
        
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
     public int GetHealth()
    {
        return health;
    }
    
}
