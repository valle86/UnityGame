using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OrbitPlayer : MonoBehaviour {

    public Transform target;
    public Text mathQuestion;
    public float orbitDistance = 10.0f;

    [SerializeField][Range(-180, 180)]
    public float orbitDegreesPerSec = 180.0f;

    // Use this for initialization
    void Start()
    {
        mathQuestion.text = "(MathProblem x)";
    }

    void Orbit()
    {
        if (target != null)
        {
            // DISTANCE
            // Keep orbiter at orbitDistance from orbit target
            transform.position = target.position + (transform.position - target.position).normalized * orbitDistance;
            transform.RotateAround(target.position, Vector3.up, -orbitDegreesPerSec * Time.deltaTime);

            // ROTATION 
            // based on vector between orbit-orbiter turned 90 degrees
            // Vector between orbit - orbiter
            Vector3 dir = target.transform.position - transform.position;
            // turn vector 90 degrees
            Vector3 ninetyDegrees = Vector3.Cross(Vector3.up, dir);
            // Set Orbiter rotation
            transform.rotation = Quaternion.LookRotation(ninetyDegrees);

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
