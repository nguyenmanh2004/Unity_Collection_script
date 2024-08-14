using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementJoystick : MonoBehaviour
{
    public Joystick _MovementJoystick;
    public float speed;
    public Rigidbody2D _Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_MovementJoystick.Direction.y != 0)
        {
            _Rigidbody.velocity = new Vector2(_MovementJoystick.Direction.x * speed, _MovementJoystick.Direction.y * speed);
        }
        else 
        {
            _Rigidbody.velocity = Vector2.zero;
        }
    }
}
