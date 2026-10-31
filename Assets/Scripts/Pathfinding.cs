using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
     WaveConfigso waveConfig;
    Transform[] waypoints;
    int waypointIndex=0;
    
    void Start()
    {
        enemySpawner=FindAnyObjectByType<EnemySpawner>();
        waveConfig=enemySpawner.GetcurrentWave();
        
        waypoints=waveConfig.GetWaypoints();
        transform.position=waveConfig.GetStartingWaypoint().position;
        
    }

   
    void Update()
    {
        FollowPath();
        
    }
    void FollowPath()
    {
        if(waypointIndex < waypoints.Length)
        {
            Vector3 targetPosition=waypoints[waypointIndex].position;
            float moveDelta=waveConfig.GetEnemyMoveSpeed()* Time.deltaTime;
            transform.position=Vector2.MoveTowards(transform.position , targetPosition , moveDelta);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
                
            }
            
        }
        else
            {
                Destroy(gameObject);
            }
    }
}
