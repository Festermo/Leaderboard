using UnityEngine;

public class RemoveButton : MonoBehaviour
{
    private GameManager _gameManager;

    public void Remove()
    {
        if (_gameManager.isRemoving == false)
            _gameManager.RemovingNow(true);
        else
            _gameManager.RemovingNow(false);
    }

    private void Start()
    {
        _gameManager = GameManager.Instance;
    }
}