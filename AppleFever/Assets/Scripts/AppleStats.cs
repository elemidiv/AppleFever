using UnityEngine;

public class AppleStats : MonoBehaviour
{
    private BasketLogic _basketLogic;
    private Rigidbody2D _rb2D;

    //Stats
    [SerializeField] private float _gravity = 1f;
    [SerializeField] private int _moneyValue;
    [SerializeField] private int _moodLoss;
    

    void Awake()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();

        _rb2D = GetComponent<Rigidbody2D>();
        _rb2D.gravityScale = _gravity;
    }

    void Update()
    {
        LostApple();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Basket"))
            return;

        _basketLogic.Money+= _moneyValue;
        Destroy();
    }

    private void LostApple()
    {
        if (transform.position.y >= -7)
            return;

        if (_basketLogic.Resistance >= _moodLoss)
            _basketLogic.Mood -= 1;
        else
            _basketLogic.Mood -= _moodLoss - _basketLogic.Resistance;

        Destroy();
    }

    private void Destroy()
    {
            Object.Destroy(gameObject);
    }
}
