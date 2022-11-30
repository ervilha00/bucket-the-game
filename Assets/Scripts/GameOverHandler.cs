using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverHandler : MonoBehaviour
{
    public TextMeshProUGUI gameOverCounterLabel;    //The pointer to the counter label (counter for the game over scene)
    [Range(1, 10)]
    public int gameOverMaxCounter = 5;                 //The time in seconds until get game over
    private float gameOverCounter = 0f;
    [Range(0f, 5f)]
    public float gameOverCounterDelay = 1f;         //The delay in seconds to start the counter for game over
    private bool gameOverEnabled = false;           //Is the counter for game over enebaled?
    private float gameOverEnableTime = 0f;          //Holds the time that a game over cycle started
    public AudioSource alertSound;                  //The irritating sound precceding the game over
    public SpriteRenderer alertSprite;              //The red pulsating shadow in the screen when near the game over
    public float alertSpritePulsationSpeed = 1.0f;  //The pulsation speed of the alertSprite
    public FloorWaterHandler floorWaterHandler;     //The pointer to the script

    // Start is called before the first frame update
    void Start()
    {
        ResetGameOverCounter();
    }

    // Update is called once per frame
    void Update()
    {
        //The alternating alpha for the alertSprite
        float currentAlertSpriteOpacity = Mathf.Sin(Time.time * alertSpritePulsationSpeed) / 2f + .5f;
        Color alertSpriteColor = alertSprite.color;
        alertSpriteColor.a = currentAlertSpriteOpacity;
        alertSprite.color = alertSpriteColor;

        if (GetCurrentFlood() > 1f) //Trigger game over cycle
        {
            EnableGameOver();
        }
        else
        {   
            DisableGameOver();
        }

        if (gameOverEnabled)
        {
            UpdateGameOverCounter();   
        }
    }

    void ResetGameOverCounter()
    {
        gameOverCounter = gameOverMaxCounter;
    }

    void EnableGameOver()
    {
        if (!gameOverEnabled)
        {
            if (!alertSound.isPlaying)
            {
                alertSound.Play();
            }

            alertSprite.enabled = true;

            gameOverEnableTime = Time.time;
            gameOverCounterLabel.enabled = true;
            gameOverEnabled = true;
        }
    }

    void DisableGameOver()
    {
        if (gameOverEnabled)
        {
            alertSound.Stop();

            alertSprite.enabled = false;

            gameOverEnabled = false;
            gameOverCounterLabel.enabled = false;
            ResetGameOverCounter();
        }
    }

    void UpdateGameOverCounter()
    {
        gameOverCounterLabel.text = Mathf.Floor(gameOverCounter).ToString();
        gameOverCounter -= Time.deltaTime;
        if (gameOverCounter < 0f)
        {
            GameOver();
        }
    }

    float GetCurrentFlood()
    {
        return floorWaterHandler.floorCurrentCapacityPercent;
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
}
