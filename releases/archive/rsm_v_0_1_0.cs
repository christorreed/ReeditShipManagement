/*
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 *                                                        -  R E E D I T  -  S H I P  -  M A N A G E M E N T  -
 * 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 *  A Reedit Solutions Group script written by Chris Reed intended for use on the Sigma Draconis Expanse Space Engineers Server 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 *     | Introduction
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 *     This script has several different commands intended to simplify the setup and control of an Expanse-style ship
 *     on the Sigma Draconis Expanse server.
 *     
 *     If you have any questions or think you have found a bug, reach out to me via the Sigma Draconis Discord server;
 *     my username is 'Christohuck'.  My comments have been removed from the code, and I may be forced to further minify
 *     at some point for length reasons, but happy to share & help (and glad to make this better for my own consuption).
 * 
 *     Here's a list of it's functions...
 * 
 *         - Automatically sets up a ship by renaming all blocks to my prefered syntax. ('Init:<ship_name>')
 *                 > Before running this, read the Init notes below!
 *                 > You don't have to 'Init' but you do have to...
 *                     >> use my naming syntax for everything to work.
 *                     >> set the ship name in the PB custom data
 *                 > My prefered syntax is something like this...
 *                     >> <ship name>.<block type>.<padded count> for most blocks that you have a lot of
 *                         >>> eg Tachi.Gyroscope.69
 *                     >> <ship name>.<block type>.<friendly name> for more specifically named blocks lke connectors
 *                         >>> eg Tachi.Connector.Upper Aft
 *                     >> <ship name>.Door.Airlock.<Airlock_ID>.<friendly name>' for airlock doors (important)
 *                         >>> eg Tachi.Door.Airlock.Starboard.Inner
 * 
 *         - Provides a constantly updating LCD output with useful ship info.
 *                 > Tag an LCD with '[RSM]' to use.
 *                 > Displays a bunch of relevant ship info including...
 *                     >> Ship name and current stance.
 *                     >> Spinners on either side of ship name (confirms script is actively running)
 *                     >> Ship fuel and oxygen levels
 *                     >> Battery charge percentage
 *                     >> Inventory counts of fuel tanks, PDC magazines, railgun rounds and both types of torpedo
 *                         >>> Note: Currently, only cargo, cockpit (and reactors for fusion fuel) are checked.
 *                     >> Last 'Comms' value and max current antenna range
 *                     >> Current beacon ('Drive Signature') range
 *                     >> Current door status (number of closed doors / number of doors)
 *                     >> Script status info, like errors, warnings (more info in block details under the k menu)
 *                 > Tag, ammo and tank counts as well as other settings are adjustable via PB custom data
 * 
 *         - Manages ship 'stance' ('Stance:<stance>').  Think of stances as modes for your whole ship.
 *             With one button, you can...
 *                 > Turn on/off main drives, RCS, internal and external lights, autorepair system, PDCs & torpedoes
 *                 > Set the colour of external 'nav' lights and 'interior' lights
 *                 > Control stockpile on tanks and recharge on batteries
 *                 > Set the burn percentage on your EFC script, and toggle the boost functionality
 *                 > Launch torpedoes
 *                 > More info about stance management and pre-programmed stances below.
 * 
 *         - Manages ship 'Comms' ('Comms:<Message>')
 *                 > This provides a way for you to use your antennas for basic communication.
 *                 > This command sets all antenna's HUD text to your message.
 *                 > I use it to with various pre-set messages on my toolbar like 'Hello!', 'Don't Approach!'
 * 
 *         - Automatically turns on blocks which shouldn't be off
 *                 > If you're using auto-repair, you prob know that rebuilt blocks from a projector usually 
 *                     start switched off, and it's annoying af.
 *                 > Effected blocks include batteries, doors, connectors, tanks, lcds, PDCs, Torpedoes, doors
 * 
 *         - Automatically closes open doors after a timer
 *                 > Seperate timer for every door.
 *                 > The actual door time (counted in 100x game 'ticks') can be adjusted via PB custom data
 * 
 *         - Automatically manages airlocks
 *                 > Basically, if you open an airlock door, all other doors for that airlock are disabled for a timer
 *                 > This is a seperate, longer timer than the door close timer which gives a vent set to
 *                     'depressurize' a moment to save any oxygen in the room.
 *                 > The actual disable time (counted in 100x game 'ticks') can be adjusted via PB custom data
 *                 > Airlock doors must be named with the correct syntax to work correctly...
 *                     >> 'ShipName.Door.Airlock.<Airlock_ID>.Door Name'
 *                 > The Airlock_ID has to be unique for each airlock (so several doors will have the same ID)
 * 
 *         - Configurable server load features.
 *                 > I'm not currently aware of any issues with excessive CPU usage on this script, but just
 *                     in case, it is configurable.
 *                 > In the custom data of the PB you'll see the following...
 *                     >> 'Throttle script, skip loops (x100 ticks, default 0)=0'
 *                         >>> This many loops are skipped between each actual script loop to save CPU.
 *                         >>> A value of 1 halves the speed of the script, 3 quarters it etc.
 *                         >>> Note, this also effects the speed of other times, like those on doors.
 *                     >> 'x100 ticks between complete script refreshes (default 50)=50'
 *                         >>> By default, the script recalculates block lists, finds new blocks like LCDs, re-parses PB
 *                             custom data etc and completes other high-CPU usage tasks every 50 loops.
 *                         >>> You can improve performance by increasing this number, but the script will be slower
 *                             to respond to some changes.
 *                         >>> You can also force a full refresh anytime by pressing 'Recompile'.
 * 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 *     | Commands
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 *     >> Init <<
 * 
 *     > Init:<(string) Ship Name>
 *         This command renames all blocks on the current construct to my prefered syntax with custom padded numeration
 *         and some custom handling of certain block types   It uses block names, and should be run once only on a ship
 *         with default, unaltered names.
 *     
 *         Later versions will improve this so it can be re-run for added blocks.
 *     
 *         Some Tips:
 * 
 *             > Name your servers first to just Server: <name>.  I call PBs servers, get over it.
 *             > For interior lights, add the word 'interior' to the name somewhere or they will be processed as nav lights.
 *             > Connectors, cameras, doors won't be numbered, just add a useful name after each one.
 *             > Welders are tagged with the '[Autorepair]' keyword (or whatever is configured in custom data of PB)
 *             > You don't have to run init, but you do have to use my naming convention for the script to work completely.
 *                 Blocks with the wrong syntax won't be counted for the display etc
 *             > If you don't run init, or you change the ship name later, make sure you also update it under the custom data
 *                 of the programmable block
 *     
 *     >> Stance <<
 * 
 *     > Stance:<(string) Stance>
 *         This sets the ship to the provided stance   The complete list of each stance and the settings can be found in
 *         the code below, search for 'switch (stance)'.
 *     
 *         Here's the current list of stances...
 * 
 *             > Docking
 *             > Docked
 *             > Cruise
 *             > MaxCruise
 *             > Combat
 *             > Torpedoes
 *             > Coast
 *             > NoAttack
 * 
 *         Each stance has the following settings..
 * 
 *             // Fire torpedoes; 0: off, 1: on, 2: shoot
 *             torpedoes = 0;                                  
 * 
 *             // PDC status; 0: off, 1: min, 2: all 
 *             pdcs = 0;            
 *         
 *             // railgun; 0: off, 1: on
 *             railgun = 0;     
 *         
 *             // epstein; 0: off, 1: on
 *             epstein = 0;      
 *         
 *             // rcs thrusters;  0: off, 1: on
 *             rcs = 0;                                        
 * 
 *             // spotlights; 0: off, 1: on
 *             spotlights = 0;  
 *         
 *             // external lights; 0: off, 1: on
 *             navlights = 1;            
 *         
 *             // colour to set exterior lights to.
 *             navlightscolour = new Color(30, 144, 225, 255); 
 * 
 *             // colour to set interior lights to.
 *             interiorlights = new Color(30, 144, 225, 255); 
 * 
 *             // stockpile tanks, recharge batts; 0: off, 1: on
 *             stockpilerecharge = 1;
 * 
 *             // all blocks with text autorepair_keyword; 0: off, 1: on
 *             autorepair = 1;         
 *         
 *             // EFC boost; 0: off, 1: on
 *             speedboost = 0;            
 *         
 *             // EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 100%
 *             burn = 0;           
 *             
 *     >> Comms <<
 *             
 *     > Comms:<(string) Message>
 *         > This provides a way for you to use your antennas for basic communication.
 *         > This command sets all antenna's HUD text to your message.
 *         > I use it to with various pre-set messages on my toolbar like 'Hello!', 'Don't Approach!'
 * 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 *     | Wishlist (TODO)
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 *     > Refactored stance management code to use the pre-built block lists from main loop (back end efficiency improvements)
 *     > Improved weapons management
 *         - Seperate defence and offence PDC groups
 *         - Set 'target grid' via stance
 *         - Improved torpedo management
 *     > Improved LCD management
 *         - More info on screen? Maybe some kind of grid with more block status, damage status info.
 *         - Load status of weapons?
 *         - Configurable which types of inventory to check for.
 *         - Refactor and improve efficiency (especially barMe())
 *         - Make it work on other screens, not just LCDs, and handle multi screen etc.
 *         - Better number formatting (eg 1k instead of 1000)
 *     > Improved light management
 *         - In docking mode, Nav lights automatially detect what side of the ship they are on and go green or red automatically
 *         - Automatically increase spotlight range?
 *     > Sound management
 *         - Control a sound block for alert noises, stance change noises etc.
 *     > Improved init which can be run more than once to cleanup names on a ship.
 *     > Management of sensor(s)
 *         - intrusion detection alert
 *         - management of welders (prevent accidental death by weld)
 *         - manage power status, ensure always on
 *     > Gravity generator management
 *         - I'm thinking gravity generator that sets grav strength based on acceleration... maybe?
 *     > Extractor management
 *         - Automatically load fuel tanks into the extractor when ship fuel reaches a certain threshold.
 *         - Extractor management toggleable via stance
 *     > Management of decoy(s)?
 *         - permit adjustment via stance
 *         - manage power status, ensure always on
 *         - other, more elaborate mthods of spoofing
 *     > Improved stance management
 *         - Could put stance settings into the custom data for better access?
 * 
 * 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 */
