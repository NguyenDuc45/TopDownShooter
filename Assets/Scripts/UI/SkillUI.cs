using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillUI : MonoBehaviour
{
    public StatBar skillCooldownBar;
    public StatBar skillDurationBar;

    PlayerSkill playerSkill;

    private void Awake()
    {
        skillCooldownBar = transform.Find("Skill Cooldown Bar").GetComponent<StatBar>();
        skillDurationBar = transform.Find("Skill Duration Bar").GetComponent<StatBar>();

        playerSkill = GameObject.FindWithTag("Player").GetComponent<PlayerSkill>();
    }

    private void Update()
    {
        UpdateSkillBar();
    }

    private void UpdateSkillBar()
    {
        skillCooldownBar.SetMaxValue(playerSkill.skillCooldown);
        skillDurationBar.SetMaxValue(playerSkill.skillDuration);

        skillCooldownBar.SetValue(playerSkill.skillCooldown - playerSkill.currentSkillCooldown);
        skillDurationBar.SetValue(playerSkill.currentSkillDuration);
    }
}
