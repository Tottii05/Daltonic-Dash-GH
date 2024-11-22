using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public static AudioManager instance;
    public AudioMixer audioMixer;
    [Header("--- Music ---")]
    public AudioSource BackGround;
    [Header("--- SBX ---")]
    public AudioSource SoundJump;
    public AudioSource SoundExplote;
    public AudioSource SoundButton;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            PlaySoundBackGround();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySoundBackGround() // Musica de Fondo
    {
        BackGround.Play();
    }
    public void PlaySoundJump() // Sonido de Salto
    {
        SoundJump.Play();
    }

    public void PlaySoundExplote() // Sonido de Explosión
    {
        SoundExplote.Play();
        BackGround.Stop();
    }

    public void PlaySoundButton() // Sonido de Botón
    {
        SoundButton.Play();
    }

    public void SetVolumeSound(float volume)
    {
        if (volume == 0)
        {
            audioMixer.SetFloat("Sound", -80);
        }
        else
        {
            audioMixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
        }


    }

    public void SetVolumeMusic(float volume)
    {
        if (volume == 0)
        {
            audioMixer.SetFloat("Sound", -80);
        }
        else
        {
            audioMixer.SetFloat("Sound", Mathf.Log10(volume) * 20);
        }
    }


}