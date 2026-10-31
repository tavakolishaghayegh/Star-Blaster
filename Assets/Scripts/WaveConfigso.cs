using UnityEngine;

[CreateAssetMenu(fileName = "WaveConfig", menuName = "New WaveConfig")]
public class WaveConfigso : ScriptableObject
{
  [SerializeField] GameObject[] enemyPrefabs;
  [SerializeField] Transform pathPrefab; 
  [SerializeField] float enemyMoveSpeed=5f;
   public int GetEnemyCount()
  {
    return enemyPrefabs.Length;
  }
  public GameObject GetEnemyPrefab(int index)
  {
    return enemyPrefabs[index];
  }
  public Transform GetStartingWaypoint()
  {
    return pathPrefab.GetChild(0);
  }
  public float GetEnemyMoveSpeed()
  {
    return enemyMoveSpeed;

  }
  public Transform[] GetWaypoints()
  {
    Transform[] wayPoints=new Transform[pathPrefab.childCount];
    for(int i=0; i<pathPrefab.childCount; i++)
    {
      wayPoints[i]=pathPrefab.GetChild(i);
    }
     
    return wayPoints;
  }


    
}
