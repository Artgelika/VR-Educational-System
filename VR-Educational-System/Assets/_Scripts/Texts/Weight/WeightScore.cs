using TMPro;
using UnityEngine;

public class WeightScore : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public WeightScale weightResults;

    void Start()
    {
        scoreText.text = weightResults.calculatedMass.ToString("f2");
    }

    void Update()
    {
        scoreText.text = weightResults.calculatedMass.ToString("f2");
    }
}