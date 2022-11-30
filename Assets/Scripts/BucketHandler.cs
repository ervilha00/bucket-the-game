/* BucketMovementHandler.cs
 * Handles how each bucket can be moved 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketHandler : MonoBehaviour
{
    private Vector3 _mouseOffset;
    private Rigidbody2D rb;

    public float minWaterLevel = 0f;
    public float maxWaterLevel = 0f;
    public float minWaterLineWidth = 0f;
    public float maxWaterLineWidth = 0f;
    public float maximumCapacity = 10f;
    public float currentCapacity = 0f;

    public float drainSpeed = 5f;

    public AudioSource drainSound;
    public AudioClip dropSound;
    public AudioClip dropFullSound;

    public ScoreIncreaseAnimController scoreIncreaseIndicatorPrefab;
    public ScoreCounter scoreCounter;
    public ScoreIncreaseAnimController bucketFullIndicatorPrefab;

    private bool drainBucket = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StateNameController.mouseOverDrainArea = false;
        
    }

    private void Update()
    {
        if (currentCapacity < maximumCapacity)
        {
            tag = "BucketNotFull";
        }else
        {
            tag = "BucketFull";
        }

        if (drainBucket)
        {
            float currentDrainValue = drainSpeed * Time.deltaTime;
            if ((currentCapacity - currentDrainValue) >= 0f)
            {
                currentCapacity -= currentDrainValue;
                if (!drainSound.isPlaying)
                {
                    drainSound.Play();
                }
            }
        }

        float waterLevel = (maxWaterLevel - minWaterLevel) / maximumCapacity * currentCapacity + minWaterLevel;
        float waterLineWidth = (maxWaterLineWidth - minWaterLineWidth) / maximumCapacity * currentCapacity + minWaterLineWidth;

        Vector3 waterLevelPos = new(0f, waterLevel, 1f);
        Vector3 waterLevelWd = new(waterLineWidth, 1f, 1f);
        transform.Find("WaterLevel").localPosition = waterLevelPos;
        transform.Find("WaterLevel").localScale = waterLevelWd;

    }

    void OnMouseDrag()
    {
        transform.position = GetMousePos() + _mouseOffset;
        if (StateNameController.mouseOverDrainArea)
        {
            drainBucket = true;
              
        }
        else
        {
            drainBucket = false;
            if (drainSound.isPlaying)
            {
                drainSound.Stop();
            }
        }
    }

    void OnMouseDown()
    {
        _mouseOffset = transform.position - GetMousePos();
        //rb.simulated = false;
        rb.gravityScale = 0.0f;
    }

    void OnMouseUp()
    {
        //rb.simulated = true;
        rb.gravityScale = 1.0f;
    }

    Vector3 GetMousePos()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        return mousePos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Drop"))
        {
            if (currentCapacity < maximumCapacity)
            {
                currentCapacity++;
                scoreCounter.score += 10f;
                Canvas mainCanvas = Canvas.FindObjectOfType<Canvas>();
                var scoreIncreaseIndicator = Instantiate(scoreIncreaseIndicatorPrefab, transform.position, Quaternion.identity, mainCanvas.transform);
                scoreIncreaseIndicator.scoreValue = 10;
                AudioSource.PlayClipAtPoint(dropSound, transform.position);
            }
            else
            {
                Canvas mainCanvas = Canvas.FindObjectOfType<Canvas>();
                Instantiate(bucketFullIndicatorPrefab, transform.position, Quaternion.identity, mainCanvas.transform);

                AudioSource.PlayClipAtPoint(dropFullSound, transform.position);
            }
        }

        



    }
}
