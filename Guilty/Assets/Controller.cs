using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject stample;
    bool hasStample = false;
    
    float timer = 0.1f;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider.tag == "Stample")
            {
               stample =  hit.transform.gameObject;
               hasStample = true;
            }
           
        }

        if (hasStample)
        {
            timer -= Time.deltaTime;
            
            stample.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0) && timer <= 0)
            {
                timer = 0.1f;
                hasStample = false;
            }
        }
    }
 
}
