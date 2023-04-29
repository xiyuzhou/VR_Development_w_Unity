using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerControl : MonoBehaviour
{
    private Animator animator;
    public Animator tvAnim;
    public float rayDistance = 20f;
    private int aniHash;
    private bool tvTrigger = false;
    public void OnControllerButtonPressed()
    {
        Debug.Log("Trigger");
        ScreenTrigger();
        animator.SetTrigger("OnControllerPress");

    }
    public void OnControllerButtonRelease()
    {
        Debug.Log("Trigger2");
        animator.SetTrigger("OnControllerRelease");

    }

    public void ScreenTrigger()
    {
        RaycastHit hit;
        Vector3 rayDirection = transform.right;

        if (Physics.Raycast(transform.position, rayDirection, out hit, rayDistance))
        {
            if (hit.collider.CompareTag("TV"))
            {
                OnTVHit();
                Debug.Log("Hit!");
            }
        }
    }

    void OnTVHit()
    {
        if (tvTrigger)
        {
            tvAnim.SetTrigger("TvOff");
        }
        else
        {
            tvAnim.SetTrigger("TvOn");
        }
        tvTrigger = !tvTrigger;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }
}
