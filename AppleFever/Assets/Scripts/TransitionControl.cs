using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionControl : MonoBehaviour
{
    private BasketLogic _basketLogic;
    [SerializeField] private AudioSource _death;
    [SerializeField] private AudioSource _track;

    private void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
    }

    public IEnumerator GameOver()
    {
        _track.Stop();
        _death.Play();
        Time.timeScale = 0.01f;

        yield return new WaitForSeconds(0.03f);

        PlayerPrefs.SetInt("Coin", _basketLogic.Money);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
