using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _appleType;
    private bool _ableToSpawn = true;
    private GameObject _newObj;
    private int _nextApple;

    private Vector3 _reposition;
    private float time;


    void Update()
    {
        if (_ableToSpawn)
        {
            _ableToSpawn = false;
            StartCoroutine(Spawn());
        }
    }

    private void SpawnBadApple()
    {
        if (Random.Range(0, 35) != 1)
            return;

        _reposition.x = Random.Range(-3.5f, 6.5f);
        _reposition.y = 8f;
        _reposition.z = 0f;

        _newObj = Instantiate(_appleType[0]);
        _newObj.transform.position = _reposition;
    }

    private IEnumerator Spawn()
    {
        time = Random.Range(0.5f, 2.3f);
        SpawnBadApple();
        yield return new WaitForSeconds(time);

        _reposition.x = Random.Range(-4f, 7f);
        _reposition.y = 8f;
        _reposition.z = 0f;
        _nextApple = Random.Range(0, 101);


        if (_nextApple > 30)
            _newObj = Instantiate(_appleType[1]);
        else if (_nextApple < 30)
            _newObj = Instantiate(_appleType[2]);


        _newObj.transform.position = _reposition;

        _ableToSpawn = true;
    }
}
