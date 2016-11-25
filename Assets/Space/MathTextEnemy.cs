using UnityEngine;
using System.Collections;

public class MathTextEnemy : MonoBehaviour {

    public Transform target;


    // Use this for initialization
    void Start ()
    {

        transform.Rotate(90,0,0);
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = target.position;


	
	}
}
