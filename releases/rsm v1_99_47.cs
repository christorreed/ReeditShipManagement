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

string Version = "1.99.47 (2024-04-11)";
ƻ Ά;int ͽ=0;int ͼ=0;int ͻ=0;int ͺ;bool ͷ=true;bool Ͷ=true;bool ʹ=false;bool ͳ=false;bool Ͳ=false;bool ͱ=false;bool Ͱ=
false;bool ˮ=false;int ˬ=0;int Έ=0;double Ή;float Θ;string Ι;string Η;string Ζ;bool Ε=false;int Δ=0;int Γ=0;Program(){Echo(
"Welcome to RSM\nV "+Version);ʷ();ͺ=ɴ;Ι=Me.GetOwnerFactionTag();Ά=new ƻ(Runtime);ϭ();ɺ.Add(0.5);ɺ.Add(0.25);ɺ.Add(0.1);ɺ.Add(0.05);ń();
Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo("Took "+ʷ());}void Main(string x,UpdateType Β){if(Β==UpdateType.
Update100)ˀ();else Α(x);}void Α(string x){if(ɾ)Echo("Processing command '"+x+"'...");if(x==""){п.Add(new ш(
"COMMAND FAILED: Arg Required!","A command was ignored because the argument was blank.",3));return;}string[]ΐ=x.Split(':');if(ΐ.Length<2){п.Add(new ш(
"COMMAND FAILED: Syntax Error!","A command was ignored because it wasn't recognised.",3));return;}if(ΐ[0].ToLower()!="comms")ΐ[1]=ΐ[1].Replace(" ",
string.Empty);switch(ΐ[0].ToLower()){case"init":bool Ώ=true,Ύ=true,Ό=true;if(ΐ.Length>2){foreach(string Ί in ΐ){if(Ί.ToLower()
=="nonames")Ώ=false;else if(Ί.ToLower()=="nosubs")Ύ=false;else if(Ί.ToLower()=="noinv")Ό=false;}}Җ(ΐ[1],Ώ,Ύ,Ό);return;case
"stance":í(ΐ[1]);return;case"hudlcd":string ˣ="";if(ΐ.Length>2)ˣ=ΐ[2];Ĩ(ΐ[1],ˣ);return;case"doors":string ˆ="";if(ΐ.Length>2)ˆ=ΐ
[2];ҳ(ΐ[1],ˆ);return;case"comms":ˢ(ΐ[1]);return;case"printblockids":ɕ();return;case"printblockprops":ɑ(ΐ[1]);return;case
"spawn":if(ΐ[1].ToLower()=="open"){ͱ=true;ͺ=ɴ;п.Add(new ш("Spawns were opened to friends",
"Spawns are now opened to the friends list as defined in PB custom data.",2));}else{ͱ=false;ͺ=ɴ;п.Add(new ш("Spawns were closed to friends",
"Spawns are now closed to the friends list as defined in PB custom data.",2));}return;case"projectors":if(ΐ[1].ToLower()=="save"){foreach(IMyProjector B in ϙ)D(B);п.Add(new ш(
"Projector positions saved","Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector B in ϙ)C(B);п.
Add(new ш("Projector positions loaded","Projector positions were loaded from custom data.",2));return;}default:п.Add(new ш(
"COMMAND FAILED: Syntax Error!","A command was ignored because it wasn't recognised.",3));return;}}void ˀ(){if(ͼ<ɵ){ͼ++;return;}ͼ=0;if(ͷ){if(ɷ)ʷ();Echo
("Parsing custom data...");Ѥ();ͷ=false;return;}ʻ();Δ=Runtime.CurrentInstructionCount;if(Δ>Γ)Γ=Runtime.
CurrentInstructionCount;if(ɷ)ʷ();if(ï.ò==Ɯ.On){ʹ=true;ͳ=true;}else if(ï.ò==Ɯ.Off){ʹ=true;}if(ͺ>=ɴ){ͺ=0;ʼ();return;}ͺ++;ʿ();ʾ();if(ɷ)Echo(
"Took "+ʷ());if(ɾ)Echo("Updating "+Φ.Count+" RSM Lcds");Ľ();if(ɷ)Echo("Took "+ʷ());}void ʿ(){ˁ();switch(ͽ){case 0:if(ɾ)Echo(
"Refreshing "+Ϗ.Count+" railguns...");h();if(ɷ)Echo("Took "+ʷ());if(Ͷ)break;else goto case 1;case 1:if(ɾ)Echo("Refreshing "+Ϙ.Count+
" reactors & "+ς.Count+" batteries...");È(ï.ù);if(ɷ)Echo("Took "+ʷ());if(Ͷ)break;else goto case 2;case 2:if(ɾ)Echo("Refreshing "+ύ.
Count+" epsteins...");å();if(ɷ)Echo("Took "+ʷ());if(Ͷ)break;else goto case 3;case 3:if(ɾ)Echo("Refreshing "+ϒ.Count+
" lidars...");Ƃ(ͳ,ʹ);if(ɷ)Echo("Took "+ʷ());if(ɾ)Echo("Refreshing pb servers...");v();if(ɷ)Echo("Took "+ʷ());if(Ͷ)break;else goto
case 4;case 4:if(ɾ)Echo("Refreshing "+Ξ.Count+" doors...");Ҷ();if(ɷ)Echo("Took "+ʷ());if(ɾ)Echo("Refreshing "+Ν.Count+
" airlocks...");ҡ();if(ɷ)Echo("Took "+ʷ());break;default:if(ɾ)Echo("Booting complete");Ͷ=false;ͽ=0;return;}if(Ͷ)ͽ++;}void ʾ(){switch(ͻ
){case 0:if(ɾ)Echo("Clearing temp inventories...");Ϭ();if(ɷ)Echo("Took "+ʷ());if(ɾ)Echo("Refreshing "+ώ.Count+
" torpedo launchers...");Ȅ();if(ɷ)Echo("Took "+ʷ());if(ɾ)Echo("Refreshing items...");ϫ();if(ɷ)Echo("Took "+ʷ());break;case 1:if(ɾ)Echo(
"Running autoload...");ː();if(ɷ)Echo("Took "+ʷ());break;case 2:if(ɾ)Echo("Refreshing "+ϖ.Count+" H2 tanks...");Ö();if(ɷ)Echo("Took "+ʷ());if(
ɾ)Echo("Refreshing refuel status...");ҁ();if(Ͳ){if(ɾ)Echo("Fuel low, filling extractors...");Ҍ();if(ɷ)Echo("Took "+ʷ());
return;}else{ʽ();if(ɷ)Echo("Took "+ʷ());}ͻ=0;return;}ͻ++;}void ʽ(){if(ɾ)Echo("Refreshing "+ό.Count+" rcs...");Ǹ();if(ɾ)Echo(
"Refreshing "+ϑ.Count+" Pdcs & "+ϐ.Count+" defensive Pdcs...");q();if(ɾ)Echo("Refreshing "+Ϛ.Count+" gyros...");Ҙ(ͳ,ʹ);if(ɾ)Echo(
"Refreshing "+ϕ.Count+" O2 tanks...");Ï();if(ɾ)Echo("Refreshing "+σ.Count+" antennas...");ˇ();if(ɾ)Echo("Refreshing "+π.Count+
" cargos...");ʗ();if(ɾ)Echo("Refreshing "+ϔ.Count+" vents...");ŭ(ͳ,ʹ);if(ɾ)Echo("Refreshing "+Ο.Count+" auxiliary blocks...");φ();if
(ɾ)Echo("Refreshing "+ϓ.Count+" welders...");ƞ();if(ɾ)Echo("Refreshing "+Ψ.Count+" lcds...");Ƈ();if(ʹ){if(ɾ)Echo(
"Refreshing "+ω.Count+" connectors...");Ū(ͳ);if(ɾ)Echo("Refreshing "+ρ.Count+" cameras...");Ũ(ͳ);if(ɾ)Echo("Refreshing "+ϗ.Count+
" sensors...");Ŧ(ͳ);}}void ʼ(){if(ɾ)Echo("Clearing block lists...");ɪ();if(ɷ)Echo("Took "+ʷ());if(ɾ)Echo("Refreshing block lists...")
;GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,Ρ);if(ɷ)Echo("Took "+ʷ());if(ɾ)Echo(
"Setting KeepFull threshold");Ҋ();if(τ==null){if(ϋ.Count>0)τ=ϋ[0];else п.Add(new ш("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ɾ)Echo("Finished block refresh.");if(ɷ)Echo("Took "+ʷ());}void ˁ(){try{Ǣ=new ǳ();Ǣ.ȩ(Me);}catch(Exception ex){Ǣ
=null;п.Add(new ш("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ʻ(){string ʹ="REEDIT SHIP MANAGEMENT \n\n|- V "+Version+"\n|- Ship Name: "+ɳ+"\n|- Stance: "+ð+
"\n|- Step: "+ͺ+"/"+ɴ+" ("+ͻ+")";if(Ͷ)ʹ+="\n|- Booting "+ͽ;if(ɷ){Ά.ƿ();ʹ+="\n|- Runtime Av/Tick: "+(Math.Round(Ά.ƹ,2)/100)+" ms"+
"\n|- Runtime Max: "+Math.Round(Ά.ǉ,4)+" ms"+"\n|- Instructions: "+Δ+" ("+Γ+")";}Echo(ʹ+"\n");}long ʸ=0;string ʷ(){long ʶ=DateTime.Now.Ticks
/TimeSpan.TicksPerMillisecond;if(ʸ==0){ʸ=ʶ;return"0 ms";}long ʵ=ʶ-ʸ;ʸ=ʶ;return ʵ+" ms";}bool ʴ=false;string ʺ="";double ʳ
=0;void ˇ(){ʴ=false;ʳ=0;foreach(IMyRadioAntenna ˠ in σ){if(ˠ!=null){if(ˠ.IsFunctional){float Ǒ=ˠ.Radius;if(Ǒ>ʳ)ʳ=Ǒ;if(ˠ.
IsBroadcasting&&ˠ.Enabled)ʴ=true;}}}}void ˢ(string ˡ){ʺ=ˡ;foreach(IMyTerminalBlock ɉ in σ){IMyRadioAntenna ˠ=ɉ as IMyRadioAntenna;if(ˠ
!=null)ˠ.HudText=ˡ;}}string ˑ="";void ː(){if(!ʒ)return;ˑ="";foreach(var ŋ in Ϣ){if(!ŋ.Ϯ&&!ŋ.Ϥ)continue;if(ɾ)Echo(
"Checking "+ŋ.Ϟ);List<Њ>ˏ=ŋ.Ё.Concat(ŋ.ϰ).ToList();List<Њ>ˎ=new List<Њ>();List<Њ>ˍ=new List<Њ>();List<Њ>ˌ=new List<Њ>();List<Њ>ˋ=
new List<Њ>();List<Њ>ˊ=new List<Њ>();int ˉ=0;int ˤ=0;bool Κ=false;double ο=.97;if(ŋ.ϣ<1)ο=ŋ.ϣ*.97;foreach(Њ ϊ in ˏ){if(ϊ==
null)continue;if(ϊ.Ї){ˤ++;ˉ+=ϊ.Ј;if(ɾ)Echo("Inv.FillFactor = "+ϊ.І+"\ntargetFillFactor = "+ο);if(ϊ.І<ο)ˌ.Add(ϊ);else if(ŋ.ϣ<
1&&ϊ.І>ŋ.ϣ*1.03)ˋ.Add(ϊ);if(ϊ.І!=0)ˍ.Add(ϊ);else if(!Κ&&ŋ.Ѓ==0)Κ=true;}else{ˊ.Add(ϊ);if(ϊ.Ј>0){ˎ.Add(ϊ);}}}if(Κ){if(ˑ!=""
)ˑ+="\n";ˑ+=ŋ.ϥ.SubtypeId;}if(ˌ.Count>0){int ψ=(int)(ˉ/ˤ);ˌ=ˌ.OrderBy(Ę=>Ę.Ј).ToList();if(ŋ.Ѓ>0){if(ɾ)Echo("Loading "+ŋ.ϥ
.SubtypeId+"...");ˎ=ˎ.OrderByDescending(Ę=>Ę.Ј).ToList();в(ˎ,ˌ,ŋ.ϥ,-1,ŋ.ϣ);}else{if(ɾ)Echo("Balancing "+ŋ.ϥ.SubtypeId+
"...");ˍ=ˍ.OrderByDescending(Ę=>Ę.Ј).ToList();в(ˍ,ˌ,ŋ.ϥ,ψ);}}else if(ˋ.Count>0){if(ɾ)Echo("Unloading "+ŋ.ϥ.SubtypeId+"...");
List<Њ>χ=new List<Њ>();if(ˎ.Count>0)χ=ˎ;else χ=ˊ;в(ˋ,χ,ŋ.ϥ,-1,1,ŋ.ϣ);}else{if(ɾ)Echo("No loading required "+ŋ.ϥ.SubtypeId+
"...");}}}void φ(){Έ=0;foreach(IMyTerminalBlock ɉ in Ο){if(ɉ==null)continue;if(ɉ.IsWorking)Έ++;}}void υ(Ɯ N){if(N==Ɯ.NoChange
)return;foreach(IMyTerminalBlock ɉ in Ο){if(ɉ==null)continue;try{if(N==Ɯ.Off)ɉ.ApplyAction("OnOff_Off");else ɉ.
ApplyAction("OnOff_On");}catch{if(ɾ)Echo("Failed to set aux block "+ɉ.CustomName);}}}IMyShipController τ;List<IMyRadioAntenna>σ=new
List<IMyRadioAntenna>();List<IMyBatteryBlock>ς=new List<IMyBatteryBlock>();List<IMyCameraBlock>ρ=new List<IMyCameraBlock>();
List<IMyCargoContainer>π=new List<IMyCargoContainer>();List<IMyShipConnector>ω=new List<IMyShipConnector>();List<
IMyShipController>ϋ=new List<IMyShipController>();List<IMyAirtightHangarDoor>Ϝ=new List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>ϝ=
new List<IMyTerminalBlock>();List<IMyTerminalBlock>ϛ=new List<IMyTerminalBlock>();List<IMyGyro>Ϛ=new List<IMyGyro>();List<
IMyProjector>ϙ=new List<IMyProjector>();List<IMyReactor>Ϙ=new List<IMyReactor>();List<IMySensorBlock>ϗ=new List<IMySensorBlock>();
List<IMyGasTank>ϖ=new List<IMyGasTank>();List<IMyGasTank>ϕ=new List<IMyGasTank>();List<IMyAirVent>ϔ=new List<IMyAirVent>();
List<IMyTerminalBlock>ϓ=new List<IMyTerminalBlock>();List<IMyConveyorSorter>ϒ=new List<IMyConveyorSorter>();List<
IMyTerminalBlock>ϑ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ϐ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ϗ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>ώ=new List<IMyTerminalBlock>();List<IMyThrust>ύ=new List<IMyThrust>();List<IMyThrust>ό=new
List<IMyThrust>();List<IMyThrust>ξ=new List<IMyThrust>();List<IMyThrust>Ϋ=new List<IMyThrust>();List<IMyProgrammableBlock>μ=
new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>Ω=new List<IMyProgrammableBlock>();List<IMyTextPanel>Ψ=new List<
IMyTextPanel>();List<IMyTextPanel>Χ=new List<IMyTextPanel>();List<г>Φ=new List<г>();List<IMyLightingBlock>Υ=new List<
IMyLightingBlock>();List<IMyLightingBlock>Τ=new List<IMyLightingBlock>();List<IMyLightingBlock>Ϊ=new List<IMyLightingBlock>();List<
IMyLightingBlock>Σ=new List<IMyLightingBlock>();List<IMyReflectorLight>Π=new List<IMyReflectorLight>();List<IMyTerminalBlock>Ο=new List<
IMyTerminalBlock>();List<ћ>Ξ=new List<ћ>();List<Ү>Ν=new List<Ү>();bool Μ=false;Dictionary<IMyTerminalBlock,string>Λ=new Dictionary<
IMyTerminalBlock,string>();bool Ρ(IMyTerminalBlock ɖ){try{if(!Me.IsSameConstructAs(ɖ))return false;string ά=ɖ.GetOwnerFactionTag();if(ά
!=Ι&&ά!=""){Echo("!"+ά+": "+ɖ.CustomName);ˬ++;return false;}if(ɖ.CustomName.Contains(ʫ))return false;if(!Μ&&ʓ&&!ɖ.
CustomName.Contains(ɳ))return false;if(ɖ.CustomName.Contains(ʨ))Ο.Add(ɖ);string ν=ɖ.BlockDefinition.ToString();if(ν==
"MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Μ)Λ.Add(ɖ,"Refill Station");return false;}if(ν.Contains("MedicalRoom/")){if(ͱ)ɖ.CustomData=Ζ;else ɖ.CustomData=Η;if
(!ɖ.CustomName.Contains(ʫ))ɖ.ApplyAction("OnOff_On");if(Μ)Λ.Add(ɖ,"Medical Room");return false;}if(ν.Contains(
"SurvivalKit/")){if(ͱ)ɖ.CustomData=Ζ;else ɖ.CustomData=Η;if(!ɖ.CustomName.Contains(ʫ))ɖ.ApplyAction("OnOff_On");if(Μ)Λ.Add(ɖ,
"Survival Kit");return false;}var λ=ɖ as IMyTextPanel;if(λ!=null){Ψ.Add(λ);if(Μ)Λ.Add(ɖ,"LCD");if(λ.CustomName.Contains(ʪ)){г κ=new г(
);κ.ɉ=λ;Φ.Add(Ƀ(κ));}else if(!ɼ&&λ.CustomName.Contains(ʩ))Χ.Add(λ);return false;}if(ν==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɩ(ɖ,"Flak",3);if(ν=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɩ(ɖ,
"OPA",3);if(ν=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɩ(ɖ,"Voltaire",3);if(ν.Contains
("Nariman Dynamics PDC"))return ɩ(ɖ,"Nari",4);if(ν.Contains("Redfields Ballistics PDC"))return ɩ(ɖ,"Red",4);if(ν==
"MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return ɧ(ɖ,"Apollo");if(ν=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɧ(ɖ,"Tycho");if(ν==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return ɧ(ɖ,"Zeus");if(ν=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɧ(ɖ,"Tycho");if(ν.Contains(
"Ares_Class"))return ɧ(ɖ,"Ares");if(ν.Contains("Artemis_Torpedo_Tube"))return ɧ(ɖ,"Artemis");if(ν==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return ɗ(ɖ,"Dawson",11);if(ν=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return ɗ(ɖ,"Stiletto",12);if
(ν=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return ɗ(ɖ,"Roci",13);if(ν==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return ɗ(ɖ,"Foehammer",14);if(ν=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return ɗ(ɖ,"Farren",15);
if(ν.Contains("Zakosetara"))return ɗ(ɖ,"Zako",10);if(ν.Contains("Kess Hashari Cannon"))return ɗ(ɖ,"Kess",16);if(ν.Contains
("Coilgun"))return ɗ(ɖ,"Coilgun",13);if(ν.Contains("Glapion"))return ɗ(ɖ,"Glapion",3);var ι=ɖ as IMyThrust;if(ι!=null){if
(ν.ToUpper().Contains("RCS")){ό.Add(ι);if(Μ)Λ.Add(ɖ,"RCS");}else if(ν.Contains("Hydro")){ξ.Add(ι);if(Μ)Λ.Add(ɖ,"Chem");}
else if(ν.Contains("Atmospheric")){Ϋ.Add(ι);if(Μ)Λ.Add(ɖ,"Atmo");}else{ύ.Add(ι);if(Μ){string ɨ="";if(ɿ){try{ɨ=ɖ.
DefinitionDisplayNameText.Split('"')[1];ɨ=ʠ+ɨ[0].ToString().ToUpper()+ɨ.Substring(1).ToLower();}catch{if(ɾ)Echo("Failed to get drive type from "+
ɖ.DefinitionDisplayNameText);}}Λ.Add(ɖ,"Epstein"+ɨ);}}return false;}var θ=ɖ as IMyCargoContainer;if(θ!=null){string η=ν.
Split('/')[1];if(η.Contains("Container")||η.Contains("Cargo")){π.Add(θ);ϡ(ɖ);if(Μ){double ζ=ɖ.GetInventory().MaxVolume.
RawValue;double ε=Math.Round(ζ/1265625024,1);if(ε==0)ε=0.1;Λ.Add(ɖ,"Cargo ["+ε+"]");}return false;}}var δ=ɖ as IMyGyro;if(δ!=
null){Ϛ.Add(δ);if(Μ)Λ.Add(ɖ,"Gyroscope");return false;}var γ=ɖ as IMyBatteryBlock;if(γ!=null){ς.Add(γ);if(Μ)Λ.Add(ɖ,"Power"+
ʠ+"Battery");return false;}var β=ɖ as IMyReflectorLight;if(β!=null){Π.Add(β);if(Μ)Λ.Add(ɖ,"Spotlight");return false;}var
α=ɖ as IMyLightingBlock;if(α!=null){if(ɖ.CustomName.ToUpper().Contains("INTERIOR")||ν.Contains("Kitchen")||ν.Contains(
"Aquarium")){Τ.Add(α);if(Μ)Λ.Add(ɖ,"Light"+ʠ+"Interior");}else if(ɖ.CustomName.Contains(ʤ)){if(ɖ.CustomName.ToUpper().Contains(
"STARBOARD")){Σ.Add(α);if(Μ)Λ.Add(ɖ,"Light"+ʠ+"Nav"+ʠ+"Starboard");}else{Ϊ.Add(α);if(Μ)Λ.Add(ɖ,"Light"+ʠ+"Nav"+ʠ+"Port");}}else{Υ.
Add(α);if(Μ)Λ.Add(ɖ,"Light"+ʠ+"Exterior");}return false;}var ΰ=ɖ as IMyGasTank;if(ΰ!=null){if(ν.Contains("Hydro")){ϖ.Add(ΰ)
;if(Μ)Λ.Add(ɖ,"Tank"+ʠ+"Hydrogen");}else{ϕ.Add(ΰ);if(Μ)Λ.Add(ɖ,"Tank"+ʠ+"Oxygen");}return false;}var ί=ɖ as IMyReactor;if
(ί!=null){Ϙ.Add(ί);ϡ(ɖ,0);if(Μ){string ή="Lg";if(ν.Contains("SmallGenerator"))ή="Sm";else if(ν.Contains("MCRN"))ή="MCRN";
Λ.Add(ɖ,"Power"+ʠ+"Reactor"+ʠ+ή);}return false;}var έ=ɖ as IMyShipController;if(έ!=null){ϋ.Add(έ);if(τ==null&&ɖ.
CustomName.Contains("Nav"))τ=έ;if(έ.HasInventory)ϡ(ɖ);if(Μ&&ν.Contains("Cockpit/")){if(ν.Contains("StandingCockpit")||ν.Contains(
"Console")){Λ.Add(ɖ,"Console");return false;}else if(ν.Contains("Cockpit")){Λ.Add(ɖ,"Cockpit");return false;}}}var ʲ=ɖ as IMyDoor
;if(ʲ!=null){ћ ɥ=new ћ();ɥ.ɉ=ʲ;if(ɖ.CustomName.Contains(ʣ)){try{string ɢ=ɖ.CustomName.Split(ʠ)[3];ɥ.ѽ=true;bool ɡ=false;
foreach(Ү ɤ in Ν){if(ɢ==ɤ.ҭ){ɤ.ҩ.Add(ɥ);ɡ=true;break;}}if(!ɡ){Ү ɠ=new Ү();ɠ.ҭ=ɢ;ɠ.ҩ.Add(ɥ);Ν.Add(ɠ);}}catch{if(ɾ)Echo(
"Error with airlock door name "+ɖ.CustomName);Ξ.Add(ɥ);}}else{Ξ.Add(ɥ);}if(Μ)Λ.Add(ɖ,"Door");return false;}var ɣ=ɖ as IMyAirVent;if(ɣ!=null){ϔ.Add(ɣ);
if(ɖ.CustomName.Contains(ʣ)){try{string ɢ=ɖ.CustomName.Split(ʠ)[3];bool ɡ=false;foreach(Ү ɤ in Ν){if(ɢ==ɤ.ҭ){ɤ.Ҩ.Add(ɣ);ɡ=
true;break;}}if(!ɡ){Ү ɠ=new Ү();ɠ.ҭ=ɢ;ɠ.Ҩ.Add(ɣ);Ν.Add(ɠ);}}catch{if(ɾ)Echo("Error with airlock vent name "+ɖ.CustomName);}}
if(Μ)Λ.Add(ɖ,"Vent");return false;}var ɞ=ɖ as IMyCameraBlock;if(ɞ!=null){ρ.Add(ɞ);if(Μ)Λ.Add(ɖ,"Camera");return false;}var
ɝ=ɖ as IMyShipConnector;if(ɝ!=null){ω.Add(ɝ);ϡ(ɖ);if(Μ){string ɜ="";if(ν.Contains("Passageway"))ɜ=ʠ+"Passageway";Λ.Add(ɖ,
"Connector"+ɜ);}return false;}var ɛ=ɖ as IMyAirtightHangarDoor;if(ɛ!=null){Ϝ.Add(ɛ);if(Μ)Λ.Add(ɖ,"Door"+ʠ+"Hangar");return false;}
if(ν.Contains("Lidar")){var ɚ=ɖ as IMyConveyorSorter;if(ɚ!=null){ϒ.Add(ɚ);if(Μ)Λ.Add(ɖ,"LiDAR");return false;}}if(ν==
"MyObjectBuilder_OxygenGenerator/Extractor"){ϝ.Add(ɖ);if(Μ)Λ.Add(ɖ,"Extractor");return false;}if(ν=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){ϛ.Add(ɖ);if(Μ
)Λ.Add(ɖ,"Extractor");return false;}var ə=ɖ as IMyRadioAntenna;if(ə!=null){σ.Add(ə);if(Μ)Λ.Add(ɖ,"Antenna");return false;
}var ɟ=ɖ as IMyProgrammableBlock;if(ɟ!=null){if(Μ)Λ.Add(ɖ,"PB Server");if(ɟ==Me)return false;try{if(ɖ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))μ.Add(ɟ);else if(ɖ.CustomData.Contains("NavConfig"))Ω.Add(ɟ);return false;}catch{}}var
ɘ=ɖ as IMyProjector;if(ɘ!=null){ϙ.Add(ɘ);if(Μ)Λ.Add(ɖ,"Projectors");return false;}var ɦ=ɖ as IMySensorBlock;if(ɦ!=null){ϗ
.Add(ɦ);if(Μ)Λ.Add(ɖ,"Sensor");return false;}var ɱ=ɖ as IMyCollector;if(ɱ!=null){ϡ(ɖ);if(Μ)Λ.Add(ɖ,"Collector");return
false;}if(ν.Contains("Welder")){ϓ.Add(ɖ);if(Μ)Λ.Add(ɖ,"Tool"+ʠ+"Welder");return false;}if(Μ){if(ν.Contains("LandingGear/")){
if(ν.Contains("Clamp"))Λ.Add(ɖ,"Clamp");else if(ν.Contains("Magnetic"))Λ.Add(ɖ,"Mag Lock");else Λ.Add(ɖ,"Gear");return
false;}if(ν.Contains("Drill")){Λ.Add(ɖ,"Tool"+ʠ+"Drill");return false;}if(ν.Contains("Grinder")){Λ.Add(ɖ,"Tool"+ʠ+"Grinder");
return false;}if(ν.Contains("Solar")){Λ.Add(ɖ,"Solar");return false;}if(ν.Contains("ButtonPanel")){Λ.Add(ɖ,"Button Panel");
return false;}var ɰ=ɖ as IMyConveyorSorter;if(ɰ!=null){Λ.Add(ɖ,"Sorter");return false;}var ɯ=ɖ as IMyMotorSuspension;if(ɯ!=
null){Λ.Add(ɖ,"Suspension");return false;}var ɮ=ɖ as IMyGravityGenerator;if(ɮ!=null){Λ.Add(ɖ,"Grav Gen");return false;}var ɭ
=ɖ as IMyTimerBlock;if(ɭ!=null){Λ.Add(ɖ,"Timer");return false;}var ɬ=ɖ as IMyGasGenerator;if(ɬ!=null){Λ.Add(ɖ,"H2 Engine"
);return false;}var ɫ=ɖ as IMyBeacon;if(ɫ!=null){Λ.Add(ɖ,"Beacon");return false;}Λ.Add(ɖ,ɖ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ɾ){Echo("Failed to sort "+ɖ.CustomName+"\nAdded "+Λ.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɪ(){τ=null;σ.Clear();ς.Clear();ρ.Clear();π.Clear();ω.Clear();ϋ.Clear();Ξ.Clear();Ν.Clear();Ϝ.Clear();ϝ.
Clear();ϛ.Clear();Ϛ.Clear();ϙ.Clear();Ϙ.Clear();ϗ.Clear();ϖ.Clear();ϕ.Clear();ϔ.Clear();ϓ.Clear();ϒ.Clear();ϑ.Clear();ϐ.Clear
();Ϗ.Clear();ώ.Clear();ύ.Clear();ό.Clear();ξ.Clear();Ϋ.Clear();μ.Clear();Ω.Clear();Ψ.Clear();Φ.Clear();Χ.Clear();Υ.Clear(
);Τ.Clear();Ϊ.Clear();Σ.Clear();Π.Clear();Ο.Clear();foreach(var ŋ in Ϣ)ŋ.Ё.Clear();if(Μ)Λ.Clear();}bool ɩ(
IMyTerminalBlock ɖ,string Ɇ,int Ʌ){if(ɖ.CustomName.Contains(ʧ))ϐ.Add(ɖ);else ϑ.Add(ɖ);ϡ(ɖ,Ʌ);if(Μ){string ɨ="";if(ʐ)ɨ=ʠ+Ɇ;Λ.Add(ɖ,"PDC"+
ɨ);}return false;}bool ɧ(IMyTerminalBlock ɖ,string Ɇ){ώ.Add(ɖ);if(Μ){string Ʉ="";if(ʐ)Ʉ=ʠ+Ɇ;Λ.Add(ɖ,"Torpedo"+Ʉ);}return
false;}bool ɗ(IMyTerminalBlock ɖ,string Ɇ,int Ʌ){Ϗ.Add(ɖ);ϡ(ɖ,Ʌ);if(Μ){string Ʉ="";if(ʐ)Ʉ=ʠ+Ɇ;Λ.Add(ɖ,"Railgun"+Ʉ);}return
false;}г Ƀ(г ĩ,string ɂ=""){bool ɇ=ɂ=="",Ɂ=!ɇ;string ȿ=ĩ.ɉ.CustomData,Ⱦ="RSM.LCD";string[]Ƚ=null;MyIni ȼ=new MyIni();
MyIniParseResult Ɗ;if(!ɇ)Ɂ=true;else{if(ȿ.Substring(0,12)=="Show Header="){try{Ƚ=ȿ.Split('\n');foreach(string Ȼ in Ƚ){if(Ȼ.Contains(
"hud")){if(Ȼ.Contains("lcd")){ɂ=Ȼ;break;}}else if(Ȼ.Contains("=")){string[]ɀ=Ȼ.Split('=');if(ɀ[0]=="Show Tanks & Batteries")ĩ
.э=bool.Parse(ɀ[1]);else if(ɀ[0]=="Show header"||ɀ[0]=="Show Header")ĩ.о=bool.Parse(ɀ[1]);else if(ɀ[0]==
"Show Header Overlay")ĩ.ю=bool.Parse(ɀ[1]);else if(ɀ[0]=="Show Warnings")ĩ.я=bool.Parse(ɀ[1]);else if(ɀ[0]=="Show Inventory")ĩ.ь=bool.Parse(ɀ
[1]);else if(ɀ[0]=="Show Thrust")ĩ.ы=bool.Parse(ɀ[1]);else if(ɀ[0]=="Show Subsystem Integrity")ĩ.ъ=bool.Parse(ɀ[1]);else
if(ɀ[0]=="Show Advanced Thrust")ĩ.щ=bool.Parse(ɀ[1]);}}}catch(Exception ex){if(ɾ)Echo("Failed to parse legacy config.\n"+
ex.Message);Ɂ=true;}}else if(!ȼ.TryParse(ȿ,out Ɗ)){Ɂ=true;}else{ĩ.о=ȼ.Get(Ⱦ,"ShowHeader").ToBoolean(ĩ.о);ĩ.ю=ȼ.Get(Ⱦ,
"ShowHeaderOverlay").ToBoolean(ĩ.ю);ĩ.я=ȼ.Get(Ⱦ,"ShowWarnings").ToBoolean(ĩ.я);ĩ.э=ȼ.Get(Ⱦ,"ShowPowerAndTanks").ToBoolean(ĩ.э);ĩ.ь=ȼ.Get(Ⱦ,
"ShowInventory").ToBoolean(ĩ.ь);ĩ.ы=ȼ.Get(Ⱦ,"ShowThrust").ToBoolean(ĩ.ы);ĩ.ъ=ȼ.Get(Ⱦ,"ShowIntegrity").ToBoolean(ĩ.ъ);ĩ.щ=ȼ.Get(Ⱦ,
"ShowAdvancedThrust").ToBoolean(ĩ.щ);}}if(ĩ.о&&ĩ.ю){ĩ.о=false;Ɂ=true;}if(Ɂ){if(Ƚ==null)Ƚ=ȿ.Split('\n');ȼ.Set(Ⱦ,"ShowHeader",ĩ.о);ȼ.Set(Ⱦ,
"ShowHeaderOverlay",ĩ.ю);ȼ.Set(Ⱦ,"ShowWarnings",ĩ.я);ȼ.Set(Ⱦ,"ShowPowerAndTanks",ĩ.э);ȼ.Set(Ⱦ,"ShowInventory",ĩ.ь);ȼ.Set(Ⱦ,"ShowThrust",ĩ.ы
);ȼ.Set(Ⱦ,"ShowIntegrity",ĩ.ъ);ȼ.Set(Ⱦ,"ShowAdvancedThrust",ĩ.щ);ȼ.Set(Ⱦ,"Hud",ɂ);ĩ.ɉ.CustomData=ȼ.ToString();if(ɇ)п.Add(
new ш("LCD CONFIG ERROR!!","Failed to parse LCD config for "+ĩ.ɉ.CustomName+"!\nLCD config was reset!",3));}return ĩ;}void
Ⱥ(IMyTerminalBlock ɉ,bool ȩ){ɉ.GetActionWithName("ToolCore_Shoot_Action").Apply(ɉ);(ɉ as IMyConveyorSorter).
GetActionWithName("ToolCore_Shoot_Action").Apply(ɉ);}void ɕ(){List<IMyTerminalBlock>ɔ=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(ɔ);string ɓ="";foreach(IMyTerminalBlock ɒ in ɔ){ɓ+=ɒ.BlockDefinition+"\n";}if(σ.Count>0&&σ[0]!=null){
σ[0].CustomData=ɓ;}}void ɑ(string Ȣ){IMyTerminalBlock ɉ=GridTerminalSystem.GetBlockWithName(Ȣ);List<ITerminalAction>ɐ=new
List<ITerminalAction>();ɉ.GetActions(ɐ);List<ITerminalProperty>ɏ=new List<ITerminalProperty>();ɉ.GetProperties(ɏ);string Ɏ=ɉ
.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction ɍ in ɐ){Ɏ+=ɍ.Id+" "+ɍ.Name+"\n";}Ɏ+="\n\n**Properties**\n\n";
foreach(ITerminalProperty Ɍ in ɏ){Ɏ+=Ɍ.Id+" "+Ɍ.TypeName+"\n";}if(σ.Count>0&&σ[0]!=null)σ[0].CustomData=Ɏ;ɉ.CustomData=Ɏ;}void
ɋ(IMyTerminalBlock Ƣ){bool Ɋ=Ƣ.GetValue<bool>("WC_Repel");if(!Ɋ)Ƣ.ApplyAction("WC_RepelMode");}void Ɉ(IMyTerminalBlock Ƣ)
{bool Ɋ=Ƣ.GetValue<bool>("WC_Repel");if(Ɋ)Ƣ.ApplyAction("WC_RepelMode");}void ʞ(IMyTerminalBlock Ƣ){try{if(Ǣ.Ɠ(Ƣ,0)==
VRageMath.Matrix.Zero)return;Ƣ.SetValue<Int64>("WC_Shoot Mode",3);if(ɾ)Echo("Shoot mode = "+Ƣ.GetValue<Int64>("WC_Shoot Mode"));}
catch{Echo("Failed to set fire mode to manual on "+Ƣ.CustomName);}}void ʜ(IMyTerminalBlock Ƣ){try{if(Ǣ.Ɠ(Ƣ,0)==VRageMath.
Matrix.Zero)return;Ƣ.SetValue<Int64>("WC_Shoot Mode",0);if(ɾ)Echo("Shoot mode = "+Ƣ.GetValue<Int64>("WC_Shoot Mode"));}catch{
Echo("Failed to set fire mode to auto on "+Ƣ.CustomName);}}void ʛ(){if(τ!=null){try{Ή=τ.GetShipSpeed();Θ=τ.CalculateShipMass
().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo(exxie.Message);}}}double ʚ=0;double
ʙ=0;double ʘ=0;void ʗ(){ʙ=0;foreach(IMyCargoContainer ʕ in π){if(ʕ!=null&&ʕ.IsFunctional){ʙ+=ʕ.GetInventory().MaxVolume.
RawValue;}}ʘ=Math.Round(100*(ʙ/ʚ));}void ʖ(){ʚ=0;foreach(IMyCargoContainer ʕ in π){if(ʕ!=null)ʚ+=ʕ.GetInventory().MaxVolume.
RawValue;}}MyIni ʔ=new MyIni();bool ʓ=false;bool ʒ=true;bool ʑ=true;bool ʝ=true;bool ʟ=true;bool ʰ=true;bool ʱ=false;string ʯ=""
;bool ʮ=true;int ʭ=3;int ʬ=6;string ʫ="[I]";string ʪ="[RSM]";string ʩ="[CS]";string ʨ="Autorepair";string ʧ="Repel";
string ʦ="Min";string ʥ="Docking";string ʤ="Nav";string ʣ="Airlock";string ʢ="[EFC]";string ʡ="[NavOS]";char ʠ='.';bool ʐ=true
;bool ɿ=true;List<string>ʎ=new List<string>();bool ɽ=false;bool ɼ=false;bool ɻ=true;List<double>ɺ=new List<double>();bool
ɹ=false;double ɸ=0.5;bool ɾ=true;bool ɷ=false;int ɵ=0;int ɴ=100;string ɳ="";bool ɲ(){string ȿ=Me.CustomData;string Ⱦ="";
bool ɶ=true;MyIniParseResult Ɗ;if(!ʔ.TryParse(ȿ,out Ɗ)){string[]ʀ=ȿ.Split('\n');if(ʀ[1]=="Reedit Ship Management"){Echo(
"Legacy config detected...");Ѩ(ȿ);return false;}else{Echo("Could not parse custom data!\n"+Ɗ.ToString());return false;}}try{Ⱦ="RSM.Main";Echo(Ⱦ);ʓ=
ʔ.Get(Ⱦ,"RequireShipName").ToBoolean(ʓ);ʒ=ʔ.Get(Ⱦ,"EnableAutoload").ToBoolean(ʒ);ʑ=ʔ.Get(Ⱦ,"AutoloadReactors").ToBoolean(
ʑ);ʝ=ʔ.Get(Ⱦ,"AutoConfigWeapons").ToBoolean(ʝ);ʟ=ʔ.Get(Ⱦ,"SetTurretFireMode").ToBoolean(ʟ);ʰ=ʔ.Get(Ⱦ,
"ManageBatteryDischarge").ToBoolean(ʰ);Ⱦ="RSM.Spawns";Echo(Ⱦ);ʱ=ʔ.Get(Ⱦ,"PrivateSpawns").ToBoolean(ʱ);ʯ=ʔ.Get(Ⱦ,"FriendlyTags").ToString(ʯ);Ⱦ=
"RSM.Doors";Echo(Ⱦ);ʮ=ʔ.Get(Ⱦ,"EnableDoorManagement").ToBoolean(ʮ);ʭ=ʔ.Get(Ⱦ,"DoorCloseTimer").ToInt32(ʭ);ʭ=ʔ.Get(Ⱦ,
"AirlockDoorDisableTimer").ToInt32(ʭ);Ⱦ="RSM.Keywords";Echo(Ⱦ);ʫ=ʔ.Get(Ⱦ,"Ignore").ToString(ʫ);ʪ=ʔ.Get(Ⱦ,"RsmLcds").ToString(ʪ);ʩ=ʔ.Get(Ⱦ,
"ColourSyncLcds").ToString(ʩ);ʨ=ʔ.Get(Ⱦ,"AuxiliaryBlocks").ToString(ʨ);ʧ=ʔ.Get(Ⱦ,"DefensivePdcs").ToString(ʧ);ʦ=ʔ.Get(Ⱦ,
"MinimumThrusters").ToString(ʦ);ʥ=ʔ.Get(Ⱦ,"DockingThrusters").ToString(ʥ);ʤ=ʔ.Get(Ⱦ,"NavLights").ToString(ʤ);ʣ=ʔ.Get(Ⱦ,"Airlock").ToString
(ʣ);Ⱦ="RSM.InitNaming";Echo(Ⱦ);ʠ=ʔ.Get(Ⱦ,"Ignore").ToChar(ʠ);ʐ=ʔ.Get(Ⱦ,"NameWeaponTypes").ToBoolean(ʐ);ɿ=ʔ.Get(Ⱦ,
"NameDriveTypes").ToBoolean(ɿ);string ʏ=ʔ.Get(Ⱦ,"BlocksToNumber").ToString("");string[]ʍ=ʏ.Split(',');ʎ.Clear();foreach(string Ȣ in ʍ)if
(Ȣ!="")ʎ.Add(Ȣ);Ⱦ="RSM.Misc";Echo(Ⱦ);ɽ=ʔ.Get(Ⱦ,"DisableLightingControl").ToBoolean(ɽ);ɼ=ʔ.Get(Ⱦ,"DisableLcdColourControl"
).ToBoolean(ɼ);ɻ=ʔ.Get(Ⱦ,"ShowBasicTelemetry").ToBoolean(ɻ);string ʌ=ʔ.Get(Ⱦ,"DecelerationPercentages").ToString("");
string[]ʋ=ʌ.Split(',');if(ʋ.Length>1){ɺ.Clear();foreach(string ʊ in ʋ){ɺ.Add(double.Parse(ʊ)/100);}}ɹ=ʔ.Get(Ⱦ,
"ShowThrustInMetric").ToBoolean(ɹ);ɸ=ʔ.Get(Ⱦ,"ReactorFillRatio").ToDouble(ɸ);Ϣ[0].ϣ=ɸ;Ⱦ="RSM.Debug";Echo(Ⱦ);ɾ=ʔ.Get(Ⱦ,"VerboseDebugging").
ToBoolean(ɾ);ɷ=ʔ.Get(Ⱦ,"RuntimeProfiling").ToBoolean(ɷ);ɴ=ʔ.Get(Ⱦ,"BlockRefreshFreq").ToInt32(ɴ);ɵ=ʔ.Get(Ⱦ,"StallCount").ToInt32(
ɵ);Ⱦ="RSM.System";Echo(Ⱦ);ɳ=ʔ.Get(Ⱦ,"ShipName").ToString(ɳ);Ⱦ="RSM.InitItems";Echo(Ⱦ);foreach(ŋ ʉ in Ϣ){ʉ.Є=ʔ.Get(Ⱦ,ʉ.ϥ.
SubtypeId).ToInt32(ʉ.Є);}Ⱦ="RSM.InitSubSystems";Echo(Ⱦ);L=ʔ.Get(Ⱦ,"Reactors").ToDouble(L);L=ʔ.Get(Ⱦ,"Batteries").ToDouble(L);u=ʔ.
Get(Ⱦ,"Pdcs").ToInt32(u);ȇ=ʔ.Get(Ⱦ,"TorpLaunchers").ToInt32(ȇ);o=ʔ.Get(Ⱦ,"KineticWeapons").ToInt32(o);Ú=ʔ.Get(Ⱦ,"H2Storage"
).ToDouble(Ú);Ð=ʔ.Get(Ⱦ,"O2Storage").ToDouble(Ð);ç=ʔ.Get(Ⱦ,"MainThrust").ToSingle(ç);Ǻ=ʔ.Get(Ⱦ,"RCSThrust").ToSingle(Ǻ);қ
=ʔ.Get(Ⱦ,"Gyros").ToDouble(қ);ʚ=ʔ.Get(Ⱦ,"CargoStorage").ToDouble(ʚ);ơ=ʔ.Get(Ⱦ,"Welders").ToInt32(ơ);}catch(Exception ex){
Ѣ(ex,"Failed to parse section\n"+Ⱦ);}Echo("Parsing stances...");Dictionary<string,X>ʈ=new Dictionary<string,X>();List<
string>ʇ=new List<string>();ʔ.GetSections(ʇ);foreach(string ʆ in ʇ){if(ʆ.Contains("RSM.Stance.")){string ʅ=ʆ.Substring(11);
Echo(ʅ);X ë=new X();string ʄ,ʃ="";string[]ʂ;int ʁ=33,ˈ=144,ɖ=255,Ę=255;bool ѱ=false;X ѩ=null;ʃ="Inherits";if(ʔ.ContainsKey(ʆ
,ʃ)){ѱ=true;try{ѩ=ʈ[ʔ.Get(ʆ,ʃ).ToString()];Echo("Inherits "+ʔ.Get(ʆ,ʃ).ToString());}catch(Exception ex){Ѣ(ex,
"Failed to find inheritee for\n"+ʆ+"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(ѱ)Echo(ѩ.V.ToString());ʃ="Torps";if(ʔ.
ContainsKey(ʆ,ʃ)){ë.V=(Ɯ)Enum.Parse(typeof(Ɯ),ʔ.Get(ʆ,ʃ).ToString());Echo("1");}else if(ѱ){ë.V=ѩ.V;Echo("2");}else{ë.V=ÿ;Echo("3");
}ʃ="Pdcs";if(ʔ.ContainsKey(ʆ,ʃ))ë.U=(Ǎ)Enum.Parse(typeof(Ǎ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.U=ѩ.U;else ë.U=ā;ʃ=
"Kinetics";if(ʔ.ContainsKey(ʆ,ʃ))ë.S=(ǌ)Enum.Parse(typeof(ǌ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.S=ѩ.S;else ë.S=Ē;ʃ="MainThrust";if
(ʔ.ContainsKey(ʆ,ʃ))ë.P=(ǎ)Enum.Parse(typeof(ǎ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.P=ѩ.P;else ë.P=ē;ʃ="ManeuveringThrust"
;if(ʔ.ContainsKey(ʆ,ʃ))ë.R=(ǐ)Enum.Parse(typeof(ǐ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.R=ѩ.R;else ë.R=đ;ʃ="Spotlights";if(
ʔ.ContainsKey(ʆ,ʃ))ë.Î=(Ǐ)Enum.Parse(typeof(Ǐ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.Î=ѩ.Î;else ë.Î=Đ;ʃ="ExteriorLights";if(
ʔ.ContainsKey(ʆ,ʃ))ë.Ā=(Ƹ)Enum.Parse(typeof(Ƹ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.Ā=ѩ.Ā;else ë.Ā=ď;ʃ=
"ExteriorLightColour";if(ʔ.ContainsKey(ʆ,ʃ)){ʄ=ʔ.Get(ʆ,ʃ).ToString();ʂ=ʄ.Split(',');ʁ=int.Parse(ʂ[0]);ˈ=int.Parse(ʂ[1]);ɖ=int.Parse(ʂ[2]);Ę=
int.Parse(ʂ[3]);ë.þ=new Color(ʁ,ˈ,ɖ,Ę);}else if(ѱ)ë.þ=ѩ.þ;else ë.þ=Ď;ʃ="InteriorLights";if(ʔ.ContainsKey(ʆ,ʃ))ë.ý=(Ƹ)Enum.
Parse(typeof(Ƹ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.ý=ѩ.ý;else ë.ý=č;ʃ="InteriorLightColour";if(ʔ.ContainsKey(ʆ,ʃ)){ʄ=ʔ.Get(ʆ,
ʃ).ToString();ʂ=ʄ.Split(',');ʁ=int.Parse(ʂ[0]);ˈ=int.Parse(ʂ[1]);ɖ=int.Parse(ʂ[2]);Ę=int.Parse(ʂ[3]);ë.ü=new Color(ʁ,ˈ,ɖ,
Ę);}else if(ѱ)ë.ü=ѩ.ü;else ë.ü=Č;ʃ="NavLights";if(ʔ.ContainsKey(ʆ,ʃ))ë.û=(Ƹ)Enum.Parse(typeof(Ƹ),ʔ.Get(ʆ,ʃ).ToString());
else if(ѱ)ë.û=ѩ.û;else ë.û=ċ;ʃ="LcdTextColour";if(ʔ.ContainsKey(ʆ,ʃ)){ʄ=ʔ.Get(ʆ,ʃ).ToString();ʂ=ʄ.Split(',');ʁ=int.Parse(ʂ[0
]);ˈ=int.Parse(ʂ[1]);ɖ=int.Parse(ʂ[2]);Ę=int.Parse(ʂ[3]);ë.ú=new Color(ʁ,ˈ,ɖ,Ę);}else if(ѱ)ë.ú=ѩ.ú;else ë.ú=Ċ;ʃ=
"TanksAndBatteries";if(ʔ.ContainsKey(ʆ,ʃ))ë.ù=(ǋ)Enum.Parse(typeof(ǋ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.ù=ѩ.ù;else ë.ù=ĉ;ʃ=
"NavOsEfcBurnPercentage";if(ʔ.ContainsKey(ʆ,ʃ))ë.ø=ʔ.Get(ʆ,"NavOsEfcBurnPercentage").ToInt32(Ĉ);else if(ѱ)ë.ø=ѩ.ø;else ë.ø=Ĉ;ʃ="EfcBoost";if(ʔ.
ContainsKey(ʆ,ʃ))ë.ö=(Ɯ)Enum.Parse(typeof(Ɯ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.ö=ѩ.ö;else ë.ö=ć;ʃ="NavOsAbortEfcOff";if(ʔ.
ContainsKey(ʆ,ʃ))ë.õ=(ƽ)Enum.Parse(typeof(ƽ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.õ=ѩ.õ;else ë.õ=Ć;ʃ="NavOsAbortEfcOff";if(ʔ.
ContainsKey(ʆ,ʃ))ë.õ=(ƽ)Enum.Parse(typeof(ƽ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.õ=ѩ.õ;else ë.õ=Ć;ʃ="AuxMode";if(ʔ.ContainsKey(ʆ,ʃ))
ë.ô=(Ɯ)Enum.Parse(typeof(Ɯ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.ô=ѩ.ô;else ë.ô=ą;ʃ="Extractor";if(ʔ.ContainsKey(ʆ,ʃ))ë.ó=(
Ƽ)Enum.Parse(typeof(Ƽ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.ó=ѩ.ó;else ë.ó=Ą;ʃ="KeepAlives";if(ʔ.ContainsKey(ʆ,ʃ))ë.ò=(Ɯ)
Enum.Parse(typeof(Ɯ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.ò=ѩ.ò;else ë.ò=ă;ʃ="HangarDoors";if(ʔ.ContainsKey(ʆ,ʃ))ë.ñ=(ƺ)Enum.
Parse(typeof(ƺ),ʔ.Get(ʆ,ʃ).ToString());else if(ѱ)ë.ñ=ѩ.ñ;else ë.ñ=Ă;ʈ.Add(ʅ,ë);}catch(Exception ex){Ѣ(ex,
"Failed to parse stance\n"+ʅ+"\nproperty\n"+ʃ);}}}if(ʈ.Count<1){Echo("Failed to parse any stances!\nStances reset to default!");ɶ=false;}else{Echo
("Finished parsing "+ʈ.Count+" stances.");ѝ=ʈ;}Ⱦ="RSM.Stance";Echo(Ⱦ);ð=ʔ.Get(Ⱦ,"CurrentStance").ToString(ð);X Ѱ;if(!ѝ.
TryGetValue(ð,out Ѱ)){ð="N/A";ï=null;}else ï=Ѱ;return ɶ;}void ѯ(){ʔ.Clear();string Ⱦ,Ȣ;Ⱦ="RSM.Main";Ȣ="RequireShipName";ʔ.Set(Ⱦ,Ȣ,ʓ
);ʔ.SetComment(Ⱦ,Ȣ,"limit to blocks with the ship name in their name");Ȣ="EnableAutoload";ʔ.Set(Ⱦ,Ȣ,ʒ);ʔ.SetComment(Ⱦ,Ȣ,
"enable RSM loading & balancing functionality for weapons");Ȣ="AutoloadReactors";ʔ.Set(Ⱦ,Ȣ,ʑ);ʔ.SetComment(Ⱦ,Ȣ,"enable loading and balancing for reactors");Ȣ="AutoConfigWeapons";
ʔ.Set(Ⱦ,Ȣ,ʝ);ʔ.SetComment(Ⱦ,Ȣ,"automatically configure weapon on stance set");Ȣ="SetTurretFireMode";ʔ.Set(Ⱦ,Ȣ,ʟ);ʔ.
SetComment(Ⱦ,Ȣ,"set turret fire mode based on stance");Ȣ="ManageBatteryDischarge";ʔ.Set(Ⱦ,Ȣ,ʰ);ʔ.SetComment(Ⱦ,Ȣ,
"set batteries to discharge on active railgun/coilgun target");ʔ.SetSectionComment(Ⱦ,а+" Reedit Ship Management\n"+а+" Config.ini\n Recompile to apply changes!\n"+а);Ⱦ="RSM.Spawns";
Ȣ="PrivateSpawns";ʔ.Set(Ⱦ,Ȣ,ʱ);ʔ.SetComment(Ⱦ,Ȣ,"don't inject faction tag into spawn custom data");Ȣ="FriendlyTags";ʔ.Set
(Ⱦ,Ȣ,ʯ);ʔ.SetComment(Ⱦ,Ȣ,"Comma seperated friendly factions or steam ids");Ⱦ="RSM.Doors";Ȣ="EnableDoorManagement";ʔ.Set(Ⱦ
,Ȣ,ʮ);ʔ.SetComment(Ⱦ,Ȣ,"enable door management functionality");Ȣ="DoorCloseTimer";ʔ.Set(Ⱦ,Ȣ,ʭ);ʔ.SetComment(Ⱦ,Ȣ,
"door open timer (x100 ticks)");Ȣ="AirlockDoorDisableTimer";ʔ.Set(Ⱦ,Ȣ,ʬ);ʔ.SetComment(Ⱦ,Ȣ,"airlock door disable timer (x100 ticks)");Ⱦ="RSM.Keywords";
Ȣ="Ignore";ʔ.Set(Ⱦ,Ȣ,ʫ);ʔ.SetComment(Ⱦ,Ȣ,"to identify blocks which RSM should ignore");Ȣ="RsmLcds";ʔ.Set(Ⱦ,Ȣ,ʪ);ʔ.
SetComment(Ⱦ,Ȣ,"to identify RSM lcds");Ȣ="ColourSyncLcds";ʔ.Set(Ⱦ,Ȣ,ʩ);ʔ.SetComment(Ⱦ,Ȣ,"to identify non RSM lcds for colour sync"
);Ȣ="AuxiliaryBlocks";ʔ.Set(Ⱦ,Ȣ,ʨ);ʔ.SetComment(Ⱦ,Ȣ,"to identify aux blocks");Ȣ="DefensivePdcs";ʔ.Set(Ⱦ,Ȣ,ʧ);ʔ.SetComment
(Ⱦ,Ȣ,"to identify defensive _normalPdcs");Ȣ="MinimumThrusters";ʔ.Set(Ⱦ,Ȣ,ʦ);ʔ.SetComment(Ⱦ,Ȣ,
"to identify minimum epsteins");Ȣ="DockingThrusters";ʔ.Set(Ⱦ,Ȣ,ʥ);ʔ.SetComment(Ⱦ,Ȣ,"to identify docking epsteins");Ȣ="NavLights";ʔ.Set(Ⱦ,Ȣ,ʤ);ʔ.
SetComment(Ⱦ,Ȣ,"to identify navigational lights");Ȣ="Airlock";ʔ.Set(Ⱦ,Ȣ,ʣ);ʔ.SetComment(Ⱦ,Ȣ,"to identify airlock doors and vents")
;Ⱦ="RSM.InitNaming";Ȣ="NameDelimiter";ʔ.Set(Ⱦ,Ȣ,ʠ.ToString());ʔ.SetComment(Ⱦ,Ȣ,"single char delimiter for names");Ȣ=
"NameWeaponTypes";ʔ.Set(Ⱦ,Ȣ,ʐ);ʔ.SetComment(Ⱦ,Ȣ,"append type names to all weapons on init");Ȣ="NameDriveTypes";ʔ.Set(Ⱦ,Ȣ,ɿ);ʔ.SetComment(
Ⱦ,Ȣ,"append type names to all drives on init");string Ѯ="";foreach(string ѭ in ʎ){if(Ѯ!="")Ѯ+=",";Ѯ+=ѭ;}Ȣ=
"BlocksToNumber";ʔ.Set(Ⱦ,Ȣ,ɿ);ʔ.SetComment(Ⱦ,Ȣ,"comma seperated list of block names to be numbered at init");Ⱦ="RSM.Misc";Ȣ=
"DisableLightingControl";ʔ.Set(Ⱦ,Ȣ,ɽ);ʔ.SetComment(Ⱦ,Ȣ,"disable all lighting control");Ȣ="DisableLcdColourControl";ʔ.Set(Ⱦ,Ȣ,ɼ);ʔ.SetComment(Ⱦ,Ȣ
,"disable text colour control for all lcds");Ȣ="ShowBasicTelemetry";ʔ.Set(Ⱦ,Ȣ,ɻ);ʔ.SetComment(Ⱦ,Ȣ,
"show basic telemetry data on advanced thrust lcds");string Ѭ="";foreach(double ĭ in ɺ){if(Ѭ!="")Ѭ+=",";Ѭ+=(ĭ*100).ToString();}Ȣ="DecelerationPercentages";ʔ.Set(Ⱦ,Ȣ,Ѭ);ʔ.
SetComment(Ⱦ,Ȣ,"thrust percentages to show on advanced thrust lcds");Ȣ="ShowThrustInMetric";ʔ.Set(Ⱦ,Ȣ,ɹ);ʔ.SetComment(Ⱦ,Ȣ,
"show basic telemetry data on advanced thrust lcds");Ȣ="ReactorFillRatio";ʔ.Set(Ⱦ,Ȣ,ɸ);ʔ.SetComment(Ⱦ,Ȣ,"0-1, fill ratio for reactors");Ⱦ="RSM.Debug";Ȣ="VerboseDebugging";
ʔ.Set(Ⱦ,Ȣ,ɾ);ʔ.SetComment(Ⱦ,Ȣ,"prints more logging info to PB details");Ȣ="RuntimeProfiling";ʔ.Set(Ⱦ,Ȣ,ɷ);ʔ.SetComment(Ⱦ,
Ȣ,"prints script runtime profiling info to PB details");Ȣ="BlockRefreshFreq";ʔ.Set(Ⱦ,Ȣ,ɴ);ʔ.SetComment(Ⱦ,Ȣ,
"ticks x100 between block refreshes");Ȣ="StallCount";ʔ.Set(Ⱦ,Ȣ,ɵ);ʔ.SetComment(Ⱦ,Ȣ,"ticks x100 to stall between runs");Ⱦ="RSM.Stance";Ȣ="CurrentStance";ʔ.
Set(Ⱦ,Ȣ,ð);ʔ.SetSectionComment(Ⱦ,а+" Stances\n Add or remove as required\n"+а);string ѫ="Red, Green, Blue, Alpha";foreach(
var Ѫ in ѝ){Ⱦ="RSM.Stance."+Ѫ.Key;X Ý=Ѫ.Value;X ѩ=null;if(Ý.W!=""){ѩ=ѝ[Ý.W];Ȣ="Inherits";ʔ.Set(Ⱦ,Ȣ,Ý.W);ʔ.SetComment(Ⱦ,Ȣ,
"Use stance of this name as a template for settings");}Ȣ="Torps";if(ѩ!=null&&Ý.V==ѩ.V){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.V.ToString());ʔ.SetComment(Ⱦ,Ȣ,
ё(typeof(Ɯ)));}Ȣ="Pdcs";if(ѩ!=null&&Ý.U==ѩ.U){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.U.ToString());ʔ.
SetComment(Ⱦ,Ȣ,ё(typeof(Ǎ)));}Ȣ="Kinetics";if(ѩ!=null&&Ý.S==ѩ.S){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.S.ToString(
));ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(ǌ)));}Ȣ="MainThrust";if(ѩ!=null&&Ý.P==ѩ.P){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ
,Ȣ,Ý.P.ToString());ʔ.SetComment(Ⱦ,"MainThrust",ё(typeof(ǎ)));}Ȣ="ManeuveringThrust";if(ѩ!=null&&Ý.R==ѩ.R){if(ʔ.
ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.R.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(ǐ)));}Ȣ="Spotlights";if(ѩ!=null&&Ý.Î==ѩ.Î)
{if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.Î.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(Ǐ)));}Ȣ="ExteriorLights";
if(ѩ!=null&&Ý.Ā==ѩ.Ā){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.Ā.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(Ƹ)));}
Ȣ="ExteriorLightColour";if(ѩ!=null&&Ý.þ==ѩ.þ){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,ѣ(Ý.þ));ʔ.SetComment(Ⱦ,
Ȣ,ѫ);}Ȣ="InteriorLights";if(ѩ!=null&&Ý.ý==ѩ.ý){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.ý.ToString());ʔ.
SetComment(Ⱦ,Ȣ,ё(typeof(Ƹ)));}Ȣ="InteriorLightColour";if(ѩ!=null&&Ý.ü==ѩ.ü){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,ѣ(
Ý.ü));ʔ.SetComment(Ⱦ,Ȣ,ѫ);}Ȣ="NavLights";if(ѩ!=null&&Ý.û==ѩ.û){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.û.
ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(Ƹ)));}Ȣ="LcdTextColour";if(ѩ!=null&&Ý.ú==ѩ.ú){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.
Set(Ⱦ,Ȣ,ѣ(Ý.ú));ʔ.SetComment(Ⱦ,Ȣ,ѫ);}Ȣ="TanksAndBatteries";if(ѩ!=null&&Ý.ù==ѩ.ù){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{
ʔ.Set(Ⱦ,Ȣ,Ý.ù.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(ǋ)));}Ȣ="NavOsEfcBurnPercentage";if(ѩ!=null&&Ý.ø==ѩ.ø){if(ʔ.
ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.ø.ToString());ʔ.SetComment(Ⱦ,Ȣ,"Burn % 0-100, -1 for no change");}Ȣ="EfcBoost";if(
ѩ!=null&&Ý.ö==ѩ.ö){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.ö.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(Ɯ)));}Ȣ=
"NavOsAbortEfcOff";if(ѩ!=null&&Ý.õ==ѩ.õ){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.õ.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(ƽ))
);}Ȣ="AuxMode";if(ѩ!=null&&Ý.ô==ѩ.ô){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.ô.ToString());ʔ.SetComment(Ⱦ,Ȣ
,ё(typeof(Ɯ)));}Ȣ="Extractor";if(ѩ!=null&&Ý.ó==ѩ.ó){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý.ó.ToString());ʔ
.SetComment(Ⱦ,Ȣ,ё(typeof(Ƽ)));}Ȣ="KeepAlives";if(ѩ!=null&&Ý.ò==ѩ.ò){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);}else{ʔ.Set(Ⱦ,Ȣ,Ý
.ò.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(Ɯ)));}Ȣ="HangarDoors";if(ѩ!=null&&Ý.ñ==ѩ.ñ){if(ʔ.ContainsKey(Ⱦ,Ȣ))ʔ.Delete(Ⱦ,Ȣ);
}else{ʔ.Set(Ⱦ,Ȣ,Ý.ñ.ToString());ʔ.SetComment(Ⱦ,Ȣ,ё(typeof(ƺ)));}}Ⱦ="RSM.System";Ȣ="ShipName";ʔ.Set(Ⱦ,Ȣ,ɳ);ʔ.
SetSectionComment(Ⱦ,а+" System\n All items below this point are\n set automatically when running init\n"+а);Ⱦ="RSM.InitItems";foreach(ŋ ʉ
in Ϣ){Ȣ=ʉ.ϥ.SubtypeId;ʔ.Set(Ⱦ,Ȣ,ʉ.Є);}Ⱦ="RSM.InitSubSystems";ʔ.Set(Ⱦ,"Reactors",L);ʔ.Set(Ⱦ,"Batteries",L);ʔ.Set(Ⱦ,"Pdcs",u
);ʔ.Set(Ⱦ,"TorpLaunchers",ȇ);ʔ.Set(Ⱦ,"KineticWeapons",o);ʔ.Set(Ⱦ,"H2Storage",Ú);ʔ.Set(Ⱦ,"O2Storage",Ð);ʔ.Set(Ⱦ,
"MainThrust",ç);ʔ.Set(Ⱦ,"RCSThrust",Ǻ);ʔ.Set(Ⱦ,"Gyros",қ);ʔ.Set(Ⱦ,"CargoStorage",ʚ);ʔ.Set(Ⱦ,"Welders",ơ);Me.CustomData=ʔ.ToString();
}void Ѩ(string ȿ){string[]ʇ=ȿ.Split(new string[]{"[Stances]"},StringSplitOptions.None);string[]ѻ=ʇ[0].Split('\n');string
Ѽ=ʇ[1];try{for(int ė=1;ė<ѻ.Length;ė++){if(ѻ[ė].Contains("=")){string Ѻ=ѻ[ė].Substring(1);switch(ѻ[(ė-1)]){case
"Ship name. Blocks without this name will be ignored":ɳ=Ѻ;break;case"Block name delimiter, used by init. One character only!":ʠ=char.Parse(Ѻ.Substring(0,1));break;case
"Keyword used to identify RSM _allLcds.":ʪ=Ѻ;break;case"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʨ=Ѻ;break;
case"Keyword used to identify defence _normalPdcs.":ʧ=Ѻ;break;case"Keyword used to identify minimum epstein drives.":ʦ=Ѻ;
break;case"Keyword used to identify docking epstein drives.":ʥ=Ѻ;break;case"Keyword to ignore block.":ʫ=Ѻ;break;case
"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʝ=bool.Parse(Ѻ);break;case"Disable lighting all control.":ɽ=bool.Parse(Ѻ);break;case
"Disable LCD Text Colour Enforcement.":ɼ=bool.Parse(Ѻ);break;case"Enable Weapon Autoload Functionality.":ʒ=bool.Parse(Ѻ);break;case
"Number these blocks at init.":ʎ.Clear();string[]ѹ=Ѻ.Split(',');foreach(string ѭ in ѹ){if(ѭ!="")ʎ.Add(ѭ);}break;case
"Add type names to weapons at init.":ʐ=bool.Parse(Ѻ);break;case"Only set batteries to discharge on active railgun/coilgun target.":ʰ=bool.Parse(Ѻ);break;
case"Show basic telemetry.":ɻ=bool.Parse(Ѻ);break;case"Show Decel Percentages (comma seperated).":ɺ.Clear();string[]Ѹ=Ѻ.
Split(',');foreach(string ĭ in Ѹ){ɺ.Add(double.Parse(ĭ)/100);}break;case"Fusion Fuel count":Ϣ[0].Є=int.Parse(Ѻ);break;case
"Fuel tank count":Ϣ[1].Є=int.Parse(Ѻ);break;case"Jerry can count":Ϣ[2].Є=int.Parse(Ѻ);break;case"40mm PDC Magazine count":Ϣ[3].Є=int.
Parse(Ѻ);break;case"40mm Teflon Tungsten PDC Magazine count":Ϣ[4].Є=int.Parse(Ѻ);break;case"220mm Torpedo count":case
"Torpedo count":Ϣ[5].Є=int.Parse(Ѻ);break;case"220mm MCRN torpedo count":Ϣ[6].Є=int.Parse(Ѻ);break;case"220mm UNN torpedo count":Ϣ[7].Є
=int.Parse(Ѻ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":Ϣ[8].Є=int.Parse(Ѻ);break;case
"Large ramshacke torpedo count":Ϣ[9].Є=int.Parse(Ѻ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":Ϣ[10].Є=int.Parse(Ѻ);break;
case"Dawson 100mm UNN Railgun rounds count":Ϣ[11].Є=int.Parse(Ѻ);break;case"Stiletto 100mm MCRN Railgun rounds count":Ϣ[12].
Є=int.Parse(Ѻ);break;case"T-47 80mm Railgun rounds count":Ϣ[13].Є=int.Parse(Ѻ);break;case
"Foehammer 120mm MCRN rounds count":Ϣ[14].Є=int.Parse(Ѻ);break;case"Farren 120mm UNN Railgun rounds count":Ϣ[15].Є=int.Parse(Ѻ);break;case
"Kess 180mm rounds count":Ϣ[16].Є=int.Parse(Ѻ);break;case"Steel plate count":Ϣ[17].Є=int.Parse(Ѻ);break;case
"Doors open timer (x100 ticks, default 3)":ʭ=int.Parse(Ѻ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ʬ=int.Parse(Ѻ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":ɵ=int.Parse(Ѻ);break;case"Full refresh frequency (x100 ticks, default 50)":ɴ=int.Parse(Ѻ);break;case
"Verbose script debugging. Prints more logging info to PB details.":ɾ=bool.Parse(Ѻ);break;case"Private spawn (don't inject faction tag into SK custom data).":ʱ=bool.Parse(Ѻ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":ʯ=string.Join("\n",Ѻ.Split(','));break;case"Current Stance":ð=Ѻ;X Ѱ;if(!ѝ.TryGetValue(ð,out Ѱ)){ð="N/A";ï=null;}else ï=
Ѱ;break;case"Reactor Integrity":L=float.Parse(Ѻ);break;case"Battery Integrity":Æ=float.Parse(Ѻ);break;case"PDC Integrity"
:u=int.Parse(Ѻ);break;case"Torpedo Integrity":ȇ=int.Parse(Ѻ);break;case"Railgun Integrity":o=int.Parse(Ѻ);break;case
"H2 Tank Integrity":Ú=double.Parse(Ѻ);break;case"O2 Tank Integrity":Ð=double.Parse(Ѻ);break;case"Epstein Integrity":ç=float.Parse(Ѻ);break;
case"RCS Integrity":Ǻ=float.Parse(Ѻ);break;case"Gyro Integrity":қ=int.Parse(Ѻ);break;case"Cargo Integrity":ʚ=double.Parse(Ѻ)
;break;case"Welder Integrity":ơ=int.Parse(Ѻ);break;}}}}catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);
}try{string[]ѷ=Ѽ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(ɾ)Echo("Parsing "+(ѷ.Length-1)+" stances");int
Ѷ=24;Dictionary<string,X>ʈ=new Dictionary<string,X>();int[]ѵ=new int[]{0,5,25,50,75,100};for(int ė=1;ė<ѷ.Length;ė++){
string[]Ѵ=ѷ[ė].Split('=');string ʅ="";int[]ѳ=new int[Ѷ];ʅ=Ѵ[0].Split(' ')[0];if(ɾ)Echo("Parsing '"+ʅ+"'");for(int Ѳ=0;Ѳ<ѳ.
Length;Ѳ++){string[]Ѧ=Ѵ[(Ѳ+1)].Split('\n');ѳ[Ѳ]=int.Parse(Ѧ[0]);}X ë=new X();if(ѳ[0]==0)ë.V=Ɯ.Off;else ë.V=Ɯ.On;if(ѳ[1]==0)ë.U
=Ǎ.Off;else if(ѳ[1]==1)ë.U=Ǎ.MinDefence;else if(ѳ[1]==2)ë.U=Ǎ.AllDefence;else if(ѳ[1]==3)ë.U=Ǎ.Offence;else if(ѳ[1]==4)ë.
U=Ǎ.AllOnOnly;if(ѳ[2]==0)ë.S=ǌ.Off;else if(ѳ[2]==1)ë.S=ǌ.HoldFire;else if(ѳ[2]==2)ë.S=ǌ.OpenFire;if(ѳ[3]==0)ë.P=ǎ.Off;
else if(ѳ[3]==1)ë.P=ǎ.On;else if(ѳ[3]==2)ë.P=ǎ.Minimum;if(ѳ[4]==0)ë.R=ǐ.Off;else if(ѳ[4]==1)ë.R=ǐ.On;else if(ѳ[4]==2)ë.R=ǐ.
ForwardOff;else if(ѳ[4]==3)ë.R=ǐ.ReverseOff;if(ѳ[5]==0)ë.Î=Ǐ.Off;else if(ѳ[5]==1)ë.Î=Ǐ.On;else if(ѳ[5]==2)ë.Î=Ǐ.OnMax;if(ѳ[6]==0)ë
.Ā=Ƹ.Off;else ë.Ā=Ƹ.On;ë.þ=new Color(ѳ[7],ѳ[8],ѳ[9],ѳ[10]);if(ѳ[11]==0)ë.ý=Ƹ.Off;else ë.ý=Ƹ.On;ë.ü=new Color(ѳ[12],ѳ[13],
ѳ[14],ѳ[15]);if(ѳ[16]==0)ë.ù=ǋ.Auto;else if(ѳ[16]==1)ë.ù=ǋ.StockpileRecharge;else if(ѳ[16]==2)ë.ù=ǋ.Discharge;if(ѳ[17]==0
)ë.ö=Ɯ.Off;else ë.ö=Ɯ.On;ë.ø=ѵ[ѳ[18]];if(ѳ[19]==0)ë.õ=ƽ.NoChange;else ë.õ=ƽ.Abort;if(ѳ[20]==0)ë.ô=Ɯ.Off;else ë.ô=Ɯ.On;if(
ѳ[21]==0)ë.ó=Ƽ.Off;else if(ѳ[21]==1)ë.ó=Ƽ.On;else if(ѳ[21]==2)ë.ó=Ƽ.FillWhenLow;else if(ѳ[21]==3)ë.ó=Ƽ.KeepFull;if(ѳ[22]
==0)ë.ò=Ɯ.Off;else ë.ò=Ɯ.On;if(ѳ[23]==0)ë.ñ=ƺ.Closed;else if(ѳ[23]==1)ë.ñ=ƺ.Open;else ë.ñ=ƺ.NoChange;ʈ.Add(ʅ,ë);}if(ʈ.
Count>=1){if(ɾ)Echo("Finished parsing "+ʈ.Count+" stances.");ѝ=ʈ;}else{Echo("Didn't find any stances!");}}catch(Exception ex)
{Echo("Custom Data Error (stances)\n"+ex.Message);}}void Ѥ(){bool ј=ɲ();if(!ј){ќ();ѯ();}if(ï==null){ï=ѝ.First().Value;}
string ї="";string і="";if(!ʱ){ї=" ".PadRight(129,' ')+Ι+"\n";і="\n".PadRight(19,'\n');}Η=ї+і;Ζ=ї+string.Join("\n",ʯ.Split(','
))+і;if(ɳ==""){if(ɾ)Echo("No ship name, trying to pull it from PB name...");string ѕ="Untitled Ship";try{string[]є=Me.
CustomName.Split(ʠ);if(є.Length>1){ɳ=є[0];if(ɾ)Echo(ɳ);}else ɳ=ѕ;}catch{ɳ=ѕ;}}}void ѓ(bool í=true,bool ђ=false,bool Ό=false){MyIni
ȼ=new MyIni();string ȿ=Me.CustomData;MyIniParseResult Ɗ;if(!ȼ.TryParse(ȿ,out Ɗ)){п.Add(new ш("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string Ⱦ,Ȣ;if(í){Ⱦ="RSM.Stance";Ȣ="CurrentStance";ȼ.Set(Ⱦ,Ȣ,ð);}if(ђ){Ⱦ="RSM.InitSubSystems";ȼ.Set(Ⱦ,
"Reactors",L);ȼ.Set(Ⱦ,"Batteries",L);ȼ.Set(Ⱦ,"Pdcs",u);ȼ.Set(Ⱦ,"TorpLaunchers",ȇ);ȼ.Set(Ⱦ,"KineticWeapons",o);ȼ.Set(Ⱦ,"H2Storage",
Ú);ȼ.Set(Ⱦ,"O2Storage",Ð);ȼ.Set(Ⱦ,"MainThrust",ç);ȼ.Set(Ⱦ,"RCSThrust",Ǻ);ȼ.Set(Ⱦ,"Gyros",қ);ȼ.Set(Ⱦ,"CargoStorage",ʚ);ȼ.
Set(Ⱦ,"Welders",ơ);}if(Ό){Ⱦ="RSM.InitItems";foreach(ŋ ʉ in Ϣ){Ȣ=ʉ.ϥ.SubtypeId;ȼ.Set(Ⱦ,Ȣ,ʉ.Є);}}Me.CustomData=ȼ.ToString();}
string ё(Type љ){string ѥ="";foreach(var Ŋ in Enum.GetValues(љ)){if(ѥ!="")ѥ+=", ";ѥ+=Ŋ.ToString();}return ѥ;}string ѣ(Color ī)
{return ī.R+", "+ī.G+", "+ī.B+", "+ī.A;}void Ѣ(Exception ѡ,string Ѡ){Runtime.UpdateFrequency=UpdateFrequency.None;string
џ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+Ѡ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(џ);List<IMyTextPanel>ў=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ў,ɖ=>ɖ.CustomName
.Contains(ʪ));foreach(IMyTextPanel Ƅ in ў){Ƅ.WriteText(џ);Ƅ.FontColor=new Color(193,0,197,255);}throw ѡ;}Dictionary<
string,X>ѝ=new Dictionary<string,X>();void ќ(){ѝ=new Dictionary<string,X>{{"Cruise",new X{V=Ɯ.On,U=Ǎ.AllDefence,S=ǌ.HoldFire,P
=ǎ.EpsteinOnly,R=ǐ.ForwardOff,Î=Ǐ.Off,Ā=Ƹ.On,þ=new Color(33,144,255,255),ý=Ƹ.On,ü=new Color(255,214,170,255),ú=new Color(
33,144,255,255),ù=ǋ.Auto,ø=50,ö=Ɯ.NoChange,õ=ƽ.Abort,ô=Ɯ.NoChange,ó=Ƽ.KeepFull,ò=Ɯ.On,ñ=ƺ.NoChange}},{"StealthCruise",new
X{W="Cruise",V=Ɯ.On,U=Ǎ.AllDefence,S=ǌ.HoldFire,P=ǎ.Minimum,R=ǐ.ForwardOff,Î=Ǐ.Off,Ā=Ƹ.Off,þ=new Color(0,0,0,255),ý=Ƹ.On,
ü=new Color(23,73,186,255),ú=new Color(23,73,186,255),ù=ǋ.Auto,ø=5,ö=Ɯ.Off,õ=ƽ.Abort,ô=Ɯ.NoChange,ó=Ƽ.KeepFull,ò=Ɯ.On,ñ=ƺ
.NoChange}},{"Docked",new X{W="Cruise",V=Ɯ.On,U=Ǎ.AllDefence,S=ǌ.HoldFire,P=ǎ.Off,R=ǐ.Off,Î=Ǐ.Off,Ā=Ƹ.On,þ=new Color(33,
144,255,255),ý=Ƹ.On,ü=new Color(255,240,225,255),û=Ƹ.On,ú=new Color(255,255,255,255),ù=ǋ.StockpileRecharge,ø=-1,ö=Ɯ.
NoChange,õ=ƽ.Abort,ô=Ɯ.Off,ó=Ƽ.On,ò=Ɯ.On,ñ=ƺ.NoChange}},{"Docking",new X{W="Docked",V=Ɯ.On,U=Ǎ.AllDefence,S=ǌ.HoldFire,P=ǎ.Off,R
=ǐ.On,Î=Ǐ.OnMax,Ā=Ƹ.On,þ=new Color(33,144,255,255),ý=Ƹ.On,ü=new Color(212,170,83,255),û=Ƹ.On,ú=new Color(212,170,83,255),
ù=ǋ.Auto,ø=-1,ö=Ɯ.NoChange,õ=ƽ.Abort,ô=Ɯ.Off,ó=Ƽ.KeepFull,ò=Ɯ.On,ñ=ƺ.NoChange}},{"NoAttack",new X{W="Docked",V=Ɯ.Off,U=Ǎ.
Off,S=ǌ.Off,P=ǎ.On,R=ǐ.On,Î=Ǐ.Off,Ā=Ƹ.On,þ=new Color(255,255,255,255),ý=Ƹ.On,ü=new Color(84,157,82,255),û=Ƹ.NoChange,ú=new
Color(84,157,82,255),ù=ǋ.NoChange,ø=-1,ö=Ɯ.NoChange,õ=ƽ.NoChange,ô=Ɯ.NoChange,ó=Ƽ.KeepFull,ò=Ɯ.On,ñ=ƺ.NoChange}},{"Combat",
new X{W="Cruise",V=Ɯ.On,U=Ǎ.AllDefence,S=ǌ.OpenFire,P=ǎ.On,R=ǐ.On,Î=Ǐ.Off,Ā=Ƹ.Off,þ=new Color(0,0,0,255),ý=Ƹ.On,ü=new Color
(210,98,17,255),û=Ƹ.On,ú=new Color(210,98,17,255),ù=ǋ.Discharge,ø=100,ö=Ɯ.On,õ=ƽ.Abort,ô=Ɯ.On,ó=Ƽ.KeepFull,ò=Ɯ.On,ñ=ƺ.
NoChange}},{"CQB",new X{W="Combat",V=Ɯ.On,U=Ǎ.Offence,S=ǌ.OpenFire,P=ǎ.On,R=ǐ.On,Î=Ǐ.Off,Ā=Ƹ.Off,þ=new Color(0,0,0,255),ý=Ƹ.On,ü
=new Color(243,18,18,255),û=Ƹ.On,ú=new Color(243,18,18,255),ù=ǋ.Discharge,ø=100,ö=Ɯ.On,õ=ƽ.Abort,ô=Ɯ.On,ó=Ƽ.KeepFull,ò=Ɯ.
On,ñ=ƺ.NoChange}},{"WeaponsHot",new X{W="CQB",V=Ɯ.On,U=Ǎ.Offence,S=ǌ.OpenFire,P=ǎ.NoChange,R=ǐ.NoChange,Î=Ǐ.NoChange,Ā=Ƹ.
NoChange,þ=new Color(0,0,0,255),ý=Ƹ.NoChange,ü=new Color(243,18,18,255),û=Ƹ.NoChange,ú=new Color(243,18,18,255),ù=ǋ.Discharge,ø=
-1,ö=Ɯ.NoChange,õ=ƽ.NoChange,ô=Ɯ.NoChange,ó=Ƽ.KeepFull,ò=Ɯ.On,ñ=ƺ.NoChange}}};}class ћ{public IMyDoor ɉ;public int њ=0;
public int ѧ=0;public bool ѽ=false;public bool Ҡ=false;}class Ү{public string ҭ;public bool Ҭ=false;public int ҫ=0;public bool
Ҫ=false;public List<ћ>ҩ=new List<ћ>();public List<IMyAirVent>Ҩ=new List<IMyAirVent>();}int ҧ=0;int Ҧ=0;int ҥ=0;bool Ҥ(ћ ң
){bool Ң=false;if(ң.ɉ==null)return false;bool ę=ң.ɉ.OpenRatio>0;ҧ++;if(ү(ң.ɉ))ҥ++;if(ę){ң.ɉ.Enabled=true;if(ɾ&&ң.њ==0)
Echo("Door just opened... ("+ң.ɉ.CustomName+")");ң.њ++;if(ң.њ>=ʭ){ң.њ=0;ң.ɉ.CloseDoor();Ң=true;}}else{Ҧ++;}return Ң;}void ҡ(
){if(!ʮ){if(ɾ)Echo("Door management is disabled.");return;}foreach(Ү ɤ in Ν){foreach(ћ ң in ɤ.ҩ){if(ң.ɉ==null)continue;
bool Ң=Ҥ(ң);if(Ң){if(ɾ)Echo("Airlock door "+ң.ɉ.CustomName+" just closed");if(ɤ.Ҫ)ɤ.Ҫ=false;else{ɤ.Ҭ=true;ң.Ҡ=true;if(ɾ)Echo
("Airlock "+ɤ.ҭ+" needs to cycle");}}}if(ɤ.Ҭ){foreach(ћ ң in ɤ.ҩ){if(ң.ɉ==null)continue;if(ң.ɉ.OpenRatio>0)ң.ɉ.CloseDoor(
);else ң.ɉ.Enabled=false;}bool ҹ=false;foreach(IMyAirVent Ҹ in ɤ.Ҩ){if(Ҹ==null)continue;if(!Ҹ.Enabled)Ҹ.Enabled=true;if(!
Ҹ.Depressurize)Ҹ.Depressurize=true;if(Ҹ.CanPressurize&&Ҹ.GetOxygenLevel()<.01&&ɤ.Ҭ)ҹ=true;}ɤ.ҫ++;bool ҷ=true;if(ɤ.ҫ>=ʬ){ҷ
=false;ҹ=true;}if(ҹ){ɤ.Ҭ=false;ɤ.ҫ=0;ɤ.Ҫ=true;foreach(ћ ң in ɤ.ҩ){if(ң.ɉ==null)continue;ң.ɉ.Enabled=true;if(ң.Ҡ)ң.Ҡ=false
;else if(ҷ)ң.ɉ.OpenDoor();}}}}}void Ҷ(){if(!ʮ){if(ɾ)Echo("Door management is disabled.");return;}ҧ=0;Ҧ=0;ҥ=0;foreach(ћ ң
in Ξ)Ҥ(ң);}void ҵ(ƺ N){if(N==ƺ.NoChange)return;foreach(IMyAirtightHangarDoor Ҵ in Ϝ){if(Ҵ==null)continue;if(N==ƺ.Closed)Ҵ.
CloseDoor();else Ҵ.OpenDoor();}}void ҳ(string Ҳ,string ұ){Ҳ=Ҳ.ToLower();foreach(ћ ң in Ξ){if(ұ==""||ң.ɉ.CustomName.Contains(ұ)){
bool Ұ=ү(ң.ɉ);if(Ұ&&(Ҳ=="locked"||Ҳ=="toggle"))ң.ɉ.ApplyAction("AnyoneCanUse");if(!Ұ&&(Ҳ=="unlocked"||Ҳ=="toggle"))ң.ɉ.
ApplyAction("AnyoneCanUse");}}}bool ү(IMyDoor ң){var Ƙ=ң.GetActionWithName("AnyoneCanUse");StringBuilder ҟ=new StringBuilder();Ƙ.
WriteValue(ң,ҟ);return(ҟ.ToString()=="On");}double Ҕ;int Ҟ=0;int Ғ=8;int ґ=10;double Ґ=3;double ҏ=245000;double Ҏ=50000;double ҍ=
100;void ғ(Ƽ N){foreach(IMyTerminalBlock ҋ in ϝ){if(ҋ==null)continue;if(N==Ƽ.Off)ҋ.ApplyAction("OnOff_Off");else ҋ.
ApplyAction("OnOff_On");}}void Ҋ(){if(ϝ.Count<1&&ϛ.Count>1)Ҕ=(Ґ*Ҏ);else Ҕ=(Ґ*ҏ);}void ҁ(){if(ï.ó==Ƽ.Off||ï.ó==Ƽ.On){if(ɾ)Echo(
"Extractor management disabled.");}else if(Ҟ>0){Ҟ--;if(ɾ)Echo("waiting ("+Ҟ+")...");}else if(ϖ.Count<1){if(ɾ)Echo("No tanks!");}else if(ï.ó==Ƽ.
FillWhenLow&&ҍ<ґ){if(ɾ)Echo("Fuel low! ("+ҍ+"% / "+ґ+"%)");Ͳ=true;Ҁ();}else if(ï.ó==Ƽ.KeepFull&&Ù<(Û-Ҕ)){Ͳ=true;Ҁ();if(ɾ)Echo(
"Fuel ready for top up ("+Ù+" < "+(Û-Ҕ)+")");}else if(ɾ){Echo("Fuel level OK ("+ҍ+"%).");if(ï.ó==Ƽ.KeepFull)Echo("Keeping tanks full\n("+Ù+" < "+
(Û-Ҕ)+")");}}void Ҁ(){string ƌ="";int ѿ=8;if(ҍ<5){ѿ=0;if(Ғ!=ѿ)ƌ="v fast";}else if(ҍ<10){ѿ=2;if(Ғ!=ѿ)ƌ="fast";}else if(ҍ<
60){ѿ=4;if(Ғ!=ѿ)ƌ="medium";}else if(Ғ!=ѿ)ƌ="slow";if(ƌ!=""){Ғ=ѿ;п.Add(new ш("Extractor loading "+ƌ,
"Extractor load speed has been set to "+ƌ+" automatically)",0));}}void Ҍ(){Ͳ=false;IMyTerminalBlock Ѿ=null;int ŋ=1;foreach(IMyTerminalBlock ҋ in ϝ){if(ҋ.
IsFunctional){Ѿ=ҋ;break;}}if(Ѿ==null){foreach(IMyTerminalBlock ҋ in ϛ){if(ҋ.IsFunctional){Ѿ=ҋ;ŋ=2;break;}}if(Ѿ==null){if(ɾ)Echo(
"No functional extractor to load!");Ͱ=true;return;}}Ͱ=false;if(Ϣ[ŋ].Ѕ<1){ˮ=true;if(ɾ)Echo("No spare "+Ϣ[ŋ].ϥ.SubtypeId+" to load!");return;}Ҟ=Ғ;Њ ϊ=new Њ(
);ϊ.ɉ=Ѿ;ϊ.ϊ=Ѿ.GetInventory();Ѿ.ApplyAction("OnOff_On");List<Њ>ҝ=new List<Њ>();ҝ.Add(ϊ);if(ɾ)Echo(
"Attempting to load extractor "+Ѿ.CustomName);bool ɶ=в(Ϣ[ŋ].Ё,ҝ,Ϣ[ŋ].ϥ);string Ҝ="fuel tank";if(ŋ==2)Ҝ="jerry can";if(ɶ)п.Add(new ш("Loaded a "+Ҝ,
"Sucessfully loaded a "+Ҝ+" into an extractor.",0));}double қ=0;int Қ=0;double ҙ=0;void Ҙ(bool Ë,bool Ŭ){Қ=0;foreach(IMyGyro җ in Ϛ){if(җ!=null
&&җ.IsFunctional){Қ++;if(Ŭ)җ.Enabled=Ë;}}ҙ=Math.Round(100*(Қ/қ));}void Җ(string ҕ,bool Ώ=true,bool Ύ=true,bool Ό=true){if(
ɾ)Echo("Initialising a ship as '"+ҕ+"'...");Μ=true;ʼ();ϫ();ͺ=0;Μ=false;ɳ=ҕ;if(ɾ)Echo("Initialising lcds...");Ɔ();if(Ύ){if
(ɾ)Echo("Initialising subsystem values...");ß();Ƿ();Ì();F();Ü();ì();ʖ();u=ϑ.Count+ϐ.Count;ȇ=ώ.Count;o=Ϗ.Count;қ=Ϛ.Count;ơ
=ϓ.Count;}if(Ό){if(ɾ)Echo("Initialising item values...");Ϫ();}if(Ώ){if(ɾ)Echo("Initialising block names...");ϻ();}ѓ(false
,Ύ,Ό);п.Add(new ш("Init:"+ҕ,"Initialised '"+ҕ+"'\nGood Hunting!",3));}class ѐ{public int ϧ=0;public int Ͻ=0;public int ϼ=
0;}void ϻ(){Dictionary<string,ѐ>Ϻ=new Dictionary<string,ѐ>();if(ʎ.Count>0){foreach(string e in ʎ){if(ɾ)Echo("Numbering "+
e);Ϻ.Add(e,new ѐ());}foreach(var Ϸ in Λ){ѐ Ϲ;if(Ϻ.TryGetValue(Ϸ.Value,out Ϲ)){Ϻ[Ϸ.Value].Ͻ++;}}foreach(var ϸ in Ϻ){if(ϸ.
Value.Ͻ<10)ϸ.Value.ϼ=1;else if(ϸ.Value.Ͻ>99)ϸ.Value.ϼ=3;else ϸ.Value.ϼ=2;}}foreach(var Ϸ in Λ){string ϵ="";string ϴ=Ϸ.Value;ѐ
ϳ;if(Ϻ.TryGetValue(Ϸ.Value,out ϳ)){if(ϳ.Ͻ>1){ϳ.ϧ++;ϵ=ʠ+ϳ.ϧ.ToString().PadLeft(ϳ.ϼ,'0');}}Ϸ.Key.CustomName=ɳ+ʠ+ϴ+ϵ+ϲ(Ϸ.Key
.CustomName,ϴ);}}string ϲ(string Ȣ,string ϱ=""){try{string[]Ͼ=Ȣ.Split(ʠ);string[]Ѐ=ϱ.Split(ʠ);string Ɗ="";if(Ͼ.Length<3)
return"";for(int ė=2;ė<Ͼ.Length;ė++){int Ѝ=0;bool Ќ=int.TryParse(Ͼ[ė],out Ѝ);if(Ќ)Ͼ[ė]="";foreach(string Ћ in Ѐ){if(Ћ==Ͼ[ė])Ͼ[
ė]="";}if(Ͼ[ė]!="")Ɗ+=ʠ+Ͼ[ė];}return Ɗ;}catch{return"";}}class Њ{public IMyTerminalBlock ɉ{get;set;}public IMyInventory ϊ
{get;set;}List<MyInventoryItem>Љ=new List<MyInventoryItem>();public int Ј=0;public bool Ї=false;public float І;}class ŋ{
public int Ѕ=0;public int Є=0;public int Ѓ=0;public double Ђ;public List<Њ>Ё=new List<Њ>();public List<Њ>ϰ=new List<Њ>();
public MyItemType ϥ;public bool Ϯ=false;public bool Ϥ=false;public string Ϟ;public double ϣ=1;}List<ŋ>Ϣ=new List<ŋ>();void ϡ(
IMyTerminalBlock ɖ,int ʉ=99){if(ʉ==99){foreach(var ŋ in Ϣ){Њ ϊ=new Њ();ϊ.ɉ=ɖ;ϊ.ϊ=ɖ.GetInventory();ŋ.Ё.Add(ϊ);}}else{Њ ϊ=new Њ();ϊ.ɉ=ɖ;ϊ.
ϊ=ɖ.GetInventory();ϊ.Ї=ʒ;if(ʉ==0&&!ʑ)ϊ.Ї=false;Ϣ[ʉ].Ё.Add(ϊ);}}void ϟ(IMyTerminalBlock ɖ,int ʉ){Њ ϊ=new Њ();ϊ.ɉ=ɖ;ϊ.ϊ=ɖ.
GetInventory();ϊ.Ї=ʒ;Ϣ[ʉ].ϰ.Add(ϊ);}void Ϡ(string Ϟ,string Ϧ,string ϯ,bool Ϥ=false,bool Ϯ=false){ŋ ŋ=new ŋ();ŋ.ϥ=new MyItemType(Ϧ,ϯ)
;ŋ.Ϥ=Ϥ;ŋ.Ϯ=Ϯ;ŋ.Ϟ=Ϟ;Ϣ.Add(ŋ);}void ϭ(){try{Ϡ("Fusion F ","MyObjectBuilder_Ingot","FusionFuel",true);Ϡ("Fuel Tank",
"MyObjectBuilder_Component","Fuel_Tank");Ϡ("Jerry Can","MyObjectBuilder_Component","SG_Fuel_Tank");Ϡ("PDC      ","MyObjectBuilder_AmmoMagazine",
"40mmLeadSteelPDCBoxMagazine",true);Ϡ("PDC Tefl ","MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);Ϡ("220 Torp ",
"MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",true,true);Ϡ("220 MCRN ","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true
,true);Ϡ("220 UNN  ","MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);Ϡ("RS Torp  ",
"MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);Ϡ("LRS Torp ","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",
true,true);Ϡ("120mm RG ","MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);Ϡ("Dawson   ",
"MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true);Ϡ("Stiletto ","MyObjectBuilder_AmmoMagazine",
"100mmTungstenUraniumSlugMCRNMagazine",true);Ϡ("80mm     ","MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);Ϡ("Foehammr ",
"MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugMCRNMagazine",true);Ϡ("Farren   ","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugUNNMagazine",true);Ϡ("Kess     ","MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);Ϡ("Steel Pla",
"MyObjectBuilder_Component","SteelPlate");Ϣ[0].ϣ=ɸ;}catch(Exception ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void Ϭ(){
foreach(var ŋ in Ϣ){ŋ.ϰ.Clear();}}void ϫ(){foreach(var ŋ in Ϣ){ŋ.Ѕ=0;ŋ.Ѓ=0;List<Њ>ˏ=ŋ.Ё.Concat(ŋ.ϰ).ToList();foreach(Њ ϊ in ˏ){
ϊ.Ј=ϊ.ϊ.GetItemAmount(ŋ.ϥ).ToIntSafe();ŋ.Ѕ+=ϊ.Ј;if(ϊ.Ї){ϊ.І=ϊ.ϊ.VolumeFillFactor;}else{ŋ.Ѓ+=ϊ.Ј;}}}}void Ϫ(){foreach(ŋ ŋ
in Ϣ){ŋ.Є=ŋ.Ѕ;}}int ϩ(string ȃ){switch(ȃ){case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":case
"MCRN Torpedo Low Spread":return 6;case"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;
case"40mm Lead-Steel PDC Box Ammo":return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":
return 10;case"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case
"80mm Tungsten-Uranium Sabot Ammo":return 13;case"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;
case"180mm Lead-Steel Sabot Ammo":return 16;default:if(ɾ)Echo("Unknown AmmoType = "+ȃ);return 99;}}bool Ϩ(IMyTerminalBlock ɉ
){IMyInventory Ў=ɉ.GetInventory();return Ў.VolumeFillFactor==0;}bool в(List<Њ>ˎ,List<Њ>ˌ,MyItemType ϥ,int н=-1,double м=1
,double л=1){if(ɾ)Echo("Loading "+ˌ.Count+" inventories from "+ˎ.Count+" sources.");bool ª=false;bool к=л<1;foreach(Њ й
in ˌ){int и=3;foreach(Њ з in ˎ){if(и<0)break;if(н!=-1&&й.Ј>=(н*.95))break;if(!й.ϊ.IsConnectedTo(з.ϊ))continue;List<
MyInventoryItem>ж=new List<MyInventoryItem>();з.ϊ.GetItems(ж);foreach(MyInventoryItem е in ж){if(е.Type==ϥ){int Ј=е.Amount.ToIntSafe();
if(Ј==0&&!к)break;и--;if(к){и=-1;try{Ј=з.Ј-Convert.ToInt32(з.Ј/з.І*л);if(ɾ)Echo("Unload "+Ј+"\n"+з.Ј+"\n"+Convert.ToInt32(
з.Ј/з.І*л));}catch(Exception ex){if(ɾ)Echo("Int conversion error at unload\n"+ex.Message);Ј=1;}}else if(м<1){try{int д=
Convert.ToInt32(й.Ј/й.І*м)-й.Ј;if(д<Ј)Ј=д;}catch(Exception ex){if(ɾ)Echo("Int conversion error at load\n"+ex.Message);Ј=1;}}
else if(н!=-1){if(Ј<=н){break;}Ј=н-й.Ј;}ª=й.ϊ.TransferItemFrom(з.ϊ,е,Ј);if(ª)и=-1;if(к&&ª)return(ª);break;}}}}return ª;}
class г{public IMyTextPanel ɉ;public bool о=true;public bool ю=false;public bool я=false;public bool э=true;public bool ь=
true;public bool ы=true;public bool ъ=false;public bool щ=false;}class ш{public string ч,ц;public int х,ф;public ш(string у,
string т,int с=0,int р=20){if(у.Length>М-3)у=у.Substring(0,М-3);ч=у.PadRight(М-3);ц=т;х=с;ф=р;}}List<ш>п=new List<ш>();class б
{public string Н,Я;public б(string e,int Л,int К){string Й="    ";while(К>3){К-=4;}if(Л==0){Н="║ "+e.PadRight(4)+" ║";Я=
"  "+Й+"  ";}else if(Л==1){if(К==0||К==2)Н="║─"+e.PadRight(4)+" ║";else Н="║ "+e.PadRight(4)+"─║";Я=" ░"+Й+"░ ";}else if(Л==
2){if(К==0||К==2){Н="║ "+e.PadRight(4)+"═║";Я="║▒"+Й+"░║";}else{Н="║═"+e.PadRight(4)+" ║";Я="║░"+Й+"▒║";}}else if(Л==3){
if(К==0||К==2){Н="║!"+e.PadRight(4)+"!║";Я="║▓"+Й+"▓║";}else{Н="║ "+Й+" ║";Я="║!"+e.PadRight(4)+"!║";}}}}Color И=new Color
(255,116,33,255);const int М=32;int З=0;string[]Е=new string[]{"▄ "," ▄"," ▀","▀ "},Д=new string[]{"─","\\","│","/"},Г=
new string[]{"- ","= ","x ","! "};string В="RSM is booting...\n\n",Б,А,Ж="──\n\n",Џ="╔══════╗",О="╚══════╝",а,Ю,Э,Ь,Ы,Ъ,Щ,Ш
,Ч,Ц,Х,Ф,У,Т,С,Р,П,ȹ,Ň,Þ,Ņ;void ń(){Џ=Џ+Џ+Џ+Џ+"\n";О=О+О+О+О+"\n";Б=new String(' ',М-8);А="└"+new String('─',М-2)+"┘";а=
new String('-',26)+"\n";Ю=Ń("Inventory");Э=Ń("Thrust");Ь=Ń("Power & Tanks");Ы=Ń("Warnings");Ъ=Ń("Subsystem Integrity");Щ=Ń(
"Telemetry & Thrust");Ш=Ł("Velocity");Ч=Ł("Velocity (Max)");Ц=Ł("Mass");Х=Ł("Max Accel");Ф=Ł("Actual Accel");У=Ł("Accel (Best)");Т=Ł(
"Max Thrust");С=Ł("Actual Thrust");Р=Ł("Decel (Dampener)");П=Ł("Decel (Actual)");ȹ=Ŀ("Fuel");Ň=Ŀ("Oxygen");Þ=Ŀ("Battery");Ņ=Ŀ(
"Capacity");}string Ń(string ł){return"──┤ "+ł+" ├"+new String('─',М-9-ł.Length);}string Ł(string ŀ){return"\n"+ŀ+":"+new String(
' ',М-16-ŀ.Length);}string Ŀ(string ľ){return ľ+new String(' ',М-22-ľ.Length)+"[";}void Ľ(){З++;if(З>=Е.Length)З=0;int ļ=З+
2;if(ļ>3)ļ-=4;string Ļ=Е[З];string ĺ=Д[З];string Ĺ=Е[ļ];string ĸ=Ю+ĺ+Ж;string ķ=Э+ĺ+Ж;string ņ=Ь+ĺ+Ж;string ň=Ы+ĺ+Ж;
string ř=Ъ+ĺ+Ж;string Ś=Щ+ĺ+Ж;string Ř=ų(ɳ.ToUpper(),М)+"\n"+"  "+Ļ+" "+ų(ð,М-10)+" "+Ļ+"  \n";string ŗ="\n  "+Ĺ+Б+Ĺ+"  \n\n";
if(Ͷ){ĸ+=В;ķ+=В;ņ+=В;ň+=В;ř+=В;}else{ʛ();double Ŗ=9.81,ŕ=Math.Round(Ή),Ŕ=Math.Round((é/Θ/Ŗ),2),œ=Math.Round((è/Θ/Ŗ),2),Œ=
Math.Round(L+Æ,1),ő=Math.Round(É,1),Ő=Math.Round(100*(Ñ/Ò)),ŏ=Math.Round(100*(Å/Ç)),Ŏ=Math.Round(100*(ő/Œ));string ō=Ш,Ō=
" Gs";if(ŕ<1){ŕ=500;ō=Ч;}if(ɹ){Ŗ=1;Ō=" m/s/s";}foreach(ŋ ŋ in Ϣ){if(ŋ.Є!=0){ŋ.Ђ=(100*((double)ŋ.Ѕ/(double)ŋ.Є));string Ŋ=(ŋ.Ѕ
+"/"+ŋ.Є).PadLeft(9);if(Ŋ.Length>9)Ŋ=Ŋ.Substring(0,9);ĸ+=ŋ.Ϟ+" ["+Ž(ŋ.Ђ)+"] "+Ŋ+"\n";}}ĸ+="\n";if(è>0)ķ=П+ƍ(è,ŕ)+Ф+(œ+Ō).
PadLeft(15);else ķ=Р+ƍ(é,ŕ,true)+У+(Ŕ+Ō).PadLeft(15);ҍ=Math.Round(100*(Ù/Û));ņ+=ȹ+Ž(ҍ)+"] "+(ҍ+" %").PadLeft(9)+"\n"+Ň+Ž(Ő)+
"] "+(Ő+" %").PadLeft(9)+"\n"+Þ+Ž(ŏ)+"] "+(ŏ+" %").PadLeft(9)+"\n"+Ņ+Ž(Ŏ)+"] "+(Ŏ+" %").PadLeft(9)+"\n"+"Max Power:"+(ő+
" MW / "+Œ+" MW").PadLeft(22)+"\n\n";List<ш>ŉ=new List<ш>();List<б>ĵ=new List<б>();int ĥ=0;for(int ė=0;ė<п.Count;ė++){п[ė].ф--;
if(п[ė].ф<1)п.RemoveAt(ė);else ŉ.Add(п[ė]);}if(!ƃ){ŉ.Add(new ш("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}int ģ=0;if(ҍ<5){ŉ.Add(new ш("FUEL CRITICAL!","FUEL CRITICAL!\nFuel Level < 5%!",3));ģ=3;}else if(ҍ<25){ŉ.Add(new ш
("FUEL LOW!","FUEL LOW!\nFuel Level < 10%!",2));ģ=2;}if(ï.ó!=Ƽ.Off){if(ˮ){if(ģ==0)ģ=1;ŉ.Add(new ш("No spare fuel tanks",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",ģ));}if(Ͱ){if(ģ==0)ģ=1;ŉ.Add(new ш("No Extractor","Cannot refuel!\nNo functional extractor!",ģ));}}ĵ.Add(new б("FUEL",ģ
,З+ĥ));ĥ++;int Ģ=0;if(Ő<5){ŉ.Add(new ш("OXYGEN CRITICAL!","OXYGEN CRITICAL!\nShip O2 Level < 5%!",3));Ģ=3;}else if(Ő<10){
ŉ.Add(new ш("OXYGEN LOW!","OXYGEN LOW!\nShip O2 Level < 10%!",2));Ģ=2;}else if(Ő<25){ŉ.Add(new ш("Oxygen Low",
"Oxygen Low!\nShip O2 Level < 25%!",1));Ģ=1;}if(ϔ.Count>Ů){int ġ=(ϔ.Count-Ů);Ģ++;ŉ.Add(new ш(ġ+" vents are unsealed",ġ+" vents are unsealed",1));}if(ҥ>0){ŉ
.Add(new ш(ҥ+" doors are insecure",ҥ+" doors are insecure",0));}if(Έ>0){ŉ.Add(new ш(ʨ+" is active ("+Έ+")",ʨ+
" is active ("+Έ+")",0));}ĵ.Add(new б("OXYG",Ģ,З+ĥ));ĥ++;int Ġ=0;if(ς.Count>0){if(ŏ<5){Ġ+=2;ŉ.Add(new ш("BATTERIES CRITICAL!",
"BATTERIES CRITICAL!\nBattery Level < 5%!",2));}else if(ŏ<10){Ġ+=1;ŉ.Add(new ш("Batteries Low!","Batteries Low!\nBattery Level < 10%!",1));}}if(Ϙ.Count>0){if(H>0)
{Ġ+=2;ŉ.Add(new ш(H+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}if(Ϣ[0].Є==0){if(Ϣ[0].Ѕ>0)
{Ġ+=1;ŉ.Add(new ш("No Spare Fusion Fuel!","No spare fusion fuel detected in ships cargo!",2));}}else if(Ϣ[0].Ђ<5){Ġ+=2;ŉ.
Add(new ш("FUSION FUEL LEVEL CRITICAL!","Fusion fuel level is low!",3));}else if(Ϣ[0].Ђ<10){Ġ+=1;ŉ.Add(new ш(
"Fusion Fuel Level Low!","Fusion fuel level is low!",2));}}if(Ġ>3)Ġ=3;ĵ.Add(new б("POWR",Ġ,З+ĥ));ĥ++;int ğ=0;if(ˑ!=""){string[]Ğ=ˑ.Split('\n');
foreach(string Ĥ in Ğ){string ĝ=Ĥ;if(Ĥ.Length>23)ĝ=Ĥ.Substring(0,23);ĝ=ĝ.ToUpper();ŉ.Add(new ш("NEED "+ĝ+"!","NEED "+ĝ+
"!  Ammo Critical!",3));}ğ=3;}if(ğ>3)ğ=3;ĵ.Add(new б("WEAP",ğ,З+ĥ));ĥ++;if(ʴ){string ě=ʺ;if(σ.Count>0)if(σ[0]!=null)ě=(σ[0]as
IMyRadioAntenna).HudText;string Ě="";if(ʳ<1000)Ě=Math.Round(ʳ)+"m";else Ě=Math.Round(ʳ/1000)+"km";ŉ.Add(new ш("Comms ("+Ě+"): "+ě,
"Antenna(s) are broadcasting at a range of "+Ě+" with the message "+ě,0));}if(ˬ>0){ŉ.Add(new ш(ˬ+" UNOWNED BLOCKS!","RSM detected "+ˬ+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ҧ>Ҧ){int ę=(ҧ-Ҧ);ŉ.Add(new ш(ę+" doors are open",ę+" doors are open",0));}ŉ=ŉ.OrderBy(Ę=>Ę.х).Reverse().ToList(
);if(ŉ.Count<1)ň+="No warnings\n";else Echo("\n\n WARNINGS:");for(int ė=0;ė<ŉ.Count;ė++){ň+=Г[ŉ[ė].х]+ŉ[ė].ч+"\n";Echo(
"-"+Г[ŉ[ė].х]+ŉ[ė].ц);}ň+="\n";string Ė=ï.P.ToString().ToUpper();if(Ė.Length>3)Ė=Ė.Substring(0,3);string Ĝ=ï.R.ToString().
ToUpper();if(Ĝ.Length>3)Ĝ=Ĝ.Substring(0,3);string ĕ=ï.P.ToString().ToUpper();if(ĕ.Length>3)ĕ=ĕ.Substring(0,3);string Ħ=ï.U.
ToString().ToUpper();if(Ħ.Length>3)Ħ=Ħ.Substring(0,3);string Ĵ=ï.V.ToString().ToUpper();if(Ĵ.Length>3)Ĵ=Ĵ.Substring(0,3);string
ĳ=ï.S.ToString().ToUpper();if(ĳ.Length>3)ĳ=ĳ.Substring(0,3);try{if(ç>0)ř+="Epstein   ["+Ž(æ)+"] "+(æ+"% ").PadLeft(5)+Ė+
"\n";if(Ǻ>0)ř+="RCS       ["+Ž(ǹ)+"] "+(ǹ+"% ").PadLeft(5)+Ĝ+"\n";if(L>0)ř+="Reactors  ["+Ž(J)+"] "+(J+"% ").PadLeft(5)+
"    \n";if(Æ>0)ř+="Batteries ["+Ž(Ä)+"] "+(Ä+"% ").PadLeft(5)+ĕ+"\n";if(u>0)ř+="PDCs      ["+Ž(s)+"] "+(s+"% ").PadLeft(5)+Ħ+
"\n";if(ȇ>0)ř+="Torpedoes ["+Ž(ȅ)+"] "+(ȅ+"% ").PadLeft(5)+Ĵ+"\n";if(o>0)ř+="Railguns  ["+Ž(l)+"] "+(l+"% ").PadLeft(5)+ĳ+
"\n";if(Ú>0)ř+="H2 Tanks  ["+Ž(Ø)+"] "+(Ø+"% ").PadLeft(5)+ĕ+"\n";if(Ð>0)ř+="O2 Tanks  ["+Ž(Õ)+"] "+(Õ+"% ").PadLeft(5)+ĕ+
"\n";if(қ>0)ř+="Gyros     ["+Ž(ҙ)+"] "+(ҙ+"% ").PadLeft(5)+"    \n";if(ʚ>0)ř+="Cargo     ["+Ž(ʘ)+"] "+(ʘ+"% ").PadLeft(5)+
"    \n";if(ơ>0)ř+="Welders   ["+Ž(Ɵ)+"] "+(Ɵ+"% ").PadLeft(5)+"    \n";}catch{}if(Æ+L+Ú==0)ř+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+"\n\n";string Ĳ="";string ı="";foreach(б İ in ĵ){Ĳ+=İ.Н;ı+=İ.Я;}int į=З+2;if(į>3)į-=4;Ř+=Џ+Ĳ+"\n"+О;ŗ+=ı;if(!Ε){Ś+=
"\n\n";}else{if(ɾ)Echo("Building advanced thrust...");string Į="";if(ɻ){Į=Ц+(Math.Round((Θ/1000000),2)+" Mkg").PadLeft(15)+ō+(
ŕ+" ms").PadLeft(15)+Х+(Ŕ+Ō).PadLeft(15)+Ф+(œ+Ō).PadLeft(15)+Т+((é/1000000)+" MN").PadLeft(15)+С+((è/1000000)+" MN").
PadLeft(15);}Ś+=Į+Р+ƍ(é,ŕ,true)+П+ƍ(è,ŕ);foreach(double ĭ in ɺ){Ś+="\n"+("Decel ("+(ĭ*100)+"%):").PadRight(17)+ƍ((float)(é*ĭ),ŕ
);}Ś+="\n\n";}}foreach(г ĩ in Φ){string Ĭ="";Color ī=ï.ú;if(ĩ.о)Ĭ+=Ř;if(ĩ.ю){Ĭ+=ŗ;ī=И;}if(ĩ.я)Ĭ+=ň;if(ĩ.э)Ĭ+=ņ;if(ĩ.ь)Ĭ+=
ĸ;if(ĩ.ы)Ĭ+=ķ;if(ĩ.ъ)Ĭ+=ř;if(ĩ.щ){Ĭ+=Ś;Ε=true;}ĩ.ɉ.WriteText(Ĭ,false);if(!ɼ)ĩ.ɉ.FontColor=ī;}}void Ī(){if(Χ.Count>0){
foreach(IMyTextPanel ĩ in Χ){ĩ.FontColor=ï.ú;}foreach(г ĩ in Φ){ĩ.ɉ.FontColor=ï.ú;}}}void Ĩ(string ħ,string Ķ){ħ=ħ.ToLower();
List<IMyTextPanel>ś=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ψ);foreach(IMyTextPanel ĩ in Ψ
){if(Ķ==""||ĩ.CustomName.Contains(Ķ)){string ſ=ĩ.CustomData;if(ſ.Contains("hudlcd")&&(ħ=="off"||ħ=="toggle"))ĩ.CustomData
=ſ.Replace("hudlcd","hudXlcd");if(ſ.Contains("hudXlcd")&&(ħ=="on"||ħ=="toggle"))ĩ.CustomData=ſ.Replace("hudXlcd","hudlcd"
);}}}string Ž(double Ŵ){try{int ż=0;if(Ŵ>0){int Ż=(int)Ŵ/10;if(Ż>10)return new string('=',10);if(Ż!=0)ż=Ż;}char ź=' ';if(
Ŵ<10){if(З==0)return" ><    >< ";if(З==1)return"  ><  ><  ";if(З==2)return"   ><><   ";if(З==3)return"<   ><   >";}string
Ź=new string('=',ż);string Ÿ=new string(ź,10-ż);return Ź+Ÿ;}catch{return"# ERROR! #";}}string ŷ(string Ŷ){string ŵ;string
Ŋ="";double Ŵ=0;switch(Ŷ){case"H2":Ŵ=Math.Round(100*(Ù/Ú));Ŋ=Ŵ.ToString()+" %";ҍ=Ŵ;break;case"O2":Ŵ=Math.Round(100*(Ñ/Ð))
;Ŋ=Ŵ.ToString()+" %";break;case"Battery":Ŵ=Math.Round(100*(Å/Ç));Ŋ=Ŵ.ToString()+" %";break;}ŵ=Ž(Ŵ);return" ["+ŵ+"] "+Ŋ.
PadLeft(9);}string ų(string Ų,int ű){int ž=ű-Ų.Length;int ƀ=ž/2+Ų.Length;return Ų.PadLeft(ƀ).PadRight(ű);}string ƍ(double Ǝ,
double ƌ,bool Ƌ=false){if(Ǝ<=0)return("N/A").PadLeft(15);if(Ƌ)Ǝ=Ǝ*1.5;double Ɗ=0.5*(Math.Pow(ƌ,2)*(Θ/Ǝ));double Ɖ=ƌ/(Ǝ/Θ);
string ƈ="m";if(Ɗ>1000){ƈ="km";Ɗ=Ɗ/1000;}return(Math.Round(Ɗ)+ƈ+" "+Math.Round(Ɖ)+"s").PadLeft(15);}void Ƈ(){foreach(
IMyTextPanel Ƅ in Ψ){Ƅ.Enabled=true;}}void Ɔ(){foreach(г ĩ in Φ){ĩ.ɉ.Font="Monospace";ĩ.ɉ.ContentType=ContentType.TEXT_AND_IMAGE;if(
ĩ.ɉ.CustomName.Contains("HUD1")){ĩ.о=true;ĩ.ю=false;ĩ.я=false;ĩ.э=false;ĩ.ь=false;ĩ.ы=false;ĩ.ъ=false;ĩ.щ=false;Ƀ(ĩ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ĩ.ɉ.CustomName.Contains("HUD2")){ĩ.о=false;ĩ.ю=false;ĩ.я=true;ĩ.э=false;ĩ.ь=false;ĩ.ы=false;ĩ.ъ=false;ĩ.щ
=false;Ƀ(ĩ,"hudlcd:0.22:0.99:0.55");continue;}if(ĩ.ɉ.CustomName.Contains("HUD3")){ĩ.о=false;ĩ.ю=false;ĩ.я=false;ĩ.э=true;
ĩ.ь=false;ĩ.ы=true;ĩ.ъ=false;ĩ.щ=false;Ƀ(ĩ,"hudlcd:0.48:0.99:0.55");continue;}if(ĩ.ɉ.CustomName.Contains("HUD4")){ĩ.о=
false;ĩ.ю=false;ĩ.я=false;ĩ.э=false;ĩ.ь=false;ĩ.ы=false;ĩ.ъ=true;ĩ.щ=false;Ƀ(ĩ,"hudlcd:0.74:0.99:0.55");continue;}if(ĩ.ɉ.
CustomName.Contains("HUD5")){ĩ.о=false;ĩ.ю=false;ĩ.я=false;ĩ.э=false;ĩ.ь=true;ĩ.ы=false;ĩ.ъ=false;ĩ.щ=true;Ƀ(ĩ,"hudlcd:0.75:0:.54"
);continue;}if(ĩ.ɉ.CustomName.Contains("HUD6")){ĩ.о=false;ĩ.ю=true;ĩ.я=false;ĩ.э=false;ĩ.ь=false;ĩ.ы=false;ĩ.ъ=false;ĩ.щ=
false;Ƀ(ĩ,"hudlcd:-0.55:0.99:0.7");continue;}}bool ƅ=false;foreach(IMyTextPanel Ƅ in Ψ){if(Ƅ==null)continue;if(!ƅ&&(Ƅ.
CustomName.Contains(ʢ)||Ƅ.CustomName.ToUpper().Contains(ʡ))){ƅ=true;Ƅ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool ƃ;void
Ƃ(bool Ë,bool Ŭ){ƃ=false;foreach(IMyConveyorSorter Ɓ in ϒ){if(Ɓ!=null&&Ɓ.IsFunctional){ƃ=true;if(Ŭ)Ɓ.Enabled=Ë;}}}void Ű(
Ǐ N){if(N==Ǐ.NoChange)return;foreach(IMyReflectorLight ů in Π){if(ů==null)continue;if(N==Ǐ.Off)ů.Enabled=false;else{ů.
Enabled=false;if(N==Ǐ.OnMax)ů.Radius=9999;}}}void ţ(Ƹ N,Color ī){if(N==Ƹ.NoChange)return;foreach(IMyLightingBlock ŝ in Υ){if(ŝ
==null)continue;if(N==Ƹ.Off)ŝ.Enabled=false;else ŝ.Enabled=true;if(N!=Ƹ.OnNoColourChange)ŝ.SetValue("Color",ī);}}void Ţ(Ƹ
N,Color ī){if(N==Ƹ.NoChange)return;foreach(IMyLightingBlock ŝ in Υ){if(ŝ==null)continue;if(N==Ƹ.Off)ŝ.Enabled=false;else
ŝ.Enabled=true;if(N!=Ƹ.OnNoColourChange)ŝ.SetValue("Color",ī);}}Color š=new Color(255,0,0,255);Color Š=new Color(255,0,0,
255);Color ş=new Color(255,0,0,255);void Ş(Ƹ N){if(N==Ƹ.NoChange)return;foreach(IMyLightingBlock ŝ in Ϊ){Ŝ(ŝ,N,Š);}foreach(
IMyLightingBlock ŝ in Σ){Ŝ(ŝ,N,ş);}}void Ŝ(IMyLightingBlock ŝ,Ƹ N,Color ī){if(ŝ==null)return;if(N==Ƹ.Off){ŝ.Enabled=false;ŝ.SetValue(
"Color",š);}else{ŝ.Enabled=true;if(N!=Ƹ.OnNoColourChange)ŝ.SetValue("Color",ī);}}int Ů=0;void ŭ(bool Ë,bool Ŭ){Ů=0;foreach(
IMyAirVent ū in ϔ){if(ū!=null){if(Ŭ)ū.Enabled=Ë;if(ū.CanPressurize)Ů++;}}}void Ū(bool Ë){foreach(IMyShipConnector ũ in ω){if(ũ!=
null)ũ.Enabled=Ë;}}void Ũ(bool Ë){foreach(IMyCameraBlock ŧ in ρ){if(ŧ!=null)ŧ.Enabled=Ë;}}void Ŧ(bool Ë){foreach(
IMySensorBlock ť in ϗ){if(ť!=null)ť.Enabled=Ë;}}bool Ť=false;List<string>Ĕ=new List<string>();bool À=false;List<string>î=new List<
string>();void µ(string x,string w){bool ª=false;List<IMyProgrammableBlock>z=new List<IMyProgrammableBlock>();try{if(w=="EFC")
z=μ;else if(w=="NavOS")z=Ω;foreach(IMyProgrammableBlock y in μ){if(y==null||!y.Enabled)continue;ª=(y as
IMyProgrammableBlock).TryRun(x);if(ª&&ɾ)Echo("Ran "+x+" on "+y.CustomName+" successfully.");else п.Add(new ш(w+" command failed!",w+
" command "+x+" failed!",1));if(w=="EFC")Ť=true;else if(w=="NavOS")À=true;break;}}catch(Exception ex){п.Add(new ш(w+
" command errored!",w+" command "+x+" errored!\n"+ex.Message,3));}}void º(string x,string w){if(w=="EFC"){if(μ.Count<1)return;if(Ť){Ĕ.Add(x
);return;}}if(w=="NavOS"){if(Ω.Count<1)return;if(À){î.Add(x);return;}}µ(x,w);}void v(){if(Ĕ.Count>0&&!Ť){µ(Ĕ[0],"EFC");Ĕ.
RemoveAt(0);}if(î.Count>0&&!À){µ(î[0],"NavOS");î.RemoveAt(0);}Ť=false;À=false;}int u=0;double t=0;double s=0;void q(){t=0;
foreach(IMyTerminalBlock p in ϑ){Á(p,ï.U!=Ǎ.Off&&ï.U!=Ǎ.MinDefence);}foreach(IMyTerminalBlock p in ϐ){Á(p,ï.U!=Ǎ.Off);}s=Math.
Round(100*(t/u));}void Á(IMyTerminalBlock Í,bool Ë){if(Í!=null&&Í.IsFunctional){t++;(Í as IMyConveyorSorter).Enabled=Ë;}}void
Ê(Ǎ N){if(N==Ǎ.NoChange)return;foreach(IMyTerminalBlock p in ϑ){if(p!=null&p.IsFunctional){switch(N){case Ǎ.Off:case Ǎ.
MinDefence:(p as IMyConveyorSorter).Enabled=false;break;case Ǎ.AllDefence:(p as IMyConveyorSorter).Enabled=true;if(ʝ){try{p.
SetValue("WC_FocusFire",false);p.SetValue("WC_Projectiles",true);p.SetValue("WC_Grids",true);p.SetValue("WC_LargeGrid",false);p.
SetValue("WC_SmallGrid",true);p.SetValue("WC_SubSystems",true);p.SetValue("WC_Biologicals",true);Ɉ(p);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;case Ǎ.Offence:(p as IMyConveyorSorter).Enabled=true;if(ʝ){try{p.SetValue("WC_FocusFire",false);p.SetValue(
"WC_Projectiles",true);p.SetValue("WC_Grids",true);p.SetValue("WC_LargeGrid",true);p.SetValue("WC_SmallGrid",true);p.SetValue(
"WC_SubSystems",true);p.SetValue("WC_Biologicals",true);Ɉ(p);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock p in ϐ){if(p!=null&p.IsFunctional){switch(N){case Ǎ.Off:(p as IMyConveyorSorter).Enabled=false;break;
case Ǎ.MinDefence:case Ǎ.AllDefence:case Ǎ.Offence:(p as IMyConveyorSorter).Enabled=true;if(ʝ){try{p.SetValue("WC_FocusFire"
,false);p.SetValue("WC_Projectiles",true);p.SetValue("WC_Grids",true);p.SetValue("WC_LargeGrid",false);p.SetValue(
"WC_SmallGrid",true);p.SetValue("WC_SubSystems",true);p.SetValue("WC_Biologicals",true);ɋ(p);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double É;void È(ǋ N){É=0;Ã(N);O();}double Ç=0;double Æ=0;double Å=0;double Ä=0;void Ã(ǋ N){Ç=0;Å=0;foreach
(IMyBatteryBlock M in ς){if(M!=null&&M.IsFunctional){Å+=M.CurrentStoredPower;Ç+=M.MaxStoredPower;É+=M.MaxOutput;M.Enabled
=true;bool Â=N==ǋ.Discharge;if(Â&&ʰ){if(k)M.ChargeMode=ChargeMode.Discharge;else M.ChargeMode=ChargeMode.Recharge;}}}Ä=
Math.Round(100*(É/Æ));}void Ì(){Æ=0;foreach(IMyBatteryBlock M in ς){Æ+=M.MaxOutput;}}void n(ǋ N){if(N==ǋ.NoChange)return;
foreach(IMyBatteryBlock M in ς){if(M!=null&M.IsFunctional){M.Enabled=true;if(N==ǋ.Auto)M.ChargeMode=ChargeMode.Auto;else if(N==
ǋ.StockpileRecharge)M.ChargeMode=ChargeMode.Recharge;else if(!ʰ)M.ChargeMode=ChargeMode.Recharge;}}}double L=0;double K=0
;double J=0;int H=0;void O(){K=0;H=0;foreach(IMyReactor E in Ϙ){if(E!=null&&E.IsFunctional){E.Enabled=true;if(Ϩ(E))H++;
else K+=E.MaxOutput;}}J=Math.Round(100*(K/L));É+=K;}void F(){L=0;foreach(IMyReactor E in Ϙ){L+=E.MaxOutput;}}void D(
IMyProjector B){B.CustomData=B.ProjectionOffset.X+"\n"+B.ProjectionOffset.Y+"\n"+B.ProjectionOffset.Z+"\n"+B.ProjectionRotation.X+
"\n"+B.ProjectionRotation.Y+"\n"+B.ProjectionRotation.Z+"\n";}void C(IMyProjector B){if(!B.IsFunctional)return;try{string[]G
=B.CustomData.Split('\n');Vector3I A=new Vector3I(int.Parse(G[0]),int.Parse(G[1]),int.Parse(G[2]));Vector3I Q=new
Vector3I(int.Parse(G[3]),int.Parse(G[4]),int.Parse(G[5]));B.Enabled=true;B.ProjectionOffset=A;B.ProjectionRotation=Q;B.
UpdateOffsetAndRotation();}catch{if(ɾ)Echo("Failed to load projector position for "+B.Name);}}int o=0;double m=0;double l=0;bool k=false;void h
(){k=false;m=0;foreach(IMyTerminalBlock Y in Ϗ){if(Y!=null&&Y.IsFunctional){m++;(Y as IMyConveyorSorter).Enabled=ï.S!=ǌ.
Off;if(!k){MyDetectedEntityInfo?f=Ǣ.ȓ(Y);if(f.HasValue){string e=f.Value.Name;if(e!=null&&e!=""){if(ɾ)Echo(
"At least one rail has a target!");k=true;}}}}}l=Math.Round(100*(m/o));}void Z(ǌ N){if(N==ǌ.NoChange)return;foreach(IMyTerminalBlock Y in Ϗ){if(Y!=null&Y
.IsFunctional){if(N==ǌ.Off){(Y as IMyConveyorSorter).Enabled=false;}else{(Y as IMyConveyorSorter).Enabled=true;if(ʝ){Y.
SetValue("WC_Grids",true);Y.SetValue("WC_LargeGrid",true);Y.SetValue("WC_SmallGrid",true);Y.SetValue("WC_SubSystems",true);Ɉ(Y);
}if(ʟ){if(N==ǌ.OpenFire){ʜ(Y);}else{ʞ(Y);}}}}}}class X{public string W="";public Ɯ V;public Ǎ U;public ǌ S;public ǎ P;
public ǐ R;public Ǐ Î;public Ƹ Ā;public Color þ;public Ƹ ý;public Color ü;public Ƹ û;public Color ú;public ǋ ù;public int ø;
public Ɯ ö;public ƽ õ;public Ɯ ô;public Ƽ ó;public Ɯ ò;public ƺ ñ;}string ð="N/A";X ï;Ɯ ÿ=Ɯ.On;Ǎ ā=Ǎ.Offence;ǌ Ē=ǌ.OpenFire;ǎ
ē=ǎ.On;ǐ đ=ǐ.On;Ǐ Đ=Ǐ.On;Ƹ ď=Ƹ.On;Color Ď=new Color(33,144,255,255);Ƹ č=Ƹ.On;Color Č=new Color(255,214,170,255);Ƹ ċ=Ƹ.On;
Color Ċ=new Color(33,144,255,255);ǋ ĉ=ǋ.Auto;int Ĉ=-1;Ɯ ć=Ɯ.NoChange;ƽ Ć=ƽ.NoChange;Ɯ ą=Ɯ.NoChange;Ƽ Ą=Ƽ.KeepFull;Ɯ ă=Ɯ.On;ƺ
Ă=ƺ.NoChange;void í(string Ý){X ë;if(!ѝ.TryGetValue(Ý,out ë)){п.Add(new ш("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ɾ)Echo("Setting stance '"+Ý+"'.");ï=ë;ð=Ý;ѓ();if(ɾ)Echo("Setting "+Ϗ.Count+" railguns to "+ï.S);Z(ï.S);
if(ɾ)Echo("Setting "+ώ.Count+" torpedoes to "+ï.V);Ȃ(ï.V);if(ɾ)Echo("Setting "+ϑ.Count+" _normalPdcs, "+ϐ.Count+
" defence _normalPdcs to "+ï.U);Ê(ï.U);if(ɾ)Echo("Setting "+ύ.Count+" epsteins, "+ξ.Count+" chems"+" to "+ï.P);Ə(ï.P,ï.R);if(ɾ)Echo("Setting "+ό.
Count+" rcs, "+Ϋ.Count+" atmos"+" to "+ï.R);ȁ(ï.R);if(ɾ)Echo("Setting "+ς.Count+" batteries to = "+ï.ù);n(ï.ù);if(ɾ)Echo(
"Setting "+ϖ.Count+" H2 tanks to stockpile = "+ï.ù);Ô(ï.ù);if(ɾ)Echo("Setting "+ϕ.Count+" O2 tanks to stockpile = "+ï.ù);ê(ï.ù);if
(ɽ){if(ɾ)Echo("No lighting was set because lighting control is disabled.");}else{if(ɾ)Echo("Setting "+Π.Count+
" spotlights to "+ï.Î);Ű(ï.Î);if(ɾ)Echo("Setting "+Υ.Count+" exterior lights to "+ï.Ā);ţ(ï.Ā,ï.þ);if(ɾ)Echo("Setting "+Τ.Count+
" exterior lights to "+ï.ý);Ţ(ï.ý,ï.ü);if(ɾ)Echo("Setting "+Ϊ.Count+" port nav lights, "+Σ.Count+" starboard nav lights to "+ï.û);Ş(ï.û);}if(ɾ
)Echo("Setting "+Ο.Count+" aux block to "+ï.ô);υ(ï.ô);if(ɾ)Echo("Setting "+ϝ.Count+" extrators to "+ï.ó);ғ(ï.ó);if(ɾ)Echo
("Setting "+Ϝ.Count+" hangar doors units to "+ï.ñ);ҵ(ï.ñ);if(ï.S==ǌ.OpenFire){if(ɾ)Echo("Setting "+Ξ.Count+
" doors to locked because we are in combat (rails set to open fire).");ҳ("locked","");}if(ɾ)Echo("Setting "+Χ.Count+" colour sync Lcds.");Ī();if(ï.õ==ƽ.Abort){º("Off","EFC");º("Abort",
"NavOS");}if(ï.ø>0){º("Set Burn "+ï.ø,"EFC");º("Thrust Set "+ï.ø/100,"NavOS");}if(ï.ö==Ɯ.On)º("Boost On","EFC");else if(ï.ö==Ɯ.
Off)º("Boost Off","EFC");if(ɾ)Echo("Finished setting stance.");}double Û=0;double Ú=0;double Ù=0;double Ø=0;void Ö(){Ù=0;Û=
0;foreach(IMyGasTank Ó in ϖ){if(Ó.IsFunctional){Ó.Enabled=true;Û+=Ó.Capacity;Ù+=(Ó.Capacity*Ó.FilledRatio);}}Ø=Math.Round
(100*(Û/Ú));}void Ü(){Ú=0;foreach(IMyGasTank Ó in ϖ){if(Ó!=null)Ú+=Ó.Capacity;}}void Ô(ǋ N){if(N==ǋ.NoChange)return;
foreach(IMyGasTank Ó in ϖ){if(Ó==null)continue;Ó.Enabled=true;if(N==ǋ.StockpileRecharge)Ó.Stockpile=true;else Ó.Stockpile=false
;}}double Ò=0;double Ñ=0;double Ð=0;double Õ=0;void Ï(){Ñ=0;Ò=0;foreach(IMyGasTank Ó in ϕ){if(Ó.IsFunctional){Ó.Enabled=
true;Ò+=Ó.Capacity;Ñ+=(Ó.Capacity*Ó.FilledRatio);}}Õ=Math.Round(100*(Ò/Ð));}void ì(){Ð=0;foreach(IMyGasTank Ó in ϕ){if(Ó!=
null)Ð+=Ó.Capacity;}}void ê(ǋ N){if(N==ǋ.NoChange)return;foreach(IMyGasTank Ó in ϕ){if(Ó==null)continue;Ó.Enabled=true;if(N
==ǋ.StockpileRecharge)Ó.Stockpile=true;else Ó.Stockpile=false;}}float é;float è;float ç;double æ;void å(){float ä=0;float
ã=0;float â=0;float á=0;foreach(IMyThrust à in ύ){if(à!=null&&à.IsFunctional){ä+=à.MaxThrust;â+=à.CurrentThrust;if(à.
Enabled){ã+=à.MaxThrust;á+=à.CurrentThrust;}}}æ=Math.Round(100*(ä/ç));if(ã==0){é=ä;è=â;}else{é=ã;è=á;}}void ß(){ç=0;foreach(
IMyThrust à in ύ){if(à!=null)ç+=à.MaxThrust;}}void Ə(ǎ N,ǐ ǿ){if(N==ǎ.NoChange)return;foreach(IMyThrust à in ύ){Ȁ(à,N,ǿ);}foreach
(IMyThrust à in ξ){Ȁ(à,N,ǿ,true);}}void Ȁ(IMyThrust à,ǎ N,ǐ ǿ,bool Ǿ=false){bool ǽ=à.CustomName.Contains(ʥ);if(ǽ){if(ǿ!=ǐ
.Off&&ǿ!=ǐ.AtmoOnly)à.Enabled=true;else à.Enabled=false;}else{bool Ǽ=à.CustomName.Contains(ʦ);if((N==ǎ.On)||(N==ǎ.Minimum
&&Ǽ)||(N==ǎ.EpsteinOnly&&!Ǿ)||(N==ǎ.ChemOnly&&Ǿ)){à.Enabled=true;}else{à.Enabled=false;}}}float ǻ;float Ǻ;double ǹ;void Ǹ(
){ǻ=0;foreach(IMyThrust à in ό){if(à!=null&&à.IsFunctional){ǻ+=à.MaxThrust;}}ǹ=Math.Round(100*(ǻ/Ǻ));}void Ƿ(){Ǻ=0;
foreach(IMyThrust à in ό){if(à!=null)Ǻ+=à.MaxThrust;}}void ȁ(ǐ N){foreach(IMyThrust à in ό){if(à!=null)ȋ(à,N);}foreach(
IMyThrust à in Ϋ){if(à!=null)ȋ(à,N,true);}}void ȋ(IMyThrust à,ǐ N,bool Ȋ=false){bool ȉ=à.GridThrustDirection==Vector3I.Backward;
bool Ȉ=à.GridThrustDirection==Vector3I.Forward;if((N==ǐ.On)||(N==ǐ.ForwardOff&&!ȉ)||(N==ǐ.ReverseOff&&!Ȉ)||(N==ǐ.RcsOnly&&!Ȋ
)||(N==ǐ.AtmoOnly&&Ȋ)){à.Enabled=true;}else{à.Enabled=false;}}int ȇ=0;double Ȇ=0;double ȅ=0;void Ȅ(){Ȇ=0;foreach(
IMyTerminalBlock ǵ in ώ){if(ǵ!=null&&ǵ.IsFunctional){Ȇ++;(ǵ as IMyConveyorSorter).Enabled=ï.V==Ɯ.On;if(ʒ){string ȃ=Ǣ.Ʋ(ǵ,0);int Ĥ=ϩ(ȃ);
if(ɾ)Echo("Launcher "+ǵ.CustomName+" needs "+ȃ+"("+Ĥ+")");ϟ(ǵ,Ĥ);}}}ȅ=Math.Round(100*(Ȇ/ȇ));}void Ȃ(Ɯ N){if(N==Ɯ.NoChange)
return;foreach(IMyTerminalBlock ǵ in ώ){if(ǵ!=null&ǵ.IsFunctional){if(N==Ɯ.Off){(ǵ as IMyConveyorSorter).Enabled=false;}else{(
ǵ as IMyConveyorSorter).Enabled=true;if(ʝ){ǵ.SetValue("WC_FocusFire",true);ǵ.SetValue("WC_Grids",true);ǵ.SetValue(
"WC_LargeGrid",true);ǵ.SetValue("WC_SmallGrid",false);ǵ.SetValue("WC_FocusFire",true);ǵ.SetValue("WC_SubSystems",true);Ɉ(ǵ);}}}}}ǳ Ǣ;
class ǳ{private Action<ICollection<MyDefinitionId>>Ǡ;private Action<ICollection<MyDefinitionId>>ǟ;private Action<ICollection<
MyDefinitionId>>Ǟ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>ǝ;private Func<long,MyTuple<bool,
int,int>>ǜ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>Ǜ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>ǡ;private Func<long,int,
MyDetectedEntityInfo>ǚ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǘ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>Ǘ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>ǖ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>Ǖ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>ǔ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>Ǔ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ǚ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>ǒ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>ǣ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ǵ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>ǲ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>Ǳ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ǰ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>ǯ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ǯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>ǭ;private Func<MyDefinitionId,float>Ǭ;private Func<long,bool>ǫ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>Ǫ;private Func<long,float>ǩ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ǩ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>Ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>ǥ;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>Ǥ;private Func<long,float>Ƕ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ȍ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȟ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ȭ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>Ȭ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>ȫ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>Ȫ;public bool ȩ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȩ){var ȧ=Ȩ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(Ȩ);if(ȧ==null)throw new Exception("WcPbAPI failed to activate");return Ȧ(ȧ);}public bool Ȧ
(IReadOnlyDictionary<string,Delegate>ȣ){if(ȣ==null)return false;ȥ(ȣ,"GetCoreWeapons",ref Ǡ);ȥ(ȣ,"GetCoreStaticLaunchers",
ref ǟ);ȥ(ȣ,"GetCoreTurrets",ref Ǟ);ȥ(ȣ,"GetBlockWeaponMap",ref ǝ);ȥ(ȣ,"GetProjectilesLockedOn",ref ǜ);ȥ(ȣ,
"GetSortedThreats",ref Ǜ);ȥ(ȣ,"GetObstructions",ref ǡ);ȥ(ȣ,"GetAiFocus",ref ǚ);ȥ(ȣ,"SetAiFocus",ref ǘ);ȥ(ȣ,"GetWeaponTarget",ref Ǘ);ȥ(ȣ,
"SetWeaponTarget",ref ǖ);ȥ(ȣ,"FireWeaponOnce",ref Ǖ);ȥ(ȣ,"ToggleWeaponFire",ref ǔ);ȥ(ȣ,"IsWeaponReadyToFire",ref Ǔ);ȥ(ȣ,
"GetMaxWeaponRange",ref Ǚ);ȥ(ȣ,"GetTurretTargetTypes",ref ǒ);ȥ(ȣ,"SetTurretTargetTypes",ref ǣ);ȥ(ȣ,"SetBlockTrackingRange",ref Ǵ);ȥ(ȣ,
"IsTargetAligned",ref ǲ);ȥ(ȣ,"IsTargetAlignedExtended",ref Ǳ);ȥ(ȣ,"CanShootTarget",ref ǰ);ȥ(ȣ,"GetPredictedTargetPosition",ref ǯ);ȥ(ȣ,
"GetHeatLevel",ref Ǯ);ȥ(ȣ,"GetCurrentPower",ref ǭ);ȥ(ȣ,"GetMaxPower",ref Ǭ);ȥ(ȣ,"HasGridAi",ref ǫ);ȥ(ȣ,"HasCoreWeapon",ref Ǫ);ȥ(ȣ,
"GetOptimalDps",ref ǩ);ȥ(ȣ,"GetActiveAmmo",ref Ǩ);ȥ(ȣ,"SetActiveAmmo",ref ǧ);ȥ(ȣ,"MonitorProjectile",ref Ǧ);ȥ(ȣ,"UnMonitorProjectile",
ref ǥ);ȥ(ȣ,"GetProjectileState",ref Ǥ);ȥ(ȣ,"GetConstructEffectiveDps",ref Ƕ);ȥ(ȣ,"GetPlayerController",ref Ȍ);ȥ(ȣ,
"GetWeaponAzimuthMatrix",ref Ȟ);ȥ(ȣ,"GetWeaponElevationMatrix",ref ȭ);ȥ(ȣ,"IsTargetValid",ref Ȭ);ȥ(ȣ,"GetWeaponScope",ref ȫ);ȥ(ȣ,"IsInRange",ref
Ȫ);return true;}private void ȥ<Ȥ>(IReadOnlyDictionary<string,Delegate>ȣ,string Ȣ,ref Ȥ ȡ)where Ȥ:class{if(ȣ==null){ȡ=null
;return;}Delegate Ƞ;if(!ȣ.TryGetValue(Ȣ,out Ƞ))throw new Exception(
$"{GetType().Name} :: Couldn't find {Ȣ} delegate of type {typeof(Ȥ)}");ȡ=Ƞ as Ȥ;if(ȡ==null)throw new Exception(
$"{GetType().Name} :: Delegate {Ȣ} is not type {typeof(Ȥ)}, instead it's: {Ƞ.GetType()}");}public void ȟ(ICollection<MyDefinitionId>Ȗ)=>Ǡ?.Invoke(Ȗ);public void Ȯ(ICollection<MyDefinitionId>Ȗ)=>ǟ?.Invoke(Ȗ);
public void ȸ(ICollection<MyDefinitionId>Ȗ)=>Ǟ?.Invoke(Ȗ);public bool ȷ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȶ,IDictionary<
string,int>Ȗ)=>ǝ?.Invoke(ȶ,Ȗ)??false;public MyTuple<bool,int,int>ȵ(long ȴ)=>ǜ?.Invoke(ȴ)??new MyTuple<bool,int,int>();public
void ȳ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȝ,IDictionary<MyDetectedEntityInfo,float>Ȗ)=>Ǜ?.Invoke(ȝ,Ȗ);public void Ȳ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ȝ,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ȗ)=>ǡ?.Invoke(ȝ,Ȗ);public
MyDetectedEntityInfo?ȱ(long Ȱ,int Ȝ=0)=>ǚ?.Invoke(Ȱ,Ȝ);public bool ȯ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȝ,long ȑ,int Ȝ=0)=>ǘ?.Invoke(ȝ,ȑ
,Ȝ)??false;public MyDetectedEntityInfo?ȓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ=0)=>Ǘ?.Invoke(ƒ,Ɛ);public void Ȓ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,long ȑ,int Ɛ=0)=>ǖ?.Invoke(ƒ,ȑ,Ɛ);public void Ȑ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
ƒ,bool ȏ=true,int Ɛ=0)=>Ǖ?.Invoke(ƒ,ȏ,Ɛ);public void Ȏ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,bool ȍ,bool ȏ,int Ɛ=0)=>ǔ
?.Invoke(ƒ,ȍ,ȏ,Ɛ);public bool Ȕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ=0,bool ț=true,bool Ț=false)=>Ǔ?.Invoke(ƒ,Ɛ
,ț,Ț)??false;public float ș(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ)=>Ǚ?.Invoke(ƒ,Ɛ)??0f;public bool Ș(Sandbox.
ModAPI.Ingame.IMyTerminalBlock ƒ,IList<string>Ȗ,int Ɛ=0)=>ǒ?.Invoke(ƒ,Ȗ,Ɛ)??false;public void ȗ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ƒ,IList<string>Ȗ,int Ɛ=0)=>ǣ?.Invoke(ƒ,Ȗ,Ɛ);public void ȕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,float Ǒ)=>Ǵ?.Invoke(
ƒ,Ǒ);public bool ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,long ƨ,int Ɛ)=>ǲ?.Invoke(ƒ,ƨ,Ɛ)??false;public MyTuple<bool,
Vector3D?>ƫ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,long ƨ,int Ɛ)=>Ǳ?.Invoke(ƒ,ƨ,Ɛ)??new MyTuple<bool,Vector3D?>();public bool
Ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,long ƨ,int Ɛ)=>ǰ?.Invoke(ƒ,ƨ,Ɛ)??false;public Vector3D?Ʃ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock ƒ,long ƨ,int Ɛ)=>ǯ?.Invoke(ƒ,ƨ,Ɛ)??null;public float ƪ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ)=>Ǯ?.
Invoke(ƒ)??0f;public float Ʈ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ)=>ǭ?.Invoke(ƒ)??0f;public float Ʒ(MyDefinitionId ƶ)=>Ǭ?.
Invoke(ƶ)??0f;public bool Ƶ(long ƕ)=>ǫ?.Invoke(ƕ)??false;public bool ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ)=>Ǫ?.Invoke(ƒ)
??false;public float Ƴ(long ƕ)=>ǩ?.Invoke(ƕ)??0f;public string Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ)=>Ǩ?.
Invoke(ƒ,Ɛ)??null;public void Ʊ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ,string ư)=>ǧ?.Invoke(ƒ,Ɛ,ư);public void Ư(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ,Action<long,int,ulong,long,Vector3D,bool>Ƙ)=>Ǧ?.Invoke(ƒ,Ɛ,Ƙ);public void ƙ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ,Action<long,int,ulong,long,Vector3D,bool>Ƙ)=>ǥ?.Invoke(ƒ,Ɛ,Ƙ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ɨ(ulong Ɩ)=>Ǥ?.Invoke(Ɩ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ƚ(long ƕ)=>Ƕ?.Invoke(ƕ)??0f;public long Ɣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ)=>Ȍ?.Invoke(ƒ)??-1;public
Matrix Ɠ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ)=>Ȟ?.Invoke(ƒ,Ɛ)??Matrix.Zero;public Matrix Ƒ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ƒ,int Ɛ)=>ȭ?.Invoke(ƒ,Ɛ)??Matrix.Zero;public bool ƛ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,long Ƨ,bool Ʀ,bool ƥ)=>Ȭ?.
Invoke(ƒ,Ƨ,Ʀ,ƥ)??false;public MyTuple<Vector3D,Vector3D>Ƥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƒ,int Ɛ)=>ȫ?.Invoke(ƒ,Ɛ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>ƣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ƣ)=>Ȫ?.Invoke(Ƣ)??new MyTuple<
bool,bool>();}int ơ=0;double Ơ=0;double Ɵ=0;void ƞ(){Ơ=0;foreach(IMyTerminalBlock Ɲ in ϓ){if(Ɲ!=null&&Ɲ.IsFunctional)Ơ++;}Ɵ=
Math.Round(100*(Ơ/ơ));}enum Ɯ{
    Off, On, NoChange
    }enum Ƹ{
    Off, On, NoChange, OnNoColourChange
    }enum Ǎ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum ǌ{
    Off, HoldFire, OpenFire, NoChange
    }enum ǎ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum ǐ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum Ǐ{
    On, Off, OnMax, NoChange
    }enum ǋ{
    Auto, StockpileRecharge, Discharge, NoChange
    }enum ƽ{
    Abort, NoChange
    }enum Ƽ{
    Off, On, FillWhenLow, KeepFull,
    }enum ƺ{
    Closed, Open, NoChange
    }
}sealed class ƻ{public double ƹ{get;private set;}private double ƾ{get{double Ǌ=ǂ[0];for(int ė=1;ė<Ǆ;ė++){Ǌ+=ǂ[ė];}return(
Ǌ/Ǆ);}}public double ǉ{get{double ǈ=ǂ[0];for(int ė=1;ė<Ǆ;ė++){if(ǂ[ė]>ǈ){ǈ=ǂ[ė];}}return ǈ;}}public double Ǉ{get;private
set;}public double ǆ{get{double ǅ=ǂ[0];for(int ė=1;ė<Ǆ;ė++){if(ǂ[ė]<ǅ){ǅ=ǂ[ė];}}return ǅ;}}public int Ǆ{get;}private double
ǃ;private IMyGridProgramRuntimeInfo ǀ;private double[]ǂ;private int ǁ=0;public ƻ(IMyGridProgramRuntimeInfo ǀ,int Ͽ=300){
this.ǀ=ǀ;this.Ǉ=ǀ.LastRunTimeMs;this.Ǆ=MathHelper.Clamp(Ͽ,1,int.MaxValue);this.ǃ=1.0/Ǆ;this.ǂ=new double[Ͽ];this.ǂ[ǁ]=ǀ.
LastRunTimeMs;this.ǁ++;}public void ƿ(){ƹ-=ǂ[ǁ]*ǃ;ƹ+=ǀ.LastRunTimeMs*ǃ;ǂ[ǁ]=ǀ.LastRunTimeMs;if(ǀ.LastRunTimeMs>Ǉ){Ǉ=ǀ.LastRunTimeMs;}
ǁ++;if(ǁ>=Ǆ){ǁ=0;ƹ=ƾ;Ǉ=ǀ.LastRunTimeMs;}}