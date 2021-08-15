using Terraria.ID;
using Terraria.ModLoader;

namespace BurdsPackTerrariaMod.Items
{
	public class ScytheOfCthulhu : ModItem
	{
		public override void SetStaticDefaults() 
		{
			DisplayName.SetDefault("ScytheOfCthulhu"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Cthulhu's favourite weapon.");
		}

		public override void SetDefaults() 
		{
			item.damage = 50;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.UseSound = SoundID.Item15; // mod.GetLegacySoundSlot(SoundType.Item, "Sounds/Item/LAFLAME");
			item.useTime = 20;
			item.useAnimation = 20;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 10;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType("ScytheOfCthulhuProjectile");
			item.shootSpeed = 5f;
		}

		public override void AddRecipes() 
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DirtBlock, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}