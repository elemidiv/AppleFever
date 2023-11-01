using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkinSystem : MonoBehaviour
{
    //Animation
    private Animator _animator;
    [SerializeField] private RuntimeAnimatorController[] _animations;

    //UI
    [SerializeField] private TMP_Text[] _tCost;
    private string[] _skins;
    private string[] _active;
    private string _temp1;

    private BasketLogic _basketLogic;

    void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
        _animator = GameObject.Find("Sprite").GetComponent<Animator>();
        _active = PlayerPrefs.GetString("ActiveSkin", "1,0,0,0,").Split(',');
        _skins = PlayerPrefs.GetString("OwnedSkins", "1,0,0,0,").Split(',');

        ActualSkin();
    }

    void Update()
    {
        DisplayCost();
    }

    private void ActualSkin()
    {
        for (int i = 0; i < _active.Length; i++)
        {
            if (_active[i] == "1")
            {
                Select(i);
            }
        }
    }

    private void DisplayCost()
    {
        for (int i = 0; i < _skins.Length - 1; i++)
        {
            if (_skins[i] == "1")
            {
                _tCost[i].text = "Elegir";
            }
            else
                _tCost[i].text = "$1000";
        }
    }

    public void Select(int option)
    {
        for (int i = 0; i < _active.Length; i++)
        {
            _active[i] = "0";
        }

        switch (option)
        {
            case 0:
                if (_skins[option] == "1")
                {
                    _animator.runtimeAnimatorController = _animations[option];
                    _active[option] = "1";
                }
                else if (_basketLogic.Money >= 1000)
                {
                    _basketLogic.Money -= 1000;

                }
                break;
            case 1:
                if (_skins[option] == "1")
                {
                    _animator.runtimeAnimatorController = _animations[option];
                    _active[option] = "1";
                }
                else if (_basketLogic.Money >= 1000)
                {
                    _basketLogic.Money -= 1000;
                    _skins[option] = "1";
                }
                break;
            case 2:
                if (_skins[option] == "1")
                {
                    _animator.runtimeAnimatorController = _animations[option];
                    _active[option] = "1";
                }
                else if (_basketLogic.Money >= 1000)
                {
                    _basketLogic.Money -= 1000;
                    _skins[option] = "1";
                }
                break;
            case 3:
                if (_skins[option] == "1")
                {
                    _animator.runtimeAnimatorController = _animations[option];
                    _active[option] = "1";
                }
                else if (_basketLogic.Money >= 1000)
                {
                    _basketLogic.Money -= 1000;
                    _skins[option] = "1";
                }
                break;
            default:
                break;
        }

        _temp1 = "";
        for (int i = 0; i < _skins.Length - 1; i++)
        {
            _temp1 += _skins[i] + ",";
        }
        PlayerPrefs.SetString("OwnedSkins", _temp1);
        _temp1 = "";
        for (int i = 0; i < _active.Length - 1; i++)
        {
            _temp1 += _active[i] + ",";
        }
        PlayerPrefs.SetString("ActiveSkin", _temp1);
    }
}
