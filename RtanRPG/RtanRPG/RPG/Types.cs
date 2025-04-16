namespace RtanRPG.RPG
{
    internal class Types
    {
        public enum Type
        {
            fire, water, land, wind, light, dark, normal
        }

        public static readonly Dictionary<(Type, Type), float> TypeEffect
        = new Dictionary<(Type, Type), float>()
        {
            {(Type.fire , Type.wind), 1.3f}, // 타입별 상성표
            {(Type.water , Type.fire), 1.3f},
            {(Type.land , Type.water), 1.3f},
            {(Type.wind , Type.land), 1.3f},
            {(Type.dark , Type.light), 1.3f},
            {(Type.light , Type.dark), 1.3f},
        };
    }
}