using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{

    public Inventory Inventory;
    public GameObject MessagePanel
 
    void Start()
    {
        Inventory.ItemAdded += InventoryScript_ItemAdded;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
        Transform inventotyPanel = transform.Find("InventoryPanel");
        foreach(Transform slot in inventotyPanel)
        {
            Image image = slot.GetChild(0).GetChild(0).GetComponent<Image>();
        }
    }


    // void Update()
    // {

    // }



    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);
    }

     public void CloseMessagePanel(string text)
    {
        MessagePanel.SetActive(false);
    }


}
