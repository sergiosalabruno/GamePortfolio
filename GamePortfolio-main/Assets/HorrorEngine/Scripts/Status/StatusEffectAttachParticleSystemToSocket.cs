using UnityEngine;
using System.Collections.Generic;

namespace HorrorEngine
{
    [CreateAssetMenu(fileName = "StatusEffectAttachParticleSystemToSocket", menuName = "Horror Engine/Status/Effects/AttachParticleSystemToSocket")]
    public class StatusEffectAttachParticleSystemToSocket : StatusEffect
    {
        [SerializeField] private GameObject m_ParticlePrefab;
        [SerializeField] private SocketAttachment[] m_SocketAttachments;

        private List<GameObject> m_AttachedParticles = new List<GameObject>();

        // --------------------------------------------------------------------

        public override void StartEffect(GameObject target)
        {
            base.StartEffect(target);

            SocketController socketController = target.GetComponent<SocketController>();
            if (socketController == null)
            {
                Debug.LogWarning("No SocketController found on target.");
                return;
            }

            foreach (var attachment in m_SocketAttachments)
            {
                var socket = socketController.GetSocket(attachment.Socket);
                if (socket != null)
                {
                    var particleInstance = GameObjectPool.Instance.GetFromPool(m_ParticlePrefab, null);
                    socketController.Attach(particleInstance.gameObject, attachment);
                    particleInstance.gameObject.SetActive(true);

                    m_AttachedParticles.Add(particleInstance.gameObject);
                }
            }
        }

        // --------------------------------------------------------------------

        public override void EndEffect()
        {
            base.EndEffect();

            foreach (var particle in m_AttachedParticles)
            {
                if (particle != null)
                {
                    GameObjectPool.Instance.ReturnToPool(particle.GetComponent<PooledGameObject>());
                }
            }

            m_AttachedParticles.Clear();
        }
    }
}
