using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ExperiencePoint : MonoBehaviour
{
    public SetValueBar EXPBar;

    public TMP_Text LevelText;
    public int Level;
    public int _currentEXP;
    public int ExpNeedLevelUp;
    private void Start()
    {
        EXPBar.SetMaxValue(ExpNeedLevelUp, _currentEXP);
        EXPBar.SetValue(_currentEXP);
    }

    public void AddEXP(int expenemy)
    {
        EXPBar.SetMaxValue(ExpNeedLevelUp, _currentEXP);
        _currentEXP += expenemy;
        EXPBar.SetValue(_currentEXP);

        if (_currentEXP >= ExpNeedLevelUp)
        {
            Level++;
            _currentEXP = 0;
            ExpNeedLevelUp *= 2;
        }
        
        LevelText.text = Level.ToString();
        
    }
}
