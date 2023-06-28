using UnityEngine;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    private int _apple;
    private TMP_Text _coinsUI;
    private int _coins;

    //Upgrade button values
    [SerializeField] private TMP_Text[] _cost;
    [SerializeField] private TMP_Text[] _currentLv;
    [SerializeField] private TMP_Text[] _nextLv;


    void Start()
    {
        _coins = PlayerPrefs.GetInt("Coin", 0);
        _coinsUI = GameObject.Find("Txt_Coins").GetComponent<TMP_Text>();
    }

    void Update()
    {
        _coinsUI.text = "$" + _coins;
    }

    private void SetValues()
    {

    }

    public void SellApple(int value)
    {
        _apple = PlayerPrefs.GetInt("Apple" + value, 0);
        _coins += value * _apple;

        _apple = 0;
        PlayerPrefs.SetInt("Apple" + value, 0);
        PlayerPrefs.SetInt("Coin", _coins);
    }

    public void BuyUpgrade(int value)
    {

    }
}
