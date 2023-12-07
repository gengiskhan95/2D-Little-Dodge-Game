using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused = false;
    public GameObject panelStart;
    public GameObject panelFinish;

    public TextMeshProUGUI textFinish;

    Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        panelStart.SetActive(true);
        PauseGame();
    }

    void Update()
    {
        if (panelFinish.activeSelf)
        {
            PauseGame();
        }

        else if (IsPlayerMoving() && isGamePaused)
        {
            StartGame();
        }
    }

    private bool IsPlayerMoving()
    {
        return Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D);
    }

    public void FinishGame()
    {
        if (score != null)
        {
            textFinish.text = "You've collided with an object this many times: " + score.hits + "\n" + textFinish.text;
        }
        else
        {
            textFinish.text = "You've collided with an object this many times: N/A" + "\n" + textFinish.text;
        }
        panelStart.SetActive(false);
        panelFinish.SetActive(true);
        PauseGame();
    }

    private void StartGame()
    {
        panelStart.SetActive(false);
        panelFinish.SetActive(false);
        ResumeGame();
    }
    private void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
    }
    private void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
    }
}
