using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Quaternion _start, _end;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float _angle = 45.0f;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float _speed = 2.0f;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float _startTime = 0.0f;

    void Start()
    {
        _start = PendulumRotation(_angle);
        _end = PendulumRotation(-_angle);
    }

    void Update()
    {
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {

    }
    void ResetTimer()
    {
        _startTime = 0.0f;
    }

    Quaternion PendulumRotation(float angle)
    {
        var pendulumRotation = transform.rotation;
        var angleZ = pendulumRotation.eulerAngles.z + angle;

        if (angleZ > 180)
            angleZ -= 360;
        else if (angleZ < -180)
            angleZ += 360;

        pendulumRotation.eulerAngles = new Vector3(pendulumRotation.eulerAngles.x, pendulumRotation.eulerAngles.y, angleZ);
        return pendulumRotation;
    }
}