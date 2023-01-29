using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

using TMPro;

public class Flicker : MonoBehaviour
{
    bool isFlickering = false;
    float TimeElapsed;
    
    Color Dark = new Color32(27, 21, 22, 255);
    Color Transparent = new Color32(0, 0, 0, 0);

    [SerializeField] TMP_Text ScoreText;


    void Start()
    {
        TimeElapsed = Random.Range(5.0f, 20.0f);
    }

    void Update()
    {
        if (isFlickering)
        {
            return;
        }

        if (0.0f >= TimeElapsed)
        {
            isFlickering = true;
            TimeElapsed = Random.Range(5.0f, 20.0f);
            IEnumerator coroutine = FlickerVFX();
            StartCoroutine(coroutine);
        }

        TimeElapsed -= Time.deltaTime;
    }

    void OnMouseDown()
    {
        SpriteShapeRenderer renderer = gameObject.GetComponent<SpriteShapeRenderer>();

        if (isFlickering)
        {
            int CurrentScore = int.Parse(ScoreText.text) + 1;
            string NewScore;

            if (10 > CurrentScore)
            {
                NewScore = "00" + CurrentScore;
            }
            else if (100 > CurrentScore)
            {
                NewScore = "0" + CurrentScore;
            }
            else
            {
                NewScore = "" + CurrentScore;
            }

            ScoreText.text = NewScore;
        }
    }

    private IEnumerator FlickerVFX()
    {
        SpriteShapeRenderer renderer = gameObject.GetComponent<SpriteShapeRenderer>();

        renderer.color = Dark;
        yield return new WaitForSeconds(0.15f);
        renderer.color = Transparent;
        yield return new WaitForSeconds(0.15f);
        renderer.color = Dark;
        yield return new WaitForSeconds(0.15f);
        renderer.color = Transparent;

        yield return new WaitForSeconds(0.15f);
        renderer.color = Dark;
        yield return new WaitForSeconds(0.15f);
        renderer.color = Transparent;

        isFlickering = false;
    }
}
