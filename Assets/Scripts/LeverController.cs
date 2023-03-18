using System.Collections;
using System.Collections.Generic;
using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.CorgiEngine
{
    /// <summary>
    /// This component extends KeyOperatedZone with animation
    /// </summary>

    public class LeverController : KeyOperatedZone
    {
        [MMInspectorGroup("Lever Control", true, 28)]

        [SerializeField]
        [Tooltip("Animation state name to palay on activation")]
        private string _activateAnimationName = "Base Layer.jumper";
        private Animator _animator;

        protected override void Start()
        {
            _animator = GetComponent<Animator>();
        }

        protected override void OnTriggerEnter2D(Collider2D collider)
        {
            if (_animator != null)
            {
                _animator.Play(_activateAnimationName);
            }
            base.OnTriggerEnter2D(collider);
        }

    }
}
