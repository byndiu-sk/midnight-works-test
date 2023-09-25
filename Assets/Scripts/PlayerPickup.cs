using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    [SerializeField]
    private float pickupRange;
    [SerializeField]
    private LayerMask pickupLayer;

    private Camera cam;
    private Inventory inventory;

    private void Awake()
    {
        cam = Camera.main;
        inventory = GetComponent<Inventory>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            RaycastHit hit;

            {
                if (Physics.Raycast(ray, out hit, pickupRange, pickupLayer))
                {
                    Debug.Log("Hit: " + hit.transform.name);
                    Weapon newItem = hit.transform.GetComponent<ItemObject>().item as Weapon;
                    inventory.AddItem(newItem);
                    Destroy(hit.transform.gameObject);
                }
            }
        }
    }
}
