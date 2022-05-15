using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour,IInterface
{
    [SerializeField] string _itemName;
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(GameObject owner, List<string> _inventory)
    {
        IInterface iif = owner.GetComponent<IInterface>();
        _audioSource.PlayOneShot(_clip);
        if (iif != null)
        {
            iif.AddInventory(_itemName);
        }
        Destroy(gameObject);
    }

    public void AddInventory(string itemName)
    {

    }
}
