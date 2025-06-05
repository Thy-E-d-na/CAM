using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroScript : MonoBehaviour
{
    public GameObject pnl;
    public Image image;
    public Sprite[] intros;
    int current;
    public AudioSource sfx;
    public AudioClip btnclick;
    public Button nextBtn;
    public Button OK;
    
   
    public void play(string name)
    {
        if (name != null && btnclick != null)
        {
            sfx.PlayOneShot(btnclick);
        }

    }
    void Update()
    {
        if (current == intros.Length - 1)
        {
            OK.gameObject.SetActive(true);
        }

    }
    public void OnOk()
    {
        play("btn");
        SceneManager.LoadScene("MainScene");

    }
    public void NextPage()
    {
        play("btn");
        current++;
        if (current == intros.Length - 1)
            nextBtn.gameObject.SetActive(false);
        image.sprite = intros[current];
    }
}
