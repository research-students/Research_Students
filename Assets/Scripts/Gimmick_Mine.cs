using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimmick_Mine : MonoBehaviour
{
    [SerializeField] float wait;
    [SerializeField] float timer;
    [SerializeField] float expl_time;
    [SerializeField] float expl_force;
    [SerializeField] float damage;
    
    private SphereCollider col;
    private bool           explosion;


    void Start()
    {
        col = GetComponent<SphereCollider>();
    }


    //-------
    // 爆発
    //-------
    private IEnumerator Explosion()
    {
        yield return new WaitForSeconds(wait);

        // 爆破までのアニメ再生:点滅終了したらcol.radiusを広げて爆発範囲を広げる
        // anim.Play()

        // ピーピーピーピーの時間
        yield return new WaitForSeconds(timer);

        // 爆発を有効化
        explosion = true;

        // 少し待つ
        yield return new WaitForSeconds(expl_time);

        // 消滅
        Destroy(gameObject);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            // 地雷を起動
            StartCoroutine(Explosion());
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (explosion == false)
        {
            return;
        }

        Transform parent = other.transform.root;

        if (parent.tag == "Player" || parent.tag == "Enemy")
        {
            // 吹き飛ばす
            parent.GetComponent<Rigidbody>().AddExplosionForce(expl_force, transform.position - transform.up, col.radius);
            
            float damage = (col.radius / Vector3.Distance(transform.position, other.transform.position)) * this.damage;

            // HPを減らす
            parent.GetComponent<Character_Base>().HP_Sub(damage);
        }
    }
}