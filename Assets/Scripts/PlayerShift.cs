using UnityEngine;

public class PlayerShift : MonoBehaviour
{
    private bool isCar = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isCar)
            {
                ShiftToPlane();
            }
            else if (!isCar)
            {
                ShiftToCar();
            }
        }
    }

    private void ShiftToCar()
    {
        isCar = true;
        Debug.Log("Agora sou um carro");
    }

    private void ShiftToPlane()
    {
        isCar = false;
        Debug.Log("Agora sou um aviao");
    }

    public bool IsCar() { return isCar; }
}
