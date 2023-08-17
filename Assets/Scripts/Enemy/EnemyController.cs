using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private Enemy enemy;
    [SerializeField]
    private GameObject damagePopup;
    public Vector3 popupOffset = new Vector3(0.5f, 0.5f, 0);

    [SerializeField]
    private float currentHitPoint;
    public float movementSpeed { get; private set; }
    public float damage { get; private set; }
    private float damageReduction = 1;

    public float patrolDistance { get; private set; }
    public float patrolCooldown { get; private set; }

    [SerializeField]
    public GameObject onDestroyFX;

    [Space]
    public bool isDead = false;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = enemy.sprite;
        currentHitPoint = enemy.hitPoint;
        movementSpeed = enemy.movementSpeed;
        damage = enemy.damage;
        patrolDistance = enemy.patrolDistance;
        patrolCooldown = enemy.patrolCooldown;
    }

    private void Update()
    {
        //TakeDamage();
        Die();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.tag.Equals("Player"))
        {
            Player player = collision.gameObject.GetComponent<Player>();
            player.TakeDamage(damage);
        }
    }

    private void OnDestroy()
    {
        
    }

    public void TakeDamage(float damageTaken, DamageType damageType)
    {
        float finalDamage = damageTaken * damageReduction;

        currentHitPoint -= finalDamage;

        Vector3 randomOffet = popupOffset + new Vector3(Random.Range(0, 0.3f), Random.Range(0, 0.3f), 0);
        GameObject popup = Instantiate(damagePopup, transform.position + randomOffet, Quaternion.identity);
        popup.GetComponent<TextMeshPro>().text = finalDamage.ToString();

        if (damageType == DamageType.True)
            popup.GetComponent<TextMeshPro>().color = Color.white;

        Destroy(popup, 1f);

        Debug.Log("That's hurt senpai >.<");
    }

    private void Die()
    {
        if (currentHitPoint <= 0)
        {
            Debug.Log("Hidoi desu (╥_╥)");
            isDead = true;

            GameObject effect = Instantiate(onDestroyFX, transform.position, Quaternion.identity);
            ParticleSystem.MainModule mainModule = effect.GetComponent<ParticleSystem>().main;
            mainModule.startColor = GetComponent<SpriteRenderer>().color;
            Destroy(effect, 3f);

            Destroy(gameObject);
        }
    }
}
