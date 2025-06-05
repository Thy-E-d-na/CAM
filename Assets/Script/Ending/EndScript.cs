using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScript : MonoBehaviour
{
    [Header("Ending")]
    public GameObject endPnl;
    public Image image;
    public Sprite[] sprites;
    public Button next;
    int current;


    [Header("Reset Choose")]
    public GameObject rsPnl;
    public Button ychoose;
    public Button nchoose;
    void Start()
    {
        image.sprite = sprites[current];
    }
    public void NextPage()
    {
        SoundEffectManager.Play("btn");
        current++;
        if (current == sprites.Length - 1)
        {
            next.gameObject.SetActive(false);
            rsPnl.SetActive(true);
        }
        image.sprite = sprites[current];
    }
    public void SetEnding(int id, bool rsLv)
    {
        SoundEffectManager.Play("btn2");
        if (rsLv)
        {
            PlayerPrefs.SetInt("playerLv", 1);
            PlayerPrefs.SetInt("Intro", 0);
        }
        PlayerPrefs.SetInt("ends",id);
        PlayerPrefs.Save();
        MusicManager.stopMusic();
        SceneManager.LoadScene("MainScene");
    }
    public void OnClick_Y0() => SetEnding(0,true);
    public void OnClick_N0() => SetEnding(0,false);
    public void OnClick_Y1() => SetEnding(1,true);
    public void OnClick_N1() => SetEnding(1,false);
}
