using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MenuPlayer : MonoBehaviour
{
    //private SpringJoint2D spring;
    private LayerMask layerMask;
    private Vector2 previousMousePos;
    private bool isDragging = false;
    private Rigidbody2D rb;
    private float moveDir = 0;
    private bool isOnGround = false;
    private bool isHold = false;
    [SerializeField] private Animator headAnim;
    [SerializeField] private Animator legAnim;
    private void Awake()
    {
       // spring = gameObject.GetComponent<SpringJoint2D>(); 
       // spring.connectedAnchor = gameObject.transform.position;
        //spring.enabled = false;
        layerMask = LayerMask.GetMask("Player");
        rb = GetComponent<Rigidbody2D>();
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

        //playerAnimator.SetFlip(moveDir.x);
        //playerAnimator.Walk();
        if (inputValue.phase == InputActionPhase.Started)
        {
            legAnim.SetInteger("State", 1);
            FlipPlayer(value);
            isHold = true;
            //playerAnimator.SetAnimation(1);
            // playerAnimator.Walk();
        }
        else if (inputValue.phase == InputActionPhase.Canceled)
        {
            legAnim.SetInteger("State", 0);
            isHold = false;
            //  playerAnimator.SetAnimation(0);
            // playerAnimator.Idle();
            //FlipPlayer(value);
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
          //  spring.enabled = true;
            StartCoroutine(OnDrag());
        }
        //Ray2D ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        //RaycastHit2D hit;


        //float x = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).x - GameManager.player.transform.position.x;
        //float y = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()).y - GameManager.player.transform.position.y;
        //Vector3 dir = new Vector3(x, y, -1).normalized;
        //RaycastHit2D hit = Physics2D.Raycast(GameManager.player.transform.position, dir, 15f, layerMask);


        //if (Physics.Raycast(ray, out hit, layerMask))
        //{
        //    Debug.Log((Physics.Raycast(ray, out hit, layerMask)));
        //    
        //}



    }



    IEnumerator OnDrag()
    {
        isDragging = true;
        while (isDragging)
        {
            rb.position = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            yield return null;
        }
        Debug.Log(Time.fixedDeltaTime);
        rb.AddForce((Mouse.current.position.ReadValue() - previousMousePos) * 10);

    }


    private void OnMouseUp()
    {
        isDragging = false;
        //Debug.Log(previousMousePos);
        //Debug.Log(Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()));
        //spring.enabled = false;
    }
}
