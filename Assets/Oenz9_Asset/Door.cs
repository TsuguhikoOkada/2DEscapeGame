using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInterface
{
    [SerializeField] string _needItemName;
    [SerializeField] Animator _animator;
    [SerializeField] string _animationName;
    [SerializeField] AudioClip _clip;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] bool isDestoroy;
    bool _acitived;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Action()
    {
        if (isDestoroy)
        {
            Destroy(gameObject);
            _audioSource.PlayOneShot(_clip);
            return;
        }
        _acitived = true;
        GetComponent<BoxCollider2D>().enabled = false;
        _animator.Play(_animationName);
        _audioSource.PlayOneShot(_clip);

    }

    public void Interact(GameObject owner, List<string> _inventory)
    {
        if (_acitived) return;
        foreach(string temp in _inventory)
        {
            if(temp == _needItemName)
            {
                Action();
                break;
            }
        }
        if (_needItemName == "")
        {
            Action();
        }
    }



    public void AddInventory(string itemName)
    {

    }
}
