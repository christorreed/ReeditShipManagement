# [RSM] Reedit Ship Management
Reedit Ship Management (RSM) is a broad, ship automation script tailor made for the Draconis Expanse server.

## The broad goals of this script are to…
* Provide a range quality-of-life functionality to make ships on DX easier to use and better.
* Output a high-density, customisable LCD display (with hudlcd support)
* Prevent configuration errors that can lead to combat failure or other mistakes.
* Simplify ship control via fully-configurable 'stances'
* Automate monotonous tasks like block naming so you can get a new ship up and running fast.=

# Quick Start Guide
RSM does a lot, so it can be daunting at first, but it's easy once you know the basics.  Let's cover them now...

## Setting Up
So you have a pretty new ship...  We'll run RSM in a minute, but first let's do a few preperation steps to make it easy...

* **Name your lights:**
	* Simply name sure the word `interior` is contained within the name of all interior lights, and NOT for exterior lights.
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
* **Prepare your LCDs:**
	* RSM outputs a range of data that is available on LCD blocks including hudlcd support.
	* There are lots of ways to set this up, but let's try out the default option first.  This will work better if you install the hudlcd plugin first.
	* Place 4 LCDs and name them `..[RSM].HUD1` to `..[RSM].HUD4`.  Again, trust me, this will make sense shortly...
	* RSM will also configure an LCD name `[EFC]` with hudlcd if you have one.
* **Build the PB:**
	* You will need a Programmable Block to run RSM.
	* Build one on your ship, name it `..[RSM]` and load the latest version of [Reedit Ship Management from steam](https://steamcommunity.com/sharedfiles/filedetails/?id=2911212140).
* **Disconnect from other ships:**
	* Make sure you seperate from other ships during the next steps to ensure you don't automatically rename other, unrelated components.

## Initialise
Now you're ready to rock. Run the RSM Programmable Block with the argument `Init:ShipName`, replacing with your actual ship name. I recommend using a short name for this step.

RSM will now initialise your ship. All blocks will be renamed with the ship name, and your LCDs will be automatically configured and loaded for hudlcd.

## Enjoy
Now that RSM is running, let's explore some features...

* **Control the whole ship with Stances:**


## Developer Promise & Disclaimer
Draconis Expanse is a PvP environment, and scripts have been used as weapons before.  I have and will do that on other scripts, but **WE DON'T DO THAT HERE**.  As long as it's me (christophuck) handling the development of the script, it won't be used as a weapon, and I guarantee malicious code won't be added.  If you experience such a thing, it's a mistake, please report it!  The full, unobfuscated script is posted here for all to review.

**USE AT YOUR OWN RISK!**

*This script is safe (all of my ships run it) but it is complex, and using it improperly can lead to damage or destruction of your ship.  Read the guide, ask questions, and practice.*

**DON'T FIGHT THE SCRIPT!**

*What? My PDCs keep turning back on when I switch them off! lol, RSM is doing that, and for good reason.  There's probably a stance or other option to achieve what you want with one command to RSM. If it's freaking you out, just turn off the RSM PB!*