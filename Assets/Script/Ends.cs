using UnityEngine;
using UnityEngine.UI;
public class Ends : MonoBehaviour
{

    [Header("Ending")]
    public GameObject endingPnl;
    public Image endImg;
    public Sprite[] BSprites;
    public Sprite[] GSprites;
    public Button ok;
    public Button next;
    int curpage;
    int chose;

    void Start()
    {
        chose = PlayerPrefs.GetInt("ends");
        if (chose == 1 && BSprites.Length > 0) endImg.sprite = BSprites[curpage];
        else if (chose == 2 && GSprites.Length > 0) endImg.sprite = GSprites[curpage];
        else endingPnl.SetActive(false);
    }
    void OnNew()
    {
        chose = PlayerPrefs.GetInt("ends");
        if (chose == 1 && BSprites.Length > 0) endImg.sprite = BSprites[curpage];
        else if (chose == 2 && GSprites.Length > 0) endImg.sprite = GSprites[curpage];
        else endingPnl.SetActive(false);
    }
    void Update()
    {
        OnNew();
    }
    public void OnNext()
    {
        if (chose == 1) pages(BSprites);
        else if (chose == 2) pages(GSprites);
    }
    public void pages(Sprite[] name)
    {
        SoundEffectManager.Play("btn");
        curpage++;
        endImg.sprite = name[curpage];
        if (curpage == name.Length - 1)
        {
            next.gameObject.SetActive(false);          
            ok.gameObject.SetActive(true);
        }
    }
    public void OkBtn()
    {
        SoundEffectManager.Play("btn");
        PlayerPrefs.DeleteKey("ends");
        curpage = 0;
        MusicManager.playMusic(false);
        endingPnl.SetActive(false);
    }

    
}


