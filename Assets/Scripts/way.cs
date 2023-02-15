using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
public class way : MonoBehaviour
{
    [SerializeField]
    GameObject Point;
    [SerializeField]
    GameObject Player;
    private InputSettings _input;
    private NavMeshAgent NavMeshAgent;
    void Awake()
    {
        _input = new InputSettings();
        NavMeshAgent = GetComponent<NavMeshAgent>();    
    }  
    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_input.Player.Way.IsPressed())
        {
            transform.position = Player.transform.position;
            NavMeshAgent.SetDestination(Point.transform.position);
        }
    }
}
