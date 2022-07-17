using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameProgression : MonoBehaviour
{
    public ChangePlayerPiece pieces;
    public int points;

    public AudioClip crash;
    public AudioClip explosion;

    void Update()
    {
        if (points >= 50 && points < 200)
        {
            pieces.level = 1;
            pieces.OnChangePiece(pieces.level);
        }
        if (points >= 200 && points < 400)
        {
            pieces.level = 2;
            pieces.OnChangePiece(pieces.level);
        }
        if (points >= 400 && points < 650)
        {
            pieces.level = 3;
            pieces.OnChangePiece(pieces.level);
        }
        if (points >= 650 && points < 900)
        {
            pieces.level = 4;
            pieces.OnChangePiece(pieces.level);
        }
        if (points >= 900 && points < 1200)
        {
            pieces.level = 5;
            pieces.OnChangePiece(pieces.level);
        }
        if (points >= 1200)
        {
            SceneManager.LoadScene(3);
        }
    }
}
