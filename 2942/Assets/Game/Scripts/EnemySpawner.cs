using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public Vector3 spawnValues;
    public int enemies;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    public int waves;
    private Coroutine spawn;
    void Start()
    {
        spawn=StartCoroutine(SpawnWaves());
        waves = 1;
    }

    private void Update()
    {
        if (waves<=0)
        {
            StopCoroutine(spawn);
        }
    }

    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < enemies; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(enemy, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            waves--;
            yield return new WaitForSeconds(waveWait);
        }
    }
}