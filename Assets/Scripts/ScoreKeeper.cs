using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{

    int score;
    static ScoreKeeper instance;

    public int GetScore()
    {  return score; }

    public void ResetScore()
    { score = 0; }


    private void Awake()
    {
        ManageSingleton();
    }

    void ManageSingleton()
    {
        //int instanceCount = FindObjectsOfType(GetType()).Length; first option of singleton
        //if (instanceCount > 1)

        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        Debug.Log(score);
    }
}
