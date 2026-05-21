using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] collectibles =
                GameObject.FindGameObjectsWithTag("Collectible");

            if (collectibles.Length == 0)
            {
                print("You collected everything!");
            }
            else
            {
                print("Collect all collectibles first!");
            }
        }
    }
}