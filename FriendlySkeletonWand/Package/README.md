# Friendly Skeleton Wand

This mod adds a craftable wand which can be used to create skeletons with. These skeletons are supposed to guard your base and hang around the general vicinity of wherever you create them.

## Important Update Note for pre-1.0.8

<details><summary>If you are upgrading from 1.0.7 or lower, your skeletons will still be there but you won't be able to command them anymore! <b>This is not a bug.</b></summary>The old skeletons used the existing Mistlands `Skeleton_Friendly` prefab which belongs to Blood Magic. In 1.0.8 these have been replaced with my own custom prefabs: `ChebGonaz_SkeletonWarrior` and `ChebGonaz_SkeletonArcher`. This gives you the control to choose either kind, instead of it being random, and also stops Blood Magic from levelling up from this mod.</details>

##  About Me

<a target="_blank" rel="noopener noreferrer" href="https://chebgonaz.pythonanywhere.com"><img alt="Necrobase" style="margin-top: 1%" src="minicheb.png" /></a> <a target="_blank" rel="noopener noreferrer" href="https://ko-fi.com/chebgonaz"><img alt="Ko-fi" style="margin-top: 1%" src="kofi-mug-small.png" /></a> <a target="_blank" rel="noopener noreferrer" href="https://www.patreon.com/chebgonaz?fan_landing=true"><img alt="Patreon" style="margin-top: 1%" src="patreon.png" /></a>

I'm a YouTuber/Game Developer/Modder who is interested in all things necromancy and minion-related. Please check out my [YouTube channel](https://www.youtube.com/channel/UCPlZ1XnekiJxKymXbXyvkCg) and if you like the work I do and want to give back, please consider supporting me on [Patreon](https://www.patreon.com/chebgonaz?fan_landing=true) or throwing me a dime on [Ko-fi](https://ko-fi.com/chebgonaz). You can also check out my [website](https://chebgonaz.pythonanywhere.com) where I host information on all known necromancy mods, games, books, videos and also some written reviews/guides.

Thank you and I hope you enjoy the mod! If you have questions or need help please join my [Discord](https://discord.com/invite/EB96ASQ).

## Requirements

- Valheim Mistlands
- BepInEx
- Jotunn

## Installation (manual)

- Drag the `FriendlySkeletonWand` folder from inside the archive to your Bepinex plugins folder in the Valheim directory.

## Features

- Craftable wands at the workbench called **Friendly Skeleton Wand** and **Friendly Draugr Wand**.
- These wands consume **Bone Fragments** to create minions.
- **Bone Fragments** now drop from all creatures when they die.
- With a wand equipped, the following is possible:
	+ **B** will make a skeleton/draugr warrior.
	+ **H** will make a skeleton/draugr archer.
	+ **F** will make all nearby minions **follow** you.
	+ **T** will make all nearby minions **wait**.
	+ **G** will teleport all following minions to your position (useful if stuck or to get them on boats)
	+ **R** to tell minions to **attack** a specific target (this is relatively inaccurate).
- A new **Necromancy Skill**.
- Minion quality increases with **Necromancy Skill Level**:
	+ 0 to 34: Level 1.
	+ 35 to 69: Level 2.
	+ 70+: Level 3.
- Minion health increases with necromancy level.
- Minions ignore collision with the player so you won't be trapped.
- You can make a special cape called the Spectral Shroud which draws spirits to it. If you're powerful enough, they will serve (necromancy level 25). Removing the cape stops them from spawning.
- Tweakable settings by editing the config file.
- A Spirit Pylon which can be constructed to serve as static base defence. It detects nearby enemies and if any are found, it spawns temporary Ghosts to defend the base with.

### Config

~~**Attention:** To edit the config as described, the [Configuration Manager](https://github.com/BepInEx/BepInEx.ConfigurationManager/releases) is required. This is a separate mod. Please download and install it.~~

~~Press **F1** to open the mod's configuration panel.~~

Doesn't work for some reason; please edit the configs manually. Almost everything can be tweaked to your liking.

## Changelog

Date | Version | Notes
--- | --- | ---
20/12/2022 | 1.0.19 | Max HP of minions is now remembered; Add code to make someone only able to command minions they created; in limit mode, existing minions replaced rather showing a msg
16/12/2022 | 1.0.17 | Nice models for the wands; skeleton equipment and damage scales to necromancy level; nice texture for Spectral Shroud; add config option to disable Guardian Wraith (permits purely cosmetic Spectral Shroud); made draugr optionally cost meat as well as bone fragments to create
12/12/2022 | 1.0.16 | Remove version check that kept annoying people; fix Guardian Wraith bug introduced in 1.0.15
09/12/2022 | 1.0.15 | Cleaned out and fixed up config (it contained one error); allow enabling/disabling of individual features (user request); add German localizations by S970X; fix a problem where minions beyond the follow radius could still follow the player
09/12/2022 | 1.0.14 | Rebalanced skeleton health modifiers
07/12/2022 | 1.0.13 | Add Spirit Pylon for static base defence; add **optional** minion limits for those who wish it; change skeleton eyes to blue to differentiate from deadraiser (pink) and enemy (red).
05/12/2022 | 1.0.12 | Add Vulkan support for Linux
03/12/2022 | 1.0.11 | Fix more shaders; add Spectral Shroud -> wraiths only summon when you wear it, and get dismissed when you take it off; removed drops from minions
03/12/2022 | 1.0.10 | Implement fix for Thunderstore Mod Manager that (hopefully) permits it to install correctly.
02/12/2022 | 1.0.9 | Fix some shaders that got messed up (white squares instead of particles on effects like arrow hit); allow minions to generate a little Necromancy XP for their master; fixed a null object exception in Guardian Wraith coroutine
01/12/2022 | 1.0.8 | Big Overhaul → Fully custom prefabs used for minions results in finer control: no more Blood Magic experience; removes randomness of the skeletons so you can choose warrior/archer; permits me to add draugr and wraiths that are not hostile when you log back in; permits me to (in the future) give custom equipment and textures/materials to the minions.
29/11/2022 | 1.0.7 | Add Guardian Wraith; ignore minion collision on player
27/11/2022 | 1.0.6 | Function added to teleport minions to you and to tell minions to attack what you're looking at.
27/11/2022 | 1.0.5 | Fixed a bug where after logging out and coming back in your skeletons wouldn't respond to commands anymore
27/11/2022 | 1.0.4 | Amount of bone fragments dropped by creatures exposed to config file; fixed a bug where at necromancy level 0 a skeleton spawned would instantly die
26/11/2022 | 1.0.3 | Default skeleton health multiplier jacked up to 15.
26/11/2022 | 1.0.2 | All creatures drop bone fragments, skeletons can be told to follow/wait, skeletons health scales with necromancy level.
25/11/2022 | 1.0.1 | Fix a bug that let you create skeletons without the wand equipped.
25/11/2022 | 1.0.0 | Release

## Known issues

- Skeletons can't follow you into/out of dungeons
- Telling minions to attack what you're looking at (by spawning a big stone there - dumb but will be replaced with something more appropriate later)

## Future Ideas

- Equipment for skeletons & draugr  → armor, different weapons, etc.
- Implement ghost minion type.
- Custom models for the wands (no more clubs).
- Fully custom undead types.

## Source

You can find the github [here](https://github.com/jpw1991/Friendly-Skeleton-Wand).

## Special Thanks

- S970X for making the German language localization for the mod.

