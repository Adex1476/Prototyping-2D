using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private PlayerData _pd;
    private GameObject _player;

    [SerializeField] private Text _fpsText;
    [SerializeField] private TextMeshPro _playerInfo;
    [SerializeField] private float _hudRefreshRate = 1f;
    private float _timer;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");

        _pd = _player.GetComponent<PlayerData>();
        _playerInfo.text = _pd.PlayerName;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            _fpsText.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}
