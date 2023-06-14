using System;
using UnityEngine;
// ReSharper disable All
#pragma warning disable CS8524

namespace Scripts.GemVersionTwo
{
    public class GemTypeVersion : MonoBehaviour
    {
        [SerializeField] private GemTypes Type;
        internal Gem type => new(Type);
    }
    
    public enum GemTypes {green, pink, yellow}

    [System.Serializable]
    public class Gem
    {
        internal static readonly Gem green = new(GemTypes.green);
        internal static readonly Gem pink = new(GemTypes.pink);
        internal static readonly Gem yellow = new(GemTypes.yellow);

        private readonly GemTypes gemTypes;
        internal Gem(GemTypes gemTypes) => this.gemTypes = gemTypes;

        internal string name => gemTypes switch
        {
            GemTypes.green => "Green",
            GemTypes.pink => "Pink",
            GemTypes.yellow => "Yellow"
        };

        internal Sprite icon => gemTypes switch
        {
            GemTypes.green => Resources.Load<Sprite>($"GemIcons/Gem_{Gem.green.name}"),
            GemTypes.pink => Resources.Load<Sprite>($"GemIcons/Gem_{Gem.pink.name}"),
            GemTypes.yellow => Resources.Load<Sprite>($"GemIcons/Gem_{Gem.yellow.name}")
        };

        internal int startPrice => gemTypes switch
        {
            GemTypes.green => Resources.Load<IntegerObject>($"GemStartPrices/Gem_{Gem.green.name}").value,
            GemTypes.pink => Resources.Load<IntegerObject>($"GemStartPrices/Gem_{Gem.pink.name}").value,
            GemTypes.yellow => Resources.Load<IntegerObject>($"GemStartPrices/Gem_{Gem.yellow.name}").value
        };
    }
}
