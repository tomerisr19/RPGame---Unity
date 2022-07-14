using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Animator anim;

    public bool isAttaking = false;

    private hitBox hitBox;

    private void Start()
    {
        hitBox = FindObjectOfType<hitBox>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attak());
        }
    }

    IEnumerator Attak()
    {
        if (!isAttaking)
        {
            hitBox.Attak();
            isAttaking = true;
            anim.SetBool("isAttaking", true);
            yield return new WaitForSeconds(0.35f);
            anim.SetBool("isAttaking", false);
            isAttaking = false;
        }
        
    }


}
