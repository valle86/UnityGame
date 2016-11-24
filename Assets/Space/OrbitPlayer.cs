using UnityEngine;
using System.Collections;

public class OrbitPlayer : MonoBehaviour {

    public Transform target;
    public float orbitDistance = 10.0f;
    public float orbitDegreesPerSec = 180.0f;

    // Use this for initialization
    void Start()
    {

    }

    void Orbit()
    {
        if (target != null)
        {
            // DISTANCE
            // Keep us at orbitDistance from target
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, Vector3.up, orbitDegreesPerSec * Time.deltaTime);


            // DIRECTION TESTING AND VARIABLES. 
            Vector3 dir = target.transform.position - transform.position;
            Vector3 ninetyDegrees = Vector3.Cross(Vector3.up, dir);
            //Vector3 thirtyDegrees = Quaternion.Euler(0, 30, 0) * dir;
            //dir = target.transform.InverseTransformDirection(dir);
            //float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector3 targetDir = target.transform.position - transform.position;
            float angle = Vector3.Angle(ninetyDegrees, transform.forward);


            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);


            //transform.rotation = Quaternion.AngleAxis(60, Vector3.up);

        }
    }

    // Update is called once per frame
    void Update()
    {

        // Call from LateUpdate instead...
        // Orbit();

    }
    // Call from LateUpdate if you want to be sure your
    // target is done with it's move.
    void LateUpdate()
    {

        Orbit();

    }
}
