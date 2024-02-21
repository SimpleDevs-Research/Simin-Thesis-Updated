using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrafficLightCOntroller : MonoBehaviour
{
    [SerializeField]
    private Tiled_Texture_Animation[] big_light;
    [SerializeField]
    private Tiled_Texture_Animation[] small_light;
    [SerializeField]
    private GameObject small_stop_target;
    NavMeshAgent Agent;
    [SerializeField]
    private GameObject big_stop_target;

    // Start is called before the first frame update
    //red=0
    //green=2
    //yellow = 1

    public int getSmallLightColor()
    {

        if (small_light[0].getImageIY() < 0.5 || small_light[0].getImageIY()> 0.875 )
        {

            return 0;
        }
        else
        {
            return 2;
        }
    } 

    public int getBighLightColor()
    {
        if(big_light[0].getImageIY()>0.78 || big_light[0].getImageIY() < 0.45)
        {
            return 2;
        }
        else
        {
            return 0;
        }
        
    }


    public Vector3 getSmallStopPosition()
    {
     

            return small_stop_target.transform.position;
        
    }

    public Vector3 getBighStopPosition()
    {
        return big_stop_target.transform.position;
    }
}
