using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DragMouse : MonoBehaviour
{
    public float Force = 500f;
    public LayerMask draggable;
    Rigidbody2D Rb;


    private void FixedUpdate()
    {
        if (Rb)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0; 
            Vector3 direcion = (mousePos - Rb.transform.position);
            Rb.linearVelocity = direcion * Force * Time.fixedDeltaTime;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))//es cero porque es el click izquierdo
        {
            Rb = GetRigidbodyFromMouseClick();
        }
        if (Input.GetMouseButtonUp(0))
        {
            Rb = null;
        }
    }
    Rigidbody2D GetRigidbodyFromMouseClick()
    {
       Vector2 clickPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       RaycastHit2D hit = Physics2D.Raycast(clickPoint, Vector2.zero,Mathf.Infinity, draggable);
        if (hit)
        {
            if (hit.collider != null)
            {
                return hit.collider.gameObject.GetComponent<Rigidbody2D>();
            }

        }
        return null;
    }
}
