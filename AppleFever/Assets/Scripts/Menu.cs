using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private BasketLogic _basketLogic;
    private SpawnObjects _spawnObjects;
    [SerializeField] private Scrollbar _scroll1;
    [SerializeField] private GameObject _UI;
    [SerializeField] private GameObject _upgrades;
    [SerializeField] private GameObject _skins;

    void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
        _spawnObjects = GetComponent<SpawnObjects>();

        _scroll1.value = 0;
        _UI.SetActive(false);
        _upgrades.SetActive(false);
        _skins.SetActive(false);
    }

    public void Game()
    {
        _basketLogic.enabled = true;
        _spawnObjects.enabled = true;
        _basketLogic.GetStatistics();
        _UI.SetActive(true);
    }
}
