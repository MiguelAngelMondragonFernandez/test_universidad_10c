using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public Transform cameraTransform;
    public float cameraSensibility = 50f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.position -cameraTransform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        cameraTransform.rotation = targetRotation;
        
        float mouseDelta = Input.mousePositionDelta.x * Time.deltaTime;
        transform.Rotate(0, mouseDelta * cameraSensibility, 0);

        transform.position = target.position ;
        cameraTransform.localPosition = offset;

    }
}
