using System.Collections;
using TMPro;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private bool isGrounded = true;
    public SpriteRenderer spriteRenderer;
    public GameObject gameOverCanvas;
    [SerializeField] private float score = 0;
    private const float NonDaltonicScore = 30;
    public TMP_Text scoreText;
    public TMP_Text resoultText;
    void Start()
    {
        scoreText = GameObject.Find("ScoreText").GetComponent<TMP_Text>();
        resoultText = GameObject.Find("ResoultText").GetComponent<TMP_Text>();
        score = 0;
        gameOverCanvas = GameObject.Find("Canva_GameOver");
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        Time.timeScale = 1;
        gameOverCanvas.SetActive(false);
    }
    void Update()
    {
        CheckGrounded();
        Jump();
        score += (Time.deltaTime * 2);
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            AudioManager.instance.PlaySoundJump();
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
        else
        {
            isGrounded = false;
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
        AudioManager.instance.PlaySoundExplote();
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        scoreText.text = score.ToString("0");
        switch (score)
        {
            case < 7:
                resoultText.text = "Possible daltonic";
                break;
            case < 15:
                resoultText.text = "Signs of daltonism";
                break;
            case > 30:
                resoultText.text = "Good color vision";
                break;
            case > 21:
                resoultText.text = "Correct color vision";
                break;
            case > 15:
                resoultText.text = "Faulty color vision";
                break;  
        }
    }
}
