using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSixEnemyController : MonoBehaviour
{
    private Transform playerTransform;
    private GameObject timer;
    private float MoveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        MoveSpeed = Random.Range(4f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDir = playerTransform.position - transform.position;
        Vector3 random = new Vector3(Random.Range(-.06f, .06f), Random.Range(-.06f, .06f), Random.Range(-.06f, .06f));
        transform.Translate (moveDir.normalized * MoveSpeed * Time.deltaTime + random);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerDeath();
        }
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            PlayerDeath();
        }
    }

    private void PlayerDeath() {
        Debug.Log("dead");
        timer.GetComponent<Scene6Timer>().Reset();
    }

    public void SetPlayerTransform(Transform player) {
        this.playerTransform = player;
    }

    public void SetTimer(GameObject timer) {
        this.timer = timer;
    }
}
