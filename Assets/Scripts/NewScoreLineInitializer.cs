using UnityEngine;

public class NewScoreLineInitializer : MonoBehaviour
{ 
    [SerializeField]
    private GameObject _scoreLinePrefab;

    [SerializeField]
    private GameObject _scrollRect;

    [SerializeField]
    private LeaderboardSorter _leaderboardSorter;

    public void InitNewScoreLine(string nickname, string score)
    {
        GameObject newScoreLine = Instantiate(_scoreLinePrefab);
        ScoreLine scoreLineContent = newScoreLine.GetComponent<ScoreLine>();
        Transform scrollRectContent = _scrollRect.transform.GetChild(0).transform;
        newScoreLine.transform.SetParent(scrollRectContent, false); //to add it to scrollrect
        scoreLineContent.SetNickname(nickname);
        scoreLineContent.SetScore(score);
        GameManager.Instance.scoreLines.Add(scoreLineContent);
        _leaderboardSorter.SortScores();
    }
}