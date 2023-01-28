﻿
using BepInEx;
using BepInEx.Configuration;
using Jotunn.Managers;
using UnityEngine;

namespace ChebsNecromancy
{
    internal class UndeadMinion : MonoBehaviour
    {
        // we add this component to the creatures we create in the mod
        // so that we can use .GetComponent<UndeadMinion>()
        // to determine whether a creature was created by the mod, or
        // whether it was created by something else.
        //
        // This allows us to only call wait/follow/whatever on minions
        // that the mod has created. The component is lost between sessions
        // so it must be checked for in Awake and readded (see harmony patching).

        public enum CleanupType
        {
            None,
            Time,
            Logout,
        }

        public bool canBeCommanded = true;

        public static ConfigEntry<CleanupType> cleanupAfter;
        public static ConfigEntry<int> cleanupDelay;

        protected float cleanupAt;

        #region CleanupAfterLogout
        private const float nextPlayerOnlineCheckInterval = 15f;
        private float nextPlayerOnlineCheckAt;
        #endregion

        public static void CreateConfigs(BaseUnityPlugin plugin)
        {
            cleanupAfter = plugin.Config.Bind("UndeadMinion (Server Synced)", "CleanupAfter",
                CleanupType.None, new ConfigDescription("Whether a minion should be cleaned up or not.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
            cleanupDelay = plugin.Config.Bind("UndeadMinion (Server Synced)", "CleanupDelay",
                300, new ConfigDescription("The delay, in seconds, after which a minion will be destroyed. It has no effect if CleanupAfter is set to None.", null,
                new ConfigurationManagerAttributes { IsAdminOnly = true }));
        }

        public virtual void Awake()
        {
            Tameable tameable = GetComponent<Tameable>();
            if (tameable != null)
            {
                // let the minions generate a little necromancy XP for their master
                tameable.m_levelUpOwnerSkill = SkillManager.Instance.GetSkill(BasePlugin.necromancySkillIdentifier).m_skill;
            }

            if (cleanupAfter.Value == CleanupType.Time)
            {
                cleanupAt = Time.time + cleanupDelay.Value;
            }
            else if (cleanupAfter.Value == CleanupType.Logout)
            {
                // check if player is still online every X seconds
                nextPlayerOnlineCheckAt = Time.time + nextPlayerOnlineCheckInterval;
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            // ignore collision with player

            Character character = collision.gameObject.GetComponent<Character>();
            if (character != null
                && character.m_faction == Character.Faction.Players
                && character.GetComponent<UndeadMinion>() == null) // allow collision between minions
            {
                Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
                return;
            }
        }

        private void Update()
        {
            if (cleanupAt > 0
                && Time.time > cleanupAt 
                && cleanupAfter.Value != CleanupType.None)
            {
                //Jotunn.Logger.LogInfo($"Cleaning up {name} because current time {Time.time} > {cleanupAt}");
                Kill();

                // check again in 5 seconds rather than spamming every frame with Kill requests. In
                // 99.9% of cases the 2nd check will never occur because the character will be dead
                cleanupAt += 5;
            }

            if (nextPlayerOnlineCheckAt > 0
                && Time.time > nextPlayerOnlineCheckAt)
            {
                if (TryGetComponent(out Character character))
                {
                    bool playerOnline = Player.GetAllPlayers().Find(player => player.GetZDOID().m_userID == character.GetOwner());
                    //bool playerOnline = Player.GetAllPlayers().Find(player => {
                        //Jotunn.Logger.LogInfo($"player ID={player.GetPlayerID()}, userID={player.GetZDOID().m_userID}, {name} owner={character.GetOwner()}");
                        //return player.GetZDOID().m_userID == character.GetOwner();
                        //});
                    if (!playerOnline)
                    {
                        cleanupAt = Time.time + cleanupDelay.Value;
                    }
                    else
                    {
                        cleanupAt = 0;
                    }
                    nextPlayerOnlineCheckAt = Time.time + nextPlayerOnlineCheckInterval;
                }
            }
        }

        public void Kill()
        {
            if (TryGetComponent(out Character character))
            {
                if (!character.IsDead()) character.SetHealth(0);
            }
            else
            {
                Jotunn.Logger.LogError($"Cannot kill {name} because it has no Character component.");
            }
        }
    }
}
