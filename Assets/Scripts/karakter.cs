using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class karakter : MonoBehaviour
{
    #region NOTLAR : tek yerde kullanacağın değişkenler için scritableObject kullanabilirsin türkçe karakter içeren (i,ü,ı) gibi değerl verme
    [SerializeField] AudioClip vampirAttackSFX;

    float hiz = 5f;
    public float ziplamaGucu;
    private bool karakterYerde;
    public Rigidbody rb;
    private float Hareket;
    private Animator anim;
    bool isAttack;

    #endregion
    PlayerDeath playerDeath;
    Score score;
    PlayerHealth playerHealth;
    private void Awake()
    {
        Time.timeScale = 1;
    }
    void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        score = GameObject.FindGameObjectWithTag("GameCanvas").GetComponent<Score>();
        playerDeath = GetComponent<PlayerDeath>();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void Update()
    {
        //olabildiğince kodu parçlara böl spagetti koddan uzak durmaya çalış
        Move();
        PlayAnim();
        isDeath();

    }
    void isDeath()
    {
        if (playerHealth.GetCurrentHealth() <= 0)
        {
            playerDeath.Death();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "zemin" || other.gameObject.tag == "platform")
        {
            karakterYerde = true;
        }
        if (other.gameObject.tag == "DeathArea")
        {

            playerDeath.Death();
        }

        if (other.gameObject.tag == "Enemy")
        {
            if (isAttack == true)
            {
                score.IncreaseCurrentScore(100);
                Destroy(other.gameObject);
            }
            else
            {
                playerHealth.ReduceCurrentHealth(10);
                score.ReduceCurrentScore(100);
            }



        }
        if (other.gameObject.tag == "Last")
        {
            score.IncreaseCurrentScore(1000);
        }
    }
    void Move()
    {
        Hareket = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Hareket * hiz, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            isAttack = false;
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            isAttack = false;
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetButtonDown("Jump") && karakterYerde == true)
        {
            isAttack = false;
            rb.AddForce(Vector2.up * ziplamaGucu, ForceMode.Impulse);
            anim.ResetTrigger("idle");
            anim.SetTrigger("jump");
            karakterYerde = false;
        }

    }
    void PlayAnim()
    {
        if (Mathf.Abs(Hareket) > Mathf.Epsilon)
        {

            anim.ResetTrigger("idle");
            anim.SetTrigger("Walk");

        }
        if (Mathf.Abs(Hareket) == 0)
        {

            anim.ResetTrigger("Walk");
            anim.SetTrigger("idle");
        }
        if (Input.GetMouseButtonDown(0))
        {
            isAttack = true;
            anim.ResetTrigger("idle");
            anim.ResetTrigger("Walk");
            anim.SetTrigger("attack");

            if (AudioManager.Instance != null)

                AudioManager.Instance.PlaySound(vampirAttackSFX);

        }

    }

}
