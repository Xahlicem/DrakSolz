using System;
using System.Collections.Generic;
using System.Linq;
using DrakSolz.NPCs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace DrakSolz {
    public class WeightedObject<T> {
        public T Obj;
        public double Weight;

        public static Tuple<T, double> Tuple(T obj, double weight = 1d) => new Tuple<T, double>(obj, weight);

        public Tuple<T, double> Tuple() => Tuple(Obj, Weight);

        public WeightedObject(T obj, double weight = 1d) {
            this.Obj = obj;
            this.Weight = weight;
        }
    }
    public static class DrakSolzUtils {
        /*public static T Get<T>(this T[] source)
			=> source[Main.rand.Next(source.Length)];
*/
        public static WeightedRandom<string> ToWeightedCollection(this string[] strings) => new WeightedRandom<string>(strings.Select(x => x.ToWeightedTuple()).ToArray());
        public static Tuple<string, double> ToWeightedTuple(this string message, double weight = 1d) => WeightedObject<string>.Tuple(message, weight);
        public static void Downed(this DrakSolzWorld.Boss boss, bool state = true) => DrakSolzWorld.downedBoss[boss] = state;

        public static bool IsDowned(this DrakSolzWorld.Boss boss) => DrakSolzWorld.downedBoss[boss];

        /*public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture)
        {
        	var effects = npc.direction == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
        	spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY), npc.frame,
        					 Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
        }*/
        public static void RedundantFunc() {
            var something = System.Linq.Enumerable.Range(1, 10);
        }
        public static void DrawNPCGlowMask(SpriteBatch spriteBatch, NPC npc, Texture2D texture, float yOffset = 0f) {
            var effects = npc.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            spriteBatch.Draw(texture, npc.Center - Main.screenPosition + new Vector2(0, npc.gfxOffY+ yOffset), npc.frame,
                Color.White, npc.rotation, npc.frame.Size() / 2, npc.scale, effects, 0);
        }
    }
}