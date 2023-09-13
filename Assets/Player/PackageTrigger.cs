using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PackageTrigger : MonoBehaviour
{
    bool hasPackage = false;
    bool hasDelivered = false;

    [SerializeField] Color32 hasPackageColor = new Color32(32, 32, 32, 100);
    [SerializeField] Color32 noPackageColor = new Color32(64, 64, 64, 100);

    SpriteRenderer spriteRenderer;
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Package")
        {
            if (!hasPackage)
            {
                Debug.Log("Package picked up!");
                hasPackage = true;
                Destroy(collision.gameObject, 0.3f);
                spriteRenderer.color = hasPackageColor;

                hasDelivered = false;
                
            }
            else if (hasPackage)
            {
                Debug.Log("You already picked up the Package!");
            }
        }
        if (collision.tag == "Customer")
        {
            if (!hasDelivered && hasPackage)
            {
                Debug.Log("Package delivered, Customer satisfied!");
                hasDelivered = true;

                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
            else if (hasDelivered)
            {
                Debug.Log("You already delivered the package!");
            }
            else if (!hasDelivered && !hasPackage)
            {
                Debug.Log("You haven't picked up any package!");
            }
        }
    }
}
