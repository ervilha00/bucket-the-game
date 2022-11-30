using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreIncreaseAnimController : MonoBehaviour
{
    public int scoreValue;
    public float lifetime = 2f;
    public bool fadeOut = true;
    public bool randomAngle = true;
    public bool useDefaultText = false;

    private TextMeshProUGUI TMComponent;
    private float motionSpeed;
    // Start is called before the first frame update
    void Start()
    {
        TMComponent = GetComponent<TextMeshProUGUI>();
        
        if (!useDefaultText)
        {
            TMComponent.text = "+" + scoreValue.ToString();
        }
        motionSpeed = 1f / lifetime;

        if (randomAngle)
        {
            transform.localRotation = Quaternion.Euler(0f, 0f, Random.Range(-30f, 30f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fadeOut)
        {
            Color currentColor = TMComponent.color;
            float currentAlpha = currentColor.a;
            //Debug.Log("Current alpha = " + currentAlpha);
            float newAlpha = currentAlpha - motionSpeed * Time.deltaTime;
            //Debug.Log("New alpha = " + newAlpha);
            if (newAlpha >= 0f)
            {
                currentColor.a = newAlpha;
                TMComponent.color = currentColor;
            }
            else
            {
                //Debug.Log("Destroy");
                Destroy(gameObject);
            }
        }


    }
}
