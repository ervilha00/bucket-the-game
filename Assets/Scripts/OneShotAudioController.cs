using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotAudioController : MonoBehaviour
{
    private AudioSource m_AudioSource;
    public float volume = 1f;
    public float pitch = 1f;

    private bool audioStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_AudioSource.volume = volume;
        m_AudioSource.pitch = pitch;
        m_AudioSource.Play();
        audioStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (audioStarted)
        {
            if (!m_AudioSource.isPlaying)
            {
                Destroy(gameObject);
            }
        }
    }
}
