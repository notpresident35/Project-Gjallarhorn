using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> cloudPrefabs;
    [SerializeField]
    private float minCloudSpeed;
    [SerializeField]
    private float maxCloudSpeed;
    [SerializeField]
    private float minTimeBetweenSpawns;
    [SerializeField]
    private float maxTimeBetweenSpawns;

    private float timePassed;
    private float nextSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timePassed = 0;
        nextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        int index = Random.Range(0, cloudPrefabs.Count);
        GameObject cloud = GameObject.Instantiate(cloudPrefabs[index], new Vector3(transform.position.x, 5.0f, 0.0f), transform.rotation);
        cloud.GetComponent<CloudMover>().SetSpeed(Random.Range(minCloudSpeed, maxCloudSpeed));
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= nextSpawn)
        {
            int index = Random.Range(0, cloudPrefabs.Count);
            GameObject cloud = GameObject.Instantiate(cloudPrefabs[index], new Vector3(transform.position.x, 5.0f, 0.0f), transform.rotation);
            cloud.GetComponent<CloudMover>().SetSpeed(Random.Range(minCloudSpeed, maxCloudSpeed));
            timePassed = 0;
            nextSpawn = Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
        }
    }
}
