using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombDefuse : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (251,9,9,255);
    [SerializeField] Color32 noPackageColor = new Color32 (196,196,196,255);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage = false;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("This is the BombDefuse class working");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Bomb" && !hasPackage)
        {
            Debug.Log("Picked up bomb!");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        else if(other.tag == "DefuseArea" && hasPackage) 
        {
            Debug.Log("Bomb Defused");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }


    }
}
