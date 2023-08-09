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
    private Bullet bullet;
    [SerializeField]
    private GameObject damagePopup;
    public Vector3 popupOffset = new Vector3(0.5f, 0.5f, 0);

    [SerializeField]
    private float currentHitPoint;
    public float movementSpeed { get; private set; }
    private float damageReduction = 1;
    private bool takenDamage = false;

    public float patrolDistance { get; private set; }
    public float patrolCooldown { get; private set; }

    [SerializeField]
    public GameObject onDestroyFX;

    private void Awake()
    {
        GetComponent<SpriteRenderer>().sprite = enemy.sprite;
        currentHitPoint = enemy.hitPoint;
        movementSpeed = enemy.movementSpeed;
        patrolDistance = enemy.patrolDistance;
        patrolCooldown = enemy.patrolCooldown;
    }

    private void Update()
    {
        TakeDamage();
        Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            bullet = collision.GetComponent<Bullet>();
            float bulletDamage = bullet.damage * damageReduction;

            currentHitPoint -= bulletDamage;
            takenDamage = true;

            Vector3 randomOffet = popupOffset + new Vector3(Random.Range(0, 0.3f), Random.Range(0, 0.3f), 0);
            GameObject popup = Instantiate(damagePopup, transform.position + randomOffet, Quaternion.identity);
            popup.GetComponent<TextMeshPro>().text = bulletDamage.ToString();
            if (bullet.damageType == DamageType.True)
                popup.GetComponent<TextMeshPro>().color = Color.white;
            Destroy(popup, 1f);

            Destroy(collision.gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(onDestroyFX, transform.position, Quaternion.identity);
        ParticleSystem.MainModule mainModule = effect.GetComponent<ParticleSystem>().main;
        mainModule.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(effect, 3f);
    }

    private void TakeDamage()
    {
        if (takenDamage)
        {
            Debug.Log("That's hurt senpai >.<");
            takenDamage = false;
        }
    }

    private void Die()
    {
        if (currentHitPoint <= 0)
        {
            Debug.Log("Hidoi desu (╥_╥)");
            Destroy(gameObject);
        }
    }
}
