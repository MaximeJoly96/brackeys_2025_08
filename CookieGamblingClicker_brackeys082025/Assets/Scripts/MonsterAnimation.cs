using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CookieGambler
{
    public class MonsterAnimation : MonoBehaviour
    {
        public const string IDLE = "Anim_Idle";
        public const string RUN = "Anim_Run";
        public const string ATTACK = "Anim_Attack";
        public const string DAMAGE = "Anim_Damage";
        public const string DEATH = "Anim_Death";

        [SerializeField]
        private Animation anim;
        [SerializeField]
        private ParticleSystem particle;
        
        private void Start()
        {
            Idle();
        }

        public void Idle()
        {
            anim.CrossFade(IDLE);
        }

        public void Eat()
        {
            StartCoroutine(EatAnim());
        }

        public void Attack()
        {
            StartCoroutine(AttackAnim());
        }

        public void TummyFull()
        {
            StartCoroutine(TummyFullAnim());
        }

        public void TakeDamage()
        {
            StartCoroutine(TakeDamageAnim());
        }

        private IEnumerator TakeDamageAnim()
        {
            anim.CrossFade(DAMAGE);
            yield return new WaitForSeconds(0.5f);
            Idle();
        }

        private IEnumerator TummyFullAnim()
        {
            anim.CrossFade(DAMAGE);
            yield return new WaitForSeconds(0.7f);
            anim.CrossFade(DEATH);
            yield return new WaitForSeconds(1.3f);

            GameManager.Instance.GameOverEvent?.Invoke(this, true);
        }

        private IEnumerator AttackAnim()
        {
            anim.CrossFade(ATTACK);
            yield return new WaitForSeconds(0.5f);
            Idle();
            yield return new WaitForSeconds(0.5f);

            GameManager.Instance.GameOverEvent?.Invoke(this, false);
        }

        private IEnumerator EatAnim()
        {
            anim.CrossFade(RUN);
            particle.Play();
            yield return new WaitForSeconds(0.3f);
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
            Idle();
        }
    }
}