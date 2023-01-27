using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stripe : MonoBehaviour
{
    [SerializeField] Color color;
    [SerializeField] GameObject square;
    [SerializeField] int squaresCount;
    [SerializeField] float frequency;
    [SerializeField] float speed;
    [SerializeField] float spacing;
    [SerializeField] float amplitude;
    [SerializeField] float angle;

    List<Transform> squares = new List<Transform>();

    void Start()
    {
        //spawn the squares?? ig??
        for (int i=0; i<squaresCount; i++)
        {
            GameObject newSquare = Instantiate(square, transform.position, Quaternion.Euler(new Vector3(0, 0, angle)), transform);
            newSquare.GetComponent<SpriteRenderer>().color = color;
            squares.Add(newSquare.transform);
        }
    }

    void Update()
    {
        for (int i=0; i<squaresCount; i++)
        {
            float heightOffset = amplitude * Mathf.Sin(frequency * i + speed * Time.realtimeSinceStartup);

            float dist = i * spacing;
            float baseX = transform.position.x + Mathf.Cos(angle * Mathf.Deg2Rad) * dist;
            float baseY = transform.position.y + Mathf.Sin(angle * Mathf.Deg2Rad) * dist;
            float xOffset = Mathf.Cos((angle + 90) * Mathf.Deg2Rad) * heightOffset;
            float yOffset = Mathf.Sin((angle + 90) * Mathf.Deg2Rad) * heightOffset;

            squares[i].position = new Vector3(baseX + xOffset, baseY + yOffset,0);
        }
    }
}
