using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace DPSCalculator;

public class PlayerCalculator : ModPlayer {
    private List<int> Damages = new();
    private int Count = 0;
    
    public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit) {
        if (crit) {
            Damages.Add((damage * 2));
        } else Damages.Add(damage);
    }

    public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection) {
        if (crit) {
            Damages.Add((damage * 2));
        } else Damages.Add(damage);
    }

    public override void ProcessTriggers(TriggersSet triggersSet) {
        if (DPSCalculator.RestartCounting.JustPressed) {
            string result = $"Total hits: {Damages.Count}\r\n" +
                            $"Total damage: {Damages.Sum()}\r\n" +
                            $"Maximum damage: {Damages.Max()}\r\n" +
                            $"Minimum damage: {Damages.Min()}\r\n" +
                            $"Average damage: {Damages.Average()}";
            Damages.Clear();
            Count++;
            File.WriteAllText($"damage-{Count}.txt", result);
        }
    }
}