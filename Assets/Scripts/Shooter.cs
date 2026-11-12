using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header(" Base Variables")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed=10f;
    [SerializeField] float projectileLifetime=5f;
    [SerializeField] float basefireRate=0.2f;
    [Header(" AI Variables")]
    [SerializeField] bool useAi;
    [SerializeField] float minimumFireRate=0.2f;
    [SerializeField] float fireRateVariance=0f;
    [HideInInspector] public bool isFiring;
    



     
     Coroutine fireCoroutine;
     AudioManager audioManager;


     void Start() 
     {
        audioManager=FindAnyObjectByType<AudioManager>();
        if (useAi)
        {
            isFiring=true;
        }

        
     }
     
  
  void Update()
  {
    Fire();
    
  }
  void Fire()
    {
        if (isFiring && fireCoroutine ==null)
        {
             fireCoroutine=StartCoroutine(FireContinuously());
            
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine=null;
            
        }


        
    }

    IEnumerator FireContinuously()
    {
        while(true){
           GameObject projectile= Instantiate(projectilePrefab,transform.position,Quaternion.identity);
           projectile.transform.rotation=transform.rotation;
           Rigidbody2D projectileRB =projectile.GetComponent<Rigidbody2D>();

          projectileRB.linearVelocity = transform.up * projectileSpeed;
           
           Destroy(projectile,projectileLifetime);
           float waitTime=Random.Range(basefireRate - fireRateVariance,basefireRate+fireRateVariance);
           waitTime=Mathf.Clamp(waitTime,minimumFireRate, float.MaxValue);
            if (!useAi)
            {
                 audioManager.PlayShootingSFX();
                
            }
         
           yield return new WaitForSeconds(waitTime);
            
        }
        
    }

 





}
