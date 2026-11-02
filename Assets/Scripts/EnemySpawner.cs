using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigso[] waveConfigs;
    [SerializeField] float timeBetweenWaves=1f;
    [SerializeField] bool isLooping;
     WaveConfigso currentWave;
    
    void Start()
    {
       StartCoroutine (SpawnEnemies()) ;
        
    }
    IEnumerator SpawnEnemies()
    {
        do
        {
            foreach (WaveConfigso wave in waveConfigs)
            {
                currentWave= wave;
                for (int i=0; i<currentWave.GetEnemyCount(); i++)
        
                 {
                    Instantiate(
                     currentWave.GetEnemyPrefab(i),
                     currentWave.GetStartingWaypoint().position,
                     Quaternion.identity,
                     transform);

                    yield return new WaitForSeconds(currentWave.GetRandomEnemySpawnTime());
            
                 }
                 yield return new WaitForSeconds(timeBetweenWaves);
            
             }
        }while(isLooping);
        
        
       
    }
    public WaveConfigso GetcurrentWave()
    {
        return currentWave; 

    }

    
}
