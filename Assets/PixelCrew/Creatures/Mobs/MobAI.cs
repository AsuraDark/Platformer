﻿using System;
using System.Collections;
using UnityEngine;
using PixelCrew.Components;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Creatures.Mobs.Patrolling;
using PixelCrew.Components.GoBased;

namespace PixelCrew.Creatures.Mobs
{
    public class MobAI : MonoBehaviour
    {
        [SerializeField] private LayerCheck _vision;
        [SerializeField] private LayerCheck _canAttack;

        [SerializeField] private float _alarmDelay = 0.5f;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _missHeroCooldown = 0.5f;

        private Coroutine _current;
        private GameObject _target;

        private static readonly int IsDeadKey = Animator.StringToHash("is-dead");

        private SpawnListComponent _particles;
        private Creature _creature;
        private Animator _animator;
        private bool _isDead;
        private Patrol _patrol;

        public bool IsDead => _isDead;
        public Animator Animators => _animator;

        private void Awake()
        {
            _particles = GetComponent<SpawnListComponent>();
            _creature = GetComponent<Creature>();
            _animator = GetComponent<Animator>();
            _patrol = GetComponent<Patrol>();
        }

        private void Start()
        {
            StartState(_patrol.DoPatrol());
        }

        public void OnHeroVision(GameObject go)
        {
            if (_isDead) return;
            _target = go;

            StartState(AgroToHero());
        }
        private IEnumerator AgroToHero()
        {
            LookAtHero();
            _particles.Spawn("Exclamation");
            yield return new WaitForSeconds(_alarmDelay);

            StartState(GoToHero());
        }

        private void LookAtHero()
        {
            var direction = GetDirectionToTarget();
            _creature.SetDirection(Vector2.zero);
            _creature.UpdateSpriteDirection(direction);
        }

        private IEnumerator GoToHero()
        {
            while (_vision.IsTouchingLayer)
            {
                if (_canAttack.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else
                {
                    SetDirectionToTarget();
                }

                yield return null;
            }

            _creature.SetDirection(Vector2.zero);
            _particles.Spawn("MissHero");
            yield return new WaitForSeconds(_missHeroCooldown);

            StartState(_patrol.DoPatrol());
        }

        private IEnumerator Attack()
        {
            while(_canAttack.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackCooldown);
            }

            StartState(GoToHero());
        }

        private void SetDirectionToTarget()
        {
            var direction = GetDirectionToTarget();
            _creature.SetDirection(direction);
        }

        private Vector2 GetDirectionToTarget()
        {
            var direction = _target.transform.position - transform.position;
            direction.y = 0;
            return direction.normalized;
        }

        private void StartState(IEnumerator coroutine)
        {
            _creature.SetDirection(Vector2.zero);

            if (_current != null)
                StopCoroutine(_current);

            _current = StartCoroutine(coroutine);
        }

        public void OnDie()
        {
            _creature.SetDirection(Vector2.zero);
            _isDead = true;
            _animator.SetBool(IsDeadKey, true);

            if (_current != null)
                StopCoroutine(_current);
        }
    }
}
