#### =========================================================================
# RSM Changelog
#### =========================================================================

![Reedit Ship Management](/thumb.png "Reedit Ship Management")

#### =========================================================================
## V 1.99.x BETA

### Full refactor/rebuild

* RSM has been completely rebuilt from the bottom up with a focus on performance, configurability and ease of use.
* 

### Init it... or don't

* Unlike previous versions, RSM is now fully init-optional...
* **By default, RSM will operate on all blocks on the same construct, regardless of block name.**
* Previous versions required the ship name to be present in the name of all blocks. This behavious is useful for seperating control of merged-on skiffs and in other situations, thus you can turn it back on if you wish by setting `RequireShipName=false`.
* Init is still helpful

### Massive config improvements

* 

#### =========================================================================

RSM V 1.12.0

Fully rebuilt User Guide
Tried to make it both easier to get started quickly, and also more thorough for those who want to understand all of the details.  I bet you're missing something...
Read it on GitHub: https://github.com/christorreed/ReeditShipManagement

Stance Changes
New Stance WeaponsHot which engages weapons without touching your drives.
Seldom used stances MaxCruise, Coast & Sleep removed from default stance list.
Stance names are no longer case sensitive in stance set commands.
New stance options for all thrusters for more granularity, including no change to leave drives un touched, and additional options for atmo/chemical drives.
Note default stance updates will not effect existing ships/existing stances.  To update to the new stances, clear all stances from custom data.

Improved Weapons Management
Weapons auto config now also turns on "Target Sub Systems" for all weapons and "Target Biologicals" (at stance set).
Detailed description of weapons management, how to use it, how to disable it, all in the updated guide.
Added support for the Kess and associated 180mm rounds

Improved Thruster Management
New tag, default "Docking", sets Epstein drives to turn on when they would otherwise be turned off if RCS mode = 1.  In other words, add ".Docking" to the end of the name of an Epstein drive to use it in Docking stance.

Improved Reactor Management
Autoloader is now operating on reactors as well.
Fusion fuel will be forced into reactors and balanced between reactors automatically.
Reactors are now forced on.
 
[21:06]christophuck:
Added LiDAR Support
LiDARs are now forced on along with the "keep alive" setting, available per stance.
New message on warnings LCD if LiDAR isn't working

New Command: Unlock Doors
New command allows you to open your ship up for inspection by unlocking all doors.
Use Doors:Toggle, Doors:Locked, Doors:Unlocked to control the "Anyone Can Use" setting on all doors on the ship.
Like Hudlcd commands, Door commands also support filtering by block name.  For example, run Doors:Unlock:Airlock to only unlock airlock doors.
The warnings LCD now displays a count of Insecure Doors if any are unlocked.
Any stance which sets rails to weapons free will also automatically lock all insecure doors (i.e. Combat, CQB, WeaponsHot)

Fixed and Improved Auxiliary Blocks Functionality
Auxiliary block functionality is now fully operational once more.
By default, configured for use with Auto Repair welders.  Tag welders, plus any alert lights etc, with [Autorepair] and they will be engaged during Combat, CQB & WeaponsHot stances.
Change the keyword to whatever you like, and adjust the aux state per stance as required.  This can be used to turn any blocks on/off per stance.
Aux state with count is now visible on the warnings LCD.

LCD Colour Sync
LCD colour sync now supported for non-RSM screens.
Add [CS] to the name of any LCD, and RSM will change it's text colour to match the current stance.
 
[21:06]christophuck:
Improved Battery Management
Stances configured to discharge batteries (Combat, CQB & WeaponsHot) now will actively toggle between Discharge & Auto based on railgun targets.  Basically, if any railgun on the ship has an active WC target, batteries will be set to Discharge, otherwise, Auto.
This new functionality is enabled by default, but can be disabled in custom data if you prefer the old functionality.

Improved Block Naming At Init
Improved Init naming for refill stations, cockpits/consoles/seats, kess cannons
Added type to Init naming of railguns (eg Shipname.Railgun.Zako) like PDCs, torpedoes.
Add type names to weapons at init now enabled by default
Added support for Toolcore ship tools,

Improved Hudlcd Command - Filtering
In addition to the existing hudlcd commands, it's now possible to add an additional argument to filter LCDs by name.
For example, hudlcd:toggle:[RSM] will toggle hudlcd on all RSM LCDs.

One Touch Airlock Improvements
Improved handling of multiple vents in airlocks.
Airlocks no longer blow out if the vent airlock is off.
Vents are now forced on along with the "keep alive" setting, available per stance.

Other Changes
Now monitoring subsystem integrity for cargo containers (based on actual capacity) and welders.
Fixed battery display bugs on subsystem integrity lcd.
Now counting steel plates on inventory display screen
New default ignore keyword: [I]
Improvements to inventory counting
Fixed a bug causing ships which only had one controller to loose telemetry
Removed beacon-based drive sig output display from LCDs
H2/O2 levels now show relative to init value, not current max capacity
Ignore keyword now prevents autoloading on weapons