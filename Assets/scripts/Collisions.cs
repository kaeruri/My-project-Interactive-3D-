using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 1;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
