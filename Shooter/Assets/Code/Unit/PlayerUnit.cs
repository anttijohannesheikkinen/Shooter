using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Shooter.Data;
using Shooter.Configs;
using DG.Tweening;

namespace Shooter
{
    public class PlayerUnit : UnitBase
    {
        public enum UnitType
        {
            None = 0,
            Fast = 1,
            Heavy = 2,
            Balanced = 3
        }

        [SerializeField]
        private UnitType _unitType;
        public PlayerData Data { get; private set; }

        public UnitType Type { get { return _unitType; } }

        private PlayerUnits _playerUnits;
        private MeshRenderer _meshRenderer;
        private bool _invulnerable;


        public override int ProjectileLayer
        {
            get { return LayerMask.NameToLayer(Config.PlayerProjectileLayername); }
        }

        public void Init  (PlayerData playerData, PlayerUnits playerUnits)
        {
            InitRequiredComponents();
            Data = playerData;
            _playerUnits = playerUnits;
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        protected override void Die()
        {
            base.Die();
            _invulnerable = true;
            _playerUnits.HandlePlayerDeath(Data);
            gameObject.SetActive(false);
            Debug.Log("Player ID: " + Data.Id + ", Lives left: " + Data.Lives);
        }

        private void OnCollisionEnter (Collision collision)
        {
            // We might want to collide with other non-player objects too sometime? Who knows?
            if (!_invulnerable && collision.gameObject.CompareTag("Enemy"))
            {
                Health.TakeDamage(Config.CollisionDamageToPlayer);
            }
        }

        public void SpawnPlayer (bool respawn)
        {
            gameObject.SetActive(true);
            _invulnerable = false;

            if (respawn)
            {
                RespawnWithMaxHealth();
                _invulnerable = true;
                StartCoroutine(PlayerUnitRespawn(2.0f, 6));
            }
        }

        private IEnumerator PlayerUnitRespawn (float length, int amountOfBlinks)
        {

            amountOfBlinks = amountOfBlinks * 2 - 1;
            float timerStartTime = Time.time;
            float blinkLength = length / amountOfBlinks;
            float blinkTimerStartTime = Time.time;
            bool meshRendererIsActive = true;

            while (timerStartTime + length >= Time.time)
            {
                if (blinkTimerStartTime + blinkLength <= Time.time )
                {
                    meshRendererIsActive = !meshRendererIsActive;
                    blinkTimerStartTime = Time.time;
                    _meshRenderer.enabled = meshRendererIsActive;
                }

                yield return null;
            }
            _meshRenderer.enabled = true;
            _invulnerable = false;
        }
    }
}