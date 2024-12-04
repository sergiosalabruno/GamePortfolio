using UnityEngine;

namespace HorrorEngine
{
    [CreateAssetMenu(fileName = "StatusData", menuName = "Horror Engine/Status/StatusData")]
    public class StatusData : Register
    {
        public UIPlayerStatusEntry[] UIEntries;
    }

    [System.Serializable]
    public class UIPlayerStatusEntry
    {
        public float FromHealth;
        public Color Color;
        public float Tiling = 1f;
        public float Interval = 1f;
        public float Speed = 1f;
        public string Text;
    }
}
