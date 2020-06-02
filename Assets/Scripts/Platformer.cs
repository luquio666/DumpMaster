using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    Rigidbody2D _rb;

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
    public float PowerupDuration = 3f;
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
        if (Input.GetKeyDown(KeyCode.P))
        {
            _usingPowerup = true;
            StartCoroutine(PowerupCo());
        }
    }
    IEnumerator PowerupCo()
    {
        yield return null;

        var endTime = Time.time + PowerupDuration;
        while (Time.time > endTime)
        {
            this.transform.position += this.transform.position + new Vector3(0, 0.01f, 0);
            yield return new WaitForSeconds(0.01f);
        }
        _usingPowerup = false;
        
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
