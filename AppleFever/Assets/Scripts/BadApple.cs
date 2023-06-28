using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadApple : MonoBehaviour
{
    private BasketLogic _basketLogic;

    private Rigidbody2D _rb2D;
    public float Gravity = 2f;

    private int _harmApples;
    [SerializeField] private GameObject _warning;


    void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();

        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.gravityScale = 0;

        StartCoroutine(StartDrop());
    }

    void Update()
    {
        LostApple();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Basket"))
        {
            _basketLogic.Mood -= 25;
            _harmApples = Random.Range(1, 5);

            if (_harmApples <= _basketLogic.Apple1)
                _basketLogic.Apple1 -= _harmApples;
            else if (_basketLogic.Apple1 == 0)
                Destroy();
            else _basketLogic.Apple1--;
            Destroy();
        }
    }

    private void LostApple()
    {
        if (transform.position.y <= -7)
            Destroy();
    }

    private void Destroy()
    {
        Object.Destroy(gameObject);
    }

    IEnumerator StartDrop()
    {
        _warning.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        _rb2D.gravityScale = 2f;
    }
}
