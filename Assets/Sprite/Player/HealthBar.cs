using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text HpText;
    public static int HpCurrent;
    public static int HpMax=100;
    private Image HpBar;
    // Start is called before the first frame update
    void Start()
    {
        HpBar = GetComponent<Image>();
        HpCurrent = HpMax;
    }

    // Update is called once per frame
    void Update()
    {
        HpBar.fillAmount = (float)HpCurrent / (float)HpMax;
        HpText.text = HpCurrent.ToString() + "/" + HpMax.ToString();
    }
}
