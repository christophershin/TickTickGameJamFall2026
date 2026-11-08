using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : Singleton<LevelManager>
{
    public int currentLevel = 1;
    public float currentExp = 0;
    public float maxExp = 5;

    [SerializeField] private float baseExp = 5;
    [SerializeField] private float increment = 1.5f;
    [SerializeField] private Button[] skillButtons;
    [SerializeField] private TextMeshProUGUI[] skillTexts;

    private void Start()
    {
        maxExp =  baseExp * currentLevel * increment;
        print(maxExp);
        ActivateCards(false);
    }

    public void GainExp()
    {
        currentExp += 1;
        if (currentExp >= maxExp)
        {
            GiveOptions();
            currentLevel += 1;
            currentExp = 0;
            maxExp = baseExp * currentLevel * increment;
        }
    }

    private string[] cardSkill = new string[3];

    public void PickCard(int i)
    {
        string skill = cardSkill[i];

        switch (skill)
        {
            case "Player Speed":
                Stats.Instance.speedLevel += 1;
                break;
            case "Banana Damage":
                Stats.Instance.bananaDamageLevel += 1;
                break;
            case "Banana Speed":
                Stats.Instance.bananaSpeedLevel += 1;
                break;
            case "Banana Count":
                Stats.Instance.bananaCountLevel += 1;
                break;
        }
        
        ActivateCards(false);
    }

    private void GiveOptions()
    {
        ActivateCards(true);
        SetSkillInfo(0, "Player Speed");
        SetSkillInfo(1, "Banana Damage");
        SetSkillInfo(2, "Banana Speed");
    }

    private void ActivateCards(bool active)
    {
        for (int i = 0; i < skillButtons.Length; i++)
        {
            skillButtons[i].gameObject.SetActive(active);
        }
    }

    private void SetSkillInfo(int i, string skill)
    {
        skillTexts[i].text = skill;
        cardSkill[i] = skill;
    }
}
