using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInZone : MonoBehaviour
{
    public Canvas can;

    // Start is called before the first frame update
    void Start()
    {
        can = GameObject.FindGameObjectWithTag("Station Canvas").GetComponent<Canvas>();
        can.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (can.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && AddScore.currentScore >= 100 && Shooting.currentAmountOfBullet != Shooting.maxBulllets)
            {
                AddScore.currentScore -= 100;
                Shooting.currentAmountOfBullet = Shooting.maxBulllets;
                
            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && AddScore.currentScore >= 50 && Shooting.currentAmountOfGrenade != Shooting.maxGrenades) {

                AddScore.currentScore -= 50;
                Shooting.currentAmountOfGrenade = Shooting.maxGrenades;
            
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            can.enabled = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            can.enabled = false;
        }
    }
}
