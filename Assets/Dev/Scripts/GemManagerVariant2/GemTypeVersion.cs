using System;
using UnityEngine;
// ReSharper disable All
#pragma warning disable CS8524

namespace Scripts.GemVersionTwo
{
    public class GemTypeVersion : MonoBehaviour
    {
        [SerializeField] private GemTypes Type;
        internal GemTwo type => new(Type);
    }
    
    public enum GemTypes {green, pink, yellow}

    [System.Serializable]
    public class GemTwo
    {
        internal static readonly GemTwo green = new(GemTypes.green);
        internal static readonly GemTwo pink = new(GemTypes.pink);
        internal static readonly GemTwo yellow = new(GemTypes.yellow);

        private readonly GemTypes gemTypes;
        internal GemTwo(GemTypes gemTypes) => this.gemTypes = gemTypes;

        internal string name => gemTypes switch
        {
            GemTypes.green => "Green",
            GemTypes.pink => "Pink",
            GemTypes.yellow => "Yellow"
        };

        internal Sprite icon => gemTypes switch
        {
            GemTypes.green => Resources.Load<Sprite>($"GemIcons/Gem_{GemTwo.green.name}"),
            GemTypes.pink => Resources.Load<Sprite>($"GemIcons/Gem_{GemTwo.pink.name}"),
            GemTypes.yellow => Resources.Load<Sprite>($"GemIcons/Gem_{GemTwo.yellow.name}")
        };

        internal int startPrice => gemTypes switch
        {
            GemTypes.green => Resources.Load<IntegerObject>($"GemStartPrices/Gem_{GemTwo.green.name}").value,
            GemTypes.pink => Resources.Load<IntegerObject>($"GemStartPrices/Gem_{GemTwo.pink.name}").value,
            GemTypes.yellow => Resources.Load<IntegerObject>($"GemStartPrices/Gem_{GemTwo.yellow.name}").value
        };
    }
}
