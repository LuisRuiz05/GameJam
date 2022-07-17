using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangePlayerPiece : MonoBehaviour
{
    public DiceSpawner spawner;

    public GameObject pawn; // Peón
    public GameObject knight; // Caballo
    public GameObject bishop; // Alfil
    public GameObject rook; // Torre
    public GameObject queen; // Reina
    public GameObject king; // Rey

    public Image currentPiece;
    public Sprite pawnImage;
    public Sprite knightImage;
    public Sprite bishopImage;
    public Sprite rookImage;
    public Sprite queenImage;
    public Sprite kingImage;

    public int level = 0;

    private void Start()
    {
        pawn.SetActive(true);
        knight.SetActive(false);
        bishop.SetActive(false);
        rook.SetActive(false);
        queen.SetActive(false);
        king.SetActive(false);

        currentPiece.sprite = pawnImage;
    }

    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            level += 1;
            if (level <= 5)
            {
                OnChangePiece(level);
            }
        }*/
    }

    public void OnChangePiece(int level)
    {
        if(level == 1)
        {
            pawn.SetActive(false);
            knight.SetActive(true);
            bishop.SetActive(false);
            rook.SetActive(false);
            queen.SetActive(false);
            king.SetActive(false);

            spawner.spawnTime = 1.25f;
            currentPiece.sprite = knightImage;
        }
        if (level == 2)
        {
            pawn.SetActive(false);
            knight.SetActive(false);
            bishop.SetActive(true);
            rook.SetActive(false);
            queen.SetActive(false);
            king.SetActive(false);

            spawner.spawnTime = 1f;
            currentPiece.sprite = bishopImage;
        }
        if (level == 3)
        {
            pawn.SetActive(false);
            knight.SetActive(false);
            bishop.SetActive(false);
            rook.SetActive(true);
            queen.SetActive(false);
            king.SetActive(false);

            spawner.spawnTime = 0.75f;
            currentPiece.sprite = rookImage;
        }
        if (level == 4)
        {
            pawn.SetActive(false);
            knight.SetActive(false);
            bishop.SetActive(false);
            rook.SetActive(false);
            queen.SetActive(true);
            king.SetActive(false);

            spawner.spawnTime = 0.5f;
            currentPiece.sprite = queenImage;
        }
        if (level == 5)
        {
            pawn.SetActive(false);
            knight.SetActive(false);
            bishop.SetActive(false);
            rook.SetActive(false);
            queen.SetActive(false);
            king.SetActive(true);

            spawner.spawnTime = 0.5f;
            currentPiece.sprite = kingImage;
        }
    }
}
