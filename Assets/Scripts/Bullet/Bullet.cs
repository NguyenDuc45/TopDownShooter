using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public DamageType damageType;
    public float knockBack;
    public float piercingCount;

    public GameObject onDestroyFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("BreakableWall"))
        {
            DestroyBullet();
        }

        if (collision.CompareTag("Enemy"))
        {
            EnemyController enemy = collision.GetComponent<EnemyController>();
            enemy.TakeDamage(damage, damageType);

            if (piercingCount > 0)
                piercingCount--;
            else DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        GameObject effect = Instantiate(onDestroyFX, transform.position, Quaternion.identity);
        ParticleSystem.MainModule mainModule = effect.GetComponent<ParticleSystem>().main;
        mainModule.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(effect, 3f);
        Destroy(gameObject);
    }
}

public enum DamageType
{
    Normal,
    True,
}
