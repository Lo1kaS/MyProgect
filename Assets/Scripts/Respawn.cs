using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    GameObject  SpawnPoint;
    public bool unstatic = false;
    private InputSettings _input;
    private void Awake()
    {
        _input = new InputSettings();
        
        //_input.Player.Respawn.performed += context => RespawnPlayer();
       
    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }


    private void Update()
    {
        if (_input.Player.Respawn.IsInProgress())
        {
            unstatic = true;   
            RespawnPlayer();
        }
    }
    void RespawnPlayer()
    {

        gameObject.transform.position = SpawnPoint.transform.position;
  
        unstatic = false;



    }

}
