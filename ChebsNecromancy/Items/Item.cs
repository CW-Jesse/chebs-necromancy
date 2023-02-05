﻿using System;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Configs;
using Jotunn.Entities;
using UnityEngine;
using Logger = Jotunn.Logger;

namespace ChebsNecromancy.Items
{

    public class InternalName : Attribute
    {
        public readonly string Name;
        public InternalName(string internalName) => Name = internalName;
    }

    public enum CraftingTable
    {
        None,
        [InternalName("piece_workbench")] Workbench,
        [InternalName("piece_cauldron")] Cauldron,
        [InternalName("forge")] Forge,
        [InternalName("piece_artisanstation")] ArtisanTable,
        [InternalName("piece_stonecutter")] StoneCutter
    }

    internal class Item
    {
        public ConfigEntry<bool> Allowed;

        public virtual string ItemName => "";
        public virtual string PrefabName => "";

        public virtual string NameLocalization => "";
        public virtual string DescriptionLocalization => "";

        public virtual void CreateConfigs(BaseUnityPlugin plugin) {}

        protected virtual string DefaultRecipe => "";

        //
        // Summary:
        //      Method SetRecipeReqs sets the material requirements needed to craft the item via a recipe.
        protected void SetRecipeReqs(
            ItemConfig recipeConfig,
            ConfigEntry<string> craftingCost, 
            ConfigEntry<CraftingTable> craftingStationRequired,
            ConfigEntry<int> craftingStationLevel
            )
        {

            // function to add a single material to the recipe
            void AddMaterial(string material)
            {
                string[] materialSplit = material.Split(':');
                string materialName = materialSplit[0];
                int materialAmount = int.Parse(materialSplit[1]);
                recipeConfig.AddRequirement(new RequirementConfig(materialName, materialAmount, materialAmount * 2));
            }

            // set the crafting station to craft it on
            recipeConfig.CraftingStation = ((InternalName)typeof(CraftingTable).GetMember(craftingStationRequired.Value.ToString())[0].GetCustomAttributes(typeof(InternalName)).First()).Name;

            // build the recipe. material config format ex: Wood:5,Stone:1,Resin:1
            if (craftingCost.Value.Contains(','))
            {
                string[] materialList = craftingCost.Value.Split(',');
                foreach (string material in materialList)
                {
                    AddMaterial(material);
                }
            }
            else
            {
                AddMaterial(craftingCost.Value);
            }

            // Set the minimum required crafting station level to craft
            recipeConfig.MinStationLevel = craftingStationLevel.Value;
        }


        // coroutines cause problems and this is not a monobehavior, but we
        // may still want some stuff to happen during update.
        protected float DoOnUpdateDelay;
        public virtual void DoOnUpdate()
        {

        }

        public virtual CustomItem GetCustomItemFromPrefab(GameObject prefab)
        {
            ItemConfig config = new ItemConfig();
            config.Name = NameLocalization;
            config.Description = DescriptionLocalization;

            CustomItem customItem = new CustomItem(prefab, false, config);
            if (customItem == null)
            {
                Logger.LogError($"GetCustomItemFromPrefab: {PrefabName}'s CustomItem is null!");
                return null;
            }
            if (customItem.ItemPrefab == null)
            {
                Logger.LogError($"GetCustomItemFromPrefab: {PrefabName}'s ItemPrefab is null!");
                return null;
            }

            return customItem;
        }
    }
}
