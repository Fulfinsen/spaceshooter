using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();

        if (scoreKeeper == null)
        {
            Debug.LogError("ScoreKeeper not found!");
        }
        else
        {
            Debug.Log("ScoreKeeper found!");
        }
    }

    void Start()
    {
        if (scoreKeeper != null)
        {
            scoreText.text = "Your score:\n" + scoreKeeper.GetScore();
        }
        else
        {
            Debug.LogError("ScoreKeeper is null, cannot update score text!");
        }
    }
}
