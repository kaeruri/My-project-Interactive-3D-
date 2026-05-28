using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollect : MonoBehaviour
{
    public float collectDistance = 5f;
    public LayerMask collectibleLayer;
    public PlayerScore playerScore;

    AudioSource collectibleAudio;

    void Update()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            Ray ray = new Ray(transform.position + Vector3.up, transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, collectDistance, collectibleLayer))
            {
                Collectible c = hit.collider.GetComponent<Collectible>();
                if (c != null)
                {
                    playerScore.AddScore(c.scoreValue);
                    c.Collect();
                }
            }
        }
    }
}
