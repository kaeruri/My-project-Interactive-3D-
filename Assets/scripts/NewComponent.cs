using UnityEngine;

public class NewComponent : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Vector3 newPosition = new Vector3(0.1f, 0.1f, 0.1f);
    Vector3 newRotation = new Vector3(0.1f, 0.0f, 0.0f);
    void Start()
    {
        print(transform.position.x);
        print(transform.position.y);
        print(transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += newPosition;
        if (transform.position.x > 10f)
        {
            newPosition = new Vector3(-0.1f, -0.1f, -0.1f);
        }

        if (transform.position.x < -10f)
        {
            newPosition = new Vector3(0.1f, 0.1f, 0.1f);
        }
        

        //transform.rotation *= Quaternion.Euler(newRotation);
        Vector3 rotation = transform.rotation.eulerAngles;
        rotation += newRotation;
        transform.rotation = Quaternion.Euler(rotation);

        float xAngle = transform.rotation.eulerAngles.x;

        if (xAngle > 180f) xAngle -= 360f;

        if (xAngle > 50f || xAngle < -50f)
        {
            newRotation = -newRotation; 
        }

    }
}
