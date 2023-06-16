using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SensitivitySliderScript : MonoBehaviour
{
    public Slider slider;
    public string sensitivityFilePath = "sensitivity.txt";

    public static event System.Action<float> OnSensitivityChanged;

    public static SensitivitySliderScript Instance { get; private set; }

    private float sensitivity;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        if (File.Exists(sensitivityFilePath))
        {
            string sensitivityValue = File.ReadAllText(sensitivityFilePath);
            float.TryParse(sensitivityValue, out sensitivity);
        }
        else
        {
            sensitivity = 0.5f;
        }

        slider.value = sensitivity;
        slider.onValueChanged.AddListener(UpdateSensitivity);
    }

    private void UpdateSensitivity(float newValue)
    {
        sensitivity = newValue;
        File.WriteAllText(sensitivityFilePath, sensitivity.ToString());

        OnSensitivityChanged?.Invoke(sensitivity);
    }
}
