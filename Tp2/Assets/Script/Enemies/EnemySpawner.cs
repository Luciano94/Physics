using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]private GameObject go;
    [SerializeField]private float timeBeetwenEnemies = 2.0f;
    [SerializeField]private float minX = -8.0f;
    [SerializeField]private float maxX = 8.0f;

    private float actualTime = 0.0f;
    private Vector3 enemyPos;

    private void Start() {
        enemyPos = transform.position;
    }

    private void Update() {
        actualTime += Time.deltaTime;
        if(actualTime > timeBeetwenEnemies){
            actualTime = 0.0f;
            enemyPos.x = Random.Range(minX, maxX);
            Instantiate(go,enemyPos,transform.rotation);
        }
    }
}
