using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnObstacles : MonoBehaviour
{
    public List<GameObject> objectsToSpawn;
    public float spawnRate = 0.5f;
    float nextTimeToSpawn = 0;
    public float minRadius, maxRadius;

    void Update()
    {
        if (Time.time >= nextTimeToSpawn)
        {
            SpawnObjectAtRandom();
            nextTimeToSpawn = Time.time + 1f / spawnRate;
        }
    }
    void SpawnObjectAtRandom()
    {
        Vector2 offset = new Vector3(minRadius, minRadius, 0);
        Vector3 randomPos = Random.insideUnitCircle.normalized * Random.Range(minRadius, maxRadius);
        int id = Random.Range(0, 2);
        Instantiate(objectsToSpawn[id], randomPos, Quaternion.identity);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, minRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, maxRadius);
    }
    public void spawnSmall(Vector3 position)
    {
        GameObject clone, clone2;
        var offset  =  Random.insideUnitCircle.normalized * Random.Range(0.5f, 1f);
        Vector3 position2 = (Vector3)offset + position;

        clone = Instantiate(objectsToSpawn[0], position, Quaternion.identity);
        clone2 = Instantiate(objectsToSpawn[0], position2, Quaternion.identity);
    }
}
