using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deneme : MonoBehaviour
{
    [SerializeField] AudioClip deathSFX;
    void Start()
    {

    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            AudioManager.Instance.PlaySound(deathSFX);
        }
    }
}
