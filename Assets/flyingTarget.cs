using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class flyingTarget : MonoBehaviour
{
  
    public int  Damage;
    public int LifeTime;
    public GameObject effectBeforeBB;
    public GameObject BB;
    public bool isArrowFire;
    public float Radius;
    public float power;
    private bool action;
    public LayerMask mask;
    public LayerMask mask2;
    public LayerMask mask3;
    public LayerMask mask4;

    private void OnCollisionEnter(Collision colli)
    {
        
        if(!colli.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            if(!isArrowFire)
            {
                if (colli.gameObject.CompareTag("Enemy"))
                {
                    var HP = colli.gameObject.GetComponent<ControlLifeEnemy>();
                    if (HP)
                    {
                        HP.TakeDamage(Damage);

                    }
                }

                if (colli.gameObject.CompareTag("BossOrc"))
                {
                    var HPBoss = colli.gameObject.GetComponent<OrcHealth>();
                    if (HPBoss)
                    {

                        HPBoss.TakeDamage(Damage);


                    }

                }
                gameObject.transform.SetParent(colli.transform);
                StartCoroutine(CountDown());
            }
            else
            {

                StartCoroutine(CDArrowBomb(colli.gameObject));
                //if(colli.gameObject.CompareTag("RockDestroy"))
                //{
                //    StartCoroutine(CDArrowBomb(colli.gameObject.GetComponent<Destruction>()));
                    
                //}
                //if(colli.gameObject.CompareTag("Enemy"))
                //{

                //}
            }
            

           
        }
        
        
        
    }
    IEnumerator CountDown()
    {
        yield return new WaitForSeconds(LifeTime);
        Destroy(gameObject);
    }
    IEnumerator CDArrowBomb(GameObject obj)
    {
        yield return new WaitForSeconds(LifeTime);
        if(obj.CompareTag("RockDestroy"))
        {
            obj.GetComponent<Destruction>().AlreadyBigBang = true;
        }
        if(obj.CompareTag("Enemy"))
        {
            Destroy(obj);
        }
       

        var explosion = transform.position;
        Collider[] coli = Physics.OverlapSphere(explosion, Radius, mask);
       
        foreach (var hit in coli)
        {
            var rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = false;
                var realPower = power / Time.timeScale;
                rb.AddExplosionForce(realPower, explosion, Radius, 1);
            }
        }
        Collider[] enemy = Physics.OverlapSphere(explosion, Radius, mask2);
        foreach(var e in enemy)
        {
            
            if(e)
            {
                print("hit");
                e.GetComponent<ControlLifeEnemy>().TakeDamage(e.GetComponent<ControlLifeEnemy>().CurrentHP);
                e.GetComponent<ControlLifeEnemy>().SnockBack();

            }
        }
        Collider[] rock = Physics.OverlapSphere(explosion, Radius, mask3);
        {
            foreach(var r in rock)
            {
                if(r)
                {
                    r.GetComponent<Destruction>().AlreadyBigBang = true;
                }
            }
        }
        Collider[] boss = Physics.OverlapSphere(explosion, Radius, mask4);
        {
            foreach(var b in boss)
            {
                if (b)
                {
                    b.GetComponent<ControlLifeEnemy>().TakeDamage(30);
                }
            }
        }


        Instantiate(effectBeforeBB, transform.position, transform.rotation);
        yield return new WaitForSeconds(0.5f);

        Instantiate(BB, transform.position, transform.rotation);
       
        Destroy(gameObject);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
