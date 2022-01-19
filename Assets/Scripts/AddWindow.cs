using UnityEngine;
using UnityEngine.UI;

public class AddWindow : MonoBehaviour
{
    [SerializeField]
    private InputField _nicknameField;

    [SerializeField]
    private InputField _scoreField;

    [SerializeField]
    private Button _addButton;

    [SerializeField]
    private NewScoreLineInitializer _newScoreLineInitializer;

    public void AddNewScoreLine()
    {
        bool success = int.TryParse(_scoreField.text, out _); //if it is int
        if (success)
        {
            _newScoreLineInitializer.InitNewScoreLine(_nicknameField.text, _scoreField.text);
            CloseAddWindow();
        }
    }

    public void OpenAddWindow()
    {
        GameManager.Instance.RemovingNow(false); //not to remove after opening add window
        gameObject.SetActive(true);
        _newScoreLineInitializer.gameObject.SetActive(false); //leaderboard
    }

    public void CloseAddWindow()
    {
        _nicknameField.text = ""; //not to see previous values
        _scoreField.text = "";
        _newScoreLineInitializer.gameObject.SetActive(true); //leaderboard
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (!string.IsNullOrEmpty(_nicknameField.text) && !string.IsNullOrEmpty(_scoreField.text)) //if both fields have values
            _addButton.interactable = true;
        else
            _addButton.interactable = false;
    }
}