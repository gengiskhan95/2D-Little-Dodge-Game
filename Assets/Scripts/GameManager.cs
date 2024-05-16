using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private bool isGamePaused = false;
    [SerializeField] private GameObject panelStart;
    [SerializeField] private GameObject panelFinish;
    [SerializeField] private TextMeshProUGUI textFinish;
    private Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();

        if (panelStart != null)
        {
            panelStart.SetActive(true);
        }

        PauseGame();
    }

    private void Update()
    {
        if (panelFinish != null && panelFinish.activeSelf)
        {
            PauseGame();
        }
        else if (IsPlayerMoving() && isGamePaused)
        {
            StartGame();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
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
            textFinish.text = $"You collided with an object {score._hitCount} times.\nThat's all, folks!\n(Press R to restart the game.)";
        }
        else
        {
            textFinish.text = "You collided with an object this many times: N/A\nThat's all, folks!\n(Press R to restart the game.)";
        }

        if (panelStart != null)
        {
            panelStart.SetActive(false);
        }

        if (panelFinish != null)
        {
            panelFinish.SetActive(true);
        }

        PauseGame();
    }

    private void StartGame()
    {
        if (panelStart != null)
        {
            panelStart.SetActive(false);
        }

        if (panelFinish != null)
        {
            panelFinish.SetActive(false);
        }

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

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
