using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateController : MonoBehaviour {

    public State currentState;
    public EnemyStats enemyStats;
    public Transform eyes;
    public State remainState;
    
    [HideInInspector] public NavMeshAgent navMeshAgent;
    [HideInInspector] public ShipShooting shipShooting;
    [HideInInspector] public List<Transform> wayPoints;
    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public Transform chaseTarget;
    [HideInInspector] public float stateTimeElapsed;

    private bool aiActive;

    void Awake()
    {
        shipShooting = GetComponent<ShipShooting> ();
        navMeshAgent = GetComponent<NavMeshAgent> ();
    }

    public void SetupAI(bool aiActivationFromShipManager, 
        List<Transform> wayPointsFromShipManager)
    {
        wayPoints = wayPointsFromShipManager;
        aiActive = aiActivationFromShipManager;
        if (aiActive)
        {
            navMeshAgent.enabled = true;
        } else
        {
            navMeshAgent.enabled = false;
        }

    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    private void OnDrawGizmos()
    {
        if (currentState != null && eyes != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawWireSphere(eyes.position,
                enemyStats.lookSphereCastRadius);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
            currentState = nextState;
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExistsState()
    {
        stateTimeElapsed = 0;
    }

}
