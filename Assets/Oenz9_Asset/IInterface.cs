using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInterface
{
    void Interact(GameObject owner, List<string> _inventory);

    void AddInventory(string itemName);
}

