using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private static PlayerScript instance;
    public static PlayerScript Instance => instance;

    [Header("Level Up")]
    public int _currentXP, _currentLv;
    public int _maxXP => (int)(40 + 30 * Math.Pow(_currentLv, 2));

    //GUI
    [SerializeField] Slider xpBar;
    [SerializeField] TMP_Text _xpText;
    [SerializeField] TMP_Text lvText;
    

    public GameObject Endpnl;
    [SerializeField] AudioClip storytell;

    [Header("Evolution")]

    public GameObject pnl;
    public Image formImage;
    public Sprite[] popUp;
    [SerializeField] Animator animator;
    [SerializeField] AnimatorOverrideController[] animByLv;



    public void SetUp(Slider bar, TMP_Text xpText, TMP_Text levelText, GameObject endpnl, AnimatorOverrideController[] anims)
    {
        xpBar = bar;
        _xpText = xpText;
        lvText = levelText;
        Endpnl = endpnl;
        animByLv = anims;
        updateXpUI();
        if (_currentLv >= 2 && _currentLv - 2 < animByLv.Length)
        {
            animator.runtimeAnimatorController = animByLv[_currentLv - 2];
        }
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else
        {
            Destroy(gameObject);
        }
        updateXpUI();
    }
    void Start()
    {
        //_currentLv = PlayerPrefs.GetInt("playerLv");
        animator.runtimeAnimatorController = animByLv[_currentLv - 2];
        updateXpUI();
    }
    void OnEnable()
    {
        XPManager.instance.ONXPChange += HandleXPChange;
    }
    void OnDisable()
    {
        XPManager.instance.ONXPChange -= HandleXPChange;
    }
    private void HandleXPChange(int newXP)
    {
        if (_currentLv >= 8) return;
        _currentXP += newXP;

        if (_currentXP >= _maxXP)
        {
            _currentXP -= _maxXP;
            LvUp();
        }
        updateXpUI();
    }
    void updateXpUI()
    {
        xpBar.maxValue = _maxXP;
        xpBar.value = _currentXP;
        _xpText.text = _currentXP + "/" + _maxXP;
        lvText.text = "Lv." + _currentLv;
        if (_currentLv >= 8)
        {
            _currentXP = 0;
            _currentLv = 1;
        }
    }
    private void LvUp()
    {
        _currentLv++;
        PlayerPrefs.SetInt("playerLv", _currentLv);
        PlayerPrefs.Save();
        if (_currentLv < 8)
        {
            ShowPopUp();
            MusicManager.pauseMusic();
            SoundEffectManager.Play("lvup");
            animator.runtimeAnimatorController = animByLv[_currentLv - 2];
        }
        else if (_currentLv == 8)
        {
            MusicManager.pauseMusic();
            Endpnl.SetActive(true);          
            MusicManager.pauseMusic();
            MusicManager.playMusic(true, storytell);
        }

    }

    void ShowPopUp()
    {
        Time.timeScale = 0;
        int lv = _currentLv - 2;
        if (lv >= 0 && lv < popUp.Length)
        {
            pnl.SetActive(true);
            formImage.sprite = popUp[lv];
        }
    }
    public void OkClicked()
    {
        SoundEffectManager.Play("btn");
        Time.timeScale = 1;
        pnl.SetActive(false);
        MusicManager.playMusic(false);
    }
    public void ChooseEndingA()
    {
        SoundEffectManager.Play("btn2");
        SceneManager.LoadScene("EndingA");
    }
    public void ChooseEndingB()
    {
        SoundEffectManager.Play("btn2");
        SceneManager.LoadScene("EndingB");
    }

}
