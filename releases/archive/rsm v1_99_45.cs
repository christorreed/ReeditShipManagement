/*
 * ----------------------------------------------------------------------------------------------------------------------
 *  REEDIT SHIP MANAGEMENT
 * ----------------------------------------------------------------------------------------------------------------------
 *  
 *   Reedit Ship Management (RSM) is a broad, ship automation script tailor made for the Draconis Expanse server.
 * 
 *   • Read the guide...
 *      https://github.com/christorreed/ReeditShipManagement
 *   • Join the discussion...
 *      https://discord.com/channels/516135382191177728/1066185228697211030/1066185233386446980
 * 
 * ----------------------------------------------------------------------------------------------------------------------
 */

string Version = "1.99.45 (2024-04-08)";
ƹ ͼ;int ͻ=0;int ͺ=0;int ͷ=0;int Ͷ;bool ͽ=true;bool ʹ=true;bool Ͳ=false;bool ͱ=false;bool Ͱ=false;bool ˮ=false;bool ˬ=
false;bool ˤ=false;int ͳ=0;int ˣ=0;double Ά;float Η;string Ε;string Δ;string Γ;bool Β=false;int Α=0;int ΐ=0;Program(){Echo(
"Welcome to RSM\nV "+Version);ʵ();Ͷ=ɷ;Ε=Me.GetOwnerFactionTag();ͼ=new ƹ(Runtime);ϫ();ɼ.Add(0.5);ɼ.Add(0.25);ɼ.Add(0.1);ɼ.Add(0.05);ʀ();
Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo("Took "+ʵ());}void Main(string À,UpdateType Ώ){if(Ώ==UpdateType.
Update100)ʾ();else Ύ(À);}void Ύ(string À){if(ɺ)Echo("Processing command '"+À+"'...");if(À==""){н.Add(new ц(
"COMMAND FAILED: Arg Required!","A command was ignored because the argument was blank.",3));return;}string[]Ό=À.Split(':');if(Ό.Length<2){н.Add(new ц(
"COMMAND FAILED: Syntax Error!","A command was ignored because it wasn't recognised.",3));return;}if(Ό[0].ToLower()!="comms")Ό[1]=Ό[1].Replace(" ",
string.Empty);switch(Ό[0].ToLower()){case"init":bool Ί=true,Ή=true,Έ=true;if(Ό.Length>2){foreach(string Ζ in Ό){if(Ζ.ToLower()
=="nonames")Ί=false;else if(Ζ.ToLower()=="nosubs")Ή=false;else if(Ζ.ToLower()=="noinv")Έ=false;}}ҏ(Ό[1],Ί,Ή,Έ);return;case
"stance":ā(Ό[1]);return;case"hudlcd":string ˢ="";if(Ό.Length>2)ˢ=Ό[2];ī(Ό[1],ˢ);return;case"doors":string ˠ="";if(Ό.Length>2)ˠ=Ό
[2];Ү(Ό[1],ˠ);return;case"comms":ˑ(Ό[1]);return;case"printblockids":ȸ();return;case"printblockprops":ɏ(Ό[1]);return;case
"spawn":if(Ό[1].ToLower()=="open"){ˮ=true;Ͷ=ɷ;н.Add(new ц("Spawns were opened to friends",
"Spawns are now opened to the friends list as defined in PB custom data.",2));}else{ˮ=false;Ͷ=ɷ;н.Add(new ц("Spawns were closed to friends",
"Spawns are now closed to the friends list as defined in PB custom data.",2));}return;case"projectors":if(Ό[1].ToLower()=="save"){foreach(IMyProjector C in ϙ)E(C);н.Add(new ц(
"Projector positions saved","Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector C in ϙ)D(C);н.
Add(new ц("Projector positions loaded","Projector positions were loaded from custom data.",2));return;}default:н.Add(new ц(
"COMMAND FAILED: Syntax Error!","A command was ignored because it wasn't recognised.",3));return;}}void ʾ(){if(ͺ<ɸ){ͺ++;return;}ͺ=0;if(ͽ){if(ɹ)ʵ();Echo
("Parsing custom data...");Ѭ();ͽ=false;return;}ʸ();Α=Runtime.CurrentInstructionCount;if(Α>ΐ)ΐ=Runtime.
CurrentInstructionCount;if(ɹ)ʵ();if(ï.ò==ƚ.On){Ͳ=true;ͱ=true;}else if(ï.ò==ƚ.Off){Ͳ=true;}if(Ͷ>=ɷ){Ͷ=0;ʿ();return;}Ͷ++;ʽ();ʼ();if(ɹ)Echo(
"Took "+ʵ());if(ɺ)Echo("Updating "+Χ.Count+" RSM Lcds");ŀ();if(ɹ)Echo("Took "+ʵ());}void ʽ(){ʺ();switch(ͻ){case 0:if(ɺ)Echo(
"Refreshing "+ώ.Count+" railguns...");l();if(ɹ)Echo("Took "+ʵ());if(ʹ)break;else goto case 1;case 1:if(ɺ)Echo("Refreshing "+ϗ.Count+
" reactors & "+ρ.Count+" batteries...");Ê(ï.ù);if(ɹ)Echo("Took "+ʵ());if(ʹ)break;else goto case 2;case 2:if(ɺ)Echo("Refreshing "+ό.
Count+" epsteins...");å();if(ɹ)Echo("Took "+ʵ());if(ʹ)break;else goto case 3;case 3:if(ɺ)Echo("Refreshing "+ϑ.Count+
" lidars...");Ƃ(ͱ,Ͳ);if(ɹ)Echo("Took "+ʵ());if(ɺ)Echo("Refreshing pb servers...");x();if(ɹ)Echo("Took "+ʵ());if(ʹ)break;else goto
case 4;case 4:if(ɺ)Echo("Refreshing "+Π.Count+" doors...");ұ();if(ɹ)Echo("Took "+ʵ());if(ɺ)Echo("Refreshing "+Ξ.Count+
" airlocks...");Ҝ();if(ɹ)Echo("Took "+ʵ());break;default:if(ɺ)Echo("Booting complete");ʹ=false;ͻ=0;return;}if(ʹ)ͻ++;}void ʼ(){switch(ͷ
){case 0:if(ɺ)Echo("Clearing temp inventories...");Ϫ();if(ɹ)Echo("Took "+ʵ());if(ɺ)Echo("Refreshing "+ύ.Count+
" torpedo launchers...");Ȃ();if(ɹ)Echo("Took "+ʵ());if(ɺ)Echo("Refreshing items...");ϩ();if(ɹ)Echo("Took "+ʵ());break;case 1:if(ɺ)Echo(
"Running autoload...");ˍ();if(ɹ)Echo("Took "+ʵ());break;case 2:if(ɺ)Echo("Refreshing "+ϕ.Count+" H2 tanks...");Ø();if(ɹ)Echo("Took "+ʵ());if(
ɺ)Echo("Refreshing refuel status...");ѽ();if(Ͱ){if(ɺ)Echo("Fuel low, filling extractors...");Ѻ();if(ɹ)Echo("Took "+ʵ());
return;}else{ʻ();if(ɹ)Echo("Took "+ʵ());}ͷ=0;return;}ͷ++;}void ʻ(){if(ɺ)Echo("Refreshing "+ϋ.Count+" rcs...");Ƿ();if(ɺ)Echo(
"Refreshing "+ϐ.Count+" Pdcs & "+Ϗ.Count+" defensive Pdcs...");t();if(ɺ)Echo("Refreshing "+Ϙ.Count+" gyros...");ґ(ͱ,Ͳ);if(ɺ)Echo(
"Refreshing "+ϔ.Count+" O2 tanks...");Ô();if(ɺ)Echo("Refreshing "+ς.Count+" antennas...");ˡ();if(ɺ)Echo("Refreshing "+ο.Count+
" cargos...");ʙ();if(ɺ)Echo("Refreshing "+ϓ.Count+" vents...");Ŭ(ͱ,Ͳ);if(ɺ)Echo("Refreshing "+Ψ.Count+" auxiliary blocks...");υ();if
(ɺ)Echo("Refreshing "+ϒ.Count+" welders...");Ɯ();if(ɺ)Echo("Refreshing "+Ω.Count+" lcds...");Ɖ();if(Ͳ){if(ɺ)Echo(
"Refreshing "+ξ.Count+" connectors...");ũ(ͱ);if(ɺ)Echo("Refreshing "+π.Count+" cameras...");ŧ(ͱ);if(ɺ)Echo("Refreshing "+ϖ.Count+
" sensors...");ť(ͱ);}}void ʿ(){if(ɺ)Echo("Clearing block lists...");ɬ();if(ɹ)Echo("Took "+ʵ());if(ɺ)Echo("Refreshing block lists...")
;GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,Λ);if(ɹ)Echo("Took "+ʵ());if(ɺ)Echo(
"Setting KeepFull threshold");Ҋ();if(σ==null){if(ν.Count>0)σ=ν[0];else н.Add(new ц("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ɺ)Echo("Finished block refresh.");if(ɹ)Echo("Took "+ʵ());}void ʺ(){try{Ǵ=new ǲ();Ǵ.ȧ(Me);}catch(Exception ex){Ǵ
=null;н.Add(new ц("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ʸ(){string ʷ="REEDIT SHIP MANAGEMENT \n\n|- V "+Version+"\n|- Ship Name: "+ɽ+"\n|- Stance: "+ð+
"\n|- Step: "+Ͷ+"/"+ɷ+" ("+ͷ+")";if(ʹ)ʷ+="\n|- Booting "+ͻ;if(ɹ){ͼ.ƽ();ʷ+="\n|- Runtime Av/Tick: "+(Math.Round(ͼ.Ʒ,2)/100)+" ms"+
"\n|- Runtime Max: "+Math.Round(ͼ.Ǉ,4)+" ms"+"\n|- Instructions: "+Α+" ("+ΐ+")";}Echo(ʷ+"\n");}long ʶ=0;string ʵ(){long ʴ=DateTime.Now.Ticks
/TimeSpan.TicksPerMillisecond;if(ʶ==0){ʶ=ʴ;return"0 ms";}long ʳ=ʴ-ʶ;ʶ=ʴ;return ʳ+" ms";}bool ʹ=false;string ʲ="";double ˁ
=0;void ˡ(){ʹ=false;ˁ=0;foreach(IMyRadioAntenna ˏ in ς){if(ˏ!=null){if(ˏ.IsFunctional){float Ȝ=ˏ.Radius;if(Ȝ>ˁ)ˁ=Ȝ;if(ˏ.
IsBroadcasting&&ˏ.Enabled)ʹ=true;}}}}void ˑ(string ː){ʲ=ː;foreach(IMyTerminalBlock ȹ in ς){IMyRadioAntenna ˏ=ȹ as IMyRadioAntenna;if(ˏ
!=null)ˏ.HudText=ː;}}string ˎ="";void ˍ(){if(!ʔ)return;ˎ="";foreach(var Ō in Ϣ){if(!Ō.ϣ&&!Ō.ϛ)continue;if(ɺ)Echo(
"Checking "+Ō.ϝ);List<Ѕ>ˌ=Ō.ϼ.Concat(Ō.ϻ).ToList();List<Ѕ>ˋ=new List<Ѕ>();List<Ѕ>ˊ=new List<Ѕ>();List<Ѕ>ˉ=new List<Ѕ>();int ˈ=0;int
ˇ=0;bool ˀ=false;foreach(Ѕ ˆ in ˌ){if(ˆ==null)continue;if(ˆ.Ђ){ˇ++;ˈ+=ˆ.Ѓ;if(ˆ.Ё<0.95){ˉ.Add(ˆ);}if(ˆ.Ё!=0){ˊ.Add(ˆ);}
else if(!ˀ&&Ō.Ͼ==0){ˀ=true;}}else{if(ˆ.Ѓ>0){ˋ.Add(ˆ);}}}if(ˀ){if(ˎ!="")ˎ+="\n";ˎ+=Ō.Ϻ.SubtypeId;}if(ˉ.Count>0){int Θ=(int)(ˈ
/ˇ);ˉ=ˉ.OrderBy(Ě=>Ě.Ѓ).ToList();if(Ō.Ͼ>0){if(ɺ)Echo("Loading "+Ō.Ϻ.SubtypeId+"...");ˋ=ˋ.OrderByDescending(Ě=>Ě.Ѓ).ToList
();Ј(ˋ,ˉ,Ō.Ϻ);}else{if(ɺ)Echo("Balancing "+Ō.Ϻ.SubtypeId+"...");ˊ=ˊ.OrderByDescending(Ě=>Ě.Ѓ).ToList();Ј(ˊ,ˉ,Ō.Ϻ,Θ);}}
else{if(ɺ)Echo("No loading required "+Ō.Ϻ.SubtypeId+"...");}}}void υ(){ˣ=0;foreach(IMyTerminalBlock ȹ in Ψ){if(ȹ==null)
continue;if(ȹ.IsWorking)ˣ++;}}void τ(ƚ e){if(e==ƚ.NoChange)return;foreach(IMyTerminalBlock ȹ in Ψ){if(ȹ==null)continue;try{if(e
==ƚ.Off)ȹ.ApplyAction("OnOff_Off");else ȹ.ApplyAction("OnOff_On");}catch{if(ɺ)Echo("Failed to set aux block "+ȹ.CustomName
);}}}IMyShipController σ;List<IMyRadioAntenna>ς=new List<IMyRadioAntenna>();List<IMyBatteryBlock>ρ=new List<
IMyBatteryBlock>();List<IMyCameraBlock>π=new List<IMyCameraBlock>();List<IMyCargoContainer>ο=new List<IMyCargoContainer>();List<
IMyShipConnector>ξ=new List<IMyShipConnector>();List<IMyShipController>ν=new List<IMyShipController>();List<IMyAirtightHangarDoor>μ=new
List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>φ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>χ=new List<
IMyTerminalBlock>();List<IMyGyro>Ϙ=new List<IMyGyro>();List<IMyProjector>ϙ=new List<IMyProjector>();List<IMyReactor>ϗ=new List<
IMyReactor>();List<IMySensorBlock>ϖ=new List<IMySensorBlock>();List<IMyGasTank>ϕ=new List<IMyGasTank>();List<IMyGasTank>ϔ=new List
<IMyGasTank>();List<IMyAirVent>ϓ=new List<IMyAirVent>();List<IMyTerminalBlock>ϒ=new List<IMyTerminalBlock>();List<
IMyConveyorSorter>ϑ=new List<IMyConveyorSorter>();List<IMyTerminalBlock>ϐ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ϗ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>ώ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ύ=new List<IMyTerminalBlock>();List<
IMyThrust>ό=new List<IMyThrust>();List<IMyThrust>ϋ=new List<IMyThrust>();List<IMyThrust>ϊ=new List<IMyThrust>();List<IMyThrust>ω=
new List<IMyThrust>();List<IMyProgrammableBlock>ψ=new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>λ=new List<
IMyProgrammableBlock>();List<IMyTextPanel>Ω=new List<IMyTextPanel>();List<IMyTextPanel>ι=new List<IMyTextPanel>();List<б>Χ=new List<б>();
List<IMyLightingBlock>Φ=new List<IMyLightingBlock>();List<IMyLightingBlock>Υ=new List<IMyLightingBlock>();List<
IMyLightingBlock>Τ=new List<IMyLightingBlock>();List<IMyLightingBlock>Σ=new List<IMyLightingBlock>();List<IMyReflectorLight>Ρ=new List<
IMyReflectorLight>();List<IMyTerminalBlock>Ψ=new List<IMyTerminalBlock>();List<љ>Π=new List<љ>();List<ђ>Ξ=new List<ђ>();bool Ν=false;
Dictionary<IMyTerminalBlock,string>Μ=new Dictionary<IMyTerminalBlock,string>();bool Λ(IMyTerminalBlock ɦ){try{if(!Me.
IsSameConstructAs(ɦ))return false;string Κ=ɦ.GetOwnerFactionTag();if(Κ!=Ε&&Κ!=""){Echo("!"+Κ+": "+ɦ.CustomName);ͳ++;return false;}if(ɦ.
CustomName.Contains(ʮ))return false;if(!Ν&&ʕ&&!ɦ.CustomName.Contains(ɽ))return false;if(ɦ.CustomName.Contains(ʫ))Ψ.Add(ɦ);string Ο
=ɦ.BlockDefinition.ToString();if(Ο=="MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Ν)Μ.Add(ɦ,"Refill Station");
return false;}if(Ο.Contains("MedicalRoom/")){if(ˮ)ɦ.CustomData=Γ;else ɦ.CustomData=Δ;if(!ɦ.CustomName.Contains(ʮ))ɦ.
ApplyAction("OnOff_On");if(Ν)Μ.Add(ɦ,"Medical Room");return false;}if(Ο.Contains("SurvivalKit/")){if(ˮ)ɦ.CustomData=Γ;else ɦ.
CustomData=Δ;if(!ɦ.CustomName.Contains(ʮ))ɦ.ApplyAction("OnOff_On");if(Ν)Μ.Add(ɦ,"Survival Kit");return false;}var Ι=ɦ as
IMyTextPanel;if(Ι!=null){Ω.Add(Ι);if(Ν)Μ.Add(ɦ,"LCD");if(Ι.CustomName.Contains(ʭ)){б Ϊ=new б();Ϊ.ȹ=Ι;Χ.Add(Ƀ(Ϊ));}else if(!ɾ&&Ι.
CustomName.Contains(ʬ))ι.Add(Ι);return false;}if(Ο=="MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɫ(ɦ,"Flak"
,3);if(Ο=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɫ(ɦ,"OPA",3);if(Ο==
"MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɫ(ɦ,"Voltaire",3);if(Ο.Contains("Nariman Dynamics PDC"))return ɫ(ɦ,"Nari",4);if(Ο.Contains(
"Redfields Ballistics PDC"))return ɫ(ɦ,"Red",4);if(Ο=="MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return ɩ(ɦ,"Apollo");if(Ο==
"MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɩ(ɦ,"Tycho");if(Ο=="MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return ɩ(ɦ,"Zeus");if(Ο==
"MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɩ(ɦ,"Tycho");if(Ο.Contains("Ares_Class"))return ɩ(ɦ,"Ares");if(Ο.Contains("Artemis_Torpedo_Tube"))return ɩ(ɦ,
"Artemis");if(Ο=="MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return ɧ(ɦ,"Dawson",11);if(Ο==
"MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return ɧ(ɦ,"Stiletto",12);if(Ο=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return ɧ(ɦ,"Roci",13);if
(Ο=="MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return ɧ(ɦ,"Foehammer",14);if(Ο==
"MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return ɧ(ɦ,"Farren",15);if(Ο.Contains("Zakosetara"))return ɧ(ɦ,"Zako",10);if(Ο.Contains("Kess Hashari Cannon"))return ɧ
(ɦ,"Kess",16);if(Ο.Contains("Coilgun"))return ɧ(ɦ,"Coilgun",13);if(Ο.Contains("Glapion"))return ɧ(ɦ,"Glapion",3);var κ=ɦ
as IMyThrust;if(κ!=null){if(Ο.ToUpper().Contains("RCS")){ϋ.Add(κ);if(Ν)Μ.Add(ɦ,"RCS");}else if(Ο.Contains("Hydro")){ϊ.Add(
κ);if(Ν)Μ.Add(ɦ,"Chem");}else if(Ο.Contains("Atmospheric")){ω.Add(κ);if(Ν)Μ.Add(ɦ,"Atmo");}else{ό.Add(κ);if(Ν){string ɪ=
"";if(ʡ){try{ɪ=ɦ.DefinitionDisplayNameText.Split('"')[1];ɪ=ʣ+ɪ[0].ToString().ToUpper()+ɪ.Substring(1).ToLower();}catch{if(
ɺ)Echo("Failed to get drive type from "+ɦ.DefinitionDisplayNameText);}}Μ.Add(ɦ,"Epstein"+ɪ);}}return false;}var θ=ɦ as
IMyCargoContainer;if(θ!=null){string η=Ο.Split('/')[1];if(η.Contains("Container")||η.Contains("Cargo")){ο.Add(θ);ϡ(ɦ);if(Ν){double ζ=ɦ.
GetInventory().MaxVolume.RawValue;double ε=Math.Round(ζ/1265625024,1);if(ε==0)ε=0.1;Μ.Add(ɦ,"Cargo ["+ε+"]");}return false;}}var δ=ɦ
as IMyGyro;if(δ!=null){Ϙ.Add(δ);if(Ν)Μ.Add(ɦ,"Gyroscope");return false;}var γ=ɦ as IMyBatteryBlock;if(γ!=null){ρ.Add(γ);if
(Ν)Μ.Add(ɦ,"Power"+ʣ+"Battery");return false;}var β=ɦ as IMyReflectorLight;if(β!=null){Ρ.Add(β);if(Ν)Μ.Add(ɦ,"Spotlight")
;return false;}var α=ɦ as IMyLightingBlock;if(α!=null){if(ɦ.CustomName.ToUpper().Contains("INTERIOR")||Ο.Contains(
"Kitchen")||Ο.Contains("Aquarium")){Υ.Add(α);if(Ν)Μ.Add(ɦ,"Light"+ʣ+"Interior");}else if(ɦ.CustomName.Contains(ʧ)){if(ɦ.
CustomName.ToUpper().Contains("STARBOARD")){Σ.Add(α);if(Ν)Μ.Add(ɦ,"Light"+ʣ+"Nav"+ʣ+"Starboard");}else{Τ.Add(α);if(Ν)Μ.Add(ɦ,
"Light"+ʣ+"Nav"+ʣ+"Port");}}else{Φ.Add(α);if(Ν)Μ.Add(ɦ,"Light"+ʣ+"Exterior");}return false;}var ΰ=ɦ as IMyGasTank;if(ΰ!=null){
if(Ο.Contains("Hydro")){ϕ.Add(ΰ);if(Ν)Μ.Add(ɦ,"Tank"+ʣ+"Hydrogen");}else{ϔ.Add(ΰ);if(Ν)Μ.Add(ɦ,"Tank"+ʣ+"Oxygen");}return
false;}var ί=ɦ as IMyReactor;if(ί!=null){ϗ.Add(ί);ϡ(ɦ,0);if(Ν){string ή="Lg";if(Ο.Contains("SmallGenerator"))ή="Sm";else if(Ο
.Contains("MCRN"))ή="MCRN";Μ.Add(ɦ,"Power"+ʣ+"Reactor"+ʣ+ή);}return false;}var έ=ɦ as IMyShipController;if(έ!=null){ν.Add
(έ);if(σ==null&&ɦ.CustomName.Contains("Nav"))σ=έ;if(έ.HasInventory)ϡ(ɦ);if(Ν&&Ο.Contains("Cockpit/")){if(Ο.Contains(
"StandingCockpit")||Ο.Contains("Console")){Μ.Add(ɦ,"Console");return false;}else if(Ο.Contains("Cockpit")){Μ.Add(ɦ,"Cockpit");return
false;}}}var ά=ɦ as IMyDoor;if(ά!=null){љ Ϋ=new љ();Ϋ.ȹ=ά;if(ɦ.CustomName.Contains(ʦ)){try{string ɡ=ɦ.CustomName.Split(ʣ)[3];
Ϋ.і=true;bool ɠ=false;foreach(ђ ɟ in Ξ){if(ɡ==ɟ.є){ɟ.Ң.Add(Ϋ);ɠ=true;break;}}if(!ɠ){ђ ɞ=new ђ();ɞ.є=ɡ;ɞ.Ң.Add(Ϋ);Ξ.Add(ɞ)
;}}catch{if(ɺ)Echo("Error with airlock door name "+ɦ.CustomName);Π.Add(Ϋ);}}else{Π.Add(Ϋ);}if(Ν)Μ.Add(ɦ,"Door");return
false;}var ɢ=ɦ as IMyAirVent;if(ɢ!=null){ϓ.Add(ɢ);if(ɦ.CustomName.Contains(ʦ)){try{string ɡ=ɦ.CustomName.Split(ʣ)[3];bool ɠ=
false;foreach(ђ ɟ in Ξ){if(ɡ==ɟ.є){ɟ.ҡ.Add(ɢ);ɠ=true;break;}}if(!ɠ){ђ ɞ=new ђ();ɞ.є=ɡ;ɞ.ҡ.Add(ɢ);Ξ.Add(ɞ);}}catch{if(ɺ)Echo(
"Error with airlock vent name "+ɦ.CustomName);}}if(Ν)Μ.Add(ɦ,"Vent");return false;}var ɝ=ɦ as IMyCameraBlock;if(ɝ!=null){π.Add(ɝ);if(Ν)Μ.Add(ɦ,"Camera"
);return false;}var ɣ=ɦ as IMyShipConnector;if(ɣ!=null){ξ.Add(ɣ);ϡ(ɦ);if(Ν){string ɜ="";if(Ο.Contains("Passageway"))ɜ=ʣ+
"Passageway";Μ.Add(ɦ,"Connector"+ɜ);}return false;}var ɚ=ɦ as IMyAirtightHangarDoor;if(ɚ!=null){μ.Add(ɚ);if(Ν)Μ.Add(ɦ,"Door"+ʣ+
"Hangar");return false;}if(Ο.Contains("Lidar")){var ə=ɦ as IMyConveyorSorter;if(ə!=null){ϑ.Add(ə);if(Ν)Μ.Add(ɦ,"LiDAR");return
false;}}if(Ο=="MyObjectBuilder_OxygenGenerator/Extractor"){φ.Add(ɦ);if(Ν)Μ.Add(ɦ,"Extractor");return false;}if(Ο==
"MyObjectBuilder_OxygenGenerator/ExtractorSmall"){χ.Add(ɦ);if(Ν)Μ.Add(ɦ,"Extractor");return false;}var ɘ=ɦ as IMyRadioAntenna;if(ɘ!=null){ς.Add(ɘ);if(Ν)Μ.Add(ɦ,
"Antenna");return false;}var ɗ=ɦ as IMyProgrammableBlock;if(ɗ!=null){if(Ν)Μ.Add(ɦ,"PB Server");if(ɗ==Me)return false;try{if(ɦ.
CustomData.Contains("Sigma_Draconis_Expanse_Server "))ψ.Add(ɗ);else if(ɦ.CustomData.Contains("NavConfig"))λ.Add(ɗ);return false;}
catch{}}var ɖ=ɦ as IMyProjector;if(ɖ!=null){ϙ.Add(ɖ);if(Ν)Μ.Add(ɦ,"Projectors");return false;}var ɕ=ɦ as IMySensorBlock;if(ɕ
!=null){ϖ.Add(ɕ);if(Ν)Μ.Add(ɦ,"Sensor");return false;}var ɛ=ɦ as IMyCollector;if(ɛ!=null){ϡ(ɦ);if(Ν)Μ.Add(ɦ,"Collector");
return false;}if(Ο.Contains("Welder")){ϒ.Add(ɦ);if(Ν)Μ.Add(ɦ,"Tool"+ʣ+"Welder");return false;}if(Ν){if(Ο.Contains(
"LandingGear/")){if(Ο.Contains("Clamp"))Μ.Add(ɦ,"Clamp");else if(Ο.Contains("Magnetic"))Μ.Add(ɦ,"Mag Lock");else Μ.Add(ɦ,"Gear");
return false;}if(Ο.Contains("Drill")){Μ.Add(ɦ,"Tool"+ʣ+"Drill");return false;}if(Ο.Contains("Grinder")){Μ.Add(ɦ,"Tool"+ʣ+
"Grinder");return false;}if(Ο.Contains("Solar")){Μ.Add(ɦ,"Solar");return false;}if(Ο.Contains("ButtonPanel")){Μ.Add(ɦ,
"Button Panel");return false;}var ɔ=ɦ as IMyConveyorSorter;if(ɔ!=null){Μ.Add(ɦ,"Sorter");return false;}var ɥ=ɦ as IMyMotorSuspension;
if(ɥ!=null){Μ.Add(ɦ,"Suspension");return false;}var ɰ=ɦ as IMyGravityGenerator;if(ɰ!=null){Μ.Add(ɦ,"Grav Gen");return
false;}var ɯ=ɦ as IMyTimerBlock;if(ɯ!=null){Μ.Add(ɦ,"Timer");return false;}var ɮ=ɦ as IMyGasGenerator;if(ɮ!=null){Μ.Add(ɦ,
"H2 Engine");return false;}var ɭ=ɦ as IMyBeacon;if(ɭ!=null){Μ.Add(ɦ,"Beacon");return false;}Μ.Add(ɦ,ɦ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ɺ){Echo("Failed to sort "+ɦ.CustomName+"\nAdded "+Μ.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɬ(){σ=null;ς.Clear();ρ.Clear();π.Clear();ο.Clear();ξ.Clear();ν.Clear();Π.Clear();Ξ.Clear();μ.Clear();φ.
Clear();χ.Clear();Ϙ.Clear();ϙ.Clear();ϗ.Clear();ϖ.Clear();ϕ.Clear();ϔ.Clear();ϓ.Clear();ϒ.Clear();ϑ.Clear();ϐ.Clear();Ϗ.Clear
();ώ.Clear();ύ.Clear();ό.Clear();ϋ.Clear();ϊ.Clear();ω.Clear();ψ.Clear();λ.Clear();Ω.Clear();Χ.Clear();ι.Clear();Φ.Clear(
);Υ.Clear();Τ.Clear();Σ.Clear();Ρ.Clear();Ψ.Clear();foreach(var Ō in Ϣ)Ō.ϼ.Clear();if(Ν)Μ.Clear();}bool ɫ(
IMyTerminalBlock ɦ,string ɨ,int ɓ){if(ɦ.CustomName.Contains(ʪ))Ϗ.Add(ɦ);else ϐ.Add(ɦ);ϡ(ɦ,ɓ);if(Ν){string ɪ="";if(ʢ)ɪ=ʣ+ɨ;Μ.Add(ɦ,"PDC"+
ɪ);}return false;}bool ɩ(IMyTerminalBlock ɦ,string ɨ){ύ.Add(ɦ);if(Ν){string ɑ="";if(ʢ)ɑ=ʣ+ɨ;Μ.Add(ɦ,"Torpedo"+ɑ);}return
false;}bool ɧ(IMyTerminalBlock ɦ,string ɨ,int ɓ){ώ.Add(ɦ);ϡ(ɦ,ɓ);if(Ν){string ɑ="";if(ʢ)ɑ=ʣ+ɨ;Μ.Add(ɦ,"Railgun"+ɑ);}return
false;}б Ƀ(б ħ,string ɂ=""){bool Ɂ=ɂ=="",ɀ=!Ɂ;string ȿ=ħ.ȹ.CustomData,Ʉ="RSM.LCD";string[]Ⱦ=null;MyIni Ƚ=new MyIni();
MyIniParseResult ƍ;if(!Ɂ)ɀ=true;else{if(ȿ.Substring(0,12)=="Show Header="){try{Ⱦ=ȿ.Split('\n');foreach(string ȼ in Ⱦ){if(ȼ.Contains(
"hud")){if(ȼ.Contains("lcd")){ɂ=ȼ;break;}}else if(ȼ.Contains("=")){string[]Ȼ=ȼ.Split('=');if(Ȼ[0]=="Show Tanks & Batteries")ħ
.и=bool.Parse(Ȼ[1]);else if(Ȼ[0]=="Show header"||Ȼ[0]=="Show Header")ħ.а=bool.Parse(Ȼ[1]);else if(Ȼ[0]==
"Show Header Overlay")ħ.Я=bool.Parse(Ȼ[1]);else if(Ȼ[0]=="Show Warnings")ħ.Ю=bool.Parse(Ȼ[1]);else if(Ȼ[0]=="Show Inventory")ħ.й=bool.Parse(Ȼ
[1]);else if(Ȼ[0]=="Show Thrust")ħ.ш=bool.Parse(Ȼ[1]);else if(Ȼ[0]=="Show Subsystem Integrity")ħ.щ=bool.Parse(Ȼ[1]);else
if(Ȼ[0]=="Show Advanced Thrust")ħ.ч=bool.Parse(Ȼ[1]);}}}catch(Exception ex){if(ɺ)Echo("Failed to parse legacy config.\n"+
ex.Message);ɀ=true;}}else if(!Ƚ.TryParse(ȿ,out ƍ)){ɀ=true;}else{ħ.а=Ƚ.Get(Ʉ,"ShowHeader").ToBoolean(ħ.а);ħ.Я=Ƚ.Get(Ʉ,
"ShowHeaderOverlay").ToBoolean(ħ.Я);ħ.Ю=Ƚ.Get(Ʉ,"ShowWarnings").ToBoolean(ħ.Ю);ħ.и=Ƚ.Get(Ʉ,"ShowPowerAndTanks").ToBoolean(ħ.и);ħ.й=Ƚ.Get(Ʉ,
"ShowInventory").ToBoolean(ħ.й);ħ.ш=Ƚ.Get(Ʉ,"ShowThrust").ToBoolean(ħ.ш);ħ.щ=Ƚ.Get(Ʉ,"ShowIntegrity").ToBoolean(ħ.щ);ħ.ч=Ƚ.Get(Ʉ,
"ShowAdvancedThrust").ToBoolean(ħ.ч);}}if(ħ.а&&ħ.Я){ħ.а=false;ɀ=true;}if(ɀ){if(Ⱦ==null)Ⱦ=ȿ.Split('\n');Ƚ.Set(Ʉ,"ShowHeader",ħ.а);Ƚ.Set(Ʉ,
"ShowHeaderOverlay",ħ.Я);Ƚ.Set(Ʉ,"ShowWarnings",ħ.Ю);Ƚ.Set(Ʉ,"ShowPowerAndTanks",ħ.и);Ƚ.Set(Ʉ,"ShowInventory",ħ.й);Ƚ.Set(Ʉ,"ShowThrust",ħ.ш
);Ƚ.Set(Ʉ,"ShowIntegrity",ħ.щ);Ƚ.Set(Ʉ,"ShowAdvancedThrust",ħ.ч);Ƚ.Set(Ʉ,"Hud",ɂ);ħ.ȹ.CustomData=Ƚ.ToString();if(Ɂ)н.Add(
new ц("LCD CONFIG ERROR!!","Failed to parse LCD config for "+ħ.ȹ.CustomName+"!\nLCD config was reset!",3));}return ħ;}void
Ⱥ(IMyTerminalBlock ȹ,bool ȧ){ȹ.GetActionWithName("ToolCore_Shoot_Action").Apply(ȹ);(ȹ as IMyConveyorSorter).
GetActionWithName("ToolCore_Shoot_Action").Apply(ȹ);}void ȸ(){List<IMyTerminalBlock>Ɇ=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(Ɇ);string ɒ="";foreach(IMyTerminalBlock ɐ in Ɇ){ɒ+=ɐ.BlockDefinition+"\n";}if(ς.Count>0&&ς[0]!=null){
ς[0].CustomData=ɒ;}}void ɏ(string Ƞ){IMyTerminalBlock ȹ=GridTerminalSystem.GetBlockWithName(Ƞ);List<ITerminalAction>Ɏ=new
List<ITerminalAction>();ȹ.GetActions(Ɏ);List<ITerminalProperty>ɍ=new List<ITerminalProperty>();ȹ.GetProperties(ɍ);string Ɍ=ȹ
.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction ɋ in Ɏ){Ɍ+=ɋ.Id+" "+ɋ.Name+"\n";}Ɍ+="\n\n**Properties**\n\n";
foreach(ITerminalProperty Ɋ in ɍ){Ɍ+=Ɋ.Id+" "+Ɋ.TypeName+"\n";}if(ς.Count>0&&ς[0]!=null)ς[0].CustomData=Ɍ;ȹ.CustomData=Ɍ;}void
ɉ(IMyTerminalBlock Ơ){bool ɇ=Ơ.GetValue<bool>("WC_Repel");if(!ɇ)Ơ.ApplyAction("WC_RepelMode");}void Ɉ(IMyTerminalBlock Ơ)
{bool ɇ=Ơ.GetValue<bool>("WC_Repel");if(ɇ)Ơ.ApplyAction("WC_RepelMode");}void Ʌ(IMyTerminalBlock Ơ){try{if(Ǵ.Ƒ(Ơ,0)==
VRageMath.Matrix.Zero)return;Ơ.SetValue<Int64>("WC_Shoot Mode",3);if(ɺ)Echo("Shoot mode = "+Ơ.GetValue<Int64>("WC_Shoot Mode"));}
catch{Echo("Failed to set fire mode to manual on "+Ơ.CustomName);}}void ɱ(IMyTerminalBlock Ơ){try{if(Ǵ.Ƒ(Ơ,0)==VRageMath.
Matrix.Zero)return;Ơ.SetValue<Int64>("WC_Shoot Mode",0);if(ɺ)Echo("Shoot mode = "+Ơ.GetValue<Int64>("WC_Shoot Mode"));}catch{
Echo("Failed to set fire mode to auto on "+Ơ.CustomName);}}void ʝ(){if(σ!=null){try{Ά=σ.GetShipSpeed();Η=σ.CalculateShipMass
().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo(exxie.Message);}}}double ʜ=0;double
ʛ=0;double ʚ=0;void ʙ(){ʛ=0;foreach(IMyCargoContainer ʗ in ο){if(ʗ!=null&&ʗ.IsFunctional){ʛ+=ʗ.GetInventory().MaxVolume.
RawValue;}}ʚ=Math.Round(100*(ʛ/ʜ));}void ʘ(){ʜ=0;foreach(IMyCargoContainer ʗ in ο){if(ʗ!=null)ʜ+=ʗ.GetInventory().MaxVolume.
RawValue;}}MyIni ʖ=new MyIni();bool ʕ=false;bool ʔ=true;bool ʓ=true;bool ʒ=true;bool ʑ=true;bool ʐ=true;bool ʞ=false;string ʟ=""
;bool ʰ=true;int ʱ=3;int ʯ=6;string ʮ="[I]";string ʭ="[RSM]";string ʬ="[CS]";string ʫ="Autorepair";string ʪ="Repel";
string ʩ="Min";string ʨ="Docking";string ʧ="Nav";string ʦ="Airlock";string ʥ="[EFC]";string ʤ="[NavOS]";char ʣ='.';bool ʢ=true
;bool ʡ=true;List<string>ʠ=new List<string>();bool ʏ=false;bool ɾ=false;bool ʍ=true;List<double>ɼ=new List<double>();bool
ɻ=false;bool ɺ=true;bool ɹ=false;int ɸ=0;int ɷ=100;string ɽ="";bool ɶ(){string ȿ=Me.CustomData;string Ʉ="";bool ɴ=true;
MyIniParseResult ƍ;if(!ʖ.TryParse(ȿ,out ƍ)){string[]ɳ=ȿ.Split('\n');if(ɳ[1]=="Reedit Ship Management"){Echo("Legacy config detected...")
;Ѥ(ȿ);return false;}else{Echo("Could not parse custom data!\n"+ƍ.ToString());return false;}}try{Ʉ="RSM.Main";Echo(Ʉ);ʕ=ʖ.
Get(Ʉ,"RequireShipName").ToBoolean(ʕ);ʔ=ʖ.Get(Ʉ,"EnableAutoload").ToBoolean(ʔ);ʓ=ʖ.Get(Ʉ,"AutoloadReactors").ToBoolean(ʓ);ʒ
=ʖ.Get(Ʉ,"AutoConfigWeapons").ToBoolean(ʒ);ʑ=ʖ.Get(Ʉ,"SetTurretFireMode").ToBoolean(ʑ);ʐ=ʖ.Get(Ʉ,"ManageBatteryDischarge"
).ToBoolean(ʐ);Ʉ="RSM.Spawns";Echo(Ʉ);ʞ=ʖ.Get(Ʉ,"PrivateSpawns").ToBoolean(ʞ);ʟ=ʖ.Get(Ʉ,"FriendlyTags").ToString(ʟ);Ʉ=
"RSM.Doors";Echo(Ʉ);ʰ=ʖ.Get(Ʉ,"EnableDoorManagement").ToBoolean(ʰ);ʱ=ʖ.Get(Ʉ,"DoorCloseTimer").ToInt32(ʱ);ʱ=ʖ.Get(Ʉ,
"AirlockDoorDisableTimer").ToInt32(ʱ);Ʉ="RSM.Keywords";Echo(Ʉ);ʮ=ʖ.Get(Ʉ,"Ignore").ToString(ʮ);ʭ=ʖ.Get(Ʉ,"RsmLcds").ToString(ʭ);ʬ=ʖ.Get(Ʉ,
"ColourSyncLcds").ToString(ʬ);ʫ=ʖ.Get(Ʉ,"AuxiliaryBlocks").ToString(ʫ);ʪ=ʖ.Get(Ʉ,"DefensivePdcs").ToString(ʪ);ʩ=ʖ.Get(Ʉ,
"MinimumThrusters").ToString(ʩ);ʨ=ʖ.Get(Ʉ,"DockingThrusters").ToString(ʨ);ʧ=ʖ.Get(Ʉ,"NavLights").ToString(ʧ);ʦ=ʖ.Get(Ʉ,"Airlock").ToString
(ʦ);Ʉ="RSM.InitNaming";Echo(Ʉ);ʣ=ʖ.Get(Ʉ,"Ignore").ToChar(ʣ);ʢ=ʖ.Get(Ʉ,"NameWeaponTypes").ToBoolean(ʢ);ʡ=ʖ.Get(Ʉ,
"NameDriveTypes").ToBoolean(ʡ);string ɲ=ʖ.Get(Ʉ,"BlocksToNumber").ToString("");string[]ɵ=ɲ.Split(',');ʠ.Clear();foreach(string Ƞ in ɵ)if
(Ƞ!="")ʠ.Add(Ƞ);Ʉ="RSM.Misc";Echo(Ʉ);ʏ=ʖ.Get(Ʉ,"DisableLightingControl").ToBoolean(ʏ);ɾ=ʖ.Get(Ʉ,"DisableLcdColourControl"
).ToBoolean(ɾ);ʍ=ʖ.Get(Ʉ,"ShowBasicTelemetry").ToBoolean(ʍ);string ɿ=ʖ.Get(Ʉ,"DecelerationPercentages").ToString("");
string[]ʎ=ɿ.Split(',');if(ʎ.Length>1){ɼ.Clear();foreach(string ʌ in ʎ){ɼ.Add(double.Parse(ʌ)/100);}}ɻ=ʖ.Get(Ʉ,
"ShowThrustInMetric").ToBoolean(ɻ);Ʉ="RSM.Debug";Echo(Ʉ);ɺ=ʖ.Get(Ʉ,"VerboseDebugging").ToBoolean(ɺ);ɹ=ʖ.Get(Ʉ,"RuntimeProfiling").ToBoolean(
ɹ);ɷ=ʖ.Get(Ʉ,"BlockRefreshFreq").ToInt32(ɷ);ɸ=ʖ.Get(Ʉ,"StallCount").ToInt32(ɸ);Ʉ="RSM.System";Echo(Ʉ);ɽ=ʖ.Get(Ʉ,
"ShipName").ToString(ɽ);Ʉ="RSM.InitItems";Echo(Ʉ);foreach(Ō ʋ in Ϣ){ʋ.Ͽ=ʖ.Get(Ʉ,ʋ.Ϻ.SubtypeId).ToInt32(ʋ.Ͽ);}Ʉ=
"RSM.InitSubSystems";Echo(Ʉ);N=ʖ.Get(Ʉ,"Reactors").ToDouble(N);N=ʖ.Get(Ʉ,"Batteries").ToDouble(N);w=ʖ.Get(Ʉ,"Pdcs").ToInt32(w);ȅ=ʖ.Get(Ʉ,
"TorpLaunchers").ToInt32(ȅ);Q=ʖ.Get(Ʉ,"KineticWeapons").ToInt32(Q);Û=ʖ.Get(Ʉ,"H2Storage").ToDouble(Û);Ñ=ʖ.Get(Ʉ,"O2Storage").ToDouble(Ñ
);ç=ʖ.Get(Ʉ,"MainThrust").ToSingle(ç);ǹ=ʖ.Get(Ʉ,"RCSThrust").ToSingle(ǹ);Ҕ=ʖ.Get(Ʉ,"Gyros").ToDouble(Ҕ);ʜ=ʖ.Get(Ʉ,
"CargoStorage").ToDouble(ʜ);Ɵ=ʖ.Get(Ʉ,"Welders").ToInt32(Ɵ);}catch(Exception ex){Ѡ(ex,"Failed to parse section\n"+Ʉ);}Echo(
"Parsing stances...");Dictionary<string,Y>ʊ=new Dictionary<string,Y>();List<string>ʉ=new List<string>();ʖ.GetSections(ʉ);foreach(string ʈ in
ʉ){if(ʈ.Contains("RSM.Stance.")){string ʇ=ʈ.Substring(11);Echo(ʇ);Y Ü=new Y();string ʆ,ʅ="";string[]ʄ;int ʃ=33,ʂ=144,ɦ=
255,Ě=255;bool ʁ=false;Y ɤ=null;ʅ="Inherits";if(ʖ.ContainsKey(ʈ,ʅ)){ʁ=true;try{ɤ=ʊ[ʖ.Get(ʈ,ʅ).ToString()];Echo("Inherits "+
ʖ.Get(ʈ,ʅ).ToString());}catch(Exception ex){Ѡ(ex,"Failed to find inheritee for\n"+ʈ+
"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(ʁ)Echo(ɤ.W.ToString());ʅ="Torps";if(ʖ.ContainsKey(ʈ,ʅ)){Ü.W=(ƚ)Enum.Parse(typeof(ƚ),ʖ.Get(ʈ,ʅ).ToString());
Echo("1");}else if(ʁ){Ü.W=ɤ.W;Echo("2");}else{Ü.W=î;Echo("3");}ʅ="Pdcs";if(ʖ.ContainsKey(ʈ,ʅ))Ü.V=(ǋ)Enum.Parse(typeof(ǋ),ʖ.
Get(ʈ,ʅ).ToString());else if(ʁ)Ü.V=ɤ.V;else Ü.V=þ;ʅ="Kinetics";if(ʖ.ContainsKey(ʈ,ʅ))Ü.U=(Ǌ)Enum.Parse(typeof(Ǌ),ʖ.Get(ʈ,ʅ)
.ToString());else if(ʁ)Ü.U=ɤ.U;else Ü.U=Ā;ʅ="MainThrust";if(ʖ.ContainsKey(ʈ,ʅ))Ü.S=(ǌ)Enum.Parse(typeof(ǌ),ʖ.Get(ʈ,ʅ).
ToString());else if(ʁ)Ü.S=ɤ.S;else Ü.S=đ;ʅ="ManeuveringThrust";if(ʖ.ContainsKey(ʈ,ʅ))Ü.P=(ǎ)Enum.Parse(typeof(ǎ),ʖ.Get(ʈ,ʅ).
ToString());else if(ʁ)Ü.P=ɤ.P;else Ü.P=Ē;ʅ="Spotlights";if(ʖ.ContainsKey(ʈ,ʅ))Ü.R=(Ǎ)Enum.Parse(typeof(Ǎ),ʖ.Get(ʈ,ʅ).ToString())
;else if(ʁ)Ü.R=ɤ.R;else Ü.R=Đ;ʅ="ExteriorLights";if(ʖ.ContainsKey(ʈ,ʅ))Ü.Î=(ƶ)Enum.Parse(typeof(ƶ),ʖ.Get(ʈ,ʅ).ToString())
;else if(ʁ)Ü.Î=ɤ.Î;else Ü.Î=ď;ʅ="ExteriorLightColour";if(ʖ.ContainsKey(ʈ,ʅ)){ʆ=ʖ.Get(ʈ,ʅ).ToString();ʄ=ʆ.Split(',');ʃ=int
.Parse(ʄ[0]);ʂ=int.Parse(ʄ[1]);ɦ=int.Parse(ʄ[2]);Ě=int.Parse(ʄ[3]);Ü.ÿ=new Color(ʃ,ʂ,ɦ,Ě);}else if(ʁ)Ü.ÿ=ɤ.ÿ;else Ü.ÿ=Ď;ʅ
="InteriorLights";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ý=(ƶ)Enum.Parse(typeof(ƶ),ʖ.Get(ʈ,ʅ).ToString());else if(ʁ)Ü.ý=ɤ.ý;else Ü.ý=č;ʅ
="InteriorLightColour";if(ʖ.ContainsKey(ʈ,ʅ)){ʆ=ʖ.Get(ʈ,ʅ).ToString();ʄ=ʆ.Split(',');ʃ=int.Parse(ʄ[0]);ʂ=int.Parse(ʄ[1]);
ɦ=int.Parse(ʄ[2]);Ě=int.Parse(ʄ[3]);Ü.ü=new Color(ʃ,ʂ,ɦ,Ě);}else if(ʁ)Ü.ü=ɤ.ü;else Ü.ü=Č;ʅ="NavLights";if(ʖ.ContainsKey(ʈ
,ʅ))Ü.û=(ƶ)Enum.Parse(typeof(ƶ),ʖ.Get(ʈ,ʅ).ToString());else if(ʁ)Ü.û=ɤ.û;else Ü.û=ċ;ʅ="LcdTextColour";if(ʖ.ContainsKey(ʈ,
ʅ)){ʆ=ʖ.Get(ʈ,ʅ).ToString();ʄ=ʆ.Split(',');ʃ=int.Parse(ʄ[0]);ʂ=int.Parse(ʄ[1]);ɦ=int.Parse(ʄ[2]);Ě=int.Parse(ʄ[3]);Ü.ú=
new Color(ʃ,ʂ,ɦ,Ě);}else if(ʁ)Ü.ú=ɤ.ú;else Ü.ú=Ċ;ʅ="TanksAndBatteries";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ù=(ǉ)Enum.Parse(typeof(ǉ),ʖ.
Get(ʈ,ʅ).ToString());else if(ʁ)Ü.ù=ɤ.ù;else Ü.ù=ĉ;ʅ="NavOsEfcBurnPercentage";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ø=ʖ.Get(ʈ,
"NavOsEfcBurnPercentage").ToInt32(Ĉ);else if(ʁ)Ü.ø=ɤ.ø;else Ü.ø=Ĉ;ʅ="EfcBoost";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ö=(ƚ)Enum.Parse(typeof(ƚ),ʖ.Get(ʈ,ʅ).
ToString());else if(ʁ)Ü.ö=ɤ.ö;else Ü.ö=ć;ʅ="NavOsAbortEfcOff";if(ʖ.ContainsKey(ʈ,ʅ))Ü.õ=(ƻ)Enum.Parse(typeof(ƻ),ʖ.Get(ʈ,ʅ).
ToString());else if(ʁ)Ü.õ=ɤ.õ;else Ü.õ=Ć;ʅ="NavOsAbortEfcOff";if(ʖ.ContainsKey(ʈ,ʅ))Ü.õ=(ƻ)Enum.Parse(typeof(ƻ),ʖ.Get(ʈ,ʅ).
ToString());else if(ʁ)Ü.õ=ɤ.õ;else Ü.õ=Ć;ʅ="AuxMode";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ô=(ƚ)Enum.Parse(typeof(ƚ),ʖ.Get(ʈ,ʅ).ToString());
else if(ʁ)Ü.ô=ɤ.ô;else Ü.ô=ą;ʅ="Extractor";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ó=(ƺ)Enum.Parse(typeof(ƺ),ʖ.Get(ʈ,ʅ).ToString());else if(
ʁ)Ü.ó=ɤ.ó;else Ü.ó=Ą;ʅ="KeepAlives";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ò=(ƚ)Enum.Parse(typeof(ƚ),ʖ.Get(ʈ,ʅ).ToString());else if(ʁ)Ü.
ò=ɤ.ò;else Ü.ò=ă;ʅ="HangarDoors";if(ʖ.ContainsKey(ʈ,ʅ))Ü.ñ=(Ƹ)Enum.Parse(typeof(Ƹ),ʖ.Get(ʈ,ʅ).ToString());else if(ʁ)Ü.ñ=ɤ
.ñ;else Ü.ñ=Ă;ʊ.Add(ʇ,Ü);}catch(Exception ex){Ѡ(ex,"Failed to parse stance\n"+ʇ+"\nproperty\n"+ʅ);}}}if(ʊ.Count<1){Echo(
"Failed to parse any stances!\nStances reset to default!");ɴ=false;}else{Echo("Finished parsing "+ʊ.Count+" stances.");ћ=ʊ;}Ʉ="RSM.Stance";Echo(Ʉ);ð=ʖ.Get(Ʉ,"CurrentStance").
ToString(ð);Y Ϛ;if(!ћ.TryGetValue(ð,out Ϛ)){ð="N/A";ï=null;}else ï=Ϛ;return ɴ;}void ϸ(){ʖ.Clear();string Ʉ,Ƞ;Ʉ="RSM.Main";Ƞ=
"RequireShipName";ʖ.Set(Ʉ,Ƞ,ʕ);ʖ.SetComment(Ʉ,Ƞ,"limit to blocks with the ship name in their name");Ƞ="EnableAutoload";ʖ.Set(Ʉ,Ƞ,ʔ);ʖ.
SetComment(Ʉ,Ƞ,"enable RSM loading & balancing functionality for weapons");Ƞ="AutoloadReactors";ʖ.Set(Ʉ,Ƞ,ʓ);ʖ.SetComment(Ʉ,Ƞ,
"enable loading and balancing for reactors");Ƞ="AutoConfigWeapons";ʖ.Set(Ʉ,Ƞ,ʒ);ʖ.SetComment(Ʉ,Ƞ,"automatically configure weapon on stance set");Ƞ=
"SetTurretFireMode";ʖ.Set(Ʉ,Ƞ,ʑ);ʖ.SetComment(Ʉ,Ƞ,"set turret fire mode based on stance");Ƞ="ManageBatteryDischarge";ʖ.Set(Ʉ,Ƞ,ʐ);ʖ.
SetComment(Ʉ,Ƞ,"set batteries to discharge on active railgun/coilgun target");ʖ.SetSectionComment(Ʉ,Њ+" Reedit Ship Management\n"+
Њ+" Config.ini\n Recompile to apply changes!\n"+Њ);Ʉ="RSM.Spawns";Ƞ="PrivateSpawns";ʖ.Set(Ʉ,Ƞ,ʞ);ʖ.SetComment(Ʉ,Ƞ,
"don't inject faction tag into spawn custom data");Ƞ="FriendlyTags";ʖ.Set(Ʉ,Ƞ,ʟ);ʖ.SetComment(Ʉ,Ƞ,"Comma seperated friendly factions or steam ids");Ʉ="RSM.Doors";Ƞ=
"EnableDoorManagement";ʖ.Set(Ʉ,Ƞ,ʰ);ʖ.SetComment(Ʉ,Ƞ,"enable door management functionality");Ƞ="DoorCloseTimer";ʖ.Set(Ʉ,Ƞ,ʱ);ʖ.SetComment(Ʉ,Ƞ,
"door open timer (x100 ticks)");Ƞ="AirlockDoorDisableTimer";ʖ.Set(Ʉ,Ƞ,ʯ);ʖ.SetComment(Ʉ,Ƞ,"airlock door disable timer (x100 ticks)");Ʉ="RSM.Keywords";
Ƞ="Ignore";ʖ.Set(Ʉ,Ƞ,ʮ);ʖ.SetComment(Ʉ,Ƞ,"to identify blocks which RSM should ignore");Ƞ="RsmLcds";ʖ.Set(Ʉ,Ƞ,ʭ);ʖ.
SetComment(Ʉ,Ƞ,"to identify RSM lcds");Ƞ="ColourSyncLcds";ʖ.Set(Ʉ,Ƞ,ʬ);ʖ.SetComment(Ʉ,Ƞ,"to identify non RSM lcds for colour sync"
);Ƞ="AuxiliaryBlocks";ʖ.Set(Ʉ,Ƞ,ʫ);ʖ.SetComment(Ʉ,Ƞ,"to identify aux blocks");Ƞ="DefensivePdcs";ʖ.Set(Ʉ,Ƞ,ʪ);ʖ.SetComment
(Ʉ,Ƞ,"to identify defensive _normalPdcs");Ƞ="MinimumThrusters";ʖ.Set(Ʉ,Ƞ,ʩ);ʖ.SetComment(Ʉ,Ƞ,
"to identify minimum epsteins");Ƞ="DockingThrusters";ʖ.Set(Ʉ,Ƞ,ʨ);ʖ.SetComment(Ʉ,Ƞ,"to identify docking epsteins");Ƞ="NavLights";ʖ.Set(Ʉ,Ƞ,ʧ);ʖ.
SetComment(Ʉ,Ƞ,"to identify navigational lights");Ƞ="Airlock";ʖ.Set(Ʉ,Ƞ,ʦ);ʖ.SetComment(Ʉ,Ƞ,"to identify airlock doors and vents")
;Ʉ="RSM.InitNaming";Ƞ="NameDelimiter";ʖ.Set(Ʉ,Ƞ,ʣ.ToString());ʖ.SetComment(Ʉ,Ƞ,"single char delimiter for names");Ƞ=
"NameWeaponTypes";ʖ.Set(Ʉ,Ƞ,ʢ);ʖ.SetComment(Ʉ,Ƞ,"append type names to all weapons on init");Ƞ="NameDriveTypes";ʖ.Set(Ʉ,Ƞ,ʡ);ʖ.SetComment(
Ʉ,Ƞ,"append type names to all drives on init");string ѩ="";foreach(string Ѩ in ʠ){if(ѩ!="")ѩ+=",";ѩ+=Ѩ;}Ƞ=
"BlocksToNumber";ʖ.Set(Ʉ,Ƞ,ʡ);ʖ.SetComment(Ʉ,Ƞ,"comma seperated list of block names to be numbered at init");Ʉ="RSM.Misc";Ƞ=
"DisableLightingControl";ʖ.Set(Ʉ,Ƞ,ʏ);ʖ.SetComment(Ʉ,Ƞ,"disable all lighting control");Ƞ="DisableLcdColourControl";ʖ.Set(Ʉ,Ƞ,ɾ);ʖ.SetComment(Ʉ,Ƞ
,"disable text colour control for all lcds");Ƞ="ShowBasicTelemetry";ʖ.Set(Ʉ,Ƞ,ʍ);ʖ.SetComment(Ʉ,Ƞ,
"show basic telemetry data on advanced thrust lcds");string ѧ="";foreach(double į in ɼ){if(ѧ!="")ѧ+=",";ѧ+=(į*100).ToString();}Ƞ="DecelerationPercentages";ʖ.Set(Ʉ,Ƞ,ѧ);ʖ.
SetComment(Ʉ,Ƞ,"thrust percentages to show on advanced thrust lcds");Ƞ="ShowThrustInMetric";ʖ.Set(Ʉ,Ƞ,ɻ);ʖ.SetComment(Ʉ,Ƞ,
"show basic telemetry data on advanced thrust lcds");Ʉ="RSM.Debug";Ƞ="VerboseDebugging";ʖ.Set(Ʉ,Ƞ,ɺ);ʖ.SetComment(Ʉ,Ƞ,"prints more logging info to PB details");Ƞ=
"RuntimeProfiling";ʖ.Set(Ʉ,Ƞ,ɹ);ʖ.SetComment(Ʉ,Ƞ,"prints script runtime profiling info to PB details");Ƞ="BlockRefreshFreq";ʖ.Set(Ʉ,Ƞ,ɷ);ʖ
.SetComment(Ʉ,Ƞ,"ticks x100 between block refreshes");Ƞ="StallCount";ʖ.Set(Ʉ,Ƞ,ɸ);ʖ.SetComment(Ʉ,Ƞ,
"ticks x100 to stall between runs");Ʉ="RSM.Stance";Ƞ="CurrentStance";ʖ.Set(Ʉ,Ƞ,ð);ʖ.SetSectionComment(Ʉ,Њ+" Stances\n Add or remove as required\n"+Њ);
string Ѧ="Red, Green, Blue, Alpha";foreach(var Ѫ in ћ){Ʉ="RSM.Stance."+Ѫ.Key;Y ì=Ѫ.Value;Y ɤ=null;if(ì.X!=""){ɤ=ћ[ì.X];Ƞ=
"Inherits";ʖ.Set(Ʉ,Ƞ,ì.X);ʖ.SetComment(Ʉ,Ƞ,"Use stance of this name as a template for settings");}Ƞ="Torps";if(ɤ!=null&&ì.W==ɤ.W){
if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.W.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƚ)));}Ƞ="Pdcs";if(ɤ!=null&&ì
.V==ɤ.V){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.V.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ǋ)));}Ƞ="Kinetics"
;if(ɤ!=null&&ì.U==ɤ.U){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.U.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(Ǌ)))
;}Ƞ="MainThrust";if(ɤ!=null&&ì.S==ɤ.S){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.S.ToString());ʖ.SetComment(Ʉ
,"MainThrust",ь(typeof(ǌ)));}Ƞ="ManeuveringThrust";if(ɤ!=null&&ì.P==ɤ.P){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(
Ʉ,Ƞ,ì.P.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ǎ)));}Ƞ="Spotlights";if(ɤ!=null&&ì.R==ɤ.R){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ
,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.R.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(Ǎ)));}Ƞ="ExteriorLights";if(ɤ!=null&&ì.Î==ɤ.Î){if(ʖ.
ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.Î.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƶ)));}Ƞ="ExteriorLightColour";if(ɤ!=null&&
ì.ÿ==ɤ.ÿ){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ѓ(ì.ÿ));ʖ.SetComment(Ʉ,Ƞ,Ѧ);}Ƞ="InteriorLights";if(ɤ!=null
&&ì.ý==ɤ.ý){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.ý.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƶ)));}Ƞ=
"InteriorLightColour";if(ɤ!=null&&ì.ü==ɤ.ü){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ѓ(ì.ü));ʖ.SetComment(Ʉ,Ƞ,Ѧ);}Ƞ="NavLights";if
(ɤ!=null&&ì.û==ɤ.û){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.û.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƶ)));}Ƞ
="LcdTextColour";if(ɤ!=null&&ì.ú==ɤ.ú){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ѓ(ì.ú));ʖ.SetComment(Ʉ,Ƞ,Ѧ);}Ƞ
="TanksAndBatteries";if(ɤ!=null&&ì.ù==ɤ.ù){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.ù.ToString());ʖ.
SetComment(Ʉ,Ƞ,ь(typeof(ǉ)));}Ƞ="NavOsEfcBurnPercentage";if(ɤ!=null&&ì.ø==ɤ.ø){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ
,ì.ø.ToString());ʖ.SetComment(Ʉ,Ƞ,"Burn % 0-100, -1 for no change");}Ƞ="EfcBoost";if(ɤ!=null&&ì.ö==ɤ.ö){if(ʖ.ContainsKey(
Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.ö.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƚ)));}Ƞ="NavOsAbortEfcOff";if(ɤ!=null&&ì.õ==
ɤ.õ){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.õ.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƻ)));}Ƞ="AuxMode";if(ɤ
!=null&&ì.ô==ɤ.ô){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.ô.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƚ)));}Ƞ=
"Extractor";if(ɤ!=null&&ì.ó==ɤ.ó){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.ó.ToString());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(ƺ))
);}Ƞ="KeepAlives";if(ɤ!=null&&ì.ò==ɤ.ò){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.ò.ToString());ʖ.SetComment(
Ʉ,Ƞ,ь(typeof(ƚ)));}Ƞ="HangarDoors";if(ɤ!=null&&ì.ñ==ɤ.ñ){if(ʖ.ContainsKey(Ʉ,Ƞ))ʖ.Delete(Ʉ,Ƞ);}else{ʖ.Set(Ʉ,Ƞ,ì.ñ.ToString
());ʖ.SetComment(Ʉ,Ƞ,ь(typeof(Ƹ)));}}Ʉ="RSM.System";Ƞ="ShipName";ʖ.Set(Ʉ,Ƞ,ɽ);ʖ.SetSectionComment(Ʉ,Њ+
" System\n All items below this point are\n set automatically when running init\n"+Њ);Ʉ="RSM.InitItems";foreach(Ō ʋ in Ϣ){Ƞ=ʋ.Ϻ.SubtypeId;ʖ.Set(Ʉ,Ƞ,ʋ.Ͽ);}Ʉ="RSM.InitSubSystems";ʖ.Set(Ʉ,"Reactors",N);ʖ.
Set(Ʉ,"Batteries",N);ʖ.Set(Ʉ,"Pdcs",w);ʖ.Set(Ʉ,"TorpLaunchers",ȅ);ʖ.Set(Ʉ,"KineticWeapons",Q);ʖ.Set(Ʉ,"H2Storage",Û);ʖ.Set(
Ʉ,"O2Storage",Ñ);ʖ.Set(Ʉ,"MainThrust",ç);ʖ.Set(Ʉ,"RCSThrust",ǹ);ʖ.Set(Ʉ,"Gyros",Ҕ);ʖ.Set(Ʉ,"CargoStorage",ʜ);ʖ.Set(Ʉ,
"Welders",Ɵ);Me.CustomData=ʖ.ToString();}void Ѥ(string ȿ){string[]ʉ=ȿ.Split(new string[]{"[Stances]"},StringSplitOptions.None);
string[]ѣ=ʉ[0].Split('\n');string ѥ=ʉ[1];try{for(int ę=1;ę<ѣ.Length;ę++){if(ѣ[ę].Contains("=")){string ѫ=ѣ[ę].Substring(1);
switch(ѣ[(ę-1)]){case"Ship name. Blocks without this name will be ignored":ɽ=ѫ;break;case
"Block name delimiter, used by init. One character only!":ʣ=char.Parse(ѫ.Substring(0,1));break;case"Keyword used to identify RSM _allLcds.":ʭ=ѫ;break;case
"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʫ=ѫ;break;case"Keyword used to identify defence _normalPdcs.":ʪ=ѫ;break
;case"Keyword used to identify minimum epstein drives.":ʩ=ѫ;break;case"Keyword used to identify docking epstein drives.":
ʨ=ѫ;break;case"Keyword to ignore block.":ʮ=ѫ;break;case"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʒ=bool
.Parse(ѫ);break;case"Disable lighting all control.":ʏ=bool.Parse(ѫ);break;case"Disable LCD Text Colour Enforcement.":ɾ=
bool.Parse(ѫ);break;case"Enable Weapon Autoload Functionality.":ʔ=bool.Parse(ѫ);break;case"Number these blocks at init.":ʠ.
Clear();string[]Ѷ=ѫ.Split(',');foreach(string Ѩ in Ѷ){if(Ѩ!="")ʠ.Add(Ѩ);}break;case"Add type names to weapons at init.":ʢ=
bool.Parse(ѫ);break;case"Only set batteries to discharge on active railgun/coilgun target.":ʐ=bool.Parse(ѫ);break;case
"Show basic telemetry.":ʍ=bool.Parse(ѫ);break;case"Show Decel Percentages (comma seperated).":ɼ.Clear();string[]Ѵ=ѫ.Split(',');foreach(string į
in Ѵ){ɼ.Add(double.Parse(į)/100);}break;case"Fusion Fuel count":Ϣ[0].Ͽ=int.Parse(ѫ);break;case"Fuel tank count":Ϣ[1].Ͽ=int
.Parse(ѫ);break;case"Jerry can count":Ϣ[2].Ͽ=int.Parse(ѫ);break;case"40mm PDC Magazine count":Ϣ[3].Ͽ=int.Parse(ѫ);break;
case"40mm Teflon Tungsten PDC Magazine count":Ϣ[4].Ͽ=int.Parse(ѫ);break;case"220mm Torpedo count":case"Torpedo count":Ϣ[5].Ͽ
=int.Parse(ѫ);break;case"220mm MCRN torpedo count":Ϣ[6].Ͽ=int.Parse(ѫ);break;case"220mm UNN torpedo count":Ϣ[7].Ͽ=int.
Parse(ѫ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":Ϣ[8].Ͽ=int.Parse(ѫ);break;case
"Large ramshacke torpedo count":Ϣ[9].Ͽ=int.Parse(ѫ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":Ϣ[10].Ͽ=int.Parse(ѫ);break;
case"Dawson 100mm UNN Railgun rounds count":Ϣ[11].Ͽ=int.Parse(ѫ);break;case"Stiletto 100mm MCRN Railgun rounds count":Ϣ[12].
Ͽ=int.Parse(ѫ);break;case"T-47 80mm Railgun rounds count":Ϣ[13].Ͽ=int.Parse(ѫ);break;case
"Foehammer 120mm MCRN rounds count":Ϣ[14].Ͽ=int.Parse(ѫ);break;case"Farren 120mm UNN Railgun rounds count":Ϣ[15].Ͽ=int.Parse(ѫ);break;case
"Kess 180mm rounds count":Ϣ[16].Ͽ=int.Parse(ѫ);break;case"Steel plate count":Ϣ[17].Ͽ=int.Parse(ѫ);break;case
"Doors open timer (x100 ticks, default 3)":ʱ=int.Parse(ѫ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ʯ=int.Parse(ѫ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":ɸ=int.Parse(ѫ);break;case"Full refresh frequency (x100 ticks, default 50)":ɷ=int.Parse(ѫ);break;case
"Verbose script debugging. Prints more logging info to PB details.":ɺ=bool.Parse(ѫ);break;case"Private spawn (don't inject faction tag into SK custom data).":ʞ=bool.Parse(ѫ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":ʟ=string.Join("\n",ѫ.Split(','));break;case"Current Stance":ð=ѫ;Y Ϛ;if(!ћ.TryGetValue(ð,out Ϛ)){ð="N/A";ï=null;}else ï=
Ϛ;break;case"Reactor Integrity":N=float.Parse(ѫ);break;case"Battery Integrity":È=float.Parse(ѫ);break;case"PDC Integrity"
:w=int.Parse(ѫ);break;case"Torpedo Integrity":ȅ=int.Parse(ѫ);break;case"Railgun Integrity":Q=int.Parse(ѫ);break;case
"H2 Tank Integrity":Û=double.Parse(ѫ);break;case"O2 Tank Integrity":Ñ=double.Parse(ѫ);break;case"Epstein Integrity":ç=float.Parse(ѫ);break;
case"RCS Integrity":ǹ=float.Parse(ѫ);break;case"Gyro Integrity":Ҕ=int.Parse(ѫ);break;case"Cargo Integrity":ʜ=double.Parse(ѫ)
;break;case"Welder Integrity":Ɵ=int.Parse(ѫ);break;}}}}catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);
}try{string[]ѳ=ѥ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(ɺ)Echo("Parsing "+(ѳ.Length-1)+" stances");int
Ѳ=24;Dictionary<string,Y>ʊ=new Dictionary<string,Y>();int[]ѱ=new int[]{0,5,25,50,75,100};for(int ę=1;ę<ѳ.Length;ę++){
string[]Ѱ=ѳ[ę].Split('=');string ʇ="";int[]ѯ=new int[Ѳ];ʇ=Ѱ[0].Split(' ')[0];if(ɺ)Echo("Parsing '"+ʇ+"'");for(int Ѯ=0;Ѯ<ѯ.
Length;Ѯ++){string[]ѭ=Ѱ[(Ѯ+1)].Split('\n');ѯ[Ѯ]=int.Parse(ѭ[0]);}Y Ü=new Y();if(ѯ[0]==0)Ü.W=ƚ.Off;else Ü.W=ƚ.On;if(ѯ[1]==0)Ü.V
=ǋ.Off;else if(ѯ[1]==1)Ü.V=ǋ.MinDefence;else if(ѯ[1]==2)Ü.V=ǋ.AllDefence;else if(ѯ[1]==3)Ü.V=ǋ.Offence;else if(ѯ[1]==4)Ü.
V=ǋ.AllOnOnly;if(ѯ[2]==0)Ü.U=Ǌ.Off;else if(ѯ[2]==1)Ü.U=Ǌ.HoldFire;else if(ѯ[2]==2)Ü.U=Ǌ.OpenFire;if(ѯ[3]==0)Ü.S=ǌ.Off;
else if(ѯ[3]==1)Ü.S=ǌ.On;else if(ѯ[3]==2)Ü.S=ǌ.Minimum;if(ѯ[4]==0)Ü.P=ǎ.Off;else if(ѯ[4]==1)Ü.P=ǎ.On;else if(ѯ[4]==2)Ü.P=ǎ.
ForwardOff;else if(ѯ[4]==3)Ü.P=ǎ.ReverseOff;if(ѯ[5]==0)Ü.R=Ǎ.Off;else if(ѯ[5]==1)Ü.R=Ǎ.On;else if(ѯ[5]==2)Ü.R=Ǎ.OnMax;if(ѯ[6]==0)Ü
.Î=ƶ.Off;else Ü.Î=ƶ.On;Ü.ÿ=new Color(ѯ[7],ѯ[8],ѯ[9],ѯ[10]);if(ѯ[11]==0)Ü.ý=ƶ.Off;else Ü.ý=ƶ.On;Ü.ü=new Color(ѯ[12],ѯ[13],
ѯ[14],ѯ[15]);if(ѯ[16]==0)Ü.ù=ǉ.Auto;else if(ѯ[16]==1)Ü.ù=ǉ.StockpileRecharge;else if(ѯ[16]==2)Ü.ù=ǉ.Discharge;if(ѯ[17]==0
)Ü.ö=ƚ.Off;else Ü.ö=ƚ.On;Ü.ø=ѱ[ѯ[18]];if(ѯ[19]==0)Ü.õ=ƻ.NoChange;else Ü.õ=ƻ.Abort;if(ѯ[20]==0)Ü.ô=ƚ.Off;else Ü.ô=ƚ.On;if(
ѯ[21]==0)Ü.ó=ƺ.Off;else if(ѯ[21]==1)Ü.ó=ƺ.On;else if(ѯ[21]==2)Ü.ó=ƺ.FillWhenLow;else if(ѯ[21]==3)Ü.ó=ƺ.KeepFull;if(ѯ[22]
==0)Ü.ò=ƚ.Off;else Ü.ò=ƚ.On;if(ѯ[23]==0)Ü.ñ=Ƹ.Closed;else if(ѯ[23]==1)Ü.ñ=Ƹ.Open;else Ü.ñ=Ƹ.NoChange;ʊ.Add(ʇ,Ü);}if(ʊ.
Count>=1){if(ɺ)Echo("Finished parsing "+ʊ.Count+" stances.");ћ=ʊ;}else{Echo("Didn't find any stances!");}}catch(Exception ex)
{Echo("Custom Data Error (stances)\n"+ex.Message);}}void Ѭ(){bool ѵ=ɶ();if(!ѵ){њ();ϸ();}if(ï==null){ï=ћ.First().Value;}
string Ѣ="";string ѡ="";if(!ʞ){Ѣ=" ".PadRight(129,' ')+Ε+"\n";ѡ="\n".PadRight(19,'\n');}Δ=Ѣ+ѡ;Γ=Ѣ+string.Join("\n",ʟ.Split(','
))+ѡ;if(ɽ==""){if(ɺ)Echo("No ship name, trying to pull it from PB name...");string ё="Untitled Ship";try{string[]ѐ=Me.
CustomName.Split(ʣ);if(ѐ.Length>1){ɽ=ѐ[0];if(ɺ)Echo(ɽ);}else ɽ=ё;}catch{ɽ=ё;}}}void я(bool ā=true,bool ю=false,bool Έ=false){MyIni
Ƚ=new MyIni();string ȿ=Me.CustomData;MyIniParseResult ƍ;if(!Ƚ.TryParse(ȿ,out ƍ)){н.Add(new ц("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string Ʉ,Ƞ;if(ā){Ʉ="RSM.Stance";Ƞ="CurrentStance";Ƚ.Set(Ʉ,Ƞ,ð);}if(ю){Ʉ="RSM.InitSubSystems";Ƚ.Set(Ʉ,
"Reactors",N);Ƚ.Set(Ʉ,"Batteries",N);Ƚ.Set(Ʉ,"Pdcs",w);Ƚ.Set(Ʉ,"TorpLaunchers",ȅ);Ƚ.Set(Ʉ,"KineticWeapons",Q);Ƚ.Set(Ʉ,"H2Storage",
Û);Ƚ.Set(Ʉ,"O2Storage",Ñ);Ƚ.Set(Ʉ,"MainThrust",ç);Ƚ.Set(Ʉ,"RCSThrust",ǹ);Ƚ.Set(Ʉ,"Gyros",Ҕ);Ƚ.Set(Ʉ,"CargoStorage",ʜ);Ƚ.
Set(Ʉ,"Welders",Ɵ);}if(Έ){Ʉ="RSM.InitItems";foreach(Ō ʋ in Ϣ){Ƞ=ʋ.Ϻ.SubtypeId;Ƚ.Set(Ʉ,Ƞ,ʋ.Ͽ);}}Me.CustomData=Ƚ.ToString();}
string ь(Type ы){string э="";foreach(var ŋ in Enum.GetValues(ы)){if(э!="")э+=", ";э+=ŋ.ToString();}return э;}string ѓ(Color ĭ)
{return ĭ.R+", "+ĭ.G+", "+ĭ.B+", "+ĭ.A;}void Ѡ(Exception џ,string ў){Runtime.UpdateFrequency=UpdateFrequency.None;string
ѝ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ў+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ѝ);List<IMyTextPanel>ќ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ќ,ɦ=>ɦ.CustomName
.Contains(ʭ));foreach(IMyTextPanel Ƅ in ќ){Ƅ.WriteText(ѝ);Ƅ.FontColor=new Color(193,0,197,255);}throw џ;}Dictionary<
string,Y>ћ=new Dictionary<string,Y>();void њ(){ћ=new Dictionary<string,Y>{{"Cruise",new Y{W=ƚ.On,V=ǋ.AllDefence,U=Ǌ.HoldFire,S
=ǌ.EpsteinOnly,P=ǎ.ForwardOff,R=Ǎ.Off,Î=ƶ.On,ÿ=new Color(33,144,255,255),ý=ƶ.On,ü=new Color(255,214,170,255),ú=new Color(
33,144,255,255),ù=ǉ.Auto,ø=50,ö=ƚ.NoChange,õ=ƻ.Abort,ô=ƚ.NoChange,ó=ƺ.KeepFull,ò=ƚ.On,ñ=Ƹ.NoChange}},{"StealthCruise",new
Y{X="Cruise",W=ƚ.On,V=ǋ.AllDefence,U=Ǌ.HoldFire,S=ǌ.Minimum,P=ǎ.ForwardOff,R=Ǎ.Off,Î=ƶ.Off,ÿ=new Color(0,0,0,255),ý=ƶ.On,
ü=new Color(23,73,186,255),ú=new Color(23,73,186,255),ù=ǉ.Auto,ø=5,ö=ƚ.Off,õ=ƻ.Abort,ô=ƚ.NoChange,ó=ƺ.KeepFull,ò=ƚ.On,ñ=Ƹ
.NoChange}},{"Docked",new Y{X="Cruise",W=ƚ.On,V=ǋ.AllDefence,U=Ǌ.HoldFire,S=ǌ.Off,P=ǎ.Off,R=Ǎ.Off,Î=ƶ.On,ÿ=new Color(33,
144,255,255),ý=ƶ.On,ü=new Color(255,240,225,255),û=ƶ.On,ú=new Color(255,255,255,255),ù=ǉ.StockpileRecharge,ø=-1,ö=ƚ.
NoChange,õ=ƻ.Abort,ô=ƚ.Off,ó=ƺ.On,ò=ƚ.On,ñ=Ƹ.NoChange}},{"Docking",new Y{X="Docked",W=ƚ.On,V=ǋ.AllDefence,U=Ǌ.HoldFire,S=ǌ.Off,P
=ǎ.On,R=Ǎ.OnMax,Î=ƶ.On,ÿ=new Color(33,144,255,255),ý=ƶ.On,ü=new Color(212,170,83,255),û=ƶ.On,ú=new Color(212,170,83,255),
ù=ǉ.Auto,ø=-1,ö=ƚ.NoChange,õ=ƻ.Abort,ô=ƚ.Off,ó=ƺ.KeepFull,ò=ƚ.On,ñ=Ƹ.NoChange}},{"NoAttack",new Y{X="Docked",W=ƚ.Off,V=ǋ.
Off,U=Ǌ.Off,S=ǌ.On,P=ǎ.On,R=Ǎ.Off,Î=ƶ.On,ÿ=new Color(255,255,255,255),ý=ƶ.On,ü=new Color(84,157,82,255),û=ƶ.NoChange,ú=new
Color(84,157,82,255),ù=ǉ.NoChange,ø=-1,ö=ƚ.NoChange,õ=ƻ.NoChange,ô=ƚ.NoChange,ó=ƺ.KeepFull,ò=ƚ.On,ñ=Ƹ.NoChange}},{"Combat",
new Y{X="Cruise",W=ƚ.On,V=ǋ.AllDefence,U=Ǌ.OpenFire,S=ǌ.On,P=ǎ.On,R=Ǎ.Off,Î=ƶ.Off,ÿ=new Color(0,0,0,255),ý=ƶ.On,ü=new Color
(210,98,17,255),û=ƶ.On,ú=new Color(210,98,17,255),ù=ǉ.Discharge,ø=100,ö=ƚ.On,õ=ƻ.Abort,ô=ƚ.On,ó=ƺ.KeepFull,ò=ƚ.On,ñ=Ƹ.
NoChange}},{"CQB",new Y{X="Combat",W=ƚ.On,V=ǋ.Offence,U=Ǌ.OpenFire,S=ǌ.On,P=ǎ.On,R=Ǎ.Off,Î=ƶ.Off,ÿ=new Color(0,0,0,255),ý=ƶ.On,ü
=new Color(243,18,18,255),û=ƶ.On,ú=new Color(243,18,18,255),ù=ǉ.Discharge,ø=100,ö=ƚ.On,õ=ƻ.Abort,ô=ƚ.On,ó=ƺ.KeepFull,ò=ƚ.
On,ñ=Ƹ.NoChange}},{"WeaponsHot",new Y{X="CQB",W=ƚ.On,V=ǋ.Offence,U=Ǌ.OpenFire,S=ǌ.NoChange,P=ǎ.NoChange,R=Ǎ.NoChange,Î=ƶ.
NoChange,ÿ=new Color(0,0,0,255),ý=ƶ.NoChange,ü=new Color(243,18,18,255),û=ƶ.NoChange,ú=new Color(243,18,18,255),ù=ǉ.Discharge,ø=
-1,ö=ƚ.NoChange,õ=ƻ.NoChange,ô=ƚ.NoChange,ó=ƺ.KeepFull,ò=ƚ.On,ñ=Ƹ.NoChange}}};}class љ{public IMyDoor ȹ;public int ј=0;
public int ї=0;public bool і=false;public bool ѕ=false;}class ђ{public string є;public bool ѷ=false;public int ҥ=0;public bool
ң=false;public List<љ>Ң=new List<љ>();public List<IMyAirVent>ҡ=new List<IMyAirVent>();}int Ҡ=0;int ҟ=0;int Ҟ=0;bool ҝ(љ Қ
){bool қ=false;if(Қ.ȹ==null)return false;bool Ĝ=Қ.ȹ.OpenRatio>0;Ҡ++;if(Ҫ(Қ.ȹ))Ҟ++;if(Ĝ){Қ.ȹ.Enabled=true;if(ɺ&&Қ.ј==0)
Echo("Door just opened... ("+Қ.ȹ.CustomName+")");Қ.ј++;if(Қ.ј>=ʱ){Қ.ј=0;Қ.ȹ.CloseDoor();қ=true;}}else{ҟ++;}return қ;}void Ҝ(
){if(!ʰ){if(ɺ)Echo("Door management is disabled.");return;}foreach(ђ ɟ in Ξ){foreach(љ Қ in ɟ.Ң){if(Қ.ȹ==null)continue;
bool қ=ҝ(Қ);if(қ){if(ɺ)Echo("Airlock door "+Қ.ȹ.CustomName+" just closed");if(ɟ.ң)ɟ.ң=false;else{ɟ.ѷ=true;Қ.ѕ=true;if(ɺ)Echo
("Airlock "+ɟ.є+" needs to cycle");}}}if(ɟ.ѷ){foreach(љ Қ in ɟ.Ң){if(Қ.ȹ==null)continue;if(Қ.ȹ.OpenRatio>0)Қ.ȹ.CloseDoor(
);else Қ.ȹ.Enabled=false;}bool Ҥ=false;foreach(IMyAirVent Ҧ in ɟ.ҡ){if(Ҧ==null)continue;if(!Ҧ.Enabled)Ҧ.Enabled=true;if(!
Ҧ.Depressurize)Ҧ.Depressurize=true;if(Ҧ.CanPressurize&&Ҧ.GetOxygenLevel()<.01&&ɟ.ѷ)Ҥ=true;}ɟ.ҥ++;bool Ҳ=true;if(ɟ.ҥ>=ʯ){Ҳ
=false;Ҥ=true;}if(Ҥ){ɟ.ѷ=false;ɟ.ҥ=0;ɟ.ң=true;foreach(љ Қ in ɟ.Ң){if(Қ.ȹ==null)continue;Қ.ȹ.Enabled=true;if(Қ.ѕ)Қ.ѕ=false
;else if(Ҳ)Қ.ȹ.OpenDoor();}}}}}void ұ(){if(!ʰ){if(ɺ)Echo("Door management is disabled.");return;}Ҡ=0;ҟ=0;Ҟ=0;foreach(љ Қ
in Π)ҝ(Қ);}void Ұ(Ƹ e){if(e==Ƹ.NoChange)return;foreach(IMyAirtightHangarDoor ү in μ){if(ү==null)continue;if(e==Ƹ.Closed)ү.
CloseDoor();else ү.OpenDoor();}}void Ү(string ҭ,string Ҭ){ҭ=ҭ.ToLower();foreach(љ Қ in Π){if(Ҭ==""||Қ.ȹ.CustomName.Contains(Ҭ)){
bool ҫ=Ҫ(Қ.ȹ);if(ҫ&&(ҭ=="locked"||ҭ=="toggle"))Қ.ȹ.ApplyAction("AnyoneCanUse");if(!ҫ&&(ҭ=="unlocked"||ҭ=="toggle"))Қ.ȹ.
ApplyAction("AnyoneCanUse");}}}bool Ҫ(IMyDoor Қ){var Ɩ=Қ.GetActionWithName("AnyoneCanUse");StringBuilder ҩ=new StringBuilder();Ɩ.
WriteValue(Қ,ҩ);return(ҩ.ToString()=="On");}double Ҩ;int ҧ=0;int Ҙ=8;int ҋ=10;double Җ=3;double ҁ=245000;double Ҁ=50000;double ѿ=
100;void Ѿ(ƺ e){foreach(IMyTerminalBlock Ѹ in φ){if(Ѹ==null)continue;if(e==ƺ.Off)Ѹ.ApplyAction("OnOff_Off");else Ѹ.
ApplyAction("OnOff_On");}}void Ҋ(){if(φ.Count<1&&χ.Count>1)Ҩ=(Җ*Ҁ);else Ҩ=(Җ*ҁ);}void ѽ(){if(ï.ó==ƺ.Off||ï.ó==ƺ.On){if(ɺ)Echo(
"Extractor management disabled.");}else if(ҧ>0){ҧ--;if(ɺ)Echo("waiting ("+ҧ+")...");}else if(ϕ.Count<1){if(ɺ)Echo("No tanks!");}else if(ï.ó==ƺ.
FillWhenLow&&ѿ<ҋ){if(ɺ)Echo("Fuel low! ("+ѿ+"% / "+ҋ+"%)");Ͱ=true;Ѽ();}else if(ï.ó==ƺ.KeepFull&&Ú<(ë-Ҩ)){Ͱ=true;Ѽ();if(ɺ)Echo(
"Fuel ready for top up ("+Ú+" < "+(ë-Ҩ)+")");}else if(ɺ){Echo("Fuel level OK ("+ѿ+"%).");if(ï.ó==ƺ.KeepFull)Echo("Keeping tanks full\n("+Ú+" < "+
(ë-Ҩ)+")");}}void Ѽ(){string ſ="";int ѻ=8;if(ѿ<5){ѻ=0;if(Ҙ!=ѻ)ſ="v fast";}else if(ѿ<10){ѻ=2;if(Ҙ!=ѻ)ſ="fast";}else if(ѿ<
60){ѻ=4;if(Ҙ!=ѻ)ſ="medium";}else if(Ҙ!=ѻ)ſ="slow";if(ſ!=""){Ҙ=ѻ;н.Add(new ц("Extractor loading "+ſ,
"Extractor load speed has been set to "+ſ+" automatically)",0));}}void Ѻ(){Ͱ=false;IMyTerminalBlock ѹ=null;int Ō=1;foreach(IMyTerminalBlock Ѹ in φ){if(Ѹ.
IsFunctional){ѹ=Ѹ;break;}}if(ѹ==null){foreach(IMyTerminalBlock Ѹ in χ){if(Ѹ.IsFunctional){ѹ=Ѹ;Ō=2;break;}}if(ѹ==null){if(ɺ)Echo(
"No functional extractor to load!");ˬ=true;return;}}ˬ=false;if(Ϣ[Ō].Ѐ<1){ˤ=true;if(ɺ)Echo("No spare "+Ϣ[Ō].Ϻ.SubtypeId+" to load!");return;}ҧ=Ҙ;Ѕ ˆ=new Ѕ(
);ˆ.ȹ=ѹ;ˆ.ˆ=ѹ.GetInventory();ѹ.ApplyAction("OnOff_On");List<Ѕ>җ=new List<Ѕ>();җ.Add(ˆ);if(ɺ)Echo(
"Attempting to load extractor "+ѹ.CustomName);bool ɴ=Ј(Ϣ[Ō].ϼ,җ,Ϣ[Ō].Ϻ);string ҕ="fuel tank";if(Ō==2)ҕ="jerry can";if(ɴ)н.Add(new ц("Loaded a "+ҕ,
"Sucessfully loaded a "+ҕ+" into an extractor.",0));}double Ҕ=0;int ғ=0;double Ғ=0;void ґ(bool Í,bool ū){ғ=0;foreach(IMyGyro Ґ in Ϙ){if(Ґ!=null
&&Ґ.IsFunctional){ғ++;if(ū)Ґ.Enabled=Í;}}Ғ=Math.Round(100*(ғ/Ҕ));}void ҏ(string Ҏ,bool Ί=true,bool Ή=true,bool Έ=true){if(
ɺ)Echo("Initialising a ship as '"+Ҏ+"'...");Ν=true;ʿ();ϩ();Ͷ=0;Ν=false;ɽ=Ҏ;if(ɺ)Echo("Initialising lcds...");ƈ();if(Ή){if
(ɺ)Echo("Initialising subsystem values...");à();Ƕ();Ã();H();Ö();Ý();ʘ();w=ϐ.Count+Ϗ.Count;ȅ=ύ.Count;Q=ώ.Count;Ҕ=Ϙ.Count;Ɵ
=ϒ.Count;}if(Έ){if(ɺ)Echo("Initialising item values...");Ϩ();}if(Ί){if(ɺ)Echo("Initialising block names...");Э();}я(false
,Ή,Έ);н.Add(new ц("Init:"+Ҏ,"Initialised '"+Ҏ+"'\nGood Hunting!",3));}class ҍ{public int Ҍ=0;public int ҙ=0;public int ъ=
0;}void Э(){Dictionary<string,ҍ>ϵ=new Dictionary<string,ҍ>();if(ʠ.Count>0){foreach(string h in ʠ){if(ɺ)Echo("Numbering "+
h);ϵ.Add(h,new ҍ());}foreach(var ϲ in Μ){ҍ ϴ;if(ϵ.TryGetValue(ϲ.Value,out ϴ)){ϵ[ϲ.Value].ҙ++;}}foreach(var ϳ in ϵ){if(ϳ.
Value.ҙ<10)ϳ.Value.ъ=1;else if(ϳ.Value.ҙ>99)ϳ.Value.ъ=3;else ϳ.Value.ъ=2;}}foreach(var ϲ in Μ){string Ϸ="";string ϱ=ϲ.Value;ҍ
ϰ;if(ϵ.TryGetValue(ϲ.Value,out ϰ)){if(ϰ.ҙ>1){ϰ.Ҍ++;Ϸ=ʣ+ϰ.Ҍ.ToString().PadLeft(ϰ.ъ,'0');}}ϲ.Key.CustomName=ɽ+ʣ+ϱ+Ϸ+ϯ(ϲ.Key
.CustomName,ϱ);}}string ϯ(string Ƞ,string Ϯ=""){try{string[]ϭ=Ƞ.Split(ʣ);string[]Ϭ=Ϯ.Split(ʣ);string ƍ="";if(ϭ.Length<3)
return"";for(int ę=2;ę<ϭ.Length;ę++){int Ϲ=0;bool Ї=int.TryParse(ϭ[ę],out Ϲ);if(Ї)ϭ[ę]="";foreach(string І in Ϭ){if(І==ϭ[ę])ϭ[
ę]="";}if(ϭ[ę]!="")ƍ+=ʣ+ϭ[ę];}return ƍ;}catch{return"";}}class Ѕ{public IMyTerminalBlock ȹ{get;set;}public IMyInventory ˆ
{get;set;}List<MyInventoryItem>Є=new List<MyInventoryItem>();public int Ѓ=0;public bool Ђ=false;public float Ё;}class Ō{
public int Ѐ=0;public int Ͽ=0;public int Ͼ=0;public double Ͻ;public List<Ѕ>ϼ=new List<Ѕ>();public List<Ѕ>ϻ=new List<Ѕ>();
public MyItemType Ϻ;public bool ϣ=false;public bool ϛ=false;public string ϝ;}List<Ō>Ϣ=new List<Ō>();void ϡ(IMyTerminalBlock ɦ,
int ʋ=99){if(ʋ==99){foreach(var Ō in Ϣ){Ѕ ˆ=new Ѕ();ˆ.ȹ=ɦ;ˆ.ˆ=ɦ.GetInventory();Ō.ϼ.Add(ˆ);}}else{Ѕ ˆ=new Ѕ();ˆ.ȹ=ɦ;ˆ.ˆ=ɦ.
GetInventory();ˆ.Ђ=ʔ;if(ʋ==0&&!ʓ)ˆ.Ђ=false;Ϣ[ʋ].ϼ.Add(ˆ);}}void Ϡ(IMyTerminalBlock ɦ,int ʋ){Ѕ ˆ=new Ѕ();ˆ.ȹ=ɦ;ˆ.ˆ=ɦ.GetInventory();ˆ
.Ђ=ʔ;Ϣ[ʋ].ϻ.Add(ˆ);}void Ϟ(string ϝ,string Ϝ,string ϟ,bool ϛ=false,bool ϣ=false){Ō Ō=new Ō();Ō.Ϻ=new MyItemType(Ϝ,ϟ);Ō.ϛ=
ϛ;Ō.ϣ=ϣ;Ō.ϝ=ϝ;Ϣ.Add(Ō);}void ϫ(){try{Ϟ("Fusion F ","MyObjectBuilder_Ingot","FusionFuel",true);Ϟ("Fuel Tank",
"MyObjectBuilder_Component","Fuel_Tank");Ϟ("Jerry Can","MyObjectBuilder_Component","SG_Fuel_Tank");Ϟ("PDC      ","MyObjectBuilder_AmmoMagazine",
"40mmLeadSteelPDCBoxMagazine",true);Ϟ("PDC Tefl ","MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);Ϟ("220 Torp ",
"MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",true,true);Ϟ("220 MCRN ","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true
,true);Ϟ("220 UNN  ","MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);Ϟ("RS Torp  ",
"MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);Ϟ("LRS Torp ","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",
true,true);Ϟ("120mm RG ","MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);Ϟ("Dawson   ",
"MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true);Ϟ("Stiletto ","MyObjectBuilder_AmmoMagazine",
"100mmTungstenUraniumSlugMCRNMagazine",true);Ϟ("80mm     ","MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);Ϟ("Foehammr ",
"MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugMCRNMagazine",true);Ϟ("Farren   ","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugUNNMagazine",true);Ϟ("Kess     ","MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);Ϟ("Steel Pla",
"MyObjectBuilder_Component","SteelPlate");}catch(Exception ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void Ϫ(){foreach(var Ō
in Ϣ){Ō.ϻ.Clear();}}void ϩ(){foreach(var Ō in Ϣ){Ō.Ѐ=0;Ō.Ͼ=0;List<Ѕ>ˌ=Ō.ϼ.Concat(Ō.ϻ).ToList();foreach(Ѕ ˆ in ˌ){ˆ.Ѓ=ˆ.ˆ.
GetItemAmount(Ō.Ϻ).ToIntSafe();Ō.Ѐ+=ˆ.Ѓ;if(ˆ.Ђ){ˆ.Ё=ˆ.ˆ.VolumeFillFactor;}else{Ō.Ͼ+=ˆ.Ѓ;}}}}void Ϩ(){foreach(Ō Ō in Ϣ){Ō.Ͽ=Ō.Ѐ;}}int
ϧ(string Ȁ){switch(Ȁ){case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":case"MCRN Torpedo Low Spread"
:return 6;case"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;
case"40mm Lead-Steel PDC Box Ammo":return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":
return 10;case"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case
"80mm Tungsten-Uranium Sabot Ammo":return 13;case"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;
case"180mm Lead-Steel Sabot Ammo":return 16;default:if(ɺ)Echo("Unknown AmmoType = "+Ȁ);return 99;}}bool Ϧ(IMyTerminalBlock ȹ
){if(ȹ==null)return false;IMyInventory Ϥ=ȹ.GetInventory();return Ϥ.CurrentVolume.RawValue>(Ϥ.MaxVolume.RawValue*0.95);}
bool ϥ(IMyTerminalBlock ȹ){IMyInventory Ϥ=ȹ.GetInventory();return Ϥ.VolumeFillFactor==0;}bool Ј(List<Ѕ>ˋ,List<Ѕ>ˉ,MyItemType
Ϻ,int з=-1){if(ɺ)Echo("Loading "+ˉ.Count+" inventories from "+ˋ.Count+" sources.");bool º=false;foreach(Ѕ ж in ˉ){int е=3
;foreach(Ѕ д in ˋ){if(е<0)break;if(з!=-1&&ж.Ѓ>=(з*.95))break;if(!ж.ˆ.IsConnectedTo(д.ˆ))continue;List<MyInventoryItem>г=
new List<MyInventoryItem>();д.ˆ.GetItems(г);foreach(MyInventoryItem в in г){if(в.Type==Ϻ){int Ѓ=в.Amount.ToIntSafe();if(Ѓ==
0)break;е--;if(з!=-1){if(Ѓ<=з){break;}Ѓ=з-ж.Ѓ;}º=ж.ˆ.TransferItemFrom(д.ˆ,в,Ѓ);if(º)е=-1;if(ɺ)Echo("Loading success = "+º
);break;}}}}return º;}class б{public IMyTextPanel ȹ;public bool а=true;public bool Я=false;public bool Ю=false;public
bool и=true;public bool й=true;public bool ш=true;public bool щ=false;public bool ч=false;}class ц{public string х,ф;public
int у,т;public ц(string с,string р,int п=0,int о=20){if(с.Length>Е-3)с=с.Substring(0,Е-3);х=с.PadRight(Е-3);ф=р;у=п;т=о;}}
List<ц>н=new List<ц>();class м{public string л,к;public м(string h,int Й,int Ы){string З="    ";while(Ы>3){Ы-=4;}if(Й==0){л=
"║ "+h.PadRight(4)+" ║";к="  "+З+"  ";}else if(Й==1){if(Ы==0||Ы==2)л="║─"+h.PadRight(4)+" ║";else л="║ "+h.PadRight(4)+"─║";
к=" ░"+З+"░ ";}else if(Й==2){if(Ы==0||Ы==2){л="║ "+h.PadRight(4)+"═║";к="║▒"+З+"░║";}else{л="║═"+h.PadRight(4)+" ║";к=
"║░"+З+"▒║";}}else if(Й==3){if(Ы==0||Ы==2){л="║!"+h.PadRight(4)+"!║";к="║▓"+З+"▓║";}else{л="║ "+З+" ║";к="║!"+h.PadRight(4)+
"!║";}}}}Color Ж=new Color(255,116,33,255);const int Е=32;int Д=0;string[]Г=new string[]{"▄ "," ▄"," ▀","▀ "},В=new string[]
{"─","\\","│","/"},И=new string[]{"- ","= ","x ","! "};string Б="RSM is booting...\n\n",Џ,Ў,Ѝ="──\n\n",Ќ="╔══════╗",Ћ=
"╚══════╝",Њ,А,Љ,К,Ь,Ъ,Щ,Ш,Ч,Ц,Х,Ф,У,Т,С,Р,П,О,Н,М,Л;void ʀ(){Ќ=Ќ+Ќ+Ќ+Ќ+"\n";Ћ=Ћ+Ћ+Ћ+Ћ+"\n";Џ=new String(' ',Е-8);Ў="└"+new String
('─',Е-2)+"┘";Њ=new String('-',26)+"\n";А=ȷ("Inventory");Љ=ȷ("Thrust");К=ȷ("Power & Tanks");Ь=ȷ("Warnings");Ъ=ȷ(
"Subsystem Integrity");Щ=ȷ("Telemetry & Thrust");Ш=ń("Velocity");Ч=ń("Velocity (Max)");Ц=ń("Mass");Х=ń("Max Accel");Ф=ń("Actual Accel");У=ń(
"Accel (Best)");Т=ń("Max Thrust");С=ń("Actual Thrust");Р=ń("Decel (Dampener)");П=ń("Decel (Actual)");О=ł("Fuel");Н=ł("Oxygen");М=ł(
"Battery");Л=ł("Capacity");}string ȷ(string Þ){return"──┤ "+Þ+" ├"+new String('─',Е-9-Þ.Length);}string ń(string Ń){return"\n"+Ń+
":"+new String(' ',Е-16-Ń.Length);}string ł(string Ł){return Ł+new String(' ',Е-22-Ł.Length)+"[";}void ŀ(){Д++;if(Д>=Г.
Length)Д=0;int Ŀ=Д+2;if(Ŀ>3)Ŀ-=4;string Ņ=Г[Д];string ľ=В[Д];string ļ=Г[Ŀ];string Ļ=А+ľ+Ѝ;string ĺ=Љ+ľ+Ѝ;string Ĺ=К+ľ+Ѝ;string
ĸ=Ь+ľ+Ѝ;string ķ=Ъ+ľ+Ѝ;string Ľ=Щ+ľ+Ѝ;string Ķ=ŵ(ɽ.ToUpper(),Е)+"\n"+"  "+Ņ+" "+ŵ(ð,Е-10)+" "+Ņ+"  \n";string Ň="\n  "+ļ+
Џ+ļ+"  \n\n";if(ʹ){Ļ+=Б;ĺ+=Б;Ĺ+=Б;ĸ+=Б;ķ+=Б;}else{ʝ();double Ř=9.81,Ŗ=Math.Round(Ά),ŕ=Math.Round((é/Η/Ř),2),Ŕ=Math.Round(
(è/Η/Ř),2),œ=Math.Round(N+È,1),Œ=Math.Round(Ë,1),ő=Math.Round(100*(Ò/Ó)),Ő=Math.Round(100*(Ç/É)),ŏ=Math.Round(100*(Œ/œ));
string Ŏ=Ш,ō=" Gs";if(Ŗ<1){Ŗ=500;Ŏ=Ч;}if(ɻ){Ř=1;ō=" m/s/s";}foreach(Ō Ō in Ϣ){if(Ō.Ͽ!=0){Ō.Ͻ=(100*((double)Ō.Ѐ/(double)Ō.Ͽ));
string ŋ=(Ō.Ѐ+"/"+Ō.Ͽ).PadLeft(9);if(ŋ.Length>9)ŋ=ŋ.Substring(0,9);Ļ+=Ō.ϝ+" ["+Ħ(Ō.Ͻ)+"] "+ŋ+"\n";}}Ļ+="\n";if(è>0)ĺ=П+Ű(è,Ŗ)+
Ф+(Ŕ+ō).PadLeft(15);else ĺ=Р+Ű(é,Ŗ,true)+У+(ŕ+ō).PadLeft(15);ѿ=Math.Round(100*(Ú/ë));Ĺ+=О+Ħ(ѿ)+"] "+(ѿ+" %").PadLeft(9)+
"\n"+Н+Ħ(ő)+"] "+(ő+" %").PadLeft(9)+"\n"+М+Ħ(Ő)+"] "+(Ő+" %").PadLeft(9)+"\n"+Л+Ħ(ŏ)+"] "+(ŏ+" %").PadLeft(9)+"\n"+
"Max Power:"+(Œ+" MW / "+œ+" MW").PadLeft(22)+"\n\n";List<ц>Ŋ=new List<ц>();List<м>ŉ=new List<м>();int ň=0;for(int ę=0;ę<н.Count;ę++
){н[ę].т--;if(н[ę].т<1)н.RemoveAt(ę);else Ŋ.Add(н[ę]);}if(!ƃ){Ŋ.Add(new ц("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}int ŗ=0;if(ѿ<5){Ŋ.Add(new ц("FUEL CRITICAL!","FUEL CRITICAL!\nFuel Level < 5%!",3));ŗ=3;}else if(ѿ<25){Ŋ.Add(new ц
("FUEL LOW!","FUEL LOW!\nFuel Level < 10%!",2));ŗ=2;}if(ï.ó!=ƺ.Off){if(ˤ){if(ŗ==0)ŗ=1;Ŋ.Add(new ц("No spare fuel tanks",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",ŗ));}if(ˬ){if(ŗ==0)ŗ=1;Ŋ.Add(new ц("No Extractor","Cannot refuel!\nNo functional extractor!",ŗ));}}ŉ.Add(new м("FUEL",ŗ
,Д+ň));ň++;int ĵ=0;if(ő<5){Ŋ.Add(new ц("OXYGEN CRITICAL!","OXYGEN CRITICAL!\nShip O2 Level < 5%!",3));ĵ=3;}else if(ő<10){
Ŋ.Add(new ц("OXYGEN LOW!","OXYGEN LOW!\nShip O2 Level < 10%!",2));ĵ=2;}else if(ő<25){Ŋ.Add(new ц("Oxygen Low",
"Oxygen Low!\nShip O2 Level < 25%!",1));ĵ=1;}if(ϓ.Count>ŭ){int ĳ=(ϓ.Count-ŭ);ĵ++;Ŋ.Add(new ц(ĳ+" vents are unsealed",ĳ+" vents are unsealed",1));}if(Ҟ>0){Ŋ
.Add(new ц(Ҟ+" doors are insecure",Ҟ+" doors are insecure",0));}if(ˣ>0){Ŋ.Add(new ц(ʫ+" is active ("+ˣ+")",ʫ+
" is active ("+ˣ+")",0));}ŉ.Add(new м("OXYG",ĵ,Д+ň));ň++;int Ģ=0;if(ρ.Count>0){if(Ő<5){Ģ+=2;Ŋ.Add(new ц("BATTERIES CRITICAL!",
"BATTERIES CRITICAL!\nBattery Level < 5%!",2));}else if(Ő<10){Ģ+=1;Ŋ.Add(new ц("Batteries Low!","Batteries Low!\nBattery Level < 10%!",1));}}if(ϗ.Count>0){if(K>0)
{Ģ+=2;Ŋ.Add(new ц(K+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}if(Ϣ[0].Ͽ==0){if(Ϣ[0].Ѐ>0)
{Ģ+=1;Ŋ.Add(new ц("No Spare Fusion Fuel!","No spare fusion fuel detected in ships cargo!",2));}}else if(Ϣ[0].Ͻ<5){Ģ+=2;Ŋ.
Add(new ц("FUSION FUEL LEVEL CRITICAL!","Fusion fuel level is low!",3));}else if(Ϣ[0].Ͻ<10){Ģ+=1;Ŋ.Add(new ц(
"Fusion Fuel Level Low!","Fusion fuel level is low!",2));}}if(Ģ>3)Ģ=3;ŉ.Add(new м("POWR",Ģ,Д+ň));ň++;int ġ=0;if(ˎ!=""){string[]Ġ=ˎ.Split('\n');
foreach(string ğ in Ġ){string Ğ=ğ;if(ğ.Length>23)Ğ=ğ.Substring(0,23);Ğ=Ğ.ToUpper();Ŋ.Add(new ц("NEED "+Ğ+"!","NEED "+Ğ+
"!  Ammo Critical!",3));}ġ=3;}if(ġ>3)ġ=3;ŉ.Add(new м("WEAP",ġ,Д+ň));ň++;if(ʹ){string ĝ=ʲ;if(ς.Count>0)if(ς[0]!=null)ĝ=(ς[0]as
IMyRadioAntenna).HudText;string ģ="";if(ˁ<1000)ģ=Math.Round(ˁ)+"m";else ģ=Math.Round(ˁ/1000)+"km";Ŋ.Add(new ц("Comms ("+ģ+"): "+ĝ,
"Antenna(s) are broadcasting at a range of "+ģ+" with the message "+ĝ,0));}if(ͳ>0){Ŋ.Add(new ц(ͳ+" UNOWNED BLOCKS!","RSM detected "+ͳ+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(Ҡ>ҟ){int Ĝ=(Ҡ-ҟ);Ŋ.Add(new ц(Ĝ+" doors are open",Ĝ+" doors are open",0));}Ŋ=Ŋ.OrderBy(Ě=>Ě.у).Reverse().ToList(
);if(Ŋ.Count<1)ĸ+="No warnings\n";else Echo("\n\n WARNINGS:");for(int ę=0;ę<Ŋ.Count;ę++){ĸ+=И[Ŋ[ę].у]+Ŋ[ę].х+"\n";Echo(
"-"+И[Ŋ[ę].у]+Ŋ[ę].ф);}ĸ+="\n";string Ę=ï.S.ToString().ToUpper();if(Ę.Length>3)Ę=Ę.Substring(0,3);string ė=ï.P.ToString().
ToUpper();if(ė.Length>3)ė=ė.Substring(0,3);string Ė=ï.S.ToString().ToUpper();if(Ė.Length>3)Ė=Ė.Substring(0,3);string ĕ=ï.V.
ToString().ToUpper();if(ĕ.Length>3)ĕ=ĕ.Substring(0,3);string ě=ï.W.ToString().ToUpper();if(ě.Length>3)ě=ě.Substring(0,3);string
Ĕ=ï.U.ToString().ToUpper();if(Ĕ.Length>3)Ĕ=Ĕ.Substring(0,3);try{if(ç>0)ķ+="Epstein   ["+Ħ(æ)+"] "+(æ+"% ").PadLeft(5)+Ę+
"\n";if(ǹ>0)ķ+="RCS       ["+Ħ(Ǹ)+"] "+(Ǹ+"% ").PadLeft(5)+ė+"\n";if(N>0)ķ+="Reactors  ["+Ħ(L)+"] "+(L+"% ").PadLeft(5)+
"    \n";if(È>0)ķ+="Batteries ["+Ħ(Æ)+"] "+(Æ+"% ").PadLeft(5)+Ė+"\n";if(w>0)ķ+="PDCs      ["+Ħ(u)+"] "+(u+"% ").PadLeft(5)+ĕ+
"\n";if(ȅ>0)ķ+="Torpedoes ["+Ħ(ȃ)+"] "+(ȃ+"% ").PadLeft(5)+ě+"\n";if(Q>0)ķ+="Railguns  ["+Ħ(n)+"] "+(n+"% ").PadLeft(5)+Ĕ+
"\n";if(Û>0)ķ+="H2 Tanks  ["+Ħ(Ù)+"] "+(Ù+"% ").PadLeft(5)+Ė+"\n";if(Ñ>0)ķ+="O2 Tanks  ["+Ħ(Ð)+"] "+(Ð+"% ").PadLeft(5)+Ė+
"\n";if(Ҕ>0)ķ+="Gyros     ["+Ħ(Ғ)+"] "+(Ғ+"% ").PadLeft(5)+"    \n";if(ʜ>0)ķ+="Cargo     ["+Ħ(ʚ)+"] "+(ʚ+"% ").PadLeft(5)+
"    \n";if(Ɵ>0)ķ+="Welders   ["+Ħ(Ɲ)+"] "+(Ɲ+"% ").PadLeft(5)+"    \n";}catch{}if(È+N+Û==0)ķ+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+"\n\n";string ĥ="";string Ĵ="";foreach(м Ĳ in ŉ){ĥ+=Ĳ.л;Ĵ+=Ĳ.к;}int ı=Д+2;if(ı>3)ı-=4;Ķ+=Ќ+ĥ+"\n"+Ћ;Ň+=Ĵ;if(!Β){Ľ+=
"\n\n";}else{if(ɺ)Echo("Building advanced thrust...");string İ="";if(ʍ){İ=Ц+(Math.Round((Η/1000000),2)+" Mkg").PadLeft(15)+Ŏ+(
Ŗ+" ms").PadLeft(15)+Х+(ŕ+ō).PadLeft(15)+Ф+(Ŕ+ō).PadLeft(15)+Т+((é/1000000)+" MN").PadLeft(15)+С+((è/1000000)+" MN").
PadLeft(15);}Ľ+=İ+Р+Ű(é,Ŗ,true)+П+Ű(è,Ŗ);foreach(double į in ɼ){Ľ+="\n"+("Decel ("+(į*100)+"%):").PadRight(17)+Ű((float)(é*į),Ŗ
);}Ľ+="\n\n";}}foreach(б ħ in Χ){string Į="";Color ĭ=ï.ú;if(ħ.а)Į+=Ķ;if(ħ.Я){Į+=Ň;ĭ=Ж;}if(ħ.Ю)Į+=ĸ;if(ħ.и)Į+=Ĺ;if(ħ.й)Į+=
Ļ;if(ħ.ш)Į+=ĺ;if(ħ.щ)Į+=ķ;if(ħ.ч){Į+=Ľ;Β=true;}ħ.ȹ.WriteText(Į,false);if(!ɾ)ħ.ȹ.FontColor=ĭ;}}void Ĭ(){if(ι.Count>0){
foreach(IMyTextPanel ħ in ι){ħ.FontColor=ï.ú;}foreach(б ħ in Χ){ħ.ȹ.FontColor=ï.ú;}}}void ī(string Ī,string ĩ){Ī=Ī.ToLower();
List<IMyTextPanel>Ĩ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ω);foreach(IMyTextPanel ħ in Ω
){if(ĩ==""||ħ.CustomName.Contains(ĩ)){string Ĥ=ħ.CustomData;if(Ĥ.Contains("hudlcd")&&(Ī=="off"||Ī=="toggle"))ħ.CustomData
=Ĥ.Replace("hudlcd","hudXlcd");if(Ĥ.Contains("hudXlcd")&&(Ī=="on"||Ī=="toggle"))ħ.CustomData=Ĥ.Replace("hudXlcd","hudlcd"
);}}}string Ħ(double ř){try{int ž=0;if(ř>0){int ż=(int)ř/10;if(ż>10)return new string('=',10);if(ż!=0)ž=ż;}char Ż=' ';if(
ř<10){if(Д==0)return" ><    >< ";if(Д==1)return"  ><  ><  ";if(Д==2)return"   ><><   ";if(Д==3)return"<   ><   >";}string
ź=new string('=',ž);string Ź=new string(Ż,10-ž);return ź+Ź;}catch{return"# ERROR! #";}}string Ÿ(string ŷ){string Ŷ;string
ŋ="";double ř=0;switch(ŷ){case"H2":ř=Math.Round(100*(Ú/Û));ŋ=ř.ToString()+" %";ѿ=ř;break;case"O2":ř=Math.Round(100*(Ò/Ñ))
;ŋ=ř.ToString()+" %";break;case"Battery":ř=Math.Round(100*(Ç/É));ŋ=ř.ToString()+" %";break;}Ŷ=Ħ(ř);return" ["+Ŷ+"] "+ŋ.
PadLeft(9);}string ŵ(string Ŵ,int ų){int Ų=ų-Ŵ.Length;int ű=Ų/2+Ŵ.Length;return Ŵ.PadLeft(ű).PadRight(ų);}string Ű(double Ž,
double ſ,bool ƌ=false){if(Ž<=0)return("N/A").PadLeft(15);if(ƌ)Ž=Ž*1.5;double ƍ=0.5*(Math.Pow(ſ,2)*(Η/Ž));double Ƌ=ſ/(Ž/Η);
string Ɗ="m";if(ƍ>1000){Ɗ="km";ƍ=ƍ/1000;}return(Math.Round(ƍ)+Ɗ+" "+Math.Round(Ƌ)+"s").PadLeft(15);}void Ɖ(){foreach(
IMyTextPanel Ƅ in Ω){Ƅ.Enabled=true;}}void ƈ(){foreach(б ħ in Χ){ħ.ȹ.Font="Monospace";ħ.ȹ.ContentType=ContentType.TEXT_AND_IMAGE;if(
ħ.ȹ.CustomName.Contains("HUD1")){ħ.а=true;ħ.Я=false;ħ.Ю=false;ħ.и=false;ħ.й=false;ħ.ш=false;ħ.щ=false;ħ.ч=false;Ƀ(ħ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ħ.ȹ.CustomName.Contains("HUD2")){ħ.а=false;ħ.Я=false;ħ.Ю=true;ħ.и=false;ħ.й=false;ħ.ш=false;ħ.щ=false;ħ.ч
=false;Ƀ(ħ,"hudlcd:0.22:0.99:0.55");continue;}if(ħ.ȹ.CustomName.Contains("HUD3")){ħ.а=false;ħ.Я=false;ħ.Ю=false;ħ.и=true;
ħ.й=false;ħ.ш=true;ħ.щ=false;ħ.ч=false;Ƀ(ħ,"hudlcd:0.48:0.99:0.55");continue;}if(ħ.ȹ.CustomName.Contains("HUD4")){ħ.а=
false;ħ.Я=false;ħ.Ю=false;ħ.и=false;ħ.й=false;ħ.ш=false;ħ.щ=true;ħ.ч=false;Ƀ(ħ,"hudlcd:0.74:0.99:0.55");continue;}if(ħ.ȹ.
CustomName.Contains("HUD5")){ħ.а=false;ħ.Я=false;ħ.Ю=false;ħ.и=false;ħ.й=true;ħ.ш=false;ħ.щ=false;ħ.ч=true;Ƀ(ħ,"hudlcd:0.75:0:.54"
);continue;}if(ħ.ȹ.CustomName.Contains("HUD6")){ħ.а=false;ħ.Я=true;ħ.Ю=false;ħ.и=false;ħ.й=false;ħ.ш=false;ħ.щ=false;ħ.ч=
false;Ƀ(ħ,"hudlcd:-0.55:0.99:0.7");continue;}}bool Ƈ=false;bool Ɔ=false;bool ƅ=false;foreach(IMyTextPanel Ƅ in Ω){if(Ƅ==null)
continue;if(!Ɔ&&Ƅ.CustomName.Contains("[REEDAV].1")){Ɔ=true;Ƅ.CustomData=
"Show Targeting Info=True\nFirst Missile=0\nLast Missile=0\nExtra Missile Info=False\nhudlcd:0.56:0:.48";continue;}if(!ƅ&&Ƅ.CustomName.Contains("[REEDAV].2")){ƅ=true;Ƅ.CustomData=
"Show Targeting Info=False\nFirst Missile=1\nLast Missile=24\nExtra Missile Info=False\nhudlcd:0.56:-.26:.48";continue;}if(!Ƈ&&(Ƅ.CustomName.Contains(ʥ)||Ƅ.CustomName.ToUpper().Contains(ʤ))){Ƈ=true;Ƅ.CustomData=
"hudlcd:-0.52:-0.7:0.52";continue;}}}bool ƃ;void Ƃ(bool Í,bool ū){ƃ=false;foreach(IMyConveyorSorter Ɓ in ϑ){if(Ɓ!=null&&Ɓ.IsFunctional){ƃ=true;
if(ū)Ɓ.Enabled=Í;}}}void ƀ(Ǎ e){if(e==Ǎ.NoChange)return;foreach(IMyReflectorLight š in Ρ){if(š==null)continue;if(e==Ǎ.Off)
š.Enabled=false;else{š.Enabled=false;if(e==Ǎ.OnMax)š.Radius=9999;}}}void Ů(ƶ e,Color ĭ){if(e==ƶ.NoChange)return;foreach(
IMyLightingBlock Ś in Φ){if(Ś==null)continue;if(e==ƶ.Off)Ś.Enabled=false;else Ś.Enabled=true;if(e!=ƶ.OnNoColourChange)Ś.SetValue("Color"
,ĭ);}}void Š(ƶ e,Color ĭ){if(e==ƶ.NoChange)return;foreach(IMyLightingBlock Ś in Φ){if(Ś==null)continue;if(e==ƶ.Off)Ś.
Enabled=false;else Ś.Enabled=true;if(e!=ƶ.OnNoColourChange)Ś.SetValue("Color",ĭ);}}Color ş=new Color(255,0,0,255);Color ŝ=new
Color(255,0,0,255);Color Ŝ=new Color(255,0,0,255);void ś(ƶ e){if(e==ƶ.NoChange)return;foreach(IMyLightingBlock Ś in Τ){Ş(Ś,e,
ŝ);}foreach(IMyLightingBlock Ś in Σ){Ş(Ś,e,Ŝ);}}void Ş(IMyLightingBlock Ś,ƶ e,Color ĭ){if(Ś==null)return;if(e==ƶ.Off){Ś.
Enabled=false;Ś.SetValue("Color",ş);}else{Ś.Enabled=true;if(e!=ƶ.OnNoColourChange)Ś.SetValue("Color",ĭ);}}int ŭ=0;void Ŭ(bool Í
,bool ū){ŭ=0;foreach(IMyAirVent Ū in ϓ){if(Ū!=null){if(ū)Ū.Enabled=Í;if(Ū.CanPressurize)ŭ++;}}}void ũ(bool Í){foreach(
IMyShipConnector Ũ in ξ){if(Ũ!=null)Ũ.Enabled=Í;}}void ŧ(bool Í){foreach(IMyCameraBlock Ŧ in π){if(Ŧ!=null)Ŧ.Enabled=Í;}}void ť(bool Í){
foreach(IMySensorBlock Ť in ϖ){if(Ť!=null)Ť.Enabled=Í;}}bool ţ=false;List<string>Ţ=new List<string>();bool ů=false;List<string>
ē=new List<string>();void í(string À,string y){bool º=false;List<IMyProgrammableBlock>µ=new List<IMyProgrammableBlock>();
try{if(y=="EFC")µ=ψ;else if(y=="NavOS")µ=λ;foreach(IMyProgrammableBlock ª in ψ){if(ª==null||!ª.Enabled)continue;º=(ª as
IMyProgrammableBlock).TryRun(À);if(º&&ɺ)Echo("Ran "+À+" on "+ª.CustomName+" successfully.");else н.Add(new ц(y+" command failed!",y+
" command "+À+" failed!",1));if(y=="EFC")ţ=true;else if(y=="NavOS")ů=true;break;}}catch(Exception ex){н.Add(new ц(y+
" command errored!",y+" command "+À+" errored!\n"+ex.Message,3));}}void z(string À,string y){if(y=="EFC"){if(ψ.Count<1)return;if(ţ){Ţ.Add(À
);return;}}if(y=="NavOS"){if(λ.Count<1)return;if(ů){ē.Add(À);return;}}í(À,y);}void x(){if(Ţ.Count>0&&!ţ){í(Ţ[0],"EFC");Ţ.
RemoveAt(0);}if(ē.Count>0&&!ů){í(ē[0],"NavOS");ē.RemoveAt(0);}ţ=false;ů=false;}int w=0;double v=0;double u=0;void t(){v=0;
foreach(IMyTerminalBlock s in ϐ){q(s,ï.V!=ǋ.Off&&ï.V!=ǋ.MinDefence);}foreach(IMyTerminalBlock s in Ϗ){q(s,ï.V!=ǋ.Off);}u=Math.
Round(100*(v/w));}void q(IMyTerminalBlock Â,bool Í){if(Â!=null&&Â.IsFunctional){v++;(Â as IMyConveyorSorter).Enabled=Í;}}void
Ì(ǋ e){if(e==ǋ.NoChange)return;foreach(IMyTerminalBlock s in ϐ){if(s!=null&s.IsFunctional){switch(e){case ǋ.Off:case ǋ.
MinDefence:(s as IMyConveyorSorter).Enabled=false;break;case ǋ.AllDefence:(s as IMyConveyorSorter).Enabled=true;if(ʒ){try{s.
SetValue("WC_FocusFire",false);s.SetValue("WC_Projectiles",true);s.SetValue("WC_Grids",true);s.SetValue("WC_LargeGrid",false);s.
SetValue("WC_SmallGrid",true);s.SetValue("WC_SubSystems",true);s.SetValue("WC_Biologicals",true);Ɉ(s);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;case ǋ.Offence:(s as IMyConveyorSorter).Enabled=true;if(ʒ){try{s.SetValue("WC_FocusFire",false);s.SetValue(
"WC_Projectiles",true);s.SetValue("WC_Grids",true);s.SetValue("WC_LargeGrid",true);s.SetValue("WC_SmallGrid",true);s.SetValue(
"WC_SubSystems",true);s.SetValue("WC_Biologicals",true);Ɉ(s);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock s in Ϗ){if(s!=null&s.IsFunctional){switch(e){case ǋ.Off:(s as IMyConveyorSorter).Enabled=false;break;
case ǋ.MinDefence:case ǋ.AllDefence:case ǋ.Offence:(s as IMyConveyorSorter).Enabled=true;if(ʒ){try{s.SetValue("WC_FocusFire"
,false);s.SetValue("WC_Projectiles",true);s.SetValue("WC_Grids",true);s.SetValue("WC_LargeGrid",false);s.SetValue(
"WC_SmallGrid",true);s.SetValue("WC_SubSystems",true);s.SetValue("WC_Biologicals",true);ɉ(s);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double Ë;void Ê(ǉ e){Ë=0;Å(e);J();}double É=0;double È=0;double Ç=0;double Æ=0;void Å(ǉ e){É=0;Ç=0;foreach
(IMyBatteryBlock O in ρ){if(O!=null&&O.IsFunctional){Ç+=O.CurrentStoredPower;É+=O.MaxStoredPower;Ë+=O.MaxOutput;O.Enabled
=true;bool Ä=e==ǉ.Discharge;if(Ä&&ʐ){if(m)O.ChargeMode=ChargeMode.Discharge;else O.ChargeMode=ChargeMode.Auto;}}}Æ=Math.
Round(100*(Ë/È));}void Ã(){È=0;foreach(IMyBatteryBlock O in ρ){È+=O.MaxOutput;}}void p(ǉ e){if(e==ǉ.NoChange)return;foreach(
IMyBatteryBlock O in ρ){if(O!=null&O.IsFunctional){O.Enabled=true;if(e==ǉ.Auto)O.ChargeMode=ChargeMode.Auto;else if(e==ǉ.
StockpileRecharge)O.ChargeMode=ChargeMode.Recharge;else if(!ʐ)O.ChargeMode=ChargeMode.Recharge;}}}double N=0;double M=0;double L=0;int K=
0;void J(){M=0;K=0;foreach(IMyReactor F in ϗ){if(F!=null&&F.IsFunctional){F.Enabled=true;if(ϥ(F))K++;else M+=F.MaxOutput;
}}L=Math.Round(100*(M/N));Ë+=M;}void H(){N=0;foreach(IMyReactor F in ϗ){N+=F.MaxOutput;}}void E(IMyProjector C){C.
CustomData=C.ProjectionOffset.X+"\n"+C.ProjectionOffset.Y+"\n"+C.ProjectionOffset.Z+"\n"+C.ProjectionRotation.X+"\n"+C.
ProjectionRotation.Y+"\n"+C.ProjectionRotation.Z+"\n";}void D(IMyProjector C){if(!C.IsFunctional)return;try{string[]B=C.CustomData.Split(
'\n');Vector3I G=new Vector3I(int.Parse(B[0]),int.Parse(B[1]),int.Parse(B[2]));Vector3I A=new Vector3I(int.Parse(B[3]),int.
Parse(B[4]),int.Parse(B[5]));C.Enabled=true;C.ProjectionOffset=G;C.ProjectionRotation=A;C.UpdateOffsetAndRotation();}catch{if
(ɺ)Echo("Failed to load projector position for "+C.Name);}}int Q=0;double o=0;double n=0;bool m=false;void l(){m=false;o=
0;foreach(IMyTerminalBlock Z in ώ){if(Z!=null&&Z.IsFunctional){o++;(Z as IMyConveyorSorter).Enabled=ï.U!=Ǌ.Off;if(!m){
MyDetectedEntityInfo?k=Ǵ.ȑ(Z);if(k.HasValue){string h=k.Value.Name;if(h!=null&&h!=""){if(ɺ)Echo("At least one rail has a target!");m=true;}}
}}}n=Math.Round(100*(o/Q));}void f(Ǌ e){if(e==Ǌ.NoChange)return;foreach(IMyTerminalBlock Z in ώ){if(Z!=null&Z.
IsFunctional){if(e==Ǌ.Off){(Z as IMyConveyorSorter).Enabled=false;}else{(Z as IMyConveyorSorter).Enabled=true;if(ʒ){Z.SetValue(
"WC_Grids",true);Z.SetValue("WC_LargeGrid",true);Z.SetValue("WC_SmallGrid",true);Z.SetValue("WC_SubSystems",true);Ɉ(Z);}if(ʑ){if(e
==Ǌ.OpenFire){ɱ(Z);}else{Ʌ(Z);}}}}}}class Y{public string X="";public ƚ W;public ǋ V;public Ǌ U;public ǌ S;public ǎ P;
public Ǎ R;public ƶ Î;public Color ÿ;public ƶ ý;public Color ü;public ƶ û;public Color ú;public ǉ ù;public int ø;public ƚ ö;
public ƻ õ;public ƚ ô;public ƺ ó;public ƚ ò;public Ƹ ñ;}string ð="N/A";Y ï;ƚ î=ƚ.On;ǋ þ=ǋ.Offence;Ǌ Ā=Ǌ.OpenFire;ǌ đ=ǌ.On;ǎ Ē=
ǎ.On;Ǎ Đ=Ǎ.On;ƶ ď=ƶ.On;Color Ď=new Color(33,144,255,255);ƶ č=ƶ.On;Color Č=new Color(255,214,170,255);ƶ ċ=ƶ.On;Color Ċ=new
Color(33,144,255,255);ǉ ĉ=ǉ.Auto;int Ĉ=-1;ƚ ć=ƚ.NoChange;ƻ Ć=ƻ.NoChange;ƚ ą=ƚ.NoChange;ƺ Ą=ƺ.KeepFull;ƚ ă=ƚ.On;Ƹ Ă=Ƹ.NoChange
;void ā(string ì){Y Ü;if(!ћ.TryGetValue(ì,out Ü)){н.Add(new ц("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ɺ)Echo("Setting stance '"+ì+"'.");ï=Ü;ð=ì;я();if(ɺ)Echo("Setting "+ώ.Count+" railguns to "+ï.U);f(ï.U);
if(ɺ)Echo("Setting "+ύ.Count+" torpedoes to "+ï.W);ǿ(ï.W);if(ɺ)Echo("Setting "+ϐ.Count+" _normalPdcs, "+Ϗ.Count+
" defence _normalPdcs to "+ï.V);Ì(ï.V);if(ɺ)Echo("Setting "+ό.Count+" epsteins, "+ϊ.Count+" chems"+" to "+ï.S);Á(ï.S,ï.P);if(ɺ)Echo("Setting "+ϋ.
Count+" rcs, "+ω.Count+" atmos"+" to "+ï.P);ǵ(ï.P);if(ɺ)Echo("Setting "+ρ.Count+" batteries to = "+ï.ù);p(ï.ù);if(ɺ)Echo(
"Setting "+ϕ.Count+" H2 tanks to stockpile = "+ï.ù);Õ(ï.ù);if(ɺ)Echo("Setting "+ϔ.Count+" O2 tanks to stockpile = "+ï.ù);ê(ï.ù);if
(ʏ){if(ɺ)Echo("No lighting was set because lighting control is disabled.");}else{if(ɺ)Echo("Setting "+Ρ.Count+
" spotlights to "+ï.R);ƀ(ï.R);if(ɺ)Echo("Setting "+Φ.Count+" exterior lights to "+ï.Î);Ů(ï.Î,ï.ÿ);if(ɺ)Echo("Setting "+Υ.Count+
" exterior lights to "+ï.ý);Š(ï.ý,ï.ü);if(ɺ)Echo("Setting "+Τ.Count+" port nav lights, "+Σ.Count+" starboard nav lights to "+ï.û);ś(ï.û);}if(ɺ
)Echo("Setting "+Ψ.Count+" aux block to "+ï.ô);τ(ï.ô);if(ɺ)Echo("Setting "+φ.Count+" extrators to "+ï.ó);Ѿ(ï.ó);if(ɺ)Echo
("Setting "+μ.Count+" hangar doors units to "+ï.ñ);Ұ(ï.ñ);if(ï.U==Ǌ.OpenFire){if(ɺ)Echo("Setting "+Π.Count+
" doors to locked because we are in combat (rails set to open fire).");Ү("locked","");}if(ɺ)Echo("Setting "+ι.Count+" colour sync Lcds.");Ĭ();if(ï.õ==ƻ.Abort){z("Off","EFC");z("Abort",
"NavOS");}if(ï.ø>0){z("Set Burn "+ï.ø,"EFC");z("Thrust Set "+ï.ø/100,"NavOS");}if(ï.ö==ƚ.On)z("Boost On","EFC");else if(ï.ö==ƚ.
Off)z("Boost Off","EFC");if(ɺ)Echo("Finished setting stance.");}double ë=0;double Û=0;double Ú=0;double Ù=0;void Ø(){Ú=0;ë=
0;foreach(IMyGasTank Ï in ϕ){if(Ï.IsFunctional){Ï.Enabled=true;ë+=Ï.Capacity;Ú+=(Ï.Capacity*Ï.FilledRatio);}}Ù=Math.Round
(100*(ë/Û));}void Ö(){Û=0;foreach(IMyGasTank Ï in ϕ){if(Ï!=null)Û+=Ï.Capacity;}}void Õ(ǉ e){if(e==ǉ.NoChange)return;
foreach(IMyGasTank Ï in ϕ){if(Ï==null)continue;Ï.Enabled=true;if(e==ǉ.StockpileRecharge)Ï.Stockpile=true;else Ï.Stockpile=false
;}}double Ó=0;double Ò=0;double Ñ=0;double Ð=0;void Ô(){Ò=0;Ó=0;foreach(IMyGasTank Ï in ϔ){if(Ï.IsFunctional){Ï.Enabled=
true;Ó+=Ï.Capacity;Ò+=(Ï.Capacity*Ï.FilledRatio);}}Ð=Math.Round(100*(Ó/Ñ));}void Ý(){Ñ=0;foreach(IMyGasTank Ï in ϔ){if(Ï!=
null)Ñ+=Ï.Capacity;}}void ê(ǉ e){if(e==ǉ.NoChange)return;foreach(IMyGasTank Ï in ϔ){if(Ï==null)continue;Ï.Enabled=true;if(e
==ǉ.StockpileRecharge)Ï.Stockpile=true;else Ï.Stockpile=false;}}float é;float è;float ç;double æ;void å(){float ä=0;float
ã=0;float â=0;float á=0;foreach(IMyThrust ß in ό){if(ß!=null&&ß.IsFunctional){ä+=ß.MaxThrust;â+=ß.CurrentThrust;if(ß.
Enabled){ã+=ß.MaxThrust;á+=ß.CurrentThrust;}}}æ=Math.Round(100*(ä/ç));if(ã==0){é=ä;è=â;}else{é=ã;è=á;}}void à(){ç=0;foreach(
IMyThrust ß in ό){if(ß!=null)ç+=ß.MaxThrust;}}void Á(ǌ e,ǎ ƫ){if(e==ǌ.NoChange)return;foreach(IMyThrust ß in ό){ǽ(ß,e,ƫ);}foreach
(IMyThrust ß in ϊ){ǽ(ß,e,ƫ,true);}}void ǽ(IMyThrust ß,ǌ e,ǎ ƫ,bool Ǽ=false){bool Ǿ=ß.CustomName.Contains(ʨ);if(Ǿ){if(ƫ!=ǎ
.Off&&ƫ!=ǎ.AtmoOnly)ß.Enabled=true;else ß.Enabled=false;}else{bool ǻ=ß.CustomName.Contains(ʩ);if((e==ǌ.On)||(e==ǌ.Minimum
&&ǻ)||(e==ǌ.EpsteinOnly&&!Ǽ)||(e==ǌ.ChemOnly&&Ǽ)){ß.Enabled=true;}else{ß.Enabled=false;}}}float Ǻ;float ǹ;double Ǹ;void Ƿ(
){Ǻ=0;foreach(IMyThrust ß in ϋ){if(ß!=null&&ß.IsFunctional){Ǻ+=ß.MaxThrust;}}Ǹ=Math.Round(100*(Ǻ/ǹ));}void Ƕ(){ǹ=0;
foreach(IMyThrust ß in ϋ){if(ß!=null)ǹ+=ß.MaxThrust;}}void ǵ(ǎ e){foreach(IMyThrust ß in ϋ){if(ß!=null)ȉ(ß,e);}foreach(
IMyThrust ß in ω){if(ß!=null)ȉ(ß,e,true);}}void ȉ(IMyThrust ß,ǎ e,bool Ȉ=false){bool ȇ=ß.GridThrustDirection==Vector3I.Backward;
bool Ȇ=ß.GridThrustDirection==Vector3I.Forward;if((e==ǎ.On)||(e==ǎ.ForwardOff&&!ȇ)||(e==ǎ.ReverseOff&&!Ȇ)||(e==ǎ.RcsOnly&&!Ȉ
)||(e==ǎ.AtmoOnly&&Ȉ)){ß.Enabled=true;}else{ß.Enabled=false;}}int ȅ=0;double Ȅ=0;double ȃ=0;void Ȃ(){Ȅ=0;foreach(
IMyTerminalBlock ȁ in ύ){if(ȁ!=null&&ȁ.IsFunctional){Ȅ++;(ȁ as IMyConveyorSorter).Enabled=ï.W==ƚ.On;if(ʔ){string Ȁ=Ǵ.ư(ȁ,0);int ğ=ϧ(Ȁ);
if(ɺ)Echo("Launcher "+ȁ.CustomName+" needs "+Ȁ+"("+ğ+")");Ϡ(ȁ,ğ);}}}ȃ=Math.Round(100*(Ȅ/ȅ));}void ǿ(ƚ e){if(e==ƚ.NoChange)
return;foreach(IMyTerminalBlock ȁ in ύ){if(ȁ!=null&ȁ.IsFunctional){if(e==ƚ.Off){(ȁ as IMyConveyorSorter).Enabled=false;}else{(
ȁ as IMyConveyorSorter).Enabled=true;if(ʒ){ȁ.SetValue("WC_FocusFire",true);ȁ.SetValue("WC_Grids",true);ȁ.SetValue(
"WC_LargeGrid",true);ȁ.SetValue("WC_SmallGrid",false);ȁ.SetValue("WC_FocusFire",true);ȁ.SetValue("WC_SubSystems",true);Ɉ(ȁ);}}}}}ǲ Ǵ;
class ǲ{private Action<ICollection<MyDefinitionId>>Ǟ;private Action<ICollection<MyDefinitionId>>ǝ;private Action<ICollection<
MyDefinitionId>>ǜ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>Ǜ;private Func<long,MyTuple<bool,
int,int>>ǚ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>Ǚ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>ǟ;private Func<long,int,
MyDetectedEntityInfo>ǘ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǖ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>Ǖ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>ǔ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>Ǔ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>ǒ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>Ǒ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ǘ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>ǐ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>ǡ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǳ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>Ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ǰ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǯ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>Ǯ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>Ǭ;private Func<MyDefinitionId,float>ǫ;private Func<long,bool>Ǫ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>ǩ;private Func<long,float>Ǩ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ǧ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>ǥ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>Ǥ;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>ǣ;private Func<long,float>Ǡ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ǣ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȋ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ȫ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>Ȫ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>ȩ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>Ȩ;public bool ȧ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȧ){var ȥ=Ȧ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(Ȧ);if(ȥ==null)throw new Exception("WcPbAPI failed to activate");return Ȥ(ȥ);}public bool Ȥ
(IReadOnlyDictionary<string,Delegate>ȡ){if(ȡ==null)return false;ȣ(ȡ,"GetCoreWeapons",ref Ǟ);ȣ(ȡ,"GetCoreStaticLaunchers",
ref ǝ);ȣ(ȡ,"GetCoreTurrets",ref ǜ);ȣ(ȡ,"GetBlockWeaponMap",ref Ǜ);ȣ(ȡ,"GetProjectilesLockedOn",ref ǚ);ȣ(ȡ,
"GetSortedThreats",ref Ǚ);ȣ(ȡ,"GetObstructions",ref ǟ);ȣ(ȡ,"GetAiFocus",ref ǘ);ȣ(ȡ,"SetAiFocus",ref ǖ);ȣ(ȡ,"GetWeaponTarget",ref Ǖ);ȣ(ȡ,
"SetWeaponTarget",ref ǔ);ȣ(ȡ,"FireWeaponOnce",ref Ǔ);ȣ(ȡ,"ToggleWeaponFire",ref ǒ);ȣ(ȡ,"IsWeaponReadyToFire",ref Ǒ);ȣ(ȡ,
"GetMaxWeaponRange",ref Ǘ);ȣ(ȡ,"GetTurretTargetTypes",ref ǐ);ȣ(ȡ,"SetTurretTargetTypes",ref ǡ);ȣ(ȡ,"SetBlockTrackingRange",ref ǳ);ȣ(ȡ,
"IsTargetAligned",ref Ǳ);ȣ(ȡ,"IsTargetAlignedExtended",ref ǰ);ȣ(ȡ,"CanShootTarget",ref ǯ);ȣ(ȡ,"GetPredictedTargetPosition",ref Ǯ);ȣ(ȡ,
"GetHeatLevel",ref ǭ);ȣ(ȡ,"GetCurrentPower",ref Ǭ);ȣ(ȡ,"GetMaxPower",ref ǫ);ȣ(ȡ,"HasGridAi",ref Ǫ);ȣ(ȡ,"HasCoreWeapon",ref ǩ);ȣ(ȡ,
"GetOptimalDps",ref Ǩ);ȣ(ȡ,"GetActiveAmmo",ref ǧ);ȣ(ȡ,"SetActiveAmmo",ref Ǧ);ȣ(ȡ,"MonitorProjectile",ref ǥ);ȣ(ȡ,"UnMonitorProjectile",
ref Ǥ);ȣ(ȡ,"GetProjectileState",ref ǣ);ȣ(ȡ,"GetConstructEffectiveDps",ref Ǡ);ȣ(ȡ,"GetPlayerController",ref Ǣ);ȣ(ȡ,
"GetWeaponAzimuthMatrix",ref Ȋ);ȣ(ȡ,"GetWeaponElevationMatrix",ref ȫ);ȣ(ȡ,"IsTargetValid",ref Ȫ);ȣ(ȡ,"GetWeaponScope",ref ȩ);ȣ(ȡ,"IsInRange",ref
Ȩ);return true;}private void ȣ<Ȣ>(IReadOnlyDictionary<string,Delegate>ȡ,string Ƞ,ref Ȣ ȟ)where Ȣ:class{if(ȡ==null){ȟ=null
;return;}Delegate Ȟ;if(!ȡ.TryGetValue(Ƞ,out Ȟ))throw new Exception(
$"{GetType().Name} :: Couldn't find {Ƞ} delegate of type {typeof(Ȣ)}");ȟ=Ȟ as Ȣ;if(ȟ==null)throw new Exception(
$"{GetType().Name} :: Delegate {Ƞ} is not type {typeof(Ȣ)}, instead it's: {Ȟ.GetType()}");}public void ȝ(ICollection<MyDefinitionId>Ȕ)=>Ǟ?.Invoke(Ȕ);public void Ȭ(ICollection<MyDefinitionId>Ȕ)=>ǝ?.Invoke(Ȕ);
public void ȶ(ICollection<MyDefinitionId>Ȕ)=>ǜ?.Invoke(Ȕ);public bool ȵ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȴ,IDictionary<
string,int>Ȕ)=>Ǜ?.Invoke(ȴ,Ȕ)??false;public MyTuple<bool,int,int>ȳ(long Ȳ)=>ǚ?.Invoke(Ȳ)??new MyTuple<bool,int,int>();public
void ȱ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ț,IDictionary<MyDetectedEntityInfo,float>Ȕ)=>Ǚ?.Invoke(ț,Ȕ);public void Ȱ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ț,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ȕ)=>ǟ?.Invoke(ț,Ȕ);public
MyDetectedEntityInfo?ȯ(long Ȯ,int Ț=0)=>ǘ?.Invoke(Ȯ,Ț);public bool ȭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ț,long ȏ,int Ț=0)=>ǖ?.Invoke(ț,ȏ
,Ț)??false;public MyDetectedEntityInfo?ȑ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ=0)=>Ǖ?.Invoke(Ɛ,Ǝ);public void Ȑ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,long ȏ,int Ǝ=0)=>ǔ?.Invoke(Ɛ,ȏ,Ǝ);public void Ȏ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Ɛ,bool ȍ=true,int Ǝ=0)=>Ǔ?.Invoke(Ɛ,ȍ,Ǝ);public void Ȍ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,bool ȋ,bool ȍ,int Ǝ=0)=>ǒ
?.Invoke(Ɛ,ȋ,ȍ,Ǝ);public bool Ȓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ=0,bool ș=true,bool Ș=false)=>Ǒ?.Invoke(Ɛ,Ǝ
,ș,Ș)??false;public float ȗ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ)=>Ǘ?.Invoke(Ɛ,Ǝ)??0f;public bool Ȗ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ɛ,IList<string>Ȕ,int Ǝ=0)=>ǐ?.Invoke(Ɛ,Ȕ,Ǝ)??false;public void ȕ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɛ,IList<string>Ȕ,int Ǝ=0)=>ǡ?.Invoke(Ɛ,Ȕ,Ǝ);public void ȓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,float Ȝ)=>ǳ?.Invoke(
Ɛ,Ȝ);public bool Ǐ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,long Ʀ,int Ǝ)=>Ǳ?.Invoke(Ɛ,Ʀ,Ǝ)??false;public MyTuple<bool,
Vector3D?>Ʃ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,long Ʀ,int Ǝ)=>ǰ?.Invoke(Ɛ,Ʀ,Ǝ)??new MyTuple<bool,Vector3D?>();public bool
ƪ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,long Ʀ,int Ǝ)=>ǯ?.Invoke(Ɛ,Ʀ,Ǝ)??false;public Vector3D?Ƨ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Ɛ,long Ʀ,int Ǝ)=>Ǯ?.Invoke(Ɛ,Ʀ,Ǝ)??null;public float ƨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ)=>ǭ?.
Invoke(Ɛ)??0f;public float Ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ)=>Ǭ?.Invoke(Ɛ)??0f;public float Ƶ(MyDefinitionId ƴ)=>ǫ?.
Invoke(ƴ)??0f;public bool Ƴ(long Ɠ)=>Ǫ?.Invoke(Ɠ)??false;public bool Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ)=>ǩ?.Invoke(Ɛ)
??false;public float Ʊ(long Ɠ)=>Ǩ?.Invoke(Ɠ)??0f;public string ư(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ)=>ǧ?.
Invoke(Ɛ,Ǝ)??null;public void Ư(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ,string Ʈ)=>Ǧ?.Invoke(Ɛ,Ǝ,Ʈ);public void ƭ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ,Action<long,int,ulong,long,Vector3D,bool>Ɩ)=>ǥ?.Invoke(Ɛ,Ǝ,Ɩ);public void Ɨ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ,Action<long,int,ulong,long,Vector3D,bool>Ɩ)=>Ǥ?.Invoke(Ɛ,Ǝ,Ɩ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>ƕ(ulong Ɣ)=>ǣ?.Invoke(Ɣ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float Ƙ(long Ɠ)=>Ǡ?.Invoke(Ɠ)??0f;public long ƒ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ)=>Ǣ?.Invoke(Ɛ)??-1;public
Matrix Ƒ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ)=>Ȋ?.Invoke(Ɛ,Ǝ)??Matrix.Zero;public Matrix Ə(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɛ,int Ǝ)=>ȫ?.Invoke(Ɛ,Ǝ)??Matrix.Zero;public bool ƙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,long ƥ,bool Ƥ,bool ƣ)=>Ȫ?.
Invoke(Ɛ,ƥ,Ƥ,ƣ)??false;public MyTuple<Vector3D,Vector3D>Ƣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɛ,int Ǝ)=>ȩ?.Invoke(Ɛ,Ǝ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>ơ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ơ)=>Ȩ?.Invoke(Ơ)??new MyTuple<
bool,bool>();}int Ɵ=0;double ƞ=0;double Ɲ=0;void Ɯ(){ƞ=0;foreach(IMyTerminalBlock ƛ in ϒ){if(ƛ!=null&&ƛ.IsFunctional)ƞ++;}Ɲ=
Math.Round(100*(ƞ/Ɵ));}enum ƚ{
    Off, On, NoChange
    }enum ƶ{
    Off, On, NoChange, OnNoColourChange
    }enum ǋ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum Ǌ{
    Off, HoldFire, OpenFire, NoChange
    }enum ǌ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum ǎ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum Ǎ{
    On, Off, OnMax, NoChange
    }enum ǉ{
    Auto, StockpileRecharge, Discharge, NoChange
    }enum ƻ{
    Abort, NoChange
    }enum ƺ{
    Off, On, FillWhenLow, KeepFull,
    }enum Ƹ{
    Closed, Open, NoChange
    }
}sealed class ƹ{public double Ʒ{get;private set;}private double Ƽ{get{double ǈ=ǀ[0];for(int ę=1;ę<ǂ;ę++){ǈ+=ǀ[ę];}return(
ǈ/ǂ);}}public double Ǉ{get{double ǆ=ǀ[0];for(int ę=1;ę<ǂ;ę++){if(ǀ[ę]>ǆ){ǆ=ǀ[ę];}}return ǆ;}}public double ǅ{get;private
set;}public double Ǆ{get{double ǃ=ǀ[0];for(int ę=1;ę<ǂ;ę++){if(ǀ[ę]<ǃ){ǃ=ǀ[ę];}}return ǃ;}}public int ǂ{get;}private double
ǁ;private IMyGridProgramRuntimeInfo ƾ;private double[]ǀ;private int ƿ=0;public ƹ(IMyGridProgramRuntimeInfo ƾ,int ņ=300){
this.ƾ=ƾ;this.ǅ=ƾ.LastRunTimeMs;this.ǂ=MathHelper.Clamp(ņ,1,int.MaxValue);this.ǁ=1.0/ǂ;this.ǀ=new double[ņ];this.ǀ[ƿ]=ƾ.
LastRunTimeMs;this.ƿ++;}public void ƽ(){Ʒ-=ǀ[ƿ]*ǁ;Ʒ+=ƾ.LastRunTimeMs*ǁ;ǀ[ƿ]=ƾ.LastRunTimeMs;if(ƾ.LastRunTimeMs>ǅ){ǅ=ƾ.LastRunTimeMs;}
ƿ++;if(ƿ>=ǂ){ƿ=0;Ʒ=Ƽ;ǅ=ƾ.LastRunTimeMs;}}