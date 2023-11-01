using UnityEngine;
using TMPro;

public class ShopSystem : MonoBehaviour
{
    private BasketLogic _basketLogic;
    private UpgradesSystem _upgradesSystem;
    private TMP_Text _coinsUI;
    private int _coins;

    //Upgrade button values
    [SerializeField] private TMP_Text[] _tCost;
    [SerializeField] private TMP_Text[] _tCurrentLv;

    //Money cost
    private int _cost1;
    private int _cost2;
    private int _cost3;
    private int _cost4;

    //Current level upgrade
    private int _currentLv1;
    private int _currentLv2;
    private int _currentLv3;
    private int _currentLv4;

    void Awake()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
        _upgradesSystem = FindObjectOfType<UpgradesSystem>();

        _coins = PlayerPrefs.GetInt("Coin", 0);
        _coinsUI = GameObject.Find("Txt_Coins").GetComponent<TMP_Text>();
    }

    void Start()
    {
        GetLevels();
    }

    void Update()
    {
        _coins = _basketLogic.Money;
        _coinsUI.text = "$" + _coins;

        DisplayValues();
        SetCost();
    }

    private void GetLevels()
    {
        _currentLv1 = _upgradesSystem.CurrentL1;
        _currentLv2 = _upgradesSystem.CurrentL2;
        _currentLv3 = _upgradesSystem.CurrentL3;
        _currentLv4 = _upgradesSystem.CurrentL4;
    }

    private void DisplayValues()
    {
        //Display actual level
        _tCurrentLv[0].text = "" + _currentLv1;
        _tCurrentLv[1].text = "" + _currentLv2;
        _tCurrentLv[2].text = "" + _currentLv3;
        _tCurrentLv[3].text = "" + _currentLv4;

        //Display needed coins
        _tCost[0].text = "$" + _cost1;
        _tCost[1].text = "$" + _cost2;
        _tCost[2].text = "$" + _cost3;
        _tCost[3].text = "$" + _cost4;
    }

    private void SetCost()
    {
        _cost1 = 10 + 15 * _currentLv1;
        _cost2 = 10 + 40 * _currentLv2;
        _cost3 = 10 + 100 * _currentLv3;
        _cost4 = 100 + 200 * _currentLv4;
    }

    public void MasDinero()
    {
        _basketLogic.Money += 1000;
    }

    public void SinDinero()
    {
        _basketLogic.Money = 0;
    }
    public void Resetear()
    {
        _currentLv1 = 0;
        _currentLv2 = 0;
        _currentLv3 = 0;
        _currentLv4 = 0;
        _upgradesSystem.SetSpeed(_currentLv1, _basketLogic.Money);
        _upgradesSystem.SetMood(_currentLv2, _basketLogic.Money);
        _upgradesSystem.SetRegeneration(_currentLv3, _basketLogic.Money);
        _upgradesSystem.SetResistance(_currentLv4, _basketLogic.Money);
    }

    //Functions called by buttons to increase the level
    public void UpSpeed()
    {
        if (_basketLogic.Money < _cost1 || _currentLv1 >= 100)
            return;

        _basketLogic.Money -= _cost1;
        _currentLv1++;
        _upgradesSystem.SetSpeed(_currentLv1, _basketLogic.Money);
    }
    public void UpMood()
    {
        if (_basketLogic.Money < _cost2 || _currentLv2 >= 50)
            return;

        _basketLogic.Money -= _cost2;
        _currentLv2++;
        _upgradesSystem.SetMood(_currentLv2, _basketLogic.Money);
    }
    public void UpRegeneration()
    {
        if (_basketLogic.Money < _cost3 || _currentLv3 >= 20)
            return;

        _basketLogic.Money -= _cost3;
        _currentLv3++;
        _upgradesSystem.SetRegeneration(_currentLv3, _basketLogic.Money);
    }
    public void UpResistance()
    {
        if (_basketLogic.Money < _cost4 || _currentLv4 >= 10)
            return;

        _basketLogic.Money -= _cost4;
        _currentLv4++;
        _upgradesSystem.SetResistance(_currentLv4, _basketLogic.Money);
    }
}
