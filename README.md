# Reedit Ship Management

<a href="https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140"><img src="/thumb.png" alt="RSM" width="300"/></a>

Reedit Ship Management (RSM) is a broad, ship automation script tailor made for the Draconis Expanse Space Engineers server.

### [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140)
***Subscribe to RSM on Steam***
### [Reedit Developments Discord](https://discord.gg/Z7UtZBBe)
***Raise bugs, ask questions, or request new features***
### [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md)
***Get started with RSM!***
### [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md)
***Go into detail with all of RSM's features and commands***
### [Change Log](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ChangeLog.md)
***Read the RSM change log***

## The broad goals of this script are to...

* Provide a range quality-of-life functionality to make ships on DX easier to use and better.
* Output a high-density, customisable LCD display (with Hudlcd support)
* Prevent configuration errors that can lead to combat failure or other mistakes.
* Simplify ship control via fully-configurable 'stances'
* Automate monotonous tasks so you can get a new ship up and running fast.

***Get started with the [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md)***

## Features

RSM has a lot of features that you will want to [explore in detail](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md), but here's just some of what it can do...

* Fully configurable ship ***Stances*** allow you to rapidly re-configure your ship for various circumstances.
* Optionally rename and tidy all **block names** on your ship.
* Control **lighting*, per *Stance*, in **Spotlight**, **Exterior**, **Interior** and **Navigational** categories, including power status and colour.
* **Extractor management**; automatically load fuel tanks into extractors to keep your grid fueled up, including dynamic fuel tank load speed
* **Dynamic battery discharge management** means batteries are recharging when your railguns aren't firing.
* Automatically control **doors**, including a default 3 second **auto closer**, and a fully automated, **one-touch airlock** algorithm.
* Door **lock management**; quickly permit access to your grid during trading, then automatically lock it again in combat.
* **Manage spawns** and prevent custom data spawn attacks.
* Detect and alert to the presence of **unowned blocks** on a the RSM grid.
* Set **thrusters**, including Epsteins, chemical thrusters, RCS, atmo thrusters per stance
* Control **NavOS** or **EFC** script settings, per stance.
* Automatically **load** and **balance** all **weapons** on the RSM grid
* Automatically **load** and **balance** all **reactors** on the RSM grid
* Saves and loads **projector alignment** data (stop re-aligning every time!)
* Enable or disable ***Auxiliary*** blocks per stance
* **Ignore** specific blocks using the Ignore keyword, default `[I]`, removing them from RSM entirely.
* **Antenna** hud text management; control all antennas hud text at once with the `Comms:Message` command from the G menu.
* **Debugging** and performance **profiling** options built in.
* Output a detailed array of ship data onto RSM **LCDs** including...
	* Ship **integrity**, per-subsystem, and per major system.
	* Ship **telemetry**, including current acceleration in G's or m/2^2, stop times and distances at max burn, and at a configurable list of burn percentages.
	* Ship **inventory status**, including actual verse expected values for ammo, fuel, fusion fuel and steel plates.
	* Ship **power** and **tank** information
	* General, **prioritised ship warnings** about various conditions like low fuel, low ammo, no lidar, low batteries, antennas on and a range of other conditions.
	* Automatic configuration of up to 6 screens, including default Hudlcd configuration, lcd text colour control per stance
* .ini compatible custom data configuration for easy adjustment in an IDE.
* Detailed [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md), and basic [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md) for ease of use.

## Draconis Expanse

RSM is tailor made for the Draconis Expanse (DX) Space Engineers server and customised mod stack. There are no plans at this stage to expand RSM support to other servers or SE environments.

## Developer Promise

Draconis Expanse is a PvP environment, and scripts have been used as weapons before.  I have and will do that on other scripts, but **WE DON'T DO THAT HERE**.  As long as it's me (christophuck) handling the development of the script, it won't be used as a weapon, and I guarantee malicious code won't be added.  If you experience such a thing, it's a mistake, please report it!  The full, unobfuscated script is posted here for all to review.

## Disclaimer

**USE AT YOUR OWN RISK!**
*This script is safe (all of my ships run it) but it is complex, and using it improperly can lead to damage or destruction of your ship.  Read the guide, ask questions, and practice.*
**DON'T FIGHT THE SCRIPT!**
*There's probably a stance or other option to achieve what you want with one command to RSM. If it's freaking you out, just turn off the RSM PB!*

[Home](https://github.com/christorreed/ReeditShipManagement/) | [Quick Start Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.QuickStartGuide.md) | [Reference Guide](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ReferenceGuide.md) | [Change Log](https://github.com/christorreed/ReeditShipManagement/blob/main/README.ChangeLog.md) | [Steam Workshop](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140) | [Discord](https://discord.gg/Z7UtZBBe) 
