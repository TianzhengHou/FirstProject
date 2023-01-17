using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float enemyCount;
    public GameObject EnemyPrefeb;


    private void Start()
    {
        StartCoroutine(EnemyDrop());
    }
    IEnumerator EnemyDrop()
    {
        while(enemyCount < 10)
        {
            xPos = Random.Range(-19f, -5f);
            xPos = Random.Range(18f, 12f);
            Instantiate(EnemyPrefeb, new Vector2(xPos, yPos), Quaternion.identity);
            yield return null;
            enemyCount += 1f;
        }
    }
}
