using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Menu : MonoBehaviour
{
    private BasketLogic _basketLogic;
    private SpawnObjects _spawnObjects;
    [SerializeField] private Scrollbar _scroll1;
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _upgrades;
    [SerializeField] private GameObject _skins;
    [SerializeField] private TMP_Text _bestTime;
    [SerializeField] private TMP_Text _newTime;

    void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
        _spawnObjects = GetComponent<SpawnObjects>();

        _scroll1.value = 0;
        _UI.SetActive(false);
        _upgrades.SetActive(false);
        _skins.SetActive(false);

        //Display timer
        _bestTime.text = "" + PlayerPrefs.GetInt("timer", 0);
    }

    private void Update()
    {
        _newTime.text = "" + ((int)_basketLogic._timer);
    }

    public void Game()
    {
        _basketLogic.enabled = true;
        _spawnObjects.enabled = true;
        _basketLogic.GetStatistics();
        _UI.SetActive(true);
    }
}
