using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    [SerializeField] private float[] _offSetX;
    [SerializeField] private float[] _offSetY;
    [SerializeField] private float[] _offSetZ;

    [SerializeField] private int _indexCamera;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (_indexCamera < _offSetX.Length -1)
            {
                _indexCamera++;
            }
            else
            {
                _indexCamera = 0;
            }
        }
    }

    void LateUpdate()
    {
        transform.position = _player.transform.position + new Vector3(_offSetX[_indexCamera], _offSetY[_indexCamera], _offSetZ[_indexCamera]);
    }
}