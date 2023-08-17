using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    public Animator titleAnimator;
    public Animator splashAnimator;
    public Animator rect1Animator;
    public Animator rect2Animator;

    public Animator startButtonAnimator;
    public Animator settingsButtonAnimator;
    public Animator quitButtonAnimator;

    public Animator settingsTitleAnimator;
    public Animator controlsButtonAnimator;
    public Animator soundsButtonAnimator;
    public Animator backButtonAnimator;

    public Animator controlsGroupAnimator;
    public Animator soundsGroupAnimator;

    public Animator transitionAnimator;

    private void Awake()
    {
        settingsTitleAnimator.SetBool("stayOut", true);
        controlsButtonAnimator.SetBool("stayOut", true);
        soundsButtonAnimator.SetBool("stayOut", true);
        backButtonAnimator.SetBool("stayOut", true);
    }

    public void MainGroupAnimGetIn()
    {
        titleAnimator.SetBool("getIn", true);
        splashAnimator.SetBool("getIn", true);
        rect1Animator.SetBool("getIn", true);
        rect2Animator.SetBool("getIn", true);
        startButtonAnimator.SetBool("getIn", true);
        settingsButtonAnimator.SetBool("getIn", true);
        quitButtonAnimator.SetBool("getIn", true);
    }

    public void MainGroupAnimGetOut()
    {
        titleAnimator.SetBool("getIn", false);
        splashAnimator.SetBool("getIn", false);
        rect1Animator.SetBool("getIn", false);
        rect2Animator.SetBool("getIn", false);
        startButtonAnimator.SetBool("getIn", false);
        settingsButtonAnimator.SetBool("getIn", false);
        quitButtonAnimator.SetBool("getIn", false);
    }

    public void SettingsGroupAnimGetIn()
    {
        settingsTitleAnimator.SetBool("stayOut", false);
        settingsTitleAnimator.SetBool("getIn", true);
        controlsButtonAnimator.SetBool("stayOut", false);
        controlsButtonAnimator.SetBool("getIn", true);
        soundsButtonAnimator.SetBool("stayOut", false);
        soundsButtonAnimator.SetBool("getIn", true);
        backButtonAnimator.SetBool("stayOut", false);
        backButtonAnimator.SetBool("getIn", true);
    }

    public void SettingsGroupAnimGetOut()
    {
        settingsTitleAnimator.SetBool("getIn", false);
        controlsButtonAnimator.SetBool("getIn", false);
        soundsButtonAnimator.SetBool("getIn", false);
        backButtonAnimator.SetBool("getIn", false);
    }

    public void ControlsGroupAnimGetIn()
    {
        controlsGroupAnimator.SetBool("stayOut", false);
        controlsGroupAnimator.SetBool("getIn", true);
    }

    public void ControlsGroupAnimGetOut()
    {
        controlsGroupAnimator.SetBool("getIn", false);
    }

    public void ControlsGroupAnimSlowGetIn()
    {
        controlsGroupAnimator.SetBool("stayOut", false);
        controlsGroupAnimator.SetBool("getIn", true);
        controlsGroupAnimator.SetBool("slowMoving", false);
    }

    public void ControlsGroupAnimSlowGetOut()
    {
        controlsGroupAnimator.SetBool("getIn", false);
        controlsGroupAnimator.SetBool("slowMoving", true);
    }

    public void SoundsGroupAnimGetIn()
    {
        soundsGroupAnimator.SetBool("stayOut", false);
        soundsGroupAnimator.SetBool("getIn", true);
    }

    public void SoundsGroupAnimGetOut()
    {
        soundsGroupAnimator.SetBool("getIn", false);
    }

    public void SoundsGroupAnimSlowGetIn()
    {
        soundsGroupAnimator.SetBool("stayOut", false);
        soundsGroupAnimator.SetBool("getIn", true);
        soundsGroupAnimator.SetBool("slowMoving", false);
    }

    public void SoundsGroupAnimSlowGetOut()
    {
        soundsGroupAnimator.SetBool("getIn", false);
        soundsGroupAnimator.SetBool("slowMoving", true);
    }
}
