using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPhysicallity : MonoBehaviour {

    public BoxCollider physicalControl;
    public GameObject basketball;

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    private void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }
    void Start () {
        physicalControl = GetComponent<BoxCollider>();
	}

    private void OnTriggerEnter(Collider col)
    {
        if(physicalControl)
        {
            basketball.GetComponent<Rigidbody>().velocity = Controller.velocity;
            basketball.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
    }
}
