using UnityEngine;

public class CallBacks : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(0f, 0f, vertical) * (Time.deltaTime * 10);

        transform.Translate(direction);

        
        transform.Rotate(0f, 180f * horizontal * Time.deltaTime, 0f);
       
    }

}