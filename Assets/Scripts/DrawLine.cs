using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lineRenderer;
    private float counter;
    private float distance;

    public Transform origin;
    public Transform destination;

    public float lineDrawSpeed = 10f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, origin.position);
        lineRenderer.SetWidth(.5f, .5f);

        distance = Vector3.Distance(origin.position, destination.position);

    }

    // Update is called once per frame
    void Update()
    {
        if (counter < distance)
        {
            counter += .1f / lineDrawSpeed;

            float x = Mathf.Lerp(0, distance, counter);

            Vector3 pointA = origin.position;
            Vector3 pointB = destination.position;

            Vector3 pointALongLine = x * Vector3.Normalize(pointB - pointA) + pointA;

            lineRenderer.SetPosition(1, pointALongLine);
        }  
    }
}
