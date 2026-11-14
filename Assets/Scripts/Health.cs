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
    LevelManager levelManager;
   

        
    
     void Start() {
        cameraShake=Camera.main.GetComponent<CameraShake>();
        audioManager=FindAnyObjectByType<AudioManager>();
        scoreKeeper=FindAnyObjectByType<ScoreKeeper>();
        levelManager=FindAnyObjectByType<LevelManager>();
        
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
            if (applyCameraShake)
            {
              cameraShake.play();
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
        if (isPlayer)
         {
             
            levelManager.LoadGameOver();
         }
     else
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
        
        
        
    }
     public int GetHealth()
    {
        return health;
    }
    
}
