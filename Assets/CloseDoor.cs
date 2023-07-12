using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
public class CloseDoor : MonoBehaviour
{
    public GameObject Cutscene_introBoss;
    public GameObject Player;
    public GameObject Boss;
   

    public float timer;
    public bool startintro;

    private void Update()
    {
        if(startintro)
        {
            if(timer <= 13.36667f)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Cutscene_introBoss.SetActive(false);
                Player.SetActive(true);
                Boss.SetActive(true);
                Player.GetComponent<CharacterMove>().enabled = true;
                startintro = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            
            Cutscene_introBoss.SetActive(true);
            Player.SetActive(false);
            Player.GetComponent<CharacterMove>().enabled = false;
            startintro = true;
            
        }
       
    }
}
