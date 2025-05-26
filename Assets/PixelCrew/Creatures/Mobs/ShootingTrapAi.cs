using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.GoBased;
using PixelCrew.Utils;
using TMPro;
using UnityEngine;

namespace PixelCrew.Creatures.Mobs
{
    public class ShootingTrapAi : MonoBehaviour
    {
        [SerializeField] private LayerCheck _vision;

        [Header("Melee")]
        [SerializeField] private Cooldown _meleeCooldown;
        [SerializeField] private CheckCircleOverlap _meleeAtack;
        [SerializeField] private LayerCheck _meleeCanAtack;

        [Header("Range")]
        [SerializeField] private Cooldown _rangeCooldown;
        [SerializeField] private SpawnComponent _rangeAttack;
        
        private static readonly int Melee = Animator.StringToHash("melee");
        private static readonly int Range = Animator.StringToHash("range");

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if(_vision.IsTouchingLayer)
            {
                if(_meleeCanAtack.IsTouchingLayer)
                {
                    if(_meleeCooldown.IsReady)
                    {
                        MeleeAttack();
                    }
                    return;
                }
                if(_rangeCooldown.IsReady)
                {
                    RangeAttack();
                }
            }
        }

        private void RangeAttack()
        {
            _rangeCooldown.Reset();
            _animator.SetTrigger(Range);
        }

        private void MeleeAttack()
        {
            _meleeCooldown.Reset();
            _animator.SetTrigger(Melee);
        }

        public void OnMeleeAttack()
        {
            _meleeAtack.Check();
        }
        public void OnRangeAttack()
        {
            _rangeAttack.Spawn();
        }
    }
}

