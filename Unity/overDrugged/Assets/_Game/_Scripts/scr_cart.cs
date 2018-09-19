using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_cart : MonoBehaviour
{

    bool bound;
    public GameObject slot1;
    public GameObject slot2;
    public Transform playerTransform;

    bool slopt1;
    bool slopt2;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!bound)
                {
                    transform.position = other.gameObject.transform.position;
                    transform.rotation = other.gameObject.transform.rotation;
                    transform.parent = other.gameObject.transform;
                    bound = true;
                }
                else
                {
                    transform.parent = null;
                    bound = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                Debug.Log(slopt1 + " " + slopt2);
                if (!slopt1 || !slopt2)
                {
                    Transform t = playerTransform;

                    Transform child = t.GetChild(0);
                    
                    if (child != null)
                    {
                   
                            if (!slopt1) {
                                child.transform.position = slot1.transform.position;
                                child.transform.parent = slot1.transform;
                                slopt1 = true;
                            }

                            else if (!slopt2){
                                child.transform.position = slot2.transform.position;
                                child.transform.parent = slot2.transform;
                                slopt2 = true;
                            }
                  
                    }

                }
            }



        }
    }
}

