using UnityEngine.UI;
using UnityEngine;

public class TutScript : MonoBehaviour
{
    public GameObject tutPnl;
    public Image image;
    public Sprite[] pages;
    public Button nextBtn;
    public Button closeBtn;
    private int curPage;
    
    public void OpenTut()
    {
        curPage = 0;
        tutPnl.SetActive(!tutPnl.activeSelf);
        nextBtn.gameObject.SetActive(true);
        SoundEffectManager.Play("btn");
        image.sprite = pages[curPage];
    }
    public void NextPage()
    {
        SoundEffectManager.Play("btn");
        curPage++;
        if (curPage == pages.Length - 1)
        nextBtn.gameObject.SetActive(false);
        image.sprite = pages[curPage];
    }


    public void closeTut()
    {
        tutPnl.SetActive(false);
        curPage = 0;
    }
}
