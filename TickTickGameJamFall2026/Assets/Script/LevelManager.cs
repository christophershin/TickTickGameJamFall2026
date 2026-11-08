using System;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevel = 0;
    public float currentExp = 0;
    public float maxExp = 10;

    [SerializeField] private float baseExp = 10;
    [SerializeField] private float increment = 1.5f;

    private void Start()
    {
        maxExp = (increment * currentLevel) * baseExp;
    }

    public void GainExp()
    {
        currentExp += 1;
        if (currentExp >= maxExp)
        {
            currentLevel += 1;
            currentExp = 0;
            maxExp = (increment * currentLevel) * baseExp;
        }
    }

    // private float time = 0f;
    //
    // private void Update()
    // {
    //     time += Time.deltaTime;
    //     if (time >= 1)
    //     {
    //         time = 0;
    //         GainExp();
    //     }
    // }
}
