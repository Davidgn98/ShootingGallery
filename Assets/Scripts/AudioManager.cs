using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public AudioMixer mainAudioMixer;
    public AudioMixerGroup musicAudioMixerGroup;
    public AudioMixerGroup fxAudioMixerGroup;

    public Sound[] music;
    [Range(0.0001f, 1f)]
    public float musicVolume = 0.5f;
    [Range(0.0001f, 1f)]
    public float fxVolume = 0.5f;

    public Sound[] fx;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        // Make the object persisten between scenes
        DontDestroyOnLoad(gameObject);

        // Create an AudioSource for each music element and configure it
        foreach (Sound s in music)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            // Set the output of the Audio Sources
            s.source.outputAudioMixerGroup = musicAudioMixerGroup;
        }
        foreach (Sound s in fx)
        {
            s.source = gameObject.AddComponent<AudioSource>();

            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

            // Set the output of the Audio Sources
            s.source.outputAudioMixerGroup = musicAudioMixerGroup;
        }
    }

    private void Start()
    {
        mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
        mainAudioMixer.SetFloat("FxVolume", Mathf.Log10(fxVolume) * 20);
    }
    // Update is called once per frame
    void Update()
    {
        // To test the musicVolume variable
        //mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }


    public void PlayMusic(string name)
    {
        Sound s = Array.Find(music, s => s.name == name);

        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogWarning("Music " + name + " not found");
        }

    }

    public void PlayFx(string name)
    {
        Sound s = Array.Find(fx, s => s.name == name);

        if (s != null)
        {
            s.source.Play();
        }
        else
        {
            Debug.LogWarning("Fx " + name + " not found");
        }

    }

    public void StopMusic(string name)
    {

        Sound s = Array.Find(music, s => s.name == name);

        if (s != null)
        {
            s.source.Stop();
        }
        else
        {
            Debug.LogWarning("Music " + name + " not found");
        }
    }
}