using System.Collections;
using UnityEngine;

public class MonsterAnimation : MonoBehaviour
{
    public const string IDLE = "Anim_Idle";
    public const string RUN = "Anim_Run";
    public const string ATTACK = "Anim_Attack";
    public const string DAMAGE = "Anim_Damage";
    public const string DEATH = "Anim_Death";

    private Animation anim;

    private void Start()
    {

        anim = GetComponent<Animation>();
        Idle();
    }

    public void Idle()
    {
        anim.CrossFade(IDLE);
    }

    public void Eat()
    {
        anim.CrossFade(RUN);
    }

    public void Attack()
    {
        anim.CrossFade(ATTACK);
    }

    public void TummyFull()
    {
        StartCoroutine(TummyFullAnim());
    }

    private IEnumerator TummyFullAnim()
    {
        anim.CrossFade(DAMAGE);
        yield return new WaitForSeconds(1.0f);
        anim.CrossFade(DEATH);
    }
}
