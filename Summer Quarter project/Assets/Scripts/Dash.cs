using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Dash : MonoBehaviour
{
    [Header("Referenes")]
    public Transform orientation;
    public Transform playCam;
    private Rigidbody rb;
    private Dash pm;

    [Header("Dashing")]
    public float dashForce;
    public float dashUpwardForce; 
    public float dashDuration;

    [Header("Cooldown")]
    public float dashCd;
    private float dashCdTimer;

    [Header("Input")]
    public KeyCode dashKey = KeyCode.E;

     private void Start()
    {
        rb = GetComponent<Rigidbody>();
        pm = GetComponent<Dash>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(dashKey))
            Dashing();
    }

    private void Dashing()
    {
        Vector3 forceToApply = orientation.forward * dashForce + orientation.up * dashUpwardForce;

        rb.AddForce(forceToApply, ForceMode.Impulse);

        Invoke(nameof(ResetDash), dashDuration);
    }

    private void ResetDash()
    {
        
    }
}
