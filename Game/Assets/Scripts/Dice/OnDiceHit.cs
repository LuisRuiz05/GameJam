using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDiceHit : MonoBehaviour
{
    public Collider collider;
    public PlayerStatistics stats;
    public AudioSource audio;

    bool hasReceivedExplosiveDamage = false;

    void Awake()
    {
        collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {

        DiceSpawner.diceType type = other.GetComponent<DestroyDice>().type;
        Effect(type);
        other.GetComponent<DestroyDice>().HandleCollision();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            ExplosionEffect(other.gameObject);
            return;
        }
    }

    public void ExplosionEffect(GameObject bomb)
    {
        if (bomb.GetComponent<ParticleSystem>().isPlaying)
        {
            StartCoroutine(ExplosionImmunity());
        }
    }

    public void Effect(DiceSpawner.diceType type)
    {
        if (type == DiceSpawner.diceType.Normal)
        {
            if (!stats.hasShield)
            {
                if (stats.currentLife > 0)
                {
                    stats.currentLife -= 1;
                    audio.Play();
                }
            } else {
                stats.hasShield = false;
                audio.Play();
                StopCoroutine(stats.ShieldCountdown());
            }
        }
        if (type == DiceSpawner.diceType.Bomb)
        {
            if (!stats.hasShield)
            {
                if (stats.currentLife > 0)
                {
                    stats.currentLife -= 1;
                    audio.Play();
                }
            } else {
                stats.hasShield = false;
                audio.Play();
                StopCoroutine(stats.ShieldCountdown());
            }
        }
        if (type == DiceSpawner.diceType.Deadly)
        {
            if (!stats.hasShield)
            {
                if (stats.currentLife > 0)
                {
                    stats.currentLife = 0;
                    audio.Play();
                }
            } else {
                stats.hasShield = false;
                audio.Play();
                StopCoroutine(stats.ShieldCountdown());
            }
        }
        if (type == DiceSpawner.diceType.Heal)
        {
            if (stats.currentLife < 3)
            {
                stats.currentLife += 1;
            }
        }
        if (type == DiceSpawner.diceType.Golden)
        {
            if (!stats.hasShield)
            {
                stats.hasShield = true;
                stats.UseShield();
            }
        }
        stats.UpdateUI();
    }

    IEnumerator ExplosionImmunity()
    {
        if (!hasReceivedExplosiveDamage)
        {
            hasReceivedExplosiveDamage = true;
            if (!stats.hasShield)
            {
                stats.currentLife -= 2;
                audio.Play();
            } else {
                stats.hasShield = false;
                StopCoroutine(stats.ShieldCountdown());
            }
            stats.UpdateUI();
        }
        yield return new WaitForSeconds(1f);
        hasReceivedExplosiveDamage = false;
    }
}
