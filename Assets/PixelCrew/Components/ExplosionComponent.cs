using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.GoBased;
using PixelCrew.Components.Health;
using PixelCrew.Creatures.Mobs;
using PixelCrew.Utils;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class ExplosionComponent : MonoBehaviour
    {
        [SerializeField] private Cooldown _cooldown;
        [SerializeField] private string _tag;
        [SerializeField] private int damage;

        [SerializeField] private GameObject _mob;

        private GameObject _target;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_mob.GetComponent<MobAI>().IsDead && other.gameObject.CompareTag(_tag))
            {
                _target = other.gameObject;
                _cooldown.Reset();
                _mob.GetComponent<MobAI>().Animators.SetBool("is-explosion", true);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(_tag))
            {
                _target = null;
                _mob.GetComponent<MobAI>().Animators.SetBool("is-explosion", false);
            }
        }

        private void Update()
        {
            if (_cooldown.IsReady && _target != null)
            {
                _target.GetComponent<HealthComponent>().ModifyHealth(damage);
                _mob?.GetComponent<DestroyObjectComponent>().DestroyObject();
            }
        }
    }
}
