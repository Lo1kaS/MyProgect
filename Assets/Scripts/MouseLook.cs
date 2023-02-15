using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class MouseLook : MonoBehaviour
{
    [FormerlySerializedAs("MouseSensitivity")] [SerializeField]
    private float mouseSensitivityX = 10f;
    private float mouseSensitivityY = 10f;
    [SerializeField]
    public Transform playerBody;

    float _xRotation = 0f;
    private InputSettings _input;


    Vector2 MouseInput;

    float mouseX;
    float mouseY;

    private void Awake()
    {
        _input = new InputSettings();
        _input.Player.MouseX.performed += ctx => MouseInput.x = ctx.ReadValue<float>();
        _input.Player.MouseY.performed += ctx => MouseInput.y = ctx.ReadValue<float>();
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
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void ReceiveInput(Vector2 mouseInput)
    {
        mouseX = mouseInput.x * mouseSensitivityX * Time.deltaTime;
        mouseY = mouseInput.y * mouseSensitivityY * Time.deltaTime;

        _xRotation -= mouseY;
        _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);


        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

   
    void Update()
    {
        ReceiveInput(MouseInput);





    }
}
