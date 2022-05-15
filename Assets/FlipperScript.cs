using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperScript : MonoBehaviour
{
    public float restPosition = 0f;
    public float pressedPosition = 45f;
    public float hitStrength = 10000f;
    public float flipperDamper = 150f;

    HingeJoint hinge;
    JointSpring spring;

    public string inputName;

    // Start is called before the first frame update
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;

        spring = new JointSpring();
    }

    // Update is called once per frame
    void Update()
    {
        
        spring.spring = hitStrength;
        spring.damper = flipperDamper;

        if (UnityEngine.Input.GetAxis(inputName) == 1) {
            spring.targetPosition = pressedPosition;
        } else {
            spring.targetPosition = restPosition;
        }

        hinge.spring = spring;
        hinge.useLimits = true;
    }
}
