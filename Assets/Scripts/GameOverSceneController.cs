using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameOverSceneController : MonoBehaviour
{
    public TextMeshProUGUI scoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        scoreLabel.text = String.Format("Score: {0:#,0}", Mathf.RoundToInt(StateNameController.finalScore));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartNewGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
