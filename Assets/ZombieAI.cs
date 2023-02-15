using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAI : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    Animator animator;
    LineRenderer lineRenderer;  
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        lineRenderer = GetComponent<LineRenderer>();    

    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Distanse", Vector3.Distance(transform.position, Player.transform.position));

    }
    public void Fire()
    {
        
        ray = new Ray(transform.position, -transform.up);
        Debug.DrawRay(transform.position, -transform.up * 20f);

        if (Physics.Raycast(ray, out RaycastHit hitinfo, 6f))
        {
            lineRenderer.enabled = true;
            lineRenderer.SetPosition(0, this.transform.position);
            lineRenderer.SetPosition(1, hitinfo.point);
        }
        else{
            lineRenderer.enabled = false;
        }
    }
}
