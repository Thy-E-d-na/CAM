using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class LoadingScript : MonoBehaviour
{
    public Image loadingImg;
    public int spawnAmount;

    void Start()
    {
        loadingImg.gameObject.SetActive(true);
        Invoke("gameLoading", 5f);
    }
    void gameLoading()
    {
        int check = PlayerPrefs.GetInt("Intro");
        if (check == 0)
        {
            PlayerPrefs.SetInt("Intro", 1);
            PlayerPrefs.Save();
            SceneManager.LoadScene("Intro");
        }
        else
        {
            targetLoad();
            SceneManager.LoadScene("MainScene");
        }
    }
    
    void targetLoad()
    {
        float lastTime = PlayerPrefs.GetFloat("LastTime", Time.time);
        float t = Time.time - lastTime;
        spawnAmount = (int)Math.Round((double)t / 5);
        PlayerPrefs.SetInt("loadspawn", spawnAmount);
        PlayerPrefs.Save();
    }
    
}
