using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("Control")]
    public GameObject Camera3rd;
    public MapController MapController;
    public GameObject PlayerManager;
    public MouseControl mouseControl;

    [Header("UI Control")]
    public GameObject FadeAnim;
    public GameObject PauseScene;
    public GameObject DeathScene;
    public GameObject WinScene;
    public GameObject MapUI;
    public ToolBarManager toolBar;


    [Header("Bool Manager")]
    internal bool Die;


    public bool pauseGame;

    private void Awake()
    {
        if (Instance != null)
        {
            return;
        }
        else Instance = this;
        pauseGame = true;
    }

    private void Start()
    {
        FadeAnim.SetActive(false);
        PauseScene.SetActive(false);
        DeathScene.SetActive(false);
        WinScene.SetActive(false);
       
       

    }
    private void OnEnable()
    {
        pauseGame = false;
    }
   
    private void Update()
    {

        if(PlayerManager.GetComponent<HealthPoint>().die)
        {
            print("Game Manager Die");
            Die = true;
            pauseGame = true;
            DeathScene.SetActive(true);
            
        }
        else
        {
            Die = false;
        }

        
        controlEnemy(pauseGame);
    }

    public void controlEnemy(bool value)
    {
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Enemy");
        if(value==true)
        {
           
            foreach (var e in enemy)
            {
                if (e)
                {

                    print("Pause");
                    e.GetComponent<ControlLifeEnemy>().enabled = false;
                    e.GetComponent<EnemyAttack>().Action = false;
                    e.GetComponent<EnemyController>().action = false;
                    PlayerManager.GetComponent<CharacterMove>().enabled = false;
                    PlayerManager.GetComponent<CharacterJump>().enabled = false;
                    PlayerManager.GetComponent<HealthPoint>().enabled = false;
                }
            }
        }
        else
        {
            foreach (var e in enemy)
            {
                if (e)
                {

                    print("resume"); 
                    e.GetComponent<ControlLifeEnemy>().enabled = true;
                    e.GetComponent<EnemyAttack>().Action = true;
                    e.GetComponent<EnemyController>().action = true;
                    PlayerManager.GetComponent<CharacterMove>().enabled = true;
                    PlayerManager.GetComponent<CharacterJump>().enabled = true;
                    PlayerManager.GetComponent<HealthPoint>().enabled = true;

                }
            }
        }
       
    }

    public void PauseGame()
    {
        pauseGame = true;
        PauseScene.SetActive(true);
        Camera3rd.SetActive(false);
        toolBar.enabled = false;
    }

    public void ResumeGame()
    {
        pauseGame = false;
        PauseScene.SetActive(false);
        Camera3rd.SetActive(true);
        toolBar.enabled = true;

    }
    public void Retry()
    {
        var HPPlayer = PlayerManager.GetComponent<HealthPoint>();
        DeathScene.SetActive(false);
        pauseGame = false;

        HPPlayer.die = false;
        HPPlayer.Anim.SetBool("Death", false);
       

        HPPlayer._currentHP = HPPlayer.MaxHP;


        print("Retry");
       
        
       

    }
}
