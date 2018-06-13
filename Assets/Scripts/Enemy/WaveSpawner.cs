using UnityEngine;
using System.Collections;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState {Spawning, Waiting, Counting};

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject[] enemy;
        public int count;
        public float rate;
    }

    public Wave[] waves;
    private int nextWave = 0;
    public static bool waveC, waveS;
    public Transform[] spawnPoints;
    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private SpawnState state = SpawnState.Counting;
    private float searchCountdown = 1f;
    public static int waveNum = 0;


    void Start()
    {
        waveCountdown = timeBetweenWaves;

    }

    void Update()
    {
        if (state == SpawnState.Waiting)
        {
            if (!EnemyisAlive())
            {
                WaveCompleted();  
            }
            else
            {
                return;
            }
        }
        if (waveCountdown <= 0)
        {
            if (state != SpawnState.Spawning)
            {
                StartCoroutine(SpawnWave(waves[nextWave]));
            }
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted()
    {
        waveC = true;
        Debug.Log("Wave Completed!");

        state = SpawnState.Counting;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            nextWave = 0;
            Debug.Log("ALL WAVES COMPLETE! Looping...");
        }
        else
        {
            nextWave++;
        }
    }

    bool EnemyisAlive()
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }

    IEnumerator SpawnWave(Wave _wave)
    {
        waveNum++;
        waveS = true;
        
        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.Spawning;

        for (int i = 0; i < _wave.count; i++)
        {
            
            SpawnEnemy(_wave.enemy[Random.Range(0, _wave.enemy.Length)]);
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        state = SpawnState.Waiting;

        yield break;
    }
    void SpawnEnemy(GameObject _enemy)
    {
        Debug.Log("Spawning Enemy" + _enemy.name);
        Transform sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, sp.position, sp.rotation);
    }
}