# Reedit Ship Management (RSM)

Reedit Ship Management (RSM) is a broad, ship automation script tailor made for the Draconis Expanse Space Engineers server.

![Reedit Ship Management](/thumb.png "Reedit Ship Management")

# Links

### Subscribe to [Reedit Ship Management](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140) on steam.

### Join the discussion, request features and say hi on the [Sigma Draconis Discord](https://discord.com/channels/516135382191177728/1066185228697211030/1066185233386446980).

## The broad goals of this script are to…

* Provide a range quality-of-life functionality to make ships on DX easier to use and better.
* Output a high-density, customisable LCD display (with hudlcd support)
* Prevent configuration errors that can lead to combat failure or other mistakes.
* Simplify ship control via fully-configurable 'stances'
* Automate monotonous tasks like block naming so you can get a new ship up and running fast.

# Quick Start Guide

RSM does a lot, so it can be daunting at first, but it's easy once you know the basics...

## Setting Up

Before we run the init command to setup the ship, let's do a few preperation steps to make it easy...

* **Install HudLcd Plugin**
	* I recommend installing the HudLcd plugin.
	* RSM is designed to work with HudLcd and will automatically set it up for you.
* **Prepare your LCDs:**
	* RSM outputs a range of data that is available on LCD blocks including hudlcd support.
	* There are lots of ways to set this up, but let's try out the default option first.  This will work better if you install the hudlcd plugin first.
	* Place 5 LCDs and name them `..[RSM].HUD1` to `..[RSM].HUD5`.  Again, trust me, this will make sense shortly...
	* RSM will also configure an LCD name `[EFC]` with hudlcd if you have one.
* **Name your lights:**
	* Simply make sure the word `interior` is contained within the name of all interior lights, and NOT for exterior lights.
* **Prepare for mass renaming:**
	* RSM is going to rename every block on your ship, and you might have names you wish to retain.
	* For example, you might have a camera called `Camera Forward`.
	* If you want the word Forward to be retained in this process, it must come after the second `.` in the name.
	* So rename that camera to `Camera..Forward` or even just `..Forward`.  Trust me, it will make sense soon.
* **Name your airlocks:**
	* RSM will automatically manage all of the doors on your ship, but it can also manage airlocks to prevent both doors opening at the same time.
	* Airlocks are configured via name. RSM will rename all our doors shortly, but we can set this up now so it's ready to go.
	* Think of a unique name for each pair of doors. In this example, we'll configure the Forward airlock.
	* Rename the inner door to `..Airlock.Forward.Inner` and rename the outer door to `..Airlock.Forward.Outer`.
* **Load your Inventory**
	* Fill your ship with ammo, fuel tanks and fusion fuel now.
	* RSM will remember the quantity of each during the next step, and then display how many have been consumed on an LCD.
* **Build the PB:**
	* You will need a Programmable Block to run RSM.
	* Build one on your ship, name it `..[RSM]` and load the latest version of [Reedit Ship Management from steam](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140).
* **Disconnect from other ships:**
	* Make sure you seperate from other ships during the next steps to ensure you don't automatically rename other, unrelated components.

## Initialise

Now you're ready to rock. Run the RSM Programmable Block with the argument `Init:ShipName`, replacing with your actual ship name. I recommend using a short name for this step.

RSM will now initialise your ship. All blocks will be renamed with the ship name, and your LCDs will be automatically configured and loaded for hudlcd.

### You run Init again anytime!

* Don't be afriad to run `Init:ShipName` again.  You can run it as many times as you like.
* Data after the second `.` in a block name will be retained during the renaming process.  For more info, see *Naming Syntax* below.
* Init also calulates sub system integrity and inventory count for ammo, fuel tanks and fusion fuel.  If you want to run init without updating those values, you can run `InitBasic:ShipName`.

## Enjoy

Now that RSM is running, let's explore some features...

* **Control the whole ship with Stances**
	* Set a stance with the command `Stance:StanceName` for example `Stance:Cruise` or `Stance:Combat`
	* Setting a stance controls a number of functions on the ship all at once such as interior and exterior lights, drives and RCS, weapons, automatic repair systems, extractor management and EFC configuration.
	* My favourite stances include...
		* `Stance:Combat` Configures the ship for a long-range fight
		* `Stance:CQB` Configures the ship for a CQB fight
		* `Stance:Cruise` Configures the ship to fly a long distance.
		* `Stance:Docking` Configures the ship to dock (spotlights on, main drives off)
		* `Stance:Docked` Configures the ship to refuel/recharge at dock.
	* There are many more stances, and all are fully configurable via the custom data on the RSM PB.
	* You can even add or remove new stances, or rename them to suit your needs.
* **Toggle hudlcd on and off!**
	* This plugin is awesome, but sometimes I just want to take a screenshot!
	* `hudlcd:on`, `hudlcd:off`,  `hudlcd:toggle` now turn all hudlcds on and off.
* **Automatically handle Extractors**
	* On DX, you probably know fuel tank components are loaded into Extractor blocks to refill your ship tanks.
	* RSM does all of this automatically. Configured per stance, RSM will use fuel tanks from your inventory to either keep the ships tanks topped up, or else top them up a little only when they are totally empty.
	* This also works with jerry cans on SG ships (yes, RSM works with SG).
