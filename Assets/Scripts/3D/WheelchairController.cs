using UnityEngine;

public class WheelchairController : MonoBehaviour
{
    [SerializeField] private WheelCollider _leftWheelCollider;
    [SerializeField] private WheelCollider _rightWheelCollider;
    [SerializeField] private Transform _leftWheelTransform;
    [SerializeField] private Transform _rightWheelTransform;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _turnSpeed;
    [SerializeField] private float _turnSpeedFactor;

    private void FixedUpdate()
    {
        Move();
        UpdateWheelTransforms();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        _leftWheelCollider.motorTorque = moveInput * _moveSpeed;
        _rightWheelCollider.motorTorque = moveInput * _moveSpeed;

        if (turnInput != 0)
        {
            if (moveInput == 0)
            {
                _leftWheelCollider.motorTorque = turnInput * _turnSpeed;
                _rightWheelCollider.motorTorque = -turnInput * _turnSpeed;
            }
            else
            {
                float turnFactor = Mathf.Abs(moveInput) * _turnSpeedFactor;
                _leftWheelCollider.motorTorque += turnInput * turnFactor;
                _rightWheelCollider.motorTorque -= turnInput * turnFactor;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            _leftWheelCollider.brakeTorque = 3000f;
            _rightWheelCollider.brakeTorque = 3000f;
        }
        else
        {
            _leftWheelCollider.brakeTorque = 0;
            _rightWheelCollider.brakeTorque = 0;
        }
    }

    private void UpdateWheelTransforms()
    {
        UpdateWheelPose(_leftWheelCollider, _leftWheelTransform);
        UpdateWheelPose(_rightWheelCollider, _rightWheelTransform);
    }

    private void UpdateWheelPose(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 wheelPos;
        Quaternion wheelRot;
        wheelCollider.GetWorldPose(out wheelPos, out wheelRot);
        wheelTransform.position = wheelPos;
        wheelTransform.rotation = wheelRot;
    }
}
