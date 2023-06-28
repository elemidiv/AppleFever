using UnityEngine;

public class AppleStats : MonoBehaviour
{
    private BasketLogic _basketLogic;

    //Stats
    private Rigidbody2D _rb2D;
    [SerializeField] private float _gravity = 1f;
    [SerializeField] private int _type; 
    

    void Start()
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

        if (_type == 2)
            _basketLogic.Apple2++;
        else if (_type == 1)
            _basketLogic.Apple1++;

        Destroy();
    }

    private void LostApple()
    {
        if (transform.position.y <= -7)
        {
            _basketLogic.Mood -= Random.Range(5, 11);
            Destroy();
        }
    }

    private void Destroy()
    {
            Object.Destroy(gameObject);
    }
}
