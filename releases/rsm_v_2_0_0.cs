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

string Version = "2.0.0 (2024-08-03)";
ǃ Λ;int Κ=0;int Ι=0;int Θ=0;int Η;int Ζ=0;bool Ε=true;bool Δ=true;bool Γ=false;bool Β=false;bool Α=false;bool ΐ=false;
bool Ώ=false;bool Ύ=false;bool Μ=false;string Ό="";int Ν=0;int έ=0;double Ϋ;float Ϊ;string Ω;string Ψ;string Χ;bool Φ=false;
int Υ=0;int ά=0;bool Τ;bool Ρ;bool Π;Program(){Echo("Welcome to RSM\nV "+Version);Ή();Η=ʒ;Ω=Me.GetOwnerFactionTag();Λ=new ǃ
(Runtime);Ђ();ʈ.Add(0.5);ʈ.Add(0.25);ʈ.Add(0.1);ʈ.Add(0.05);ł();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo(
"Took "+Ή());}void Main(string p,UpdateType Ο){if(Ο==UpdateType.Update100)ˏ();else Ξ(p);}void Ξ(string p){if(ʅ)Echo(
"Processing command '"+p+"'...");if(Δ){ˑ(p,"RSM is still booting");return;}if(Γ){ˑ(p,"RSM is still initialising");return;}if(p==""){ˑ(p,
"the argument was blank");return;}string[]Ί=p.Split(':');if(Ί.Length<2){ˑ(p,"the argument wasn't recognised");return;}if(Ί[0].ToLower()!="comms"
)Ί[1]=Ί[1].Replace(" ",string.Empty);switch(Ί[0].ToLower()){case"init":bool ˬ=true,ˉ=true,ˣ=true;if(Ί.Length>2){foreach(
string ˢ in Ί){if(ˢ.ToLower()=="nonames")ˬ=false;else if(ˢ.ToLower()=="nosubs")ˉ=false;else if(ˢ.ToLower()=="noinv")ˣ=false;}}
Ѥ(Ί[1],ˬ,ˉ,ˣ);return;case"stance":Ú(Ί[1]);return;case"hudlcd":string ˡ="";if(Ί.Length>2)ˡ=Ί[2];Ƃ(Ί[1],ˡ);return;case
"doors":string ˠ="";if(Ί.Length>2)ˠ=Ί[2];ҧ(Ί[1],ˠ);return;case"comms":Ͷ(Ί[1]);return;case"printblockids":ɗ();return;case
"printblockprops":ɓ(Ί[1]);return;case"spawn":if(Ί[1].ToLower()=="open"){Ώ=true;Η=ʒ;}else{Ώ=false;Η=ʒ;}return;case"projectors":if(Ί[1].
ToLower()=="save"){foreach(IMyProjector O in Ϥ)N(O);а.Add(new ј("Projector positions saved",
"Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector O in Ϥ)l(O);а.Add(new ј("Projector positions loaded",
"Projector positions were loaded from custom data.",2));return;}default:ˑ(p,"the argument wasn't recognised");return;}}void ˑ(string p,string ː){а.Add(new ј(
"COMMAND FAILED!","Command '"+p+"' was ignored because "+ː,3));}void ˏ(){if(ʄ)Ή();if(Ι<ʃ){Ι++;return;}Ι=0;if(Ε){Echo(
"Parsing custom data...");ѭ();Ε=false;return;}else if(Γ){В();if(ʅ)Echo("Updating "+α.Count+" RSM Lcds");Ļ();}ˤ();Υ=Runtime.
CurrentInstructionCount;if(Υ>ά)ά=Runtime.CurrentInstructionCount;if(č.Đ==Ƣ.On){Β=true;Α=true;}else if(č.Đ==Ƣ.Off){Β=true;}if(Η>=ʒ){Η=0;ˋ();
return;}Η++;ˎ();ˍ();if(ʄ)Echo("Took "+Ή());if(ʅ)Echo("Updating "+α.Count+" RSM Lcds");Ļ();if(ʄ)Echo("Took "+Ή());}void ˎ(){ˊ()
;switch(Κ){case 0:if(ʅ)Echo("Refreshing "+(μ.Count+λ.Count)+" kinetics...");W();if(ʄ)Echo("Took "+Ή());if(Δ)break;else
goto case 1;case 1:if(ʅ)Echo("Refreshing "+ϣ.Count+" reactors & "+ϭ.Count+" batteries...");Æ(č.ā);if(ʄ)Echo("Took "+Ή());if(
Δ)break;else goto case 2;case 2:if(ʅ)Echo("Refreshing "+ι.Count+" epsteins...");Ɣ();if(ʄ)Echo("Took "+Ή());if(Δ)break;
else goto case 3;case 3:if(ʅ)Echo("Refreshing "+ί.Count+" lidars...");Ū(Α,Β);if(ʄ)Echo("Took "+Ή());if(ʅ)Echo(
"Refreshing pb servers...");º();if(ʄ)Echo("Took "+Ή());if(Δ)break;else goto case 4;case 4:if(ʅ)Echo("Refreshing "+ύ.Count+" doors...");ӆ();if(ʄ)
Echo("Took "+Ή());if(ʅ)Echo("Refreshing "+ό.Count+" airlocks...");Ӎ();if(ʄ)Echo("Took "+Ή());break;default:if(ʅ)Echo(
"Booting complete");Δ=false;Κ=0;return;}if(Δ)Κ++;}void ˍ(){switch(Θ){case 0:if(ʅ)Echo("Clearing temp inventories...");Ё();if(ʄ)Echo(
"Took "+Ή());if(ʅ)Echo("Refreshing "+κ.Count+" torpedo launchers...");ǧ();if(ʄ)Echo("Took "+Ή());if(ʅ)Echo(
"Refreshing items...");Ѐ();if(ʄ)Echo("Took "+Ή());break;case 1:if(ʅ)Echo("Running autoload...");Ͳ();if(ʄ)Echo("Took "+Ή());break;case 2:if(ʅ)
Echo("Refreshing "+Ϡ.Count+" H2 tanks...");Ò();if(ʄ)Echo("Took "+Ή());if(ʅ)Echo("Refreshing refuel status...");ҳ();if(ΐ){if(
ʅ)Echo("Fuel low, filling extractors...");Ҳ();if(ʄ)Echo("Took "+Ή());return;}else{ˌ();if(ʄ)Echo("Took "+Ή());}Θ=0;return;
}Θ++;}void ˌ(){if(ʅ)Echo("Refreshing "+θ.Count+" rcs...");ȑ();if(ʅ)Echo("Refreshing "+ξ.Count+" Pdcs & "+ν.Count+
" defensive Pdcs...");Í();if(ʅ)Echo("Refreshing "+ϥ.Count+" gyros...");Ҭ(Α,Β);if(ʅ)Echo("Refreshing "+ϟ.Count+" O2 tanks...");é();if(ʅ)Echo(
"Refreshing "+Ϯ.Count+" antennas...");ͷ();if(ʅ)Echo("Refreshing "+ϫ.Count+" cargos...");ʯ();if(ʅ)Echo("Refreshing "+ϒ.Count+
" vents...");ű(Α,Β);if(ʅ)Echo("Refreshing "+Ϗ.Count+" auxiliary blocks...");ϔ();if(ʅ)Echo("Refreshing "+π.Count+" welders...");Ƥ();
if(ʅ)Echo("Refreshing "+γ.Count+" lcds...");Ƈ();if(ʅ)Echo("Refreshing "+ϡ.Count+" lcds...");µ();if(Β){if(ʅ)Echo(
"Refreshing "+Ϫ.Count+" connectors...");ů(Α);if(ʅ)Echo("Refreshing "+Ϭ.Count+" cameras...");ŭ(Α);if(ʅ)Echo("Refreshing "+Ϣ.Count+
" sensors...");ħ(Α);}}void ˋ(){if(ʅ)Echo("Clearing block lists...");ɰ();if(ʄ)Echo("Took "+Ή());if(ʅ)Echo("Refreshing block lists...")
;GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,ϊ);if(ʄ)Echo("Took "+Ή());if(ʅ)Echo(
"Setting KeepFull threshold");ҵ();if(ϯ==null){if(ϩ.Count>0)ϯ=ϩ[0];else а.Add(new ј("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ʅ)Echo("Finished block refresh.");if(ʄ)Echo("Took "+Ή());}void ˊ(){try{ǣ=new Ǣ();ǣ.Ȭ(Me);}catch(Exception ex){ǣ
=null;а.Add(new ј("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ˤ(){string ˮ="REEDIT SHIP MANAGEMENT \n\n";if(Δ)ˮ+="Booting, please wait ("+Κ+"/5)...\n\n";ˮ+=
"|- V "+Version+"\n|- Ship Name: "+ʔ+"\n|- Stance: "+Ď+"\n|- Step: "+Η+"/"+ʒ+" ("+Θ+")";if(ʄ){Λ.ǅ();ˮ+="\n|- Runtime Av/Tick: "
+(Math.Round(Λ.Ǆ,2)/100)+" ms"+"\n|- Runtime Max: "+Math.Round(Λ.Ǐ,4)+" ms"+"\n|- Instructions: "+Υ+" ("+ά+")";}Echo(ˮ+
"\n");}long Έ=0;string Ή(){long Ά=DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;if(Έ==0){Έ=Ά;return"0 ms";}long ͽ=Ά-Έ;Έ=Ά;
return ͽ+" ms";}bool ͼ=false;string ͻ="";double ͺ=0;void ͷ(){ͼ=false;ͺ=0;foreach(IMyRadioAntenna ͳ in Ϯ){if(ͳ!=null&&!ͳ.Closed
&&ͳ.IsFunctional){float Ƶ=ͳ.Radius;if(Ƶ>ͺ)ͺ=Ƶ;if(ͳ.IsBroadcasting&&ͳ.Enabled)ͼ=true;}}}void Ͷ(string ʹ){ͻ=ʹ;foreach(
IMyTerminalBlock ɒ in Ϯ){IMyRadioAntenna ͳ=ɒ as IMyRadioAntenna;if(ͳ!=null)ͳ.HudText=ʹ;}}void Ͳ(){if(!ˀ)return;foreach(var ɯ in ϴ){if(!ɯ
.Ϻ&&!ɯ.Ϲ)continue;if(ʅ)Echo("Checking "+ɯ.ϸ);List<М>ͱ=ɯ.Ͻ.Concat(ɯ.ϼ).ToList();List<М>Σ=new List<М>();List<М>ή=new List<М
>();List<М>ϧ=new List<М>();List<М>ϝ=new List<М>();List<М>ϛ=new List<М>();int Ϛ=0;int ϙ=0;double Ϙ=.97;if(ɯ.ϵ<1)Ϙ=ɯ.ϵ*.97;
foreach(М ϗ in ͱ){if(ϗ==null)continue;if(ϗ.И){ϙ++;Ϛ+=ϗ.Й;if(ϗ.З<Ϙ)ϧ.Add(ϗ);else if(ɯ.ϵ<1&&ϗ.З>ɯ.ϵ*1.03)ϝ.Add(ϗ);if(ϗ.З!=0)ή.Add
(ϗ);}else{ϛ.Add(ϗ);if(ϗ.Й>0){Σ.Add(ϗ);}}}if(ϧ.Count>0){int ϖ=(int)(Ϛ/ϙ);ϧ=ϧ.OrderBy(ķ=>ķ.Й).ToList();if(ɯ.Ͽ>0){if(ʅ)Echo(
"Loading "+ɯ.ϻ.SubtypeId+"...");Σ=Σ.OrderByDescending(ķ=>ķ.Й).ToList();я(Σ,ϧ,ɯ.ϻ,-1,ɯ.ϵ);}else{if(ʅ)Echo("Balancing "+ɯ.ϻ.
SubtypeId+"...");ή=ή.OrderByDescending(ķ=>ķ.Й).ToList();я(ή,ϧ,ɯ.ϻ,ϖ);}}else if(ϝ.Count>0){if(ʅ)Echo("Unloading "+ɯ.ϻ.SubtypeId+
"...");List<М>ϕ=new List<М>();if(Σ.Count>0)ϕ=Σ;else ϕ=ϛ;я(ϝ,ϕ,ɯ.ϻ,-1,1,ɯ.ϵ);}else{if(ʅ)Echo("No loading required "+ɯ.ϻ.
SubtypeId+"...");}}}void ϔ(){έ=0;foreach(IMyTerminalBlock ɒ in Ϗ){if(ɒ==null)continue;if(ɒ.IsWorking)έ++;}}void ϓ(Ƣ J){if(J==Ƣ.
NoChange)return;foreach(IMyTerminalBlock ɒ in Ϗ){if(ɒ==null)continue;try{bool Ϝ=ɒ.BlockDefinition.ToString().Contains("ToolCore"
);if(J==Ƣ.On||Ϝ)ɒ.ApplyAction("OnOff_On");else if(!Ϝ)ɒ.ApplyAction("OnOff_Off");if(Ϝ){ITerminalAction Ɲ=ɒ.
GetActionWithName("ToolCore_Shoot_Action");if(Ɲ!=null){StringBuilder Ϟ=new StringBuilder();Ɲ.WriteValue(ɒ,Ϟ);string ϱ=Ϟ.ToString();if(ʅ)
Echo(ϱ);if(ϱ=="Active"&&J==Ƣ.Off)Ɲ.Apply(ɒ);else if(ϱ=="Inactive"&&J==Ƣ.On)Ɲ.Apply(ɒ);}}}catch{if(ʅ)Echo(
"Failed to set aux block "+ɒ.CustomName);}}}IMyShipController ϯ;List<IMyRadioAntenna>Ϯ=new List<IMyRadioAntenna>();List<IMyBatteryBlock>ϭ=new List
<IMyBatteryBlock>();List<IMyCameraBlock>Ϭ=new List<IMyCameraBlock>();List<IMyCargoContainer>ϫ=new List<IMyCargoContainer>
();List<IMyShipConnector>Ϫ=new List<IMyShipConnector>();List<IMyShipController>ϩ=new List<IMyShipController>();List<
IMyAirtightHangarDoor>ϰ=new List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>Ϩ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ϧ=new
List<IMyTerminalBlock>();List<IMyGyro>ϥ=new List<IMyGyro>();List<IMyProjector>Ϥ=new List<IMyProjector>();List<IMyReactor>ϣ=
new List<IMyReactor>();List<IMySensorBlock>Ϣ=new List<IMySensorBlock>();List<IMyTerminalBlock>ϡ=new List<IMyTerminalBlock>(
);List<IMyGasTank>Ϡ=new List<IMyGasTank>();List<IMyGasTank>ϟ=new List<IMyGasTank>();List<IMyAirVent>ϒ=new List<IMyAirVent
>();List<IMyTerminalBlock>π=new List<IMyTerminalBlock>();List<IMyConveyorSorter>ί=new List<IMyConveyorSorter>();List<
IMyTerminalBlock>ξ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ν=new List<IMyTerminalBlock>();List<IMyTerminalBlock>μ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>λ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>κ=new List<IMyTerminalBlock>();List<
IMyThrust>ι=new List<IMyThrust>();List<IMyThrust>θ=new List<IMyThrust>();List<IMyThrust>η=new List<IMyThrust>();List<IMyThrust>ζ=
new List<IMyThrust>();List<IMyProgrammableBlock>ε=new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>δ=new List<
IMyProgrammableBlock>();List<IMyTextPanel>γ=new List<IMyTextPanel>();List<IMyTextPanel>β=new List<IMyTextPanel>();List<ѡ>α=new List<ѡ>();
List<IMyLightingBlock>ΰ=new List<IMyLightingBlock>();List<IMyLightingBlock>ο=new List<IMyLightingBlock>();List<
IMyLightingBlock>ρ=new List<IMyLightingBlock>();List<IMyLightingBlock>ϐ=new List<IMyLightingBlock>();List<IMyReflectorLight>ϑ=new List<
IMyReflectorLight>();List<IMyTerminalBlock>Ϗ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ώ=new List<IMyTerminalBlock>();List<Қ>ύ=
new List<Қ>();List<Ӏ>ό=new List<Ӏ>();Dictionary<IMyTerminalBlock,string>ϋ=new Dictionary<IMyTerminalBlock,string>();bool ϊ(
IMyTerminalBlock ɋ){try{if(!Me.IsSameConstructAs(ɋ))return false;string ω=ɋ.GetOwnerFactionTag();if(ω!=Ω&&ω!=""){Echo("!"+ω+": "+ɋ.
CustomName);Ν++;return false;}if(ɋ.CustomName.Contains(ʷ))return false;if(!Γ&&ˁ&&!ɋ.CustomName.Contains(ʔ))return false;string ψ=ɋ
.BlockDefinition.ToString();if(ɋ.CustomName.Contains(ʴ)){Ϗ.Add(ɋ);}if(ψ.Contains("MedicalRoom/")){if(Ώ)ɋ.CustomData=Χ;
else ɋ.CustomData=Ψ;ϡ.Add(ɋ);if(Γ)ϋ.Add(ɋ,"Medical Room");return false;}if(ψ.Contains("SurvivalKit/")){if(Ώ)ɋ.CustomData=Χ;
else ɋ.CustomData=Ψ;ϡ.Add(ɋ);if(Γ)ϋ.Add(ɋ,"Survival Kit");return false;}if(ψ==
"MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Γ)ϋ.Add(ɋ,"Refill Station");return false;}var χ=ɋ as IMyTextPanel;if(χ!=null){γ.Add(χ);if(Γ)ϋ.Add(ɋ,"LCD");if(χ.
CustomName.Contains(ʶ)){ѡ φ=new ѡ();φ.ɒ=χ;α.Add(Ɉ(φ));}else if(!ʊ&&χ.CustomName.Contains(ʵ))β.Add(χ);return false;}if(ψ==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɮ(ɋ,"Flak",3);if(ψ=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɮ(ɋ,
"OPA",3);if(ψ=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɮ(ɋ,"Voltaire",3);if(ψ.Contains
("Nariman Dynamics PDC"))return ɮ(ɋ,"Nari",4);if(ψ.Contains("Redfields Ballistics PDC"))return ɮ(ɋ,"Red",4);if(ψ.Contains
("OPA Shotgun PDC"))return ɮ(ɋ,"Shotgun",4);if(ψ=="MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return ɍ
(ɋ,"Apollo");if(ψ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɍ(ɋ,"Tycho");if(ψ==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return ɍ(ɋ,"Zeus");if(ψ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɍ(ɋ,"Tycho");if(ψ.Contains(
"Ares_Class"))return ɍ(ɋ,"Ares");if(ψ.Contains("Artemis_Torpedo_Tube"))return ɍ(ɋ,"Artemis");if(ψ==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return Ɍ(ɋ,"Dawson",11);if(ψ=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return Ɍ(ɋ,"Stiletto",12);if
(ψ=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return Ɍ(ɋ,"Roci",13,true);if(ψ==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return Ɍ(ɋ,"Foehammer",14);if(ψ=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return Ɍ(ɋ,"Farren",15);
if(ψ=="MyObjectBuilder_ConveyorSorter/Zakosetara Heavy Railgun")return Ɍ(ɋ,"Zako",10);if(ψ==
"MyObjectBuilder_ConveyorSorter/Mounted Zakosetara Heavy Railgun")return Ɍ(ɋ,"Zako",10,true,"Fixed");if(ψ.Contains("Kess Hashari Cannon"))return Ɍ(ɋ,"Kess",16,true,"Fixed");if(ψ.
Contains("Coilgun"))return Ɍ(ɋ,"Coilgun",13,false,"");if(ψ.Contains("Glapion"))return Ɍ(ɋ,"Glapion",3,true,"Fixed");var υ=ɋ as
IMyThrust;if(υ!=null){if(ψ.ToUpper().Contains("RCS")){θ.Add(υ);if(Γ)ϋ.Add(ɋ,"RCS");}else if(ψ.Contains("Hydro")){η.Add(υ);if(Γ)ϋ.
Add(ɋ,"Chem");}else if(ψ.Contains("Atmospheric")){ζ.Add(υ);if(Γ)ϋ.Add(ɋ,"Atmo");}else{ι.Add(υ);if(Γ){string Ɏ="";if(ʍ){try{
Ɏ=ɋ.DefinitionDisplayNameText.Split('"')[1];Ɏ=ʏ+Ɏ[0].ToString().ToUpper()+Ɏ.Substring(1).ToLower();}catch{if(ʅ)Echo(
"Failed to get drive type from "+ɋ.DefinitionDisplayNameText);}}ϋ.Add(ɋ,"Epstein"+Ɏ);}}return false;}var τ=ɋ as IMyCargoContainer;if(τ!=null){string σ=ψ
.Split('/')[1];if(σ.Contains("Container")||σ.Contains("Cargo")){ϫ.Add(τ);ϳ(ɋ);if(Γ){double ς=ɋ.GetInventory().MaxVolume.
RawValue;double Ͱ=Math.Round(ς/1265625024,1);if(Ͱ==0)Ͱ=0.1;ϋ.Add(ɋ,"Cargo ["+Ͱ+"]");}return false;}}var ˈ=ɋ as IMyGyro;if(ˈ!=
null){ϥ.Add(ˈ);if(Γ)ϋ.Add(ɋ,"Gyroscope");return false;}var ɑ=ɋ as IMyBatteryBlock;if(ɑ!=null){ϭ.Add(ɑ);if(Γ)ϋ.Add(ɋ,"Power"+
ʏ+"Battery");return false;}var ɫ=ɋ as IMyReflectorLight;if(ɫ!=null){ϑ.Add(ɫ);if(Γ)ϋ.Add(ɋ,"Spotlight");return false;}var
ɪ=ɋ as IMyLightingBlock;if(ɪ!=null){if(ɋ.CustomName.ToUpper().Contains("INTERIOR")){ο.Add(ɪ);if(Γ)ϋ.Add(ɋ,"Light"+ʏ+
"Interior");}else if(ψ.Contains("Kitchen")||ψ.Contains("Aquarium")){ο.Add(ɪ);if(Γ)ϋ.Add(ɋ,"Light"+ʏ+"Interior"+ʏ+ɋ.
DefinitionDisplayNameText);}else if(ɋ.CustomName.Contains(ʓ)){if(ɋ.CustomName.ToUpper().Contains("STARBOARD")){ϐ.Add(ɪ);if(Γ)ϋ.Add(ɋ,"Light"+ʏ+
"Nav"+ʏ+"Starboard");}else{ρ.Add(ɪ);if(Γ)ϋ.Add(ɋ,"Light"+ʏ+"Nav"+ʏ+"Port");}}else{ΰ.Add(ɪ);if(Γ)ϋ.Add(ɋ,"Light"+ʏ+"Exterior")
;}return false;}var ɩ=ɋ as IMyGasTank;if(ɩ!=null){if(ψ.Contains("Hydro")){Ϡ.Add(ɩ);if(Γ)ϋ.Add(ɋ,"Tank"+ʏ+"Hydrogen");}
else{ϟ.Add(ɩ);if(Γ)ϋ.Add(ɋ,"Tank"+ʏ+"Oxygen");}return false;}var ɨ=ɋ as IMyReactor;if(ɨ!=null){ϣ.Add(ɨ);ϳ(ɋ,0);if(Γ){string
ɧ="Lg";if(ψ.Contains("SmallGenerator"))ɧ="Sm";else if(ψ.Contains("MCRN"))ɧ="MCRN";ϋ.Add(ɋ,"Power"+ʏ+"Reactor"+ʏ+ɧ);}
return false;}var ɦ=ɋ as IMyShipController;if(ɦ!=null){ϩ.Add(ɦ);if(ϯ==null&&ɋ.CustomName.Contains("Nav"))ϯ=ɦ;if(ɦ.HasInventory
)ϳ(ɋ);if(Γ&&ψ.Contains("Cockpit/")){if(ψ.Contains("StandingCockpit")||ψ.Contains("Console")){ϋ.Add(ɋ,"Console");return
false;}else if(ψ.Contains("Cockpit")){ϋ.Add(ɋ,"Cockpit");return false;}}}var ɥ=ɋ as IMyDoor;if(ɥ!=null){Қ ɤ=new Қ();ɤ.ɒ=ɥ;if(
ɋ.CustomName.Contains(ʂ)){try{string ɡ=ɋ.CustomName.Split(ʏ)[3];ɤ.ӂ=true;bool ɠ=false;foreach(Ӏ ɣ in ό){if(ɡ==ɣ.ҿ){ɣ.һ.
Add(ɤ);ɠ=true;break;}}if(!ɠ){Ӏ ɟ=new Ӏ();ɟ.ҿ=ɡ;ɟ.һ.Add(ɤ);ό.Add(ɟ);}}catch{if(ʅ)Echo("Error with airlock door name "+ɋ.
CustomName);ύ.Add(ɤ);}}else{ύ.Add(ɤ);}if(Γ)ϋ.Add(ɋ,"Door");return false;}var ɢ=ɋ as IMyAirVent;if(ɢ!=null){ϒ.Add(ɢ);if(ɋ.
CustomName.Contains(ʂ)){try{string ɡ=ɋ.CustomName.Split(ʏ)[3];bool ɠ=false;foreach(Ӏ ɣ in ό){if(ɡ==ɣ.ҿ){ɣ.Һ.Add(ɢ);ɠ=true;break;}}
if(!ɠ){Ӏ ɟ=new Ӏ();ɟ.ҿ=ɡ;ɟ.Һ.Add(ɢ);ό.Add(ɟ);}}catch{if(ʅ)Echo("Error with airlock vent name "+ɋ.CustomName);}}if(Γ)ϋ.Add(
ɋ,"Vent");return false;}var ɭ=ɋ as IMyCameraBlock;if(ɭ!=null){Ϭ.Add(ɭ);if(Γ)ϋ.Add(ɋ,"Camera");return false;}var ʀ=ɋ as
IMyShipConnector;if(ʀ!=null){Ϫ.Add(ʀ);ϳ(ɋ);if(Γ){string ɾ="";if(ψ.Contains("Passageway"))ɾ=ʏ+"Passageway";ϋ.Add(ɋ,"Connector"+ɾ);}return
false;}var ɽ=ɋ as IMyAirtightHangarDoor;if(ɽ!=null){ϰ.Add(ɽ);if(Γ)ϋ.Add(ɋ,"Door"+ʏ+"Hangar");return false;}if(ψ.Contains(
"Lidar")){var ɼ=ɋ as IMyConveyorSorter;if(ɼ!=null){ί.Add(ɼ);if(Γ)ϋ.Add(ɋ,"LiDAR");return false;}}if(ψ==
"MyObjectBuilder_OxygenGenerator/Extractor"){Ϩ.Add(ɋ);if(Γ)ϋ.Add(ɋ,"Extractor");return false;}if(ψ=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){Ϧ.Add(ɋ);if(Γ
)ϋ.Add(ɋ,"Extractor");return false;}var ɻ=ɋ as IMyRadioAntenna;if(ɻ!=null){Ϯ.Add(ɻ);if(Γ)ϋ.Add(ɋ,"Antenna");return false;
}var ɺ=ɋ as IMyProgrammableBlock;if(ɺ!=null){if(Γ)ϋ.Add(ɋ,"PB Server");if(ɺ==Me)return false;try{if(ɋ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))ε.Add(ɺ);else if(ɋ.CustomData.Contains("NavConfig"))δ.Add(ɺ);return false;}catch{}}var
ɹ=ɋ as IMyProjector;if(ɹ!=null){Ϥ.Add(ɹ);if(Γ)ϋ.Add(ɋ,"Projectors");return false;}var ɸ=ɋ as IMySensorBlock;if(ɸ!=null){Ϣ
.Add(ɸ);if(Γ)ϋ.Add(ɋ,"Sensor");return false;}var ɿ=ɋ as IMyCollector;if(ɿ!=null){ϳ(ɋ);if(Γ)ϋ.Add(ɋ,"Collector");return
false;}if(ψ.Contains("Welder")){π.Add(ɋ);if(Γ)ϋ.Add(ɋ,"Tool"+ʏ+"Welder");return false;}if(Γ){if(ψ.Contains("LandingGear/")){
if(ψ.Contains("Clamp"))ϋ.Add(ɋ,"Clamp");else if(ψ.Contains("Magnetic"))ϋ.Add(ɋ,"Mag Lock");else ϋ.Add(ɋ,"Gear");return
false;}if(ψ.Contains("Drill")){ϋ.Add(ɋ,"Tool"+ʏ+"Drill");return false;}if(ψ.Contains("Grinder")){ϋ.Add(ɋ,"Tool"+ʏ+"Grinder");
return false;}if(ψ.Contains("Solar")){ϋ.Add(ɋ,"Solar");return false;}if(ψ.Contains("ButtonPanel")){ϋ.Add(ɋ,"Button Panel");
return false;}var ɷ=ɋ as IMyConveyorSorter;if(ɷ!=null){ϋ.Add(ɋ,"Sorter");return false;}var ɵ=ɋ as IMyMotorSuspension;if(ɵ!=
null){ϋ.Add(ɋ,"Suspension");return false;}var ɴ=ɋ as IMyGravityGenerator;if(ɴ!=null){ϋ.Add(ɋ,"Grav Gen");return false;}var ɳ
=ɋ as IMyTimerBlock;if(ɳ!=null){ϋ.Add(ɋ,"Timer");return false;}var ɲ=ɋ as IMyGasGenerator;if(ɲ!=null){ϋ.Add(ɋ,"H2 Engine"
);return false;}var ɱ=ɋ as IMyBeacon;if(ɱ!=null){ϋ.Add(ɋ,"Beacon");return false;}ϋ.Add(ɋ,ɋ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ʅ){Echo("Failed to sort "+ɋ.CustomName+"\nAdded "+ϋ.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɰ(){ϯ=null;Ϯ.Clear();ϭ.Clear();Ϭ.Clear();ϫ.Clear();Ϫ.Clear();ϩ.Clear();ύ.Clear();ό.Clear();ϰ.Clear();Ϩ.
Clear();Ϧ.Clear();ϥ.Clear();Ϥ.Clear();ϣ.Clear();Ϣ.Clear();Ϡ.Clear();ϟ.Clear();ϒ.Clear();π.Clear();ί.Clear();ξ.Clear();ν.Clear
();μ.Clear();λ.Clear();κ.Clear();ι.Clear();θ.Clear();η.Clear();ζ.Clear();ε.Clear();δ.Clear();γ.Clear();α.Clear();β.Clear(
);ΰ.Clear();ο.Clear();ρ.Clear();ϐ.Clear();ϑ.Clear();Ϗ.Clear();foreach(var ɯ in ϴ)ɯ.Ͻ.Clear();if(Γ)ϋ.Clear();}bool ɮ(
IMyTerminalBlock ɋ,string ŕ,int Ɇ){if(ɋ.CustomName.Contains(ʳ))ν.Add(ɋ);else ξ.Add(ɋ);ϳ(ɋ,Ɇ);if(Γ){string Ɏ="";if(ʎ)Ɏ=ʏ+ŕ;ϋ.Add(ɋ,"PDC"+
Ɏ);}return false;}bool ɍ(IMyTerminalBlock ɋ,string ŕ){κ.Add(ɋ);if(Γ){string ɉ="";if(ʎ)ɉ=ʏ+ŕ;ϋ.Add(ɋ,"Torpedo"+ɉ);}return
false;}bool Ɍ(IMyTerminalBlock ɋ,string ŕ,int Ɇ,bool Ā=false,string Ɋ="Rail"){if(Ā)λ.Add(ɋ);else μ.Add(ɋ);ϳ(ɋ,Ɇ);if(Γ){string
ɉ="";if(Ɋ!="")Ɋ=ʏ+Ɋ;if(ʎ)ɉ=ʏ+ŕ;ϋ.Add(ɋ,"Kinetic"+Ɋ+ɉ);}return false;}ѡ Ɉ(ѡ ĩ,string ɇ=""){bool ɏ=ɇ=="",ɐ=!ɏ;string ɝ=ĩ.ɒ.
CustomData,ɞ="RSM.LCD";string[]ɜ=null;MyIni ɛ=new MyIni();MyIniParseResult Ɗ;if(!ɏ||ɝ=="")ɐ=true;else{try{if(ɝ.Substring(0,12)==
"Show Header="){ɜ=ɝ.Split('\n');foreach(string ɚ in ɜ){if(ɚ.Contains("hud")){if(ɚ.Contains("lcd")){ɇ=ɚ;break;}}else if(ɚ.Contains("=")
){string[]ə=ɚ.Split('=');if(ə[0]=="Show Tanks & Batteries")ĩ.ѝ=bool.Parse(ə[1]);else if(ə[0]=="Show header"||ə[0]==
"Show Header")ĩ.Ѡ=bool.Parse(ə[1]);else if(ə[0]=="Show Header Overlay")ĩ.џ=bool.Parse(ə[1]);else if(ə[0]=="Show Warnings")ĩ.ў=bool.
Parse(ə[1]);else if(ə[0]=="Show Inventory")ĩ.ќ=bool.Parse(ə[1]);else if(ə[0]=="Show Thrust")ĩ.Ѣ=bool.Parse(ə[1]);else if(ə[0]
=="Show Subsystem Integrity")ĩ.ћ=bool.Parse(ə[1]);else if(ə[0]=="Show Advanced Thrust")ĩ.љ=bool.Parse(ə[1]);}}}else if(!ɛ.
TryParse(ɝ,out Ɗ)){ɐ=true;}else{ĩ.Ѡ=ɛ.Get(ɞ,"ShowHeader").ToBoolean(ĩ.Ѡ);ĩ.џ=ɛ.Get(ɞ,"ShowHeaderOverlay").ToBoolean(ĩ.џ);ĩ.ў=ɛ.
Get(ɞ,"ShowWarnings").ToBoolean(ĩ.ў);ĩ.ѝ=ɛ.Get(ɞ,"ShowPowerAndTanks").ToBoolean(ĩ.ѝ);ĩ.ќ=ɛ.Get(ɞ,"ShowInventory").ToBoolean
(ĩ.ќ);ĩ.Ѣ=ɛ.Get(ɞ,"ShowThrust").ToBoolean(ĩ.Ѣ);ĩ.ћ=ɛ.Get(ɞ,"ShowIntegrity").ToBoolean(ĩ.ћ);ĩ.љ=ɛ.Get(ɞ,
"ShowAdvancedThrust").ToBoolean(ĩ.љ);}}catch(Exception ex){if(ʅ)Echo("LCD parsing error, resetting\n"+ex.Message);ɐ=true;}}if(ĩ.Ѡ&&ĩ.џ){ĩ.Ѡ=
false;ɐ=true;}if(ɐ){if(ɜ==null)ɜ=ɝ.Split('\n');ɛ.Set(ɞ,"ShowHeader",ĩ.Ѡ);ɛ.Set(ɞ,"ShowHeaderOverlay",ĩ.џ);ɛ.Set(ɞ,
"ShowWarnings",ĩ.ў);ɛ.Set(ɞ,"ShowPowerAndTanks",ĩ.ѝ);ɛ.Set(ɞ,"ShowInventory",ĩ.ќ);ɛ.Set(ɞ,"ShowThrust",ĩ.Ѣ);ɛ.Set(ɞ,"ShowIntegrity",ĩ.
ћ);ɛ.Set(ɞ,"ShowAdvancedThrust",ĩ.љ);ɛ.Set(ɞ,"Hud",ɇ);ĩ.ɒ.CustomData=ɛ.ToString();if(ɏ)а.Add(new ј("LCD CONFIG ERROR!!",
"Failed to parse LCD config for "+ĩ.ɒ.CustomName+"!\nLCD config was reset!",3));}return ĩ;}void ɘ(IMyTerminalBlock ɒ,bool Ȭ){ɒ.GetActionWithName(
"ToolCore_Shoot_Action").Apply(ɒ);(ɒ as IMyConveyorSorter).GetActionWithName("ToolCore_Shoot_Action").Apply(ɒ);}void ɗ(){List<IMyTerminalBlock>
ɖ=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(ɖ);string ɕ="";foreach(
IMyTerminalBlock ɔ in ɖ){ɕ+=ɔ.BlockDefinition+"\n";}if(Ϯ.Count>0&&Ϯ[0]!=null){Ϯ[0].CustomData=ɕ;}}void ɓ(string ȸ){IMyTerminalBlock ɒ=
GridTerminalSystem.GetBlockWithName(ȸ);List<ITerminalAction>ɶ=new List<ITerminalAction>();ɒ.GetActions(ɶ);List<ITerminalProperty>ʁ=new
List<ITerminalProperty>();ɒ.GetProperties(ʁ);string ʺ=ɒ.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction ʰ in ɶ){ʺ+=ʰ.
Id+" "+ʰ.Name+"\n";}ʺ+="\n\n**Properties**\n\n";foreach(ITerminalProperty ʮ in ʁ){ʺ+=ʮ.Id+" "+ʮ.TypeName+"\n";}if(Ϯ.Count>
0&&Ϯ[0]!=null)Ϯ[0].CustomData=ʺ;ɒ.CustomData=ʺ;}void ʭ(IMyTerminalBlock ƨ){bool ʫ=ƨ.GetValue<bool>("WC_Repel");if(!ʫ)ƨ.
ApplyAction("WC_RepelMode");}void ʬ(IMyTerminalBlock ƨ){bool ʫ=ƨ.GetValue<bool>("WC_Repel");if(ʫ)ƨ.ApplyAction("WC_RepelMode");}
void ʪ(IMyTerminalBlock ƨ){try{if(ǣ.Ɨ(ƨ,0)==VRageMath.Matrix.Zero)return;ƨ.SetValue<Int64>("WC_Shoot Mode",3);if(ʅ)Echo(
"Shoot mode = "+ƨ.GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to manual on "+ƨ.CustomName);}}void ʩ(
IMyTerminalBlock ƨ){try{if(ǣ.Ɨ(ƨ,0)==VRageMath.Matrix.Zero)return;ƨ.SetValue<Int64>("WC_Shoot Mode",0);if(ʅ)Echo("Shoot mode = "+ƨ.
GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to auto on "+ƨ.CustomName);}}void ʨ(){if(ϯ!=null){try{Ϋ=ϯ
.GetShipSpeed();Ϊ=ϯ.CalculateShipMass().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo
(exxie.Message);}}}double ʧ=0;double ʦ=0;double ʥ=0;void ʯ(){ʦ=0;foreach(IMyCargoContainer ʤ in ϫ){if(ʤ!=null&&!ʤ.Closed
&&ʤ.IsFunctional){try{ʦ+=ʤ.GetInventory().MaxVolume.RawValue;}catch(Exception ex){if(ʅ)Echo("Cargo integrity error!\n"+ex.
Message);throw ex;}}}ʥ=Math.Round(100*(ʦ/ʧ));}void ʱ(){ʧ=0;foreach(IMyCargoContainer ʤ in ϫ){if(ʤ!=null)ʧ+=ʤ.GetInventory().
MaxVolume.RawValue;}}MyIni ˆ=new MyIni();bool ˁ=false;bool ˀ=true;bool ʿ=true;bool ʾ=true;bool ʽ=true;bool ʼ=false;string ˇ="";
bool ʻ=true;int ʹ=3;int ʸ=6;string ʷ="[I]";string ʶ="[RSM]";string ʵ="[CS]";string ʴ="Autorepair";string ʳ="Repel";string ʲ=
"Min";string ʣ="Docking";string ʓ="Nav";string ʂ="Airlock";string ʑ="[EFC]";string ʐ="[NavOS]";char ʏ='.';bool ʎ=true;bool ʍ=
true;List<string>ʌ=new List<string>();bool ʋ=false;bool ʊ=false;bool ʉ=true;List<double>ʈ=new List<double>();bool ʇ=false;
double ʆ=0.5;bool ʅ=false;bool ʄ=false;int ʃ=0;int ʒ=100;string ʔ="";bool ʢ(){string ɝ=Me.CustomData;string ɞ="";bool ʡ=true;
MyIniParseResult Ɗ;if(!ˆ.TryParse(ɝ,out Ɗ)){string[]ʠ=ɝ.Split('\n');if(ʠ[1]=="Reedit Ship Management"){Echo("Legacy config detected...")
;ҙ(ɝ);return false;}else{Echo("Could not parse custom data!\n"+Ɗ.ToString());return false;}}try{ɞ="RSM.Main";Echo(ɞ);ˁ=ˆ.
Get(ɞ,"RequireShipName").ToBoolean(ˁ);ˀ=ˆ.Get(ɞ,"EnableAutoload").ToBoolean(ˀ);ʿ=ˆ.Get(ɞ,"AutoloadReactors").ToBoolean(ʿ);ʾ
=ˆ.Get(ɞ,"AutoConfigWeapons").ToBoolean(ʾ);ʽ=ˆ.Get(ɞ,"SetTurretFireMode").ToBoolean(ʽ);ɞ="RSM.Spawns";Echo(ɞ);ʼ=ˆ.Get(ɞ,
"PrivateSpawns").ToBoolean(ʼ);ˇ=ˆ.Get(ɞ,"FriendlyTags").ToString(ˇ);ɞ="RSM.Doors";Echo(ɞ);ʻ=ˆ.Get(ɞ,"EnableDoorManagement").ToBoolean(ʻ
);ʹ=ˆ.Get(ɞ,"DoorCloseTimer").ToInt32(ʹ);ʹ=ˆ.Get(ɞ,"AirlockDoorDisableTimer").ToInt32(ʹ);ɞ="RSM.Keywords";Echo(ɞ);ʷ=ˆ.Get
(ɞ,"Ignore").ToString(ʷ);ʶ=ˆ.Get(ɞ,"RsmLcds").ToString(ʶ);ʵ=ˆ.Get(ɞ,"ColourSyncLcds").ToString(ʵ);ʴ=ˆ.Get(ɞ,
"AuxiliaryBlocks").ToString(ʴ);ʳ=ˆ.Get(ɞ,"DefensivePdcs").ToString(ʳ);ʲ=ˆ.Get(ɞ,"MinimumThrusters").ToString(ʲ);ʣ=ˆ.Get(ɞ,
"DockingThrusters").ToString(ʣ);ʓ=ˆ.Get(ɞ,"NavLights").ToString(ʓ);ʂ=ˆ.Get(ɞ,"Airlock").ToString(ʂ);ɞ="RSM.InitNaming";Echo(ɞ);string ʟ=ˆ.
Get(ɞ,"NameDelimiter").ToString(ʏ.ToString());int ʞ=0;if(ʟ.Length>1)ʞ=1;ʏ=char.Parse(ʟ.Substring(ʞ,1));ʎ=ˆ.Get(ɞ,
"NameWeaponTypes").ToBoolean(ʎ);ʍ=ˆ.Get(ɞ,"NameDriveTypes").ToBoolean(ʍ);string ʝ=ˆ.Get(ɞ,"BlocksToNumber").ToString("");string[]ʜ=ʝ.
Split(',');ʌ.Clear();foreach(string ȸ in ʜ)if(ȸ!="")ʌ.Add(ȸ);ɞ="RSM.Misc";Echo(ɞ);ʋ=ˆ.Get(ɞ,"DisableLightingControl").
ToBoolean(ʋ);ʊ=ˆ.Get(ɞ,"DisableLcdColourControl").ToBoolean(ʊ);ʉ=ˆ.Get(ɞ,"ShowBasicTelemetry").ToBoolean(ʉ);string ʛ=ˆ.Get(ɞ,
"DecelerationPercentages").ToString("");string[]ʚ=ʛ.Split(',');if(ʚ.Length>1){ʈ.Clear();foreach(string ʙ in ʚ){ʈ.Add(double.Parse(ʙ)/100);}}ʇ=ˆ.
Get(ɞ,"ShowThrustInMetric").ToBoolean(ʇ);ʆ=ˆ.Get(ɞ,"ReactorFillRatio").ToDouble(ʆ);ϴ[0].ϵ=ʆ;ɞ="RSM.Debug";Echo(ɞ);ʅ=ˆ.Get(ɞ
,"VerboseDebugging").ToBoolean(ʅ);ʄ=ˆ.Get(ɞ,"RuntimeProfiling").ToBoolean(ʄ);ʒ=ˆ.Get(ɞ,"BlockRefreshFreq").ToInt32(ʒ);ʃ=ˆ
.Get(ɞ,"StallCount").ToInt32(ʃ);ɞ="RSM.System";Echo(ɞ);ʔ=ˆ.Get(ɞ,"ShipName").ToString(ʔ);ɞ="RSM.InitItems";Echo(ɞ);
foreach(ɯ ʘ in ϴ){ʘ.І=ˆ.Get(ɞ,ʘ.ϻ.SubtypeId).ToInt32(ʘ.І);}ɞ="RSM.InitSubSystems";Echo(ɞ);H=ˆ.Get(ɞ,"Reactors").ToDouble(H);H=ˆ
.Get(ɞ,"Batteries").ToDouble(Ä);n=ˆ.Get(ɞ,"Pdcs").ToInt32(n);ȉ=ˆ.Get(ɞ,"TorpLaunchers").ToInt32(ȉ);e=ˆ.Get(ɞ,
"KineticWeapons").ToInt32(e);Õ=ˆ.Get(ɞ,"H2Storage").ToDouble(Õ);ë=ˆ.Get(ɞ,"O2Storage").ToDouble(ë);ä=ˆ.Get(ɞ,"MainThrust").ToSingle(ä);ȓ
=ˆ.Get(ɞ,"RCSThrust").ToSingle(ȓ);ү=ˆ.Get(ɞ,"Gyros").ToDouble(ү);ʧ=ˆ.Get(ɞ,"CargoStorage").ToDouble(ʧ);Ƨ=ˆ.Get(ɞ,
"Welders").ToInt32(Ƨ);}catch(Exception ex){Ѷ(ex,"Failed to parse section\n"+ɞ);}Echo("Parsing stances...");Dictionary<string,ÿ>ʗ=
new Dictionary<string,ÿ>();List<string>ʖ=new List<string>();ˆ.GetSections(ʖ);foreach(string ɬ in ʖ){if(ɬ.Contains(
"RSM.Stance.")){string ʕ=ɬ.Substring(11);Echo(ʕ);ÿ Ø=new ÿ();string ģ,ҏ="";string[]Ҏ;int ҍ=33,Ҍ=144,ɋ=255,ķ=255;bool ҋ=false;ÿ Ҋ=null
;ҏ="Inherits";if(ˆ.ContainsKey(ɬ,ҏ)){ҋ=true;try{Ҋ=ʗ[ˆ.Get(ɬ,ҏ).ToString()];Echo("Inherits "+ˆ.Get(ɬ,ҏ).ToString());}catch
(Exception ex){Ѷ(ex,"Failed to find inheritee for\n"+ɬ+"\nEnsure inheritee stances are\nlisted before their heirs");}}try
{if(ҋ)Echo(Ҋ.ý.ToString());ҏ="Torps";if(ˆ.ContainsKey(ɬ,ҏ)){Ø.ý=(Ƣ)Enum.Parse(typeof(Ƣ),ˆ.Get(ɬ,ҏ).ToString());Echo("1");
}else if(ҋ){Ø.ý=Ҋ.ý;Echo("2");}else{Ø.ý=Č;Echo("3");}ҏ="Pdcs";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ü=(Ǖ)Enum.Parse(typeof(Ǖ),ˆ.Get(ɬ,ҏ
).ToString());else if(ҋ)Ø.ü=Ҋ.ü;else Ø.ü=ē;ҏ="Kinetics";if(ˆ.ContainsKey(ɬ,ҏ))Ø.û=(ǔ)Enum.Parse(typeof(ǔ),ˆ.Get(ɬ,ҏ).
ToString());else if(ҋ)Ø.û=Ҋ.û;else Ø.û=ċ;ҏ="MainThrust";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ú=(Ǔ)Enum.Parse(typeof(Ǔ),ˆ.Get(ɬ,ҏ).ToString())
;else if(ҋ)Ø.ú=Ҋ.ú;else Ø.ú=Ċ;ҏ="ManeuveringThrust";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ù=(ǘ)Enum.Parse(typeof(ǘ),ˆ.Get(ɬ,ҏ).ToString
());else if(ҋ)Ø.ù=Ҋ.ù;else Ø.ù=ĉ;ҏ="Spotlights";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ø=(Ǘ)Enum.Parse(typeof(Ǘ),ˆ.Get(ɬ,ҏ).ToString());
else if(ҋ)Ø.ø=Ҋ.ø;else Ø.ø=Ĉ;ҏ="ExteriorLights";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ö=(ǖ)Enum.Parse(typeof(ǖ),ˆ.Get(ɬ,ҏ).ToString());
else if(ҋ)Ø.ö=Ҋ.ö;else Ø.ö=ć;ҏ="ExteriorLightColour";if(ˆ.ContainsKey(ɬ,ҏ)){ģ=ˆ.Get(ɬ,ҏ).ToString();Ҏ=ģ.Split(',');ҍ=int.
Parse(Ҏ[0]);Ҍ=int.Parse(Ҏ[1]);ɋ=int.Parse(Ҏ[2]);ķ=int.Parse(Ҏ[3]);Ø.õ=new Color(ҍ,Ҍ,ɋ,ķ);}else if(ҋ)Ø.õ=Ҋ.õ;else Ø.õ=Ć;ҏ=
"InteriorLights";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ô=(ǖ)Enum.Parse(typeof(ǖ),ˆ.Get(ɬ,ҏ).ToString());else if(ҋ)Ø.ô=Ҋ.ô;else Ø.ô=ą;ҏ=
"InteriorLightColour";if(ˆ.ContainsKey(ɬ,ҏ)){ģ=ˆ.Get(ɬ,ҏ).ToString();Ҏ=ģ.Split(',');ҍ=int.Parse(Ҏ[0]);Ҍ=int.Parse(Ҏ[1]);ɋ=int.Parse(Ҏ[2]);ķ=
int.Parse(Ҏ[3]);Ø.ó=new Color(ҍ,Ҍ,ɋ,ķ);}else if(ҋ)Ø.ó=Ҋ.ó;else Ø.ó=Ą;ҏ="NavLights";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ò=(ǖ)Enum.Parse(
typeof(ǖ),ˆ.Get(ɬ,ҏ).ToString());else if(ҋ)Ø.ò=Ҋ.ò;else Ø.ò=ă;ҏ="LcdTextColour";if(ˆ.ContainsKey(ɬ,ҏ)){ģ=ˆ.Get(ɬ,ҏ).ToString()
;Ҏ=ģ.Split(',');ҍ=int.Parse(Ҏ[0]);Ҍ=int.Parse(Ҏ[1]);ɋ=int.Parse(Ҏ[2]);ķ=int.Parse(Ҏ[3]);Ø.ñ=new Color(ҍ,Ҍ,ɋ,ķ);}else if(ҋ
)Ø.ñ=Ҋ.ñ;else Ø.ñ=ï;ҏ="TanksAndBatteries";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ā=(ǒ)Enum.Parse(typeof(ǒ),ˆ.Get(ɬ,ҏ).ToString());else
if(ҋ)Ø.ā=Ҋ.ā;else Ø.ā=â;ҏ="NavOsEfcBurnPercentage";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ð=ˆ.Get(ɬ,"NavOsEfcBurnPercentage").ToInt32(Ð);
else if(ҋ)Ø.ð=Ҋ.ð;else Ø.ð=Ð;ҏ="EfcBoost";if(ˆ.ContainsKey(ɬ,ҏ))Ø.Ă=(Ƣ)Enum.Parse(typeof(Ƣ),ˆ.Get(ɬ,ҏ).ToString());else if(ҋ
)Ø.Ă=Ҋ.Ă;else Ø.Ă=à;ҏ="NavOsAbortEfcOff";if(ˆ.ContainsKey(ɬ,ҏ))Ø.Ĕ=(ǂ)Enum.Parse(typeof(ǂ),ˆ.Get(ɬ,ҏ).ToString());else if
(ҋ)Ø.Ĕ=Ҋ.Ĕ;else Ø.Ĕ=ß;ҏ="NavOsAbortEfcOff";if(ˆ.ContainsKey(ɬ,ҏ))Ø.Ĕ=(ǂ)Enum.Parse(typeof(ǂ),ˆ.Get(ɬ,ҏ).ToString());else
if(ҋ)Ø.Ĕ=Ҋ.Ĕ;else Ø.Ĕ=ß;ҏ="AuxMode";if(ˆ.ContainsKey(ɬ,ҏ))Ø.Ē=(Ƣ)Enum.Parse(typeof(Ƣ),ˆ.Get(ɬ,ҏ).ToString());else if(ҋ)Ø.Ē
=Ҋ.Ē;else Ø.Ē=Þ;ҏ="Extractor";if(ˆ.ContainsKey(ɬ,ҏ))Ø.đ=(ǁ)Enum.Parse(typeof(ǁ),ˆ.Get(ɬ,ҏ).ToString());else if(ҋ)Ø.đ=Ҋ.đ;
else Ø.đ=Ý;ҏ="KeepAlives";if(ˆ.ContainsKey(ɬ,ҏ))Ø.Đ=(Ƣ)Enum.Parse(typeof(Ƣ),ˆ.Get(ɬ,ҏ).ToString());else if(ҋ)Ø.Đ=Ҋ.Đ;else Ø.
Đ=Ü;ҏ="HangarDoors";if(ˆ.ContainsKey(ɬ,ҏ))Ø.ď=(ǀ)Enum.Parse(typeof(ǀ),ˆ.Get(ɬ,ҏ).ToString());else if(ҋ)Ø.ď=Ҋ.ď;else Ø.ď=Û
;ʗ.Add(ʕ,Ø);}catch(Exception ex){Ѷ(ex,"Failed to parse stance\n"+ʕ+"\nproperty\n"+ҏ);}}}if(ʗ.Count<1){Echo(
"Failed to parse any stances!\nStances reset to default!");ʡ=false;}else{Echo("Finished parsing "+ʗ.Count+" stances.");ҕ=ʗ;}ɞ="RSM.Stance";Echo(ɞ);Ď=ˆ.Get(ɞ,"CurrentStance").
ToString(Ď);ÿ ҁ;if(!ҕ.TryGetValue(Ď,out ҁ)){Ď="N/A";č=null;}else č=ҁ;return ʡ;}void Ҁ(){ˆ.Clear();string ɞ,ȸ;ɞ="RSM.Main";ȸ=
"RequireShipName";ˆ.Set(ɞ,ȸ,ˁ);ˆ.SetComment(ɞ,ȸ,"limit to blocks with the ship name in their name");ȸ="EnableAutoload";ˆ.Set(ɞ,ȸ,ˀ);ˆ.
SetComment(ɞ,ȸ,"enable RSM loading & balancing functionality for weapons");ȸ="AutoloadReactors";ˆ.Set(ɞ,ȸ,ʿ);ˆ.SetComment(ɞ,ȸ,
"enable loading and balancing for reactors");ȸ="AutoConfigWeapons";ˆ.Set(ɞ,ȸ,ʾ);ˆ.SetComment(ɞ,ȸ,"automatically configure weapon on stance set");ȸ=
"SetTurretFireMode";ˆ.Set(ɞ,ȸ,ʽ);ˆ.SetComment(ɞ,ȸ,"set turret fire mode based on stance");ˆ.SetSectionComment(ɞ,п+
" Reedit Ship Management\n"+п+" Config.ini\n Recompile to apply changes!\n"+п);ɞ="RSM.Spawns";ȸ="PrivateSpawns";ˆ.Set(ɞ,ȸ,ʼ);ˆ.SetComment(ɞ,ȸ,
"don't inject faction tag into spawn custom data");ȸ="FriendlyTags";ˆ.Set(ɞ,ȸ,ˇ);ˆ.SetComment(ɞ,ȸ,"Comma seperated friendly factions or steam ids");ɞ="RSM.Doors";ȸ=
"EnableDoorManagement";ˆ.Set(ɞ,ȸ,ʻ);ˆ.SetComment(ɞ,ȸ,"enable door management functionality");ȸ="DoorCloseTimer";ˆ.Set(ɞ,ȸ,ʹ);ˆ.SetComment(ɞ,ȸ,
"door open timer (x100 ticks)");ȸ="AirlockDoorDisableTimer";ˆ.Set(ɞ,ȸ,ʸ);ˆ.SetComment(ɞ,ȸ,"airlock door disable timer (x100 ticks)");ɞ="RSM.Keywords";
ȸ="Ignore";ˆ.Set(ɞ,ȸ,ʷ);ˆ.SetComment(ɞ,ȸ,"to identify blocks which RSM should ignore");ȸ="RsmLcds";ˆ.Set(ɞ,ȸ,ʶ);ˆ.
SetComment(ɞ,ȸ,"to identify RSM lcds");ȸ="ColourSyncLcds";ˆ.Set(ɞ,ȸ,ʵ);ˆ.SetComment(ɞ,ȸ,"to identify non RSM lcds for colour sync"
);ȸ="AuxiliaryBlocks";ˆ.Set(ɞ,ȸ,ʴ);ˆ.SetComment(ɞ,ȸ,"to identify aux blocks");ȸ="DefensivePdcs";ˆ.Set(ɞ,ȸ,ʳ);ˆ.SetComment
(ɞ,ȸ,"to identify defensive _normalPdcs");ȸ="MinimumThrusters";ˆ.Set(ɞ,ȸ,ʲ);ˆ.SetComment(ɞ,ȸ,
"to identify minimum epsteins");ȸ="DockingThrusters";ˆ.Set(ɞ,ȸ,ʣ);ˆ.SetComment(ɞ,ȸ,"to identify docking epsteins");ȸ="NavLights";ˆ.Set(ɞ,ȸ,ʓ);ˆ.
SetComment(ɞ,ȸ,"to identify navigational lights");ȸ="Airlock";ˆ.Set(ɞ,ȸ,ʂ);ˆ.SetComment(ɞ,ȸ,"to identify airlock doors and vents")
;ɞ="RSM.InitNaming";ȸ="NameDelimiter";ˆ.Set(ɞ,ȸ,'"'+ʏ.ToString()+'"');ˆ.SetComment(ɞ,ȸ,"single char delimiter for names")
;ȸ="NameWeaponTypes";ˆ.Set(ɞ,ȸ,ʎ);ˆ.SetComment(ɞ,ȸ,"append type names to all weapons on init");ȸ="NameDriveTypes";ˆ.Set(ɞ
,ȸ,ʍ);ˆ.SetComment(ɞ,ȸ,"append type names to all drives on init");string ѿ="";foreach(string Ѿ in ʌ){if(ѿ!="")ѿ+=",";ѿ+=Ѿ
;}ȸ="BlocksToNumber";ˆ.Set(ɞ,ȸ,ʍ);ˆ.SetComment(ɞ,ȸ,"comma seperated list of block names to be numbered at init");ɞ=
"RSM.Misc";ȸ="DisableLightingControl";ˆ.Set(ɞ,ȸ,ʋ);ˆ.SetComment(ɞ,ȸ,"disable all lighting control");ȸ="DisableLcdColourControl";ˆ.
Set(ɞ,ȸ,ʊ);ˆ.SetComment(ɞ,ȸ,"disable text colour control for all lcds");ȸ="ShowBasicTelemetry";ˆ.Set(ɞ,ȸ,ʉ);ˆ.SetComment(ɞ,
ȸ,"show basic telemetry data on advanced thrust lcds");string ѽ="";foreach(double Ī in ʈ){if(ѽ!="")ѽ+=",";ѽ+=(Ī*100).
ToString();}ȸ="DecelerationPercentages";ˆ.Set(ɞ,ȸ,ѽ);ˆ.SetComment(ɞ,ȸ,"thrust percentages to show on advanced thrust lcds");ȸ=
"ShowThrustInMetric";ˆ.Set(ɞ,ȸ,ʇ);ˆ.SetComment(ɞ,ȸ,"show basic telemetry data on advanced thrust lcds");ȸ="ReactorFillRatio";ˆ.Set(ɞ,ȸ,ʆ);ˆ.
SetComment(ɞ,ȸ,"0-1, fill ratio for reactors");ɞ="RSM.Debug";ȸ="VerboseDebugging";ˆ.Set(ɞ,ȸ,ʅ);ˆ.SetComment(ɞ,ȸ,
"prints more logging info to PB details");ȸ="RuntimeProfiling";ˆ.Set(ɞ,ȸ,ʄ);ˆ.SetComment(ɞ,ȸ,"prints script runtime profiling info to PB details");ȸ=
"BlockRefreshFreq";ˆ.Set(ɞ,ȸ,ʒ);ˆ.SetComment(ɞ,ȸ,"ticks x100 between block refreshes");ȸ="StallCount";ˆ.Set(ɞ,ȸ,ʃ);ˆ.SetComment(ɞ,ȸ,
"ticks x100 to stall between runs");ɞ="RSM.Stance";ȸ="CurrentStance";ˆ.Set(ɞ,ȸ,Ď);ˆ.SetSectionComment(ɞ,п+" Stances\n Add or remove as required\n"+п);
string Ѽ="Red, Green, Blue, Alpha";foreach(var Ґ in ҕ){ɞ="RSM.Stance."+Ґ.Key;ÿ Ù=Ґ.Value;ÿ Ҋ=null;if(Ù.þ!=""){Ҋ=ҕ[Ù.þ];ȸ=
"Inherits";ˆ.Set(ɞ,ȸ,Ù.þ);ˆ.SetComment(ɞ,ȸ,"Use stance of this name as a template for settings");}ȸ="Torps";if(Ҋ!=null&&Ù.ý==Ҋ.ý){
if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ý.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(Ƣ)));}ȸ="Pdcs";if(Ҋ!=null&&Ù
.ü==Ҋ.ü){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ü.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(Ǖ)));}ȸ="Kinetics"
;if(Ҋ!=null&&Ù.û==Ҋ.û){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.û.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǔ)))
;}ȸ="MainThrust";if(Ҋ!=null&&Ù.ú==Ҋ.ú){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ú.ToString());ˆ.SetComment(ɞ
,"MainThrust",Ѻ(typeof(Ǔ)));}ȸ="ManeuveringThrust";if(Ҋ!=null&&Ù.ù==Ҋ.ù){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(
ɞ,ȸ,Ù.ù.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǘ)));}ȸ="Spotlights";if(Ҋ!=null&&Ù.ø==Ҋ.ø){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ
,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ø.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(Ǘ)));}ȸ="ExteriorLights";if(Ҋ!=null&&Ù.ö==Ҋ.ö){if(ˆ.
ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ö.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǖ)));}ȸ="ExteriorLightColour";if(Ҋ!=null&&
Ù.õ==Ҋ.õ){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,ѷ(Ù.õ));ˆ.SetComment(ɞ,ȸ,Ѽ);}ȸ="InteriorLights";if(Ҋ!=null
&&Ù.ô==Ҋ.ô){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ô.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǖ)));}ȸ=
"InteriorLightColour";if(Ҋ!=null&&Ù.ó==Ҋ.ó){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,ѷ(Ù.ó));ˆ.SetComment(ɞ,ȸ,Ѽ);}ȸ="NavLights";if
(Ҋ!=null&&Ù.ò==Ҋ.ò){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ò.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǖ)));}ȸ
="LcdTextColour";if(Ҋ!=null&&Ù.ñ==Ҋ.ñ){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,ѷ(Ù.ñ));ˆ.SetComment(ɞ,ȸ,Ѽ);}ȸ
="TanksAndBatteries";if(Ҋ!=null&&Ù.ā==Ҋ.ā){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ā.ToString());ˆ.
SetComment(ɞ,ȸ,Ѻ(typeof(ǒ)));}ȸ="NavOsEfcBurnPercentage";if(Ҋ!=null&&Ù.ð==Ҋ.ð){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ
,Ù.ð.ToString());ˆ.SetComment(ɞ,ȸ,"Burn % 0-100, -1 for no change");}ȸ="EfcBoost";if(Ҋ!=null&&Ù.Ă==Ҋ.Ă){if(ˆ.ContainsKey(
ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.Ă.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(Ƣ)));}ȸ="NavOsAbortEfcOff";if(Ҋ!=null&&Ù.Ĕ==
Ҋ.Ĕ){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.Ĕ.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǂ)));}ȸ="AuxMode";if(Ҋ
!=null&&Ù.Ē==Ҋ.Ē){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.Ē.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(Ƣ)));}ȸ=
"Extractor";if(Ҋ!=null&&Ù.đ==Ҋ.đ){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.đ.ToString());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǁ))
);}ȸ="KeepAlives";if(Ҋ!=null&&Ù.Đ==Ҋ.Đ){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.Đ.ToString());ˆ.SetComment(
ɞ,ȸ,Ѻ(typeof(Ƣ)));}ȸ="HangarDoors";if(Ҋ!=null&&Ù.ď==Ҋ.ď){if(ˆ.ContainsKey(ɞ,ȸ))ˆ.Delete(ɞ,ȸ);}else{ˆ.Set(ɞ,ȸ,Ù.ď.ToString
());ˆ.SetComment(ɞ,ȸ,Ѻ(typeof(ǀ)));}}ɞ="RSM.System";ȸ="ShipName";ˆ.Set(ɞ,ȸ,ʔ);ˆ.SetSectionComment(ɞ,п+
" System\n All items below this point are\n set automatically when running init\n"+п);ɞ="RSM.InitItems";foreach(ɯ ʘ in ϴ){ȸ=ʘ.ϻ.SubtypeId;ˆ.Set(ɞ,ȸ,ʘ.І);}ɞ="RSM.InitSubSystems";ˆ.Set(ɞ,"Reactors",H);ˆ.
Set(ɞ,"Batteries",H);ˆ.Set(ɞ,"Pdcs",n);ˆ.Set(ɞ,"TorpLaunchers",ȉ);ˆ.Set(ɞ,"KineticWeapons",e);ˆ.Set(ɞ,"H2Storage",Õ);ˆ.Set(
ɞ,"O2Storage",ë);ˆ.Set(ɞ,"MainThrust",ä);ˆ.Set(ɞ,"RCSThrust",ȓ);ˆ.Set(ɞ,"Gyros",ү);ˆ.Set(ɞ,"CargoStorage",ʧ);ˆ.Set(ɞ,
"Welders",Ƨ);Me.CustomData=ˆ.ToString();}void ҙ(string ɝ){string[]ʖ=ɝ.Split(new string[]{"[Stances]"},StringSplitOptions.None);
string[]Ҙ=ʖ[0].Split('\n');string җ=ʖ[1];try{for(int ĝ=1;ĝ<Ҙ.Length;ĝ++){if(Ҙ[ĝ].Contains("=")){string Җ=Ҙ[ĝ].Substring(1);
switch(Ҙ[(ĝ-1)]){case"Ship name. Blocks without this name will be ignored":ʔ=Җ;break;case
"Block name delimiter, used by init. One character only!":ʏ=char.Parse(Җ.Substring(0,1));break;case"Keyword used to identify RSM _allLcds.":ʶ=Җ;break;case
"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʴ=Җ;break;case"Keyword used to identify defence _normalPdcs.":ʳ=Җ;break
;case"Keyword used to identify minimum epstein drives.":ʲ=Җ;break;case"Keyword used to identify docking epstein drives.":
ʣ=Җ;break;case"Keyword to ignore block.":ʷ=Җ;break;case"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʾ=bool
.Parse(Җ);break;case"Disable lighting all control.":ʋ=bool.Parse(Җ);break;case"Disable LCD Text Colour Enforcement.":ʊ=
bool.Parse(Җ);break;case"Enable Weapon Autoload Functionality.":ˀ=bool.Parse(Җ);break;case"Number these blocks at init.":ʌ.
Clear();string[]Ҕ=Җ.Split(',');foreach(string Ѿ in Ҕ){if(Ѿ!="")ʌ.Add(Ѿ);}break;case"Show basic telemetry.":ʉ=bool.Parse(Җ);
break;case"Show Decel Percentages (comma seperated).":ʈ.Clear();string[]ғ=Җ.Split(',');foreach(string Ī in ғ){ʈ.Add(double.
Parse(Ī)/100);}break;case"Fusion Fuel count":ϴ[0].І=int.Parse(Җ);break;case"Fuel tank count":ϴ[1].І=int.Parse(Җ);break;case
"Jerry can count":ϴ[2].І=int.Parse(Җ);break;case"40mm PDC Magazine count":ϴ[3].І=int.Parse(Җ);break;case
"40mm Teflon Tungsten PDC Magazine count":ϴ[4].І=int.Parse(Җ);break;case"220mm Torpedo count":case"Torpedo count":ϴ[5].І=int.Parse(Җ);break;case
"220mm MCRN torpedo count":ϴ[6].І=int.Parse(Җ);break;case"220mm UNN torpedo count":ϴ[7].І=int.Parse(Җ);break;case"Ramshackle torpedo count":case
"Ramshackle torpedo Count":ϴ[8].І=int.Parse(Җ);break;case"Large ramshacke torpedo count":ϴ[9].І=int.Parse(Җ);break;case
"Zako 120mm Railgun rounds count":case"Railgun rounds count":ϴ[10].І=int.Parse(Җ);break;case"Dawson 100mm UNN Railgun rounds count":ϴ[11].І=int.Parse(Җ);
break;case"Stiletto 100mm MCRN Railgun rounds count":ϴ[12].І=int.Parse(Җ);break;case"T-47 80mm Railgun rounds count":ϴ[13].І=
int.Parse(Җ);break;case"Foehammer 120mm MCRN rounds count":ϴ[14].І=int.Parse(Җ);break;case
"Farren 120mm UNN Railgun rounds count":ϴ[15].І=int.Parse(Җ);break;case"Kess 180mm rounds count":ϴ[16].І=int.Parse(Җ);break;case"Steel plate count":ϴ[17].І=int
.Parse(Җ);break;case"Doors open timer (x100 ticks, default 3)":ʹ=int.Parse(Җ);break;case
"Airlock doors disabled timer (x100 ticks, default 6)":ʸ=int.Parse(Җ);break;case"Throttle script (x100 ticks pause between loops, default 0)":ʃ=int.Parse(Җ);break;case
"Full refresh frequency (x100 ticks, default 50)":ʒ=int.Parse(Җ);break;case"Verbose script debugging. Prints more logging info to PB details.":ʅ=bool.Parse(Җ);break;case
"Private spawn (don't inject faction tag into SK custom data).":ʼ=bool.Parse(Җ);break;case"Comma seperated friendly factions or steam ids for survival kits.":ˇ=string.Join("\n",Җ.
Split(','));break;case"Current Stance":Ď=Җ;ÿ ҁ;if(!ҕ.TryGetValue(Ď,out ҁ)){Ď="N/A";č=null;}else č=ҁ;break;case
"Reactor Integrity":H=float.Parse(Җ);break;case"Battery Integrity":Ä=float.Parse(Җ);break;case"PDC Integrity":n=int.Parse(Җ);break;case
"Torpedo Integrity":ȉ=int.Parse(Җ);break;case"Railgun Integrity":e=int.Parse(Җ);break;case"H2 Tank Integrity":Õ=double.Parse(Җ);break;case
"O2 Tank Integrity":ë=double.Parse(Җ);break;case"Epstein Integrity":ä=float.Parse(Җ);break;case"RCS Integrity":ȓ=float.Parse(Җ);break;case
"Gyro Integrity":ү=int.Parse(Җ);break;case"Cargo Integrity":ʧ=double.Parse(Җ);break;case"Welder Integrity":Ƨ=int.Parse(Җ);break;}}}}
catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);}try{string[]Ғ=җ.Split(new string[]{"Stance:"},
StringSplitOptions.None);if(ʅ)Echo("Parsing "+(Ғ.Length-1)+" stances");int ґ=24;Dictionary<string,ÿ>ʗ=new Dictionary<string,ÿ>();int[]ѻ=
new int[]{0,5,25,50,75,100};for(int ĝ=1;ĝ<Ғ.Length;ĝ++){string[]ѥ=Ғ[ĝ].Split('=');string ʕ="";int[]Ѱ=new int[ґ];ʕ=ѥ[0].
Split(' ')[0];if(ʅ)Echo("Parsing '"+ʕ+"'");for(int ѯ=0;ѯ<Ѱ.Length;ѯ++){string[]Ѯ=ѥ[(ѯ+1)].Split('\n');Ѱ[ѯ]=int.Parse(Ѯ[0]);}ÿ
Ø=new ÿ();if(Ѱ[0]==0)Ø.ý=Ƣ.Off;else Ø.ý=Ƣ.On;if(Ѱ[1]==0)Ø.ü=Ǖ.Off;else if(Ѱ[1]==1)Ø.ü=Ǖ.MinDefence;else if(Ѱ[1]==2)Ø.ü=Ǖ.
AllDefence;else if(Ѱ[1]==3)Ø.ü=Ǖ.Offence;else if(Ѱ[1]==4)Ø.ü=Ǖ.AllOnOnly;if(Ѱ[2]==0)Ø.û=ǔ.Off;else if(Ѱ[2]==1)Ø.û=ǔ.HoldFire;else
if(Ѱ[2]==2)Ø.û=ǔ.OpenFire;if(Ѱ[3]==0)Ø.ú=Ǔ.Off;else if(Ѱ[3]==1)Ø.ú=Ǔ.On;else if(Ѱ[3]==2)Ø.ú=Ǔ.Minimum;if(Ѱ[4]==0)Ø.ù=ǘ.Off
;else if(Ѱ[4]==1)Ø.ù=ǘ.On;else if(Ѱ[4]==2)Ø.ù=ǘ.ForwardOff;else if(Ѱ[4]==3)Ø.ù=ǘ.ReverseOff;if(Ѱ[5]==0)Ø.ø=Ǘ.Off;else if(
Ѱ[5]==1)Ø.ø=Ǘ.On;else if(Ѱ[5]==2)Ø.ø=Ǘ.OnMax;if(Ѱ[6]==0)Ø.ö=ǖ.Off;else Ø.ö=ǖ.On;Ø.õ=new Color(Ѱ[7],Ѱ[8],Ѱ[9],Ѱ[10]);if(Ѱ[
11]==0)Ø.ô=ǖ.Off;else Ø.ô=ǖ.On;Ø.ó=new Color(Ѱ[12],Ѱ[13],Ѱ[14],Ѱ[15]);if(Ѱ[16]==0)Ø.ā=ǒ.Auto;else if(Ѱ[16]==1)Ø.ā=ǒ.
StockpileRecharge;else if(Ѱ[16]==2)Ø.ā=ǒ.Discharge;if(Ѱ[17]==0)Ø.Ă=Ƣ.Off;else Ø.Ă=Ƣ.On;Ø.ð=ѻ[Ѱ[18]];if(Ѱ[19]==0)Ø.Ĕ=ǂ.NoChange;else Ø.Ĕ=ǂ
.Abort;if(Ѱ[20]==0)Ø.Ē=Ƣ.Off;else Ø.Ē=Ƣ.On;if(Ѱ[21]==0)Ø.đ=ǁ.Off;else if(Ѱ[21]==1)Ø.đ=ǁ.On;else if(Ѱ[21]==2)Ø.đ=ǁ.
FillWhenLow;else if(Ѱ[21]==3)Ø.đ=ǁ.KeepFull;if(Ѱ[22]==0)Ø.Đ=Ƣ.Off;else Ø.Đ=Ƣ.On;if(Ѱ[23]==0)Ø.ď=ǀ.Closed;else if(Ѱ[23]==1)Ø.ď=ǀ.
Open;else Ø.ď=ǀ.NoChange;ʗ.Add(ʕ,Ø);}if(ʗ.Count>=1){if(ʅ)Echo("Finished parsing "+ʗ.Count+" stances.");ҕ=ʗ;}else{Echo(
"Didn't find any stances!");}}catch(Exception ex){Echo("Custom Data Error (stances)\n"+ex.Message);}}void ѭ(){bool Ѭ=ʢ();if(!Ѭ){ѱ();Ҁ();}if(č==
null){č=ҕ.First().Value;}string ѫ="";string Ѫ="";if(!ʼ){ѫ=" ".PadRight(129,' ')+Ω+"\n";Ѫ="\n".PadRight(19,'\n');}Ψ=ѫ+Ѫ;Χ=ѫ+
string.Join("\n",ˇ.Split(','))+Ѫ;if(ʔ==""){if(ʅ)Echo("No ship name, trying to pull it from PB name...");string ѩ=
"Untitled Ship";try{string[]Ѩ=Me.CustomName.Split(ʏ);if(Ѩ.Length>1){ʔ=Ѩ[0];if(ʅ)Echo(ʔ);}else ʔ=ѩ;}catch{ʔ=ѩ;}}}void ѧ(bool Ú=true,bool
Ѧ=false,bool ˣ=false){MyIni ɛ=new MyIni();string ɝ=Me.CustomData;MyIniParseResult Ɗ;if(!ɛ.TryParse(ɝ,out Ɗ)){а.Add(new ј(
"CONFIG ERROR!!","Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ɞ,ȸ;if(Ú){ɞ="RSM.Stance"
;ȸ="CurrentStance";ɛ.Set(ɞ,ȸ,Ď);}else{ɞ="RSM.System";ȸ="ShipName";ɛ.Set(ɞ,ȸ,ʔ);}if(Ѧ){ɞ="RSM.InitSubSystems";ɛ.Set(ɞ,
"Reactors",H);ɛ.Set(ɞ,"Batteries",Ä);ɛ.Set(ɞ,"Pdcs",n);ɛ.Set(ɞ,"TorpLaunchers",ȉ);ɛ.Set(ɞ,"KineticWeapons",e);ɛ.Set(ɞ,"H2Storage",
Õ);ɛ.Set(ɞ,"O2Storage",ë);ɛ.Set(ɞ,"MainThrust",ä);ɛ.Set(ɞ,"RCSThrust",ȓ);ɛ.Set(ɞ,"Gyros",ү);ɛ.Set(ɞ,"CargoStorage",ʧ);ɛ.
Set(ɞ,"Welders",Ƨ);}if(ˣ){ɞ="RSM.InitItems";foreach(ɯ ʘ in ϴ){ȸ=ʘ.ϻ.SubtypeId;ɛ.Set(ɞ,ȸ,ʘ.І);}}Me.CustomData=ɛ.ToString();}
string Ѻ(Type ѹ){string Ѹ="";foreach(var ġ in Enum.GetValues(ѹ)){if(Ѹ!="")Ѹ+=", ";Ѹ+=ġ.ToString();}return Ѹ;}string ѷ(Color Ŕ)
{return Ŕ.R+", "+Ŕ.G+", "+Ŕ.B+", "+Ŕ.A;}void Ѷ(Exception ѵ,string Ѵ){Runtime.UpdateFrequency=UpdateFrequency.None;string
ѳ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+Ѵ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ѳ);List<IMyTextPanel>Ѳ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ѳ,ɋ=>ɋ.CustomName
.Contains(ʶ));foreach(IMyTextPanel Ƅ in Ѳ){Ƅ.WriteText(ѳ);Ƅ.FontColor=new Color(193,0,197,255);}throw ѵ;}Dictionary<
string,ÿ>ҕ=new Dictionary<string,ÿ>();void ѱ(){ҕ=new Dictionary<string,ÿ>{{"Cruise",new ÿ{ý=Ƣ.On,ü=Ǖ.AllDefence,û=ǔ.HoldFire,ú
=Ǔ.EpsteinOnly,ù=ǘ.ForwardOff,ø=Ǘ.Off,ö=ǖ.On,õ=new Color(33,144,255,255),ô=ǖ.On,ó=new Color(255,214,170,255),ò=ǖ.On,ñ=new
Color(33,144,255,255),ā=ǒ.Auto,ð=50,Ă=Ƣ.NoChange,Ĕ=ǂ.Abort,Ē=Ƣ.NoChange,đ=ǁ.KeepFull,Đ=Ƣ.On,ď=ǀ.NoChange,}},{"StealthCruise",
new ÿ{þ="Cruise",ý=Ƣ.On,ü=Ǖ.AllDefence,û=ǔ.HoldFire,ú=Ǔ.Minimum,ù=ǘ.ForwardOff,ø=Ǘ.Off,ö=ǖ.Off,õ=new Color(0,0,0,255),ô=ǖ.
On,ó=new Color(23,73,186,255),ò=ǖ.Off,ñ=new Color(23,73,186,255),ā=ǒ.Auto,ð=5,Ă=Ƣ.Off,Ĕ=ǂ.Abort,Ē=Ƣ.NoChange,đ=ǁ.KeepFull,
Đ=Ƣ.On,ď=ǀ.NoChange}},{"Docked",new ÿ{þ="Cruise",ý=Ƣ.On,ü=Ǖ.AllDefence,û=ǔ.HoldFire,ú=Ǔ.Off,ù=ǘ.Off,ø=Ǘ.Off,ö=ǖ.On,õ=new
Color(33,144,255,255),ô=ǖ.On,ó=new Color(255,240,225,255),ò=ǖ.On,ñ=new Color(255,255,255,255),ā=ǒ.StockpileRecharge,ð=-1,Ă=Ƣ.
NoChange,Ĕ=ǂ.Abort,Ē=Ƣ.Off,đ=ǁ.On,Đ=Ƣ.On,ď=ǀ.NoChange}},{"Docking",new ÿ{þ="Docked",ý=Ƣ.On,ü=Ǖ.AllDefence,û=ǔ.HoldFire,ú=Ǔ.Off,ù
=ǘ.On,ø=Ǘ.OnMax,ö=ǖ.On,õ=new Color(33,144,255,255),ô=ǖ.On,ó=new Color(212,170,83,255),ò=ǖ.On,ñ=new Color(212,170,83,255),
ā=ǒ.Auto,ð=-1,Ă=Ƣ.NoChange,Ĕ=ǂ.Abort,Ē=Ƣ.Off,đ=ǁ.KeepFull,Đ=Ƣ.On,ď=ǀ.NoChange}},{"NoAttack",new ÿ{þ="Docked",ý=Ƣ.Off,ü=Ǖ.
Off,û=ǔ.Off,ú=Ǔ.On,ù=ǘ.On,ø=Ǘ.Off,ö=ǖ.On,õ=new Color(255,255,255,255),ô=ǖ.On,ó=new Color(84,157,82,255),ò=ǖ.NoChange,ñ=new
Color(84,157,82,255),ā=ǒ.NoChange,ð=-1,Ă=Ƣ.NoChange,Ĕ=ǂ.NoChange,Ē=Ƣ.NoChange,đ=ǁ.KeepFull,Đ=Ƣ.On,ď=ǀ.NoChange}},{"Combat",
new ÿ{þ="Cruise",ý=Ƣ.On,ü=Ǖ.AllDefence,û=ǔ.OpenFire,ú=Ǔ.On,ù=ǘ.On,ø=Ǘ.Off,ö=ǖ.Off,õ=new Color(0,0,0,255),ô=ǖ.On,ó=new Color
(210,98,17,255),ò=ǖ.Off,ñ=new Color(210,98,17,255),ā=ǒ.ManagedDischarge,ð=100,Ă=Ƣ.On,Ĕ=ǂ.Abort,Ē=Ƣ.On,đ=ǁ.KeepFull,Đ=Ƣ.On
,ď=ǀ.NoChange}},{"CQB",new ÿ{þ="Combat",ý=Ƣ.On,ü=Ǖ.Offence,û=ǔ.OpenFire,ú=Ǔ.On,ù=ǘ.On,ø=Ǘ.Off,ö=ǖ.Off,õ=new Color(0,0,0,
255),ô=ǖ.On,ó=new Color(243,18,18,255),ò=ǖ.Off,ñ=new Color(243,18,18,255),ā=ǒ.ManagedDischarge,ð=100,Ă=Ƣ.On,Ĕ=ǂ.Abort,Ē=Ƣ.
On,đ=ǁ.KeepFull,Đ=Ƣ.On,ď=ǀ.NoChange}},{"WeaponsHot",new ÿ{þ="CQB",ý=Ƣ.On,ü=Ǖ.Offence,û=ǔ.OpenFire,ú=Ǔ.NoChange,ù=ǘ.
NoChange,ø=Ǘ.NoChange,ö=ǖ.NoChange,õ=new Color(0,0,0,255),ô=ǖ.NoChange,ó=new Color(243,18,18,255),ò=ǖ.NoChange,ñ=new Color(243,
18,18,255),ā=ǒ.ManagedDischarge,ð=-1,Ă=Ƣ.NoChange,Ĕ=ǂ.NoChange,Ē=Ƣ.NoChange,đ=ǁ.KeepFull,Đ=Ƣ.On,ď=ǀ.NoChange}}};}class Қ{
public IMyDoor ɒ;public int ӄ=0;public int Ӄ=0;public bool ӂ=false;public bool Ӂ=false;}class Ӏ{public string ҿ;public bool Ҿ=
false;public int ҽ=0;public bool Ҽ=false;public List<Қ>һ=new List<Қ>();public List<IMyAirVent>Һ=new List<IMyAirVent>();}int ҹ
=0;int Ҹ=0;int ҷ=0;int Ҷ(Қ Ң,bool ɣ=false){bool Ӆ=false;bool ӏ=false;if(Ң.ɒ==null)return 0;bool Ķ=Ң.ɒ.OpenRatio>0;ҹ++;if(
ң(Ң.ɒ))ҷ++;if(!ɣ||Ķ)Ң.ɒ.Enabled=true;if(Ķ){if(Ң.ӄ==0){ӏ=true;}Ң.ӄ++;if(Ң.ӄ>=ʹ){Ң.ӄ=0;Ң.ɒ.CloseDoor();Ӆ=true;}}else{Ҹ++;if
(Ң.ӄ!=0){Ӆ=true;Ң.ӄ=0;}}int Ĩ=0;if(Ӆ)Ĩ=1;else if(ӏ)Ĩ=2;return Ĩ;}void Ӎ(){if(!ʻ){if(ʅ)Echo("Door management is disabled."
);return;}foreach(Ӏ ɣ in ό){bool ӌ=false;foreach(Қ Ң in ɣ.һ){if(Ң.ɒ==null)continue;int Ӌ=Ҷ(Ң,true);if(Ӌ==1){if(ʅ)Echo(
"Airlock door "+Ң.ɒ.CustomName+" just closed");if(ɣ.Ҽ)ɣ.Ҽ=false;else{ɣ.Ҿ=true;Ң.Ӂ=true;if(ʅ)Echo("Airlock "+ɣ.ҿ+" needs to cycle");}}
else if(Ӌ==2){if(ʅ)Echo("Airlock door "+Ң.ɒ.CustomName+" just opened");ӌ=true;}}bool ӎ=true;if(ɣ.Ҿ){foreach(Қ Ң in ɣ.һ){if(Ң
.ɒ==null)continue;if(Ң.ɒ.OpenRatio>0){Ң.ɒ.CloseDoor();ӎ=false;}else Ң.ɒ.Enabled=false;}bool Ӊ=false;foreach(IMyAirVent ӈ
in ɣ.Һ){if(ӈ==null)continue;if(!ӈ.Enabled)ӈ.Enabled=true;if(!ӈ.Depressurize)ӈ.Depressurize=true;if(ӈ.CanPressurize&&ӈ.
GetOxygenLevel()<.01&&ɣ.Ҿ&&ӎ)Ӊ=true;}ɣ.ҽ++;bool Ӈ=true;if(ɣ.ҽ>=ʸ){Ӈ=false;Ӊ=true;}if(Ӊ){ɣ.Ҿ=false;ɣ.ҽ=0;ɣ.Ҽ=true;foreach(Қ Ң in ɣ.һ){
if(Ң.ɒ==null)continue;Ң.ɒ.Enabled=true;if(Ң.Ӂ)Ң.Ӂ=false;else if(Ӈ)Ң.ɒ.OpenDoor();}}}else if(ӌ){foreach(Қ Ң in ɣ.һ){if(Ң.ɒ
==null)continue;if(Ң.ɒ.OpenRatio==0)Ң.ɒ.Enabled=false;}}else{foreach(Қ Ң in ɣ.һ){Ң.ɒ.Enabled=true;}}}}void ӆ(){if(!ʻ){if(ʅ
)Echo("Door management is disabled.");return;}ҹ=0;Ҹ=0;ҷ=0;foreach(Қ Ң in ύ)Ҷ(Ң);}void ӊ(ǀ J){if(J==ǀ.NoChange)return;
foreach(IMyAirtightHangarDoor Ұ in ϰ){if(Ұ==null)continue;if(J==ǀ.Closed)Ұ.CloseDoor();else Ұ.OpenDoor();}}void ҧ(string Ҧ,
string ҥ){Ҧ=Ҧ.ToLower();foreach(Қ Ң in ύ){if(ҥ==""||Ң.ɒ.CustomName.Contains(ҥ)){bool Ҥ=ң(Ң.ɒ);if(Ҥ&&(Ҧ=="locked"||Ҧ=="toggle")
)Ң.ɒ.ApplyAction("AnyoneCanUse");if(!Ҥ&&(Ҧ=="unlocked"||Ҧ=="toggle"))Ң.ɒ.ApplyAction("AnyoneCanUse");}}}bool ң(IMyDoor Ң)
{var Ɲ=Ң.GetActionWithName("AnyoneCanUse");StringBuilder ҡ=new StringBuilder();Ɲ.WriteValue(Ң,ҡ);return(ҡ.ToString()==
"On");}double Ҡ;int ҟ=10;double Ҟ=3;double ҝ=245000;double Ҝ=50000;double қ=100;void Ҩ(ǁ J){foreach(IMyTerminalBlock Ҫ in Ϩ)
{if(Ҫ==null)continue;if(J==ǁ.Off)Ҫ.ApplyAction("OnOff_Off");else Ҫ.ApplyAction("OnOff_On");}}void ҵ(){if(Ϩ.Count<1&&Ϧ.
Count>0)Ҡ=(Ҟ*Ҝ);else Ҡ=(Ҟ*ҝ);}void ҳ(){if(č.đ==ǁ.Off||č.đ==ǁ.On){if(ʅ)Echo("Extractor management disabled.");}else if(Ϡ.Count
<1){if(ʅ)Echo("No tanks!");}else if(č.đ==ǁ.FillWhenLow&&қ<ҟ){ΐ=true;if(ʅ)Echo("Fuel low! ("+қ+"% / "+ҟ+"%)");}else if(č.đ
==ǁ.KeepFull&&Ô<(Ö-Ҡ)){ΐ=true;if(ʅ)Echo("Fuel ready for top up ("+Ô+" < "+(Ö-Ҡ)+")");}else if(ʅ){Echo("Fuel level OK ("+қ+
"%).");if(č.đ==ǁ.KeepFull)Echo("Keeping tanks full\n("+Ô+" < "+(Ö-Ҡ)+")");}}void Ҳ(){ΐ=false;IMyTerminalBlock ұ=null;int ɯ=1;
foreach(IMyTerminalBlock Ҫ in Ϩ){if(Ҫ.IsFunctional){ұ=Ҫ;break;}}if(ұ==null||ϴ[ɯ].Ж<1){ɯ=2;foreach(IMyTerminalBlock Ҫ in Ϧ){if(Ҫ
.IsFunctional){ұ=Ҫ;ɯ=2;if(ϴ[ɯ].Ж<1)break;}}if(ұ==null){Μ=true;return;}}Μ=false;if(ϴ[ɯ].Ж<1){Ό=ϴ[ɯ].ϸ;return;}Ό="";М ϗ=new
М();ϗ.ɒ=ұ;ϗ.ϗ=ұ.GetInventory();if(ϗ.ϗ.VolumeFillFactor>0){if(ʅ)Echo("Extractor already loaded, waiting...");ұ.ApplyAction
("OnOff_On");return;}List<М>Ҵ=new List<М>();Ҵ.Add(ϗ);if(ʅ)Echo("Attempting to load extractor "+ұ.CustomName);bool ʡ=я(ϴ[ɯ
].Ͻ,Ҵ,ϴ[ɯ].ϻ,1);string Ɋ="fuel tank";if(ɯ==2)Ɋ="jerry can";if(ʡ)а.Add(new ј("Loaded a "+Ɋ,"Sucessfully loaded a "+Ɋ+
" into an extractor.",0));}double ү=0;int Ү=0;double ҭ=0;void Ҭ(bool Ê,bool Ũ){Ү=0;foreach(IMyGyro ҫ in ϥ){if(ҫ!=null&&ҫ.IsFunctional){Ү++;if
(Ũ)ҫ.Enabled=Ê;}}ҭ=Math.Round(100*(Ү/ү));}void Ѥ(string Д,bool ˬ=true,bool ˉ=true,bool ˣ=true){if(ʅ)Echo(
"Initialising a ship as '"+Д+"'...");Γ=true;ʔ=Д;Π=ˬ;Τ=ˉ;Ρ=ˣ;В();}void В(){switch(Ζ){case 0:ˋ();Η=0;if(ʄ)Echo("Took "+Ή());break;case 1:Ѐ();if(ʄ)
Echo("Took "+Ή());break;case 2:if(ʅ)Echo("Initialising lcds...");Ɔ();if(Τ){if(ʅ)Echo("Initialising subsystem values...");Ȃ()
;Ȑ();M();C();á();è();ʱ();n=ξ.Count+ν.Count;ȉ=κ.Count;e=μ.Count;ү=ϥ.Count;Ƨ=π.Count;}if(Ρ){if(ʅ)Echo(
"Initialising item values...");Л();}if(Π){if(ʅ)Echo("Initialising block names...");Ѝ();}ѧ(false,Τ,Ρ);а.Add(new ј("Init:"+ʔ,"Initialised '"+ʔ+
"'\nGood Hunting!",3));Ζ=0;Γ=false;if(ʄ)Echo("Took "+Ή());return;}Ζ++;}class Б{public int А=0;public int Џ=0;public int Ў=0;}void Ѝ(){
Dictionary<string,Б>Ќ=new Dictionary<string,Б>();if(ʌ.Count>0){foreach(string U in ʌ){if(ʅ)Echo("Numbering "+U);Ќ.Add(U,new Б());}
foreach(var Љ in ϋ){Б Ћ;if(Ќ.TryGetValue(Љ.Value,out Ћ)){Ќ[Љ.Value].Џ++;}}foreach(var Њ in Ќ){if(Њ.Value.Џ<10)Њ.Value.Ў=1;else
if(Њ.Value.Џ>99)Њ.Value.Ў=3;else Њ.Value.Ў=2;}}foreach(var Љ in ϋ){string Ј="";string Г=Љ.Value;Б Ї;if(Ќ.TryGetValue(Љ.
Value,out Ї)){if(Ї.Џ>1){Ї.А++;Ј=ʏ+Ї.А.ToString().PadLeft(Ї.Ў,'0');}}Љ.Key.CustomName=ʔ+ʏ+Г+Ј+Е(Љ.Key.CustomName,Г);}}string Е
(string ȸ,string С=""){try{string[]Р=ȸ.Split(ʏ);string[]П=С.Split(ʏ);string Ɗ="";if(Р.Length<3)return"";for(int ĝ=2;ĝ<Р.
Length;ĝ++){int О=0;bool Н=int.TryParse(Р[ĝ],out О);if(Н)Р[ĝ]="";foreach(string Т in П){if(Т==Р[ĝ])Р[ĝ]="";}if(Р[ĝ]!="")Ɗ+=ʏ+Р
[ĝ];}return Ɗ;}catch{return"";}}class М{public IMyTerminalBlock ɒ{get;set;}public IMyInventory ϗ{get;set;}List<
MyInventoryItem>К=new List<MyInventoryItem>();public int Й=0;public bool И=false;public float З;}class ɯ{public int Ж=0;public int І=0;
public int Ͽ=0;public double ϲ;public List<М>Ͻ=new List<М>();public List<М>ϼ=new List<М>();public MyItemType ϻ;public bool Ϻ=
false;public bool Ϲ=false;public string ϸ;public string Ϸ;public double ϵ=1;}List<ɯ>ϴ=new List<ɯ>();void ϳ(IMyTerminalBlock ɋ
,int ʘ=99){if(ʘ==99){foreach(var ɯ in ϴ){М ϗ=new М();ϗ.ɒ=ɋ;ϗ.ϗ=ɋ.GetInventory();ɯ.Ͻ.Add(ϗ);}}else{М ϗ=new М();ϗ.ɒ=ɋ;ϗ.ϗ=ɋ
.GetInventory();ϗ.И=ˀ;if(ʘ==0&&!ʿ)ϗ.И=false;ϴ[ʘ].Ͻ.Add(ϗ);}}void Ͼ(IMyTerminalBlock ɋ,int ʘ){М ϗ=new М();ϗ.ɒ=ɋ;ϗ.ϗ=ɋ.
GetInventory();ϗ.И=ˀ;if(ʘ!=99)ϴ[ʘ].ϼ.Add(ϗ);}void Ѕ(string ϸ,string Є,string Ѓ,bool Ϲ=false,bool Ϻ=false){ɯ ɯ=new ɯ();ɯ.ϻ=new
MyItemType(Є,Ѓ);ɯ.Ϲ=Ϲ;ɯ.Ϻ=Ϻ;ɯ.ϸ=ϸ;string Ϸ;if(ϸ.Length>9)Ϸ=ϸ.Substring(0,9);else Ϸ=ϸ.PadRight(9);ɯ.Ϸ=Ϸ;ϴ.Add(ɯ);}void Ђ(){try{Ѕ(
"Fusion Fuel","MyObjectBuilder_Ingot","FusionFuel",true);Ѕ("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");Ѕ("Jerry Can",
"MyObjectBuilder_Component","SG_Fuel_Tank");Ѕ("PDC","MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine",true);Ѕ("PDC Tefl",
"MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);Ѕ("220 Torp ","MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",
true,true);Ѕ("220 MCRN","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true,true);Ѕ("220 UNN",
"MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);Ѕ("RS Torp","MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);
Ѕ("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",true,true);Ѕ("120mm RG",
"MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);Ѕ("Dawson","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true
);Ѕ("Stiletto","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugMCRNMagazine",true);Ѕ("80mm",
"MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);Ѕ("Foehammr","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugMCRNMagazine",true);Ѕ("Farren","MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugUNNMagazine",true);Ѕ("Kess",
"MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);Ѕ("Steel Pla","MyObjectBuilder_Component","SteelPlate");ϴ[0].ϵ=ʆ;}catch(Exception
ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void Ё(){foreach(var ɯ in ϴ){ɯ.ϼ.Clear();}}void Ѐ(){
foreach(var ɯ in ϴ){ɯ.Ж=0;ɯ.Ͽ=0;List<М>ͱ=ɯ.Ͻ.Concat(ɯ.ϼ).ToList();foreach(М ϗ in ͱ){ϗ.Й=ϗ.ϗ.GetItemAmount(ɯ.ϻ).ToIntSafe();ɯ.Ж
+=ϗ.Й;if(ϗ.И){ϗ.З=ϗ.ϗ.VolumeFillFactor;}else{ɯ.Ͽ+=ϗ.Й;}}}}void Л(){foreach(ɯ ɯ in ϴ){ɯ.І=ɯ.Ж;}}int њ(string ǥ){switch(ǥ){
case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":case"MCRN Torpedo Low Spread":return 6;case
"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;case"40mm Lead-Steel PDC Box Ammo":
return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":return 10;case
"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case"80mm Tungsten-Uranium Sabot Ammo":return 13;case
"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;case"180mm Lead-Steel Sabot Ammo":return 16;case
"Large Ramshackle Torpedo Magazine":return 9;default:if(ʅ)Echo("Unknown AmmoType = "+ǥ);return 99;}}bool ё(IMyTerminalBlock ɒ){IMyInventory ѐ=ɒ.
GetInventory();return ѐ.VolumeFillFactor==0;}bool я(List<М>Σ,List<М>ϧ,MyItemType ϻ,int ю=-1,double э=1,double ь=1){if(ʅ)Echo(
"Loading "+ϧ.Count+" inventories from "+Σ.Count+" sources.");bool u=false;bool ы=ь<1;foreach(М ъ in ϧ){int щ=3;foreach(М ш in Σ){
if(щ<0)break;if(ю!=-1&&ъ.Й>=(ю*.95))break;if(!ъ.ϗ.IsConnectedTo(ш.ϗ))continue;List<MyInventoryItem>ђ=new List<
MyInventoryItem>();ш.ϗ.GetItems(ђ);foreach(MyInventoryItem ч in ђ){if(ч.Type==ϻ){int Й=ч.Amount.ToIntSafe();if(Й==0&&!ы)break;щ--;if(ы)
{щ=-1;try{Й=ш.Й-Convert.ToInt32(ш.Й/ш.З*ь);if(ʅ)Echo("Unload "+Й+"\n"+ш.Й+"\n"+Convert.ToInt32(ш.Й/ш.З*ь));}catch(
Exception ex){if(ʅ)Echo("Int conversion error at unload\n"+ex.Message);Й=1;}}else if(э<1){try{int ѣ=Convert.ToInt32(ъ.Й/ъ.З*э)-ъ.
Й;if(ѣ<Й)Й=ѣ;}catch(Exception ex){if(ʅ)Echo("Int conversion error at load\n"+ex.Message);Й=1;}}else if(ю!=-1){if(Й<=ю){
break;}Й=ю-ъ.Й;}u=ъ.ϗ.TransferItemFrom(ш.ϗ,ч,Й);if(u)щ=-1;if(ы&&u)return(u);break;}}}}return u;}class ѡ{public IMyTextPanel ɒ
;public bool Ѡ=true;public bool џ=false;public bool ў=false;public bool ѝ=true;public bool ќ=true;public bool Ѣ=true;
public bool ћ=false;public bool љ=false;}class ј{public string ї,і;public int ѕ,є;public ј(string ѓ,string ц,int в=0,int У=20)
{if(ѓ.Length>Ш-3)ѓ=ѓ.Substring(0,Ш-3);ї=ѓ.PadRight(Ш-3);і=ц;ѕ=в;є=У;}}List<ј>а=new List<ј>();class Я{public string Ю,Э;
public Я(string U,int Ь,int Ы){string Ъ="    ";while(Ы>3){Ы-=4;}if(Ь==0){Ю="║ "+U.PadRight(4)+" ║";Э="  "+Ъ+"  ";}else if(Ь==1
){if(Ы==0||Ы==2)Ю="║─"+U.PadRight(4)+" ║";else Ю="║ "+U.PadRight(4)+"─║";Э=" ░"+Ъ+"░ ";}else if(Ь==2){if(Ы==0||Ы==2){Ю=
"║ "+U.PadRight(4)+"═║";Э="║▒"+Ъ+"░║";}else{Ю="║═"+U.PadRight(4)+" ║";Э="║░"+Ъ+"▒║";}}else if(Ь==3){if(Ы==0||Ы==2){Ю="║!"+U.
PadRight(4)+"!║";Э="║▓"+Ъ+"▓║";}else{Ю="║ "+Ъ+" ║";Э="║!"+U.PadRight(4)+"!║";}}}}Color Щ=new Color(255,116,33,255);const int Ш=
32;int Ч=0;string[]Ц=new string[]{"▄ "," ▄"," ▀","▀ "},Х=new string[]{"─","\\","│","/"},Ф=new string[]{"- ","= ","x ","! "
};string б,г,ф,х,у="\n\n",т,с="╔══════╗",р="╚══════╝",п,о,н,м,л,к,й,и,з,ж,е,д,Ʌ,Ŋ,ã,ň,Ň,ņ,Ņ,ń,Ń;void ł(){с=с+с+с+с+"\n";р
=р+р+р+р+"\n";б=Ɠ("Welcome to")+у+Ɠ("R S M")+у;г=Ɠ("Initialising")+у;ф=new String(' ',Ш-8);х="└"+new String('─',Ш-2)+"┘";
п=new String('-',26)+"\n";т="──"+у;о=Ł("Inventory");н=Ł("Thrust");м=Ł("Power & Tanks");л=Ł("Warnings");к=Ł(
"Subsystem Integrity");й=Ł("Telemetry & Thrust");и=Ŀ("Velocity");з=Ŀ("Velocity (Max)");ж=Ŀ("Mass");е=Ŀ("Max Accel");д=Ŀ("Actual Accel");Ʌ=Ŀ(
"Accel (Best)");Ŋ=Ŀ("Max Thrust");ã=Ŀ("Actual Thrust");ň=Ŀ("Decel (Dampener)");Ň=Ŀ("Decel (Actual)");ņ=Ľ("Fuel");Ņ=Ľ("Oxygen");ń=Ľ(
"Battery");Ń=Ľ("Capacity");}string Ł(string ŀ){return"──┤ "+ŀ+" ├"+new String('─',Ш-9-ŀ.Length);}string Ŀ(string ľ){return ľ+":"+
new String(' ',Ш-16-ľ.Length);}string Ľ(string ļ){return ļ+new String(' ',Ш-22-ļ.Length)+"[";}void Ļ(){Ч++;if(Ч>=Ц.Length)Ч
=0;int ĺ=Ч+2;if(ĺ>3)ĺ-=4;string ŉ=Ц[Ч];string Ĺ=Х[Ч];string ŋ=Ц[ĺ];string Ş=о+Ĺ+т;string Ŝ=н+Ĺ+т;string ś=м+Ĺ+т;string Ś=
л+Ĺ+т;string ř=к+Ĺ+т;string Ř=й+Ĺ+т;string ŗ=Ɠ(ʔ.ToUpper())+"\n"+"  "+ŉ+" "+Ɠ(Ď,Ш-10)+" "+ŉ+"  \n";string Ŗ="\n  "+ŋ+ф+ŋ+
"  "+у;if(Δ){string ŝ=б+Ɠ("Booting"+new string('.',Κ))+у;Ş+=ŝ;Ŝ+=ŝ;ś+=ŝ;Ś+=ŝ;ř+=ŝ;}else if(Γ){string ŕ=г+Ɠ(ʔ)+у;Ş+=ŕ;Ŝ+=ŕ;ś
+=ŕ;Ś+=ŕ;ř+=ŕ;}else{ʨ();double œ=9.81,Œ=Math.Round(Ϋ),ő=Math.Round((æ/Ϊ/œ),2),Ő=Math.Round((å/Ϊ/œ),2),ŏ=Math.Round(H+Ä,1),
Ŏ=Math.Round(Ç,1),ō=Math.Round(100*(ì/í)),Ō=Math.Round(100*(Ã/Å)),ĸ=Math.Round(100*(Ŏ/ŏ));string ĥ=и,ĕ=" Gs",ģ;List<
string>Ģ=new List<string>();if(Œ<1){Œ=500;ĥ=з;}if(ʇ){œ=1;ĕ=" m/s/s";}for(int ĝ=0;ĝ<ϴ.Count;ĝ++){if(ϴ[ĝ].І!=0){ϴ[ĝ].ϲ=(100*((
double)ϴ[ĝ].Ж/(double)ϴ[ĝ].І));string ġ=(ϴ[ĝ].Ж+"/"+ϴ[ĝ].І).PadLeft(9);if(ġ.Length>9)ġ=ġ.Substring(0,9);Ş+=ϴ[ĝ].Ϸ+" ["+Ž(ϴ[ĝ].
ϲ)+"] "+ġ+"\n";if(ĝ>2&&ϴ[ĝ].Ͽ<1)Ģ.Add(ϴ[ĝ].ϸ);}}Ş+="\n";if(å>0)Ŝ+=Ň+ƍ(å,Œ)+"\n"+д+(Ő+ĕ).PadLeft(15)+у;else Ŝ+=ň+ƍ(æ,Œ,
true)+"\n"+Ʌ+(ő+ĕ).PadLeft(15)+у;қ=Math.Round(100*(Ô/Ö));ś+=ņ+Ž(қ)+"] "+(қ+" %").PadLeft(9)+"\n"+Ņ+Ž(ō)+"] "+(ō+" %").
PadLeft(9)+"\n"+ń+Ž(Ō)+"] "+(Ō+" %").PadLeft(9)+"\n"+Ń+Ž(ĸ)+"] "+(ĸ+" %").PadLeft(9)+"\n"+"Max Power:"+(Ŏ+" MW / "+ŏ+" MW").
PadLeft(22)+у;List<ј>Ġ=new List<ј>();List<Я>ğ=new List<Я>();int Ğ=0;for(int ĝ=0;ĝ<а.Count;ĝ++){а[ĝ].є--;if(а[ĝ].є<1)а.RemoveAt(
ĝ);else Ġ.Add(а[ĝ]);}if(!Ŵ){Ġ.Add(new ј("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(Ύ){Ġ.Add(new ј("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int Ĝ=0;if(қ<5)
{ģ="FUEL CRITICAL!";Ġ.Add(new ј(ģ,ģ+"\nFuel Level < 5%!",3));Ĝ=3;}else if(қ<25){ģ="FUEL LOW!";Ġ.Add(new ј(ģ,ģ+
"\nFuel Level < 10%!",2));Ĝ=2;}if(č.đ!=ǁ.Off){if(Ό!=""){if(Ĝ==0)Ĝ=1;Ġ.Add(new ј("NO SPARE "+Ό.ToUpper()+"!",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",Ĝ));}if(Μ){if(Ĝ==0)Ĝ=1;Ġ.Add(new ј("NO EXTRACTOR!","Cannot refuel!\nNo functional extractor!",Ĝ));}}ğ.Add(new Я("FUEL",
Ĝ,Ч+Ğ));Ğ++;if(Ώ){ģ=ϡ.Count+" spawns are open to friends";Ġ.Add(new ј(ģ,ģ,0));}int ě=0;if(ō<5){ģ="OXYGEN CRITICAL!";Ġ.Add
(new ј(ģ,ģ+"\nShip O2 Level < 5%!",3));ě=3;}else if(ō<10){ģ="OXYGEN LOW!";Ġ.Add(new ј(ģ,ģ+"\nShip O2 Level < 10%!",2));ě=
2;}else if(ō<25){ģ="Oxygen Low!";Ġ.Add(new ј(ģ,ģ+"\nShip O2 Level < 25%!",1));ě=1;}if(ϒ.Count>Ų){int Ě=(ϒ.Count-Ų);ě++;ģ=
Ě+" vents are unsealed";Ġ.Add(new ј(ģ,ģ,1));}if(ҷ>0){ģ=ҷ+" doors are insecure";Ġ.Add(new ј(ģ,ģ,0));}if(έ>0){ģ=ʴ+
" is active ("+έ+")";Ġ.Add(new ј(ģ,ģ,0));}ğ.Add(new Я("OXYG",ě,Ч+Ğ));Ğ++;int ę=0;if(ϭ.Count>0){if(Ō<5){ę+=2;ģ="BATTERIES CRITICAL!";Ġ.
Add(new ј(ģ,ģ+"\nBattery Level < 5%!",2));}else if(Ō<10){ę+=1;ģ="Batteries Low!";Ġ.Add(new ј(ģ,ģ+"\nBattery Level < 10%!",1
));}}if(ϣ.Count>0){if(E>0){ę+=2;Ġ.Add(new ј(E+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}
if(ϴ[0].Ж<1){ę+=3;ģ="NO FUSION FUEL!";Ġ.Add(new ј(ģ,ģ,2));}else if(ϴ[0].Ж<50){ę+=2;ģ="FUSION FUEL CRITICAL! ("+ϴ[0].Ж+")";
Ġ.Add(new ј(ģ,ģ,2));}else if(ϴ[0].І>0&&ϴ[0].ϲ<5){ę+=2;ģ="FUSION FUEL CRITICAL!";Ġ.Add(new ј(ģ,ģ,3));}else if(ϴ[0].І>0&&ϴ[
0].ϲ<10){ę+=1;ģ="Fusion Fuel Level Low!";Ġ.Add(new ј(ģ,ģ,2));}}if(ę>3)ę=3;ğ.Add(new Я("POWR",ę,Ч+Ğ));Ğ++;int Ę=0;if(Ģ.
Count>0){foreach(string ė in Ģ){string Ė=ė;if(ė.Length>23)Ė=ė.Substring(0,23);Ė=Ė.ToUpper();ģ="NO SPARE "+Ė+"!";Ġ.Add(new ј(ģ
,ģ,3));}Ę=3;}if(Ę>3)Ę=3;ğ.Add(new Я("WEAP",Ę,Ч+Ğ));Ğ++;if(ͼ){string Ĥ=ͻ;if(Ϯ.Count>0)if(Ϯ[0]!=null)Ĥ=(Ϯ[0]as
IMyRadioAntenna).HudText;string Ħ="";if(ͺ<1000)Ħ=Math.Round(ͺ)+"m";else Ħ=Math.Round(ͺ/1000)+"km";Ġ.Add(new ј("Comms ("+Ħ+"): "+Ĥ,
"Antenna(s) are broadcasting at a range of "+Ħ+" with the message "+Ĥ,0));}if(Ν>0){ģ=Ν+" UNOWNED BLOCKS!";Ġ.Add(new ј(ģ,ģ+"\nRSM detected "+Ν+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ҹ>Ҹ){int Ķ=(ҹ-Ҹ);ģ=Ķ+" doors are open";Ġ.Add(new ј(ģ,ģ,0));}Ġ=Ġ.OrderBy(ķ=>ķ.ѕ).Reverse().ToList();if(Ġ.Count<1
)Ś+="No warnings\n";else Echo(у+" WARNINGS:");for(int ĝ=0;ĝ<Ġ.Count;ĝ++){Ś+=Ф[Ġ[ĝ].ѕ]+Ġ[ĝ].ї+"\n";Echo("-"+Ф[Ġ[ĝ].ѕ]+Ġ[ĝ]
.і);}Ś+="\n";string ĵ=č.ú.ToString().ToUpper();if(ĵ.Length>3)ĵ=ĵ.Substring(0,3);string Ĵ=č.ù.ToString().ToUpper();if(Ĵ.
Length>3)Ĵ=Ĵ.Substring(0,3);string ĳ=č.ú.ToString().ToUpper();if(ĳ.Length>3)ĳ=ĳ.Substring(0,3);string Ĳ=č.ü.ToString().ToUpper
();if(Ĳ.Length>3)Ĳ=Ĳ.Substring(0,3);string ı=č.ý.ToString().ToUpper();if(ı.Length>3)ı=ı.Substring(0,3);string İ=č.û.
ToString().ToUpper();if(İ.Length>3)İ=İ.Substring(0,3);try{if(ä>0)ř+="Epstein   ["+Ž(À)+"] "+(À+"% ").PadLeft(5)+ĵ+"\n";if(ȓ>0)ř
+="RCS       ["+Ž(Ȓ)+"] "+(Ȓ+"% ").PadLeft(5)+Ĵ+"\n";if(H>0)ř+="Reactors  ["+Ž(F)+"] "+(F+"% ").PadLeft(5)+"    \n";if(Ä>0
)ř+="Batteries ["+Ž(Â)+"] "+(Â+"% ").PadLeft(5)+ĳ+"\n";if(n>0)ř+="PDCs      ["+Ž(Î)+"] "+(Î+"% ").PadLeft(5)+Ĳ+"\n";if(ȉ>
0)ř+="Torpedoes ["+Ž(ǻ)+"] "+(ǻ+"% ").PadLeft(5)+ı+"\n";if(e>0)ř+="Railguns  ["+Ž(Y)+"] "+(Y+"% ").PadLeft(5)+İ+"\n";if(Õ
>0)ř+="H2 Tanks  ["+Ž(Ó)+"] "+(Ó+"% ").PadLeft(5)+ĳ+"\n";if(ë>0)ř+="O2 Tanks  ["+Ž(ê)+"] "+(ê+"% ").PadLeft(5)+ĳ+"\n";if(
ү>0)ř+="Gyros     ["+Ž(ҭ)+"] "+(ҭ+"% ").PadLeft(5)+"    \n";if(ʧ>0)ř+="Cargo     ["+Ž(ʥ)+"] "+(ʥ+"% ").PadLeft(5)+
"    \n";if(Ƨ>0)ř+="Welders   ["+Ž(ƥ)+"] "+(ƥ+"% ").PadLeft(5)+"    \n";}catch{}if(Ä+H+Õ==0)ř+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+у;string į="";string Į="";foreach(Я ĭ in ğ){į+=ĭ.Ю;Į+=ĭ.Э;}int Ĭ=Ч+2;if(Ĭ>3)Ĭ-=4;ŗ+=с+į+"\n"+р;Ŗ+=Į;if(!Φ){Ř+=у;}else{
if(ʅ)Echo("Building advanced thrust...");string ī="";if(ʉ){ī=ж+(Math.Round((Ϊ/1000000),2)+" Mkg").PadLeft(15)+"\n"+ĥ+(Œ+
" ms").PadLeft(15)+"\n"+е+(ő+ĕ).PadLeft(15)+"\n"+д+(Ő+ĕ).PadLeft(15)+"\n"+Ŋ+((æ/1000000)+" MN").PadLeft(15)+"\n"+ã+((å/
1000000)+" MN").PadLeft(15)+"\n";}Ř+=ī+ň+ƍ(æ,Œ,true)+"\n"+Ň+ƍ(å,Œ)+"\n";foreach(double Ī in ʈ){Ř+=("Decel ("+(Ī*100)+"%):").
PadRight(17)+ƍ((float)(æ*Ī),Œ)+"\n";}Ř+=у;}}foreach(ѡ ĩ in α){string Ĩ="";Color Ŕ=č.ñ;if(ĩ.Ѡ)Ĩ+=ŗ;if(ĩ.џ){Ĩ+=Ŗ;Ŕ=Щ;}if(ĩ.ў)Ĩ+=Ś;
if(ĩ.ѝ)Ĩ+=ś;if(ĩ.ќ)Ĩ+=Ş;if(ĩ.Ѣ)Ĩ+=Ŝ;if(ĩ.ћ)Ĩ+=ř;if(ĩ.љ){Ĩ+=Ř;Φ=true;}ĩ.ɒ.WriteText(Ĩ,false);if(!ʊ)ĩ.ɒ.FontColor=Ŕ;}}void ş
(){if(β.Count>0){foreach(IMyTextPanel ĩ in β){ĩ.FontColor=č.ñ;}foreach(ѡ ĩ in α){ĩ.ɒ.FontColor=č.ñ;}}}void Ƃ(string Ɓ,
string ƀ){Ɓ=Ɓ.ToLower();List<IMyTextPanel>ſ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(γ);
foreach(IMyTextPanel ĩ in γ){if(ƀ==""||ĩ.CustomName.Contains(ƀ)){string ž=ĩ.CustomData;if(ž.Contains("hudlcd")&&(Ɓ=="off"||Ɓ==
"toggle"))ĩ.CustomData=ž.Replace("hudlcd","hudXlcd");if(ž.Contains("hudXlcd")&&(Ɓ=="on"||Ɓ=="toggle"))ĩ.CustomData=ž.Replace(
"hudXlcd","hudlcd");}}}string Ž(double ż){try{int Ż=0;if(ż>0){int ź=(int)ż/10;if(ź>10)return new string('=',10);if(ź!=0)Ż=ź;}char
Ź=' ';if(ż<10){if(Ч==0)return" ><    >< ";if(Ч==1)return"  ><  ><  ";if(Ч==2)return"   ><><   ";if(Ч==3)return
"<   ><   >";}string Ÿ=new string('=',Ż);string ŷ=new string(Ź,10-Ż);return Ÿ+ŷ;}catch{return"# ERROR! #";}}string Ŷ(string ŵ){
string ƃ;string ġ="";double ż=0;switch(ŵ){case"H2":ż=Math.Round(100*(Ô/Õ));ġ=ż.ToString()+" %";қ=ż;break;case"O2":ż=Math.Round
(100*(ì/ë));ġ=ż.ToString()+" %";break;case"Battery":ż=Math.Round(100*(Ã/Å));ġ=ż.ToString()+" %";break;}ƃ=Ž(ż);return" ["+
ƃ+"] "+ġ.PadLeft(9);}string Ɠ(string Ƒ,int Ɛ=Ш){int Ə=Ɛ-Ƒ.Length;int Ǝ=Ə/2+Ƒ.Length;return Ƒ.PadLeft(Ǝ).PadRight(Ɛ);}
string ƍ(double ƌ,double Ƌ,bool ƒ=false){if(ƌ<=0)return("N/A").PadLeft(15);if(ƒ)ƌ=ƌ*1.5;double Ɗ=0.5*(Math.Pow(Ƌ,2)*(Ϊ/ƌ));
double Ɖ=Ƌ/(ƌ/Ϊ);string ƈ="m";if(Ɗ>1000){ƈ="km";Ɗ=Ɗ/1000;}return(Math.Round(Ɗ)+ƈ+" "+Math.Round(Ɖ)+"s").PadLeft(15);}void Ƈ(){
foreach(IMyTextPanel Ƅ in γ){Ƅ.Enabled=true;}}void Ɔ(){foreach(ѡ ĩ in α){ĩ.ɒ.Font="Monospace";ĩ.ɒ.ContentType=ContentType.
TEXT_AND_IMAGE;if(ĩ.ɒ.CustomName.Contains("HUD1")){ĩ.Ѡ=true;ĩ.џ=false;ĩ.ў=false;ĩ.ѝ=false;ĩ.ќ=false;ĩ.Ѣ=false;ĩ.ћ=false;ĩ.љ=false;Ɉ(ĩ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ĩ.ɒ.CustomName.Contains("HUD2")){ĩ.Ѡ=false;ĩ.џ=false;ĩ.ў=true;ĩ.ѝ=false;ĩ.ќ=false;ĩ.Ѣ=false;ĩ.ћ=false;ĩ.љ
=false;Ɉ(ĩ,"hudlcd:0.22:0.99:0.55");continue;}if(ĩ.ɒ.CustomName.Contains("HUD3")){ĩ.Ѡ=false;ĩ.џ=false;ĩ.ў=false;ĩ.ѝ=true;
ĩ.ќ=false;ĩ.Ѣ=false;ĩ.ћ=false;ĩ.љ=false;Ɉ(ĩ,"hudlcd:0.48:0.99:0.55");continue;}if(ĩ.ɒ.CustomName.Contains("HUD4")){ĩ.Ѡ=
false;ĩ.џ=false;ĩ.ў=false;ĩ.ѝ=false;ĩ.ќ=false;ĩ.Ѣ=false;ĩ.ћ=true;ĩ.љ=false;Ɉ(ĩ,"hudlcd:0.74:0.99:0.55");continue;}if(ĩ.ɒ.
CustomName.Contains("HUD5")){ĩ.Ѡ=false;ĩ.џ=false;ĩ.ў=false;ĩ.ѝ=false;ĩ.ќ=true;ĩ.Ѣ=false;ĩ.ћ=false;ĩ.љ=true;Ɉ(ĩ,"hudlcd:0.75:0:.54"
);continue;}if(ĩ.ɒ.CustomName.Contains("HUD6")){ĩ.Ѡ=false;ĩ.џ=true;ĩ.ў=false;ĩ.ѝ=false;ĩ.ќ=false;ĩ.Ѣ=false;ĩ.ћ=false;ĩ.љ=
false;Ɉ(ĩ,"hudlcd:-0.55:0.99:0.7");continue;}}bool ƅ=false;foreach(IMyTextPanel Ƅ in γ){if(Ƅ==null)continue;if(!ƅ&&(Ƅ.
CustomName.Contains(ʑ)||Ƅ.CustomName.ToUpper().Contains(ʐ))){ƅ=true;Ƅ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool Ŵ;void
Ū(bool Ê,bool Ũ){Ŵ=false;foreach(IMyConveyorSorter ŧ in ί){if(ŧ!=null&&ŧ.IsFunctional){Ŵ=true;if(Ũ)ŧ.Enabled=Ê;}}}void Ŧ(
Ǘ J){if(J==Ǘ.NoChange)return;foreach(IMyReflectorLight ť in ϑ){if(ť==null)continue;if(J==Ǘ.Off)ť.Enabled=false;else{ť.
Enabled=true;if(J==Ǘ.OnMax)ť.Radius=9999;}}}void Ť(ǖ J,Color Ŕ){if(J==ǖ.NoChange)return;foreach(IMyLightingBlock Ţ in ΰ){if(Ţ==
null)continue;if(J==ǖ.Off)Ţ.Enabled=false;else Ţ.Enabled=true;if(J!=ǖ.OnNoColourChange)Ţ.SetValue("Color",Ŕ);}}void ţ(ǖ J,
Color Ŕ){if(J==ǖ.NoChange)return;foreach(IMyLightingBlock Ţ in ο){if(Ţ==null)continue;if(J==ǖ.Off)Ţ.Enabled=false;else Ţ.
Enabled=true;if(J!=ǖ.OnNoColourChange)Ţ.SetValue("Color",Ŕ);}}Color š=new Color(255,0,0,255);Color Š=new Color(255,0,0,255);
Color ũ=new Color(0,255,0,255);void ū(ǖ J){if(J==ǖ.NoChange)return;foreach(IMyLightingBlock Ţ in ρ){ų(Ţ,J,Š);}foreach(
IMyLightingBlock Ţ in ϐ){ų(Ţ,J,ũ);}}void ų(IMyLightingBlock Ţ,ǖ J,Color Ŕ){if(Ţ==null)return;if(J==ǖ.Off){Ţ.Enabled=false;Ţ.SetValue(
"Color",š);}else{Ţ.Enabled=true;if(J!=ǖ.OnNoColourChange)Ţ.SetValue("Color",Ŕ);}}int Ų=0;void ű(bool Ê,bool Ũ){Ų=0;foreach(
IMyAirVent Ű in ϒ){if(Ű!=null){if(Ũ)Ű.Enabled=Ê;if(Ű.CanPressurize)Ų++;}}}void ů(bool Ê){foreach(IMyShipConnector Ů in Ϫ){if(Ů!=
null)Ů.Enabled=Ê;}}void ŭ(bool Ê){foreach(IMyCameraBlock Ŭ in Ϭ){if(Ŭ!=null)Ŭ.Enabled=Ê;}}void ħ(bool Ê){foreach(
IMySensorBlock P in Ϣ){if(P!=null)P.Enabled=Ê;}}void µ(){Ύ=true;foreach(IMyTerminalBlock ª in ϡ){ª.ApplyAction("OnOff_On");if(ª.
IsFunctional)Ύ=false;}}bool z=false;List<string>y=new List<string>();bool x=false;List<string>w=new List<string>();void v(string p,
string o){bool u=false;List<IMyProgrammableBlock>t=new List<IMyProgrammableBlock>();try{if(o=="EFC")t=ε;else if(o=="NavOS")t=δ
;foreach(IMyProgrammableBlock s in ε){if(s==null||!s.Enabled)continue;u=(s as IMyProgrammableBlock).TryRun(p);if(u&&ʅ)
Echo("Ran "+p+" on "+s.CustomName+" successfully.");else а.Add(new ј(o+" command failed!",o+" command "+p+" failed!",1));if(
o=="EFC")z=true;else if(o=="NavOS")x=true;break;}}catch(Exception ex){а.Add(new ј(o+" command errored!",o+" command "+p+
" errored!\n"+ex.Message,3));}}void q(string p,string o){if(o=="EFC"){if(ε.Count<1)return;if(z){y.Add(p);return;}}if(o=="NavOS"){if(δ
.Count<1)return;if(x){w.Add(p);return;}}v(p,o);}void º(){if(y.Count>0&&!z){v(y[0],"EFC");y.RemoveAt(0);}if(w.Count>0&&!x)
{v(w[0],"NavOS");w.RemoveAt(0);}z=false;x=false;}int n=0;double Á=0;double Î=0;void Í(){Á=0;foreach(IMyTerminalBlock È in
ξ){Ì(È,č.ü!=Ǖ.Off&&č.ü!=Ǖ.MinDefence);}foreach(IMyTerminalBlock È in ν){Ì(È,č.ü!=Ǖ.Off);}Î=Math.Round(100*(Á/n));}void Ì(
IMyTerminalBlock Ë,bool Ê){if(Ë!=null&&Ë.IsFunctional){Á++;(Ë as IMyConveyorSorter).Enabled=Ê;}}void É(Ǖ J){if(J==Ǖ.NoChange)return;
foreach(IMyTerminalBlock È in ξ){if(È!=null&È.IsFunctional){switch(J){case Ǖ.Off:case Ǖ.MinDefence:(È as IMyConveyorSorter).
Enabled=false;break;case Ǖ.AllDefence:(È as IMyConveyorSorter).Enabled=true;if(ʾ){try{È.SetValue("WC_FocusFire",false);È.
SetValue("WC_Projectiles",true);È.SetValue("WC_Grids",true);È.SetValue("WC_LargeGrid",false);È.SetValue("WC_SmallGrid",true);È.
SetValue("WC_SubSystems",true);È.SetValue("WC_Biologicals",true);ʬ(È);}catch{Echo("Strange PDC config error! Possible WC crash!"
);}}break;case Ǖ.Offence:(È as IMyConveyorSorter).Enabled=true;if(ʾ){try{È.SetValue("WC_FocusFire",false);È.SetValue(
"WC_Projectiles",true);È.SetValue("WC_Grids",true);È.SetValue("WC_LargeGrid",true);È.SetValue("WC_SmallGrid",true);È.SetValue(
"WC_SubSystems",true);È.SetValue("WC_Biologicals",true);ʬ(È);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock È in ν){if(È!=null&È.IsFunctional){switch(J){case Ǖ.Off:(È as IMyConveyorSorter).Enabled=false;break;
case Ǖ.MinDefence:case Ǖ.AllDefence:case Ǖ.Offence:(È as IMyConveyorSorter).Enabled=true;if(ʾ){try{È.SetValue("WC_FocusFire"
,false);È.SetValue("WC_Projectiles",true);È.SetValue("WC_Grids",true);È.SetValue("WC_LargeGrid",false);È.SetValue(
"WC_SmallGrid",true);È.SetValue("WC_SubSystems",true);È.SetValue("WC_Biologicals",true);ʭ(È);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double Ç;void Æ(ǒ J){Ç=0;D();m(J);}double Å=0;double Ä=0;double Ã=0;double Â=0;void m(ǒ J){Å=0;Ã=0;double
A=0;foreach(IMyBatteryBlock I in ϭ){if(I!=null&&I.IsFunctional){Ã+=I.CurrentStoredPower;Å+=I.MaxStoredPower;A+=I.
MaxOutput;I.Enabled=true;if(J==ǒ.ManagedDischarge){if(X||G<=0)I.ChargeMode=ChargeMode.Discharge;else I.ChargeMode=ChargeMode.
Recharge;}}}Â=Math.Round(100*(A/Ä));Ç+=A;}void M(){Ä=0;foreach(IMyBatteryBlock I in ϭ){ChargeMode L=I.ChargeMode;I.ChargeMode=
ChargeMode.Auto;Ä+=I.MaxOutput;I.ChargeMode=L;}}void K(ǒ J){if(J==ǒ.NoChange)return;foreach(IMyBatteryBlock I in ϭ){if(I!=null&&!I
.Closed&&I.IsFunctional){I.Enabled=true;if(J==ǒ.Auto)I.ChargeMode=ChargeMode.Auto;else if(J==ǒ.StockpileRecharge)I.
ChargeMode=ChargeMode.Recharge;else if(J==ǒ.Discharge)I.ChargeMode=ChargeMode.Discharge;}}}double H=0;double G=0;double F=0;int E=
0;void D(){G=0;E=0;foreach(IMyReactor B in ϣ){if(B!=null&&!B.Closed&&B.IsFunctional){B.Enabled=true;if(ё(B))E++;else G+=B
.MaxOutput;}}F=Math.Round(100*(G/H));Ç+=G;}void C(){H=0;foreach(IMyReactor B in ϣ){H+=B.MaxOutput;}}void N(IMyProjector O
){O.CustomData=O.ProjectionOffset.X+"\n"+O.ProjectionOffset.Y+"\n"+O.ProjectionOffset.Z+"\n"+O.ProjectionRotation.X+"\n"+
O.ProjectionRotation.Y+"\n"+O.ProjectionRotation.Z+"\n";}void l(IMyProjector O){if(!O.IsFunctional)return;try{string[]k=O
.CustomData.Split('\n');Vector3I h=new Vector3I(int.Parse(k[0]),int.Parse(k[1]),int.Parse(k[2]));Vector3I f=new Vector3I(
int.Parse(k[3]),int.Parse(k[4]),int.Parse(k[5]));O.Enabled=true;O.ProjectionOffset=h;O.ProjectionRotation=f;O.
UpdateOffsetAndRotation();}catch{if(ʅ)Echo("Failed to load projector position for "+O.Name);}}int e=0;double Z=0;double Y=0;bool X=false;void W
(){X=false;Z=0;foreach(IMyTerminalBlock S in μ){if(S!=null&&S.IsFunctional){Z++;(S as IMyConveyorSorter).Enabled=č.û!=ǔ.
Off;if(!X){MyDetectedEntityInfo?V=ǣ.Ț(S);if(V.HasValue){string U=V.Value.Name;if(U!=null&&U!=""){if(ʅ)Echo(
"At least one rail has a target!");X=true;}}}}}foreach(IMyTerminalBlock S in λ){if(S!=null&&S.IsFunctional){Z++;(S as IMyConveyorSorter).Enabled=č.û!=ǔ.
Off;}}Y=Math.Round(100*(Z/e));}void R(ǔ J){if(J==ǔ.NoChange)return;foreach(IMyTerminalBlock Q in μ){Ï(Q,J,false);}foreach(
IMyTerminalBlock Q in λ){Ï(Q,J,true);}}void Ï(IMyTerminalBlock Q,ǔ J,bool Ā){if(Q!=null&Q.IsFunctional){if(J==ǔ.Off){(Q as
IMyConveyorSorter).Enabled=false;}else{(Q as IMyConveyorSorter).Enabled=true;if(!Ā){if(ʾ){Q.SetValue("WC_Grids",true);Q.SetValue(
"WC_LargeGrid",true);Q.SetValue("WC_SmallGrid",true);Q.SetValue("WC_SubSystems",true);ʬ(Q);}if(ʽ){if(J==ǔ.OpenFire){ʩ(Q);}else{ʪ(Q);}}
}}}}class ÿ{public string þ="";public Ƣ ý;public Ǖ ü;public ǔ û;public Ǔ ú;public ǘ ù;public Ǘ ø;public ǖ ö;public Color
õ;public ǖ ô;public Color ó;public ǖ ò;public Color ñ;public ǒ ā;public int ð;public Ƣ Ă;public ǂ Ĕ;public Ƣ Ē;public ǁ đ
;public Ƣ Đ;public ǀ ď;}string Ď="N/A";ÿ č;Ƣ Č=Ƣ.On;Ǖ ē=Ǖ.Offence;ǔ ċ=ǔ.OpenFire;Ǔ Ċ=Ǔ.On;ǘ ĉ=ǘ.On;Ǘ Ĉ=Ǘ.On;ǖ ć=ǖ.On;
Color Ć=new Color(33,144,255,255);ǖ ą=ǖ.On;Color Ą=new Color(255,214,170,255);ǖ ă=ǖ.On;Color ï=new Color(33,144,255,255);ǒ â=
ǒ.Auto;int Ð=-1;Ƣ à=Ƣ.NoChange;ǂ ß=ǂ.NoChange;Ƣ Þ=Ƣ.NoChange;ǁ Ý=ǁ.KeepFull;Ƣ Ü=Ƣ.On;ǀ Û=ǀ.NoChange;void Ú(string Ù){ÿ Ø;
if(!ҕ.TryGetValue(Ù,out Ø)){а.Add(new ј("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ʅ)Echo("Setting stance '"+Ù+"'.");č=Ø;Ď=Ù;ѧ();if(ʅ)Echo("Setting "+μ.Count+" railguns to "+č.û);R(č.û);
if(ʅ)Echo("Setting "+κ.Count+" torpedoes to "+č.ý);Ǥ(č.ý);if(ʅ)Echo("Setting "+ξ.Count+" _normalPdcs, "+ν.Count+
" defence _normalPdcs to "+č.ü);É(č.ü);if(ʅ)Echo("Setting "+ι.Count+" epsteins, "+η.Count+" chems"+" to "+č.ú);ȁ(č.ú,č.ù);if(ʅ)Echo("Setting "+θ.
Count+" rcs, "+ζ.Count+" atmos"+" to "+č.ù);ȏ(č.ù);if(ʅ)Echo("Setting "+ϭ.Count+" batteries to = "+č.ā);K(č.ā);if(ʅ)Echo(
"Setting "+Ϡ.Count+" H2 tanks to stockpile = "+č.ā);î(č.ā);if(ʅ)Echo("Setting "+ϟ.Count+" O2 tanks to stockpile = "+č.ā);ç(č.ā);if
(ʋ){if(ʅ)Echo("No lighting was set because lighting control is disabled.");}else{if(ʅ)Echo("Setting "+ϑ.Count+
" spotlights to "+č.ø);Ŧ(č.ø);if(ʅ)Echo("Setting "+ΰ.Count+" exterior lights to "+č.ö);Ť(č.ö,č.õ);if(ʅ)Echo("Setting "+ο.Count+
" exterior lights to "+č.ô);ţ(č.ô,č.ó);if(ʅ)Echo("Setting "+ρ.Count+" port nav lights, "+ϐ.Count+" starboard nav lights to "+č.ò);ū(č.ò);}if(ʅ
)Echo("Setting "+Ϗ.Count+" aux block to "+č.Ē);ϓ(č.Ē);if(ʅ)Echo("Setting "+Ϩ.Count+" extrators to "+č.đ);Ҩ(č.đ);if(ʅ)Echo
("Setting "+ϰ.Count+" hangar doors units to "+č.ď);ӊ(č.ď);if(č.û==ǔ.OpenFire){if(ʅ)Echo("Setting "+ύ.Count+
" doors to locked because we are in combat (rails set to open fire).");ҧ("locked","");}if(ʅ)Echo("Setting "+β.Count+" colour sync Lcds.");ş();if(č.Ĕ==ǂ.Abort){q("Off","EFC");q("Abort",
"NavOS");}if(č.ð>0){q("Set Burn "+č.ð,"EFC");q("Thrust Set "+č.ð/100,"NavOS");}if(č.Ă==Ƣ.On)q("Boost On","EFC");else if(č.Ă==Ƣ.
Off)q("Boost Off","EFC");if(ʅ)Echo("Finished setting stance.");}double Ö=0;double Õ=0;double Ô=0;double Ó=0;void Ò(){Ô=0;Ö=
0;foreach(IMyGasTank Ñ in Ϡ){if(Ñ.IsFunctional){Ñ.Enabled=true;Ö+=Ñ.Capacity;Ô+=(Ñ.Capacity*Ñ.FilledRatio);}}Ó=Math.Round
(100*(Ö/Õ));}void á(){Õ=0;foreach(IMyGasTank Ñ in Ϡ){if(Ñ!=null)Õ+=Ñ.Capacity;}}void î(ǒ J){if(J==ǒ.NoChange)return;
foreach(IMyGasTank Ñ in Ϡ){if(Ñ==null)continue;Ñ.Enabled=true;if(J==ǒ.StockpileRecharge)Ñ.Stockpile=true;else Ñ.Stockpile=false
;}}double í=0;double ì=0;double ë=0;double ê=0;void é(){ì=0;í=0;foreach(IMyGasTank Ñ in ϟ){if(Ñ.IsFunctional){Ñ.Enabled=
true;í+=Ñ.Capacity;ì+=(Ñ.Capacity*Ñ.FilledRatio);}}ê=Math.Round(100*(í/ë));}void è(){ë=0;foreach(IMyGasTank Ñ in ϟ){if(Ñ!=
null)ë+=Ñ.Capacity;}}void ç(ǒ J){if(J==ǒ.NoChange)return;foreach(IMyGasTank Ñ in ϟ){if(Ñ==null)continue;Ñ.Enabled=true;if(J
==ǒ.StockpileRecharge)Ñ.Stockpile=true;else Ñ.Stockpile=false;}}float æ;float å;float ä;double À;void Ɣ(){float ƶ=0;float
Ȇ=0;float Ȅ=0;float ȃ=0;foreach(IMyThrust ǿ in ι){if(ǿ!=null&&ǿ.IsFunctional){ƶ+=ǿ.MaxThrust;Ȅ+=ǿ.CurrentThrust;if(ǿ.
Enabled){Ȇ+=ǿ.MaxThrust;ȃ+=ǿ.CurrentThrust;}}}À=Math.Round(100*(ƶ/ä));if(Ȇ==0){æ=ƶ;å=Ȅ;}else{æ=Ȇ;å=ȃ;}}void Ȃ(){ä=0;foreach(
IMyThrust ǿ in ι){if(ǿ!=null)ä+=ǿ.MaxThrust;}}void ȁ(Ǔ J,ǘ Ǿ){if(J==Ǔ.NoChange)return;foreach(IMyThrust ǿ in ι){Ȁ(ǿ,J,Ǿ);}foreach
(IMyThrust ǿ in η){Ȁ(ǿ,J,Ǿ,true);}}void Ȁ(IMyThrust ǿ,Ǔ J,ǘ Ǿ,bool ǽ=false){bool ȅ=ǿ.CustomName.Contains(ʣ);if(ȅ){if(Ǿ!=ǘ
.Off&&Ǿ!=ǘ.AtmoOnly)ǿ.Enabled=true;else ǿ.Enabled=false;}else{bool Ǽ=ǿ.CustomName.Contains(ʲ);if((J==Ǔ.On)||(J==Ǔ.Minimum
&&Ǽ)||(J==Ǔ.EpsteinOnly&&!ǽ)||(J==Ǔ.ChemOnly&&ǽ)){ǿ.Enabled=true;}else{ǿ.Enabled=false;}}}float ȇ;float ȓ;double Ȓ;void ȑ(
){ȇ=0;foreach(IMyThrust ǿ in θ){if(ǿ!=null&&ǿ.IsFunctional){ȇ+=ǿ.MaxThrust;}}Ȓ=Math.Round(100*(ȇ/ȓ));}void Ȑ(){ȓ=0;
foreach(IMyThrust ǿ in θ){if(ǿ!=null)ȓ+=ǿ.MaxThrust;}}void ȏ(ǘ J){foreach(IMyThrust ǿ in θ){if(ǿ!=null)ȍ(ǿ,J);}foreach(
IMyThrust ǿ in ζ){if(ǿ!=null)ȍ(ǿ,J,true);}}void ȍ(IMyThrust ǿ,ǘ J,bool Ȍ=false){bool ȋ=ǿ.GridThrustDirection==Vector3I.Backward;
bool Ȋ=ǿ.GridThrustDirection==Vector3I.Forward;if((J==ǘ.On)||(J==ǘ.ForwardOff&&!ȋ)||(J==ǘ.ReverseOff&&!Ȋ)||(J==ǘ.RcsOnly&&!Ȍ
)||(J==ǘ.AtmoOnly&&Ȍ)){ǿ.Enabled=true;}else{ǿ.Enabled=false;}}int ȉ=0;double Ȉ=0;double ǻ=0;void ǧ(){Ȉ=0;foreach(
IMyTerminalBlock Ǚ in κ){if(Ǚ!=null&&Ǚ.IsFunctional){Ȉ++;(Ǚ as IMyConveyorSorter).Enabled=č.ý==Ƣ.On;if(ˀ){string ǥ=ǣ.Ƹ(Ǚ,0);int ė=њ(ǥ);
if(ʅ)Echo("Launcher "+Ǚ.CustomName+" needs "+ǥ+"("+ė+")");Ͼ(Ǚ,ė);}}}ǻ=Math.Round(100*(Ȉ/ȉ));}void Ǥ(Ƣ J){if(J==Ƣ.NoChange)
return;foreach(IMyTerminalBlock Ǚ in κ){if(Ǚ!=null&Ǚ.IsFunctional){if(J==Ƣ.Off){(Ǚ as IMyConveyorSorter).Enabled=false;}else{(
Ǚ as IMyConveyorSorter).Enabled=true;if(ʾ){Ǚ.SetValue("WC_FocusFire",true);Ǚ.SetValue("WC_Grids",true);Ǚ.SetValue(
"WC_LargeGrid",true);Ǚ.SetValue("WC_SmallGrid",false);Ǚ.SetValue("WC_FocusFire",true);Ǚ.SetValue("WC_SubSystems",true);ʬ(Ǚ);}}}}}Ǣ ǣ;
class Ǣ{private Action<ICollection<MyDefinitionId>>ǡ;private Action<ICollection<MyDefinitionId>>Ǡ;private Action<ICollection<
MyDefinitionId>>ǟ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>Ǟ;private Func<long,MyTuple<bool,
int,int>>ǝ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>ǜ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>Ǜ;private Func<long,int,
MyDetectedEntityInfo>ǚ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ǧ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>Ǩ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>ǹ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>Ǻ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>Ǹ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>Ƿ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ƕ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>ǵ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>Ǵ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǳ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>ǲ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>Ǳ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǰ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>ǯ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ǯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>ǭ;private Func<MyDefinitionId,float>Ǭ;private Func<long,bool>ǫ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>Ǫ;private Func<long,float>Ȏ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ȕ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ƚ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>ȷ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>ȵ;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>ȴ;private Func<long,float>ȳ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ȳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ȱ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȱ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ȯ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>Ȯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>ȭ;public bool Ȭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȫ){var Ȫ=ȫ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(ȫ);if(Ȫ==null)throw new Exception("WcPbAPI failed to activate");return ȩ(Ȫ);}public bool ȩ
(IReadOnlyDictionary<string,Delegate>ȧ){if(ȧ==null)return false;Ȩ(ȧ,"GetCoreWeapons",ref ǡ);Ȩ(ȧ,"GetCoreStaticLaunchers",
ref Ǡ);Ȩ(ȧ,"GetCoreTurrets",ref ǟ);Ȩ(ȧ,"GetBlockWeaponMap",ref Ǟ);Ȩ(ȧ,"GetProjectilesLockedOn",ref ǝ);Ȩ(ȧ,
"GetSortedThreats",ref ǜ);Ȩ(ȧ,"GetObstructions",ref Ǜ);Ȩ(ȧ,"GetAiFocus",ref ǚ);Ȩ(ȧ,"SetAiFocus",ref Ǧ);Ȩ(ȧ,"GetWeaponTarget",ref Ǩ);Ȩ(ȧ,
"SetWeaponTarget",ref ǹ);Ȩ(ȧ,"FireWeaponOnce",ref Ǻ);Ȩ(ȧ,"ToggleWeaponFire",ref Ǹ);Ȩ(ȧ,"IsWeaponReadyToFire",ref Ƿ);Ȩ(ȧ,
"GetMaxWeaponRange",ref Ƕ);Ȩ(ȧ,"GetTurretTargetTypes",ref ǵ);Ȩ(ȧ,"SetTurretTargetTypes",ref Ǵ);Ȩ(ȧ,"SetBlockTrackingRange",ref ǳ);Ȩ(ȧ,
"IsTargetAligned",ref ǲ);Ȩ(ȧ,"IsTargetAlignedExtended",ref Ǳ);Ȩ(ȧ,"CanShootTarget",ref ǰ);Ȩ(ȧ,"GetPredictedTargetPosition",ref ǯ);Ȩ(ȧ,
"GetHeatLevel",ref Ǯ);Ȩ(ȧ,"GetCurrentPower",ref ǭ);Ȩ(ȧ,"GetMaxPower",ref Ǭ);Ȩ(ȧ,"HasGridAi",ref ǫ);Ȩ(ȧ,"HasCoreWeapon",ref Ǫ);Ȩ(ȧ,
"GetOptimalDps",ref Ȏ);Ȩ(ȧ,"GetActiveAmmo",ref Ȕ);Ȩ(ȧ,"SetActiveAmmo",ref Ƚ);Ȩ(ȧ,"MonitorProjectile",ref ȷ);Ȩ(ȧ,"UnMonitorProjectile",
ref ȵ);Ȩ(ȧ,"GetProjectileState",ref ȴ);Ȩ(ȧ,"GetConstructEffectiveDps",ref ȳ);Ȩ(ȧ,"GetPlayerController",ref Ȳ);Ȩ(ȧ,
"GetWeaponAzimuthMatrix",ref ȱ);Ȩ(ȧ,"GetWeaponElevationMatrix",ref Ȱ);Ȩ(ȧ,"IsTargetValid",ref ȯ);Ȩ(ȧ,"GetWeaponScope",ref Ȯ);Ȩ(ȧ,"IsInRange",ref
ȭ);return true;}private void Ȩ<ȶ>(IReadOnlyDictionary<string,Delegate>ȧ,string ȸ,ref ȶ Ʉ)where ȶ:class{if(ȧ==null){Ʉ=null
;return;}Delegate ɂ;if(!ȧ.TryGetValue(ȸ,out ɂ))throw new Exception(
$"{GetType().Name} :: Couldn't find {ȸ} delegate of type {typeof(ȶ)}");Ʉ=ɂ as ȶ;if(Ʉ==null)throw new Exception(
$"{GetType().Name} :: Delegate {ȸ} is not type {typeof(ȶ)}, instead it's: {ɂ.GetType()}");}public void Ɂ(ICollection<MyDefinitionId>ǩ)=>ǡ?.Invoke(ǩ);public void ɀ(ICollection<MyDefinitionId>ǩ)=>Ǡ?.Invoke(ǩ);
public void ȿ(ICollection<MyDefinitionId>ǩ)=>ǟ?.Invoke(ǩ);public bool Ƀ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ⱦ,IDictionary<
string,int>ǩ)=>Ǟ?.Invoke(Ⱦ,ǩ)??false;public MyTuple<bool,int,int>ȼ(long Ȼ)=>ǝ?.Invoke(Ȼ)??new MyTuple<bool,int,int>();public
void Ⱥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȝ,IDictionary<MyDetectedEntityInfo,float>ǩ)=>ǜ?.Invoke(Ȝ,ǩ);public void ȹ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȝ,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>ǩ)=>Ǜ?.Invoke(Ȝ,ǩ);public
MyDetectedEntityInfo?Ȟ(long ȕ,int ț=0)=>ǚ?.Invoke(ȕ,ț);public bool ȝ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȝ,long Ș,int ț=0)=>Ǧ?.Invoke(Ȝ,Ș
,ț)??false;public MyDetectedEntityInfo?Ț(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ=0)=>Ǩ?.Invoke(ƕ,Ɩ);public void ș(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long Ș,int Ɩ=0)=>ǹ?.Invoke(ƕ,Ș,Ɩ);public void ȗ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
ƕ,bool Ȗ=true,int Ɩ=0)=>Ǻ?.Invoke(ƕ,Ȗ,Ɩ);public void ȟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,bool Ȧ,bool Ȗ,int Ɩ=0)=>Ǹ
?.Invoke(ƕ,Ȧ,Ȗ,Ɩ);public bool ȥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ=0,bool Ȥ=true,bool ȣ=false)=>Ƿ?.Invoke(ƕ,Ɩ
,Ȥ,ȣ)??false;public float Ȣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>Ƕ?.Invoke(ƕ,Ɩ)??0f;public bool ȡ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock ƕ,IList<string>ǩ,int Ɩ=0)=>ǵ?.Invoke(ƕ,ǩ,Ɩ)??false;public void Ƞ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ƕ,IList<string>ǩ,int Ɩ=0)=>Ǵ?.Invoke(ƕ,ǩ,Ɩ);public void ơ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,float Ƶ)=>ǳ?.Invoke(
ƕ,Ƶ);public bool ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ư,int Ɩ)=>ǲ?.Invoke(ƕ,ư,Ɩ)??false;public MyTuple<bool,
Vector3D?>Ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ư,int Ɩ)=>Ǳ?.Invoke(ƕ,ư,Ɩ)??new MyTuple<bool,Vector3D?>();public bool
Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ư,int Ɩ)=>ǰ?.Invoke(ƕ,ư,Ɩ)??false;public Vector3D?Ʊ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock ƕ,long ư,int Ɩ)=>ǯ?.Invoke(ƕ,ư,Ɩ)??null;public float ƿ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>Ǯ?.
Invoke(ƕ)??0f;public float ƽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>ǭ?.Invoke(ƕ)??0f;public float Ƽ(MyDefinitionId ƻ)=>Ǭ?.
Invoke(ƻ)??0f;public bool ƺ(long ƙ)=>ǫ?.Invoke(ƙ)??false;public bool ƾ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>Ǫ?.Invoke(ƕ)
??false;public float ƹ(long ƙ)=>Ȏ?.Invoke(ƙ)??0f;public string Ƹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>Ȕ?.
Invoke(ƕ,Ɩ)??null;public void Ʒ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ,string Ư)=>Ƚ?.Invoke(ƕ,Ɩ,Ư);public void Ơ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ,Action<long,int,ulong,long,Vector3D,bool>Ɲ)=>ȷ?.Invoke(ƕ,Ɩ,Ɲ);public void ƞ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ,Action<long,int,ulong,long,Vector3D,bool>Ɲ)=>ȵ?.Invoke(ƕ,Ɩ,Ɲ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ɯ(ulong ƛ)=>ȴ?.Invoke(ƛ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ƚ(long ƙ)=>ȳ?.Invoke(ƙ)??0f;public long Ƙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>Ȳ?.Invoke(ƕ)??-1;public
Matrix Ɨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>ȱ?.Invoke(ƕ,Ɩ)??Matrix.Zero;public Matrix Ɵ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ƕ,int Ɩ)=>Ȱ?.Invoke(ƕ,Ɩ)??Matrix.Zero;public bool Ʈ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ƭ,bool Ƭ,bool ƫ)=>ȯ?.
Invoke(ƕ,ƭ,Ƭ,ƫ)??false;public MyTuple<Vector3D,Vector3D>ƪ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>Ȯ?.Invoke(ƕ,Ɩ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>Ʃ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƨ)=>ȭ?.Invoke(ƨ)??new MyTuple<
bool,bool>();}int Ƨ=0;double Ʀ=0;double ƥ=0;void Ƥ(){Ʀ=0;foreach(IMyTerminalBlock ƣ in π){if(ƣ!=null&&ƣ.IsFunctional)Ʀ++;}ƥ=
Math.Round(100*(Ʀ/Ƨ));}enum Ƣ{
    Off, On, NoChange
    }enum ǖ{
    Off, On, NoChange, OnNoColourChange
    }enum Ǖ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum ǔ{
    Off, HoldFire, OpenFire, NoChange
    }enum Ǔ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum ǘ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum Ǘ{
    On, Off, OnMax, NoChange
    }enum ǒ{
    Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
    }enum ǂ{
    Abort, NoChange
    }enum ǁ{
    Off, On, FillWhenLow, KeepFull,
    }enum ǀ{
    Closed, Open, NoChange
    }
}sealed class ǃ{public double Ǆ{get;private set;}private double ǐ{get{double Ǒ=ǈ[0];for(int ĝ=1;ĝ<Ǌ;ĝ++){Ǒ+=ǈ[ĝ];}return(
Ǒ/Ǌ);}}public double Ǐ{get{double ǎ=ǈ[0];for(int ĝ=1;ĝ<Ǌ;ĝ++){if(ǈ[ĝ]>ǎ){ǎ=ǈ[ĝ];}}return ǎ;}}public double Ǎ{get;private
set;}public double ǌ{get{double ǋ=ǈ[0];for(int ĝ=1;ĝ<Ǌ;ĝ++){if(ǈ[ĝ]<ǋ){ǋ=ǈ[ĝ];}}return ǋ;}}public int Ǌ{get;}private double
ǉ;private IMyGridProgramRuntimeInfo ǆ;private double[]ǈ;private int Ǉ=0;public ǃ(IMyGridProgramRuntimeInfo ǆ,int ҩ=300){
this.ǆ=ǆ;this.Ǎ=ǆ.LastRunTimeMs;this.Ǌ=MathHelper.Clamp(ҩ,1,int.MaxValue);this.ǉ=1.0/Ǌ;this.ǈ=new double[ҩ];this.ǈ[Ǉ]=ǆ.
LastRunTimeMs;this.Ǉ++;}public void ǅ(){Ǆ-=ǈ[Ǉ]*ǉ;Ǆ+=ǆ.LastRunTimeMs*ǉ;ǈ[Ǉ]=ǆ.LastRunTimeMs;if(ǆ.LastRunTimeMs>Ǎ){Ǎ=ǆ.LastRunTimeMs;}
Ǉ++;if(Ǉ>=Ǌ){Ǉ=0;Ǆ=ǐ;Ǎ=ǆ.LastRunTimeMs;}}