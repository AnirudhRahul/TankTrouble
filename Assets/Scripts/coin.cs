using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public LayerMask m_TankMask;                        // Used to filter what the explosion affects, this should be set to "Players".

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider collider)
    {

        Rigidbody targetRigidbody = collider.GetComponent<Rigidbody>();
        TankHealth targetHealth = targetRigidbody.GetComponent<TankHealth>();
        if (!targetHealth.m_hasCoin) { 
            targetHealth.GetCoin();
            Destroy(gameObject);
        }


        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
