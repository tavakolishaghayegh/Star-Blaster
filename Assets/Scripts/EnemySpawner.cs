using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigso currentWave;
    void Start()
    {
        SpawnEnemies();
        
    }
    void SpawnEnemies()
    {
        for (int i=0; i<currentWave.GetEnemyCount(); i++)
        {
             Instantiate(
                currentWave.GetEnemyPrefab(i),
                currentWave.GetStartingWaypoint().position,
                Quaternion.identity,
                transform);
            
        }
       
    }
    public WaveConfigso GetcurrentWave()
    {
        return currentWave; 

    }

    
}
