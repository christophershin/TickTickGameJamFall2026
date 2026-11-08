using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Stats : Singleton<Stats>
{
    // base stats
    [SerializeField] private int baseSpeed = 10;
    [SerializeField] private int baseBananaDamage = 1;
    [SerializeField] private int baseBananaSpeed = 20;
    [SerializeField] private int baseBananaCount = 1;
    [SerializeField] private int basePlayerHealthMax = 10;

    // levels
    public int speedLevel = 1;
    public int bananaDamageLevel = 1;
    public int bananaSpeedLevel = 1;
    public int bananaCountLevel = 1;
    public int playerHealthMaxLevel = 1;

    public float playerSpeed => baseSpeed * speedLevel;
    public float bananaDamage => baseBananaDamage * bananaDamageLevel;
    public float bananaSpeed => baseBananaSpeed * bananaSpeedLevel;
    public int bananaCount => baseBananaCount * bananaCountLevel;

    public float playerHealthMax => basePlayerHealthMax * playerHealthMaxLevel;

    [Range(0f, 5)]
    public float bananaShotMaxTimer  = 5;

    public void IncreaseBaseSpeed()
    {
        speedLevel++;
    }

    public void IncreaseBaseBananaDamage()
    {
        bananaDamageLevel++;
    }

    public void IncreaseBaseBananaSpeed()
    {
        bananaSpeedLevel++;
    }

    public void IncreaseBaseBananaCount()
    {
        bananaCountLevel++;
    }
}
