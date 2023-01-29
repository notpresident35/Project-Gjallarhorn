using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSixEnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject enemy;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject timer;
    private float newEnemyTime = 4.5f;
    private float currentTime;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentTime < newEnemyTime) {
            currentTime += Time.deltaTime;
        }
        else {
            spawnEnemy();
        }
    }

    private void spawnEnemy() {
        GameObject e = Instantiate(enemy, transform.position, Quaternion.identity);
        e.transform.GetChild(0).GetComponent<SceneSixEnemyController>().SetPlayerTransform(player.transform);
        e.transform.GetChild(0).GetComponent<SceneSixEnemyController>().SetTimer(timer);
        currentTime = 0f;
    }
}
