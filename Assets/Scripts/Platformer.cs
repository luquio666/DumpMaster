using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    Rigidbody2D _rb;

    public BoxCollider2D PlayerCollider;

    public float Speed = 4f;
    public float JumpForce = 12f;

    public float FallMultiplier = 2.5f;
    public float LowJumpMultiplier = 2f;

    bool _isGrounded = false;
    public Transform IsGroundedChecker;
    public float CheckGroundRadius = 0.3f;
    public LayerMask GroundLayer;

    public float RememberGroundedFor = 0.1f;
    float _lastTimeGrounded;

    public int DefaultAdditionalJumps = 1;
    int _additionalJumps;


    public float PowerupDistanceTravel = 5f;
    public float PowerupSpeed = 3f;
    public float PowerupColIncrement = 0.1f;
    public CircleCollider2D PowerupCollider;
    Vector3 _powerupTarget;
    bool _usingPowerup = false;


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        _additionalJumps = DefaultAdditionalJumps;
    }

    void Update()
    {
        Powerup();

        if (_usingPowerup == false)
        {
            Move();
            Jump();
            BetterJump();
            CheckIfGrounded();
        }
    }


    void Move() {
        float x = Input.GetAxisRaw("Horizontal");

        float moveBy = x * Speed;

        _rb.velocity = new Vector2(moveBy, _rb.velocity.y);
    }

    void Jump() {
        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) && (_isGrounded || Time.time - _lastTimeGrounded <= RememberGroundedFor || _additionalJumps > 0)) {
            _rb.velocity = new Vector2(_rb.velocity.x, JumpForce);
            _additionalJumps--;
        }
    }

    void BetterJump() {
        if (_rb.velocity.y < 0) {
            _rb.velocity += Vector2.up * Physics2D.gravity * (FallMultiplier - 1) * Time.deltaTime;
        } else if (_rb.velocity.y > 0 && !(Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))) {
            _rb.velocity += Vector2.up * Physics2D.gravity * (LowJumpMultiplier - 1) * Time.deltaTime;
        }   
    }

    void CheckIfGrounded() {
        Collider2D colliders = Physics2D.OverlapCircle(IsGroundedChecker.position, CheckGroundRadius, GroundLayer);

        if (colliders != null) {
            _isGrounded = true;
            _additionalJumps = DefaultAdditionalJumps;
        } else {
            if (_isGrounded) {
                _lastTimeGrounded = Time.time;
            }
            _isGrounded = false;
        }
    }

    void Powerup()
    {
        if (Input.GetKeyDown(KeyCode.P) && _usingPowerup == false)
        {
            _usingPowerup = true;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            PlayerCollider.enabled = false;
            PowerupCollider.enabled = true;
            StartCoroutine(PowerupCo());
        }
    }

    IEnumerator PowerupCo()
    {
        yield return null;

        // Target will be up and centered
        _powerupTarget = new Vector3(0, this.transform.position.y + PowerupDistanceTravel, 0);

        var colSizeTarget = 2.5f;

        while (this.transform.position != _powerupTarget)
        {
            if (PowerupCollider.radius < 2.5f)
            {
                PowerupCollider.radius += PowerupColIncrement;
            }
            float step = PowerupSpeed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, _powerupTarget, step);
            yield return null;
        }

        _rb.bodyType = RigidbodyType2D.Dynamic;
        _usingPowerup = false;

        PowerupCollider.radius = 0.5f;
        PlayerCollider.enabled = true;

        PowerupCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ETags.item_worm.ToString())
        {
            print("worm added");
        }
        if (collision.tag == ETags.item_powerup.ToString())
        {
            print("powerup added");
        }
    }

}
