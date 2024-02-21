using System.Collections;
using System.Transactions;
using UnityEngine;
using Random = UnityEngine.Random;

public class NPC_Attraction : MonoBehaviour
{
    public float attractive = 0f;
 
    
    void Start()
    {
        if(gameObject.name != "Camera")
        {
            attractive = Random.Range(-10f, 10f);
        }
        
      
    }

  



}
     

