using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public enum SkillType
{
    Skill1,
    Skill2,
    Skill3,
}

public class PlayerSkill : MonoBehaviour
{
    Player player;

    public float skillCooldown;
    public float currentSkillCooldown;
    public float skillDuration;
    public float currentSkillDuration;

    [Space]
    public Sprite skillSprite;
    public GameObject skillPlaceholder;

    [SerializeField]
    private bool isUsingSkill = false;

    public float s1_Speed;

    private void Awake()
    {
        player = GetComponent<Player>();
        skillPlaceholder.GetComponent<Image>().sprite = skillSprite;
    }

    private void Update()
    {
        if (currentSkillCooldown > 0 && !isUsingSkill)
            currentSkillCooldown -= Time.deltaTime;

        if (currentSkillDuration > 0)
            currentSkillDuration -= Time.deltaTime;

        if (currentSkillCooldown <= 0)
            currentSkillDuration = skillDuration;
    }

    public void UseSkill(SkillType skillType)
    {
        if (currentSkillCooldown <= 0)
        {
            if (skillType == SkillType.Skill1)
            {
                Skill_1();
            }

            currentSkillCooldown = skillCooldown;
        }
    }

    private void Skill_1()
    {
        if (!isUsingSkill)
        {
            isUsingSkill = true;

            player.pb_movementSpeed += s1_Speed;
            StartCoroutine(EndSkill1());
        }
    }

    IEnumerator EndSkill1()
    {
        yield return new WaitForSeconds(skillDuration);
        player.pb_movementSpeed -= s1_Speed;
        isUsingSkill = false;
    }
}
