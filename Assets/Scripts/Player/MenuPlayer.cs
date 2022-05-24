using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuPlayer : MonoBehaviour
{
    private LayerMask layerMask;
    private Vector2 previousMousePos;
    private bool isDragging = false;
    private Rigidbody2D rb;
    private float moveDir = 0;
    private bool isOnGround = false;
    private bool isHold = false;
    [SerializeField] private Animator headAnim;
    [SerializeField] private Animator legAnim;
    private AudioSource audioSource;
    private void Awake()
    {
        layerMask = LayerMask.GetMask("Player");
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
        audioSource.Pause();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnGround = true;
        headAnim.SetInteger("State", 1);
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        headAnim.SetInteger("State", 0);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isOnGround = false;
    }

    private void FixedUpdate()
    {
        previousMousePos = Mouse.current.position.ReadValue();
        if (isHold && isOnGround)
        {
            rb.position += new Vector2((moveDir * 0.06f), 0);
            audioSource.UnPause();
        }
    }

    private void FlipPlayer(float x)
    {
        if (x>0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (x < 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
    public void GetMove(InputAction.CallbackContext inputValue)
    {
        float value = inputValue.ReadValue<float>();
        if (inputValue.phase == InputActionPhase.Started)
        {
            legAnim.SetInteger("State", 1);
            FlipPlayer(value);
            isHold = true;
        }
        else if (inputValue.phase == InputActionPhase.Canceled)
        {
            legAnim.SetInteger("State", 0);
            isHold = false;
            audioSource.Pause();
        }
        moveDir = value;
    }

    public void OnMouseUse(InputAction.CallbackContext inputValue)
    {
        if (inputValue.started)
        {
            OnMouseDown();
        }
        else if (inputValue.canceled)
        {
            OnMouseUp();
        }
    }

    private void OnMouseDown()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()), Vector2.zero, 1, layerMask);
        if (hit.collider != null)
        {
            StartCoroutine(OnDrag());
        }
    }

    IEnumerator OnDrag()
    {
        isDragging = true;
        while (isDragging)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            yield return null;
        }
        rb.AddForce((Mouse.current.position.ReadValue() - previousMousePos) * 10);
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
