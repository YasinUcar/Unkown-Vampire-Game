using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] AudioClip deathSFX;
    [SerializeField] GameObject gameOver;
    Animator anim;
    karakter player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<karakter>();

        anim = GetComponent<Animator>();
    }

    public void Death()
    {
        anim.SetTrigger("die");
        gameOver.SetActive(true);
        player.enabled = false;

        if (AudioManager.Instance != null)
            AudioManager.Instance.PlaySound(deathSFX);

    }
}
