using UnityEngine;
using System.Collections;
using VRTK;

public class FetchBall : MonoBehaviour
{

    [Tooltip("The amount of force to apply to the ball")]
    public float pullForce;

    private void Start()
    {
        if (GetComponent<VRTK_SimplePointer>() == null)
        {
            Debug.LogError("VRTK_ControllerPointerEvents_ListenerExample is required to be attached to a SteamVR Controller that has the VRTK_SimplePointer script attached to it");
            return;
        }

        //Setup controller event listeners
        GetComponent<VRTK_SimplePointer>().DestinationMarkerEnter += new DestinationMarkerEventHandler(DoPointerIn);
        GetComponent<VRTK_SimplePointer>().DestinationMarkerExit += new DestinationMarkerEventHandler(DoPointerOut);
    }

    private void DoPointerIn(object sender, DestinationMarkerEventArgs e)
    {
        if (e.target.tag == "Ball")
        {
            Debug.Log("Fetching Ball");
            Vector3 direction = transform.position - e.target.transform.position;
            //Quaternion towardPlayer = Quaternion.LookRotation();
            e.target.GetComponent<Rigidbody>().AddForce(direction.normalized * pullForce * Time.deltaTime);
        }
    }

    private void DoPointerOut(object sender, DestinationMarkerEventArgs e)
    {
        if (e.target.tag == "Ball")
        {
            Debug.Log("Releaseing Ball");
        }
    }
}