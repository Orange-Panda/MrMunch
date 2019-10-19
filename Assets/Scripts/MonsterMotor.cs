using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Monster movement
/// </summary>
public class MonsterMotor : MonoBehaviour
{
    [SerializeField] private Material _unselected;
    [SerializeField] private Material _selected;

    [SerializeField] private Camera _characterCamera;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotateSpeed;

    //[SerializeField] private HandIK _leftHand;
    //[SerializeField] private HandIK _rightHand;

    private CharacterController _controller;

    private int _layerMask;
    private bool _isGrounded = false;

    //private float yDir;
    //private float gravity = 2f;
    
    private void Start()
    {
        _controller = GetComponent<CharacterController>();

        _layerMask = LayerMask.GetMask("Player");
        _layerMask = ~_layerMask;
    }
    
    private void Update()
    {
        // get input
        var input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Multiply by camera orientation
        Vector3 correctedHorizontal = input.x * _characterCamera.transform.right;
        Vector3 correctedVertical = input.y * _characterCamera.transform.forward;

        // Combine
        Vector3 combinedInput = correctedHorizontal + correctedVertical;

        // normalize the direction and remove the y component from the vector
        var moveDirection = new Vector3((combinedInput).normalized.x, 0, (combinedInput).normalized.z);

        // Get an overall magnitude and amount for animation (and for analog controls)
        float inputMagnitude = Mathf.Abs(input.x) + Mathf.Abs(input.y);
        var inputAmount = Mathf.Clamp01(inputMagnitude);

        // rotate player to movement direction smoothly
        Quaternion rotation = Quaternion.identity;
        if (moveDirection != Vector3.zero) rotation = Quaternion.LookRotation(moveDirection);
        Quaternion targetRotation = Quaternion.Slerp(transform.rotation, rotation, Time.fixedDeltaTime * inputAmount * _rotateSpeed);
        transform.rotation = targetRotation;
        
        _animator.SetBool("Moving", inputMagnitude != 0);

        //if (Physics.Raycast(transform.position, Vector3.down, out RaycastHit hit, 10f, _layerMask))
        //{
        //    _isGrounded = !(hit.distance > .4f);
        //}
        //else _isGrounded = false;

        //if (!_isGrounded) yDir -= gravity;
        //else yDir = 0;

        //transform.position += new Vector3(0, yDir, 0);

        // Ideally you'd set the animator stuff now but we don't have that yet
        transform.position += moveDirection * Time.deltaTime * inputAmount * _moveSpeed;
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.CompareTag("Consumable"))
    //    {
    //        Debug.Log("Found consumable");

    //        var consumable = other.GetComponent<Consumable>();

    //        other.GetComponent<Renderer>().material = _selected;

    //        if (consumable is null)
    //        {
    //            Debug.LogWarning("Object was tagged as consumable but wasn't");
    //            return;
    //        }

    //        if (consumable.Flagged) return;

    //        // Determine which side of the sphere it is on
    //        var heading = transform.position - other.transform.position;
    //        var dotProduct = Vector3.Dot(heading, transform.right);

    //        // might have the direction wrong
    //        dotProduct *= -1;

    //        // Tell hand to grab
    //        if (dotProduct > 0)         // to the right
    //        {
    //            _rightHand.Grab(consumable);
    //        }
    //        else if (dotProduct < 0)    // to the left
    //        {
    //            _leftHand.Grab(consumable);
    //        }
    //        else                        // in center 
    //        {
    //            _leftHand.Grab(consumable);
    //        }
    //    }
    //}
}
