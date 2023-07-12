using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaPoint : MonoBehaviour
{
    public SetValueBar ManaBar;

    public int MaxMana;
    public  int CurrentMana;

    private void Start()
    {
        ManaBar.SetMaxValue(MaxMana, CurrentMana);
        CurrentMana = MaxMana;
        ManaBar.SetValue(CurrentMana);
    }

    public void SubTracMana(int mananeedskill)
    {
        CurrentMana -= mananeedskill;
        
    }
    public void ResumeMana(int value)
    {
        CurrentMana += value;
    }
    private void Update()
    {
        UpdateUiBar();
    }
    private void UpdateUiBar()
    {
        ManaBar.SetValue(CurrentMana);
    }
}
