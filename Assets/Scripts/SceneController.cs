using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using TMPro;

public class SceneController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timeCount, _attemptCount;
    [SerializeField] private GameObject _gameWindow, _lossWindow;
    [SerializeField] private CameraController _cameraController;
    [SerializeField] private ChunkController _chunkController;
    [SerializeField] private BallController _ballPrefabs;
    [SerializeField] private SaveFullGame _saveFullGame;
    private float _ballSpeed = 0.1f, _timeGame;
    private bool _startTimer;

    public static SceneController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
            Destroy(this.gameObject);
    }

    private void Update()
    {
        if (_startTimer)
            _timeGame += Time.deltaTime;
    }

    //Старт игры
    public void StartGame()
    {
        BallController ball = Instantiate(_ballPrefabs, transform.position, transform.rotation);
        _chunkController.StartChunkSpawner();
        _cameraController.StartCamera = true;
        _cameraController.Ball = ball;
        ball.Speed = _ballSpeed;
        _startTimer = true;
        _timeGame = 0f;
        _saveFullGame.Load();
    }

    //Конец игры
    public void LossGame()
    {
        _saveFullGame.CountAttempt++;
        _attemptCount.text = _saveFullGame.CountAttempt.ToString();
        _saveFullGame.Save();
        _timeCount.text = Mathf.Round(_timeGame).ToString();
        _cameraController.StartCamera = false;
        _chunkController.ChunkRestart();
        _gameWindow.SetActive(false);
        _lossWindow.SetActive(true);
    }

    //Выбор сложности игры
    public void EasyGame()
    {
        _ballSpeed = 0.1f;
    }

    public void AverageGame()
    {
        _ballSpeed = 0.2f;
    }

    public void ComplicatedGame()
    {
        _ballSpeed = 0.4f;
    }
}