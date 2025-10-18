using UnityEngine;
using UnityEngine.Rendering;

public class practica : MonoBehaviour
{

    public float velocidad = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float movHorizontal = Input.GetAxis("Horizontal");
        float movVertical = Input.GetAxis("Vertical");
        float movimientoHorizontal = movHorizontal * velocidad * Time.deltaTime;
        float movimientoVertical = movVertical * velocidad * Time.deltaTime;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Salto(movimientoHorizontal, movimientoVertical);
        }
        if (movHorizontal != 0 || movVertical != 0)
        {
            Movimiento(movimientoHorizontal, movimientoVertical);
        }
    }

    public void Movimiento(float movimientoHorizontal, float movimientoVertical)
    {

        transform.Translate(movimientoHorizontal, 0f, movimientoVertical);
    }

    public void Salto(float movimientoHorizontal, float movimientoVertical)
    { 
        float salto = Input.GetAxis("Jump") * velocidad * Time.deltaTime;
        transform.Translate(movimientoHorizontal, salto, movimientoVertical);
    }

}
