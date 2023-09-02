using System.Collections;
using UnityEngine;

public class PendulumTouch : MonoBehaviour
{
    private Quaternion _start, _end, _beginning;
    private Coroutine _pushPendulum;
    private Coroutine _pendulumSwing;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float _angle = 45.0f;

    [SerializeField]
    [Range(0.0f, 360.0f)]
    private float _speed = 2.0f;

    [SerializeField]
    [Range(0.0f, 10.0f)]
    private float _startTime = 0.0f;

    private int _countWaving = 0;

    public bool IsHoverOvered { get; set; }

    void Start()
    {

        //_ball = GameObject.Find("Ball");
        _beginning = PendulumRotation(0);
        //_start = PendulumRotation(_angle);
        _start = PendulumRotation(-_angle);
        _end = PendulumRotation(_angle);

        if (IsHoverOvered)
        {
            // StartCoroutine(NameOfCoroutine())
            //Debug.Log("Pendulum: First wave");
            //transform.rotation = Quaternion.Lerp(_end, _beginning, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
            StartCoroutine("PendulumSwing");
        }
    }
    // w starcie wywolanie metody, która wystartuje wahad³o
    // wzi¹æ GameObject "Ball"
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
    IEnumerator WaitForFunction()
    {
        yield return new WaitForSeconds(3);
        Debug.Log("Hello!");
    }

    //IEnumerator PendulumSwing()
    //{
    //    int numberOfSwings = 0;
    //    while (numberOfSwings < 1)
    //    {
    //        transform.rotation = Quaternion.Lerp(_end, _beginning, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    //        numberOfSwings++;
    //        Debug.Log("");
    //        yield return null;
    //    }
    //    yield return transform.rotation = Quaternion.Lerp(_end, _start, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    //}
    IEnumerator PendulumSwing()
    {
        int numberOfSwings = 0;
        while (numberOfSwings < 1)
        {
            transform.rotation = Quaternion.Lerp(_beginning, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
            numberOfSwings++;
            Debug.Log($"Number of swings is {numberOfSwings}");
            yield return null;
        }
        yield return transform.rotation = Quaternion.Lerp(_end, _start, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }
    //IEnumerator PushPendulum()
    //{

    //}
    public void StartThePendulum()
    {
        Debug.Log("Collision in pendulum was detected");
        _startTime += Time.deltaTime;
        transform.rotation = Quaternion.Lerp(_end, _start, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
        //transform.rotation = Quaternion.Lerp(_start, _end, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
    }
    void Update()
    {
        if (IsHoverOvered)
        {   
            StartThePendulum();
        }
        
        //_startTime += Time.deltaTime;
        // ..
        // ..
        //transform.rotation = Quaternion.Lerp(_end, _start, (Mathf.Sin(_startTime * _speed + Mathf.PI / 2) + 1.0f) / 2.0f);
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