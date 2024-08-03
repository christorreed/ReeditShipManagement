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

string Version = "1.99.55 (2024-04-29)";
ǀ Δ;int Γ=0;int Β=0;int Α=0;int ΐ;int Ώ=0;bool Ύ=true;bool Ό=true;bool Ί=false;bool Ή=false;bool Έ=false;bool Ά=false;
bool ͽ=false;bool ͼ=false;bool Ε=false;string Ζ="";int Υ=0;int Φ=0;double Τ;float Σ;string Ρ;string Π;string Ο;bool Ξ=false;
int Ν=0;int Μ=0;bool Λ;bool Κ;bool Ι;Program(){Echo("Welcome to RSM\nV "+Version);Ͷ();ΐ=ʍ;Ρ=Me.GetOwnerFactionTag();Δ=new ǀ
(Runtime);Ϲ();ʃ.Add(0.5);ʃ.Add(0.25);ʃ.Add(0.1);ʃ.Add(0.05);Ł();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo(
"Took "+Ͷ());}void Main(string t,UpdateType Θ){if(Θ==UpdateType.Update100)ˈ();else Η(t);}void Η(string t){if(ʀ)Echo(
"Processing command '"+t+"'...");if(Ό){ˊ(t,"RSM is still booting");return;}if(Ί){ˊ(t,"RSM is still initialising");return;}if(t==""){ˊ(t,
"the argument was blank");return;}string[]ͻ=t.Split(':');if(ͻ.Length<2){ˊ(t,"the argument wasn't recognised");return;}if(ͻ[0].ToLower()!="comms"
)ͻ[1]=ͻ[1].Replace(" ",string.Empty);switch(ͻ[0].ToLower()){case"init":bool ʿ=true,ˏ=true,ˎ=true;if(ͻ.Length>2){foreach(
string ˍ in ͻ){if(ˍ.ToLower()=="nonames")ʿ=false;else if(ˍ.ToLower()=="nosubs")ˏ=false;else if(ˍ.ToLower()=="noinv")ˎ=false;}}
ҡ(ͻ[1],ʿ,ˏ,ˎ);return;case"stance":Ú(ͻ[1]);return;case"hudlcd":string ˌ="";if(ͻ.Length>2)ˌ=ͻ[2];ſ(ͻ[1],ˌ);return;case
"doors":string ˋ="";if(ͻ.Length>2)ˋ=ͻ[2];Ӏ(ͻ[1],ˋ);return;case"comms":ˬ(ͻ[1]);return;case"printblockids":ɕ();return;case
"printblockprops":ɑ(ͻ[1]);return;case"spawn":if(ͻ[1].ToLower()=="open"){ͽ=true;ΐ=ʍ;Ш.Add(new ѐ("Spawns were opened to friends",
"Spawns are now opened to the friends list as defined in PB custom data.",2));}else{ͽ=false;ΐ=ʍ;Ш.Add(new ѐ("Spawns were closed to friends",
"Spawns are now closed to the friends list as defined in PB custom data.",2));}return;case"projectors":if(ͻ[1].ToLower()=="save"){foreach(IMyProjector h in Ϝ)l(h);Ш.Add(new ѐ(
"Projector positions saved","Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector h in Ϝ)k(h);Ш.
Add(new ѐ("Projector positions loaded","Projector positions were loaded from custom data.",2));return;}default:ˊ(t,
"the argument wasn't recognised");return;}}void ˊ(string t,string ˉ){Ш.Add(new ѐ("COMMAND FAILED!","Command '"+t+"' was ignored because "+ˉ,3));}void ˈ(
){if(ɿ)Ͷ();if(Β<ɾ){Β++;return;}Β=0;if(Ύ){Echo("Parsing custom data...");Ѣ();Ύ=false;return;}else if(Ί){Ћ();if(ʀ)Echo(
"Updating "+Ϊ.Count+" RSM Lcds");ĺ();}ˠ();Ν=Runtime.CurrentInstructionCount;if(Ν>Μ)Μ=Runtime.CurrentInstructionCount;if(Đ.Ē==Ơ.On){
Ή=true;Έ=true;}else if(Đ.Ē==Ơ.Off){Ή=true;}if(ΐ>=ʍ){ΐ=0;ˀ();return;}ΐ++;ˇ();ˆ();if(ɿ)Echo("Took "+Ͷ());if(ʀ)Echo(
"Updating "+Ϊ.Count+" RSM Lcds");ĺ();if(ɿ)Echo("Took "+Ͷ());}void ˇ(){ː();switch(Γ){case 0:if(ʀ)Echo("Refreshing "+δ.Count+
" railguns...");U();if(ɿ)Echo("Took "+Ͷ());if(Ό)break;else goto case 1;case 1:if(ʀ)Echo("Refreshing "+ϛ.Count+" reactors & "+Ϥ.Count+
" batteries...");Â(Đ.ò);if(ɿ)Echo("Took "+Ͷ());if(Ό)break;else goto case 2;case 2:if(ʀ)Echo("Refreshing "+β.Count+" epsteins...");á();
if(ɿ)Echo("Took "+Ͷ());if(Ό)break;else goto case 3;case 3:if(ʀ)Echo("Refreshing "+η.Count+" lidars...");ŧ(Έ,Ή);if(ɿ)Echo(
"Took "+Ͷ());if(ʀ)Echo("Refreshing pb servers...");Ì();if(ɿ)Echo("Took "+Ͷ());if(Ό)break;else goto case 4;case 4:if(ʀ)Echo(
"Refreshing "+φ.Count+" doors...");Ӈ();if(ɿ)Echo("Took "+Ͷ());if(ʀ)Echo("Refreshing "+υ.Count+" airlocks...");Ҽ();if(ɿ)Echo("Took "+Ͷ
());break;default:if(ʀ)Echo("Booting complete");Ό=false;Γ=0;return;}if(Ό)Γ++;}void ˆ(){switch(Α){case 0:if(ʀ)Echo(
"Clearing temp inventories...");ϸ();if(ɿ)Echo("Took "+Ͷ());if(ʀ)Echo("Refreshing "+γ.Count+" torpedo launchers...");Ȇ();if(ɿ)Echo("Took "+Ͷ());if(ʀ)
Echo("Refreshing items...");Ϸ();if(ɿ)Echo("Took "+Ͷ());break;case 1:if(ʀ)Echo("Running autoload...");ˢ();if(ɿ)Echo("Took "+Ͷ
());break;case 2:if(ʀ)Echo("Refreshing "+Ϙ.Count+" H2 tanks...");Ò();if(ɿ)Echo("Took "+Ͷ());if(ʀ)Echo(
"Refreshing refuel status...");ґ();if(Ά){if(ʀ)Echo("Fuel low, filling extractors...");ҩ();if(ɿ)Echo("Took "+Ͷ());return;}else{ˁ();if(ɿ)Echo("Took "+Ͷ
());}Α=0;return;}Α++;}void ˁ(){if(ʀ)Echo("Refreshing "+α.Count+" rcs...");Ȑ();if(ʀ)Echo("Refreshing "+ζ.Count+" Pdcs & "+
ε.Count+" defensive Pdcs...");È();if(ʀ)Echo("Refreshing "+ϝ.Count+" gyros...");ң(Έ,Ή);if(ʀ)Echo("Refreshing "+ϋ.Count+
" O2 tanks...");è();if(ʀ)Echo("Refreshing "+ϥ.Count+" antennas...");ˮ();if(ʀ)Echo("Refreshing "+Ϣ.Count+" cargos...");ʠ();if(ʀ)Echo(
"Refreshing "+ι.Count+" vents...");Ů(Έ,Ή);if(ʀ)Echo("Refreshing "+ψ.Count+" auxiliary blocks...");ώ();if(ʀ)Echo("Refreshing "+Ψ.Count
+" welders...");Ƣ();if(ʀ)Echo("Refreshing "+ά.Count+" lcds...");Ƅ();if(ʀ)Echo("Refreshing "+ϙ.Count+" lcds...");ª();if(Ή)
{if(ʀ)Echo("Refreshing "+ϡ.Count+" connectors...");Ŭ(Έ);if(ʀ)Echo("Refreshing "+ϣ.Count+" cameras...");Ĕ(Έ);if(ʀ)Echo(
"Refreshing "+Ϛ.Count+" sensors...");À(Έ);}}void ˀ(){if(ʀ)Echo("Clearing block lists...");ɫ();if(ɿ)Echo("Took "+Ͷ());if(ʀ)Echo(
"Refreshing block lists...");GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,σ);if(ɿ)Echo("Took "+Ͷ());if(ʀ)Echo(
"Setting KeepFull threshold");Ғ();if(Ϧ==null){if(Ϩ.Count>0)Ϧ=Ϩ[0];else Ш.Add(new ѐ("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ʀ)Echo("Finished block refresh.");if(ɿ)Echo("Took "+Ͷ());}void ː(){try{Ǣ=new ǡ();Ǣ.ȫ(Me);}catch(Exception ex){Ǣ
=null;Ш.Add(new ѐ("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ˠ(){string ͷ="REEDIT SHIP MANAGEMENT \n\n|- V "+Version+"\n|- Ship Name: "+ʏ+"\n|- Stance: "+đ+
"\n|- Step: "+ΐ+"/"+ʍ+" ("+Α+")";if(Ό)ͷ+="\n|- Booting "+Γ;if(ɿ){Δ.ǃ();ͷ+="\n|- Runtime Av/Tick: "+(Math.Round(Δ.ǂ,2)/100)+" ms"+
"\n|- Runtime Max: "+Math.Round(Δ.Ǎ,4)+" ms"+"\n|- Instructions: "+Ν+" ("+Μ+")";}Echo(ͷ+"\n");}long ͺ=0;string Ͷ(){long ʹ=DateTime.Now.Ticks
/TimeSpan.TicksPerMillisecond;if(ͺ==0){ͺ=ʹ;return"0 ms";}long ͳ=ʹ-ͺ;ͺ=ʹ;return ͳ+" ms";}bool Ͳ=false;string ͱ="";double Ͱ
=0;void ˮ(){Ͳ=false;Ͱ=0;foreach(IMyRadioAntenna ˣ in ϥ){if(ˣ!=null){if(ˣ.IsFunctional){float Ɵ=ˣ.Radius;if(Ɵ>Ͱ)Ͱ=Ɵ;if(ˣ.
IsBroadcasting&&ˣ.Enabled)Ͳ=true;}}}}void ˬ(string ˤ){ͱ=ˤ;foreach(IMyTerminalBlock ɐ in ϥ){IMyRadioAntenna ˣ=ɐ as IMyRadioAntenna;if(ˣ
!=null)ˣ.HudText=ˤ;}}void ˢ(){if(!ʻ)return;foreach(var ğ in ϭ){if(!ğ.ϲ&&!ğ.ϱ)continue;if(ʀ)Echo("Checking "+ğ.ϰ);List<Г>ˑ=
ğ.Ϫ.Concat(ğ.ϴ).ToList();List<Г>ˡ=new List<Г>();List<Г>Χ=new List<Г>();List<Г>ϗ=new List<Г>();List<Г>ϖ=new List<Г>();List
<Г>ϕ=new List<Г>();int ϔ=0;int ϓ=0;double ϒ=.97;if(ğ.Ϯ<1)ϒ=ğ.Ϯ*.97;foreach(Г ϑ in ˑ){if(ϑ==null)continue;if(ϑ.А){ϓ++;ϔ+=ϑ
.Б;if(ϑ.Џ<ϒ)ϗ.Add(ϑ);else if(ğ.Ϯ<1&&ϑ.Џ>ğ.Ϯ*1.03)ϖ.Add(ϑ);if(ϑ.Џ!=0)Χ.Add(ϑ);}else{ϕ.Add(ϑ);if(ϑ.Б>0){ˡ.Add(ϑ);}}}if(ϗ.
Count>0){int ϐ=(int)(ϔ/ϓ);ϗ=ϗ.OrderBy(Ĳ=>Ĳ.Б).ToList();if(ğ.Ͼ>0){if(ʀ)Echo("Loading "+ğ.ϳ.SubtypeId+"...");ˡ=ˡ.
OrderByDescending(Ĳ=>Ĳ.Б).ToList();ч(ˡ,ϗ,ğ.ϳ,-1,ğ.Ϯ);}else{if(ʀ)Echo("Balancing "+ğ.ϳ.SubtypeId+"...");Χ=Χ.OrderByDescending(Ĳ=>Ĳ.Б).
ToList();ч(Χ,ϗ,ğ.ϳ,ϐ);}}else if(ϖ.Count>0){if(ʀ)Echo("Unloading "+ğ.ϳ.SubtypeId+"...");List<Г>Ϗ=new List<Г>();if(ˡ.Count>0)Ϗ=ˡ
;else Ϗ=ϕ;ч(ϖ,Ϗ,ğ.ϳ,-1,1,ğ.Ϯ);}else{if(ʀ)Echo("No loading required "+ğ.ϳ.SubtypeId+"...");}}}void ώ(){Φ=0;foreach(
IMyTerminalBlock ɐ in ψ){if(ɐ==null)continue;if(ɐ.IsWorking)Φ++;}}void ύ(Ơ I){if(I==Ơ.NoChange)return;foreach(IMyTerminalBlock ɐ in ψ){
if(ɐ==null)continue;try{bool ό=ɐ.BlockDefinition.ToString().Contains("ToolCore");if(I==Ơ.On||ό)ɐ.ApplyAction("OnOff_On");
else if(!ό)ɐ.ApplyAction("OnOff_Off");if(ό){ITerminalAction Ɲ=ɐ.GetActionWithName("ToolCore_Shoot_Action");if(Ɲ!=null){
StringBuilder ϩ=new StringBuilder();Ɲ.WriteValue(ɐ,ϩ);string ϧ=ϩ.ToString();if(ʀ)Echo(ϧ);if(ϧ=="Active"&&I==Ơ.Off)Ɲ.Apply(ɐ);else if(
ϧ=="Inactive"&&I==Ơ.On)Ɲ.Apply(ɐ);}}}catch{if(ʀ)Echo("Failed to set aux block "+ɐ.CustomName);}}}IMyShipController Ϧ;List
<IMyRadioAntenna>ϥ=new List<IMyRadioAntenna>();List<IMyBatteryBlock>Ϥ=new List<IMyBatteryBlock>();List<IMyCameraBlock>ϣ=
new List<IMyCameraBlock>();List<IMyCargoContainer>Ϣ=new List<IMyCargoContainer>();List<IMyShipConnector>ϡ=new List<
IMyShipConnector>();List<IMyShipController>Ϩ=new List<IMyShipController>();List<IMyAirtightHangarDoor>Ϡ=new List<IMyAirtightHangarDoor>(
);List<IMyTerminalBlock>ϟ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ϟ=new List<IMyTerminalBlock>();List<IMyGyro>
ϝ=new List<IMyGyro>();List<IMyProjector>Ϝ=new List<IMyProjector>();List<IMyReactor>ϛ=new List<IMyReactor>();List<
IMySensorBlock>Ϛ=new List<IMySensorBlock>();List<IMyTerminalBlock>ϙ=new List<IMyTerminalBlock>();List<IMyGasTank>Ϙ=new List<IMyGasTank
>();List<IMyGasTank>ϋ=new List<IMyGasTank>();List<IMyAirVent>ι=new List<IMyAirVent>();List<IMyTerminalBlock>Ψ=new List<
IMyTerminalBlock>();List<IMyConveyorSorter>η=new List<IMyConveyorSorter>();List<IMyTerminalBlock>ζ=new List<IMyTerminalBlock>();List<
IMyTerminalBlock>ε=new List<IMyTerminalBlock>();List<IMyTerminalBlock>δ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>γ=new List<
IMyTerminalBlock>();List<IMyThrust>β=new List<IMyThrust>();List<IMyThrust>α=new List<IMyThrust>();List<IMyThrust>ΰ=new List<IMyThrust>()
;List<IMyThrust>ί=new List<IMyThrust>();List<IMyProgrammableBlock>ή=new List<IMyProgrammableBlock>();List<
IMyProgrammableBlock>έ=new List<IMyProgrammableBlock>();List<IMyTextPanel>ά=new List<IMyTextPanel>();List<IMyTextPanel>Ϋ=new List<
IMyTextPanel>();List<њ>Ϊ=new List<њ>();List<IMyLightingBlock>Ω=new List<IMyLightingBlock>();List<IMyLightingBlock>θ=new List<
IMyLightingBlock>();List<IMyLightingBlock>κ=new List<IMyLightingBlock>();List<IMyLightingBlock>ω=new List<IMyLightingBlock>();List<
IMyReflectorLight>ϊ=new List<IMyReflectorLight>();List<IMyTerminalBlock>ψ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>χ=new List<
IMyTerminalBlock>();List<ѧ>φ=new List<ѧ>();List<Ҷ>υ=new List<Ҷ>();Dictionary<IMyTerminalBlock,string>τ=new Dictionary<IMyTerminalBlock,
string>();bool σ(IMyTerminalBlock ɇ){try{if(!Me.IsSameConstructAs(ɇ))return false;string ς=ɇ.GetOwnerFactionTag();if(ς!=Ρ&&ς!=
""){Echo("!"+ς+": "+ɇ.CustomName);Υ++;return false;}if(ɇ.CustomName.Contains(ʲ))return false;if(!Ί&&ʼ&&!ɇ.CustomName.
Contains(ʏ))return false;string ρ=ɇ.BlockDefinition.ToString();if(ɇ.CustomName.Contains(ʯ)){ψ.Add(ɇ);}if(ρ.Contains(
"MedicalRoom/")){if(ͽ)ɇ.CustomData=Ο;else ɇ.CustomData=Π;ϙ.Add(ɇ);if(Ί)τ.Add(ɇ,"Medical Room");return false;}if(ρ.Contains(
"SurvivalKit/")){if(ͽ)ɇ.CustomData=Ο;else ɇ.CustomData=Π;ϙ.Add(ɇ);if(Ί)τ.Add(ɇ,"Survival Kit");return false;}if(ρ==
"MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Ί)τ.Add(ɇ,"Refill Station");return false;}var π=ɇ as IMyTextPanel;if(π!=null){ά.Add(π);if(Ί)τ.Add(ɇ,"LCD");if(π.
CustomName.Contains(ʱ)){њ ο=new њ();ο.ɐ=π;Ϊ.Add(Ʉ(ο));}else if(!ʅ&&π.CustomName.Contains(ʰ))Ϋ.Add(π);return false;}if(ρ==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɜ(ɇ,"Flak",3);if(ρ=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɜ(ɇ,
"OPA",3);if(ρ=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɜ(ɇ,"Voltaire",3);if(ρ.Contains
("Nariman Dynamics PDC"))return ɜ(ɇ,"Nari",4);if(ρ.Contains("Redfields Ballistics PDC"))return ɜ(ɇ,"Red",4);if(ρ.Contains
("OPA Shotgun PDC"))return ɜ(ɇ,"Shotgun",4);if(ρ=="MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return ɉ
(ɇ,"Apollo");if(ρ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɉ(ɇ,"Tycho");if(ρ==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return ɉ(ɇ,"Zeus");if(ρ=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɉ(ɇ,"Tycho");if(ρ.Contains(
"Ares_Class"))return ɉ(ɇ,"Ares");if(ρ.Contains("Artemis_Torpedo_Tube"))return ɉ(ɇ,"Artemis");if(ρ==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return Ɉ(ɇ,"Dawson",11);if(ρ=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return Ɉ(ɇ,"Stiletto",12);if
(ρ=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return Ɉ(ɇ,"Roci",13);if(ρ==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return Ɉ(ɇ,"Foehammer",14);if(ρ=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return Ɉ(ɇ,"Farren",15);
if(ρ.Contains("Zakosetara"))return Ɉ(ɇ,"Zako",10);if(ρ.Contains("Kess Hashari Cannon"))return Ɉ(ɇ,"Kess",16);if(ρ.Contains
("Coilgun"))return Ɉ(ɇ,"Coilgun",13);if(ρ.Contains("Glapion"))return Ɉ(ɇ,"Glapion",3);var ξ=ɇ as IMyThrust;if(ξ!=null){if
(ρ.ToUpper().Contains("RCS")){α.Add(ξ);if(Ί)τ.Add(ɇ,"RCS");}else if(ρ.Contains("Hydro")){ΰ.Add(ξ);if(Ί)τ.Add(ɇ,"Chem");}
else if(ρ.Contains("Atmospheric")){ί.Add(ξ);if(Ί)τ.Add(ɇ,"Atmo");}else{β.Add(ξ);if(Ί){string Ɋ="";if(ʈ){try{Ɋ=ɇ.
DefinitionDisplayNameText.Split('"')[1];Ɋ=ʊ+Ɋ[0].ToString().ToUpper()+Ɋ.Substring(1).ToLower();}catch{if(ʀ)Echo("Failed to get drive type from "+
ɇ.DefinitionDisplayNameText);}}τ.Add(ɇ,"Epstein"+Ɋ);}}return false;}var ν=ɇ as IMyCargoContainer;if(ν!=null){string μ=ρ.
Split('/')[1];if(μ.Contains("Container")||μ.Contains("Cargo")){Ϣ.Add(ν);Ϭ(ɇ);if(Ί){double λ=ɇ.GetInventory().MaxVolume.
RawValue;double ʾ=Math.Round(λ/1265625024,1);if(ʾ==0)ʾ=0.1;τ.Add(ɇ,"Cargo ["+ʾ+"]");}return false;}}var ɪ=ɇ as IMyGyro;if(ɪ!=
null){ϝ.Add(ɪ);if(Ί)τ.Add(ɇ,"Gyroscope");return false;}var Ɏ=ɇ as IMyBatteryBlock;if(Ɏ!=null){Ϥ.Add(Ɏ);if(Ί)τ.Add(ɇ,"Power"+
ʊ+"Battery");return false;}var ɩ=ɇ as IMyReflectorLight;if(ɩ!=null){ϊ.Add(ɩ);if(Ί)τ.Add(ɇ,"Spotlight");return false;}var
ɨ=ɇ as IMyLightingBlock;if(ɨ!=null){if(ɇ.CustomName.ToUpper().Contains("INTERIOR")){θ.Add(ɨ);if(Ί)τ.Add(ɇ,"Light"+ʊ+
"Interior");}else if(ρ.Contains("Kitchen")||ρ.Contains("Aquarium")){θ.Add(ɨ);if(Ί)τ.Add(ɇ,"Light"+ʊ+"Interior"+ʊ+ɇ.
DefinitionDisplayNameText);}else if(ɇ.CustomName.Contains(ʞ)){if(ɇ.CustomName.ToUpper().Contains("STARBOARD")){ω.Add(ɨ);if(Ί)τ.Add(ɇ,"Light"+ʊ+
"Nav"+ʊ+"Starboard");}else{κ.Add(ɨ);if(Ί)τ.Add(ɇ,"Light"+ʊ+"Nav"+ʊ+"Port");}}else{Ω.Add(ɨ);if(Ί)τ.Add(ɇ,"Light"+ʊ+"Exterior")
;}return false;}var ɧ=ɇ as IMyGasTank;if(ɧ!=null){if(ρ.Contains("Hydro")){Ϙ.Add(ɧ);if(Ί)τ.Add(ɇ,"Tank"+ʊ+"Hydrogen");}
else{ϋ.Add(ɧ);if(Ί)τ.Add(ɇ,"Tank"+ʊ+"Oxygen");}return false;}var ɦ=ɇ as IMyReactor;if(ɦ!=null){ϛ.Add(ɦ);Ϭ(ɇ,0);if(Ί){string
ɥ="Lg";if(ρ.Contains("SmallGenerator"))ɥ="Sm";else if(ρ.Contains("MCRN"))ɥ="MCRN";τ.Add(ɇ,"Power"+ʊ+"Reactor"+ʊ+ɥ);}
return false;}var ɤ=ɇ as IMyShipController;if(ɤ!=null){Ϩ.Add(ɤ);if(Ϧ==null&&ɇ.CustomName.Contains("Nav"))Ϧ=ɤ;if(ɤ.HasInventory
)Ϭ(ɇ);if(Ί&&ρ.Contains("Cockpit/")){if(ρ.Contains("StandingCockpit")||ρ.Contains("Console")){τ.Add(ɇ,"Console");return
false;}else if(ρ.Contains("Cockpit")){τ.Add(ɇ,"Cockpit");return false;}}}var ɣ=ɇ as IMyDoor;if(ɣ!=null){ѧ ɢ=new ѧ();ɢ.ɐ=ɣ;if(
ɇ.CustomName.Contains(ɽ)){try{string ɞ=ɇ.CustomName.Split(ʊ)[3];ɢ.Ҹ=true;bool ɝ=false;foreach(Ҷ ɡ in υ){if(ɞ==ɡ.ҵ){ɡ.ұ.
Add(ɢ);ɝ=true;break;}}if(!ɝ){Ҷ ɠ=new Ҷ();ɠ.ҵ=ɞ;ɠ.ұ.Add(ɢ);υ.Add(ɠ);}}catch{if(ʀ)Echo("Error with airlock door name "+ɇ.
CustomName);φ.Add(ɢ);}}else{φ.Add(ɢ);}if(Ί)τ.Add(ɇ,"Door");return false;}var ɟ=ɇ as IMyAirVent;if(ɟ!=null){ι.Add(ɟ);if(ɇ.
CustomName.Contains(ɽ)){try{string ɞ=ɇ.CustomName.Split(ʊ)[3];bool ɝ=false;foreach(Ҷ ɡ in υ){if(ɞ==ɡ.ҵ){ɡ.Ұ.Add(ɟ);ɝ=true;break;}}
if(!ɝ){Ҷ ɠ=new Ҷ();ɠ.ҵ=ɞ;ɠ.Ұ.Add(ɟ);υ.Add(ɠ);}}catch{if(ʀ)Echo("Error with airlock vent name "+ɇ.CustomName);}}if(Ί)τ.Add(
ɇ,"Vent");return false;}var ɺ=ɇ as IMyCameraBlock;if(ɺ!=null){ϣ.Add(ɺ);if(Ί)τ.Add(ɇ,"Camera");return false;}var ɻ=ɇ as
IMyShipConnector;if(ɻ!=null){ϡ.Add(ɻ);Ϭ(ɇ);if(Ί){string ɹ="";if(ρ.Contains("Passageway"))ɹ=ʊ+"Passageway";τ.Add(ɇ,"Connector"+ɹ);}return
false;}var ɸ=ɇ as IMyAirtightHangarDoor;if(ɸ!=null){Ϡ.Add(ɸ);if(Ί)τ.Add(ɇ,"Door"+ʊ+"Hangar");return false;}if(ρ.Contains(
"Lidar")){var ɷ=ɇ as IMyConveyorSorter;if(ɷ!=null){η.Add(ɷ);if(Ί)τ.Add(ɇ,"LiDAR");return false;}}if(ρ==
"MyObjectBuilder_OxygenGenerator/Extractor"){ϟ.Add(ɇ);if(Ί)τ.Add(ɇ,"Extractor");return false;}if(ρ=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){Ϟ.Add(ɇ);if(Ί
)τ.Add(ɇ,"Extractor");return false;}var ɶ=ɇ as IMyRadioAntenna;if(ɶ!=null){ϥ.Add(ɶ);if(Ί)τ.Add(ɇ,"Antenna");return false;
}var ɵ=ɇ as IMyProgrammableBlock;if(ɵ!=null){if(Ί)τ.Add(ɇ,"PB Server");if(ɵ==Me)return false;try{if(ɇ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))ή.Add(ɵ);else if(ɇ.CustomData.Contains("NavConfig"))έ.Add(ɵ);return false;}catch{}}var
ɴ=ɇ as IMyProjector;if(ɴ!=null){Ϝ.Add(ɴ);if(Ί)τ.Add(ɇ,"Projectors");return false;}var ɳ=ɇ as IMySensorBlock;if(ɳ!=null){Ϛ
.Add(ɳ);if(Ί)τ.Add(ɇ,"Sensor");return false;}var ɲ=ɇ as IMyCollector;if(ɲ!=null){Ϭ(ɇ);if(Ί)τ.Add(ɇ,"Collector");return
false;}if(ρ.Contains("Welder")){Ψ.Add(ɇ);if(Ί)τ.Add(ɇ,"Tool"+ʊ+"Welder");return false;}if(Ί){if(ρ.Contains("LandingGear/")){
if(ρ.Contains("Clamp"))τ.Add(ɇ,"Clamp");else if(ρ.Contains("Magnetic"))τ.Add(ɇ,"Mag Lock");else τ.Add(ɇ,"Gear");return
false;}if(ρ.Contains("Drill")){τ.Add(ɇ,"Tool"+ʊ+"Drill");return false;}if(ρ.Contains("Grinder")){τ.Add(ɇ,"Tool"+ʊ+"Grinder");
return false;}if(ρ.Contains("Solar")){τ.Add(ɇ,"Solar");return false;}if(ρ.Contains("ButtonPanel")){τ.Add(ɇ,"Button Panel");
return false;}var ɱ=ɇ as IMyConveyorSorter;if(ɱ!=null){τ.Add(ɇ,"Sorter");return false;}var ɰ=ɇ as IMyMotorSuspension;if(ɰ!=
null){τ.Add(ɇ,"Suspension");return false;}var ɯ=ɇ as IMyGravityGenerator;if(ɯ!=null){τ.Add(ɇ,"Grav Gen");return false;}var ɮ
=ɇ as IMyTimerBlock;if(ɮ!=null){τ.Add(ɇ,"Timer");return false;}var ɭ=ɇ as IMyGasGenerator;if(ɭ!=null){τ.Add(ɇ,"H2 Engine"
);return false;}var ɬ=ɇ as IMyBeacon;if(ɬ!=null){τ.Add(ɇ,"Beacon");return false;}τ.Add(ɇ,ɇ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ʀ){Echo("Failed to sort "+ɇ.CustomName+"\nAdded "+τ.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɫ(){Ϧ=null;ϥ.Clear();Ϥ.Clear();ϣ.Clear();Ϣ.Clear();ϡ.Clear();Ϩ.Clear();φ.Clear();υ.Clear();Ϡ.Clear();ϟ.
Clear();Ϟ.Clear();ϝ.Clear();Ϝ.Clear();ϛ.Clear();Ϛ.Clear();Ϙ.Clear();ϋ.Clear();ι.Clear();Ψ.Clear();η.Clear();ζ.Clear();ε.Clear
();δ.Clear();γ.Clear();β.Clear();α.Clear();ΰ.Clear();ί.Clear();ή.Clear();έ.Clear();ά.Clear();Ϊ.Clear();Ϋ.Clear();Ω.Clear(
);θ.Clear();κ.Clear();ω.Clear();ϊ.Clear();ψ.Clear();foreach(var ğ in ϭ)ğ.Ϫ.Clear();if(Ί)τ.Clear();}bool ɜ(
IMyTerminalBlock ɇ,string Œ,int Ɇ){if(ɇ.CustomName.Contains(ʮ))ε.Add(ɇ);else ζ.Add(ɇ);Ϭ(ɇ,Ɇ);if(Ί){string Ɋ="";if(ʉ)Ɋ=ʊ+Œ;τ.Add(ɇ,"PDC"+
Ɋ);}return false;}bool ɉ(IMyTerminalBlock ɇ,string Œ){γ.Add(ɇ);if(Ί){string Ʌ="";if(ʉ)Ʌ=ʊ+Œ;τ.Add(ɇ,"Torpedo"+Ʌ);}return
false;}bool Ɉ(IMyTerminalBlock ɇ,string Œ,int Ɇ){δ.Add(ɇ);Ϭ(ɇ,Ɇ);if(Ί){string Ʌ="";if(ʉ)Ʌ=ʊ+Œ;τ.Add(ɇ,"Railgun"+Ʌ);}return
false;}њ Ʉ(њ Ħ,string Ƀ=""){bool ɂ=Ƀ=="",ɋ=!ɂ;string ɍ=Ħ.ɐ.CustomData,ɚ="RSM.LCD";string[]ɛ=null;MyIni ə=new MyIni();
MyIniParseResult Ƈ;if(!ɂ||ɍ=="")ɋ=true;else{try{if(ɍ.Substring(0,12)=="Show Header="){ɛ=ɍ.Split('\n');foreach(string ɘ in ɛ){if(ɘ.
Contains("hud")){if(ɘ.Contains("lcd")){Ƀ=ɘ;break;}}else if(ɘ.Contains("=")){string[]ɗ=ɘ.Split('=');if(ɗ[0]==
"Show Tanks & Batteries")Ħ.ѕ=bool.Parse(ɗ[1]);else if(ɗ[0]=="Show header"||ɗ[0]=="Show Header")Ħ.ј=bool.Parse(ɗ[1]);else if(ɗ[0]==
"Show Header Overlay")Ħ.ї=bool.Parse(ɗ[1]);else if(ɗ[0]=="Show Warnings")Ħ.і=bool.Parse(ɗ[1]);else if(ɗ[0]=="Show Inventory")Ħ.є=bool.Parse(ɗ
[1]);else if(ɗ[0]=="Show Thrust")Ħ.ѓ=bool.Parse(ɗ[1]);else if(ɗ[0]=="Show Subsystem Integrity")Ħ.ђ=bool.Parse(ɗ[1]);else
if(ɗ[0]=="Show Advanced Thrust")Ħ.ё=bool.Parse(ɗ[1]);}}}else if(!ə.TryParse(ɍ,out Ƈ)){ɋ=true;}else{Ħ.ј=ə.Get(ɚ,
"ShowHeader").ToBoolean(Ħ.ј);Ħ.ї=ə.Get(ɚ,"ShowHeaderOverlay").ToBoolean(Ħ.ї);Ħ.і=ə.Get(ɚ,"ShowWarnings").ToBoolean(Ħ.і);Ħ.ѕ=ə.Get(ɚ,
"ShowPowerAndTanks").ToBoolean(Ħ.ѕ);Ħ.є=ə.Get(ɚ,"ShowInventory").ToBoolean(Ħ.є);Ħ.ѓ=ə.Get(ɚ,"ShowThrust").ToBoolean(Ħ.ѓ);Ħ.ђ=ə.Get(ɚ,
"ShowIntegrity").ToBoolean(Ħ.ђ);Ħ.ё=ə.Get(ɚ,"ShowAdvancedThrust").ToBoolean(Ħ.ё);}}catch(Exception ex){if(ʀ)Echo(
"LCD parsing error, resetting\n"+ex.Message);ɋ=true;}}if(Ħ.ј&&Ħ.ї){Ħ.ј=false;ɋ=true;}if(ɋ){if(ɛ==null)ɛ=ɍ.Split('\n');ə.Set(ɚ,"ShowHeader",Ħ.ј);ə.Set(ɚ,
"ShowHeaderOverlay",Ħ.ї);ə.Set(ɚ,"ShowWarnings",Ħ.і);ə.Set(ɚ,"ShowPowerAndTanks",Ħ.ѕ);ə.Set(ɚ,"ShowInventory",Ħ.є);ə.Set(ɚ,"ShowThrust",Ħ.ѓ
);ə.Set(ɚ,"ShowIntegrity",Ħ.ђ);ə.Set(ɚ,"ShowAdvancedThrust",Ħ.ё);ə.Set(ɚ,"Hud",Ƀ);Ħ.ɐ.CustomData=ə.ToString();if(ɂ)Ш.Add(
new ѐ("LCD CONFIG ERROR!!","Failed to parse LCD config for "+Ħ.ɐ.CustomName+"!\nLCD config was reset!",3));}return Ħ;}void
ɖ(IMyTerminalBlock ɐ,bool ȫ){ɐ.GetActionWithName("ToolCore_Shoot_Action").Apply(ɐ);(ɐ as IMyConveyorSorter).
GetActionWithName("ToolCore_Shoot_Action").Apply(ɐ);}void ɕ(){List<IMyTerminalBlock>ɔ=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(ɔ);string ɓ="";foreach(IMyTerminalBlock ɒ in ɔ){ɓ+=ɒ.BlockDefinition+"\n";}if(ϥ.Count>0&&ϥ[0]!=null){
ϥ[0].CustomData=ɓ;}}void ɑ(string ȳ){IMyTerminalBlock ɐ=GridTerminalSystem.GetBlockWithName(ȳ);List<ITerminalAction>ɏ=new
List<ITerminalAction>();ɐ.GetActions(ɏ);List<ITerminalProperty>Ɍ=new List<ITerminalProperty>();ɐ.GetProperties(Ɍ);string ɼ=ɐ
.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction ʎ in ɏ){ɼ+=ʎ.Id+" "+ʎ.Name+"\n";}ɼ+="\n\n**Properties**\n\n";
foreach(ITerminalProperty ʫ in Ɍ){ɼ+=ʫ.Id+" "+ʫ.TypeName+"\n";}if(ϥ.Count>0&&ϥ[0]!=null)ϥ[0].CustomData=ɼ;ɐ.CustomData=ɼ;}void
ʩ(IMyTerminalBlock Ʀ){bool ʧ=Ʀ.GetValue<bool>("WC_Repel");if(!ʧ)Ʀ.ApplyAction("WC_RepelMode");}void ʨ(IMyTerminalBlock Ʀ)
{bool ʧ=Ʀ.GetValue<bool>("WC_Repel");if(ʧ)Ʀ.ApplyAction("WC_RepelMode");}void ʦ(IMyTerminalBlock Ʀ){try{if(Ǣ.Ɨ(Ʀ,0)==
VRageMath.Matrix.Zero)return;Ʀ.SetValue<Int64>("WC_Shoot Mode",3);if(ʀ)Echo("Shoot mode = "+Ʀ.GetValue<Int64>("WC_Shoot Mode"));}
catch{Echo("Failed to set fire mode to manual on "+Ʀ.CustomName);}}void ʥ(IMyTerminalBlock Ʀ){try{if(Ǣ.Ɨ(Ʀ,0)==VRageMath.
Matrix.Zero)return;Ʀ.SetValue<Int64>("WC_Shoot Mode",0);if(ʀ)Echo("Shoot mode = "+Ʀ.GetValue<Int64>("WC_Shoot Mode"));}catch{
Echo("Failed to set fire mode to auto on "+Ʀ.CustomName);}}void ʤ(){if(Ϧ!=null){try{Τ=Ϧ.GetShipSpeed();Σ=Ϧ.CalculateShipMass
().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo(exxie.Message);}}}double ʣ=0;double
ʢ=0;double ʡ=0;void ʠ(){ʢ=0;foreach(IMyCargoContainer ʪ in Ϣ){if(ʪ!=null&&ʪ.IsFunctional){ʢ+=ʪ.GetInventory().MaxVolume.
RawValue;}}ʡ=Math.Round(100*(ʢ/ʣ));}void ʬ(){ʣ=0;foreach(IMyCargoContainer ʪ in Ϣ){if(ʪ!=null)ʣ+=ʪ.GetInventory().MaxVolume.
RawValue;}}MyIni ʽ=new MyIni();bool ʼ=false;bool ʻ=true;bool ʺ=true;bool ʹ=true;bool ʸ=true;bool ʷ=false;string ʶ="";bool ʵ=true
;int ʴ=3;int ʳ=6;string ʲ="[I]";string ʱ="[RSM]";string ʰ="[CS]";string ʯ="Autorepair";string ʮ="Repel";string ʭ="Min";
string ʟ="Docking";string ʞ="Nav";string ɽ="Airlock";string ʌ="[EFC]";string ʋ="[NavOS]";char ʊ='.';bool ʉ=true;bool ʈ=true;
List<string>ʇ=new List<string>();bool ʆ=false;bool ʅ=false;bool ʄ=true;List<double>ʃ=new List<double>();bool ʂ=false;double
ʁ=0.5;bool ʀ=true;bool ɿ=false;int ɾ=0;int ʍ=100;string ʏ="";bool ʝ(){string ɍ=Me.CustomData;string ɚ="";bool ʜ=true;
MyIniParseResult Ƈ;if(!ʽ.TryParse(ɍ,out Ƈ)){string[]ʛ=ɍ.Split('\n');if(ʛ[1]=="Reedit Ship Management"){Echo("Legacy config detected...")
;ҏ(ɍ);return false;}else{Echo("Could not parse custom data!\n"+Ƈ.ToString());return false;}}try{ɚ="RSM.Main";Echo(ɚ);ʼ=ʽ.
Get(ɚ,"RequireShipName").ToBoolean(ʼ);ʻ=ʽ.Get(ɚ,"EnableAutoload").ToBoolean(ʻ);ʺ=ʽ.Get(ɚ,"AutoloadReactors").ToBoolean(ʺ);ʹ
=ʽ.Get(ɚ,"AutoConfigWeapons").ToBoolean(ʹ);ʸ=ʽ.Get(ɚ,"SetTurretFireMode").ToBoolean(ʸ);ɚ="RSM.Spawns";Echo(ɚ);ʷ=ʽ.Get(ɚ,
"PrivateSpawns").ToBoolean(ʷ);ʶ=ʽ.Get(ɚ,"FriendlyTags").ToString(ʶ);ɚ="RSM.Doors";Echo(ɚ);ʵ=ʽ.Get(ɚ,"EnableDoorManagement").ToBoolean(ʵ
);ʴ=ʽ.Get(ɚ,"DoorCloseTimer").ToInt32(ʴ);ʴ=ʽ.Get(ɚ,"AirlockDoorDisableTimer").ToInt32(ʴ);ɚ="RSM.Keywords";Echo(ɚ);ʲ=ʽ.Get
(ɚ,"Ignore").ToString(ʲ);ʱ=ʽ.Get(ɚ,"RsmLcds").ToString(ʱ);ʰ=ʽ.Get(ɚ,"ColourSyncLcds").ToString(ʰ);ʯ=ʽ.Get(ɚ,
"AuxiliaryBlocks").ToString(ʯ);ʮ=ʽ.Get(ɚ,"DefensivePdcs").ToString(ʮ);ʭ=ʽ.Get(ɚ,"MinimumThrusters").ToString(ʭ);ʟ=ʽ.Get(ɚ,
"DockingThrusters").ToString(ʟ);ʞ=ʽ.Get(ɚ,"NavLights").ToString(ʞ);ɽ=ʽ.Get(ɚ,"Airlock").ToString(ɽ);ɚ="RSM.InitNaming";Echo(ɚ);ʊ=ʽ.Get(ɚ,
"Ignore").ToChar(ʊ);ʉ=ʽ.Get(ɚ,"NameWeaponTypes").ToBoolean(ʉ);ʈ=ʽ.Get(ɚ,"NameDriveTypes").ToBoolean(ʈ);string ʚ=ʽ.Get(ɚ,
"BlocksToNumber").ToString("");string[]ʙ=ʚ.Split(',');ʇ.Clear();foreach(string ȳ in ʙ)if(ȳ!="")ʇ.Add(ȳ);ɚ="RSM.Misc";Echo(ɚ);ʆ=ʽ.Get(ɚ,
"DisableLightingControl").ToBoolean(ʆ);ʅ=ʽ.Get(ɚ,"DisableLcdColourControl").ToBoolean(ʅ);ʄ=ʽ.Get(ɚ,"ShowBasicTelemetry").ToBoolean(ʄ);string ʘ=ʽ
.Get(ɚ,"DecelerationPercentages").ToString("");string[]ʗ=ʘ.Split(',');if(ʗ.Length>1){ʃ.Clear();foreach(string ʖ in ʗ){ʃ.
Add(double.Parse(ʖ)/100);}}ʂ=ʽ.Get(ɚ,"ShowThrustInMetric").ToBoolean(ʂ);ʁ=ʽ.Get(ɚ,"ReactorFillRatio").ToDouble(ʁ);ϭ[0].Ϯ=ʁ;
ɚ="RSM.Debug";Echo(ɚ);ʀ=ʽ.Get(ɚ,"VerboseDebugging").ToBoolean(ʀ);ɿ=ʽ.Get(ɚ,"RuntimeProfiling").ToBoolean(ɿ);ʍ=ʽ.Get(ɚ,
"BlockRefreshFreq").ToInt32(ʍ);ɾ=ʽ.Get(ɚ,"StallCount").ToInt32(ɾ);ɚ="RSM.System";Echo(ɚ);ʏ=ʽ.Get(ɚ,"ShipName").ToString(ʏ);ɚ=
"RSM.InitItems";Echo(ɚ);foreach(ğ ʕ in ϭ){ʕ.Ѝ=ʽ.Get(ɚ,ʕ.ϳ.SubtypeId).ToInt32(ʕ.Ѝ);}ɚ="RSM.InitSubSystems";Echo(ɚ);G=ʽ.Get(ɚ,"Reactors")
.ToDouble(G);G=ʽ.Get(ɚ,"Batteries").ToDouble(G);Ë=ʽ.Get(ɚ,"Pdcs").ToInt32(Ë);ȉ=ʽ.Get(ɚ,"TorpLaunchers").ToInt32(ȉ);Y=ʽ.
Get(ɚ,"KineticWeapons").ToInt32(Y);Õ=ʽ.Get(ɚ,"H2Storage").ToDouble(Õ);ê=ʽ.Get(ɚ,"O2Storage").ToDouble(ê);ã=ʽ.Get(ɚ,
"MainThrust").ToSingle(ã);Ȅ=ʽ.Get(ɚ,"RCSThrust").ToSingle(Ȅ);Ҧ=ʽ.Get(ɚ,"Gyros").ToDouble(Ҧ);ʣ=ʽ.Get(ɚ,"CargoStorage").ToDouble(ʣ);ƥ=
ʽ.Get(ɚ,"Welders").ToInt32(ƥ);}catch(Exception ex){ѭ(ex,"Failed to parse section\n"+ɚ);}Echo("Parsing stances...");
Dictionary<string,Í>ʔ=new Dictionary<string,Í>();List<string>ʓ=new List<string>();ʽ.GetSections(ʓ);foreach(string ʒ in ʓ){if(ʒ.
Contains("RSM.Stance.")){string ʑ=ʒ.Substring(11);Echo(ʑ);Í Ø=new Í();string ġ,Ӄ="";string[]Ѿ;int Ѽ=33,ѻ=144,ɇ=255,Ĳ=255;bool Ѻ=
false;Í ѹ=null;Ӄ="Inherits";if(ʽ.ContainsKey(ʒ,Ӄ)){Ѻ=true;try{ѹ=ʔ[ʽ.Get(ʒ,Ӄ).ToString()];Echo("Inherits "+ʽ.Get(ʒ,Ӄ).ToString
());}catch(Exception ex){ѭ(ex,"Failed to find inheritee for\n"+ʒ+
"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(Ѻ)Echo(ѹ.Ā.ToString());Ӄ="Torps";if(ʽ.ContainsKey(ʒ,Ӄ)){Ø.Ā=(Ơ)Enum.Parse(typeof(Ơ),ʽ.Get(ʒ,Ӄ).ToString());
Echo("1");}else if(Ѻ){Ø.Ā=ѹ.Ā;Echo("2");}else{Ø.Ā=ď;Echo("3");}Ӄ="Pdcs";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.þ=(ǒ)Enum.Parse(typeof(ǒ),ʽ.
Get(ʒ,Ӄ).ToString());else if(Ѻ)Ø.þ=ѹ.þ;else Ø.þ=Ď;Ӄ="Kinetics";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ý=(Ǒ)Enum.Parse(typeof(Ǒ),ʽ.Get(ʒ,Ӄ)
.ToString());else if(Ѻ)Ø.ý=ѹ.ý;else Ø.ý=č;Ӄ="MainThrust";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ü=(Ǔ)Enum.Parse(typeof(Ǔ),ʽ.Get(ʒ,Ӄ).
ToString());else if(Ѻ)Ø.ü=ѹ.ü;else Ø.ü=Č;Ӄ="ManeuveringThrust";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.û=(Ǖ)Enum.Parse(typeof(Ǖ),ʽ.Get(ʒ,Ӄ).
ToString());else if(Ѻ)Ø.û=ѹ.û;else Ø.û=ċ;Ӄ="Spotlights";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ú=(ǔ)Enum.Parse(typeof(ǔ),ʽ.Get(ʒ,Ӄ).ToString())
;else if(Ѻ)Ø.ú=ѹ.ú;else Ø.ú=Ċ;Ӄ="ExteriorLights";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ù=(ǁ)Enum.Parse(typeof(ǁ),ʽ.Get(ʒ,Ӄ).ToString())
;else if(Ѻ)Ø.ù=ѹ.ù;else Ø.ù=ĉ;Ӄ="ExteriorLightColour";if(ʽ.ContainsKey(ʒ,Ӄ)){ġ=ʽ.Get(ʒ,Ӄ).ToString();Ѿ=ġ.Split(',');Ѽ=int
.Parse(Ѿ[0]);ѻ=int.Parse(Ѿ[1]);ɇ=int.Parse(Ѿ[2]);Ĳ=int.Parse(Ѿ[3]);Ø.ø=new Color(Ѽ,ѻ,ɇ,Ĳ);}else if(Ѻ)Ø.ø=ѹ.ø;else Ø.ø=Ĉ;Ӄ
="InteriorLights";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ö=(ǁ)Enum.Parse(typeof(ǁ),ʽ.Get(ʒ,Ӄ).ToString());else if(Ѻ)Ø.ö=ѹ.ö;else Ø.ö=ć;Ӄ
="InteriorLightColour";if(ʽ.ContainsKey(ʒ,Ӄ)){ġ=ʽ.Get(ʒ,Ӄ).ToString();Ѿ=ġ.Split(',');Ѽ=int.Parse(Ѿ[0]);ѻ=int.Parse(Ѿ[1]);
ɇ=int.Parse(Ѿ[2]);Ĳ=int.Parse(Ѿ[3]);Ø.õ=new Color(Ѽ,ѻ,ɇ,Ĳ);}else if(Ѻ)Ø.õ=ѹ.õ;else Ø.õ=Ć;Ӄ="NavLights";if(ʽ.ContainsKey(ʒ
,Ӄ))Ø.ô=(ǁ)Enum.Parse(typeof(ǁ),ʽ.Get(ʒ,Ӄ).ToString());else if(Ѻ)Ø.ô=ѹ.ô;else Ø.ô=ą;Ӄ="LcdTextColour";if(ʽ.ContainsKey(ʒ,
Ӄ)){ġ=ʽ.Get(ʒ,Ӄ).ToString();Ѿ=ġ.Split(',');Ѽ=int.Parse(Ѿ[0]);ѻ=int.Parse(Ѿ[1]);ɇ=int.Parse(Ѿ[2]);Ĳ=int.Parse(Ѿ[3]);Ø.ó=
new Color(Ѽ,ѻ,ɇ,Ĳ);}else if(Ѻ)Ø.ó=ѹ.ó;else Ø.ó=Ą;Ӄ="TanksAndBatteries";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ò=(ǐ)Enum.Parse(typeof(ǐ),ʽ.
Get(ʒ,Ӄ).ToString());else if(Ѻ)Ø.ò=ѹ.ò;else Ø.ò=ă;Ӄ="NavOsEfcBurnPercentage";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ñ=ʽ.Get(ʒ,
"NavOsEfcBurnPercentage").ToInt32(Ă);else if(Ѻ)Ø.ñ=ѹ.ñ;else Ø.ñ=Ă;Ӄ="EfcBoost";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ð=(Ơ)Enum.Parse(typeof(Ơ),ʽ.Get(ʒ,Ӄ).
ToString());else if(Ѻ)Ø.ð=ѹ.ð;else Ø.ð=î;Ӄ="NavOsAbortEfcOff";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ï=(ƿ)Enum.Parse(typeof(ƿ),ʽ.Get(ʒ,Ӄ).
ToString());else if(Ѻ)Ø.ï=ѹ.ï;else Ø.ï=í;Ӄ="NavOsAbortEfcOff";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ï=(ƿ)Enum.Parse(typeof(ƿ),ʽ.Get(ʒ,Ӄ).
ToString());else if(Ѻ)Ø.ï=ѹ.ï;else Ø.ï=í;Ӄ="AuxMode";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ÿ=(Ơ)Enum.Parse(typeof(Ơ),ʽ.Get(ʒ,Ӄ).ToString());
else if(Ѻ)Ø.ÿ=ѹ.ÿ;else Ø.ÿ=Î;Ӄ="Extractor";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ā=(ƾ)Enum.Parse(typeof(ƾ),ʽ.Get(ʒ,Ӄ).ToString());else if(
Ѻ)Ø.ā=ѹ.ā;else Ø.ā=Ý;Ӄ="KeepAlives";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.Ē=(Ơ)Enum.Parse(typeof(Ơ),ʽ.Get(ʒ,Ӄ).ToString());else if(Ѻ)Ø.
Ē=ѹ.Ē;else Ø.Ē=Ü;Ӄ="HangarDoors";if(ʽ.ContainsKey(ʒ,Ӄ))Ø.ē=(ƽ)Enum.Parse(typeof(ƽ),ʽ.Get(ʒ,Ӄ).ToString());else if(Ѻ)Ø.ē=ѹ
.ē;else Ø.ē=Û;ʔ.Add(ʑ,Ø);}catch(Exception ex){ѭ(ex,"Failed to parse stance\n"+ʑ+"\nproperty\n"+Ӄ);}}}if(ʔ.Count<1){Echo(
"Failed to parse any stances!\nStances reset to default!");ʜ=false;}else{Echo("Finished parsing "+ʔ.Count+" stances.");Ѩ=ʔ;}ɚ="RSM.Stance";Echo(ɚ);đ=ʽ.Get(ɚ,"CurrentStance").
ToString(đ);Í Ѹ;if(!Ѩ.TryGetValue(đ,out Ѹ)){đ="N/A";Đ=null;}else Đ=Ѹ;return ʜ;}void ѷ(){ʽ.Clear();string ɚ,ȳ;ɚ="RSM.Main";ȳ=
"RequireShipName";ʽ.Set(ɚ,ȳ,ʼ);ʽ.SetComment(ɚ,ȳ,"limit to blocks with the ship name in their name");ȳ="EnableAutoload";ʽ.Set(ɚ,ȳ,ʻ);ʽ.
SetComment(ɚ,ȳ,"enable RSM loading & balancing functionality for weapons");ȳ="AutoloadReactors";ʽ.Set(ɚ,ȳ,ʺ);ʽ.SetComment(ɚ,ȳ,
"enable loading and balancing for reactors");ȳ="AutoConfigWeapons";ʽ.Set(ɚ,ȳ,ʹ);ʽ.SetComment(ɚ,ȳ,"automatically configure weapon on stance set");ȳ=
"SetTurretFireMode";ʽ.Set(ɚ,ȳ,ʸ);ʽ.SetComment(ɚ,ȳ,"set turret fire mode based on stance");ʽ.SetSectionComment(ɚ,ж+
" Reedit Ship Management\n"+ж+" Config.ini\n Recompile to apply changes!\n"+ж);ɚ="RSM.Spawns";ȳ="PrivateSpawns";ʽ.Set(ɚ,ȳ,ʷ);ʽ.SetComment(ɚ,ȳ,
"don't inject faction tag into spawn custom data");ȳ="FriendlyTags";ʽ.Set(ɚ,ȳ,ʶ);ʽ.SetComment(ɚ,ȳ,"Comma seperated friendly factions or steam ids");ɚ="RSM.Doors";ȳ=
"EnableDoorManagement";ʽ.Set(ɚ,ȳ,ʵ);ʽ.SetComment(ɚ,ȳ,"enable door management functionality");ȳ="DoorCloseTimer";ʽ.Set(ɚ,ȳ,ʴ);ʽ.SetComment(ɚ,ȳ,
"door open timer (x100 ticks)");ȳ="AirlockDoorDisableTimer";ʽ.Set(ɚ,ȳ,ʳ);ʽ.SetComment(ɚ,ȳ,"airlock door disable timer (x100 ticks)");ɚ="RSM.Keywords";
ȳ="Ignore";ʽ.Set(ɚ,ȳ,ʲ);ʽ.SetComment(ɚ,ȳ,"to identify blocks which RSM should ignore");ȳ="RsmLcds";ʽ.Set(ɚ,ȳ,ʱ);ʽ.
SetComment(ɚ,ȳ,"to identify RSM lcds");ȳ="ColourSyncLcds";ʽ.Set(ɚ,ȳ,ʰ);ʽ.SetComment(ɚ,ȳ,"to identify non RSM lcds for colour sync"
);ȳ="AuxiliaryBlocks";ʽ.Set(ɚ,ȳ,ʯ);ʽ.SetComment(ɚ,ȳ,"to identify aux blocks");ȳ="DefensivePdcs";ʽ.Set(ɚ,ȳ,ʮ);ʽ.SetComment
(ɚ,ȳ,"to identify defensive _normalPdcs");ȳ="MinimumThrusters";ʽ.Set(ɚ,ȳ,ʭ);ʽ.SetComment(ɚ,ȳ,
"to identify minimum epsteins");ȳ="DockingThrusters";ʽ.Set(ɚ,ȳ,ʟ);ʽ.SetComment(ɚ,ȳ,"to identify docking epsteins");ȳ="NavLights";ʽ.Set(ɚ,ȳ,ʞ);ʽ.
SetComment(ɚ,ȳ,"to identify navigational lights");ȳ="Airlock";ʽ.Set(ɚ,ȳ,ɽ);ʽ.SetComment(ɚ,ȳ,"to identify airlock doors and vents")
;ɚ="RSM.InitNaming";ȳ="NameDelimiter";ʽ.Set(ɚ,ȳ,ʊ.ToString());ʽ.SetComment(ɚ,ȳ,"single char delimiter for names");ȳ=
"NameWeaponTypes";ʽ.Set(ɚ,ȳ,ʉ);ʽ.SetComment(ɚ,ȳ,"append type names to all weapons on init");ȳ="NameDriveTypes";ʽ.Set(ɚ,ȳ,ʈ);ʽ.SetComment(
ɚ,ȳ,"append type names to all drives on init");string Ѷ="";foreach(string ѵ in ʇ){if(Ѷ!="")Ѷ+=",";Ѷ+=ѵ;}ȳ=
"BlocksToNumber";ʽ.Set(ɚ,ȳ,ʈ);ʽ.SetComment(ɚ,ȳ,"comma seperated list of block names to be numbered at init");ɚ="RSM.Misc";ȳ=
"DisableLightingControl";ʽ.Set(ɚ,ȳ,ʆ);ʽ.SetComment(ɚ,ȳ,"disable all lighting control");ȳ="DisableLcdColourControl";ʽ.Set(ɚ,ȳ,ʅ);ʽ.SetComment(ɚ,ȳ
,"disable text colour control for all lcds");ȳ="ShowBasicTelemetry";ʽ.Set(ɚ,ȳ,ʄ);ʽ.SetComment(ɚ,ȳ,
"show basic telemetry data on advanced thrust lcds");string Ѵ="";foreach(double Ĥ in ʃ){if(Ѵ!="")Ѵ+=",";Ѵ+=(Ĥ*100).ToString();}ȳ="DecelerationPercentages";ʽ.Set(ɚ,ȳ,Ѵ);ʽ.
SetComment(ɚ,ȳ,"thrust percentages to show on advanced thrust lcds");ȳ="ShowThrustInMetric";ʽ.Set(ɚ,ȳ,ʂ);ʽ.SetComment(ɚ,ȳ,
"show basic telemetry data on advanced thrust lcds");ȳ="ReactorFillRatio";ʽ.Set(ɚ,ȳ,ʁ);ʽ.SetComment(ɚ,ȳ,"0-1, fill ratio for reactors");ɚ="RSM.Debug";ȳ="VerboseDebugging";
ʽ.Set(ɚ,ȳ,ʀ);ʽ.SetComment(ɚ,ȳ,"prints more logging info to PB details");ȳ="RuntimeProfiling";ʽ.Set(ɚ,ȳ,ɿ);ʽ.SetComment(ɚ,
ȳ,"prints script runtime profiling info to PB details");ȳ="BlockRefreshFreq";ʽ.Set(ɚ,ȳ,ʍ);ʽ.SetComment(ɚ,ȳ,
"ticks x100 between block refreshes");ȳ="StallCount";ʽ.Set(ɚ,ȳ,ɾ);ʽ.SetComment(ɚ,ȳ,"ticks x100 to stall between runs");ɚ="RSM.Stance";ȳ="CurrentStance";ʽ.
Set(ɚ,ȳ,đ);ʽ.SetSectionComment(ɚ,ж+" Stances\n Add or remove as required\n"+ж);string ѳ="Red, Green, Blue, Alpha";foreach(
var ѽ in Ѩ){ɚ="RSM.Stance."+ѽ.Key;Í Ù=ѽ.Value;Í ѹ=null;if(Ù.Þ!=""){ѹ=Ѩ[Ù.Þ];ȳ="Inherits";ʽ.Set(ɚ,ȳ,Ù.Þ);ʽ.SetComment(ɚ,ȳ,
"Use stance of this name as a template for settings");}ȳ="Torps";if(ѹ!=null&&Ù.Ā==ѹ.Ā){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.Ā.ToString());ʽ.SetComment(ɚ,ȳ,
ѱ(typeof(Ơ)));}ȳ="Pdcs";if(ѹ!=null&&Ù.þ==ѹ.þ){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.þ.ToString());ʽ.
SetComment(ɚ,ȳ,ѱ(typeof(ǒ)));}ȳ="Kinetics";if(ѹ!=null&&Ù.ý==ѹ.ý){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ý.ToString(
));ʽ.SetComment(ɚ,ȳ,ѱ(typeof(Ǒ)));}ȳ="MainThrust";if(ѹ!=null&&Ù.ü==ѹ.ü){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ
,ȳ,Ù.ü.ToString());ʽ.SetComment(ɚ,"MainThrust",ѱ(typeof(Ǔ)));}ȳ="ManeuveringThrust";if(ѹ!=null&&Ù.û==ѹ.û){if(ʽ.
ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.û.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(Ǖ)));}ȳ="Spotlights";if(ѹ!=null&&Ù.ú==ѹ.ú)
{if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ú.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(ǔ)));}ȳ="ExteriorLights";
if(ѹ!=null&&Ù.ù==ѹ.ù){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ù.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(ǁ)));}
ȳ="ExteriorLightColour";if(ѹ!=null&&Ù.ø==ѹ.ø){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ѯ(Ù.ø));ʽ.SetComment(ɚ,
ȳ,ѳ);}ȳ="InteriorLights";if(ѹ!=null&&Ù.ö==ѹ.ö){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ö.ToString());ʽ.
SetComment(ɚ,ȳ,ѱ(typeof(ǁ)));}ȳ="InteriorLightColour";if(ѹ!=null&&Ù.õ==ѹ.õ){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ѯ(
Ù.õ));ʽ.SetComment(ɚ,ȳ,ѳ);}ȳ="NavLights";if(ѹ!=null&&Ù.ô==ѹ.ô){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ô.
ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(ǁ)));}ȳ="LcdTextColour";if(ѹ!=null&&Ù.ó==ѹ.ó){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.
Set(ɚ,ȳ,Ѯ(Ù.ó));ʽ.SetComment(ɚ,ȳ,ѳ);}ȳ="TanksAndBatteries";if(ѹ!=null&&Ù.ò==ѹ.ò){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{
ʽ.Set(ɚ,ȳ,Ù.ò.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(ǐ)));}ȳ="NavOsEfcBurnPercentage";if(ѹ!=null&&Ù.ñ==ѹ.ñ){if(ʽ.
ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ñ.ToString());ʽ.SetComment(ɚ,ȳ,"Burn % 0-100, -1 for no change");}ȳ="EfcBoost";if(
ѹ!=null&&Ù.ð==ѹ.ð){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ð.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(Ơ)));}ȳ=
"NavOsAbortEfcOff";if(ѹ!=null&&Ù.ï==ѹ.ï){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ï.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(ƿ))
);}ȳ="AuxMode";if(ѹ!=null&&Ù.ÿ==ѹ.ÿ){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ÿ.ToString());ʽ.SetComment(ɚ,ȳ
,ѱ(typeof(Ơ)));}ȳ="Extractor";if(ѹ!=null&&Ù.ā==ѹ.ā){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù.ā.ToString());ʽ
.SetComment(ɚ,ȳ,ѱ(typeof(ƾ)));}ȳ="KeepAlives";if(ѹ!=null&&Ù.Ē==ѹ.Ē){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);}else{ʽ.Set(ɚ,ȳ,Ù
.Ē.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(Ơ)));}ȳ="HangarDoors";if(ѹ!=null&&Ù.ē==ѹ.ē){if(ʽ.ContainsKey(ɚ,ȳ))ʽ.Delete(ɚ,ȳ);
}else{ʽ.Set(ɚ,ȳ,Ù.ē.ToString());ʽ.SetComment(ɚ,ȳ,ѱ(typeof(ƽ)));}}ɚ="RSM.System";ȳ="ShipName";ʽ.Set(ɚ,ȳ,ʏ);ʽ.
SetSectionComment(ɚ,ж+" System\n All items below this point are\n set automatically when running init\n"+ж);ɚ="RSM.InitItems";foreach(ğ ʕ
in ϭ){ȳ=ʕ.ϳ.SubtypeId;ʽ.Set(ɚ,ȳ,ʕ.Ѝ);}ɚ="RSM.InitSubSystems";ʽ.Set(ɚ,"Reactors",G);ʽ.Set(ɚ,"Batteries",G);ʽ.Set(ɚ,"Pdcs",Ë
);ʽ.Set(ɚ,"TorpLaunchers",ȉ);ʽ.Set(ɚ,"KineticWeapons",Y);ʽ.Set(ɚ,"H2Storage",Õ);ʽ.Set(ɚ,"O2Storage",ê);ʽ.Set(ɚ,
"MainThrust",ã);ʽ.Set(ɚ,"RCSThrust",Ȅ);ʽ.Set(ɚ,"Gyros",Ҧ);ʽ.Set(ɚ,"CargoStorage",ʣ);ʽ.Set(ɚ,"Welders",ƥ);Me.CustomData=ʽ.ToString();
}void ҏ(string ɍ){string[]ʓ=ɍ.Split(new string[]{"[Stances]"},StringSplitOptions.None);string[]Ҏ=ʓ[0].Split('\n');string
ҍ=ʓ[1];try{for(int Ě=1;Ě<Ҏ.Length;Ě++){if(Ҏ[Ě].Contains("=")){string Ҍ=Ҏ[Ě].Substring(1);switch(Ҏ[(Ě-1)]){case
"Ship name. Blocks without this name will be ignored":ʏ=Ҍ;break;case"Block name delimiter, used by init. One character only!":ʊ=char.Parse(Ҍ.Substring(0,1));break;case
"Keyword used to identify RSM _allLcds.":ʱ=Ҍ;break;case"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʯ=Ҍ;break;
case"Keyword used to identify defence _normalPdcs.":ʮ=Ҍ;break;case"Keyword used to identify minimum epstein drives.":ʭ=Ҍ;
break;case"Keyword used to identify docking epstein drives.":ʟ=Ҍ;break;case"Keyword to ignore block.":ʲ=Ҍ;break;case
"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʹ=bool.Parse(Ҍ);break;case"Disable lighting all control.":ʆ=bool.Parse(Ҍ);break;case
"Disable LCD Text Colour Enforcement.":ʅ=bool.Parse(Ҍ);break;case"Enable Weapon Autoload Functionality.":ʻ=bool.Parse(Ҍ);break;case
"Number these blocks at init.":ʇ.Clear();string[]ҋ=Ҍ.Split(',');foreach(string ѵ in ҋ){if(ѵ!="")ʇ.Add(ѵ);}break;case
"Add type names to weapons at init.":ʉ=bool.Parse(Ҍ);break;case"Show basic telemetry.":ʄ=bool.Parse(Ҍ);break;case"Show Decel Percentages (comma seperated)."
:ʃ.Clear();string[]Ҋ=Ҍ.Split(',');foreach(string Ĥ in Ҋ){ʃ.Add(double.Parse(Ĥ)/100);}break;case"Fusion Fuel count":ϭ[0].Ѝ
=int.Parse(Ҍ);break;case"Fuel tank count":ϭ[1].Ѝ=int.Parse(Ҍ);break;case"Jerry can count":ϭ[2].Ѝ=int.Parse(Ҍ);break;case
"40mm PDC Magazine count":ϭ[3].Ѝ=int.Parse(Ҍ);break;case"40mm Teflon Tungsten PDC Magazine count":ϭ[4].Ѝ=int.Parse(Ҍ);break;case
"220mm Torpedo count":case"Torpedo count":ϭ[5].Ѝ=int.Parse(Ҍ);break;case"220mm MCRN torpedo count":ϭ[6].Ѝ=int.Parse(Ҍ);break;case
"220mm UNN torpedo count":ϭ[7].Ѝ=int.Parse(Ҍ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":ϭ[8].Ѝ=int.Parse(Ҍ);break;case
"Large ramshacke torpedo count":ϭ[9].Ѝ=int.Parse(Ҍ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":ϭ[10].Ѝ=int.Parse(Ҍ);break;
case"Dawson 100mm UNN Railgun rounds count":ϭ[11].Ѝ=int.Parse(Ҍ);break;case"Stiletto 100mm MCRN Railgun rounds count":ϭ[12].
Ѝ=int.Parse(Ҍ);break;case"T-47 80mm Railgun rounds count":ϭ[13].Ѝ=int.Parse(Ҍ);break;case
"Foehammer 120mm MCRN rounds count":ϭ[14].Ѝ=int.Parse(Ҍ);break;case"Farren 120mm UNN Railgun rounds count":ϭ[15].Ѝ=int.Parse(Ҍ);break;case
"Kess 180mm rounds count":ϭ[16].Ѝ=int.Parse(Ҍ);break;case"Steel plate count":ϭ[17].Ѝ=int.Parse(Ҍ);break;case
"Doors open timer (x100 ticks, default 3)":ʴ=int.Parse(Ҍ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ʳ=int.Parse(Ҍ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":ɾ=int.Parse(Ҍ);break;case"Full refresh frequency (x100 ticks, default 50)":ʍ=int.Parse(Ҍ);break;case
"Verbose script debugging. Prints more logging info to PB details.":ʀ=bool.Parse(Ҍ);break;case"Private spawn (don't inject faction tag into SK custom data).":ʷ=bool.Parse(Ҍ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":ʶ=string.Join("\n",Ҍ.Split(','));break;case"Current Stance":đ=Ҍ;Í Ѹ;if(!Ѩ.TryGetValue(đ,out Ѹ)){đ="N/A";Đ=null;}else Đ=
Ѹ;break;case"Reactor Integrity":G=float.Parse(Ҍ);break;case"Battery Integrity":m=float.Parse(Ҍ);break;case"PDC Integrity"
:Ë=int.Parse(Ҍ);break;case"Torpedo Integrity":ȉ=int.Parse(Ҍ);break;case"Railgun Integrity":Y=int.Parse(Ҍ);break;case
"H2 Tank Integrity":Õ=double.Parse(Ҍ);break;case"O2 Tank Integrity":ê=double.Parse(Ҍ);break;case"Epstein Integrity":ã=float.Parse(Ҍ);break;
case"RCS Integrity":Ȅ=float.Parse(Ҍ);break;case"Gyro Integrity":Ҧ=int.Parse(Ҍ);break;case"Cargo Integrity":ʣ=double.Parse(Ҍ)
;break;case"Welder Integrity":ƥ=int.Parse(Ҍ);break;}}}}catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);
}try{string[]ҁ=ҍ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(ʀ)Echo("Parsing "+(ҁ.Length-1)+" stances");int
Ҁ=24;Dictionary<string,Í>ʔ=new Dictionary<string,Í>();int[]ѿ=new int[]{0,5,25,50,75,100};for(int Ě=1;Ě<ҁ.Length;Ě++){
string[]Ѳ=ҁ[Ě].Split('=');string ʑ="";int[]ѥ=new int[Ҁ];ʑ=Ѳ[0].Split(' ')[0];if(ʀ)Echo("Parsing '"+ʑ+"'");for(int Ѥ=0;Ѥ<ѥ.
Length;Ѥ++){string[]ѣ=Ѳ[(Ѥ+1)].Split('\n');ѥ[Ѥ]=int.Parse(ѣ[0]);}Í Ø=new Í();if(ѥ[0]==0)Ø.Ā=Ơ.Off;else Ø.Ā=Ơ.On;if(ѥ[1]==0)Ø.þ
=ǒ.Off;else if(ѥ[1]==1)Ø.þ=ǒ.MinDefence;else if(ѥ[1]==2)Ø.þ=ǒ.AllDefence;else if(ѥ[1]==3)Ø.þ=ǒ.Offence;else if(ѥ[1]==4)Ø.
þ=ǒ.AllOnOnly;if(ѥ[2]==0)Ø.ý=Ǒ.Off;else if(ѥ[2]==1)Ø.ý=Ǒ.HoldFire;else if(ѥ[2]==2)Ø.ý=Ǒ.OpenFire;if(ѥ[3]==0)Ø.ü=Ǔ.Off;
else if(ѥ[3]==1)Ø.ü=Ǔ.On;else if(ѥ[3]==2)Ø.ü=Ǔ.Minimum;if(ѥ[4]==0)Ø.û=Ǖ.Off;else if(ѥ[4]==1)Ø.û=Ǖ.On;else if(ѥ[4]==2)Ø.û=Ǖ.
ForwardOff;else if(ѥ[4]==3)Ø.û=Ǖ.ReverseOff;if(ѥ[5]==0)Ø.ú=ǔ.Off;else if(ѥ[5]==1)Ø.ú=ǔ.On;else if(ѥ[5]==2)Ø.ú=ǔ.OnMax;if(ѥ[6]==0)Ø
.ù=ǁ.Off;else Ø.ù=ǁ.On;Ø.ø=new Color(ѥ[7],ѥ[8],ѥ[9],ѥ[10]);if(ѥ[11]==0)Ø.ö=ǁ.Off;else Ø.ö=ǁ.On;Ø.õ=new Color(ѥ[12],ѥ[13],
ѥ[14],ѥ[15]);if(ѥ[16]==0)Ø.ò=ǐ.Auto;else if(ѥ[16]==1)Ø.ò=ǐ.StockpileRecharge;else if(ѥ[16]==2)Ø.ò=ǐ.Discharge;if(ѥ[17]==0
)Ø.ð=Ơ.Off;else Ø.ð=Ơ.On;Ø.ñ=ѿ[ѥ[18]];if(ѥ[19]==0)Ø.ï=ƿ.NoChange;else Ø.ï=ƿ.Abort;if(ѥ[20]==0)Ø.ÿ=Ơ.Off;else Ø.ÿ=Ơ.On;if(
ѥ[21]==0)Ø.ā=ƾ.Off;else if(ѥ[21]==1)Ø.ā=ƾ.On;else if(ѥ[21]==2)Ø.ā=ƾ.FillWhenLow;else if(ѥ[21]==3)Ø.ā=ƾ.KeepFull;if(ѥ[22]
==0)Ø.Ē=Ơ.Off;else Ø.Ē=Ơ.On;if(ѥ[23]==0)Ø.ē=ƽ.Closed;else if(ѥ[23]==1)Ø.ē=ƽ.Open;else Ø.ē=ƽ.NoChange;ʔ.Add(ʑ,Ø);}if(ʔ.
Count>=1){if(ʀ)Echo("Finished parsing "+ʔ.Count+" stances.");Ѩ=ʔ;}else{Echo("Didn't find any stances!");}}catch(Exception ex)
{Echo("Custom Data Error (stances)\n"+ex.Message);}}void Ѣ(){bool ѡ=ʝ();if(!ѡ){Ѧ();ѷ();}if(Đ==null){Đ=Ѩ.First().Value;}
string Ѡ="";string џ="";if(!ʷ){Ѡ=" ".PadRight(129,' ')+Ρ+"\n";џ="\n".PadRight(19,'\n');}Π=Ѡ+џ;Ο=Ѡ+string.Join("\n",ʶ.Split(','
))+џ;if(ʏ==""){if(ʀ)Echo("No ship name, trying to pull it from PB name...");string ў="Untitled Ship";try{string[]ѝ=Me.
CustomName.Split(ʊ);if(ѝ.Length>1){ʏ=ѝ[0];if(ʀ)Echo(ʏ);}else ʏ=ў;}catch{ʏ=ў;}}}void ќ(bool Ú=true,bool ћ=false,bool ˎ=false){MyIni
ə=new MyIni();string ɍ=Me.CustomData;MyIniParseResult Ƈ;if(!ə.TryParse(ɍ,out Ƈ)){Ш.Add(new ѐ("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ɚ,ȳ;if(Ú){ɚ="RSM.Stance";ȳ="CurrentStance";ə.Set(ɚ,ȳ,đ);}else{ɚ="RSM.System";ȳ="ShipName";ə.Set(ɚ,ȳ,
ʏ);}if(ћ){ɚ="RSM.InitSubSystems";ə.Set(ɚ,"Reactors",G);ə.Set(ɚ,"Batteries",G);ə.Set(ɚ,"Pdcs",Ë);ə.Set(ɚ,"TorpLaunchers",ȉ
);ə.Set(ɚ,"KineticWeapons",Y);ə.Set(ɚ,"H2Storage",Õ);ə.Set(ɚ,"O2Storage",ê);ə.Set(ɚ,"MainThrust",ã);ə.Set(ɚ,"RCSThrust",Ȅ
);ə.Set(ɚ,"Gyros",Ҧ);ə.Set(ɚ,"CargoStorage",ʣ);ə.Set(ɚ,"Welders",ƥ);}if(ˎ){ɚ="RSM.InitItems";foreach(ğ ʕ in ϭ){ȳ=ʕ.ϳ.
SubtypeId;ə.Set(ɚ,ȳ,ʕ.Ѝ);}}Me.CustomData=ə.ToString();}string ѱ(Type Ѱ){string ѯ="";foreach(var Ğ in Enum.GetValues(Ѱ)){if(ѯ!="")
ѯ+=", ";ѯ+=Ğ.ToString();}return ѯ;}string Ѯ(Color ş){return ş.R+", "+ş.G+", "+ş.B+", "+ş.A;}void ѭ(Exception Ѭ,string ѫ){
Runtime.UpdateFrequency=UpdateFrequency.None;string Ѫ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ѫ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(Ѫ);List<IMyTextPanel>ѩ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ѩ,ɇ=>ɇ.CustomName
.Contains(ʱ));foreach(IMyTextPanel Ş in ѩ){Ş.WriteText(Ѫ);Ş.FontColor=new Color(193,0,197,255);}throw Ѭ;}Dictionary<
string,Í>Ѩ=new Dictionary<string,Í>();void Ѧ(){Ѩ=new Dictionary<string,Í>{{"Cruise",new Í{Ā=Ơ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü
=Ǔ.EpsteinOnly,û=Ǖ.ForwardOff,ú=ǔ.Off,ù=ǁ.On,ø=new Color(33,144,255,255),ö=ǁ.On,õ=new Color(255,214,170,255),ô=ǁ.On,ó=new
Color(33,144,255,255),ò=ǐ.Auto,ñ=50,ð=Ơ.NoChange,ï=ƿ.Abort,ÿ=Ơ.NoChange,ā=ƾ.KeepFull,Ē=Ơ.On,ē=ƽ.NoChange,}},{"StealthCruise",
new Í{Þ="Cruise",Ā=Ơ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü=Ǔ.Minimum,û=Ǖ.ForwardOff,ú=ǔ.Off,ù=ǁ.Off,ø=new Color(0,0,0,255),ö=ǁ.
On,õ=new Color(23,73,186,255),ô=ǁ.Off,ó=new Color(23,73,186,255),ò=ǐ.Auto,ñ=5,ð=Ơ.Off,ï=ƿ.Abort,ÿ=Ơ.NoChange,ā=ƾ.KeepFull,
Ē=Ơ.On,ē=ƽ.NoChange}},{"Docked",new Í{Þ="Cruise",Ā=Ơ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü=Ǔ.Off,û=Ǖ.Off,ú=ǔ.Off,ù=ǁ.On,ø=new
Color(33,144,255,255),ö=ǁ.On,õ=new Color(255,240,225,255),ô=ǁ.On,ó=new Color(255,255,255,255),ò=ǐ.StockpileRecharge,ñ=-1,ð=Ơ.
NoChange,ï=ƿ.Abort,ÿ=Ơ.Off,ā=ƾ.On,Ē=Ơ.On,ē=ƽ.NoChange}},{"Docking",new Í{Þ="Docked",Ā=Ơ.On,þ=ǒ.AllDefence,ý=Ǒ.HoldFire,ü=Ǔ.Off,û
=Ǖ.On,ú=ǔ.OnMax,ù=ǁ.On,ø=new Color(33,144,255,255),ö=ǁ.On,õ=new Color(212,170,83,255),ô=ǁ.On,ó=new Color(212,170,83,255),
ò=ǐ.Auto,ñ=-1,ð=Ơ.NoChange,ï=ƿ.Abort,ÿ=Ơ.Off,ā=ƾ.KeepFull,Ē=Ơ.On,ē=ƽ.NoChange}},{"NoAttack",new Í{Þ="Docked",Ā=Ơ.Off,þ=ǒ.
Off,ý=Ǒ.Off,ü=Ǔ.On,û=Ǖ.On,ú=ǔ.Off,ù=ǁ.On,ø=new Color(255,255,255,255),ö=ǁ.On,õ=new Color(84,157,82,255),ô=ǁ.NoChange,ó=new
Color(84,157,82,255),ò=ǐ.NoChange,ñ=-1,ð=Ơ.NoChange,ï=ƿ.NoChange,ÿ=Ơ.NoChange,ā=ƾ.KeepFull,Ē=Ơ.On,ē=ƽ.NoChange}},{"Combat",
new Í{Þ="Cruise",Ā=Ơ.On,þ=ǒ.AllDefence,ý=Ǒ.OpenFire,ü=Ǔ.On,û=Ǖ.On,ú=ǔ.Off,ù=ǁ.Off,ø=new Color(0,0,0,255),ö=ǁ.On,õ=new Color
(210,98,17,255),ô=ǁ.Off,ó=new Color(210,98,17,255),ò=ǐ.ManagedDischarge,ñ=100,ð=Ơ.On,ï=ƿ.Abort,ÿ=Ơ.On,ā=ƾ.KeepFull,Ē=Ơ.On
,ē=ƽ.NoChange}},{"CQB",new Í{Þ="Combat",Ā=Ơ.On,þ=ǒ.Offence,ý=Ǒ.OpenFire,ü=Ǔ.On,û=Ǖ.On,ú=ǔ.Off,ù=ǁ.Off,ø=new Color(0,0,0,
255),ö=ǁ.On,õ=new Color(243,18,18,255),ô=ǁ.Off,ó=new Color(243,18,18,255),ò=ǐ.ManagedDischarge,ñ=100,ð=Ơ.On,ï=ƿ.Abort,ÿ=Ơ.
On,ā=ƾ.KeepFull,Ē=Ơ.On,ē=ƽ.NoChange}},{"WeaponsHot",new Í{Þ="CQB",Ā=Ơ.On,þ=ǒ.Offence,ý=Ǒ.OpenFire,ü=Ǔ.NoChange,û=Ǖ.
NoChange,ú=ǔ.NoChange,ù=ǁ.NoChange,ø=new Color(0,0,0,255),ö=ǁ.NoChange,õ=new Color(243,18,18,255),ô=ǁ.NoChange,ó=new Color(243,
18,18,255),ò=ǐ.ManagedDischarge,ñ=-1,ð=Ơ.NoChange,ï=ƿ.NoChange,ÿ=Ơ.NoChange,ā=ƾ.KeepFull,Ē=Ơ.On,ē=ƽ.NoChange}}};}class ѧ{
public IMyDoor ɐ;public int һ=0;public int ҹ=0;public bool Ҹ=false;public bool ҷ=false;}class Ҷ{public string ҵ;public bool Ҵ=
false;public int ҳ=0;public bool Ҳ=false;public List<ѧ>ұ=new List<ѧ>();public List<IMyAirVent>Ұ=new List<IMyAirVent>();}int ү
=0;int Ү=0;int ҭ=0;bool Ҭ(ѧ Ҟ){bool Һ=false;if(Ҟ.ɐ==null)return false;bool ĳ=Ҟ.ɐ.OpenRatio>0;ү++;if(ҫ(Ҟ.ɐ))ҭ++;if(ĳ){Ҟ.ɐ.
Enabled=true;if(ʀ&&Ҟ.һ==0)Echo("Door just opened... ("+Ҟ.ɐ.CustomName+")");Ҟ.һ++;if(Ҟ.һ>=ʴ){Ҟ.һ=0;Ҟ.ɐ.CloseDoor();Һ=true;}}else
{Ү++;}return Һ;}void Ҽ(){if(!ʵ){if(ʀ)Echo("Door management is disabled.");return;}foreach(Ҷ ɡ in υ){foreach(ѧ Ҟ in ɡ.ұ){
if(Ҟ.ɐ==null)continue;bool Һ=Ҭ(Ҟ);if(Һ){if(ʀ)Echo("Airlock door "+Ҟ.ɐ.CustomName+" just closed");if(ɡ.Ҳ)ɡ.Ҳ=false;else{ɡ.Ҵ
=true;Ҟ.ҷ=true;if(ʀ)Echo("Airlock "+ɡ.ҵ+" needs to cycle");}}}if(ɡ.Ҵ){foreach(ѧ Ҟ in ɡ.ұ){if(Ҟ.ɐ==null)continue;if(Ҟ.ɐ.
OpenRatio>0)Ҟ.ɐ.CloseDoor();else Ҟ.ɐ.Enabled=false;}bool ӆ=false;foreach(IMyAirVent Ӆ in ɡ.Ұ){if(Ӆ==null)continue;if(!Ӆ.Enabled)Ӆ
.Enabled=true;if(!Ӆ.Depressurize)Ӆ.Depressurize=true;if(Ӆ.CanPressurize&&Ӆ.GetOxygenLevel()<.01&&ɡ.Ҵ)ӆ=true;}ɡ.ҳ++;bool ӄ
=true;if(ɡ.ҳ>=ʳ){ӄ=false;ӆ=true;}if(ӆ){ɡ.Ҵ=false;ɡ.ҳ=0;ɡ.Ҳ=true;foreach(ѧ Ҟ in ɡ.ұ){if(Ҟ.ɐ==null)continue;Ҟ.ɐ.Enabled=
true;if(Ҟ.ҷ)Ҟ.ҷ=false;else if(ӄ)Ҟ.ɐ.OpenDoor();}}}}}void Ӈ(){if(!ʵ){if(ʀ)Echo("Door management is disabled.");return;}ү=0;Ү=
0;ҭ=0;foreach(ѧ Ҟ in φ)Ҭ(Ҟ);}void ӂ(ƽ I){if(I==ƽ.NoChange)return;foreach(IMyAirtightHangarDoor Ӂ in Ϡ){if(Ӂ==null)
continue;if(I==ƽ.Closed)Ӂ.CloseDoor();else Ӂ.OpenDoor();}}void Ӏ(string ҿ,string Ҿ){ҿ=ҿ.ToLower();foreach(ѧ Ҟ in φ){if(Ҿ==""||Ҟ.
ɐ.CustomName.Contains(Ҿ)){bool ҽ=ҫ(Ҟ.ɐ);if(ҽ&&(ҿ=="locked"||ҿ=="toggle"))Ҟ.ɐ.ApplyAction("AnyoneCanUse");if(!ҽ&&(ҿ==
"unlocked"||ҿ=="toggle"))Ҟ.ɐ.ApplyAction("AnyoneCanUse");}}}bool ҫ(IMyDoor Ҟ){var Ɲ=Ҟ.GetActionWithName("AnyoneCanUse");
StringBuilder ҝ=new StringBuilder();Ɲ.WriteValue(Ҟ,ҝ);return(ҝ.ToString()=="On");}double Ҝ;int қ=0;int Қ=8;int ҙ=10;double Ҙ=3;double
җ=245000;double Җ=50000;double ҕ=100;void Ҕ(ƾ I){foreach(IMyTerminalBlock ғ in ϟ){if(ғ==null)continue;if(I==ƾ.Off)ғ.
ApplyAction("OnOff_Off");else ғ.ApplyAction("OnOff_On");}}void Ғ(){if(ϟ.Count<1&&Ϟ.Count>1)Ҝ=(Ҙ*Җ);else Ҝ=(Ҙ*җ);}void ґ(){if(Đ.ā==ƾ
.Off||Đ.ā==ƾ.On){if(ʀ)Echo("Extractor management disabled.");}else if(қ>0){қ--;if(ʀ)Echo("waiting ("+қ+")...");}else if(Ϙ
.Count<1){if(ʀ)Echo("No tanks!");}else if(Đ.ā==ƾ.FillWhenLow&&ҕ<ҙ){if(ʀ)Echo("Fuel low! ("+ҕ+"% / "+ҙ+"%)");Ά=true;Ґ();}
else if(Đ.ā==ƾ.KeepFull&&Ô<(Ö-Ҝ)){Ά=true;Ґ();if(ʀ)Echo("Fuel ready for top up ("+Ô+" < "+(Ö-Ҝ)+")");}else if(ʀ){Echo(
"Fuel level OK ("+ҕ+"%).");if(Đ.ā==ƾ.KeepFull)Echo("Keeping tanks full\n("+Ô+" < "+(Ö-Ҝ)+")");}}void Ґ(){string Ɖ="";int ҟ=8;if(ҕ<5){ҟ=0;
if(Қ!=ҟ)Ɖ="v fast";}else if(ҕ<10){ҟ=2;if(Қ!=ҟ)Ɖ="fast";}else if(ҕ<60){ҟ=4;if(Қ!=ҟ)Ɖ="medium";}else if(Қ!=ҟ)Ɖ="slow";if(Ɖ!=
""){Қ=ҟ;Ш.Add(new ѐ("Extractor loading "+Ɖ,"Extractor load speed has been set to "+Ɖ+" automatically)",0));}}void ҩ(){Ά=
false;IMyTerminalBlock Ҫ=null;int ğ=1;foreach(IMyTerminalBlock ғ in ϟ){if(ғ.IsFunctional){Ҫ=ғ;break;}}if(Ҫ==null){foreach(
IMyTerminalBlock ғ in Ϟ){if(ғ.IsFunctional){Ҫ=ғ;ğ=2;break;}}if(Ҫ==null){if(ʀ)Echo("No functional extractor to load!");Ε=true;return;}}Ε=
false;if(ϭ[ğ].Ў<1){Ζ=ϭ[ğ].ϰ;return;}Ζ="";қ=Қ;Г ϑ=new Г();ϑ.ɐ=Ҫ;ϑ.ϑ=Ҫ.GetInventory();Ҫ.ApplyAction("OnOff_On");List<Г>Ҩ=new
List<Г>();Ҩ.Add(ϑ);if(ʀ)Echo("Attempting to load extractor "+Ҫ.CustomName);bool ʜ=ч(ϭ[ğ].Ϫ,Ҩ,ϭ[ğ].ϳ);string ҧ="fuel tank";if
(ğ==2)ҧ="jerry can";if(ʜ)Ш.Add(new ѐ("Loaded a "+ҧ,"Sucessfully loaded a "+ҧ+" into an extractor.",0));}double Ҧ=0;int ҥ=
0;double Ҥ=0;void ң(bool º,bool Ŧ){ҥ=0;foreach(IMyGyro Ң in ϝ){if(Ң!=null&&Ң.IsFunctional){ҥ++;if(Ŧ)Ң.Enabled=º;}}Ҥ=Math.
Round(100*(ҥ/Ҧ));}void ҡ(string Ҡ,bool ʿ=true,bool ˏ=true,bool ˎ=true){if(ʀ)Echo("Initialising a ship as '"+Ҡ+"'...");Ί=true;
ʏ=Ҡ;Ι=ʿ;Λ=ˏ;Κ=ˎ;Ћ();}void Ћ(){switch(Ώ){case 0:ˀ();ΐ=0;if(ɿ)Echo("Took "+Ͷ());break;case 1:Ϸ();if(ɿ)Echo("Took "+Ͷ());
break;case 2:if(ʀ)Echo("Initialising lcds...");ƃ();if(Λ){if(ʀ)Echo("Initialising subsystem values...");ȃ();ȏ();K();N();Ñ();ç(
);ʬ();Ë=ζ.Count+ε.Count;ȉ=γ.Count;Y=δ.Count;Ҧ=ϝ.Count;ƥ=Ψ.Count;}if(Κ){if(ʀ)Echo("Initialising item values...");ϵ();}if(Ι
){if(ʀ)Echo("Initialising block names...");І();}ќ(false,Λ,Κ);Ш.Add(new ѐ("Init:"+ʏ,"Initialised '"+ʏ+"'\nGood Hunting!",3
));Ώ=0;Ί=false;if(ɿ)Echo("Took "+Ͷ());return;}Ώ++;}class Њ{public int Љ=0;public int Ј=0;public int Ї=0;}void І(){
Dictionary<string,Њ>Ѕ=new Dictionary<string,Њ>();if(ʇ.Count>0){foreach(string R in ʇ){if(ʀ)Echo("Numbering "+R);Ѕ.Add(R,new Њ());}
foreach(var Ђ in τ){Њ Є;if(Ѕ.TryGetValue(Ђ.Value,out Є)){Ѕ[Ђ.Value].Ј++;}}foreach(var Ѓ in Ѕ){if(Ѓ.Value.Ј<10)Ѓ.Value.Ї=1;else
if(Ѓ.Value.Ј>99)Ѓ.Value.Ї=3;else Ѓ.Value.Ї=2;}}foreach(var Ђ in τ){string Ё="";string Ѐ=Ђ.Value;Њ Ͽ;if(Ѕ.TryGetValue(Ђ.
Value,out Ͽ)){if(Ͽ.Ј>1){Ͽ.Љ++;Ё=ʊ+Ͽ.Љ.ToString().PadLeft(Ͽ.Ї,'0');}}Ђ.Key.CustomName=ʏ+ʊ+Ѐ+Ё+Ќ(Ђ.Key.CustomName,Ѐ);}}string Ќ
(string ȳ,string И=""){try{string[]Й=ȳ.Split(ʊ);string[]З=И.Split(ʊ);string Ƈ="";if(Й.Length<3)return"";for(int Ě=2;Ě<Й.
Length;Ě++){int Ж=0;bool Е=int.TryParse(Й[Ě],out Ж);if(Е)Й[Ě]="";foreach(string Д in З){if(Д==Й[Ě])Й[Ě]="";}if(Й[Ě]!="")Ƈ+=ʊ+Й
[Ě];}return Ƈ;}catch{return"";}}class Г{public IMyTerminalBlock ɐ{get;set;}public IMyInventory ϑ{get;set;}List<
MyInventoryItem>В=new List<MyInventoryItem>();public int Б=0;public bool А=false;public float Џ;}class ğ{public int Ў=0;public int Ѝ=0;
public int Ͼ=0;public double Ͻ;public List<Г>Ϫ=new List<Г>();public List<Г>ϴ=new List<Г>();public MyItemType ϳ;public bool ϲ=
false;public bool ϱ=false;public string ϰ;public string ϯ;public double Ϯ=1;}List<ğ>ϭ=new List<ğ>();void Ϭ(IMyTerminalBlock ɇ
,int ʕ=99){if(ʕ==99){foreach(var ğ in ϭ){Г ϑ=new Г();ϑ.ɐ=ɇ;ϑ.ϑ=ɇ.GetInventory();ğ.Ϫ.Add(ϑ);}}else{Г ϑ=new Г();ϑ.ɐ=ɇ;ϑ.ϑ=ɇ
.GetInventory();ϑ.А=ʻ;if(ʕ==0&&!ʺ)ϑ.А=false;ϭ[ʕ].Ϫ.Add(ϑ);}}void ϫ(IMyTerminalBlock ɇ,int ʕ){Г ϑ=new Г();ϑ.ɐ=ɇ;ϑ.ϑ=ɇ.
GetInventory();ϑ.А=ʻ;if(ʕ!=99)ϭ[ʕ].ϴ.Add(ϑ);}void ϼ(string ϰ,string ϻ,string Ϻ,bool ϱ=false,bool ϲ=false){ğ ğ=new ğ();ğ.ϳ=new
MyItemType(ϻ,Ϻ);ğ.ϱ=ϱ;ğ.ϲ=ϲ;ğ.ϰ=ϰ;string ϯ;if(ϰ.Length>9)ϯ=ϰ.Substring(0,9);else ϯ=ϰ.PadRight(9);ğ.ϯ=ϯ;ϭ.Add(ğ);}void Ϲ(){try{ϼ(
"Fusion Fuel","MyObjectBuilder_Ingot","FusionFuel",true);ϼ("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");ϼ("Jerry Can",
"MyObjectBuilder_Component","SG_Fuel_Tank");ϼ("PDC","MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine",true);ϼ("PDC Tefl",
"MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);ϼ("220 Torp ","MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",
true,true);ϼ("220 MCRN","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true,true);ϼ("220 UNN",
"MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);ϼ("RS Torp","MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);
ϼ("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",true,true);ϼ("120mm RG",
"MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);ϼ("Dawson","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true
);ϼ("Stiletto","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugMCRNMagazine",true);ϼ("80mm",
"MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);ϼ("Foehammr","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugMCRNMagazine",true);ϼ("Farren","MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugUNNMagazine",true);ϼ("Kess",
"MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);ϼ("Steel Pla","MyObjectBuilder_Component","SteelPlate");ϭ[0].Ϯ=ʁ;}catch(Exception
ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void ϸ(){foreach(var ğ in ϭ){ğ.ϴ.Clear();}}void Ϸ(){
foreach(var ğ in ϭ){ğ.Ў=0;ğ.Ͼ=0;List<Г>ˑ=ğ.Ϫ.Concat(ğ.ϴ).ToList();foreach(Г ϑ in ˑ){ϑ.Б=ϑ.ϑ.GetItemAmount(ğ.ϳ).ToIntSafe();ğ.Ў
+=ϑ.Б;if(ϑ.А){ϑ.Џ=ϑ.ϑ.VolumeFillFactor;}else{ğ.Ͼ+=ϑ.Б;}}if(ʀ)Echo("Item "+ğ.ϰ+"\nActualQty="+ğ.Ў+"\nSpareQty="+ğ.Ͼ);}}void
ϵ(){foreach(ğ ğ in ϭ){ğ.Ѝ=ğ.Ў;}}int К(string Ǻ){switch(Ǻ){case"220mm Explosive Torpedo":return 5;case
"MCRN Torpedo High Spread":case"MCRN Torpedo Low Spread":return 6;case"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case
"40mm Tungsten-Teflon Ammo":return 4;case"40mm Lead-Steel PDC Box Ammo":return 4;case"Ramshackle Torpedo Magazine":return 8;case
"120mm Lead-Steel Slug Ammo":return 10;case"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case
"80mm Tungsten-Uranium Sabot Ammo":return 13;case"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;
case"180mm Lead-Steel Sabot Ammo":return 16;default:if(ʀ)Echo("Unknown AmmoType = "+Ǻ);return 99;}}bool ъ(IMyTerminalBlock ɐ
){IMyInventory ш=ɐ.GetInventory();return ш.VolumeFillFactor==0;}bool ч(List<Г>ˡ,List<Г>ϗ,MyItemType ϳ,int ц=-1,double х=1
,double ф=1){if(ʀ)Echo("Loading "+ϗ.Count+" inventories from "+ˡ.Count+" sources.");bool q=false;bool у=ф<1;foreach(Г т
in ϗ){int с=3;foreach(Г р in ˡ){if(с<0)break;if(ц!=-1&&т.Б>=(ц*.95))break;if(!т.ϑ.IsConnectedTo(р.ϑ))continue;List<
MyInventoryItem>п=new List<MyInventoryItem>();р.ϑ.GetItems(п);foreach(MyInventoryItem щ in п){if(щ.Type==ϳ){int Б=щ.Amount.ToIntSafe();
if(Б==0&&!у)break;с--;if(у){с=-1;try{Б=р.Б-Convert.ToInt32(р.Б/р.Џ*ф);if(ʀ)Echo("Unload "+Б+"\n"+р.Б+"\n"+Convert.ToInt32(
р.Б/р.Џ*ф));}catch(Exception ex){if(ʀ)Echo("Int conversion error at unload\n"+ex.Message);Б=1;}}else if(х<1){try{int љ=
Convert.ToInt32(т.Б/т.Џ*х)-т.Б;if(љ<Б)Б=љ;}catch(Exception ex){if(ʀ)Echo("Int conversion error at load\n"+ex.Message);Б=1;}}
else if(ц!=-1){if(Б<=ц){break;}Б=ц-т.Б;}q=т.ϑ.TransferItemFrom(р.ϑ,щ,Б);if(q)с=-1;if(у&&q)return(q);break;}}}}return q;}
class њ{public IMyTextPanel ɐ;public bool ј=true;public bool ї=false;public bool і=false;public bool ѕ=true;public bool є=
true;public bool ѓ=true;public bool ђ=false;public bool ё=false;}class ѐ{public string я,ю;public int э,ь;public ѐ(string ы,
string о,int н=0,int Л=20){if(ы.Length>Р-3)ы=ы.Substring(0,Р-3);я=ы.PadRight(Р-3);ю=о;э=н;ь=Л;}}List<ѐ>Ш=new List<ѐ>();class Ч
{public string Ц,Х;public Ч(string R,int Ф,int У){string Т="    ";while(У>3){У-=4;}if(Ф==0){Ц="║ "+R.PadRight(4)+" ║";Х=
"  "+Т+"  ";}else if(Ф==1){if(У==0||У==2)Ц="║─"+R.PadRight(4)+" ║";else Ц="║ "+R.PadRight(4)+"─║";Х=" ░"+Т+"░ ";}else if(Ф==
2){if(У==0||У==2){Ц="║ "+R.PadRight(4)+"═║";Х="║▒"+Т+"░║";}else{Ц="║═"+R.PadRight(4)+" ║";Х="║░"+Т+"▒║";}}else if(Ф==3){
if(У==0||У==2){Ц="║!"+R.PadRight(4)+"!║";Х="║▓"+Т+"▓║";}else{Ц="║ "+Т+" ║";Х="║!"+R.PadRight(4)+"!║";}}}}Color С=new Color
(255,116,33,255);const int Р=32;int П=0;string[]О=new string[]{"▄ "," ▄"," ▀","▀ "},Н=new string[]{"─","\\","│","/"},М=
new string[]{"- ","= ","x ","! "};string Щ,Ъ,л,м,к="\n\n",й,и="╔══════╗",з="╚══════╝",ж,е,д,г,в,б,а,Я,Ю,Э,Ь,Ы,ʐ,Ɂ,ß,Ň,ņ,Ņ,ń
,Ń,ł;void Ł(){и=и+и+и+и+"\n";з=з+з+з+з+"\n";Щ=Ɛ("Welcome to")+к+Ɛ("R S M")+к;Ъ=Ɛ("Initialising")+к;л=new String(' ',Р-8);
м="└"+new String('─',Р-2)+"┘";ж=new String('-',26)+"\n";й="──"+к;е=ŀ("Inventory");д=ŀ("Thrust");г=ŀ("Power & Tanks");в=ŀ(
"Warnings");б=ŀ("Subsystem Integrity");а=ŀ("Telemetry & Thrust");Я=ľ("Velocity");Ю=ľ("Velocity (Max)");Э=ľ("Mass");Ь=ľ("Max Accel"
);Ы=ľ("Actual Accel");ʐ=ľ("Accel (Best)");Ɂ=ľ("Max Thrust");ß=ľ("Actual Thrust");Ň=ľ("Decel (Dampener)");ņ=ľ(
"Decel (Actual)");Ņ=ļ("Fuel");ń=ļ("Oxygen");Ń=ļ("Battery");ł=ļ("Capacity");}string ŀ(string Ŀ){return"──┤ "+Ŀ+" ├"+new String('─',Р-9-Ŀ.
Length);}string ľ(string Ľ){return Ľ+":"+new String(' ',Р-16-Ľ.Length);}string ļ(string Ļ){return Ļ+new String(' ',Р-22-Ļ.
Length)+"[";}void ĺ(){П++;if(П>=О.Length)П=0;int Ĺ=П+2;if(Ĺ>3)Ĺ-=4;string ň=О[П];string Ŋ=Н[П];string ś=О[Ĺ];string Ŝ=е+Ŋ+й;
string Ś=д+Ŋ+й;string ř=г+Ŋ+й;string Ř=в+Ŋ+й;string ŗ=б+Ŋ+й;string Ŗ=а+Ŋ+й;string ŕ=Ɛ(ʏ.ToUpper())+"\n"+"  "+ň+" "+Ɛ(đ,Р-10)+
" "+ň+"  \n";string Ŕ="\n  "+ś+л+ś+"  "+к;if(Ό){string œ=Щ+Ɛ("Booting"+new string('.',Γ))+к;Ŝ+=œ;Ś+=œ;ř+=œ;Ř+=œ;ŗ+=œ;}else
if(Ί){string Œ=Ъ+Ɛ(ʏ)+к;Ŝ+=Œ;Ś+=Œ;ř+=Œ;Ř+=Œ;ŗ+=Œ;}else{ʤ();double ő=9.81,Ő=Math.Round(Τ),ŏ=Math.Round((å/Σ/ő),2),Ŏ=Math.
Round((ä/Σ/ő),2),ō=Math.Round(G+m,1),Ō=Math.Round(Ã,1),ŋ=Math.Round(100*(ì/ë)),ĸ=Math.Round(100*(A/n)),ķ=Math.Round(100*(Ō/ō)
);string ĕ=Я,Ģ=" Gs",ġ;List<string>Ġ=new List<string>();if(Ő<1){Ő=500;ĕ=Ю;}if(ʂ){ő=1;Ģ=" m/s/s";}for(int Ě=0;Ě<ϭ.Count;Ě
++){if(ϭ[Ě].Ѝ!=0){ϭ[Ě].Ͻ=(100*((double)ϭ[Ě].Ў/(double)ϭ[Ě].Ѝ));string Ğ=(ϭ[Ě].Ў+"/"+ϭ[Ě].Ѝ).PadLeft(9);if(Ğ.Length>9)Ğ=Ğ.
Substring(0,9);Ŝ+=ϭ[Ě].ϯ+" ["+ź(ϭ[Ě].Ͻ)+"] "+Ğ+"\n";if(Ě>2&&ϭ[Ě].Ͼ<1)Ġ.Add(ϭ[Ě].ϰ);}}foreach(ğ ğ in ϭ){if(ğ.Ѝ!=0){ğ.Ͻ=(100*((
double)ğ.Ў/(double)ğ.Ѝ));string Ğ=(ğ.Ў+"/"+ğ.Ѝ).PadLeft(9);if(Ğ.Length>9)Ğ=Ğ.Substring(0,9);Ŝ+=ğ.ϯ+" ["+ź(ğ.Ͻ)+"] "+Ğ+"\n";if(
ğ.Ͼ<1)Ġ.Add(ğ.ϰ);}}Ŝ+="\n";if(ä>0)Ś+=ņ+Ƒ(ä,Ő)+"\n"+Ы+(Ŏ+Ģ).PadLeft(15)+к;else Ś+=Ň+Ƒ(å,Ő,true)+"\n"+ʐ+(ŏ+Ģ).PadLeft(15)+к
;ҕ=Math.Round(100*(Ô/Ö));ř+=Ņ+ź(ҕ)+"] "+(ҕ+" %").PadLeft(9)+"\n"+ń+ź(ŋ)+"] "+(ŋ+" %").PadLeft(9)+"\n"+Ń+ź(ĸ)+"] "+(ĸ+" %"
).PadLeft(9)+"\n"+ł+ź(ķ)+"] "+(ķ+" %").PadLeft(9)+"\n"+"Max Power:"+(Ō+" MW / "+ō+" MW").PadLeft(22)+к;List<ѐ>ĝ=new List<
ѐ>();List<Ч>Ĝ=new List<Ч>();int ě=0;for(int Ě=0;Ě<Ш.Count;Ě++){Ш[Ě].ь--;if(Ш[Ě].ь<1)Ш.RemoveAt(Ě);else ĝ.Add(Ш[Ě]);}if(!Ũ
){ĝ.Add(new ѐ("NO LiDAR!","No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(ͼ){ĝ.
Add(new ѐ("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int ę=0;if(ҕ<5){ġ=
"FUEL CRITICAL!";ĝ.Add(new ѐ(ġ,ġ+"\nFuel Level < 5%!",3));ę=3;}else if(ҕ<25){ġ="FUEL LOW!";ĝ.Add(new ѐ(ġ,ġ+"\nFuel Level < 10%!",2));ę=2
;}if(Đ.ā!=ƾ.Off){if(Ζ!=""){if(ę==0)ę=1;ĝ.Add(new ѐ("NO SPARE "+Ζ.ToUpper()+"!",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",ę));}if(Ε){if(ę==0)ę=1;ĝ.Add(new ѐ("NO EXTRACTOR!","Cannot refuel!\nNo functional extractor!",ę));}}Ĝ.Add(new Ч("FUEL",
ę,П+ě));ě++;int Ę=0;if(ŋ<5){ġ="OXYGEN CRITICAL!";ĝ.Add(new ѐ(ġ,ġ+"\nShip O2 Level < 5%!",3));Ę=3;}else if(ŋ<10){ġ=
"OXYGEN LOW!";ĝ.Add(new ѐ(ġ,ġ+"\nShip O2 Level < 10%!",2));Ę=2;}else if(ŋ<25){ġ="Oxygen Low!";ĝ.Add(new ѐ(ġ,ġ+
"\nShip O2 Level < 25%!",1));Ę=1;}if(ι.Count>ů){int ė=(ι.Count-ů);Ę++;ġ=ė+" vents are unsealed";ĝ.Add(new ѐ(ġ,ġ,1));}if(ҭ>0){ġ=ҭ+
" doors are insecure";ĝ.Add(new ѐ(ġ,ġ,0));}if(Φ>0){ġ=ʯ+" is active ("+Φ+")";ĝ.Add(new ѐ(ġ,ġ,0));}Ĝ.Add(new Ч("OXYG",Ę,П+ě));ě++;int Ė=0;if(Ϥ.
Count>0){if(ĸ<5){Ė+=2;ġ="BATTERIES CRITICAL!";ĝ.Add(new ѐ(ġ,ġ+"\nBattery Level < 5%!",2));}else if(ĸ<10){Ė+=1;ġ=
"Batteries Low!";ĝ.Add(new ѐ(ġ,ġ+"\nBattery Level < 10%!",1));}}if(ϛ.Count>0){if(D>0){Ė+=2;ĝ.Add(new ѐ(D+" REACTORS NEED FUS. FUEL!",
"At least one reactor needs Fusion Fuel!",3));}if(ϭ[0].Ў<1){Ė+=3;ġ="NO FUSION FUEL!";ĝ.Add(new ѐ(ġ,ġ,2));}else if(ϭ[0].Ў<50){Ė+=2;ġ="FUSION FUEL CRITICAL! ("+ϭ[0
].Ў+")";ĝ.Add(new ѐ(ġ,ġ,2));}else if(ϭ[0].Ѝ>0&&ϭ[0].Ͻ<5){Ė+=2;ġ="FUSION FUEL CRITICAL!";ĝ.Add(new ѐ(ġ,ġ,3));}else if(ϭ[0]
.Ѝ>0&&ϭ[0].Ͻ<10){Ė+=1;ġ="Fusion Fuel Level Low!";ĝ.Add(new ѐ(ġ,ġ,2));}}if(Ė>3)Ė=3;Ĝ.Add(new Ч("POWR",Ė,П+ě));ě++;int ģ=0;
if(Ġ.Count>0){foreach(string ĥ in Ġ){string ĵ=ĥ;if(ĥ.Length>23)ĵ=ĥ.Substring(0,23);ĵ=ĵ.ToUpper();ġ="NO SPARE "+ĵ+"!";ĝ.Add
(new ѐ(ġ,ġ,3));}ģ=3;}if(ģ>3)ģ=3;Ĝ.Add(new Ч("WEAP",ģ,П+ě));ě++;if(Ͳ){string Ķ=ͱ;if(ϥ.Count>0)if(ϥ[0]!=null)Ķ=(ϥ[0]as
IMyRadioAntenna).HudText;string Ĵ="";if(Ͱ<1000)Ĵ=Math.Round(Ͱ)+"m";else Ĵ=Math.Round(Ͱ/1000)+"km";ĝ.Add(new ѐ("Comms ("+Ĵ+"): "+Ķ,
"Antenna(s) are broadcasting at a range of "+Ĵ+" with the message "+Ķ,0));}if(Υ>0){ġ=Υ+" UNOWNED BLOCKS!";ĝ.Add(new ѐ(ġ,ġ+"\nRSM detected "+Υ+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ү>Ү){int ĳ=(ү-Ү);ġ=ĳ+" doors are open";ĝ.Add(new ѐ(ġ,ġ,0));}ĝ=ĝ.OrderBy(Ĳ=>Ĳ.э).Reverse().ToList();if(ĝ.Count<1
)Ř+="No warnings\n";else Echo(к+" WARNINGS:");for(int Ě=0;Ě<ĝ.Count;Ě++){Ř+=М[ĝ[Ě].э]+ĝ[Ě].я+"\n";Echo("-"+М[ĝ[Ě].э]+ĝ[Ě]
.ю);}Ř+="\n";string ı=Đ.ü.ToString().ToUpper();if(ı.Length>3)ı=ı.Substring(0,3);string İ=Đ.û.ToString().ToUpper();if(İ.
Length>3)İ=İ.Substring(0,3);string į=Đ.ü.ToString().ToUpper();if(į.Length>3)į=į.Substring(0,3);string Į=Đ.þ.ToString().ToUpper
();if(Į.Length>3)Į=Į.Substring(0,3);string ĭ=Đ.Ā.ToString().ToUpper();if(ĭ.Length>3)ĭ=ĭ.Substring(0,3);string Ĭ=Đ.ý.
ToString().ToUpper();if(Ĭ.Length>3)Ĭ=Ĭ.Substring(0,3);try{if(ã>0)ŗ+="Epstein   ["+ź(â)+"] "+(â+"% ").PadLeft(5)+ı+"\n";if(Ȅ>0)ŗ
+="RCS       ["+ź(ȅ)+"] "+(ȅ+"% ").PadLeft(5)+İ+"\n";if(G>0)ŗ+="Reactors  ["+ź(E)+"] "+(E+"% ").PadLeft(5)+"    \n";if(m>0
)ŗ+="Batteries ["+ź(M)+"] "+(M+"% ").PadLeft(5)+į+"\n";if(Ë>0)ŗ+="PDCs      ["+ź(É)+"] "+(É+"% ").PadLeft(5)+Į+"\n";if(ȉ>
0)ŗ+="Torpedoes ["+ź(ȇ)+"] "+(ȇ+"% ").PadLeft(5)+ĭ+"\n";if(Y>0)ŗ+="Railguns  ["+ź(W)+"] "+(W+"% ").PadLeft(5)+Ĭ+"\n";if(Õ
>0)ŗ+="H2 Tanks  ["+ź(Ó)+"] "+(Ó+"% ").PadLeft(5)+į+"\n";if(ê>0)ŗ+="O2 Tanks  ["+ź(é)+"] "+(é+"% ").PadLeft(5)+į+"\n";if(
Ҧ>0)ŗ+="Gyros     ["+ź(Ҥ)+"] "+(Ҥ+"% ").PadLeft(5)+"    \n";if(ʣ>0)ŗ+="Cargo     ["+ź(ʡ)+"] "+(ʡ+"% ").PadLeft(5)+
"    \n";if(ƥ>0)ŗ+="Welders   ["+ź(ƣ)+"] "+(ƣ+"% ").PadLeft(5)+"    \n";}catch{}if(m+G+Õ==0)ŗ+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+к;string ī="";string Ī="";foreach(Ч ĩ in Ĝ){ī+=ĩ.Ц;Ī+=ĩ.Х;}int Ĩ=П+2;if(Ĩ>3)Ĩ-=4;ŕ+=и+ī+"\n"+з;Ŕ+=Ī;if(!Ξ){Ŗ+=к;}else{
if(ʀ)Echo("Building advanced thrust...");string ħ="";if(ʄ){ħ=Э+(Math.Round((Σ/1000000),2)+" Mkg").PadLeft(15)+"\n"+ĕ+(Ő+
" ms").PadLeft(15)+"\n"+Ь+(ŏ+Ģ).PadLeft(15)+"\n"+Ы+(Ŏ+Ģ).PadLeft(15)+"\n"+Ɂ+((å/1000000)+" MN").PadLeft(15)+"\n"+ß+((ä/
1000000)+" MN").PadLeft(15)+"\n";}Ŗ+=ħ+Ň+Ƒ(å,Ő,true)+"\n"+ņ+Ƒ(ä,Ő)+"\n";foreach(double Ĥ in ʃ){Ŗ+=("Decel ("+(Ĥ*100)+"%):").
PadRight(17)+Ƒ((float)(å*Ĥ),Ő)+"\n";}Ŗ+=к;}}foreach(њ Ħ in Ϊ){string ŝ="";Color ş=Đ.ó;if(Ħ.ј)ŝ+=ŕ;if(Ħ.ї){ŝ+=Ŕ;ş=С;}if(Ħ.і)ŝ+=Ř;
if(Ħ.ѕ)ŝ+=ř;if(Ħ.є)ŝ+=Ŝ;if(Ħ.ѓ)ŝ+=Ś;if(Ħ.ђ)ŝ+=ŗ;if(Ħ.ё){ŝ+=Ŗ;Ξ=true;}Ħ.ɐ.WriteText(ŝ,false);if(!ʅ)Ħ.ɐ.FontColor=ş;}}void ƀ
(){if(Ϋ.Count>0){foreach(IMyTextPanel Ħ in Ϋ){Ħ.FontColor=Đ.ó;}foreach(њ Ħ in Ϊ){Ħ.ɐ.FontColor=Đ.ó;}}}void ſ(string ž,
string Ž){ž=ž.ToLower();List<IMyTextPanel>ż=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ά);
foreach(IMyTextPanel Ħ in ά){if(Ž==""||Ħ.CustomName.Contains(Ž)){string Ż=Ħ.CustomData;if(Ż.Contains("hudlcd")&&(ž=="off"||ž==
"toggle"))Ħ.CustomData=Ż.Replace("hudlcd","hudXlcd");if(Ż.Contains("hudXlcd")&&(ž=="on"||ž=="toggle"))Ħ.CustomData=Ż.Replace(
"hudXlcd","hudlcd");}}}string ź(double Ź){try{int Ÿ=0;if(Ź>0){int ŷ=(int)Ź/10;if(ŷ>10)return new string('=',10);if(ŷ!=0)Ÿ=ŷ;}char
Ŷ=' ';if(Ź<10){if(П==0)return" ><    >< ";if(П==1)return"  ><  ><  ";if(П==2)return"   ><><   ";if(П==3)return
"<   ><   >";}string ŵ=new string('=',Ÿ);string Ɓ=new string(Ŷ,10-Ÿ);return ŵ+Ɓ;}catch{return"# ERROR! #";}}string Ŵ(string Ƃ){
string ƒ;string Ğ="";double Ź=0;switch(Ƃ){case"H2":Ź=Math.Round(100*(Ô/Õ));Ğ=Ź.ToString()+" %";ҕ=Ź;break;case"O2":Ź=Math.Round
(100*(ì/ê));Ğ=Ź.ToString()+" %";break;case"Battery":Ź=Math.Round(100*(A/n));Ğ=Ź.ToString()+" %";break;}ƒ=ź(Ź);return" ["+
ƒ+"] "+Ğ.PadLeft(9);}string Ɛ(string Ə,int Ǝ=Р){int ƍ=Ǝ-Ə.Length;int ƌ=ƍ/2+Ə.Length;return Ə.PadLeft(ƌ).PadRight(Ǝ);}
string Ƒ(double Ƌ,double Ɖ,bool ƈ=false){if(Ƌ<=0)return("N/A").PadLeft(15);if(ƈ)Ƌ=Ƌ*1.5;double Ƈ=0.5*(Math.Pow(Ɖ,2)*(Σ/Ƌ));
double Ɔ=Ɖ/(Ƌ/Σ);string ƅ="m";if(Ƈ>1000){ƅ="km";Ƈ=Ƈ/1000;}return(Math.Round(Ƈ)+ƅ+" "+Math.Round(Ɔ)+"s").PadLeft(15);}void Ƅ(){
foreach(IMyTextPanel Ş in ά){Ş.Enabled=true;}}void ƃ(){foreach(њ Ħ in Ϊ){Ħ.ɐ.Font="Monospace";Ħ.ɐ.ContentType=ContentType.
TEXT_AND_IMAGE;if(Ħ.ɐ.CustomName.Contains("HUD1")){Ħ.ј=true;Ħ.ї=false;Ħ.і=false;Ħ.ѕ=false;Ħ.є=false;Ħ.ѓ=false;Ħ.ђ=false;Ħ.ё=false;Ʉ(Ħ,
"hudlcd:-0.55:0.99:0.7");continue;}if(Ħ.ɐ.CustomName.Contains("HUD2")){Ħ.ј=false;Ħ.ї=false;Ħ.і=true;Ħ.ѕ=false;Ħ.є=false;Ħ.ѓ=false;Ħ.ђ=false;Ħ.ё
=false;Ʉ(Ħ,"hudlcd:0.22:0.99:0.55");continue;}if(Ħ.ɐ.CustomName.Contains("HUD3")){Ħ.ј=false;Ħ.ї=false;Ħ.і=false;Ħ.ѕ=true;
Ħ.є=false;Ħ.ѓ=false;Ħ.ђ=false;Ħ.ё=false;Ʉ(Ħ,"hudlcd:0.48:0.99:0.55");continue;}if(Ħ.ɐ.CustomName.Contains("HUD4")){Ħ.ј=
false;Ħ.ї=false;Ħ.і=false;Ħ.ѕ=false;Ħ.є=false;Ħ.ѓ=false;Ħ.ђ=true;Ħ.ё=false;Ʉ(Ħ,"hudlcd:0.74:0.99:0.55");continue;}if(Ħ.ɐ.
CustomName.Contains("HUD5")){Ħ.ј=false;Ħ.ї=false;Ħ.і=false;Ħ.ѕ=false;Ħ.є=true;Ħ.ѓ=false;Ħ.ђ=false;Ħ.ё=true;Ʉ(Ħ,"hudlcd:0.75:0:.54"
);continue;}if(Ħ.ɐ.CustomName.Contains("HUD6")){Ħ.ј=false;Ħ.ї=true;Ħ.і=false;Ħ.ѕ=false;Ħ.є=false;Ħ.ѓ=false;Ħ.ђ=false;Ħ.ё=
false;Ʉ(Ħ,"hudlcd:-0.55:0.99:0.7");continue;}}bool ũ=false;foreach(IMyTextPanel Ş in ά){if(Ş==null)continue;if(!ũ&&(Ş.
CustomName.Contains(ʌ)||Ş.CustomName.ToUpper().Contains(ʋ))){ũ=true;Ş.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool Ũ;void
ŧ(bool º,bool Ŧ){Ũ=false;foreach(IMyConveyorSorter ť in η){if(ť!=null&&ť.IsFunctional){Ũ=true;if(Ŧ)ť.Enabled=º;}}}void Ť(
ǔ I){if(I==ǔ.NoChange)return;foreach(IMyReflectorLight ţ in ϊ){if(ţ==null)continue;if(I==ǔ.Off)ţ.Enabled=false;else{ţ.
Enabled=false;if(I==ǔ.OnMax)ţ.Radius=9999;}}}void Ţ(ǁ I,Color ş){if(I==ǁ.NoChange)return;foreach(IMyLightingBlock š in Ω){if(š
==null)continue;if(I==ǁ.Off)š.Enabled=false;else š.Enabled=true;if(I!=ǁ.OnNoColourChange)š.SetValue("Color",ş);}}void Š(ǁ
I,Color ş){if(I==ǁ.NoChange)return;foreach(IMyLightingBlock š in θ){if(š==null)continue;if(I==ǁ.Off)š.Enabled=false;else
š.Enabled=true;if(I!=ǁ.OnNoColourChange)š.SetValue("Color",ş);}}Color Ū=new Color(255,0,0,255);Color Ų=new Color(255,0,0,
255);Color ų=new Color(0,255,0,255);void ű(ǁ I){if(I==ǁ.NoChange)return;foreach(IMyLightingBlock š in κ){Ű(š,I,Ų);}foreach(
IMyLightingBlock š in ω){Ű(š,I,ų);}}void Ű(IMyLightingBlock š,ǁ I,Color ş){if(š==null)return;if(I==ǁ.Off){š.Enabled=false;š.SetValue(
"Color",Ū);}else{š.Enabled=true;if(I!=ǁ.OnNoColourChange)š.SetValue("Color",ş);}}int ů=0;void Ů(bool º,bool Ŧ){ů=0;foreach(
IMyAirVent ŭ in ι){if(ŭ!=null){if(Ŧ)ŭ.Enabled=º;if(ŭ.CanPressurize)ů++;}}}void Ŭ(bool º){foreach(IMyShipConnector ū in ϡ){if(ū!=
null)ū.Enabled=º;}}void Ĕ(bool º){foreach(IMyCameraBlock P in ϣ){if(P!=null)P.Enabled=º;}}void À(bool º){foreach(
IMySensorBlock µ in Ϛ){if(µ!=null)µ.Enabled=º;}}void ª(){ͼ=true;foreach(IMyTerminalBlock z in ϙ){z.ApplyAction("OnOff_On");if(z.
IsFunctional)ͼ=false;}}bool y=false;List<string>x=new List<string>();bool w=false;List<string>v=new List<string>();void u(string t,
string s){bool q=false;List<IMyProgrammableBlock>p=new List<IMyProgrammableBlock>();try{if(s=="EFC")p=ή;else if(s=="NavOS")p=έ
;foreach(IMyProgrammableBlock o in ή){if(o==null||!o.Enabled)continue;q=(o as IMyProgrammableBlock).TryRun(t);if(q&&ʀ)
Echo("Ran "+t+" on "+o.CustomName+" successfully.");else Ш.Add(new ѐ(s+" command failed!",s+" command "+t+" failed!",1));if(
s=="EFC")y=true;else if(s=="NavOS")w=true;break;}}catch(Exception ex){Ш.Add(new ѐ(s+" command errored!",s+" command "+t+
" errored!\n"+ex.Message,3));}}void Á(string t,string s){if(s=="EFC"){if(ή.Count<1)return;if(y){x.Add(t);return;}}if(s=="NavOS"){if(έ
.Count<1)return;if(w){v.Add(t);return;}}u(t,s);}void Ì(){if(x.Count>0&&!y){u(x[0],"EFC");x.RemoveAt(0);}if(v.Count>0&&!w)
{u(v[0],"NavOS");v.RemoveAt(0);}y=false;w=false;}int Ë=0;double Ê=0;double É=0;void È(){Ê=0;foreach(IMyTerminalBlock Ä in
ζ){Ç(Ä,Đ.þ!=ǒ.Off&&Đ.þ!=ǒ.MinDefence);}foreach(IMyTerminalBlock Ä in ε){Ç(Ä,Đ.þ!=ǒ.Off);}É=Math.Round(100*(Ê/Ë));}void Ç(
IMyTerminalBlock Æ,bool º){if(Æ!=null&&Æ.IsFunctional){Ê++;(Æ as IMyConveyorSorter).Enabled=º;}}void Å(ǒ I){if(I==ǒ.NoChange)return;
foreach(IMyTerminalBlock Ä in ζ){if(Ä!=null&Ä.IsFunctional){switch(I){case ǒ.Off:case ǒ.MinDefence:(Ä as IMyConveyorSorter).
Enabled=false;break;case ǒ.AllDefence:(Ä as IMyConveyorSorter).Enabled=true;if(ʹ){try{Ä.SetValue("WC_FocusFire",false);Ä.
SetValue("WC_Projectiles",true);Ä.SetValue("WC_Grids",true);Ä.SetValue("WC_LargeGrid",false);Ä.SetValue("WC_SmallGrid",true);Ä.
SetValue("WC_SubSystems",true);Ä.SetValue("WC_Biologicals",true);ʨ(Ä);}catch{Echo("Strange PDC config error! Possible WC crash!"
);}}break;case ǒ.Offence:(Ä as IMyConveyorSorter).Enabled=true;if(ʹ){try{Ä.SetValue("WC_FocusFire",false);Ä.SetValue(
"WC_Projectiles",true);Ä.SetValue("WC_Grids",true);Ä.SetValue("WC_LargeGrid",true);Ä.SetValue("WC_SmallGrid",true);Ä.SetValue(
"WC_SubSystems",true);Ä.SetValue("WC_Biologicals",true);ʨ(Ä);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock Ä in ε){if(Ä!=null&Ä.IsFunctional){switch(I){case ǒ.Off:(Ä as IMyConveyorSorter).Enabled=false;break;
case ǒ.MinDefence:case ǒ.AllDefence:case ǒ.Offence:(Ä as IMyConveyorSorter).Enabled=true;if(ʹ){try{Ä.SetValue("WC_FocusFire"
,false);Ä.SetValue("WC_Projectiles",true);Ä.SetValue("WC_Grids",true);Ä.SetValue("WC_LargeGrid",false);Ä.SetValue(
"WC_SmallGrid",true);Ä.SetValue("WC_SubSystems",true);Ä.SetValue("WC_Biologicals",true);ʩ(Ä);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double Ã;void Â(ǐ I){Ã=0;L(I);C();}double n=0;double m=0;double A=0;double M=0;void L(ǐ I){n=0;A=0;foreach
(IMyBatteryBlock H in Ϥ){if(H!=null&&H.IsFunctional){A+=H.CurrentStoredPower;n+=H.MaxStoredPower;Ã+=H.MaxOutput;H.Enabled
=true;if(I==ǐ.ManagedDischarge){if(V||F>0)H.ChargeMode=ChargeMode.Discharge;else H.ChargeMode=ChargeMode.Recharge;}}}M=
Math.Round(100*(Ã/m));}void K(){m=0;foreach(IMyBatteryBlock H in Ϥ){m+=H.MaxOutput;}}void J(ǐ I){if(I==ǐ.NoChange)return;
foreach(IMyBatteryBlock H in Ϥ){if(H!=null&H.IsFunctional){H.Enabled=true;if(I==ǐ.Auto)H.ChargeMode=ChargeMode.Auto;else if(I==
ǐ.StockpileRecharge)H.ChargeMode=ChargeMode.Recharge;else if(I==ǐ.Discharge)H.ChargeMode=ChargeMode.Recharge;}}}double G=
0;double F=0;double E=0;int D=0;void C(){F=0;D=0;foreach(IMyReactor B in ϛ){if(B!=null&&B.IsFunctional){B.Enabled=true;if
(ъ(B))D++;else F+=B.MaxOutput;}}E=Math.Round(100*(F/G));Ã+=F;}void N(){G=0;foreach(IMyReactor B in ϛ){G+=B.MaxOutput;}}
void l(IMyProjector h){h.CustomData=h.ProjectionOffset.X+"\n"+h.ProjectionOffset.Y+"\n"+h.ProjectionOffset.Z+"\n"+h.
ProjectionRotation.X+"\n"+h.ProjectionRotation.Y+"\n"+h.ProjectionRotation.Z+"\n";}void k(IMyProjector h){if(!h.IsFunctional)return;try{
string[]f=h.CustomData.Split('\n');Vector3I e=new Vector3I(int.Parse(f[0]),int.Parse(f[1]),int.Parse(f[2]));Vector3I Z=new
Vector3I(int.Parse(f[3]),int.Parse(f[4]),int.Parse(f[5]));h.Enabled=true;h.ProjectionOffset=e;h.ProjectionRotation=Z;h.
UpdateOffsetAndRotation();}catch{if(ʀ)Echo("Failed to load projector position for "+h.Name);}}int Y=0;double X=0;double W=0;bool V=false;void U
(){V=false;X=0;foreach(IMyTerminalBlock O in δ){if(O!=null&&O.IsFunctional){X++;(O as IMyConveyorSorter).Enabled=Đ.ý!=Ǒ.
Off;if(!V){MyDetectedEntityInfo?S=Ǣ.Ș(O);if(S.HasValue){string R=S.Value.Name;if(R!=null&&R!=""){if(ʀ)Echo(
"At least one rail has a target!");V=true;}}}}}W=Math.Round(100*(X/Y));}void Q(Ǒ I){if(I==Ǒ.NoChange)return;foreach(IMyTerminalBlock O in δ){if(O!=null&O
.IsFunctional){if(I==Ǒ.Off){(O as IMyConveyorSorter).Enabled=false;}else{(O as IMyConveyorSorter).Enabled=true;if(ʹ){O.
SetValue("WC_Grids",true);O.SetValue("WC_LargeGrid",true);O.SetValue("WC_SmallGrid",true);O.SetValue("WC_SubSystems",true);ʨ(O);
}if(ʸ){if(I==Ǒ.OpenFire){ʥ(O);}else{ʦ(O);}}}}}}class Í{public string Þ="";public Ơ Ā;public ǒ þ;public Ǒ ý;public Ǔ ü;
public Ǖ û;public ǔ ú;public ǁ ù;public Color ø;public ǁ ö;public Color õ;public ǁ ô;public Color ó;public ǐ ò;public int ñ;
public Ơ ð;public ƿ ï;public Ơ ÿ;public ƾ ā;public Ơ Ē;public ƽ ē;}string đ="N/A";Í Đ;Ơ ď=Ơ.On;ǒ Ď=ǒ.Offence;Ǒ č=Ǒ.OpenFire;Ǔ
Č=Ǔ.On;Ǖ ċ=Ǖ.On;ǔ Ċ=ǔ.On;ǁ ĉ=ǁ.On;Color Ĉ=new Color(33,144,255,255);ǁ ć=ǁ.On;Color Ć=new Color(255,214,170,255);ǁ ą=ǁ.On;
Color Ą=new Color(33,144,255,255);ǐ ă=ǐ.Auto;int Ă=-1;Ơ î=Ơ.NoChange;ƿ í=ƿ.NoChange;Ơ Î=Ơ.NoChange;ƾ Ý=ƾ.KeepFull;Ơ Ü=Ơ.On;ƽ
Û=ƽ.NoChange;void Ú(string Ù){Í Ø;if(!Ѩ.TryGetValue(Ù,out Ø)){Ш.Add(new ѐ("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ʀ)Echo("Setting stance '"+Ù+"'.");Đ=Ø;đ=Ù;ќ();if(ʀ)Echo("Setting "+δ.Count+" railguns to "+Đ.ý);Q(Đ.ý);
if(ʀ)Echo("Setting "+γ.Count+" torpedoes to "+Đ.Ā);Ǥ(Đ.Ā);if(ʀ)Echo("Setting "+ζ.Count+" _normalPdcs, "+ε.Count+
" defence _normalPdcs to "+Đ.þ);Å(Đ.þ);if(ʀ)Echo("Setting "+β.Count+" epsteins, "+ΰ.Count+" chems"+" to "+Đ.ü);Ȃ(Đ.ü,Đ.û);if(ʀ)Echo("Setting "+α.
Count+" rcs, "+ί.Count+" atmos"+" to "+Đ.û);Ȏ(Đ.û);if(ʀ)Echo("Setting "+Ϥ.Count+" batteries to = "+Đ.ò);J(Đ.ò);if(ʀ)Echo(
"Setting "+Ϙ.Count+" H2 tanks to stockpile = "+Đ.ò);Ï(Đ.ò);if(ʀ)Echo("Setting "+ϋ.Count+" O2 tanks to stockpile = "+Đ.ò);æ(Đ.ò);if
(ʆ){if(ʀ)Echo("No lighting was set because lighting control is disabled.");}else{if(ʀ)Echo("Setting "+ϊ.Count+
" spotlights to "+Đ.ú);Ť(Đ.ú);if(ʀ)Echo("Setting "+Ω.Count+" exterior lights to "+Đ.ù);Ţ(Đ.ù,Đ.ø);if(ʀ)Echo("Setting "+θ.Count+
" exterior lights to "+Đ.ö);Š(Đ.ö,Đ.õ);if(ʀ)Echo("Setting "+κ.Count+" port nav lights, "+ω.Count+" starboard nav lights to "+Đ.ô);ű(Đ.ô);}if(ʀ
)Echo("Setting "+ψ.Count+" aux block to "+Đ.ÿ);ύ(Đ.ÿ);if(ʀ)Echo("Setting "+ϟ.Count+" extrators to "+Đ.ā);Ҕ(Đ.ā);if(ʀ)Echo
("Setting "+Ϡ.Count+" hangar doors units to "+Đ.ē);ӂ(Đ.ē);if(Đ.ý==Ǒ.OpenFire){if(ʀ)Echo("Setting "+φ.Count+
" doors to locked because we are in combat (rails set to open fire).");Ӏ("locked","");}if(ʀ)Echo("Setting "+Ϋ.Count+" colour sync Lcds.");ƀ();if(Đ.ï==ƿ.Abort){Á("Off","EFC");Á("Abort",
"NavOS");}if(Đ.ñ>0){Á("Set Burn "+Đ.ñ,"EFC");Á("Thrust Set "+Đ.ñ/100,"NavOS");}if(Đ.ð==Ơ.On)Á("Boost On","EFC");else if(Đ.ð==Ơ.
Off)Á("Boost Off","EFC");if(ʀ)Echo("Finished setting stance.");}double Ö=0;double Õ=0;double Ô=0;double Ó=0;void Ò(){Ô=0;Ö=
0;foreach(IMyGasTank Ð in Ϙ){if(Ð.IsFunctional){Ð.Enabled=true;Ö+=Ð.Capacity;Ô+=(Ð.Capacity*Ð.FilledRatio);}}Ó=Math.Round
(100*(Ö/Õ));}void Ñ(){Õ=0;foreach(IMyGasTank Ð in Ϙ){if(Ð!=null)Õ+=Ð.Capacity;}}void Ï(ǐ I){if(I==ǐ.NoChange)return;
foreach(IMyGasTank Ð in Ϙ){if(Ð==null)continue;Ð.Enabled=true;if(I==ǐ.StockpileRecharge)Ð.Stockpile=true;else Ð.Stockpile=false
;}}double ë=0;double ì=0;double ê=0;double é=0;void è(){ì=0;ë=0;foreach(IMyGasTank Ð in ϋ){if(Ð.IsFunctional){Ð.Enabled=
true;ë+=Ð.Capacity;ì+=(Ð.Capacity*Ð.FilledRatio);}}é=Math.Round(100*(ë/ê));}void ç(){ê=0;foreach(IMyGasTank Ð in ϋ){if(Ð!=
null)ê+=Ð.Capacity;}}void æ(ǐ I){if(I==ǐ.NoChange)return;foreach(IMyGasTank Ð in ϋ){if(Ð==null)continue;Ð.Enabled=true;if(I
==ǐ.StockpileRecharge)Ð.Stockpile=true;else Ð.Stockpile=false;}}float å;float ä;float ã;double â;void á(){float à=0;float
Ɗ=0;float Ɠ=0;float Ⱥ=0;foreach(IMyThrust Ȁ in β){if(Ȁ!=null&&Ȁ.IsFunctional){à+=Ȁ.MaxThrust;Ɠ+=Ȁ.CurrentThrust;if(Ȁ.
Enabled){Ɗ+=Ȁ.MaxThrust;Ⱥ+=Ȁ.CurrentThrust;}}}â=Math.Round(100*(à/ã));if(Ɗ==0){å=à;ä=Ɠ;}else{å=Ɗ;ä=Ⱥ;}}void ȃ(){ã=0;foreach(
IMyThrust Ȁ in β){if(Ȁ!=null)ã+=Ȁ.MaxThrust;}}void Ȃ(Ǔ I,Ǖ ǿ){if(I==Ǔ.NoChange)return;foreach(IMyThrust Ȁ in β){ȁ(Ȁ,I,ǿ);}foreach
(IMyThrust Ȁ in ΰ){ȁ(Ȁ,I,ǿ,true);}}void ȁ(IMyThrust Ȁ,Ǔ I,Ǖ ǿ,bool Ǿ=false){bool ǽ=Ȁ.CustomName.Contains(ʟ);if(ǽ){if(ǿ!=Ǖ
.Off&&ǿ!=Ǖ.AtmoOnly)Ȁ.Enabled=true;else Ȁ.Enabled=false;}else{bool Ǽ=Ȁ.CustomName.Contains(ʭ);if((I==Ǔ.On)||(I==Ǔ.Minimum
&&Ǽ)||(I==Ǔ.EpsteinOnly&&!Ǿ)||(I==Ǔ.ChemOnly&&Ǿ)){Ȁ.Enabled=true;}else{Ȁ.Enabled=false;}}}float ǻ;float Ȅ;double ȅ;void Ȑ(
){ǻ=0;foreach(IMyThrust Ȁ in α){if(Ȁ!=null&&Ȁ.IsFunctional){ǻ+=Ȁ.MaxThrust;}}ȅ=Math.Round(100*(ǻ/Ȅ));}void ȏ(){Ȅ=0;
foreach(IMyThrust Ȁ in α){if(Ȁ!=null)Ȅ+=Ȁ.MaxThrust;}}void Ȏ(Ǖ I){foreach(IMyThrust Ȁ in α){if(Ȁ!=null)ȍ(Ȁ,I);}foreach(
IMyThrust Ȁ in ί){if(Ȁ!=null)ȍ(Ȁ,I,true);}}void ȍ(IMyThrust Ȁ,Ǖ I,bool Ȍ=false){bool ȋ=Ȁ.GridThrustDirection==Vector3I.Backward;
bool Ȋ=Ȁ.GridThrustDirection==Vector3I.Forward;if((I==Ǖ.On)||(I==Ǖ.ForwardOff&&!ȋ)||(I==Ǖ.ReverseOff&&!Ȋ)||(I==Ǖ.RcsOnly&&!Ȍ
)||(I==Ǖ.AtmoOnly&&Ȍ)){Ȁ.Enabled=true;}else{Ȁ.Enabled=false;}}int ȉ=0;double Ȉ=0;double ȇ=0;void Ȇ(){Ȉ=0;foreach(
IMyTerminalBlock ǣ in γ){if(ǣ!=null&&ǣ.IsFunctional){Ȉ++;(ǣ as IMyConveyorSorter).Enabled=Đ.Ā==Ơ.On;if(ʻ){string Ǻ=Ǣ.ƶ(ǣ,0);int ĥ=К(Ǻ);
if(ʀ)Echo("Launcher "+ǣ.CustomName+" needs "+Ǻ+"("+ĥ+")");ϫ(ǣ,ĥ);}}}ȇ=Math.Round(100*(Ȉ/ȉ));}void Ǥ(Ơ I){if(I==Ơ.NoChange)
return;foreach(IMyTerminalBlock ǣ in γ){if(ǣ!=null&ǣ.IsFunctional){if(I==Ơ.Off){(ǣ as IMyConveyorSorter).Enabled=false;}else{(
ǣ as IMyConveyorSorter).Enabled=true;if(ʹ){ǣ.SetValue("WC_FocusFire",true);ǣ.SetValue("WC_Grids",true);ǣ.SetValue(
"WC_LargeGrid",true);ǣ.SetValue("WC_SmallGrid",false);ǣ.SetValue("WC_FocusFire",true);ǣ.SetValue("WC_SubSystems",true);ʨ(ǣ);}}}}}ǡ Ǣ;
class ǡ{private Action<ICollection<MyDefinitionId>>Ǡ;private Action<ICollection<MyDefinitionId>>ǟ;private Action<ICollection<
MyDefinitionId>>Ǟ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>ǝ;private Func<long,MyTuple<bool,
int,int>>ǜ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>Ǜ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>ǚ;private Func<long,int,
MyDetectedEntityInfo>Ǚ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǘ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>Ǘ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>ǥ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>Ǹ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>ǹ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ƿ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>Ƕ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>ǵ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ǵ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ǲ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>ǰ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>Ǯ;private Func<MyDefinitionId,float>ǭ;private Func<long,bool>Ǭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>ǫ;private Func<long,float>Ǫ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ǩ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>Ǩ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>ȑ;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>ȴ;private Func<long,float>Ȳ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>ȱ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȱ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ȯ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>Ȯ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>ȭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>Ȭ;public bool ȫ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȫ){var ȩ=Ȫ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(Ȫ);if(ȩ==null)throw new Exception("WcPbAPI failed to activate");return Ȩ(ȩ);}public bool Ȩ
(IReadOnlyDictionary<string,Delegate>ȥ){if(ȥ==null)return false;ȧ(ȥ,"GetCoreWeapons",ref Ǡ);ȧ(ȥ,"GetCoreStaticLaunchers",
ref ǟ);ȧ(ȥ,"GetCoreTurrets",ref Ǟ);ȧ(ȥ,"GetBlockWeaponMap",ref ǝ);ȧ(ȥ,"GetProjectilesLockedOn",ref ǜ);ȧ(ȥ,
"GetSortedThreats",ref Ǜ);ȧ(ȥ,"GetObstructions",ref ǚ);ȧ(ȥ,"GetAiFocus",ref Ǚ);ȧ(ȥ,"SetAiFocus",ref ǘ);ȧ(ȥ,"GetWeaponTarget",ref Ǘ);ȧ(ȥ,
"SetWeaponTarget",ref ǥ);ȧ(ȥ,"FireWeaponOnce",ref ǧ);ȧ(ȥ,"ToggleWeaponFire",ref Ǹ);ȧ(ȥ,"IsWeaponReadyToFire",ref ǹ);ȧ(ȥ,
"GetMaxWeaponRange",ref Ƿ);ȧ(ȥ,"GetTurretTargetTypes",ref Ƕ);ȧ(ȥ,"SetTurretTargetTypes",ref ǵ);ȧ(ȥ,"SetBlockTrackingRange",ref Ǵ);ȧ(ȥ,
"IsTargetAligned",ref ǳ);ȧ(ȥ,"IsTargetAlignedExtended",ref ǲ);ȧ(ȥ,"CanShootTarget",ref Ǳ);ȧ(ȥ,"GetPredictedTargetPosition",ref ǰ);ȧ(ȥ,
"GetHeatLevel",ref ǯ);ȧ(ȥ,"GetCurrentPower",ref Ǯ);ȧ(ȥ,"GetMaxPower",ref ǭ);ȧ(ȥ,"HasGridAi",ref Ǭ);ȧ(ȥ,"HasCoreWeapon",ref ǫ);ȧ(ȥ,
"GetOptimalDps",ref Ǫ);ȧ(ȥ,"GetActiveAmmo",ref ǩ);ȧ(ȥ,"SetActiveAmmo",ref Ǧ);ȧ(ȥ,"MonitorProjectile",ref Ǩ);ȧ(ȥ,"UnMonitorProjectile",
ref ȑ);ȧ(ȥ,"GetProjectileState",ref ȴ);ȧ(ȥ,"GetConstructEffectiveDps",ref Ȳ);ȧ(ȥ,"GetPlayerController",ref ȱ);ȧ(ȥ,
"GetWeaponAzimuthMatrix",ref Ȱ);ȧ(ȥ,"GetWeaponElevationMatrix",ref ȯ);ȧ(ȥ,"IsTargetValid",ref Ȯ);ȧ(ȥ,"GetWeaponScope",ref ȭ);ȧ(ȥ,"IsInRange",ref
Ȭ);return true;}private void ȧ<Ȧ>(IReadOnlyDictionary<string,Delegate>ȥ,string ȳ,ref Ȧ Ȥ)where Ȧ:class{if(ȥ==null){Ȥ=null
;return;}Delegate ȵ;if(!ȥ.TryGetValue(ȳ,out ȵ))throw new Exception(
$"{GetType().Name} :: Couldn't find {ȳ} delegate of type {typeof(Ȧ)}");Ȥ=ȵ as Ȧ;if(Ȥ==null)throw new Exception(
$"{GetType().Name} :: Delegate {ȳ} is not type {typeof(Ȧ)}, instead it's: {ȵ.GetType()}");}public void ɀ(ICollection<MyDefinitionId>Ȝ)=>Ǡ?.Invoke(Ȝ);public void ȿ(ICollection<MyDefinitionId>Ȝ)=>ǟ?.Invoke(Ȝ);
public void Ⱦ(ICollection<MyDefinitionId>Ȝ)=>Ǟ?.Invoke(Ȝ);public bool Ƚ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȼ,IDictionary<
string,int>Ȝ)=>ǝ?.Invoke(ȼ,Ȝ)??false;public MyTuple<bool,int,int>Ȼ(long ȹ)=>ǜ?.Invoke(ȹ)??new MyTuple<bool,int,int>();public
void ȸ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ț,IDictionary<MyDetectedEntityInfo,float>Ȝ)=>Ǜ?.Invoke(Ț,Ȝ);public void ȷ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ț,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ȝ)=>ǚ?.Invoke(Ț,Ȝ);public
MyDetectedEntityInfo?ȶ(long ȣ,int ș=0)=>Ǚ?.Invoke(ȣ,ș);public bool Ȓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ț,long Ȗ,int ș=0)=>ǘ?.Invoke(Ț,Ȗ
,ș)??false;public MyDetectedEntityInfo?Ș(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ=0)=>Ǘ?.Invoke(Ɩ,Ɣ);public void ȗ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,long Ȗ,int Ɣ=0)=>ǥ?.Invoke(Ɩ,Ȗ,Ɣ);public void ȕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Ɩ,bool Ȕ=true,int Ɣ=0)=>ǧ?.Invoke(Ɩ,Ȕ,Ɣ);public void ȓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,bool ț,bool Ȕ,int Ɣ=0)=>Ǹ
?.Invoke(Ɩ,ț,Ȕ,Ɣ);public bool Ȣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ=0,bool ȡ=true,bool Ƞ=false)=>ǹ?.Invoke(Ɩ,Ɣ
,ȡ,Ƞ)??false;public float ȟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ)=>Ƿ?.Invoke(Ɩ,Ɣ)??0f;public bool Ȟ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ɩ,IList<string>Ȝ,int Ɣ=0)=>Ƕ?.Invoke(Ɩ,Ȝ,Ɣ)??false;public void ȝ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɩ,IList<string>Ȝ,int Ɣ=0)=>ǵ?.Invoke(Ɩ,Ȝ,Ɣ);public void ǖ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,float Ɵ)=>Ǵ?.Invoke(
Ɩ,Ɵ);public bool Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,long Ʈ,int Ɣ)=>ǳ?.Invoke(Ɩ,Ʈ,Ɣ)??false;public MyTuple<bool,
Vector3D?>Ʊ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,long Ʈ,int Ɣ)=>ǲ?.Invoke(Ɩ,Ʈ,Ɣ)??new MyTuple<bool,Vector3D?>();public bool
ư(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,long Ʈ,int Ɣ)=>Ǳ?.Invoke(Ɩ,Ʈ,Ɣ)??false;public Vector3D?Ư(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Ɩ,long Ʈ,int Ɣ)=>ǰ?.Invoke(Ɩ,Ʈ,Ɣ)??null;public float Ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ)=>ǯ?.
Invoke(Ɩ)??0f;public float Ƽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ)=>Ǯ?.Invoke(Ɩ)??0f;public float ƻ(MyDefinitionId ƺ)=>ǭ?.
Invoke(ƺ)??0f;public bool ƹ(long ƙ)=>Ǭ?.Invoke(ƙ)??false;public bool Ƹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ)=>ǫ?.Invoke(Ɩ)
??false;public float Ʒ(long ƙ)=>Ǫ?.Invoke(ƙ)??0f;public string ƶ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ)=>ǩ?.
Invoke(Ɩ,Ɣ)??null;public void Ƶ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ,string ƴ)=>Ǧ?.Invoke(Ɩ,Ɣ,ƴ);public void ƭ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ,Action<long,int,ulong,long,Vector3D,bool>Ɲ)=>Ǩ?.Invoke(Ɩ,Ɣ,Ɲ);public void ƞ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ,Action<long,int,ulong,long,Vector3D,bool>Ɲ)=>ȑ?.Invoke(Ɩ,Ɣ,Ɲ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ɯ(ulong ƛ)=>ȴ?.Invoke(ƛ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ƚ(long ƙ)=>Ȳ?.Invoke(ƙ)??0f;public long Ƙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ)=>ȱ?.Invoke(Ɩ)??-1;public
Matrix Ɨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ)=>Ȱ?.Invoke(Ɩ,Ɣ)??Matrix.Zero;public Matrix ƕ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɩ,int Ɣ)=>ȯ?.Invoke(Ɩ,Ɣ)??Matrix.Zero;public bool Ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,long ƫ,bool ƪ,bool Ʃ)=>Ȯ?.
Invoke(Ɩ,ƫ,ƪ,Ʃ)??false;public MyTuple<Vector3D,Vector3D>ƨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɩ,int Ɣ)=>ȭ?.Invoke(Ɩ,Ɣ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>Ƨ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ʀ)=>Ȭ?.Invoke(Ʀ)??new MyTuple<
bool,bool>();}int ƥ=0;double Ƥ=0;double ƣ=0;void Ƣ(){Ƥ=0;foreach(IMyTerminalBlock ơ in Ψ){if(ơ!=null&&ơ.IsFunctional)Ƥ++;}ƣ=
Math.Round(100*(Ƥ/ƥ));}enum Ơ{
    Off, On, NoChange
    }enum ǁ{
    Off, On, NoChange, OnNoColourChange
    }enum ǒ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum Ǒ{
    Off, HoldFire, OpenFire, NoChange
    }enum Ǔ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum Ǖ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum ǔ{
    On, Off, OnMax, NoChange
    }enum ǐ{
    Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
    }enum ƿ{
    Abort, NoChange
    }enum ƾ{
    Off, On, FillWhenLow, KeepFull,
    }enum ƽ{
    Closed, Open, NoChange
    }
}sealed class ǀ{public double ǂ{get;private set;}private double ǎ{get{double Ǐ=ǆ[0];for(int Ě=1;Ě<ǈ;Ě++){Ǐ+=ǆ[Ě];}return(
Ǐ/ǈ);}}public double Ǎ{get{double ǌ=ǆ[0];for(int Ě=1;Ě<ǈ;Ě++){if(ǆ[Ě]>ǌ){ǌ=ǆ[Ě];}}return ǌ;}}public double ǋ{get;private
set;}public double Ǌ{get{double ǉ=ǆ[0];for(int Ě=1;Ě<ǈ;Ě++){if(ǆ[Ě]<ǉ){ǉ=ǆ[Ě];}}return ǉ;}}public int ǈ{get;}private double
Ǉ;private IMyGridProgramRuntimeInfo Ǆ;private double[]ǆ;private int ǅ=0;public ǀ(IMyGridProgramRuntimeInfo Ǆ,int ŉ=300){
this.Ǆ=Ǆ;this.ǋ=Ǆ.LastRunTimeMs;this.ǈ=MathHelper.Clamp(ŉ,1,int.MaxValue);this.Ǉ=1.0/ǈ;this.ǆ=new double[ŉ];this.ǆ[ǅ]=Ǆ.
LastRunTimeMs;this.ǅ++;}public void ǃ(){ǂ-=ǆ[ǅ]*Ǉ;ǂ+=Ǆ.LastRunTimeMs*Ǉ;ǆ[ǅ]=Ǆ.LastRunTimeMs;if(Ǆ.LastRunTimeMs>ǋ){ǋ=Ǆ.LastRunTimeMs;}
ǅ++;if(ǅ>=ǈ){ǅ=0;ǂ=ǎ;ǋ=Ǆ.LastRunTimeMs;}}