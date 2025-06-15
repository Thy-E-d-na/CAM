using UnityEngine;
using UnityEngine.UI;

public class TabCtrl : MonoBehaviour
{
    public Image[] tabImages;
    public GameObject[] pages;
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
    
}
