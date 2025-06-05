using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SoundEffectManager : MonoBehaviour
{
#region 
   public static SoundEffectManager instance;
   private static AudioSource audioSource;
   private static SoundEffectLibrary soundEffectLibrary;
   [SerializeField] private Slider sfxSlider;  
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            audioSource = GetComponent<AudioSource>();
            soundEffectLibrary = GetComponent<SoundEffectLibrary>();
            DontDestroyOnLoad(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
    public static void Play(string soundName)
    {
        AudioClip audioClip = soundEffectLibrary.GetRandomClip(soundName);
        if(audioClip != null)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }

    public static void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void OnValueChanged()
    {
        SetVolume(sfxSlider.value);
    }
    public void PlayDelayed(string name, float delay)
    {
        StartCoroutine(playDs(name,delay));
    }
    private IEnumerator playDs(string name, float delay)
    {
        yield return new WaitForSeconds(delay);
        Play(name);
    }
    void Start()
    {
        if(sfxSlider != null)
        {
            float savedVol = PlayerPrefs.GetFloat("SFXVolume",1f);
            sfxSlider.value = savedVol;
            SetVolume(savedVol);

            sfxSlider.onValueChanged.AddListener(delegate {OnValueChanged();});
        }
    }
    public static void Pausesound()
    {

    }
    public void SetSFXVol(float volume)
    {
        audioSource.volume = volume;
        PlayerPrefs.SetFloat("SFXVolume",volume);
    }
    #endregion
}
