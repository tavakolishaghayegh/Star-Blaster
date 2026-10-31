using System.Collections;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigso[] waveConfigs;
    [SerializeField] float timeBetweenWaves=1f;
     WaveConfigso currentWave;
    
    void Start()
    {
       StartCoroutine (SpawnEnemies()) ;
        
    }
    IEnumerator SpawnEnemies()
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
        
       
    }
    public WaveConfigso GetcurrentWave()
    {
        return currentWave; 

    }

    
}
