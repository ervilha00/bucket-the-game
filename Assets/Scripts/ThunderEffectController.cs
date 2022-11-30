using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderEffectController : MonoBehaviour
{
    public AudioSource[] thunderAudio;
    public float minDelay = 10f;
    public float maxDelay = 60f;
    [Range(0f, 1f)]
    public float maxSpriteAlpha = 0.8f;
    public float minDelayAlphaChange = 0.05f;
    public float maxDelayAlphaChange = 0.15f;
    public float flashTime = 0.8f;
    private bool generateNewThunder = true;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ChangeSpriteAlpha(0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(generateNewThunder)
        {
            generateNewThunder = false;
            StartCoroutine("Kabum");

        }
    }

    private IEnumerator Kabum()
    {
        float delay = Random.Range(minDelay, maxDelay);
        //Debug.Log("Thunder in " + delay + " seconds");
        yield return new WaitForSeconds(delay);

        int thunderIndex = Random.Range(0, thunderAudio.Length);
        float initialTime = Time.time;
        thunderAudio[thunderIndex].Play();

        while((Time.time - initialTime) < flashTime)
        {
            ChangeSpriteAlpha(Random.Range(0f, maxSpriteAlpha));
            yield return new WaitForSeconds(Random.Range(minDelayAlphaChange, maxDelayAlphaChange));
        }

        ChangeSpriteAlpha(0f);
        generateNewThunder = true;

    }

    void ChangeSpriteAlpha(float a)
    {
        Color currentColor = spriteRenderer.color;
        currentColor.a = a;
        spriteRenderer.color = currentColor;
    }
}
