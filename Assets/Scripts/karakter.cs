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
        playerDeath = GetComponent<PlayerDeath>();

        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }
    void Update()
    {
        //olabildiğince kodu parçlara böl spagetti koddan uzak durmaya çalış
        Move();
        PlayAnim();
        Deneme();
    }
    void Deneme()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerHealth.ReduceCurrentHealth(10);
            if (playerHealth.GetCurrentHealth() <= 0)
            {
                playerDeath.Death();
            }
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
            print("öldünke");
            playerDeath.Death();
        }
    }
    void Move()
    {
        Hareket = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(Hareket * hiz, rb.velocity.y);

        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 270f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }
        if (Input.GetButtonDown("Jump") && karakterYerde == true)
        {
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
            anim.ResetTrigger("idle");
            anim.ResetTrigger("Walk");
            anim.SetTrigger("attack");

            if (AudioManager.Instance != null)

                AudioManager.Instance.PlaySound(vampirAttackSFX);

        }

    }

}
