using UnityEngine;

public class FallingSnowflake : MonoBehaviour
{
    float speed = 0.5f;
    void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
