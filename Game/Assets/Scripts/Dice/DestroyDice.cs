using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDice : MonoBehaviour
{
    public GameProgression progression;

    public AudioSource audio;

    public DiceSpawner.diceType type;
    public ParticleSystem explosionAnimation;
    public PlayerStatistics stats;

    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        progression = GameObject.FindGameObjectWithTag("Player").GetComponent<GameProgression>();
        audio = GetComponent<AudioSource>();
        collider = GetComponent<Collider>();
        explosionAnimation = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Board"))
        {
            if (type == DiceSpawner.diceType.Normal)
                StartCoroutine(DestroyDie(15f, 2)); audio.clip = progression.crash; audio.Play();
            if (type == DiceSpawner.diceType.Heal)
                StartCoroutine(DestroyDie(7f, 1)); audio.clip = progression.crash; audio.Play();
            if (type == DiceSpawner.diceType.Bomb)
                StartCoroutine(Explosion()); audio.clip = progression.crash; audio.Play();
            if ((type == DiceSpawner.diceType.Deadly))
                StartCoroutine(DestroyDie(10f, 10)); audio.clip = progression.crash; audio.Play();
            if ((type == DiceSpawner.diceType.Golden))
                StartCoroutine(DestroyDie(10f, 2)); audio.clip = progression.crash; audio.Play();
        }
    }

    public void HandleCollision()
    {
        if (type == DiceSpawner.diceType.Normal)
        {
            Destroy(gameObject);
        }
        if (type == DiceSpawner.diceType.Deadly)
        {
            Destroy(gameObject);
        }
        if (type == DiceSpawner.diceType.Heal)
            Destroy(gameObject);
        if (type == DiceSpawner.diceType.Golden)
            Destroy(gameObject);
    }

    IEnumerator DestroyDie(float time, int points)
    {
        yield return new WaitForSeconds(time);
        progression.points += points;
        Destroy(gameObject);
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2f);
        audio.clip = progression.explosion; audio.Play();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        explosionAnimation.Play();
        progression.points += 5;
        Destroy(gameObject, 0.5f);
    }
}
