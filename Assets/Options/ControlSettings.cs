using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

using UnityEngine.InputSystem;

public class ControlSettings : MonoBehaviour
{
    private const string saveKey = "ControlSettings";

    [SerializeField]
    private Button ForwordKey;
    
    [SerializeField]
    private Button BackwardKey;
    
    [SerializeField]
    private Button LeftKey;
    
    [SerializeField]
    private Button RightKey;   
    
    [SerializeField]
    private Button AttackKey;   

    [SerializeField]
    private Button ActiveItem;

    [SerializeField]
    private GameObject PressKeyPanel;
    private InputSettings _input;

    
    private void Awake()
    {
        _input = new InputSettings();
        var Move = _input.Player.Move.ChangeBinding("Move");
     

    }

    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
     }


        private void Start()
    {

        PressKeyPanel.SetActive(false);
    }

    private void Update()
    {


    }
    public void RebindKey(string LineName)
    {

        
    }




    public void Forward()
    {



    }




    private void Load()
    {
        var data = SaveManager.Load<SaveData.SavePropertis.VideoSettings>(saveKey);




    }
    private void Save()
    {
        SaveManager.Save(saveKey, GetSaveSnapshots());
    }

    private SaveData.SavePropertis.VideoSettings GetSaveSnapshots()
    {
        var data = new SaveData.SavePropertis.VideoSettings()
        {

        };
        return data;
    }
}
