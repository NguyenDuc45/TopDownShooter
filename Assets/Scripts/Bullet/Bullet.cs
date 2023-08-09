using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;
    public DamageType damageType;
    public float knockBack;

    public GameObject onDestroyFX;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall") || collision.CompareTag("BreakableWall"))
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        GameObject effect = Instantiate(onDestroyFX, transform.position, Quaternion.identity);
        ParticleSystem.MainModule mainModule = effect.GetComponent<ParticleSystem>().main;
        mainModule.startColor = GetComponent<SpriteRenderer>().color;
        Destroy(effect, 3f);
    }
}

public enum DamageType
{
    Normal,
    True,
}
