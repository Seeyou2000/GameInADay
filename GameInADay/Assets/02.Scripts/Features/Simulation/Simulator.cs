using System;
using System.Globalization;
using UnityEngine;

public class Simulator
{
    public int ElapsedTime;
    public readonly int DayDuration = 30;
    public string DateString => _calendar.AddDays(RealStartedDate, ElapsedTime / DayDuration).ToString("yyyy/MM/dd");
    public float DatePercentage => (float)(ElapsedTime % DayDuration) / DayDuration;
    public bool Enabled = true;
    public float SpeedMultiplier = 1f;
    public DateTime RealStartedDate;

    private int _fixedUpdateCounter;
    private Calendar _calendar;

    private GameScene _gameScene;

    public Simulator(GameScene gameScene)
    {
        _gameScene = gameScene;

        _calendar = CultureInfo.InvariantCulture.Calendar;

        // TODO: 저장같은게 생긴다면 유지되어야 함
        RealStartedDate = DateTime.Now;

        PlayNormal();
    }

    public void PlayNormal()
    {
        Play(1.0f);
    }

    public void PlayDouble() {
        Play(3.0f);
    }

    private void Play(float speedMultiplier) {
        SpeedMultiplier = speedMultiplier;
        Enabled = true;
    }

    public void Pause()
    {
        Enabled = false;
    }

    private void Simulate()
    {
        ElapsedTime++;
    }

    public void OnFixedUpdate()
    {
        if (!Enabled) return;

        _fixedUpdateCounter++;
        if (_fixedUpdateCounter > (1 / Time.fixedDeltaTime / SpeedMultiplier)) {
            _fixedUpdateCounter = 0;
            Simulate();
        }
    }
}