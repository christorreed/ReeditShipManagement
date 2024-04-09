# Quick Start Guide
### Reedit Ship Management
[Home](https://github.com/christorreed/ReeditShipManagement/) | [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md) | [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md) | [Change Log](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ChangeLog.md) | [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140) | [Discord](https://discord.gg/Z7UtZBBe) 

#### There's quite a lot to go over...

# ...but it doesn't have to be complicated to start.

Let's cover the basics first, and get you up and running with RSM as quickly as possible...

* **Build the PB:**
	* You will need a Programmable Block to run RSM, place one on your ship and load the latest version of [Reedit Ship Management from steam](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140).

* **Build some LCDs:**
	* RSM has lots of LCDs, and all are fully configurable via custom data.
	* For the default experience including **hudlcd plugin** config, build 6 LCDs and name them `..[RSM].HUD1` to `..[RSM].HUD6`.

* **Initialise your Ship:**
	* This step prepares RSM to run on your ship.
	* Choose a short name for your ship. In the examples below, we'll just use *ShipName*
	* Load up your ship with components first. This will record item quanities of ammo, fuel and other items as a reference.
	* Disconnect from all other ships or stations!
	* Run the command `Init:ShipName`
	* By default, **this step will rename every block on your ship!**. Add the *NoNames* argument to prevent this, e.g. `Init:ShipName:NoNames`
	* More info about the Init command [here](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md#init).

If you did everything right, and if you have the **hudlcd plugin**, you should see RSM running on your hud from any cockpit. Screens are covered in detail below, but take particular note of the **Warnings** section which outputs an easily read, prioritised list of warnings for your attention, such as low fuel, low ammo, and many other warnings.

* **Set a Stance:**
	* RSM uses **Stances** to control your ship. Each stance is intended for a different purpose and will reconfigure many things on the ship to suit such as thrusters, weapons, interior/exterior and navigation lighting, EFC/NavOS settings and more.
	* Use the `Stance:StanceName` command to select a ship stance.
		* Run `Stance:Combat` to configure the ship to fight a long distance battle
		* Run `Stance:CQB` to configure the ship to fight in close quarters battle (PDC on grid combat)
		* Run `Stance:Cruise` to configure the ship to fly a long distance.
		* Run `Stance:Docking` to configure the ship to dock via RCS thrusters.
		* Run `Stance:Docked` to configure the ship to refuel and recharge.
	* Most settings only change when a stance command is set, only a few such as power for critical blocks, are constantly enforced.  A full list stance functionality is below.

* **Tinker:**
	* RSM is extremely configurable.
	* Copy paste the Custom Data from the programmable block into Notepad or your favorite IDE.
	* Each stance has an interior/LCD colour and an exterior colour, all of which are configured to my personal tastes. Replace them to match your own requirements.
	* You're not restricted to the default stances; you can add, delete or modify via this custom data.
	* Each individual LCD is configurable; for example all default screens could be added to just one screen if you require.  Check LCD custom data.

So, that's basically it I guess...

#### ...except that it's really not.

That should get you started, but to get the most out of RSM, you'll want to read on and learn about some of the many other features...

#### Go into detail with the complete [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md)

[Home](https://github.com/christorreed/ReeditShipManagement/) | [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md) | [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md) | [Change Log](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ChangeLog.md) | [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140) | [Discord](https://discord.gg/Z7UtZBBe) 