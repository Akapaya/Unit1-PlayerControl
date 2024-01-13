using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _acceleration;
    [SerializeField] private float _maxAcceleration = 1;

    [SerializeField] private float _speed;

    [SerializeField] private float _breakForce = 0.8f;
    [SerializeField] private float _decelerationRate = 0.5f;

    [SerializeField] private float _turnSpeed = 1;
    [SerializeField] private float _turnRotateSpeed = 10;

    [SerializeField] private float _horizontalInput;
    [SerializeField] private float _verticalInput;

    public Types _horizontalType;
    public Types _verticalType;

    void Update()
    {
        Debug.Log(_verticalType.ToString());
        _verticalInput = Input.GetAxis(_verticalType.ToString());
        _horizontalInput = Input.GetAxis(_horizontalType.ToString());

        _acceleration = _verticalInput;

        if (Input.GetKey(KeyCode.Space))
        {
            Break();
        }
        else
        {
            if (_verticalInput > 0)
            {
                Accelerate();
            }
            else
            {
                if (_verticalInput < 0)
                {
                    Reverse();
                }
                else
                {
                    Decelerate();
                }
            }
        }

        if (_horizontalInput != 0 && _verticalInput != 0)
        {
            TurnVehicle();
        }

        transform.Translate(Vector3.forward * Time.deltaTime * (_speed * _acceleration));
    }

    private void TurnVehicle()
    {
        transform.Rotate(0, _turnRotateSpeed * _horizontalInput * Time.deltaTime, 0);
        transform.Translate(Vector3.right * Time.deltaTime * (_turnSpeed * _horizontalInput));
    }

    #region Actions Methods
    private void Accelerate()
    {
        if (_acceleration < _maxAcceleration)
        {
            _acceleration += Time.deltaTime;
        }
    }

    private void Reverse()
    {
        if (_acceleration > -_maxAcceleration)
        {
            _acceleration -= Time.deltaTime;
        }
    }

    private void Break()
    {
        if (_acceleration > 0)
        {
            _acceleration -= _breakForce;
        }
        else
        {
            if (_acceleration < 0)
            {
                _acceleration += _breakForce;
            }
        }
    }

    private void Decelerate()
    {
        if (_acceleration > 0)
        {
            _acceleration -= Time.deltaTime * _decelerationRate;
        }
        else if (_acceleration < 0)
        {
            _acceleration += Time.deltaTime * _decelerationRate;
        }
    }
    #endregion
}

public enum Types
{
    Horizontal, Vertical, Horizontal2, Vertical2
}