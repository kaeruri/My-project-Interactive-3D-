using UnityEngine;

public class GiftBox : MonoBehaviour
{
    [Header("Settings")]
    public GameObject ballPrefab;
    public float playerInteractionRange = 3.5f;
    public int hitsRequired = 3;

    private int currentHits = 0;
    private Transform playerTransform;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerTransform = player.transform;
        }
    }

    private void Update()
    {
        if (playerTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance <= playerInteractionRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentHits++;
                Debug.Log("GiftBox Hit! Total hits: " + currentHits + "/" + hitsRequired);

                if (currentHits >= hitsRequired)
                {
                    SpawnBallAndDestroy();
                }
            }
        }
    }

    private void SpawnBallAndDestroy()
    {
        if (ballPrefab != null)
        {
            Instantiate(ballPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
