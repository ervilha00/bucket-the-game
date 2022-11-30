/* DropSpawner.cs
 * Spawns continuosly drops in regular time
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSpawner : MonoBehaviour
{
    public GameObject dropObject; //The drop object itself
    [Range(0.1f, 5.0f)]
    public float dropTime = 3.0f; //The time between each drop
    [Range(0f, 1f)]
    public float dropTimeVariation = 0.2f; //The random variation of the drop time
    [Range(0f, 5f)]
    public float dropMaxDelay = 5.0f; //The maximum delay for the first drop
    [Range(0f, 100f)]
    public float speedChangeFactor = 25.0f; //The denominator factor for difficulty change in the speed
    public float dropMinScale = 0.5f; //The smallest scale for the drop
    public float dropMaxScale = 1f; //The greatest scale for the drop

    private float dropDelay; //The delay for the first drop
    private bool isFirstDrop = true;
    private float difficulty = 0.0f;

    void Start()
    {
        dropDelay = Random.Range(0.1f, dropMaxDelay);
        //Debug.Log("First drop in " + dropDelay + " seconds.");
        StartCoroutine(CreateDrop());
    }

    void Update()
    {
        
    }

    //Create a drop every dropTime with a initial dropDelay time
    private IEnumerator CreateDrop()
    {
        while(true)
        {
            if(isFirstDrop)
            {
                yield return new WaitForSeconds(dropDelay);
                isFirstDrop = false;
            }
            else
            {
                yield return new WaitForSeconds(dropTime + Random.Range(-dropTimeVariation, dropTimeVariation));
            }

            var newDrop = Instantiate(dropObject, transform);
            float dropScale = Random.Range(dropMinScale, dropMaxScale);
            newDrop.transform.localScale *= dropScale;
        }
    }

    public void DifficultyChanged(float d)
    {
        difficulty = d;
        float dropTimeTest = dropTime - (difficulty / speedChangeFactor);
        
        if (dropTimeTest > 0.2f)
        {
            dropTime = dropTimeTest;
        }
        else
        {
            //Debug.Log(gameObject.GetInstanceID() + " Drop time reached minimum value.");
        }

        //Debug.Log("Drop time = " + dropTime);
    }

}
