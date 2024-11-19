using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField]
    private GameObject goblinPrefab;
    [SerializeField]
    private float spawnInterval = 3.5f;
    [SerializeField]
    private int spawnMax = 5;
    private int currentSpawn = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, goblinPrefab));
    }
    //Function for CoRoutine to spawn Enemy, takes in spawn time and enemy's prefab
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        if(currentSpawn < spawnMax)
        {
            yield return new WaitForSeconds(interval);
            //spawns given enemy GameObject at vector ranges (x, y, z)
            GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
            currentSpawn += 1;
            StartCoroutine(spawnEnemy(interval, enemy));
        }
    }
    
}