using UnityEngine;
using UnityEngine.UI;

public class BasketLogic : MonoBehaviour
{
    //Stats
    [HideInInspector] public int Money;
    [HideInInspector] public float Mood = 100;
    [HideInInspector] public int Resistance;
    private float _speed;
    private float _regeneration;
    private float _maxMood;

    //Hud
    private Image _moodSprite;
    [SerializeField] private Sprite _100;
    [SerializeField] private Sprite _080;
    [SerializeField] private Sprite _060;
    [SerializeField] private Sprite _040;
    [SerializeField] private Sprite _020;

    //Movement
    private Vector2 _newPosition;
    private SpriteRenderer _sprite;
    private Animator _animatorPlayer;
    
    //Extras
    private TransitionControl TransitionControl;
    private UpgradesSystem _upgradesSystem;
    private bool _isDead;

    private Camera _camera;


    [SerializeField] private Text Text;

    private void Awake()
    {
        _moodSprite = GameObject.Find("Mood (Life)").GetComponent<Image>();
        _upgradesSystem = FindObjectOfType<UpgradesSystem>();

        Money = PlayerPrefs.GetInt("Coin", 0);
    }

    void Start()
    {
        _camera = FindObjectOfType<Camera>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _animatorPlayer = GetComponentInChildren<Animator>();

        TransitionControl = FindObjectOfType<TransitionControl>();
    }

    void Update()
    {
        Text.text = "" + Mood;
        Movement();
        MoodStatus();
    }

    public void GetStatistics()
    {
        _speed = _upgradesSystem.GetSpeed();
        Mood = _upgradesSystem.GetMood();
        _maxMood = Mood;
        _regeneration = _upgradesSystem.GetRegeneration();
        Resistance = _upgradesSystem.GetResistance();
    }

    /// <summary>
    /// Function that refresh the Mood sprite based on actual Mood
    /// </summary>
    private void MoodStatus()
    {
        if (Mood < _maxMood)
            Mood += _regeneration * Time.deltaTime/10;

        if (Mood >= 81 && Mood <=100)
        {
            _moodSprite.sprite = _100;
        }
        if (Mood >= 61 && Mood <= 80)
        {
            _moodSprite.sprite = _080;
        }
        if (Mood >= 41 && Mood <= 60)
        {
            _moodSprite.sprite = _060;
        }
        if (Mood >= 21 && Mood <= 40)
        {
            _moodSprite.sprite = _040;
        }
        if (Mood >= 1 && Mood <= 20)
        {
            _moodSprite.sprite = _020;
        }

        if (Mood <= 0)
            Death();
    }


    /// <summary>
    /// Function that makes the player move
    /// </summary>
    private void Movement()
    {
        if (_isDead)
            return;

        if(transform.position.x <= _camera.ScreenToWorldPoint(Input.mousePosition).x + 0.11f && transform.position.x >= _camera.ScreenToWorldPoint(Input.mousePosition).x - 0.03f)
        {
            _animatorPlayer.SetBool("Walking", false);
        }

        if (transform.position.x > -5 && transform.position.x > _camera.ScreenToWorldPoint(Input.mousePosition).x + 0.1f)
        {
            _newPosition.x -= _speed * Time.deltaTime;
            _newPosition.y = transform.position.y;

            transform.position = _newPosition;
            _sprite.flipX = true;
            _animatorPlayer.SetBool("Walking", true);
        }

        if (transform.position.x < 7 && transform.position.x < _camera.ScreenToWorldPoint(Input.mousePosition).x)
        {
            _newPosition.x += _speed * Time.deltaTime;
            _newPosition.y = transform.position.y;

            transform.position = _newPosition;
            _sprite.flipX = false;
            _animatorPlayer.SetBool("Walking", true);
        }
    }


    /// <summary>
    /// Actions that excecute when the player dies
    /// </summary>
    private void Death()
    {
        _isDead = true;

        TransitionControl.GameOver();
    }
}
