using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafficlightcontroller_big : MonoBehaviour
{
    /* [SerializeField]
      private Tiled_Texture_Animation[] big_light;
      [SerializeField]
      private Tiled_Texture_Animation[] small_light;*/

    [SerializeField]
    private Tiled_Texture_Animation[] lightit;
    [SerializeField]
    private GameObject stop_target;

    public bool isBig;

    /* [SerializeField]
     private GameObject big_stop_target;*/
    // Start is called before the first frame update
    //red=0
    //green=2
    //yellow = 1

   /* public int getLightColor()
    {
        if (lightit[0].getImageIY() < 0.5 || lightit[0].getImageIY() > 0.875)
        {

            return 0;
        }
        else
        {
            return 2;
        }
    }*/

    public int getLightColor()
     {
        if (isBig)
        {
            if (lightit[0].getImageIY() > 0.66 && lightit[0].getImageIY() < 0.97)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
      
        else {
            if (lightit[0].getImageIY() < 0.5 || lightit[0].getImageIY() > 0.98)
            {

                return 2;
            }
            else
            {
                return 0;
            }
        }
    }


    public Vector3 getStopPosition()
    {
        return stop_target.transform.position;
    }

    /*   public Vector3 getBighStopPosition()
       {
           return big_stop_target.transform.position;
       }*/
}
