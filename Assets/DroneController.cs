using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneController : MonoBehaviour
{
    public GameObject markerGoal;
    Vector3 parentPos;
    NavMeshAgent agent;
    public GameObject destSprite;

    /// <summary>
    private Animator anim; 
    /// </summary>

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ///////
        anim = GetComponent<Animator>();
        /// 
    }

    // Update is called once per frame
    void Update()
    {
        moveToTarget();
        PitchCtrl();
    }

    void moveToTarget()
    {
        if (markerGoal.activeSelf)
        {
            parentPos = markerGoal.transform.parent.position;
            agent.SetDestination(parentPos);
            destSprite.transform.position = new Vector3(parentPos.x, 0, parentPos.y);
        }
    }

    float MapRange(float s, float a1, float a2, float b1, float b2)
    {
        if (s >= a2) return b2;
        if (s <= a1) return b1;
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }


    void PitchCtrl()
    {
        transform.GetChild(0).eulerAngles = new Vector3(
            MapRange(agent.velocity.magnitude, 0f, 2f, 0f, 20f),
            transform.eulerAngles.y,
            transform.eulerAngles.z
            );
    }

    /////
    public void PlaceCharacter()
    {
        transform.localPosition = Vector3.zero;
    }
    //////

}
