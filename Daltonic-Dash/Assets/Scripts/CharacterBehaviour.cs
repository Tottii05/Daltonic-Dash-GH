using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isGrounded = true;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        Debug.DrawLine(transform.position + Vector3.right * -0.02f, transform.position + Vector3.right * -0.02f + Vector3.down * 0.09f, Color.red);
        if (hit.collider != null)
        {
            isGrounded = hit.collider.gameObject.CompareTag("Ground");
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Spyke")
        {
            anim.SetTrigger("dead");
            StartCoroutine(DeadCoroutine());
        }
    }
    public IEnumerator DeadCoroutine()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.enabled = false;
        Time.timeScale = 0;
    }
}
