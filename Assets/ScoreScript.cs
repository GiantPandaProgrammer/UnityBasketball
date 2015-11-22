using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    bool passing;
    int score;

    // Use this for initialization
    void Start()
    {
        passing = true;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision enter");

        if (passing)
        {
            score++;
            GameObject o = GameObject.Find("Score");
            o.GetComponent<Text>().text = "Score:" + score.ToString();
        }
         
        passing = !passing;
    }
}
