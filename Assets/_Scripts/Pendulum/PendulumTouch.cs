using UnityEngine;

public class PendulumTouch : MonoBehaviour
{

    private Quaternion _start, _end, _beginning;
    //private GameObject _ball;

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
        //_ball = GameObject.Find("Ball");
        //_beginning = PendulumRotation(0);
        //_start = PendulumRotation(_angle);
        _start = PendulumRotation(0);
        _end = PendulumRotation(-_angle);
    }
    // w starcie wywolanie metody, kt�ra wystartuje wahad�o
    // wzi�� GameObject "Ball"
    // OnTriggerEnter - jak sie dotknie pilki, to wahadlo sie rusza

    //private void OnTriggerEnter(Collider collision)
    //{
    //    if (collision.gameObject.name == "Ball")
    //    {
    //        Debug.Log("Collision in pendulum was detected");
    //        _startTime += Time.deltaTime;
    //        transform.rotation = Quaternion.Lerp(_end, _start, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    //    }
    //}

    public void StartThePendulum()
    {
        Debug.Log("Collision in pendulum was detected");
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_end, _start, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }
    void Update()
    {
        StartThePendulum();
        //_startTime += Time.deltaTime;
        // ..
        // ..
        //transform.rotation = Quaternion.Lerp(_end, _start, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
     }

    private void OnCollisionEnter(Collision collision)
    {

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
        // ..
        // ..
        // ..
        return pendulumRotation;
    }

    public void PendulumTouched(bool pressed)
    {
        //if (pressed)
    }


}