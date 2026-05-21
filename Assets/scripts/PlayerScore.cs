using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;

    public void AddScore(int value)
    {
        score += value;
        Debug.Log("Score: " + score);
    }
}
