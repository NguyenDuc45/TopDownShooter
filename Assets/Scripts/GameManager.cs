using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Animator transitionAnimator;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

    private void OnPause(InputValue inputValue)
    {
        if (pauseMenu.activeSelf == false)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        StartCoroutine(LoadScene(1));
    }

    public void QuitGame()
    {
        transitionAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        StartCoroutine(UnfreezeGame());
        StartCoroutine(LoadScene(0));
    }

    IEnumerator UnfreezeGame()
    {
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1f;
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        transitionAnimator.SetBool("getIn", true);
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(sceneIndex);
    }

    public void ShowGameOverMenu()
    {
        StartCoroutine(SetGameOverMenuActive());
    }

    IEnumerator SetGameOverMenuActive()
    {
        yield return new WaitForSeconds(1);
        gameOverMenu.SetActive(true);
    }
}
