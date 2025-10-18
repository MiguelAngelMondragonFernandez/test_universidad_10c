using UnityEngine;

public class CoinScript : MonoBehaviour
{

    private int coinValue = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 360f * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //sumar puntos
            PointManager.Instance.AddPoints(coinValue);
            //desactivar el objeto
            gameObject.SetActive(false);
        }
    }
}
