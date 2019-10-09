using UnityEngine;
using UnityEngine.UI;

public class SampleViewController : MonoBehaviour
{
    public Text FeedbackText;
    public Button ButtonTestInternet;

    private ConnectionTester _connectionTester;
    void Start()
    {
        _connectionTester = ConnectionTester
            .GetInstance(gameObject)
            .ipToTest("www.google.com");
        
        ButtonTestInternet.onClick.AddListener(() =>
        {
            ShowFeedback("Starting test");
            _connectionTester.TestInternet(hasInternet =>
            {
                ShowFeedback($"Has internet connection: {hasInternet}");
            });
        });

    }

    void ShowFeedback(string text)
    {
        FeedbackText.text = text;
    }
}
