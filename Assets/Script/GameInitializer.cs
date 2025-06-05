using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameInitializer : MonoBehaviour
{
    public Slider xpBar;
    public TMP_Text xpText;
    public TMP_Text lvText;
    public GameObject endPanel;
    public AnimatorOverrideController[] anims;
    void Start()
    {
        PlayerScript.Instance.SetUp(xpBar, xpText, lvText, endPanel,anims);
    }
}
