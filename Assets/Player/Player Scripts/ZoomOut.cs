using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomOut : MonoBehaviour
{

    public Camera cam;
    public GameObject UISprites;
    public Canvas UICanvas;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            cam.orthographicSize = 15f;
            UICanvas.enabled = false;
            UISprites.SetActive(false);
        } else
        {
            cam.orthographicSize = 7f;
            UICanvas.enabled = true;
            UISprites.SetActive(true);
        }
    }
}
