using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Inventory : MonoBehaviour
{
    //0 = primary, 1 = secondarym, 2 = melle
    private Weapon[] weapons;

    private void Start()
    {
        Init();
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.T))
    //    {
    //        AddItem(testWeapon);
    //    }
    //}

    public void Init()
    {
        weapons = new Weapon[3];
    }

    public void AddItem(Weapon newItem)
    {
        int newItemIndex = (int)newItem.weaponStyle;

        if (weapons[newItemIndex] != null)
        {
            RemoveItem(newItemIndex);
        }
        weapons[newItemIndex] = newItem;
    }

    public void RemoveItem(int index)
    {
        weapons[index] = null;
    }

    public Weapon GetItem(int index)
    {
        return weapons[index];
    }
}
