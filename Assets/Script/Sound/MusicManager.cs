using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    public AudioClip bgm;
    public AudioClip strorytell;
    [SerializeField] private Slider musicSlider;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(bgm != null)
        {
            playMusic(false,bgm);
        }
        if(musicSlider != null)
        {
            float savedVol = PlayerPrefs.GetFloat("SFXVolume",0.2f);
            musicSlider.value = savedVol;
            SetVolume(savedVol);
        }
        musicSlider.onValueChanged.AddListener(delegate {SetVolume(musicSlider.value);});
    }
    public static void SetVolume(float volume)
    {
        instance.audioSource.volume = volume;
    }
    public static void playMusic(bool rsSong, AudioClip audioClip = null)
    {
        if (audioClip != null)
        {
            instance.audioSource.clip = audioClip;
            instance.audioSource.Play();
        }
        else if (instance.audioSource.clip != null)
        {
            if (rsSong)
            {
                instance.audioSource.Stop();
            }
            instance.audioSource.Play();
        }

    }
    public static void stopMusic()
    {
        instance.audioSource.Stop();
    }
    public static void pauseMusic()
    {
        instance.audioSource.Pause();
    }
    
}
