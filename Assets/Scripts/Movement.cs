using UnityEngine;

public class Movement : MonoBehaviour
{
    
    public Transform cameraTransform; 
    void Update()
    {
       

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        Vector3 cameraForward = new Vector3(cameraTransform.forward.x,0,cameraTransform.forward.z).normalized * vertical;
        Vector3 cameraRight = new Vector3(cameraTransform.right.x,0,cameraTransform.right.z ).normalized* horizontal;

        Vector3 direction = (cameraForward + cameraRight) * (Time.deltaTime * 5F);

        if (direction!= Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            //interpolacion 
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
        

        transform.position += direction;


    }

}