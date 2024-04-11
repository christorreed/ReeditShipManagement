# Reference Guide
### Reedit Ship Management
[Home](https://github.com/christorreed/ReeditShipManagement/) | [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md) | [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md) | [Change Log](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ChangeLog.md) | [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140) | [Discord](https://discord.gg/Z7UtZBBe) 

This reference guide goes through each [feature](#Features) and [command](#Commands) in detail.

# Contents

### [Features](#Features)

* [Weapons Management](#Weapons-Management)
* [Block Renaming](#Block-Renaming)
* [Lighting Control](#Lighting-Control)
* [Door Management & Airlocks](#Door-Management-&-Airlocks)
* [Spawn Management](#Spawn-Management)
* [Thruster Management](#Thruster-Management)
* [Weapons Autoloading & Balancing](#Weapons-Autoloading-&-Balancing)
* [Extractor Management](#Extractor-Management)
* [Inventory Management](#Inventory-Management)
* [Projector Management](#Projector-Management)
* [Auxiliary Block Management](#Auxiliary-Block-Management)
* [Ignore Keyword](#Ignore-Keyword)
* [Hudlcd](#Hudlcd)
* [Antenna Comms Management](#Antenna-Comms-Management)
* [Miscellaneous Warnings](#Miscellaneous-Warnings)
* [Debugging and Performance](#Debugging-and-Performance)

### [Commands](#Commands)

* [Init:*ShipName*](#Init)
* [Stance:*StanceName*](#Stance)
* [Spawn:*Open*/*Close*](#Spawn)
* [Hudlcd:*On*/*Of*/*Toggle*](#Hudlcd)
* [Projectors:*Save*/*Load*](#Projectors)
* [Comms:*Message*](#Comms)
* [Doors:*Locked*/*Unlocked*/*Toggle*](#Doors)

# Features

## Weapons Management

DX has an awesome weapons system, but it's also unforgiving. RSM has a few tricks up its sleeve to get you up and started fast, and to make sure your guns are ready when you need them.

### Weapons Tips & Tricks

* **Use CQB stance to target another large grid with PDCs!**
	* In order to improve defensive characteristics, in most cases, RSM configures PDCs **NOT** to target large grids.
	* Run `Stance:CQB` if you are approaching PDC range to enable targeting of grids
	* Dedicated defensive PDCs will not engage large grids ever.
	* This is configurable; if you don't like it, adjust your stances configs! Set PDCs to 'offense' mode (3) for all stances and be constantly ready for CQB, if you prefer.
* **Use Combat or CQB stances to permit railguns to open fire!**
	* In most stances, Railguns are enabled and active, but are have shoot mode set to `key fire`. This acts as a hold-fire for railguns; in this state they will track targets, but never actually fire by themselves.
	* Run `Stance:CQB` or `Stance:Combat` and shoot mode on railguns will be changed `ai shoot`. This acts as an open-fire for railguns, and will have you spewing slugs in no time.
	* For the purposes of RSM, coilguns are treated the same as railguns.
* **RSM supports dedicated defensive PDCs!**
	* Tag PDCs with `Repel` for them to be marked by RSM as defensive PDCs
	* You can change the tag to another value in custom data.
	* Defensive PDCs will never target large grids, and so can help protect against CQB torpedo attacks.
* **RSM Enforces Power Status on Weapons!**
	* RSM will constantly re-enable weapons if you turn them off, as per the config of the current stance.
	* Use RSM instead. You can run `Stance:NoAttack` to quickly disable all weapons systems or `Stance:CQB` to go into fully enabled combat mode.
	* Or else, just turn off the RSM PB; don't bother trying to fight it!
	* Enforcement only applies to power, other settings are only changed once when you set a stance.
* **RSM acts as a weapons autoloader, balancing your ammo amongst all weapons**
	* Read more about that in [Weapons Autoloading & Balancing](#Weapons-Autoloading-&-Balancing).

### Automatic Configuration

By default, RSM will automatically configure your weapons each time you set a stance, to suit that stance.

***I'm always looking to improve the logic of automatic weapons config. If you think any of the settings should be changed, let me know!***

If you wish, you can disable this functionality in custom data, and none of these values will be touched, only power on/off.

For all weapons that are enabled in the current stance, the following settings are automatically configured...
* Target Projectiles: True
* Target Grids: True
* Target Large Grids: True
	* This setting is set to false for defence PDCs, and all other PDCs not in offence mode
* Target Small Grids: True
	* This is set to false for torpedo launchers
* Target Sub Systems: True
* Target Biologicals: True
	* PDCs only
* Focus Fire: False
	* This is set to true for torpedo launchers
* Repel Mode: Off
	* Repel mode is true for defence PDCs
* Shoot Mode
	* Railguns only, this setting is used to toggle between open fire (ai shoot) and hold fire (key fire), as per the current stance.

### Stay Away From My Guns!

Some players want RSM to leave the guns alone.  If you have a complex configuration, or prefer manual control, it may be preferable to disable weapons automatic configuration.

* In custom data, set `AutoConfigWeapons=false`, and none of the above settings will be adjusted.
	* RSM will still enforce weapon power status, but no other settings will be adjusted in any stance.
* You can also use the [ignore keyword](#Ignore Keyword) to ignore certain weapons you don't want to be touched by RSM at all.

If you're doing this because you think I'm configuring the weapons incorrectly, let me know, I'd love to improve the weapons logic instead.

## Block Renaming

When you run `Init:ShipName`, RSM will rename all of the blocks on your ship.  There are a few tricks to getting the most out of this process, but once you understand, you can easily retain info in names and run the `Init:ShipName` command over and over again without problems.

You can also choose not to rename your blocks at when running the `Init:ShipName` command. For more info, see [Init](#init).

### Block Naming Syntax

	ShipName.BlockType.Retained Data
	eg
	RockHopper.Connector.Fwd

### Block Naming Tips and Tricks

* **If you want to make sure RSM retains some part of a name, make sure it occurs after two dots!**
	* For example, suppose you rename your camera to `Camera Fwd`, then I later run `Init:RockHopper`, this will be renamed to `RockHopper.Camera`, and the `Fwd` will be lost.
	* So do this instead... rename the camera to `..Fwd`, then later run `Init:RockHopper`, this will be corrected to `RockHopper.Camera.Fwd`.
	* I tend to stack these with further `.`s, like `RockHopper.Camera.Connector.Fwd`.
	* Sections of retained data that only include numbers won't be retained, so add another character if you want to keep them.  For example `RockHopper.Camera.1` will be cleaned up to `RockHopper.Camera` so use `RockHopper.Camera.#1` instead.
* **Delimiter:** Don't like using a `.` as the delimiter in every name? You can configure this to any other char in custom data, other good options include `[space]`, `_` or `-`.
* **Numbering:** RSM does support numbering of some blocks as well.
	* To number blocks, add the block name to the new `Number these blocks at init` setting in custom data.
	* For example...
		* If you add Lights all lights will be numbered within different categories.
		* If you add Lights.Exterior only exterior lights will be numbered. 
	* You can add multiple blocks to this list, just separate them with a comma (eg Lights,Cargo).
	* Blocks that do support numbering include lights, PBs, Extractors, Batteries, Beacons, Gyros, Hangar Doors, Antennas, Vents, RCS, Epstein Drives, O2 Tanks, H2 Tanks, Cargos, H2 Engines, Reactors all weapon types.
	* Other blocks like Connectors, Merge Blocks, Doors etc do not support numbering.  This can change in the future if requested
	

## Lighting Control

RSM sorts all lights on your ship into four categories...

* **Interior Lights**
	* All lights which contain `interior` in their name will be set as interior lights.
	* Colour is set per stance.  Interior stance colour is also used at the LCD text colour.
* **Navigation Lights**
	* All lights which contain `nav` in their name will be set as navigation lights.
	* These are intended to be used as red and green navigation lights, with red on the left (port) and green on the right (starboard).
	* Navigation lights which contain `starboard` in their name will be set to green, all others will be set to red.
	* Navigation lights can be enabled or disabled with each stance. When disabled, they are also set to black to ensure they are extra dark.
	* Be cool like me, and configure these to flash in sequence as well!
* **Spotlights**
	* Spotlights are detected automatically by their type, not their name.
	* Spotlights can be switched on/off per stance, and you can also force them to max radius when a stance is called.
	* RSM doesn't edit spotlight colours, set that manually.
* **Exterior Lights**
	* All lights on the ship not in another category will be set as exterior lights.
	* Colour is set per stance.
	* Default stances such as `Combat` or `StealthCruise` set the lights to black, as well as switching them off.  This helps keep the ship extra dark and hard for enemies view in combat situations.

And here's a few more tips related to lighting...

* **Not enough categories? Want one random light to be a different colour...?**
	* Use the ignore keyword, default (`[I]`) set in custom data, to simply ignore the light in question, then you can control it manually.
* **Don't want RSM to mess with your lights at all...?**
	* Lighting control can be disabled completely in custom data.
* **Don't like the LCD text colours matching the interior lights...?**
	* You can disable LCD text colour enforcement in custom data.


## Door Management & Airlocks

By default, RSM will automatically shut all doors on your ship after 3 seconds.  You can configure the time length in custom data.

RSM can also be setup to automatically manage airlocks. When configured correctly, RSM controlled airlocks should never lose air, and should get you through as fast as possible with only one press.

Here's how to set that up...

* All airlocks need an identifier which will be added to the names of blocks
	* I recommend something short like `Main` or `Fwd`.
	* It must be unique for every airlock
	* This example will use `Main`.
* Name both doors...
	* The Sytax should be `ShipName.Door.Airlock.Identifier.EasyName`
	* In this example, we will use...
		* The name of the inner door should be `ShipName.Door.Airlock.Main.Inner`
		* The name of the inner door should be `ShipName.Door.Airlock.Main.Outer`
* Name at least one vent...
	* The Sytax should be `ShipName.Vent.Airlock.Identifier`
	* In this example, we will use `ShipName.Vent.Airlock.Main`
* The vent will automatically be set to depressurise.
	* There are more realistic ways to setup an airlock, but vent on depressurise all the time is the most practical for Space Engineers and makes the overall experience much faster.

That's it, you're done. RSM will refresh every now and then, or you can force it to detect the change by recompiling.

Simply open either door to operate.  It should work like this...
* Open either door and walk into the airlock.
* Shortly after this, RSM will disable the opposite door, to prevent a blow out.
* Close the door behind you after the normal door timer has expired.
* The vent will suck all air out of the airlock into ship tanks.
* As soon as the vent detects that all air is clear, it will re-enable and open the opposite door. Exit the airlock, it will close and reset behind you.
	* Coming into your ship from void, this should occur as soon as the outer door closes.
* If a depressurised condition is never reached (such as if your O2 tanks are full), RSM will wait for the door airlock timer to expire, and then open anyway (default 6 seconds).

RSM turns off the opposite door in an airlock to prevent you accidentially opening it and blowing the lock, releasing all air.  In an emergency, you can blow the airlock by opening the first door, then turning on and opening the second door, or by disabling RSM before you start.  Generally this happens so quickly, you won't find yourself wanting to blow it except in extreme situations. 


## Spawn Management

RSM has some features to handle spawns, such as survival kits or medical rooms.

* You may be aware that spawn custom data is a vulnerability, and players can potentially inject their Steam ID or Faction ID into custom data of survival kits or medical rooms, giving them access.
* RSM closes this vulnerability by frequently resetting custom data on all spawn blocks.
* In addition to removing potentially malitious ids, RSM will also inject your own faction tag into custom data during this reset. This potentially leaves your spawns open to you even after an enemy has completely stolen your ship.
	* If you don't want RSM to inject your faction tag, such as if you want the spawn to be closed to faction members, you can set the spawn to private in custom data.
* Sometimes you do want to open your spawns, and RSM handles this too...
	* Add a comma seperated list of Steam IDs or Faction IDs of your friends to the relevant section of RSM custom data.
	* Run `Spawn:Open` to open the spawn to the list of friendly IDs.
	* Either run `Spawn:Close` or else recompile, unhangar or transition instances, and RSM will reset and remove friendly tags from all spawns until you open them again.


## Thruster Management

RSM stances can be used to control your epstein drives, RCS and other types of thrusters.

* RSM splits all thrusters into main and maneuvering, each with per-stance configuration options.
	* Chemical thrusters are grouped with main thrusters. Main thruster stance options allow you to turn either or both on as required.
	* Atmo thrusters (only SG on DX) are grouped with maneuvering thrusters, and also have discreet stance control options.
	* Maneuvering thrusters settings `ForwardOff` and `ReverseOff` allow you to disable maneuvering thrusters in those directions only, per stance. For example, by default, the `Cruise` stance disables forward RCS to conserve fuel.
	* You can configure thrusters to `NoChange` for any given stance, and thrusters won't be touched when that stance is called.
* RSM only touches your thrusters when running a `Stance:StanceName` command, not at any other time. I like to use manual thruster control as well as stance-based control on my ships.
* Some players like to use a select few Epstein drives as maneuvering thrusters when docking.
	* Simply add `[Docking]` to the name of any main thruster which you want to be enabled as forward RCS.
	* For example, if you name a small secondary drive with `[Docking]`, it will be activated by default during the `Docking` stance
	* The keyword itself is configurable under `[RSM.Keywords]`
* Thrusters may also be effected when a stance is called if `NavOsAbortEfcOff=true`. This will force a NavOS `Abort` or EFC `Off` command when the stance is set, and this may disable thrust override and other changes.

## Weapons Autoloading & Balancing

* RSM acts as an autoloader, constantly automatically searching your cargo containers (as well as connectors & ejectors) for ammo that your weapons need, and then attempting to place that ammo into the weapons for you.
* Once all ammo in cargo is exhausted, RSM will begin to run additional calculations to balance ammo between weapons of the same time.
* Ammo will be balanced to within 10% across all weapons of the same type.
* RSM will also actively remove torpedoes from a launcher if a different ammo type is selected prior to autoloading, so that there's room for the correct ammo.
* Autoloading and balancing is enabled by default, but can be disabled in custom data if desired.
* Autoloading functionality is also present on reactors, forcing fusion fuel up to the quantity configured in custom data.

In rare cases, some players have reported a condition where RSM seems to remove all ammo from or misload a torpedo launcher after an ammo type change. This appears to be caused by a desync condition where you and the server disagree on the ammo type for the given weapon. Fix this with a `!fixship` command.

## Extractor Management

RSM automatically loads your extractor, depending upong your stance...

* On DX, you probably know fuel tank components are loaded into Extractor blocks to refill your ship tanks (or jerry cans for SG extractors).
* Each stance can be configured for one of three extractor management options...
	* **Off**
		* Extractors are switched off and ignored.
	* **Autoload Below 10%**
		* Extractors are switched on.
		* If your total ship fuel falls below 10%, RSM will automatically top the ship up by loading a fuel tank.
	* **Keep Ship Tanks Full**
		* Extractors are switched on.
		* Once your ship fuel falls below 3x the capacity of one fuel tank (or Jerry Can for SG), RSM will automatically top the ship up by loading a fuel tank.
	* By default, most stances use fuel tanks to keep ship tanks full.
* RSM dynamically adjusts the load speed of fuel tanks based on your current fuel level.

## Inventory Management

RSM counts inventory for certain items including fuel tanks, fusion fuel canisters, jerry cans and all types of ammo.

RSM measures the counts of all of these items at `Init:ShipName`, and then constantly compares the current counts to populate the Inventory LCD.

The first time you load up your ship, run `Init:ShipName` again to save all of the item counts.  You can also manually set them in custom data.

All counts include items in connectors, ejectors and located inside weapons or reactors.


## Projector Management

RSM has some basic functions that help you control your projector(s)' alignment.

* Run `Projectors:Save` to store offset and orientation to custom data.
* Run `Projectors:Load` after loading your BP to recall it's offset and orientation.

I recommend using zero alignment projectors for even simpler usage.  To do that...

* Your projector must be the first block placed on the ship.
* If you have an already constructed ship, copy-paste it onto a standalone projector, also taking note of the projector's alignment.  This works best from spectator mode (F8).
* If done correctly, your projector will work perfectly with no alignment.


## Auxiliary Block Management

RSM auxiliary blocks are simply a way to control a random group of blocks, per stance.

* By default, the auxiliary keyword is `Autorepair`. Add that text to the name of any autorepair welders, as well as warning lights etc, and they will be enabled during combat stances, by default.
* Auxiliary block functionality really can be any block used for any purpose. Change the keyword as required, and configure your aux blocks to come on with any stance you wish.


## Ignore Keyword

Sometimes RSM can get in the way, and you just want it to ignore one block or one category of blocks but continue to use it for other tasks.  It's easy, simply set an ignore keyword in RSM (`[I]` by default) and make sure that keyword is included in the name of the blocks you want to ignore.

Ignored blocks won't be renamed, and won't be controlled in almost all cases.


## Hudlcd

If you don't already have it, I strongly recommend installing the Hudlcd plugin via the plugin loader. Basically, it allows any text LCD to display on the HUD while you're in a cockpit, and it works great with RSM.

RSM will only adjust your hudlcd settings when you run the `Init:ShipName` command, and under the following conditions...
* LCDs with names containing `.[RSM].HUD1` to `.[RSM].HUD6`.  If you change the default values, remove the `HUD1` component from the name, and RSM won't adjust it during subsequent init commands.
* LCDs containing `[EFC]` or `[NavOS]` will be configured with by prefered default Hudlcd setting

RSM also has a simple quality of life feature related to hudlcd; a simple toggle command.  Run `Hudlcd:Toggle`, `Hudlcd:On` or `Hudlcd:Off` to enable or disable all hudlcd screens on your ship.  I mostly use this to disable my hud for screenshots


## Antenna Comms Management

RSM doesn't actually control antennas directly at all; power, broadcast status and range should all be configured manually by the player.

It does offer a handy command for quickly changing the hudtext on one or more antennas.  I use it to easily flash messages on my antennas for other players to see.

For example, turn antennas on with broadcasting on and an appropriate range set. Now approach another grid, and alternate the commands `Comms:Hello!` & `Comms:We Come In Peace`. Your antennas will flash those messages for your friend to see. Of course, also works well for taunting your enemies...


## Miscellaneous Warnings

Here are a few miscellaneous alerts you may see pop up on the Warnings LCD...

* **X UNOWNED BLOCKS!**
	* RSM has detected X number of blocks on the current ship which are owned by a player in another faction!
* **NO SUCH STANCE!**
	* A command was ignored because the provided stance doesn't exist.
	* Stance names are case sensitive!
* **RESET CUSTOM DATA!**
	* Something was wrong or missing from your PB custom data, and so RSM has reset it.
	* This may occur after an update if new config options are added.  Don't worry, RSM will retain all existing options as is.
	* If you didn't just update RSM, 
* **COMMAND FAILED**
	* A command you sent recently failed.
	* This will be accompanied by another message with more info.
* **Init:ShipName**
	* Init command completed successfully
* **Loaded Fuel Tank**
	* RSM just loaded a fuel tank or jerry can into your extractor successfully.
* **Comms (Range): Message**
	* Indicates your antennas are on, and shows the broadcasting range and message.


## Debugging and Performance

There are a few settings in custom data that can assist with debugging.

* **Throttle Script**
	* By default, RSM runs fairly slowly, once every 100 ticks.
	* Increase this number to throttle RSM by skipping this number of 100 ticks. For example, a value of 3 will force RSM to effectively run once every 300 ticks.
	* In general, this isn't required, but offers some extra control to prevent burn out in extreme circumstances, or to force RSM to run slowly for debugging reasons.
* **Full Refresh Frequency**
	* To improve performance, RSM only performs some tasks infrequently, called a Full Refresh, which includes things like getting new blocks.
	* By default, this value is 50, or 5,000 ticks
	* You can adjust this value up to slow RSM down further and improve performance, or adjust the value down and force RSM to refresh more frequently.
* **Verbose script debugging**
	* If true, RSM will flood the PB block details (in the K menu) with a range of additional logging data, which can assist in specific debugging.


# LCD Screens

In this section, I'll go over each of the 6 default LCD screens, explain what each one means, and how to use it.

## HUD1: The Header Screen
![HUD1 LCD Screen](/img/hud1.png "HUD1 LCD Screen")

This screen is the "Header", like the title page of all LCD screens.
It contains a few pieces of information...
* The currently configured ship name, at the top.  Our example ship is called Nascent.
* The currently selected stance, below the name.  Our example is in Docking stance.
* The spinners, the alternating squares in the corner.  These simply indicate that the script is still running
* Four widgets, each in their own box at the bottom.
	* The widgets represent Fuel, Oxygen, Power and Weapons.
	* Each widget represents the current status of the associated system.
	* Depending on the severity of each, the widgets will begin to flash, alternate colours etc in order to catch your attention to these important systems.

## HUD6: The Header Overlay

Skipping ahead to HUD6, this screen is simply an overlay for HUD1.

* This screen is not required, you can run without an overlay if you wish.
* If you want to be very fancy, place HUD6 as a transparent or holo LCD in front of your HUD1 LCD, and use text size and padding settings to overlay them perfectly when viewed from your cockpit.

## HUD2: The Warnings Screen
![HUD2 LCD Screen](/img/hud2.png "HUD2 LCD Screen")

The warnings screen shows a prioritised list of things you should be aware of.

More urgent errors will be visible at the top of the screen, and will transition to caps etc based on the priority of the warning.

A wide variety of info will appear on this screen, such as warnings about low fuel, fusion fuel, ammo or oxygen, feedback relating to commands you ran recently, and other types of feedback.  See the [Miscellaneous Warnings section](#Miscellaneous-Warnings) for more info.

## HUD3: Power, Gas & Thrust
![HUD3 LCD Screen](/img/hud3.png "HUD3 LCD Screen")

This LCD includes two sections; Power & Gas, and the Thrust section.

### Power & Gas

Power & Gas contains quick information about the status of power, H2 and O2 systems on the ship.  Any bar with low values will flash in a moving pattern to catch your eye and alert you something is low.

* Fuel and Oxygen simply show your H2 and O2 level for all tanks on the ship.
* Battery shows the current battery charge overall for all batteries on the ship.
* Capacity shows the current power output capacity of the ship. This will only drop if power sources are disabled.
* Max power shows the same value as capacity, but displays it as a MW value to give you a quick indication of the total power of your ship.

### Thrust

The thrust screen gives you a quick read out of your ship's thrust.

* Decel (Dampener) shows the minimum distance and time until the ship can stop, assuming optimal retrograde orientation and dampener usage.
	* If you are currently under thrust, this will instead show as Decel (Actual), with the values showing your actual estimate distance and time until full stop.
	* This value is based on which drives are currently on. This means in a stance such as `StealthCruise` with only some drives enabled, this will show the value for those drives only.
* Accel (Best) shows your best possible acceleration with the current drives in Gs.
	* If you are currently under thrust, this will instead show as Accel (Actual) and will provide a read out of the G's of your current burn.
	* This value is based on which drives are currently on. This means in a stance such as `StealthCruise` with only some drives enabled, this will show the value for those drives only.
* Drive Signature
	* This shows your current beacon radius, or your Drive Signature range.

## HUD4: Subsystem Integrity
![HUD4 LCD Screen](/img/hud4.png "HUD4 LCD Screen")

The Subsystem Integrity screen is a readout providing a quick indication of the health of each subsystem on your ship.

Strayed into PDC range?  Rail slug just went through your ship?  Every time I take damage, I glance at the Subsystem Integrity screen to get a quick indication of how effective my ship still is, and to help me decide if to press on or disengage for repairs.

RSM measures the effectiveness of your ship at `Init:ShipName`, and then constantly compares the current status of those systems to provide this percentage.  Values are based on real world effectiveness, so for example, the `Reactors` value is based on the total possible output of all reactors, accounting for reactors that are ineffective because they are off, damaged, destroyed, or out of fusion fuel. 

In addition to integrity, a small amount of text is added to the right of some subsystems.  This provides a quick output of how this subsystem is configured in the current stance.  For example, Railguns can be `OFF`, `HOLD` or `FREE`, and batteries can be `AUTO`, `CHG` or `DCHG`, as determined by the currently selected stance.

## HUD5: Inventory, Telemetry & Thrust
![HUD5 LCD Screen](/img/hud5.png "HUD5 LCD Screen")

This LCD includes two sections; Inventory, and Telemetry & Thrust.

### Inventory

The Inventory screen is a readout of your ship's critical inventory, including fuel tanks, fusion fuel canisters, jerry cans and all types of ammo.

RSM measures the counts of all of these items at `Init:ShipName`, and then constantly compares the current counts to provide this percentage.  Any items you don't have on your ship at `Init:ShipName` will be given an init value of 0, and so won't appear in the list at all.

The first time you load up your ship, run `Init:ShipName` again to save all of the ammo amounts.  You can also manually set them in custom data.

All counts include items in connectors, ejectors and located inside weapons or reactors.

### Telemetry & Thrust

The Telemetry and Thrust screen is a more detailed thrust output with more specific info.

* Basic telemetry such as current mass and speed are displayed. You can disable basic telemetry in custom data.
	* All values from the thrust section are duplicated, with actual and best values displayed together.
* Also included is a list of deceleration thrust percentages which show the distance and time until stop from the current speed at the given thrust percentage, assuming optimal retrograde orientation.
	* Like other thrust values, this is based on which drives are currently on, and will adjust to reflect a state where only some drives are active.
	* You can choose which percentages are displayed in custom data.

# Commands

## Init

    Init:ShipName
		
The **Init** command prepares your ship for use with RSM. Input a ship name with the command.

* Sets the provided name in the RSM PB custom data.
* Renames every block on the ship to include the ship's name.
	* Since blocks which do not have the ship's name in their block name will be ignored by RSM in most circumstances, this is mandatory.
* Automatically configures hudlcd
	* If you're running the hudlcd plugin, add `[RSM].HUD1` - `[RSM].HUD5` to the names of LCDs and RSM will automatically configure and position them on your hud. Also adjusts `[EFC]` tagged LCDs.
* Stores sub system integrity data to custom data so that RSM can detect the current damage level of each sub system.
* Stores inventory data of ammo, fuel tanks and fusion fuel to custom data
* You can run **Init** as many times as you like, or never.

### Naming Syntax

You can run **Init** as many times as you like without overwriting existing names, you just have to follow the correct naming syntax.

    ShipName.BlockType.*Retained*

Items after the second . in a name are retained during an init command. For example, you can rename a ship without losing names like this...

	Tachi.PDC.Forward.Starboard
	*Init:Rocinante*
	Rocinante.PDC.Forward.Starboard

### Optional Init Arguments

You can optionally add arguments after the ship name...

* `Init:ShipName:NoNames` will prevent renaming of any blocks.
* `Init:ShipName:NoSubs` will prevent overwriting current subsystem health values
* `Init:ShipName:NoInv` will prevent overwriting current inventory values

These can be combined and are case insensitive, e.g. `Init:ShipName:NoSubs:noinv`

## Stance

    Stance:StanceName

The **Stance** command is a one-press ship mode button which can be used to alter a whole range of settings all at once and put your ship into a different *stance*.

RSM comes with a range of default stances out of the box, here are my favourites...
* `Stance:Cruise` - weapons defensive, drives & rcs on, external and internal lights on and blue, spotlights off, hangars closed, extractor keeping tanks topped up.
* `Stance:StealthCruise` - same as above, except min drives on only.
* `Stance:Docking` - weapons defensive, drives off, rcs on, external lights bright, internal lights purple, spotlights on, hangars unchanged, extractor keeping tanks topped up.
* `Stance:Docked` - weapons defensive, drives & rcs off, external lights white, internal lights white, spotlights off, hangars unchanged, extractor off, stockpile & recharge on.
* `Stance:Combat` - weapons offensive, drives & rcs on, external lights off, internal lights red, spotlights off, hangars unchanged, extractor keeping tanks topped up, batteries discharge.
* `Stance:CQB` - weapons offensive with PDCs targetting LG, drives & rcs on, external lights off, internal lights amber, spotlights off, hangars unchanged, extractor keeping tanks topped up, batteries discharge.
* `Stance:NoAttack` - weapons off, drives & rcs on, interior and exterior lights white,  spotlights off, hangars unchanged, extractor keeping tanks topped up.

**Don't feel locked in! You can edit each of these settings for every stance, or even add new ones via the RSM PB custom data!**
It's a long list, so I recommend going to the RSM *PB Server* and copying the *Custom Data* to notepad or an external IDE for easier editing.

## Spawn

	Spawn:Open
	Spawn:Close

RSM automatically manages custom data on all connected spawns in order to prevent intrusion via open spawns, such as when they are included in BP's spawn, or injected into a spawn via hacking, and also in turn to create a potential backdoor into a stolen ship. To facilitate this, RSM frequently and mercilessly replaces custom data on all spawns, which is great until you *actually want to open your spawn to another faction or player intentionally*.

Therefore RSM also has a command to open and close the spawn to friends. Configure your friends list, steamids or faction tags, in the RSM PB custom data.

	Comma seperated friendly factions or steam ids for survival kits.
	=RSG,VOL,SUS,LHI,ITC,JSO,76561198217763901

Now run `Spawn:Open` to add all of the configured tags to all spawns on the ship, opening them up to those friends.  You can then use the `Spawn:Close` command to remove the tags at any time. Friendly tags will also be removed on instance transition.

As per the *Developer Promise* below, I should note RSM uses the detected player faction tag only, and does not inject mine or any other tag or steamid and never will.

## Hudlcd

	Hudlcd:On
	Hudlcd:Off
	Hudlcd:Toggle

The hudlcd plugin is great and pairs well with RSM, but then you press TAB to take a screenshot and there's still a bunch of text on your screen. Since the hudlcd plugin doesn't have some kind of toggle, I've built one into RSM.  Use this command to turn hudlcd on and off on all LCDs on the ship (including those with the ignore keyword).

## Projectors

	Projectors:Save
	Projectors:Load

RSM can save projector offset and orientation to a projector's custom data, and then recall it later.  This is useful since nexus often clears this data during transitions, fixships or hangar loads.

* Load your BP into your projector(s) and position it manually.  When you're ready, run `Projectors:Save`.
* Next time your ship is damaged and needs repair, load the same BP into the projector(s) and run `Projectors:Load` and the position will be recalled.

## Comms

	Comms:Message

This command is a tool for quickly changing the hud text for multiple antennas at once. By setting up toolbar buttons, you can quickly change your broadcasted text to send a message. Comms commands support spaces.

	Comms:Hello!
	Comms:We Come In Peace
	Comms:GoCN
	Comms:Prepare To Be Boarded!
	Comms:DO NOT APPROACH
	Comms:We Surrender! Don't Shoot!
	Comms:MAYDAY! MAYDAY! SOS!

Note that RSM doesn't currently control antenna range or power status; please control those settings manually.

## Doors

	Doors:Locked
	Doors:Unlocked
	Doors:Toggle

This command allows you to open your ship up for inspection by unlocking all doors. Use `Doors:Toggle`, `Doors:Locked`, `Doors:Unlocked` to control the "*Anyone Can Use*" setting on all doors on the ship.

* Like Hudlcd commands, Door commands also support filtering by block name.  For example, run `Doors:Unlock:Airlock` to only unlock airlock doors.
* The warnings LCD now displays a count of Insecure Doors if any are unlocked.
* Any stance which sets rails to weapons free will also automatically lock all insecure doors (i.e. `Combat`, `CQB`, `WeaponsHot`)