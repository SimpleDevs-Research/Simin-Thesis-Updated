using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class NPC_Controller : MonoBehaviour
{
    //Getting all the Goals.
    private GameObject[] GoalLocations;
    //Getting the NavMeshAgent(Present in components of our NPC.)
    NavMeshAgent Agent;
    public ThirdPersonCharacter npc;
    public SensorToolkit.Sensor sight;
    private Vector3 previous_target;
    private float ignore_traffic_range = 0.1f;
    public float originalSpeed = 0.1f;
    private int cur_target;
    float nextLookTime;
    public float LookRate = 1000;
    private bool triggerstay = false;

    void Start()
    {   
       
        //Setting our GoalLocation objects
        GoalLocations = GameObject.FindGameObjectsWithTag("Goal");
        //Setting our NavMeshAgent
        Agent = GetComponent<NavMeshAgent>();
        //Setting Random Desitnation for NPC
        sight = GetComponent<SensorToolkit.Example.SoldierAI>().Sight;
        Agent.updateRotation = false;
        cur_target = Random.Range(0, GoalLocations.Length);
        Agent.SetDestination(GoalLocations[cur_target].transform.position);
     
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "ontriggerstay")
        {
           triggerstay = true;
            Agent.speed = 1f;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "ontriggerstay")
        {
            triggerstay = false;
            Agent.speed = 0.6f;

        }
    }

    void Update()
    {
        //TrafficLightCOntroller detected = sight.GetNearestByComponent<TrafficLightCOntroller>();

        /*  if (triggerstay)
          {
              //targetLight.transform.position = new Vector3(targetLight.transform.position.x, targetLight.transform.position.y+1, targetLight.transform.position.z );
              // Debug.Log("Light selected");
              //Debug.Log(targetLight.getLightColor());

              //Debug.Log("------------------");
              Debug.Log(bool.TrueString+ this.gameObject.name);

          }
          if (!triggerstay)
          {
              Debug.Log(bool.FalseString + this.gameObject.name);
          }*/


        List<trafficlightcontroller_big> lights = sight.GetDetectedByComponent<trafficlightcontroller_big>();
       
        trafficlightcontroller_big targetLight = null;

        Vector3 stop_pos = Vector3.zero;
        double max_angle = 190;
        double min_angle = 140;


        foreach (trafficlightcontroller_big trafficlight in lights)
        {
            /* if (Vector3.Distance(transform.position, trafficlight.transform.position) <= ignore_traffic_range)
             {
                 continue;
             }*/

            double cur_angle = Vector3.Angle(Agent.velocity.normalized, (trafficlight.transform.forward).normalized);
           
            //double cur_angle = Vector3.Angle((Agent.transform.forward).normalized, (trafficlight.transform.forward).normalized);
            // print(cur_angle+"original");

            if (cur_angle > min_angle && cur_angle < max_angle)
            {
                //max_angle = cur_angle;

                targetLight = trafficlight;

            }
        }

        if (targetLight != null)
        {


            if (triggerstay)
            {


                if (targetLight.getLightColor() == 0)
                {
                    Agent.speed = 2f;
                    stop_pos = targetLight.getStopPosition();


                }

                Agent.SetDestination(stop_pos);
            }

            else if (targetLight.getLightColor() == 0)
            {

                Agent.speed = 0;
                //Agent.SetDestination(transform.position);
                Agent.speed = originalSpeed;

            }



            //Agent.stoppingDistance
            if (Agent.remainingDistance <= 0f)
            {
                Agent.speed = 0f;
                npc.Move(Vector3.zero, false, false);
             //   gameObject.transform.LookAt(targetLight.gameObject.transform);


            }
            /* else
             {
                 // Agent.SetDestination(GoalLocations[cur_target].transform.position);
                npc.Move(Agent.desiredVelocity, false, false);
                // Agent.speed = 0f;

             }*/
        }

        else
        {
            Agent.speed = originalSpeed;
            if (Agent.remainingDistance <= 1f)
            {
                Agent.SetDestination(GoalLocations[Random.Range(0, GoalLocations.Length)].transform.position);
            }

            if (Agent.remainingDistance > Agent.stoppingDistance)
            {
                npc.Move(Agent.desiredVelocity, false, false);
            }




        }
    }


    }
