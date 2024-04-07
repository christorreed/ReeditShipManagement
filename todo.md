# debugs

- hudlcd:toggle:pattern not working

x fuel tanks loading?
x run autoload twice?
x airlocks not working
x reactor subsys integ value wrong
x rcs nfwd not working
x failed to get drive type
x Setting NavOS ThrustRatio via stances does not seem to work
x Init did not set up content type or font on the RSM HUD LCD
x first init, get zero value
x make stuff faster
x fuel tank loading freq might need to go up
x check camera keep-alives
x less .GetItemAmount(Item) calls
x - store item counts as you go
x - fix balancing
x figure out how to view all kinds of files in VS.
x not counting ammo from weapons
x inventory counting, zeroing bugs.
x issues with fuel level
x issues with capacity?
x issues with Reactor subsystem
x reactors subsystem caps
x Batteries subsys
x tanks 3000% subsys
x railguns count is zero even tho i have some
x "An item with the same key has already been added" during 
 
# todos

- debug/test
- update the documentation
- update the change notes
- add toolcore welder control (setToolActivate, iterateWelders)
- review and improve updateLcds 
- booting improvements, lcd outputs
- snek private spawn default: make spawns private automatically if spawn kits are set to no share
- init no renames.
- automatically detect name at start.
- gat support
- opa pdc ammo type support
- saving custom data on stance set.

x more aggressive naming into sub groups.  Like power.reactor
x fuel tank fast loading command
x lcd error on config parse failure.
x find a way to provide default custom data mostly commented out.
x germ wants m/s^2 rather than G's bc he's weird.
x refactor the rest of the var names
x make stance a class ffs
x fix runProgramable, make it run commands over sperate ticks
x review and improve setStance
x _appendDriveTypes
x review and improve manageDoors
x handle fixed weapons better
x confirm if to also check for blocks for ship names
x experiment with ini, use for config (updateCustomData)
x review and improve the main loop
x review and improve quickRefresh
x consider changing position of the ignore keyword.
X review and fix extractor management
X finalise init naming initBlockNames

# wishlist

- add detailed ini block overrides: https://discord.com/channels/348745744846422016/1205752120280743987/1219246089136246826
- airlock 