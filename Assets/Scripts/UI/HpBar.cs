using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] Image hpBar;
    [SerializeField] Castle castle;


    void Update()
    {
        hpBar.fillAmount = castle.currentHp / castle.maxHp;
    }
}
