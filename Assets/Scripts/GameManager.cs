using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<ScoreLine> scoreLines;

    [SerializeField]
    private EditWindow _editWindow;

    [SerializeField]
    private GameObject _leaderBoard;

    private bool _isRemoving;

    public bool isRemoving => _isRemoving; //after remove button was pressed

    [SerializeField]
    private LeaderboardSorter _leaderboardSorter;

    public LeaderboardSorter leaderboardSorter => _leaderboardSorter;

    #region Singleton

    public static GameManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion 

    public void OpenEditWindow(ScoreLine scoreLineToEdit)
    {
        _editWindow.gameObject.SetActive(true);
        _leaderBoard.SetActive(false);
        _editWindow.SetCurrentScoreLine(scoreLineToEdit);
        _isRemoving = false;
    }

    public void RemovingNow(bool value)
    {
        _isRemoving = value;
    }
}