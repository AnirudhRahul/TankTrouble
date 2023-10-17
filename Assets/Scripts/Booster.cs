using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider) {
        Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();
        TankMovement targetMovement = targetRigidbody.GetComponent<TankMovement>();
        targetMovement.m_Speed = 24f;
        targetMovement.m_TurnSpeed = 360f;  
    }

    private void OnTriggerExit(Collider collider) {
        Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();
        TankMovement targetMovement = targetRigidbody.GetComponent<TankMovement>();
        targetMovement.m_Speed = 12f;
        targetMovement.m_TurnSpeed = 180f; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
