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

string Version = "1.99.58 (2024-05-04)";
ǁ Ζ;int Ε=0;int Δ=0;int Γ=0;int Β;int Α=0;bool ΐ=true;bool Ώ=true;bool Ύ=false;bool Ό=false;bool Ί=false;bool Ή=false;
bool Έ=false;bool Ά=false;bool Η=false;string Θ="";int Χ=0;int Ψ=0;double Φ;float Υ;string Τ;string Σ;string Ρ;bool Π=false;
int Ο=0;int Ξ=0;bool Ν;bool Μ;bool Λ;Program(){Echo("Welcome to RSM\nV "+Version);ͺ();Β=ʏ;Τ=Me.GetOwnerFactionTag();Ζ=new ǁ
(Runtime);ϻ();ʅ.Add(0.5);ʅ.Add(0.25);ʅ.Add(0.1);ʅ.Add(0.05);Ń();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo(
"Took "+ͺ());}void Main(string o,UpdateType Κ){if(Κ==UpdateType.Update100)ˊ();else Ι(o);}void Ι(string o){if(ʂ)Echo(
"Processing command '"+o+"'...");if(Ώ){ˌ(o,"RSM is still booting");return;}if(Ύ){ˌ(o,"RSM is still initialising");return;}if(o==""){ˌ(o,
"the argument was blank");return;}string[]ͽ=o.Split(':');if(ͽ.Length<2){ˌ(o,"the argument wasn't recognised");return;}if(ͽ[0].ToLower()!="comms"
)ͽ[1]=ͽ[1].Replace(" ",string.Empty);switch(ͽ[0].ToLower()){case"init":bool ˁ=true,ˑ=true,ː=true;if(ͽ.Length>2){foreach(
string ˏ in ͽ){if(ˏ.ToLower()=="nonames")ˁ=false;else if(ˏ.ToLower()=="nosubs")ˑ=false;else if(ˏ.ToLower()=="noinv")ː=false;}}
ң(ͽ[1],ˁ,ˑ,ː);return;case"stance":Û(ͽ[1]);return;case"hudlcd":string ˎ="";if(ͽ.Length>2)ˎ=ͽ[2];Ƃ(ͽ[1],ˎ);return;case
"doors":string ˍ="";if(ͽ.Length>2)ˍ=ͽ[2];ӂ(ͽ[1],ˍ);return;case"comms":Ͱ(ͽ[1]);return;case"printblockids":ɖ();return;case
"printblockprops":ɒ(ͽ[1]);return;case"spawn":if(ͽ[1].ToLower()=="open"){Έ=true;Β=ʏ;}else{Έ=false;Β=ʏ;}return;case"projectors":if(ͽ[1].
ToLower()=="save"){foreach(IMyProjector h in Ϟ)l(h);Ъ.Add(new ђ("Projector positions saved",
"Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector h in Ϟ)k(h);Ъ.Add(new ђ("Projector positions loaded",
"Projector positions were loaded from custom data.",2));return;}default:ˌ(o,"the argument wasn't recognised");return;}}void ˌ(string o,string ˋ){Ъ.Add(new ђ(
"COMMAND FAILED!","Command '"+o+"' was ignored because "+ˋ,3));}void ˊ(){if(ʁ)ͺ();if(Δ<ʀ){Δ++;return;}Δ=0;if(ΐ){Echo(
"Parsing custom data...");Ѥ();ΐ=false;return;}else if(Ύ){Ѝ();if(ʂ)Echo("Updating "+ά.Count+" RSM Lcds");ļ();}ˢ();Ο=Runtime.
CurrentInstructionCount;if(Ο>Ξ)Ξ=Runtime.CurrentInstructionCount;if(đ.ē==ơ.On){Ό=true;Ί=true;}else if(đ.ē==ơ.Off){Ό=true;}if(Β>=ʏ){Β=0;ˆ();
return;}Β++;ˉ();ˈ();if(ʁ)Echo("Took "+ͺ());if(ʂ)Echo("Updating "+ά.Count+" RSM Lcds");ļ();if(ʁ)Echo("Took "+ͺ());}void ˉ(){ˠ()
;switch(Ε){case 0:if(ʂ)Echo("Refreshing "+ζ.Count+" railguns...");U();if(ʁ)Echo("Took "+ͺ());if(Ώ)break;else goto case 1;
case 1:if(ʂ)Echo("Refreshing "+ϝ.Count+" reactors & "+Ϧ.Count+" batteries...");Ä(đ.ó);if(ʁ)Echo("Took "+ͺ());if(Ώ)break;else
goto case 2;case 2:if(ʂ)Echo("Refreshing "+δ.Count+" epsteins...");â();if(ʁ)Echo("Took "+ͺ());if(Ώ)break;else goto case 3;
case 3:if(ʂ)Echo("Refreshing "+ι.Count+" lidars...");Š(Ί,Ό);if(ʁ)Echo("Took "+ͺ());if(ʂ)Echo("Refreshing pb servers...");Á()
;if(ʁ)Echo("Took "+ͺ());if(Ώ)break;else goto case 4;case 4:if(ʂ)Echo("Refreshing "+ψ.Count+" doors...");Ӊ();if(ʁ)Echo(
"Took "+ͺ());if(ʂ)Echo("Refreshing "+χ.Count+" airlocks...");Ҿ();if(ʁ)Echo("Took "+ͺ());break;default:if(ʂ)Echo(
"Booting complete");Ώ=false;Ε=0;return;}if(Ώ)Ε++;}void ˈ(){switch(Γ){case 0:if(ʂ)Echo("Clearing temp inventories...");Ϻ();if(ʁ)Echo(
"Took "+ͺ());if(ʂ)Echo("Refreshing "+ε.Count+" torpedo launchers...");ȇ();if(ʁ)Echo("Took "+ͺ());if(ʂ)Echo(
"Refreshing items...");Ϲ();if(ʁ)Echo("Took "+ͺ());break;case 1:if(ʂ)Echo("Running autoload...");ˤ();if(ʁ)Echo("Took "+ͺ());break;case 2:if(ʂ)
Echo("Refreshing "+Ϛ.Count+" H2 tanks...");Ó();if(ʁ)Echo("Took "+ͺ());if(ʂ)Echo("Refreshing refuel status...");ғ();if(Ή){if(
ʂ)Echo("Fuel low, filling extractors...");ҫ();if(ʁ)Echo("Took "+ͺ());return;}else{ˇ();if(ʁ)Echo("Took "+ͺ());}Γ=0;return;
}Γ++;}void ˇ(){if(ʂ)Echo("Refreshing "+γ.Count+" rcs...");ȑ();if(ʂ)Echo("Refreshing "+θ.Count+" Pdcs & "+η.Count+
" defensive Pdcs...");Ê();if(ʂ)Echo("Refreshing "+ϟ.Count+" gyros...");ҥ(Ί,Ό);if(ʂ)Echo("Refreshing "+ύ.Count+" O2 tanks...");é();if(ʂ)Echo(
"Refreshing "+ϧ.Count+" antennas...");ͱ();if(ʂ)Echo("Refreshing "+Ϥ.Count+" cargos...");ʢ();if(ʂ)Echo("Refreshing "+λ.Count+
" vents...");Ű(Ί,Ό);if(ʂ)Echo("Refreshing "+ϊ.Count+" auxiliary blocks...");ϐ();if(ʂ)Echo("Refreshing "+Ϊ.Count+" welders...");ƣ();
if(ʂ)Echo("Refreshing "+ή.Count+" lcds...");Ɔ();if(ʂ)Echo("Refreshing "+ϛ.Count+" lcds...");µ();if(Ό){if(ʂ)Echo(
"Refreshing "+ϣ.Count+" connectors...");Ů(Ί);if(ʂ)Echo("Refreshing "+ϥ.Count+" cameras...");Ŭ(Ί);if(ʂ)Echo("Refreshing "+Ϝ.Count+
" sensors...");À(Ί);}}void ˆ(){if(ʂ)Echo("Clearing block lists...");ɭ();if(ʁ)Echo("Took "+ͺ());if(ʂ)Echo("Refreshing block lists...")
;GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,υ);if(ʁ)Echo("Took "+ͺ());if(ʂ)Echo(
"Setting KeepFull threshold");Ҕ();if(Ϩ==null){if(Ϫ.Count>0)Ϩ=Ϫ[0];else Ъ.Add(new ђ("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ʂ)Echo("Finished block refresh.");if(ʁ)Echo("Took "+ͺ());}void ˠ(){try{ǣ=new Ǣ();ǣ.Ȭ(Me);}catch(Exception ex){ǣ
=null;Ъ.Add(new ђ("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ˢ(){string ͻ="REEDIT SHIP MANAGEMENT \n\n";if(Ώ)ͻ+="Booting, please wait ("+Ε+"/5)...\n\n";ͻ+=
"|- V "+Version+"\n|- Ship Name: "+ʑ+"\n|- Stance: "+Ē+"\n|- Step: "+Β+"/"+ʏ+" ("+Γ+")";if(ʁ){Ζ.Ǆ();ͻ+="\n|- Runtime Av/Tick: "
+(Math.Round(Ζ.ǃ,2)/100)+" ms"+"\n|- Runtime Max: "+Math.Round(Ζ.ǎ,4)+" ms"+"\n|- Instructions: "+Ο+" ("+Ξ+")";}Echo(ͻ+
"\n");}long ͼ=0;string ͺ(){long ͷ=DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;if(ͼ==0){ͼ=ͷ;return"0 ms";}long Ͷ=ͷ-ͼ;ͼ=ͷ;
return Ͷ+" ms";}bool ʹ=false;string ͳ="";double Ͳ=0;void ͱ(){ʹ=false;Ͳ=0;foreach(IMyRadioAntenna ˬ in ϧ){if(ˬ!=null&&!ˬ.Closed
&&ˬ.IsFunctional){float Ơ=ˬ.Radius;if(Ơ>Ͳ)Ͳ=Ơ;if(ˬ.IsBroadcasting&&ˬ.Enabled)ʹ=true;}}}void Ͱ(string ˮ){ͳ=ˮ;foreach(
IMyTerminalBlock ɑ in ϧ){IMyRadioAntenna ˬ=ɑ as IMyRadioAntenna;if(ˬ!=null)ˬ.HudText=ˮ;}}void ˤ(){if(!ʽ)return;foreach(var ɬ in ϯ){if(!ɬ
.ϴ&&!ɬ.ϳ)continue;if(ʂ)Echo("Checking "+ɬ.ϲ);List<Е>ˡ=ɬ.Ϭ.Concat(ɬ.Ϸ).ToList();List<Е>ˣ=new List<Е>();List<Е>Ω=new List<Е
>();List<Е>ϙ=new List<Е>();List<Е>Ϙ=new List<Е>();List<Е>ϗ=new List<Е>();int ϖ=0;int ϕ=0;double ϔ=.97;if(ɬ.ϰ<1)ϔ=ɬ.ϰ*.97;
foreach(Е ϓ in ˡ){if(ϓ==null)continue;if(ϓ.В){ϕ++;ϖ+=ϓ.Г;if(ϓ.Б<ϔ)ϙ.Add(ϓ);else if(ɬ.ϰ<1&&ϓ.Б>ɬ.ϰ*1.03)Ϙ.Add(ϓ);if(ϓ.Б!=0)Ω.Add
(ϓ);}else{ϗ.Add(ϓ);if(ϓ.Г>0){ˣ.Add(ϓ);}}}if(ϙ.Count>0){int ϒ=(int)(ϖ/ϕ);ϙ=ϙ.OrderBy(Ķ=>Ķ.Г).ToList();if(ɬ.Ѐ>0){if(ʂ)Echo(
"Loading "+ɬ.ϵ.SubtypeId+"...");ˣ=ˣ.OrderByDescending(Ķ=>Ķ.Г).ToList();щ(ˣ,ϙ,ɬ.ϵ,-1,ɬ.ϰ);}else{if(ʂ)Echo("Balancing "+ɬ.ϵ.
SubtypeId+"...");Ω=Ω.OrderByDescending(Ķ=>Ķ.Г).ToList();щ(Ω,ϙ,ɬ.ϵ,ϒ);}}else if(Ϙ.Count>0){if(ʂ)Echo("Unloading "+ɬ.ϵ.SubtypeId+
"...");List<Е>ϑ=new List<Е>();if(ˣ.Count>0)ϑ=ˣ;else ϑ=ϗ;щ(Ϙ,ϑ,ɬ.ϵ,-1,1,ɬ.ϰ);}else{if(ʂ)Echo("No loading required "+ɬ.ϵ.
SubtypeId+"...");}}}void ϐ(){Ψ=0;foreach(IMyTerminalBlock ɑ in ϊ){if(ɑ==null)continue;if(ɑ.IsWorking)Ψ++;}}void Ϗ(ơ I){if(I==ơ.
NoChange)return;foreach(IMyTerminalBlock ɑ in ϊ){if(ɑ==null)continue;try{bool ώ=ɑ.BlockDefinition.ToString().Contains("ToolCore"
);if(I==ơ.On||ώ)ɑ.ApplyAction("OnOff_On");else if(!ώ)ɑ.ApplyAction("OnOff_Off");if(ώ){ITerminalAction ƞ=ɑ.
GetActionWithName("ToolCore_Shoot_Action");if(ƞ!=null){StringBuilder ϫ=new StringBuilder();ƞ.WriteValue(ɑ,ϫ);string ϩ=ϫ.ToString();if(ʂ)
Echo(ϩ);if(ϩ=="Active"&&I==ơ.Off)ƞ.Apply(ɑ);else if(ϩ=="Inactive"&&I==ơ.On)ƞ.Apply(ɑ);}}}catch{if(ʂ)Echo(
"Failed to set aux block "+ɑ.CustomName);}}}IMyShipController Ϩ;List<IMyRadioAntenna>ϧ=new List<IMyRadioAntenna>();List<IMyBatteryBlock>Ϧ=new List
<IMyBatteryBlock>();List<IMyCameraBlock>ϥ=new List<IMyCameraBlock>();List<IMyCargoContainer>Ϥ=new List<IMyCargoContainer>
();List<IMyShipConnector>ϣ=new List<IMyShipConnector>();List<IMyShipController>Ϫ=new List<IMyShipController>();List<
IMyAirtightHangarDoor>Ϣ=new List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>ϡ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ϡ=new
List<IMyTerminalBlock>();List<IMyGyro>ϟ=new List<IMyGyro>();List<IMyProjector>Ϟ=new List<IMyProjector>();List<IMyReactor>ϝ=
new List<IMyReactor>();List<IMySensorBlock>Ϝ=new List<IMySensorBlock>();List<IMyTerminalBlock>ϛ=new List<IMyTerminalBlock>(
);List<IMyGasTank>Ϛ=new List<IMyGasTank>();List<IMyGasTank>ύ=new List<IMyGasTank>();List<IMyAirVent>λ=new List<IMyAirVent
>();List<IMyTerminalBlock>Ϊ=new List<IMyTerminalBlock>();List<IMyConveyorSorter>ι=new List<IMyConveyorSorter>();List<
IMyTerminalBlock>θ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>η=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ζ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>ε=new List<IMyTerminalBlock>();List<IMyThrust>δ=new List<IMyThrust>();List<IMyThrust>γ=new
List<IMyThrust>();List<IMyThrust>β=new List<IMyThrust>();List<IMyThrust>α=new List<IMyThrust>();List<IMyProgrammableBlock>ΰ=
new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>ί=new List<IMyProgrammableBlock>();List<IMyTextPanel>ή=new List<
IMyTextPanel>();List<IMyTextPanel>έ=new List<IMyTextPanel>();List<ќ>ά=new List<ќ>();List<IMyLightingBlock>Ϋ=new List<
IMyLightingBlock>();List<IMyLightingBlock>κ=new List<IMyLightingBlock>();List<IMyLightingBlock>μ=new List<IMyLightingBlock>();List<
IMyLightingBlock>ϋ=new List<IMyLightingBlock>();List<IMyReflectorLight>ό=new List<IMyReflectorLight>();List<IMyTerminalBlock>ϊ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>ω=new List<IMyTerminalBlock>();List<ѩ>ψ=new List<ѩ>();List<Ҹ>χ=new List<Ҹ>();Dictionary<
IMyTerminalBlock,string>φ=new Dictionary<IMyTerminalBlock,string>();bool υ(IMyTerminalBlock Ɉ){try{if(!Me.IsSameConstructAs(Ɉ))return
false;string τ=Ɉ.GetOwnerFactionTag();if(τ!=Τ&&τ!=""){Echo("!"+τ+": "+Ɉ.CustomName);Χ++;return false;}if(Ɉ.CustomName.
Contains(ʴ))return false;if(!Ύ&&ʾ&&!Ɉ.CustomName.Contains(ʑ))return false;string σ=Ɉ.BlockDefinition.ToString();if(Ɉ.CustomName.
Contains(ʱ)){ϊ.Add(Ɉ);}if(σ.Contains("MedicalRoom/")){if(Έ)Ɉ.CustomData=Ρ;else Ɉ.CustomData=Σ;ϛ.Add(Ɉ);if(Ύ)φ.Add(Ɉ,
"Medical Room");return false;}if(σ.Contains("SurvivalKit/")){if(Έ)Ɉ.CustomData=Ρ;else Ɉ.CustomData=Σ;ϛ.Add(Ɉ);if(Ύ)φ.Add(Ɉ,
"Survival Kit");return false;}if(σ=="MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Ύ)φ.Add(Ɉ,"Refill Station");return false;}var
ς=Ɉ as IMyTextPanel;if(ς!=null){ή.Add(ς);if(Ύ)φ.Add(Ɉ,"LCD");if(ς.CustomName.Contains(ʳ)){ќ ρ=new ќ();ρ.ɑ=ς;ά.Add(Ʌ(ρ));}
else if(!ʇ&&ς.CustomName.Contains(ʲ))έ.Add(ς);return false;}if(σ==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɝ(Ɉ,"Flak",3);if(σ=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɝ(Ɉ,
"OPA",3);if(σ=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɝ(Ɉ,"Voltaire",3);if(σ.Contains
("Nariman Dynamics PDC"))return ɝ(Ɉ,"Nari",4);if(σ.Contains("Redfields Ballistics PDC"))return ɝ(Ɉ,"Red",4);if(σ.Contains
("OPA Shotgun PDC"))return ɝ(Ɉ,"Shotgun",4);if(σ=="MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return Ɋ
(Ɉ,"Apollo");if(σ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return Ɋ(Ɉ,"Tycho");if(σ==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return Ɋ(Ɉ,"Zeus");if(σ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return Ɋ(Ɉ,"Tycho");if(σ.Contains(
"Ares_Class"))return Ɋ(Ɉ,"Ares");if(σ.Contains("Artemis_Torpedo_Tube"))return Ɋ(Ɉ,"Artemis");if(σ==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return ɉ(Ɉ,"Dawson",11);if(σ=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return ɉ(Ɉ,"Stiletto",12);if
(σ=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return ɉ(Ɉ,"Roci",13);if(σ==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return ɉ(Ɉ,"Foehammer",14);if(σ=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return ɉ(Ɉ,"Farren",15);
if(σ.Contains("Zakosetara"))return ɉ(Ɉ,"Zako",10);if(σ.Contains("Kess Hashari Cannon"))return ɉ(Ɉ,"Kess",16);if(σ.Contains
("Coilgun"))return ɉ(Ɉ,"Coilgun",13);if(σ.Contains("Glapion"))return ɉ(Ɉ,"Glapion",3);var π=Ɉ as IMyThrust;if(π!=null){if
(σ.ToUpper().Contains("RCS")){γ.Add(π);if(Ύ)φ.Add(Ɉ,"RCS");}else if(σ.Contains("Hydro")){β.Add(π);if(Ύ)φ.Add(Ɉ,"Chem");}
else if(σ.Contains("Atmospheric")){α.Add(π);if(Ύ)φ.Add(Ɉ,"Atmo");}else{δ.Add(π);if(Ύ){string ɋ="";if(ʊ){try{ɋ=Ɉ.
DefinitionDisplayNameText.Split('"')[1];ɋ=ʌ+ɋ[0].ToString().ToUpper()+ɋ.Substring(1).ToLower();}catch{if(ʂ)Echo("Failed to get drive type from "+
Ɉ.DefinitionDisplayNameText);}}φ.Add(Ɉ,"Epstein"+ɋ);}}return false;}var ο=Ɉ as IMyCargoContainer;if(ο!=null){string ξ=σ.
Split('/')[1];if(ξ.Contains("Container")||ξ.Contains("Cargo")){Ϥ.Add(ο);Ϯ(Ɉ);if(Ύ){double ν=Ɉ.GetInventory().MaxVolume.
RawValue;double ˀ=Math.Round(ν/1265625024,1);if(ˀ==0)ˀ=0.1;φ.Add(Ɉ,"Cargo ["+ˀ+"]");}return false;}}var ɫ=Ɉ as IMyGyro;if(ɫ!=
null){ϟ.Add(ɫ);if(Ύ)φ.Add(Ɉ,"Gyroscope");return false;}var ɏ=Ɉ as IMyBatteryBlock;if(ɏ!=null){Ϧ.Add(ɏ);if(Ύ)φ.Add(Ɉ,"Power"+
ʌ+"Battery");return false;}var ɪ=Ɉ as IMyReflectorLight;if(ɪ!=null){ό.Add(ɪ);if(Ύ)φ.Add(Ɉ,"Spotlight");return false;}var
ɩ=Ɉ as IMyLightingBlock;if(ɩ!=null){if(Ɉ.CustomName.ToUpper().Contains("INTERIOR")){κ.Add(ɩ);if(Ύ)φ.Add(Ɉ,"Light"+ʌ+
"Interior");}else if(σ.Contains("Kitchen")||σ.Contains("Aquarium")){κ.Add(ɩ);if(Ύ)φ.Add(Ɉ,"Light"+ʌ+"Interior"+ʌ+Ɉ.
DefinitionDisplayNameText);}else if(Ɉ.CustomName.Contains(ʠ)){if(Ɉ.CustomName.ToUpper().Contains("STARBOARD")){ϋ.Add(ɩ);if(Ύ)φ.Add(Ɉ,"Light"+ʌ+
"Nav"+ʌ+"Starboard");}else{μ.Add(ɩ);if(Ύ)φ.Add(Ɉ,"Light"+ʌ+"Nav"+ʌ+"Port");}}else{Ϋ.Add(ɩ);if(Ύ)φ.Add(Ɉ,"Light"+ʌ+"Exterior")
;}return false;}var ɨ=Ɉ as IMyGasTank;if(ɨ!=null){if(σ.Contains("Hydro")){Ϛ.Add(ɨ);if(Ύ)φ.Add(Ɉ,"Tank"+ʌ+"Hydrogen");}
else{ύ.Add(ɨ);if(Ύ)φ.Add(Ɉ,"Tank"+ʌ+"Oxygen");}return false;}var ɧ=Ɉ as IMyReactor;if(ɧ!=null){ϝ.Add(ɧ);Ϯ(Ɉ,0);if(Ύ){string
ɦ="Lg";if(σ.Contains("SmallGenerator"))ɦ="Sm";else if(σ.Contains("MCRN"))ɦ="MCRN";φ.Add(Ɉ,"Power"+ʌ+"Reactor"+ʌ+ɦ);}
return false;}var ɥ=Ɉ as IMyShipController;if(ɥ!=null){Ϫ.Add(ɥ);if(Ϩ==null&&Ɉ.CustomName.Contains("Nav"))Ϩ=ɥ;if(ɥ.HasInventory
)Ϯ(Ɉ);if(Ύ&&σ.Contains("Cockpit/")){if(σ.Contains("StandingCockpit")||σ.Contains("Console")){φ.Add(Ɉ,"Console");return
false;}else if(σ.Contains("Cockpit")){φ.Add(Ɉ,"Cockpit");return false;}}}var ɤ=Ɉ as IMyDoor;if(ɤ!=null){ѩ ɣ=new ѩ();ɣ.ɑ=ɤ;if(
Ɉ.CustomName.Contains(ɿ)){try{string ɟ=Ɉ.CustomName.Split(ʌ)[3];ɣ.Һ=true;bool ɞ=false;foreach(Ҹ ɢ in χ){if(ɟ==ɢ.ҷ){ɢ.ҳ.
Add(ɣ);ɞ=true;break;}}if(!ɞ){Ҹ ɡ=new Ҹ();ɡ.ҷ=ɟ;ɡ.ҳ.Add(ɣ);χ.Add(ɡ);}}catch{if(ʂ)Echo("Error with airlock door name "+Ɉ.
CustomName);ψ.Add(ɣ);}}else{ψ.Add(ɣ);}if(Ύ)φ.Add(Ɉ,"Door");return false;}var ɠ=Ɉ as IMyAirVent;if(ɠ!=null){λ.Add(ɠ);if(Ɉ.
CustomName.Contains(ɿ)){try{string ɟ=Ɉ.CustomName.Split(ʌ)[3];bool ɞ=false;foreach(Ҹ ɢ in χ){if(ɟ==ɢ.ҷ){ɢ.Ҳ.Add(ɠ);ɞ=true;break;}}
if(!ɞ){Ҹ ɡ=new Ҹ();ɡ.ҷ=ɟ;ɡ.Ҳ.Add(ɠ);χ.Add(ɡ);}}catch{if(ʂ)Echo("Error with airlock vent name "+Ɉ.CustomName);}}if(Ύ)φ.Add(
Ɉ,"Vent");return false;}var ɼ=Ɉ as IMyCameraBlock;if(ɼ!=null){ϥ.Add(ɼ);if(Ύ)φ.Add(Ɉ,"Camera");return false;}var ɽ=Ɉ as
IMyShipConnector;if(ɽ!=null){ϣ.Add(ɽ);Ϯ(Ɉ);if(Ύ){string ɻ="";if(σ.Contains("Passageway"))ɻ=ʌ+"Passageway";φ.Add(Ɉ,"Connector"+ɻ);}return
false;}var ɺ=Ɉ as IMyAirtightHangarDoor;if(ɺ!=null){Ϣ.Add(ɺ);if(Ύ)φ.Add(Ɉ,"Door"+ʌ+"Hangar");return false;}if(σ.Contains(
"Lidar")){var ɹ=Ɉ as IMyConveyorSorter;if(ɹ!=null){ι.Add(ɹ);if(Ύ)φ.Add(Ɉ,"LiDAR");return false;}}if(σ==
"MyObjectBuilder_OxygenGenerator/Extractor"){ϡ.Add(Ɉ);if(Ύ)φ.Add(Ɉ,"Extractor");return false;}if(σ=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){Ϡ.Add(Ɉ);if(Ύ
)φ.Add(Ɉ,"Extractor");return false;}var ɸ=Ɉ as IMyRadioAntenna;if(ɸ!=null){ϧ.Add(ɸ);if(Ύ)φ.Add(Ɉ,"Antenna");return false;
}var ɷ=Ɉ as IMyProgrammableBlock;if(ɷ!=null){if(Ύ)φ.Add(Ɉ,"PB Server");if(ɷ==Me)return false;try{if(Ɉ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))ΰ.Add(ɷ);else if(Ɉ.CustomData.Contains("NavConfig"))ί.Add(ɷ);return false;}catch{}}var
ɶ=Ɉ as IMyProjector;if(ɶ!=null){Ϟ.Add(ɶ);if(Ύ)φ.Add(Ɉ,"Projectors");return false;}var ɵ=Ɉ as IMySensorBlock;if(ɵ!=null){Ϝ
.Add(ɵ);if(Ύ)φ.Add(Ɉ,"Sensor");return false;}var ɴ=Ɉ as IMyCollector;if(ɴ!=null){Ϯ(Ɉ);if(Ύ)φ.Add(Ɉ,"Collector");return
false;}if(σ.Contains("Welder")){Ϊ.Add(Ɉ);if(Ύ)φ.Add(Ɉ,"Tool"+ʌ+"Welder");return false;}if(Ύ){if(σ.Contains("LandingGear/")){
if(σ.Contains("Clamp"))φ.Add(Ɉ,"Clamp");else if(σ.Contains("Magnetic"))φ.Add(Ɉ,"Mag Lock");else φ.Add(Ɉ,"Gear");return
false;}if(σ.Contains("Drill")){φ.Add(Ɉ,"Tool"+ʌ+"Drill");return false;}if(σ.Contains("Grinder")){φ.Add(Ɉ,"Tool"+ʌ+"Grinder");
return false;}if(σ.Contains("Solar")){φ.Add(Ɉ,"Solar");return false;}if(σ.Contains("ButtonPanel")){φ.Add(Ɉ,"Button Panel");
return false;}var ɳ=Ɉ as IMyConveyorSorter;if(ɳ!=null){φ.Add(Ɉ,"Sorter");return false;}var ɲ=Ɉ as IMyMotorSuspension;if(ɲ!=
null){φ.Add(Ɉ,"Suspension");return false;}var ɱ=Ɉ as IMyGravityGenerator;if(ɱ!=null){φ.Add(Ɉ,"Grav Gen");return false;}var ɰ
=Ɉ as IMyTimerBlock;if(ɰ!=null){φ.Add(Ɉ,"Timer");return false;}var ɯ=Ɉ as IMyGasGenerator;if(ɯ!=null){φ.Add(Ɉ,"H2 Engine"
);return false;}var ɮ=Ɉ as IMyBeacon;if(ɮ!=null){φ.Add(Ɉ,"Beacon");return false;}φ.Add(Ɉ,Ɉ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ʂ){Echo("Failed to sort "+Ɉ.CustomName+"\nAdded "+φ.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɭ(){Ϩ=null;ϧ.Clear();Ϧ.Clear();ϥ.Clear();Ϥ.Clear();ϣ.Clear();Ϫ.Clear();ψ.Clear();χ.Clear();Ϣ.Clear();ϡ.
Clear();Ϡ.Clear();ϟ.Clear();Ϟ.Clear();ϝ.Clear();Ϝ.Clear();Ϛ.Clear();ύ.Clear();λ.Clear();Ϊ.Clear();ι.Clear();θ.Clear();η.Clear
();ζ.Clear();ε.Clear();δ.Clear();γ.Clear();β.Clear();α.Clear();ΰ.Clear();ί.Clear();ή.Clear();ά.Clear();έ.Clear();Ϋ.Clear(
);κ.Clear();μ.Clear();ϋ.Clear();ό.Clear();ϊ.Clear();foreach(var ɬ in ϯ)ɬ.Ϭ.Clear();if(Ύ)φ.Clear();}bool ɝ(
IMyTerminalBlock Ɉ,string Ŕ,int ɇ){if(Ɉ.CustomName.Contains(ʰ))η.Add(Ɉ);else θ.Add(Ɉ);Ϯ(Ɉ,ɇ);if(Ύ){string ɋ="";if(ʋ)ɋ=ʌ+Ŕ;φ.Add(Ɉ,"PDC"+
ɋ);}return false;}bool Ɋ(IMyTerminalBlock Ɉ,string Ŕ){ε.Add(Ɉ);if(Ύ){string Ɇ="";if(ʋ)Ɇ=ʌ+Ŕ;φ.Add(Ɉ,"Torpedo"+Ɇ);}return
false;}bool ɉ(IMyTerminalBlock Ɉ,string Ŕ,int ɇ){ζ.Add(Ɉ);Ϯ(Ɉ,ɇ);if(Ύ){string Ɇ="";if(ʋ)Ɇ=ʌ+Ŕ;φ.Add(Ɉ,"Railgun"+Ɇ);}return
false;}ќ Ʌ(ќ ĩ,string Ʉ=""){bool Ƀ=Ʉ=="",Ɍ=!Ƀ;string Ɏ=ĩ.ɑ.CustomData,ɛ="RSM.LCD";string[]ɜ=null;MyIni ɚ=new MyIni();
MyIniParseResult Ɖ;if(!Ƀ||Ɏ=="")Ɍ=true;else{try{if(Ɏ.Substring(0,12)=="Show Header="){ɜ=Ɏ.Split('\n');foreach(string ə in ɜ){if(ə.
Contains("hud")){if(ə.Contains("lcd")){Ʉ=ə;break;}}else if(ə.Contains("=")){string[]ɘ=ə.Split('=');if(ɘ[0]==
"Show Tanks & Batteries")ĩ.ї=bool.Parse(ɘ[1]);else if(ɘ[0]=="Show header"||ɘ[0]=="Show Header")ĩ.њ=bool.Parse(ɘ[1]);else if(ɘ[0]==
"Show Header Overlay")ĩ.љ=bool.Parse(ɘ[1]);else if(ɘ[0]=="Show Warnings")ĩ.ј=bool.Parse(ɘ[1]);else if(ɘ[0]=="Show Inventory")ĩ.і=bool.Parse(ɘ
[1]);else if(ɘ[0]=="Show Thrust")ĩ.ѕ=bool.Parse(ɘ[1]);else if(ɘ[0]=="Show Subsystem Integrity")ĩ.є=bool.Parse(ɘ[1]);else
if(ɘ[0]=="Show Advanced Thrust")ĩ.ѓ=bool.Parse(ɘ[1]);}}}else if(!ɚ.TryParse(Ɏ,out Ɖ)){Ɍ=true;}else{ĩ.њ=ɚ.Get(ɛ,
"ShowHeader").ToBoolean(ĩ.њ);ĩ.љ=ɚ.Get(ɛ,"ShowHeaderOverlay").ToBoolean(ĩ.љ);ĩ.ј=ɚ.Get(ɛ,"ShowWarnings").ToBoolean(ĩ.ј);ĩ.ї=ɚ.Get(ɛ,
"ShowPowerAndTanks").ToBoolean(ĩ.ї);ĩ.і=ɚ.Get(ɛ,"ShowInventory").ToBoolean(ĩ.і);ĩ.ѕ=ɚ.Get(ɛ,"ShowThrust").ToBoolean(ĩ.ѕ);ĩ.є=ɚ.Get(ɛ,
"ShowIntegrity").ToBoolean(ĩ.є);ĩ.ѓ=ɚ.Get(ɛ,"ShowAdvancedThrust").ToBoolean(ĩ.ѓ);}}catch(Exception ex){if(ʂ)Echo(
"LCD parsing error, resetting\n"+ex.Message);Ɍ=true;}}if(ĩ.њ&&ĩ.љ){ĩ.њ=false;Ɍ=true;}if(Ɍ){if(ɜ==null)ɜ=Ɏ.Split('\n');ɚ.Set(ɛ,"ShowHeader",ĩ.њ);ɚ.Set(ɛ,
"ShowHeaderOverlay",ĩ.љ);ɚ.Set(ɛ,"ShowWarnings",ĩ.ј);ɚ.Set(ɛ,"ShowPowerAndTanks",ĩ.ї);ɚ.Set(ɛ,"ShowInventory",ĩ.і);ɚ.Set(ɛ,"ShowThrust",ĩ.ѕ
);ɚ.Set(ɛ,"ShowIntegrity",ĩ.є);ɚ.Set(ɛ,"ShowAdvancedThrust",ĩ.ѓ);ɚ.Set(ɛ,"Hud",Ʉ);ĩ.ɑ.CustomData=ɚ.ToString();if(Ƀ)Ъ.Add(
new ђ("LCD CONFIG ERROR!!","Failed to parse LCD config for "+ĩ.ɑ.CustomName+"!\nLCD config was reset!",3));}return ĩ;}void
ɗ(IMyTerminalBlock ɑ,bool Ȭ){ɑ.GetActionWithName("ToolCore_Shoot_Action").Apply(ɑ);(ɑ as IMyConveyorSorter).
GetActionWithName("ToolCore_Shoot_Action").Apply(ɑ);}void ɖ(){List<IMyTerminalBlock>ɕ=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(ɕ);string ɔ="";foreach(IMyTerminalBlock ɓ in ɕ){ɔ+=ɓ.BlockDefinition+"\n";}if(ϧ.Count>0&&ϧ[0]!=null){
ϧ[0].CustomData=ɔ;}}void ɒ(string ȴ){IMyTerminalBlock ɑ=GridTerminalSystem.GetBlockWithName(ȴ);List<ITerminalAction>ɐ=new
List<ITerminalAction>();ɑ.GetActions(ɐ);List<ITerminalProperty>ɍ=new List<ITerminalProperty>();ɑ.GetProperties(ɍ);string ɾ=ɑ
.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction ʐ in ɐ){ɾ+=ʐ.Id+" "+ʐ.Name+"\n";}ɾ+="\n\n**Properties**\n\n";
foreach(ITerminalProperty ʭ in ɍ){ɾ+=ʭ.Id+" "+ʭ.TypeName+"\n";}if(ϧ.Count>0&&ϧ[0]!=null)ϧ[0].CustomData=ɾ;ɑ.CustomData=ɾ;}void
ʫ(IMyTerminalBlock Ƨ){bool ʩ=Ƨ.GetValue<bool>("WC_Repel");if(!ʩ)Ƨ.ApplyAction("WC_RepelMode");}void ʪ(IMyTerminalBlock Ƨ)
{bool ʩ=Ƨ.GetValue<bool>("WC_Repel");if(ʩ)Ƨ.ApplyAction("WC_RepelMode");}void ʨ(IMyTerminalBlock Ƨ){try{if(ǣ.Ƙ(Ƨ,0)==
VRageMath.Matrix.Zero)return;Ƨ.SetValue<Int64>("WC_Shoot Mode",3);if(ʂ)Echo("Shoot mode = "+Ƨ.GetValue<Int64>("WC_Shoot Mode"));}
catch{Echo("Failed to set fire mode to manual on "+Ƨ.CustomName);}}void ʧ(IMyTerminalBlock Ƨ){try{if(ǣ.Ƙ(Ƨ,0)==VRageMath.
Matrix.Zero)return;Ƨ.SetValue<Int64>("WC_Shoot Mode",0);if(ʂ)Echo("Shoot mode = "+Ƨ.GetValue<Int64>("WC_Shoot Mode"));}catch{
Echo("Failed to set fire mode to auto on "+Ƨ.CustomName);}}void ʦ(){if(Ϩ!=null){try{Φ=Ϩ.GetShipSpeed();Υ=Ϩ.CalculateShipMass
().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo(exxie.Message);}}}double ʥ=0;double
ʤ=0;double ʣ=0;void ʢ(){ʤ=0;foreach(IMyCargoContainer ʬ in Ϥ){if(ʬ!=null&&!ʬ.Closed&&ʬ.IsFunctional){try{ʤ+=ʬ.
GetInventory().MaxVolume.RawValue;}catch(Exception ex){if(ʂ)Echo("Cargo integrity error!\n"+ex.Message);throw ex;}}}ʣ=Math.Round(100
*(ʤ/ʥ));}void ʮ(){ʥ=0;foreach(IMyCargoContainer ʬ in Ϥ){if(ʬ!=null)ʥ+=ʬ.GetInventory().MaxVolume.RawValue;}}MyIni ʿ=new
MyIni();bool ʾ=false;bool ʽ=true;bool ʼ=true;bool ʻ=true;bool ʺ=true;bool ʹ=false;string ʸ="";bool ʷ=true;int ʶ=3;int ʵ=6;
string ʴ="[I]";string ʳ="[RSM]";string ʲ="[CS]";string ʱ="Autorepair";string ʰ="Repel";string ʯ="Min";string ʡ="Docking";
string ʠ="Nav";string ɿ="Airlock";string ʎ="[EFC]";string ʍ="[NavOS]";char ʌ='.';bool ʋ=true;bool ʊ=true;List<string>ʉ=new
List<string>();bool ʈ=false;bool ʇ=false;bool ʆ=true;List<double>ʅ=new List<double>();bool ʄ=false;double ʃ=0.5;bool ʂ=true;
bool ʁ=false;int ʀ=0;int ʏ=100;string ʑ="";bool ʟ(){string Ɏ=Me.CustomData;string ɛ="";bool ʞ=true;MyIniParseResult Ɖ;if(!ʿ.
TryParse(Ɏ,out Ɖ)){string[]ʝ=Ɏ.Split('\n');if(ʝ[1]=="Reedit Ship Management"){Echo("Legacy config detected...");ґ(Ɏ);return
false;}else{Echo("Could not parse custom data!\n"+Ɖ.ToString());return false;}}try{ɛ="RSM.Main";Echo(ɛ);ʾ=ʿ.Get(ɛ,
"RequireShipName").ToBoolean(ʾ);ʽ=ʿ.Get(ɛ,"EnableAutoload").ToBoolean(ʽ);ʼ=ʿ.Get(ɛ,"AutoloadReactors").ToBoolean(ʼ);ʻ=ʿ.Get(ɛ,
"AutoConfigWeapons").ToBoolean(ʻ);ʺ=ʿ.Get(ɛ,"SetTurretFireMode").ToBoolean(ʺ);ɛ="RSM.Spawns";Echo(ɛ);ʹ=ʿ.Get(ɛ,"PrivateSpawns").ToBoolean(ʹ
);ʸ=ʿ.Get(ɛ,"FriendlyTags").ToString(ʸ);ɛ="RSM.Doors";Echo(ɛ);ʷ=ʿ.Get(ɛ,"EnableDoorManagement").ToBoolean(ʷ);ʶ=ʿ.Get(ɛ,
"DoorCloseTimer").ToInt32(ʶ);ʶ=ʿ.Get(ɛ,"AirlockDoorDisableTimer").ToInt32(ʶ);ɛ="RSM.Keywords";Echo(ɛ);ʴ=ʿ.Get(ɛ,"Ignore").ToString(ʴ);ʳ=
ʿ.Get(ɛ,"RsmLcds").ToString(ʳ);ʲ=ʿ.Get(ɛ,"ColourSyncLcds").ToString(ʲ);ʱ=ʿ.Get(ɛ,"AuxiliaryBlocks").ToString(ʱ);ʰ=ʿ.Get(ɛ
,"DefensivePdcs").ToString(ʰ);ʯ=ʿ.Get(ɛ,"MinimumThrusters").ToString(ʯ);ʡ=ʿ.Get(ɛ,"DockingThrusters").ToString(ʡ);ʠ=ʿ.Get
(ɛ,"NavLights").ToString(ʠ);ɿ=ʿ.Get(ɛ,"Airlock").ToString(ɿ);ɛ="RSM.InitNaming";Echo(ɛ);ʌ=ʿ.Get(ɛ,"Ignore").ToChar(ʌ);ʋ=ʿ
.Get(ɛ,"NameWeaponTypes").ToBoolean(ʋ);ʊ=ʿ.Get(ɛ,"NameDriveTypes").ToBoolean(ʊ);string ʜ=ʿ.Get(ɛ,"BlocksToNumber").
ToString("");string[]ʛ=ʜ.Split(',');ʉ.Clear();foreach(string ȴ in ʛ)if(ȴ!="")ʉ.Add(ȴ);ɛ="RSM.Misc";Echo(ɛ);ʈ=ʿ.Get(ɛ,
"DisableLightingControl").ToBoolean(ʈ);ʇ=ʿ.Get(ɛ,"DisableLcdColourControl").ToBoolean(ʇ);ʆ=ʿ.Get(ɛ,"ShowBasicTelemetry").ToBoolean(ʆ);string ʚ=ʿ
.Get(ɛ,"DecelerationPercentages").ToString("");string[]ʙ=ʚ.Split(',');if(ʙ.Length>1){ʅ.Clear();foreach(string ʘ in ʙ){ʅ.
Add(double.Parse(ʘ)/100);}}ʄ=ʿ.Get(ɛ,"ShowThrustInMetric").ToBoolean(ʄ);ʃ=ʿ.Get(ɛ,"ReactorFillRatio").ToDouble(ʃ);ϯ[0].ϰ=ʃ;
ɛ="RSM.Debug";Echo(ɛ);ʂ=ʿ.Get(ɛ,"VerboseDebugging").ToBoolean(ʂ);ʁ=ʿ.Get(ɛ,"RuntimeProfiling").ToBoolean(ʁ);ʏ=ʿ.Get(ɛ,
"BlockRefreshFreq").ToInt32(ʏ);ʀ=ʿ.Get(ɛ,"StallCount").ToInt32(ʀ);ɛ="RSM.System";Echo(ɛ);ʑ=ʿ.Get(ɛ,"ShipName").ToString(ʑ);ɛ=
"RSM.InitItems";Echo(ɛ);foreach(ɬ ʗ in ϯ){ʗ.Џ=ʿ.Get(ɛ,ʗ.ϵ.SubtypeId).ToInt32(ʗ.Џ);}ɛ="RSM.InitSubSystems";Echo(ɛ);G=ʿ.Get(ɛ,"Reactors")
.ToDouble(G);G=ʿ.Get(ɛ,"Batteries").ToDouble(Â);Ì=ʿ.Get(ɛ,"Pdcs").ToInt32(Ì);Ȋ=ʿ.Get(ɛ,"TorpLaunchers").ToInt32(Ȋ);Y=ʿ.
Get(ɛ,"KineticWeapons").ToInt32(Y);Ö=ʿ.Get(ɛ,"H2Storage").ToDouble(Ö);ë=ʿ.Get(ɛ,"O2Storage").ToDouble(ë);ä=ʿ.Get(ɛ,
"MainThrust").ToSingle(ä);ȅ=ʿ.Get(ɛ,"RCSThrust").ToSingle(ȅ);Ҩ=ʿ.Get(ɛ,"Gyros").ToDouble(Ҩ);ʥ=ʿ.Get(ɛ,"CargoStorage").ToDouble(ʥ);Ʀ=
ʿ.Get(ɛ,"Welders").ToInt32(Ʀ);}catch(Exception ex){ѯ(ex,"Failed to parse section\n"+ɛ);}Echo("Parsing stances...");
Dictionary<string,Î>ʖ=new Dictionary<string,Î>();List<string>ʕ=new List<string>();ʿ.GetSections(ʕ);foreach(string ʔ in ʕ){if(ʔ.
Contains("RSM.Stance.")){string ʓ=ʔ.Substring(11);Echo(ʓ);Î Ù=new Î();string ģ,Ӆ="";string[]Ҁ;int Ѿ=33,ѽ=144,Ɉ=255,Ķ=255;bool Ѽ=
false;Î ѻ=null;Ӆ="Inherits";if(ʿ.ContainsKey(ʔ,Ӆ)){Ѽ=true;try{ѻ=ʖ[ʿ.Get(ʔ,Ӆ).ToString()];Echo("Inherits "+ʿ.Get(ʔ,Ӆ).ToString
());}catch(Exception ex){ѯ(ex,"Failed to find inheritee for\n"+ʔ+
"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(Ѽ)Echo(ѻ.ā.ToString());Ӆ="Torps";if(ʿ.ContainsKey(ʔ,Ӆ)){Ù.ā=(ơ)Enum.Parse(typeof(ơ),ʿ.Get(ʔ,Ӆ).ToString());
Echo("1");}else if(Ѽ){Ù.ā=ѻ.ā;Echo("2");}else{Ù.ā=Đ;Echo("3");}Ӆ="Pdcs";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ÿ=(Ǔ)Enum.Parse(typeof(Ǔ),ʿ.
Get(ʔ,Ӆ).ToString());else if(Ѽ)Ù.ÿ=ѻ.ÿ;else Ù.ÿ=ď;Ӆ="Kinetics";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.þ=(ǒ)Enum.Parse(typeof(ǒ),ʿ.Get(ʔ,Ӆ)
.ToString());else if(Ѽ)Ù.þ=ѻ.þ;else Ù.þ=Ď;Ӆ="MainThrust";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ý=(ǔ)Enum.Parse(typeof(ǔ),ʿ.Get(ʔ,Ӆ).
ToString());else if(Ѽ)Ù.ý=ѻ.ý;else Ù.ý=č;Ӆ="ManeuveringThrust";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ü=(ǖ)Enum.Parse(typeof(ǖ),ʿ.Get(ʔ,Ӆ).
ToString());else if(Ѽ)Ù.ü=ѻ.ü;else Ù.ü=Č;Ӆ="Spotlights";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.û=(Ǖ)Enum.Parse(typeof(Ǖ),ʿ.Get(ʔ,Ӆ).ToString())
;else if(Ѽ)Ù.û=ѻ.û;else Ù.û=ċ;Ӆ="ExteriorLights";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ú=(ǂ)Enum.Parse(typeof(ǂ),ʿ.Get(ʔ,Ӆ).ToString())
;else if(Ѽ)Ù.ú=ѻ.ú;else Ù.ú=Ċ;Ӆ="ExteriorLightColour";if(ʿ.ContainsKey(ʔ,Ӆ)){ģ=ʿ.Get(ʔ,Ӆ).ToString();Ҁ=ģ.Split(',');Ѿ=int
.Parse(Ҁ[0]);ѽ=int.Parse(Ҁ[1]);Ɉ=int.Parse(Ҁ[2]);Ķ=int.Parse(Ҁ[3]);Ù.ù=new Color(Ѿ,ѽ,Ɉ,Ķ);}else if(Ѽ)Ù.ù=ѻ.ù;else Ù.ù=ĉ;Ӆ
="InteriorLights";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ø=(ǂ)Enum.Parse(typeof(ǂ),ʿ.Get(ʔ,Ӆ).ToString());else if(Ѽ)Ù.ø=ѻ.ø;else Ù.ø=Ĉ;Ӆ
="InteriorLightColour";if(ʿ.ContainsKey(ʔ,Ӆ)){ģ=ʿ.Get(ʔ,Ӆ).ToString();Ҁ=ģ.Split(',');Ѿ=int.Parse(Ҁ[0]);ѽ=int.Parse(Ҁ[1]);
Ɉ=int.Parse(Ҁ[2]);Ķ=int.Parse(Ҁ[3]);Ù.ö=new Color(Ѿ,ѽ,Ɉ,Ķ);}else if(Ѽ)Ù.ö=ѻ.ö;else Ù.ö=ć;Ӆ="NavLights";if(ʿ.ContainsKey(ʔ
,Ӆ))Ù.õ=(ǂ)Enum.Parse(typeof(ǂ),ʿ.Get(ʔ,Ӆ).ToString());else if(Ѽ)Ù.õ=ѻ.õ;else Ù.õ=Ć;Ӆ="LcdTextColour";if(ʿ.ContainsKey(ʔ,
Ӆ)){ģ=ʿ.Get(ʔ,Ӆ).ToString();Ҁ=ģ.Split(',');Ѿ=int.Parse(Ҁ[0]);ѽ=int.Parse(Ҁ[1]);Ɉ=int.Parse(Ҁ[2]);Ķ=int.Parse(Ҁ[3]);Ù.ô=
new Color(Ѿ,ѽ,Ɉ,Ķ);}else if(Ѽ)Ù.ô=ѻ.ô;else Ù.ô=ą;Ӆ="TanksAndBatteries";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ó=(Ǒ)Enum.Parse(typeof(Ǒ),ʿ.
Get(ʔ,Ӆ).ToString());else if(Ѽ)Ù.ó=ѻ.ó;else Ù.ó=Ą;Ӆ="NavOsEfcBurnPercentage";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ò=ʿ.Get(ʔ,
"NavOsEfcBurnPercentage").ToInt32(ă);else if(Ѽ)Ù.ò=ѻ.ò;else Ù.ò=ă;Ӆ="EfcBoost";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ñ=(ơ)Enum.Parse(typeof(ơ),ʿ.Get(ʔ,Ӆ).
ToString());else if(Ѽ)Ù.ñ=ѻ.ñ;else Ù.ñ=ï;Ӆ="NavOsAbortEfcOff";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ð=(ǀ)Enum.Parse(typeof(ǀ),ʿ.Get(ʔ,Ӆ).
ToString());else if(Ѽ)Ù.ð=ѻ.ð;else Ù.ð=î;Ӆ="NavOsAbortEfcOff";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ð=(ǀ)Enum.Parse(typeof(ǀ),ʿ.Get(ʔ,Ӆ).
ToString());else if(Ѽ)Ù.ð=ѻ.ð;else Ù.ð=î;Ӆ="AuxMode";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.Ā=(ơ)Enum.Parse(typeof(ơ),ʿ.Get(ʔ,Ӆ).ToString());
else if(Ѽ)Ù.Ā=ѻ.Ā;else Ù.Ā=Ï;Ӆ="Extractor";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.Ă=(ƿ)Enum.Parse(typeof(ƿ),ʿ.Get(ʔ,Ӆ).ToString());else if(
Ѽ)Ù.Ă=ѻ.Ă;else Ù.Ă=Þ;Ӆ="KeepAlives";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.ē=(ơ)Enum.Parse(typeof(ơ),ʿ.Get(ʔ,Ӆ).ToString());else if(Ѽ)Ù.
ē=ѻ.ē;else Ù.ē=Ý;Ӆ="HangarDoors";if(ʿ.ContainsKey(ʔ,Ӆ))Ù.Ĕ=(ƾ)Enum.Parse(typeof(ƾ),ʿ.Get(ʔ,Ӆ).ToString());else if(Ѽ)Ù.Ĕ=ѻ
.Ĕ;else Ù.Ĕ=Ü;ʖ.Add(ʓ,Ù);}catch(Exception ex){ѯ(ex,"Failed to parse stance\n"+ʓ+"\nproperty\n"+Ӆ);}}}if(ʖ.Count<1){Echo(
"Failed to parse any stances!\nStances reset to default!");ʞ=false;}else{Echo("Finished parsing "+ʖ.Count+" stances.");Ѫ=ʖ;}ɛ="RSM.Stance";Echo(ɛ);Ē=ʿ.Get(ɛ,"CurrentStance").
ToString(Ē);Î Ѻ;if(!Ѫ.TryGetValue(Ē,out Ѻ)){Ē="N/A";đ=null;}else đ=Ѻ;return ʞ;}void ѹ(){ʿ.Clear();string ɛ,ȴ;ɛ="RSM.Main";ȴ=
"RequireShipName";ʿ.Set(ɛ,ȴ,ʾ);ʿ.SetComment(ɛ,ȴ,"limit to blocks with the ship name in their name");ȴ="EnableAutoload";ʿ.Set(ɛ,ȴ,ʽ);ʿ.
SetComment(ɛ,ȴ,"enable RSM loading & balancing functionality for weapons");ȴ="AutoloadReactors";ʿ.Set(ɛ,ȴ,ʼ);ʿ.SetComment(ɛ,ȴ,
"enable loading and balancing for reactors");ȴ="AutoConfigWeapons";ʿ.Set(ɛ,ȴ,ʻ);ʿ.SetComment(ɛ,ȴ,"automatically configure weapon on stance set");ȴ=
"SetTurretFireMode";ʿ.Set(ɛ,ȴ,ʺ);ʿ.SetComment(ɛ,ȴ,"set turret fire mode based on stance");ʿ.SetSectionComment(ɛ,и+
" Reedit Ship Management\n"+и+" Config.ini\n Recompile to apply changes!\n"+и);ɛ="RSM.Spawns";ȴ="PrivateSpawns";ʿ.Set(ɛ,ȴ,ʹ);ʿ.SetComment(ɛ,ȴ,
"don't inject faction tag into spawn custom data");ȴ="FriendlyTags";ʿ.Set(ɛ,ȴ,ʸ);ʿ.SetComment(ɛ,ȴ,"Comma seperated friendly factions or steam ids");ɛ="RSM.Doors";ȴ=
"EnableDoorManagement";ʿ.Set(ɛ,ȴ,ʷ);ʿ.SetComment(ɛ,ȴ,"enable door management functionality");ȴ="DoorCloseTimer";ʿ.Set(ɛ,ȴ,ʶ);ʿ.SetComment(ɛ,ȴ,
"door open timer (x100 ticks)");ȴ="AirlockDoorDisableTimer";ʿ.Set(ɛ,ȴ,ʵ);ʿ.SetComment(ɛ,ȴ,"airlock door disable timer (x100 ticks)");ɛ="RSM.Keywords";
ȴ="Ignore";ʿ.Set(ɛ,ȴ,ʴ);ʿ.SetComment(ɛ,ȴ,"to identify blocks which RSM should ignore");ȴ="RsmLcds";ʿ.Set(ɛ,ȴ,ʳ);ʿ.
SetComment(ɛ,ȴ,"to identify RSM lcds");ȴ="ColourSyncLcds";ʿ.Set(ɛ,ȴ,ʲ);ʿ.SetComment(ɛ,ȴ,"to identify non RSM lcds for colour sync"
);ȴ="AuxiliaryBlocks";ʿ.Set(ɛ,ȴ,ʱ);ʿ.SetComment(ɛ,ȴ,"to identify aux blocks");ȴ="DefensivePdcs";ʿ.Set(ɛ,ȴ,ʰ);ʿ.SetComment
(ɛ,ȴ,"to identify defensive _normalPdcs");ȴ="MinimumThrusters";ʿ.Set(ɛ,ȴ,ʯ);ʿ.SetComment(ɛ,ȴ,
"to identify minimum epsteins");ȴ="DockingThrusters";ʿ.Set(ɛ,ȴ,ʡ);ʿ.SetComment(ɛ,ȴ,"to identify docking epsteins");ȴ="NavLights";ʿ.Set(ɛ,ȴ,ʠ);ʿ.
SetComment(ɛ,ȴ,"to identify navigational lights");ȴ="Airlock";ʿ.Set(ɛ,ȴ,ɿ);ʿ.SetComment(ɛ,ȴ,"to identify airlock doors and vents")
;ɛ="RSM.InitNaming";ȴ="NameDelimiter";ʿ.Set(ɛ,ȴ,ʌ.ToString());ʿ.SetComment(ɛ,ȴ,"single char delimiter for names");ȴ=
"NameWeaponTypes";ʿ.Set(ɛ,ȴ,ʋ);ʿ.SetComment(ɛ,ȴ,"append type names to all weapons on init");ȴ="NameDriveTypes";ʿ.Set(ɛ,ȴ,ʊ);ʿ.SetComment(
ɛ,ȴ,"append type names to all drives on init");string Ѹ="";foreach(string ѷ in ʉ){if(Ѹ!="")Ѹ+=",";Ѹ+=ѷ;}ȴ=
"BlocksToNumber";ʿ.Set(ɛ,ȴ,ʊ);ʿ.SetComment(ɛ,ȴ,"comma seperated list of block names to be numbered at init");ɛ="RSM.Misc";ȴ=
"DisableLightingControl";ʿ.Set(ɛ,ȴ,ʈ);ʿ.SetComment(ɛ,ȴ,"disable all lighting control");ȴ="DisableLcdColourControl";ʿ.Set(ɛ,ȴ,ʇ);ʿ.SetComment(ɛ,ȴ
,"disable text colour control for all lcds");ȴ="ShowBasicTelemetry";ʿ.Set(ɛ,ȴ,ʆ);ʿ.SetComment(ɛ,ȴ,
"show basic telemetry data on advanced thrust lcds");string Ѷ="";foreach(double Ī in ʅ){if(Ѷ!="")Ѷ+=",";Ѷ+=(Ī*100).ToString();}ȴ="DecelerationPercentages";ʿ.Set(ɛ,ȴ,Ѷ);ʿ.
SetComment(ɛ,ȴ,"thrust percentages to show on advanced thrust lcds");ȴ="ShowThrustInMetric";ʿ.Set(ɛ,ȴ,ʄ);ʿ.SetComment(ɛ,ȴ,
"show basic telemetry data on advanced thrust lcds");ȴ="ReactorFillRatio";ʿ.Set(ɛ,ȴ,ʃ);ʿ.SetComment(ɛ,ȴ,"0-1, fill ratio for reactors");ɛ="RSM.Debug";ȴ="VerboseDebugging";
ʿ.Set(ɛ,ȴ,ʂ);ʿ.SetComment(ɛ,ȴ,"prints more logging info to PB details");ȴ="RuntimeProfiling";ʿ.Set(ɛ,ȴ,ʁ);ʿ.SetComment(ɛ,
ȴ,"prints script runtime profiling info to PB details");ȴ="BlockRefreshFreq";ʿ.Set(ɛ,ȴ,ʏ);ʿ.SetComment(ɛ,ȴ,
"ticks x100 between block refreshes");ȴ="StallCount";ʿ.Set(ɛ,ȴ,ʀ);ʿ.SetComment(ɛ,ȴ,"ticks x100 to stall between runs");ɛ="RSM.Stance";ȴ="CurrentStance";ʿ.
Set(ɛ,ȴ,Ē);ʿ.SetSectionComment(ɛ,и+" Stances\n Add or remove as required\n"+и);string ѵ="Red, Green, Blue, Alpha";foreach(
var ѿ in Ѫ){ɛ="RSM.Stance."+ѿ.Key;Î Ú=ѿ.Value;Î ѻ=null;if(Ú.ß!=""){ѻ=Ѫ[Ú.ß];ȴ="Inherits";ʿ.Set(ɛ,ȴ,Ú.ß);ʿ.SetComment(ɛ,ȴ,
"Use stance of this name as a template for settings");}ȴ="Torps";if(ѻ!=null&&Ú.ā==ѻ.ā){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ā.ToString());ʿ.SetComment(ɛ,ȴ,
ѳ(typeof(ơ)));}ȴ="Pdcs";if(ѻ!=null&&Ú.ÿ==ѻ.ÿ){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ÿ.ToString());ʿ.
SetComment(ɛ,ȴ,ѳ(typeof(Ǔ)));}ȴ="Kinetics";if(ѻ!=null&&Ú.þ==ѻ.þ){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.þ.ToString(
));ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ǒ)));}ȴ="MainThrust";if(ѻ!=null&&Ú.ý==ѻ.ý){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ
,ȴ,Ú.ý.ToString());ʿ.SetComment(ɛ,"MainThrust",ѳ(typeof(ǔ)));}ȴ="ManeuveringThrust";if(ѻ!=null&&Ú.ü==ѻ.ü){if(ʿ.
ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ü.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ǖ)));}ȴ="Spotlights";if(ѻ!=null&&Ú.û==ѻ.û)
{if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.û.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(Ǖ)));}ȴ="ExteriorLights";
if(ѻ!=null&&Ú.ú==ѻ.ú){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ú.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ǂ)));}
ȴ="ExteriorLightColour";if(ѻ!=null&&Ú.ù==ѻ.ù){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ѱ(Ú.ù));ʿ.SetComment(ɛ,
ȴ,ѵ);}ȴ="InteriorLights";if(ѻ!=null&&Ú.ø==ѻ.ø){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ø.ToString());ʿ.
SetComment(ɛ,ȴ,ѳ(typeof(ǂ)));}ȴ="InteriorLightColour";if(ѻ!=null&&Ú.ö==ѻ.ö){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ѱ(
Ú.ö));ʿ.SetComment(ɛ,ȴ,ѵ);}ȴ="NavLights";if(ѻ!=null&&Ú.õ==ѻ.õ){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.õ.
ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ǂ)));}ȴ="LcdTextColour";if(ѻ!=null&&Ú.ô==ѻ.ô){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.
Set(ɛ,ȴ,Ѱ(Ú.ô));ʿ.SetComment(ɛ,ȴ,ѵ);}ȴ="TanksAndBatteries";if(ѻ!=null&&Ú.ó==ѻ.ó){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{
ʿ.Set(ɛ,ȴ,Ú.ó.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(Ǒ)));}ȴ="NavOsEfcBurnPercentage";if(ѻ!=null&&Ú.ò==ѻ.ò){if(ʿ.
ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ò.ToString());ʿ.SetComment(ɛ,ȴ,"Burn % 0-100, -1 for no change");}ȴ="EfcBoost";if(
ѻ!=null&&Ú.ñ==ѻ.ñ){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ñ.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ơ)));}ȴ=
"NavOsAbortEfcOff";if(ѻ!=null&&Ú.ð==ѻ.ð){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.ð.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ǀ))
);}ȴ="AuxMode";if(ѻ!=null&&Ú.Ā==ѻ.Ā){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.Ā.ToString());ʿ.SetComment(ɛ,ȴ
,ѳ(typeof(ơ)));}ȴ="Extractor";if(ѻ!=null&&Ú.Ă==ѻ.Ă){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú.Ă.ToString());ʿ
.SetComment(ɛ,ȴ,ѳ(typeof(ƿ)));}ȴ="KeepAlives";if(ѻ!=null&&Ú.ē==ѻ.ē){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);}else{ʿ.Set(ɛ,ȴ,Ú
.ē.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ơ)));}ȴ="HangarDoors";if(ѻ!=null&&Ú.Ĕ==ѻ.Ĕ){if(ʿ.ContainsKey(ɛ,ȴ))ʿ.Delete(ɛ,ȴ);
}else{ʿ.Set(ɛ,ȴ,Ú.Ĕ.ToString());ʿ.SetComment(ɛ,ȴ,ѳ(typeof(ƾ)));}}ɛ="RSM.System";ȴ="ShipName";ʿ.Set(ɛ,ȴ,ʑ);ʿ.
SetSectionComment(ɛ,и+" System\n All items below this point are\n set automatically when running init\n"+и);ɛ="RSM.InitItems";foreach(ɬ ʗ
in ϯ){ȴ=ʗ.ϵ.SubtypeId;ʿ.Set(ɛ,ȴ,ʗ.Џ);}ɛ="RSM.InitSubSystems";ʿ.Set(ɛ,"Reactors",G);ʿ.Set(ɛ,"Batteries",G);ʿ.Set(ɛ,"Pdcs",Ì
);ʿ.Set(ɛ,"TorpLaunchers",Ȋ);ʿ.Set(ɛ,"KineticWeapons",Y);ʿ.Set(ɛ,"H2Storage",Ö);ʿ.Set(ɛ,"O2Storage",ë);ʿ.Set(ɛ,
"MainThrust",ä);ʿ.Set(ɛ,"RCSThrust",ȅ);ʿ.Set(ɛ,"Gyros",Ҩ);ʿ.Set(ɛ,"CargoStorage",ʥ);ʿ.Set(ɛ,"Welders",Ʀ);Me.CustomData=ʿ.ToString();
}void ґ(string Ɏ){string[]ʕ=Ɏ.Split(new string[]{"[Stances]"},StringSplitOptions.None);string[]Ґ=ʕ[0].Split('\n');string
ҏ=ʕ[1];try{for(int ĝ=1;ĝ<Ґ.Length;ĝ++){if(Ґ[ĝ].Contains("=")){string Ҏ=Ґ[ĝ].Substring(1);switch(Ґ[(ĝ-1)]){case
"Ship name. Blocks without this name will be ignored":ʑ=Ҏ;break;case"Block name delimiter, used by init. One character only!":ʌ=char.Parse(Ҏ.Substring(0,1));break;case
"Keyword used to identify RSM _allLcds.":ʳ=Ҏ;break;case"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʱ=Ҏ;break;
case"Keyword used to identify defence _normalPdcs.":ʰ=Ҏ;break;case"Keyword used to identify minimum epstein drives.":ʯ=Ҏ;
break;case"Keyword used to identify docking epstein drives.":ʡ=Ҏ;break;case"Keyword to ignore block.":ʴ=Ҏ;break;case
"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʻ=bool.Parse(Ҏ);break;case"Disable lighting all control.":ʈ=bool.Parse(Ҏ);break;case
"Disable LCD Text Colour Enforcement.":ʇ=bool.Parse(Ҏ);break;case"Enable Weapon Autoload Functionality.":ʽ=bool.Parse(Ҏ);break;case
"Number these blocks at init.":ʉ.Clear();string[]ҍ=Ҏ.Split(',');foreach(string ѷ in ҍ){if(ѷ!="")ʉ.Add(ѷ);}break;case
"Add type names to weapons at init.":ʋ=bool.Parse(Ҏ);break;case"Show basic telemetry.":ʆ=bool.Parse(Ҏ);break;case"Show Decel Percentages (comma seperated)."
:ʅ.Clear();string[]Ҍ=Ҏ.Split(',');foreach(string Ī in Ҍ){ʅ.Add(double.Parse(Ī)/100);}break;case"Fusion Fuel count":ϯ[0].Џ
=int.Parse(Ҏ);break;case"Fuel tank count":ϯ[1].Џ=int.Parse(Ҏ);break;case"Jerry can count":ϯ[2].Џ=int.Parse(Ҏ);break;case
"40mm PDC Magazine count":ϯ[3].Џ=int.Parse(Ҏ);break;case"40mm Teflon Tungsten PDC Magazine count":ϯ[4].Џ=int.Parse(Ҏ);break;case
"220mm Torpedo count":case"Torpedo count":ϯ[5].Џ=int.Parse(Ҏ);break;case"220mm MCRN torpedo count":ϯ[6].Џ=int.Parse(Ҏ);break;case
"220mm UNN torpedo count":ϯ[7].Џ=int.Parse(Ҏ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":ϯ[8].Џ=int.Parse(Ҏ);break;case
"Large ramshacke torpedo count":ϯ[9].Џ=int.Parse(Ҏ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":ϯ[10].Џ=int.Parse(Ҏ);break;
case"Dawson 100mm UNN Railgun rounds count":ϯ[11].Џ=int.Parse(Ҏ);break;case"Stiletto 100mm MCRN Railgun rounds count":ϯ[12].
Џ=int.Parse(Ҏ);break;case"T-47 80mm Railgun rounds count":ϯ[13].Џ=int.Parse(Ҏ);break;case
"Foehammer 120mm MCRN rounds count":ϯ[14].Џ=int.Parse(Ҏ);break;case"Farren 120mm UNN Railgun rounds count":ϯ[15].Џ=int.Parse(Ҏ);break;case
"Kess 180mm rounds count":ϯ[16].Џ=int.Parse(Ҏ);break;case"Steel plate count":ϯ[17].Џ=int.Parse(Ҏ);break;case
"Doors open timer (x100 ticks, default 3)":ʶ=int.Parse(Ҏ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ʵ=int.Parse(Ҏ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":ʀ=int.Parse(Ҏ);break;case"Full refresh frequency (x100 ticks, default 50)":ʏ=int.Parse(Ҏ);break;case
"Verbose script debugging. Prints more logging info to PB details.":ʂ=bool.Parse(Ҏ);break;case"Private spawn (don't inject faction tag into SK custom data).":ʹ=bool.Parse(Ҏ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":ʸ=string.Join("\n",Ҏ.Split(','));break;case"Current Stance":Ē=Ҏ;Î Ѻ;if(!Ѫ.TryGetValue(Ē,out Ѻ)){Ē="N/A";đ=null;}else đ=
Ѻ;break;case"Reactor Integrity":G=float.Parse(Ҏ);break;case"Battery Integrity":Â=float.Parse(Ҏ);break;case"PDC Integrity"
:Ì=int.Parse(Ҏ);break;case"Torpedo Integrity":Ȋ=int.Parse(Ҏ);break;case"Railgun Integrity":Y=int.Parse(Ҏ);break;case
"H2 Tank Integrity":Ö=double.Parse(Ҏ);break;case"O2 Tank Integrity":ë=double.Parse(Ҏ);break;case"Epstein Integrity":ä=float.Parse(Ҏ);break;
case"RCS Integrity":ȅ=float.Parse(Ҏ);break;case"Gyro Integrity":Ҩ=int.Parse(Ҏ);break;case"Cargo Integrity":ʥ=double.Parse(Ҏ)
;break;case"Welder Integrity":Ʀ=int.Parse(Ҏ);break;}}}}catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);
}try{string[]ҋ=ҏ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(ʂ)Echo("Parsing "+(ҋ.Length-1)+" stances");int
Ҋ=24;Dictionary<string,Î>ʖ=new Dictionary<string,Î>();int[]ҁ=new int[]{0,5,25,50,75,100};for(int ĝ=1;ĝ<ҋ.Length;ĝ++){
string[]Ѵ=ҋ[ĝ].Split('=');string ʓ="";int[]ѧ=new int[Ҋ];ʓ=Ѵ[0].Split(' ')[0];if(ʂ)Echo("Parsing '"+ʓ+"'");for(int Ѧ=0;Ѧ<ѧ.
Length;Ѧ++){string[]ѥ=Ѵ[(Ѧ+1)].Split('\n');ѧ[Ѧ]=int.Parse(ѥ[0]);}Î Ù=new Î();if(ѧ[0]==0)Ù.ā=ơ.Off;else Ù.ā=ơ.On;if(ѧ[1]==0)Ù.ÿ
=Ǔ.Off;else if(ѧ[1]==1)Ù.ÿ=Ǔ.MinDefence;else if(ѧ[1]==2)Ù.ÿ=Ǔ.AllDefence;else if(ѧ[1]==3)Ù.ÿ=Ǔ.Offence;else if(ѧ[1]==4)Ù.
ÿ=Ǔ.AllOnOnly;if(ѧ[2]==0)Ù.þ=ǒ.Off;else if(ѧ[2]==1)Ù.þ=ǒ.HoldFire;else if(ѧ[2]==2)Ù.þ=ǒ.OpenFire;if(ѧ[3]==0)Ù.ý=ǔ.Off;
else if(ѧ[3]==1)Ù.ý=ǔ.On;else if(ѧ[3]==2)Ù.ý=ǔ.Minimum;if(ѧ[4]==0)Ù.ü=ǖ.Off;else if(ѧ[4]==1)Ù.ü=ǖ.On;else if(ѧ[4]==2)Ù.ü=ǖ.
ForwardOff;else if(ѧ[4]==3)Ù.ü=ǖ.ReverseOff;if(ѧ[5]==0)Ù.û=Ǖ.Off;else if(ѧ[5]==1)Ù.û=Ǖ.On;else if(ѧ[5]==2)Ù.û=Ǖ.OnMax;if(ѧ[6]==0)Ù
.ú=ǂ.Off;else Ù.ú=ǂ.On;Ù.ù=new Color(ѧ[7],ѧ[8],ѧ[9],ѧ[10]);if(ѧ[11]==0)Ù.ø=ǂ.Off;else Ù.ø=ǂ.On;Ù.ö=new Color(ѧ[12],ѧ[13],
ѧ[14],ѧ[15]);if(ѧ[16]==0)Ù.ó=Ǒ.Auto;else if(ѧ[16]==1)Ù.ó=Ǒ.StockpileRecharge;else if(ѧ[16]==2)Ù.ó=Ǒ.Discharge;if(ѧ[17]==0
)Ù.ñ=ơ.Off;else Ù.ñ=ơ.On;Ù.ò=ҁ[ѧ[18]];if(ѧ[19]==0)Ù.ð=ǀ.NoChange;else Ù.ð=ǀ.Abort;if(ѧ[20]==0)Ù.Ā=ơ.Off;else Ù.Ā=ơ.On;if(
ѧ[21]==0)Ù.Ă=ƿ.Off;else if(ѧ[21]==1)Ù.Ă=ƿ.On;else if(ѧ[21]==2)Ù.Ă=ƿ.FillWhenLow;else if(ѧ[21]==3)Ù.Ă=ƿ.KeepFull;if(ѧ[22]
==0)Ù.ē=ơ.Off;else Ù.ē=ơ.On;if(ѧ[23]==0)Ù.Ĕ=ƾ.Closed;else if(ѧ[23]==1)Ù.Ĕ=ƾ.Open;else Ù.Ĕ=ƾ.NoChange;ʖ.Add(ʓ,Ù);}if(ʖ.
Count>=1){if(ʂ)Echo("Finished parsing "+ʖ.Count+" stances.");Ѫ=ʖ;}else{Echo("Didn't find any stances!");}}catch(Exception ex)
{Echo("Custom Data Error (stances)\n"+ex.Message);}}void Ѥ(){bool ѣ=ʟ();if(!ѣ){Ѩ();ѹ();}if(đ==null){đ=Ѫ.First().Value;}
string Ѣ="";string ѡ="";if(!ʹ){Ѣ=" ".PadRight(129,' ')+Τ+"\n";ѡ="\n".PadRight(19,'\n');}Σ=Ѣ+ѡ;Ρ=Ѣ+string.Join("\n",ʸ.Split(','
))+ѡ;if(ʑ==""){if(ʂ)Echo("No ship name, trying to pull it from PB name...");string Ѡ="Untitled Ship";try{string[]џ=Me.
CustomName.Split(ʌ);if(џ.Length>1){ʑ=џ[0];if(ʂ)Echo(ʑ);}else ʑ=Ѡ;}catch{ʑ=Ѡ;}}}void ў(bool Û=true,bool ѝ=false,bool ː=false){MyIni
ɚ=new MyIni();string Ɏ=Me.CustomData;MyIniParseResult Ɖ;if(!ɚ.TryParse(Ɏ,out Ɖ)){Ъ.Add(new ђ("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ɛ,ȴ;if(Û){ɛ="RSM.Stance";ȴ="CurrentStance";ɚ.Set(ɛ,ȴ,Ē);}else{ɛ="RSM.System";ȴ="ShipName";ɚ.Set(ɛ,ȴ,
ʑ);}if(ѝ){ɛ="RSM.InitSubSystems";ɚ.Set(ɛ,"Reactors",G);ɚ.Set(ɛ,"Batteries",Â);ɚ.Set(ɛ,"Pdcs",Ì);ɚ.Set(ɛ,"TorpLaunchers",Ȋ
);ɚ.Set(ɛ,"KineticWeapons",Y);ɚ.Set(ɛ,"H2Storage",Ö);ɚ.Set(ɛ,"O2Storage",ë);ɚ.Set(ɛ,"MainThrust",ä);ɚ.Set(ɛ,"RCSThrust",ȅ
);ɚ.Set(ɛ,"Gyros",Ҩ);ɚ.Set(ɛ,"CargoStorage",ʥ);ɚ.Set(ɛ,"Welders",Ʀ);}if(ː){ɛ="RSM.InitItems";foreach(ɬ ʗ in ϯ){ȴ=ʗ.ϵ.
SubtypeId;ɚ.Set(ɛ,ȴ,ʗ.Џ);}}Me.CustomData=ɚ.ToString();}string ѳ(Type Ѳ){string ѱ="";foreach(var ġ in Enum.GetValues(Ѳ)){if(ѱ!="")
ѱ+=", ";ѱ+=ġ.ToString();}return ѱ;}string Ѱ(Color Ĩ){return Ĩ.R+", "+Ĩ.G+", "+Ĩ.B+", "+Ĩ.A;}void ѯ(Exception Ѯ,string ѭ){
Runtime.UpdateFrequency=UpdateFrequency.None;string Ѭ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ѭ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(Ѭ);List<IMyTextPanel>ѫ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ѫ,Ɉ=>Ɉ.CustomName
.Contains(ʳ));foreach(IMyTextPanel Ŵ in ѫ){Ŵ.WriteText(Ѭ);Ŵ.FontColor=new Color(193,0,197,255);}throw Ѯ;}Dictionary<
string,Î>Ѫ=new Dictionary<string,Î>();void Ѩ(){Ѫ=new Dictionary<string,Î>{{"Cruise",new Î{ā=ơ.On,ÿ=Ǔ.AllDefence,þ=ǒ.HoldFire,ý
=ǔ.EpsteinOnly,ü=ǖ.ForwardOff,û=Ǖ.Off,ú=ǂ.On,ù=new Color(33,144,255,255),ø=ǂ.On,ö=new Color(255,214,170,255),õ=ǂ.On,ô=new
Color(33,144,255,255),ó=Ǒ.Auto,ò=50,ñ=ơ.NoChange,ð=ǀ.Abort,Ā=ơ.NoChange,Ă=ƿ.KeepFull,ē=ơ.On,Ĕ=ƾ.NoChange,}},{"StealthCruise",
new Î{ß="Cruise",ā=ơ.On,ÿ=Ǔ.AllDefence,þ=ǒ.HoldFire,ý=ǔ.Minimum,ü=ǖ.ForwardOff,û=Ǖ.Off,ú=ǂ.Off,ù=new Color(0,0,0,255),ø=ǂ.
On,ö=new Color(23,73,186,255),õ=ǂ.Off,ô=new Color(23,73,186,255),ó=Ǒ.Auto,ò=5,ñ=ơ.Off,ð=ǀ.Abort,Ā=ơ.NoChange,Ă=ƿ.KeepFull,
ē=ơ.On,Ĕ=ƾ.NoChange}},{"Docked",new Î{ß="Cruise",ā=ơ.On,ÿ=Ǔ.AllDefence,þ=ǒ.HoldFire,ý=ǔ.Off,ü=ǖ.Off,û=Ǖ.Off,ú=ǂ.On,ù=new
Color(33,144,255,255),ø=ǂ.On,ö=new Color(255,240,225,255),õ=ǂ.On,ô=new Color(255,255,255,255),ó=Ǒ.StockpileRecharge,ò=-1,ñ=ơ.
NoChange,ð=ǀ.Abort,Ā=ơ.Off,Ă=ƿ.On,ē=ơ.On,Ĕ=ƾ.NoChange}},{"Docking",new Î{ß="Docked",ā=ơ.On,ÿ=Ǔ.AllDefence,þ=ǒ.HoldFire,ý=ǔ.Off,ü
=ǖ.On,û=Ǖ.OnMax,ú=ǂ.On,ù=new Color(33,144,255,255),ø=ǂ.On,ö=new Color(212,170,83,255),õ=ǂ.On,ô=new Color(212,170,83,255),
ó=Ǒ.Auto,ò=-1,ñ=ơ.NoChange,ð=ǀ.Abort,Ā=ơ.Off,Ă=ƿ.KeepFull,ē=ơ.On,Ĕ=ƾ.NoChange}},{"NoAttack",new Î{ß="Docked",ā=ơ.Off,ÿ=Ǔ.
Off,þ=ǒ.Off,ý=ǔ.On,ü=ǖ.On,û=Ǖ.Off,ú=ǂ.On,ù=new Color(255,255,255,255),ø=ǂ.On,ö=new Color(84,157,82,255),õ=ǂ.NoChange,ô=new
Color(84,157,82,255),ó=Ǒ.NoChange,ò=-1,ñ=ơ.NoChange,ð=ǀ.NoChange,Ā=ơ.NoChange,Ă=ƿ.KeepFull,ē=ơ.On,Ĕ=ƾ.NoChange}},{"Combat",
new Î{ß="Cruise",ā=ơ.On,ÿ=Ǔ.AllDefence,þ=ǒ.OpenFire,ý=ǔ.On,ü=ǖ.On,û=Ǖ.Off,ú=ǂ.Off,ù=new Color(0,0,0,255),ø=ǂ.On,ö=new Color
(210,98,17,255),õ=ǂ.Off,ô=new Color(210,98,17,255),ó=Ǒ.ManagedDischarge,ò=100,ñ=ơ.On,ð=ǀ.Abort,Ā=ơ.On,Ă=ƿ.KeepFull,ē=ơ.On
,Ĕ=ƾ.NoChange}},{"CQB",new Î{ß="Combat",ā=ơ.On,ÿ=Ǔ.Offence,þ=ǒ.OpenFire,ý=ǔ.On,ü=ǖ.On,û=Ǖ.Off,ú=ǂ.Off,ù=new Color(0,0,0,
255),ø=ǂ.On,ö=new Color(243,18,18,255),õ=ǂ.Off,ô=new Color(243,18,18,255),ó=Ǒ.ManagedDischarge,ò=100,ñ=ơ.On,ð=ǀ.Abort,Ā=ơ.
On,Ă=ƿ.KeepFull,ē=ơ.On,Ĕ=ƾ.NoChange}},{"WeaponsHot",new Î{ß="CQB",ā=ơ.On,ÿ=Ǔ.Offence,þ=ǒ.OpenFire,ý=ǔ.NoChange,ü=ǖ.
NoChange,û=Ǖ.NoChange,ú=ǂ.NoChange,ù=new Color(0,0,0,255),ø=ǂ.NoChange,ö=new Color(243,18,18,255),õ=ǂ.NoChange,ô=new Color(243,
18,18,255),ó=Ǒ.ManagedDischarge,ò=-1,ñ=ơ.NoChange,ð=ǀ.NoChange,Ā=ơ.NoChange,Ă=ƿ.KeepFull,ē=ơ.On,Ĕ=ƾ.NoChange}}};}class ѩ{
public IMyDoor ɑ;public int ҽ=0;public int һ=0;public bool Һ=false;public bool ҹ=false;}class Ҹ{public string ҷ;public bool Ҷ=
false;public int ҵ=0;public bool Ҵ=false;public List<ѩ>ҳ=new List<ѩ>();public List<IMyAirVent>Ҳ=new List<IMyAirVent>();}int ұ
=0;int Ұ=0;int ү=0;bool Ү(ѩ Ҡ){bool Ҽ=false;if(Ҡ.ɑ==null)return false;bool ĸ=Ҡ.ɑ.OpenRatio>0;ұ++;if(ҭ(Ҡ.ɑ))ү++;if(ĸ){Ҡ.ɑ.
Enabled=true;if(ʂ&&Ҡ.ҽ==0)Echo("Door just opened... ("+Ҡ.ɑ.CustomName+")");Ҡ.ҽ++;if(Ҡ.ҽ>=ʶ){Ҡ.ҽ=0;Ҡ.ɑ.CloseDoor();Ҽ=true;}}else
{Ұ++;}return Ҽ;}void Ҿ(){if(!ʷ){if(ʂ)Echo("Door management is disabled.");return;}foreach(Ҹ ɢ in χ){foreach(ѩ Ҡ in ɢ.ҳ){
if(Ҡ.ɑ==null)continue;bool Ҽ=Ү(Ҡ);if(Ҽ){if(ʂ)Echo("Airlock door "+Ҡ.ɑ.CustomName+" just closed");if(ɢ.Ҵ)ɢ.Ҵ=false;else{ɢ.Ҷ
=true;Ҡ.ҹ=true;if(ʂ)Echo("Airlock "+ɢ.ҷ+" needs to cycle");}}}if(ɢ.Ҷ){foreach(ѩ Ҡ in ɢ.ҳ){if(Ҡ.ɑ==null)continue;if(Ҡ.ɑ.
OpenRatio>0)Ҡ.ɑ.CloseDoor();else Ҡ.ɑ.Enabled=false;}bool ӈ=false;foreach(IMyAirVent Ӈ in ɢ.Ҳ){if(Ӈ==null)continue;if(!Ӈ.Enabled)Ӈ
.Enabled=true;if(!Ӈ.Depressurize)Ӈ.Depressurize=true;if(Ӈ.CanPressurize&&Ӈ.GetOxygenLevel()<.01&&ɢ.Ҷ)ӈ=true;}ɢ.ҵ++;bool ӆ
=true;if(ɢ.ҵ>=ʵ){ӆ=false;ӈ=true;}if(ӈ){ɢ.Ҷ=false;ɢ.ҵ=0;ɢ.Ҵ=true;foreach(ѩ Ҡ in ɢ.ҳ){if(Ҡ.ɑ==null)continue;Ҡ.ɑ.Enabled=
true;if(Ҡ.ҹ)Ҡ.ҹ=false;else if(ӆ)Ҡ.ɑ.OpenDoor();}}}}}void Ӊ(){if(!ʷ){if(ʂ)Echo("Door management is disabled.");return;}ұ=0;Ұ=
0;ү=0;foreach(ѩ Ҡ in ψ)Ү(Ҡ);}void ӄ(ƾ I){if(I==ƾ.NoChange)return;foreach(IMyAirtightHangarDoor Ӄ in Ϣ){if(Ӄ==null)
continue;if(I==ƾ.Closed)Ӄ.CloseDoor();else Ӄ.OpenDoor();}}void ӂ(string Ӂ,string Ӏ){Ӂ=Ӂ.ToLower();foreach(ѩ Ҡ in ψ){if(Ӏ==""||Ҡ.
ɑ.CustomName.Contains(Ӏ)){bool ҿ=ҭ(Ҡ.ɑ);if(ҿ&&(Ӂ=="locked"||Ӂ=="toggle"))Ҡ.ɑ.ApplyAction("AnyoneCanUse");if(!ҿ&&(Ӂ==
"unlocked"||Ӂ=="toggle"))Ҡ.ɑ.ApplyAction("AnyoneCanUse");}}}bool ҭ(IMyDoor Ҡ){var ƞ=Ҡ.GetActionWithName("AnyoneCanUse");
StringBuilder ҟ=new StringBuilder();ƞ.WriteValue(Ҡ,ҟ);return(ҟ.ToString()=="On");}double Ҟ;int ҝ=0;int Ҝ=8;int қ=10;double Қ=3;double
ҙ=245000;double Ҙ=50000;double җ=100;void Җ(ƿ I){foreach(IMyTerminalBlock ҕ in ϡ){if(ҕ==null)continue;if(I==ƿ.Off)ҕ.
ApplyAction("OnOff_Off");else ҕ.ApplyAction("OnOff_On");}}void Ҕ(){if(ϡ.Count<1&&Ϡ.Count>1)Ҟ=(Қ*Ҙ);else Ҟ=(Қ*ҙ);}void ғ(){if(đ.Ă==ƿ
.Off||đ.Ă==ƿ.On){if(ʂ)Echo("Extractor management disabled.");}else if(ҝ>0){ҝ--;if(ʂ)Echo("waiting ("+ҝ+")...");}else if(Ϛ
.Count<1){if(ʂ)Echo("No tanks!");}else if(đ.Ă==ƿ.FillWhenLow&&җ<қ){if(ʂ)Echo("Fuel low! ("+җ+"% / "+қ+"%)");Ή=true;Ғ();}
else if(đ.Ă==ƿ.KeepFull&&Õ<(Ø-Ҟ)){Ή=true;Ғ();if(ʂ)Echo("Fuel ready for top up ("+Õ+" < "+(Ø-Ҟ)+")");}else if(ʂ){Echo(
"Fuel level OK ("+җ+"%).");if(đ.Ă==ƿ.KeepFull)Echo("Keeping tanks full\n("+Õ+" < "+(Ø-Ҟ)+")");}}void Ғ(){string Ɠ="";int ҡ=8;if(җ<5){ҡ=0;
if(Ҝ!=ҡ)Ɠ="v fast";}else if(җ<10){ҡ=2;if(Ҝ!=ҡ)Ɠ="fast";}else if(җ<60){ҡ=4;if(Ҝ!=ҡ)Ɠ="medium";}else if(Ҝ!=ҡ)Ɠ="slow";if(Ɠ!=
""){Ҝ=ҡ;Ъ.Add(new ђ("Extractor loading "+Ɠ,"Extractor load speed has been set to "+Ɠ+" automatically)",0));}}void ҫ(){Ή=
false;IMyTerminalBlock Ҭ=null;int ɬ=1;foreach(IMyTerminalBlock ҕ in ϡ){if(ҕ.IsFunctional){Ҭ=ҕ;break;}}if(Ҭ==null){foreach(
IMyTerminalBlock ҕ in Ϡ){if(ҕ.IsFunctional){Ҭ=ҕ;ɬ=2;break;}}if(Ҭ==null){if(ʂ)Echo("No functional extractor to load!");Η=true;return;}}Η=
false;if(ϯ[ɬ].А<1){Θ=ϯ[ɬ].ϲ;return;}Θ="";ҝ=Ҝ;Е ϓ=new Е();ϓ.ɑ=Ҭ;ϓ.ϓ=Ҭ.GetInventory();Ҭ.ApplyAction("OnOff_On");List<Е>Ҫ=new
List<Е>();Ҫ.Add(ϓ);if(ʂ)Echo("Attempting to load extractor "+Ҭ.CustomName);bool ʞ=щ(ϯ[ɬ].Ϭ,Ҫ,ϯ[ɬ].ϵ);string ҩ="fuel tank";if
(ɬ==2)ҩ="jerry can";if(ʞ)Ъ.Add(new ђ("Loaded a "+ҩ,"Sucessfully loaded a "+ҩ+" into an extractor.",0));}double Ҩ=0;int ҧ=
0;double Ҧ=0;void ҥ(bool P,bool Ũ){ҧ=0;foreach(IMyGyro Ҥ in ϟ){if(Ҥ!=null&&Ҥ.IsFunctional){ҧ++;if(Ũ)Ҥ.Enabled=P;}}Ҧ=Math.
Round(100*(ҧ/Ҩ));}void ң(string Ң,bool ˁ=true,bool ˑ=true,bool ː=true){if(ʂ)Echo("Initialising a ship as '"+Ң+"'...");Ύ=true;
ʑ=Ң;Λ=ˁ;Ν=ˑ;Μ=ː;Ѝ();}void Ѝ(){switch(Α){case 0:ˆ();Β=0;if(ʁ)Echo("Took "+ͺ());break;case 1:Ϲ();if(ʁ)Echo("Took "+ͺ());
break;case 2:if(ʂ)Echo("Initialising lcds...");ƅ();if(Ν){if(ʂ)Echo("Initialising subsystem values...");Ȅ();Ȑ();L();N();Ò();è(
);ʮ();Ì=θ.Count+η.Count;Ȋ=ε.Count;Y=ζ.Count;Ҩ=ϟ.Count;Ʀ=Ϊ.Count;}if(Μ){if(ʂ)Echo("Initialising item values...");ϸ();}if(Λ
){if(ʂ)Echo("Initialising block names...");Ј();}ў(false,Ν,Μ);Ъ.Add(new ђ("Init:"+ʑ,"Initialised '"+ʑ+"'\nGood Hunting!",3
));Α=0;Ύ=false;if(ʁ)Echo("Took "+ͺ());return;}Α++;}class Ќ{public int Ћ=0;public int Њ=0;public int Љ=0;}void Ј(){
Dictionary<string,Ќ>Ї=new Dictionary<string,Ќ>();if(ʉ.Count>0){foreach(string R in ʉ){if(ʂ)Echo("Numbering "+R);Ї.Add(R,new Ќ());}
foreach(var Є in φ){Ќ І;if(Ї.TryGetValue(Є.Value,out І)){Ї[Є.Value].Њ++;}}foreach(var Ѕ in Ї){if(Ѕ.Value.Њ<10)Ѕ.Value.Љ=1;else
if(Ѕ.Value.Њ>99)Ѕ.Value.Љ=3;else Ѕ.Value.Љ=2;}}foreach(var Є in φ){string Ѓ="";string Ђ=Є.Value;Ќ Ё;if(Ї.TryGetValue(Є.
Value,out Ё)){if(Ё.Њ>1){Ё.Ћ++;Ѓ=ʌ+Ё.Ћ.ToString().PadLeft(Ё.Љ,'0');}}Є.Key.CustomName=ʑ+ʌ+Ђ+Ѓ+Ў(Є.Key.CustomName,Ђ);}}string Ў
(string ȴ,string К=""){try{string[]Л=ȴ.Split(ʌ);string[]Й=К.Split(ʌ);string Ɖ="";if(Л.Length<3)return"";for(int ĝ=2;ĝ<Л.
Length;ĝ++){int И=0;bool З=int.TryParse(Л[ĝ],out И);if(З)Л[ĝ]="";foreach(string Ж in Й){if(Ж==Л[ĝ])Л[ĝ]="";}if(Л[ĝ]!="")Ɖ+=ʌ+Л
[ĝ];}return Ɖ;}catch{return"";}}class Е{public IMyTerminalBlock ɑ{get;set;}public IMyInventory ϓ{get;set;}List<
MyInventoryItem>Д=new List<MyInventoryItem>();public int Г=0;public bool В=false;public float Б;}class ɬ{public int А=0;public int Џ=0;
public int Ѐ=0;public double Ͽ;public List<Е>Ϭ=new List<Е>();public List<Е>Ϸ=new List<Е>();public MyItemType ϵ;public bool ϴ=
false;public bool ϳ=false;public string ϲ;public string ϱ;public double ϰ=1;}List<ɬ>ϯ=new List<ɬ>();void Ϯ(IMyTerminalBlock Ɉ
,int ʗ=99){if(ʗ==99){foreach(var ɬ in ϯ){Е ϓ=new Е();ϓ.ɑ=Ɉ;ϓ.ϓ=Ɉ.GetInventory();ɬ.Ϭ.Add(ϓ);}}else{Е ϓ=new Е();ϓ.ɑ=Ɉ;ϓ.ϓ=Ɉ
.GetInventory();ϓ.В=ʽ;if(ʗ==0&&!ʼ)ϓ.В=false;ϯ[ʗ].Ϭ.Add(ϓ);}}void ϭ(IMyTerminalBlock Ɉ,int ʗ){Е ϓ=new Е();ϓ.ɑ=Ɉ;ϓ.ϓ=Ɉ.
GetInventory();ϓ.В=ʽ;if(ʗ!=99)ϯ[ʗ].Ϸ.Add(ϓ);}void Ͼ(string ϲ,string Ͻ,string ϼ,bool ϳ=false,bool ϴ=false){ɬ ɬ=new ɬ();ɬ.ϵ=new
MyItemType(Ͻ,ϼ);ɬ.ϳ=ϳ;ɬ.ϴ=ϴ;ɬ.ϲ=ϲ;string ϱ;if(ϲ.Length>9)ϱ=ϲ.Substring(0,9);else ϱ=ϲ.PadRight(9);ɬ.ϱ=ϱ;ϯ.Add(ɬ);}void ϻ(){try{Ͼ(
"Fusion Fuel","MyObjectBuilder_Ingot","FusionFuel",true);Ͼ("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");Ͼ("Jerry Can",
"MyObjectBuilder_Component","SG_Fuel_Tank");Ͼ("PDC","MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine",true);Ͼ("PDC Tefl",
"MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);Ͼ("220 Torp ","MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",
true,true);Ͼ("220 MCRN","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true,true);Ͼ("220 UNN",
"MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);Ͼ("RS Torp","MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);
Ͼ("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",true,true);Ͼ("120mm RG",
"MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);Ͼ("Dawson","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true
);Ͼ("Stiletto","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugMCRNMagazine",true);Ͼ("80mm",
"MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);Ͼ("Foehammr","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugMCRNMagazine",true);Ͼ("Farren","MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugUNNMagazine",true);Ͼ("Kess",
"MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);Ͼ("Steel Pla","MyObjectBuilder_Component","SteelPlate");ϯ[0].ϰ=ʃ;}catch(Exception
ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void Ϻ(){foreach(var ɬ in ϯ){ɬ.Ϸ.Clear();}}void Ϲ(){
foreach(var ɬ in ϯ){ɬ.А=0;ɬ.Ѐ=0;List<Е>ˡ=ɬ.Ϭ.Concat(ɬ.Ϸ).ToList();foreach(Е ϓ in ˡ){ϓ.Г=ϓ.ϓ.GetItemAmount(ɬ.ϵ).ToIntSafe();ɬ.А
+=ϓ.Г;if(ϓ.В){ϓ.Б=ϓ.ϓ.VolumeFillFactor;}else{ɬ.Ѐ+=ϓ.Г;}}}}void ϸ(){foreach(ɬ ɬ in ϯ){ɬ.Џ=ɬ.А;}}int М(string ǻ){switch(ǻ){
case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":case"MCRN Torpedo Low Spread":return 6;case
"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;case"40mm Lead-Steel PDC Box Ammo":
return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":return 10;case
"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case"80mm Tungsten-Uranium Sabot Ammo":return 13;case
"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;case"180mm Lead-Steel Sabot Ammo":return 16;default:if(ʂ
)Echo("Unknown AmmoType = "+ǻ);return 99;}}bool ь(IMyTerminalBlock ɑ){IMyInventory ъ=ɑ.GetInventory();return ъ.
VolumeFillFactor==0;}bool щ(List<Е>ˣ,List<Е>ϙ,MyItemType ϵ,int ш=-1,double ч=1,double ц=1){if(ʂ)Echo("Loading "+ϙ.Count+
" inventories from "+ˣ.Count+" sources.");bool t=false;bool х=ц<1;foreach(Е ф in ϙ){int у=3;foreach(Е т in ˣ){if(у<0)break;if(ш!=-1&&ф.Г>=(ш
*.95))break;if(!ф.ϓ.IsConnectedTo(т.ϓ))continue;List<MyInventoryItem>с=new List<MyInventoryItem>();т.ϓ.GetItems(с);
foreach(MyInventoryItem ы in с){if(ы.Type==ϵ){int Г=ы.Amount.ToIntSafe();if(Г==0&&!х)break;у--;if(х){у=-1;try{Г=т.Г-Convert.
ToInt32(т.Г/т.Б*ц);if(ʂ)Echo("Unload "+Г+"\n"+т.Г+"\n"+Convert.ToInt32(т.Г/т.Б*ц));}catch(Exception ex){if(ʂ)Echo(
"Int conversion error at unload\n"+ex.Message);Г=1;}}else if(ч<1){try{int ћ=Convert.ToInt32(ф.Г/ф.Б*ч)-ф.Г;if(ћ<Г)Г=ћ;}catch(Exception ex){if(ʂ)Echo(
"Int conversion error at load\n"+ex.Message);Г=1;}}else if(ш!=-1){if(Г<=ш){break;}Г=ш-ф.Г;}t=ф.ϓ.TransferItemFrom(т.ϓ,ы,Г);if(t)у=-1;if(х&&t)return(t);
break;}}}}return t;}class ќ{public IMyTextPanel ɑ;public bool њ=true;public bool љ=false;public bool ј=false;public bool ї=
true;public bool і=true;public bool ѕ=true;public bool є=false;public bool ѓ=false;}class ђ{public string ё,ѐ;public int я,ю
;public ђ(string э,string р,int п=0,int Н=20){if(э.Length>Т-3)э=э.Substring(0,Т-3);ё=э.PadRight(Т-3);ѐ=р;я=п;ю=Н;}}List<ђ
>Ъ=new List<ђ>();class Щ{public string Ш,Ч;public Щ(string R,int Ц,int Х){string Ф="    ";while(Х>3){Х-=4;}if(Ц==0){Ш=
"║ "+R.PadRight(4)+" ║";Ч="  "+Ф+"  ";}else if(Ц==1){if(Х==0||Х==2)Ш="║─"+R.PadRight(4)+" ║";else Ш="║ "+R.PadRight(4)+"─║";
Ч=" ░"+Ф+"░ ";}else if(Ц==2){if(Х==0||Х==2){Ш="║ "+R.PadRight(4)+"═║";Ч="║▒"+Ф+"░║";}else{Ш="║═"+R.PadRight(4)+" ║";Ч=
"║░"+Ф+"▒║";}}else if(Ц==3){if(Х==0||Х==2){Ш="║!"+R.PadRight(4)+"!║";Ч="║▓"+Ф+"▓║";}else{Ш="║ "+Ф+" ║";Ч="║!"+R.PadRight(4)+
"!║";}}}}Color У=new Color(255,116,33,255);const int Т=32;int С=0;string[]Р=new string[]{"▄ "," ▄"," ▀","▀ "},П=new string[]
{"─","\\","│","/"},О=new string[]{"- ","= ","x ","! "};string Ы,Ь,н,о,м="\n\n",л,к="╔══════╗",й="╚══════╝",и,з,ж,е,д,г,в,
б,а,Я,Ю,Э,ʒ,ɂ,à,ŉ,ň,Ň,ņ,Ņ,ń;void Ń(){к=к+к+к+к+"\n";й=й+й+й+й+"\n";Ы=ƒ("Welcome to")+м+ƒ("R S M")+м;Ь=ƒ("Initialising")+м
;н=new String(' ',Т-8);о="└"+new String('─',Т-2)+"┘";и=new String('-',26)+"\n";л="──"+м;з=ł("Inventory");ж=ł("Thrust");е=
ł("Power & Tanks");д=ł("Warnings");г=ł("Subsystem Integrity");в=ł("Telemetry & Thrust");б=ŀ("Velocity");а=ŀ(
"Velocity (Max)");Я=ŀ("Mass");Ю=ŀ("Max Accel");Э=ŀ("Actual Accel");ʒ=ŀ("Accel (Best)");ɂ=ŀ("Max Thrust");à=ŀ("Actual Thrust");ŉ=ŀ(
"Decel (Dampener)");ň=ŀ("Decel (Actual)");Ň=ľ("Fuel");ņ=ľ("Oxygen");Ņ=ľ("Battery");ń=ľ("Capacity");}string ł(string Ł){return"──┤ "+Ł+" ├"
+new String('─',Т-9-Ł.Length);}string ŀ(string Ŀ){return Ŀ+":"+new String(' ',Т-16-Ŀ.Length);}string ľ(string Ľ){return Ľ
+new String(' ',Т-22-Ľ.Length)+"[";}void ļ(){С++;if(С>=Р.Length)С=0;int Ļ=С+2;if(Ļ>3)Ļ-=4;string Ŋ=Р[С];string Ō=П[С];
string ŝ=Р[Ļ];string Ş=з+Ō+л;string Ŝ=ж+Ō+л;string ś=е+Ō+л;string Ś=д+Ō+л;string ř=г+Ō+л;string Ř=в+Ō+л;string ŗ=ƒ(ʑ.ToUpper()
)+"\n"+"  "+Ŋ+" "+ƒ(Ē,Т-10)+" "+Ŋ+"  \n";string Ŗ="\n  "+ŝ+н+ŝ+"  "+м;if(Ώ){string ŕ=Ы+ƒ("Booting"+new string('.',Ε))+м;Ş
+=ŕ;Ŝ+=ŕ;ś+=ŕ;Ś+=ŕ;ř+=ŕ;}else if(Ύ){string Ŕ=Ь+ƒ(ʑ)+м;Ş+=Ŕ;Ŝ+=Ŕ;ś+=Ŕ;Ś+=Ŕ;ř+=Ŕ;}else{ʦ();double œ=9.81,Œ=Math.Round(Φ),ő=
Math.Round((æ/Υ/œ),2),Ő=Math.Round((å/Υ/œ),2),ŏ=Math.Round(G+Â,1),Ŏ=Math.Round(Å,1),ō=Math.Round(100*(í/ì)),ĺ=Math.Round(100
*(n/Ã)),Ĺ=Math.Round(100*(Ŏ/ŏ));string Ė=б,Ĥ=" Gs",ģ;List<string>Ģ=new List<string>();if(Œ<1){Œ=500;Ė=а;}if(ʄ){œ=1;Ĥ=
" m/s/s";}for(int ĝ=0;ĝ<ϯ.Count;ĝ++){if(ϯ[ĝ].Џ!=0){ϯ[ĝ].Ͽ=(100*((double)ϯ[ĝ].А/(double)ϯ[ĝ].Џ));string ġ=(ϯ[ĝ].А+"/"+ϯ[ĝ].Џ).
PadLeft(9);if(ġ.Length>9)ġ=ġ.Substring(0,9);Ş+=ϯ[ĝ].ϱ+" ["+Ž(ϯ[ĝ].Ͽ)+"] "+ġ+"\n";if(ĝ>2&&ϯ[ĝ].Ѐ<1)Ģ.Add(ϯ[ĝ].ϲ);}}Ş+="\n";if(å>
0)Ŝ+=ň+ƍ(å,Œ)+"\n"+Э+(Ő+Ĥ).PadLeft(15)+м;else Ŝ+=ŉ+ƍ(æ,Œ,true)+"\n"+ʒ+(ő+Ĥ).PadLeft(15)+м;җ=Math.Round(100*(Õ/Ø));ś+=Ň+Ž(
җ)+"] "+(җ+" %").PadLeft(9)+"\n"+ņ+Ž(ō)+"] "+(ō+" %").PadLeft(9)+"\n"+Ņ+Ž(ĺ)+"] "+(ĺ+" %").PadLeft(9)+"\n"+ń+Ž(Ĺ)+"] "+(Ĺ
+" %").PadLeft(9)+"\n"+"Max Power:"+(Ŏ+" MW / "+ŏ+" MW").PadLeft(22)+м;List<ђ>Ġ=new List<ђ>();List<Щ>ğ=new List<Щ>();int
Ğ=0;for(int ĝ=0;ĝ<Ъ.Count;ĝ++){Ъ[ĝ].ю--;if(Ъ[ĝ].ю<1)Ъ.RemoveAt(ĝ);else Ġ.Add(Ъ[ĝ]);}if(!Ū){Ġ.Add(new ђ("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(Ά){Ġ.Add(new ђ("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int Ĝ=0;if(җ<5)
{ģ="FUEL CRITICAL!";Ġ.Add(new ђ(ģ,ģ+"\nFuel Level < 5%!",3));Ĝ=3;}else if(җ<25){ģ="FUEL LOW!";Ġ.Add(new ђ(ģ,ģ+
"\nFuel Level < 10%!",2));Ĝ=2;}if(đ.Ă!=ƿ.Off){if(Θ!=""){if(Ĝ==0)Ĝ=1;Ġ.Add(new ђ("NO SPARE "+Θ.ToUpper()+"!",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",Ĝ));}if(Η){if(Ĝ==0)Ĝ=1;Ġ.Add(new ђ("NO EXTRACTOR!","Cannot refuel!\nNo functional extractor!",Ĝ));}}ğ.Add(new Щ("FUEL",
Ĝ,С+Ğ));Ğ++;if(Έ){ģ=ϛ.Count+" spawns are open to friends";Ġ.Add(new ђ(ģ,ģ,0));}int ě=0;if(ō<5){ģ="OXYGEN CRITICAL!";Ġ.Add
(new ђ(ģ,ģ+"\nShip O2 Level < 5%!",3));ě=3;}else if(ō<10){ģ="OXYGEN LOW!";Ġ.Add(new ђ(ģ,ģ+"\nShip O2 Level < 10%!",2));ě=
2;}else if(ō<25){ģ="Oxygen Low!";Ġ.Add(new ђ(ģ,ģ+"\nShip O2 Level < 25%!",1));ě=1;}if(λ.Count>ű){int Ě=(λ.Count-ű);ě++;ģ=
Ě+" vents are unsealed";Ġ.Add(new ђ(ģ,ģ,1));}if(ү>0){ģ=ү+" doors are insecure";Ġ.Add(new ђ(ģ,ģ,0));}if(Ψ>0){ģ=ʱ+
" is active ("+Ψ+")";Ġ.Add(new ђ(ģ,ģ,0));}ğ.Add(new Щ("OXYG",ě,С+Ğ));Ğ++;int ę=0;if(Ϧ.Count>0){if(ĺ<5){ę+=2;ģ="BATTERIES CRITICAL!";Ġ.
Add(new ђ(ģ,ģ+"\nBattery Level < 5%!",2));}else if(ĺ<10){ę+=1;ģ="Batteries Low!";Ġ.Add(new ђ(ģ,ģ+"\nBattery Level < 10%!",1
));}}if(ϝ.Count>0){if(D>0){ę+=2;Ġ.Add(new ђ(D+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}
if(ϯ[0].А<1){ę+=3;ģ="NO FUSION FUEL!";Ġ.Add(new ђ(ģ,ģ,2));}else if(ϯ[0].А<50){ę+=2;ģ="FUSION FUEL CRITICAL! ("+ϯ[0].А+")";
Ġ.Add(new ђ(ģ,ģ,2));}else if(ϯ[0].Џ>0&&ϯ[0].Ͽ<5){ę+=2;ģ="FUSION FUEL CRITICAL!";Ġ.Add(new ђ(ģ,ģ,3));}else if(ϯ[0].Џ>0&&ϯ[
0].Ͽ<10){ę+=1;ģ="Fusion Fuel Level Low!";Ġ.Add(new ђ(ģ,ģ,2));}}if(ę>3)ę=3;ğ.Add(new Щ("POWR",ę,С+Ğ));Ğ++;int Ę=0;if(Ģ.
Count>0){foreach(string ė in Ģ){string ĥ=ė;if(ė.Length>23)ĥ=ė.Substring(0,23);ĥ=ĥ.ToUpper();ģ="NO SPARE "+ĥ+"!";Ġ.Add(new ђ(ģ
,ģ,3));}Ę=3;}if(Ę>3)Ę=3;ğ.Add(new Щ("WEAP",Ę,С+Ğ));Ğ++;if(ʹ){string ħ=ͳ;if(ϧ.Count>0)if(ϧ[0]!=null)ħ=(ϧ[0]as
IMyRadioAntenna).HudText;string ķ="";if(Ͳ<1000)ķ=Math.Round(Ͳ)+"m";else ķ=Math.Round(Ͳ/1000)+"km";Ġ.Add(new ђ("Comms ("+ķ+"): "+ħ,
"Antenna(s) are broadcasting at a range of "+ķ+" with the message "+ħ,0));}if(Χ>0){ģ=Χ+" UNOWNED BLOCKS!";Ġ.Add(new ђ(ģ,ģ+"\nRSM detected "+Χ+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ұ>Ұ){int ĸ=(ұ-Ұ);ģ=ĸ+" doors are open";Ġ.Add(new ђ(ģ,ģ,0));}Ġ=Ġ.OrderBy(Ķ=>Ķ.я).Reverse().ToList();if(Ġ.Count<1
)Ś+="No warnings\n";else Echo(м+" WARNINGS:");for(int ĝ=0;ĝ<Ġ.Count;ĝ++){Ś+=О[Ġ[ĝ].я]+Ġ[ĝ].ё+"\n";Echo("-"+О[Ġ[ĝ].я]+Ġ[ĝ]
.ѐ);}Ś+="\n";string ĵ=đ.ý.ToString().ToUpper();if(ĵ.Length>3)ĵ=ĵ.Substring(0,3);string Ĵ=đ.ü.ToString().ToUpper();if(Ĵ.
Length>3)Ĵ=Ĵ.Substring(0,3);string ĳ=đ.ý.ToString().ToUpper();if(ĳ.Length>3)ĳ=ĳ.Substring(0,3);string Ĳ=đ.ÿ.ToString().ToUpper
();if(Ĳ.Length>3)Ĳ=Ĳ.Substring(0,3);string ı=đ.ā.ToString().ToUpper();if(ı.Length>3)ı=ı.Substring(0,3);string İ=đ.þ.
ToString().ToUpper();if(İ.Length>3)İ=İ.Substring(0,3);try{if(ä>0)ř+="Epstein   ["+Ž(ã)+"] "+(ã+"% ").PadLeft(5)+ĵ+"\n";if(ȅ>0)ř
+="RCS       ["+Ž(Ȇ)+"] "+(Ȇ+"% ").PadLeft(5)+Ĵ+"\n";if(G>0)ř+="Reactors  ["+Ž(E)+"] "+(E+"% ").PadLeft(5)+"    \n";if(Â>0
)ř+="Batteries ["+Ž(m)+"] "+(m+"% ").PadLeft(5)+ĳ+"\n";if(Ì>0)ř+="PDCs      ["+Ž(Ë)+"] "+(Ë+"% ").PadLeft(5)+Ĳ+"\n";if(Ȋ>
0)ř+="Torpedoes ["+Ž(Ȉ)+"] "+(Ȉ+"% ").PadLeft(5)+ı+"\n";if(Y>0)ř+="Railguns  ["+Ž(W)+"] "+(W+"% ").PadLeft(5)+İ+"\n";if(Ö
>0)ř+="H2 Tanks  ["+Ž(Ô)+"] "+(Ô+"% ").PadLeft(5)+ĳ+"\n";if(ë>0)ř+="O2 Tanks  ["+Ž(ê)+"] "+(ê+"% ").PadLeft(5)+ĳ+"\n";if(
Ҩ>0)ř+="Gyros     ["+Ž(Ҧ)+"] "+(Ҧ+"% ").PadLeft(5)+"    \n";if(ʥ>0)ř+="Cargo     ["+Ž(ʣ)+"] "+(ʣ+"% ").PadLeft(5)+
"    \n";if(Ʀ>0)ř+="Welders   ["+Ž(Ƥ)+"] "+(Ƥ+"% ").PadLeft(5)+"    \n";}catch{}if(Â+G+Ö==0)ř+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+м;string į="";string Į="";foreach(Щ ĭ in ğ){į+=ĭ.Ш;Į+=ĭ.Ч;}int Ĭ=С+2;if(Ĭ>3)Ĭ-=4;ŗ+=к+į+"\n"+й;Ŗ+=Į;if(!Π){Ř+=м;}else{
if(ʂ)Echo("Building advanced thrust...");string ī="";if(ʆ){ī=Я+(Math.Round((Υ/1000000),2)+" Mkg").PadLeft(15)+"\n"+Ė+(Œ+
" ms").PadLeft(15)+"\n"+Ю+(ő+Ĥ).PadLeft(15)+"\n"+Э+(Ő+Ĥ).PadLeft(15)+"\n"+ɂ+((æ/1000000)+" MN").PadLeft(15)+"\n"+à+((å/
1000000)+" MN").PadLeft(15)+"\n";}Ř+=ī+ŉ+ƍ(æ,Œ,true)+"\n"+ň+ƍ(å,Œ)+"\n";foreach(double Ī in ʅ){Ř+=("Decel ("+(Ī*100)+"%):").
PadRight(17)+ƍ((float)(æ*Ī),Œ)+"\n";}Ř+=м;}}foreach(ќ ĩ in ά){string Ħ="";Color Ĩ=đ.ô;if(ĩ.њ)Ħ+=ŗ;if(ĩ.љ){Ħ+=Ŗ;Ĩ=У;}if(ĩ.ј)Ħ+=Ś;
if(ĩ.ї)Ħ+=ś;if(ĩ.і)Ħ+=Ş;if(ĩ.ѕ)Ħ+=Ŝ;if(ĩ.є)Ħ+=ř;if(ĩ.ѓ){Ħ+=Ř;Π=true;}ĩ.ɑ.WriteText(Ħ,false);if(!ʇ)ĩ.ɑ.FontColor=Ĩ;}}void ş
(){if(έ.Count>0){foreach(IMyTextPanel ĩ in έ){ĩ.FontColor=đ.ô;}foreach(ќ ĩ in ά){ĩ.ɑ.FontColor=đ.ô;}}}void Ƃ(string Ɓ,
string ƀ){Ɓ=Ɓ.ToLower();List<IMyTextPanel>ſ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ή);
foreach(IMyTextPanel ĩ in ή){if(ƀ==""||ĩ.CustomName.Contains(ƀ)){string ž=ĩ.CustomData;if(ž.Contains("hudlcd")&&(Ɓ=="off"||Ɓ==
"toggle"))ĩ.CustomData=ž.Replace("hudlcd","hudXlcd");if(ž.Contains("hudXlcd")&&(Ɓ=="on"||Ɓ=="toggle"))ĩ.CustomData=ž.Replace(
"hudXlcd","hudlcd");}}}string Ž(double ż){try{int Ż=0;if(ż>0){int ź=(int)ż/10;if(ź>10)return new string('=',10);if(ź!=0)Ż=ź;}char
Ź=' ';if(ż<10){if(С==0)return" ><    >< ";if(С==1)return"  ><  ><  ";if(С==2)return"   ><><   ";if(С==3)return
"<   ><   >";}string Ÿ=new string('=',Ż);string ŷ=new string(Ź,10-Ż);return Ÿ+ŷ;}catch{return"# ERROR! #";}}string Ŷ(string ƃ){
string ŵ;string ġ="";double ż=0;switch(ƃ){case"H2":ż=Math.Round(100*(Õ/Ö));ġ=ż.ToString()+" %";җ=ż;break;case"O2":ż=Math.Round
(100*(í/ë));ġ=ż.ToString()+" %";break;case"Battery":ż=Math.Round(100*(n/Ã));ġ=ż.ToString()+" %";break;}ŵ=Ž(ż);return" ["+
ŵ+"] "+ġ.PadLeft(9);}string ƒ(string Ƒ,int Ɛ=Т){int Ə=Ɛ-Ƒ.Length;int Ǝ=Ə/2+Ƒ.Length;return Ƒ.PadLeft(Ǝ).PadRight(Ɛ);}
string ƍ(double ƌ,double Ɠ,bool Ƌ=false){if(ƌ<=0)return("N/A").PadLeft(15);if(Ƌ)ƌ=ƌ*1.5;double Ɖ=0.5*(Math.Pow(Ɠ,2)*(Υ/ƌ));
double ƈ=Ɠ/(ƌ/Υ);string Ƈ="m";if(Ɖ>1000){Ƈ="km";Ɖ=Ɖ/1000;}return(Math.Round(Ɖ)+Ƈ+" "+Math.Round(ƈ)+"s").PadLeft(15);}void Ɔ(){
foreach(IMyTextPanel Ŵ in ή){Ŵ.Enabled=true;}}void ƅ(){foreach(ќ ĩ in ά){ĩ.ɑ.Font="Monospace";ĩ.ɑ.ContentType=ContentType.
TEXT_AND_IMAGE;if(ĩ.ɑ.CustomName.Contains("HUD1")){ĩ.њ=true;ĩ.љ=false;ĩ.ј=false;ĩ.ї=false;ĩ.і=false;ĩ.ѕ=false;ĩ.є=false;ĩ.ѓ=false;Ʌ(ĩ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ĩ.ɑ.CustomName.Contains("HUD2")){ĩ.њ=false;ĩ.љ=false;ĩ.ј=true;ĩ.ї=false;ĩ.і=false;ĩ.ѕ=false;ĩ.є=false;ĩ.ѓ
=false;Ʌ(ĩ,"hudlcd:0.22:0.99:0.55");continue;}if(ĩ.ɑ.CustomName.Contains("HUD3")){ĩ.њ=false;ĩ.љ=false;ĩ.ј=false;ĩ.ї=true;
ĩ.і=false;ĩ.ѕ=false;ĩ.є=false;ĩ.ѓ=false;Ʌ(ĩ,"hudlcd:0.48:0.99:0.55");continue;}if(ĩ.ɑ.CustomName.Contains("HUD4")){ĩ.њ=
false;ĩ.љ=false;ĩ.ј=false;ĩ.ї=false;ĩ.і=false;ĩ.ѕ=false;ĩ.є=true;ĩ.ѓ=false;Ʌ(ĩ,"hudlcd:0.74:0.99:0.55");continue;}if(ĩ.ɑ.
CustomName.Contains("HUD5")){ĩ.њ=false;ĩ.љ=false;ĩ.ј=false;ĩ.ї=false;ĩ.і=true;ĩ.ѕ=false;ĩ.є=false;ĩ.ѓ=true;Ʌ(ĩ,"hudlcd:0.75:0:.54"
);continue;}if(ĩ.ɑ.CustomName.Contains("HUD6")){ĩ.њ=false;ĩ.љ=true;ĩ.ј=false;ĩ.ї=false;ĩ.і=false;ĩ.ѕ=false;ĩ.є=false;ĩ.ѓ=
false;Ʌ(ĩ,"hudlcd:-0.55:0.99:0.7");continue;}}bool Ƅ=false;foreach(IMyTextPanel Ŵ in ή){if(Ŵ==null)continue;if(!Ƅ&&(Ŵ.
CustomName.Contains(ʎ)||Ŵ.CustomName.ToUpper().Contains(ʍ))){Ƅ=true;Ŵ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool Ū;void
Š(bool P,bool Ũ){Ū=false;foreach(IMyConveyorSorter ŧ in ι){if(ŧ!=null&&ŧ.IsFunctional){Ū=true;if(Ũ)ŧ.Enabled=P;}}}void Ŧ(
Ǖ I){if(I==Ǖ.NoChange)return;foreach(IMyReflectorLight ť in ό){if(ť==null)continue;if(I==Ǖ.Off)ť.Enabled=false;else{ť.
Enabled=false;if(I==Ǖ.OnMax)ť.Radius=9999;}}}void Ť(ǂ I,Color Ĩ){if(I==ǂ.NoChange)return;foreach(IMyLightingBlock Ţ in Ϋ){if(Ţ
==null)continue;if(I==ǂ.Off)Ţ.Enabled=false;else Ţ.Enabled=true;if(I!=ǂ.OnNoColourChange)Ţ.SetValue("Color",Ĩ);}}void ţ(ǂ
I,Color Ĩ){if(I==ǂ.NoChange)return;foreach(IMyLightingBlock Ţ in κ){if(Ţ==null)continue;if(I==ǂ.Off)Ţ.Enabled=false;else
Ţ.Enabled=true;if(I!=ǂ.OnNoColourChange)Ţ.SetValue("Color",Ĩ);}}Color š=new Color(255,0,0,255);Color ũ=new Color(255,0,0,
255);Color ū=new Color(0,255,0,255);void ų(ǂ I){if(I==ǂ.NoChange)return;foreach(IMyLightingBlock Ţ in μ){Ų(Ţ,I,ũ);}foreach(
IMyLightingBlock Ţ in ϋ){Ų(Ţ,I,ū);}}void Ų(IMyLightingBlock Ţ,ǂ I,Color Ĩ){if(Ţ==null)return;if(I==ǂ.Off){Ţ.Enabled=false;Ţ.SetValue(
"Color",š);}else{Ţ.Enabled=true;if(I!=ǂ.OnNoColourChange)Ţ.SetValue("Color",Ĩ);}}int ű=0;void Ű(bool P,bool Ũ){ű=0;foreach(
IMyAirVent ů in λ){if(ů!=null){if(Ũ)ů.Enabled=P;if(ů.CanPressurize)ű++;}}}void Ů(bool P){foreach(IMyShipConnector ŭ in ϣ){if(ŭ!=
null)ŭ.Enabled=P;}}void Ŭ(bool P){foreach(IMyCameraBlock ĕ in ϥ){if(ĕ!=null)ĕ.Enabled=P;}}void À(bool P){foreach(
IMySensorBlock º in Ϝ){if(º!=null)º.Enabled=P;}}void µ(){Ά=true;foreach(IMyTerminalBlock ª in ϛ){ª.ApplyAction("OnOff_On");if(ª.
IsFunctional)Ά=false;}}bool z=false;List<string>y=new List<string>();bool x=false;List<string>w=new List<string>();void v(string o,
string u){bool t=false;List<IMyProgrammableBlock>s=new List<IMyProgrammableBlock>();try{if(u=="EFC")s=ΰ;else if(u=="NavOS")s=ί
;foreach(IMyProgrammableBlock q in ΰ){if(q==null||!q.Enabled)continue;t=(q as IMyProgrammableBlock).TryRun(o);if(t&&ʂ)
Echo("Ran "+o+" on "+q.CustomName+" successfully.");else Ъ.Add(new ђ(u+" command failed!",u+" command "+o+" failed!",1));if(
u=="EFC")z=true;else if(u=="NavOS")x=true;break;}}catch(Exception ex){Ъ.Add(new ђ(u+" command errored!",u+" command "+o+
" errored!\n"+ex.Message,3));}}void p(string o,string u){if(u=="EFC"){if(ΰ.Count<1)return;if(z){y.Add(o);return;}}if(u=="NavOS"){if(ί
.Count<1)return;if(x){w.Add(o);return;}}v(o,u);}void Á(){if(y.Count>0&&!z){v(y[0],"EFC");y.RemoveAt(0);}if(w.Count>0&&!x)
{v(w[0],"NavOS");w.RemoveAt(0);}z=false;x=false;}int Ì=0;double Í=0;double Ë=0;void Ê(){Í=0;foreach(IMyTerminalBlock Æ in
θ){É(Æ,đ.ÿ!=Ǔ.Off&&đ.ÿ!=Ǔ.MinDefence);}foreach(IMyTerminalBlock Æ in η){É(Æ,đ.ÿ!=Ǔ.Off);}Ë=Math.Round(100*(Í/Ì));}void É(
IMyTerminalBlock È,bool P){if(È!=null&&È.IsFunctional){Í++;(È as IMyConveyorSorter).Enabled=P;}}void Ç(Ǔ I){if(I==Ǔ.NoChange)return;
foreach(IMyTerminalBlock Æ in θ){if(Æ!=null&Æ.IsFunctional){switch(I){case Ǔ.Off:case Ǔ.MinDefence:(Æ as IMyConveyorSorter).
Enabled=false;break;case Ǔ.AllDefence:(Æ as IMyConveyorSorter).Enabled=true;if(ʻ){try{Æ.SetValue("WC_FocusFire",false);Æ.
SetValue("WC_Projectiles",true);Æ.SetValue("WC_Grids",true);Æ.SetValue("WC_LargeGrid",false);Æ.SetValue("WC_SmallGrid",true);Æ.
SetValue("WC_SubSystems",true);Æ.SetValue("WC_Biologicals",true);ʪ(Æ);}catch{Echo("Strange PDC config error! Possible WC crash!"
);}}break;case Ǔ.Offence:(Æ as IMyConveyorSorter).Enabled=true;if(ʻ){try{Æ.SetValue("WC_FocusFire",false);Æ.SetValue(
"WC_Projectiles",true);Æ.SetValue("WC_Grids",true);Æ.SetValue("WC_LargeGrid",true);Æ.SetValue("WC_SmallGrid",true);Æ.SetValue(
"WC_SubSystems",true);Æ.SetValue("WC_Biologicals",true);ʪ(Æ);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock Æ in η){if(Æ!=null&Æ.IsFunctional){switch(I){case Ǔ.Off:(Æ as IMyConveyorSorter).Enabled=false;break;
case Ǔ.MinDefence:case Ǔ.AllDefence:case Ǔ.Offence:(Æ as IMyConveyorSorter).Enabled=true;if(ʻ){try{Æ.SetValue("WC_FocusFire"
,false);Æ.SetValue("WC_Projectiles",true);Æ.SetValue("WC_Grids",true);Æ.SetValue("WC_LargeGrid",false);Æ.SetValue(
"WC_SmallGrid",true);Æ.SetValue("WC_SubSystems",true);Æ.SetValue("WC_Biologicals",true);ʫ(Æ);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double Å;void Ä(Ǒ I){Å=0;C();A(I);}double Ã=0;double Â=0;double n=0;double m=0;void A(Ǒ I){Ã=0;n=0;double
M=0;foreach(IMyBatteryBlock H in Ϧ){if(H!=null&&H.IsFunctional){n+=H.CurrentStoredPower;Ã+=H.MaxStoredPower;M+=H.
MaxOutput;H.Enabled=true;if(I==Ǒ.ManagedDischarge){if(V||F<=0)H.ChargeMode=ChargeMode.Discharge;else H.ChargeMode=ChargeMode.
Recharge;}}}m=Math.Round(100*(M/Â));Å+=M;}void L(){Â=0;foreach(IMyBatteryBlock H in Ϧ){Echo("FFS CUNT1"+H.MaxOutput);ChargeMode
K=H.ChargeMode;H.ChargeMode=ChargeMode.Auto;Echo("FFS CUNT2"+H.MaxOutput);Â+=H.MaxOutput;H.ChargeMode=K;Echo("FFS CUNT3"+
H.MaxOutput);}}void J(Ǒ I){if(I==Ǒ.NoChange)return;foreach(IMyBatteryBlock H in Ϧ){if(H!=null&&!H.Closed&&H.IsFunctional)
{H.Enabled=true;if(I==Ǒ.Auto)H.ChargeMode=ChargeMode.Auto;else if(I==Ǒ.StockpileRecharge)H.ChargeMode=ChargeMode.Recharge
;else if(I==Ǒ.Discharge)H.ChargeMode=ChargeMode.Discharge;}}}double G=0;double F=0;double E=0;int D=0;void C(){F=0;D=0;
foreach(IMyReactor B in ϝ){if(B!=null&&!B.Closed&&B.IsFunctional){B.Enabled=true;if(ь(B))D++;else F+=B.MaxOutput;}}E=Math.Round
(100*(F/G));Å+=F;}void N(){G=0;foreach(IMyReactor B in ϝ){G+=B.MaxOutput;}}void l(IMyProjector h){h.CustomData=h.
ProjectionOffset.X+"\n"+h.ProjectionOffset.Y+"\n"+h.ProjectionOffset.Z+"\n"+h.ProjectionRotation.X+"\n"+h.ProjectionRotation.Y+"\n"+h.
ProjectionRotation.Z+"\n";}void k(IMyProjector h){if(!h.IsFunctional)return;try{string[]f=h.CustomData.Split('\n');Vector3I e=new Vector3I
(int.Parse(f[0]),int.Parse(f[1]),int.Parse(f[2]));Vector3I Z=new Vector3I(int.Parse(f[3]),int.Parse(f[4]),int.Parse(f[5])
);h.Enabled=true;h.ProjectionOffset=e;h.ProjectionRotation=Z;h.UpdateOffsetAndRotation();}catch{if(ʂ)Echo(
"Failed to load projector position for "+h.Name);}}int Y=0;double X=0;double W=0;bool V=false;void U(){V=false;X=0;foreach(IMyTerminalBlock O in ζ){if(O!=null&&
O.IsFunctional){X++;(O as IMyConveyorSorter).Enabled=đ.þ!=ǒ.Off;if(!V){MyDetectedEntityInfo?S=ǣ.ș(O);if(S.HasValue){
string R=S.Value.Name;if(R!=null&&R!=""){if(ʂ)Echo("At least one rail has a target!");V=true;}}}}}W=Math.Round(100*(X/Y));}
void Q(ǒ I){if(I==ǒ.NoChange)return;foreach(IMyTerminalBlock O in ζ){if(O!=null&O.IsFunctional){if(I==ǒ.Off){(O as
IMyConveyorSorter).Enabled=false;}else{(O as IMyConveyorSorter).Enabled=true;if(ʻ){O.SetValue("WC_Grids",true);O.SetValue("WC_LargeGrid",
true);O.SetValue("WC_SmallGrid",true);O.SetValue("WC_SubSystems",true);ʪ(O);}if(ʺ){if(I==ǒ.OpenFire){ʧ(O);}else{ʨ(O);}}}}}}
class Î{public string ß="";public ơ ā;public Ǔ ÿ;public ǒ þ;public ǔ ý;public ǖ ü;public Ǖ û;public ǂ ú;public Color ù;public
ǂ ø;public Color ö;public ǂ õ;public Color ô;public Ǒ ó;public int ò;public ơ ñ;public ǀ ð;public ơ Ā;public ƿ Ă;public ơ
ē;public ƾ Ĕ;}string Ē="N/A";Î đ;ơ Đ=ơ.On;Ǔ ď=Ǔ.Offence;ǒ Ď=ǒ.OpenFire;ǔ č=ǔ.On;ǖ Č=ǖ.On;Ǖ ċ=Ǖ.On;ǂ Ċ=ǂ.On;Color ĉ=new
Color(33,144,255,255);ǂ Ĉ=ǂ.On;Color ć=new Color(255,214,170,255);ǂ Ć=ǂ.On;Color ą=new Color(33,144,255,255);Ǒ Ą=Ǒ.Auto;int ă
=-1;ơ ï=ơ.NoChange;ǀ î=ǀ.NoChange;ơ Ï=ơ.NoChange;ƿ Þ=ƿ.KeepFull;ơ Ý=ơ.On;ƾ Ü=ƾ.NoChange;void Û(string Ú){Î Ù;if(!Ѫ.
TryGetValue(Ú,out Ù)){Ъ.Add(new ђ("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ʂ)Echo("Setting stance '"+Ú+"'.");đ=Ù;Ē=Ú;ў();if(ʂ)Echo("Setting "+ζ.Count+" railguns to "+đ.þ);Q(đ.þ);
if(ʂ)Echo("Setting "+ε.Count+" torpedoes to "+đ.ā);ǥ(đ.ā);if(ʂ)Echo("Setting "+θ.Count+" _normalPdcs, "+η.Count+
" defence _normalPdcs to "+đ.ÿ);Ç(đ.ÿ);if(ʂ)Echo("Setting "+δ.Count+" epsteins, "+β.Count+" chems"+" to "+đ.ý);ȃ(đ.ý,đ.ü);if(ʂ)Echo("Setting "+γ.
Count+" rcs, "+α.Count+" atmos"+" to "+đ.ü);ȏ(đ.ü);if(ʂ)Echo("Setting "+Ϧ.Count+" batteries to = "+đ.ó);J(đ.ó);if(ʂ)Echo(
"Setting "+Ϛ.Count+" H2 tanks to stockpile = "+đ.ó);Ð(đ.ó);if(ʂ)Echo("Setting "+ύ.Count+" O2 tanks to stockpile = "+đ.ó);ç(đ.ó);if
(ʈ){if(ʂ)Echo("No lighting was set because lighting control is disabled.");}else{if(ʂ)Echo("Setting "+ό.Count+
" spotlights to "+đ.û);Ŧ(đ.û);if(ʂ)Echo("Setting "+Ϋ.Count+" exterior lights to "+đ.ú);Ť(đ.ú,đ.ù);if(ʂ)Echo("Setting "+κ.Count+
" exterior lights to "+đ.ø);ţ(đ.ø,đ.ö);if(ʂ)Echo("Setting "+μ.Count+" port nav lights, "+ϋ.Count+" starboard nav lights to "+đ.õ);ų(đ.õ);}if(ʂ
)Echo("Setting "+ϊ.Count+" aux block to "+đ.Ā);Ϗ(đ.Ā);if(ʂ)Echo("Setting "+ϡ.Count+" extrators to "+đ.Ă);Җ(đ.Ă);if(ʂ)Echo
("Setting "+Ϣ.Count+" hangar doors units to "+đ.Ĕ);ӄ(đ.Ĕ);if(đ.þ==ǒ.OpenFire){if(ʂ)Echo("Setting "+ψ.Count+
" doors to locked because we are in combat (rails set to open fire).");ӂ("locked","");}if(ʂ)Echo("Setting "+έ.Count+" colour sync Lcds.");ş();if(đ.ð==ǀ.Abort){p("Off","EFC");p("Abort",
"NavOS");}if(đ.ò>0){p("Set Burn "+đ.ò,"EFC");p("Thrust Set "+đ.ò/100,"NavOS");}if(đ.ñ==ơ.On)p("Boost On","EFC");else if(đ.ñ==ơ.
Off)p("Boost Off","EFC");if(ʂ)Echo("Finished setting stance.");}double Ø=0;double Ö=0;double Õ=0;double Ô=0;void Ó(){Õ=0;Ø=
0;foreach(IMyGasTank Ñ in Ϛ){if(Ñ.IsFunctional){Ñ.Enabled=true;Ø+=Ñ.Capacity;Õ+=(Ñ.Capacity*Ñ.FilledRatio);}}Ô=Math.Round
(100*(Ø/Ö));}void Ò(){Ö=0;foreach(IMyGasTank Ñ in Ϛ){if(Ñ!=null)Ö+=Ñ.Capacity;}}void Ð(Ǒ I){if(I==Ǒ.NoChange)return;
foreach(IMyGasTank Ñ in Ϛ){if(Ñ==null)continue;Ñ.Enabled=true;if(I==Ǒ.StockpileRecharge)Ñ.Stockpile=true;else Ñ.Stockpile=false
;}}double ì=0;double í=0;double ë=0;double ê=0;void é(){í=0;ì=0;foreach(IMyGasTank Ñ in ύ){if(Ñ.IsFunctional){Ñ.Enabled=
true;ì+=Ñ.Capacity;í+=(Ñ.Capacity*Ñ.FilledRatio);}}ê=Math.Round(100*(ì/ë));}void è(){ë=0;foreach(IMyGasTank Ñ in ύ){if(Ñ!=
null)ë+=Ñ.Capacity;}}void ç(Ǒ I){if(I==Ǒ.NoChange)return;foreach(IMyGasTank Ñ in ύ){if(Ñ==null)continue;Ñ.Enabled=true;if(I
==Ǒ.StockpileRecharge)Ñ.Stockpile=true;else Ñ.Stockpile=false;}}float æ;float å;float ä;double ã;void â(){float á=0;float
Ɗ=0;float Ɣ=0;float Ȼ=0;foreach(IMyThrust ȁ in δ){if(ȁ!=null&&ȁ.IsFunctional){á+=ȁ.MaxThrust;Ɣ+=ȁ.CurrentThrust;if(ȁ.
Enabled){Ɗ+=ȁ.MaxThrust;Ȼ+=ȁ.CurrentThrust;}}}ã=Math.Round(100*(á/ä));if(Ɗ==0){æ=á;å=Ɣ;}else{æ=Ɗ;å=Ȼ;}}void Ȅ(){ä=0;foreach(
IMyThrust ȁ in δ){if(ȁ!=null)ä+=ȁ.MaxThrust;}}void ȃ(ǔ I,ǖ Ȁ){if(I==ǔ.NoChange)return;foreach(IMyThrust ȁ in δ){Ȃ(ȁ,I,Ȁ);}foreach
(IMyThrust ȁ in β){Ȃ(ȁ,I,Ȁ,true);}}void Ȃ(IMyThrust ȁ,ǔ I,ǖ Ȁ,bool ǿ=false){bool Ǿ=ȁ.CustomName.Contains(ʡ);if(Ǿ){if(Ȁ!=ǖ
.Off&&Ȁ!=ǖ.AtmoOnly)ȁ.Enabled=true;else ȁ.Enabled=false;}else{bool ǽ=ȁ.CustomName.Contains(ʯ);if((I==ǔ.On)||(I==ǔ.Minimum
&&ǽ)||(I==ǔ.EpsteinOnly&&!ǿ)||(I==ǔ.ChemOnly&&ǿ)){ȁ.Enabled=true;}else{ȁ.Enabled=false;}}}float Ǽ;float ȅ;double Ȇ;void ȑ(
){Ǽ=0;foreach(IMyThrust ȁ in γ){if(ȁ!=null&&ȁ.IsFunctional){Ǽ+=ȁ.MaxThrust;}}Ȇ=Math.Round(100*(Ǽ/ȅ));}void Ȑ(){ȅ=0;
foreach(IMyThrust ȁ in γ){if(ȁ!=null)ȅ+=ȁ.MaxThrust;}}void ȏ(ǖ I){foreach(IMyThrust ȁ in γ){if(ȁ!=null)Ȏ(ȁ,I);}foreach(
IMyThrust ȁ in α){if(ȁ!=null)Ȏ(ȁ,I,true);}}void Ȏ(IMyThrust ȁ,ǖ I,bool ȍ=false){bool Ȍ=ȁ.GridThrustDirection==Vector3I.Backward;
bool ȋ=ȁ.GridThrustDirection==Vector3I.Forward;if((I==ǖ.On)||(I==ǖ.ForwardOff&&!Ȍ)||(I==ǖ.ReverseOff&&!ȋ)||(I==ǖ.RcsOnly&&!ȍ
)||(I==ǖ.AtmoOnly&&ȍ)){ȁ.Enabled=true;}else{ȁ.Enabled=false;}}int Ȋ=0;double ȉ=0;double Ȉ=0;void ȇ(){ȉ=0;foreach(
IMyTerminalBlock Ǥ in ε){if(Ǥ!=null&&Ǥ.IsFunctional){ȉ++;(Ǥ as IMyConveyorSorter).Enabled=đ.ā==ơ.On;if(ʽ){string ǻ=ǣ.Ʒ(Ǥ,0);int ė=М(ǻ);
if(ʂ)Echo("Launcher "+Ǥ.CustomName+" needs "+ǻ+"("+ė+")");ϭ(Ǥ,ė);}}}Ȉ=Math.Round(100*(ȉ/Ȋ));}void ǥ(ơ I){if(I==ơ.NoChange)
return;foreach(IMyTerminalBlock Ǥ in ε){if(Ǥ!=null&Ǥ.IsFunctional){if(I==ơ.Off){(Ǥ as IMyConveyorSorter).Enabled=false;}else{(
Ǥ as IMyConveyorSorter).Enabled=true;if(ʻ){Ǥ.SetValue("WC_FocusFire",true);Ǥ.SetValue("WC_Grids",true);Ǥ.SetValue(
"WC_LargeGrid",true);Ǥ.SetValue("WC_SmallGrid",false);Ǥ.SetValue("WC_FocusFire",true);Ǥ.SetValue("WC_SubSystems",true);ʪ(Ǥ);}}}}}Ǣ ǣ;
class Ǣ{private Action<ICollection<MyDefinitionId>>ǡ;private Action<ICollection<MyDefinitionId>>Ǡ;private Action<ICollection<
MyDefinitionId>>ǟ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>Ǟ;private Func<long,MyTuple<bool,
int,int>>ǝ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>ǜ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>Ǜ;private Func<long,int,
MyDetectedEntityInfo>ǚ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ǚ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>ǘ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>Ǧ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>Ǩ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>ǹ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>Ǻ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ǹ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>Ƿ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>Ƕ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǵ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>Ǵ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ǳ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǲ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>Ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǰ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>ǯ;private Func<MyDefinitionId,float>Ǯ;private Func<long,bool>ǭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>Ǭ;private Func<long,float>ǫ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ǫ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>ǩ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>Ȓ;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>ȵ;private Func<long,float>ȳ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ȳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ȱ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȱ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ȯ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>Ȯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>ȭ;public bool Ȭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȫ){var Ȫ=ȫ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(ȫ);if(Ȫ==null)throw new Exception("WcPbAPI failed to activate");return ȩ(Ȫ);}public bool ȩ
(IReadOnlyDictionary<string,Delegate>Ȧ){if(Ȧ==null)return false;Ȩ(Ȧ,"GetCoreWeapons",ref ǡ);Ȩ(Ȧ,"GetCoreStaticLaunchers",
ref Ǡ);Ȩ(Ȧ,"GetCoreTurrets",ref ǟ);Ȩ(Ȧ,"GetBlockWeaponMap",ref Ǟ);Ȩ(Ȧ,"GetProjectilesLockedOn",ref ǝ);Ȩ(Ȧ,
"GetSortedThreats",ref ǜ);Ȩ(Ȧ,"GetObstructions",ref Ǜ);Ȩ(Ȧ,"GetAiFocus",ref ǚ);Ȩ(Ȧ,"SetAiFocus",ref Ǚ);Ȩ(Ȧ,"GetWeaponTarget",ref ǘ);Ȩ(Ȧ,
"SetWeaponTarget",ref Ǧ);Ȩ(Ȧ,"FireWeaponOnce",ref Ǩ);Ȩ(Ȧ,"ToggleWeaponFire",ref ǹ);Ȩ(Ȧ,"IsWeaponReadyToFire",ref Ǻ);Ȩ(Ȧ,
"GetMaxWeaponRange",ref Ǹ);Ȩ(Ȧ,"GetTurretTargetTypes",ref Ƿ);Ȩ(Ȧ,"SetTurretTargetTypes",ref Ƕ);Ȩ(Ȧ,"SetBlockTrackingRange",ref ǵ);Ȩ(Ȧ,
"IsTargetAligned",ref Ǵ);Ȩ(Ȧ,"IsTargetAlignedExtended",ref ǳ);Ȩ(Ȧ,"CanShootTarget",ref ǲ);Ȩ(Ȧ,"GetPredictedTargetPosition",ref Ǳ);Ȩ(Ȧ,
"GetHeatLevel",ref ǰ);Ȩ(Ȧ,"GetCurrentPower",ref ǯ);Ȩ(Ȧ,"GetMaxPower",ref Ǯ);Ȩ(Ȧ,"HasGridAi",ref ǭ);Ȩ(Ȧ,"HasCoreWeapon",ref Ǭ);Ȩ(Ȧ,
"GetOptimalDps",ref ǫ);Ȩ(Ȧ,"GetActiveAmmo",ref Ǫ);Ȩ(Ȧ,"SetActiveAmmo",ref ǧ);Ȩ(Ȧ,"MonitorProjectile",ref ǩ);Ȩ(Ȧ,"UnMonitorProjectile",
ref Ȓ);Ȩ(Ȧ,"GetProjectileState",ref ȵ);Ȩ(Ȧ,"GetConstructEffectiveDps",ref ȳ);Ȩ(Ȧ,"GetPlayerController",ref Ȳ);Ȩ(Ȧ,
"GetWeaponAzimuthMatrix",ref ȱ);Ȩ(Ȧ,"GetWeaponElevationMatrix",ref Ȱ);Ȩ(Ȧ,"IsTargetValid",ref ȯ);Ȩ(Ȧ,"GetWeaponScope",ref Ȯ);Ȩ(Ȧ,"IsInRange",ref
ȭ);return true;}private void Ȩ<ȧ>(IReadOnlyDictionary<string,Delegate>Ȧ,string ȴ,ref ȧ ȥ)where ȧ:class{if(Ȧ==null){ȥ=null
;return;}Delegate ȶ;if(!Ȧ.TryGetValue(ȴ,out ȶ))throw new Exception(
$"{GetType().Name} :: Couldn't find {ȴ} delegate of type {typeof(ȧ)}");ȥ=ȶ as ȧ;if(ȥ==null)throw new Exception(
$"{GetType().Name} :: Delegate {ȴ} is not type {typeof(ȧ)}, instead it's: {ȶ.GetType()}");}public void Ɂ(ICollection<MyDefinitionId>ȝ)=>ǡ?.Invoke(ȝ);public void ɀ(ICollection<MyDefinitionId>ȝ)=>Ǡ?.Invoke(ȝ);
public void ȿ(ICollection<MyDefinitionId>ȝ)=>ǟ?.Invoke(ȝ);public bool Ⱦ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ƚ,IDictionary<
string,int>ȝ)=>Ǟ?.Invoke(Ƚ,ȝ)??false;public MyTuple<bool,int,int>ȼ(long Ⱥ)=>ǝ?.Invoke(Ⱥ)??new MyTuple<bool,int,int>();public
void ȹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ț,IDictionary<MyDetectedEntityInfo,float>ȝ)=>ǜ?.Invoke(ț,ȝ);public void ȸ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ț,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>ȝ)=>Ǜ?.Invoke(ț,ȝ);public
MyDetectedEntityInfo?ȷ(long Ȥ,int Ț=0)=>ǚ?.Invoke(Ȥ,Ț);public bool ȓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ț,long ȗ,int Ț=0)=>Ǚ?.Invoke(ț,ȗ
,Ț)??false;public MyDetectedEntityInfo?ș(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ=0)=>ǘ?.Invoke(Ɨ,ƕ);public void Ș(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,long ȗ,int ƕ=0)=>Ǧ?.Invoke(Ɨ,ȗ,ƕ);public void Ȗ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Ɨ,bool ȕ=true,int ƕ=0)=>Ǩ?.Invoke(Ɨ,ȕ,ƕ);public void Ȕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,bool Ȝ,bool ȕ,int ƕ=0)=>ǹ
?.Invoke(Ɨ,Ȝ,ȕ,ƕ);public bool ȣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ=0,bool Ȣ=true,bool ȡ=false)=>Ǻ?.Invoke(Ɨ,ƕ
,Ȣ,ȡ)??false;public float Ƞ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ)=>Ǹ?.Invoke(Ɨ,ƕ)??0f;public bool ȟ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ɨ,IList<string>ȝ,int ƕ=0)=>Ƿ?.Invoke(Ɨ,ȝ,ƕ)??false;public void Ȟ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɨ,IList<string>ȝ,int ƕ=0)=>Ƕ?.Invoke(Ɨ,ȝ,ƕ);public void Ǘ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,float Ơ)=>ǵ?.Invoke(
Ɨ,Ơ);public bool Ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,long Ư,int ƕ)=>Ǵ?.Invoke(Ɨ,Ư,ƕ)??false;public MyTuple<bool,
Vector3D?>Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,long Ư,int ƕ)=>ǳ?.Invoke(Ɨ,Ư,ƕ)??new MyTuple<bool,Vector3D?>();public bool
Ʊ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,long Ư,int ƕ)=>ǲ?.Invoke(Ɨ,Ư,ƕ)??false;public Vector3D?ư(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Ɨ,long Ư,int ƕ)=>Ǳ?.Invoke(Ɨ,Ư,ƕ)??null;public float ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ)=>ǰ?.
Invoke(Ɨ)??0f;public float ƽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ)=>ǯ?.Invoke(Ɨ)??0f;public float Ƽ(MyDefinitionId ƻ)=>Ǯ?.
Invoke(ƻ)??0f;public bool ƺ(long ƚ)=>ǭ?.Invoke(ƚ)??false;public bool ƹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ)=>Ǭ?.Invoke(Ɨ)
??false;public float Ƹ(long ƚ)=>ǫ?.Invoke(ƚ)??0f;public string Ʒ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ)=>Ǫ?.
Invoke(Ɨ,ƕ)??null;public void ƶ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ,string Ƶ)=>ǧ?.Invoke(Ɨ,ƕ,Ƶ);public void Ʈ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ,Action<long,int,ulong,long,Vector3D,bool>ƞ)=>ǩ?.Invoke(Ɨ,ƕ,ƞ);public void Ɵ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ,Action<long,int,ulong,long,Vector3D,bool>ƞ)=>Ȓ?.Invoke(Ɨ,ƕ,ƞ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ɲ(ulong Ɯ)=>ȵ?.Invoke(Ɯ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ƛ(long ƚ)=>ȳ?.Invoke(ƚ)??0f;public long ƙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ)=>Ȳ?.Invoke(Ɨ)??-1;public
Matrix Ƙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ)=>ȱ?.Invoke(Ɨ,ƕ)??Matrix.Zero;public Matrix Ɩ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɨ,int ƕ)=>Ȱ?.Invoke(Ɨ,ƕ)??Matrix.Zero;public bool ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,long Ƭ,bool ƫ,bool ƪ)=>ȯ?.
Invoke(Ɨ,Ƭ,ƫ,ƪ)??false;public MyTuple<Vector3D,Vector3D>Ʃ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɨ,int ƕ)=>Ȯ?.Invoke(Ɨ,ƕ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>ƨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ƨ)=>ȭ?.Invoke(Ƨ)??new MyTuple<
bool,bool>();}int Ʀ=0;double ƥ=0;double Ƥ=0;void ƣ(){ƥ=0;foreach(IMyTerminalBlock Ƣ in Ϊ){if(Ƣ!=null&&Ƣ.IsFunctional)ƥ++;}Ƥ=
Math.Round(100*(ƥ/Ʀ));}enum ơ{
    Off, On, NoChange
    }enum ǂ{
    Off, On, NoChange, OnNoColourChange
    }enum Ǔ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum ǒ{
    Off, HoldFire, OpenFire, NoChange
    }enum ǔ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum ǖ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum Ǖ{
    On, Off, OnMax, NoChange
    }enum Ǒ{
    Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
    }enum ǀ{
    Abort, NoChange
    }enum ƿ{
    Off, On, FillWhenLow, KeepFull,
    }enum ƾ{
    Closed, Open, NoChange
    }
}sealed class ǁ{public double ǃ{get;private set;}private double Ǐ{get{double ǐ=Ǉ[0];for(int ĝ=1;ĝ<ǉ;ĝ++){ǐ+=Ǉ[ĝ];}return(
ǐ/ǉ);}}public double ǎ{get{double Ǎ=Ǉ[0];for(int ĝ=1;ĝ<ǉ;ĝ++){if(Ǉ[ĝ]>Ǎ){Ǎ=Ǉ[ĝ];}}return Ǎ;}}public double ǌ{get;private
set;}public double ǋ{get{double Ǌ=Ǉ[0];for(int ĝ=1;ĝ<ǉ;ĝ++){if(Ǉ[ĝ]<Ǌ){Ǌ=Ǉ[ĝ];}}return Ǌ;}}public int ǉ{get;}private double
ǈ;private IMyGridProgramRuntimeInfo ǅ;private double[]Ǉ;private int ǆ=0;public ǁ(IMyGridProgramRuntimeInfo ǅ,int ŋ=300){
this.ǅ=ǅ;this.ǌ=ǅ.LastRunTimeMs;this.ǉ=MathHelper.Clamp(ŋ,1,int.MaxValue);this.ǈ=1.0/ǉ;this.Ǉ=new double[ŋ];this.Ǉ[ǆ]=ǅ.
LastRunTimeMs;this.ǆ++;}public void Ǆ(){ǃ-=Ǉ[ǆ]*ǈ;ǃ+=ǅ.LastRunTimeMs*ǈ;Ǉ[ǆ]=ǅ.LastRunTimeMs;if(ǅ.LastRunTimeMs>ǌ){ǌ=ǅ.LastRunTimeMs;}
ǆ++;if(ǆ>=ǉ){ǆ=0;ǃ=Ǐ;ǌ=ǅ.LastRunTimeMs;}}