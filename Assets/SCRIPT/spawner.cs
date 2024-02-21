using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject[] npc;
   //ublic Vector3 spawnValue;
    public float spawnwait;
    public float spawnMostwait;
    public float spawnLeastwait;
    public int startWait;
    public bool stop;
    public GameObject spawn;

    int randNPC;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
        
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnwait = Random.Range(spawnLeastwait, spawnMostwait);

    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);
        while (!stop)
        {
            randNPC = Random.Range(0,4);
            Vector3 spawnPosition = spawn.transform.position;
           // Debug.Log(randNPC);
            Instantiate(npc[randNPC], spawnPosition, npc[randNPC].transform.rotation);
            yield return new WaitForSeconds(spawnwait);
            

        }
    }
   
}
