using UnityEngine;

public class fogones : MonoBehaviour
{
    Ratoncillo ratoncillo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ratoncillo = collision.GetComponent<Ratoncillo>();

        ratoncillo.Spawner(ratoncillo.nivelActual);
    }
}
