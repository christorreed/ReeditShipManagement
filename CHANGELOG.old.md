- 0.0.1
    Unreleased initial working version
    
- 0.1.0
    Initial release on Discord

- 0.2.0
    Second release, now on steam.
    Improved init, now can be repeated, so you can update ship names, name new blocks.
    Improved stance management including...
        > stances can now be edited via PB custom data. You can add or remove them as well, it iterates over as a loop.
        > additional features were added to each stances
        > removed 'Combat' and 'Torpedoes' and replaced with 'Defence' and 'Offence'
        > now supports controlling two PDC groups, normal and defence
        > some stance features, like block power state, are maintained every loop.
        > automatic extractor management, automatically load tanks below 10%, if set in stance.
    Setting a target value of 0 in custom data now removes it from the screen.
    Added debug variable, better verbose logging.
    LCD number rounding now the same on bar as text
    Efficiency, stability improvements.
        > Refactored the init and stance code bases for effeciency
        > Fixed crash on no-inventory cockpit block
        > Fixed crash on door custom data parsing error
    Built Guide

- 0.2.1
    Fixed a bug that caused block lists to overflow.

- 0.2.2
    Fixed several bugs with the extraction management algorithm.

- 0.3.0
    Added projection offset and orientation mangagement with projectors:save and projectors:load commands
    Added keep alive functionality to Sensors, LCDs & Cameras
    Getting comms value from first antenna hud text rather than local variable
    No longer forcing Focus Fire to PDCs in Offence stance.
    Fixed bugs with fuel percentage calculations
    Fixed crash on command to destroyed block.
    Fixed crash on extractor management with no extractor on board

- 0.3.1
    Fixed a bug caused a crash if no antenna.
    No longer forcing LCD padding.

- 0.3.2
    Improved init function autonaming of LCD blocks.

- 0.3.3
    Added a delay to fuel extractor management retries so it won't constantly attempt to refuel.
    Minor bug fixes.

- 0.4.0
    Script now automatically adds own faction tag to Medical Rooms and Survival Kits
    Added adjustable delimiter functionality. In custom data you can now set a character other than '.' to be used to name blocks during init.
    I've capitulated and decided to start referring to Programmable Blocks as PB Server rather than Server so it can be easily found.
    No longer numbering servers during init
    Changes to more smoothly permit additional configurable custom data options.

- 0.4.1
    Fixed a bug with configurable block name delimiter functionality.
    Fixed a bug with custom data

- 0.4.2
    Fixed a crash on set stance with certain grids.
    Changed defence PDC default keywork to 'Repel' so it doesn't interact with OPA PDCs which have defence in the name.
    Fixed a bug where repel/defence PDCs & railguns were not processed by the init command.
    
- 0.5.0
    Added support for some additional inventory items on the LCD...
        - 40mm Tungsten Teflon PDC Boxes
        - 100mm Railgun Slugs (UNN - Dawson)
        - 100mm Railgun Slugs (MCRN - Stiletto)
        - Jerry cans (SG fuel tanks)
        - just a reminder, you can hide any of these by setting the targets to 0 in custom data.
    Added improved support for railguns/torpedoes
        - railguns & torpedoes can now be set to off / hold fire / ai weapons free per stance.
        - railguns & torpedoes will also be auto-configured like PDCs to ensure they are setup correctly.
        - by default, both will be forced into ai weapons free during the combat and CQB stances, though this can be disabled in custom data.
    Improved auto PDC configuration
        - Repel PDCs now automatically set to target biologicals
        - Repel PDCs and normal PDCs in defensive mode will now also target SG to protect against PMWs
    Added support for SG extractors; can now automatically refill H2 tanks via either SG or LG extractors
    Updated default stance behaviours
        - stronger defensive PDC behaviour across most stances by default
        - Defence was renamed to 'Combat' and Offense was renamed to 'CQB', clarifying intended usage.
        - note the above change means that you may be required to update the toolbar to match.
        - just a reminder, stances are configured in custom data, so these changes won't occur unless you reset there, they are only defaults.
    Added option to not change hangar door status with stance.
    Current stance is now retained across instances/restarts. 
    Updated guide to reflect several versions worth of changes.

- 0.5.1
    Spaces are now ignored in all arguments to prevent syntax errors. This means no spaces in ship names

- 0.6.0
    Battery discharge functionality added to stance management.
    Combat and CQB default stance data updated to discharge batteries. Note: reset your stance custom data to apply this change.

