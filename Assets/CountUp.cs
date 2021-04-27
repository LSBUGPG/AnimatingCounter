using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUp : MonoBehaviour
{
    public int score;
    public float duration = 5f;
    Text scoreText;
    // Start is called before the first frame update
    void Awake()
    {
        scoreText = GetComponent<Text>();
    }

    [ContextMenu("Play")]
    public void Play()
    {
        if (Application.isPlaying)
        {
            StartCoroutine(Animate(score));
        }
        else
        {
            Debug.Log("You need to be running");
        }
    }

    IEnumerator Animate(int target)
    {
        float t = 0;
        if (target > 0)
        {
            while (t < 1f)
            {
                scoreText.text = (target - (target / Mathf.Pow(target, t))).ToString("N0");
                t += Time.deltaTime / duration;
                yield return null;
            }
        }
        scoreText.text = target.ToString("N0");
    }
}
