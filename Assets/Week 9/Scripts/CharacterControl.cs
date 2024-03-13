using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CharacterControl : MonoBehaviour
{
    public static Villager SelectedVillager { get; private set; }
    public TextMeshProUGUI villagerTypeText;

    void Start()
    {
            UpdateSelectedVillager();
    }

    public static void SetSelectedVillager(Villager villager)
    {
        if(SelectedVillager != null)
        {
            SelectedVillager.Selected(false);
        }
        SelectedVillager = villager;
        if (SelectedVillager != null)
        {
            SelectedVillager.Selected(true);
        }
        
    }

    private static void UpdateSelectedVillager() {
        if (SelectedVillager != null)
        {
            //villagerTypeText.text = SelectedVillager.GetVillagerType().ToString();
        }
        else
        {
            //villagerTypeText.text = "No Selection";
        }
    }
}
   
