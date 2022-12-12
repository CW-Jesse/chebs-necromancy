﻿using Jotunn.Configs;
using Jotunn.Entities;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;

namespace FriendlySkeletonWand
{
    internal class SpectralShroud : Item
    {
        public Material material;

        public SpectralShroud()
        {
            ItemName = "ChebGonaz_SpectralShroud";
        }

        public override void CreateConfigs(BaseUnityPlugin plugin)
        {
            base.CreateConfigs(plugin);

            allowed = plugin.Config.Bind("Client config", "SpectralShroudAllowed",
                true, new ConfigDescription("Whether crafting a Spectral Shroud is allowed or not."));
        }

        public override CustomItem GetCustomItem()
        {
            ItemConfig config = new ItemConfig();
            config.Name = "$item_friendlyskeletonwand_spectralshroud";
            config.Description = "$item_friendlyskeletonwand_spectralshroud_desc";
            if (allowed.Value)
            {
                config.CraftingStation = "piece_workbench";
                config.AddRequirement(new RequirementConfig("Chain", 5));
                config.AddRequirement(new RequirementConfig("TrollHide", 10));
            }

            CustomItem customItem = new CustomItem(ItemName, "CapeTrollHide", config);
            //// sigh, nothing works...
            ////customItem.ItemDrop.GetComponentInChildren<MeshRenderer>().material = material;
            //customItem.ItemPrefab.GetComponentsInChildren<MeshRenderer>().ToList().ForEach(mr => mr.material.SetColor("black",Color.black));
            return customItem;

        }

        public void LoadSpectralShroudMaterial(AssetBundle bundle, string materialName = "ChebGonaz_SpectralShroud.mat")
        {
            Jotunn.Logger.LogInfo($"Loading {materialName}...");
            material = bundle.LoadAsset<Material>(materialName);
            if (material == null) { Jotunn.Logger.LogError($"{materialName} is null!"); }
        }
    }
}