- 0.6.1
    Fixed tank stockpile error

- 0.7.0
    New option for extractor management; 3: keep ship tanks full.  In this mode, extractor is loaded sooner to keep fuel tanks on ship at max.
        - Specifically, fill up will occur when there is room for 3 fuel tanks components worth of H2 in the ship tanks.
        - Note: This mode is now the default for most stances. You can revert to 2; fill ship up at 10% to retain current settings
    Improved survival kit custom data management.
        - New option in PB Server custom data; friendly faction tags or steam IDs.
        - They will saved to the custom data of your SKs automatically.
        - You can also toggle this on and off with the command 'Spawn:Open' or 'Spawn:Closed'. If closed, friendly tags are removed from all SKs.
        - Note: off by default, must run 'Spawn:Open' to set this up.
        - Add faction tags like 'RSG' or steam ids like '76561198217763901'.
        - Add multiple by seperating with commas.
    Comms commands now permit spaces (ie for command 'Comms:Hello There', antenna was "RSG:HelloThere" is now "RSG:Hello There")
    Fixed a bug related to crashing during stance calls with high EFC burn percentages, such as during Stance:MaxCruise

- 0.7.2
    Added crash prevention during PDC auto configuration error.  One player reported issues with PDCs which was causing a crash.
    I've prevented this crash, even though I can't replicate it.  It will throw an error if this occurs to you, if so recommend you
    grind and rebuild your PDCs as the repel mode function is bugged.
    Also removed the auto fire mode control on railguns and torpedoes.  I think it was working, but feedback was bad in the menu.

- 0.8.0
    Added per-LCD configuration
        - Screen was starting to get a bit busy with new functionality.  Now you can spread it out across multiple screens.
        - Configure in custom data of each LCD.
    Added stop distance calculation to the RSM LCD (as inspired by Germstorm)
        - A single line stopping distance is provided on the 'Thrust' screen
        - If Epstine drive overrides are off, RSM will calculate a best possible stopping distance based on maximum Epstine thrust (not RCS)
        - If any overrides are on, RSM will calculate an actual stopping distance based on configured thrust.
        - In advanced mode, a whole array of stopping distances are displayed.
    Fixed a bug causing some blocks without the correct naming to be included.
        - Note: if you have issues after this, make sure all blocks have the ship name in them by running init.

- 0.8.1 / 0.8.2 / 0.8.3
    Bug fixes

- 0.9.0
    Added support for HudLcd plugin.  You can now add the text 'hudlcd' into the custom data of RSM LCDs, and it won't be cleared.
        - Recommended settings: top left= "hudlcd:-.99:.99", "top right= hudlcd:.65:.99"

- 0.9.1
    The basic thrust lcd output now defaults to 500ms when stationary, like the one from the advanced view.

- 0.10.0
    New command with 3 arguments: 'hudlcd:on', 'hudlcd:off',  'hudlcd:toggle'
    Hudlcd is game changing, but sometimes you just want it to piss off and take in the stars around you.  The new commands search
    custom data of every LCD on the ship, and adjust the name in order to remove, or re-add, them to your hud.  Note that the
    command effects all LCDs, including ignored ones.

- 0.11.0
    Improved LCD output 

- 0.12.0
    Added acceleration output both max and actual to thrust and advanced thrust output pages.
    Spawn custom data management now effects all SKs and MRs regardless of block name, or construct.  RSM now fully cleans all
        spawn custom data for you automatically.
    Spawn custom data now includes spacing for obfuscation. 
    Added support for sloped PDCs
    New custom data option automatically sets spotlights to max radius per stance.  Default now for 'Docking' stance, but will
        require custom data reset/adjustment for existing ships.
    Hid the title line REEDIT SHIP MANAGEMENT from the header LCD
    Replaced the 'idle' LCD status bar with a . .. ... pattern
    Cameras, sensors now have better name tidying on init.
    Added default hudlcd configurations.
        - Setup 4 LCDs and name them `<shipname>.LCD.[RSM].HUD1 to <shipname>.LCD.[RSM].HUD4`
        - Now run init.
        - RSM sets up HUD LCDs perfect for a 16x9 layout.

 - 0.12.1
    Fixed a small bug with default hudlcd configs.
    
 - 0.12.2
    Fixed a bug with spawn custom data obfuscation.