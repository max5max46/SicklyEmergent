using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private Toggle chaseModeToggle;
    [SerializeField] private Slider totalSlider;
    [SerializeField] private TextMeshProUGUI totalSliderText;
    [SerializeField] private Slider startingIllSlider;
    [SerializeField] private TextMeshProUGUI startingIllSliderText;
    [SerializeField] private Slider healthySpeedSlider;
    [SerializeField] private TextMeshProUGUI healthySpeedSliderText;
    [SerializeField] private Slider illSpeedSlider;
    [SerializeField] private TextMeshProUGUI illSpeedSliderText;
    [SerializeField] private Slider disFromHealthySlider;
    [SerializeField] private TextMeshProUGUI disFromHealthySliderText;
    [SerializeField] private Slider disFromIllSlider;
    [SerializeField] private TextMeshProUGUI disFromIllSliderText;
    [SerializeField] private Slider timeToGetIllSlider;
    [SerializeField] private TextMeshProUGUI timeToGetIllSliderText;
    [SerializeField] private Slider disToGetIllSlider;
    [SerializeField] private TextMeshProUGUI disToGetIllSliderText;

    [Header("Script References")]
    [SerializeField] private SicklingsManager sicklingsManager;
    [SerializeField] private GameObject optionPanel;
    [SerializeField] private GameObject unhideButton;

    private bool isHidden;

    void Awake()
    {
        optionPanel.SetActive(true);
        unhideButton.SetActive(false);
        isHidden = false;
        Reset();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Hide()
    {
        isHidden = true;
        optionPanel.SetActive(false);
        unhideButton.SetActive(true);
    }

    public void Unhide()
    {
        isHidden = false;
        optionPanel.SetActive(true);
        unhideButton.SetActive(false);
    }

    public void Reset()
    {
        SetVariables();
        sicklingsManager.ResetArrays();
        sicklingsManager.StartSim();
    }

    // Update is called once per frame
    void Update()
    {
        startingIllSlider.maxValue = totalSlider.value;

        totalSliderText.text = totalSlider.value.ToString();
        startingIllSliderText.text = startingIllSlider.value.ToString();
        healthySpeedSliderText.text = healthySpeedSlider.value.ToString("F2");
        illSpeedSliderText.text = illSpeedSlider.value.ToString("F2");
        disFromHealthySliderText.text = disFromHealthySlider.value.ToString("F2");
        disFromIllSliderText.text = disFromIllSlider.value.ToString("F2");
        timeToGetIllSliderText.text = timeToGetIllSlider.value.ToString("F2");
        disToGetIllSliderText.text = disToGetIllSlider.value.ToString("F2");
    }



    public void SetVariables()
    {
        sicklingsManager.chaseMode = chaseModeToggle.isOn;
        sicklingsManager.amountOfSicklings = (int)totalSlider.value;
        sicklingsManager.amountOfIllSicklings = (int)startingIllSlider.value;
        sicklingsManager.healthySpeed = healthySpeedSlider.value;
        sicklingsManager.illSpeed = illSpeedSlider.value;
        sicklingsManager.distanceToKeepFromSicklings = disFromHealthySlider.value;
        sicklingsManager.distanceToKeepFromIllSicklings = disFromIllSlider.value;
        sicklingsManager.timeToGetIll = timeToGetIllSlider.value;
        sicklingsManager.distanceToGetIll = disToGetIllSlider.value;
    }
}
