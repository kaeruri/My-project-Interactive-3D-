using UnityEngine;

public class GoalArea : MonoBehaviour
{
    [Header("Score Tracker")]
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<BallController>() != null)
        {
            score++;
            Debug.Log("GOAL! Total Score: " + score);
            
            Destroy(other.gameObject);
        }
    }
}
