using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] GameObject Prefab;
    
    private float cooldown = 0;

    void Update()
    {
        if (0 >= cooldown)
        {
            Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, Random.Range(0.0f, 40.0f)));
            Instantiate(Prefab, new Vector3(-15.0f, Random.Range(4.0f, 9.0f), -1), rotation, null);
            cooldown = 2.0f;
        }

        cooldown -= Time.deltaTime;
    }
}
