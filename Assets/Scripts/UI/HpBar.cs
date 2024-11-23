using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Image hpBar;

    public float maxHp = 100f;
    public static float currentHp;

    void Start()
    {
        currentHp = maxHp;
    }

    void Update()
    {
        hpBar.fillAmount = currentHp / maxHp;
    }
}
