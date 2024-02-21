using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sound_interaction : MonoBehaviour
{
    private AudioSource horn;
    private GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        horn = car.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "car" || other.tag == "Agent")
        {
            StartCoroutine(Example());
            car = other.gameObject;
        }

    }


        IEnumerator Example()
        {



            horn = car.gameObject.GetComponent<AudioSource>();
            horn.Play();

            yield return new WaitForSeconds(5);
        }





    }
