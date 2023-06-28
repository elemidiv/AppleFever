using UnityEngine;
using TMPro;

public class BasketLogic : MonoBehaviour
{
    //Stats
    [HideInInspector] public float _speed;
    public float Mood = 100f;
    public int Apple1;
    public int Apple2;

    [SerializeField] private TMP_Text _moodBox;
    private bool _isDead;

    private Vector3 _newPosition;

    [SerializeField] private TransitionControl TransitionControl;


    void Start()
    {
        _speed = 6f;
        _moodBox = GameObject.Find("MoodBox").GetComponent<TMP_Text>();

        TransitionControl = FindObjectOfType<TransitionControl>();
    }

    void Update()
    {
        Movement();
        Death();
    }

    private void Movement()
    {
        if (_isDead)
            return;
        _moodBox.text = Mood + "";

        if (transform.position.x > -5 && Input.GetKey(KeyCode.LeftArrow))
        {
            _newPosition.x += -_speed * Time.deltaTime;
            _newPosition.y = transform.position.y;
            _newPosition.z = transform.position.z;

            transform.position = _newPosition;
        }
        
        if (transform.position.x < 7 && Input.GetKey(KeyCode.RightArrow))
        {
            _newPosition.x += _speed * Time.deltaTime;
            _newPosition.y = transform.position.y;
            _newPosition.z = transform.position.z;

            transform.position = _newPosition;
        }
    }

    private void Death()
    {
        if (Mood > 0)
            return;

        _moodBox.text = "0";
        _isDead = true;

        TransitionControl.GameOver();
    }
}
