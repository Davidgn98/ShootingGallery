using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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

    public Slider musicSlider;
    public Slider fxSlider;

    private bool firstTime;

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
        setVolume();
        //mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
        //mainAudioMixer.SetFloat("FxVolume", Mathf.Log10(fxVolume) * 20);
    }
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetSceneByName("MainMenu").isLoaded)
        {
            if(GameObject.FindGameObjectWithTag("SliderMusic"))
            {
                musicSlider = (Slider)GameObject.FindObjectsOfType(typeof(Slider))[0];
                fxSlider = (Slider)GameObject.FindObjectsOfType(typeof(Slider))[1];
                mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(musicSlider.value) * 20);
                PlayerPrefs.SetFloat("music", GetMusicVolume());
                mainAudioMixer.SetFloat("FxVolume", Mathf.Log10(fxSlider.value) * 20);
                PlayerPrefs.SetFloat("fx", GetFxVolume());
                PlayerPrefs.Save();
                

            }
        }
        // To test the musicVolume variable
        //mainAudioMixer.SetFloat("MusicVolume", Mathf.Log10(musicVolume) * 20);
    }

    private void setVolume()
    {
        mainAudioMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("music"));
        mainAudioMixer.SetFloat("FxVolume", PlayerPrefs.GetFloat("fx"));
        fxSlider.value = Mathf.Log10(PlayerPrefs.GetFloat("music"));
        musicSlider.value = Mathf.Log10(PlayerPrefs.GetFloat("fx"));
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
    
    public float GetMusicVolume()
    {
        float value;
        bool result = mainAudioMixer.GetFloat("MusicVolume", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }

    public float GetFxVolume()
    {
        float value;
        bool result = mainAudioMixer.GetFloat("FxVolume", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }
}