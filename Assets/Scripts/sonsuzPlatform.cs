using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sonsuzPlatform : MonoBehaviour
{

    [SerializeField] GameObject platform1;
    [SerializeField] float spawnLocation;

    void Start()
    {


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameObject platform2 = Instantiate(platform1, new Vector3(other.transform.localPosition.x + spawnLocation, platform1.transform.position.y, platform1.transform.position.z), Quaternion.identity);
        }

    }

}
