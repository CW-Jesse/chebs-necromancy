﻿using ChebsNecromancy.Structures;
using UnityEngine;

namespace ChebsNecromancy.Minions
{
    internal class SpiritPylonGhostMinion : UndeadMinion
    {
        private float killAt;

        public override void Awake()
        {
            base.Awake();
            canBeCommanded = false;
            killAt = Time.time + Structures.SpiritPylon.GhostDuration.Value;
        }

        private void Update()
        {
            if (Time.time > killAt)
            {
                Kill();
            }
        }
    }
}
