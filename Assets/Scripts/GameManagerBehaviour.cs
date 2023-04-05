using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManagerBehaviour : MonoBehaviour
{
    [SerializeField]
    private FlapBehaviour _player;
    [SerializeField]
    private GameObject _deathScreen;

    private static int _score;

    public static int Score { get => _score; set => _score = value; }

    private void Start()
    {
        _score = 0;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!_player.IsAlive)
            _deathScreen.SetActive(true);
    }
}
