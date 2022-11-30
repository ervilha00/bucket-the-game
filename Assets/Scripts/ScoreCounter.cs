/* ScoreCounter.cs
 * Handles the score of the game and it's exibition in the GUI
 */

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class ScoreCounter : MonoBehaviour
{
    public float score = 0;                        //The current score
    private float initialTime = 0.0f;               //The time at the beginning of the scene
    private float difficulty = 0.0f;                //The current value of the difficulty
    public TextMeshProUGUI scoreLabel;              //The pointer to the score label
    
    public GameObject dropSpawnerGroup;             //The pointer for the spawn spawner group
    public float difficultyChangeInterval = 30.0f;  //The interval which the difficulty changes over time
    
    

    void Start()
    {
        initialTime = Time.time;
        StartCoroutine(UpdateDifficulty());
    }

    void Update()
    {
        //Updates the time score
        score += Time.deltaTime*10;
        scoreLabel.text = String.Format("Score: {0:#,0}", Mathf.RoundToInt(score));
        StateNameController.finalScore = score;
        
    }

    //Returns the time in seconds since the begining of the scene
    float GetDeltaTime()
    {
        float t = Time.time - initialTime;
        return t;
    }

    private IEnumerator UpdateDifficulty()
    {
        while(true)
        {
            yield return new WaitForSeconds(.25f);

            if (GetDeltaTime() >= difficultyChangeInterval)
            {
                difficulty += .25f;
                initialTime = Time.time;
                dropSpawnerGroup.BroadcastMessage("DifficultyChanged", difficulty);
            }
        }
            
    }


    
}
