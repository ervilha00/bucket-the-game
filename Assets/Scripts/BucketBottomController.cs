using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketBottomController : MonoBehaviour
{
    public AudioClip bucketHitFloorSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            AudioSource.PlayClipAtPoint(bucketHitFloorSound, transform.position);
        }
    }
}
