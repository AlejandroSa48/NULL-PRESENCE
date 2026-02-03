using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreValue = 10;
    public ScoreSystem scoreSystem;

    public void Collect()
    {
        scoreSystem.AddScore(scoreValue);
        Debug.Log($"Collected! Score increased by {scoreValue}.");
    }

}
