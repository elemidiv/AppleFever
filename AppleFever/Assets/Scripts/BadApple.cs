using System.Collections;
using UnityEngine;

public class BadApple : MonoBehaviour
{
    private BasketLogic _basketLogic;
    private AudioSource _sound;

    private Rigidbody2D _rb2D;
    [SerializeField] private GameObject _warning;


    void Start()
    {
        _basketLogic = FindObjectOfType<BasketLogic>();
        _sound = GameObject.Find("Sound_BadApple").GetComponent<AudioSource>();

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
            _sound.Play();
            _basketLogic.Mood -= 15;
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
