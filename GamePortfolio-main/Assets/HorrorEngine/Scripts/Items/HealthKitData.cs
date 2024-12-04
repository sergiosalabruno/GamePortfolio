using UnityEngine;

namespace HorrorEngine
{
    [CreateAssetMenu(menuName = "Horror Engine/Items/HealthKit")]
    public class HealthKitData : ItemData
    {
        [SerializeField] private float m_Regeneration;
        [SerializeField] private bool m_CompleteRegeneration;
        [SerializeField] private StatusData[] m_RemoveStatus;
        [SerializeField] private StatusEffect[] m_RemoveStatusEffect;

        public override void OnUse(InventoryEntry entry)
        {
            base.OnUse(entry);

            PlayerActor player = GameManager.Instance.Player;

            if (m_CompleteRegeneration)
                player.GetComponent<Health>().RegenerateAll();
            else
                player.GetComponent<Health>().Regenerate(m_Regeneration);

            if (m_RemoveStatus.Length > 0)
            {
                var playerStatus = player.GetComponent<Status>();
                Debug.Assert(playerStatus, "HealthKit is trying to remove status but the player has no Status component");
                if (playerStatus != null)
                {
                    foreach (StatusData status in m_RemoveStatus)
                    {
                        playerStatus.RemoveStatus(status);
                    }
                }
            }

            if (m_RemoveStatusEffect.Length > 0)
            {
                var statusEffectHandler = player.GetComponent<StatusEffectHandler>();
                if (statusEffectHandler != null)
                {
                    foreach (StatusEffect statusEffect in m_RemoveStatusEffect)
                    {
                        statusEffectHandler.RemoveStatusEffect(statusEffect);
                    }
                }
            }
        }
    }
}