using UnityEngine;
using UnityEngine.UI;

public class ScoreLine : MonoBehaviour
{
    [SerializeField]
    private Text _nickname;

    public Text nickname => _nickname;

    [SerializeField]
    private Text _score;

    public Text score => _score;

    [SerializeField]
    private Text _place;

    public Text place => _place;

    [SerializeField]
    private Collider _collider;

    private GameManager _gameManager;

    public void SetNickname(string value)
    {
        _nickname.text = value;
    }

    public void SetScore(string value)
    {
        _score.text = value;
    }

    public void SetPlace(string value)
    {
        _place.text = value;
    }

    private void Awake()
    {
        _gameManager = GameManager.Instance;
    }

    void Update()
    {
        if (_collider.bounds.Contains(Input.mousePosition) && Input.GetMouseButtonDown(0) && _gameManager.isRemoving == true) //if left mouse button was clicked on scoreline after pressing remove
        {
            _gameManager.RemovingNow(false); //not to continue removing
            _gameManager.scoreLines.Remove(this);
            _gameManager.leaderboardSorter.SortScores();
            Destroy(gameObject);
        }
        if (Input.GetMouseButtonDown(1) && _collider.bounds.Contains(Input.mousePosition)) //if right mouse button  was clicked on scoreline 
        {
            _gameManager.OpenEditWindow(this);
        }
    }
}