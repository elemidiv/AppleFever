using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    [SerializeField] private Scrollbar _scroll1;
    [SerializeField] private Scrollbar _scroll2;
    [SerializeField] private GameObject UpgradeMenu;


    void Start()
    {
        _scroll1.value = 0;
        _scroll2.value = 0;
        UpgradeMenu.SetActive(false);
    }

    void Update()
    {
        
    }
}
