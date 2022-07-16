using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDice : MonoBehaviour
{
    public DiceSpawner.diceType type;
    public ParticleSystem explosionAnimation;

    private Collider collider;

    // Start is called before the first frame update
    void Start()
    {
        collider = GetComponent<Collider>();
        explosionAnimation = gameObject.GetComponentInChildren<ParticleSystem>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Board"))
        {
            if (type == DiceSpawner.diceType.Normal)
                StartCoroutine(DestroyDie(25f));
            if (type == DiceSpawner.diceType.Heal)
                StartCoroutine(DestroyDie(5f));
            if (type == DiceSpawner.diceType.Bomb)
                StartCoroutine(Explosion());
            if ((type == DiceSpawner.diceType.Deadly))
                StartCoroutine(DestroyDie(3f));
            if ((type == DiceSpawner.diceType.Golden))
                StartCoroutine(DestroyDie(7f));
        }
    }

    public void HandleCollision()
    {
        if (type == DiceSpawner.diceType.Normal)
        {
            Destroy(gameObject);
            Damage();
        }
        if (type == DiceSpawner.diceType.Deadly)
        {
            Destroy(gameObject);
            Damage();
        }
        if (type == DiceSpawner.diceType.Heal)
            Destroy(gameObject);
        if (type == DiceSpawner.diceType.Bomb)
            Damage();
        if (type == DiceSpawner.diceType.Golden)
            Destroy(gameObject);
    }

    public void Damage()
    {
        //Damage
    }

    IEnumerator DestroyDie(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    IEnumerator Explosion()
    {
        yield return new WaitForSeconds(2f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        explosionAnimation.Play();
        Destroy(gameObject, 0.5f);
    }
}
