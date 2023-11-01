using System.Collections;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    [SerializeField] private GameObject[] _appleType;
    private bool _ableToSpawn = true;
    private GameObject _newObj;
    private int _nextApple;

    private Vector2 _reposition;
    private float _time;

    //About difficult
    private float _min = 0.5f;
    private float _max = 2.3f;
    private int _badAppleMax = 35;
    private int _count;
    private float _gravity = 0.1f;


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
        if (Random.Range(0, _badAppleMax) != 1)
            return;

        _reposition.x = Random.Range(-3.5f, 6.5f);
        _reposition.y = 8f;

        _newObj = Instantiate(_appleType[0]);
        _newObj.transform.position = _reposition;
    }

    private IEnumerator Spawn()
    {
        _time = Random.Range(_min, _max);
        SpawnBadApple();
        yield return new WaitForSeconds(_time);

        _reposition.x = Random.Range(-4f, 7f);
        _reposition.y = 8f;
        _nextApple = Random.Range(0, 101);

        if (_nextApple > 30)
            _newObj = Instantiate(_appleType[1]);
        else if (_nextApple < 30)
            _newObj = Instantiate(_appleType[2]);

        _newObj.transform.position = _reposition;
        _newObj.GetComponent<Rigidbody2D>().gravityScale += _gravity;


        _count++;
        if(_count >= 7)
        {
            _count = 0;
            _badAppleMax--;
            _gravity += 0.04f;
            if (_min > 0.1) _min -= 0.04f;
            if (_max > 1) _max -= 0.06f;
        }

        _ableToSpawn = true;
    }
}
