using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInZone : MonoBehaviour
{
    public Canvas can;

    public static int scoreSpent;

    // Start is called before the first frame update
    void Start()
    {
        can = GameObject.FindGameObjectWithTag("Station Canvas").GetComponent<Canvas>();
        can.enabled = false;
        scoreSpent = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (can.enabled == true)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) && SetStartScore.currentScore >= 100 && Shooting.currentAmountOfBullet != Shooting.maxBulllets)
            {
                SetStartScore.currentScore -= 100;
                Shooting.currentAmountOfBullet = Shooting.maxBulllets;
                scoreSpent += 100;
                Debug.Log("score spent: " + scoreSpent);

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && SetStartScore.currentScore >= 50 && Shooting.currentAmountOfGrenade != Shooting.maxGrenades) {

                SetStartScore.currentScore -= 50;
                Shooting.currentAmountOfGrenade = Shooting.maxGrenades;
                scoreSpent += 50;
                Debug.Log("score spent: " + scoreSpent);

            }

            if (Input.GetKeyDown(KeyCode.LeftShift) && SetStartScore.currentScore >= 50 && MedKitUse.currentAmountOfMedKit != MedKitUse.maxMedKit)
            {

                SetStartScore.currentScore -= 50;
                MedKitUse.currentAmountOfMedKit += 1;
                scoreSpent+= 50;
                Debug.Log("score spent: " + scoreSpent);

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
