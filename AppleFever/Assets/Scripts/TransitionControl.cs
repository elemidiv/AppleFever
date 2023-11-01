using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionControl : MonoBehaviour
{
    private BasketLogic _basketLogic;

    private void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
    }

    public void GameOver()
    {
        PlayerPrefs.SetInt("Coin", _basketLogic.Money);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
