/*using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace XahlicemMod.Items.World
{
	public class FirelinkGen : ModWorld
	{

        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref float totalWeight)
		{


			int TrapsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Bonfires"));
			if (TrapsIndex != -1)
			{
				tasks.Insert(TrapsIndex + 1, new PassLegacy("Bonfires Galore", delegate (GenerationProgress progress)
				{
					progress.Message = "Bonfires Galore";
					// Computers are fast, so WorldGen code sometimes looks stupid.
					// Here, we want to place a bunch of tiles in the world, so we just repeat until success. It might be useful to keep track of attempts and check for attemps > maxattempts so you don't have infinite loops. 
					// The WorldGen.PlaceTile method returns a bool, but it is useless. Instead, we check the tile after calling it and if it is the desired tile, we know we succeeded.
					for (int k = 0; k < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); k++)
					{
						bool placeSuccessful = false;
						Tile tile;
						int tileToPlace = mod.TileType("FirelinkShrine2");
						while (!placeSuccessful)
						{
							int x = WorldGen.genRand.Next(0, Main.maxTilesX);
							int y = WorldGen.genRand.Next(0, Main.maxTilesY);
							WorldGen.PlaceTile(x, y, tileToPlace);
							tile = Main.tile[x, y];
							placeSuccessful = tile.active() && tile.type == tileToPlace;
						}
					}
				}));
			}
        }
    }
}*/