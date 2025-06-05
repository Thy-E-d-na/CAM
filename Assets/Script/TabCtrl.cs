using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TabCtrl : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
    public Button BE;
    public Button GE;
    void Start()
    {
        openTab(0);
    }
    public void openTab(int tabNo)
    {
        for (int i = 0; i < pages.Length; i++)
        {
            SoundEffectManager.Play("btn");
            pages[i].SetActive(false);
            tabImages[i].color = Color.grey;
        }
        pages[tabNo].SetActive(true);
        tabImages[tabNo].color = Color.white;

    }
     public void ChooseEndingA()
    {
        SoundEffectManager.Play("btn");
        SceneManager.LoadScene("EndingA");
    }
    public void ChooseEndingB()
    {
        SoundEffectManager.Play("btn");
        SceneManager.LoadScene("EndingB");
    }
}
