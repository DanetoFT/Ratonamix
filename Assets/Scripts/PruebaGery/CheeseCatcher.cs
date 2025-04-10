using UnityEngine;
using System.Collections;

public class CheeseCatcher : MonoBehaviour
{
    public Transform cheeseHoldPoint; 
    public Sprite[] cheeseSprites;
    public float spriteChangeDelay;
    public float particuleTime;
    public GameObject particuleSystem;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var Cheese = other.gameObject.GetComponent<Queso>();
        if (Cheese) 
        {
            StartCoroutine(AcopleQueso(other.gameObject));
        }
    }

    IEnumerator AcopleQueso(GameObject queso)
    {
        
        Rigidbody2D rb = queso.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            
        }

       queso.transform.position = cheeseHoldPoint.position;
        queso.transform.SetParent(cheeseHoldPoint); 

        // Cambiar sprites 
        SpriteRenderer Sr = queso.GetComponent<SpriteRenderer>();
        if (Sr != null && cheeseSprites.Length > 0)
        {
            for (int i = 0; i < cheeseSprites.Length; i++)
            {
                Sr.sprite = cheeseSprites[i];
                GameObject particuleIntance = null;
                if(particuleSystem != null)
                {
                    Quaternion RotationParticule = Quaternion.Euler(-180f,90f,0f);
                     particuleIntance = Instantiate(particuleSystem, queso.transform.position, RotationParticule, queso.transform);
                }
                yield return new WaitForSeconds(particuleTime);
                if(particuleIntance !=null)
                {
                    Destroy(particuleIntance);
                }
                float Delay = spriteChangeDelay - particuleTime;
                if (Delay > 0)
                {
                    yield return new WaitForSeconds(Delay);
                }
                
            }
            Destroy(queso);
        }
    }
}
