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

    private void OnCollisionEnter(Collision collision) {
        Rigidbody targetRigidbody = collision.rigidbody;
        TankMovement tankMovement = targetRigidbody.GetComponent<TankMovement>();
        TankShooting tankShooting = targetRigidbody.GetComponent<TankShooting>();
        tankMovement.doubleSpeedAndTurnSpeed();
        tankShooting.disableShooting();

        
    }

    private void OnCollisionExit(Collision collision) {
        Rigidbody targetRigidbody = collision.rigidbody;
        TankMovement targetMovement = targetRigidbody.GetComponent<TankMovement>();
        TankShooting tankShooting = targetRigidbody.GetComponent<TankShooting>();
        targetMovement.resetSpeedAndTurnSpeed();
        tankShooting.enableShooting();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
