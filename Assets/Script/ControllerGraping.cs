using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ControllerGraping : MonoBehaviour
{
    private GameObject timerManager;
    [Header("스팀VR")]
    public SteamVR_Input_Sources handType;
    public SteamVR_Behaviour_Pose controllerPose;
    public SteamVR_Action_Boolean grapAction;
    public SteamVR_Action_Boolean BallresetAction;
    public SteamVR_Action_Boolean menuAction;
    private GameObject coldobject;
    private GameObject objinhand;

    private void Awake()
    {
        timerManager = GameObject.FindGameObjectWithTag("TimerManager");
    }

    void Update()
    {
        Function();
    }
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }
    public void OnTriggerExit(Collider other)
    {
        if (!coldobject) return;

        coldobject = null;
    }

    void SetCollidingObject(Collider col)
    {
        if (coldobject || !col.GetComponent<Rigidbody>())
            return;

        coldobject = col.gameObject;
    }
    void GrabObject()
    {
        objinhand = coldobject;
        coldobject = null;

        var joint = AddFixedJoint();
        joint.connectedBody = objinhand.GetComponent<Rigidbody>();

    }
    void ReleaseObject()
    {
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());

            objinhand.GetComponent<Rigidbody>().velocity = controllerPose.GetVelocity();
            objinhand.GetComponent<Rigidbody>().angularVelocity = controllerPose.GetAngularVelocity();
        }
        objinhand = null;
    }
    private FixedJoint AddFixedJoint()
    {

        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakForce = 20000;
        return fx;
    }
    private void Function()
    {
        if (grapAction.GetLastStateDown(handType))
        {
            if (coldobject)
            {
                GrabObject();
            }
        }
        if (grapAction.GetLastStateUp(handType))
        {
            if (objinhand)
            {
                ReleaseObject();
            }
        }

        if (BallresetAction.GetStateDown(handType))
        {
            GameObject.Find("Ball").transform.position = new Vector3(-24.143f, -1.658f, -72.87119f);
                //(-24.1f, -1.641f, -72);
        }

        if (menuAction.GetStateDown(handType))
        {
            StartCoroutine(timerManager.GetComponent<Timer>().Delay());
        }
    }
}
