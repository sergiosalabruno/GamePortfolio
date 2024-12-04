using UnityEngine;
using UnityEngine.Serialization;

namespace HorrorEngine
{
    public abstract class StatusEffect : Register
    {
        public float Duration;
        
        public bool HasFinished { get; set; }

        [HideInInspector]
        public float RemainingTime;

        // --------------------------------------------------------------------

        public virtual bool ShouldTick()
        {
            return false;
        }

        // --------------------------------------------------------------------

        public virtual void StartEffect(GameObject target)
        {
            HasFinished = false;
            RemainingTime = Duration;
        }

        // --------------------------------------------------------------------

        public virtual void FixedTimeTick()
        {

        }

        // --------------------------------------------------------------------

        public virtual void Tick() 
        {
            if (Duration > 0)
            {
                RemainingTime -= Time.deltaTime;
                if (RemainingTime <= 0)
                    HasFinished = true;
            }
        }

        // --------------------------------------------------------------------

        public virtual void EndEffect()
        {
            HasFinished = true;
        }
    }
}
