using UnityEngine;
using UnityEngine.UI;

public class MicroscopeButton : MonoBehaviour
{
    private Button _microscope;
    private Vector3 _positionMicroButton;
    private GameObject _microscopeSlide;

    void Awake()
    {
        _microscope = GameObject.Find("AnimalCellButton").GetComponent<Button>();
        _microscopeSlide = GameObject.Find("Microscope01Slide");
        _positionMicroButton = _microscopeSlide.transform.position;
    }
    // Start is called before the first frame update
    void Start()
    {
        _microscope.transform.position = _positionMicroButton;
        
    }


    

    // Update is called once per frame
    void Update()
    {
        
    }
}
