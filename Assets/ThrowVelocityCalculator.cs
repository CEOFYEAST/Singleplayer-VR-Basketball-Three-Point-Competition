using System;
using UnityEngine;

public class ThrowVelocityCalculator : MonoBehaviour
{
    public float distance = 0;
    public float throwVelocity = 0;
    //tweak the scale if shots are off
    public float scale = 4.5f;

    public Vector3 goalPos;
    public Vector3 hmdPos;

    public GameObject goalRing;
    public GameObject mainCamera;
    public GameObject basketball;

    public int updateIterations = 0;

    void Start()
    {
        goalPos = goalRing.transform.position;
    }

    //algorith that sets the velocity of a shot proportional to the distance from the goal 
    void Update()
    {
        if (updateIterations % 50 == 0)
        {
            hmdPos = mainCamera.transform.position;
            distance = (float)Math.Sqrt(Math.Pow(hmdPos.x, 2) + Math.Pow(hmdPos.z, 2));
            throwVelocity = distance * scale;
            //float velocityScale = distance/
            basketball.GetComponent<UnityEngine.XR.Interaction.Toolkit.XRGrabInteractable>().throwVelocityScale = throwVelocity;
            
        }
        updateIterations += 1;
    }
}
