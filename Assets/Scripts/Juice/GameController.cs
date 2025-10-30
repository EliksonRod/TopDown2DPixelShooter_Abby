using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    float currScore = 0;

    [SerializeField] TextMeshProUGUI scoreAmount;

    private void Start()
    {
        currScore = 0;
    }
    public void AddScore(float amount)
    {
        currScore += amount;
        UpdateScoreUI();
    }
    private void UpdateScoreUI()
    {
        scoreAmount.text = currScore.ToString("0");
        
    }
}
