using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContollerBehavior : MonoBehaviour
{

    public GameObject basketball;
    public BoxCollider controllerHitBox;

    Vector3 basketballOrigin = new Vector3(0, 1, -8);
    private SteamVR_TrackedObject trackedObj;
    private GameObject collidingObject;
    private GameObject objectInHand;
    private bool controllerPhysical;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        controllerHitBox.isTrigger = true;
        Debug.Log(controllerHitBox.enabled);
    }
    private void FixedUpdate()
    {
        if(Controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            basketball.transform.position = basketballOrigin;
            basketball.GetComponent<Rigidbody>().velocity = Vector3.zero;
            basketball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;


        }
            if (Controller.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
            {
                controllerHitBox.isTrigger = false;
            }
            if (Controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
            {
                controllerHitBox.isTrigger = true;
            }
    }


    private void Update()
    {
        if (controllerHitBox.isTrigger == enabled)
        {
            if (Controller.GetHairTriggerDown())
            {
                if (collidingObject)
                {
                    GrabObject();
                }
            }

            if (Controller.GetHairTriggerUp())
            {
                if (objectInHand)
                {
                    ReleaseObject();
                }
            }
        }
        else if(controllerHitBox.isTrigger == enabled)
        {
            BounceObject();
        }
    }

    //Set a touched rigidboy to a 'CollidingObject'
    private void SetCollidingObject(Collider col)
    {
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        collidingObject = col.gameObject;
    }

    //If there's an object being touched by a trigger collider, set it as the colliding object
    //if not, do nothing and set the colliding object as null
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
        if (!collidingObject)
        {
            return;
        }
        collidingObject = null;
    }

    private void GrabObject()
    {
        //Set the object holding to the collided object then set a collided object to null
        objectInHand = collidingObject;
        collidingObject = null;

        //create a connection between the controller and the collided object
        var joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
    }

    private void ReleaseObject()
    {
        
        if(GetComponent<FixedJoint>())
        {
            //find the connection between the object and the controller and break it
            GetComponent<FixedJoint>().connectedBody = null;
            Destroy(GetComponent<FixedJoint>());
            //set the object in the same direction the controller is moving
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        //allow another object to be picked up
        objectInHand = null;
    }

    private void BounceObject()
    {
        collidingObject.GetComponent<Rigidbody>().velocity = Controller.velocity;
        collidingObject.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }
}

