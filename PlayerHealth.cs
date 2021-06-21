using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerHealth = 7;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip baseHitSFX;
     void Start()
    {
        Collider collider = GetComponent<BoxCollider>();
        healthText.text = playerHealth.ToString();
    }
     void OnTriggerEnter(Collider collider)
    {
        GetComponent<AudioSource>().PlayOneShot(baseHitSFX);
        playerHealth--;
        healthText.text = playerHealth.ToString();
        if (playerHealth < 0)
        {
            //lose
        }
    }
}
