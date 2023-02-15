using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.InputSystem;
using Debug = UnityEngine.Debug;
using UnityEngine.UI;
using System.Linq.Expressions;
using static UnityEditor.Progress;
using System;

public class RayController : MonoBehaviour
{
    [SerializeField]
    Ray ray;

    [SerializeField]
    LayerMask Target;
    private bool startquest = true;
    private bool progressquest = false;
    private bool endquest = false;
    private InputSettings _input;
    [SerializeField]
    GameObject start;
    [SerializeField]
    GameObject end;
    [SerializeField]
    GameObject progress;
    [SerializeField]
    Material selectionMaterial;
    [SerializeField]
    GameObject hand;
    [SerializeField]
    Material defaultnMaterial;
    [SerializeField]
    GameObject inventory;
    [SerializeField]
    GameObject cursorText;
    int emeralds = 6;
    // Update is called once per frame
    void Awake()
    {
        _input = new InputSettings();
        _input.Player.Hand.performed += _ => ShitchHand();
        start.SetActive(false);
        end.SetActive(false);
        progress.SetActive(false);
    }
    private void OnEnable()
    {
        _input.Enable();
    }

    private void OnDisable()
    {
        _input.Disable();
    }
    void FixedUpdate()
    {
        Debug.DrawRay(transform.position, transform.forward*20f);
        ray = new Ray(transform.position, transform.forward);
        DropItem();
        
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 20f))
        {
            if(hitinfo.transform.name == "villiager")
            {
                QuestVillage();
               
            }
            else if (hitinfo.transform.gameObject.GetComponent<UsableItem>())
            {
             
                ItemManager(hitinfo.transform.gameObject);
            }
            else
            {
                cursorText.GetComponent<Text>().text = " ";
            }
        }
        
        else
        {
            cursorText.GetComponent<Text>().text = " ";
            start.SetActive(false);
            end.SetActive(false);
            progress.SetActive(false);
        }
        //if (_input.Player.Hand.WasPerformedThisFrame())
       // {
         //   ShitchHand();
       // }
    }
    private void QuestVillage()
    {
        Inventory iventScript = inventory.GetComponent<Inventory>();
        if (startquest)
        {
            
            start.SetActive(true);
            if (_input.Player.MouseLeft.IsPressed())
            {
                startquest = false;
                progressquest = true;
                start.SetActive(false);
            }

        }
        else if (progressquest)
        {
            progress.SetActive(true);
            if (_input.Player.MouseLeft.IsPressed())
            {
                if (emeralds == 0)
                {
                    
                    progressquest = false;
                    endquest = true;
                    progress.SetActive(false);
                }
                else if (!iventScript.handIsFree)
                {
                    if(hand.transform.GetChild(0).gameObject.tag == "questItem")
                    {
                        GameObject item2 = hand.transform.GetChild(0).gameObject;
                        item2.transform.parent = null;
                        item2.GetComponent<Rigidbody>().isKinematic = false;
                        item2.GetComponent<Rigidbody>().useGravity = true;
                        Destroy(item2);
                        iventScript.handIsFree = true;
                        emeralds -= 1;
                        progress.GetComponent<Text>().text = "Need " + emeralds + " emeralds";
                    }
                    
                }
            }
            
        }
        else if (endquest)
        {
            end.SetActive(true);
        }

    }
    public void ItemManager(GameObject gameObject)
    {
        
        Inventory iventScript =  inventory.GetComponent<Inventory>();
        if (iventScript.lastSlot)
        {
            int slot = iventScript.inventory[iventScript.lastSlot];
            if (iventScript.inventoryItems[slot] == null)
            {
                cursorText.GetComponent<Text>().text = "Press 'E' to take item";
                if (_input.Player.ActionButton.IsPressed())
                {
                    inventory.GetComponent<Inventory>().PushSlot(gameObject);
                    return;
                }
            }
            else 
            {
                cursorText.GetComponent<Text>().text = "Slot full";
                return;
            }
        }
        else
        {
            cursorText.GetComponent<Text>().text = " ";
            return;
        }
        
    }
    public void DropItem()
    {
        Inventory iventScript = inventory.GetComponent<Inventory>();
        if (_input.Player.Drop.IsPressed())
        {
            if (iventScript.inventoryItems[iventScript.inventory[iventScript.lastSlot]] != null)
            {
                GameObject item = iventScript.RepelSlot();
                item.SetActive(true);
                item.transform.position = new Vector3(transform.root.position.x, transform.root.position.y +2, transform.root.position.z);

                item.GetComponent<Rigidbody>().AddForce(transform.parent.forward * 10f, ForceMode.Impulse);
            }
            
        }
    }
    public void ShitchHand()
    {
        Inventory iventScript = inventory.GetComponent<Inventory>();
       
            if (iventScript.handIsFree)
            {
                if (iventScript.inventoryItems[iventScript.inventory[iventScript.lastSlot]] != null)
                {
                    GameObject item = iventScript.RepelSlot();
                    item.SetActive(true);
                    item.transform.SetParent(hand.transform);
                    item.GetComponent<Rigidbody>().isKinematic = true;
                    item.GetComponent<Rigidbody>().useGravity = false;
                    
                    item.transform.position = hand.transform.position;
                    
                    iventScript.handIsFree = false;
                    return ;
                }
                else
                {
                    cursorText.GetComponent<Text>().text = "Slot empty";
                    return;
                }
            }
            else if(!iventScript.handIsFree)
            {
                if (iventScript.inventoryItems[iventScript.inventory[iventScript.lastSlot]] == null)
                {


                    GameObject item2 = hand.transform.GetChild(0).gameObject;
                    item2.transform.parent = null;
                    item2.GetComponent<Rigidbody>().isKinematic = false;
                    item2.GetComponent<Rigidbody>().useGravity = true;
                    
                    inventory.GetComponent<Inventory>().PushSlot(item2);
                    iventScript.handIsFree = true;
                    return;

                }
                else
                {
                    cursorText.GetComponent<Text>().text = "Hand full";
                    return;
                }
                
            
            
        }
    }
}
