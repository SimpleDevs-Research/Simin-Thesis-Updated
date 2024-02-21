using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singal_obstacle : MonoBehaviour
{
    [SerializeField]
    private Tiled_Texture_Animation[] lightit;
    public GameObject a1;
    public GameObject a2;
    public GameObject b1;
    public GameObject b2;
    public GameObject c1;
    public GameObject c2;
    public GameObject d1;
    public GameObject d2;

    public GameObject data_Left;
    public GameObject data_Right;
    public GameObject data_Top;
    public GameObject data_Down;

    public GameObject cara1;
    public GameObject carb1;
    public GameObject carc1;
    public GameObject card1;
    public GameObject cara2;
    public GameObject carb2;
    public GameObject carc2;
    public GameObject card2;

    
    // Start is called before the first frame update
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if (lightit[0].getImageIY() > 0.5 && lightit[0].getImageIY() < 0.97)
        {
            a1.gameObject.SetActive(true);
            a2.gameObject.SetActive(true);
            b1.gameObject.SetActive(false);
            b2.gameObject.SetActive(false);


            c1.gameObject.SetActive(true);
            c2.gameObject.SetActive(true);
            d1.gameObject.SetActive(false);
            d2.gameObject.SetActive(false);


            data_Top.gameObject.SetActive(true);
            data_Down.gameObject.SetActive(true);
            data_Right.gameObject.SetActive(false);
            data_Left.gameObject.SetActive(false);

            /*carc1.gameObject.GetComponent<spawner>().stop = true;
              card1.gameObject.GetComponent<spawner>().stop = true;
              cara1.gameObject.GetComponent<spawner>().stop = false;
              carb1.gameObject.GetComponent<spawner>().stop = false;

              carc2.gameObject.GetComponent<spawner>().stop = true;
              card2.gameObject.GetComponent<spawner>().stop = true;
              cara2.gameObject.GetComponent<spawner>().stop = false;
              carb2.gameObject.GetComponent<spawner>().stop = false;*/



            /* cara1.gameObject.transform.position = new Vector3(0,-1000,0);
             cara2.gameObject.transform.position = new Vector3(0, -1000, 0);
             carb1.gameObject.transform.position = new Vector3(0, -1000, 0);
             carb2.gameObject.transform.position = new Vector3(0, -1000, 0);


             carc1.gameObject.transform.position = new Vector3(0, 0, 0);
             carc2.gameObject.transform.position = new Vector3(0, 0, 0);
             card1.gameObject.transform.position = new Vector3(0, 0, 0);
             card2.gameObject.transform.position = new Vector3(0, 0, 0);*/
        }
        else
        {
            a1.gameObject.SetActive(false);
            a2.gameObject.SetActive(false);
            b1.gameObject.SetActive(true);
            b2.gameObject.SetActive(true);



            c1.gameObject.SetActive(false);
            c2.gameObject.SetActive(false);
            d1.gameObject.SetActive(true);
            d2.gameObject.SetActive(true);


            data_Top.gameObject.SetActive(false);
            data_Down.gameObject.SetActive(false);
            data_Right.gameObject.SetActive(true);
            data_Left.gameObject.SetActive(true);
            /*carc1.gameObject.GetComponent<spawner>().stop = false;
            card1.gameObject.GetComponent<spawner>().stop = false;
            cara1.gameObject.GetComponent<spawner>().stop = true;
            carb1.gameObject.GetComponent<spawner>().stop = true;

            carc2.gameObject.GetComponent<spawner>().stop = false;
            card2.gameObject.GetComponent<spawner>().stop = false;
            cara2.gameObject.GetComponent<spawner>().stop = true;
            carb2.gameObject.GetComponent<spawner>().stop = true;*/



            /*   cara1.gameObject.transform.position = new Vector3(0,1000, 0);
               cara2.gameObject.transform.position = new Vector3(0, 1000, 0);
               carb1.gameObject.transform.position = new Vector3(0, 1000, 0);
               carb2.gameObject.transform.position = new Vector3(0, 01000, 0);


               carc1.gameObject.transform.position = new Vector3(0, -1000, 0);
               carc2.gameObject.transform.position = new Vector3(0, -1000, 0);
               card1.gameObject.transform.position = new Vector3(0, -1000, 0);
               card2.gameObject.transform.position = new Vector3(0, -1000, 0);*/

        }
    }
}
