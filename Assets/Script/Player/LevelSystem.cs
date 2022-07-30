using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSystem : MonoBehaviour
{   
    public int level;
    public float currentXp;
    public float requireXp;
    private float LerpTimer;
    private float delayTimer;

    public Image frontXpBar;
    public Image backXpBar;
    public float additionMultiplier =300;
    public float powerMultiplier =2;
    public float divisionMultiplier =7;
    // Start is called before the first frame update
    void Start()
    {
        frontXpBar.fillAmount =currentXp/requireXp;
        backXpBar.fillAmount =currentXp/requireXp;
        requireXp=CalculateRequiredXp();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateXpUI();
        if(Input.GetKeyDown(KeyCode.Equals))
            GainExperienceFlatRate(20);
        if(currentXp>requireXp)
            levelup();
    }
    public void UpdateXpUI()
    {
        float XpFraction =currentXp/requireXp;
        float FXP=frontXpBar.fillAmount;
        if(FXP<XpFraction)
        {
            delayTimer += Time.deltaTime;
            backXpBar.fillAmount =XpFraction;
            if(delayTimer > 0.5)
            {
                LerpTimer += Time.deltaTime;
                float percentComplete =LerpTimer/4;
                frontXpBar.fillAmount =Mathf.Lerp(FXP, backXpBar.fillAmount, percentComplete);
            }
        }
    }

    public void GainExperienceFlatRate(float xpGained)
    {
        currentXp += xpGained;
        LerpTimer =0f;
        delayTimer =0f;
    }
    public void levelup()
    {
        level++;
        frontXpBar.fillAmount=0f;
        backXpBar.fillAmount=0f;
        currentXp =Mathf.RoundToInt(currentXp-requireXp);
        GetComponent<Healthbar>().increaseHealth(level);
        requireXp=CalculateRequiredXp();
    }

    private int CalculateRequiredXp()
    {
        int solveForRequiredXp =0;
        for(int levelCycle =1; levelCycle<=level; levelCycle++)
        {
            solveForRequiredXp +=(int)Mathf.Floor(levelCycle+additionMultiplier*Mathf.Pow(powerMultiplier, levelCycle/divisionMultiplier));
        }
        return solveForRequiredXp/4;
    }
}