const string lcd_divider="-------------------------";const string lcd_title="REEDIT SHIP MANAGEMENT";string[]
lcd_spinners=new string[]{"-","\\","|","/"};int lcd_spinner_status=0;const float lcd_font_size=0.8f;Color lcd_font_colour=new Color(
30,144,255,255);string ship_name="Untitled Ship";string lcd_keyword="[RSM]";string autorepair_keyword="[Autorepair]";int
target_fusion_count=1000;int target_pdc_count=100;int target_railgun_count=100;int target_torp_count=50;int target_torp_rs_count=50;int
target_tank_count=50;int door_open_time=3;int door_airlock_time=6;int wait_count=0;int refresh_freq=50;int loop_step;int wait_step;double
tank_h2_actual=0;double tank_h2_total=0;double tank_o2_actual=0;double tank_o2_total=0;double bat_actual=0;double bat_total=0;int
doors_count=0;int doors_count_closed=0;int autorepair_active=0;string current_stance="N/A";string current_comms="";double
current_comms_range=0;double current_sig_range=0;bool airlock_name_error_called=false;int debug_dwell_max=4;int debug_dwell=0;string
debug_msg="";string debug_msg_long="";List<IMyRadioAntenna>antenna_blocks=new List<IMyRadioAntenna>();List<IMyTextPanel>
lcd_blocks=new List<IMyTextPanel>();List<IMyGasTank>tank_blocks=new List<IMyGasTank>();List<IMyBatteryBlock>battery_blocks=new
List<IMyBatteryBlock>();List<IMyDoor>door_blocks=new List<IMyDoor>();List<IMyInventory>cargo_inventory=new List<IMyInventory
>();List<MyItemType>components=new List<MyItemType>();List<int>component_counts=new List<int>();int now_reactors;Program(
){loop_step=refresh_freq;wait_step=0;try{components.Add(new MyItemType("MyObjectBuilder_Ingot","FusionFuel"));
component_counts.Add(0);components.Add(new MyItemType("MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine"));component_counts.Add
(0);components.Add(new MyItemType("MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine"));component_counts.Add(0
);components.Add(new MyItemType("MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine"));component_counts.Add(0);
components.Add(new MyItemType("MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine"));component_counts.Add(0);components.
Add(new MyItemType("MyObjectBuilder_Component","Fuel_Tank"));component_counts.Add(0);}catch{debugEcho("Component error!","It seems like you might be missing one of the required mods?!  Failed to build a list of components to check inventories for."
);}Runtime.UpdateFrequency=UpdateFrequency.Update100;}void Save(){}void Main(string argument,UpdateType updateSource){if(
updateSource==UpdateType.Update100){mainLoop();return;}if(argument==""){debugEcho("Command Failed!",
"Argument Required!\ne.g.\nStance:Docked\nEvade:1\nComms:Whatsup?");return;}string[]args=argument.Split(':');if(args.Length!=2){debugEcho("Command Failed!",
"Syntax Error!\nWTF is that?\n"+argument);return;}switch(args[0].ToLower()){case"init":initShip(args[1]);break;case"stance":setStance(args[1]);break;
case"comms":setComms(args[1]);break;default:debugEcho("Command Failed!","Syntax Error!\nCommand not recognised\n"+args[0].
ToLower());return;}}void setStance(string stance){int torpedoes;int torpedoes_count=0;int pdcs;int pdcs_count=0;int
pdcs_on_count=0;int railgun;int railgun_count=0;int epstein;int epstein_count=0;int rcs;int rcs_count=0;int spotlights;int
spotlights_count=0;int navlights;int navlights_count=0;Color navlightscolour;Color interiorlights;int interiorlights_count=0;int
stockpilerecharge;int hydrogentank_count=0;int oxygentank_count=0;int battery_count=0;int autorepair;int autorepair_count=0;int
speedboost;int burn;int efc_found=0;switch(stance){case"Docked":torpedoes=0;pdcs=1;railgun=0;epstein=0;rcs=0;spotlights=0;
navlights=1;navlightscolour=new Color(30,144,255,255);interiorlights=new Color(255,240,225,255);stockpilerecharge=1;speedboost=0;
burn=0;autorepair=0;break;case"Docking":torpedoes=0;pdcs=1;railgun=0;epstein=0;rcs=1;spotlights=1;navlights=1;
navlightscolour=new Color(30,144,255,255);interiorlights=new Color(158,26,219,255);stockpilerecharge=0;speedboost=0;burn=0;autorepair=0
;break;case"NoAttack":torpedoes=0;pdcs=0;railgun=0;epstein=1;rcs=1;spotlights=0;navlights=1;navlightscolour=new Color(30,
144,255,255);interiorlights=new Color(255,255,255,255);stockpilerecharge=0;speedboost=0;burn=0;autorepair=0;break;case
"Cruise":torpedoes=0;pdcs=2;railgun=0;epstein=1;rcs=1;spotlights=0;navlights=1;navlightscolour=new Color(30,144,255,255);
interiorlights=new Color(33,144,255,255);stockpilerecharge=0;speedboost=0;burn=2;autorepair=0;break;case"MaxCruise":torpedoes=0;pdcs=2
;railgun=0;epstein=1;rcs=1;spotlights=0;navlights=1;navlightscolour=new Color(30,144,255,255);interiorlights=new Color(36
,17,242,255);stockpilerecharge=0;speedboost=1;burn=3;autorepair=0;break;case"Coast":torpedoes=1;pdcs=2;railgun=1;epstein=
0;rcs=0;spotlights=0;navlights=0;navlightscolour=new Color(0,0,0,0);interiorlights=new Color(33,144,255,50);
stockpilerecharge=0;speedboost=0;burn=0;autorepair=0;break;case"Combat":torpedoes=1;pdcs=2;railgun=1;epstein=1;rcs=1;spotlights=0;
navlights=0;navlightscolour=new Color(0,0,0,0);interiorlights=new Color(232,55,16,255);stockpilerecharge=0;speedboost=1;burn=3;
autorepair=1;break;case"Torpedoes":torpedoes=2;pdcs=2;railgun=1;epstein=1;rcs=1;spotlights=0;navlights=0;navlightscolour=new Color
(0,0,0,0);interiorlights=new Color(242,17,125,255);stockpilerecharge=0;speedboost=1;burn=3;autorepair=1;break;default:
debugEcho("Command Failed!","Syntax Error!\nStance not recognised\n"+stance);return;}current_stance=stance;autorepair_active=
autorepair;List<IMyTerminalBlock>allBlocks=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(
allBlocks);for(int i=0;i<allBlocks.Count;i++){if(Me.IsSameConstructAs(allBlocks[i])){if(allBlocks[i].DisplayNameText.Contains(
".Torpedo")){torpedoes_count++;switch(torpedoes){case 0:setBlockShootOff(allBlocks[i]);setBlockOff(allBlocks[i]);break;case 1:
setBlockShootOff(allBlocks[i]);setBlockOn(allBlocks[i]);break;case 2:setBlockOn(allBlocks[i]);setBlockShootOn(allBlocks[i]);break;}}if(
allBlocks[i].DisplayNameText.Contains(".PDC")){pdcs_count++;switch(pdcs){case 0:setBlockOff(allBlocks[i]);pdcs_on_count=0;break;
case 1:if(allBlocks[i].DisplayNameText.Contains("min")){setBlockOn(allBlocks[i]);pdcs_on_count++;}else setBlockOff(allBlocks
[i]);break;case 2:setBlockOn(allBlocks[i]);pdcs_on_count++;break;}}if(allBlocks[i].DisplayNameText.Contains(".Railgun")){
railgun_count++;if(railgun==1)setBlockOn(allBlocks[i]);else setBlockOff(allBlocks[i]);}if(allBlocks[i].DisplayNameText.Contains(
".Epstein")){epstein_count++;if(epstein==1)setBlockOn(allBlocks[i]);else setBlockOff(allBlocks[i]);}if(allBlocks[i].
DisplayNameText.Contains(".RCS")){rcs_count++;if(rcs==1)setBlockOn(allBlocks[i]);else setBlockOff(allBlocks[i]);}if(allBlocks[i].
DisplayNameText.Contains(".Spotlight")){spotlights_count++;if(spotlights==1)setBlockOn(allBlocks[i]);else setBlockOff(allBlocks[i]);}if
(allBlocks[i].DisplayNameText.Contains(".Light.Nav")){navlights_count++;allBlocks[i].SetValue("Color",navlightscolour);if
(navlights==1)setBlockOn(allBlocks[i]);else setBlockOff(allBlocks[i]);}if(allBlocks[i].DisplayNameText.Contains(
".Light.Interior")){interiorlights_count++;setBlockOn(allBlocks[i]);allBlocks[i].SetValue("Color",interiorlights);}if(allBlocks[i].
DisplayNameText.Contains(".Tank")){setBlockOn(allBlocks[i]);if(stockpilerecharge==1)setBlockStockpileOn(allBlocks[i]);else
setBlockStockpileOff(allBlocks[i]);if(allBlocks[i].DisplayNameText.Contains(".Hydrogen"))hydrogentank_count++;if(allBlocks[i].
DisplayNameText.Contains(".Oxygen"))oxygentank_count++;}if(allBlocks[i].DisplayNameText.Contains(".Battery")){battery_count++;
setBlockOn(allBlocks[i]);if(stockpilerecharge==1)setBlockRechargeOn(allBlocks[i]);else setBlockRechargeOff(allBlocks[i]);}if(
allBlocks[i].DisplayNameText.Contains(autorepair_keyword)){autorepair_count++;if(autorepair==1)setBlockOn(allBlocks[i]);else
setBlockOff(allBlocks[i]);}if(allBlocks[i].DisplayNameText.Contains(".Server")&&allBlocks[i].DisplayNameText.Contains("EFC")){
efc_found++;if(speedboost==1)setSpeedBoostOn(allBlocks[i]);else setSpeedBoostOff(allBlocks[i]);string burnt="";if(burn==1)burnt=
"5";else if(burn==2)burnt="25";else if(burn==3)burnt="100";if(allBlocks[i]is IMyProgrammableBlock)(allBlocks[i]as
IMyProgrammableBlock).TryRun("Set Burn "+burnt);}}}debugEcho(stance+" Stance Engaged","Found EFC Server: "+efc_found.ToString()+
"\n EFC Speedboost = "+speedboost.ToString()+"\n EFC Burn = "+burn.ToString()+"\n Torpedoes to "+torpedoes+": "+torpedoes_count.ToString()+
"\n PDCs to "+pdcs+": "+pdcs_on_count.ToString()+"/"+pdcs_count.ToString()+"\n Railguns to "+railgun+": "+railgun_count.ToString()+
"\n Epsteins to "+epstein+": "+epstein_count.ToString()+"\n RCS to "+rcs+": "+rcs_count.ToString()+"\n Spotlights to "+spotlights+": "+
spotlights_count.ToString()+"\n Navlights to "+navlights+": "+navlights_count.ToString()+"\n Interior Lights:  "+interiorlights_count.
ToString()+"\n H2 Tanks to "+stockpilerecharge+": "+hydrogentank_count.ToString()+"\n 02 Tanks to "+stockpilerecharge+": "+
oxygentank_count.ToString()+"\n Batteries to "+stockpilerecharge+": "+battery_count.ToString());}void initShip(string ship){ship_name=
ship;int blockCount=0;int nav_lights=0;int interior_lights=0;List<int>blockCounts=new List<int>();List<string>blockTypes=new
List<string>();blockTypes.Add("Torpedo");blockCounts.Add(0);blockTypes.Add("Railgun");blockCounts.Add(0);blockTypes.Add(
"Battery");blockCounts.Add(0);blockTypes.Add("RCS");blockCounts.Add(0);blockTypes.Add("Epstein");blockCounts.Add(0);blockTypes.
Add("Gyroscope");blockCounts.Add(0);blockTypes.Add("Flak");blockCounts.Add(0);blockTypes.Add("PDC");blockCounts.Add(0);
blockTypes.Add("Oxygen Tank");blockCounts.Add(0);blockTypes.Add("Hydrogen Tank");blockCounts.Add(0);blockTypes.Add(
"Fusion Reactor");blockCounts.Add(0);blockTypes.Add("Supercooled Reactor");blockCounts.Add(0);blockTypes.Add("Small Reactor");
blockCounts.Add(0);blockTypes.Add("Door");blockCounts.Add(0);blockTypes.Add("Light");blockCounts.Add(0);blockTypes.Add("Spotlight")
;blockCounts.Add(0);blockTypes.Add("LCD");blockCounts.Add(0);blockTypes.Add("Vent");blockCounts.Add(0);blockTypes.Add(
"Antenna");blockCounts.Add(0);blockTypes.Add("Cargo");blockCounts.Add(0);blockTypes.Add("Beacon");blockCounts.Add(0);blockTypes.
Add("Welder");blockCounts.Add(0);List<IMyTerminalBlock>allBlocks=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(allBlocks);for(int i=0;i<allBlocks.Count;i++){if(Me.IsSameConstructAs(allBlocks[i])){blockCount++;
bool found=false;for(int j=0;j<blockTypes.Count;j++){if(allBlocks[i].CustomName.Contains(blockTypes[j])){found=true;string
thisType=blockTypes[j];string formattedCount;if(thisType=="Flak")thisType="PDC";if(thisType=="Epstein")thisType="Epstein."+
allBlocks[i].CustomName.Split('"')[1];if(thisType=="Oxygen Tank")thisType="Tank.Oxygen";if(thisType=="Hydrogen Tank")thisType=
"Tank.Hydrogen";if(thisType=="Fusion Reactor")thisType="Reactor.Primary";if(thisType=="Supercooled Reactor")thisType="Reactor.SCSmall";
if(thisType=="Small Reactor")thisType="Reactor.Small";if(thisType=="Cargo"&&allBlocks[i].CustomName.Contains("Small"))
thisType="Cargo.Sm";blockCounts[j]++;if(thisType=="Light"){if(allBlocks[i].CustomName.Contains("Interior")){interior_lights++;
thisType="Light.Interior";formattedCount=interior_lights.ToString().PadLeft(2,'0');}else{nav_lights++;thisType="Light.Nav";
formattedCount=nav_lights.ToString().PadLeft(2,'0');}}else if(thisType=="Connector"||thisType=="Camera"||thisType=="Door")
formattedCount="";else formattedCount=blockCounts[j].ToString().PadLeft(2,'0');if(thisType=="Welder")formattedCount+=" "+
autorepair_keyword;allBlocks[i].CustomName=ship+"."+thisType+"."+formattedCount;}}if(!found)allBlocks[i].CustomName=ship+"."+allBlocks[i].
CustomName;}}string msg="Done!\n";for(int i=0;i<blockTypes.Count;i++)msg+=" "+blockTypes[i]+"="+blockCounts[i]+"\n";debugEcho(
"Initialised '"+ship+"'",msg+"\nGood Hunting!");}void setComms(string comms){current_comms=comms;for(int i=0;i<antenna_blocks.Count;i++
){antenna_blocks[i].HudText=comms;}}void setBlockOff(IMyTerminalBlock block){List<ITerminalAction>actions=new List<
ITerminalAction>();block.GetActions(actions,(x)=>x.Id.Equals("OnOff_Off"));if(actions.Count>0)actions[0].Apply(block);}void setBlockOn(
IMyTerminalBlock block){List<ITerminalAction>actions=new List<ITerminalAction>();block.GetActions(actions,(x)=>x.Id.Equals("OnOff_On"));
if(actions.Count>0)actions[0].Apply(block);}void setBlockShootOn(IMyTerminalBlock block){List<ITerminalAction>actions=new
List<ITerminalAction>();block.GetActions(actions,(x)=>x.Id.Equals("Shoot_On"));if(actions.Count>0)actions[0].Apply(block);}
void setBlockShootOff(IMyTerminalBlock block){List<ITerminalAction>actions=new List<ITerminalAction>();block.GetActions(
actions,(x)=>x.Id.Equals("Shoot_Off"));if(actions.Count>0)actions[0].Apply(block);}void setBlockStockpileOn(IMyTerminalBlock
block){List<ITerminalAction>actions=new List<ITerminalAction>();block.GetActions(actions,(x)=>x.Id.Equals("Stockpile_On"));if
(actions.Count>0)actions[0].Apply(block);}void setBlockStockpileOff(IMyTerminalBlock block){List<ITerminalAction>actions=
new List<ITerminalAction>();block.GetActions(actions,(x)=>x.Id.Equals("Stockpile_Off"));if(actions.Count>0)actions[0].Apply
(block);}void setBlockRechargeOn(IMyTerminalBlock block){long status=block.GetValue<long>("ChargeMode");if(status!=1){
List<ITerminalAction>actions=new List<ITerminalAction>();block.GetActions(actions,(x)=>x.Id.Equals("Recharge"));if(actions.
Count>0)actions[0].Apply(block);}}void setBlockRechargeOff(IMyTerminalBlock block){List<ITerminalAction>actions=new List<
ITerminalAction>();block.GetActions(actions,(x)=>x.Id.Equals("Auto"));if(actions.Count>0)actions[0].Apply(block);}void setSpeedBoostOn(
IMyTerminalBlock block){if(block is IMyProgrammableBlock)(block as IMyProgrammableBlock).TryRun("Boost On");}void setSpeedBoostOff(
IMyTerminalBlock block){if(block is IMyProgrammableBlock)(block as IMyProgrammableBlock).TryRun("Boost Off");}void mainLoop(){if(
wait_step<wait_count){wait_step++;return;}wait_step=0;if(loop_step>=refresh_freq){loop_step=0;fullRefresh();return;}loop_step++;
partialRefresh();return;}void partialRefresh(){List<IMyTerminalBlock>allBlocks=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(allBlocks);bool got_beacon_range=false;current_comms_range=0;for(int i=0;i<allBlocks.Count;i++){if(Me
.IsSameConstructAs(allBlocks[i])){if(allBlocks[i].DisplayNameText.Contains(".Beacon")&&allBlocks[i]is IMyBeacon&&
got_beacon_range==false){current_sig_range=allBlocks[i].GetValue<float>("Radius");got_beacon_range=true;}if(allBlocks[i].DisplayNameText
.Contains(".Connector"))setBlockOn(allBlocks[i]);}}for(int i=0;i<antenna_blocks.Count;i++){if(antenna_blocks[i].
CustomName.Contains(ship_name)){float range=antenna_blocks[i].Radius;if(range>current_comms_range)current_comms_range=range;}}for(
int i=0;i<tank_blocks.Count;i++){if(tank_blocks[i].DisplayNameText.Contains(ship_name)){tank_blocks[i].Enabled=true;if(
tank_blocks[i].DisplayNameText.Contains(".Hydrogen")){tank_h2_total+=tank_blocks[i].Capacity;tank_h2_actual+=(tank_blocks[i].
Capacity*tank_blocks[i].FilledRatio);}if(tank_blocks[i].DisplayNameText.Contains(".Oxygen")){tank_o2_total+=tank_blocks[i].
Capacity;tank_o2_actual+=(tank_blocks[i].Capacity*tank_blocks[i].FilledRatio);}}}bat_actual=0;bat_total=0;for(int i=0;i<
battery_blocks.Count;i++){if(battery_blocks[i].DisplayNameText.Contains(ship_name)){battery_blocks[i].Enabled=true;bat_actual+=
battery_blocks[i].CurrentStoredPower;bat_total+=battery_blocks[i].MaxStoredPower;}}for(int i=0;i<component_counts.Count;i++){
component_counts[i]=0;}for(int i=0;i<cargo_inventory.Count;i++){if(i>=now_reactors){try{MyInventoryItem?check=cargo_inventory[i].
FindItem(components[0]);string[]parse_dat=check.ToString().Split('x');double count=double.Parse(parse_dat[0]);component_counts[0
]+=(int)Math.Round(count);}catch{}}else{for(int j=0;j<components.Count;j++){MyInventoryItem?check=cargo_inventory[i].
FindItem(components[j]);if(check!=null){try{string[]parse_dat=check.ToString().Split('x');double count=double.Parse(parse_dat[0]
);component_counts[j]+=(int)Math.Round(count);}catch{}}}}}manageDoors();updateLcd();return;}void fullRefresh(){
updateCustomData();lcd_blocks.Clear();antenna_blocks.Clear();door_blocks.Clear();tank_blocks.Clear();battery_blocks.Clear();
cargo_inventory.Clear();List<IMyRadioAntenna>ants=new List<IMyRadioAntenna>();GridTerminalSystem.GetBlocksOfType<IMyRadioAntenna>(ants)
;for(int i=0;i<ants.Count;i++){if(ants[i].CustomName.Contains(ship_name)){antenna_blocks.Add(ants[i]);}}List<IMyTextPanel
>lcds=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(lcds);for(int i=0;i<lcds.Count;i++){if(
lcds[i].CustomName.Contains(lcd_keyword)&&lcds[i].CustomName.Contains(ship_name)){lcd_blocks.Add(lcds[i]);lcds[i].
ContentType=ContentType.TEXT_AND_IMAGE;lcds[i].FontColor=lcd_font_colour;lcds[i].FontSize=lcd_font_size;lcds[i].Font="Monospace";
lcds[i].TextPadding=0;lcds[i].Alignment=TextAlignment.CENTER;}}List<IMyDoor>doors=new List<IMyDoor>();GridTerminalSystem.
GetBlocksOfType<IMyDoor>(doors);for(int i=0;i<doors.Count;i++){if(doors[i].CustomName.Contains(".Door")&&doors[i].CustomName.Contains(
ship_name)){door_blocks.Add(doors[i]);}}List<IMyGasTank>tanks=new List<IMyGasTank>();GridTerminalSystem.GetBlocksOfType<
IMyGasTank>(tanks);for(int i=0;i<tanks.Count;i++){if(tanks[i].CustomName.Contains(".Tank")&&tanks[i].CustomName.Contains(ship_name
)){tank_blocks.Add(tanks[i]);}}List<IMyBatteryBlock>batteries=new List<IMyBatteryBlock>();GridTerminalSystem.
GetBlocksOfType<IMyBatteryBlock>(batteries);for(int i=0;i<batteries.Count;i++){if(batteries[i].CustomName.Contains(".Battery")&&
batteries[i].CustomName.Contains(ship_name)){battery_blocks.Add(batteries[i]);}}List<IMyCargoContainer>cargos=new List<
IMyCargoContainer>();GridTerminalSystem.GetBlocksOfType<IMyCargoContainer>(cargos);for(int i=0;i<cargos.Count;i++){if(cargos[i].
CustomName.Contains(ship_name)){cargo_inventory.Add(cargos[i].GetInventory());}}List<IMyCockpit>cockpits=new List<IMyCockpit>();
GridTerminalSystem.GetBlocksOfType<IMyCockpit>(cockpits);for(int i=0;i<cockpits.Count;i++){if(cockpits[i].CustomName.Contains(ship_name)){
cargo_inventory.Add(cockpits[i].GetInventory());}}now_reactors=cargo_inventory.Count;List<IMyReactor>reactors=new List<IMyReactor>();
GridTerminalSystem.GetBlocksOfType<IMyReactor>(reactors);for(int i=0;i<reactors.Count;i++){if(reactors[i].CustomName.Contains(ship_name)){
cargo_inventory.Add(reactors[i].GetInventory());}}return;}void updateCustomData(){try{string[]parse_dat=Me.CustomData.Split('=');for(
int i=0;i<parse_dat.Length;i++){string[]cleanup=parse_dat[i].Split('\n');parse_dat[i]=cleanup[0];}ship_name=parse_dat[1];
lcd_keyword=parse_dat[2];autorepair_keyword=parse_dat[3];target_fusion_count=int.Parse(parse_dat[4]);if(target_fusion_count==0)
target_fusion_count++;target_pdc_count=int.Parse(parse_dat[5]);if(target_pdc_count==0)target_pdc_count++;target_railgun_count=int.Parse(
parse_dat[6]);if(target_railgun_count==0)target_railgun_count++;target_torp_count=int.Parse(parse_dat[7]);if(target_torp_count==0
)target_torp_count++;target_torp_rs_count=int.Parse(parse_dat[8]);if(target_torp_rs_count==0)target_torp_rs_count++;
target_tank_count=int.Parse(parse_dat[9]);if(target_tank_count==0)target_tank_count++;door_open_time=int.Parse(parse_dat[10]);
door_airlock_time=int.Parse(parse_dat[11]);wait_count=int.Parse(parse_dat[12]);refresh_freq=int.Parse(parse_dat[13]);return;}catch{
debugEcho("Custom Data Error!","Custom data invalid or blank, resetting...");}Me.CustomData="-------------------------\n"+
"Reedit Ship Management"+"\n"+"-------------------------\n"+"If this data can't be parsed, it will be reset!"+"\n"+"-------------------------\n"
+"Ship name="+ship_name+"\n"+"LCD keyword="+lcd_keyword+"\n"+"Autorepair keyword="+autorepair_keyword+"\n"+
"Fusion Fuel count="+target_fusion_count+"\n"+"PDC Magazine count="+target_pdc_count+"\n"+"Railgun rounds count="+target_railgun_count+"\n"+
"Torpedo count="+target_torp_count+"\n"+"Ramshackle torpedo Count="+target_torp_rs_count+"\n"+"Fuel tank count="+target_tank_count+"\n"+
"Doors open timer (x100 ticks, default 3)="+door_open_time+"\n"+"Airlock doors disabled timer (x100 ticks, default 6)="+door_airlock_time+"\n"+
"Throttle script, skip loops (x100 ticks, default 0)="+wait_count+"\n"+"x100 ticks between complete script refreshes (default 50)="+refresh_freq+"\n"+
"-------------------------\n";return;}void manageDoors(){string marked_for_disabling="";doors_count=0;doors_count_closed=0;for(int i=0;i<door_blocks.
Count;i++){doors_count++;if(!door_blocks[i].Enabled==true||door_blocks[i].OpenRatio!=0){string[]parse_dat=door_blocks[i].
CustomData.Split('=');for(int j=0;j<parse_dat.Length;j++){string[]cleanup=parse_dat[j].Split('\n');parse_dat[j]=cleanup[0];}int
open_timer_count=int.Parse(parse_dat[1]);int off_timer_count=int.Parse(parse_dat[2]);if(door_blocks[i].OpenRatio!=0){if(open_timer_count
==0){try{string[]name_bits=door_blocks[i].CustomName.Split('.');if(!marked_for_disabling.Contains(name_bits[3])){
marked_for_disabling+=name_bits[3]+",";}}catch{if(airlock_name_error_called){airlock_name_error_called=true;debugEcho("Airlock door naming!"
,"There's a door block marked as .Airlock. that isn't named correctly. Please use ShipName.Door.Airlock.<Airlock_ID>.Door Name"
);}}}door_blocks[i].Enabled=true;open_timer_count++;if(open_timer_count>=door_open_time){open_timer_count=0;door_blocks[i
].CloseDoor();}}if(!door_blocks[i].Enabled){off_timer_count++;if(off_timer_count>=door_airlock_time){off_timer_count=0;
door_blocks[i].Enabled=true;}}door_blocks[i].CustomData=buildDoorData(open_timer_count,off_timer_count);}else{door_blocks[i].
CustomData=buildDoorData(0,0);if(door_blocks[i].OpenRatio==0)doors_count_closed++;}}if(marked_for_disabling!=""){string[]
to_disable=marked_for_disabling.Split(',');for(int i=0;i<door_blocks.Count;i++){bool disable=false;for(int j=0;j<to_disable.Length
;j++){if(to_disable[j]!=""&&door_blocks[i].CustomName.Contains(to_disable[j])&&door_blocks[i].Enabled==true&&door_blocks[
i].OpenRatio==0)disable=true;}if(disable==true){door_blocks[i].Enabled=false;}}}return;}string buildDoorData(int open,int
disabled){return"-------------------------\n"+"Reedit Ship Management"+"\n"+"-------------------------\n"+
"Timer count values, don't touch!"+"\n"+"-------------------------\n"+"Open Timer="+open.ToString()+"\n"+"Disabled Timer="+disabled.ToString()+"\n"+
"-------------------------\n";}void updateLcd(){lcd_spinner_status++;if(lcd_spinner_status>=lcd_spinners.Length)lcd_spinner_status=0;string spinner=
lcd_spinners[lcd_spinner_status];string debug="";if(debug_msg!=""){debug_dwell++;if(debug_dwell>=debug_dwell_max){debug_dwell=0;
debug_msg="";}else{debug="\n\n"+debug_msg+"\n"+debug_msg_long;}}string output_comms=current_comms;if(output_comms.Length<13)
output_comms+=new string(' ',(13-output_comms.Length));string output_comms_range=Math.Round((current_comms_range/1000),3).ToString()
+" km ";if(output_comms_range.Length<13)output_comms_range+=new string(' ',(13-output_comms_range.Length));string
output_sig_range=Math.Round((current_sig_range/1000),3).ToString()+" km ";if(output_sig_range.Length<13)output_sig_range+=new string(' '
,(13-output_sig_range.Length));string output_ar="ACTIVE       ";if(autorepair_active==1)output_ar="INACTIVE     ";string
output_doors=doors_count_closed+"/"+doors_count;if(output_doors.Length<13)output_doors+=new string(' ',(13-output_doors.Length));
string output_text=lcd_divider+"\n"+spinner+" "+ship_name.ToUpper()+" "+spinner+"\n"+lcd_title+"\n"+lcd_divider+"\n"+
"STANCE: "+current_stance.ToUpper()+"\n"+lcd_divider+"\n"+debug_msg+"\n"+"Fuel     "+barMe("H2")+"\n"+"Oxygen   "+barMe("O2")+"\n"
+"Battery  "+barMe("Battery")+"\n"+"F Tanks  "+barMe("FuelTanks")+"\n"+"Fusion F "+barMe("Fusion")+"\n"+"PDC Mags "+barMe
("PDC")+"\n"+"Railgun  "+barMe("Railgun")+"\n"+"Torps220 "+barMe("Torp")+"\n"+"TorpsRS  "+barMe("TorpRS")+"\n"+
"Comms:            "+output_comms+"\n"+"Comms Range:      "+output_comms_range+"\n"+"Signature Range:  "+output_sig_range+"\n"+
"Autorepair:       "+output_ar+"\n"+"Doors Closed:     "+output_doors+"\n";for(int i=0;i<lcd_blocks.Count;i++){lcd_blocks[i].WriteText(
output_text,false);}Echo(output_text+debug);return;}string barMe(string bar_type){string bar;string val="";double percentage=0;
switch(bar_type){case"H2":percentage=(100*(tank_h2_actual/tank_h2_total));val=Math.Round(percentage).ToString()+" %";break;
case"O2":percentage=(100*(tank_o2_actual/tank_o2_total));val=Math.Round(percentage).ToString()+" %";break;case"Battery":
percentage=(100*(bat_actual/bat_total));val=Math.Round(percentage).ToString()+" %";break;case"FuelTanks":percentage=(100*((double)
component_counts[5]/(double)target_tank_count));val=component_counts[5].ToString()+"/"+target_tank_count;break;case"Fusion":percentage=(
100*((double)component_counts[0]/(double)target_fusion_count));val=component_counts[0].ToString()+"/"+target_fusion_count;
break;case"PDC":percentage=(100*((double)component_counts[4]/(double)target_pdc_count));val=component_counts[4].ToString()+
"/"+target_pdc_count;break;case"Railgun":percentage=(100*((double)component_counts[1]/(double)target_railgun_count));val=
component_counts[1].ToString()+"/"+target_railgun_count;break;case"Torp":percentage=(100*((double)component_counts[2]/(double)
target_torp_count));val=component_counts[2].ToString()+"/"+target_torp_count;break;case"TorpRS":percentage=(100*((double)component_counts
[3]/(double)target_torp_rs_count));val=component_counts[3].ToString()+"/"+target_torp_rs_count;break;}bar=generateBar(
percentage);if(val.Length<9)val+=new string(' ',(9-val.Length));if(val.Length>9)val=val.Substring(0,9);return"["+bar+"] "+val;}
void debugEcho(string msg,string msg_long){debug_dwell=0;debug_msg=msg;debug_msg_long=msg_long;}string generateBar(double
percentage){int ones_count=0;if(percentage>0){int try_this=(int)percentage/10;if(try_this>10)return new string('=',10);if(try_this
!=0)ones_count=try_this;}string ones=new string('=',ones_count);string zeros=new string(' ',10-ones_count);return ones+
zeros;}