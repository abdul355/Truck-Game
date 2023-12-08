using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    private int score = 0;

    // This method is called once when the script is first executed
    void Start()
    {
        // Check if the scoreText variable is not assigned in the Unity Editor
        if (scoreText == null)
        {
            Debug.LogError("scoreText is not assigned. Please assign it in the Unity Editor.");
        }
    }

    // This method is called every frame
    void Update()
    {
        // Check if scoreText is still null (just in case)
        if (scoreText != null)
        {
            // Update the UI text with the current score
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogError("scoreText is null. Please make sure it is assigned in the Unity Editor.");
        }
    }
        public void IncreaseScore(int points)
{
    // Check if points is greater than zero before increasing the score
    if (points > 0)
    {
        // Call this method when you want to increase the score
        score += points;
        Debug.Log("Score increased: " + score);
    }
    else
    {
        Debug.LogWarning("Points should be greater than zero to increase the score.");
    }
}
    // public void IncreaseScore(int points)
    // {
    //     // Call this method when you want to increase the score
    //     score += points;
    //     IncreaseScore(10);
    // }
}

// public class Score : MonoBehaviour
// {
//     public Text scoreText;
//     private int score = 1;

//     void Update()
//     {
//         // // Update the UI text with the current score
//         // scoreText.text = "Score: " + score;

//          // Assuming you've dragged the Text component to scoreText in the Unity Editor
//     if (scoreText == null)
//     {
//         Debug.LogError("scoreText is not assigned. Please assign it in the Unity Editor.");
//     }
//     }

//     public void IncreaseScore(int points)
//     {
//         // Call this method when you want to increase the score
//         score += points;

        
//     }
// }
