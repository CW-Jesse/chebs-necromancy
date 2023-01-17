﻿using Jotunn.Configs;
using Jotunn.Entities;
using UnityEngine;

namespace ChebsNecromancy
{
    internal class SkeletonHelmetLeatherPoison : Item
    {
        // This is a copy of the HelmetLeather item that is scaled slightly larger
        // to accomodate a skeleton's large dome

        public override string ItemName { get { return "ChebGonaz_SkeletonHelmetLeatherPoison"; } }
        public override string PrefabName { get { return "ChebGonaz_SkeletonHelmetLeatherPoison.prefab"; } }
        public override string NameLocalization { get { return "$item_helmet_leather"; } }
        public override string DescriptionLocalization { get { return "$item_helmet_leather_description"; } }
    }
}
