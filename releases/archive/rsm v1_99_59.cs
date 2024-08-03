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

string Version = "1.99.59 (2024-05-12)";
ǂ Ζ;int Ε=0;int Δ=0;int Γ=0;int Β;int Α=0;bool ΐ=true;bool Ώ=true;bool Ύ=false;bool Ό=false;bool Ί=false;bool Ή=false;
bool Έ=false;bool Ά=false;bool Η=false;string Θ="";int Χ=0;int Ψ=0;double Φ;float Υ;string Τ;string Σ;string Ρ;bool Π=false;
int Ο=0;int Ξ=0;bool Ν;bool Μ;bool Λ;Program(){Echo("Welcome to RSM\nV "+Version);ͺ();Β=ʐ;Τ=Me.GetOwnerFactionTag();Ζ=new ǂ
(Runtime);Ͼ();ʆ.Add(0.5);ʆ.Add(0.25);ʆ.Add(0.1);ʆ.Add(0.05);Ł();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo(
"Took "+ͺ());}void Main(string v,UpdateType Κ){if(Κ==UpdateType.Update100)ˊ();else Ι(v);}void Ι(string v){if(ʃ)Echo(
"Processing command '"+v+"'...");if(Ώ){ˌ(v,"RSM is still booting");return;}if(Ύ){ˌ(v,"RSM is still initialising");return;}if(v==""){ˌ(v,
"the argument was blank");return;}string[]ͽ=v.Split(':');if(ͽ.Length<2){ˌ(v,"the argument wasn't recognised");return;}if(ͽ[0].ToLower()!="comms"
)ͽ[1]=ͽ[1].Replace(" ",string.Empty);switch(ͽ[0].ToLower()){case"init":bool ˁ=true,ˑ=true,ː=true;if(ͽ.Length>2){foreach(
string ˏ in ͽ){if(ˏ.ToLower()=="nonames")ˁ=false;else if(ˏ.ToLower()=="nosubs")ˑ=false;else if(ˏ.ToLower()=="noinv")ː=false;}}
ӄ(ͽ[1],ˁ,ˑ,ː);return;case"stance":Ú(ͽ[1]);return;case"hudlcd":string ˎ="";if(ͽ.Length>2)ˎ=ͽ[2];Ɓ(ͽ[1],ˎ);return;case
"doors":string ˍ="";if(ͽ.Length>2)ˍ=ͽ[2];Ҕ(ͽ[1],ˍ);return;case"comms":Ͱ(ͽ[1]);return;case"printblockids":ɗ();return;case
"printblockprops":ɓ(ͽ[1]);return;case"spawn":if(ͽ[1].ToLower()=="open"){Έ=true;Β=ʐ;}else{Έ=false;Β=ʐ;}return;case"projectors":if(ͽ[1].
ToLower()=="save"){foreach(IMyProjector k in Ϟ)m(k);Ъ.Add(new ѓ("Projector positions saved",
"Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector k in Ϟ)l(k);Ъ.Add(new ѓ("Projector positions loaded",
"Projector positions were loaded from custom data.",2));return;}default:ˌ(v,"the argument wasn't recognised");return;}}void ˌ(string v,string ˋ){Ъ.Add(new ѓ(
"COMMAND FAILED!","Command '"+v+"' was ignored because "+ˋ,3));}void ˊ(){if(ʂ)ͺ();if(Δ<ʁ){Δ++;return;}Δ=0;if(ΐ){Echo(
"Parsing custom data...");Ѧ();ΐ=false;return;}else if(Ύ){Ў();if(ʃ)Echo("Updating "+ά.Count+" RSM Lcds");ĺ();}ˢ();Ο=Runtime.
CurrentInstructionCount;if(Ο>Ξ)Ξ=Runtime.CurrentInstructionCount;if(Đ.Ĕ==Ơ.On){Ό=true;Ί=true;}else if(Đ.Ĕ==Ơ.Off){Ό=true;}if(Β>=ʐ){Β=0;ˆ();
return;}Β++;ˉ();ˈ();if(ʂ)Echo("Took "+ͺ());if(ʃ)Echo("Updating "+ά.Count+" RSM Lcds");ĺ();if(ʂ)Echo("Took "+ͺ());}void ˉ(){ˠ()
;switch(Ε){case 0:if(ʃ)Echo("Refreshing "+ζ.Count+" railguns...");V();if(ʂ)Echo("Took "+ͺ());if(Ώ)break;else goto case 1;
case 1:if(ʃ)Echo("Refreshing "+ϝ.Count+" reactors & "+Ϧ.Count+" batteries...");Ä(Đ.ò);if(ʂ)Echo("Took "+ͺ());if(Ώ)break;else
goto case 2;case 2:if(ʃ)Echo("Refreshing "+δ.Count+" epsteins...");â();if(ʂ)Echo("Took "+ͺ());if(Ώ)break;else goto case 3;
case 3:if(ʃ)Echo("Refreshing "+ι.Count+" lidars...");ŧ(Ί,Ό);if(ʂ)Echo("Took "+ͺ());if(ʃ)Echo("Refreshing pb servers...");Í()
;if(ʂ)Echo("Took "+ͺ());if(Ώ)break;else goto case 4;case 4:if(ʃ)Echo("Refreshing "+ψ.Count+" doors...");Ӂ();if(ʂ)Echo(
"Took "+ͺ());if(ʃ)Echo("Refreshing "+χ.Count+" airlocks...");Ӊ();if(ʂ)Echo("Took "+ͺ());break;default:if(ʃ)Echo(
"Booting complete");Ώ=false;Ε=0;return;}if(Ώ)Ε++;}void ˈ(){switch(Γ){case 0:if(ʃ)Echo("Clearing temp inventories...");Ͻ();if(ʂ)Echo(
"Took "+ͺ());if(ʃ)Echo("Refreshing "+ε.Count+" torpedo launchers...");Ǽ();if(ʂ)Echo("Took "+ͺ());if(ʃ)Echo(
"Refreshing items...");ϼ();if(ʂ)Echo("Took "+ͺ());break;case 1:if(ʃ)Echo("Running autoload...");ˤ();if(ʂ)Echo("Took "+ͺ());break;case 2:if(ʃ)
Echo("Refreshing "+Ϛ.Count+" H2 tanks...");Ò();if(ʂ)Echo("Took "+ͺ());if(ʃ)Echo("Refreshing refuel status...");Ү();if(Ή){if(
ʃ)Echo("Fuel low, filling extractors...");Ҭ();if(ʂ)Echo("Took "+ͺ());return;}else{ˇ();if(ʂ)Echo("Took "+ͺ());}Γ=0;return;
}Γ++;}void ˇ(){if(ʃ)Echo("Refreshing "+γ.Count+" rcs...");Ȓ();if(ʃ)Echo("Refreshing "+θ.Count+" Pdcs & "+η.Count+
" defensive Pdcs...");Ê();if(ʃ)Echo("Refreshing "+ϟ.Count+" gyros...");ҥ(Ί,Ό);if(ʃ)Echo("Refreshing "+ύ.Count+" O2 tanks...");é();if(ʃ)Echo(
"Refreshing "+ϧ.Count+" antennas...");ͱ();if(ʃ)Echo("Refreshing "+Ϥ.Count+" cargos...");ʢ();if(ʃ)Echo("Refreshing "+λ.Count+
" vents...");ů(Ί,Ό);if(ʃ)Echo("Refreshing "+ϊ.Count+" auxiliary blocks...");ϐ();if(ʃ)Echo("Refreshing "+Ϊ.Count+" welders...");Ƣ();
if(ʃ)Echo("Refreshing "+ή.Count+" lcds...");Ɔ();if(ʃ)Echo("Refreshing "+ϛ.Count+" lcds...");º();if(Ό){if(ʃ)Echo(
"Refreshing "+ϣ.Count+" connectors...");ŭ(Ί);if(ʃ)Echo("Refreshing "+ϥ.Count+" cameras...");ū(Ί);if(ʃ)Echo("Refreshing "+Ϝ.Count+
" sensors...");P(Ί);}}void ˆ(){if(ʃ)Echo("Clearing block lists...");ɮ();if(ʂ)Echo("Took "+ͺ());if(ʃ)Echo("Refreshing block lists...")
;GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,υ);if(ʂ)Echo("Took "+ͺ());if(ʃ)Echo(
"Setting KeepFull threshold");ҭ();if(Ϩ==null){if(Ϫ.Count>0)Ϩ=Ϫ[0];else Ъ.Add(new ѓ("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ʃ)Echo("Finished block refresh.");if(ʂ)Echo("Took "+ͺ());}void ˠ(){try{Ǥ=new ǣ();Ǥ.Ȯ(Me);}catch(Exception ex){Ǥ
=null;Ъ.Add(new ѓ("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ˢ(){string ͻ="REEDIT SHIP MANAGEMENT \n\n";if(Ώ)ͻ+="Booting, please wait ("+Ε+"/5)...\n\n";ͻ+=
"|- V "+Version+"\n|- Ship Name: "+ʒ+"\n|- Stance: "+đ+"\n|- Step: "+Β+"/"+ʐ+" ("+Γ+")";if(ʂ){Ζ.Ǆ();ͻ+="\n|- Runtime Av/Tick: "
+(Math.Round(Ζ.ǃ,2)/100)+" ms"+"\n|- Runtime Max: "+Math.Round(Ζ.ǎ,4)+" ms"+"\n|- Instructions: "+Ο+" ("+Ξ+")";}Echo(ͻ+
"\n");}long ͼ=0;string ͺ(){long ͷ=DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;if(ͼ==0){ͼ=ͷ;return"0 ms";}long Ͷ=ͷ-ͼ;ͼ=ͷ;
return Ͷ+" ms";}bool ʹ=false;string ͳ="";double Ͳ=0;void ͱ(){ʹ=false;Ͳ=0;foreach(IMyRadioAntenna ˬ in ϧ){if(ˬ!=null&&!ˬ.Closed
&&ˬ.IsFunctional){float ƴ=ˬ.Radius;if(ƴ>Ͳ)Ͳ=ƴ;if(ˬ.IsBroadcasting&&ˬ.Enabled)ʹ=true;}}}void Ͱ(string ˮ){ͳ=ˮ;foreach(
IMyTerminalBlock ɒ in ϧ){IMyRadioAntenna ˬ=ɒ as IMyRadioAntenna;if(ˬ!=null)ˬ.HudText=ˮ;}}void ˤ(){if(!ʽ)return;foreach(var ɭ in ϯ){if(!ɭ
.ϴ&&!ɭ.ϳ)continue;if(ʃ)Echo("Checking "+ɭ.ϲ);List<Ж>ˡ=ɭ.ϸ.Concat(ɭ.Ϸ).ToList();List<Ж>ˣ=new List<Ж>();List<Ж>Ω=new List<Ж
>();List<Ж>ϙ=new List<Ж>();List<Ж>Ϙ=new List<Ж>();List<Ж>ϗ=new List<Ж>();int ϖ=0;int ϕ=0;double ϔ=.97;if(ɭ.ϰ<1)ϔ=ɭ.ϰ*.97;
foreach(Ж ϓ in ˡ){if(ϓ==null)continue;if(ϓ.Г){ϕ++;ϖ+=ϓ.Д;if(ϓ.В<ϔ)ϙ.Add(ϓ);else if(ɭ.ϰ<1&&ϓ.В>ɭ.ϰ*1.03)Ϙ.Add(ϓ);if(ϓ.В!=0)Ω.Add
(ϓ);}else{ϗ.Add(ϓ);if(ϓ.Д>0){ˣ.Add(ϓ);}}}if(ϙ.Count>0){int ϒ=(int)(ϖ/ϕ);ϙ=ϙ.OrderBy(Ĵ=>Ĵ.Д).ToList();if(ɭ.ϭ>0){if(ʃ)Echo(
"Loading "+ɭ.ϵ.SubtypeId+"...");ˣ=ˣ.OrderByDescending(Ĵ=>Ĵ.Д).ToList();щ(ˣ,ϙ,ɭ.ϵ,-1,ɭ.ϰ);}else{if(ʃ)Echo("Balancing "+ɭ.ϵ.
SubtypeId+"...");Ω=Ω.OrderByDescending(Ĵ=>Ĵ.Д).ToList();щ(Ω,ϙ,ɭ.ϵ,ϒ);}}else if(Ϙ.Count>0){if(ʃ)Echo("Unloading "+ɭ.ϵ.SubtypeId+
"...");List<Ж>ϑ=new List<Ж>();if(ˣ.Count>0)ϑ=ˣ;else ϑ=ϗ;щ(Ϙ,ϑ,ɭ.ϵ,-1,1,ɭ.ϰ);}else{if(ʃ)Echo("No loading required "+ɭ.ϵ.
SubtypeId+"...");}}}void ϐ(){Ψ=0;foreach(IMyTerminalBlock ɒ in ϊ){if(ɒ==null)continue;if(ɒ.IsWorking)Ψ++;}}void Ϗ(Ơ H){if(H==Ơ.
NoChange)return;foreach(IMyTerminalBlock ɒ in ϊ){if(ɒ==null)continue;try{bool ώ=ɒ.BlockDefinition.ToString().Contains("ToolCore"
);if(H==Ơ.On||ώ)ɒ.ApplyAction("OnOff_On");else if(!ώ)ɒ.ApplyAction("OnOff_Off");if(ώ){ITerminalAction Ɲ=ɒ.
GetActionWithName("ToolCore_Shoot_Action");if(Ɲ!=null){StringBuilder ϫ=new StringBuilder();Ɲ.WriteValue(ɒ,ϫ);string ϩ=ϫ.ToString();if(ʃ)
Echo(ϩ);if(ϩ=="Active"&&H==Ơ.Off)Ɲ.Apply(ɒ);else if(ϩ=="Inactive"&&H==Ơ.On)Ɲ.Apply(ɒ);}}}catch{if(ʃ)Echo(
"Failed to set aux block "+ɒ.CustomName);}}}IMyShipController Ϩ;List<IMyRadioAntenna>ϧ=new List<IMyRadioAntenna>();List<IMyBatteryBlock>Ϧ=new List
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
IMyTextPanel>();List<IMyTextPanel>έ=new List<IMyTextPanel>();List<ћ>ά=new List<ћ>();List<IMyLightingBlock>Ϋ=new List<
IMyLightingBlock>();List<IMyLightingBlock>κ=new List<IMyLightingBlock>();List<IMyLightingBlock>μ=new List<IMyLightingBlock>();List<
IMyLightingBlock>ϋ=new List<IMyLightingBlock>();List<IMyReflectorLight>ό=new List<IMyReflectorLight>();List<IMyTerminalBlock>ϊ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>ω=new List<IMyTerminalBlock>();List<ѫ>ψ=new List<ѫ>();List<Һ>χ=new List<Һ>();Dictionary<
IMyTerminalBlock,string>φ=new Dictionary<IMyTerminalBlock,string>();bool υ(IMyTerminalBlock ɉ){try{if(!Me.IsSameConstructAs(ɉ))return
false;string τ=ɉ.GetOwnerFactionTag();if(τ!=Τ&&τ!=""){Echo("!"+τ+": "+ɉ.CustomName);Χ++;return false;}if(ɉ.CustomName.
Contains(ʴ))return false;if(!Ύ&&ʾ&&!ɉ.CustomName.Contains(ʒ))return false;string σ=ɉ.BlockDefinition.ToString();if(ɉ.CustomName.
Contains(ʱ)){ϊ.Add(ɉ);}if(σ.Contains("MedicalRoom/")){if(Έ)ɉ.CustomData=Ρ;else ɉ.CustomData=Σ;ϛ.Add(ɉ);if(Ύ)φ.Add(ɉ,
"Medical Room");return false;}if(σ.Contains("SurvivalKit/")){if(Έ)ɉ.CustomData=Ρ;else ɉ.CustomData=Σ;ϛ.Add(ɉ);if(Ύ)φ.Add(ɉ,
"Survival Kit");return false;}if(σ=="MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Ύ)φ.Add(ɉ,"Refill Station");return false;}var
ς=ɉ as IMyTextPanel;if(ς!=null){ή.Add(ς);if(Ύ)φ.Add(ɉ,"LCD");if(ς.CustomName.Contains(ʳ)){ћ ρ=new ћ();ρ.ɒ=ς;ά.Add(Ɇ(ρ));}
else if(!ʈ&&ς.CustomName.Contains(ʲ))έ.Add(ς);return false;}if(σ==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɞ(ɉ,"Flak",3);if(σ=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɞ(ɉ,
"OPA",3);if(σ=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɞ(ɉ,"Voltaire",3);if(σ.Contains
("Nariman Dynamics PDC"))return ɞ(ɉ,"Nari",4);if(σ.Contains("Redfields Ballistics PDC"))return ɞ(ɉ,"Red",4);if(σ.Contains
("OPA Shotgun PDC"))return ɞ(ɉ,"Shotgun",4);if(σ=="MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return ɋ
(ɉ,"Apollo");if(σ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɋ(ɉ,"Tycho");if(σ==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return ɋ(ɉ,"Zeus");if(σ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɋ(ɉ,"Tycho");if(σ.Contains(
"Ares_Class"))return ɋ(ɉ,"Ares");if(σ.Contains("Artemis_Torpedo_Tube"))return ɋ(ɉ,"Artemis");if(σ==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return Ɋ(ɉ,"Dawson",11);if(σ=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return Ɋ(ɉ,"Stiletto",12);if
(σ=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return Ɋ(ɉ,"Roci",13);if(σ==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return Ɋ(ɉ,"Foehammer",14);if(σ=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return Ɋ(ɉ,"Farren",15);
if(σ.Contains("Zakosetara"))return Ɋ(ɉ,"Zako",10);if(σ.Contains("Kess Hashari Cannon"))return Ɋ(ɉ,"Kess",16);if(σ.Contains
("Coilgun"))return Ɋ(ɉ,"Coilgun",13);if(σ.Contains("Glapion"))return Ɋ(ɉ,"Glapion",3);var π=ɉ as IMyThrust;if(π!=null){if
(σ.ToUpper().Contains("RCS")){γ.Add(π);if(Ύ)φ.Add(ɉ,"RCS");}else if(σ.Contains("Hydro")){β.Add(π);if(Ύ)φ.Add(ɉ,"Chem");}
else if(σ.Contains("Atmospheric")){α.Add(π);if(Ύ)φ.Add(ɉ,"Atmo");}else{δ.Add(π);if(Ύ){string Ɍ="";if(ʋ){try{Ɍ=ɉ.
DefinitionDisplayNameText.Split('"')[1];Ɍ=ʍ+Ɍ[0].ToString().ToUpper()+Ɍ.Substring(1).ToLower();}catch{if(ʃ)Echo("Failed to get drive type from "+
ɉ.DefinitionDisplayNameText);}}φ.Add(ɉ,"Epstein"+Ɍ);}}return false;}var ο=ɉ as IMyCargoContainer;if(ο!=null){string ξ=σ.
Split('/')[1];if(ξ.Contains("Container")||ξ.Contains("Cargo")){Ϥ.Add(ο);Ϯ(ɉ);if(Ύ){double ν=ɉ.GetInventory().MaxVolume.
RawValue;double ˀ=Math.Round(ν/1265625024,1);if(ˀ==0)ˀ=0.1;φ.Add(ɉ,"Cargo ["+ˀ+"]");}return false;}}var ɬ=ɉ as IMyGyro;if(ɬ!=
null){ϟ.Add(ɬ);if(Ύ)φ.Add(ɉ,"Gyroscope");return false;}var ɐ=ɉ as IMyBatteryBlock;if(ɐ!=null){Ϧ.Add(ɐ);if(Ύ)φ.Add(ɉ,"Power"+
ʍ+"Battery");return false;}var ɫ=ɉ as IMyReflectorLight;if(ɫ!=null){ό.Add(ɫ);if(Ύ)φ.Add(ɉ,"Spotlight");return false;}var
ɪ=ɉ as IMyLightingBlock;if(ɪ!=null){if(ɉ.CustomName.ToUpper().Contains("INTERIOR")){κ.Add(ɪ);if(Ύ)φ.Add(ɉ,"Light"+ʍ+
"Interior");}else if(σ.Contains("Kitchen")||σ.Contains("Aquarium")){κ.Add(ɪ);if(Ύ)φ.Add(ɉ,"Light"+ʍ+"Interior"+ʍ+ɉ.
DefinitionDisplayNameText);}else if(ɉ.CustomName.Contains(ʠ)){if(ɉ.CustomName.ToUpper().Contains("STARBOARD")){ϋ.Add(ɪ);if(Ύ)φ.Add(ɉ,"Light"+ʍ+
"Nav"+ʍ+"Starboard");}else{μ.Add(ɪ);if(Ύ)φ.Add(ɉ,"Light"+ʍ+"Nav"+ʍ+"Port");}}else{Ϋ.Add(ɪ);if(Ύ)φ.Add(ɉ,"Light"+ʍ+"Exterior")
;}return false;}var ɩ=ɉ as IMyGasTank;if(ɩ!=null){if(σ.Contains("Hydro")){Ϛ.Add(ɩ);if(Ύ)φ.Add(ɉ,"Tank"+ʍ+"Hydrogen");}
else{ύ.Add(ɩ);if(Ύ)φ.Add(ɉ,"Tank"+ʍ+"Oxygen");}return false;}var ɨ=ɉ as IMyReactor;if(ɨ!=null){ϝ.Add(ɨ);Ϯ(ɉ,0);if(Ύ){string
ɧ="Lg";if(σ.Contains("SmallGenerator"))ɧ="Sm";else if(σ.Contains("MCRN"))ɧ="MCRN";φ.Add(ɉ,"Power"+ʍ+"Reactor"+ʍ+ɧ);}
return false;}var ɦ=ɉ as IMyShipController;if(ɦ!=null){Ϫ.Add(ɦ);if(Ϩ==null&&ɉ.CustomName.Contains("Nav"))Ϩ=ɦ;if(ɦ.HasInventory
)Ϯ(ɉ);if(Ύ&&σ.Contains("Cockpit/")){if(σ.Contains("StandingCockpit")||σ.Contains("Console")){φ.Add(ɉ,"Console");return
false;}else if(σ.Contains("Cockpit")){φ.Add(ɉ,"Cockpit");return false;}}}var ɥ=ɉ as IMyDoor;if(ɥ!=null){ѫ ɤ=new ѫ();ɤ.ɒ=ɥ;if(
ɉ.CustomName.Contains(ʀ)){try{string ɠ=ɉ.CustomName.Split(ʍ)[3];ɤ.Ҽ=true;bool ɟ=false;foreach(Һ ɣ in χ){if(ɠ==ɣ.ҹ){ɣ.ҵ.
Add(ɤ);ɟ=true;break;}}if(!ɟ){Һ ɢ=new Һ();ɢ.ҹ=ɠ;ɢ.ҵ.Add(ɤ);χ.Add(ɢ);}}catch{if(ʃ)Echo("Error with airlock door name "+ɉ.
CustomName);ψ.Add(ɤ);}}else{ψ.Add(ɤ);}if(Ύ)φ.Add(ɉ,"Door");return false;}var ɡ=ɉ as IMyAirVent;if(ɡ!=null){λ.Add(ɡ);if(ɉ.
CustomName.Contains(ʀ)){try{string ɠ=ɉ.CustomName.Split(ʍ)[3];bool ɟ=false;foreach(Һ ɣ in χ){if(ɠ==ɣ.ҹ){ɣ.Ҵ.Add(ɡ);ɟ=true;break;}}
if(!ɟ){Һ ɢ=new Һ();ɢ.ҹ=ɠ;ɢ.Ҵ.Add(ɡ);χ.Add(ɢ);}}catch{if(ʃ)Echo("Error with airlock vent name "+ɉ.CustomName);}}if(Ύ)φ.Add(
ɉ,"Vent");return false;}var ɽ=ɉ as IMyCameraBlock;if(ɽ!=null){ϥ.Add(ɽ);if(Ύ)φ.Add(ɉ,"Camera");return false;}var ɾ=ɉ as
IMyShipConnector;if(ɾ!=null){ϣ.Add(ɾ);Ϯ(ɉ);if(Ύ){string ɼ="";if(σ.Contains("Passageway"))ɼ=ʍ+"Passageway";φ.Add(ɉ,"Connector"+ɼ);}return
false;}var ɻ=ɉ as IMyAirtightHangarDoor;if(ɻ!=null){Ϣ.Add(ɻ);if(Ύ)φ.Add(ɉ,"Door"+ʍ+"Hangar");return false;}if(σ.Contains(
"Lidar")){var ɺ=ɉ as IMyConveyorSorter;if(ɺ!=null){ι.Add(ɺ);if(Ύ)φ.Add(ɉ,"LiDAR");return false;}}if(σ==
"MyObjectBuilder_OxygenGenerator/Extractor"){ϡ.Add(ɉ);if(Ύ)φ.Add(ɉ,"Extractor");return false;}if(σ=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){Ϡ.Add(ɉ);if(Ύ
)φ.Add(ɉ,"Extractor");return false;}var ɹ=ɉ as IMyRadioAntenna;if(ɹ!=null){ϧ.Add(ɹ);if(Ύ)φ.Add(ɉ,"Antenna");return false;
}var ɸ=ɉ as IMyProgrammableBlock;if(ɸ!=null){if(Ύ)φ.Add(ɉ,"PB Server");if(ɸ==Me)return false;try{if(ɉ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))ΰ.Add(ɸ);else if(ɉ.CustomData.Contains("NavConfig"))ί.Add(ɸ);return false;}catch{}}var
ɷ=ɉ as IMyProjector;if(ɷ!=null){Ϟ.Add(ɷ);if(Ύ)φ.Add(ɉ,"Projectors");return false;}var ɶ=ɉ as IMySensorBlock;if(ɶ!=null){Ϝ
.Add(ɶ);if(Ύ)φ.Add(ɉ,"Sensor");return false;}var ɵ=ɉ as IMyCollector;if(ɵ!=null){Ϯ(ɉ);if(Ύ)φ.Add(ɉ,"Collector");return
false;}if(σ.Contains("Welder")){Ϊ.Add(ɉ);if(Ύ)φ.Add(ɉ,"Tool"+ʍ+"Welder");return false;}if(Ύ){if(σ.Contains("LandingGear/")){
if(σ.Contains("Clamp"))φ.Add(ɉ,"Clamp");else if(σ.Contains("Magnetic"))φ.Add(ɉ,"Mag Lock");else φ.Add(ɉ,"Gear");return
false;}if(σ.Contains("Drill")){φ.Add(ɉ,"Tool"+ʍ+"Drill");return false;}if(σ.Contains("Grinder")){φ.Add(ɉ,"Tool"+ʍ+"Grinder");
return false;}if(σ.Contains("Solar")){φ.Add(ɉ,"Solar");return false;}if(σ.Contains("ButtonPanel")){φ.Add(ɉ,"Button Panel");
return false;}var ɴ=ɉ as IMyConveyorSorter;if(ɴ!=null){φ.Add(ɉ,"Sorter");return false;}var ɳ=ɉ as IMyMotorSuspension;if(ɳ!=
null){φ.Add(ɉ,"Suspension");return false;}var ɲ=ɉ as IMyGravityGenerator;if(ɲ!=null){φ.Add(ɉ,"Grav Gen");return false;}var ɱ
=ɉ as IMyTimerBlock;if(ɱ!=null){φ.Add(ɉ,"Timer");return false;}var ɰ=ɉ as IMyGasGenerator;if(ɰ!=null){φ.Add(ɉ,"H2 Engine"
);return false;}var ɯ=ɉ as IMyBeacon;if(ɯ!=null){φ.Add(ɉ,"Beacon");return false;}φ.Add(ɉ,ɉ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ʃ){Echo("Failed to sort "+ɉ.CustomName+"\nAdded "+φ.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɮ(){Ϩ=null;ϧ.Clear();Ϧ.Clear();ϥ.Clear();Ϥ.Clear();ϣ.Clear();Ϫ.Clear();ψ.Clear();χ.Clear();Ϣ.Clear();ϡ.
Clear();Ϡ.Clear();ϟ.Clear();Ϟ.Clear();ϝ.Clear();Ϝ.Clear();Ϛ.Clear();ύ.Clear();λ.Clear();Ϊ.Clear();ι.Clear();θ.Clear();η.Clear
();ζ.Clear();ε.Clear();δ.Clear();γ.Clear();β.Clear();α.Clear();ΰ.Clear();ί.Clear();ή.Clear();ά.Clear();έ.Clear();Ϋ.Clear(
);κ.Clear();μ.Clear();ϋ.Clear();ό.Clear();ϊ.Clear();foreach(var ɭ in ϯ)ɭ.ϸ.Clear();if(Ύ)φ.Clear();}bool ɞ(
IMyTerminalBlock ɉ,string Œ,int Ɉ){if(ɉ.CustomName.Contains(ʰ))η.Add(ɉ);else θ.Add(ɉ);Ϯ(ɉ,Ɉ);if(Ύ){string Ɍ="";if(ʌ)Ɍ=ʍ+Œ;φ.Add(ɉ,"PDC"+
Ɍ);}return false;}bool ɋ(IMyTerminalBlock ɉ,string Œ){ε.Add(ɉ);if(Ύ){string ɇ="";if(ʌ)ɇ=ʍ+Œ;φ.Add(ɉ,"Torpedo"+ɇ);}return
false;}bool Ɋ(IMyTerminalBlock ɉ,string Œ,int Ɉ){ζ.Add(ɉ);Ϯ(ɉ,Ɉ);if(Ύ){string ɇ="";if(ʌ)ɇ=ʍ+Œ;φ.Add(ɉ,"Railgun"+ɇ);}return
false;}ћ Ɇ(ћ ĥ,string Ʌ=""){bool Ʉ=Ʌ=="",ɍ=!Ʉ;string ɏ=ĥ.ɒ.CustomData,ɜ="RSM.LCD";string[]ɝ=null;MyIni ɛ=new MyIni();
MyIniParseResult Ɖ;if(!Ʉ||ɏ=="")ɍ=true;else{try{if(ɏ.Substring(0,12)=="Show Header="){ɝ=ɏ.Split('\n');foreach(string ɚ in ɝ){if(ɚ.
Contains("hud")){if(ɚ.Contains("lcd")){Ʌ=ɚ;break;}}else if(ɚ.Contains("=")){string[]ə=ɚ.Split('=');if(ə[0]==
"Show Tanks & Batteries")ĥ.ї=bool.Parse(ə[1]);else if(ə[0]=="Show header"||ə[0]=="Show Header")ĥ.њ=bool.Parse(ə[1]);else if(ə[0]==
"Show Header Overlay")ĥ.љ=bool.Parse(ə[1]);else if(ə[0]=="Show Warnings")ĥ.ј=bool.Parse(ə[1]);else if(ə[0]=="Show Inventory")ĥ.ѝ=bool.Parse(ə
[1]);else if(ə[0]=="Show Thrust")ĥ.і=bool.Parse(ə[1]);else if(ə[0]=="Show Subsystem Integrity")ĥ.ѕ=bool.Parse(ə[1]);else
if(ə[0]=="Show Advanced Thrust")ĥ.є=bool.Parse(ə[1]);}}}else if(!ɛ.TryParse(ɏ,out Ɖ)){ɍ=true;}else{ĥ.њ=ɛ.Get(ɜ,
"ShowHeader").ToBoolean(ĥ.њ);ĥ.љ=ɛ.Get(ɜ,"ShowHeaderOverlay").ToBoolean(ĥ.љ);ĥ.ј=ɛ.Get(ɜ,"ShowWarnings").ToBoolean(ĥ.ј);ĥ.ї=ɛ.Get(ɜ,
"ShowPowerAndTanks").ToBoolean(ĥ.ї);ĥ.ѝ=ɛ.Get(ɜ,"ShowInventory").ToBoolean(ĥ.ѝ);ĥ.і=ɛ.Get(ɜ,"ShowThrust").ToBoolean(ĥ.і);ĥ.ѕ=ɛ.Get(ɜ,
"ShowIntegrity").ToBoolean(ĥ.ѕ);ĥ.є=ɛ.Get(ɜ,"ShowAdvancedThrust").ToBoolean(ĥ.є);}}catch(Exception ex){if(ʃ)Echo(
"LCD parsing error, resetting\n"+ex.Message);ɍ=true;}}if(ĥ.њ&&ĥ.љ){ĥ.њ=false;ɍ=true;}if(ɍ){if(ɝ==null)ɝ=ɏ.Split('\n');ɛ.Set(ɜ,"ShowHeader",ĥ.њ);ɛ.Set(ɜ,
"ShowHeaderOverlay",ĥ.љ);ɛ.Set(ɜ,"ShowWarnings",ĥ.ј);ɛ.Set(ɜ,"ShowPowerAndTanks",ĥ.ї);ɛ.Set(ɜ,"ShowInventory",ĥ.ѝ);ɛ.Set(ɜ,"ShowThrust",ĥ.і
);ɛ.Set(ɜ,"ShowIntegrity",ĥ.ѕ);ɛ.Set(ɜ,"ShowAdvancedThrust",ĥ.є);ɛ.Set(ɜ,"Hud",Ʌ);ĥ.ɒ.CustomData=ɛ.ToString();if(Ʉ)Ъ.Add(
new ѓ("LCD CONFIG ERROR!!","Failed to parse LCD config for "+ĥ.ɒ.CustomName+"!\nLCD config was reset!",3));}return ĥ;}void
ɘ(IMyTerminalBlock ɒ,bool Ȯ){ɒ.GetActionWithName("ToolCore_Shoot_Action").Apply(ɒ);(ɒ as IMyConveyorSorter).
GetActionWithName("ToolCore_Shoot_Action").Apply(ɒ);}void ɗ(){List<IMyTerminalBlock>ɖ=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(ɖ);string ɕ="";foreach(IMyTerminalBlock ɔ in ɖ){ɕ+=ɔ.BlockDefinition+"\n";}if(ϧ.Count>0&&ϧ[0]!=null){
ϧ[0].CustomData=ɕ;}}void ɓ(string ȧ){IMyTerminalBlock ɒ=GridTerminalSystem.GetBlockWithName(ȧ);List<ITerminalAction>ɑ=new
List<ITerminalAction>();ɒ.GetActions(ɑ);List<ITerminalProperty>Ɏ=new List<ITerminalProperty>();ɒ.GetProperties(Ɏ);string ɿ=ɒ
.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction ʑ in ɑ){ɿ+=ʑ.Id+" "+ʑ.Name+"\n";}ɿ+="\n\n**Properties**\n\n";
foreach(ITerminalProperty ʭ in Ɏ){ɿ+=ʭ.Id+" "+ʭ.TypeName+"\n";}if(ϧ.Count>0&&ϧ[0]!=null)ϧ[0].CustomData=ɿ;ɒ.CustomData=ɿ;}void
ʫ(IMyTerminalBlock Ʀ){bool ʩ=Ʀ.GetValue<bool>("WC_Repel");if(!ʩ)Ʀ.ApplyAction("WC_RepelMode");}void ʪ(IMyTerminalBlock Ʀ)
{bool ʩ=Ʀ.GetValue<bool>("WC_Repel");if(ʩ)Ʀ.ApplyAction("WC_RepelMode");}void ʨ(IMyTerminalBlock Ʀ){try{if(Ǥ.Ɨ(Ʀ,0)==
VRageMath.Matrix.Zero)return;Ʀ.SetValue<Int64>("WC_Shoot Mode",3);if(ʃ)Echo("Shoot mode = "+Ʀ.GetValue<Int64>("WC_Shoot Mode"));}
catch{Echo("Failed to set fire mode to manual on "+Ʀ.CustomName);}}void ʧ(IMyTerminalBlock Ʀ){try{if(Ǥ.Ɨ(Ʀ,0)==VRageMath.
Matrix.Zero)return;Ʀ.SetValue<Int64>("WC_Shoot Mode",0);if(ʃ)Echo("Shoot mode = "+Ʀ.GetValue<Int64>("WC_Shoot Mode"));}catch{
Echo("Failed to set fire mode to auto on "+Ʀ.CustomName);}}void ʦ(){if(Ϩ!=null){try{Φ=Ϩ.GetShipSpeed();Υ=Ϩ.CalculateShipMass
().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo(exxie.Message);}}}double ʥ=0;double
ʤ=0;double ʣ=0;void ʢ(){ʤ=0;foreach(IMyCargoContainer ʬ in Ϥ){if(ʬ!=null&&!ʬ.Closed&&ʬ.IsFunctional){try{ʤ+=ʬ.
GetInventory().MaxVolume.RawValue;}catch(Exception ex){if(ʃ)Echo("Cargo integrity error!\n"+ex.Message);throw ex;}}}ʣ=Math.Round(100
*(ʤ/ʥ));}void ʮ(){ʥ=0;foreach(IMyCargoContainer ʬ in Ϥ){if(ʬ!=null)ʥ+=ʬ.GetInventory().MaxVolume.RawValue;}}MyIni ʿ=new
MyIni();bool ʾ=false;bool ʽ=true;bool ʼ=true;bool ʻ=true;bool ʺ=true;bool ʹ=false;string ʸ="";bool ʷ=true;int ʶ=3;int ʵ=6;
string ʴ="[I]";string ʳ="[RSM]";string ʲ="[CS]";string ʱ="Autorepair";string ʰ="Repel";string ʯ="Min";string ʡ="Docking";
string ʠ="Nav";string ʀ="Airlock";string ʏ="[EFC]";string ʎ="[NavOS]";char ʍ='.';bool ʌ=true;bool ʋ=true;List<string>ʊ=new
List<string>();bool ʉ=false;bool ʈ=false;bool ʇ=true;List<double>ʆ=new List<double>();bool ʅ=false;double ʄ=0.5;bool ʃ=true;
bool ʂ=false;int ʁ=0;int ʐ=100;string ʒ="";bool ʟ(){string ɏ=Me.CustomData;string ɜ="";bool ʞ=true;MyIniParseResult Ɖ;if(!ʿ.
TryParse(ɏ,out Ɖ)){string[]ʝ=ɏ.Split('\n');if(ʝ[1]=="Reedit Ship Management"){Echo("Legacy config detected...");ғ(ɏ);return
false;}else{Echo("Could not parse custom data!\n"+Ɖ.ToString());return false;}}try{ɜ="RSM.Main";Echo(ɜ);ʾ=ʿ.Get(ɜ,
"RequireShipName").ToBoolean(ʾ);ʽ=ʿ.Get(ɜ,"EnableAutoload").ToBoolean(ʽ);ʼ=ʿ.Get(ɜ,"AutoloadReactors").ToBoolean(ʼ);ʻ=ʿ.Get(ɜ,
"AutoConfigWeapons").ToBoolean(ʻ);ʺ=ʿ.Get(ɜ,"SetTurretFireMode").ToBoolean(ʺ);ɜ="RSM.Spawns";Echo(ɜ);ʹ=ʿ.Get(ɜ,"PrivateSpawns").ToBoolean(ʹ
);ʸ=ʿ.Get(ɜ,"FriendlyTags").ToString(ʸ);ɜ="RSM.Doors";Echo(ɜ);ʷ=ʿ.Get(ɜ,"EnableDoorManagement").ToBoolean(ʷ);ʶ=ʿ.Get(ɜ,
"DoorCloseTimer").ToInt32(ʶ);ʶ=ʿ.Get(ɜ,"AirlockDoorDisableTimer").ToInt32(ʶ);ɜ="RSM.Keywords";Echo(ɜ);ʴ=ʿ.Get(ɜ,"Ignore").ToString(ʴ);ʳ=
ʿ.Get(ɜ,"RsmLcds").ToString(ʳ);ʲ=ʿ.Get(ɜ,"ColourSyncLcds").ToString(ʲ);ʱ=ʿ.Get(ɜ,"AuxiliaryBlocks").ToString(ʱ);ʰ=ʿ.Get(ɜ
,"DefensivePdcs").ToString(ʰ);ʯ=ʿ.Get(ɜ,"MinimumThrusters").ToString(ʯ);ʡ=ʿ.Get(ɜ,"DockingThrusters").ToString(ʡ);ʠ=ʿ.Get
(ɜ,"NavLights").ToString(ʠ);ʀ=ʿ.Get(ɜ,"Airlock").ToString(ʀ);ɜ="RSM.InitNaming";Echo(ɜ);ʍ=ʿ.Get(ɜ,"Ignore").ToChar(ʍ);ʌ=ʿ
.Get(ɜ,"NameWeaponTypes").ToBoolean(ʌ);ʋ=ʿ.Get(ɜ,"NameDriveTypes").ToBoolean(ʋ);string ʜ=ʿ.Get(ɜ,"BlocksToNumber").
ToString("");string[]ʛ=ʜ.Split(',');ʊ.Clear();foreach(string ȧ in ʛ)if(ȧ!="")ʊ.Add(ȧ);ɜ="RSM.Misc";Echo(ɜ);ʉ=ʿ.Get(ɜ,
"DisableLightingControl").ToBoolean(ʉ);ʈ=ʿ.Get(ɜ,"DisableLcdColourControl").ToBoolean(ʈ);ʇ=ʿ.Get(ɜ,"ShowBasicTelemetry").ToBoolean(ʇ);string ʚ=ʿ
.Get(ɜ,"DecelerationPercentages").ToString("");string[]ʙ=ʚ.Split(',');if(ʙ.Length>1){ʆ.Clear();foreach(string ʘ in ʙ){ʆ.
Add(double.Parse(ʘ)/100);}}ʅ=ʿ.Get(ɜ,"ShowThrustInMetric").ToBoolean(ʅ);ʄ=ʿ.Get(ɜ,"ReactorFillRatio").ToDouble(ʄ);ϯ[0].ϰ=ʄ;
ɜ="RSM.Debug";Echo(ɜ);ʃ=ʿ.Get(ɜ,"VerboseDebugging").ToBoolean(ʃ);ʂ=ʿ.Get(ɜ,"RuntimeProfiling").ToBoolean(ʂ);ʐ=ʿ.Get(ɜ,
"BlockRefreshFreq").ToInt32(ʐ);ʁ=ʿ.Get(ɜ,"StallCount").ToInt32(ʁ);ɜ="RSM.System";Echo(ɜ);ʒ=ʿ.Get(ɜ,"ShipName").ToString(ʒ);ɜ=
"RSM.InitItems";Echo(ɜ);foreach(ɭ ʗ in ϯ){ʗ.Ђ=ʿ.Get(ɜ,ʗ.ϵ.SubtypeId).ToInt32(ʗ.Ђ);}ɜ="RSM.InitSubSystems";Echo(ɜ);F=ʿ.Get(ɜ,"Reactors")
.ToDouble(F);F=ʿ.Get(ɜ,"Batteries").ToDouble(o);Î=ʿ.Get(ɜ,"Pdcs").ToInt32(Î);Ȋ=ʿ.Get(ɜ,"TorpLaunchers").ToInt32(Ȋ);Z=ʿ.
Get(ɜ,"KineticWeapons").ToInt32(Z);Õ=ʿ.Get(ɜ,"H2Storage").ToDouble(Õ);ë=ʿ.Get(ɜ,"O2Storage").ToDouble(ë);ä=ʿ.Get(ɜ,
"MainThrust").ToSingle(ä);ȇ=ʿ.Get(ɜ,"RCSThrust").ToSingle(ȇ);Ҩ=ʿ.Get(ɜ,"Gyros").ToDouble(Ҩ);ʥ=ʿ.Get(ɜ,"CargoStorage").ToDouble(ʥ);ƥ=
ʿ.Get(ɜ,"Welders").ToInt32(ƥ);}catch(Exception ex){ѱ(ex,"Failed to parse section\n"+ɜ);}Echo("Parsing stances...");
Dictionary<string,à>ʖ=new Dictionary<string,à>();List<string>ʕ=new List<string>();ʿ.GetSections(ʕ);foreach(string ʔ in ʕ){if(ʔ.
Contains("RSM.Stance.")){string ʓ=ʔ.Substring(11);Echo(ʓ);à Ø=new à();string ġ,Ϭ="";string[]Ҋ;int Ҁ=33,ѿ=144,ɉ=255,Ĵ=255;bool Ѿ=
false;à ѽ=null;Ϭ="Inherits";if(ʿ.ContainsKey(ʔ,Ϭ)){Ѿ=true;try{ѽ=ʖ[ʿ.Get(ʔ,Ϭ).ToString()];Echo("Inherits "+ʿ.Get(ʔ,Ϭ).ToString
());}catch(Exception ex){ѱ(ex,"Failed to find inheritee for\n"+ʔ+
"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(Ѿ)Echo(ѽ.ÿ.ToString());Ϭ="Torps";if(ʿ.ContainsKey(ʔ,Ϭ)){Ø.ÿ=(Ơ)Enum.Parse(typeof(Ơ),ʿ.Get(ʔ,Ϭ).ToString());
Echo("1");}else if(Ѿ){Ø.ÿ=ѽ.ÿ;Echo("2");}else{Ø.ÿ=ď;Echo("3");}Ϭ="Pdcs";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.þ=(ǔ)Enum.Parse(typeof(ǔ),ʿ.
Get(ʔ,Ϭ).ToString());else if(Ѿ)Ø.þ=ѽ.þ;else Ø.þ=Ď;Ϭ="Kinetics";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ý=(Ǔ)Enum.Parse(typeof(Ǔ),ʿ.Get(ʔ,Ϭ)
.ToString());else if(Ѿ)Ø.ý=ѽ.ý;else Ø.ý=č;Ϭ="MainThrust";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ü=(ǒ)Enum.Parse(typeof(ǒ),ʿ.Get(ʔ,Ϭ).
ToString());else if(Ѿ)Ø.ü=ѽ.ü;else Ø.ü=Č;Ϭ="ManeuveringThrust";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.û=(Ǘ)Enum.Parse(typeof(Ǘ),ʿ.Get(ʔ,Ϭ).
ToString());else if(Ѿ)Ø.û=ѽ.û;else Ø.û=ċ;Ϭ="Spotlights";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ú=(ǖ)Enum.Parse(typeof(ǖ),ʿ.Get(ʔ,Ϭ).ToString())
;else if(Ѿ)Ø.ú=ѽ.ú;else Ø.ú=Ċ;Ϭ="ExteriorLights";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ù=(Ǖ)Enum.Parse(typeof(Ǖ),ʿ.Get(ʔ,Ϭ).ToString())
;else if(Ѿ)Ø.ù=ѽ.ù;else Ø.ù=ĉ;Ϭ="ExteriorLightColour";if(ʿ.ContainsKey(ʔ,Ϭ)){ġ=ʿ.Get(ʔ,Ϭ).ToString();Ҋ=ġ.Split(',');Ҁ=int
.Parse(Ҋ[0]);ѿ=int.Parse(Ҋ[1]);ɉ=int.Parse(Ҋ[2]);Ĵ=int.Parse(Ҋ[3]);Ø.ø=new Color(Ҁ,ѿ,ɉ,Ĵ);}else if(Ѿ)Ø.ø=ѽ.ø;else Ø.ø=Ĉ;Ϭ
="InteriorLights";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ö=(Ǖ)Enum.Parse(typeof(Ǖ),ʿ.Get(ʔ,Ϭ).ToString());else if(Ѿ)Ø.ö=ѽ.ö;else Ø.ö=ć;Ϭ
="InteriorLightColour";if(ʿ.ContainsKey(ʔ,Ϭ)){ġ=ʿ.Get(ʔ,Ϭ).ToString();Ҋ=ġ.Split(',');Ҁ=int.Parse(Ҋ[0]);ѿ=int.Parse(Ҋ[1]);
ɉ=int.Parse(Ҋ[2]);Ĵ=int.Parse(Ҋ[3]);Ø.õ=new Color(Ҁ,ѿ,ɉ,Ĵ);}else if(Ѿ)Ø.õ=ѽ.õ;else Ø.õ=Ć;Ϭ="NavLights";if(ʿ.ContainsKey(ʔ
,Ϭ))Ø.ô=(Ǖ)Enum.Parse(typeof(Ǖ),ʿ.Get(ʔ,Ϭ).ToString());else if(Ѿ)Ø.ô=ѽ.ô;else Ø.ô=ą;Ϭ="LcdTextColour";if(ʿ.ContainsKey(ʔ,
Ϭ)){ġ=ʿ.Get(ʔ,Ϭ).ToString();Ҋ=ġ.Split(',');Ҁ=int.Parse(Ҋ[0]);ѿ=int.Parse(Ҋ[1]);ɉ=int.Parse(Ҋ[2]);Ĵ=int.Parse(Ҋ[3]);Ø.ó=
new Color(Ҁ,ѿ,ɉ,Ĵ);}else if(Ѿ)Ø.ó=ѽ.ó;else Ø.ó=Ą;Ϭ="TanksAndBatteries";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ò=(Ǒ)Enum.Parse(typeof(Ǒ),ʿ.
Get(ʔ,Ϭ).ToString());else if(Ѿ)Ø.ò=ѽ.ò;else Ø.ò=ă;Ϭ="NavOsEfcBurnPercentage";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ñ=ʿ.Get(ʔ,
"NavOsEfcBurnPercentage").ToInt32(ï);else if(Ѿ)Ø.ñ=ѽ.ñ;else Ø.ñ=ï;Ϭ="EfcBoost";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ð=(Ơ)Enum.Parse(typeof(Ơ),ʿ.Get(ʔ,Ϭ).
ToString());else if(Ѿ)Ø.ð=ѽ.ð;else Ø.ð=î;Ϭ="NavOsAbortEfcOff";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.Ā=(ǁ)Enum.Parse(typeof(ǁ),ʿ.Get(ʔ,Ϭ).
ToString());else if(Ѿ)Ø.Ā=ѽ.Ā;else Ø.Ā=Ï;Ϭ="NavOsAbortEfcOff";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.Ā=(ǁ)Enum.Parse(typeof(ǁ),ʿ.Get(ʔ,Ϭ).
ToString());else if(Ѿ)Ø.Ā=ѽ.Ā;else Ø.Ā=Ï;Ϭ="AuxMode";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.Ă=(Ơ)Enum.Parse(typeof(Ơ),ʿ.Get(ʔ,Ϭ).ToString());
else if(Ѿ)Ø.Ă=ѽ.Ă;else Ø.Ă=Þ;Ϭ="Extractor";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.ē=(ǀ)Enum.Parse(typeof(ǀ),ʿ.Get(ʔ,Ϭ).ToString());else if(
Ѿ)Ø.ē=ѽ.ē;else Ø.ē=Ý;Ϭ="KeepAlives";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.Ĕ=(Ơ)Enum.Parse(typeof(Ơ),ʿ.Get(ʔ,Ϭ).ToString());else if(Ѿ)Ø.
Ĕ=ѽ.Ĕ;else Ø.Ĕ=Ü;Ϭ="HangarDoors";if(ʿ.ContainsKey(ʔ,Ϭ))Ø.Ē=(ƿ)Enum.Parse(typeof(ƿ),ʿ.Get(ʔ,Ϭ).ToString());else if(Ѿ)Ø.Ē=ѽ
.Ē;else Ø.Ē=Û;ʖ.Add(ʓ,Ø);}catch(Exception ex){ѱ(ex,"Failed to parse stance\n"+ʓ+"\nproperty\n"+Ϭ);}}}if(ʖ.Count<1){Echo(
"Failed to parse any stances!\nStances reset to default!");ʞ=false;}else{Echo("Finished parsing "+ʖ.Count+" stances.");Ѭ=ʖ;}ɜ="RSM.Stance";Echo(ɜ);đ=ʿ.Get(ɜ,"CurrentStance").
ToString(đ);à Ѽ;if(!Ѭ.TryGetValue(đ,out Ѽ)){đ="N/A";Đ=null;}else Đ=Ѽ;return ʞ;}void ѻ(){ʿ.Clear();string ɜ,ȧ;ɜ="RSM.Main";ȧ=
"RequireShipName";ʿ.Set(ɜ,ȧ,ʾ);ʿ.SetComment(ɜ,ȧ,"limit to blocks with the ship name in their name");ȧ="EnableAutoload";ʿ.Set(ɜ,ȧ,ʽ);ʿ.
SetComment(ɜ,ȧ,"enable RSM loading & balancing functionality for weapons");ȧ="AutoloadReactors";ʿ.Set(ɜ,ȧ,ʼ);ʿ.SetComment(ɜ,ȧ,
"enable loading and balancing for reactors");ȧ="AutoConfigWeapons";ʿ.Set(ɜ,ȧ,ʻ);ʿ.SetComment(ɜ,ȧ,"automatically configure weapon on stance set");ȧ=
"SetTurretFireMode";ʿ.Set(ɜ,ȧ,ʺ);ʿ.SetComment(ɜ,ȧ,"set turret fire mode based on stance");ʿ.SetSectionComment(ɜ,й+
" Reedit Ship Management\n"+й+" Config.ini\n Recompile to apply changes!\n"+й);ɜ="RSM.Spawns";ȧ="PrivateSpawns";ʿ.Set(ɜ,ȧ,ʹ);ʿ.SetComment(ɜ,ȧ,
"don't inject faction tag into spawn custom data");ȧ="FriendlyTags";ʿ.Set(ɜ,ȧ,ʸ);ʿ.SetComment(ɜ,ȧ,"Comma seperated friendly factions or steam ids");ɜ="RSM.Doors";ȧ=
"EnableDoorManagement";ʿ.Set(ɜ,ȧ,ʷ);ʿ.SetComment(ɜ,ȧ,"enable door management functionality");ȧ="DoorCloseTimer";ʿ.Set(ɜ,ȧ,ʶ);ʿ.SetComment(ɜ,ȧ,
"door open timer (x100 ticks)");ȧ="AirlockDoorDisableTimer";ʿ.Set(ɜ,ȧ,ʵ);ʿ.SetComment(ɜ,ȧ,"airlock door disable timer (x100 ticks)");ɜ="RSM.Keywords";
ȧ="Ignore";ʿ.Set(ɜ,ȧ,ʴ);ʿ.SetComment(ɜ,ȧ,"to identify blocks which RSM should ignore");ȧ="RsmLcds";ʿ.Set(ɜ,ȧ,ʳ);ʿ.
SetComment(ɜ,ȧ,"to identify RSM lcds");ȧ="ColourSyncLcds";ʿ.Set(ɜ,ȧ,ʲ);ʿ.SetComment(ɜ,ȧ,"to identify non RSM lcds for colour sync"
);ȧ="AuxiliaryBlocks";ʿ.Set(ɜ,ȧ,ʱ);ʿ.SetComment(ɜ,ȧ,"to identify aux blocks");ȧ="DefensivePdcs";ʿ.Set(ɜ,ȧ,ʰ);ʿ.SetComment
(ɜ,ȧ,"to identify defensive _normalPdcs");ȧ="MinimumThrusters";ʿ.Set(ɜ,ȧ,ʯ);ʿ.SetComment(ɜ,ȧ,
"to identify minimum epsteins");ȧ="DockingThrusters";ʿ.Set(ɜ,ȧ,ʡ);ʿ.SetComment(ɜ,ȧ,"to identify docking epsteins");ȧ="NavLights";ʿ.Set(ɜ,ȧ,ʠ);ʿ.
SetComment(ɜ,ȧ,"to identify navigational lights");ȧ="Airlock";ʿ.Set(ɜ,ȧ,ʀ);ʿ.SetComment(ɜ,ȧ,"to identify airlock doors and vents")
;ɜ="RSM.InitNaming";ȧ="NameDelimiter";ʿ.Set(ɜ,ȧ,ʍ.ToString());ʿ.SetComment(ɜ,ȧ,"single char delimiter for names");ȧ=
"NameWeaponTypes";ʿ.Set(ɜ,ȧ,ʌ);ʿ.SetComment(ɜ,ȧ,"append type names to all weapons on init");ȧ="NameDriveTypes";ʿ.Set(ɜ,ȧ,ʋ);ʿ.SetComment(
ɜ,ȧ,"append type names to all drives on init");string Ѻ="";foreach(string ѹ in ʊ){if(Ѻ!="")Ѻ+=",";Ѻ+=ѹ;}ȧ=
"BlocksToNumber";ʿ.Set(ɜ,ȧ,ʋ);ʿ.SetComment(ɜ,ȧ,"comma seperated list of block names to be numbered at init");ɜ="RSM.Misc";ȧ=
"DisableLightingControl";ʿ.Set(ɜ,ȧ,ʉ);ʿ.SetComment(ɜ,ȧ,"disable all lighting control");ȧ="DisableLcdColourControl";ʿ.Set(ɜ,ȧ,ʈ);ʿ.SetComment(ɜ,ȧ
,"disable text colour control for all lcds");ȧ="ShowBasicTelemetry";ʿ.Set(ɜ,ȧ,ʇ);ʿ.SetComment(ɜ,ȧ,
"show basic telemetry data on advanced thrust lcds");string Ѹ="";foreach(double Ĩ in ʆ){if(Ѹ!="")Ѹ+=",";Ѹ+=(Ĩ*100).ToString();}ȧ="DecelerationPercentages";ʿ.Set(ɜ,ȧ,Ѹ);ʿ.
SetComment(ɜ,ȧ,"thrust percentages to show on advanced thrust lcds");ȧ="ShowThrustInMetric";ʿ.Set(ɜ,ȧ,ʅ);ʿ.SetComment(ɜ,ȧ,
"show basic telemetry data on advanced thrust lcds");ȧ="ReactorFillRatio";ʿ.Set(ɜ,ȧ,ʄ);ʿ.SetComment(ɜ,ȧ,"0-1, fill ratio for reactors");ɜ="RSM.Debug";ȧ="VerboseDebugging";
ʿ.Set(ɜ,ȧ,ʃ);ʿ.SetComment(ɜ,ȧ,"prints more logging info to PB details");ȧ="RuntimeProfiling";ʿ.Set(ɜ,ȧ,ʂ);ʿ.SetComment(ɜ,
ȧ,"prints script runtime profiling info to PB details");ȧ="BlockRefreshFreq";ʿ.Set(ɜ,ȧ,ʐ);ʿ.SetComment(ɜ,ȧ,
"ticks x100 between block refreshes");ȧ="StallCount";ʿ.Set(ɜ,ȧ,ʁ);ʿ.SetComment(ɜ,ȧ,"ticks x100 to stall between runs");ɜ="RSM.Stance";ȧ="CurrentStance";ʿ.
Set(ɜ,ȧ,đ);ʿ.SetSectionComment(ɜ,й+" Stances\n Add or remove as required\n"+й);string ѷ="Red, Green, Blue, Alpha";foreach(
var ҁ in Ѭ){ɜ="RSM.Stance."+ҁ.Key;à Ù=ҁ.Value;à ѽ=null;if(Ù.ā!=""){ѽ=Ѭ[Ù.ā];ȧ="Inherits";ʿ.Set(ɜ,ȧ,Ù.ā);ʿ.SetComment(ɜ,ȧ,
"Use stance of this name as a template for settings");}ȧ="Torps";if(ѽ!=null&&Ù.ÿ==ѽ.ÿ){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ÿ.ToString());ʿ.SetComment(ɜ,ȧ,
ѵ(typeof(Ơ)));}ȧ="Pdcs";if(ѽ!=null&&Ù.þ==ѽ.þ){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.þ.ToString());ʿ.
SetComment(ɜ,ȧ,ѵ(typeof(ǔ)));}ȧ="Kinetics";if(ѽ!=null&&Ù.ý==ѽ.ý){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ý.ToString(
));ʿ.SetComment(ɜ,ȧ,ѵ(typeof(Ǔ)));}ȧ="MainThrust";if(ѽ!=null&&Ù.ü==ѽ.ü){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ
,ȧ,Ù.ü.ToString());ʿ.SetComment(ɜ,"MainThrust",ѵ(typeof(ǒ)));}ȧ="ManeuveringThrust";if(ѽ!=null&&Ù.û==ѽ.û){if(ʿ.
ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.û.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(Ǘ)));}ȧ="Spotlights";if(ѽ!=null&&Ù.ú==ѽ.ú)
{if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ú.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(ǖ)));}ȧ="ExteriorLights";
if(ѽ!=null&&Ù.ù==ѽ.ù){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ù.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(Ǖ)));}
ȧ="ExteriorLightColour";if(ѽ!=null&&Ù.ø==ѽ.ø){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ѳ(Ù.ø));ʿ.SetComment(ɜ,
ȧ,ѷ);}ȧ="InteriorLights";if(ѽ!=null&&Ù.ö==ѽ.ö){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ö.ToString());ʿ.
SetComment(ɜ,ȧ,ѵ(typeof(Ǖ)));}ȧ="InteriorLightColour";if(ѽ!=null&&Ù.õ==ѽ.õ){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ѳ(
Ù.õ));ʿ.SetComment(ɜ,ȧ,ѷ);}ȧ="NavLights";if(ѽ!=null&&Ù.ô==ѽ.ô){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ô.
ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(Ǖ)));}ȧ="LcdTextColour";if(ѽ!=null&&Ù.ó==ѽ.ó){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.
Set(ɜ,ȧ,Ѳ(Ù.ó));ʿ.SetComment(ɜ,ȧ,ѷ);}ȧ="TanksAndBatteries";if(ѽ!=null&&Ù.ò==ѽ.ò){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{
ʿ.Set(ɜ,ȧ,Ù.ò.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(Ǒ)));}ȧ="NavOsEfcBurnPercentage";if(ѽ!=null&&Ù.ñ==ѽ.ñ){if(ʿ.
ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ñ.ToString());ʿ.SetComment(ɜ,ȧ,"Burn % 0-100, -1 for no change");}ȧ="EfcBoost";if(
ѽ!=null&&Ù.ð==ѽ.ð){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ð.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(Ơ)));}ȧ=
"NavOsAbortEfcOff";if(ѽ!=null&&Ù.Ā==ѽ.Ā){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.Ā.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(ǁ))
);}ȧ="AuxMode";if(ѽ!=null&&Ù.Ă==ѽ.Ă){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.Ă.ToString());ʿ.SetComment(ɜ,ȧ
,ѵ(typeof(Ơ)));}ȧ="Extractor";if(ѽ!=null&&Ù.ē==ѽ.ē){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù.ē.ToString());ʿ
.SetComment(ɜ,ȧ,ѵ(typeof(ǀ)));}ȧ="KeepAlives";if(ѽ!=null&&Ù.Ĕ==ѽ.Ĕ){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);}else{ʿ.Set(ɜ,ȧ,Ù
.Ĕ.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(Ơ)));}ȧ="HangarDoors";if(ѽ!=null&&Ù.Ē==ѽ.Ē){if(ʿ.ContainsKey(ɜ,ȧ))ʿ.Delete(ɜ,ȧ);
}else{ʿ.Set(ɜ,ȧ,Ù.Ē.ToString());ʿ.SetComment(ɜ,ȧ,ѵ(typeof(ƿ)));}}ɜ="RSM.System";ȧ="ShipName";ʿ.Set(ɜ,ȧ,ʒ);ʿ.
SetSectionComment(ɜ,й+" System\n All items below this point are\n set automatically when running init\n"+й);ɜ="RSM.InitItems";foreach(ɭ ʗ
in ϯ){ȧ=ʗ.ϵ.SubtypeId;ʿ.Set(ɜ,ȧ,ʗ.Ђ);}ɜ="RSM.InitSubSystems";ʿ.Set(ɜ,"Reactors",F);ʿ.Set(ɜ,"Batteries",F);ʿ.Set(ɜ,"Pdcs",Î
);ʿ.Set(ɜ,"TorpLaunchers",Ȋ);ʿ.Set(ɜ,"KineticWeapons",Z);ʿ.Set(ɜ,"H2Storage",Õ);ʿ.Set(ɜ,"O2Storage",ë);ʿ.Set(ɜ,
"MainThrust",ä);ʿ.Set(ɜ,"RCSThrust",ȇ);ʿ.Set(ɜ,"Gyros",Ҩ);ʿ.Set(ɜ,"CargoStorage",ʥ);ʿ.Set(ɜ,"Welders",ƥ);Me.CustomData=ʿ.ToString();
}void ғ(string ɏ){string[]ʕ=ɏ.Split(new string[]{"[Stances]"},StringSplitOptions.None);string[]Ғ=ʕ[0].Split('\n');string
ґ=ʕ[1];try{for(int ě=1;ě<Ғ.Length;ě++){if(Ғ[ě].Contains("=")){string Ґ=Ғ[ě].Substring(1);switch(Ғ[(ě-1)]){case
"Ship name. Blocks without this name will be ignored":ʒ=Ґ;break;case"Block name delimiter, used by init. One character only!":ʍ=char.Parse(Ґ.Substring(0,1));break;case
"Keyword used to identify RSM _allLcds.":ʳ=Ґ;break;case"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʱ=Ґ;break;
case"Keyword used to identify defence _normalPdcs.":ʰ=Ґ;break;case"Keyword used to identify minimum epstein drives.":ʯ=Ґ;
break;case"Keyword used to identify docking epstein drives.":ʡ=Ґ;break;case"Keyword to ignore block.":ʴ=Ґ;break;case
"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʻ=bool.Parse(Ґ);break;case"Disable lighting all control.":ʉ=bool.Parse(Ґ);break;case
"Disable LCD Text Colour Enforcement.":ʈ=bool.Parse(Ґ);break;case"Enable Weapon Autoload Functionality.":ʽ=bool.Parse(Ґ);break;case
"Number these blocks at init.":ʊ.Clear();string[]ҏ=Ґ.Split(',');foreach(string ѹ in ҏ){if(ѹ!="")ʊ.Add(ѹ);}break;case
"Add type names to weapons at init.":ʌ=bool.Parse(Ґ);break;case"Show basic telemetry.":ʇ=bool.Parse(Ґ);break;case"Show Decel Percentages (comma seperated)."
:ʆ.Clear();string[]Ҏ=Ґ.Split(',');foreach(string Ĩ in Ҏ){ʆ.Add(double.Parse(Ĩ)/100);}break;case"Fusion Fuel count":ϯ[0].Ђ
=int.Parse(Ґ);break;case"Fuel tank count":ϯ[1].Ђ=int.Parse(Ґ);break;case"Jerry can count":ϯ[2].Ђ=int.Parse(Ґ);break;case
"40mm PDC Magazine count":ϯ[3].Ђ=int.Parse(Ґ);break;case"40mm Teflon Tungsten PDC Magazine count":ϯ[4].Ђ=int.Parse(Ґ);break;case
"220mm Torpedo count":case"Torpedo count":ϯ[5].Ђ=int.Parse(Ґ);break;case"220mm MCRN torpedo count":ϯ[6].Ђ=int.Parse(Ґ);break;case
"220mm UNN torpedo count":ϯ[7].Ђ=int.Parse(Ґ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":ϯ[8].Ђ=int.Parse(Ґ);break;case
"Large ramshacke torpedo count":ϯ[9].Ђ=int.Parse(Ґ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":ϯ[10].Ђ=int.Parse(Ґ);break;
case"Dawson 100mm UNN Railgun rounds count":ϯ[11].Ђ=int.Parse(Ґ);break;case"Stiletto 100mm MCRN Railgun rounds count":ϯ[12].
Ђ=int.Parse(Ґ);break;case"T-47 80mm Railgun rounds count":ϯ[13].Ђ=int.Parse(Ґ);break;case
"Foehammer 120mm MCRN rounds count":ϯ[14].Ђ=int.Parse(Ґ);break;case"Farren 120mm UNN Railgun rounds count":ϯ[15].Ђ=int.Parse(Ґ);break;case
"Kess 180mm rounds count":ϯ[16].Ђ=int.Parse(Ґ);break;case"Steel plate count":ϯ[17].Ђ=int.Parse(Ґ);break;case
"Doors open timer (x100 ticks, default 3)":ʶ=int.Parse(Ґ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ʵ=int.Parse(Ґ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":ʁ=int.Parse(Ґ);break;case"Full refresh frequency (x100 ticks, default 50)":ʐ=int.Parse(Ґ);break;case
"Verbose script debugging. Prints more logging info to PB details.":ʃ=bool.Parse(Ґ);break;case"Private spawn (don't inject faction tag into SK custom data).":ʹ=bool.Parse(Ґ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":ʸ=string.Join("\n",Ґ.Split(','));break;case"Current Stance":đ=Ґ;à Ѽ;if(!Ѭ.TryGetValue(đ,out Ѽ)){đ="N/A";Đ=null;}else Đ=
Ѽ;break;case"Reactor Integrity":F=float.Parse(Ґ);break;case"Battery Integrity":o=float.Parse(Ґ);break;case"PDC Integrity"
:Î=int.Parse(Ґ);break;case"Torpedo Integrity":Ȋ=int.Parse(Ґ);break;case"Railgun Integrity":Z=int.Parse(Ґ);break;case
"H2 Tank Integrity":Õ=double.Parse(Ґ);break;case"O2 Tank Integrity":ë=double.Parse(Ґ);break;case"Epstein Integrity":ä=float.Parse(Ґ);break;
case"RCS Integrity":ȇ=float.Parse(Ґ);break;case"Gyro Integrity":Ҩ=int.Parse(Ґ);break;case"Cargo Integrity":ʥ=double.Parse(Ґ)
;break;case"Welder Integrity":ƥ=int.Parse(Ґ);break;}}}}catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);
}try{string[]ҍ=ґ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(ʃ)Echo("Parsing "+(ҍ.Length-1)+" stances");int
Ҍ=24;Dictionary<string,à>ʖ=new Dictionary<string,à>();int[]ҋ=new int[]{0,5,25,50,75,100};for(int ě=1;ě<ҍ.Length;ě++){
string[]Ѷ=ҍ[ě].Split('=');string ʓ="";int[]ѩ=new int[Ҍ];ʓ=Ѷ[0].Split(' ')[0];if(ʃ)Echo("Parsing '"+ʓ+"'");for(int Ѩ=0;Ѩ<ѩ.
Length;Ѩ++){string[]ѧ=Ѷ[(Ѩ+1)].Split('\n');ѩ[Ѩ]=int.Parse(ѧ[0]);}à Ø=new à();if(ѩ[0]==0)Ø.ÿ=Ơ.Off;else Ø.ÿ=Ơ.On;if(ѩ[1]==0)Ø.þ
=ǔ.Off;else if(ѩ[1]==1)Ø.þ=ǔ.MinDefence;else if(ѩ[1]==2)Ø.þ=ǔ.AllDefence;else if(ѩ[1]==3)Ø.þ=ǔ.Offence;else if(ѩ[1]==4)Ø.
þ=ǔ.AllOnOnly;if(ѩ[2]==0)Ø.ý=Ǔ.Off;else if(ѩ[2]==1)Ø.ý=Ǔ.HoldFire;else if(ѩ[2]==2)Ø.ý=Ǔ.OpenFire;if(ѩ[3]==0)Ø.ü=ǒ.Off;
else if(ѩ[3]==1)Ø.ü=ǒ.On;else if(ѩ[3]==2)Ø.ü=ǒ.Minimum;if(ѩ[4]==0)Ø.û=Ǘ.Off;else if(ѩ[4]==1)Ø.û=Ǘ.On;else if(ѩ[4]==2)Ø.û=Ǘ.
ForwardOff;else if(ѩ[4]==3)Ø.û=Ǘ.ReverseOff;if(ѩ[5]==0)Ø.ú=ǖ.Off;else if(ѩ[5]==1)Ø.ú=ǖ.On;else if(ѩ[5]==2)Ø.ú=ǖ.OnMax;if(ѩ[6]==0)Ø
.ù=Ǖ.Off;else Ø.ù=Ǖ.On;Ø.ø=new Color(ѩ[7],ѩ[8],ѩ[9],ѩ[10]);if(ѩ[11]==0)Ø.ö=Ǖ.Off;else Ø.ö=Ǖ.On;Ø.õ=new Color(ѩ[12],ѩ[13],
ѩ[14],ѩ[15]);if(ѩ[16]==0)Ø.ò=Ǒ.Auto;else if(ѩ[16]==1)Ø.ò=Ǒ.StockpileRecharge;else if(ѩ[16]==2)Ø.ò=Ǒ.Discharge;if(ѩ[17]==0
)Ø.ð=Ơ.Off;else Ø.ð=Ơ.On;Ø.ñ=ҋ[ѩ[18]];if(ѩ[19]==0)Ø.Ā=ǁ.NoChange;else Ø.Ā=ǁ.Abort;if(ѩ[20]==0)Ø.Ă=Ơ.Off;else Ø.Ă=Ơ.On;if(
ѩ[21]==0)Ø.ē=ǀ.Off;else if(ѩ[21]==1)Ø.ē=ǀ.On;else if(ѩ[21]==2)Ø.ē=ǀ.FillWhenLow;else if(ѩ[21]==3)Ø.ē=ǀ.KeepFull;if(ѩ[22]
==0)Ø.Ĕ=Ơ.Off;else Ø.Ĕ=Ơ.On;if(ѩ[23]==0)Ø.Ē=ƿ.Closed;else if(ѩ[23]==1)Ø.Ē=ƿ.Open;else Ø.Ē=ƿ.NoChange;ʖ.Add(ʓ,Ø);}if(ʖ.
Count>=1){if(ʃ)Echo("Finished parsing "+ʖ.Count+" stances.");Ѭ=ʖ;}else{Echo("Didn't find any stances!");}}catch(Exception ex)
{Echo("Custom Data Error (stances)\n"+ex.Message);}}void Ѧ(){bool ѥ=ʟ();if(!ѥ){Ѫ();ѻ();}if(Đ==null){Đ=Ѭ.First().Value;}
string Ѥ="";string ѣ="";if(!ʹ){Ѥ=" ".PadRight(129,' ')+Τ+"\n";ѣ="\n".PadRight(19,'\n');}Σ=Ѥ+ѣ;Ρ=Ѥ+string.Join("\n",ʸ.Split(','
))+ѣ;if(ʒ==""){if(ʃ)Echo("No ship name, trying to pull it from PB name...");string Ѣ="Untitled Ship";try{string[]ѡ=Me.
CustomName.Split(ʍ);if(ѡ.Length>1){ʒ=ѡ[0];if(ʃ)Echo(ʒ);}else ʒ=Ѣ;}catch{ʒ=Ѣ;}}}void Ѡ(bool Ú=true,bool џ=false,bool ː=false){MyIni
ɛ=new MyIni();string ɏ=Me.CustomData;MyIniParseResult Ɖ;if(!ɛ.TryParse(ɏ,out Ɖ)){Ъ.Add(new ѓ("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ɜ,ȧ;if(Ú){ɜ="RSM.Stance";ȧ="CurrentStance";ɛ.Set(ɜ,ȧ,đ);}else{ɜ="RSM.System";ȧ="ShipName";ɛ.Set(ɜ,ȧ,
ʒ);}if(џ){ɜ="RSM.InitSubSystems";ɛ.Set(ɜ,"Reactors",F);ɛ.Set(ɜ,"Batteries",o);ɛ.Set(ɜ,"Pdcs",Î);ɛ.Set(ɜ,"TorpLaunchers",Ȋ
);ɛ.Set(ɜ,"KineticWeapons",Z);ɛ.Set(ɜ,"H2Storage",Õ);ɛ.Set(ɜ,"O2Storage",ë);ɛ.Set(ɜ,"MainThrust",ä);ɛ.Set(ɜ,"RCSThrust",ȇ
);ɛ.Set(ɜ,"Gyros",Ҩ);ɛ.Set(ɜ,"CargoStorage",ʥ);ɛ.Set(ɜ,"Welders",ƥ);}if(ː){ɜ="RSM.InitItems";foreach(ɭ ʗ in ϯ){ȧ=ʗ.ϵ.
SubtypeId;ɛ.Set(ɜ,ȧ,ʗ.Ђ);}}Me.CustomData=ɛ.ToString();}string ѵ(Type Ѵ){string ѳ="";foreach(var ğ in Enum.GetValues(Ѵ)){if(ѳ!="")
ѳ+=", ";ѳ+=ğ.ToString();}return ѳ;}string Ѳ(Color Ş){return Ş.R+", "+Ş.G+", "+Ş.B+", "+Ş.A;}void ѱ(Exception Ѱ,string ѯ){
Runtime.UpdateFrequency=UpdateFrequency.None;string Ѯ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ѯ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(Ѯ);List<IMyTextPanel>ѭ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ѭ,ɉ=>ɉ.CustomName
.Contains(ʳ));foreach(IMyTextPanel ũ in ѭ){ũ.WriteText(Ѯ);ũ.FontColor=new Color(193,0,197,255);}throw Ѱ;}Dictionary<
string,à>Ѭ=new Dictionary<string,à>();void Ѫ(){Ѭ=new Dictionary<string,à>{{"Cruise",new à{ÿ=Ơ.On,þ=ǔ.AllDefence,ý=Ǔ.HoldFire,ü
=ǒ.EpsteinOnly,û=Ǘ.ForwardOff,ú=ǖ.Off,ù=Ǖ.On,ø=new Color(33,144,255,255),ö=Ǖ.On,õ=new Color(255,214,170,255),ô=Ǖ.On,ó=new
Color(33,144,255,255),ò=Ǒ.Auto,ñ=50,ð=Ơ.NoChange,Ā=ǁ.Abort,Ă=Ơ.NoChange,ē=ǀ.KeepFull,Ĕ=Ơ.On,Ē=ƿ.NoChange,}},{"StealthCruise",
new à{ā="Cruise",ÿ=Ơ.On,þ=ǔ.AllDefence,ý=Ǔ.HoldFire,ü=ǒ.Minimum,û=Ǘ.ForwardOff,ú=ǖ.Off,ù=Ǖ.Off,ø=new Color(0,0,0,255),ö=Ǖ.
On,õ=new Color(23,73,186,255),ô=Ǖ.Off,ó=new Color(23,73,186,255),ò=Ǒ.Auto,ñ=5,ð=Ơ.Off,Ā=ǁ.Abort,Ă=Ơ.NoChange,ē=ǀ.KeepFull,
Ĕ=Ơ.On,Ē=ƿ.NoChange}},{"Docked",new à{ā="Cruise",ÿ=Ơ.On,þ=ǔ.AllDefence,ý=Ǔ.HoldFire,ü=ǒ.Off,û=Ǘ.Off,ú=ǖ.Off,ù=Ǖ.On,ø=new
Color(33,144,255,255),ö=Ǖ.On,õ=new Color(255,240,225,255),ô=Ǖ.On,ó=new Color(255,255,255,255),ò=Ǒ.StockpileRecharge,ñ=-1,ð=Ơ.
NoChange,Ā=ǁ.Abort,Ă=Ơ.Off,ē=ǀ.On,Ĕ=Ơ.On,Ē=ƿ.NoChange}},{"Docking",new à{ā="Docked",ÿ=Ơ.On,þ=ǔ.AllDefence,ý=Ǔ.HoldFire,ü=ǒ.Off,û
=Ǘ.On,ú=ǖ.OnMax,ù=Ǖ.On,ø=new Color(33,144,255,255),ö=Ǖ.On,õ=new Color(212,170,83,255),ô=Ǖ.On,ó=new Color(212,170,83,255),
ò=Ǒ.Auto,ñ=-1,ð=Ơ.NoChange,Ā=ǁ.Abort,Ă=Ơ.Off,ē=ǀ.KeepFull,Ĕ=Ơ.On,Ē=ƿ.NoChange}},{"NoAttack",new à{ā="Docked",ÿ=Ơ.Off,þ=ǔ.
Off,ý=Ǔ.Off,ü=ǒ.On,û=Ǘ.On,ú=ǖ.Off,ù=Ǖ.On,ø=new Color(255,255,255,255),ö=Ǖ.On,õ=new Color(84,157,82,255),ô=Ǖ.NoChange,ó=new
Color(84,157,82,255),ò=Ǒ.NoChange,ñ=-1,ð=Ơ.NoChange,Ā=ǁ.NoChange,Ă=Ơ.NoChange,ē=ǀ.KeepFull,Ĕ=Ơ.On,Ē=ƿ.NoChange}},{"Combat",
new à{ā="Cruise",ÿ=Ơ.On,þ=ǔ.AllDefence,ý=Ǔ.OpenFire,ü=ǒ.On,û=Ǘ.On,ú=ǖ.Off,ù=Ǖ.Off,ø=new Color(0,0,0,255),ö=Ǖ.On,õ=new Color
(210,98,17,255),ô=Ǖ.Off,ó=new Color(210,98,17,255),ò=Ǒ.ManagedDischarge,ñ=100,ð=Ơ.On,Ā=ǁ.Abort,Ă=Ơ.On,ē=ǀ.KeepFull,Ĕ=Ơ.On
,Ē=ƿ.NoChange}},{"CQB",new à{ā="Combat",ÿ=Ơ.On,þ=ǔ.Offence,ý=Ǔ.OpenFire,ü=ǒ.On,û=Ǘ.On,ú=ǖ.Off,ù=Ǖ.Off,ø=new Color(0,0,0,
255),ö=Ǖ.On,õ=new Color(243,18,18,255),ô=Ǖ.Off,ó=new Color(243,18,18,255),ò=Ǒ.ManagedDischarge,ñ=100,ð=Ơ.On,Ā=ǁ.Abort,Ă=Ơ.
On,ē=ǀ.KeepFull,Ĕ=Ơ.On,Ē=ƿ.NoChange}},{"WeaponsHot",new à{ā="CQB",ÿ=Ơ.On,þ=ǔ.Offence,ý=Ǔ.OpenFire,ü=ǒ.NoChange,û=Ǘ.
NoChange,ú=ǖ.NoChange,ù=Ǖ.NoChange,ø=new Color(0,0,0,255),ö=Ǖ.NoChange,õ=new Color(243,18,18,255),ô=Ǖ.NoChange,ó=new Color(243,
18,18,255),ò=Ǒ.ManagedDischarge,ñ=-1,ð=Ơ.NoChange,Ā=ǁ.NoChange,Ă=Ơ.NoChange,ē=ǀ.KeepFull,Ĕ=Ơ.On,Ē=ƿ.NoChange}}};}class ѫ{
public IMyDoor ɒ;public int Ҿ=0;public int ҽ=0;public bool Ҽ=false;public bool һ=false;}class Һ{public string ҹ;public bool Ҹ=
false;public int ҷ=0;public bool Ҷ=false;public List<ѫ>ҵ=new List<ѫ>();public List<IMyAirVent>Ҵ=new List<IMyAirVent>();}int ҳ
=0;int Ҳ=0;int ұ=0;int Ұ(ѫ ҝ,bool ɣ=false){bool ү=false;bool ҿ=false;if(ҝ.ɒ==null)return 0;bool ĵ=ҝ.ɒ.OpenRatio>0;ҳ++;if(
Ҟ(ҝ.ɒ))ұ++;if(!ɣ||ĵ)ҝ.ɒ.Enabled=true;if(ĵ){if(ҝ.Ҿ==0){ҿ=true;}ҝ.Ҿ++;if(ҝ.Ҿ>=ʶ){ҝ.Ҿ=0;ҝ.ɒ.CloseDoor();ү=true;}}else{Ҳ++;if
(ҝ.Ҿ!=0){ү=true;ҝ.Ҿ=0;}}int ħ=0;if(ү)ħ=1;else if(ҿ)ħ=2;return ħ;}void Ӊ(){if(!ʷ){if(ʃ)Echo("Door management is disabled."
);return;}foreach(Һ ɣ in χ){bool ӈ=false;foreach(ѫ ҝ in ɣ.ҵ){if(ҝ.ɒ==null)continue;int Ӈ=Ұ(ҝ,true);if(Ӈ==1){if(ʃ)Echo(
"Airlock door "+ҝ.ɒ.CustomName+" just closed");if(ɣ.Ҷ)ɣ.Ҷ=false;else{ɣ.Ҹ=true;ҝ.һ=true;if(ʃ)Echo("Airlock "+ɣ.ҹ+" needs to cycle");}}
else if(Ӈ==2){if(ʃ)Echo("Airlock door "+ҝ.ɒ.CustomName+" just opened");ӈ=true;}}bool ӆ=true;if(ɣ.Ҹ){foreach(ѫ ҝ in ɣ.ҵ){if(ҝ
.ɒ==null)continue;if(ҝ.ɒ.OpenRatio>0){ҝ.ɒ.CloseDoor();ӆ=false;}else ҝ.ɒ.Enabled=false;}bool Ӆ=false;foreach(IMyAirVent Ӄ
in ɣ.Ҵ){if(Ӄ==null)continue;if(!Ӄ.Enabled)Ӄ.Enabled=true;if(!Ӄ.Depressurize)Ӄ.Depressurize=true;if(Ӄ.CanPressurize&&Ӄ.
GetOxygenLevel()<.01&&ɣ.Ҹ&&ӆ)Ӆ=true;}ɣ.ҷ++;bool ӂ=true;if(ɣ.ҷ>=ʵ){ӂ=false;Ӆ=true;}if(Ӆ){ɣ.Ҹ=false;ɣ.ҷ=0;ɣ.Ҷ=true;foreach(ѫ ҝ in ɣ.ҵ){
if(ҝ.ɒ==null)continue;ҝ.ɒ.Enabled=true;if(ҝ.һ)ҝ.һ=false;else if(ӂ)ҝ.ɒ.OpenDoor();}}}else if(ӈ){foreach(ѫ ҝ in ɣ.ҵ){if(ҝ.ɒ
==null)continue;if(ҝ.ɒ.OpenRatio==0)ҝ.ɒ.Enabled=false;}}else{foreach(ѫ ҝ in ɣ.ҵ){ҝ.ɒ.Enabled=true;}}}}void Ӂ(){if(!ʷ){if(ʃ
)Echo("Door management is disabled.");return;}ҳ=0;Ҳ=0;ұ=0;foreach(ѫ ҝ in ψ)Ұ(ҝ);}void Ӏ(ƿ H){if(H==ƿ.NoChange)return;
foreach(IMyAirtightHangarDoor Ң in Ϣ){if(Ң==null)continue;if(H==ƿ.Closed)Ң.CloseDoor();else Ң.OpenDoor();}}void Ҕ(string ҡ,
string Ҡ){ҡ=ҡ.ToLower();foreach(ѫ ҝ in ψ){if(Ҡ==""||ҝ.ɒ.CustomName.Contains(Ҡ)){bool ҟ=Ҟ(ҝ.ɒ);if(ҟ&&(ҡ=="locked"||ҡ=="toggle")
)ҝ.ɒ.ApplyAction("AnyoneCanUse");if(!ҟ&&(ҡ=="unlocked"||ҡ=="toggle"))ҝ.ɒ.ApplyAction("AnyoneCanUse");}}}bool Ҟ(IMyDoor ҝ)
{var Ɲ=ҝ.GetActionWithName("AnyoneCanUse");StringBuilder Ҝ=new StringBuilder();Ɲ.WriteValue(ҝ,Ҝ);return(Ҝ.ToString()==
"On");}double қ;int Қ=10;double ҙ=3;double Ҙ=245000;double җ=50000;double Җ=100;void ҕ(ǀ H){foreach(IMyTerminalBlock ң in ϡ)
{if(ң==null)continue;if(H==ǀ.Off)ң.ApplyAction("OnOff_Off");else ң.ApplyAction("OnOff_On");}}void ҭ(){if(ϡ.Count<1&&Ϡ.
Count>0)қ=(ҙ*җ);else қ=(ҙ*Ҙ);}void Ү(){if(Đ.ē==ǀ.Off||Đ.ē==ǀ.On){if(ʃ)Echo("Extractor management disabled.");}else if(Ϛ.Count
<1){if(ʃ)Echo("No tanks!");}else if(Đ.ē==ǀ.FillWhenLow&&Җ<Қ){Ή=true;if(ʃ)Echo("Fuel low! ("+Җ+"% / "+Қ+"%)");}else if(Đ.ē
==ǀ.KeepFull&&Ô<(Ö-қ)){Ή=true;if(ʃ)Echo("Fuel ready for top up ("+Ô+" < "+(Ö-қ)+")");}else if(ʃ){Echo("Fuel level OK ("+Җ+
"%).");if(Đ.ē==ǀ.KeepFull)Echo("Keeping tanks full\n("+Ô+" < "+(Ö-қ)+")");}}void Ҭ(){Ή=false;IMyTerminalBlock ҫ=null;int ɭ=1;
foreach(IMyTerminalBlock ң in ϡ){if(ң.IsFunctional){ҫ=ң;break;}}if(ҫ==null||ϯ[ɭ].Ѓ<1){ɭ=2;foreach(IMyTerminalBlock ң in Ϡ){if(ң
.IsFunctional){ҫ=ң;ɭ=2;if(ϯ[ɭ].Ѓ<1)break;}}if(ҫ==null){Η=true;return;}}Η=false;if(ϯ[ɭ].Ѓ<1){Θ=ϯ[ɭ].ϲ;return;}Θ="";Ж ϓ=new
Ж();ϓ.ɒ=ҫ;ϓ.ϓ=ҫ.GetInventory();if(ϓ.ϓ.VolumeFillFactor>0){if(ʃ)Echo("Extractor already loaded, waiting...");ҫ.ApplyAction
("OnOff_On");return;}List<Ж>Ҫ=new List<Ж>();Ҫ.Add(ϓ);if(ʃ)Echo("Attempting to load extractor "+ҫ.CustomName);bool ʞ=щ(ϯ[ɭ
].ϸ,Ҫ,ϯ[ɭ].ϵ,1);string ҩ="fuel tank";if(ɭ==2)ҩ="jerry can";if(ʞ)Ъ.Add(new ѓ("Loaded a "+ҩ,"Sucessfully loaded a "+ҩ+
" into an extractor.",0));}double Ҩ=0;int ҧ=0;double Ҧ=0;void ҥ(bool Á,bool Ŧ){ҧ=0;foreach(IMyGyro Ҥ in ϟ){if(Ҥ!=null&&Ҥ.IsFunctional){ҧ++;if
(Ŧ)Ҥ.Enabled=Á;}}Ҧ=Math.Round(100*(ҧ/Ҩ));}void ӄ(string ў,bool ˁ=true,bool ˑ=true,bool ː=true){if(ʃ)Echo(
"Initialising a ship as '"+ў+"'...");Ύ=true;ʒ=ў;Λ=ˁ;Ν=ˑ;Μ=ː;Ў();}void Ў(){switch(Α){case 0:ˆ();Β=0;if(ʂ)Echo("Took "+ͺ());break;case 1:ϼ();if(ʂ)
Echo("Took "+ͺ());break;case 2:if(ʃ)Echo("Initialising lcds...");ƅ();if(Ν){if(ʃ)Echo("Initialising subsystem values...");Ȅ()
;Ȑ();K();O();Ñ();è();ʮ();Î=θ.Count+η.Count;Ȋ=ε.Count;Z=ζ.Count;Ҩ=ϟ.Count;ƥ=Ϊ.Count;}if(Μ){if(ʃ)Echo(
"Initialising item values...");ϻ();}if(Λ){if(ʃ)Echo("Initialising block names...");Љ();}Ѡ(false,Ν,Μ);Ъ.Add(new ѓ("Init:"+ʒ,"Initialised '"+ʒ+
"'\nGood Hunting!",3));Α=0;Ύ=false;if(ʂ)Echo("Took "+ͺ());return;}Α++;}class Ѝ{public int Ќ=0;public int Ћ=0;public int Њ=0;}void Љ(){
Dictionary<string,Ѝ>Ј=new Dictionary<string,Ѝ>();if(ʊ.Count>0){foreach(string R in ʊ){if(ʃ)Echo("Numbering "+R);Ј.Add(R,new Ѝ());}
foreach(var Ѕ in φ){Ѝ Ї;if(Ј.TryGetValue(Ѕ.Value,out Ї)){Ј[Ѕ.Value].Ћ++;}}foreach(var І in Ј){if(І.Value.Ћ<10)І.Value.Њ=1;else
if(І.Value.Ћ>99)І.Value.Њ=3;else І.Value.Њ=2;}}foreach(var Ѕ in φ){string Є="";string Џ=Ѕ.Value;Ѝ Б;if(Ј.TryGetValue(Ѕ.
Value,out Б)){if(Б.Ћ>1){Б.Ќ++;Є=ʍ+Б.Ќ.ToString().PadLeft(Б.Њ,'0');}}Ѕ.Key.CustomName=ʒ+ʍ+Џ+Є+Н(Ѕ.Key.CustomName,Џ);}}string Н
(string ȧ,string М=""){try{string[]Л=ȧ.Split(ʍ);string[]К=М.Split(ʍ);string Ɖ="";if(Л.Length<3)return"";for(int ě=2;ě<Л.
Length;ě++){int Й=0;bool И=int.TryParse(Л[ě],out Й);if(И)Л[ě]="";foreach(string З in К){if(З==Л[ě])Л[ě]="";}if(Л[ě]!="")Ɖ+=ʍ+Л
[ě];}return Ɖ;}catch{return"";}}class Ж{public IMyTerminalBlock ɒ{get;set;}public IMyInventory ϓ{get;set;}List<
MyInventoryItem>Е=new List<MyInventoryItem>();public int Д=0;public bool Г=false;public float В;}class ɭ{public int Ѓ=0;public int Ђ=0;
public int ϭ=0;public double Ϲ;public List<Ж>ϸ=new List<Ж>();public List<Ж>Ϸ=new List<Ж>();public MyItemType ϵ;public bool ϴ=
false;public bool ϳ=false;public string ϲ;public string ϱ;public double ϰ=1;}List<ɭ>ϯ=new List<ɭ>();void Ϯ(IMyTerminalBlock ɉ
,int ʗ=99){if(ʗ==99){foreach(var ɭ in ϯ){Ж ϓ=new Ж();ϓ.ɒ=ɉ;ϓ.ϓ=ɉ.GetInventory();ɭ.ϸ.Add(ϓ);}}else{Ж ϓ=new Ж();ϓ.ɒ=ɉ;ϓ.ϓ=ɉ
.GetInventory();ϓ.Г=ʽ;if(ʗ==0&&!ʼ)ϓ.Г=false;ϯ[ʗ].ϸ.Add(ϓ);}}void Ϻ(IMyTerminalBlock ɉ,int ʗ){Ж ϓ=new Ж();ϓ.ɒ=ɉ;ϓ.ϓ=ɉ.
GetInventory();ϓ.Г=ʽ;if(ʗ!=99)ϯ[ʗ].Ϸ.Add(ϓ);}void Ё(string ϲ,string Ѐ,string Ͽ,bool ϳ=false,bool ϴ=false){ɭ ɭ=new ɭ();ɭ.ϵ=new
MyItemType(Ѐ,Ͽ);ɭ.ϳ=ϳ;ɭ.ϴ=ϴ;ɭ.ϲ=ϲ;string ϱ;if(ϲ.Length>9)ϱ=ϲ.Substring(0,9);else ϱ=ϲ.PadRight(9);ɭ.ϱ=ϱ;ϯ.Add(ɭ);}void Ͼ(){try{Ё(
"Fusion Fuel","MyObjectBuilder_Ingot","FusionFuel",true);Ё("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");Ё("Jerry Can",
"MyObjectBuilder_Component","SG_Fuel_Tank");Ё("PDC","MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine",true);Ё("PDC Tefl",
"MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);Ё("220 Torp ","MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",
true,true);Ё("220 MCRN","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true,true);Ё("220 UNN",
"MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);Ё("RS Torp","MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);
Ё("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",true,true);Ё("120mm RG",
"MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);Ё("Dawson","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true
);Ё("Stiletto","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugMCRNMagazine",true);Ё("80mm",
"MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);Ё("Foehammr","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugMCRNMagazine",true);Ё("Farren","MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugUNNMagazine",true);Ё("Kess",
"MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);Ё("Steel Pla","MyObjectBuilder_Component","SteelPlate");ϯ[0].ϰ=ʄ;}catch(Exception
ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void Ͻ(){foreach(var ɭ in ϯ){ɭ.Ϸ.Clear();}}void ϼ(){
foreach(var ɭ in ϯ){ɭ.Ѓ=0;ɭ.ϭ=0;List<Ж>ˡ=ɭ.ϸ.Concat(ɭ.Ϸ).ToList();foreach(Ж ϓ in ˡ){ϓ.Д=ϓ.ϓ.GetItemAmount(ɭ.ϵ).ToIntSafe();ɭ.Ѓ
+=ϓ.Д;if(ϓ.Г){ϓ.В=ϓ.ϓ.VolumeFillFactor;}else{ɭ.ϭ+=ϓ.Д;}}}}void ϻ(){foreach(ɭ ɭ in ϯ){ɭ.Ђ=ɭ.Ѓ;}}int э(string Ǚ){switch(Ǚ){
case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":case"MCRN Torpedo Low Spread":return 6;case
"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;case"40mm Lead-Steel PDC Box Ammo":
return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":return 10;case
"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case"80mm Tungsten-Uranium Sabot Ammo":return 13;case
"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;case"180mm Lead-Steel Sabot Ammo":return 16;default:if(ʃ
)Echo("Unknown AmmoType = "+Ǚ);return 99;}}bool ы(IMyTerminalBlock ɒ){IMyInventory ъ=ɒ.GetInventory();return ъ.
VolumeFillFactor==0;}bool щ(List<Ж>ˣ,List<Ж>ϙ,MyItemType ϵ,int ш=-1,double ч=1,double ц=1){if(ʃ)Echo("Loading "+ϙ.Count+
" inventories from "+ˣ.Count+" sources.");bool t=false;bool х=ц<1;foreach(Ж ф in ϙ){int у=3;foreach(Ж ь in ˣ){if(у<0)break;if(ш!=-1&&ф.Д>=(ш
*.95))break;if(!ф.ϓ.IsConnectedTo(ь.ϓ))continue;List<MyInventoryItem>т=new List<MyInventoryItem>();ь.ϓ.GetItems(т);
foreach(MyInventoryItem ю in т){if(ю.Type==ϵ){int Д=ю.Amount.ToIntSafe();if(Д==0&&!х)break;у--;if(х){у=-1;try{Д=ь.Д-Convert.
ToInt32(ь.Д/ь.В*ц);if(ʃ)Echo("Unload "+Д+"\n"+ь.Д+"\n"+Convert.ToInt32(ь.Д/ь.В*ц));}catch(Exception ex){if(ʃ)Echo(
"Int conversion error at unload\n"+ex.Message);Д=1;}}else if(ч<1){try{int ќ=Convert.ToInt32(ф.Д/ф.В*ч)-ф.Д;if(ќ<Д)Д=ќ;}catch(Exception ex){if(ʃ)Echo(
"Int conversion error at load\n"+ex.Message);Д=1;}}else if(ш!=-1){if(Д<=ш){break;}Д=ш-ф.Д;}t=ф.ϓ.TransferItemFrom(ь.ϓ,ю,Д);if(t)у=-1;if(х&&t)return(t);
break;}}}}return t;}class ћ{public IMyTextPanel ɒ;public bool њ=true;public bool љ=false;public bool ј=false;public bool ї=
true;public bool ѝ=true;public bool і=true;public bool ѕ=false;public bool є=false;}class ѓ{public string ђ,ё;public int ѐ,я
;public ѓ(string с,string Э,int О=0,int Ы=20){if(с.Length>Т-3)с=с.Substring(0,Т-3);ђ=с.PadRight(Т-3);ё=Э;ѐ=О;я=Ы;}}List<ѓ
>Ъ=new List<ѓ>();class Щ{public string Ш,Ч;public Щ(string R,int Ц,int Х){string Ф="    ";while(Х>3){Х-=4;}if(Ц==0){Ш=
"║ "+R.PadRight(4)+" ║";Ч="  "+Ф+"  ";}else if(Ц==1){if(Х==0||Х==2)Ш="║─"+R.PadRight(4)+" ║";else Ш="║ "+R.PadRight(4)+"─║";
Ч=" ░"+Ф+"░ ";}else if(Ц==2){if(Х==0||Х==2){Ш="║ "+R.PadRight(4)+"═║";Ч="║▒"+Ф+"░║";}else{Ш="║═"+R.PadRight(4)+" ║";Ч=
"║░"+Ф+"▒║";}}else if(Ц==3){if(Х==0||Х==2){Ш="║!"+R.PadRight(4)+"!║";Ч="║▓"+Ф+"▓║";}else{Ш="║ "+Ф+" ║";Ч="║!"+R.PadRight(4)+
"!║";}}}}Color У=new Color(255,116,33,255);const int Т=32;int С=0;string[]Р=new string[]{"▄ "," ▄"," ▀","▀ "},П=new string[]
{"─","\\","│","/"},Ь=new string[]{"- ","= ","x ","! "};string Ю,п,р,о,н="\n\n",м,л="╔══════╗",к="╚══════╝",й,и,з,ж,е,д,г,
в,б,а,Я,А,Ƀ,Ƶ,ň,Ň,ņ,Ņ,ń,Ń,ł;void Ł(){л=л+л+л+л+"\n";к=к+к+к+к+"\n";Ю=ƒ("Welcome to")+н+ƒ("R S M")+н;п=ƒ("Initialising")+н
;р=new String(' ',Т-8);о="└"+new String('─',Т-2)+"┘";й=new String('-',26)+"\n";м="──"+н;и=ŀ("Inventory");з=ŀ("Thrust");ж=
ŀ("Power & Tanks");е=ŀ("Warnings");д=ŀ("Subsystem Integrity");г=ŀ("Telemetry & Thrust");в=ľ("Velocity");б=ľ(
"Velocity (Max)");а=ľ("Mass");Я=ľ("Max Accel");А=ľ("Actual Accel");Ƀ=ľ("Accel (Best)");Ƶ=ľ("Max Thrust");ň=ľ("Actual Thrust");Ň=ľ(
"Decel (Dampener)");ņ=ľ("Decel (Actual)");Ņ=ļ("Fuel");ń=ļ("Oxygen");Ń=ļ("Battery");ł=ļ("Capacity");}string ŀ(string Ŀ){return"──┤ "+Ŀ+" ├"
+new String('─',Т-9-Ŀ.Length);}string ľ(string Ľ){return Ľ+":"+new String(' ',Т-16-Ľ.Length);}string ļ(string Ļ){return Ļ
+new String(' ',Т-22-Ļ.Length)+"[";}void ĺ(){С++;if(С>=Р.Length)С=0;int ŉ=С+2;if(ŉ>3)ŉ-=4;string ŋ=Р[С];string Ŝ=П[С];
string ŝ=Р[ŉ];string ś=и+Ŝ+м;string Ś=з+Ŝ+м;string ř=ж+Ŝ+м;string Ř=е+Ŝ+м;string ŗ=д+Ŝ+м;string Ŗ=г+Ŝ+м;string ŕ=ƒ(ʒ.ToUpper()
)+"\n"+"  "+ŋ+" "+ƒ(đ,Т-10)+" "+ŋ+"  \n";string Ŕ="\n  "+ŝ+р+ŝ+"  "+н;if(Ώ){string œ=Ю+ƒ("Booting"+new string('.',Ε))+н;ś
+=œ;Ś+=œ;ř+=œ;Ř+=œ;ŗ+=œ;}else if(Ύ){string Œ=п+ƒ(ʒ)+н;ś+=Œ;Ś+=Œ;ř+=Œ;Ř+=Œ;ŗ+=Œ;}else{ʦ();double ő=9.81,Ő=Math.Round(Φ),ŏ=
Math.Round((æ/Υ/ő),2),Ŏ=Math.Round((å/Υ/ő),2),ō=Math.Round(F+o,1),Ō=Math.Round(Å,1),Ĺ=Math.Round(100*(ì/í)),ĸ=Math.Round(100
*(n/Ã)),ĕ=Math.Round(100*(Ō/ō));string ģ=в,Ģ=" Gs",ġ;List<string>Ġ=new List<string>();if(Ő<1){Ő=500;ģ=б;}if(ʅ){ő=1;Ģ=
" m/s/s";}for(int ě=0;ě<ϯ.Count;ě++){if(ϯ[ě].Ђ!=0){ϯ[ě].Ϲ=(100*((double)ϯ[ě].Ѓ/(double)ϯ[ě].Ђ));string ğ=(ϯ[ě].Ѓ+"/"+ϯ[ě].Ђ).
PadLeft(9);if(ğ.Length>9)ğ=ğ.Substring(0,9);ś+=ϯ[ě].ϱ+" ["+ż(ϯ[ě].Ϲ)+"] "+ğ+"\n";if(ě>2&&ϯ[ě].ϭ<1)Ġ.Add(ϯ[ě].ϲ);}}ś+="\n";if(å>
0)Ś+=ņ+ƍ(å,Ő)+"\n"+А+(Ŏ+Ģ).PadLeft(15)+н;else Ś+=Ň+ƍ(æ,Ő,true)+"\n"+Ƀ+(ŏ+Ģ).PadLeft(15)+н;Җ=Math.Round(100*(Ô/Ö));ř+=Ņ+ż(
Җ)+"] "+(Җ+" %").PadLeft(9)+"\n"+ń+ż(Ĺ)+"] "+(Ĺ+" %").PadLeft(9)+"\n"+Ń+ż(ĸ)+"] "+(ĸ+" %").PadLeft(9)+"\n"+ł+ż(ĕ)+"] "+(ĕ
+" %").PadLeft(9)+"\n"+"Max Power:"+(Ō+" MW / "+ō+" MW").PadLeft(22)+н;List<ѓ>Ğ=new List<ѓ>();List<Щ>ĝ=new List<Щ>();int
Ĝ=0;for(int ě=0;ě<Ъ.Count;ě++){Ъ[ě].я--;if(Ъ[ě].я<1)Ъ.RemoveAt(ě);else Ğ.Add(Ъ[ě]);}if(!ş){Ğ.Add(new ѓ("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(Ά){Ğ.Add(new ѓ("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int Ě=0;if(Җ<5)
{ġ="FUEL CRITICAL!";Ğ.Add(new ѓ(ġ,ġ+"\nFuel Level < 5%!",3));Ě=3;}else if(Җ<25){ġ="FUEL LOW!";Ğ.Add(new ѓ(ġ,ġ+
"\nFuel Level < 10%!",2));Ě=2;}if(Đ.ē!=ǀ.Off){if(Θ!=""){if(Ě==0)Ě=1;Ğ.Add(new ѓ("NO SPARE "+Θ.ToUpper()+"!",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",Ě));}if(Η){if(Ě==0)Ě=1;Ğ.Add(new ѓ("NO EXTRACTOR!","Cannot refuel!\nNo functional extractor!",Ě));}}ĝ.Add(new Щ("FUEL",
Ě,С+Ĝ));Ĝ++;if(Έ){ġ=ϛ.Count+" spawns are open to friends";Ğ.Add(new ѓ(ġ,ġ,0));}int ę=0;if(Ĺ<5){ġ="OXYGEN CRITICAL!";Ğ.Add
(new ѓ(ġ,ġ+"\nShip O2 Level < 5%!",3));ę=3;}else if(Ĺ<10){ġ="OXYGEN LOW!";Ğ.Add(new ѓ(ġ,ġ+"\nShip O2 Level < 10%!",2));ę=
2;}else if(Ĺ<25){ġ="Oxygen Low!";Ğ.Add(new ѓ(ġ,ġ+"\nShip O2 Level < 25%!",1));ę=1;}if(λ.Count>Ű){int Ę=(λ.Count-Ű);ę++;ġ=
Ę+" vents are unsealed";Ğ.Add(new ѓ(ġ,ġ,1));}if(ұ>0){ġ=ұ+" doors are insecure";Ğ.Add(new ѓ(ġ,ġ,0));}if(Ψ>0){ġ=ʱ+
" is active ("+Ψ+")";Ğ.Add(new ѓ(ġ,ġ,0));}ĝ.Add(new Щ("OXYG",ę,С+Ĝ));Ĝ++;int ė=0;if(Ϧ.Count>0){if(ĸ<5){ė+=2;ġ="BATTERIES CRITICAL!";Ğ.
Add(new ѓ(ġ,ġ+"\nBattery Level < 5%!",2));}else if(ĸ<10){ė+=1;ġ="Batteries Low!";Ğ.Add(new ѓ(ġ,ġ+"\nBattery Level < 10%!",1
));}}if(ϝ.Count>0){if(C>0){ė+=2;Ğ.Add(new ѓ(C+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}
if(ϯ[0].Ѓ<1){ė+=3;ġ="NO FUSION FUEL!";Ğ.Add(new ѓ(ġ,ġ,2));}else if(ϯ[0].Ѓ<50){ė+=2;ġ="FUSION FUEL CRITICAL! ("+ϯ[0].Ѓ+")";
Ğ.Add(new ѓ(ġ,ġ,2));}else if(ϯ[0].Ђ>0&&ϯ[0].Ϲ<5){ė+=2;ġ="FUSION FUEL CRITICAL!";Ğ.Add(new ѓ(ġ,ġ,3));}else if(ϯ[0].Ђ>0&&ϯ[
0].Ϲ<10){ė+=1;ġ="Fusion Fuel Level Low!";Ğ.Add(new ѓ(ġ,ġ,2));}}if(ė>3)ė=3;ĝ.Add(new Щ("POWR",ė,С+Ĝ));Ĝ++;int Ė=0;if(Ġ.
Count>0){foreach(string Ĥ in Ġ){string Ħ=Ĥ;if(Ĥ.Length>23)Ħ=Ĥ.Substring(0,23);Ħ=Ħ.ToUpper();ġ="NO SPARE "+Ħ+"!";Ğ.Add(new ѓ(ġ
,ġ,3));}Ė=3;}if(Ė>3)Ė=3;ĝ.Add(new Щ("WEAP",Ė,С+Ĝ));Ĝ++;if(ʹ){string Ķ=ͳ;if(ϧ.Count>0)if(ϧ[0]!=null)Ķ=(ϧ[0]as
IMyRadioAntenna).HudText;string ķ="";if(Ͳ<1000)ķ=Math.Round(Ͳ)+"m";else ķ=Math.Round(Ͳ/1000)+"km";Ğ.Add(new ѓ("Comms ("+ķ+"): "+Ķ,
"Antenna(s) are broadcasting at a range of "+ķ+" with the message "+Ķ,0));}if(Χ>0){ġ=Χ+" UNOWNED BLOCKS!";Ğ.Add(new ѓ(ġ,ġ+"\nRSM detected "+Χ+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ҳ>Ҳ){int ĵ=(ҳ-Ҳ);ġ=ĵ+" doors are open";Ğ.Add(new ѓ(ġ,ġ,0));}Ğ=Ğ.OrderBy(Ĵ=>Ĵ.ѐ).Reverse().ToList();if(Ğ.Count<1
)Ř+="No warnings\n";else Echo(н+" WARNINGS:");for(int ě=0;ě<Ğ.Count;ě++){Ř+=Ь[Ğ[ě].ѐ]+Ğ[ě].ђ+"\n";Echo("-"+Ь[Ğ[ě].ѐ]+Ğ[ě]
.ё);}Ř+="\n";string ĳ=Đ.ü.ToString().ToUpper();if(ĳ.Length>3)ĳ=ĳ.Substring(0,3);string Ĳ=Đ.û.ToString().ToUpper();if(Ĳ.
Length>3)Ĳ=Ĳ.Substring(0,3);string ı=Đ.ü.ToString().ToUpper();if(ı.Length>3)ı=ı.Substring(0,3);string İ=Đ.þ.ToString().ToUpper
();if(İ.Length>3)İ=İ.Substring(0,3);string į=Đ.ÿ.ToString().ToUpper();if(į.Length>3)į=į.Substring(0,3);string Į=Đ.ý.
ToString().ToUpper();if(Į.Length>3)Į=Į.Substring(0,3);try{if(ä>0)ŗ+="Epstein   ["+ż(ã)+"] "+(ã+"% ").PadLeft(5)+ĳ+"\n";if(ȇ>0)ŗ
+="RCS       ["+ż(ȑ)+"] "+(ȑ+"% ").PadLeft(5)+Ĳ+"\n";if(F>0)ŗ+="Reactors  ["+ż(D)+"] "+(D+"% ").PadLeft(5)+"    \n";if(o>0
)ŗ+="Batteries ["+ż(A)+"] "+(A+"% ").PadLeft(5)+ı+"\n";if(Î>0)ŗ+="PDCs      ["+ż(Ë)+"] "+(Ë+"% ").PadLeft(5)+İ+"\n";if(Ȋ>
0)ŗ+="Torpedoes ["+ż(Ȉ)+"] "+(Ȉ+"% ").PadLeft(5)+į+"\n";if(Z>0)ŗ+="Railguns  ["+ż(X)+"] "+(X+"% ").PadLeft(5)+Į+"\n";if(Õ
>0)ŗ+="H2 Tanks  ["+ż(Ó)+"] "+(Ó+"% ").PadLeft(5)+ı+"\n";if(ë>0)ŗ+="O2 Tanks  ["+ż(ê)+"] "+(ê+"% ").PadLeft(5)+ı+"\n";if(
Ҩ>0)ŗ+="Gyros     ["+ż(Ҧ)+"] "+(Ҧ+"% ").PadLeft(5)+"    \n";if(ʥ>0)ŗ+="Cargo     ["+ż(ʣ)+"] "+(ʣ+"% ").PadLeft(5)+
"    \n";if(ƥ>0)ŗ+="Welders   ["+ż(ƣ)+"] "+(ƣ+"% ").PadLeft(5)+"    \n";}catch{}if(o+F+Õ==0)ŗ+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+н;string ĭ="";string Ĭ="";foreach(Щ ī in ĝ){ĭ+=ī.Ш;Ĭ+=ī.Ч;}int Ī=С+2;if(Ī>3)Ī-=4;ŕ+=л+ĭ+"\n"+к;Ŕ+=Ĭ;if(!Π){Ŗ+=н;}else{
if(ʃ)Echo("Building advanced thrust...");string ĩ="";if(ʇ){ĩ=а+(Math.Round((Υ/1000000),2)+" Mkg").PadLeft(15)+"\n"+ģ+(Ő+
" ms").PadLeft(15)+"\n"+Я+(ŏ+Ģ).PadLeft(15)+"\n"+А+(Ŏ+Ģ).PadLeft(15)+"\n"+Ƶ+((æ/1000000)+" MN").PadLeft(15)+"\n"+ň+((å/
1000000)+" MN").PadLeft(15)+"\n";}Ŗ+=ĩ+Ň+ƍ(æ,Ő,true)+"\n"+ņ+ƍ(å,Ő)+"\n";foreach(double Ĩ in ʆ){Ŗ+=("Decel ("+(Ĩ*100)+"%):").
PadRight(17)+ƍ((float)(æ*Ĩ),Ő)+"\n";}Ŗ+=н;}}foreach(ћ ĥ in ά){string ħ="";Color Ş=Đ.ó;if(ĥ.њ)ħ+=ŕ;if(ĥ.љ){ħ+=Ŕ;Ş=У;}if(ĥ.ј)ħ+=Ř;
if(ĥ.ї)ħ+=ř;if(ĥ.ѝ)ħ+=ś;if(ĥ.і)ħ+=Ś;if(ĥ.ѕ)ħ+=ŗ;if(ĥ.є){ħ+=Ŗ;Π=true;}ĥ.ɒ.WriteText(ħ,false);if(!ʈ)ĥ.ɒ.FontColor=Ş;}}void ƃ
(){if(έ.Count>0){foreach(IMyTextPanel ĥ in έ){ĥ.FontColor=Đ.ó;}foreach(ћ ĥ in ά){ĥ.ɒ.FontColor=Đ.ó;}}}void Ɓ(string ƀ,
string ſ){ƀ=ƀ.ToLower();List<IMyTextPanel>ž=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ή);
foreach(IMyTextPanel ĥ in ή){if(ſ==""||ĥ.CustomName.Contains(ſ)){string Ž=ĥ.CustomData;if(Ž.Contains("hudlcd")&&(ƀ=="off"||ƀ==
"toggle"))ĥ.CustomData=Ž.Replace("hudlcd","hudXlcd");if(Ž.Contains("hudXlcd")&&(ƀ=="on"||ƀ=="toggle"))ĥ.CustomData=Ž.Replace(
"hudXlcd","hudlcd");}}}string ż(double Ż){try{int ź=0;if(Ż>0){int Ź=(int)Ż/10;if(Ź>10)return new string('=',10);if(Ź!=0)ź=Ź;}char
Ÿ=' ';if(Ż<10){if(С==0)return" ><    >< ";if(С==1)return"  ><  ><  ";if(С==2)return"   ><><   ";if(С==3)return
"<   ><   >";}string ŷ=new string('=',ź);string Ŷ=new string(Ÿ,10-ź);return ŷ+Ŷ;}catch{return"# ERROR! #";}}string Ƃ(string ŵ){
string Ƅ;string ğ="";double Ż=0;switch(ŵ){case"H2":Ż=Math.Round(100*(Ô/Õ));ğ=Ż.ToString()+" %";Җ=Ż;break;case"O2":Ż=Math.Round
(100*(ì/ë));ğ=Ż.ToString()+" %";break;case"Battery":Ż=Math.Round(100*(n/Ã));ğ=Ż.ToString()+" %";break;}Ƅ=ż(Ż);return" ["+
Ƅ+"] "+ğ.PadLeft(9);}string ƒ(string Ƒ,int Ɛ=Т){int Ə=Ɛ-Ƒ.Length;int Ǝ=Ə/2+Ƒ.Length;return Ƒ.PadLeft(Ǝ).PadRight(Ɛ);}
string ƍ(double Ɠ,double ƌ,bool Ɗ=false){if(Ɠ<=0)return("N/A").PadLeft(15);if(Ɗ)Ɠ=Ɠ*1.5;double Ɖ=0.5*(Math.Pow(ƌ,2)*(Υ/Ɠ));
double ƈ=ƌ/(Ɠ/Υ);string Ƈ="m";if(Ɖ>1000){Ƈ="km";Ɖ=Ɖ/1000;}return(Math.Round(Ɖ)+Ƈ+" "+Math.Round(ƈ)+"s").PadLeft(15);}void Ɔ(){
foreach(IMyTextPanel ũ in ή){ũ.Enabled=true;}}void ƅ(){foreach(ћ ĥ in ά){ĥ.ɒ.Font="Monospace";ĥ.ɒ.ContentType=ContentType.
TEXT_AND_IMAGE;if(ĥ.ɒ.CustomName.Contains("HUD1")){ĥ.њ=true;ĥ.љ=false;ĥ.ј=false;ĥ.ї=false;ĥ.ѝ=false;ĥ.і=false;ĥ.ѕ=false;ĥ.є=false;Ɇ(ĥ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ĥ.ɒ.CustomName.Contains("HUD2")){ĥ.њ=false;ĥ.љ=false;ĥ.ј=true;ĥ.ї=false;ĥ.ѝ=false;ĥ.і=false;ĥ.ѕ=false;ĥ.є
=false;Ɇ(ĥ,"hudlcd:0.22:0.99:0.55");continue;}if(ĥ.ɒ.CustomName.Contains("HUD3")){ĥ.њ=false;ĥ.љ=false;ĥ.ј=false;ĥ.ї=true;
ĥ.ѝ=false;ĥ.і=false;ĥ.ѕ=false;ĥ.є=false;Ɇ(ĥ,"hudlcd:0.48:0.99:0.55");continue;}if(ĥ.ɒ.CustomName.Contains("HUD4")){ĥ.њ=
false;ĥ.љ=false;ĥ.ј=false;ĥ.ї=false;ĥ.ѝ=false;ĥ.і=false;ĥ.ѕ=true;ĥ.є=false;Ɇ(ĥ,"hudlcd:0.74:0.99:0.55");continue;}if(ĥ.ɒ.
CustomName.Contains("HUD5")){ĥ.њ=false;ĥ.љ=false;ĥ.ј=false;ĥ.ї=false;ĥ.ѝ=true;ĥ.і=false;ĥ.ѕ=false;ĥ.є=true;Ɇ(ĥ,"hudlcd:0.75:0:.54"
);continue;}if(ĥ.ɒ.CustomName.Contains("HUD6")){ĥ.њ=false;ĥ.љ=true;ĥ.ј=false;ĥ.ї=false;ĥ.ѝ=false;ĥ.і=false;ĥ.ѕ=false;ĥ.є=
false;Ɇ(ĥ,"hudlcd:-0.55:0.99:0.7");continue;}}bool Ŵ=false;foreach(IMyTextPanel ũ in ή){if(ũ==null)continue;if(!Ŵ&&(ũ.
CustomName.Contains(ʏ)||ũ.CustomName.ToUpper().Contains(ʎ))){Ŵ=true;ũ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool ş;void
ŧ(bool Á,bool Ŧ){ş=false;foreach(IMyConveyorSorter ť in ι){if(ť!=null&&ť.IsFunctional){ş=true;if(Ŧ)ť.Enabled=Á;}}}void Ť(
ǖ H){if(H==ǖ.NoChange)return;foreach(IMyReflectorLight ţ in ό){if(ţ==null)continue;if(H==ǖ.Off)ţ.Enabled=false;else{ţ.
Enabled=false;if(H==ǖ.OnMax)ţ.Radius=9999;}}}void Ţ(Ǖ H,Color Ş){if(H==Ǖ.NoChange)return;foreach(IMyLightingBlock Š in Ϋ){if(Š
==null)continue;if(H==Ǖ.Off)Š.Enabled=false;else Š.Enabled=true;if(H!=Ǖ.OnNoColourChange)Š.SetValue("Color",Ş);}}void š(Ǖ
H,Color Ş){if(H==Ǖ.NoChange)return;foreach(IMyLightingBlock Š in κ){if(Š==null)continue;if(H==Ǖ.Off)Š.Enabled=false;else
Š.Enabled=true;if(H!=Ǖ.OnNoColourChange)Š.SetValue("Color",Ş);}}Color Ũ=new Color(255,0,0,255);Color Ū=new Color(255,0,0,
255);Color Ų=new Color(0,255,0,255);void ų(Ǖ H){if(H==Ǖ.NoChange)return;foreach(IMyLightingBlock Š in μ){ű(Š,H,Ū);}foreach(
IMyLightingBlock Š in ϋ){ű(Š,H,Ų);}}void ű(IMyLightingBlock Š,Ǖ H,Color Ş){if(Š==null)return;if(H==Ǖ.Off){Š.Enabled=false;Š.SetValue(
"Color",Ũ);}else{Š.Enabled=true;if(H!=Ǖ.OnNoColourChange)Š.SetValue("Color",Ş);}}int Ű=0;void ů(bool Á,bool Ŧ){Ű=0;foreach(
IMyAirVent Ů in λ){if(Ů!=null){if(Ŧ)Ů.Enabled=Á;if(Ů.CanPressurize)Ű++;}}}void ŭ(bool Á){foreach(IMyShipConnector Ŭ in ϣ){if(Ŭ!=
null)Ŭ.Enabled=Á;}}void ū(bool Á){foreach(IMyCameraBlock Â in ϥ){if(Â!=null)Â.Enabled=Á;}}void P(bool Á){foreach(
IMySensorBlock À in Ϝ){if(À!=null)À.Enabled=Á;}}void º(){Ά=true;foreach(IMyTerminalBlock µ in ϛ){µ.ApplyAction("OnOff_On");if(µ.
IsFunctional)Ά=false;}}bool ª=false;List<string>z=new List<string>();bool y=false;List<string>x=new List<string>();void w(string v,
string u){bool t=false;List<IMyProgrammableBlock>s=new List<IMyProgrammableBlock>();try{if(u=="EFC")s=ΰ;else if(u=="NavOS")s=ί
;foreach(IMyProgrammableBlock q in ΰ){if(q==null||!q.Enabled)continue;t=(q as IMyProgrammableBlock).TryRun(v);if(t&&ʃ)
Echo("Ran "+v+" on "+q.CustomName+" successfully.");else Ъ.Add(new ѓ(u+" command failed!",u+" command "+v+" failed!",1));if(
u=="EFC")ª=true;else if(u=="NavOS")y=true;break;}}catch(Exception ex){Ъ.Add(new ѓ(u+" command errored!",u+" command "+v+
" errored!\n"+ex.Message,3));}}void p(string v,string u){if(u=="EFC"){if(ΰ.Count<1)return;if(ª){z.Add(v);return;}}if(u=="NavOS"){if(ί
.Count<1)return;if(y){x.Add(v);return;}}w(v,u);}void Í(){if(z.Count>0&&!ª){w(z[0],"EFC");z.RemoveAt(0);}if(x.Count>0&&!y)
{w(x[0],"NavOS");x.RemoveAt(0);}ª=false;y=false;}int Î=0;double Ì=0;double Ë=0;void Ê(){Ì=0;foreach(IMyTerminalBlock Æ in
θ){É(Æ,Đ.þ!=ǔ.Off&&Đ.þ!=ǔ.MinDefence);}foreach(IMyTerminalBlock Æ in η){É(Æ,Đ.þ!=ǔ.Off);}Ë=Math.Round(100*(Ì/Î));}void É(
IMyTerminalBlock È,bool Á){if(È!=null&&È.IsFunctional){Ì++;(È as IMyConveyorSorter).Enabled=Á;}}void Ç(ǔ H){if(H==ǔ.NoChange)return;
foreach(IMyTerminalBlock Æ in θ){if(Æ!=null&Æ.IsFunctional){switch(H){case ǔ.Off:case ǔ.MinDefence:(Æ as IMyConveyorSorter).
Enabled=false;break;case ǔ.AllDefence:(Æ as IMyConveyorSorter).Enabled=true;if(ʻ){try{Æ.SetValue("WC_FocusFire",false);Æ.
SetValue("WC_Projectiles",true);Æ.SetValue("WC_Grids",true);Æ.SetValue("WC_LargeGrid",false);Æ.SetValue("WC_SmallGrid",true);Æ.
SetValue("WC_SubSystems",true);Æ.SetValue("WC_Biologicals",true);ʪ(Æ);}catch{Echo("Strange PDC config error! Possible WC crash!"
);}}break;case ǔ.Offence:(Æ as IMyConveyorSorter).Enabled=true;if(ʻ){try{Æ.SetValue("WC_FocusFire",false);Æ.SetValue(
"WC_Projectiles",true);Æ.SetValue("WC_Grids",true);Æ.SetValue("WC_LargeGrid",true);Æ.SetValue("WC_SmallGrid",true);Æ.SetValue(
"WC_SubSystems",true);Æ.SetValue("WC_Biologicals",true);ʪ(Æ);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock Æ in η){if(Æ!=null&Æ.IsFunctional){switch(H){case ǔ.Off:(Æ as IMyConveyorSorter).Enabled=false;break;
case ǔ.MinDefence:case ǔ.AllDefence:case ǔ.Offence:(Æ as IMyConveyorSorter).Enabled=true;if(ʻ){try{Æ.SetValue("WC_FocusFire"
,false);Æ.SetValue("WC_Projectiles",true);Æ.SetValue("WC_Grids",true);Æ.SetValue("WC_LargeGrid",false);Æ.SetValue(
"WC_SmallGrid",true);Æ.SetValue("WC_SubSystems",true);Æ.SetValue("WC_Biologicals",true);ʫ(Æ);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double Å;void Ä(Ǒ H){Å=0;B();M(H);}double Ã=0;double o=0;double n=0;double A=0;void M(Ǒ H){Ã=0;n=0;double
L=0;foreach(IMyBatteryBlock G in Ϧ){if(G!=null&&G.IsFunctional){n+=G.CurrentStoredPower;Ã+=G.MaxStoredPower;L+=G.
MaxOutput;G.Enabled=true;if(H==Ǒ.ManagedDischarge){if(W||E<=0)G.ChargeMode=ChargeMode.Discharge;else G.ChargeMode=ChargeMode.
Recharge;}}}A=Math.Round(100*(L/o));Å+=L;}void K(){o=0;foreach(IMyBatteryBlock G in Ϧ){ChargeMode J=G.ChargeMode;G.ChargeMode=
ChargeMode.Auto;o+=G.MaxOutput;G.ChargeMode=J;}}void I(Ǒ H){if(H==Ǒ.NoChange)return;foreach(IMyBatteryBlock G in Ϧ){if(G!=null&&!G
.Closed&&G.IsFunctional){G.Enabled=true;if(H==Ǒ.Auto)G.ChargeMode=ChargeMode.Auto;else if(H==Ǒ.StockpileRecharge)G.
ChargeMode=ChargeMode.Recharge;else if(H==Ǒ.Discharge)G.ChargeMode=ChargeMode.Discharge;}}}double F=0;double E=0;double D=0;int C=
0;void B(){E=0;C=0;foreach(IMyReactor N in ϝ){if(N!=null&&!N.Closed&&N.IsFunctional){N.Enabled=true;if(ы(N))C++;else E+=N
.MaxOutput;}}D=Math.Round(100*(E/F));Å+=E;}void O(){F=0;foreach(IMyReactor N in ϝ){F+=N.MaxOutput;}}void m(IMyProjector k
){k.CustomData=k.ProjectionOffset.X+"\n"+k.ProjectionOffset.Y+"\n"+k.ProjectionOffset.Z+"\n"+k.ProjectionRotation.X+"\n"+
k.ProjectionRotation.Y+"\n"+k.ProjectionRotation.Z+"\n";}void l(IMyProjector k){if(!k.IsFunctional)return;try{string[]h=k
.CustomData.Split('\n');Vector3I f=new Vector3I(int.Parse(h[0]),int.Parse(h[1]),int.Parse(h[2]));Vector3I e=new Vector3I(
int.Parse(h[3]),int.Parse(h[4]),int.Parse(h[5]));k.Enabled=true;k.ProjectionOffset=f;k.ProjectionRotation=e;k.
UpdateOffsetAndRotation();}catch{if(ʃ)Echo("Failed to load projector position for "+k.Name);}}int Z=0;double Y=0;double X=0;bool W=false;void V
(){W=false;Y=0;foreach(IMyTerminalBlock U in ζ){if(U!=null&&U.IsFunctional){Y++;(U as IMyConveyorSorter).Enabled=Đ.ý!=Ǔ.
Off;if(!W){MyDetectedEntityInfo?S=Ǥ.ș(U);if(S.HasValue){string R=S.Value.Name;if(R!=null&&R!=""){if(ʃ)Echo(
"At least one rail has a target!");W=true;}}}}}X=Math.Round(100*(Y/Z));}void Q(Ǔ H){if(H==Ǔ.NoChange)return;foreach(IMyTerminalBlock U in ζ){if(U!=null&U
.IsFunctional){if(H==Ǔ.Off){(U as IMyConveyorSorter).Enabled=false;}else{(U as IMyConveyorSorter).Enabled=true;if(ʻ){U.
SetValue("WC_Grids",true);U.SetValue("WC_LargeGrid",true);U.SetValue("WC_SmallGrid",true);U.SetValue("WC_SubSystems",true);ʪ(U);
}if(ʺ){if(H==Ǔ.OpenFire){ʧ(U);}else{ʨ(U);}}}}}}class à{public string ā="";public Ơ ÿ;public ǔ þ;public Ǔ ý;public ǒ ü;
public Ǘ û;public ǖ ú;public Ǖ ù;public Color ø;public Ǖ ö;public Color õ;public Ǖ ô;public Color ó;public Ǒ ò;public int ñ;
public Ơ ð;public ǁ Ā;public Ơ Ă;public ǀ ē;public Ơ Ĕ;public ƿ Ē;}string đ="N/A";à Đ;Ơ ď=Ơ.On;ǔ Ď=ǔ.Offence;Ǔ č=Ǔ.OpenFire;ǒ
Č=ǒ.On;Ǘ ċ=Ǘ.On;ǖ Ċ=ǖ.On;Ǖ ĉ=Ǖ.On;Color Ĉ=new Color(33,144,255,255);Ǖ ć=Ǖ.On;Color Ć=new Color(255,214,170,255);Ǖ ą=Ǖ.On;
Color Ą=new Color(33,144,255,255);Ǒ ă=Ǒ.Auto;int ï=-1;Ơ î=Ơ.NoChange;ǁ Ï=ǁ.NoChange;Ơ Þ=Ơ.NoChange;ǀ Ý=ǀ.KeepFull;Ơ Ü=Ơ.On;ƿ
Û=ƿ.NoChange;void Ú(string Ù){à Ø;if(!Ѭ.TryGetValue(Ù,out Ø)){Ъ.Add(new ѓ("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ʃ)Echo("Setting stance '"+Ù+"'.");Đ=Ø;đ=Ù;Ѡ();if(ʃ)Echo("Setting "+ζ.Count+" railguns to "+Đ.ý);Q(Đ.ý);
if(ʃ)Echo("Setting "+ε.Count+" torpedoes to "+Đ.ÿ);Ǧ(Đ.ÿ);if(ʃ)Echo("Setting "+θ.Count+" _normalPdcs, "+η.Count+
" defence _normalPdcs to "+Đ.þ);Ç(Đ.þ);if(ʃ)Echo("Setting "+δ.Count+" epsteins, "+β.Count+" chems"+" to "+Đ.ü);ȃ(Đ.ü,Đ.û);if(ʃ)Echo("Setting "+γ.
Count+" rcs, "+α.Count+" atmos"+" to "+Đ.û);ȏ(Đ.û);if(ʃ)Echo("Setting "+Ϧ.Count+" batteries to = "+Đ.ò);I(Đ.ò);if(ʃ)Echo(
"Setting "+Ϛ.Count+" H2 tanks to stockpile = "+Đ.ò);ß(Đ.ò);if(ʃ)Echo("Setting "+ύ.Count+" O2 tanks to stockpile = "+Đ.ò);ç(Đ.ò);if
(ʉ){if(ʃ)Echo("No lighting was set because lighting control is disabled.");}else{if(ʃ)Echo("Setting "+ό.Count+
" spotlights to "+Đ.ú);Ť(Đ.ú);if(ʃ)Echo("Setting "+Ϋ.Count+" exterior lights to "+Đ.ù);Ţ(Đ.ù,Đ.ø);if(ʃ)Echo("Setting "+κ.Count+
" exterior lights to "+Đ.ö);š(Đ.ö,Đ.õ);if(ʃ)Echo("Setting "+μ.Count+" port nav lights, "+ϋ.Count+" starboard nav lights to "+Đ.ô);ų(Đ.ô);}if(ʃ
)Echo("Setting "+ϊ.Count+" aux block to "+Đ.Ă);Ϗ(Đ.Ă);if(ʃ)Echo("Setting "+ϡ.Count+" extrators to "+Đ.ē);ҕ(Đ.ē);if(ʃ)Echo
("Setting "+Ϣ.Count+" hangar doors units to "+Đ.Ē);Ӏ(Đ.Ē);if(Đ.ý==Ǔ.OpenFire){if(ʃ)Echo("Setting "+ψ.Count+
" doors to locked because we are in combat (rails set to open fire).");Ҕ("locked","");}if(ʃ)Echo("Setting "+έ.Count+" colour sync Lcds.");ƃ();if(Đ.Ā==ǁ.Abort){p("Off","EFC");p("Abort",
"NavOS");}if(Đ.ñ>0){p("Set Burn "+Đ.ñ,"EFC");p("Thrust Set "+Đ.ñ/100,"NavOS");}if(Đ.ð==Ơ.On)p("Boost On","EFC");else if(Đ.ð==Ơ.
Off)p("Boost Off","EFC");if(ʃ)Echo("Finished setting stance.");}double Ö=0;double Õ=0;double Ô=0;double Ó=0;void Ò(){Ô=0;Ö=
0;foreach(IMyGasTank Ð in Ϛ){if(Ð.IsFunctional){Ð.Enabled=true;Ö+=Ð.Capacity;Ô+=(Ð.Capacity*Ð.FilledRatio);}}Ó=Math.Round
(100*(Ö/Õ));}void Ñ(){Õ=0;foreach(IMyGasTank Ð in Ϛ){if(Ð!=null)Õ+=Ð.Capacity;}}void ß(Ǒ H){if(H==Ǒ.NoChange)return;
foreach(IMyGasTank Ð in Ϛ){if(Ð==null)continue;Ð.Enabled=true;if(H==Ǒ.StockpileRecharge)Ð.Stockpile=true;else Ð.Stockpile=false
;}}double í=0;double ì=0;double ë=0;double ê=0;void é(){ì=0;í=0;foreach(IMyGasTank Ð in ύ){if(Ð.IsFunctional){Ð.Enabled=
true;í+=Ð.Capacity;ì+=(Ð.Capacity*Ð.FilledRatio);}}ê=Math.Round(100*(í/ë));}void è(){ë=0;foreach(IMyGasTank Ð in ύ){if(Ð!=
null)ë+=Ð.Capacity;}}void ç(Ǒ H){if(H==Ǒ.NoChange)return;foreach(IMyGasTank Ð in ύ){if(Ð==null)continue;Ð.Enabled=true;if(H
==Ǒ.StockpileRecharge)Ð.Stockpile=true;else Ð.Stockpile=false;}}float æ;float å;float ä;double ã;void â(){float Ƌ=0;float
á=0;float Ɣ=0;float Ȇ=0;foreach(IMyThrust ȁ in δ){if(ȁ!=null&&ȁ.IsFunctional){Ƌ+=ȁ.MaxThrust;Ɣ+=ȁ.CurrentThrust;if(ȁ.
Enabled){á+=ȁ.MaxThrust;Ȇ+=ȁ.CurrentThrust;}}}ã=Math.Round(100*(Ƌ/ä));if(á==0){æ=Ƌ;å=Ɣ;}else{æ=á;å=Ȇ;}}void Ȅ(){ä=0;foreach(
IMyThrust ȁ in δ){if(ȁ!=null)ä+=ȁ.MaxThrust;}}void ȃ(ǒ H,Ǘ Ȁ){if(H==ǒ.NoChange)return;foreach(IMyThrust ȁ in δ){Ȃ(ȁ,H,Ȁ);}foreach
(IMyThrust ȁ in β){Ȃ(ȁ,H,Ȁ,true);}}void Ȃ(IMyThrust ȁ,ǒ H,Ǘ Ȁ,bool ǿ=false){bool Ǿ=ȁ.CustomName.Contains(ʡ);if(Ǿ){if(Ȁ!=Ǘ
.Off&&Ȁ!=Ǘ.AtmoOnly)ȁ.Enabled=true;else ȁ.Enabled=false;}else{bool ǽ=ȁ.CustomName.Contains(ʯ);if((H==ǒ.On)||(H==ǒ.Minimum
&&ǽ)||(H==ǒ.EpsteinOnly&&!ǿ)||(H==ǒ.ChemOnly&&ǿ)){ȁ.Enabled=true;}else{ȁ.Enabled=false;}}}float ȅ;float ȇ;double ȑ;void Ȓ(
){ȅ=0;foreach(IMyThrust ȁ in γ){if(ȁ!=null&&ȁ.IsFunctional){ȅ+=ȁ.MaxThrust;}}ȑ=Math.Round(100*(ȅ/ȇ));}void Ȑ(){ȇ=0;
foreach(IMyThrust ȁ in γ){if(ȁ!=null)ȇ+=ȁ.MaxThrust;}}void ȏ(Ǘ H){foreach(IMyThrust ȁ in γ){if(ȁ!=null)Ȏ(ȁ,H);}foreach(
IMyThrust ȁ in α){if(ȁ!=null)Ȏ(ȁ,H,true);}}void Ȏ(IMyThrust ȁ,Ǘ H,bool ȍ=false){bool Ȍ=ȁ.GridThrustDirection==Vector3I.Backward;
bool ȋ=ȁ.GridThrustDirection==Vector3I.Forward;if((H==Ǘ.On)||(H==Ǘ.ForwardOff&&!Ȍ)||(H==Ǘ.ReverseOff&&!ȋ)||(H==Ǘ.RcsOnly&&!ȍ
)||(H==Ǘ.AtmoOnly&&ȍ)){ȁ.Enabled=true;}else{ȁ.Enabled=false;}}int Ȋ=0;double ȉ=0;double Ȉ=0;void Ǽ(){ȉ=0;foreach(
IMyTerminalBlock ǥ in ε){if(ǥ!=null&&ǥ.IsFunctional){ȉ++;(ǥ as IMyConveyorSorter).Enabled=Đ.ÿ==Ơ.On;if(ʽ){string Ǚ=Ǥ.Ʒ(ǥ,0);int Ĥ=э(Ǚ);
if(ʃ)Echo("Launcher "+ǥ.CustomName+" needs "+Ǚ+"("+Ĥ+")");Ϻ(ǥ,Ĥ);}}}Ȉ=Math.Round(100*(ȉ/Ȋ));}void Ǧ(Ơ H){if(H==Ơ.NoChange)
return;foreach(IMyTerminalBlock ǥ in ε){if(ǥ!=null&ǥ.IsFunctional){if(H==Ơ.Off){(ǥ as IMyConveyorSorter).Enabled=false;}else{(
ǥ as IMyConveyorSorter).Enabled=true;if(ʻ){ǥ.SetValue("WC_FocusFire",true);ǥ.SetValue("WC_Grids",true);ǥ.SetValue(
"WC_LargeGrid",true);ǥ.SetValue("WC_SmallGrid",false);ǥ.SetValue("WC_FocusFire",true);ǥ.SetValue("WC_SubSystems",true);ʪ(ǥ);}}}}}ǣ Ǥ;
class ǣ{private Action<ICollection<MyDefinitionId>>Ǣ;private Action<ICollection<MyDefinitionId>>ǡ;private Action<ICollection<
MyDefinitionId>>Ǡ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>ǟ;private Func<long,MyTuple<bool,
int,int>>Ǟ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>ǝ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>ǜ;private Func<long,int,
MyDetectedEntityInfo>Ǜ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǚ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>ǩ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>Ǻ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>ǻ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>ǹ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ǹ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>Ƿ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>Ƕ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǵ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>Ǵ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ǳ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǲ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>Ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǰ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>ǯ;private Func<MyDefinitionId,float>Ǯ;private Func<long,bool>ǭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>Ǭ;private Func<long,float>ǫ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ǩ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ǫ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>ȓ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>ȷ;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>ȶ;private Func<long,float>ȵ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>ȴ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ȳ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ȱ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>Ȱ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>ȯ;public bool Ȯ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȭ){var Ȭ=ȭ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(ȭ);if(Ȭ==null)throw new Exception("WcPbAPI failed to activate");return ȫ(Ȭ);}public bool ȫ
(IReadOnlyDictionary<string,Delegate>Ȫ){if(Ȫ==null)return false;ȩ(Ȫ,"GetCoreWeapons",ref Ǣ);ȩ(Ȫ,"GetCoreStaticLaunchers",
ref ǡ);ȩ(Ȫ,"GetCoreTurrets",ref Ǡ);ȩ(Ȫ,"GetBlockWeaponMap",ref ǟ);ȩ(Ȫ,"GetProjectilesLockedOn",ref Ǟ);ȩ(Ȫ,
"GetSortedThreats",ref ǝ);ȩ(Ȫ,"GetObstructions",ref ǜ);ȩ(Ȫ,"GetAiFocus",ref Ǜ);ȩ(Ȫ,"SetAiFocus",ref ǚ);ȩ(Ȫ,"GetWeaponTarget",ref ǧ);ȩ(Ȫ,
"SetWeaponTarget",ref ǩ);ȩ(Ȫ,"FireWeaponOnce",ref Ǻ);ȩ(Ȫ,"ToggleWeaponFire",ref ǻ);ȩ(Ȫ,"IsWeaponReadyToFire",ref ǹ);ȩ(Ȫ,
"GetMaxWeaponRange",ref Ǹ);ȩ(Ȫ,"GetTurretTargetTypes",ref Ƿ);ȩ(Ȫ,"SetTurretTargetTypes",ref Ƕ);ȩ(Ȫ,"SetBlockTrackingRange",ref ǵ);ȩ(Ȫ,
"IsTargetAligned",ref Ǵ);ȩ(Ȫ,"IsTargetAlignedExtended",ref ǳ);ȩ(Ȫ,"CanShootTarget",ref ǲ);ȩ(Ȫ,"GetPredictedTargetPosition",ref Ǳ);ȩ(Ȫ,
"GetHeatLevel",ref ǰ);ȩ(Ȫ,"GetCurrentPower",ref ǯ);ȩ(Ȫ,"GetMaxPower",ref Ǯ);ȩ(Ȫ,"HasGridAi",ref ǭ);ȩ(Ȫ,"HasCoreWeapon",ref Ǭ);ȩ(Ȫ,
"GetOptimalDps",ref ǫ);ȩ(Ȫ,"GetActiveAmmo",ref Ǩ);ȩ(Ȫ,"SetActiveAmmo",ref Ǫ);ȩ(Ȫ,"MonitorProjectile",ref ȓ);ȩ(Ȫ,"UnMonitorProjectile",
ref ȷ);ȩ(Ȫ,"GetProjectileState",ref ȶ);ȩ(Ȫ,"GetConstructEffectiveDps",ref ȵ);ȩ(Ȫ,"GetPlayerController",ref ȴ);ȩ(Ȫ,
"GetWeaponAzimuthMatrix",ref ȳ);ȩ(Ȫ,"GetWeaponElevationMatrix",ref Ȳ);ȩ(Ȫ,"IsTargetValid",ref ȱ);ȩ(Ȫ,"GetWeaponScope",ref Ȱ);ȩ(Ȫ,"IsInRange",ref
ȯ);return true;}private void ȩ<Ȩ>(IReadOnlyDictionary<string,Delegate>Ȫ,string ȧ,ref Ȩ ȸ)where Ȩ:class{if(Ȫ==null){ȸ=null
;return;}Delegate ɂ;if(!Ȫ.TryGetValue(ȧ,out ɂ))throw new Exception(
$"{GetType().Name} :: Couldn't find {ȧ} delegate of type {typeof(Ȩ)}");ȸ=ɂ as Ȩ;if(ȸ==null)throw new Exception(
$"{GetType().Name} :: Delegate {ȧ} is not type {typeof(Ȩ)}, instead it's: {ɂ.GetType()}");}public void ɀ(ICollection<MyDefinitionId>Ȟ)=>Ǣ?.Invoke(Ȟ);public void ȿ(ICollection<MyDefinitionId>Ȟ)=>ǡ?.Invoke(Ȟ);
public void Ⱦ(ICollection<MyDefinitionId>Ȟ)=>Ǡ?.Invoke(Ȟ);public bool Ƚ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɂ,IDictionary<
string,int>Ȟ)=>ǟ?.Invoke(Ɂ,Ȟ)??false;public MyTuple<bool,int,int>ȼ(long Ȼ)=>Ǟ?.Invoke(Ȼ)??new MyTuple<bool,int,int>();public
void Ⱥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ț,IDictionary<MyDetectedEntityInfo,float>Ȟ)=>ǝ?.Invoke(Ț,Ȟ);public void ȹ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ț,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ȟ)=>ǜ?.Invoke(Ț,Ȟ);public
MyDetectedEntityInfo?Ȧ(long ȝ,int Ȕ=0)=>Ǜ?.Invoke(ȝ,Ȕ);public bool ț(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ț,long ȗ,int Ȕ=0)=>ǚ?.Invoke(Ț,ȗ
,Ȕ)??false;public MyDetectedEntityInfo?ș(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ=0)=>ǧ?.Invoke(ƕ,Ɩ);public void Ș(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ȗ,int Ɩ=0)=>ǩ?.Invoke(ƕ,ȗ,Ɩ);public void Ȗ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
ƕ,bool ȕ=true,int Ɩ=0)=>Ǻ?.Invoke(ƕ,ȕ,Ɩ);public void Ȝ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,bool ȥ,bool ȕ,int Ɩ=0)=>ǻ
?.Invoke(ƕ,ȥ,ȕ,Ɩ);public bool Ȥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ=0,bool ȣ=true,bool Ȣ=false)=>ǹ?.Invoke(ƕ,Ɩ
,ȣ,Ȣ)??false;public float ȡ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>Ǹ?.Invoke(ƕ,Ɩ)??0f;public bool Ƞ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock ƕ,IList<string>Ȟ,int Ɩ=0)=>Ƿ?.Invoke(ƕ,Ȟ,Ɩ)??false;public void ȟ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ƕ,IList<string>Ȟ,int Ɩ=0)=>Ƕ?.Invoke(ƕ,Ȟ,Ɩ);public void ǘ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,float ƴ)=>ǵ?.Invoke(
ƕ,ƴ);public bool Ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ư,int Ɩ)=>Ǵ?.Invoke(ƕ,ư,Ɩ)??false;public MyTuple<bool,
Vector3D?>Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ư,int Ɩ)=>ǳ?.Invoke(ƕ,ư,Ɩ)??new MyTuple<bool,Vector3D?>();public bool
Ʊ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ư,int Ɩ)=>ǲ?.Invoke(ƕ,ư,Ɩ)??false;public Vector3D?Ư(Sandbox.ModAPI.Ingame
.IMyTerminalBlock ƕ,long ư,int Ɩ)=>Ǳ?.Invoke(ƕ,ư,Ɩ)??null;public float ƾ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>ǰ?.
Invoke(ƕ)??0f;public float ƽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>ǯ?.Invoke(ƕ)??0f;public float Ƽ(MyDefinitionId ƻ)=>Ǯ?.
Invoke(ƻ)??0f;public bool ƺ(long ƙ)=>ǭ?.Invoke(ƙ)??false;public bool ƹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>Ǭ?.Invoke(ƕ)
??false;public float Ƹ(long ƙ)=>ǫ?.Invoke(ƙ)??0f;public string Ʒ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>Ǩ?.
Invoke(ƕ,Ɩ)??null;public void ƶ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ,string Ʈ)=>Ǫ?.Invoke(ƕ,Ɩ,Ʈ);public void ƭ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ,Action<long,int,ulong,long,Vector3D,bool>Ɲ)=>ȓ?.Invoke(ƕ,Ɩ,Ɲ);public void ƞ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ,Action<long,int,ulong,long,Vector3D,bool>Ɲ)=>ȷ?.Invoke(ƕ,Ɩ,Ɲ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ɯ(ulong ƛ)=>ȶ?.Invoke(ƛ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ƚ(long ƙ)=>ȵ?.Invoke(ƙ)??0f;public long Ƙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ)=>ȴ?.Invoke(ƕ)??-1;public
Matrix Ɨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>ȳ?.Invoke(ƕ,Ɩ)??Matrix.Zero;public Matrix Ɵ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ƕ,int Ɩ)=>Ȳ?.Invoke(ƕ,Ɩ)??Matrix.Zero;public bool Ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,long ƫ,bool ƪ,bool Ʃ)=>ȱ?.
Invoke(ƕ,ƫ,ƪ,Ʃ)??false;public MyTuple<Vector3D,Vector3D>ƨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƕ,int Ɩ)=>Ȱ?.Invoke(ƕ,Ɩ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>Ƨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ʀ)=>ȯ?.Invoke(Ʀ)??new MyTuple<
bool,bool>();}int ƥ=0;double Ƥ=0;double ƣ=0;void Ƣ(){Ƥ=0;foreach(IMyTerminalBlock ơ in Ϊ){if(ơ!=null&&ơ.IsFunctional)Ƥ++;}ƣ=
Math.Round(100*(Ƥ/ƥ));}enum Ơ{
    Off, On, NoChange
    }enum Ǖ{
    Off, On, NoChange, OnNoColourChange
    }enum ǔ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum Ǔ{
    Off, HoldFire, OpenFire, NoChange
    }enum ǒ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum Ǘ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum ǖ{
    On, Off, OnMax, NoChange
    }enum Ǒ{
    Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
    }enum ǁ{
    Abort, NoChange
    }enum ǀ{
    Off, On, FillWhenLow, KeepFull,
    }enum ƿ{
    Closed, Open, NoChange
    }
}sealed class ǂ{public double ǃ{get;private set;}private double Ǐ{get{double ǐ=Ǉ[0];for(int ě=1;ě<ǉ;ě++){ǐ+=Ǉ[ě];}return(
ǐ/ǉ);}}public double ǎ{get{double Ǎ=Ǉ[0];for(int ě=1;ě<ǉ;ě++){if(Ǉ[ě]>Ǎ){Ǎ=Ǉ[ě];}}return Ǎ;}}public double ǌ{get;private
set;}public double ǋ{get{double Ǌ=Ǉ[0];for(int ě=1;ě<ǉ;ě++){if(Ǉ[ě]<Ǌ){Ǌ=Ǉ[ě];}}return Ǌ;}}public int ǉ{get;}private double
ǈ;private IMyGridProgramRuntimeInfo ǅ;private double[]Ǉ;private int ǆ=0;public ǂ(IMyGridProgramRuntimeInfo ǅ,int Ŋ=300){
this.ǅ=ǅ;this.ǌ=ǅ.LastRunTimeMs;this.ǉ=MathHelper.Clamp(Ŋ,1,int.MaxValue);this.ǈ=1.0/ǉ;this.Ǉ=new double[Ŋ];this.Ǉ[ǆ]=ǅ.
LastRunTimeMs;this.ǆ++;}public void Ǆ(){ǃ-=Ǉ[ǆ]*ǈ;ǃ+=ǅ.LastRunTimeMs*ǈ;Ǉ[ǆ]=ǅ.LastRunTimeMs;if(ǅ.LastRunTimeMs>ǌ){ǌ=ǅ.LastRunTimeMs;}
ǆ++;if(ǆ>=ǉ){ǆ=0;ǃ=Ǐ;ǌ=ǅ.LastRunTimeMs;}}