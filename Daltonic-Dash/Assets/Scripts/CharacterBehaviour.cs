using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private float jumpForce = 10f;
    void Start()
    {

    }
    void Update()
    {
        Jump();
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger("jump");
        }
    }
}
