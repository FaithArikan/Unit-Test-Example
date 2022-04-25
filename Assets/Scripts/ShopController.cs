using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopController : MonoBehaviour
{
    [SerializeField] private int goldAmnt;
    [SerializeField] private TextMeshProUGUI mainText;

    public int goldAmount
    {
        get => goldAmnt;
        set => goldAmnt = value;
    }    
    public TextMeshProUGUI mainTxt
    {
        get => mainText;
        set => mainText = value;
    }
}

