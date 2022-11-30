/* ScoreCounter.cs
 * Handles the actions when the drops reach the floor
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorWaterHandler : MonoBehaviour
{
    public AudioClip dropSound;
    public float floorMaxCapacity = 100f;
    public float floorCurrentCapacity = 0f;
    private float floodMinScale;
    public float floodMaxScale = 5.0f;
    private float floodStep;
    private DropBehaviour incomingDrop;
    public float floodReduceSpeed = 0.25f;
    private float initialY;
    public float floorCurrentCapacityPercent = 0f;


    void Start()
    {
        floodMinScale = transform.localScale.y;
        floodStep = floorMaxCapacity / (floodMaxScale - floodMinScale);
        initialY = transform.position.y;
        gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
    }

    // Update is called once per frame
    void Update()
    {
        float currentTimeDelta = Time.deltaTime;
        float currentFloodReduce = currentTimeDelta * floodReduceSpeed;

        if (floorCurrentCapacity > currentFloodReduce)
        {
            floorCurrentCapacity -= currentFloodReduce;
            UpdateFloodHeight();
        }

        floorCurrentCapacityPercent = floorCurrentCapacity / floorMaxCapacity;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Drop"))
        {
            incomingDrop = collision.GetComponent<DropBehaviour>();
            floorCurrentCapacity += incomingDrop.dropFloodCapacity;
            UpdateFloodHeight();
            AudioSource.PlayClipAtPoint(dropSound, collision.transform.position);
        }
    }

    void UpdateFloodHeight()
    {
        float _y = (floodMaxScale-floodMinScale) / floorMaxCapacity * floorCurrentCapacity + floodMinScale;
        RescaleFloorHeight(_y);

    }

    void RescaleFloorHeight(float h)
    {
        Vector3 rescale = new(0f, h - transform.localScale.y, 0f);
        
        float newY = initialY + h / 2f - 0.25f;
        Vector3 newTransform = new Vector3(transform.position.x, newY, transform.position.z);
        transform.position = newTransform;
        transform.localScale += rescale;
        //Debug.Log(rescale);
    }
}
