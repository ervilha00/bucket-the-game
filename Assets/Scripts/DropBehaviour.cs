/* DropBehaviour.cs
 * Handles the behaviour of each individual drop
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBehaviour : MonoBehaviour
{
    public float dropFloodCapacity = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(3, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("BucketFull"))
        {

        }
        else
        {
            Destroy(gameObject);
        }

        
    }
}
