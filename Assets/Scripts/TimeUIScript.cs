using UnityEngine;
using TMPro;

public class TimeUIScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countDownText;
    [SerializeField] private float initialTime;
    
    private float currentTime = 0f;

    private void Start()
    {
        currentTime = initialTime;
        countDownText.text = $"Time left {currentTime.ToString()}";
    }

    private void Update()
    {
        CDTimerCalculation();
    }

    private void CDTimerCalculation()
    {
        if (currentTime <= 0)
        {
            EventHandler.InvokeOnTimeZero();
            return;
        }
        currentTime -= Time.deltaTime;
        countDownText.text = $"Time left {currentTime:0.00}";
    }
}
