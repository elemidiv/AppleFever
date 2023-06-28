using System.Collections;
using UnityEngine;

public class UnloadLogic : MonoBehaviour
{
    private BasketLogic _basketLogic;
    public int StoredT1;
    public int StoredT2;
    private bool _abledToUnload = true;
    private float UnloadSpeed = 0.25f;

    WaitForSeconds Cooldown;


    void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
        Cooldown = new WaitForSeconds(UnloadSpeed);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && _basketLogic.Apple1 >= 1 && _abledToUnload)
        {
            _abledToUnload = false;
            StartCoroutine(Unloading());
        }
    }

    IEnumerator Unloading()
    {
        if(_basketLogic.Apple2 > 0)
        {
            _basketLogic.Apple2--;
            StoredT2++;
        }
        else if(_basketLogic.Apple1 > 0)
        {
            _basketLogic.Apple1--;
            StoredT1++;
        }

        yield return Cooldown;
        _abledToUnload = true;
    }

    public void SaveApples()
    {
        PlayerPrefs.SetInt("Apple1", PlayerPrefs.GetInt("Apple1", 0) + StoredT1);
        PlayerPrefs.SetInt("Apple2", PlayerPrefs.GetInt("Apple2", 0) + StoredT2);
    }
}
