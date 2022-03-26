using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public GameObject stample;
    public bool hasStample = false;
    bool onFile = false;
    
    float timer = 0.1f;

    public Vector3 lastPosition;

    public GameObject[] stamples;

    public GameObject person;
    
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

            if (hit.collider != null)
            {
                if (hit.collider.tag == "File" && hasStample == true)
                {
                    onFile = true;
                }

                if (hit.collider.tag == "Stample" && hasStample == false)
                {
                    stample = hit.transform.gameObject;
                    stample.GetComponent<Collider2D>().enabled = false;
                    lastPosition = stample.transform.position;
                    hasStample = true;
                }
            }
           
        }

        if (hasStample)
        {
            timer -= Time.deltaTime;
            
            stample.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            if (Input.GetMouseButtonDown(0) && timer <= 0)
            {
                
                timer = 0.1f;

                if (onFile)
                {
                    switch (stample.name)
                    {
                        case "GreenStample":
                            Instantiate(stamples[0], stample.transform.position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Random.Range(-4, 45)));
                            person.GetComponent<Animator>().SetTrigger("WalkOut");
                            break;

                        case "RedStample":
                            Instantiate(stamples[1], stample.transform.position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Random.Range(-4, 45)));
                            person.GetComponent<Animator>().SetTrigger("WalkOut");
                            break;

                        case "BlackStample":
                            Instantiate(stamples[2], stample.transform.position, Quaternion.Euler(Quaternion.identity.x, Quaternion.identity.y, Random.Range(-4, 45)));
                            person.GetComponent<Animator>().SetTrigger("WalkOut");
                            break;


                        default:
                            break;
                    }
                }

               
                stample.transform.position = lastPosition;
                stample.GetComponent<Collider2D>().enabled = true;
                hasStample = false;
                onFile = false;
            }
        }
    }
 
}
