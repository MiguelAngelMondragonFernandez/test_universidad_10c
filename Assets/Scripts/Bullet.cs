using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector3 direction;
    public float speed = 20f;
    void Update()
    {
        transform.position += direction * (speed * Time.deltaTime);
    }
}
