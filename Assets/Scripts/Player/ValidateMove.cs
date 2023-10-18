using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValidateMove : MonoBehaviour
{
    [SerializeField] private float _limit;
    [SerializeField] private float _rotationSpeed = 5;

    private Vector2 _direction = Vector2.zero;

    public void CheckValidateToMove()
    {
        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, -_limit, _limit);
        clampPosition.z = Mathf.Clamp(clampPosition.z, -_limit, _limit);
        transform.position = clampPosition;

        var currentRotation = transform.rotation;
        var targetRotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(_direction.x, _direction.y) * 360 / Mathf.PI, 0));
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, Time.deltaTime * _rotationSpeed);
    }

    public void CheckRotate()
    {
        Vector3 clampPosition = transform.position;
        clampPosition.x = Mathf.Clamp(clampPosition.x, -_limit, _limit);
        clampPosition.z = Mathf.Clamp(clampPosition.z, -_limit, _limit);
        transform.position = clampPosition;

        //if (transform.rotation.y < -_rotateY)
        //{
        //    transform.rotation = Quaternion.Euler(0, -90, 0);
        //}
        //else if (transform.rotation.y > _rotateY)
        //{
        //    transform.rotation = Quaternion.Euler(0, 90, 0);
        //}
    }
}
