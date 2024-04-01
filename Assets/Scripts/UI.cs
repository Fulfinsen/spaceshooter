using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UI : MonoBehaviour 
{
    //setting up the health slider
    [Header("Health")]
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;
    
    //setting up the score
    [Header("Score")]
    [SerializeField] TextMeshProUGUI score;
    ScoreKeeper scoreKeeper;


    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    // Start is called before the first frame update
    void Start()
    {
        healthSlider.maxValue = playerHealth.GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        healthSlider.value = playerHealth.GetHealth();
        score.text = scoreKeeper.GetScore().ToString("000000000");
    }
}
