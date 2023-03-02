using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Outch!");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {

        if(other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;

            // Change Car's color
            spriteRenderer.color = hasPackageColor;

            Destroy(other.gameObject, destroyDelay);
            
            Debug.Log("Package picked up!");
        } else if(other.tag == "Customer" && hasPackage)
        {
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
            Debug.Log("Package delivered!");
        }
        // Debug.Log("What was that?");    

        // float tmp = 0;
        // for (int i = 0; i < 10; i++)
        // {
        //     Debug.Log(tmp.ToString());
        //     tmp += 13.34678f;
        // }
    }
}
