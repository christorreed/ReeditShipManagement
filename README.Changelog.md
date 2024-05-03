# Change Log
### Reedit Ship Management
[Home](https://github.com/christorreed/ReeditShipManagement/) | [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md) | [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md) | [Change Log](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ChangeLog.md) | [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140) | [Discord](https://discord.gg/Z7UtZBBe) 

## V 2.0.0 (*IN DEVELOPMENT*)

#### Full refactor/rebuild

* RSM has been completely rebuilt from the bottom up with a focus on performance, configurability and ease of use.
* RSM has always been light on performance, but this has been improved significantly with an emphasis on reduced startup impact.
* Additional optional performance monitoring has been added, measuring the impact of individual tasks.
* The RSM codebase is now much more readable and supportable.
* A raft of small bugs and inefficiencies have been fixed.

#### Init it... or don't

* Unlike previous versions, RSM is now fully init-optional...
* **By default, RSM will operate on all blocks on the same construct, regardless of block name.**
* Previous versions required the ship name to be present in the name of all blocks. This behavious is useful for seperating control of merged-on skiffs and in other situations, thus you can turn it back on if you wish by setting `RequireShipName=false`.
* There are other reasons to run `Init:ShipName`, like to remember your current inventory counts and subsystem integrity values. You can now add options after the ship name...
* `Init:ShipName:NoNames` will prevent renaming of any blocks.
* `Init:ShipName:NoSubs` will prevent overwriting current subsystem health values
* `Init:ShipName:NoInv` will prevent overwriting current inventory values
* These can be combined and are case insensitive: `Init:ShipName:NoSubs:noinv`

#### Massive config improvements

* RSM now generates configurations in custom data in proper ini format, and is more human-readable.
* Save your config to a .ini file, and then edit in an IDE like VSCode for formatting assistance.
* **RSM v2 will not allow you to run a bad configuration.** In the case of a config error, RSM will set all your LCD text pink and display an error. More info under block details. Fix the error, or delete your custom data to reset it.
* RSM v2 is automatically backwards compatible with older configs
* I still recommend a config reset when upgrading if possible by deleting all custom data, recompiling, and re-running `Init:ShipName`
* Stance config now supports inheritance; set the name of the inherited stance, and then only list 
* Note that, unlike previously, RSM only parses your custom data configuration on *Recompile*. This is for performance reasons.

#### Fully rebuilt User Guide

* Tried to make it both easier to get started quickly, and also more thorough for those who want to understand all of the details.  I bet you're missing something...
* Read it on [GitHub](https://github.com/christorreed/ReeditShipManagement).

#### Improved Extractor Management

* Extractor management now automatically speeds up or slows down depending on your fuel percentage.

#### Stance Changes

* New Stance WeaponsHot which engages weapons without touching your drives.
* Seldom used stances MaxCruise, Coast & Sleep removed from default stance list.
* Stance names are no longer case sensitive in stance set commands.
* New stance options for all thrusters for more granularity, including no change to leave drives un touched, and additional options for atmo/chemical drives.
	* Note default stance updates will not effect existing ships/existing stances.  To update to the new stances, clear all stances from custom data.

#### Improved Weapons Management

* Weapons auto config now also turns on "***Target Sub Systems***" for all weapons and "***Target Biologicals***" (at stance set).
* Detailed description of weapons management, how to use it, how to disable it, all in the updated guide.
* Added support for the Kess and associated 180mm rounds
 
#### Improved Thruster Management
* New tag, default "`Docking`", sets Epstein drives to turn on when they would otherwise be turned off if RCS mode = 1.  In other words, add "`.Docking`" to the end of the name of an Epstein drive to use it in Docking stance.
* Additional stance options for main drives and RCS now also offer options for controlling chemical and atmo thrusters, per stance.

#### Improved Reactor Management

* Autoloader is now operating on reactors as well.
* Fusion fuel will be forced into reactors and balanced between reactors automatically.
* Reactors are now forced on.

#### Added LiDAR Support

* LiDARs are now forced on along with the "keep alive" setting, available per stance.
* New message on warnings LCD if LiDAR isn't working

#### Improved Hudlcd Command * Filtering

* In addition to the existing hudlcd commands, it's now possible to add an additional argument to filter LCDs by name.
* For example, `hudlcd:toggle:[RSM]` will toggle hudlcd on all RSM LCDs.

#### New Command: Unlock Doors

* New command allows you to open your ship up for inspection by unlocking all doors.
* Use `Doors:Toggle`, `Doors:Locked`, `Doors:Unlocked` to control the "*Anyone Can Use*" setting on all doors on the ship.
* Like Hudlcd commands, Door commands also support filtering by block name.  For example, run `Doors:Unlock:Airlock` to only unlock airlock doors.
* The warnings LCD now displays a count of Insecure Doors if any are unlocked.
* Any stance which sets rails to weapons free will also automatically lock all insecure doors (i.e. `Combat`, `CQB`, `WeaponsHot`)

#### Fixed and Improved Auxiliary Blocks Functionality

* Auxiliary block functionality is now fully operational once more.
* By default, configured for use with Auto Repair welders.  Tag welders, plus any alert lights etc, with `[Autorepair]` and they will be engaged during `Combat`, `CQB` & `WeaponsHot` stances.
* Change the keyword to whatever you like, and adjust the aux state per stance as required.  This can be used to turn any blocks on/off per stance.
* Aux state with count is now visible on the warnings LCD.

#### LCD Colour Sync

* LCD colour sync now supported for non-RSM screens.
* Add `[CS]` to the name of any LCD, and RSM will change it's text colour to match the current stance.

#### Improved Battery Management

* Stances configured to discharge batteries (Combat, CQB & WeaponsHot) now will actively toggle between Discharge & Auto based on railgun targets.
* Basically, if any railgun on the ship has an active WC target, batteries will be set to Discharge, otherwise, Auto.
* This new functionality is enabled by default, but can be disabled in custom data if you prefer the old functionality.

#### Improved Block Naming At Init

* Improved Init naming for refill stations, cockpits/consoles/seats, kess cannons, toolcore tools
* Added type to Init naming of railguns (eg `Shipname.Railgun.Zako`) like PDCs, torpedoes.
* Added type to Init naming of epsteins (eg `Shipname.Epstein.Tachi`).
* Add type names to weapons at init now enabled by default
* Added some categorisation, such as `ShipName.Power.Battery` or `ShipName.Power.Reactor.MCRN`

#### One Touch Airlock Improvements

* Improved handling of multiple vents in airlocks.
* Airlocks no longer blow out if the vent airlock is off.
* Vents are now forced on along with the "keep alive" setting, available per stance.
* Airlock vents are now automatically configured to depresurize.

#### Added NavOs integration, improved Pb management

* Now set your NavOS burn percentage, and optionally force an Abort, per stance, same as EFC.
* Commands to other Pbs now buffer up and are fed over several runs to prevent errors.

#### Other Changes

* Now monitoring subsystem integrity for cargo containers (based on actual capacity) and welders.
* Improved spawn management, including a warning if no functional spawn is present.
* Fixed battery display bugs on subsystem integrity lcd.
* Now counting steel plates on inventory display screen
* New default ignore keyword: `[I]`
* Improvements to inventory counting
* Fixed a bug causing ships which only had one controller to loose telemetry
* Removed beacon-based drive sig output display from LCDs
* H2/O2 levels now show relative to init value, not current max capacity
* Ignore keyword now prevents autoloading on weapons
* RSM now optionally supports m/s^2 as a acceleration value rather than Gs, configurable in custom data
* Improved version naming with build date.
* Updated RSM thumbnail image
* Removed old beacon-based signal data from display (custom hud now)

## V 1.99.58 (BETA) (2024-05-04)

* Fixed crashes on deleted blocks, including cargos, reactors and antennas.
* Fixed issues with the battery discharge management changes.
* Fixed a bug that caused doubled up items in the inventory list.
* Removed spawn open command warning, added a spawn is open constant warning.
* Improved debug output on boot.
* Removed some superfluous logs
* Fixed a number of battery init and subsystem display bugs

## V 1.99.56 (BETA) (2024-04-29)

* Fixed a bug with discharge management.

## V 1.99.55 (BETA) (2024-04-29)

* Added support for ToolCore tools in auxiliary management. Tools tagged with the aux keyword will be activated/deactivated as required.
* Discharge management is now a stance option rather than a global setting.
* New stance option is the new default for combat stances, however existing beta users will need to reset stances to apply this (or change in custom data manually).
* Discharge management will only discharge if there are no functional reactors on board
* Fixed all bugs with fusion fuel/fuel tanks/jerry cans/ammo critical warnings.
* Fixed a bug with stance lighting colours
* Fixed an init naming bug with aquariums, kitchens.
* Fixed crash on removed torpedo launcher

## V 1.99.54 (BETA) (2024-04-22)

* LCD ammo warnings now use friendly names
* Starboard nav lights now green
* Fixed HUD lcd defaults not working due to custom data parsing error
* Fixed a few errors in default stances
* Fixed incorrect no fuel tanks warnings
* Renamed fuel tanks to fuel cans
* Fixed a bug with the basic thrust header, removed it from the hud default
* Fixed a few other small LCD output bugs.
* Removed some overly verbose logging

## V 1.99.53 (BETA) (2024-04-18)

* Fixed name not saved during init
* Added support for shotgun PDCs
* Improved ammo critical warning output
* Improved lcd booting output
* Split init operations over several runs for improved performance, added LCD output to show.
* Other minor refactors/improvements

## V 1.99.48 (BETA) (2024-04-15)

* Added improved spawn management, including more frequent power on commands, and an LCD warning on a no functional spawn condition.
    * Thanks @snek, @brillcrafter
* Fixed LCD output bugs in thrust section
    * Thanks @brillcrafter

## V 1.99.47 (BETA) (2024-04-11)

* Added ReactorFillRatio .
    * Default value 0.5, this is the fill ratio RSM will use for reactors (with 3% wiggle room).
    * Thanks @mkaito, @draconb
* Set dynamic battery discharge management to toggle between `Discharge` and `Recharge` rather than `Discharge` and `Auto`
    * Thanks @snek
* Removed REEDAV hudlcd autoconfig.

## V 1.99.45 (BETA) (2024-04-08)

Released v2 public beta [link](https://discord.com/channels/516135382191177728/1066185228697211030/1226887321010442351)

## V 1.11.1 (2023-12-01)

Fixes a bug with cargo scanning introduced in 1.11.0
    *Thanks @aryemis, @gigawatt9099*

## V 1.11.0 (2023-11-30)

* New Cargo Volume Factor in names at init.
    * @hato2 and I were riffing about how Cargo ***Large*** no longer has any meanying now that we have so many different varieties of cargo.  We love the new blocks, but are nostalgic for the simplicity of the LCC as a unit.
    * With that in mind, instead of adding "Small" to cargo names, `Init:ShipName` will now add a volume factor in LCCs to the name in square brackets.
    * For example, a 7x11x3 Cargo will be renamed to `ShipName.Cargo [8.6]`, as in that cargo holds 8.6 LCCs worth of cargo.  This will order your cargos nicely in the list, and hopefully makes it a bit easier to grasp it's size at a glance.
* New custom data option `Add type names to weapons at init` (default `False` lol @dj8552).  If `True`, init will append type names to weapon (eg `ShipName.Torpedo.Ares` instead of `ShipName.Torpedo`)
* Now supports Artemis launchers.
* Improved, simplified naming at `Init:ShipName` for connectors, cockpits, cryo chambers, solar panels, medical rooms, lidars, sorters, timers, fixed cannons, chem thrusters, suspensions, grav gens, clamps, mag locks, landing gears & button panels.  Kitchen and aquariums are categorised as lights, but have names appended afterwards.
    Massive shout out to @gigawatt9099 for suggestions on most of the name improvements.

* This isn't a change, but I just wanted to make an additional note related to the numbering functionality from the previous version.  It doesn't support all block types...
    * Blocks that do support numbering include lights, PBs, Extractors, Batteries, Beacons, Gyros, Hangar Doors, Antennas, Vents, RCS, Epstein Drives, O2 Tanks, H2 Tanks, Cargos, H2 Engines, Reactors all weapon types.
    * Other blocks like Connectors, Merge Blocks, Doors etc do not support numbering.  This can change in the future if requested

## V 1.10.0 (2023-11-30)

* One random new feature: selective block numbering at init.
    * As requested by @raz19 and @aryemis.
    * When `Init:ShipName` renames all of your blocks, it can also automatically number them for you.  Previously I had basically removed this from all blocks, but sometimes you might want to number them, such as while debugging a problem with your ship.
    * If so, add that block name to the new `Number these blocks at init` setting in custom data.  For example, if you add `Lights` all lights will be numbered within different categories.  If you add `Lights.Exterior` only exterior lights will be numbered.  You can add multiple blocks to this list, just separate them with a comma (eg `Lights, Cargo`).
    * Note that on each `Init:ShipName`, the numbers will be reset and may change.
* @reckless0661 was right; current thrust output was borked.  Borked no more.
* @gigawatt9099 pointed out that there was a bug causing light names to become ever longer.  Now fixed, and should automatically correct any of these errors next time you run `Init:ShipName`.

## V 1.9.1 (2023-11-05)

**HUD6: HUD1 LCD Overlay**
    * Hudlcd is awesome, but since it doesn't support sprites, it's hard to add different colours to the interface... unless we use an overlay.
    * Optionally, name a 6th LCD with `[RSM].HUD6` and run `Init:ShipName` to add an overlay to the header LCD.
    * You can even use place a transparent LCD over a normal LCD to achieve the overlay effect which is visible in the cockpit.
    * Note that the default hudlcd configuration has changed, and some LCDs will be moved to different parts of the screen from previous versions when using the `Init:ShipName` command.

**New Header LCD**
    * Header LCD has been updated
    * Header screen now shows a quick status light for Fuel, Oxygen, Power and Weapons.
    * Additional status lights might be added in subsequent rows later (open to suggestions).
    * There's also a new spinner which uses the overlay.

**New Warnings LCD**
    * The comms, doors and auxiliary LCD sections have been removed, and some of the other sections have been shuffled slightly on the default hud configuration in order to make room for a new section, the Warnings LCD.
    This LCD is designed to be a quick, prioritised list of things you need to know..
    * The results of  RSM commands are displayed at the top of the list.  For example `Spawns were opened to friends`, `Init:ShipName`
    * RSM will add warnings for important fuel conditions, such as empty reactors, low or no fusion fuel, low or no fuel, low or no fuel tanks, no extractor, low battery etc.
    * RSM will add warnings for unsealed vents, open doors, antennas broadcasting, blocks owned by a different faction and more.
    * RSM will add warnings for low or no ammo, and will tell you which kinds of ammo.
    * **If you can think of any other useful warnings to test for, hit me up :)**

**Subsystem Integrity LCD Improvements**
    * To the right of each subsystem integrity percentage, I've added a quick readout which shows what the subsystem is configured for within the current stance.
    * For example, Railguns can be OFF, HOLD or FREE, and batteries can be AUTO, CHG or DCHG, as determined by the currently selected stance.

**Stopping Distance Output Improvements** *Special thanks to @germstorm*
    * Stopping distance calculations will now display values relating to thrusters currently switched on, unless all are switched off.
    * This means, if only half your thrusters are on (such as during the 'StealthCruise' stance), RSM will calculate stopping distances and times for those thrusters that are on only, making it a lot easier to calculate stop times in complicated environments.

**Weapons Ammo Balancing** *Special thanks to @reckless0661 *
    * Especially now that torpedo magazine sizes are much higher, it's more important to ensure all torps get their share of ammo.  In previous versions, the autoloader would put all available torps in the first launcher, for example.
    * In this version, once all ammo in cargo is exhausted, RSM will begin to run additional calculations to balance ammo between weapons of the same time.
    * Ammo will be balanced to within 10% across all weapons of the same type.
    * RSM will also actively remove torpedoes from a launcher if a different ammo type is selected prior to autoloading, so that there's room for the correct ammo.

**Improved Inventory Counting**
    * RSM now counts the ammo inside weapons, as well as the ammo in cargo, for the total shown on the inventory screen.
    * RSM now counts inventory items stored in connectors and collectors.
    * Farren and Foehammer ammo levels now on inventory screen, and setup for autoloading.

**PDC Manual Control** *Special thanks to @hato2, @danimal10055 *
    * While some players have reported that they love the way RSM manages PDCs, especially around targeting of grids between the Combat/CQB stances, others would prefer RSM keep its hands off those settings.
    You have two options if you don't want RSM to manage this behaviour...
    * Per stance, PDCs now have an additional option, 4.  If selected, PDCs will still be forced on, but all other settings will be left at that point.  This does mean you can still auto configure your PDCs with RSM, but can choose to leave it alone for manual control in some stances.
    * If you don't want RSM to control these settings at any point, you can disable them globally.  Just set `Automatically configure PDCs, Railguns, Torpedoes` to `False`.  RSM will still manage power for you, and so will switch PDCs on as you leave the trade zone, for example, but other settings won't be touched by RSM at any point.

**Miscellaneous**
    * Note that the unminified code has now exceeded the character limit.  Obfuscation of the code brings us way back down to like 60%, but it does make things a bit harder to read.  This was always kinda inevitable as more features were added, and it doesn't change my commitment to the developer promise as always, and the complete and unobfuscated code is available on github.
    * Added runtime profiling thanks to  Lurking StarCtpn's library.  RSM only runs once per 100 ticks, and at it's worst should consume 1%-2% of your runtime limit, so it shouldn't be too much of a problem, but I'm keeping an eye on it.
    * A variety of bug fixes and minor changes.

## V 1.7.0 (2023-09-22)

**One Touch Airlocks**
    * I like RSM's fairly simple, nexus proof automatic doors, BUT I HATE WAITING IN AIRLOCKS!  So, now we manage airlock vents as well to minimise time spent waiting.
    * Basically, you can now configure a vent for an airlock in the same way you configure a door (use a name like `Ship.Vent.Airlock.AirlockIdentifier`) and the door will open as soon as the vent reports sealed and depressurised.
    * Now you only need press to open the first door, RSM will close it behind you, and then open the next door as soon as possible.
    * It will turn the door on anyway after the timeout even if the vent isn't ready, but won't open the door automatically.
    * This is intended for use with a vent on depressurise; this makes for simple, fast, lossless airlocks.
    * It doesn't support airlocks with more than 2 doors.

**Improved Railgun Management**
    * Railguns stance values of 1 or 2+ are now processed to toggle between key fire and ai control.
    * The intention here is that when in a stance like **Cruise** or **Docking**, Railguns (& Coilguns) will be switched on, will provide their radar, but won't actually fire (unless you do so manually).  If we go instead to a stance like **Combat** or **CQB**, we want our weapons free.
    * This is really a bug fix; custom data always implied this should be happening, it just wasn't.
    * As a reminder, you can edit the stances to suit you, if you prefer different behaviour.
    * You can always ignore a particular weapon by adding the ignore keyword to it's name, or disable this entirely entirely by setting `Automatically configure PDCs, Railguns, Torpedoes.` to `false`.

**Private Spawn Mode**
    * New option in PB custom data `Private spawn`.  False by default (no change to default behaviour) but when true your faction tags will **not** be injected into the custom data of survival kits.
    * This offers reduced protection against theft, but does close your spawn to other members of the same faction.
    * Other functions of spawn management will continue to operate.  RSM will clear out your spawn custom data to prevent hacking, and the `Spawn:Open` and `Spawn:Close` commands will continue to work.
    * For related reasons, it's also been decided that RSM will no longer inject data into or power on SK's on docked ships.  It will only effect SK's on the current construct, like most other RSM functions.

**Improved Low Ammo LCD Alert**
    * RSM will now display prominent low ammo warnings on the inventory LCD section.
    * These warnings are triggered by the autoloader when the actively selected ammo for one of your weapons cannot be auto loaded because there are none on your ship. This indicates at least one of your weapons needs more ammo and can't get it!

**Vent Management**
    Along side the airlock improvements, this new version now adds some basic vent status under the Doors LCD section.

**Low Value Bar Animation**
    * When one of the bars on the RSM screen goes below 10%, it now flashes a cool little animation to let you know a value is low.

**Bug Fixes & Minor Changes**
    * Small fixes to the default stances and how rails/torpedoes are processed at stance change.
    * Added rounding on Max Power values.
    * Other minor bug fixes

## V 1.6.0 (2023-09-05)

**New Max Power output value on LCD** *As requested by @pixelworld*
    * This value shows the total max output capacity of all functional reactors and batteries.
    * Use it to determine your ships ability to keep fighting after taking damage, especially with railgun ships with large power draw requirements.
**LCD Improvements**
    * New headers on each LCD section.
    * Minor changes to the spinner, now visible in each header.
    * Improvements and bug fixes to the battery subsystem integrity display
    * Percentage bars on screen will now flash with `!` when below 10% to catch your eye that you're very low on something.
**Auxiliary Blocks**
    * Rebranded the functionality previously known as AutoRepair to Auxiliary.
    * If you are using AutoRepair already, this change shouldn't prevent that at al
    * This allows the functionality to be used for other things and given a custom name as required by setting the Aux Block Keyword in custom data.
**Bug Fixes & Minor Changes**
    * Removed case sensitivity from HudLcd arguments. (thanks @redsavann)
    * Added, changed some content on the readme on GitHub
    * Dampened the `Ammo Low` warning so it doesn't appear constantly.
    * Other minor bug fixes.

## V 1.5.0 (2023-08-12)

* **Built in RSM Weapon Auto-Loader (i.e. ammo puller)**
    * Many players have been running *AmmoPuller* or *RSU* scripts separately in order to force load weapons.  Well, RSM already has a nice list of all of your weapons, and was already counting ammo quantities... so might as well load them as well.
    * RSM now loads the selected ammo type into each weapon automatically.
    * A new option has been added to PB custom data to disable auto-loader functionality if required.
    * For *reasons*, auto-loader functionality works on all weapons, including those with the ignore keyword.

* **New RCS Option: Forward/Reverse RCS Off** *As requested by @danimal10055*
    * Some players like to turn off forward RCS thrusters while cruising.  Since your Epstein drives are more efficient, you can save on fuel by not running RCS when you press `W`.  Set an RCS mode of 2 for the stance in PB custom data.
    * Other players like to cruise with reverse RCS off, so they can retain dampeners without the ship always trying to brake.  For this, set an RCS mode of 3 for the stance in PB custom data.
    * RCS mode of 2 (forward RCS off) will now be the default for the `Cruise`, `StealthCruise` & `MaxCruise` stances.

* **Improved Advanced Thrust LCD Output**
    * The advanced thrust screen has been revamped somewhat.
    * Additional configuration options available in PB custom data, such as the ability to choose which percentage thrust values to display, and if to show or hide certain elements.

* **FINE! LCD text doesn't have to be blue!** *As requested by @germstorm * 
    * Some players who are lacking in taste (:stuck_out_tongue_closed_eyes:) didn't like being forced to use sexy RSG blue (33, 144, 255) on all LCDs, nor how RSM enforced it aggressively.
    * By default, RSM now uses the interior lighting colour as the text colour on all LCDs.  This means your LCDs can change colour with each stance just like lights. 
    * Some small adjustments to some interior light colours to better suit this change.
    * There is a new global option in PB custom data to disable text colour enforcement all together.  In this case, RSM won't touch your LCDs at all, and you can make them whatever colour your heart desires.
    * Some small adjustments to some interior light colours to better suit this change.

* **Inventory Counts now automatically set on `Init:<ShipName>`** 
  The inventory screen is helpful, but it's a pain in the bum to go and manually set limits for each one.  Now this will be determined automatically when `Init:<ShipName>` is run, counting the number of items currently in the ship, and setting those numbers as the targets for each.

* **New Command `InitBasic:<ShipName>`**
  This command is exactly the same as the `Init:<ShipName>` command, except inventory counts and block integrity counts will not be saved.  This means u can still tidy up block names with a damaged/not full ship without resetting other parts of the configuration.

* **Added Support for new torpedo types**
  RSM now supports the new Ramshackle, UNN and MCRN torpedoes, will auto-load them, and will display them on the inventory screen.

*Note: changes to default stances won't occur without resetting your PB custom data!*

## V 1.4.1 (2023-07-30)

Recently seems like something is broken in WC related to repel mode.  Specifically, WC is always reporting that repel mode is on, even when it is off.  Because RSM can't send discreet commands to control repel, it's checking this variable and then sending a toggle command when required.  **This behaviour is forcing all rails and PDCs onto repel mode when any RSM stance is engaged!**

As a result, I've just pushed a bug fix which removes all repel mode control.  I'll dig into this further later, and will probably report a bug to the WC dudes.  For now, recommend the following immediate changes...
* update your RSM to the latest version, **v 1.4.1**
* check all weapons for repel mode and adjust accordingly.

## V 1.4.0 (2023-07-14)

* **New default PDC configuration** As per testing since the recent update, @danimal10055 has made some recommendations on improvements tot he default PDC configuration.  Repel mode will now only be used by PDCs tagged as defence.  This is because repel mode has been found to be much less effective against torpedoes since the recent update.  **Recommend all users update to v1.4.0 to get the most out of their PDCs**
* **Added support for Coilguns** RSM now supports the new Coilgun.  The coilgun will be named appropriately by init, but otherwise treated like a railgun.

## V 1.3.0 (2023-07-07)

* **New Subsystem Integrity Monitoring** *as requested by @buranimo*
    * New LCD screen called Subsystem Integrity gives a quick, at-a-glance readout of integrity of each ship's sub system.
    * Think of this as SIMPL-lite, with all the information you need about the health of your ship, without the pretty pictures.
    * At `init`, the maximum integrity is measured and stored into custom data.
    * Rather than a simple count of the number of blocks or HP, the RSM subsystem integrity hedges the value based on a block's capacity.  For example, reactor integrity is calculated based on maximum power output, so losing a large reactor will have a greater effect on overall 'Reactor Integrity' than a small one.
* **New Lighting Control Options** *as requested by @germstorm*
    * There is a master lighting control switch, just set `Disable lighting all control = true` and lights will no longer be effected on stance change. 
    * There's also a new option 3 for all lighting power states which is simply no change.  This means you can leave certain groups of lights alone if you prefer instead.
* **Decel now accounting for the additional thrust due to dampeners** *as requested by @germstorm*
    * The output previously refered to as `Decel (Best)` will now be called `Decel (Dampeners)` and adds a 1.5x buff to thrust in order to accommodate for the weird af extra thrust you get from braking with dampeners.  Germ and I will keep tweaking this to keep those numbers accurate.
* **Improved Stance Persistence**
    * The PB save functionality doesn't play nice with Nexus, now storing current stance info in custom data, making for more persistence stances on ships during restarts/instance transitions.
* **Backend improvements and bug fixes**
    * improved the parsing of LCD custom data to provide for better resilience.
    * removed some superfluous lists and functionality to improve performance.
    * other minor changes...

## V 1.1.1 (2023-06-24)

* **Block ownership check:**  As suggested by @buranimo﻿, I'm not running a basic ownership test frequently.  If unowned blocks are detected, a warning will appear on LCD saying `!!UNOWNED BLOCKS!!`.  Doesn't do anything else yet, but I'm open to further suggestions.
* **Minimum Drive Stance Option:** New Epstein drive setting available for stances; 2=minimum thrusters only.  There is a keyword, `Min` by default but configurable.  In this mode, only drives with the keyword will be turned on, others will be turned off.  New default stance **StealthCruise** is the same as the Cruise stance, except with only min drives.
* **RSM now automatically turns Survival Kits, Medical Rooms on** unless they contain the ignore keyword.
* **Added support for updated DX weapons.**
* **Weapons Config Change:** Small changes to the way RSM auto configures Railguns, Torpedoes.
* **Assorted Bugfixes**

## V 1.0.2 (2023-06-19)

Fixed a bug with alternative delimiters not working on some blocks.

## V 1.0.1 (2023-06-18)

Fixed a crash on malformed command (without argument)
*thanks to @buranimo*

## V 1.0.0 (2023-06-18)

* Instead of an annoying steam guide, everything has been moved to github
* There is a new quick start guide to help get new players up and running.
* I'm calling this the first release version, so we're starting at 1.0.0

## V 0.12.2 

* Added support for 80mm Railgun rounds (T-47)
* Fixed a bug with spawn custom data obfuscation.

## V 0.12.1

Fixed a small bug with default hudlcd configs.

## V 0.12.0

* Added acceleration output both max and actual to thrust and advanced thrust output pages.
* Spawn custom data management now effects all SKs and MRs regardless of block name, or construct.  RSM now fully cleans all spawn custom data for you automatically.
* Spawn custom data now includes spacing for obfuscation. 
* Added support for sloped PDCs
* New custom data option automatically sets spotlights to max radius per stance.  Default now for 'Docking' stance, but willrequire custom data reset/adjustment for existing ships.
* Hid the title line REEDIT SHIP MANAGEMENT from the header LCD
* Replaced the 'idle' LCD status bar with a . .. ... pattern
* Cameras, sensors now have better name tidying on init.
* Added default hudlcd configurations.
    * Setup 4 LCDs and name them `<shipname>.LCD.[RSM].HUD1 to <shipname>.LCD.[RSM].HUD4`
    * Now run init.
    * RSM sets up HUD LCDs perfect for a 16x9 layout.

## V 0.11.0

Improved LCD output 

## V 0.10.0

* New command with 3 arguments: 'hudlcd:on', 'hudlcd:off',  'hudlcd:toggle'
* Hudlcd is game changing, but sometimes you just want it to piss off and take in the stars around you.  The new commands search
* custom data of every LCD on the ship, and adjust the name in order to remove, or re-add, them to your hud.  Note that the
* command effects all LCDs, including ignored ones.

## V 0.9.1

The basic thrust lcd output now defaults to 500ms when stationary, like the one from the advanced view.

## V 0.9.0

Added support for HudLcd plugin.  You can now add the text 'hudlcd' into the custom data of RSM LCDs, and it won't be cleared.
Recommended settings: top left= "hudlcd:-.99:.99", "top right= hudlcd:.65:.99"

## V 0.8.3

Bug fixes

## V 0.8.0

* Added per-LCD configuration
    * Screen was starting to get a bit busy with new functionality.  Now you can spread it out across multiple screens.
    * Configure in custom data of each LCD.
* Added stop distance calculation to the RSM LCD (as inspired by Germstorm)
    * A single line stopping distance is provided on the 'Thrust' screen
    * If Epstine drive overrides are off, RSM will calculate a best possible stopping distance based on maximum Epstine thrust (not RCS)
    * If any overrides are on, RSM will calculate an actual stopping distance based on configured thrust.
    * In advanced mode, a whole array of stopping distances are displayed.
* Fixed a bug causing some blocks without the correct naming to be included.
    * Note: if you have issues after this, make sure all blocks have the ship name in them by running init.


## V 0.7.2

* Added crash prevention during PDC auto configuration error.  One player reported issues with PDCs which was causing a crash.
* I've prevented this crash, even though I can't replicate it.  It will throw an error if this occurs to you, if so recommend you grind and rebuild your PDCs as the repel mode function is bugged.
* Also removed the auto fire mode control on railguns and torpedoes.  I think it was working, but feedback was bad in the menu.

## V 0.7.0

* New option for extractor management; 3: keep ship tanks full.  In this mode, extractor is loaded sooner to keep fuel tanks on ship at max.
    * Specifically, fill up will occur when there is room for 3 fuel tanks components worth of H2 in the ship tanks.
    * Note: This mode is now the default for most stances. You can revert to 2; fill ship up at 10% to retain current settings
* Improved survival kit custom data management.
    * New option in PB Server custom data; friendly faction tags or steam IDs.
    * They will saved to the custom data of your SKs automatically.
    * You can also toggle this on and off with the command 'Spawn:Open' or 'Spawn:Closed'. If closed, friendly tags are removed from all SKs.
    * Note: off by default, must run 'Spawn:Open' to set this up.
    * Add faction tags like 'RSG' or steam ids like '76561198217763901'.
    * Add multiple by seperating with commas.
* Comms commands now permit spaces (ie for command 'Comms:Hello There', antenna was "RSG:HelloThere" is now "RSG:Hello There")
* Fixed a bug related to crashing during stance calls with high EFC burn percentages, such as during Stance:MaxCruise

## V 0.6.1

Fixed tank stockpile error

## V 0.6.0

* Battery discharge functionality added to stance management.
* Combat and CQB default stance data updated to discharge batteries. Note: reset your stance custom data to apply this change.

## V 0.5.1

Spaces are now ignored in all arguments to prevent syntax errors. This means no spaces in ship names

## V 0.5.0

* Added support for some additional inventory items on the LCD...
    * 40mm Tungsten Teflon PDC Boxes
    * 100mm Railgun Slugs (UNN * Dawson)
    * 100mm Railgun Slugs (MCRN * Stiletto)
    * Jerry cans (SG fuel tanks)
    * just a reminder, you can hide any of these by setting the targets to 0 in custom data.
* Added improved support for railguns/torpedoes
    * railguns & torpedoes can now be set to off / hold fire / ai weapons free per stance.
    * railguns & torpedoes will also be auto-configured like PDCs to ensure they are setup correctly.
    * by default, both will be forced into ai weapons free during the combat and CQB stances, though this can be disabled in custom data.
* Improved auto PDC configuration
    * Repel PDCs now automatically set to target biologicals
    * Repel PDCs and normal PDCs in defensive mode will now also target SG to protect against PMWs
* Added support for SG extractors; can now automatically refill H2 tanks via either SG or LG extractors
* Updated default stance behaviours
    * stronger defensive PDC behaviour across most stances by default
    * Defence was renamed to 'Combat' and Offense was renamed to 'CQB', clarifying intended usage.
    * note the above change means that you may be required to update the toolbar to match.
    * just a reminder, stances are configured in custom data, so these changes won't occur unless you reset there, they are only defaults.
* Added option to not change hangar door status with stance.
* Current stance is now retained across instances/restarts. 
* Updated guide to reflect several versions worth of changes.

## V 0.4.2

* Fixed a crash on set stance with certain grids.
* Changed defence PDC default keywork to 'Repel' so it doesn't interact with OPA PDCs which have defence in the name.
* Fixed a bug where repel/defence PDCs & railguns were not processed by the init command.

## V 0.4.1

* Fixed a bug with configurable block name delimiter functionality.
* Fixed a bug with custom data

## V 0.4.0

* Script now automatically adds own faction tag to Medical Rooms and Survival Kits
* Added adjustable delimiter functionality. In custom data you can now set a character other than '.' to be used to name blocks during init.
* I've capitulated and decided to start referring to Programmable Blocks as PB Server rather than Server so it can be easily found.
* No longer numbering servers during init
* Changes to more smoothly permit additional configurable custom data options.

## V 0.3.3

* Added a delay to fuel extractor management retries so it won't constantly attempt to refuel.
* Minor bug fixes.

## V 0.3.2

Improved init function autonaming of LCD blocks.

## V 0.3.1

* Fixed a bug caused a crash if no antenna.
* No longer forcing LCD padding.

## V 0.3.0

*Added projection offset and orientation mangagement with projectors:save and projectors:load commands
*Added keep alive functionality to Sensors, LCDs & Cameras
*Getting comms value from first antenna hud text rather than local variable
*No longer forcing Focus Fire to PDCs in Offence stance.
*Fixed bugs with fuel percentage calculations
*Fixed crash on command to destroyed block.
*Fixed crash on extractor management with no extractor on board

## V 0.2.2

Fixed several bugs with the extraction management algorithm.

## V 0.2.1

Fixed a bug that caused block lists to overflow.

## V 0.2.0

* Second release, now on steam.
* Improved init, now can be repeated, so you can update ship names, name new blocks.
* Improved stance management including...
    * stances can now be edited via PB custom data. You can add or remove them as well, it iterates over as a loop.
    * additional features were added to each stances
    * removed 'Combat' and 'Torpedoes' and replaced with 'Defence' and 'Offence'
    * now supports controlling two PDC groups, normal and defence
    * some stance features, like block power state, are maintained every loop.
    * automatic extractor management, automatically load tanks below 10%, if set in stance.
* Setting a target value of 0 in custom data now removes it from the screen.
* Added debug variable, better verbose logging.
* LCD number rounding now the same on bar as text
* Efficiency, stability improvements.
    * Refactored the init and stance code bases for effeciency
    * Fixed crash on no-inventory cockpit block
    * Fixed crash on door custom data parsing error
* Built Guide

## V 0.1.0

Initial release on Discord

## V 0.0.1

Unreleased initial working version