* **Automatically handle Spawns**
	* Spawns are a vulnerability, and players can inject data into custom data of survival kits or medical rooms to open up spawn access.
	* RSM clamps down on this hard, frequently resetting the custom data to prevent mismanagement.
	* It also uses this chance to inject the owner's faction tag into all connected SKs and MRs.  If someone steals your ship and doens't check themselves, it might let you back on.
	* RSM can also automatically handle opening and closing of your respawn point for your friends. You can configure a list of friendly faction tags or steamIds in the RSM PB custom data, and then use the `Spawn:Open` and `Spawn:Close` command to add or remove them.
* **Save and load the position of projectors for easy alignment.**
	* Run `Projectors:Save` to store offset and orientation to custom data.
	* Run `Projectors:Load` after loading your BP to recall it's offset and orientation.
* **Automatically handle Doors**
	* RSM acts as a basic door management script, closing open doors after a timer runs out.
	* For airlocks, RSM also disables other doors in the same airlock for a time to prevent loss of air.
	* You can configure the timer values in the RSM PB custom data.
* **Manage Antennas**
	* Send a new hud message to all antennas with the command `Comms:Antenna Message`.
* **Output a range of data onto LCDs and your hud.**
	* RSM's LCDs output a whole range of useful info, with each LCD configurable via custom data.
	* The header section shows the ship name and current stance, as well as other useful messages.
	* The inventory section shows a list of important inventory with quotas and bars.  Configure the quotas in the RSM PB custom data, or remove all together by setting to 0.
	* The thrust section shows Decel (distance and time needed to stop), Accel (total thrust) and drive signature range. Switches from Best to Actual when a thrust override value is set.
	* The comms section shows the current antenna hud message and range.
	* The autorepair section shows the current status of autorepair blocks.
	* The doors section shows a count of all doors and how many are closed.
	* The advanced thrust section shows a range of additional thrust info including current mass, and decel at different thrust percentages.
* **Automatically Configure Weapons**
	* RSM sets a range of configuration options for weapons
	* RSM can also handle a seperate group of 'Repel' PDCs always set to defend.

# Commands
Here's a list of RSM commands you can use...

## Init

    Init:ShipName
		
The **Init** command prepares your ship for use with RSM. Input a ship name with the command.

* Sets the provided name in the RSM PB custom data.
* Renames every block on the ship to include the ship's name.
	* Since blocks which do not have the ship's name in their block name will be ignored by RSM in most circumstances, this is mandatory.
* Automatically configures hudlcd
	* If you're running the hudlcd plugin, add `[RSM].HUD1` - `[RSM].HUD5` to the names of LCDs and RSM will automatically configure and position them on your hud. Also adjusts [EFC] tagged LCDs.
* Stores sub system integrity data to custom data so that RSM can detect the current damage level of each sub system.
* Stores inventory data of ammo, fuel tanks and fusion fuel to custom data
* You can also run `InitBasic:ShipName` to initialise the ship without updating inventory or subsystem values.
* You can run **Init** as many times as you like, or never.

### Naming Syntax

You can run **Init** as many times as you like without overwriting existing names, you just have to follow the correct naming syntax.

    ShipName.BlockType.*Retained*

Items after the second . in a name are retained during an init command. For example, you can rename a ship without losing  names like this...

	Tachi.PDC.Forward.Starboard
	*Init:Rocinante*
	Rocinante.PDC.Forward.Starboard

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

# Custom Data Configuration

There's a whole range of settings which you can adjust in the RSM PB Server (*Programmable Block*) custom data. It's a long list, so I recommend going to the RSM PB Server and copying the *Custom Data* to notepad or an external IDE for easier editing.

Some of the things you can edit include...

* The ship name (set by the Init command)
* The block name delimiter. If you would rather RSM uses - rather than . as a delimiter (or whatever), go for it.
* The keywords used in various functions such as LCDs, defence PDCs, autorepair systems and minimum epstein drives.
* Enable or disable automatic weapons configuration
* Set expected counts for each inventory items (or set items to 0 to remove them from the list)
* Adjust door open timers
* Set friendly faction tags or steamids for the **Spawn:Open** command.
* Set the script to verbose logging and throttle the script or adjust it's refresh rate.

# Developer Promise

Draconis Expanse is a PvP environment, and scripts have been used as weapons before.  I have and will do that on other scripts, but **WE DON'T DO THAT HERE**.  As long as it's me (christophuck) handling the development of the script, it won't be used as a weapon, and I guarantee malicious code won't be added.  If you experience such a thing, it's a mistake, please report it!  The full, unobfuscated script is posted here for all to review.

# Disclaimer

**USE AT YOUR OWN RISK!**

*This script is safe (all of my ships run it) but it is complex, and using it improperly can lead to damage or destruction of your ship.  Read the guide, ask questions, and practice.*

**DON'T FIGHT THE SCRIPT!**

*What? My PDCs keep turning back on when I switch them off! lol, RSM is doing that, and for good reason.  There's probably a stance or other option to achieve what you want with one command to RSM. If it's freaking you out, just turn off the RSM PB!*