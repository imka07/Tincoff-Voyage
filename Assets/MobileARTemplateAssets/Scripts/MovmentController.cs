using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(BoxCollider))]
public class MovmentController : MonoBehaviour
{

    [Header("Controller Settinggs")]
    private Rigidbody _rigidbody;
    private DynamicJoystick _joystick;
    public  Animator anim;
    public float _moveSpeed;


    private void Start()
    {
        _joystick = FindObjectOfType<DynamicJoystick>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector3(_joystick.Horizontal * _moveSpeed, _rigidbody.velocity.y, _joystick.Vertical * _moveSpeed);

        if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
        {
            transform.rotation = Quaternion.LookRotation(_rigidbody.velocity);
            anim.SetBool("isWalking", true);
        }
        else
            anim.SetBool("isWalking", false);
    }

}
