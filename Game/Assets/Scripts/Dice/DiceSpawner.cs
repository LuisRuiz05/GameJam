using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSpawner : MonoBehaviour
{
    //X: -5, 8.5
    //Y: 18
    //Z: -8.5, 5
    public GameObject normalDice;
    public GameObject bombDice;
    public GameObject healDice;
    public GameObject goldenDice;
    public GameObject deadlyDice;

    public enum diceType { Normal, Bomb, Heal, Golden, Deadly };

    public ChangePlayerPiece playerPiece;

    public float spawnTime = 1.25f;
    private bool hasSpawned = false;

    private void Update()
    {
        if (!hasSpawned)
        {
            hasSpawned = true;
            StartCoroutine(GenerateNewDice(spawnTime));
        }
    }

    (diceType, GameObject) DetermineDiceType(int playerLevel)
    {
        // Pawn (Peón)
        if (playerLevel == 0)
        {
            return Random.Range(1, 50) == 5 ? (diceType.Golden, goldenDice) : (diceType.Normal, normalDice);
        }
        // Knight (Caballo)
        if (playerLevel == 1)
        {
            return Random.Range(1, 50) == 5 ? (diceType.Golden, goldenDice) : Random.Range(1, 10) != 1 ? (diceType.Normal, normalDice) : (diceType.Heal, healDice);
        }
        // Bishop (Alfil)
        if (playerLevel == 2)
        {
            int randGoldenDice = Random.Range(1, 50);
            if (randGoldenDice == 5)
                return (diceType.Golden, goldenDice);

            int randomType = Random.Range(1, 11);
            // 1-7
            if (randomType >=1 && randomType <= 7)
                return (diceType.Normal, normalDice);
            // 8-9
            if (randomType == 8 || randomType == 9)
                return (diceType.Bomb, bombDice);
            // 10
            return (diceType.Heal, healDice);
        }
        // Rook (Torre)
        if (playerLevel == 3)
        {
            int randGoldenDice = Random.Range(1, 50);
            if (randGoldenDice == 5)
                return (diceType.Golden, goldenDice);

            int randomType = Random.Range(1, 11);
            // 1-3
            if (randomType >= 1 && randomType <= 3)
                return (diceType.Normal, normalDice);
            // 4-7
            if (randomType >= 4 && randomType <= 7)
                return (diceType.Bomb, bombDice);
            // 8-9
            if (randomType == 8 || randomType == 9)
                return (diceType.Heal, healDice);
            // 10
            return (diceType.Deadly, deadlyDice);
        }
        // Queen (Reina)
        if (playerLevel == 4)
        {
            int randomType = Random.Range(1, 11);
            // 1-2
            if (randomType == 1 || randomType == 2)
                return (diceType.Normal, normalDice);
            // 3-6
            if (randomType >= 3 && randomType <= 6)
                return (diceType.Bomb, bombDice);
            // 7-8
            if (randomType == 7 || randomType == 8)
                return (diceType.Heal, healDice);
            // 9
            if (randomType == 9)
                return (diceType.Deadly, deadlyDice);
            // 10
            return (diceType.Golden, goldenDice);
        }
        // King (Rey)
        else {
            int randGoldenDice = Random.Range(1, 50);
            if (randGoldenDice == 5)
                return (diceType.Golden, goldenDice);

            int randomType = Random.Range(1, 11);
            // 1-6
            if (randomType >= 1 && randomType <= 6)
                return (diceType.Bomb, bombDice);
            // 7-8
            if (randomType == 7 || randomType == 8)
                return (diceType.Heal, healDice);
            // 9-10
            return (diceType.Deadly, deadlyDice);
        }
    }

    public void SpawnDice(Vector3 position, (diceType, GameObject) diceTuple)
    {
        GameObject diceClone = Instantiate(diceTuple.Item2, position, transform.rotation);
        DestroyDice destroyDice = diceClone.AddComponent<DestroyDice>();
        destroyDice.type = diceTuple.Item1;
    }

    public Vector3 GenerateDiceSpawnpoint()
    {
        float randomX = Random.Range(-5f, 8.5f);
        float randomZ = Random.Range(-8.5f, 5f);
        Vector3 spawnPoint = new Vector3(randomX, 18, randomZ);

        return spawnPoint;
    }

    IEnumerator GenerateNewDice(float time)
    {
        yield return new WaitForSeconds(time);
        SpawnDice(GenerateDiceSpawnpoint(), DetermineDiceType(playerPiece.level));
        hasSpawned = false;
    }
}
