using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RAYCASTMAP : MonoBehaviour
{

    public float logInterval = 50f;
    private float counter;
    private TextWriter outputStream;
    string hitpoint;
    public SensorToolkit.Sensor sight;

    private string GazeX;
    private string GazeY;
    private string GazeZ;

    private string CamX;
    private string CamY;
    private string CamZ;

    private string CamRotateX;
    private string CamRotateY;
    private string CamRotateZ;
    private string CamRotateW;
    private string HitObject;
    public string accident;
    public string OnTheRoad;

    //  [SerializeField]
    //  private string BASE_URL = "https://docs.google.com/forms/d/e/1FAIpQLSdQ7bQHTQd2I5jb-x-naLRlIicbHdo2xMeSbUZnaJoFsgdXxg/formResponse";

    //private bool didLog = false;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start");
        counter = logInterval;
        string suffix = System.DateTime.Now.Day.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString();
        outputStream = new StreamWriter("RaycastLog" + suffix + ".csv", true);
        outputStream.WriteLine("Time, GazeX, GazeY, GazeZ, GazePoint, CamX, CamY, CamZ,CamRotateX,CamRotateY,CamRotateZ, Dected_Objects,Accident,cross");
        sight = GetComponent<SensorToolkit.Example.SoldierAI>().Sight;
    }

    void OnTriggerEnter(Collider theCollision)
    {

        if (theCollision.tag == "car")
        {
           accident = "HitByCar";
        }
        else
        {
           accident = "  ";
        }
           
    }

    void OnTriggerStay(Collider theCollision)
    {

        if (theCollision.tag == "data")
        {
            OnTheRoad = "cross";
        }
        else
        {
            OnTheRoad = "not cross";
        }

    }

    private void FixedUpdate()
    {

        print(accident);
        counter -= 1;
        if (counter < 0) {

            List<GameObject> heads = sight.GetDetected();
            string result = heads.ToString();

            Ray ray = GetComponent<Camera>().ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                //Debug.Log(hit.point);
                HitObject = hit.collider.name.ToString();
              string hitpoint = System.DateTime.Now.ToString() + ',' + hit.point.x.ToString() + ',' + hit.point.y.ToString() + ',' + hit.point.z.ToString() + ',' + HitObject + ',' + this.transform.position.x.ToString() + ',' + this.transform.position.y.ToString() + ',' + this.transform.position.z.ToString() + ',' +this.transform.eulerAngles.x.ToString() + ',' + this.transform.eulerAngles.y.ToString() + ',' + this.transform.eulerAngles.z.ToString()+',' + string.Join(";", new List<GameObject>(heads)
             .ConvertAll(i => i.ToString())
             .ToArray())+',' + accident + ',' + OnTheRoad;
                Debug.Log(hitpoint);
                outputStream.WriteLine(hitpoint);
                counter = logInterval;


                GazeX = hit.point.x.ToString();
                GazeY = hit.point.y.ToString();
                GazeZ = hit.point.z.ToString();
                CamX = this.transform.position.x.ToString();
                CamY = this.transform.position.y.ToString();
                CamZ = this.transform.position.z.ToString();
                CamRotateX = this.transform.rotation.x.ToString();
                CamRotateY = this.transform.rotation.y.ToString();
                CamRotateZ = this.transform.rotation.z.ToString();

                WWWForm form = new WWWForm();
                form.AddField("entry.1717685645", GazeX);
                form.AddField("entry.861186408", GazeY);
                form.AddField("entry.174360862", GazeZ);
                form.AddField("entry.1797067011", CamX);
                form.AddField("entry.1468155548", CamY);
                form.AddField("entry.1407192239", CamZ);
                byte[] rawData = form.data;
              //  WWW www = new WWW(BASE_URL, rawData);

            }
        }

    }

    




  
        void Update()
        {
            //Debug.Log("Test");

            //else
            //Debug.Log("I'm looking at nothing!");
        }

        void OnDestroy()
        {
            outputStream.Close();
        }

    }

