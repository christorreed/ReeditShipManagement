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

string Version = "1.99.52 (2024-04-18)";
ǁ Β;int Α=0;int ΐ=0;int Ώ=0;int Ύ;int Ό=0;bool Ί=true;bool Ή=true;bool Έ=false;bool Ά=false;bool ͽ=false;bool ͼ=false;
bool ͻ=false;bool ͺ=false;bool Γ=false;bool Δ=false;int Σ=0;int Τ=0;double Ρ;float Π;string Ο;string Ξ;string Ν;bool Μ=false
;int Λ=0;int Κ=0;bool Ι;bool Θ;bool Η;Program(){Echo("Welcome to RSM\nV "+Version);ͳ();Ύ=ɽ;Ο=Me.GetOwnerFactionTag();Β=
new ǁ(Runtime);Ϲ();ʃ.Add(0.5);ʃ.Add(0.25);ʃ.Add(0.1);ʃ.Add(0.05);Ń();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo
("Took "+ͳ());}void Main(string n,UpdateType Ζ){if(Ζ==UpdateType.Update100)ˆ();else Ε(n);}void Ε(string n){if(ʀ)Echo(
"Processing command '"+n+"'...");if(Ή){ˈ(n,"RSM is still booting");return;}if(Έ){ˈ(n,"RSM is still initialising");return;}if(n==""){ˈ(n,
"the argument was blank");return;}string[]ͷ=n.Split(':');if(ͷ.Length<2){ˈ(n,"the argument wasn't recognised");return;}if(ͷ[0].ToLower()!="comms"
)ͷ[1]=ͷ[1].Replace(" ",string.Empty);switch(ͷ[0].ToLower()){case"init":bool ʽ=true,ˍ=true,ˌ=true;if(ͷ.Length>2){foreach(
string ˋ in ͷ){if(ˋ.ToLower()=="nonames")ʽ=false;else if(ˋ.ToLower()=="nosubs")ˍ=false;else if(ˋ.ToLower()=="noinv")ˌ=false;}}
ҡ(ͷ[1],ʽ,ˍ,ˌ);return;case"stance":Û(ͷ[1]);return;case"hudlcd":string ˊ="";if(ͷ.Length>2)ˊ=ͷ[2];Ƃ(ͷ[1],ˊ);return;case
"doors":string ˉ="";if(ͷ.Length>2)ˉ=ͷ[2];Ӏ(ͷ[1],ˉ);return;case"comms":ˣ(ͷ[1]);return;case"printblockids":ə();return;case
"printblockprops":ɕ(ͷ[1]);return;case"spawn":if(ͷ[1].ToLower()=="open"){ͻ=true;Ύ=ɽ;Щ.Add(new ё("Spawns were opened to friends",
"Spawns are now opened to the friends list as defined in PB custom data.",2));}else{ͻ=false;Ύ=ɽ;Щ.Add(new ё("Spawns were closed to friends",
"Spawns are now closed to the friends list as defined in PB custom data.",2));}return;case"projectors":if(ͷ[1].ToLower()=="save"){foreach(IMyProjector h in ϝ)N(h);Щ.Add(new ё(
"Projector positions saved","Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector h in ϝ)k(h);Щ.
Add(new ё("Projector positions loaded","Projector positions were loaded from custom data.",2));return;}default:ˈ(n,
"the argument wasn't recognised");return;}}void ˈ(string n,string ˇ){Щ.Add(new ё("COMMAND FAILED!","Command '"+n+"' was ignored because "+ˇ,3));}void ˆ(
){if(ɿ)ͳ();if(ΐ<ɾ){ΐ++;return;}ΐ=0;if(Ί){Echo("Parsing custom data...");Ѥ();Ί=false;return;}else if(Έ){Ћ();if(ʀ)Echo(
"Updating "+Ω.Count+" RSM Lcds");ļ();}ˏ();Λ=Runtime.CurrentInstructionCount;if(Λ>Κ)Κ=Runtime.CurrentInstructionCount;if(Đ.Ē==Ɵ.On){
Ά=true;ͽ=true;}else if(Đ.Ē==Ɵ.Off){Ά=true;}if(Ύ>=ɽ){Ύ=0;ʾ();return;}Ύ++;ˁ();ˀ();if(ɿ)Echo("Took "+ͳ());if(ʀ)Echo(
"Updating "+Ω.Count+" RSM Lcds");ļ();if(ɿ)Echo("Took "+ͳ());}void ˁ(){ˎ();switch(Α){case 0:if(ʀ)Echo("Refreshing "+γ.Count+
" railguns...");U();if(ɿ)Echo("Took "+ͳ());if(Ή)break;else goto case 1;case 1:if(ʀ)Echo("Refreshing "+Ϝ.Count+" reactors & "+Ϧ.Count+
" batteries...");Ã(Đ.ò);if(ɿ)Echo("Took "+ͳ());if(Ή)break;else goto case 2;case 2:if(ʀ)Echo("Refreshing "+α.Count+" epsteins...");á();
if(ɿ)Echo("Took "+ͳ());if(Ή)break;else goto case 3;case 3:if(ʀ)Echo("Refreshing "+Φ.Count+" lidars...");Š(ͽ,Ά);if(ɿ)Echo(
"Took "+ͳ());if(ʀ)Echo("Refreshing pb servers...");À();if(ɿ)Echo("Took "+ͳ());if(Ή)break;else goto case 4;case 4:if(ʀ)Echo(
"Refreshing "+φ.Count+" doors...");Ӄ();if(ɿ)Echo("Took "+ͳ());if(ʀ)Echo("Refreshing "+υ.Count+" airlocks...");Ҽ();if(ɿ)Echo("Took "+ͳ
());break;default:if(ʀ)Echo("Booting complete");Ή=false;Α=0;return;}if(Ή)Α++;}void ˀ(){switch(Ώ){case 0:if(ʀ)Echo(
"Clearing temp inventories...");ϸ();if(ɿ)Echo("Took "+ͳ());if(ʀ)Echo("Refreshing "+β.Count+" torpedo launchers...");Ȇ();if(ɿ)Echo("Took "+ͳ());if(ʀ)
Echo("Refreshing items...");Ϸ();if(ɿ)Echo("Took "+ͳ());break;case 1:if(ʀ)Echo("Running autoload...");ˑ();if(ɿ)Echo("Took "+ͳ
());break;case 2:if(ʀ)Echo("Refreshing "+ϙ.Count+" H2 tanks...");Ó();if(ɿ)Echo("Took "+ͳ());if(ʀ)Echo(
"Refreshing refuel status...");ґ();if(ͼ){if(ʀ)Echo("Fuel low, filling extractors...");ҩ();if(ɿ)Echo("Took "+ͳ());return;}else{ʿ();if(ɿ)Echo("Took "+ͳ
());}Ώ=0;return;}Ώ++;}void ʿ(){if(ʀ)Echo("Refreshing "+ΰ.Count+" rcs...");Ȑ();if(ʀ)Echo("Refreshing "+ε.Count+" Pdcs & "+
δ.Count+" defensive Pdcs...");Ê();if(ʀ)Echo("Refreshing "+Ϟ.Count+" gyros...");ң(ͽ,Ά);if(ʀ)Echo("Refreshing "+Ϙ.Count+
" O2 tanks...");è();if(ʀ)Echo("Refreshing "+ϧ.Count+" antennas...");ˤ();if(ʀ)Echo("Refreshing "+Ϥ.Count+" cargos...");ʠ();if(ʀ)Echo(
"Refreshing "+ϊ.Count+" vents...");ů(ͽ,Ά);if(ʀ)Echo("Refreshing "+ψ.Count+" auxiliary blocks...");ϋ();if(ʀ)Echo("Refreshing "+ω.Count
+" welders...");ơ();if(ʀ)Echo("Refreshing "+Ϋ.Count+" lcds...");Ɔ();if(ʀ)Echo("Refreshing "+Ϛ.Count+" lcds...");ª();if(Ά)
{if(ʀ)Echo("Refreshing "+ϣ.Count+" connectors...");ŭ(ͽ);if(ʀ)Echo("Refreshing "+ϥ.Count+" cameras...");ū(ͽ);if(ʀ)Echo(
"Refreshing "+ϛ.Count+" sensors...");º(ͽ);}}void ʾ(){if(ʀ)Echo("Clearing block lists...");ɬ();if(ɿ)Echo("Took "+ͳ());if(ʀ)Echo(
"Refreshing block lists...");GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,σ);if(ɿ)Echo("Took "+ͳ());if(ʀ)Echo(
"Setting KeepFull threshold");Ғ();if(Ϩ==null){if(Ϣ.Count>0)Ϩ=Ϣ[0];else Щ.Add(new ё("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ʀ)Echo("Finished block refresh.");if(ɿ)Echo("Took "+ͳ());}void ˎ(){try{ǣ=new Ǣ();ǣ.Ȭ(Me);}catch(Exception ex){ǣ
=null;Щ.Add(new ё("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ˏ(){string ʹ="REEDIT SHIP MANAGEMENT \n\n|- V "+Version+"\n|- Ship Name: "+ʌ+"\n|- Stance: "+đ+
"\n|- Step: "+Ύ+"/"+ɽ+" ("+Ώ+")";if(Ή)ʹ+="\n|- Booting "+Α;if(ɿ){Β.ǃ();ʹ+="\n|- Runtime Av/Tick: "+(Math.Round(Β.ǂ,2)/100)+" ms"+
"\n|- Runtime Max: "+Math.Round(Β.Ǎ,4)+" ms"+"\n|- Instructions: "+Λ+" ("+Κ+")";}Echo(ʹ+"\n");}long Ͷ=0;string ͳ(){long Ͳ=DateTime.Now.Ticks
/TimeSpan.TicksPerMillisecond;if(Ͷ==0){Ͷ=Ͳ;return"0 ms";}long ͱ=Ͳ-Ͷ;Ͷ=Ͳ;return ͱ+" ms";}bool Ͱ=false;string ˮ="";double ˬ
=0;void ˤ(){Ͱ=false;ˬ=0;foreach(IMyRadioAntenna ˡ in ϧ){if(ˡ!=null){if(ˡ.IsFunctional){float Ƴ=ˡ.Radius;if(Ƴ>ˬ)ˬ=Ƴ;if(ˡ.
IsBroadcasting&&ˡ.Enabled)Ͱ=true;}}}}void ˣ(string ˢ){ˮ=ˢ;foreach(IMyTerminalBlock ɔ in ϧ){IMyRadioAntenna ˡ=ɔ as IMyRadioAntenna;if(ˡ
!=null)ˡ.HudText=ˢ;}}List<string>ˠ=new List<string>();void ˑ(){if(!ʻ)return;ˠ.Clear();foreach(var Ģ in ϭ){if(!Ģ.ϲ&&!Ģ.ϱ)
continue;if(ʀ)Echo("Checking "+Ģ.ϯ);List<Д>Υ=Ģ.Ϫ.Concat(Ģ.ϴ).ToList();List<Д>η=new List<Д>();List<Д>ϗ=new List<Д>();List<Д>ϕ=new
List<Д>();List<Д>ϔ=new List<Д>();List<Д>ϓ=new List<Д>();int ϒ=0;int ϑ=0;bool ϐ=false;double Ϗ=.97;if(Ģ.Ϯ<1)Ϗ=Ģ.Ϯ*.97;foreach
(Д ώ in Υ){if(ώ==null)continue;if(ώ.Б){ϑ++;ϒ+=ώ.В;if(ʀ)Echo("Inv.FillFactor = "+ώ.А+"\ntargetFillFactor = "+Ϗ);if(ώ.А<Ϗ)ϕ
.Add(ώ);else if(Ģ.Ϯ<1&&ώ.А>Ģ.Ϯ*1.03)ϔ.Add(ώ);if(ώ.А!=0)ϗ.Add(ώ);else if(!ϐ&&Ģ.Ͼ==0)ϐ=true;}else{ϓ.Add(ώ);if(ώ.В>0){η.Add(
ώ);}}}if(ϐ)ˠ.Add(Ģ.ϰ);if(ϕ.Count>0){int ύ=(int)(ϒ/ϑ);ϕ=ϕ.OrderBy(ĸ=>ĸ.В).ToList();if(Ģ.Ͼ>0){if(ʀ)Echo("Loading "+Ģ.ϳ.
SubtypeId+"...");η=η.OrderByDescending(ĸ=>ĸ.В).ToList();ш(η,ϕ,Ģ.ϳ,-1,Ģ.Ϯ);}else{if(ʀ)Echo("Balancing "+Ģ.ϳ.SubtypeId+"...");ϗ=ϗ.
OrderByDescending(ĸ=>ĸ.В).ToList();ш(ϗ,ϕ,Ģ.ϳ,ύ);}}else if(ϔ.Count>0){if(ʀ)Echo("Unloading "+Ģ.ϳ.SubtypeId+"...");List<Д>ό=new List<Д>();
if(η.Count>0)ό=η;else ό=ϓ;ш(ϔ,ό,Ģ.ϳ,-1,1,Ģ.Ϯ);}else{if(ʀ)Echo("No loading required "+Ģ.ϳ.SubtypeId+"...");}}}void ϋ(){Τ=0;
foreach(IMyTerminalBlock ɔ in ψ){if(ɔ==null)continue;if(ɔ.IsWorking)Τ++;}}void ϖ(Ɵ L){if(L==Ɵ.NoChange)return;foreach(
IMyTerminalBlock ɔ in ψ){if(ɔ==null)continue;try{if(L==Ɵ.Off)ɔ.ApplyAction("OnOff_Off");else ɔ.ApplyAction("OnOff_On");}catch{if(ʀ)Echo(
"Failed to set aux block "+ɔ.CustomName);}}}IMyShipController Ϩ;List<IMyRadioAntenna>ϧ=new List<IMyRadioAntenna>();List<IMyBatteryBlock>Ϧ=new List
<IMyBatteryBlock>();List<IMyCameraBlock>ϥ=new List<IMyCameraBlock>();List<IMyCargoContainer>Ϥ=new List<IMyCargoContainer>
();List<IMyShipConnector>ϣ=new List<IMyShipConnector>();List<IMyShipController>Ϣ=new List<IMyShipController>();List<
IMyAirtightHangarDoor>ϡ=new List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>Ϡ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ϟ=new
List<IMyTerminalBlock>();List<IMyGyro>Ϟ=new List<IMyGyro>();List<IMyProjector>ϝ=new List<IMyProjector>();List<IMyReactor>Ϝ=
new List<IMyReactor>();List<IMySensorBlock>ϛ=new List<IMySensorBlock>();List<IMyTerminalBlock>Ϛ=new List<IMyTerminalBlock>(
);List<IMyGasTank>ϙ=new List<IMyGasTank>();List<IMyGasTank>Ϙ=new List<IMyGasTank>();List<IMyAirVent>ϊ=new List<IMyAirVent
>();List<IMyTerminalBlock>ω=new List<IMyTerminalBlock>();List<IMyConveyorSorter>Φ=new List<IMyConveyorSorter>();List<
IMyTerminalBlock>ε=new List<IMyTerminalBlock>();List<IMyTerminalBlock>δ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>γ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>β=new List<IMyTerminalBlock>();List<IMyThrust>α=new List<IMyThrust>();List<IMyThrust>ΰ=new
List<IMyThrust>();List<IMyThrust>ί=new List<IMyThrust>();List<IMyThrust>ή=new List<IMyThrust>();List<IMyProgrammableBlock>έ=
new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>ά=new List<IMyProgrammableBlock>();List<IMyTextPanel>Ϋ=new List<
IMyTextPanel>();List<IMyTextPanel>Ϊ=new List<IMyTextPanel>();List<ћ>Ω=new List<ћ>();List<IMyLightingBlock>Ψ=new List<
IMyLightingBlock>();List<IMyLightingBlock>Χ=new List<IMyLightingBlock>();List<IMyLightingBlock>ζ=new List<IMyLightingBlock>();List<
IMyLightingBlock>θ=new List<IMyLightingBlock>();List<IMyReflectorLight>χ=new List<IMyReflectorLight>();List<IMyTerminalBlock>ψ=new List<
IMyTerminalBlock>();List<ѧ>φ=new List<ѧ>();List<Ҹ>υ=new List<Ҹ>();Dictionary<IMyTerminalBlock,string>τ=new Dictionary<IMyTerminalBlock,
string>();bool σ(IMyTerminalBlock Ɋ){try{if(!Me.IsSameConstructAs(Ɋ))return false;string ς=Ɋ.GetOwnerFactionTag();if(ς!=Ο&&ς!=
""){Echo("!"+ς+": "+Ɋ.CustomName);Σ++;return false;}if(Ɋ.CustomName.Contains(ʰ))return false;if(!Έ&&ʺ&&!Ɋ.CustomName.
Contains(ʌ))return false;if(Ɋ.CustomName.Contains(ʭ))ψ.Add(Ɋ);string ρ=Ɋ.BlockDefinition.ToString();if(ρ.Contains("MedicalRoom/"
)){if(ͻ)Ɋ.CustomData=Ν;else Ɋ.CustomData=Ξ;Ϛ.Add(Ɋ);if(Έ)τ.Add(Ɋ,"Medical Room");return false;}if(ρ.Contains(
"SurvivalKit/")){if(ͻ)Ɋ.CustomData=Ν;else Ɋ.CustomData=Ξ;Ϛ.Add(Ɋ);if(Έ)τ.Add(Ɋ,"Survival Kit");return false;}if(ρ==
"MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Έ)τ.Add(Ɋ,"Refill Station");return false;}var π=Ɋ as IMyTextPanel;if(π!=null){Ϋ.Add(π);if(Έ)τ.Add(Ɋ,"LCD");if(π.
CustomName.Contains(ʯ)){ћ ο=new ћ();ο.ɔ=π;Ω.Add(ɇ(ο));}else if(!ʅ&&π.CustomName.Contains(ʮ))Ϊ.Add(π);return false;}if(ρ==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɫ(Ɋ,"Flak",3);if(ρ=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɫ(Ɋ,
"OPA",3);if(ρ=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɫ(Ɋ,"Voltaire",3);if(ρ.Contains
("Nariman Dynamics PDC"))return ɫ(Ɋ,"Nari",4);if(ρ.Contains("Redfields Ballistics PDC"))return ɫ(Ɋ,"Red",4);if(ρ.Contains
("OPA Shotgun PDC"))return ɫ(Ɋ,"Shotgun",4);if(ρ=="MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return Ɍ
(Ɋ,"Apollo");if(ρ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return Ɍ(Ɋ,"Tycho");if(ρ==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return Ɍ(Ɋ,"Zeus");if(ρ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return Ɍ(Ɋ,"Tycho");if(ρ.Contains(
"Ares_Class"))return Ɍ(Ɋ,"Ares");if(ρ.Contains("Artemis_Torpedo_Tube"))return Ɍ(Ɋ,"Artemis");if(ρ==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return ɋ(Ɋ,"Dawson",11);if(ρ=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return ɋ(Ɋ,"Stiletto",12);if
(ρ=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return ɋ(Ɋ,"Roci",13);if(ρ==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return ɋ(Ɋ,"Foehammer",14);if(ρ=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return ɋ(Ɋ,"Farren",15);
if(ρ.Contains("Zakosetara"))return ɋ(Ɋ,"Zako",10);if(ρ.Contains("Kess Hashari Cannon"))return ɋ(Ɋ,"Kess",16);if(ρ.Contains
("Coilgun"))return ɋ(Ɋ,"Coilgun",13);if(ρ.Contains("Glapion"))return ɋ(Ɋ,"Glapion",3);var ξ=Ɋ as IMyThrust;if(ξ!=null){if
(ρ.ToUpper().Contains("RCS")){ΰ.Add(ξ);if(Έ)τ.Add(Ɋ,"RCS");}else if(ρ.Contains("Hydro")){ί.Add(ξ);if(Έ)τ.Add(Ɋ,"Chem");}
else if(ρ.Contains("Atmospheric")){ή.Add(ξ);if(Έ)τ.Add(Ɋ,"Atmo");}else{α.Add(ξ);if(Έ){string ɂ="";if(ʈ){try{ɂ=Ɋ.
DefinitionDisplayNameText.Split('"')[1];ɂ=ʊ+ɂ[0].ToString().ToUpper()+ɂ.Substring(1).ToLower();}catch{if(ʀ)Echo("Failed to get drive type from "+
Ɋ.DefinitionDisplayNameText);}}τ.Add(Ɋ,"Epstein"+ɂ);}}return false;}var ν=Ɋ as IMyCargoContainer;if(ν!=null){string μ=ρ.
Split('/')[1];if(μ.Contains("Container")||μ.Contains("Cargo")){Ϥ.Add(ν);Ϭ(Ɋ);if(Έ){double λ=Ɋ.GetInventory().MaxVolume.
RawValue;double κ=Math.Round(λ/1265625024,1);if(κ==0)κ=0.1;τ.Add(Ɋ,"Cargo ["+κ+"]");}return false;}}var ι=Ɋ as IMyGyro;if(ι!=
null){Ϟ.Add(ι);if(Έ)τ.Add(Ɋ,"Gyroscope");return false;}var ː=Ɋ as IMyBatteryBlock;if(ː!=null){Ϧ.Add(ː);if(Έ)τ.Add(Ɋ,"Power"+
ʊ+"Battery");return false;}var ʼ=Ɋ as IMyReflectorLight;if(ʼ!=null){χ.Add(ʼ);if(Έ)τ.Add(Ɋ,"Spotlight");return false;}var
ɐ=Ɋ as IMyLightingBlock;if(ɐ!=null){if(Ɋ.CustomName.ToUpper().Contains("INTERIOR")||ρ.Contains("Kitchen")||ρ.Contains(
"Aquarium")){Χ.Add(ɐ);if(Έ)τ.Add(Ɋ,"Light"+ʊ+"Interior");}else if(Ɋ.CustomName.Contains(ʝ)){if(Ɋ.CustomName.ToUpper().Contains(
"STARBOARD")){θ.Add(ɐ);if(Έ)τ.Add(Ɋ,"Light"+ʊ+"Nav"+ʊ+"Starboard");}else{ζ.Add(ɐ);if(Έ)τ.Add(Ɋ,"Light"+ʊ+"Nav"+ʊ+"Port");}}else{Ψ.
Add(ɐ);if(Έ)τ.Add(Ɋ,"Light"+ʊ+"Exterior");}return false;}var ɨ=Ɋ as IMyGasTank;if(ɨ!=null){if(ρ.Contains("Hydro")){ϙ.Add(ɨ)
;if(Έ)τ.Add(Ɋ,"Tank"+ʊ+"Hydrogen");}else{Ϙ.Add(ɨ);if(Έ)τ.Add(Ɋ,"Tank"+ʊ+"Oxygen");}return false;}var ɧ=Ɋ as IMyReactor;if
(ɧ!=null){Ϝ.Add(ɧ);Ϭ(Ɋ,0);if(Έ){string ɦ="Lg";if(ρ.Contains("SmallGenerator"))ɦ="Sm";else if(ρ.Contains("MCRN"))ɦ="MCRN";
τ.Add(Ɋ,"Power"+ʊ+"Reactor"+ʊ+ɦ);}return false;}var ɥ=Ɋ as IMyShipController;if(ɥ!=null){Ϣ.Add(ɥ);if(Ϩ==null&&Ɋ.
CustomName.Contains("Nav"))Ϩ=ɥ;if(ɥ.HasInventory)Ϭ(Ɋ);if(Έ&&ρ.Contains("Cockpit/")){if(ρ.Contains("StandingCockpit")||ρ.Contains(
"Console")){τ.Add(Ɋ,"Console");return false;}else if(ρ.Contains("Cockpit")){τ.Add(Ɋ,"Cockpit");return false;}}}var ɤ=Ɋ as IMyDoor
;if(ɤ!=null){ѧ ɣ=new ѧ();ɣ.ɔ=ɤ;if(Ɋ.CustomName.Contains(ʜ)){try{string ɡ=Ɋ.CustomName.Split(ʊ)[3];ɣ.Һ=true;bool ɠ=false;
foreach(Ҹ ɟ in υ){if(ɡ==ɟ.ҷ){ɟ.ҳ.Add(ɣ);ɠ=true;break;}}if(!ɠ){Ҹ ɞ=new Ҹ();ɞ.ҷ=ɡ;ɞ.ҳ.Add(ɣ);υ.Add(ɞ);}}catch{if(ʀ)Echo(
"Error with airlock door name "+Ɋ.CustomName);φ.Add(ɣ);}}else{φ.Add(ɣ);}if(Έ)τ.Add(Ɋ,"Door");return false;}var ɢ=Ɋ as IMyAirVent;if(ɢ!=null){ϊ.Add(ɢ);
if(Ɋ.CustomName.Contains(ʜ)){try{string ɡ=Ɋ.CustomName.Split(ʊ)[3];bool ɠ=false;foreach(Ҹ ɟ in υ){if(ɡ==ɟ.ҷ){ɟ.Ҳ.Add(ɢ);ɠ=
true;break;}}if(!ɠ){Ҹ ɞ=new Ҹ();ɞ.ҷ=ɡ;ɞ.Ҳ.Add(ɢ);υ.Add(ɞ);}}catch{if(ʀ)Echo("Error with airlock vent name "+Ɋ.CustomName);}}
if(Έ)τ.Add(Ɋ,"Vent");return false;}var ɩ=Ɋ as IMyCameraBlock;if(ɩ!=null){ϥ.Add(ɩ);if(Έ)τ.Add(Ɋ,"Camera");return false;}var
ɪ=Ɋ as IMyShipConnector;if(ɪ!=null){ϣ.Add(ɪ);Ϭ(Ɋ);if(Έ){string ɹ="";if(ρ.Contains("Passageway"))ɹ=ʊ+"Passageway";τ.Add(Ɋ,
"Connector"+ɹ);}return false;}var ɺ=Ɋ as IMyAirtightHangarDoor;if(ɺ!=null){ϡ.Add(ɺ);if(Έ)τ.Add(Ɋ,"Door"+ʊ+"Hangar");return false;}
if(ρ.Contains("Lidar")){var ɸ=Ɋ as IMyConveyorSorter;if(ɸ!=null){Φ.Add(ɸ);if(Έ)τ.Add(Ɋ,"LiDAR");return false;}}if(ρ==
"MyObjectBuilder_OxygenGenerator/Extractor"){Ϡ.Add(Ɋ);if(Έ)τ.Add(Ɋ,"Extractor");return false;}if(ρ=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){ϟ.Add(Ɋ);if(Έ
)τ.Add(Ɋ,"Extractor");return false;}var ɷ=Ɋ as IMyRadioAntenna;if(ɷ!=null){ϧ.Add(ɷ);if(Έ)τ.Add(Ɋ,"Antenna");return false;
}var ɶ=Ɋ as IMyProgrammableBlock;if(ɶ!=null){if(Έ)τ.Add(Ɋ,"PB Server");if(ɶ==Me)return false;try{if(Ɋ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))έ.Add(ɶ);else if(Ɋ.CustomData.Contains("NavConfig"))ά.Add(ɶ);return false;}catch{}}var
ɵ=Ɋ as IMyProjector;if(ɵ!=null){ϝ.Add(ɵ);if(Έ)τ.Add(Ɋ,"Projectors");return false;}var ɴ=Ɋ as IMySensorBlock;if(ɴ!=null){ϛ
.Add(ɴ);if(Έ)τ.Add(Ɋ,"Sensor");return false;}var ɳ=Ɋ as IMyCollector;if(ɳ!=null){Ϭ(Ɋ);if(Έ)τ.Add(Ɋ,"Collector");return
false;}if(ρ.Contains("Welder")){ω.Add(Ɋ);if(Έ)τ.Add(Ɋ,"Tool"+ʊ+"Welder");return false;}if(Έ){if(ρ.Contains("LandingGear/")){
if(ρ.Contains("Clamp"))τ.Add(Ɋ,"Clamp");else if(ρ.Contains("Magnetic"))τ.Add(Ɋ,"Mag Lock");else τ.Add(Ɋ,"Gear");return
false;}if(ρ.Contains("Drill")){τ.Add(Ɋ,"Tool"+ʊ+"Drill");return false;}if(ρ.Contains("Grinder")){τ.Add(Ɋ,"Tool"+ʊ+"Grinder");
return false;}if(ρ.Contains("Solar")){τ.Add(Ɋ,"Solar");return false;}if(ρ.Contains("ButtonPanel")){τ.Add(Ɋ,"Button Panel");
return false;}var ɲ=Ɋ as IMyConveyorSorter;if(ɲ!=null){τ.Add(Ɋ,"Sorter");return false;}var ɱ=Ɋ as IMyMotorSuspension;if(ɱ!=
null){τ.Add(Ɋ,"Suspension");return false;}var ɰ=Ɋ as IMyGravityGenerator;if(ɰ!=null){τ.Add(Ɋ,"Grav Gen");return false;}var ɯ
=Ɋ as IMyTimerBlock;if(ɯ!=null){τ.Add(Ɋ,"Timer");return false;}var ɮ=Ɋ as IMyGasGenerator;if(ɮ!=null){τ.Add(Ɋ,"H2 Engine"
);return false;}var ɭ=Ɋ as IMyBeacon;if(ɭ!=null){τ.Add(Ɋ,"Beacon");return false;}τ.Add(Ɋ,Ɋ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ʀ){Echo("Failed to sort "+Ɋ.CustomName+"\nAdded "+τ.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɬ(){Ϩ=null;ϧ.Clear();Ϧ.Clear();ϥ.Clear();Ϥ.Clear();ϣ.Clear();Ϣ.Clear();φ.Clear();υ.Clear();ϡ.Clear();Ϡ.
Clear();ϟ.Clear();Ϟ.Clear();ϝ.Clear();Ϝ.Clear();ϛ.Clear();ϙ.Clear();Ϙ.Clear();ϊ.Clear();ω.Clear();Φ.Clear();ε.Clear();δ.Clear
();γ.Clear();β.Clear();α.Clear();ΰ.Clear();ί.Clear();ή.Clear();έ.Clear();ά.Clear();Ϋ.Clear();Ω.Clear();Ϊ.Clear();Ψ.Clear(
);Χ.Clear();ζ.Clear();θ.Clear();χ.Clear();ψ.Clear();foreach(var Ģ in ϭ)Ģ.Ϫ.Clear();if(Έ)τ.Clear();}bool ɫ(
IMyTerminalBlock Ɋ,string Ŕ,int ɉ){if(Ɋ.CustomName.Contains(ʬ))δ.Add(Ɋ);else ε.Add(Ɋ);Ϭ(Ɋ,ɉ);if(Έ){string ɂ="";if(ʉ)ɂ=ʊ+Ŕ;τ.Add(Ɋ,"PDC"+
ɂ);}return false;}bool Ɍ(IMyTerminalBlock Ɋ,string Ŕ){β.Add(Ɋ);if(Έ){string Ɉ="";if(ʉ)Ɉ=ʊ+Ŕ;τ.Add(Ɋ,"Torpedo"+Ɉ);}return
false;}bool ɋ(IMyTerminalBlock Ɋ,string Ŕ,int ɉ){γ.Add(Ɋ);Ϭ(Ɋ,ɉ);if(Έ){string Ɉ="";if(ʉ)Ɉ=ʊ+Ŕ;τ.Add(Ɋ,"Railgun"+Ɉ);}return
false;}ћ ɇ(ћ Ī,string Ɇ=""){bool Ʌ=Ɇ=="",Ʉ=!Ʌ;string Ƀ=Ī.ɔ.CustomData,ɍ="RSM.LCD";string[]ɏ=null;MyIni ɝ=new MyIni();
MyIniParseResult Ɖ;if(!Ʌ)Ʉ=true;else{if(Ƀ.Substring(0,12)=="Show Header="){try{ɏ=Ƀ.Split('\n');foreach(string ɜ in ɏ){if(ɜ.Contains(
"hud")){if(ɜ.Contains("lcd")){Ɇ=ɜ;break;}}else if(ɜ.Contains("=")){string[]ɛ=ɜ.Split('=');if(ɛ[0]=="Show Tanks & Batteries")Ī
.і=bool.Parse(ɛ[1]);else if(ɛ[0]=="Show header"||ɛ[0]=="Show Header")Ī.љ=bool.Parse(ɛ[1]);else if(ɛ[0]==
"Show Header Overlay")Ī.ј=bool.Parse(ɛ[1]);else if(ɛ[0]=="Show Warnings")Ī.ї=bool.Parse(ɛ[1]);else if(ɛ[0]=="Show Inventory")Ī.ѕ=bool.Parse(ɛ
[1]);else if(ɛ[0]=="Show Thrust")Ī.є=bool.Parse(ɛ[1]);else if(ɛ[0]=="Show Subsystem Integrity")Ī.ѓ=bool.Parse(ɛ[1]);else
if(ɛ[0]=="Show Advanced Thrust")Ī.ђ=bool.Parse(ɛ[1]);}}}catch(Exception ex){if(ʀ)Echo("Failed to parse legacy config.\n"+
ex.Message);Ʉ=true;}}else if(!ɝ.TryParse(Ƀ,out Ɖ)){Ʉ=true;}else{Ī.љ=ɝ.Get(ɍ,"ShowHeader").ToBoolean(Ī.љ);Ī.ј=ɝ.Get(ɍ,
"ShowHeaderOverlay").ToBoolean(Ī.ј);Ī.ї=ɝ.Get(ɍ,"ShowWarnings").ToBoolean(Ī.ї);Ī.і=ɝ.Get(ɍ,"ShowPowerAndTanks").ToBoolean(Ī.і);Ī.ѕ=ɝ.Get(ɍ,
"ShowInventory").ToBoolean(Ī.ѕ);Ī.є=ɝ.Get(ɍ,"ShowThrust").ToBoolean(Ī.є);Ī.ѓ=ɝ.Get(ɍ,"ShowIntegrity").ToBoolean(Ī.ѓ);Ī.ђ=ɝ.Get(ɍ,
"ShowAdvancedThrust").ToBoolean(Ī.ђ);}}if(Ī.љ&&Ī.ј){Ī.љ=false;Ʉ=true;}if(Ʉ){if(ɏ==null)ɏ=Ƀ.Split('\n');ɝ.Set(ɍ,"ShowHeader",Ī.љ);ɝ.Set(ɍ,
"ShowHeaderOverlay",Ī.ј);ɝ.Set(ɍ,"ShowWarnings",Ī.ї);ɝ.Set(ɍ,"ShowPowerAndTanks",Ī.і);ɝ.Set(ɍ,"ShowInventory",Ī.ѕ);ɝ.Set(ɍ,"ShowThrust",Ī.є
);ɝ.Set(ɍ,"ShowIntegrity",Ī.ѓ);ɝ.Set(ɍ,"ShowAdvancedThrust",Ī.ђ);ɝ.Set(ɍ,"Hud",Ɇ);Ī.ɔ.CustomData=ɝ.ToString();if(Ʌ)Щ.Add(
new ё("LCD CONFIG ERROR!!","Failed to parse LCD config for "+Ī.ɔ.CustomName+"!\nLCD config was reset!",3));}return Ī;}void
ɚ(IMyTerminalBlock ɔ,bool Ȭ){ɔ.GetActionWithName("ToolCore_Shoot_Action").Apply(ɔ);(ɔ as IMyConveyorSorter).
GetActionWithName("ToolCore_Shoot_Action").Apply(ɔ);}void ə(){List<IMyTerminalBlock>ɘ=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(ɘ);string ɗ="";foreach(IMyTerminalBlock ɖ in ɘ){ɗ+=ɖ.BlockDefinition+"\n";}if(ϧ.Count>0&&ϧ[0]!=null){
ϧ[0].CustomData=ɗ;}}void ɕ(string ȴ){IMyTerminalBlock ɔ=GridTerminalSystem.GetBlockWithName(ȴ);List<ITerminalAction>ɓ=new
List<ITerminalAction>();ɔ.GetActions(ɓ);List<ITerminalProperty>ɒ=new List<ITerminalProperty>();ɔ.GetProperties(ɒ);string ɑ=ɔ
.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction Ɏ in ɓ){ɑ+=Ɏ.Id+" "+Ɏ.Name+"\n";}ɑ+="\n\n**Properties**\n\n";
foreach(ITerminalProperty ɻ in ɒ){ɑ+=ɻ.Id+" "+ɻ.TypeName+"\n";}if(ϧ.Count>0&&ϧ[0]!=null)ϧ[0].CustomData=ɑ;ɔ.CustomData=ɑ;}void
ʍ(IMyTerminalBlock ƥ){bool ʧ=ƥ.GetValue<bool>("WC_Repel");if(!ʧ)ƥ.ApplyAction("WC_RepelMode");}void ʨ(IMyTerminalBlock ƥ)
{bool ʧ=ƥ.GetValue<bool>("WC_Repel");if(ʧ)ƥ.ApplyAction("WC_RepelMode");}void ʦ(IMyTerminalBlock ƥ){try{if(ǣ.Ɩ(ƥ,0)==
VRageMath.Matrix.Zero)return;ƥ.SetValue<Int64>("WC_Shoot Mode",3);if(ʀ)Echo("Shoot mode = "+ƥ.GetValue<Int64>("WC_Shoot Mode"));}
catch{Echo("Failed to set fire mode to manual on "+ƥ.CustomName);}}void ʥ(IMyTerminalBlock ƥ){try{if(ǣ.Ɩ(ƥ,0)==VRageMath.
Matrix.Zero)return;ƥ.SetValue<Int64>("WC_Shoot Mode",0);if(ʀ)Echo("Shoot mode = "+ƥ.GetValue<Int64>("WC_Shoot Mode"));}catch{
Echo("Failed to set fire mode to auto on "+ƥ.CustomName);}}void ʤ(){if(Ϩ!=null){try{Ρ=Ϩ.GetShipSpeed();Π=Ϩ.CalculateShipMass
().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo(exxie.Message);}}}double ʣ=0;double
ʢ=0;double ʡ=0;void ʠ(){ʢ=0;foreach(IMyCargoContainer ʟ in Ϥ){if(ʟ!=null&&ʟ.IsFunctional){ʢ+=ʟ.GetInventory().MaxVolume.
RawValue;}}ʡ=Math.Round(100*(ʢ/ʣ));}void ʞ(){ʣ=0;foreach(IMyCargoContainer ʟ in Ϥ){if(ʟ!=null)ʣ+=ʟ.GetInventory().MaxVolume.
RawValue;}}MyIni ʩ=new MyIni();bool ʺ=false;bool ʻ=true;bool ʹ=true;bool ʸ=true;bool ʷ=true;bool ʶ=true;bool ʵ=false;string ʴ=""
;bool ʳ=true;int ʲ=3;int ʱ=6;string ʰ="[I]";string ʯ="[RSM]";string ʮ="[CS]";string ʭ="Autorepair";string ʬ="Repel";
string ʫ="Min";string ʪ="Docking";string ʝ="Nav";string ʜ="Airlock";string ɼ="[EFC]";string ʋ="[NavOS]";char ʊ='.';bool ʉ=true
;bool ʈ=true;List<string>ʇ=new List<string>();bool ʆ=false;bool ʅ=false;bool ʄ=true;List<double>ʃ=new List<double>();bool
ʂ=false;double ʁ=0.5;bool ʀ=true;bool ɿ=false;int ɾ=0;int ɽ=100;string ʌ="";bool ʎ(){string Ƀ=Me.CustomData;string ɍ="";
bool ʛ=true;MyIniParseResult Ɖ;if(!ʩ.TryParse(Ƀ,out Ɖ)){string[]ʚ=Ƀ.Split('\n');if(ʚ[1]=="Reedit Ship Management"){Echo(
"Legacy config detected...");ҏ(Ƀ);return false;}else{Echo("Could not parse custom data!\n"+Ɖ.ToString());return false;}}try{ɍ="RSM.Main";Echo(ɍ);ʺ=
ʩ.Get(ɍ,"RequireShipName").ToBoolean(ʺ);ʻ=ʩ.Get(ɍ,"EnableAutoload").ToBoolean(ʻ);ʹ=ʩ.Get(ɍ,"AutoloadReactors").ToBoolean(
ʹ);ʸ=ʩ.Get(ɍ,"AutoConfigWeapons").ToBoolean(ʸ);ʷ=ʩ.Get(ɍ,"SetTurretFireMode").ToBoolean(ʷ);ʶ=ʩ.Get(ɍ,
"ManageBatteryDischarge").ToBoolean(ʶ);ɍ="RSM.Spawns";Echo(ɍ);ʵ=ʩ.Get(ɍ,"PrivateSpawns").ToBoolean(ʵ);ʴ=ʩ.Get(ɍ,"FriendlyTags").ToString(ʴ);ɍ=
"RSM.Doors";Echo(ɍ);ʳ=ʩ.Get(ɍ,"EnableDoorManagement").ToBoolean(ʳ);ʲ=ʩ.Get(ɍ,"DoorCloseTimer").ToInt32(ʲ);ʲ=ʩ.Get(ɍ,
"AirlockDoorDisableTimer").ToInt32(ʲ);ɍ="RSM.Keywords";Echo(ɍ);ʰ=ʩ.Get(ɍ,"Ignore").ToString(ʰ);ʯ=ʩ.Get(ɍ,"RsmLcds").ToString(ʯ);ʮ=ʩ.Get(ɍ,
"ColourSyncLcds").ToString(ʮ);ʭ=ʩ.Get(ɍ,"AuxiliaryBlocks").ToString(ʭ);ʬ=ʩ.Get(ɍ,"DefensivePdcs").ToString(ʬ);ʫ=ʩ.Get(ɍ,
"MinimumThrusters").ToString(ʫ);ʪ=ʩ.Get(ɍ,"DockingThrusters").ToString(ʪ);ʝ=ʩ.Get(ɍ,"NavLights").ToString(ʝ);ʜ=ʩ.Get(ɍ,"Airlock").ToString
(ʜ);ɍ="RSM.InitNaming";Echo(ɍ);ʊ=ʩ.Get(ɍ,"Ignore").ToChar(ʊ);ʉ=ʩ.Get(ɍ,"NameWeaponTypes").ToBoolean(ʉ);ʈ=ʩ.Get(ɍ,
"NameDriveTypes").ToBoolean(ʈ);string ʙ=ʩ.Get(ɍ,"BlocksToNumber").ToString("");string[]ʘ=ʙ.Split(',');ʇ.Clear();foreach(string ȴ in ʘ)if
(ȴ!="")ʇ.Add(ȴ);ɍ="RSM.Misc";Echo(ɍ);ʆ=ʩ.Get(ɍ,"DisableLightingControl").ToBoolean(ʆ);ʅ=ʩ.Get(ɍ,"DisableLcdColourControl"
).ToBoolean(ʅ);ʄ=ʩ.Get(ɍ,"ShowBasicTelemetry").ToBoolean(ʄ);string ʗ=ʩ.Get(ɍ,"DecelerationPercentages").ToString("");
string[]ʖ=ʗ.Split(',');if(ʖ.Length>1){ʃ.Clear();foreach(string ʕ in ʖ){ʃ.Add(double.Parse(ʕ)/100);}}ʂ=ʩ.Get(ɍ,
"ShowThrustInMetric").ToBoolean(ʂ);ʁ=ʩ.Get(ɍ,"ReactorFillRatio").ToDouble(ʁ);ϭ[0].Ϯ=ʁ;ɍ="RSM.Debug";Echo(ɍ);ʀ=ʩ.Get(ɍ,"VerboseDebugging").
ToBoolean(ʀ);ɿ=ʩ.Get(ɍ,"RuntimeProfiling").ToBoolean(ɿ);ɽ=ʩ.Get(ɍ,"BlockRefreshFreq").ToInt32(ɽ);ɾ=ʩ.Get(ɍ,"StallCount").ToInt32(
ɾ);ɍ="RSM.System";Echo(ɍ);ʌ=ʩ.Get(ɍ,"ShipName").ToString(ʌ);ɍ="RSM.InitItems";Echo(ɍ);foreach(Ģ ʔ in ϭ){ʔ.Ў=ʩ.Get(ɍ,ʔ.ϳ.
SubtypeId).ToInt32(ʔ.Ў);}ɍ="RSM.InitSubSystems";Echo(ɍ);F=ʩ.Get(ɍ,"Reactors").ToDouble(F);F=ʩ.Get(ɍ,"Batteries").ToDouble(F);Ì=ʩ.
Get(ɍ,"Pdcs").ToInt32(Ì);ȉ=ʩ.Get(ɍ,"TorpLaunchers").ToInt32(ȉ);Y=ʩ.Get(ɍ,"KineticWeapons").ToInt32(Y);Ö=ʩ.Get(ɍ,"H2Storage"
).ToDouble(Ö);ê=ʩ.Get(ɍ,"O2Storage").ToDouble(ê);ã=ʩ.Get(ɍ,"MainThrust").ToSingle(ã);Ȅ=ʩ.Get(ɍ,"RCSThrust").ToSingle(Ȅ);Ҧ
=ʩ.Get(ɍ,"Gyros").ToDouble(Ҧ);ʣ=ʩ.Get(ɍ,"CargoStorage").ToDouble(ʣ);Ƥ=ʩ.Get(ɍ,"Welders").ToInt32(Ƥ);}catch(Exception ex){
Ѯ(ex,"Failed to parse section\n"+ɍ);}Echo("Parsing stances...");Dictionary<string,O>ʓ=new Dictionary<string,O>();List<
string>ʒ=new List<string>();ʩ.GetSections(ʒ);foreach(string ʑ in ʒ){if(ʑ.Contains("RSM.Stance.")){string ʐ=ʑ.Substring(11);
Echo(ʐ);O Ù=new O();string ģ,ϩ="";string[]Ѝ;int Ѿ=33,ѽ=144,Ɋ=255,ĸ=255;bool Ѽ=false;O ѻ=null;ϩ="Inherits";if(ʩ.ContainsKey(ʑ
,ϩ)){Ѽ=true;try{ѻ=ʓ[ʩ.Get(ʑ,ϩ).ToString()];Echo("Inherits "+ʩ.Get(ʑ,ϩ).ToString());}catch(Exception ex){Ѯ(ex,
"Failed to find inheritee for\n"+ʑ+"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(Ѽ)Echo(ѻ.Ā.ToString());ϩ="Torps";if(ʩ.
ContainsKey(ʑ,ϩ)){Ù.Ā=(Ɵ)Enum.Parse(typeof(Ɵ),ʩ.Get(ʑ,ϩ).ToString());Echo("1");}else if(Ѽ){Ù.Ā=ѻ.Ā;Echo("2");}else{Ù.Ā=ď;Echo("3");
}ϩ="Pdcs";if(ʩ.ContainsKey(ʑ,ϩ))Ù.þ=(ǒ)Enum.Parse(typeof(ǒ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.þ=ѻ.þ;else Ù.þ=Ď;ϩ=
"Kinetics";if(ʩ.ContainsKey(ʑ,ϩ))Ù.ý=(Ǒ)Enum.Parse(typeof(Ǒ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ý=ѻ.ý;else Ù.ý=č;ϩ="MainThrust";if
(ʩ.ContainsKey(ʑ,ϩ))Ù.ü=(ǔ)Enum.Parse(typeof(ǔ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ü=ѻ.ü;else Ù.ü=Č;ϩ="ManeuveringThrust"
;if(ʩ.ContainsKey(ʑ,ϩ))Ù.û=(ǖ)Enum.Parse(typeof(ǖ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.û=ѻ.û;else Ù.û=ċ;ϩ="Spotlights";if(
ʩ.ContainsKey(ʑ,ϩ))Ù.ú=(Ǖ)Enum.Parse(typeof(Ǖ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ú=ѻ.ú;else Ù.ú=Ċ;ϩ="ExteriorLights";if(
ʩ.ContainsKey(ʑ,ϩ))Ù.ù=(Ǔ)Enum.Parse(typeof(Ǔ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ù=ѻ.ù;else Ù.ù=ĉ;ϩ=
"ExteriorLightColour";if(ʩ.ContainsKey(ʑ,ϩ)){ģ=ʩ.Get(ʑ,ϩ).ToString();Ѝ=ģ.Split(',');Ѿ=int.Parse(Ѝ[0]);ѽ=int.Parse(Ѝ[1]);Ɋ=int.Parse(Ѝ[2]);ĸ=
int.Parse(Ѝ[3]);Ù.ø=new Color(Ѿ,ѽ,Ɋ,ĸ);}else if(Ѽ)Ù.ø=ѻ.ø;else Ù.ø=Ĉ;ϩ="InteriorLights";if(ʩ.ContainsKey(ʑ,ϩ))Ù.ö=(Ǔ)Enum.
Parse(typeof(Ǔ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ö=ѻ.ö;else Ù.ö=ć;ϩ="InteriorLightColour";if(ʩ.ContainsKey(ʑ,ϩ)){ģ=ʩ.Get(ʑ,
ϩ).ToString();Ѝ=ģ.Split(',');Ѿ=int.Parse(Ѝ[0]);ѽ=int.Parse(Ѝ[1]);Ɋ=int.Parse(Ѝ[2]);ĸ=int.Parse(Ѝ[3]);Ù.õ=new Color(Ѿ,ѽ,Ɋ,
ĸ);}else if(Ѽ)Ù.õ=ѻ.õ;else Ù.õ=Ć;ϩ="NavLights";if(ʩ.ContainsKey(ʑ,ϩ))Ù.ô=(Ǔ)Enum.Parse(typeof(Ǔ),ʩ.Get(ʑ,ϩ).ToString());
else if(Ѽ)Ù.ô=ѻ.ô;else Ù.ô=ą;ϩ="LcdTextColour";if(ʩ.ContainsKey(ʑ,ϩ)){ģ=ʩ.Get(ʑ,ϩ).ToString();Ѝ=ģ.Split(',');Ѿ=int.Parse(Ѝ[0
]);ѽ=int.Parse(Ѝ[1]);Ɋ=int.Parse(Ѝ[2]);ĸ=int.Parse(Ѝ[3]);Ù.ó=new Color(Ѿ,ѽ,Ɋ,ĸ);}else if(Ѽ)Ù.ó=ѻ.ó;else Ù.ó=Ą;ϩ=
"TanksAndBatteries";if(ʩ.ContainsKey(ʑ,ϩ))Ù.ò=(ǐ)Enum.Parse(typeof(ǐ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ò=ѻ.ò;else Ù.ò=ă;ϩ=
"NavOsEfcBurnPercentage";if(ʩ.ContainsKey(ʑ,ϩ))Ù.ñ=ʩ.Get(ʑ,"NavOsEfcBurnPercentage").ToInt32(Ă);else if(Ѽ)Ù.ñ=ѻ.ñ;else Ù.ñ=Ă;ϩ="EfcBoost";if(ʩ.
ContainsKey(ʑ,ϩ))Ù.ð=(Ɵ)Enum.Parse(typeof(Ɵ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ð=ѻ.ð;else Ù.ð=î;ϩ="NavOsAbortEfcOff";if(ʩ.
ContainsKey(ʑ,ϩ))Ù.ï=(ǀ)Enum.Parse(typeof(ǀ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ï=ѻ.ï;else Ù.ï=í;ϩ="NavOsAbortEfcOff";if(ʩ.
ContainsKey(ʑ,ϩ))Ù.ï=(ǀ)Enum.Parse(typeof(ǀ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ï=ѻ.ï;else Ù.ï=í;ϩ="AuxMode";if(ʩ.ContainsKey(ʑ,ϩ))
Ù.ÿ=(Ɵ)Enum.Parse(typeof(Ɵ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ÿ=ѻ.ÿ;else Ù.ÿ=Ï;ϩ="Extractor";if(ʩ.ContainsKey(ʑ,ϩ))Ù.ā=(
ƿ)Enum.Parse(typeof(ƿ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ā=ѻ.ā;else Ù.ā=Þ;ϩ="KeepAlives";if(ʩ.ContainsKey(ʑ,ϩ))Ù.Ē=(Ɵ)
Enum.Parse(typeof(Ɵ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.Ē=ѻ.Ē;else Ù.Ē=Ý;ϩ="HangarDoors";if(ʩ.ContainsKey(ʑ,ϩ))Ù.ē=(ƾ)Enum.
Parse(typeof(ƾ),ʩ.Get(ʑ,ϩ).ToString());else if(Ѽ)Ù.ē=ѻ.ē;else Ù.ē=Ü;ʓ.Add(ʐ,Ù);}catch(Exception ex){Ѯ(ex,
"Failed to parse stance\n"+ʐ+"\nproperty\n"+ϩ);}}}if(ʓ.Count<1){Echo("Failed to parse any stances!\nStances reset to default!");ʛ=false;}else{Echo
("Finished parsing "+ʓ.Count+" stances.");ѩ=ʓ;}ɍ="RSM.Stance";Echo(ɍ);đ=ʩ.Get(ɍ,"CurrentStance").ToString(đ);O Ѻ;if(!ѩ.
TryGetValue(đ,out Ѻ)){đ="N/A";Đ=null;}else Đ=Ѻ;return ʛ;}void ѹ(){ʩ.Clear();string ɍ,ȴ;ɍ="RSM.Main";ȴ="RequireShipName";ʩ.Set(ɍ,ȴ,ʺ
);ʩ.SetComment(ɍ,ȴ,"limit to blocks with the ship name in their name");ȴ="EnableAutoload";ʩ.Set(ɍ,ȴ,ʻ);ʩ.SetComment(ɍ,ȴ,
"enable RSM loading & balancing functionality for weapons");ȴ="AutoloadReactors";ʩ.Set(ɍ,ȴ,ʹ);ʩ.SetComment(ɍ,ȴ,"enable loading and balancing for reactors");ȴ="AutoConfigWeapons";
ʩ.Set(ɍ,ȴ,ʸ);ʩ.SetComment(ɍ,ȴ,"automatically configure weapon on stance set");ȴ="SetTurretFireMode";ʩ.Set(ɍ,ȴ,ʷ);ʩ.
SetComment(ɍ,ȴ,"set turret fire mode based on stance");ȴ="ManageBatteryDischarge";ʩ.Set(ɍ,ȴ,ʶ);ʩ.SetComment(ɍ,ȴ,
"set batteries to discharge on active railgun/coilgun target");ʩ.SetSectionComment(ɍ,з+" Reedit Ship Management\n"+з+" Config.ini\n Recompile to apply changes!\n"+з);ɍ="RSM.Spawns";
ȴ="PrivateSpawns";ʩ.Set(ɍ,ȴ,ʵ);ʩ.SetComment(ɍ,ȴ,"don't inject faction tag into spawn custom data");ȴ="FriendlyTags";ʩ.Set
(ɍ,ȴ,ʴ);ʩ.SetComment(ɍ,ȴ,"Comma seperated friendly factions or steam ids");ɍ="RSM.Doors";ȴ="EnableDoorManagement";ʩ.Set(ɍ
,ȴ,ʳ);ʩ.SetComment(ɍ,ȴ,"enable door management functionality");ȴ="DoorCloseTimer";ʩ.Set(ɍ,ȴ,ʲ);ʩ.SetComment(ɍ,ȴ,
"door open timer (x100 ticks)");ȴ="AirlockDoorDisableTimer";ʩ.Set(ɍ,ȴ,ʱ);ʩ.SetComment(ɍ,ȴ,"airlock door disable timer (x100 ticks)");ɍ="RSM.Keywords";
ȴ="Ignore";ʩ.Set(ɍ,ȴ,ʰ);ʩ.SetComment(ɍ,ȴ,"to identify blocks which RSM should ignore");ȴ="RsmLcds";ʩ.Set(ɍ,ȴ,ʯ);ʩ.
SetComment(ɍ,ȴ,"to identify RSM lcds");ȴ="ColourSyncLcds";ʩ.Set(ɍ,ȴ,ʮ);ʩ.SetComment(ɍ,ȴ,"to identify non RSM lcds for colour sync"
);ȴ="AuxiliaryBlocks";ʩ.Set(ɍ,ȴ,ʭ);ʩ.SetComment(ɍ,ȴ,"to identify aux blocks");ȴ="DefensivePdcs";ʩ.Set(ɍ,ȴ,ʬ);ʩ.SetComment
(ɍ,ȴ,"to identify defensive _normalPdcs");ȴ="MinimumThrusters";ʩ.Set(ɍ,ȴ,ʫ);ʩ.SetComment(ɍ,ȴ,
"to identify minimum epsteins");ȴ="DockingThrusters";ʩ.Set(ɍ,ȴ,ʪ);ʩ.SetComment(ɍ,ȴ,"to identify docking epsteins");ȴ="NavLights";ʩ.Set(ɍ,ȴ,ʝ);ʩ.
SetComment(ɍ,ȴ,"to identify navigational lights");ȴ="Airlock";ʩ.Set(ɍ,ȴ,ʜ);ʩ.SetComment(ɍ,ȴ,"to identify airlock doors and vents")
;ɍ="RSM.InitNaming";ȴ="NameDelimiter";ʩ.Set(ɍ,ȴ,ʊ.ToString());ʩ.SetComment(ɍ,ȴ,"single char delimiter for names");ȴ=
"NameWeaponTypes";ʩ.Set(ɍ,ȴ,ʉ);ʩ.SetComment(ɍ,ȴ,"append type names to all weapons on init");ȴ="NameDriveTypes";ʩ.Set(ɍ,ȴ,ʈ);ʩ.SetComment(
ɍ,ȴ,"append type names to all drives on init");string Ѹ="";foreach(string ѷ in ʇ){if(Ѹ!="")Ѹ+=",";Ѹ+=ѷ;}ȴ=
"BlocksToNumber";ʩ.Set(ɍ,ȴ,ʈ);ʩ.SetComment(ɍ,ȴ,"comma seperated list of block names to be numbered at init");ɍ="RSM.Misc";ȴ=
"DisableLightingControl";ʩ.Set(ɍ,ȴ,ʆ);ʩ.SetComment(ɍ,ȴ,"disable all lighting control");ȴ="DisableLcdColourControl";ʩ.Set(ɍ,ȴ,ʅ);ʩ.SetComment(ɍ,ȴ
,"disable text colour control for all lcds");ȴ="ShowBasicTelemetry";ʩ.Set(ɍ,ȴ,ʄ);ʩ.SetComment(ɍ,ȴ,
"show basic telemetry data on advanced thrust lcds");string Ѷ="";foreach(double ī in ʃ){if(Ѷ!="")Ѷ+=",";Ѷ+=(ī*100).ToString();}ȴ="DecelerationPercentages";ʩ.Set(ɍ,ȴ,Ѷ);ʩ.
SetComment(ɍ,ȴ,"thrust percentages to show on advanced thrust lcds");ȴ="ShowThrustInMetric";ʩ.Set(ɍ,ȴ,ʂ);ʩ.SetComment(ɍ,ȴ,
"show basic telemetry data on advanced thrust lcds");ȴ="ReactorFillRatio";ʩ.Set(ɍ,ȴ,ʁ);ʩ.SetComment(ɍ,ȴ,"0-1, fill ratio for reactors");ɍ="RSM.Debug";ȴ="VerboseDebugging";
ʩ.Set(ɍ,ȴ,ʀ);ʩ.SetComment(ɍ,ȴ,"prints more logging info to PB details");ȴ="RuntimeProfiling";ʩ.Set(ɍ,ȴ,ɿ);ʩ.SetComment(ɍ,
ȴ,"prints script runtime profiling info to PB details");ȴ="BlockRefreshFreq";ʩ.Set(ɍ,ȴ,ɽ);ʩ.SetComment(ɍ,ȴ,
"ticks x100 between block refreshes");ȴ="StallCount";ʩ.Set(ɍ,ȴ,ɾ);ʩ.SetComment(ɍ,ȴ,"ticks x100 to stall between runs");ɍ="RSM.Stance";ȴ="CurrentStance";ʩ.
Set(ɍ,ȴ,đ);ʩ.SetSectionComment(ɍ,з+" Stances\n Add or remove as required\n"+з);string ѵ="Red, Green, Blue, Alpha";foreach(
var Ѵ in ѩ){ɍ="RSM.Stance."+Ѵ.Key;O Ú=Ѵ.Value;O ѻ=null;if(Ú.Î!=""){ѻ=ѩ[Ú.Î];ȴ="Inherits";ʩ.Set(ɍ,ȴ,Ú.Î);ʩ.SetComment(ɍ,ȴ,
"Use stance of this name as a template for settings");}ȴ="Torps";if(ѻ!=null&&Ú.Ā==ѻ.Ā){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.Ā.ToString());ʩ.SetComment(ɍ,ȴ,
Ѳ(typeof(Ɵ)));}ȴ="Pdcs";if(ѻ!=null&&Ú.þ==ѻ.þ){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.þ.ToString());ʩ.
SetComment(ɍ,ȴ,Ѳ(typeof(ǒ)));}ȴ="Kinetics";if(ѻ!=null&&Ú.ý==ѻ.ý){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ý.ToString(
));ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(Ǒ)));}ȴ="MainThrust";if(ѻ!=null&&Ú.ü==ѻ.ü){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ
,ȴ,Ú.ü.ToString());ʩ.SetComment(ɍ,"MainThrust",Ѳ(typeof(ǔ)));}ȴ="ManeuveringThrust";if(ѻ!=null&&Ú.û==ѻ.û){if(ʩ.
ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.û.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(ǖ)));}ȴ="Spotlights";if(ѻ!=null&&Ú.ú==ѻ.ú)
{if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ú.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(Ǖ)));}ȴ="ExteriorLights";
if(ѻ!=null&&Ú.ù==ѻ.ù){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ù.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(Ǔ)));}
ȴ="ExteriorLightColour";if(ѻ!=null&&Ú.ø==ѻ.ø){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,ѯ(Ú.ø));ʩ.SetComment(ɍ,
ȴ,ѵ);}ȴ="InteriorLights";if(ѻ!=null&&Ú.ö==ѻ.ö){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ö.ToString());ʩ.
SetComment(ɍ,ȴ,Ѳ(typeof(Ǔ)));}ȴ="InteriorLightColour";if(ѻ!=null&&Ú.õ==ѻ.õ){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,ѯ(
Ú.õ));ʩ.SetComment(ɍ,ȴ,ѵ);}ȴ="NavLights";if(ѻ!=null&&Ú.ô==ѻ.ô){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ô.
ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(Ǔ)));}ȴ="LcdTextColour";if(ѻ!=null&&Ú.ó==ѻ.ó){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.
Set(ɍ,ȴ,ѯ(Ú.ó));ʩ.SetComment(ɍ,ȴ,ѵ);}ȴ="TanksAndBatteries";if(ѻ!=null&&Ú.ò==ѻ.ò){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{
ʩ.Set(ɍ,ȴ,Ú.ò.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(ǐ)));}ȴ="NavOsEfcBurnPercentage";if(ѻ!=null&&Ú.ñ==ѻ.ñ){if(ʩ.
ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ñ.ToString());ʩ.SetComment(ɍ,ȴ,"Burn % 0-100, -1 for no change");}ȴ="EfcBoost";if(
ѻ!=null&&Ú.ð==ѻ.ð){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ð.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(Ɵ)));}ȴ=
"NavOsAbortEfcOff";if(ѻ!=null&&Ú.ï==ѻ.ï){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ï.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(ǀ))
);}ȴ="AuxMode";if(ѻ!=null&&Ú.ÿ==ѻ.ÿ){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ÿ.ToString());ʩ.SetComment(ɍ,ȴ
,Ѳ(typeof(Ɵ)));}ȴ="Extractor";if(ѻ!=null&&Ú.ā==ѻ.ā){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú.ā.ToString());ʩ
.SetComment(ɍ,ȴ,Ѳ(typeof(ƿ)));}ȴ="KeepAlives";if(ѻ!=null&&Ú.Ē==ѻ.Ē){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);}else{ʩ.Set(ɍ,ȴ,Ú
.Ē.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(Ɵ)));}ȴ="HangarDoors";if(ѻ!=null&&Ú.ē==ѻ.ē){if(ʩ.ContainsKey(ɍ,ȴ))ʩ.Delete(ɍ,ȴ);
}else{ʩ.Set(ɍ,ȴ,Ú.ē.ToString());ʩ.SetComment(ɍ,ȴ,Ѳ(typeof(ƾ)));}}ɍ="RSM.System";ȴ="ShipName";ʩ.Set(ɍ,ȴ,ʌ);ʩ.
SetSectionComment(ɍ,з+" System\n All items below this point are\n set automatically when running init\n"+з);ɍ="RSM.InitItems";foreach(Ģ ʔ
in ϭ){ȴ=ʔ.ϳ.SubtypeId;ʩ.Set(ɍ,ȴ,ʔ.Ў);}ɍ="RSM.InitSubSystems";ʩ.Set(ɍ,"Reactors",F);ʩ.Set(ɍ,"Batteries",F);ʩ.Set(ɍ,"Pdcs",Ì
);ʩ.Set(ɍ,"TorpLaunchers",ȉ);ʩ.Set(ɍ,"KineticWeapons",Y);ʩ.Set(ɍ,"H2Storage",Ö);ʩ.Set(ɍ,"O2Storage",ê);ʩ.Set(ɍ,
"MainThrust",ã);ʩ.Set(ɍ,"RCSThrust",Ȅ);ʩ.Set(ɍ,"Gyros",Ҧ);ʩ.Set(ɍ,"CargoStorage",ʣ);ʩ.Set(ɍ,"Welders",Ƥ);Me.CustomData=ʩ.ToString();
}void ҏ(string Ƀ){string[]ʒ=Ƀ.Split(new string[]{"[Stances]"},StringSplitOptions.None);string[]Ҏ=ʒ[0].Split('\n');string
ҍ=ʒ[1];try{for(int ĝ=1;ĝ<Ҏ.Length;ĝ++){if(Ҏ[ĝ].Contains("=")){string Ҍ=Ҏ[ĝ].Substring(1);switch(Ҏ[(ĝ-1)]){case
"Ship name. Blocks without this name will be ignored":ʌ=Ҍ;break;case"Block name delimiter, used by init. One character only!":ʊ=char.Parse(Ҍ.Substring(0,1));break;case
"Keyword used to identify RSM _allLcds.":ʯ=Ҍ;break;case"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʭ=Ҍ;break;
case"Keyword used to identify defence _normalPdcs.":ʬ=Ҍ;break;case"Keyword used to identify minimum epstein drives.":ʫ=Ҍ;
break;case"Keyword used to identify docking epstein drives.":ʪ=Ҍ;break;case"Keyword to ignore block.":ʰ=Ҍ;break;case
"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʸ=bool.Parse(Ҍ);break;case"Disable lighting all control.":ʆ=bool.Parse(Ҍ);break;case
"Disable LCD Text Colour Enforcement.":ʅ=bool.Parse(Ҍ);break;case"Enable Weapon Autoload Functionality.":ʻ=bool.Parse(Ҍ);break;case
"Number these blocks at init.":ʇ.Clear();string[]ҋ=Ҍ.Split(',');foreach(string ѷ in ҋ){if(ѷ!="")ʇ.Add(ѷ);}break;case
"Add type names to weapons at init.":ʉ=bool.Parse(Ҍ);break;case"Only set batteries to discharge on active railgun/coilgun target.":ʶ=bool.Parse(Ҍ);break;
case"Show basic telemetry.":ʄ=bool.Parse(Ҍ);break;case"Show Decel Percentages (comma seperated).":ʃ.Clear();string[]Ҋ=Ҍ.
Split(',');foreach(string ī in Ҋ){ʃ.Add(double.Parse(ī)/100);}break;case"Fusion Fuel count":ϭ[0].Ў=int.Parse(Ҍ);break;case
"Fuel tank count":ϭ[1].Ў=int.Parse(Ҍ);break;case"Jerry can count":ϭ[2].Ў=int.Parse(Ҍ);break;case"40mm PDC Magazine count":ϭ[3].Ў=int.
Parse(Ҍ);break;case"40mm Teflon Tungsten PDC Magazine count":ϭ[4].Ў=int.Parse(Ҍ);break;case"220mm Torpedo count":case
"Torpedo count":ϭ[5].Ў=int.Parse(Ҍ);break;case"220mm MCRN torpedo count":ϭ[6].Ў=int.Parse(Ҍ);break;case"220mm UNN torpedo count":ϭ[7].Ў
=int.Parse(Ҍ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":ϭ[8].Ў=int.Parse(Ҍ);break;case
"Large ramshacke torpedo count":ϭ[9].Ў=int.Parse(Ҍ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":ϭ[10].Ў=int.Parse(Ҍ);break;
case"Dawson 100mm UNN Railgun rounds count":ϭ[11].Ў=int.Parse(Ҍ);break;case"Stiletto 100mm MCRN Railgun rounds count":ϭ[12].
Ў=int.Parse(Ҍ);break;case"T-47 80mm Railgun rounds count":ϭ[13].Ў=int.Parse(Ҍ);break;case
"Foehammer 120mm MCRN rounds count":ϭ[14].Ў=int.Parse(Ҍ);break;case"Farren 120mm UNN Railgun rounds count":ϭ[15].Ў=int.Parse(Ҍ);break;case
"Kess 180mm rounds count":ϭ[16].Ў=int.Parse(Ҍ);break;case"Steel plate count":ϭ[17].Ў=int.Parse(Ҍ);break;case
"Doors open timer (x100 ticks, default 3)":ʲ=int.Parse(Ҍ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ʱ=int.Parse(Ҍ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":ɾ=int.Parse(Ҍ);break;case"Full refresh frequency (x100 ticks, default 50)":ɽ=int.Parse(Ҍ);break;case
"Verbose script debugging. Prints more logging info to PB details.":ʀ=bool.Parse(Ҍ);break;case"Private spawn (don't inject faction tag into SK custom data).":ʵ=bool.Parse(Ҍ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":ʴ=string.Join("\n",Ҍ.Split(','));break;case"Current Stance":đ=Ҍ;O Ѻ;if(!ѩ.TryGetValue(đ,out Ѻ)){đ="N/A";Đ=null;}else Đ=
Ѻ;break;case"Reactor Integrity":F=float.Parse(Ҍ);break;case"Battery Integrity":Á=float.Parse(Ҍ);break;case"PDC Integrity"
:Ì=int.Parse(Ҍ);break;case"Torpedo Integrity":ȉ=int.Parse(Ҍ);break;case"Railgun Integrity":Y=int.Parse(Ҍ);break;case
"H2 Tank Integrity":Ö=double.Parse(Ҍ);break;case"O2 Tank Integrity":ê=double.Parse(Ҍ);break;case"Epstein Integrity":ã=float.Parse(Ҍ);break;
case"RCS Integrity":Ȅ=float.Parse(Ҍ);break;case"Gyro Integrity":Ҧ=int.Parse(Ҍ);break;case"Cargo Integrity":ʣ=double.Parse(Ҍ)
;break;case"Welder Integrity":Ƥ=int.Parse(Ҍ);break;}}}}catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);
}try{string[]ҁ=ҍ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(ʀ)Echo("Parsing "+(ҁ.Length-1)+" stances");int
Ҁ=24;Dictionary<string,O>ʓ=new Dictionary<string,O>();int[]ѿ=new int[]{0,5,25,50,75,100};for(int ĝ=1;ĝ<ҁ.Length;ĝ++){
string[]ѳ=ҁ[ĝ].Split('=');string ʐ="";int[]ќ=new int[Ҁ];ʐ=ѳ[0].Split(' ')[0];if(ʀ)Echo("Parsing '"+ʐ+"'");for(int Ѧ=0;Ѧ<ќ.
Length;Ѧ++){string[]ѥ=ѳ[(Ѧ+1)].Split('\n');ќ[Ѧ]=int.Parse(ѥ[0]);}O Ù=new O();if(ќ[0]==0)Ù.Ā=Ɵ.Off;else Ù.Ā=Ɵ.On;if(ќ[1]==0)Ù.þ
=ǒ.Off;else if(ќ[1]==1)Ù.þ=ǒ.MinDefence;else if(ќ[1]==2)Ù.þ=ǒ.AllDefence;else if(ќ[1]==3)Ù.þ=ǒ.Offence;else if(ќ[1]==4)Ù.
þ=ǒ.AllOnOnly;if(ќ[2]==0)Ù.ý=Ǒ.Off;else if(ќ[2]==1)Ù.ý=Ǒ.HoldFire;else if(ќ[2]==2)Ù.ý=Ǒ.OpenFire;if(ќ[3]==0)Ù.ü=ǔ.Off;
else if(ќ[3]==1)Ù.ü=ǔ.On;else if(ќ[3]==2)Ù.ü=ǔ.Minimum;if(ќ[4]==0)Ù.û=ǖ.Off;else if(ќ[4]==1)Ù.û=ǖ.On;else if(ќ[4]==2)Ù.û=ǖ.
ForwardOff;else if(ќ[4]==3)Ù.û=ǖ.ReverseOff;if(ќ[5]==0)Ù.ú=Ǖ.Off;else if(ќ[5]==1)Ù.ú=Ǖ.On;else if(ќ[5]==2)Ù.ú=Ǖ.OnMax;if(ќ[6]==0)Ù
.ù=Ǔ.Off;else Ù.ù=Ǔ.On;Ù.ø=new Color(ќ[7],ќ[8],ќ[9],ќ[10]);if(ќ[11]==0)Ù.ö=Ǔ.Off;else Ù.ö=Ǔ.On;Ù.õ=new Color(ќ[12],ќ[13],
ќ[14],ќ[15]);if(ќ[16]==0)Ù.ò=ǐ.Auto;else if(ќ[16]==1)Ù.ò=ǐ.StockpileRecharge;else if(ќ[16]==2)Ù.ò=ǐ.Discharge;if(ќ[17]==0
)Ù.ð=Ɵ.Off;else Ù.ð=Ɵ.On;Ù.ñ=ѿ[ќ[18]];if(ќ[19]==0)Ù.ï=ǀ.NoChange;else Ù.ï=ǀ.Abort;if(ќ[20]==0)Ù.ÿ=Ɵ.Off;else Ù.ÿ=Ɵ.On;if(
ќ[21]==0)Ù.ā=ƿ.Off;else if(ќ[21]==1)Ù.ā=ƿ.On;else if(ќ[21]==2)Ù.ā=ƿ.FillWhenLow;else if(ќ[21]==3)Ù.ā=ƿ.KeepFull;if(ќ[22]
==0)Ù.Ē=Ɵ.Off;else Ù.Ē=Ɵ.On;if(ќ[23]==0)Ù.ē=ƾ.Closed;else if(ќ[23]==1)Ù.ē=ƾ.Open;else Ù.ē=ƾ.NoChange;ʓ.Add(ʐ,Ù);}if(ʓ.
Count>=1){if(ʀ)Echo("Finished parsing "+ʓ.Count+" stances.");ѩ=ʓ;}else{Echo("Didn't find any stances!");}}catch(Exception ex)
{Echo("Custom Data Error (stances)\n"+ex.Message);}}void Ѥ(){bool ѣ=ʎ();if(!ѣ){Ѩ();ѹ();}if(Đ==null){Đ=ѩ.First().Value;}
string Ѣ="";string ѡ="";if(!ʵ){Ѣ=" ".PadRight(129,' ')+Ο+"\n";ѡ="\n".PadRight(19,'\n');}Ξ=Ѣ+ѡ;Ν=Ѣ+string.Join("\n",ʴ.Split(','
))+ѡ;if(ʌ==""){if(ʀ)Echo("No ship name, trying to pull it from PB name...");string Ѡ="Untitled Ship";try{string[]џ=Me.
CustomName.Split(ʊ);if(џ.Length>1){ʌ=џ[0];if(ʀ)Echo(ʌ);}else ʌ=Ѡ;}catch{ʌ=Ѡ;}}}void ў(bool Û=true,bool ѝ=false,bool ˌ=false){MyIni
ɝ=new MyIni();string Ƀ=Me.CustomData;MyIniParseResult Ɖ;if(!ɝ.TryParse(Ƀ,out Ɖ)){Щ.Add(new ё("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ɍ,ȴ;if(Û){ɍ="RSM.Stance";ȴ="CurrentStance";ɝ.Set(ɍ,ȴ,đ);}else{ɍ="RSM.System";ȴ="ShipName";ɝ.Set(ɍ,ȴ,
ʌ);}if(ѝ){ɍ="RSM.InitSubSystems";ɝ.Set(ɍ,"Reactors",F);ɝ.Set(ɍ,"Batteries",F);ɝ.Set(ɍ,"Pdcs",Ì);ɝ.Set(ɍ,"TorpLaunchers",ȉ
);ɝ.Set(ɍ,"KineticWeapons",Y);ɝ.Set(ɍ,"H2Storage",Ö);ɝ.Set(ɍ,"O2Storage",ê);ɝ.Set(ɍ,"MainThrust",ã);ɝ.Set(ɍ,"RCSThrust",Ȅ
);ɝ.Set(ɍ,"Gyros",Ҧ);ɝ.Set(ɍ,"CargoStorage",ʣ);ɝ.Set(ɍ,"Welders",Ƥ);}if(ˌ){ɍ="RSM.InitItems";foreach(Ģ ʔ in ϭ){ȴ=ʔ.ϳ.
SubtypeId;ɝ.Set(ɍ,ȴ,ʔ.Ў);}}Me.CustomData=ɝ.ToString();}string Ѳ(Type ѱ){string Ѱ="";foreach(var ġ in Enum.GetValues(ѱ)){if(Ѱ!="")
Ѱ+=", ";Ѱ+=ġ.ToString();}return Ѱ;}string ѯ(Color Ħ){return Ħ.R+", "+Ħ.G+", "+Ħ.B+", "+Ħ.A;}void Ѯ(Exception ѭ,string Ѭ){
Runtime.UpdateFrequency=UpdateFrequency.None;string ѫ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+Ѭ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ѫ);List<IMyTextPanel>Ѫ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ѫ,Ɋ=>Ɋ.CustomName
.Contains(ʯ));foreach(IMyTextPanel Ŵ in Ѫ){Ŵ.WriteText(ѫ);Ŵ.FontColor=new Color(193,0,197,255);}throw ѭ;}Dictionary<
string,O>ѩ=new Dictionary<string,O>();void Ѩ(){ѩ=new Dictionary<string,O>{{"Cruise",new O{Ā=Ɵ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü
=ǔ.EpsteinOnly,û=ǖ.ForwardOff,ú=Ǖ.Off,ù=Ǔ.On,ø=new Color(33,144,255,255),ö=Ǔ.On,õ=new Color(255,214,170,255),ó=new Color(
33,144,255,255),ò=ǐ.Auto,ñ=50,ð=Ɵ.NoChange,ï=ǀ.Abort,ÿ=Ɵ.NoChange,ā=ƿ.KeepFull,Ē=Ɵ.On,ē=ƾ.NoChange}},{"StealthCruise",new
O{Î="Cruise",Ā=Ɵ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü=ǔ.Minimum,û=ǖ.ForwardOff,ú=Ǖ.Off,ù=Ǔ.Off,ø=new Color(0,0,0,255),ö=Ǔ.On,
õ=new Color(23,73,186,255),ó=new Color(23,73,186,255),ò=ǐ.Auto,ñ=5,ð=Ɵ.Off,ï=ǀ.Abort,ÿ=Ɵ.NoChange,ā=ƿ.KeepFull,Ē=Ɵ.On,ē=ƾ
.NoChange}},{"Docked",new O{Î="Cruise",Ā=Ɵ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü=ǔ.Off,û=ǖ.Off,ú=Ǖ.Off,ù=Ǔ.On,ø=new Color(33,
144,255,255),ö=Ǔ.On,õ=new Color(255,240,225,255),ô=Ǔ.On,ó=new Color(255,255,255,255),ò=ǐ.StockpileRecharge,ñ=-1,ð=Ɵ.
NoChange,ï=ǀ.Abort,ÿ=Ɵ.Off,ā=ƿ.On,Ē=Ɵ.On,ē=ƾ.NoChange}},{"Docking",new O{Î="Docked",Ā=Ɵ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü=ǔ.Off,û
=ǖ.On,ú=Ǖ.OnMax,ù=Ǔ.On,ø=new Color(33,144,255,255),ö=Ǔ.On,õ=new Color(212,170,83,255),ô=Ǔ.On,ó=new Color(212,170,83,255),
ò=ǐ.Auto,ñ=-1,ð=Ɵ.NoChange,ï=ǀ.Abort,ÿ=Ɵ.Off,ā=ƿ.KeepFull,Ē=Ɵ.On,ē=ƾ.NoChange}},{"NoAttack",new O{Î="Docked",Ā=Ɵ.Off,þ=ǒ.
Off,ý=Ǒ.Off,ü=ǔ.On,û=ǖ.On,ú=Ǖ.Off,ù=Ǔ.On,ø=new Color(255,255,255,255),ö=Ǔ.On,õ=new Color(84,157,82,255),ô=Ǔ.NoChange,ó=new
Color(84,157,82,255),ò=ǐ.NoChange,ñ=-1,ð=Ɵ.NoChange,ï=ǀ.NoChange,ÿ=Ɵ.NoChange,ā=ƿ.KeepFull,Ē=Ɵ.On,ē=ƾ.NoChange}},{"Combat",
new O{Î="Cruise",Ā=Ɵ.On,þ=ǒ.AllDefence,ý=Ǒ.OpenFire,ü=ǔ.On,û=ǖ.On,ú=Ǖ.Off,ù=Ǔ.Off,ø=new Color(0,0,0,255),ö=Ǔ.On,õ=new Color
(210,98,17,255),ô=Ǔ.On,ó=new Color(210,98,17,255),ò=ǐ.Discharge,ñ=100,ð=Ɵ.On,ï=ǀ.Abort,ÿ=Ɵ.On,ā=ƿ.KeepFull,Ē=Ɵ.On,ē=ƾ.
NoChange}},{"CQB",new O{Î="Combat",Ā=Ɵ.On,þ=ǒ.Offence,ý=Ǒ.OpenFire,ü=ǔ.On,û=ǖ.On,ú=Ǖ.Off,ù=Ǔ.Off,ø=new Color(0,0,0,255),ö=Ǔ.On,õ
=new Color(243,18,18,255),ô=Ǔ.On,ó=new Color(243,18,18,255),ò=ǐ.Discharge,ñ=100,ð=Ɵ.On,ï=ǀ.Abort,ÿ=Ɵ.On,ā=ƿ.KeepFull,Ē=Ɵ.
On,ē=ƾ.NoChange}},{"WeaponsHot",new O{Î="CQB",Ā=Ɵ.On,þ=ǒ.Offence,ý=Ǒ.OpenFire,ü=ǔ.NoChange,û=ǖ.NoChange,ú=Ǖ.NoChange,ù=Ǔ.
NoChange,ø=new Color(0,0,0,255),ö=Ǔ.NoChange,õ=new Color(243,18,18,255),ô=Ǔ.NoChange,ó=new Color(243,18,18,255),ò=ǐ.Discharge,ñ=
-1,ð=Ɵ.NoChange,ï=ǀ.NoChange,ÿ=Ɵ.NoChange,ā=ƿ.KeepFull,Ē=Ɵ.On,ē=ƾ.NoChange}}};}class ѧ{public IMyDoor ɔ;public int Ҟ=0;
public int һ=0;public bool Һ=false;public bool ҹ=false;}class Ҹ{public string ҷ;public bool Ҷ=false;public int ҵ=0;public bool
Ҵ=false;public List<ѧ>ҳ=new List<ѧ>();public List<IMyAirVent>Ҳ=new List<IMyAirVent>();}int ұ=0;int Ұ=0;int ү=0;bool Ү(ѧ ҫ
){bool ҭ=false;if(ҫ.ɔ==null)return false;bool ķ=ҫ.ɔ.OpenRatio>0;ұ++;if(Ҭ(ҫ.ɔ))ү++;if(ķ){ҫ.ɔ.Enabled=true;if(ʀ&&ҫ.Ҟ==0)
Echo("Door just opened... ("+ҫ.ɔ.CustomName+")");ҫ.Ҟ++;if(ҫ.Ҟ>=ʲ){ҫ.Ҟ=0;ҫ.ɔ.CloseDoor();ҭ=true;}}else{Ұ++;}return ҭ;}void Ҽ(
){if(!ʳ){if(ʀ)Echo("Door management is disabled.");return;}foreach(Ҹ ɟ in υ){foreach(ѧ ҫ in ɟ.ҳ){if(ҫ.ɔ==null)continue;
bool ҭ=Ү(ҫ);if(ҭ){if(ʀ)Echo("Airlock door "+ҫ.ɔ.CustomName+" just closed");if(ɟ.Ҵ)ɟ.Ҵ=false;else{ɟ.Ҷ=true;ҫ.ҹ=true;if(ʀ)Echo
("Airlock "+ɟ.ҷ+" needs to cycle");}}}if(ɟ.Ҷ){foreach(ѧ ҫ in ɟ.ҳ){if(ҫ.ɔ==null)continue;if(ҫ.ɔ.OpenRatio>0)ҫ.ɔ.CloseDoor(
);else ҫ.ɔ.Enabled=false;}bool ӆ=false;foreach(IMyAirVent Ӆ in ɟ.Ҳ){if(Ӆ==null)continue;if(!Ӆ.Enabled)Ӆ.Enabled=true;if(!
Ӆ.Depressurize)Ӆ.Depressurize=true;if(Ӆ.CanPressurize&&Ӆ.GetOxygenLevel()<.01&&ɟ.Ҷ)ӆ=true;}ɟ.ҵ++;bool ӄ=true;if(ɟ.ҵ>=ʱ){ӄ
=false;ӆ=true;}if(ӆ){ɟ.Ҷ=false;ɟ.ҵ=0;ɟ.Ҵ=true;foreach(ѧ ҫ in ɟ.ҳ){if(ҫ.ɔ==null)continue;ҫ.ɔ.Enabled=true;if(ҫ.ҹ)ҫ.ҹ=false
;else if(ӄ)ҫ.ɔ.OpenDoor();}}}}}void Ӄ(){if(!ʳ){if(ʀ)Echo("Door management is disabled.");return;}ұ=0;Ұ=0;ү=0;foreach(ѧ ҫ
in φ)Ү(ҫ);}void ӂ(ƾ L){if(L==ƾ.NoChange)return;foreach(IMyAirtightHangarDoor Ӂ in ϡ){if(Ӂ==null)continue;if(L==ƾ.Closed)Ӂ.
CloseDoor();else Ӂ.OpenDoor();}}void Ӏ(string ҿ,string Ҿ){ҿ=ҿ.ToLower();foreach(ѧ ҫ in φ){if(Ҿ==""||ҫ.ɔ.CustomName.Contains(Ҿ)){
bool ҽ=Ҭ(ҫ.ɔ);if(ҽ&&(ҿ=="locked"||ҿ=="toggle"))ҫ.ɔ.ApplyAction("AnyoneCanUse");if(!ҽ&&(ҿ=="unlocked"||ҿ=="toggle"))ҫ.ɔ.
ApplyAction("AnyoneCanUse");}}}bool Ҭ(IMyDoor ҫ){var Ɯ=ҫ.GetActionWithName("AnyoneCanUse");StringBuilder ҝ=new StringBuilder();Ɯ.
WriteValue(ҫ,ҝ);return(ҝ.ToString()=="On");}double Ҝ;int қ=0;int Қ=8;int ҙ=10;double Ҙ=3;double җ=245000;double Җ=50000;double ҕ=
100;void Ҕ(ƿ L){foreach(IMyTerminalBlock ғ in Ϡ){if(ғ==null)continue;if(L==ƿ.Off)ғ.ApplyAction("OnOff_Off");else ғ.
ApplyAction("OnOff_On");}}void Ғ(){if(Ϡ.Count<1&&ϟ.Count>1)Ҝ=(Ҙ*Җ);else Ҝ=(Ҙ*җ);}void ґ(){if(Đ.ā==ƿ.Off||Đ.ā==ƿ.On){if(ʀ)Echo(
"Extractor management disabled.");}else if(қ>0){қ--;if(ʀ)Echo("waiting ("+қ+")...");}else if(ϙ.Count<1){if(ʀ)Echo("No tanks!");}else if(Đ.ā==ƿ.
FillWhenLow&&ҕ<ҙ){if(ʀ)Echo("Fuel low! ("+ҕ+"% / "+ҙ+"%)");ͼ=true;Ґ();}else if(Đ.ā==ƿ.KeepFull&&Õ<(Ø-Ҝ)){ͼ=true;Ґ();if(ʀ)Echo(
"Fuel ready for top up ("+Õ+" < "+(Ø-Ҝ)+")");}else if(ʀ){Echo("Fuel level OK ("+ҕ+"%).");if(Đ.ā==ƿ.KeepFull)Echo("Keeping tanks full\n("+Õ+" < "+
(Ø-Ҝ)+")");}}void Ґ(){string Ƌ="";int ҟ=8;if(ҕ<5){ҟ=0;if(Қ!=ҟ)Ƌ="v fast";}else if(ҕ<10){ҟ=2;if(Қ!=ҟ)Ƌ="fast";}else if(ҕ<
60){ҟ=4;if(Қ!=ҟ)Ƌ="medium";}else if(Қ!=ҟ)Ƌ="slow";if(Ƌ!=""){Қ=ҟ;Щ.Add(new ё("Extractor loading "+Ƌ,
"Extractor load speed has been set to "+Ƌ+" automatically)",0));}}void ҩ(){ͼ=false;IMyTerminalBlock Ҫ=null;int Ģ=1;foreach(IMyTerminalBlock ғ in Ϡ){if(ғ.
IsFunctional){Ҫ=ғ;break;}}if(Ҫ==null){foreach(IMyTerminalBlock ғ in ϟ){if(ғ.IsFunctional){Ҫ=ғ;Ģ=2;break;}}if(Ҫ==null){if(ʀ)Echo(
"No functional extractor to load!");Γ=true;return;}}Γ=false;if(ϭ[Ģ].Џ<1){Δ=true;if(ʀ)Echo("No spare "+ϭ[Ģ].ϳ.SubtypeId+" to load!");return;}қ=Қ;Д ώ=new Д(
);ώ.ɔ=Ҫ;ώ.ώ=Ҫ.GetInventory();Ҫ.ApplyAction("OnOff_On");List<Д>Ҩ=new List<Д>();Ҩ.Add(ώ);if(ʀ)Echo(
"Attempting to load extractor "+Ҫ.CustomName);bool ʛ=ш(ϭ[Ģ].Ϫ,Ҩ,ϭ[Ģ].ϳ);string ҧ="fuel tank";if(Ģ==2)ҧ="jerry can";if(ʛ)Щ.Add(new ё("Loaded a "+ҧ,
"Sucessfully loaded a "+ҧ+" into an extractor.",0));}double Ҧ=0;int ҥ=0;double Ҥ=0;void ң(bool Ç,bool Ũ){ҥ=0;foreach(IMyGyro Ң in Ϟ){if(Ң!=null
&&Ң.IsFunctional){ҥ++;if(Ũ)Ң.Enabled=Ç;}}Ҥ=Math.Round(100*(ҥ/Ҧ));}void ҡ(string Ҡ,bool ʽ=true,bool ˍ=true,bool ˌ=true){if(
ʀ)Echo("Initialising a ship as '"+Ҡ+"'...");Έ=true;ʌ=Ҡ;Η=ʽ;Ι=ˍ;Θ=ˌ;Ћ();}void Ћ(){switch(Ό){case 0:ʾ();Ύ=0;if(ɿ)Echo(
"Took "+ͳ());break;case 1:Ϸ();if(ɿ)Echo("Took "+ͳ());break;case 2:if(ʀ)Echo("Initialising lcds...");ƅ();if(Ι){if(ʀ)Echo(
"Initialising subsystem values...");ȃ();ȏ();J();G();Ò();ç();ʞ();Ì=ε.Count+δ.Count;ȉ=β.Count;Y=γ.Count;Ҧ=Ϟ.Count;Ƥ=ω.Count;}if(Θ){if(ʀ)Echo(
"Initialising item values...");ϵ();}if(Η){if(ʀ)Echo("Initialising block names...");І();}ў(false,Ι,Θ);Щ.Add(new ё("Init:"+ʌ,"Initialised '"+ʌ+
"'\nGood Hunting!",3));Ό=0;Έ=false;if(ɿ)Echo("Took "+ͳ());return;}Ό++;}class Њ{public int Љ=0;public int Ј=0;public int Ї=0;}void І(){
Dictionary<string,Њ>Ѕ=new Dictionary<string,Њ>();if(ʇ.Count>0){foreach(string Q in ʇ){if(ʀ)Echo("Numbering "+Q);Ѕ.Add(Q,new Њ());}
foreach(var Ђ in τ){Њ Є;if(Ѕ.TryGetValue(Ђ.Value,out Є)){Ѕ[Ђ.Value].Ј++;}}foreach(var Ѓ in Ѕ){if(Ѓ.Value.Ј<10)Ѓ.Value.Ї=1;else
if(Ѓ.Value.Ј>99)Ѓ.Value.Ї=3;else Ѓ.Value.Ї=2;}}foreach(var Ђ in τ){string Ё="";string Ѐ=Ђ.Value;Њ Ͽ;if(Ѕ.TryGetValue(Ђ.
Value,out Ͽ)){if(Ͽ.Ј>1){Ͽ.Љ++;Ё=ʊ+Ͽ.Љ.ToString().PadLeft(Ͽ.Ї,'0');}}Ђ.Key.CustomName=ʌ+ʊ+Ѐ+Ё+Ќ(Ђ.Key.CustomName,Ѐ);}}string Ќ
(string ȴ,string Й=""){try{string[]К=ȴ.Split(ʊ);string[]И=Й.Split(ʊ);string Ɖ="";if(К.Length<3)return"";for(int ĝ=2;ĝ<К.
Length;ĝ++){int З=0;bool Ж=int.TryParse(К[ĝ],out З);if(Ж)К[ĝ]="";foreach(string Е in И){if(Е==К[ĝ])К[ĝ]="";}if(К[ĝ]!="")Ɖ+=ʊ+К
[ĝ];}return Ɖ;}catch{return"";}}class Д{public IMyTerminalBlock ɔ{get;set;}public IMyInventory ώ{get;set;}List<
MyInventoryItem>Г=new List<MyInventoryItem>();public int В=0;public bool Б=false;public float А;}class Ģ{public int Џ=0;public int Ў=0;
public int Ͼ=0;public double Ͻ;public List<Д>Ϫ=new List<Д>();public List<Д>ϴ=new List<Д>();public MyItemType ϳ;public bool ϲ=
false;public bool ϱ=false;public string ϰ;public string ϯ;public double Ϯ=1;}List<Ģ>ϭ=new List<Ģ>();void Ϭ(IMyTerminalBlock Ɋ
,int ʔ=99){if(ʔ==99){foreach(var Ģ in ϭ){Д ώ=new Д();ώ.ɔ=Ɋ;ώ.ώ=Ɋ.GetInventory();Ģ.Ϫ.Add(ώ);}}else{Д ώ=new Д();ώ.ɔ=Ɋ;ώ.ώ=Ɋ
.GetInventory();ώ.Б=ʻ;if(ʔ==0&&!ʹ)ώ.Б=false;ϭ[ʔ].Ϫ.Add(ώ);}}void ϫ(IMyTerminalBlock Ɋ,int ʔ){Д ώ=new Д();ώ.ɔ=Ɋ;ώ.ώ=Ɋ.
GetInventory();ώ.Б=ʻ;ϭ[ʔ].ϴ.Add(ώ);}void ϼ(string ϰ,string ϻ,string Ϻ,bool ϱ=false,bool ϲ=false){Ģ Ģ=new Ģ();Ģ.ϳ=new MyItemType(ϻ,Ϻ)
;Ģ.ϱ=ϱ;Ģ.ϲ=ϲ;Ģ.ϰ=ϰ;string ϯ=ϰ.PadRight(9);Ģ.ϯ=ϯ;ϭ.Add(Ģ);}void Ϲ(){try{ϼ("Fusion F ","MyObjectBuilder_Ingot","FusionFuel"
,true);ϼ("Fuel Tank","MyObjectBuilder_Component","Fuel_Tank");ϼ("Jerry Can","MyObjectBuilder_Component","SG_Fuel_Tank");ϼ
("PDC      ","MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine",true);ϼ("PDC Tefl ",
"MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);ϼ("220 Torp ","MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",
true,true);ϼ("220 MCRN ","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true,true);ϼ("220 UNN  ",
"MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);ϼ("RS Torp  ","MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true
);ϼ("LRS Torp ","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",true,true);ϼ("120mm RG ",
"MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);ϼ("Dawson   ","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",
true);ϼ("Stiletto ","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugMCRNMagazine",true);ϼ("80mm     ",
"MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);ϼ("Foehammr ","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugMCRNMagazine",true);ϼ("Farren   ","MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugUNNMagazine",true);ϼ("Kess     ",
"MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);ϼ("Steel Pla","MyObjectBuilder_Component","SteelPlate");ϭ[0].Ϯ=ʁ;}catch(Exception
ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void ϸ(){foreach(var Ģ in ϭ){Ģ.ϴ.Clear();}}void Ϸ(){
foreach(var Ģ in ϭ){Ģ.Џ=0;Ģ.Ͼ=0;List<Д>Υ=Ģ.Ϫ.Concat(Ģ.ϴ).ToList();foreach(Д ώ in Υ){ώ.В=ώ.ώ.GetItemAmount(Ģ.ϳ).ToIntSafe();Ģ.Џ
+=ώ.В;if(ώ.Б){ώ.А=ώ.ώ.VolumeFillFactor;}else{Ģ.Ͼ+=ώ.В;}}}}void ϵ(){foreach(Ģ Ģ in ϭ){Ģ.Ў=Ģ.Џ;}}int Л(string Ǻ){switch(Ǻ){
case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":case"MCRN Torpedo Low Spread":return 6;case
"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;case"40mm Lead-Steel PDC Box Ammo":
return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":return 10;case
"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case"80mm Tungsten-Uranium Sabot Ammo":return 13;case
"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;case"180mm Lead-Steel Sabot Ammo":return 16;default:if(ʀ
)Echo("Unknown AmmoType = "+Ǻ);return 99;}}bool ы(IMyTerminalBlock ɔ){IMyInventory щ=ɔ.GetInventory();return щ.
VolumeFillFactor==0;}bool ш(List<Д>η,List<Д>ϕ,MyItemType ϳ,int ч=-1,double ц=1,double х=1){if(ʀ)Echo("Loading "+ϕ.Count+
" inventories from "+η.Count+" sources.");bool s=false;bool ф=х<1;foreach(Д у in ϕ){int т=3;foreach(Д с in η){if(т<0)break;if(ч!=-1&&у.В>=(ч
*.95))break;if(!у.ώ.IsConnectedTo(с.ώ))continue;List<MyInventoryItem>р=new List<MyInventoryItem>();с.ώ.GetItems(р);
foreach(MyInventoryItem ъ in р){if(ъ.Type==ϳ){int В=ъ.Amount.ToIntSafe();if(В==0&&!ф)break;т--;if(ф){т=-1;try{В=с.В-Convert.
ToInt32(с.В/с.А*х);if(ʀ)Echo("Unload "+В+"\n"+с.В+"\n"+Convert.ToInt32(с.В/с.А*х));}catch(Exception ex){if(ʀ)Echo(
"Int conversion error at unload\n"+ex.Message);В=1;}}else if(ц<1){try{int њ=Convert.ToInt32(у.В/у.А*ц)-у.В;if(њ<В)В=њ;}catch(Exception ex){if(ʀ)Echo(
"Int conversion error at load\n"+ex.Message);В=1;}}else if(ч!=-1){if(В<=ч){break;}В=ч-у.В;}s=у.ώ.TransferItemFrom(с.ώ,ъ,В);if(s)т=-1;if(ф&&s)return(s);
break;}}}}return s;}class ћ{public IMyTextPanel ɔ;public bool љ=true;public bool ј=false;public bool ї=false;public bool і=
true;public bool ѕ=true;public bool є=true;public bool ѓ=false;public bool ђ=false;}class ё{public string ѐ,я;public int ю,э
;public ё(string ь,string п,int о=0,int М=20){if(ь.Length>С-3)ь=ь.Substring(0,С-3);ѐ=ь.PadRight(С-3);я=п;ю=о;э=М;}}List<ё
>Щ=new List<ё>();class Ш{public string Ч,Ц;public Ш(string Q,int Х,int Ф){string У="    ";while(Ф>3){Ф-=4;}if(Х==0){Ч=
"║ "+Q.PadRight(4)+" ║";Ц="  "+У+"  ";}else if(Х==1){if(Ф==0||Ф==2)Ч="║─"+Q.PadRight(4)+" ║";else Ч="║ "+Q.PadRight(4)+"─║";
Ц=" ░"+У+"░ ";}else if(Х==2){if(Ф==0||Ф==2){Ч="║ "+Q.PadRight(4)+"═║";Ц="║▒"+У+"░║";}else{Ч="║═"+Q.PadRight(4)+" ║";Ц=
"║░"+У+"▒║";}}else if(Х==3){if(Ф==0||Ф==2){Ч="║!"+Q.PadRight(4)+"!║";Ц="║▓"+У+"▓║";}else{Ч="║ "+У+" ║";Ц="║!"+Q.PadRight(4)+
"!║";}}}}Color Т=new Color(255,116,33,255);const int С=32;int Р=0;string[]П=new string[]{"▄ "," ▄"," ▀","▀ "},О=new string[]
{"─","\\","│","/"},Н=new string[]{"- ","= ","x ","! "};string Ъ,Ы,м,н,л="\n\n",к,й="╔══════╗",и="╚══════╝",з,ж,е,д,г,в,б,
а,Я,Ю,Э,Ь,Ɂ,ŋ,ƴ,ŉ,ň,Ň,ņ,Ņ,ń;void Ń(){й=й+й+й+й+"\n";и=и+и+и+и+"\n";Ъ=ƒ("Welcome to")+л+ƒ("R S M.")+л;Ы=ƒ("Initialising")+
л;м=new String(' ',С-8);н="└"+new String('─',С-2)+"┘";з=new String('-',26)+"\n";к="──"+л;ж=ł("Inventory");е=ł("Thrust");д
=ł("Power & Tanks");г=ł("Warnings");в=ł("Subsystem Integrity");б=ł("Telemetry & Thrust");а=ŀ("Velocity");Я=ŀ(
"Velocity (Max)");Ю=ŀ("Mass");Э=ŀ("Max Accel");Ь=ŀ("Actual Accel");Ɂ=ŀ("Accel (Best)");ŋ=ŀ("Max Thrust");ƴ=ŀ("Actual Thrust");ŉ=ŀ(
"Decel (Dampener)");ň=ŀ("Decel (Actual)");Ň=ľ("Fuel");ņ=ľ("Oxygen");Ņ=ľ("Battery");ń=ľ("Capacity");}string ł(string Ł){return"──┤ "+Ł+" ├"
+new String('─',С-9-Ł.Length);}string ŀ(string Ŀ){return"\n"+Ŀ+":"+new String(' ',С-16-Ŀ.Length);}string ľ(string Ľ){
return Ľ+new String(' ',С-22-Ľ.Length)+"[";}void ļ(){Р++;if(Р>=П.Length)Р=0;int Ļ=Р+2;if(Ļ>3)Ļ-=4;string Ŋ=П[Р];string Ō=О[Р];
string ŝ=П[Ļ];string Ş=ж+Ō+к;string Ŝ=е+Ō+к;string ś=д+Ō+к;string Ś=г+Ō+к;string ř=в+Ō+к;string Ř=б+Ō+к;string ŗ=ƒ(ʌ.ToUpper()
)+"\n"+"  "+Ŋ+" "+ƒ(đ,С-10)+" "+Ŋ+"  \n";string Ŗ="\n  "+ŝ+м+ŝ+"  "+л;if(Ή){string ŕ=Ъ+ƒ("Booting"+new string('.',Α))+л;Ş
+=ŕ;Ŝ+=ŕ;ś+=ŕ;Ś+=ŕ;ř+=ŕ;}else if(Έ){string Ŕ=Ы+ƒ(ʌ)+л;Ş+=Ŕ;Ŝ+=Ŕ;ś+=Ŕ;Ś+=Ŕ;ř+=Ŕ;}else{ʤ();double œ=9.81,Œ=Math.Round(Ρ),ő=
Math.Round((å/Π/œ),2),Ő=Math.Round((ä/Π/œ),2),ŏ=Math.Round(F+Á,1),Ŏ=Math.Round(Ä,1),ō=Math.Round(100*(ì/ë)),ĺ=Math.Round(100
*(m/Â)),Ĺ=Math.Round(100*(Ŏ/ŏ));string ĕ=а,Ĥ=" Gs",ģ;if(Œ<1){Œ=500;ĕ=Я;}if(ʂ){œ=1;Ĥ=" m/s/s";}foreach(Ģ Ģ in ϭ){if(Ģ.Ў!=0
){Ģ.Ͻ=(100*((double)Ģ.Џ/(double)Ģ.Ў));string ġ=(Ģ.Џ+"/"+Ģ.Ў).PadLeft(9);if(ġ.Length>9)ġ=ġ.Substring(0,9);Ş+=Ģ.ϯ+" ["+Ž(Ģ.
Ͻ)+"] "+ġ+"\n";}}Ş+="\n";if(ä>0)Ŝ=ň+ƍ(ä,Œ)+Ь+(Ő+Ĥ).PadLeft(15)+л;else Ŝ=ŉ+ƍ(å,Œ,true)+Ɂ+(ő+Ĥ).PadLeft(15)+л;ҕ=Math.Round(
100*(Õ/Ø));ś+=Ň+Ž(ҕ)+"] "+(ҕ+" %").PadLeft(9)+"\n"+ņ+Ž(ō)+"] "+(ō+" %").PadLeft(9)+"\n"+Ņ+Ž(ĺ)+"] "+(ĺ+" %").PadLeft(9)+
"\n"+ń+Ž(Ĺ)+"] "+(Ĺ+" %").PadLeft(9)+"\n"+"Max Power:"+(Ŏ+" MW / "+ŏ+" MW").PadLeft(22)+л;List<ё>Ġ=new List<ё>();List<Ш>ğ=
new List<Ш>();int Ğ=0;for(int ĝ=0;ĝ<Щ.Count;ĝ++){Щ[ĝ].э--;if(Щ[ĝ].э<1)Щ.RemoveAt(ĝ);else Ġ.Add(Щ[ĝ]);}if(!ų){Ġ.Add(new ё(
"NO LiDAR!","No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(ͺ){Ġ.Add(new ё("NO SPAWNS!",
"NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int Ĝ=0;if(ҕ<5){ģ="FUEL CRITICAL!";Ġ.Add(new ё(ģ,ģ+"\nFuel Level < 5%!",3));Ĝ=3;}else if(ҕ<25){ģ="FUEL LOW!";Ġ.Add
(new ё(ģ,ģ+"\nFuel Level < 10%!",2));Ĝ=2;}if(Đ.ā!=ƿ.Off){if(Δ){if(Ĝ==0)Ĝ=1;Ġ.Add(new ё("No spare fuel tanks",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",Ĝ));}if(Γ){if(Ĝ==0)Ĝ=1;Ġ.Add(new ё("No extractor","Cannot refuel!\nNo functional extractor!",Ĝ));}}ğ.Add(new Ш("FUEL",Ĝ
,Р+Ğ));Ğ++;int ě=0;if(ō<5){ģ="OXYGEN CRITICAL!";Ġ.Add(new ё(ģ,ģ+"\nShip O2 Level < 5%!",3));ě=3;}else if(ō<10){ģ=
"OXYGEN LOW!";Ġ.Add(new ё(ģ,ģ+"\nShip O2 Level < 10%!",2));ě=2;}else if(ō<25){ģ="Oxygen Low!";Ġ.Add(new ё(ģ,ģ+
"\nShip O2 Level < 25%!",1));ě=1;}if(ϊ.Count>Ű){int Ě=(ϊ.Count-Ű);ě++;ģ=Ě+" vents are unsealed";Ġ.Add(new ё(ģ,ģ,1));}if(ү>0){ģ=ү+
" doors are insecure";Ġ.Add(new ё(ģ,ģ,0));}if(Τ>0){ģ=ʭ+" is active ("+Τ+")";Ġ.Add(new ё(ģ,ģ,0));}ğ.Add(new Ш("OXYG",ě,Р+Ğ));Ğ++;int ę=0;if(Ϧ.
Count>0){if(ĺ<5){ę+=2;ģ="BATTERIES CRITICAL!";Ġ.Add(new ё(ģ,ģ+"\nBattery Level < 5%!",2));}else if(ĺ<10){ę+=1;ģ=
"Batteries Low!";Ġ.Add(new ё(ģ,ģ+"\nBattery Level < 10%!",1));}}if(Ϝ.Count>0){if(C>0){ę+=2;Ġ.Add(new ё(C+" REACTORS NEED FUS. FUEL!",
"At least one reactor needs Fusion Fuel!",3));}if(ϭ[0].Ў==0){if(ϭ[0].Џ>0){ę+=1;ģ="No Spare Fusion Fuel!";Ġ.Add(new ё(ģ,ģ,2));}}else if(ϭ[0].Ͻ<5){ę+=2;ģ=
"FUSION FUEL LEVEL CRITICAL!";Ġ.Add(new ё(ģ,ģ,3));}else if(ϭ[0].Ͻ<10){ę+=1;ģ="Fusion Fuel Level Low!";Ġ.Add(new ё(ģ,ģ,2));}}if(ę>3)ę=3;ğ.Add(new Ш(
"POWR",ę,Р+Ğ));Ğ++;int Ę=0;if(ˠ.Count>0){foreach(string ė in ˠ){string Ė=ė;if(ė.Length>23)Ė=ė.Substring(0,23);Ė=Ė.ToUpper();ģ=
"NEED "+Ė+"AMMO!";Ġ.Add(new ё(ģ,ģ,3));}Ę=3;}if(Ę>3)Ę=3;ğ.Add(new Ш("WEAP",Ę,Р+Ğ));Ğ++;if(Ͱ){string ĥ=ˮ;if(ϧ.Count>0)if(ϧ[0]!=
null)ĥ=(ϧ[0]as IMyRadioAntenna).HudText;string ħ="";if(ˬ<1000)ħ=Math.Round(ˬ)+"m";else ħ=Math.Round(ˬ/1000)+"km";Ġ.Add(new ё
("Comms ("+ħ+"): "+ĥ,"Antenna(s) are broadcasting at a range of "+ħ+" with the message "+ĥ,0));}if(Σ>0){ģ=Σ+
" UNOWNED BLOCKS!";Ġ.Add(new ё(ģ,ģ+"\nRSM detected "+Σ+" terminal blocks on this grid owned by a player with a different faction tag.",3))
;}if(ұ>Ұ){int ķ=(ұ-Ұ);ģ=ķ+" doors are open";Ġ.Add(new ё(ģ,ģ,0));}Ġ=Ġ.OrderBy(ĸ=>ĸ.ю).Reverse().ToList();if(Ġ.Count<1)Ś+=
"No warnings\n";else Echo(л+" WARNINGS:");for(int ĝ=0;ĝ<Ġ.Count;ĝ++){Ś+=Н[Ġ[ĝ].ю]+Ġ[ĝ].ѐ+"\n";Echo("-"+Н[Ġ[ĝ].ю]+Ġ[ĝ].я);}Ś+="\n";
string Ķ=Đ.ü.ToString().ToUpper();if(Ķ.Length>3)Ķ=Ķ.Substring(0,3);string ĵ=Đ.û.ToString().ToUpper();if(ĵ.Length>3)ĵ=ĵ.
Substring(0,3);string Ĵ=Đ.ü.ToString().ToUpper();if(Ĵ.Length>3)Ĵ=Ĵ.Substring(0,3);string ĳ=Đ.þ.ToString().ToUpper();if(ĳ.Length>3
)ĳ=ĳ.Substring(0,3);string Ĳ=Đ.Ā.ToString().ToUpper();if(Ĳ.Length>3)Ĳ=Ĳ.Substring(0,3);string ı=Đ.ý.ToString().ToUpper();
if(ı.Length>3)ı=ı.Substring(0,3);try{if(ã>0)ř+="Epstein   ["+Ž(â)+"] "+(â+"% ").PadLeft(5)+Ķ+"\n";if(Ȅ>0)ř+="RCS       ["+
Ž(ȅ)+"] "+(ȅ+"% ").PadLeft(5)+ĵ+"\n";if(F>0)ř+="Reactors  ["+Ž(D)+"] "+(D+"% ").PadLeft(5)+"    \n";if(Á>0)ř+=
"Batteries ["+Ž(M)+"] "+(M+"% ").PadLeft(5)+Ĵ+"\n";if(Ì>0)ř+="PDCs      ["+Ž(Ë)+"] "+(Ë+"% ").PadLeft(5)+ĳ+"\n";if(ȉ>0)ř+=
"Torpedoes ["+Ž(ȇ)+"] "+(ȇ+"% ").PadLeft(5)+Ĳ+"\n";if(Y>0)ř+="Railguns  ["+Ž(W)+"] "+(W+"% ").PadLeft(5)+ı+"\n";if(Ö>0)ř+=
"H2 Tanks  ["+Ž(Ô)+"] "+(Ô+"% ").PadLeft(5)+Ĵ+"\n";if(ê>0)ř+="O2 Tanks  ["+Ž(é)+"] "+(é+"% ").PadLeft(5)+Ĵ+"\n";if(Ҧ>0)ř+=
"Gyros     ["+Ž(Ҥ)+"] "+(Ҥ+"% ").PadLeft(5)+"    \n";if(ʣ>0)ř+="Cargo     ["+Ž(ʡ)+"] "+(ʡ+"% ").PadLeft(5)+"    \n";if(Ƥ>0)ř+=
"Welders   ["+Ž(Ƣ)+"] "+(Ƣ+"% ").PadLeft(5)+"    \n";}catch{}if(Á+F+Ö==0)ř+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+л;string İ="";string į="";foreach(Ш Į in ğ){İ+=Į.Ч;į+=Į.Ц;}int ĭ=Р+2;if(ĭ>3)ĭ-=4;ŗ+=й+İ+"\n"+и;Ŗ+=į;if(!Μ){Ř+=л;}else{
if(ʀ)Echo("Building advanced thrust...");string Ĭ="";if(ʄ){Ĭ=Ю+(Math.Round((Π/1000000),2)+" Mkg").PadLeft(15)+ĕ+(Œ+" ms").
PadLeft(15)+Э+(ő+Ĥ).PadLeft(15)+Ь+(Ő+Ĥ).PadLeft(15)+ŋ+((å/1000000)+" MN").PadLeft(15)+ƴ+((ä/1000000)+" MN").PadLeft(15);}Ř+=Ĭ+ŉ
+ƍ(å,Œ,true)+ň+ƍ(ä,Œ);foreach(double ī in ʃ){Ř+="\n"+("Decel ("+(ī*100)+"%):").PadRight(17)+ƍ((float)(å*ī),Œ);}Ř+=л;}}
foreach(ћ Ī in Ω){string ĩ="";Color Ħ=Đ.ó;if(Ī.љ)ĩ+=ŗ;if(Ī.ј){ĩ+=Ŗ;Ħ=Т;}if(Ī.ї)ĩ+=Ś;if(Ī.і)ĩ+=ś;if(Ī.ѕ)ĩ+=Ş;if(Ī.є)ĩ+=Ŝ;if(Ī.ѓ)
ĩ+=ř;if(Ī.ђ){ĩ+=Ř;Μ=true;}Ī.ɔ.WriteText(ĩ,false);if(!ʅ)Ī.ɔ.FontColor=Ħ;}}void ş(){if(Ϊ.Count>0){foreach(IMyTextPanel Ī in
Ϊ){Ī.FontColor=Đ.ó;}foreach(ћ Ī in Ω){Ī.ɔ.FontColor=Đ.ó;}}}void Ƃ(string Ɓ,string ƀ){Ɓ=Ɓ.ToLower();List<IMyTextPanel>ſ=
new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ϋ);foreach(IMyTextPanel Ī in Ϋ){if(ƀ==""||Ī.
CustomName.Contains(ƀ)){string ž=Ī.CustomData;if(ž.Contains("hudlcd")&&(Ɓ=="off"||Ɓ=="toggle"))Ī.CustomData=ž.Replace("hudlcd",
"hudXlcd");if(ž.Contains("hudXlcd")&&(Ɓ=="on"||Ɓ=="toggle"))Ī.CustomData=ž.Replace("hudXlcd","hudlcd");}}}string Ž(double ż){try{
int Ż=0;if(ż>0){int ź=(int)ż/10;if(ź>10)return new string('=',10);if(ź!=0)Ż=ź;}char Ź=' ';if(ż<10){if(Р==0)return
" ><    >< ";if(Р==1)return"  ><  ><  ";if(Р==2)return"   ><><   ";if(Р==3)return"<   ><   >";}string Ÿ=new string('=',Ż);string ŷ=
new string(Ź,10-Ż);return Ÿ+ŷ;}catch{return"# ERROR! #";}}string Ŷ(string ŵ){string ƃ;string ġ="";double ż=0;switch(ŵ){case
"H2":ż=Math.Round(100*(Õ/Ö));ġ=ż.ToString()+" %";ҕ=ż;break;case"O2":ż=Math.Round(100*(ì/ê));ġ=ż.ToString()+" %";break;case
"Battery":ż=Math.Round(100*(m/Â));ġ=ż.ToString()+" %";break;}ƃ=Ž(ż);return" ["+ƃ+"] "+ġ.PadLeft(9);}string ƒ(string Ƒ,int Ɛ=С){
int Ə=Ɛ-Ƒ.Length;int Ǝ=Ə/2+Ƒ.Length;return Ƒ.PadLeft(Ǝ).PadRight(Ɛ);}string ƍ(double ƌ,double Ƌ,bool Ɗ=false){if(ƌ<=0)
return("N/A").PadLeft(15);if(Ɗ)ƌ=ƌ*1.5;double Ɖ=0.5*(Math.Pow(Ƌ,2)*(Π/ƌ));double ƈ=Ƌ/(ƌ/Π);string Ƈ="m";if(Ɖ>1000){Ƈ="km";Ɖ=Ɖ/
1000;}return(Math.Round(Ɖ)+Ƈ+" "+Math.Round(ƈ)+"s").PadLeft(15);}void Ɔ(){foreach(IMyTextPanel Ŵ in Ϋ){Ŵ.Enabled=true;}}void
ƅ(){foreach(ћ Ī in Ω){Ī.ɔ.Font="Monospace";Ī.ɔ.ContentType=ContentType.TEXT_AND_IMAGE;if(Ī.ɔ.CustomName.Contains("HUD1"))
{Ī.љ=true;Ī.ј=false;Ī.ї=false;Ī.і=false;Ī.ѕ=false;Ī.є=false;Ī.ѓ=false;Ī.ђ=false;ɇ(Ī,"hudlcd:-0.55:0.99:0.7");continue;}if
(Ī.ɔ.CustomName.Contains("HUD2")){Ī.љ=false;Ī.ј=false;Ī.ї=true;Ī.і=false;Ī.ѕ=false;Ī.є=false;Ī.ѓ=false;Ī.ђ=false;ɇ(Ī,
"hudlcd:0.22:0.99:0.55");continue;}if(Ī.ɔ.CustomName.Contains("HUD3")){Ī.љ=false;Ī.ј=false;Ī.ї=false;Ī.і=true;Ī.ѕ=false;Ī.є=true;Ī.ѓ=false;Ī.ђ=
false;ɇ(Ī,"hudlcd:0.48:0.99:0.55");continue;}if(Ī.ɔ.CustomName.Contains("HUD4")){Ī.љ=false;Ī.ј=false;Ī.ї=false;Ī.і=false;Ī.ѕ=
false;Ī.є=false;Ī.ѓ=true;Ī.ђ=false;ɇ(Ī,"hudlcd:0.74:0.99:0.55");continue;}if(Ī.ɔ.CustomName.Contains("HUD5")){Ī.љ=false;Ī.ј=
false;Ī.ї=false;Ī.і=false;Ī.ѕ=true;Ī.є=false;Ī.ѓ=false;Ī.ђ=true;ɇ(Ī,"hudlcd:0.75:0:.54");continue;}if(Ī.ɔ.CustomName.Contains
("HUD6")){Ī.љ=false;Ī.ј=true;Ī.ї=false;Ī.і=false;Ī.ѕ=false;Ī.є=false;Ī.ѓ=false;Ī.ђ=false;ɇ(Ī,"hudlcd:-0.55:0.99:0.7");
continue;}}bool Ƅ=false;foreach(IMyTextPanel Ŵ in Ϋ){if(Ŵ==null)continue;if(!Ƅ&&(Ŵ.CustomName.Contains(ɼ)||Ŵ.CustomName.ToUpper(
).Contains(ʋ))){Ƅ=true;Ŵ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool ų;void Š(bool Ç,bool Ũ){ų=false;foreach(
IMyConveyorSorter ŧ in Φ){if(ŧ!=null&&ŧ.IsFunctional){ų=true;if(Ũ)ŧ.Enabled=Ç;}}}void Ŧ(Ǖ L){if(L==Ǖ.NoChange)return;foreach(
IMyReflectorLight ť in χ){if(ť==null)continue;if(L==Ǖ.Off)ť.Enabled=false;else{ť.Enabled=false;if(L==Ǖ.OnMax)ť.Radius=9999;}}}void Ť(Ǔ L,
Color Ħ){if(L==Ǔ.NoChange)return;foreach(IMyLightingBlock Ţ in Ψ){if(Ţ==null)continue;if(L==Ǔ.Off)Ţ.Enabled=false;else Ţ.
Enabled=true;if(L!=Ǔ.OnNoColourChange)Ţ.SetValue("Color",Ħ);}}void ţ(Ǔ L,Color Ħ){if(L==Ǔ.NoChange)return;foreach(
IMyLightingBlock Ţ in Ψ){if(Ţ==null)continue;if(L==Ǔ.Off)Ţ.Enabled=false;else Ţ.Enabled=true;if(L!=Ǔ.OnNoColourChange)Ţ.SetValue("Color"
,Ħ);}}Color š=new Color(255,0,0,255);Color ũ=new Color(255,0,0,255);Color Ū=new Color(255,0,0,255);void Ų(Ǔ L){if(L==Ǔ.
NoChange)return;foreach(IMyLightingBlock Ţ in ζ){ű(Ţ,L,ũ);}foreach(IMyLightingBlock Ţ in θ){ű(Ţ,L,Ū);}}void ű(IMyLightingBlock Ţ
,Ǔ L,Color Ħ){if(Ţ==null)return;if(L==Ǔ.Off){Ţ.Enabled=false;Ţ.SetValue("Color",š);}else{Ţ.Enabled=true;if(L!=Ǔ.
OnNoColourChange)Ţ.SetValue("Color",Ħ);}}int Ű=0;void ů(bool Ç,bool Ũ){Ű=0;foreach(IMyAirVent Ů in ϊ){if(Ů!=null){if(Ũ)Ů.Enabled=Ç;if(Ů.
CanPressurize)Ű++;}}}void ŭ(bool Ç){foreach(IMyShipConnector Ŭ in ϣ){if(Ŭ!=null)Ŭ.Enabled=Ç;}}void ū(bool Ç){foreach(IMyCameraBlock Ĕ
in ϥ){if(Ĕ!=null)Ĕ.Enabled=Ç;}}void º(bool Ç){foreach(IMySensorBlock µ in ϛ){if(µ!=null)µ.Enabled=Ç;}}void ª(){ͺ=true;
foreach(IMyTerminalBlock z in Ϛ){z.ApplyAction("OnOff_On");if(z.IsFunctional)ͺ=false;}}bool y=false;List<string>x=new List<
string>();bool w=false;List<string>v=new List<string>();void u(string n,string t){bool s=false;List<IMyProgrammableBlock>q=new
List<IMyProgrammableBlock>();try{if(t=="EFC")q=έ;else if(t=="NavOS")q=ά;foreach(IMyProgrammableBlock p in έ){if(p==null||!p.
Enabled)continue;s=(p as IMyProgrammableBlock).TryRun(n);if(s&&ʀ)Echo("Ran "+n+" on "+p.CustomName+" successfully.");else Щ.Add
(new ё(t+" command failed!",t+" command "+n+" failed!",1));if(t=="EFC")y=true;else if(t=="NavOS")w=true;break;}}catch(
Exception ex){Щ.Add(new ё(t+" command errored!",t+" command "+n+" errored!\n"+ex.Message,3));}}void o(string n,string t){if(t==
"EFC"){if(έ.Count<1)return;if(y){x.Add(n);return;}}if(t=="NavOS"){if(ά.Count<1)return;if(w){v.Add(n);return;}}u(n,t);}void À(
){if(x.Count>0&&!y){u(x[0],"EFC");x.RemoveAt(0);}if(v.Count>0&&!w){u(v[0],"NavOS");v.RemoveAt(0);}y=false;w=false;}int Ì=
0;double Í=0;double Ë=0;void Ê(){Í=0;foreach(IMyTerminalBlock Å in ε){É(Å,Đ.þ!=ǒ.Off&&Đ.þ!=ǒ.MinDefence);}foreach(
IMyTerminalBlock Å in δ){É(Å,Đ.þ!=ǒ.Off);}Ë=Math.Round(100*(Í/Ì));}void É(IMyTerminalBlock È,bool Ç){if(È!=null&&È.IsFunctional){Í++;(È
as IMyConveyorSorter).Enabled=Ç;}}void Æ(ǒ L){if(L==ǒ.NoChange)return;foreach(IMyTerminalBlock Å in ε){if(Å!=null&Å.
IsFunctional){switch(L){case ǒ.Off:case ǒ.MinDefence:(Å as IMyConveyorSorter).Enabled=false;break;case ǒ.AllDefence:(Å as
IMyConveyorSorter).Enabled=true;if(ʸ){try{Å.SetValue("WC_FocusFire",false);Å.SetValue("WC_Projectiles",true);Å.SetValue("WC_Grids",true);
Å.SetValue("WC_LargeGrid",false);Å.SetValue("WC_SmallGrid",true);Å.SetValue("WC_SubSystems",true);Å.SetValue(
"WC_Biologicals",true);ʨ(Å);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;case ǒ.Offence:(Å as IMyConveyorSorter).
Enabled=true;if(ʸ){try{Å.SetValue("WC_FocusFire",false);Å.SetValue("WC_Projectiles",true);Å.SetValue("WC_Grids",true);Å.
SetValue("WC_LargeGrid",true);Å.SetValue("WC_SmallGrid",true);Å.SetValue("WC_SubSystems",true);Å.SetValue("WC_Biologicals",true)
;ʨ(Å);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}foreach(IMyTerminalBlock Å in δ){if(Å!=null&
Å.IsFunctional){switch(L){case ǒ.Off:(Å as IMyConveyorSorter).Enabled=false;break;case ǒ.MinDefence:case ǒ.AllDefence:
case ǒ.Offence:(Å as IMyConveyorSorter).Enabled=true;if(ʸ){try{Å.SetValue("WC_FocusFire",false);Å.SetValue("WC_Projectiles",
true);Å.SetValue("WC_Grids",true);Å.SetValue("WC_LargeGrid",false);Å.SetValue("WC_SmallGrid",true);Å.SetValue(
"WC_SubSystems",true);Å.SetValue("WC_Biologicals",true);ʍ(Å);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}}
double Ä;void Ã(ǐ L){Ä=0;l(L);B();}double Â=0;double Á=0;double m=0;double M=0;void l(ǐ L){Â=0;m=0;foreach(IMyBatteryBlock H
in Ϧ){if(H!=null&&H.IsFunctional){m+=H.CurrentStoredPower;Â+=H.MaxStoredPower;Ä+=H.MaxOutput;H.Enabled=true;bool K=L==ǐ.
Discharge;if(K&&ʶ){if(V)H.ChargeMode=ChargeMode.Discharge;else H.ChargeMode=ChargeMode.Recharge;}}}M=Math.Round(100*(Ä/Á));}void
J(){Á=0;foreach(IMyBatteryBlock H in Ϧ){Á+=H.MaxOutput;}}void I(ǐ L){if(L==ǐ.NoChange)return;foreach(IMyBatteryBlock H in
Ϧ){if(H!=null&H.IsFunctional){H.Enabled=true;if(L==ǐ.Auto)H.ChargeMode=ChargeMode.Auto;else if(L==ǐ.StockpileRecharge)H.
ChargeMode=ChargeMode.Recharge;else if(!ʶ)H.ChargeMode=ChargeMode.Recharge;}}}double F=0;double E=0;double D=0;int C=0;void B(){E=
0;C=0;foreach(IMyReactor A in Ϝ){if(A!=null&&A.IsFunctional){A.Enabled=true;if(ы(A))C++;else E+=A.MaxOutput;}}D=Math.
Round(100*(E/F));Ä+=E;}void G(){F=0;foreach(IMyReactor A in Ϝ){F+=A.MaxOutput;}}void N(IMyProjector h){h.CustomData=h.
ProjectionOffset.X+"\n"+h.ProjectionOffset.Y+"\n"+h.ProjectionOffset.Z+"\n"+h.ProjectionRotation.X+"\n"+h.ProjectionRotation.Y+"\n"+h.
ProjectionRotation.Z+"\n";}void k(IMyProjector h){if(!h.IsFunctional)return;try{string[]f=h.CustomData.Split('\n');Vector3I e=new Vector3I
(int.Parse(f[0]),int.Parse(f[1]),int.Parse(f[2]));Vector3I Z=new Vector3I(int.Parse(f[3]),int.Parse(f[4]),int.Parse(f[5])
);h.Enabled=true;h.ProjectionOffset=e;h.ProjectionRotation=Z;h.UpdateOffsetAndRotation();}catch{if(ʀ)Echo(
"Failed to load projector position for "+h.Name);}}int Y=0;double X=0;double W=0;bool V=false;void U(){V=false;X=0;foreach(IMyTerminalBlock S in γ){if(S!=null&&
S.IsFunctional){X++;(S as IMyConveyorSorter).Enabled=Đ.ý!=Ǒ.Off;if(!V){MyDetectedEntityInfo?R=ǣ.ȗ(S);if(R.HasValue){
string Q=R.Value.Name;if(Q!=null&&Q!=""){if(ʀ)Echo("At least one rail has a target!");V=true;}}}}}W=Math.Round(100*(X/Y));}
void P(Ǒ L){if(L==Ǒ.NoChange)return;foreach(IMyTerminalBlock S in γ){if(S!=null&S.IsFunctional){if(L==Ǒ.Off){(S as
IMyConveyorSorter).Enabled=false;}else{(S as IMyConveyorSorter).Enabled=true;if(ʸ){S.SetValue("WC_Grids",true);S.SetValue("WC_LargeGrid",
true);S.SetValue("WC_SmallGrid",true);S.SetValue("WC_SubSystems",true);ʨ(S);}if(ʷ){if(L==Ǒ.OpenFire){ʥ(S);}else{ʦ(S);}}}}}}
class O{public string Î="";public Ɵ Ā;public ǒ þ;public Ǒ ý;public ǔ ü;public ǖ û;public Ǖ ú;public Ǔ ù;public Color ø;public
Ǔ ö;public Color õ;public Ǔ ô;public Color ó;public ǐ ò;public int ñ;public Ɵ ð;public ǀ ï;public Ɵ ÿ;public ƿ ā;public Ɵ
Ē;public ƾ ē;}string đ="N/A";O Đ;Ɵ ď=Ɵ.On;ǒ Ď=ǒ.Offence;Ǒ č=Ǒ.OpenFire;ǔ Č=ǔ.On;ǖ ċ=ǖ.On;Ǖ Ċ=Ǖ.On;Ǔ ĉ=Ǔ.On;Color Ĉ=new
Color(33,144,255,255);Ǔ ć=Ǔ.On;Color Ć=new Color(255,214,170,255);Ǔ ą=Ǔ.On;Color Ą=new Color(33,144,255,255);ǐ ă=ǐ.Auto;int Ă
=-1;Ɵ î=Ɵ.NoChange;ǀ í=ǀ.NoChange;Ɵ Ï=Ɵ.NoChange;ƿ Þ=ƿ.KeepFull;Ɵ Ý=Ɵ.On;ƾ Ü=ƾ.NoChange;void Û(string Ú){O Ù;if(!ѩ.
TryGetValue(Ú,out Ù)){Щ.Add(new ё("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ʀ)Echo("Setting stance '"+Ú+"'.");Đ=Ù;đ=Ú;ў();if(ʀ)Echo("Setting "+γ.Count+" railguns to "+Đ.ý);P(Đ.ý);
if(ʀ)Echo("Setting "+β.Count+" torpedoes to "+Đ.Ā);ǥ(Đ.Ā);if(ʀ)Echo("Setting "+ε.Count+" _normalPdcs, "+δ.Count+
" defence _normalPdcs to "+Đ.þ);Æ(Đ.þ);if(ʀ)Echo("Setting "+α.Count+" epsteins, "+ί.Count+" chems"+" to "+Đ.ü);Ȃ(Đ.ü,Đ.û);if(ʀ)Echo("Setting "+ΰ.
Count+" rcs, "+ή.Count+" atmos"+" to "+Đ.û);Ȏ(Đ.û);if(ʀ)Echo("Setting "+Ϧ.Count+" batteries to = "+Đ.ò);I(Đ.ò);if(ʀ)Echo(
"Setting "+ϙ.Count+" H2 tanks to stockpile = "+Đ.ò);Ð(Đ.ò);if(ʀ)Echo("Setting "+Ϙ.Count+" O2 tanks to stockpile = "+Đ.ò);æ(Đ.ò);if
(ʆ){if(ʀ)Echo("No lighting was set because lighting control is disabled.");}else{if(ʀ)Echo("Setting "+χ.Count+
" spotlights to "+Đ.ú);Ŧ(Đ.ú);if(ʀ)Echo("Setting "+Ψ.Count+" exterior lights to "+Đ.ù);Ť(Đ.ù,Đ.ø);if(ʀ)Echo("Setting "+Χ.Count+
" exterior lights to "+Đ.ö);ţ(Đ.ö,Đ.õ);if(ʀ)Echo("Setting "+ζ.Count+" port nav lights, "+θ.Count+" starboard nav lights to "+Đ.ô);Ų(Đ.ô);}if(ʀ
)Echo("Setting "+ψ.Count+" aux block to "+Đ.ÿ);ϖ(Đ.ÿ);if(ʀ)Echo("Setting "+Ϡ.Count+" extrators to "+Đ.ā);Ҕ(Đ.ā);if(ʀ)Echo
("Setting "+ϡ.Count+" hangar doors units to "+Đ.ē);ӂ(Đ.ē);if(Đ.ý==Ǒ.OpenFire){if(ʀ)Echo("Setting "+φ.Count+
" doors to locked because we are in combat (rails set to open fire).");Ӏ("locked","");}if(ʀ)Echo("Setting "+Ϊ.Count+" colour sync Lcds.");ş();if(Đ.ï==ǀ.Abort){o("Off","EFC");o("Abort",
"NavOS");}if(Đ.ñ>0){o("Set Burn "+Đ.ñ,"EFC");o("Thrust Set "+Đ.ñ/100,"NavOS");}if(Đ.ð==Ɵ.On)o("Boost On","EFC");else if(Đ.ð==Ɵ.
Off)o("Boost Off","EFC");if(ʀ)Echo("Finished setting stance.");}double Ø=0;double Ö=0;double Õ=0;double Ô=0;void Ó(){Õ=0;Ø=
0;foreach(IMyGasTank Ñ in ϙ){if(Ñ.IsFunctional){Ñ.Enabled=true;Ø+=Ñ.Capacity;Õ+=(Ñ.Capacity*Ñ.FilledRatio);}}Ô=Math.Round
(100*(Ø/Ö));}void Ò(){Ö=0;foreach(IMyGasTank Ñ in ϙ){if(Ñ!=null)Ö+=Ñ.Capacity;}}void Ð(ǐ L){if(L==ǐ.NoChange)return;
foreach(IMyGasTank Ñ in ϙ){if(Ñ==null)continue;Ñ.Enabled=true;if(L==ǐ.StockpileRecharge)Ñ.Stockpile=true;else Ñ.Stockpile=false
;}}double ë=0;double ì=0;double ê=0;double é=0;void è(){ì=0;ë=0;foreach(IMyGasTank Ñ in Ϙ){if(Ñ.IsFunctional){Ñ.Enabled=
true;ë+=Ñ.Capacity;ì+=(Ñ.Capacity*Ñ.FilledRatio);}}é=Math.Round(100*(ë/ê));}void ç(){ê=0;foreach(IMyGasTank Ñ in Ϙ){if(Ñ!=
null)ê+=Ñ.Capacity;}}void æ(ǐ L){if(L==ǐ.NoChange)return;foreach(IMyGasTank Ñ in Ϙ){if(Ñ==null)continue;Ñ.Enabled=true;if(L
==ǐ.StockpileRecharge)Ñ.Stockpile=true;else Ñ.Stockpile=false;}}float å;float ä;float ã;double â;void á(){float à=0;float
Ĩ=0;float ß=0;float Ɠ=0;foreach(IMyThrust Ȁ in α){if(Ȁ!=null&&Ȁ.IsFunctional){à+=Ȁ.MaxThrust;ß+=Ȁ.CurrentThrust;if(Ȁ.
Enabled){Ĩ+=Ȁ.MaxThrust;Ɠ+=Ȁ.CurrentThrust;}}}â=Math.Round(100*(à/ã));if(Ĩ==0){å=à;ä=ß;}else{å=Ĩ;ä=Ɠ;}}void ȃ(){ã=0;foreach(
IMyThrust Ȁ in α){if(Ȁ!=null)ã+=Ȁ.MaxThrust;}}void Ȃ(ǔ L,ǖ ǿ){if(L==ǔ.NoChange)return;foreach(IMyThrust Ȁ in α){ȁ(Ȁ,L,ǿ);}foreach
(IMyThrust Ȁ in ί){ȁ(Ȁ,L,ǿ,true);}}void ȁ(IMyThrust Ȁ,ǔ L,ǖ ǿ,bool Ǿ=false){bool ǽ=Ȁ.CustomName.Contains(ʪ);if(ǽ){if(ǿ!=ǖ
.Off&&ǿ!=ǖ.AtmoOnly)Ȁ.Enabled=true;else Ȁ.Enabled=false;}else{bool Ǽ=Ȁ.CustomName.Contains(ʫ);if((L==ǔ.On)||(L==ǔ.Minimum
&&Ǽ)||(L==ǔ.EpsteinOnly&&!Ǿ)||(L==ǔ.ChemOnly&&Ǿ)){Ȁ.Enabled=true;}else{Ȁ.Enabled=false;}}}float ǻ;float Ȅ;double ȅ;void Ȑ(
){ǻ=0;foreach(IMyThrust Ȁ in ΰ){if(Ȁ!=null&&Ȁ.IsFunctional){ǻ+=Ȁ.MaxThrust;}}ȅ=Math.Round(100*(ǻ/Ȅ));}void ȏ(){Ȅ=0;
foreach(IMyThrust Ȁ in ΰ){if(Ȁ!=null)Ȅ+=Ȁ.MaxThrust;}}void Ȏ(ǖ L){foreach(IMyThrust Ȁ in ΰ){if(Ȁ!=null)ȍ(Ȁ,L);}foreach(
IMyThrust Ȁ in ή){if(Ȁ!=null)ȍ(Ȁ,L,true);}}void ȍ(IMyThrust Ȁ,ǖ L,bool Ȍ=false){bool ȋ=Ȁ.GridThrustDirection==Vector3I.Backward;
bool Ȋ=Ȁ.GridThrustDirection==Vector3I.Forward;if((L==ǖ.On)||(L==ǖ.ForwardOff&&!ȋ)||(L==ǖ.ReverseOff&&!Ȋ)||(L==ǖ.RcsOnly&&!Ȍ
)||(L==ǖ.AtmoOnly&&Ȍ)){Ȁ.Enabled=true;}else{Ȁ.Enabled=false;}}int ȉ=0;double Ȉ=0;double ȇ=0;void Ȇ(){Ȉ=0;foreach(
IMyTerminalBlock Ǥ in β){if(Ǥ!=null&&Ǥ.IsFunctional){Ȉ++;(Ǥ as IMyConveyorSorter).Enabled=Đ.Ā==Ɵ.On;if(ʻ){string Ǻ=ǣ.ƶ(Ǥ,0);int ė=Л(Ǻ);
if(ʀ)Echo("Launcher "+Ǥ.CustomName+" needs "+Ǻ+"("+ė+")");ϫ(Ǥ,ė);}}}ȇ=Math.Round(100*(Ȉ/ȉ));}void ǥ(Ɵ L){if(L==Ɵ.NoChange)
return;foreach(IMyTerminalBlock Ǥ in β){if(Ǥ!=null&Ǥ.IsFunctional){if(L==Ɵ.Off){(Ǥ as IMyConveyorSorter).Enabled=false;}else{(
Ǥ as IMyConveyorSorter).Enabled=true;if(ʸ){Ǥ.SetValue("WC_FocusFire",true);Ǥ.SetValue("WC_Grids",true);Ǥ.SetValue(
"WC_LargeGrid",true);Ǥ.SetValue("WC_SmallGrid",false);Ǥ.SetValue("WC_FocusFire",true);Ǥ.SetValue("WC_SubSystems",true);ʨ(Ǥ);}}}}}Ǣ ǣ;
class Ǣ{private Action<ICollection<MyDefinitionId>>ǡ;private Action<ICollection<MyDefinitionId>>Ǡ;private Action<ICollection<
MyDefinitionId>>ǟ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>Ǟ;private Func<long,MyTuple<bool,
int,int>>ǝ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>ǜ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>Ǜ;private Func<long,int,
MyDetectedEntityInfo>ǚ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ǚ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>ǘ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>Ǧ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>Ǩ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>Ǹ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>ǹ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ƿ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>Ƕ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>ǵ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ǵ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ǲ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>ǰ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>Ǯ;private Func<MyDefinitionId,float>ǭ;private Func<long,bool>Ǭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>ǫ;private Func<long,float>Ǫ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ǩ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>ȑ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>ț;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>ȵ;private Func<long,float>ȳ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ȳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ȱ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȱ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ȯ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>Ȯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>ȭ;public bool Ȭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȫ){var Ȫ=ȫ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(ȫ);if(Ȫ==null)throw new Exception("WcPbAPI failed to activate");return ȩ(Ȫ);}public bool ȩ
(IReadOnlyDictionary<string,Delegate>Ȧ){if(Ȧ==null)return false;Ȩ(Ȧ,"GetCoreWeapons",ref ǡ);Ȩ(Ȧ,"GetCoreStaticLaunchers",
ref Ǡ);Ȩ(Ȧ,"GetCoreTurrets",ref ǟ);Ȩ(Ȧ,"GetBlockWeaponMap",ref Ǟ);Ȩ(Ȧ,"GetProjectilesLockedOn",ref ǝ);Ȩ(Ȧ,
"GetSortedThreats",ref ǜ);Ȩ(Ȧ,"GetObstructions",ref Ǜ);Ȩ(Ȧ,"GetAiFocus",ref ǚ);Ȩ(Ȧ,"SetAiFocus",ref Ǚ);Ȩ(Ȧ,"GetWeaponTarget",ref ǘ);Ȩ(Ȧ,
"SetWeaponTarget",ref Ǧ);Ȩ(Ȧ,"FireWeaponOnce",ref Ǩ);Ȩ(Ȧ,"ToggleWeaponFire",ref Ǹ);Ȩ(Ȧ,"IsWeaponReadyToFire",ref ǹ);Ȩ(Ȧ,
"GetMaxWeaponRange",ref Ƿ);Ȩ(Ȧ,"GetTurretTargetTypes",ref Ƕ);Ȩ(Ȧ,"SetTurretTargetTypes",ref ǵ);Ȩ(Ȧ,"SetBlockTrackingRange",ref Ǵ);Ȩ(Ȧ,
"IsTargetAligned",ref ǳ);Ȩ(Ȧ,"IsTargetAlignedExtended",ref ǲ);Ȩ(Ȧ,"CanShootTarget",ref Ǳ);Ȩ(Ȧ,"GetPredictedTargetPosition",ref ǰ);Ȩ(Ȧ,
"GetHeatLevel",ref ǯ);Ȩ(Ȧ,"GetCurrentPower",ref Ǯ);Ȩ(Ȧ,"GetMaxPower",ref ǭ);Ȩ(Ȧ,"HasGridAi",ref Ǭ);Ȩ(Ȧ,"HasCoreWeapon",ref ǫ);Ȩ(Ȧ,
"GetOptimalDps",ref Ǫ);Ȩ(Ȧ,"GetActiveAmmo",ref ǩ);Ȩ(Ȧ,"SetActiveAmmo",ref ǧ);Ȩ(Ȧ,"MonitorProjectile",ref ȑ);Ȩ(Ȧ,"UnMonitorProjectile",
ref ț);Ȩ(Ȧ,"GetProjectileState",ref ȵ);Ȩ(Ȧ,"GetConstructEffectiveDps",ref ȳ);Ȩ(Ȧ,"GetPlayerController",ref Ȳ);Ȩ(Ȧ,
"GetWeaponAzimuthMatrix",ref ȱ);Ȩ(Ȧ,"GetWeaponElevationMatrix",ref Ȱ);Ȩ(Ȧ,"IsTargetValid",ref ȯ);Ȩ(Ȧ,"GetWeaponScope",ref Ȯ);Ȩ(Ȧ,"IsInRange",ref
ȭ);return true;}private void Ȩ<ȧ>(IReadOnlyDictionary<string,Delegate>Ȧ,string ȴ,ref ȧ ȶ)where ȧ:class{if(Ȧ==null){ȶ=null
;return;}Delegate ȿ;if(!Ȧ.TryGetValue(ȴ,out ȿ))throw new Exception(
$"{GetType().Name} :: Couldn't find {ȴ} delegate of type {typeof(ȧ)}");ȶ=ȿ as ȧ;if(ȶ==null)throw new Exception(
$"{GetType().Name} :: Delegate {ȴ} is not type {typeof(ȧ)}, instead it's: {ȿ.GetType()}");}public void ɀ(ICollection<MyDefinitionId>Ȝ)=>ǡ?.Invoke(Ȝ);public void Ⱦ(ICollection<MyDefinitionId>Ȝ)=>Ǡ?.Invoke(Ȝ);
public void Ƚ(ICollection<MyDefinitionId>Ȝ)=>ǟ?.Invoke(Ȝ);public bool ȼ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȼ,IDictionary<
string,int>Ȝ)=>Ǟ?.Invoke(Ȼ,Ȝ)??false;public MyTuple<bool,int,int>Ⱥ(long ȹ)=>ǝ?.Invoke(ȹ)??new MyTuple<bool,int,int>();public
void ȸ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ș,IDictionary<MyDetectedEntityInfo,float>Ȝ)=>ǜ?.Invoke(Ș,Ȝ);public void ȷ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ș,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ȝ)=>Ǜ?.Invoke(Ș,Ȝ);public
MyDetectedEntityInfo?ȥ(long Ȥ,int Ȓ=0)=>ǚ?.Invoke(Ȥ,Ȓ);public bool ș(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ș,long ȕ,int Ȓ=0)=>Ǚ?.Invoke(Ș,ȕ
,Ȓ)??false;public MyDetectedEntityInfo?ȗ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ=0)=>ǘ?.Invoke(Ɣ,ƕ);public void Ȗ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,long ȕ,int ƕ=0)=>Ǧ?.Invoke(Ɣ,ȕ,ƕ);public void Ȕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Ɣ,bool ȓ=true,int ƕ=0)=>Ǩ?.Invoke(Ɣ,ȓ,ƕ);public void Ț(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,bool ȣ,bool ȓ,int ƕ=0)=>Ǹ
?.Invoke(Ɣ,ȣ,ȓ,ƕ);public bool Ȣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ=0,bool ȡ=true,bool Ƞ=false)=>ǹ?.Invoke(Ɣ,ƕ
,ȡ,Ƞ)??false;public float ȟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ)=>Ƿ?.Invoke(Ɣ,ƕ)??0f;public bool Ȟ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ɣ,IList<string>Ȝ,int ƕ=0)=>Ƕ?.Invoke(Ɣ,Ȝ,ƕ)??false;public void ȝ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɣ,IList<string>Ȝ,int ƕ=0)=>ǵ?.Invoke(Ɣ,Ȝ,ƕ);public void Ǘ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,float Ƴ)=>Ǵ?.Invoke(
Ɣ,Ƴ);public bool Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,long Ư,int ƕ)=>ǳ?.Invoke(Ɣ,Ư,ƕ)??false;public MyTuple<bool,
Vector3D?>Ʊ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,long Ư,int ƕ)=>ǲ?.Invoke(Ɣ,Ư,ƕ)??new MyTuple<bool,Vector3D?>();public bool
ư(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,long Ư,int ƕ)=>Ǳ?.Invoke(Ɣ,Ư,ƕ)??false;public Vector3D?Ʈ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Ɣ,long Ư,int ƕ)=>ǰ?.Invoke(Ɣ,Ư,ƕ)??null;public float ƽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ)=>ǯ?.
Invoke(Ɣ)??0f;public float Ƽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ)=>Ǯ?.Invoke(Ɣ)??0f;public float ƻ(MyDefinitionId ƺ)=>ǭ?.
Invoke(ƺ)??0f;public bool ƹ(long Ƙ)=>Ǭ?.Invoke(Ƙ)??false;public bool Ƹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ)=>ǫ?.Invoke(Ɣ)
??false;public float Ʒ(long Ƙ)=>Ǫ?.Invoke(Ƙ)??0f;public string ƶ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ)=>ǩ?.
Invoke(Ɣ,ƕ)??null;public void Ƶ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ,string ƭ)=>ǧ?.Invoke(Ɣ,ƕ,ƭ);public void Ƭ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ,Action<long,int,ulong,long,Vector3D,bool>Ɯ)=>ȑ?.Invoke(Ɣ,ƕ,Ɯ);public void Ɲ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ,Action<long,int,ulong,long,Vector3D,bool>Ɯ)=>ț?.Invoke(Ɣ,ƕ,Ɯ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>ƛ(ulong ƚ)=>ȵ?.Invoke(ƚ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ƙ(long Ƙ)=>ȳ?.Invoke(Ƙ)??0f;public long Ɨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ)=>Ȳ?.Invoke(Ɣ)??-1;public
Matrix Ɩ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ)=>ȱ?.Invoke(Ɣ,ƕ)??Matrix.Zero;public Matrix ƞ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɣ,int ƕ)=>Ȱ?.Invoke(Ɣ,ƕ)??Matrix.Zero;public bool ƫ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,long ƪ,bool Ʃ,bool ƨ)=>ȯ?.
Invoke(Ɣ,ƪ,Ʃ,ƨ)??false;public MyTuple<Vector3D,Vector3D>Ƨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɣ,int ƕ)=>Ȯ?.Invoke(Ɣ,ƕ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>Ʀ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƥ)=>ȭ?.Invoke(ƥ)??new MyTuple<
bool,bool>();}int Ƥ=0;double ƣ=0;double Ƣ=0;void ơ(){ƣ=0;foreach(IMyTerminalBlock Ơ in ω){if(Ơ!=null&&Ơ.IsFunctional)ƣ++;}Ƣ=
Math.Round(100*(ƣ/Ƥ));}enum Ɵ{
    Off, On, NoChange
    }enum Ǔ{
    Off, On, NoChange, OnNoColourChange
    }enum ǒ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum Ǒ{
    Off, HoldFire, OpenFire, NoChange
    }enum ǔ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum ǖ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum Ǖ{
    On, Off, OnMax, NoChange
    }enum ǐ{
    Auto, StockpileRecharge, Discharge, NoChange
    }enum ǀ{
    Abort, NoChange
    }enum ƿ{
    Off, On, FillWhenLow, KeepFull,
    }enum ƾ{
    Closed, Open, NoChange
    }
}sealed class ǁ{public double ǂ{get;private set;}private double ǎ{get{double Ǐ=ǆ[0];for(int ĝ=1;ĝ<ǈ;ĝ++){Ǐ+=ǆ[ĝ];}return(
Ǐ/ǈ);}}public double Ǎ{get{double ǌ=ǆ[0];for(int ĝ=1;ĝ<ǈ;ĝ++){if(ǆ[ĝ]>ǌ){ǌ=ǆ[ĝ];}}return ǌ;}}public double ǋ{get;private
set;}public double Ǌ{get{double ǉ=ǆ[0];for(int ĝ=1;ĝ<ǈ;ĝ++){if(ǆ[ĝ]<ǉ){ǉ=ǆ[ĝ];}}return ǉ;}}public int ǈ{get;}private double
Ǉ;private IMyGridProgramRuntimeInfo Ǆ;private double[]ǆ;private int ǅ=0;public ǁ(IMyGridProgramRuntimeInfo Ǆ,int ʏ=300){
this.Ǆ=Ǆ;this.ǋ=Ǆ.LastRunTimeMs;this.ǈ=MathHelper.Clamp(ʏ,1,int.MaxValue);this.Ǉ=1.0/ǈ;this.ǆ=new double[ʏ];this.ǆ[ǅ]=Ǆ.
LastRunTimeMs;this.ǅ++;}public void ǃ(){ǂ-=ǆ[ǅ]*Ǉ;ǂ+=Ǆ.LastRunTimeMs*Ǉ;ǆ[ǅ]=Ǆ.LastRunTimeMs;if(Ǆ.LastRunTimeMs>ǋ){ǋ=Ǆ.LastRunTimeMs;}
ǅ++;if(ǅ>=ǈ){ǅ=0;ǂ=ǎ;ǋ=Ǆ.LastRunTimeMs;}}