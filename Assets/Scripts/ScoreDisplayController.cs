﻿using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreDisplayController : MonoBehaviour {
    public Text ScoreText;
    public Text TimeleftText;
    public Text LevelText;

    public string ScoreFormat;
    public string TimeLeftFormat;
    public string LevelTextFormat;

    [Inject]
    private ScoreManager _scoreManager;

    void Update() {
        UpdateScoreboardText();
    }

    public void UpdateScoreboardText() {
        ScoreText.text = string.Format(ScoreFormat, _scoreManager.Score);
		if (_scoreManager.GameOver) {
			TimeleftText.text = "Game over.";
		} else {
			var seconds = (int)_scoreManager.TimeLeft;
			var milliseconds = (int)(_scoreManager.TimeLeft % 1 * 100);
			TimeleftText.text = string.Format(TimeLeftFormat, seconds, milliseconds);
		}
        LevelText.text = string.Format(LevelTextFormat, _scoreManager.Level);
    }
}

    