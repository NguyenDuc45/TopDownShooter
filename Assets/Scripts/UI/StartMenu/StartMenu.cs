using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public AnimatorController animatorController;

    public GameObject blockingPanel;

    private bool isAtControlsOption = true;

    public void StartGame()
    {
        BlockingPanel(1);
        animatorController.transitionAnimator.SetBool("getIn", true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }

    public void Settings()
    {
        BlockingPanel(1);
        animatorController.MainGroupAnimGetOut();
        animatorController.SettingsGroupAnimGetIn();

        if (isAtControlsOption)
            animatorController.ControlsGroupAnimSlowGetIn();
        else animatorController.SoundsGroupAnimSlowGetIn();
    }

    public void Controls()
    {
        if (!isAtControlsOption)
        {
            BlockingPanel(0.3f);
            isAtControlsOption = true;
            animatorController.ControlsGroupAnimGetIn();
            animatorController.SoundsGroupAnimGetOut();
        }
    }

    public void Sounds()
    {
        if (isAtControlsOption)
        {
            BlockingPanel(0.3f);
            isAtControlsOption = false;
            animatorController.ControlsGroupAnimGetOut();
            animatorController.SoundsGroupAnimGetIn();
        }
    }

    public void Back()
    {
        BlockingPanel(1);
        animatorController.SettingsGroupAnimGetOut();

        if (isAtControlsOption)
            animatorController.ControlsGroupAnimSlowGetOut();
        else animatorController.SoundsGroupAnimSlowGetOut();

        animatorController.MainGroupAnimGetIn();
    }

    public void QuitGame()
    {
        Debug.Log("Ragequit");
        Application.Quit();

        /*animatorController.MainGroupAnimGetIn();
        animatorController.SettingsGroupAnimGetOut();*/
    }

    private void BlockingPanel(float waitTime)
    {
        blockingPanel.SetActive(true);
        StartCoroutine(DeactivateBlockingPanel(waitTime));
    }

    IEnumerator DeactivateBlockingPanel(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        blockingPanel.SetActive(false);
    }
}
