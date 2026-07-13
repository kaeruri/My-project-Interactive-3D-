using UnityEngine;

public class BallController : MonoBehaviour
{
    [Header("Physics Settings")]
    public float kickForce = 12f;
    public float interactionRange = 3.0f;

    private Rigidbody rb;
    private Transform playerCameraTransform;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (rb != null)
        {
            rb.Sleep();
        }
        
        if (Camera.main != null)
        {
            playerCameraTransform = Camera.main.transform;
        }
    }

    private void Update()
    {
        if (playerCameraTransform == null) return;

        float distance = Vector3.Distance(transform.position, playerCameraTransform.position);

        if (distance <= interactionRange)
        {
            if (UnityEngine.InputSystem.Keyboard.current != null && 
                UnityEngine.InputSystem.Keyboard.current.eKey.wasPressedThisFrame)
            {
                ApplyInteractionForce();
            }
        }
    }

    private void ApplyInteractionForce()
    {
        if (rb.IsSleeping())
        {
            rb.WakeUp();
        }

        Vector3 pushDirection = playerCameraTransform.forward;
        pushDirection.y = 0.1f; 
        pushDirection.Normalize();

        rb.AddForce(pushDirection * kickForce, ForceMode.Impulse);
        Debug.Log("Ball propelled forward via player input!");
    }
}