using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health=50;

     void OnTriggerEnter2D(Collider2D other) 
     {
        DamageDealar damageDealar = other.GetComponent<DamageDealar>();
        if(damageDealar != null)
        {
            TakeDamage(damageDealar.GetDamage());
            damageDealar.Hit();
            
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
    
}
