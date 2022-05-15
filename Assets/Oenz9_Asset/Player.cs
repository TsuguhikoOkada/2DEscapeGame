using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IInterface
{
    Rigidbody2D _rb;
    [SerializeField] float _speed = 20.0f;
    [Header("Interact")]
    [SerializeField] float _startLength = 1.0f;
    [SerializeField] float _endLength = 10.0f;
    [SerializeField] bool _debug;

    private Vector3 latestPos;  //前回のPosition
    private Vector2 cachedDirection;

    public List<string> _inventory;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0.0f;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.E))
        {
            InteractAction();
        }
    }

    public void InteractAction()
    {
        Vector2 start = (Vector2)transform.position + (Vector2)transform.up * _startLength;
        Vector2 end = (Vector2)transform.position + (Vector2)transform.up * _endLength;
        
        if(_debug) Debug.DrawLine(start, end, Color.red, 5.0f);

        RaycastHit2D hit = Physics2D.Linecast(start, end);
        if (hit.collider != null)
        {
            IInterface iif = hit.collider.gameObject.GetComponent<IInterface>();
            if (iif != null)
            {
                iif.Interact(this.gameObject, _inventory);
            }
        }
    }

    private void FixedUpdate()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        print(vertical);
        Vector2 Dir = new Vector2(horizontal, vertical).normalized;
        _rb.velocity = (Dir * _speed);

        if (Dir.magnitude > 0.1)
        {
            cachedDirection = Dir;
        }
        transform.up = cachedDirection;

        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;  

    }

    
    public void Interact(GameObject owner, List<string> _inventory)
    {

    }

    public void AddInventory(string itemName)
    {
        _inventory.Add(itemName);
    }
}