using UnityEngine;
using UnityEngine.UI;

public class EditWindow : MonoBehaviour
{
    [SerializeField]
    private InputField _nicknameField;

    [SerializeField]
    private InputField _scoreField;

    [SerializeField]
    private Button _editButton;

    [SerializeField]
    private GameObject _leaderboard;

    [SerializeField]
    private LeaderboardSorter _leaderboardSorter;

    private ScoreLine _currentScoreLine;

    public void Edit()
    {
        bool success = int.TryParse(_scoreField.text, out _);
        if (success)
        {
            _currentScoreLine.SetNickname(_nicknameField.text);
            _currentScoreLine.SetScore(_scoreField.text);
            _leaderboardSorter.SortScores();
            CloseEditWindow();
        }
    }

    public void CloseEditWindow()
    {
        _nicknameField.text = ""; //not to see previous values 
        _scoreField.text = "";
        gameObject.SetActive(false);
        _leaderboard.SetActive(true);
    }

    public void SetCurrentScoreLine(ScoreLine value) //to edit needed scoreLine
    {
        _currentScoreLine = value;
    }

    private void Update()
    {
        if (!string.IsNullOrEmpty(_nicknameField.text) && !string.IsNullOrEmpty(_scoreField.text)) //if both fields have values
            _editButton.interactable = true;
        else
            _editButton.interactable = false;
    }
}