using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public GameObject pnl;
    public Image image;
    public Sprite[] intros;
    int current;
    public Button nextBtn;
    public Button OK;
    public AudioSource audio;
    public AudioClip clip;

    void play()
    {
        audio = GetComponent<AudioSource>();
        if (audio != null)
        {
            audio.PlayOneShot(clip);
        }
    }

    public void OnOk()
    {
        play();
        SceneManager.LoadScene("MainScene");

    }
    public void NextPage()
    {
        play();
        current++;
        if (current == intros.Length - 1)
            nextBtn.gameObject.SetActive(false);
        image.sprite = intros[current];

        if (current == intros.Length - 1)
        {
            OK.gameObject.SetActive(true);
        }
    }
}
