using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isGrounded = true;
    void Start()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        CheckGrounded();
        Jump();
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }

    public void CheckGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + Vector3.right* -0.2f, Vector2.down, 0.09f);
        //Debug.DrawRay(transform.position + Vector3.right * -0.02f, Vector2.down, Color.red);
        Debug.DrawLine(transform.position + Vector3.right * -0.02f, transform.position + Vector3.right * -0.02f + Vector3.down * 0.09f, Color.red);
        isGrounded = hit.collider.gameObject.CompareTag("Ground");
        Debug.Log(isGrounded);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Spyke")
        {
            anim.SetTrigger("dead");
            StartCoroutine(DeadCoroutine());
        }
    }
    public IEnumerator DeadCoroutine()
    {
        yield return new WaitForSeconds(0.03f);
        Time.timeScale = 0;
    }
}
