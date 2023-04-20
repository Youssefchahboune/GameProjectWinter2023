using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeToss : MonoBehaviour
{
    private Vector3 targetPos;
    public float speed = 10f;
    public GameObject explosion;

    private void Start()
    {
        targetPos = GameObject.Find("Dir").transform.position;
    }

    private void Update()
    {
        if(speed > 0)
        {
            speed -= Random.Range(.05f, .1f);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        } else if (speed < 0)
        {
            speed = 0;

            StartCoroutine(Explode(1));
        }
    }

    IEnumerator Explode(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Zombie") || collision.gameObject.CompareTag("BigZombie"))
        {
            StartCoroutine(Explode(0));
        }
    }



}
