using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatusUI : MonoBehaviour
{
    public void TurnOnUI()
    {
        ChangeUI(true);
    }

    public void TurnOffUI()
    {
        ChangeUI(false);
    }

    private void ChangeUI(bool value)
    {
        gameObject.SetActive(value);
    }

}
