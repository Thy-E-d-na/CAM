using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class EndScript : MonoBehaviour
{
    [Header("Ending")]
    public GameObject endingPnl;
    public Image endImg;
    // public Sprite[] BSprites;
    // public Sprite[] GSprites;
    public Sprite[] sprites;

    public Button next;
    int curpage;
    int chose;

    [Header("Reset Choose")]
    public GameObject rsPnl;
    
    public Button yes;
    public Button no;
    void Start()
    {
        chose = PlayerPrefs.GetInt("ends");
        endImg.sprite = sprites[curpage];
        // OnNew();
    }
    public void OnNext()
    {
        SoundEffectManager.Play("btn");
        curpage++;
        endImg.sprite = sprites[curpage];
        if (curpage == sprites.Length - 1)
        {
            next.gameObject.SetActive(false);
            rsPnl.SetActive(true);

        }
    }
    // void OnNew()
    // {
    //     chose = PlayerPrefs.GetInt("ends");
    //     if (chose == 1 && BSprites.Length > 0) endImg.sprite = BSprites[curpage];
    //     else if (chose == 2 && GSprites.Length > 0) endImg.sprite = GSprites[curpage];
    //     else endingPnl.SetActive(false);
    //     lv = FindAnyObjectByType<PlayerScript>()._currentLv;
    // }
    // void Update()
    // {
    //     OnNew();
    // }
    // public void OnNext()
    // {
    //     if (chose == 1) pages(BSprites);
    //     else if (chose == 2) pages(GSprites);
    // }
    // public void pages(Sprite[] name)
    // {
    //     SoundEffectManager.Play("btn");
    //     curpage++;
    //     endImg.sprite = name[curpage];
    //     if (curpage == name.Length - 1)
    //     {
    //         next.gameObject.SetActive(false);

    //         if (lv == 8)
    //         {
    //             rsPnl.SetActive(true);
    //         }
    //         else
    //         {
    //             ok.gameObject.SetActive(true);

    //         }
    //     }
    // }
    // public void OkBtn()
    // {
    //     SoundEffectManager.Play("btn");
    //     PlayerPrefs.DeleteKey("ends");
    //     curpage = 0;
    //     MusicManager.playMusic(false);
    //     endingPnl.SetActive(false);
    // }
    public void SetEnding(bool rsLv)
    {
        SoundEffectManager.Play("btn2");
        if (rsLv == true)
        {
            RsGame(chose);
        }
        else
        {
            if (chose == 1)
                PlayerPrefs.SetInt("ending1", 1);
            else
                PlayerPrefs.SetInt("ending2", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("MainScene");
            //endingPnl.SetActive(false);
        }
        //PlayerPrefs.Save();
        MusicManager.stopMusic();

    }

    public void OnClick_Y0() => SetEnding(true);
    public void OnClick_N0() => SetEnding(false);
    void RsGame(int chose)
    {
        PlayerPrefs.DeleteAll();
        if (chose == 1)
            PlayerPrefs.SetInt("ending1", 1);
        else
            PlayerPrefs.SetInt("ending2", 1);
        PlayerPrefs.Save();
    
        SceneManager.LoadScene("MainScene");
    }
}
