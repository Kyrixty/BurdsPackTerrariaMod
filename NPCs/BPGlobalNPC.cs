using BurdsPackTerrariaMod.Items;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace BurdsPackTerrariaMod.NPCs
{
    public class BPGlobalNPC : GlobalNPC
    {
        public override void NPCLoot(NPC npc)
        {
            // Eye of Cthulhu drops
            if (npc.type == NPCID.EyeofCthulhu) {
                if (Main.rand.NextFloat() < 0.33f) { // 33% chance
                    npc.DropItemInstanced(npc.position, npc.Size, mod.ItemType("ScytheOfCthulhu"));
                }
            }
        }
    }
}