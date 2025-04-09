using UnityEngine;
using UnityEngine.UIElements;

public class Ratoncillo : MonoBehaviour
{
    private Transform cheeseTransform;

    public float speed;
    public float rotationSpeed;

    public Transform queso;

    private void Awake()
    {
        cheeseTransform = transform;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Chase();
    }

    void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, queso.transform.position, speed * Time.deltaTime);

        Vector3 cheeseDirection = (queso.position - transform.position).normalized;

        float angle = Mathf.Atan2(cheeseDirection.y, cheeseDirection.x) * Mathf.Rad2Deg;
        cheeseTransform.eulerAngles = new Vector3(0, 0, angle);
    }
}
