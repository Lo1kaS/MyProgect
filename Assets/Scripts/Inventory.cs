using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventoryItems;
    [SerializeField]
    static GameObject Slot1;
    [SerializeField]
    static GameObject Slot2;
    [SerializeField]
    static GameObject Slot3;
    [SerializeField]
    static GameObject Slot4;
    [SerializeField]
    public bool handIsFree = true;
    public GameObject lastSlot = null;
    private InputSettings _input;
    public Dictionary<GameObject, int> inventory;
    
    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    void Awake()
    {
        _input = new InputSettings();
    }
    void Start()
    {
        Slot1 = this.transform.GetChild(0).gameObject;
        
        Slot2 = this.transform.GetChild(1).gameObject;
        Slot3 = this.transform.GetChild(2).gameObject;
        Slot4 = this.transform.GetChild(3).gameObject;
        inventory = new Dictionary<GameObject, int>()
    {
        {Slot1,0 },
        {Slot2,1 },
        {Slot3,2 },
        {Slot4,3 }


    };
       inventoryItems
         = new List<GameObject>( inventory.Count);

        inventoryItems.Add(null);
        inventoryItems.Add(null);
        inventoryItems.Add(null);
        inventoryItems.Add(null);
        Select(Slot1);
    }


    void Update()
    {
        if (_input.Inventory.Slot1.IsPressed())
        {
            Select(Slot1);
        }
        else if (_input.Inventory.Slot2.IsPressed())
        {
            Select(Slot2);
        }
        else if (_input.Inventory.Slot3.IsPressed())
        {
            Select(Slot3);
        }
        else if (_input.Inventory.Slot4.IsPressed())
        {
            Select(Slot4);
        }
        
    }
    private void Select(GameObject slot)
    {
        GameObject targetSlot = slot;
        if (lastSlot)
        {
            Unselect(lastSlot);
        }
        targetSlot.GetComponent<Image>().color = Color.green;
        lastSlot = targetSlot;
        
    }
    private void Unselect(GameObject lastSlot)
    {
        lastSlot.GetComponent<Image>().color = Color.white;
        return;
    }
    public void PushSlot(GameObject item)
    {
        inventoryItems[inventory[lastSlot]] = item;
        lastSlot.transform.GetChild(0).GetComponent<RawImage>().texture = item.GetComponent<UsableItem>().inventoryTexture;
        item.SetActive(false);
        
    }
    public GameObject RepelSlot()
    {
        GameObject item = inventoryItems[inventory[lastSlot]];
        inventoryItems[inventory[lastSlot]] = null;
        lastSlot.transform.GetChild(0).GetComponent<RawImage>().texture = null;
        return item;
    }
}
