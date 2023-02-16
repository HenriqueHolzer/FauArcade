using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;

    [SerializeField]
    private float jumpForce;

    public LayerMask ground;

    private bool isGrounded;

    private Collider2D collider2D;

    public float points;

    private float highscore;

    public float multiplicadorP = 1;

    public Text pointsText;

    public Text highScoreText;

    public AudioSource pularAudio;

    public AudioSource milPontosAudio;

    public AudioSource gameOverAudio;

    public GameObject gameOverPanel;

    public Animator animatorComponent;

    public bool canCollectShield = true;

    public bool canDie = true;

    public GameObject escudo;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("HIGHSCORE");

        collider2D = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        points += Time.deltaTime * multiplicadorP;
        var pontosArrendondados = Mathf.FloorToInt(points);

        pointsText.text = "Pontos: " + pontosArrendondados.ToString();

        highScoreText.text = "HighScore: " + Mathf.FloorToInt(highscore).ToString();

        if(pontosArrendondados > 0 && pontosArrendondados % 1000 == 0 && !milPontosAudio.isPlaying)
        {
            milPontosAudio.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Pular();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && isGrounded)
        {
            Abaixar();
        } 
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            Levantar();
        }
    }

    void Pular()
    {
        rb.AddForce(Vector2.up * jumpForce);

        pularAudio.Play();
    }

    void Abaixar()
    {
        animatorComponent.SetBool("Abaixado", true);
    }

    void Levantar()
    {
        animatorComponent.SetBool("Abaixado", false);
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.IsTouchingLayers(collider2D, LayerMask.GetMask("Ground"));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (canDie == true)
        {
            if (collision.gameObject.CompareTag("Inimigo"))
            {
                if (points > highscore)
                {
                    highscore = points;

                    PlayerPrefs.SetFloat("HIGHSCORE", highscore);
                }

                gameOverAudio.Play();

                gameOverPanel.SetActive(true);

                Time.timeScale = 0;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PowerUp") && canCollectShield)
        {
            // Coletar power-up de escudo
            escudo.SetActive(true);
            canCollectShield = false;
            canDie = false;
 
        }
    }
}
