using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    [SerializeField] private Button button1, button2, button3;
    [SerializeField] private TextMeshProUGUI button1Txt, button2Txt, button3Txt;
    
    [SerializeField] private ShopController shop;

    void Awake()
    {
        button1Txt = button1.GetComponentInChildren<TextMeshProUGUI>();
        button2Txt = button2.GetComponentInChildren<TextMeshProUGUI>();
        button3Txt = button3.GetComponentInChildren<TextMeshProUGUI>();

        button1.onClick.AddListener(Button1Click);
        button2.onClick.AddListener(Button2Click);
        button3.onClick.AddListener(Button3Click);
        shop.mainTxt.text = shop.goldAmount.ToString();
    }
    private void Button1Click()
    {
        button1Txt.text = "Gold Amount increased by 5";
        shop.goldAmount += 5;
        shop.mainTxt.text = shop.goldAmount.ToString();
    }
    private void Button2Click()
    {
        button2Txt.text = "Gold Amount increased by 10";
        shop.goldAmount += 10;
        shop.mainTxt.text = shop.goldAmount.ToString();
    }
    private void Button3Click()
    {
        button3Txt.text = "Gold Amount increased by 20";
        shop.goldAmount += 20;
        shop.mainTxt.text = shop.goldAmount.ToString();
    }
}
