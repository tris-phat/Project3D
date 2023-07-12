using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxController : MonoBehaviour
{
    public GameObject[] House;
    public GameObject[] BarrackOrc;

    public Material daySkybox;
    public Material nightSkybox;

    public Light directionalLight;
    public Color dayColor;
    public Color nightColor;

    bool isDay = true;


    private bool ok;

    private void Update()
    {
        if (ok)
        {
            //StartCoroutine(ResetEnemy());
        }
        else return;
       
    }
    IEnumerator ResetEnemy()
    {
        for (int i = 0; i < BarrackOrc[8].transform.childCount; i++)
        {
            BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().enabled = false;
            //BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().action = false;
             
            //BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().enabled = true;
            //BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().action = t;

        }
        yield return new WaitForSeconds(1);
        for (int i = 0; i < BarrackOrc[8].transform.childCount; i++)
        {
            BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().enabled = true;
            //BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().action = false;

            //BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().enabled = true;
            //BarrackOrc[8].transform.GetChild(i).GetComponent<EnemyController>().action = t;

        }

        ok = false;
    }
        



    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.FadeAnim.SetActive(true); 
            isDay = !isDay;
            if (isDay)
            {
                DayMode();
            }
            else
            {
                NightMode();
            }
            Barrack(isDay);
            ActiveHouse(isDay);
        }
    }

    private void Barrack(bool open)
    {
        for(int i =0; i < BarrackOrc.Length;i++)
        {
            BarrackOrc[i].SetActive(!open);
        }
        ok = true;
    }
    private void ActiveHouse(bool open)
    {
        for (int i = 0; i < House.Length; i++)
        {
            House[i].SetActive(open);
        }
    }

    void DayMode()
    {
        RenderSettings.skybox = daySkybox;
        directionalLight.color = dayColor;
    }

    void NightMode()
    {
        RenderSettings.skybox = nightSkybox;
        directionalLight.color = nightColor;
    }
}
