using UnityEngine;

public class AddScoreButton : MonoBehaviour
{
    public ScoreSystem scoreSystem;
    public int scoreValue = 10;

    public void OnClick()
    {
        scoreSystem.AddScore(scoreValue);
    }
}


