using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public Vector3 spawnValues;
    public int enemies;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public float timer;
    public int waves;
    private Coroutine spawn;
    void Start()
    {
        spawn=StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (waves >= 0)
        {
            for (int i = 0; i < enemies; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                if (waves%2==0)
                {
                    Instantiate(enemy1, spawnPosition, spawnRotation);
                }
                else
                {
                    Instantiate(enemy2, spawnPosition, spawnRotation);
                }
                
                yield return new WaitForSeconds(spawnWait);
            }
            waves--;
            yield return new WaitForSeconds(waveWait);
        }
    }


}