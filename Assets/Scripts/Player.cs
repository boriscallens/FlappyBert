using System.Linq;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class Player : MonoBehaviour
{
    public float gravity = -9.8f;
    public float strength = 5;
    public Sprite[] sprites;

    private Vector3 _direction;
    private SpriteRenderer _spriteRenderer;
    private int _spriteIndex;
    private GameManager _gameManager;

    public void Reset()
    {
        _direction = Vector3.zero;
        transform.position = Vector3.zero;
        enabled = true;
    }

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            _direction = Vector3.up * strength;
        }

        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                _direction = Vector3.up * strength;
            }
        }

        _direction.y += gravity * Time.deltaTime;
        transform.position += _direction * Time.deltaTime;
    }

    private void AnimateSprite()
    {
        if (!sprites.Any()) return;
        _spriteIndex = (_spriteIndex + 1) % sprites.Length;
        _spriteRenderer.sprite = sprites[_spriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            _gameManager.GameOver();
        }
        if (other.CompareTag("Score"))
        {
            _gameManager.IncreaseScore();
        }
    }
}