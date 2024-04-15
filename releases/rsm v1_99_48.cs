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

string Version = "1.99.48 (2024-04-15)";
Ƽ Ό;int Ί=0;int Ή=0;int Έ=0;int Ά;bool ͽ=true;bool ͼ=true;bool ͻ=false;bool ͺ=false;bool ͷ=false;bool Ͷ=false;bool ʹ=
false;bool ͳ=false;bool Ͳ=false;int Ύ=0;int Ώ=0;double Μ;float Ν;string Λ;string Κ;string Ι;bool Θ=false;int Η=0;int Ζ=0;
Program(){Echo("Welcome to RSM\nV "+Version);ʺ();Ά=ɹ;Λ=Me.GetOwnerFactionTag();Ό=new Ƽ(Runtime);ϱ();ɾ.Add(0.5);ɾ.Add(0.25);ɾ.
Add(0.1);ɾ.Add(0.05);ņ();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo("Took "+ʺ());}void Main(string w,UpdateType
Ε){if(Ε==UpdateType.Update100)ˇ();else Δ(w);}void Δ(string w){if(ɼ)Echo("Processing command '"+w+"'...");if(w==""){у.Add(
new ь("COMMAND FAILED: Arg Required!","A command was ignored because the argument was blank.",3));return;}string[]Γ=w.Split
(':');if(Γ.Length<2){у.Add(new ь("COMMAND FAILED: Syntax Error!","A command was ignored because it wasn't recognised.",3)
);return;}if(Γ[0].ToLower()!="comms")Γ[1]=Γ[1].Replace(" ",string.Empty);switch(Γ[0].ToLower()){case"init":bool Β=true,Α=
true,ΐ=true;if(Γ.Length>2){foreach(string Ͱ in Γ){if(Ͱ.ToLower()=="nonames")Β=false;else if(Ͱ.ToLower()=="nosubs")Α=false;
else if(Ͱ.ToLower()=="noinv")ΐ=false;}}қ(Γ[1],Β,Α,ΐ);return;case"stance":Þ(Γ[1]);return;case"hudlcd":string ˉ="";if(Γ.Length
>2)ˉ=Γ[2];Ī(Γ[1],ˉ);return;case"doors":string ˬ="";if(Γ.Length>2)ˬ=Γ[2];ҷ(Γ[1],ˬ);return;case"comms":ˤ(Γ[1]);return;case
"printblockids":ɗ();return;case"printblockprops":ɓ(Γ[1]);return;case"spawn":if(Γ[1].ToLower()=="open"){Ͷ=true;Ά=ɹ;у.Add(new ь(
"Spawns were opened to friends","Spawns are now opened to the friends list as defined in PB custom data.",2));}else{Ͷ=false;Ά=ɹ;у.Add(new ь(
"Spawns were closed to friends","Spawns are now closed to the friends list as defined in PB custom data.",2));}return;case"projectors":if(Γ[1].ToLower(
)=="save"){foreach(IMyProjector C in Ϝ)D(C);у.Add(new ь("Projector positions saved",
"Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector C in Ϝ)B(C);у.Add(new ь("Projector positions loaded",
"Projector positions were loaded from custom data.",2));return;}default:у.Add(new ь("COMMAND FAILED: Syntax Error!","A command was ignored because it wasn't recognised.",3
));return;}}void ˇ(){if(Ή<ɺ){Ή++;return;}Ή=0;if(ͽ){if(ɻ)ʺ();Echo("Parsing custom data...");њ();ͽ=false;return;}ʽ();Η=
Runtime.CurrentInstructionCount;if(Η>Ζ)Ζ=Runtime.CurrentInstructionCount;if(ɻ)ʺ();if(Ā.ò==ƞ.On){ͻ=true;ͺ=true;}else if(Ā.ò==ƞ.
Off){ͻ=true;}if(Ά>=ɹ){Ά=0;ˈ();return;}Ά++;ˆ();ˁ();if(ɻ)Echo("Took "+ʺ());if(ɼ)Echo("Updating "+Ω.Count+" RSM Lcds");Ŀ();if(
ɻ)Echo("Took "+ʺ());}void ˆ(){ʿ();switch(Ί){case 0:if(ɼ)Echo("Refreshing "+ϑ.Count+" railguns...");f();if(ɻ)Echo("Took "+
ʺ());if(ͼ)break;else goto case 1;case 1:if(ɼ)Echo("Refreshing "+ϛ.Count+" reactors & "+υ.Count+" batteries...");É(Ā.ù);if
(ɻ)Echo("Took "+ʺ());if(ͼ)break;else goto case 2;case 2:if(ɼ)Echo("Refreshing "+ς.Count+" epsteins...");æ();if(ɻ)Echo(
"Took "+ʺ());if(ͼ)break;else goto case 3;case 3:if(ɼ)Echo("Refreshing "+ϔ.Count+" lidars...");Ƅ(ͺ,ͻ);if(ɻ)Echo("Took "+ʺ());if(
ɼ)Echo("Refreshing pb servers...");u();if(ɻ)Echo("Took "+ʺ());if(ͼ)break;else goto case 4;case 4:if(ɼ)Echo("Refreshing "+
Ρ.Count+" doors...");Һ();if(ɻ)Echo("Took "+ʺ());if(ɼ)Echo("Refreshing "+Π.Count+" airlocks...");Ҥ();if(ɻ)Echo("Took "+ʺ()
);break;default:if(ɼ)Echo("Booting complete");ͼ=false;Ί=0;return;}if(ͼ)Ί++;}void ˁ(){switch(Έ){case 0:if(ɼ)Echo(
"Clearing temp inventories...");ϰ();if(ɻ)Echo("Took "+ʺ());if(ɼ)Echo("Refreshing "+ϐ.Count+" torpedo launchers...");Ȅ();if(ɻ)Echo("Took "+ʺ());if(ɼ)
Echo("Refreshing items...");ϯ();if(ɻ)Echo("Took "+ʺ());break;case 1:if(ɼ)Echo("Running autoload...");ˠ();if(ɻ)Echo("Took "+ʺ
());break;case 2:if(ɼ)Echo("Refreshing "+Ϙ.Count+" H2 tanks...");Ø();if(ɻ)Echo("Took "+ʺ());if(ɼ)Echo(
"Refreshing refuel status...");Ҍ();if(ͷ){if(ɼ)Echo("Fuel low, filling extractors...");җ();if(ɻ)Echo("Took "+ʺ());return;}else{ˀ();if(ɻ)Echo("Took "+ʺ
());}Έ=0;return;}Έ++;}void ˀ(){if(ɼ)Echo("Refreshing "+ΰ.Count+" rcs...");Ǹ();if(ɼ)Echo("Refreshing "+ϓ.Count+" Pdcs & "+
ϒ.Count+" defensive Pdcs...");Á();if(ɼ)Echo("Refreshing "+ϝ.Count+" gyros...");ҝ(ͺ,ͻ);if(ɼ)Echo("Refreshing "+ϗ.Count+
" O2 tanks...");ß();if(ɼ)Echo("Refreshing "+φ.Count+" antennas...");ˮ();if(ɼ)Echo("Refreshing "+ύ.Count+" cargos...");ʛ();if(ɼ)Echo(
"Refreshing "+ϖ.Count+" vents...");ů(ͺ,ͻ);if(ɼ)Echo("Refreshing "+Σ.Count+" auxiliary blocks...");ω();if(ɼ)Echo("Refreshing "+ϕ.Count
+" welders...");Ơ();if(ɼ)Echo("Refreshing "+Ϋ.Count+" lcds...");Ɖ();if(ɼ)Echo("Refreshing "+ϙ.Count+" lcds...");Ŧ();if(ͻ)
{if(ɼ)Echo("Refreshing "+Ϗ.Count+" connectors...");Ŭ(ͺ);if(ɼ)Echo("Refreshing "+τ.Count+" cameras...");Ū(ͺ);if(ɼ)Echo(
"Refreshing "+Ϛ.Count+" sensors...");Ũ(ͺ);}}void ˈ(){if(ɼ)Echo("Clearing block lists...");ɫ();if(ɻ)Echo("Took "+ʺ());if(ɼ)Echo(
"Refreshing block lists...");GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,α);if(ɻ)Echo("Took "+ʺ());if(ɼ)Echo(
"Setting KeepFull threshold");ҍ();if(χ==null){if(Ϡ.Count>0)χ=Ϡ[0];else у.Add(new ь("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(ɼ)Echo("Finished block refresh.");if(ɻ)Echo("Took "+ʺ());}void ʿ(){try{ǵ=new Ǣ();ǵ.Ȫ(Me);}catch(Exception ex){ǵ
=null;у.Add(new ь("WcPbApi Error!","WcPbApi failed to start!\n"+ex.Message,1));Echo("WcPbAPI failed to activate!");Echo(
ex.Message);return;}}void ʽ(){string ʼ="REEDIT SHIP MANAGEMENT \n\n|- V "+Version+"\n|- Ship Name: "+ɸ+"\n|- Stance: "+ð+
"\n|- Step: "+Ά+"/"+ɹ+" ("+Έ+")";if(ͼ)ʼ+="\n|- Booting "+Ί;if(ɻ){Ό.ǀ();ʼ+="\n|- Runtime Av/Tick: "+(Math.Round(Ό.ƺ,2)/100)+" ms"+
"\n|- Runtime Max: "+Math.Round(Ό.Ǌ,4)+" ms"+"\n|- Instructions: "+Η+" ("+Ζ+")";}Echo(ʼ+"\n");}long ʻ=0;string ʺ(){long ʹ=DateTime.Now.Ticks
/TimeSpan.TicksPerMillisecond;if(ʻ==0){ʻ=ʹ;return"0 ms";}long ʸ=ʹ-ʻ;ʻ=ʹ;return ʸ+" ms";}bool ʾ=false;string ʷ="";double ˊ
=0;void ˮ(){ʾ=false;ˊ=0;foreach(IMyRadioAntenna ˢ in φ){if(ˢ!=null){if(ˢ.IsFunctional){float Ǔ=ˢ.Radius;if(Ǔ>ˊ)ˊ=Ǔ;if(ˢ.
IsBroadcasting&&ˢ.Enabled)ʾ=true;}}}}void ˤ(string ˣ){ʷ=ˣ;foreach(IMyTerminalBlock ɒ in φ){IMyRadioAntenna ˢ=ɒ as IMyRadioAntenna;if(ˢ
!=null)ˢ.HudText=ˣ;}}string ˡ="";void ˠ(){if(!ʖ)return;ˡ="";foreach(var ō in Ϧ){if(!ō.ϲ&&!ō.Ϩ)continue;if(ɼ)Echo(
"Checking "+ō.Ϣ);List<Ў>ˑ=ō.Ѕ.Concat(ō.ϴ).ToList();List<Ў>ː=new List<Ў>();List<Ў>ˏ=new List<Ў>();List<Ў>ˎ=new List<Ў>();List<Ў>ˍ=
new List<Ў>();List<Ў>ˌ=new List<Ў>();int ͱ=0;int Ξ=0;bool σ=false;double ώ=.97;if(ō.ϧ<1)ώ=ō.ϧ*.97;foreach(Ў ό in ˑ){if(ό==
null)continue;if(ό.Ћ){Ξ++;ͱ+=ό.Ќ;if(ɼ)Echo("Inv.FillFactor = "+ό.Њ+"\ntargetFillFactor = "+ώ);if(ό.Њ<ώ)ˎ.Add(ό);else if(ō.ϧ<
1&&ό.Њ>ō.ϧ*1.03)ˍ.Add(ό);if(ό.Њ!=0)ˏ.Add(ό);else if(!σ&&ō.Ї==0)σ=true;}else{ˌ.Add(ό);if(ό.Ќ>0){ː.Add(ό);}}}if(σ){if(ˡ!=""
)ˡ+="\n";ˡ+=ō.ϩ.SubtypeId;}if(ˎ.Count>0){int ϋ=(int)(ͱ/Ξ);ˎ=ˎ.OrderBy(ę=>ę.Ќ).ToList();if(ō.Ї>0){if(ɼ)Echo("Loading "+ō.ϩ
.SubtypeId+"...");ː=ː.OrderByDescending(ę=>ę.Ќ).ToList();ж(ː,ˎ,ō.ϩ,-1,ō.ϧ);}else{if(ɼ)Echo("Balancing "+ō.ϩ.SubtypeId+
"...");ˏ=ˏ.OrderByDescending(ę=>ę.Ќ).ToList();ж(ˏ,ˎ,ō.ϩ,ϋ);}}else if(ˍ.Count>0){if(ɼ)Echo("Unloading "+ō.ϩ.SubtypeId+"...");
List<Ў>ϊ=new List<Ў>();if(ː.Count>0)ϊ=ː;else ϊ=ˌ;ж(ˍ,ϊ,ō.ϩ,-1,1,ō.ϧ);}else{if(ɼ)Echo("No loading required "+ō.ϩ.SubtypeId+
"...");}}}void ω(){Ώ=0;foreach(IMyTerminalBlock ɒ in Σ){if(ɒ==null)continue;if(ɒ.IsWorking)Ώ++;}}void ψ(ƞ M){if(M==ƞ.NoChange
)return;foreach(IMyTerminalBlock ɒ in Σ){if(ɒ==null)continue;try{if(M==ƞ.Off)ɒ.ApplyAction("OnOff_Off");else ɒ.
ApplyAction("OnOff_On");}catch{if(ɼ)Echo("Failed to set aux block "+ɒ.CustomName);}}}IMyShipController χ;List<IMyRadioAntenna>φ=new
List<IMyRadioAntenna>();List<IMyBatteryBlock>υ=new List<IMyBatteryBlock>();List<IMyCameraBlock>τ=new List<IMyCameraBlock>();
List<IMyCargoContainer>ύ=new List<IMyCargoContainer>();List<IMyShipConnector>Ϗ=new List<IMyShipConnector>();List<
IMyShipController>Ϡ=new List<IMyShipController>();List<IMyAirtightHangarDoor>ϡ=new List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>ϟ=
new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ϟ=new List<IMyTerminalBlock>();List<IMyGyro>ϝ=new List<IMyGyro>();List<
IMyProjector>Ϝ=new List<IMyProjector>();List<IMyReactor>ϛ=new List<IMyReactor>();List<IMySensorBlock>Ϛ=new List<IMySensorBlock>();
List<IMyTerminalBlock>ϙ=new List<IMyTerminalBlock>();List<IMyGasTank>Ϙ=new List<IMyGasTank>();List<IMyGasTank>ϗ=new List<
IMyGasTank>();List<IMyAirVent>ϖ=new List<IMyAirVent>();List<IMyTerminalBlock>ϕ=new List<IMyTerminalBlock>();List<IMyConveyorSorter
>ϔ=new List<IMyConveyorSorter>();List<IMyTerminalBlock>ϓ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ϒ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>ϑ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ϐ=new List<IMyTerminalBlock>();List<
IMyThrust>ς=new List<IMyThrust>();List<IMyThrust>ΰ=new List<IMyThrust>();List<IMyThrust>ρ=new List<IMyThrust>();List<IMyThrust>ή=
new List<IMyThrust>();List<IMyProgrammableBlock>έ=new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>ά=new List<
IMyProgrammableBlock>();List<IMyTextPanel>Ϋ=new List<IMyTextPanel>();List<IMyTextPanel>Ϊ=new List<IMyTextPanel>();List<з>Ω=new List<з>();
List<IMyLightingBlock>ί=new List<IMyLightingBlock>();List<IMyLightingBlock>Ψ=new List<IMyLightingBlock>();List<
IMyLightingBlock>Φ=new List<IMyLightingBlock>();List<IMyLightingBlock>Υ=new List<IMyLightingBlock>();List<IMyReflectorLight>Τ=new List<
IMyReflectorLight>();List<IMyTerminalBlock>Σ=new List<IMyTerminalBlock>();List<џ>Ρ=new List<џ>();List<ұ>Π=new List<ұ>();bool Χ=false;
Dictionary<IMyTerminalBlock,string>Ο=new Dictionary<IMyTerminalBlock,string>();bool α(IMyTerminalBlock Ɉ){try{if(!Me.
IsSameConstructAs(Ɉ))return false;string π=Ɉ.GetOwnerFactionTag();if(π!=Λ&&π!=""){Echo("!"+π+": "+Ɉ.CustomName);Ύ++;return false;}if(Ɉ.
CustomName.Contains(ʮ))return false;if(!Χ&&ʗ&&!Ɉ.CustomName.Contains(ɸ))return false;if(Ɉ.CustomName.Contains(ʫ))Σ.Add(Ɉ);string ο
=Ɉ.BlockDefinition.ToString();if(ο.Contains("MedicalRoom/")){if(Ͷ)Ɉ.CustomData=Ι;else Ɉ.CustomData=Κ;ϙ.Add(Ɉ);if(Χ)Ο.Add(
Ɉ,"Medical Room");return false;}if(ο.Contains("SurvivalKit/")){if(Ͷ)Ɉ.CustomData=Ι;else Ɉ.CustomData=Κ;ϙ.Add(Ɉ);if(Χ)Ο.
Add(Ɉ,"Survival Kit");return false;}if(ο=="MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(Χ)Ο.Add(Ɉ,"Refill Station");
return false;}var ξ=Ɉ as IMyTextPanel;if(ξ!=null){Ϋ.Add(ξ);if(Χ)Ο.Add(Ɉ,"LCD");if(ξ.CustomName.Contains(ʭ)){з ν=new з();ν.ɒ=ξ;
Ω.Add(Ʉ(ν));}else if(!ʀ&&ξ.CustomName.Contains(ʬ))Ϊ.Add(ξ);return false;}if(ο==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return ɪ(Ɉ,"Flak",3);if(ο=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return ɪ(Ɉ,
"OPA",3);if(ο=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return ɪ(Ɉ,"Voltaire",3);if(ο.Contains
("Nariman Dynamics PDC"))return ɪ(Ɉ,"Nari",4);if(ο.Contains("Redfields Ballistics PDC"))return ɪ(Ɉ,"Red",4);if(ο==
"MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return ɨ(Ɉ,"Apollo");if(ο=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɨ(Ɉ,"Tycho");if(ο==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return ɨ(Ɉ,"Zeus");if(ο=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ɨ(Ɉ,"Tycho");if(ο.Contains(
"Ares_Class"))return ɨ(Ɉ,"Ares");if(ο.Contains("Artemis_Torpedo_Tube"))return ɨ(Ɉ,"Artemis");if(ο==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return ɘ(Ɉ,"Dawson",11);if(ο=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return ɘ(Ɉ,"Stiletto",12);if
(ο=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return ɘ(Ɉ,"Roci",13);if(ο==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return ɘ(Ɉ,"Foehammer",14);if(ο=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return ɘ(Ɉ,"Farren",15);
if(ο.Contains("Zakosetara"))return ɘ(Ɉ,"Zako",10);if(ο.Contains("Kess Hashari Cannon"))return ɘ(Ɉ,"Kess",16);if(ο.Contains
("Coilgun"))return ɘ(Ɉ,"Coilgun",13);if(ο.Contains("Glapion"))return ɘ(Ɉ,"Glapion",3);var μ=Ɉ as IMyThrust;if(μ!=null){if
(ο.ToUpper().Contains("RCS")){ΰ.Add(μ);if(Χ)Ο.Add(Ɉ,"RCS");}else if(ο.Contains("Hydro")){ρ.Add(μ);if(Χ)Ο.Add(Ɉ,"Chem");}
else if(ο.Contains("Atmospheric")){ή.Add(μ);if(Χ)Ο.Add(Ɉ,"Atmo");}else{ς.Add(μ);if(Χ){string ɩ="";if(ʓ){try{ɩ=Ɉ.
DefinitionDisplayNameText.Split('"')[1];ɩ=ʕ+ɩ[0].ToString().ToUpper()+ɩ.Substring(1).ToLower();}catch{if(ɼ)Echo("Failed to get drive type from "+
Ɉ.DefinitionDisplayNameText);}}Ο.Add(Ɉ,"Epstein"+ɩ);}}return false;}var λ=Ɉ as IMyCargoContainer;if(λ!=null){string κ=ο.
Split('/')[1];if(κ.Contains("Container")||κ.Contains("Cargo")){ύ.Add(λ);ϥ(Ɉ);if(Χ){double ι=Ɉ.GetInventory().MaxVolume.
RawValue;double θ=Math.Round(ι/1265625024,1);if(θ==0)θ=0.1;Ο.Add(Ɉ,"Cargo ["+θ+"]");}return false;}}var η=Ɉ as IMyGyro;if(η!=
null){ϝ.Add(η);if(Χ)Ο.Add(Ɉ,"Gyroscope");return false;}var ζ=Ɉ as IMyBatteryBlock;if(ζ!=null){υ.Add(ζ);if(Χ)Ο.Add(Ɉ,"Power"+
ʕ+"Battery");return false;}var ε=Ɉ as IMyReflectorLight;if(ε!=null){Τ.Add(ε);if(Χ)Ο.Add(Ɉ,"Spotlight");return false;}var
δ=Ɉ as IMyLightingBlock;if(δ!=null){if(Ɉ.CustomName.ToUpper().Contains("INTERIOR")||ο.Contains("Kitchen")||ο.Contains(
"Aquarium")){Ψ.Add(δ);if(Χ)Ο.Add(Ɉ,"Light"+ʕ+"Interior");}else if(Ɉ.CustomName.Contains(ʧ)){if(Ɉ.CustomName.ToUpper().Contains(
"STARBOARD")){Υ.Add(δ);if(Χ)Ο.Add(Ɉ,"Light"+ʕ+"Nav"+ʕ+"Starboard");}else{Φ.Add(δ);if(Χ)Ο.Add(Ɉ,"Light"+ʕ+"Nav"+ʕ+"Port");}}else{ί.
Add(δ);if(Χ)Ο.Add(Ɉ,"Light"+ʕ+"Exterior");}return false;}var γ=Ɉ as IMyGasTank;if(γ!=null){if(ο.Contains("Hydro")){Ϙ.Add(γ)
;if(Χ)Ο.Add(Ɉ,"Tank"+ʕ+"Hydrogen");}else{ϗ.Add(γ);if(Χ)Ο.Add(Ɉ,"Tank"+ʕ+"Oxygen");}return false;}var β=Ɉ as IMyReactor;if
(β!=null){ϛ.Add(β);ϥ(Ɉ,0);if(Χ){string ˋ="Lg";if(ο.Contains("SmallGenerator"))ˋ="Sm";else if(ο.Contains("MCRN"))ˋ="MCRN";
Ο.Add(Ɉ,"Power"+ʕ+"Reactor"+ʕ+ˋ);}return false;}var ʶ=Ɉ as IMyShipController;if(ʶ!=null){Ϡ.Add(ʶ);if(χ==null&&Ɉ.
CustomName.Contains("Nav"))χ=ʶ;if(ʶ.HasInventory)ϥ(Ɉ);if(Χ&&ο.Contains("Cockpit/")){if(ο.Contains("StandingCockpit")||ο.Contains(
"Console")){Ο.Add(Ɉ,"Console");return false;}else if(ο.Contains("Cockpit")){Ο.Add(Ɉ,"Cockpit");return false;}}}var ɋ=Ɉ as IMyDoor
;if(ɋ!=null){џ ɤ=new џ();ɤ.ɒ=ɋ;if(Ɉ.CustomName.Contains(ʦ)){try{string ɢ=Ɉ.CustomName.Split(ʕ)[3];ɤ.Ҁ=true;bool ɡ=false;
foreach(ұ ɠ in Π){if(ɢ==ɠ.Ұ){ɠ.Ҭ.Add(ɤ);ɡ=true;break;}}if(!ɡ){ұ ɟ=new ұ();ɟ.Ұ=ɢ;ɟ.Ҭ.Add(ɤ);Π.Add(ɟ);}}catch{if(ɼ)Echo(
"Error with airlock door name "+Ɉ.CustomName);Ρ.Add(ɤ);}}else{Ρ.Add(ɤ);}if(Χ)Ο.Add(Ɉ,"Door");return false;}var ɣ=Ɉ as IMyAirVent;if(ɣ!=null){ϖ.Add(ɣ);
if(Ɉ.CustomName.Contains(ʦ)){try{string ɢ=Ɉ.CustomName.Split(ʕ)[3];bool ɡ=false;foreach(ұ ɠ in Π){if(ɢ==ɠ.Ұ){ɠ.ҫ.Add(ɣ);ɡ=
true;break;}}if(!ɡ){ұ ɟ=new ұ();ɟ.Ұ=ɢ;ɟ.ҫ.Add(ɣ);Π.Add(ɟ);}}catch{if(ɼ)Echo("Error with airlock vent name "+Ɉ.CustomName);}}
if(Χ)Ο.Add(Ɉ,"Vent");return false;}var ɞ=Ɉ as IMyCameraBlock;if(ɞ!=null){τ.Add(ɞ);if(Χ)Ο.Add(Ɉ,"Camera");return false;}var
ɝ=Ɉ as IMyShipConnector;if(ɝ!=null){Ϗ.Add(ɝ);ϥ(Ɉ);if(Χ){string ɜ="";if(ο.Contains("Passageway"))ɜ=ʕ+"Passageway";Ο.Add(Ɉ,
"Connector"+ɜ);}return false;}var ɛ=Ɉ as IMyAirtightHangarDoor;if(ɛ!=null){ϡ.Add(ɛ);if(Χ)Ο.Add(Ɉ,"Door"+ʕ+"Hangar");return false;}
if(ο.Contains("Lidar")){var ɚ=Ɉ as IMyConveyorSorter;if(ɚ!=null){ϔ.Add(ɚ);if(Χ)Ο.Add(Ɉ,"LiDAR");return false;}}if(ο==
"MyObjectBuilder_OxygenGenerator/Extractor"){ϟ.Add(Ɉ);if(Χ)Ο.Add(Ɉ,"Extractor");return false;}if(ο=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){Ϟ.Add(Ɉ);if(Χ
)Ο.Add(Ɉ,"Extractor");return false;}var ɥ=Ɉ as IMyRadioAntenna;if(ɥ!=null){φ.Add(ɥ);if(Χ)Ο.Add(Ɉ,"Antenna");return false;
}var ɧ=Ɉ as IMyProgrammableBlock;if(ɧ!=null){if(Χ)Ο.Add(Ɉ,"PB Server");if(ɧ==Me)return false;try{if(Ɉ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))έ.Add(ɧ);else if(Ɉ.CustomData.Contains("NavConfig"))ά.Add(ɧ);return false;}catch{}}var
ɳ=Ɉ as IMyProjector;if(ɳ!=null){Ϝ.Add(ɳ);if(Χ)Ο.Add(Ɉ,"Projectors");return false;}var ɴ=Ɉ as IMySensorBlock;if(ɴ!=null){Ϛ
.Add(ɴ);if(Χ)Ο.Add(Ɉ,"Sensor");return false;}var ɲ=Ɉ as IMyCollector;if(ɲ!=null){ϥ(Ɉ);if(Χ)Ο.Add(Ɉ,"Collector");return
false;}if(ο.Contains("Welder")){ϕ.Add(Ɉ);if(Χ)Ο.Add(Ɉ,"Tool"+ʕ+"Welder");return false;}if(Χ){if(ο.Contains("LandingGear/")){
if(ο.Contains("Clamp"))Ο.Add(Ɉ,"Clamp");else if(ο.Contains("Magnetic"))Ο.Add(Ɉ,"Mag Lock");else Ο.Add(Ɉ,"Gear");return
false;}if(ο.Contains("Drill")){Ο.Add(Ɉ,"Tool"+ʕ+"Drill");return false;}if(ο.Contains("Grinder")){Ο.Add(Ɉ,"Tool"+ʕ+"Grinder");
return false;}if(ο.Contains("Solar")){Ο.Add(Ɉ,"Solar");return false;}if(ο.Contains("ButtonPanel")){Ο.Add(Ɉ,"Button Panel");
return false;}var ɱ=Ɉ as IMyConveyorSorter;if(ɱ!=null){Ο.Add(Ɉ,"Sorter");return false;}var ɰ=Ɉ as IMyMotorSuspension;if(ɰ!=
null){Ο.Add(Ɉ,"Suspension");return false;}var ɯ=Ɉ as IMyGravityGenerator;if(ɯ!=null){Ο.Add(Ɉ,"Grav Gen");return false;}var ɮ
=Ɉ as IMyTimerBlock;if(ɮ!=null){Ο.Add(Ɉ,"Timer");return false;}var ɭ=Ɉ as IMyGasGenerator;if(ɭ!=null){Ο.Add(Ɉ,"H2 Engine"
);return false;}var ɬ=Ɉ as IMyBeacon;if(ɬ!=null){Ο.Add(Ɉ,"Beacon");return false;}Ο.Add(Ɉ,Ɉ.DefinitionDisplayNameText);}
return false;}catch(Exception Ex){if(ɼ){Echo("Failed to sort "+Ɉ.CustomName+"\nAdded "+Ο.Count+" so far.");Echo(Ex.Message);}
return false;}}void ɫ(){χ=null;φ.Clear();υ.Clear();τ.Clear();ύ.Clear();Ϗ.Clear();Ϡ.Clear();Ρ.Clear();Π.Clear();ϡ.Clear();ϟ.
Clear();Ϟ.Clear();ϝ.Clear();Ϝ.Clear();ϛ.Clear();Ϛ.Clear();Ϙ.Clear();ϗ.Clear();ϖ.Clear();ϕ.Clear();ϔ.Clear();ϓ.Clear();ϒ.Clear
();ϑ.Clear();ϐ.Clear();ς.Clear();ΰ.Clear();ρ.Clear();ή.Clear();έ.Clear();ά.Clear();Ϋ.Clear();Ω.Clear();Ϊ.Clear();ί.Clear(
);Ψ.Clear();Φ.Clear();Υ.Clear();Τ.Clear();Σ.Clear();foreach(var ō in Ϧ)ō.Ѕ.Clear();if(Χ)Ο.Clear();}bool ɪ(
IMyTerminalBlock Ɉ,string ɇ,int Ɇ){if(Ɉ.CustomName.Contains(ʪ))ϒ.Add(Ɉ);else ϓ.Add(Ɉ);ϥ(Ɉ,Ɇ);if(Χ){string ɩ="";if(ʄ)ɩ=ʕ+ɇ;Ο.Add(Ɉ,"PDC"+
ɩ);}return false;}bool ɨ(IMyTerminalBlock Ɉ,string ɇ){ϐ.Add(Ɉ);if(Χ){string Ʌ="";if(ʄ)Ʌ=ʕ+ɇ;Ο.Add(Ɉ,"Torpedo"+Ʌ);}return
false;}bool ɘ(IMyTerminalBlock Ɉ,string ɇ,int Ɇ){ϑ.Add(Ɉ);ϥ(Ɉ,Ɇ);if(Χ){string Ʌ="";if(ʄ)Ʌ=ʕ+ɇ;Ο.Add(Ɉ,"Railgun"+Ʌ);}return
false;}з Ʉ(з ī,string ɉ=""){bool Ƀ=ɉ=="",Ɂ=!Ƀ;string ɀ=ī.ɒ.CustomData,ȿ="RSM.LCD";string[]Ⱦ=null;MyIni Ƚ=new MyIni();
MyIniParseResult ƌ;if(!Ƀ)Ɂ=true;else{if(ɀ.Substring(0,12)=="Show Header="){try{Ⱦ=ɀ.Split('\n');foreach(string ɂ in Ⱦ){if(ɂ.Contains(
"hud")){if(ɂ.Contains("lcd")){ɉ=ɂ;break;}}else if(ɂ.Contains("=")){string[]ȼ=ɂ.Split('=');if(ȼ[0]=="Show Tanks & Batteries")ī
.ё=bool.Parse(ȼ[1]);else if(ȼ[0]=="Show header"||ȼ[0]=="Show Header")ī.т=bool.Parse(ȼ[1]);else if(ȼ[0]==
"Show Header Overlay")ī.ђ=bool.Parse(ȼ[1]);else if(ȼ[0]=="Show Warnings")ī.ѓ=bool.Parse(ȼ[1]);else if(ȼ[0]=="Show Inventory")ī.ѐ=bool.Parse(ȼ
[1]);else if(ȼ[0]=="Show Thrust")ī.я=bool.Parse(ȼ[1]);else if(ȼ[0]=="Show Subsystem Integrity")ī.ю=bool.Parse(ȼ[1]);else
if(ȼ[0]=="Show Advanced Thrust")ī.э=bool.Parse(ȼ[1]);}}}catch(Exception ex){if(ɼ)Echo("Failed to parse legacy config.\n"+
ex.Message);Ɂ=true;}}else if(!Ƚ.TryParse(ɀ,out ƌ)){Ɂ=true;}else{ī.т=Ƚ.Get(ȿ,"ShowHeader").ToBoolean(ī.т);ī.ђ=Ƚ.Get(ȿ,
"ShowHeaderOverlay").ToBoolean(ī.ђ);ī.ѓ=Ƚ.Get(ȿ,"ShowWarnings").ToBoolean(ī.ѓ);ī.ё=Ƚ.Get(ȿ,"ShowPowerAndTanks").ToBoolean(ī.ё);ī.ѐ=Ƚ.Get(ȿ,
"ShowInventory").ToBoolean(ī.ѐ);ī.я=Ƚ.Get(ȿ,"ShowThrust").ToBoolean(ī.я);ī.ю=Ƚ.Get(ȿ,"ShowIntegrity").ToBoolean(ī.ю);ī.э=Ƚ.Get(ȿ,
"ShowAdvancedThrust").ToBoolean(ī.э);}}if(ī.т&&ī.ђ){ī.т=false;Ɂ=true;}if(Ɂ){if(Ⱦ==null)Ⱦ=ɀ.Split('\n');Ƚ.Set(ȿ,"ShowHeader",ī.т);Ƚ.Set(ȿ,
"ShowHeaderOverlay",ī.ђ);Ƚ.Set(ȿ,"ShowWarnings",ī.ѓ);Ƚ.Set(ȿ,"ShowPowerAndTanks",ī.ё);Ƚ.Set(ȿ,"ShowInventory",ī.ѐ);Ƚ.Set(ȿ,"ShowThrust",ī.я
);Ƚ.Set(ȿ,"ShowIntegrity",ī.ю);Ƚ.Set(ȿ,"ShowAdvancedThrust",ī.э);Ƚ.Set(ȿ,"Hud",ɉ);ī.ɒ.CustomData=Ƚ.ToString();if(Ƀ)у.Add(
new ь("LCD CONFIG ERROR!!","Failed to parse LCD config for "+ī.ɒ.CustomName+"!\nLCD config was reset!",3));}return ī;}void
Ɋ(IMyTerminalBlock ɒ,bool Ȫ){ɒ.GetActionWithName("ToolCore_Shoot_Action").Apply(ɒ);(ɒ as IMyConveyorSorter).
GetActionWithName("ToolCore_Shoot_Action").Apply(ɒ);}void ɗ(){List<IMyTerminalBlock>ɖ=new List<IMyTerminalBlock>();GridTerminalSystem.
GetBlocksOfType<IMyTerminalBlock>(ɖ);string ɕ="";foreach(IMyTerminalBlock ɔ in ɖ){ɕ+=ɔ.BlockDefinition+"\n";}if(φ.Count>0&&φ[0]!=null){
φ[0].CustomData=ɕ;}}void ɓ(string ȣ){IMyTerminalBlock ɒ=GridTerminalSystem.GetBlockWithName(ȣ);List<ITerminalAction>ɑ=new
List<ITerminalAction>();ɒ.GetActions(ɑ);List<ITerminalProperty>ɐ=new List<ITerminalProperty>();ɒ.GetProperties(ɐ);string ɏ=ɒ
.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction Ɏ in ɑ){ɏ+=Ɏ.Id+" "+Ɏ.Name+"\n";}ɏ+="\n\n**Properties**\n\n";
foreach(ITerminalProperty ɍ in ɐ){ɏ+=ɍ.Id+" "+ɍ.TypeName+"\n";}if(φ.Count>0&&φ[0]!=null)φ[0].CustomData=ɏ;ɒ.CustomData=ɏ;}void
Ɍ(IMyTerminalBlock Ƥ){bool ə=Ƥ.GetValue<bool>("WC_Repel");if(!ə)Ƥ.ApplyAction("WC_RepelMode");}void ɵ(IMyTerminalBlock Ƥ)
{bool ə=Ƥ.GetValue<bool>("WC_Repel");if(ə)Ƥ.ApplyAction("WC_RepelMode");}void ʡ(IMyTerminalBlock Ƥ){try{if(ǵ.Ɣ(Ƥ,0)==
VRageMath.Matrix.Zero)return;Ƥ.SetValue<Int64>("WC_Shoot Mode",3);if(ɼ)Echo("Shoot mode = "+Ƥ.GetValue<Int64>("WC_Shoot Mode"));}
catch{Echo("Failed to set fire mode to manual on "+Ƥ.CustomName);}}void ʠ(IMyTerminalBlock Ƥ){try{if(ǵ.Ɣ(Ƥ,0)==VRageMath.
Matrix.Zero)return;Ƥ.SetValue<Int64>("WC_Shoot Mode",0);if(ɼ)Echo("Shoot mode = "+Ƥ.GetValue<Int64>("WC_Shoot Mode"));}catch{
Echo("Failed to set fire mode to auto on "+Ƥ.CustomName);}}void ʟ(){if(χ!=null){try{Μ=χ.GetShipSpeed();Ν=χ.CalculateShipMass
().PhysicalMass;}catch(Exception exxie){Echo("Failed to get velocity or mass!");Echo(exxie.Message);}}}double ʞ=0;double
ʝ=0;double ʜ=0;void ʛ(){ʝ=0;foreach(IMyCargoContainer ʙ in ύ){if(ʙ!=null&&ʙ.IsFunctional){ʝ+=ʙ.GetInventory().MaxVolume.
RawValue;}}ʜ=Math.Round(100*(ʝ/ʞ));}void ʚ(){ʞ=0;foreach(IMyCargoContainer ʙ in ύ){if(ʙ!=null)ʞ+=ʙ.GetInventory().MaxVolume.
RawValue;}}MyIni ʘ=new MyIni();bool ʗ=false;bool ʖ=true;bool ʢ=true;bool ʣ=true;bool ʴ=true;bool ʵ=true;bool ʳ=false;string ʲ=""
;bool ʱ=true;int ʰ=3;int ʯ=6;string ʮ="[I]";string ʭ="[RSM]";string ʬ="[CS]";string ʫ="Autorepair";string ʪ="Repel";
string ʩ="Min";string ʨ="Docking";string ʧ="Nav";string ʦ="Airlock";string ʥ="[EFC]";string ʤ="[NavOS]";char ʕ='.';bool ʄ=true
;bool ʓ=true;List<string>ʂ=new List<string>();bool ʁ=false;bool ʀ=false;bool ɿ=true;List<double>ɾ=new List<double>();bool
ɽ=false;double ʃ=0.5;bool ɼ=true;bool ɻ=false;int ɺ=0;int ɹ=100;string ɸ="";bool ɷ(){string ɀ=Me.CustomData;string ȿ="";
bool ɶ=true;MyIniParseResult ƌ;if(!ʘ.TryParse(ɀ,out ƌ)){string[]ʔ=ɀ.Split('\n');if(ʔ[1]=="Reedit Ship Management"){Echo(
"Legacy config detected...");ѵ(ɀ);return false;}else{Echo("Could not parse custom data!\n"+ƌ.ToString());return false;}}try{ȿ="RSM.Main";Echo(ȿ);ʗ=
ʘ.Get(ȿ,"RequireShipName").ToBoolean(ʗ);ʖ=ʘ.Get(ȿ,"EnableAutoload").ToBoolean(ʖ);ʢ=ʘ.Get(ȿ,"AutoloadReactors").ToBoolean(
ʢ);ʣ=ʘ.Get(ȿ,"AutoConfigWeapons").ToBoolean(ʣ);ʴ=ʘ.Get(ȿ,"SetTurretFireMode").ToBoolean(ʴ);ʵ=ʘ.Get(ȿ,
"ManageBatteryDischarge").ToBoolean(ʵ);ȿ="RSM.Spawns";Echo(ȿ);ʳ=ʘ.Get(ȿ,"PrivateSpawns").ToBoolean(ʳ);ʲ=ʘ.Get(ȿ,"FriendlyTags").ToString(ʲ);ȿ=
"RSM.Doors";Echo(ȿ);ʱ=ʘ.Get(ȿ,"EnableDoorManagement").ToBoolean(ʱ);ʰ=ʘ.Get(ȿ,"DoorCloseTimer").ToInt32(ʰ);ʰ=ʘ.Get(ȿ,
"AirlockDoorDisableTimer").ToInt32(ʰ);ȿ="RSM.Keywords";Echo(ȿ);ʮ=ʘ.Get(ȿ,"Ignore").ToString(ʮ);ʭ=ʘ.Get(ȿ,"RsmLcds").ToString(ʭ);ʬ=ʘ.Get(ȿ,
"ColourSyncLcds").ToString(ʬ);ʫ=ʘ.Get(ȿ,"AuxiliaryBlocks").ToString(ʫ);ʪ=ʘ.Get(ȿ,"DefensivePdcs").ToString(ʪ);ʩ=ʘ.Get(ȿ,
"MinimumThrusters").ToString(ʩ);ʨ=ʘ.Get(ȿ,"DockingThrusters").ToString(ʨ);ʧ=ʘ.Get(ȿ,"NavLights").ToString(ʧ);ʦ=ʘ.Get(ȿ,"Airlock").ToString
(ʦ);ȿ="RSM.InitNaming";Echo(ȿ);ʕ=ʘ.Get(ȿ,"Ignore").ToChar(ʕ);ʄ=ʘ.Get(ȿ,"NameWeaponTypes").ToBoolean(ʄ);ʓ=ʘ.Get(ȿ,
"NameDriveTypes").ToBoolean(ʓ);string ʒ=ʘ.Get(ȿ,"BlocksToNumber").ToString("");string[]ʑ=ʒ.Split(',');ʂ.Clear();foreach(string ȣ in ʑ)if
(ȣ!="")ʂ.Add(ȣ);ȿ="RSM.Misc";Echo(ȿ);ʁ=ʘ.Get(ȿ,"DisableLightingControl").ToBoolean(ʁ);ʀ=ʘ.Get(ȿ,"DisableLcdColourControl"
).ToBoolean(ʀ);ɿ=ʘ.Get(ȿ,"ShowBasicTelemetry").ToBoolean(ɿ);string ʐ=ʘ.Get(ȿ,"DecelerationPercentages").ToString("");
string[]ʏ=ʐ.Split(',');if(ʏ.Length>1){ɾ.Clear();foreach(string ʎ in ʏ){ɾ.Add(double.Parse(ʎ)/100);}}ɽ=ʘ.Get(ȿ,
"ShowThrustInMetric").ToBoolean(ɽ);ʃ=ʘ.Get(ȿ,"ReactorFillRatio").ToDouble(ʃ);Ϧ[0].ϧ=ʃ;ȿ="RSM.Debug";Echo(ȿ);ɼ=ʘ.Get(ȿ,"VerboseDebugging").
ToBoolean(ɼ);ɻ=ʘ.Get(ȿ,"RuntimeProfiling").ToBoolean(ɻ);ɹ=ʘ.Get(ȿ,"BlockRefreshFreq").ToInt32(ɹ);ɺ=ʘ.Get(ȿ,"StallCount").ToInt32(
ɺ);ȿ="RSM.System";Echo(ȿ);ɸ=ʘ.Get(ȿ,"ShipName").ToString(ɸ);ȿ="RSM.InitItems";Echo(ȿ);foreach(ō ʍ in Ϧ){ʍ.Ј=ʘ.Get(ȿ,ʍ.ϩ.
SubtypeId).ToInt32(ʍ.Ј);}ȿ="RSM.InitSubSystems";Echo(ȿ);K=ʘ.Get(ȿ,"Reactors").ToDouble(K);K=ʘ.Get(ȿ,"Batteries").ToDouble(K);t=ʘ.
Get(ȿ,"Pdcs").ToInt32(t);ȇ=ʘ.Get(ȿ,"TorpLaunchers").ToInt32(ȇ);m=ʘ.Get(ȿ,"KineticWeapons").ToInt32(m);Û=ʘ.Get(ȿ,"H2Storage"
).ToDouble(Û);Õ=ʘ.Get(ȿ,"O2Storage").ToDouble(Õ);è=ʘ.Get(ȿ,"MainThrust").ToSingle(è);Ǻ=ʘ.Get(ȿ,"RCSThrust").ToSingle(Ǻ);Ҡ
=ʘ.Get(ȿ,"Gyros").ToDouble(Ҡ);ʞ=ʘ.Get(ȿ,"CargoStorage").ToDouble(ʞ);ƣ=ʘ.Get(ȿ,"Welders").ToInt32(ƣ);}catch(Exception ex){
Ѧ(ex,"Failed to parse section\n"+ȿ);}Echo("Parsing stances...");Dictionary<string,W>ʌ=new Dictionary<string,W>();List<
string>ʋ=new List<string>();ʘ.GetSections(ʋ);foreach(string ʊ in ʋ){if(ʊ.Contains("RSM.Stance.")){string ʉ=ʊ.Substring(11);
Echo(ʉ);W Ý=new W();string ʈ,ʇ="";string[]ʆ;int ɦ=33,ʅ=144,Ɉ=255,ę=255;bool Ѵ=false;W Ѭ=null;ʇ="Inherits";if(ʘ.ContainsKey(ʊ
,ʇ)){Ѵ=true;try{Ѭ=ʌ[ʘ.Get(ʊ,ʇ).ToString()];Echo("Inherits "+ʘ.Get(ʊ,ʇ).ToString());}catch(Exception ex){Ѧ(ex,
"Failed to find inheritee for\n"+ʊ+"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(Ѵ)Echo(Ѭ.U.ToString());ʇ="Torps";if(ʘ.
ContainsKey(ʊ,ʇ)){Ý.U=(ƞ)Enum.Parse(typeof(ƞ),ʘ.Get(ʊ,ʇ).ToString());Echo("1");}else if(Ѵ){Ý.U=Ѭ.U;Echo("2");}else{Ý.U=Ă;Echo("3");
}ʇ="Pdcs";if(ʘ.ContainsKey(ʊ,ʇ))Ý.S=(Ǐ)Enum.Parse(typeof(Ǐ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.S=Ѭ.S;else Ý.S=ē;ʇ=
"Kinetics";if(ʘ.ContainsKey(ʊ,ʇ))Ý.p=(ǎ)Enum.Parse(typeof(ǎ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.p=Ѭ.p;else Ý.p=Ĕ;ʇ="MainThrust";if
(ʘ.ContainsKey(ʊ,ʇ))Ý.Ï=(ǐ)Enum.Parse(typeof(ǐ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.Ï=Ѭ.Ï;else Ý.Ï=Ē;ʇ="ManeuveringThrust"
;if(ʘ.ContainsKey(ʊ,ʇ))Ý.ï=(ǒ)Enum.Parse(typeof(ǒ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ï=Ѭ.ï;else Ý.ï=đ;ʇ="Spotlights";if(
ʘ.ContainsKey(ʊ,ʇ))Ý.ā=(Ǒ)Enum.Parse(typeof(Ǒ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ā=Ѭ.ā;else Ý.ā=Đ;ʇ="ExteriorLights";if(
ʘ.ContainsKey(ʊ,ʇ))Ý.ÿ=(Ǎ)Enum.Parse(typeof(Ǎ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ÿ=Ѭ.ÿ;else Ý.ÿ=ď;ʇ=
"ExteriorLightColour";if(ʘ.ContainsKey(ʊ,ʇ)){ʈ=ʘ.Get(ʊ,ʇ).ToString();ʆ=ʈ.Split(',');ɦ=int.Parse(ʆ[0]);ʅ=int.Parse(ʆ[1]);Ɉ=int.Parse(ʆ[2]);ę=
int.Parse(ʆ[3]);Ý.þ=new Color(ɦ,ʅ,Ɉ,ę);}else if(Ѵ)Ý.þ=Ѭ.þ;else Ý.þ=Ď;ʇ="InteriorLights";if(ʘ.ContainsKey(ʊ,ʇ))Ý.ý=(Ǎ)Enum.
Parse(typeof(Ǎ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ý=Ѭ.ý;else Ý.ý=č;ʇ="InteriorLightColour";if(ʘ.ContainsKey(ʊ,ʇ)){ʈ=ʘ.Get(ʊ,
ʇ).ToString();ʆ=ʈ.Split(',');ɦ=int.Parse(ʆ[0]);ʅ=int.Parse(ʆ[1]);Ɉ=int.Parse(ʆ[2]);ę=int.Parse(ʆ[3]);Ý.ü=new Color(ɦ,ʅ,Ɉ,
ę);}else if(Ѵ)Ý.ü=Ѭ.ü;else Ý.ü=Č;ʇ="NavLights";if(ʘ.ContainsKey(ʊ,ʇ))Ý.û=(Ǎ)Enum.Parse(typeof(Ǎ),ʘ.Get(ʊ,ʇ).ToString());
else if(Ѵ)Ý.û=Ѭ.û;else Ý.û=ċ;ʇ="LcdTextColour";if(ʘ.ContainsKey(ʊ,ʇ)){ʈ=ʘ.Get(ʊ,ʇ).ToString();ʆ=ʈ.Split(',');ɦ=int.Parse(ʆ[0
]);ʅ=int.Parse(ʆ[1]);Ɉ=int.Parse(ʆ[2]);ę=int.Parse(ʆ[3]);Ý.ú=new Color(ɦ,ʅ,Ɉ,ę);}else if(Ѵ)Ý.ú=Ѭ.ú;else Ý.ú=Ċ;ʇ=
"TanksAndBatteries";if(ʘ.ContainsKey(ʊ,ʇ))Ý.ù=(ǌ)Enum.Parse(typeof(ǌ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ù=Ѭ.ù;else Ý.ù=ĉ;ʇ=
"NavOsEfcBurnPercentage";if(ʘ.ContainsKey(ʊ,ʇ))Ý.ø=ʘ.Get(ʊ,"NavOsEfcBurnPercentage").ToInt32(Ĉ);else if(Ѵ)Ý.ø=Ѭ.ø;else Ý.ø=Ĉ;ʇ="EfcBoost";if(ʘ.
ContainsKey(ʊ,ʇ))Ý.ö=(ƞ)Enum.Parse(typeof(ƞ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ö=Ѭ.ö;else Ý.ö=ć;ʇ="NavOsAbortEfcOff";if(ʘ.
ContainsKey(ʊ,ʇ))Ý.õ=(ƾ)Enum.Parse(typeof(ƾ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.õ=Ѭ.õ;else Ý.õ=Ć;ʇ="NavOsAbortEfcOff";if(ʘ.
ContainsKey(ʊ,ʇ))Ý.õ=(ƾ)Enum.Parse(typeof(ƾ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.õ=Ѭ.õ;else Ý.õ=Ć;ʇ="AuxMode";if(ʘ.ContainsKey(ʊ,ʇ))
Ý.ô=(ƞ)Enum.Parse(typeof(ƞ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ô=Ѭ.ô;else Ý.ô=ą;ʇ="Extractor";if(ʘ.ContainsKey(ʊ,ʇ))Ý.ó=(
ƽ)Enum.Parse(typeof(ƽ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ó=Ѭ.ó;else Ý.ó=Ą;ʇ="KeepAlives";if(ʘ.ContainsKey(ʊ,ʇ))Ý.ò=(ƞ)
Enum.Parse(typeof(ƞ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ò=Ѭ.ò;else Ý.ò=ă;ʇ="HangarDoors";if(ʘ.ContainsKey(ʊ,ʇ))Ý.ñ=(ƻ)Enum.
Parse(typeof(ƻ),ʘ.Get(ʊ,ʇ).ToString());else if(Ѵ)Ý.ñ=Ѭ.ñ;else Ý.ñ=î;ʌ.Add(ʉ,Ý);}catch(Exception ex){Ѧ(ex,
"Failed to parse stance\n"+ʉ+"\nproperty\n"+ʇ);}}}if(ʌ.Count<1){Echo("Failed to parse any stances!\nStances reset to default!");ɶ=false;}else{Echo
("Finished parsing "+ʌ.Count+" stances.");ѡ=ʌ;}ȿ="RSM.Stance";Echo(ȿ);ð=ʘ.Get(ȿ,"CurrentStance").ToString(ð);W ѳ;if(!ѡ.
TryGetValue(ð,out ѳ)){ð="N/A";Ā=null;}else Ā=ѳ;return ɶ;}void Ѳ(){ʘ.Clear();string ȿ,ȣ;ȿ="RSM.Main";ȣ="RequireShipName";ʘ.Set(ȿ,ȣ,ʗ
);ʘ.SetComment(ȿ,ȣ,"limit to blocks with the ship name in their name");ȣ="EnableAutoload";ʘ.Set(ȿ,ȣ,ʖ);ʘ.SetComment(ȿ,ȣ,
"enable RSM loading & balancing functionality for weapons");ȣ="AutoloadReactors";ʘ.Set(ȿ,ȣ,ʢ);ʘ.SetComment(ȿ,ȣ,"enable loading and balancing for reactors");ȣ="AutoConfigWeapons";
ʘ.Set(ȿ,ȣ,ʣ);ʘ.SetComment(ȿ,ȣ,"automatically configure weapon on stance set");ȣ="SetTurretFireMode";ʘ.Set(ȿ,ȣ,ʴ);ʘ.
SetComment(ȿ,ȣ,"set turret fire mode based on stance");ȣ="ManageBatteryDischarge";ʘ.Set(ȿ,ȣ,ʵ);ʘ.SetComment(ȿ,ȣ,
"set batteries to discharge on active railgun/coilgun target");ʘ.SetSectionComment(ȿ,д+" Reedit Ship Management\n"+д+" Config.ini\n Recompile to apply changes!\n"+д);ȿ="RSM.Spawns";
ȣ="PrivateSpawns";ʘ.Set(ȿ,ȣ,ʳ);ʘ.SetComment(ȿ,ȣ,"don't inject faction tag into spawn custom data");ȣ="FriendlyTags";ʘ.Set
(ȿ,ȣ,ʲ);ʘ.SetComment(ȿ,ȣ,"Comma seperated friendly factions or steam ids");ȿ="RSM.Doors";ȣ="EnableDoorManagement";ʘ.Set(ȿ
,ȣ,ʱ);ʘ.SetComment(ȿ,ȣ,"enable door management functionality");ȣ="DoorCloseTimer";ʘ.Set(ȿ,ȣ,ʰ);ʘ.SetComment(ȿ,ȣ,
"door open timer (x100 ticks)");ȣ="AirlockDoorDisableTimer";ʘ.Set(ȿ,ȣ,ʯ);ʘ.SetComment(ȿ,ȣ,"airlock door disable timer (x100 ticks)");ȿ="RSM.Keywords";
ȣ="Ignore";ʘ.Set(ȿ,ȣ,ʮ);ʘ.SetComment(ȿ,ȣ,"to identify blocks which RSM should ignore");ȣ="RsmLcds";ʘ.Set(ȿ,ȣ,ʭ);ʘ.
SetComment(ȿ,ȣ,"to identify RSM lcds");ȣ="ColourSyncLcds";ʘ.Set(ȿ,ȣ,ʬ);ʘ.SetComment(ȿ,ȣ,"to identify non RSM lcds for colour sync"
);ȣ="AuxiliaryBlocks";ʘ.Set(ȿ,ȣ,ʫ);ʘ.SetComment(ȿ,ȣ,"to identify aux blocks");ȣ="DefensivePdcs";ʘ.Set(ȿ,ȣ,ʪ);ʘ.SetComment
(ȿ,ȣ,"to identify defensive _normalPdcs");ȣ="MinimumThrusters";ʘ.Set(ȿ,ȣ,ʩ);ʘ.SetComment(ȿ,ȣ,
"to identify minimum epsteins");ȣ="DockingThrusters";ʘ.Set(ȿ,ȣ,ʨ);ʘ.SetComment(ȿ,ȣ,"to identify docking epsteins");ȣ="NavLights";ʘ.Set(ȿ,ȣ,ʧ);ʘ.
SetComment(ȿ,ȣ,"to identify navigational lights");ȣ="Airlock";ʘ.Set(ȿ,ȣ,ʦ);ʘ.SetComment(ȿ,ȣ,"to identify airlock doors and vents")
;ȿ="RSM.InitNaming";ȣ="NameDelimiter";ʘ.Set(ȿ,ȣ,ʕ.ToString());ʘ.SetComment(ȿ,ȣ,"single char delimiter for names");ȣ=
"NameWeaponTypes";ʘ.Set(ȿ,ȣ,ʄ);ʘ.SetComment(ȿ,ȣ,"append type names to all weapons on init");ȣ="NameDriveTypes";ʘ.Set(ȿ,ȣ,ʓ);ʘ.SetComment(
ȿ,ȣ,"append type names to all drives on init");string ѱ="";foreach(string Ѱ in ʂ){if(ѱ!="")ѱ+=",";ѱ+=Ѱ;}ȣ=
"BlocksToNumber";ʘ.Set(ȿ,ȣ,ʓ);ʘ.SetComment(ȿ,ȣ,"comma seperated list of block names to be numbered at init");ȿ="RSM.Misc";ȣ=
"DisableLightingControl";ʘ.Set(ȿ,ȣ,ʁ);ʘ.SetComment(ȿ,ȣ,"disable all lighting control");ȣ="DisableLcdColourControl";ʘ.Set(ȿ,ȣ,ʀ);ʘ.SetComment(ȿ,ȣ
,"disable text colour control for all lcds");ȣ="ShowBasicTelemetry";ʘ.Set(ȿ,ȣ,ɿ);ʘ.SetComment(ȿ,ȣ,
"show basic telemetry data on advanced thrust lcds");string ѯ="";foreach(double į in ɾ){if(ѯ!="")ѯ+=",";ѯ+=(į*100).ToString();}ȣ="DecelerationPercentages";ʘ.Set(ȿ,ȣ,ѯ);ʘ.
SetComment(ȿ,ȣ,"thrust percentages to show on advanced thrust lcds");ȣ="ShowThrustInMetric";ʘ.Set(ȿ,ȣ,ɽ);ʘ.SetComment(ȿ,ȣ,
"show basic telemetry data on advanced thrust lcds");ȣ="ReactorFillRatio";ʘ.Set(ȿ,ȣ,ʃ);ʘ.SetComment(ȿ,ȣ,"0-1, fill ratio for reactors");ȿ="RSM.Debug";ȣ="VerboseDebugging";
ʘ.Set(ȿ,ȣ,ɼ);ʘ.SetComment(ȿ,ȣ,"prints more logging info to PB details");ȣ="RuntimeProfiling";ʘ.Set(ȿ,ȣ,ɻ);ʘ.SetComment(ȿ,
ȣ,"prints script runtime profiling info to PB details");ȣ="BlockRefreshFreq";ʘ.Set(ȿ,ȣ,ɹ);ʘ.SetComment(ȿ,ȣ,
"ticks x100 between block refreshes");ȣ="StallCount";ʘ.Set(ȿ,ȣ,ɺ);ʘ.SetComment(ȿ,ȣ,"ticks x100 to stall between runs");ȿ="RSM.Stance";ȣ="CurrentStance";ʘ.
Set(ȿ,ȣ,ð);ʘ.SetSectionComment(ȿ,д+" Stances\n Add or remove as required\n"+д);string Ѯ="Red, Green, Blue, Alpha";foreach(
var ѭ in ѡ){ȿ="RSM.Stance."+ѭ.Key;W í=ѭ.Value;W Ѭ=null;if(í.V!=""){Ѭ=ѡ[í.V];ȣ="Inherits";ʘ.Set(ȿ,ȣ,í.V);ʘ.SetComment(ȿ,ȣ,
"Use stance of this name as a template for settings");}ȣ="Torps";if(Ѭ!=null&&í.U==Ѭ.U){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.U.ToString());ʘ.SetComment(ȿ,ȣ,
ѝ(typeof(ƞ)));}ȣ="Pdcs";if(Ѭ!=null&&í.S==Ѭ.S){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.S.ToString());ʘ.
SetComment(ȿ,ȣ,ѝ(typeof(Ǐ)));}ȣ="Kinetics";if(Ѭ!=null&&í.p==Ѭ.p){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.p.ToString(
));ʘ.SetComment(ȿ,ȣ,ѝ(typeof(ǎ)));}ȣ="MainThrust";if(Ѭ!=null&&í.Ï==Ѭ.Ï){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ
,ȣ,í.Ï.ToString());ʘ.SetComment(ȿ,"MainThrust",ѝ(typeof(ǐ)));}ȣ="ManeuveringThrust";if(Ѭ!=null&&í.ï==Ѭ.ï){if(ʘ.
ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ï.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(ǒ)));}ȣ="Spotlights";if(Ѭ!=null&&í.ā==Ѭ.ā)
{if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ā.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(Ǒ)));}ȣ="ExteriorLights";
if(Ѭ!=null&&í.ÿ==Ѭ.ÿ){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ÿ.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(Ǎ)));}
ȣ="ExteriorLightColour";if(Ѭ!=null&&í.þ==Ѭ.þ){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,ѧ(í.þ));ʘ.SetComment(ȿ,
ȣ,Ѯ);}ȣ="InteriorLights";if(Ѭ!=null&&í.ý==Ѭ.ý){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ý.ToString());ʘ.
SetComment(ȿ,ȣ,ѝ(typeof(Ǎ)));}ȣ="InteriorLightColour";if(Ѭ!=null&&í.ü==Ѭ.ü){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,ѧ(
í.ü));ʘ.SetComment(ȿ,ȣ,Ѯ);}ȣ="NavLights";if(Ѭ!=null&&í.û==Ѭ.û){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.û.
ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(Ǎ)));}ȣ="LcdTextColour";if(Ѭ!=null&&í.ú==Ѭ.ú){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.
Set(ȿ,ȣ,ѧ(í.ú));ʘ.SetComment(ȿ,ȣ,Ѯ);}ȣ="TanksAndBatteries";if(Ѭ!=null&&í.ù==Ѭ.ù){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{
ʘ.Set(ȿ,ȣ,í.ù.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(ǌ)));}ȣ="NavOsEfcBurnPercentage";if(Ѭ!=null&&í.ø==Ѭ.ø){if(ʘ.
ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ø.ToString());ʘ.SetComment(ȿ,ȣ,"Burn % 0-100, -1 for no change");}ȣ="EfcBoost";if(
Ѭ!=null&&í.ö==Ѭ.ö){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ö.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(ƞ)));}ȣ=
"NavOsAbortEfcOff";if(Ѭ!=null&&í.õ==Ѭ.õ){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.õ.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(ƾ))
);}ȣ="AuxMode";if(Ѭ!=null&&í.ô==Ѭ.ô){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ô.ToString());ʘ.SetComment(ȿ,ȣ
,ѝ(typeof(ƞ)));}ȣ="Extractor";if(Ѭ!=null&&í.ó==Ѭ.ó){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í.ó.ToString());ʘ
.SetComment(ȿ,ȣ,ѝ(typeof(ƽ)));}ȣ="KeepAlives";if(Ѭ!=null&&í.ò==Ѭ.ò){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);}else{ʘ.Set(ȿ,ȣ,í
.ò.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(ƞ)));}ȣ="HangarDoors";if(Ѭ!=null&&í.ñ==Ѭ.ñ){if(ʘ.ContainsKey(ȿ,ȣ))ʘ.Delete(ȿ,ȣ);
}else{ʘ.Set(ȿ,ȣ,í.ñ.ToString());ʘ.SetComment(ȿ,ȣ,ѝ(typeof(ƻ)));}}ȿ="RSM.System";ȣ="ShipName";ʘ.Set(ȿ,ȣ,ɸ);ʘ.
SetSectionComment(ȿ,д+" System\n All items below this point are\n set automatically when running init\n"+д);ȿ="RSM.InitItems";foreach(ō ʍ
in Ϧ){ȣ=ʍ.ϩ.SubtypeId;ʘ.Set(ȿ,ȣ,ʍ.Ј);}ȿ="RSM.InitSubSystems";ʘ.Set(ȿ,"Reactors",K);ʘ.Set(ȿ,"Batteries",K);ʘ.Set(ȿ,"Pdcs",t
);ʘ.Set(ȿ,"TorpLaunchers",ȇ);ʘ.Set(ȿ,"KineticWeapons",m);ʘ.Set(ȿ,"H2Storage",Û);ʘ.Set(ȿ,"O2Storage",Õ);ʘ.Set(ȿ,
"MainThrust",è);ʘ.Set(ȿ,"RCSThrust",Ǻ);ʘ.Set(ȿ,"Gyros",Ҡ);ʘ.Set(ȿ,"CargoStorage",ʞ);ʘ.Set(ȿ,"Welders",ƣ);Me.CustomData=ʘ.ToString();
}void ѵ(string ɀ){string[]ʋ=ɀ.Split(new string[]{"[Stances]"},StringSplitOptions.None);string[]ѿ=ʋ[0].Split('\n');string
Ѿ=ʋ[1];try{for(int Ę=1;Ę<ѿ.Length;Ę++){if(ѿ[Ę].Contains("=")){string ѽ=ѿ[Ę].Substring(1);switch(ѿ[(Ę-1)]){case
"Ship name. Blocks without this name will be ignored":ɸ=ѽ;break;case"Block name delimiter, used by init. One character only!":ʕ=char.Parse(ѽ.Substring(0,1));break;case
"Keyword used to identify RSM _allLcds.":ʭ=ѽ;break;case"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":ʫ=ѽ;break;
case"Keyword used to identify defence _normalPdcs.":ʪ=ѽ;break;case"Keyword used to identify minimum epstein drives.":ʩ=ѽ;
break;case"Keyword used to identify docking epstein drives.":ʨ=ѽ;break;case"Keyword to ignore block.":ʮ=ѽ;break;case
"Automatically configure _normalPdcs, Railguns, Torpedoes.":ʣ=bool.Parse(ѽ);break;case"Disable lighting all control.":ʁ=bool.Parse(ѽ);break;case
"Disable LCD Text Colour Enforcement.":ʀ=bool.Parse(ѽ);break;case"Enable Weapon Autoload Functionality.":ʖ=bool.Parse(ѽ);break;case
"Number these blocks at init.":ʂ.Clear();string[]Ѽ=ѽ.Split(',');foreach(string Ѱ in Ѽ){if(Ѱ!="")ʂ.Add(Ѱ);}break;case
"Add type names to weapons at init.":ʄ=bool.Parse(ѽ);break;case"Only set batteries to discharge on active railgun/coilgun target.":ʵ=bool.Parse(ѽ);break;
case"Show basic telemetry.":ɿ=bool.Parse(ѽ);break;case"Show Decel Percentages (comma seperated).":ɾ.Clear();string[]ѻ=ѽ.
Split(',');foreach(string į in ѻ){ɾ.Add(double.Parse(į)/100);}break;case"Fusion Fuel count":Ϧ[0].Ј=int.Parse(ѽ);break;case
"Fuel tank count":Ϧ[1].Ј=int.Parse(ѽ);break;case"Jerry can count":Ϧ[2].Ј=int.Parse(ѽ);break;case"40mm PDC Magazine count":Ϧ[3].Ј=int.
Parse(ѽ);break;case"40mm Teflon Tungsten PDC Magazine count":Ϧ[4].Ј=int.Parse(ѽ);break;case"220mm Torpedo count":case
"Torpedo count":Ϧ[5].Ј=int.Parse(ѽ);break;case"220mm MCRN torpedo count":Ϧ[6].Ј=int.Parse(ѽ);break;case"220mm UNN torpedo count":Ϧ[7].Ј
=int.Parse(ѽ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":Ϧ[8].Ј=int.Parse(ѽ);break;case
"Large ramshacke torpedo count":Ϧ[9].Ј=int.Parse(ѽ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":Ϧ[10].Ј=int.Parse(ѽ);break;
case"Dawson 100mm UNN Railgun rounds count":Ϧ[11].Ј=int.Parse(ѽ);break;case"Stiletto 100mm MCRN Railgun rounds count":Ϧ[12].
Ј=int.Parse(ѽ);break;case"T-47 80mm Railgun rounds count":Ϧ[13].Ј=int.Parse(ѽ);break;case
"Foehammer 120mm MCRN rounds count":Ϧ[14].Ј=int.Parse(ѽ);break;case"Farren 120mm UNN Railgun rounds count":Ϧ[15].Ј=int.Parse(ѽ);break;case
"Kess 180mm rounds count":Ϧ[16].Ј=int.Parse(ѽ);break;case"Steel plate count":Ϧ[17].Ј=int.Parse(ѽ);break;case
"Doors open timer (x100 ticks, default 3)":ʰ=int.Parse(ѽ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ʯ=int.Parse(ѽ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":ɺ=int.Parse(ѽ);break;case"Full refresh frequency (x100 ticks, default 50)":ɹ=int.Parse(ѽ);break;case
"Verbose script debugging. Prints more logging info to PB details.":ɼ=bool.Parse(ѽ);break;case"Private spawn (don't inject faction tag into SK custom data).":ʳ=bool.Parse(ѽ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":ʲ=string.Join("\n",ѽ.Split(','));break;case"Current Stance":ð=ѽ;W ѳ;if(!ѡ.TryGetValue(ð,out ѳ)){ð="N/A";Ā=null;}else Ā=
ѳ;break;case"Reactor Integrity":K=float.Parse(ѽ);break;case"Battery Integrity":Ç=float.Parse(ѽ);break;case"PDC Integrity"
:t=int.Parse(ѽ);break;case"Torpedo Integrity":ȇ=int.Parse(ѽ);break;case"Railgun Integrity":m=int.Parse(ѽ);break;case
"H2 Tank Integrity":Û=double.Parse(ѽ);break;case"O2 Tank Integrity":Õ=double.Parse(ѽ);break;case"Epstein Integrity":è=float.Parse(ѽ);break;
case"RCS Integrity":Ǻ=float.Parse(ѽ);break;case"Gyro Integrity":Ҡ=int.Parse(ѽ);break;case"Cargo Integrity":ʞ=double.Parse(ѽ)
;break;case"Welder Integrity":ƣ=int.Parse(ѽ);break;}}}}catch(Exception ex){Echo("Custom Data Error (vars)\n"+ex.Message);
}try{string[]Ѻ=Ѿ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(ɼ)Echo("Parsing "+(Ѻ.Length-1)+" stances");int
ѹ=24;Dictionary<string,W>ʌ=new Dictionary<string,W>();int[]Ѹ=new int[]{0,5,25,50,75,100};for(int Ę=1;Ę<Ѻ.Length;Ę++){
string[]ѷ=Ѻ[Ę].Split('=');string ʉ="";int[]Ѷ=new int[ѹ];ʉ=ѷ[0].Split(' ')[0];if(ɼ)Echo("Parsing '"+ʉ+"'");for(int Ѫ=0;Ѫ<Ѷ.
Length;Ѫ++){string[]ќ=ѷ[(Ѫ+1)].Split('\n');Ѷ[Ѫ]=int.Parse(ќ[0]);}W Ý=new W();if(Ѷ[0]==0)Ý.U=ƞ.Off;else Ý.U=ƞ.On;if(Ѷ[1]==0)Ý.S
=Ǐ.Off;else if(Ѷ[1]==1)Ý.S=Ǐ.MinDefence;else if(Ѷ[1]==2)Ý.S=Ǐ.AllDefence;else if(Ѷ[1]==3)Ý.S=Ǐ.Offence;else if(Ѷ[1]==4)Ý.
S=Ǐ.AllOnOnly;if(Ѷ[2]==0)Ý.p=ǎ.Off;else if(Ѷ[2]==1)Ý.p=ǎ.HoldFire;else if(Ѷ[2]==2)Ý.p=ǎ.OpenFire;if(Ѷ[3]==0)Ý.Ï=ǐ.Off;
else if(Ѷ[3]==1)Ý.Ï=ǐ.On;else if(Ѷ[3]==2)Ý.Ï=ǐ.Minimum;if(Ѷ[4]==0)Ý.ï=ǒ.Off;else if(Ѷ[4]==1)Ý.ï=ǒ.On;else if(Ѷ[4]==2)Ý.ï=ǒ.
ForwardOff;else if(Ѷ[4]==3)Ý.ï=ǒ.ReverseOff;if(Ѷ[5]==0)Ý.ā=Ǒ.Off;else if(Ѷ[5]==1)Ý.ā=Ǒ.On;else if(Ѷ[5]==2)Ý.ā=Ǒ.OnMax;if(Ѷ[6]==0)Ý
.ÿ=Ǎ.Off;else Ý.ÿ=Ǎ.On;Ý.þ=new Color(Ѷ[7],Ѷ[8],Ѷ[9],Ѷ[10]);if(Ѷ[11]==0)Ý.ý=Ǎ.Off;else Ý.ý=Ǎ.On;Ý.ü=new Color(Ѷ[12],Ѷ[13],
Ѷ[14],Ѷ[15]);if(Ѷ[16]==0)Ý.ù=ǌ.Auto;else if(Ѷ[16]==1)Ý.ù=ǌ.StockpileRecharge;else if(Ѷ[16]==2)Ý.ù=ǌ.Discharge;if(Ѷ[17]==0
)Ý.ö=ƞ.Off;else Ý.ö=ƞ.On;Ý.ø=Ѹ[Ѷ[18]];if(Ѷ[19]==0)Ý.õ=ƾ.NoChange;else Ý.õ=ƾ.Abort;if(Ѷ[20]==0)Ý.ô=ƞ.Off;else Ý.ô=ƞ.On;if(
Ѷ[21]==0)Ý.ó=ƽ.Off;else if(Ѷ[21]==1)Ý.ó=ƽ.On;else if(Ѷ[21]==2)Ý.ó=ƽ.FillWhenLow;else if(Ѷ[21]==3)Ý.ó=ƽ.KeepFull;if(Ѷ[22]
==0)Ý.ò=ƞ.Off;else Ý.ò=ƞ.On;if(Ѷ[23]==0)Ý.ñ=ƻ.Closed;else if(Ѷ[23]==1)Ý.ñ=ƻ.Open;else Ý.ñ=ƻ.NoChange;ʌ.Add(ʉ,Ý);}if(ʌ.
Count>=1){if(ɼ)Echo("Finished parsing "+ʌ.Count+" stances.");ѡ=ʌ;}else{Echo("Didn't find any stances!");}}catch(Exception ex)
{Echo("Custom Data Error (stances)\n"+ex.Message);}}void њ(){bool љ=ɷ();if(!љ){Ѡ();Ѳ();}if(Ā==null){Ā=ѡ.First().Value;}
string ј="";string ї="";if(!ʳ){ј=" ".PadRight(129,' ')+Λ+"\n";ї="\n".PadRight(19,'\n');}Κ=ј+ї;Ι=ј+string.Join("\n",ʲ.Split(','
))+ї;if(ɸ==""){if(ɼ)Echo("No ship name, trying to pull it from PB name...");string і="Untitled Ship";try{string[]ѕ=Me.
CustomName.Split(ʕ);if(ѕ.Length>1){ɸ=ѕ[0];if(ɼ)Echo(ɸ);}else ɸ=і;}catch{ɸ=і;}}}void ћ(bool Þ=true,bool є=false,bool ΐ=false){MyIni
Ƚ=new MyIni();string ɀ=Me.CustomData;MyIniParseResult ƌ;if(!Ƚ.TryParse(ɀ,out ƌ)){у.Add(new ь("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ȿ,ȣ;if(Þ){ȿ="RSM.Stance";ȣ="CurrentStance";Ƚ.Set(ȿ,ȣ,ð);}if(є){ȿ="RSM.InitSubSystems";Ƚ.Set(ȿ,
"Reactors",K);Ƚ.Set(ȿ,"Batteries",K);Ƚ.Set(ȿ,"Pdcs",t);Ƚ.Set(ȿ,"TorpLaunchers",ȇ);Ƚ.Set(ȿ,"KineticWeapons",m);Ƚ.Set(ȿ,"H2Storage",
Û);Ƚ.Set(ȿ,"O2Storage",Õ);Ƚ.Set(ȿ,"MainThrust",è);Ƚ.Set(ȿ,"RCSThrust",Ǻ);Ƚ.Set(ȿ,"Gyros",Ҡ);Ƚ.Set(ȿ,"CargoStorage",ʞ);Ƚ.
Set(ȿ,"Welders",ƣ);}if(ΐ){ȿ="RSM.InitItems";foreach(ō ʍ in Ϧ){ȣ=ʍ.ϩ.SubtypeId;Ƚ.Set(ȿ,ȣ,ʍ.Ј);}}Me.CustomData=Ƚ.ToString();}
string ѝ(Type ѩ){string Ѩ="";foreach(var Ō in Enum.GetValues(ѩ)){if(Ѩ!="")Ѩ+=", ";Ѩ+=Ō.ToString();}return Ѩ;}string ѧ(Color ĭ)
{return ĭ.R+", "+ĭ.G+", "+ĭ.B+", "+ĭ.A;}void Ѧ(Exception ѥ,string Ѥ){Runtime.UpdateFrequency=UpdateFrequency.None;string
ѣ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+Ѥ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ѣ);List<IMyTextPanel>Ѣ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ѣ,Ɉ=>Ɉ.CustomName
.Contains(ʭ));foreach(IMyTextPanel Ɔ in Ѣ){Ɔ.WriteText(ѣ);Ɔ.FontColor=new Color(193,0,197,255);}throw ѥ;}Dictionary<
string,W>ѡ=new Dictionary<string,W>();void Ѡ(){ѡ=new Dictionary<string,W>{{"Cruise",new W{U=ƞ.On,S=Ǐ.AllDefence,p=ǎ.HoldFire,Ï
=ǐ.EpsteinOnly,ï=ǒ.ForwardOff,ā=Ǒ.Off,ÿ=Ǎ.On,þ=new Color(33,144,255,255),ý=Ǎ.On,ü=new Color(255,214,170,255),ú=new Color(
33,144,255,255),ù=ǌ.Auto,ø=50,ö=ƞ.NoChange,õ=ƾ.Abort,ô=ƞ.NoChange,ó=ƽ.KeepFull,ò=ƞ.On,ñ=ƻ.NoChange}},{"StealthCruise",new
W{V="Cruise",U=ƞ.On,S=Ǐ.AllDefence,p=ǎ.HoldFire,Ï=ǐ.Minimum,ï=ǒ.ForwardOff,ā=Ǒ.Off,ÿ=Ǎ.Off,þ=new Color(0,0,0,255),ý=Ǎ.On,
ü=new Color(23,73,186,255),ú=new Color(23,73,186,255),ù=ǌ.Auto,ø=5,ö=ƞ.Off,õ=ƾ.Abort,ô=ƞ.NoChange,ó=ƽ.KeepFull,ò=ƞ.On,ñ=ƻ
.NoChange}},{"Docked",new W{V="Cruise",U=ƞ.On,S=Ǐ.AllDefence,p=ǎ.HoldFire,Ï=ǐ.Off,ï=ǒ.Off,ā=Ǒ.Off,ÿ=Ǎ.On,þ=new Color(33,
144,255,255),ý=Ǎ.On,ü=new Color(255,240,225,255),û=Ǎ.On,ú=new Color(255,255,255,255),ù=ǌ.StockpileRecharge,ø=-1,ö=ƞ.
NoChange,õ=ƾ.Abort,ô=ƞ.Off,ó=ƽ.On,ò=ƞ.On,ñ=ƻ.NoChange}},{"Docking",new W{V="Docked",U=ƞ.On,S=Ǐ.AllDefence,p=ǎ.HoldFire,Ï=ǐ.Off,ï
=ǒ.On,ā=Ǒ.OnMax,ÿ=Ǎ.On,þ=new Color(33,144,255,255),ý=Ǎ.On,ü=new Color(212,170,83,255),û=Ǎ.On,ú=new Color(212,170,83,255),
ù=ǌ.Auto,ø=-1,ö=ƞ.NoChange,õ=ƾ.Abort,ô=ƞ.Off,ó=ƽ.KeepFull,ò=ƞ.On,ñ=ƻ.NoChange}},{"NoAttack",new W{V="Docked",U=ƞ.Off,S=Ǐ.
Off,p=ǎ.Off,Ï=ǐ.On,ï=ǒ.On,ā=Ǒ.Off,ÿ=Ǎ.On,þ=new Color(255,255,255,255),ý=Ǎ.On,ü=new Color(84,157,82,255),û=Ǎ.NoChange,ú=new
Color(84,157,82,255),ù=ǌ.NoChange,ø=-1,ö=ƞ.NoChange,õ=ƾ.NoChange,ô=ƞ.NoChange,ó=ƽ.KeepFull,ò=ƞ.On,ñ=ƻ.NoChange}},{"Combat",
new W{V="Cruise",U=ƞ.On,S=Ǐ.AllDefence,p=ǎ.OpenFire,Ï=ǐ.On,ï=ǒ.On,ā=Ǒ.Off,ÿ=Ǎ.Off,þ=new Color(0,0,0,255),ý=Ǎ.On,ü=new Color
(210,98,17,255),û=Ǎ.On,ú=new Color(210,98,17,255),ù=ǌ.Discharge,ø=100,ö=ƞ.On,õ=ƾ.Abort,ô=ƞ.On,ó=ƽ.KeepFull,ò=ƞ.On,ñ=ƻ.
NoChange}},{"CQB",new W{V="Combat",U=ƞ.On,S=Ǐ.Offence,p=ǎ.OpenFire,Ï=ǐ.On,ï=ǒ.On,ā=Ǒ.Off,ÿ=Ǎ.Off,þ=new Color(0,0,0,255),ý=Ǎ.On,ü
=new Color(243,18,18,255),û=Ǎ.On,ú=new Color(243,18,18,255),ù=ǌ.Discharge,ø=100,ö=ƞ.On,õ=ƾ.Abort,ô=ƞ.On,ó=ƽ.KeepFull,ò=ƞ.
On,ñ=ƻ.NoChange}},{"WeaponsHot",new W{V="CQB",U=ƞ.On,S=Ǐ.Offence,p=ǎ.OpenFire,Ï=ǐ.NoChange,ï=ǒ.NoChange,ā=Ǒ.NoChange,ÿ=Ǎ.
NoChange,þ=new Color(0,0,0,255),ý=Ǎ.NoChange,ü=new Color(243,18,18,255),û=Ǎ.NoChange,ú=new Color(243,18,18,255),ù=ǌ.Discharge,ø=
-1,ö=ƞ.NoChange,õ=ƾ.NoChange,ô=ƞ.NoChange,ó=ƽ.KeepFull,ò=ƞ.On,ñ=ƻ.NoChange}}};}class џ{public IMyDoor ɒ;public int ѫ=0;
public int ў=0;public bool Ҁ=false;public bool Ҳ=false;}class ұ{public string Ұ;public bool ү=false;public int Ү=0;public bool
ҭ=false;public List<џ>Ҭ=new List<џ>();public List<IMyAirVent>ҫ=new List<IMyAirVent>();}int Ҫ=0;int ҩ=0;int Ҩ=0;bool ҧ(џ Ҧ
){bool ҥ=false;if(Ҧ.ɒ==null)return false;bool Ě=Ҧ.ɒ.OpenRatio>0;Ҫ++;if(ҳ(Ҧ.ɒ))Ҩ++;if(Ě){Ҧ.ɒ.Enabled=true;if(ɼ&&Ҧ.ѫ==0)
Echo("Door just opened... ("+Ҧ.ɒ.CustomName+")");Ҧ.ѫ++;if(Ҧ.ѫ>=ʰ){Ҧ.ѫ=0;Ҧ.ɒ.CloseDoor();ҥ=true;}}else{ҩ++;}return ҥ;}void Ҥ(
){if(!ʱ){if(ɼ)Echo("Door management is disabled.");return;}foreach(ұ ɠ in Π){foreach(џ Ҧ in ɠ.Ҭ){if(Ҧ.ɒ==null)continue;
bool ҥ=ҧ(Ҧ);if(ҥ){if(ɼ)Echo("Airlock door "+Ҧ.ɒ.CustomName+" just closed");if(ɠ.ҭ)ɠ.ҭ=false;else{ɠ.ү=true;Ҧ.Ҳ=true;if(ɼ)Echo
("Airlock "+ɠ.Ұ+" needs to cycle");}}}if(ɠ.ү){foreach(џ Ҧ in ɠ.Ҭ){if(Ҧ.ɒ==null)continue;if(Ҧ.ɒ.OpenRatio>0)Ҧ.ɒ.CloseDoor(
);else Ҧ.ɒ.Enabled=false;}bool ҽ=false;foreach(IMyAirVent Ҽ in ɠ.ҫ){if(Ҽ==null)continue;if(!Ҽ.Enabled)Ҽ.Enabled=true;if(!
Ҽ.Depressurize)Ҽ.Depressurize=true;if(Ҽ.CanPressurize&&Ҽ.GetOxygenLevel()<.01&&ɠ.ү)ҽ=true;}ɠ.Ү++;bool һ=true;if(ɠ.Ү>=ʯ){һ
=false;ҽ=true;}if(ҽ){ɠ.ү=false;ɠ.Ү=0;ɠ.ҭ=true;foreach(џ Ҧ in ɠ.Ҭ){if(Ҧ.ɒ==null)continue;Ҧ.ɒ.Enabled=true;if(Ҧ.Ҳ)Ҧ.Ҳ=false
;else if(һ)Ҧ.ɒ.OpenDoor();}}}}}void Һ(){if(!ʱ){if(ɼ)Echo("Door management is disabled.");return;}Ҫ=0;ҩ=0;Ҩ=0;foreach(џ Ҧ
in Ρ)ҧ(Ҧ);}void ҹ(ƻ M){if(M==ƻ.NoChange)return;foreach(IMyAirtightHangarDoor Ҹ in ϡ){if(Ҹ==null)continue;if(M==ƻ.Closed)Ҹ.
CloseDoor();else Ҹ.OpenDoor();}}void ҷ(string Ҷ,string ҵ){Ҷ=Ҷ.ToLower();foreach(џ Ҧ in Ρ){if(ҵ==""||Ҧ.ɒ.CustomName.Contains(ҵ)){
bool Ҵ=ҳ(Ҧ.ɒ);if(Ҵ&&(Ҷ=="locked"||Ҷ=="toggle"))Ҧ.ɒ.ApplyAction("AnyoneCanUse");if(!Ҵ&&(Ҷ=="unlocked"||Ҷ=="toggle"))Ҧ.ɒ.
ApplyAction("AnyoneCanUse");}}}bool ҳ(IMyDoor Ҧ){var ƙ=Ҧ.GetActionWithName("AnyoneCanUse");StringBuilder ң=new StringBuilder();ƙ.
WriteValue(Ҧ,ң);return(ң.ToString()=="On");}double ҁ;int Җ=0;int ҕ=8;int Ҕ=10;double ғ=3;double Ғ=245000;double ґ=50000;double Ґ=
100;void ҏ(ƽ M){foreach(IMyTerminalBlock Ҏ in ϟ){if(Ҏ==null)continue;if(M==ƽ.Off)Ҏ.ApplyAction("OnOff_Off");else Ҏ.
ApplyAction("OnOff_On");}}void ҍ(){if(ϟ.Count<1&&Ϟ.Count>1)ҁ=(ғ*ґ);else ҁ=(ғ*Ғ);}void Ҍ(){if(Ā.ó==ƽ.Off||Ā.ó==ƽ.On){if(ɼ)Echo(
"Extractor management disabled.");}else if(Җ>0){Җ--;if(ɼ)Echo("waiting ("+Җ+")...");}else if(Ϙ.Count<1){if(ɼ)Echo("No tanks!");}else if(Ā.ó==ƽ.
FillWhenLow&&Ґ<Ҕ){if(ɼ)Echo("Fuel low! ("+Ґ+"% / "+Ҕ+"%)");ͷ=true;ҋ();}else if(Ā.ó==ƽ.KeepFull&&Ú<(Ü-ҁ)){ͷ=true;ҋ();if(ɼ)Echo(
"Fuel ready for top up ("+Ú+" < "+(Ü-ҁ)+")");}else if(ɼ){Echo("Fuel level OK ("+Ґ+"%).");if(Ā.ó==ƽ.KeepFull)Echo("Keeping tanks full\n("+Ú+" < "+
(Ü-ҁ)+")");}}void ҋ(){string Ǝ="";int Ҋ=8;if(Ґ<5){Ҋ=0;if(ҕ!=Ҋ)Ǝ="v fast";}else if(Ґ<10){Ҋ=2;if(ҕ!=Ҋ)Ǝ="fast";}else if(Ґ<
60){Ҋ=4;if(ҕ!=Ҋ)Ǝ="medium";}else if(ҕ!=Ҋ)Ǝ="slow";if(Ǝ!=""){ҕ=Ҋ;у.Add(new ь("Extractor loading "+Ǝ,
"Extractor load speed has been set to "+Ǝ+" automatically)",0));}}void җ(){ͷ=false;IMyTerminalBlock ҙ=null;int ō=1;foreach(IMyTerminalBlock Ҏ in ϟ){if(Ҏ.
IsFunctional){ҙ=Ҏ;break;}}if(ҙ==null){foreach(IMyTerminalBlock Ҏ in Ϟ){if(Ҏ.IsFunctional){ҙ=Ҏ;ō=2;break;}}if(ҙ==null){if(ɼ)Echo(
"No functional extractor to load!");ͳ=true;return;}}ͳ=false;if(Ϧ[ō].Љ<1){Ͳ=true;if(ɼ)Echo("No spare "+Ϧ[ō].ϩ.SubtypeId+" to load!");return;}Җ=ҕ;Ў ό=new Ў(
);ό.ɒ=ҙ;ό.ό=ҙ.GetInventory();ҙ.ApplyAction("OnOff_On");List<Ў>Ң=new List<Ў>();Ң.Add(ό);if(ɼ)Echo(
"Attempting to load extractor "+ҙ.CustomName);bool ɶ=ж(Ϧ[ō].Ѕ,Ң,Ϧ[ō].ϩ);string ҡ="fuel tank";if(ō==2)ҡ="jerry can";if(ɶ)у.Add(new ь("Loaded a "+ҡ,
"Sucessfully loaded a "+ҡ+" into an extractor.",0));}double Ҡ=0;int ҟ=0;double Ҟ=0;void ҝ(bool Ì,bool Ů){ҟ=0;foreach(IMyGyro Ҝ in ϝ){if(Ҝ!=null
&&Ҝ.IsFunctional){ҟ++;if(Ů)Ҝ.Enabled=Ì;}}Ҟ=Math.Round(100*(ҟ/Ҡ));}void қ(string Қ,bool Β=true,bool Α=true,bool ΐ=true){if(
ɼ)Echo("Initialising a ship as '"+Қ+"'...");Χ=true;ˈ();ϯ();Ά=0;Χ=false;ɸ=Қ;if(ɼ)Echo("Initialising lcds...");ƈ();if(Α){if
(ɼ)Echo("Initialising subsystem values...");Â();ȁ();P();F();Ö();ì();ʚ();t=ϓ.Count+ϒ.Count;ȇ=ϐ.Count;m=ϑ.Count;Ҡ=ϝ.Count;ƣ
=ϕ.Count;}if(ΐ){if(ɼ)Echo("Initialising item values...");Ϯ();}if(Β){if(ɼ)Echo("Initialising block names...");Ͽ();}ћ(false
,Α,ΐ);у.Add(new ь("Init:"+Қ,"Initialised '"+Қ+"'\nGood Hunting!",3));}class Ѓ{public int ϫ=0;public int Ё=0;public int Ѐ=
0;}void Ͽ(){Dictionary<string,Ѓ>Ͼ=new Dictionary<string,Ѓ>();if(ʂ.Count>0){foreach(string Z in ʂ){if(ɼ)Echo("Numbering "+
Z);Ͼ.Add(Z,new Ѓ());}foreach(var ϻ in Ο){Ѓ Ͻ;if(Ͼ.TryGetValue(ϻ.Value,out Ͻ)){Ͼ[ϻ.Value].Ё++;}}foreach(var ϼ in Ͼ){if(ϼ.
Value.Ё<10)ϼ.Value.Ѐ=1;else if(ϼ.Value.Ё>99)ϼ.Value.Ѐ=3;else ϼ.Value.Ѐ=2;}}foreach(var ϻ in Ο){string Ϻ="";string Ϲ=ϻ.Value;Ѓ
ϸ;if(Ͼ.TryGetValue(ϻ.Value,out ϸ)){if(ϸ.Ё>1){ϸ.ϫ++;Ϻ=ʕ+ϸ.ϫ.ToString().PadLeft(ϸ.Ѐ,'0');}}ϻ.Key.CustomName=ɸ+ʕ+Ϲ+Ϻ+Ϸ(ϻ.Key
.CustomName,Ϲ);}}string Ϸ(string ȣ,string ϵ=""){try{string[]Ђ=ȣ.Split(ʕ);string[]Є=ϵ.Split(ʕ);string ƌ="";if(Ђ.Length<3)
return"";for(int Ę=2;Ę<Ђ.Length;Ę++){int Б=0;bool А=int.TryParse(Ђ[Ę],out Б);if(А)Ђ[Ę]="";foreach(string Џ in Є){if(Џ==Ђ[Ę])Ђ[
Ę]="";}if(Ђ[Ę]!="")ƌ+=ʕ+Ђ[Ę];}return ƌ;}catch{return"";}}class Ў{public IMyTerminalBlock ɒ{get;set;}public IMyInventory ό
{get;set;}List<MyInventoryItem>Ѝ=new List<MyInventoryItem>();public int Ќ=0;public bool Ћ=false;public float Њ;}class ō{
public int Љ=0;public int Ј=0;public int Ї=0;public double І;public List<Ў>Ѕ=new List<Ў>();public List<Ў>ϴ=new List<Ў>();
public MyItemType ϩ;public bool ϲ=false;public bool Ϩ=false;public string Ϣ;public double ϧ=1;}List<ō>Ϧ=new List<ō>();void ϥ(
IMyTerminalBlock Ɉ,int ʍ=99){if(ʍ==99){foreach(var ō in Ϧ){Ў ό=new Ў();ό.ɒ=Ɉ;ό.ό=Ɉ.GetInventory();ō.Ѕ.Add(ό);}}else{Ў ό=new Ў();ό.ɒ=Ɉ;ό.
ό=Ɉ.GetInventory();ό.Ћ=ʖ;if(ʍ==0&&!ʢ)ό.Ћ=false;Ϧ[ʍ].Ѕ.Add(ό);}}void ϣ(IMyTerminalBlock Ɉ,int ʍ){Ў ό=new Ў();ό.ɒ=Ɉ;ό.ό=Ɉ.
GetInventory();ό.Ћ=ʖ;Ϧ[ʍ].ϴ.Add(ό);}void Ϥ(string Ϣ,string Ϫ,string ϳ,bool Ϩ=false,bool ϲ=false){ō ō=new ō();ō.ϩ=new MyItemType(Ϫ,ϳ)
;ō.Ϩ=Ϩ;ō.ϲ=ϲ;ō.Ϣ=Ϣ;Ϧ.Add(ō);}void ϱ(){try{Ϥ("Fusion F ","MyObjectBuilder_Ingot","FusionFuel",true);Ϥ("Fuel Tank",
"MyObjectBuilder_Component","Fuel_Tank");Ϥ("Jerry Can","MyObjectBuilder_Component","SG_Fuel_Tank");Ϥ("PDC      ","MyObjectBuilder_AmmoMagazine",
"40mmLeadSteelPDCBoxMagazine",true);Ϥ("PDC Tefl ","MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);Ϥ("220 Torp ",
"MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",true,true);Ϥ("220 MCRN ","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true
,true);Ϥ("220 UNN  ","MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);Ϥ("RS Torp  ",
"MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);Ϥ("LRS Torp ","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",
true,true);Ϥ("120mm RG ","MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);Ϥ("Dawson   ",
"MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true);Ϥ("Stiletto ","MyObjectBuilder_AmmoMagazine",
"100mmTungstenUraniumSlugMCRNMagazine",true);Ϥ("80mm     ","MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);Ϥ("Foehammr ",
"MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugMCRNMagazine",true);Ϥ("Farren   ","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugUNNMagazine",true);Ϥ("Kess     ","MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);Ϥ("Steel Pla",
"MyObjectBuilder_Component","SteelPlate");Ϧ[0].ϧ=ʃ;}catch(Exception ex){Echo("Failed to build item lists!");Echo(ex.Message);return;}}void ϰ(){
foreach(var ō in Ϧ){ō.ϴ.Clear();}}void ϯ(){foreach(var ō in Ϧ){ō.Љ=0;ō.Ї=0;List<Ў>ˑ=ō.Ѕ.Concat(ō.ϴ).ToList();foreach(Ў ό in ˑ){
ό.Ќ=ό.ό.GetItemAmount(ō.ϩ).ToIntSafe();ō.Љ+=ό.Ќ;if(ό.Ћ){ό.Њ=ό.ό.VolumeFillFactor;}else{ō.Ї+=ό.Ќ;}}}}void Ϯ(){foreach(ō ō
in Ϧ){ō.Ј=ō.Љ;}}int ϭ(string ȃ){switch(ȃ){case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":case
"MCRN Torpedo Low Spread":return 6;case"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;
case"40mm Lead-Steel PDC Box Ammo":return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":
return 10;case"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case
"80mm Tungsten-Uranium Sabot Ammo":return 13;case"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;
case"180mm Lead-Steel Sabot Ammo":return 16;default:if(ɼ)Echo("Unknown AmmoType = "+ȃ);return 99;}}bool Ϭ(IMyTerminalBlock ɒ
){IMyInventory В=ɒ.GetInventory();return В.VolumeFillFactor==0;}bool ж(List<Ў>ː,List<Ў>ˎ,MyItemType ϩ,int с=-1,double р=1
,double п=1){if(ɼ)Echo("Loading "+ˎ.Count+" inventories from "+ː.Count+" sources.");bool ª=false;bool о=п<1;foreach(Ў н
in ˎ){int м=3;foreach(Ў л in ː){if(м<0)break;if(с!=-1&&н.Ќ>=(с*.95))break;if(!н.ό.IsConnectedTo(л.ό))continue;List<
MyInventoryItem>к=new List<MyInventoryItem>();л.ό.GetItems(к);foreach(MyInventoryItem й in к){if(й.Type==ϩ){int Ќ=й.Amount.ToIntSafe();
if(Ќ==0&&!о)break;м--;if(о){м=-1;try{Ќ=л.Ќ-Convert.ToInt32(л.Ќ/л.Њ*п);if(ɼ)Echo("Unload "+Ќ+"\n"+л.Ќ+"\n"+Convert.ToInt32(
л.Ќ/л.Њ*п));}catch(Exception ex){if(ɼ)Echo("Int conversion error at unload\n"+ex.Message);Ќ=1;}}else if(р<1){try{int и=
Convert.ToInt32(н.Ќ/н.Њ*р)-н.Ќ;if(и<Ќ)Ќ=и;}catch(Exception ex){if(ɼ)Echo("Int conversion error at load\n"+ex.Message);Ќ=1;}}
else if(с!=-1){if(Ќ<=с){break;}Ќ=с-н.Ќ;}ª=н.ό.TransferItemFrom(л.ό,й,Ќ);if(ª)м=-1;if(о&&ª)return(ª);break;}}}}return ª;}
class з{public IMyTextPanel ɒ;public bool т=true;public bool ђ=false;public bool ѓ=false;public bool ё=true;public bool ѐ=
true;public bool я=true;public bool ю=false;public bool э=false;}class ь{public string ы,ъ;public int щ,ш;public ь(string ч,
string ц,int х=0,int ф=20){if(ч.Length>Р-3)ч=ч.Substring(0,Р-3);ы=ч.PadRight(Р-3);ъ=ц;щ=х;ш=ф;}}List<ь>у=new List<ь>();class е
{public string С,г;public е(string Z,int П,int О){string Н="    ";while(О>3){О-=4;}if(П==0){С="║ "+Z.PadRight(4)+" ║";г=
"  "+Н+"  ";}else if(П==1){if(О==0||О==2)С="║─"+Z.PadRight(4)+" ║";else С="║ "+Z.PadRight(4)+"─║";г=" ░"+Н+"░ ";}else if(П==
2){if(О==0||О==2){С="║ "+Z.PadRight(4)+"═║";г="║▒"+Н+"░║";}else{С="║═"+Z.PadRight(4)+" ║";г="║░"+Н+"▒║";}}else if(П==3){
if(О==0||О==2){С="║!"+Z.PadRight(4)+"!║";г="║▓"+Н+"▓║";}else{С="║ "+Н+" ║";г="║!"+Z.PadRight(4)+"!║";}}}}Color М=new Color
(255,116,33,255);const int Р=32;int Л=0;string[]Й=new string[]{"▄ "," ▄"," ▀","▀ "},И=new string[]{"─","\\","│","/"},З=
new string[]{"- ","= ","x ","! "};string Ж="RSM is booting...\n\n",Е,Д,К="──\n\n",Г="╔══════╗",Т="╚══════╝",д,в,б,а,Я,Ю,Э,Ь
,Ы,Ъ,Щ,Ш,Ч,Ц,Х,Ф,У,Ȼ,ŉ,à,Ň;void ņ(){Г=Г+Г+Г+Г+"\n";Т=Т+Т+Т+Т+"\n";Е=new String(' ',Р-8);Д="└"+new String('─',Р-2)+"┘";д=
new String('-',26)+"\n";в=Ņ("Inventory");б=Ņ("Thrust");а=Ņ("Power & Tanks");Я=Ņ("Warnings");Ю=Ņ("Subsystem Integrity");Э=Ņ(
"Telemetry & Thrust");Ь=Ń("Velocity");Ы=Ń("Velocity (Max)");Ъ=Ń("Mass");Щ=Ń("Max Accel");Ш=Ń("Actual Accel");Ч=Ń("Accel (Best)");Ц=Ń(
"Max Thrust");Х=Ń("Actual Thrust");Ф=Ń("Decel (Dampener)");У=Ń("Decel (Actual)");Ȼ=Ł("Fuel");ŉ=Ł("Oxygen");à=Ł("Battery");Ň=Ł(
"Capacity");}string Ņ(string ń){return"──┤ "+ń+" ├"+new String('─',Р-9-ń.Length);}string Ń(string ł){return"\n"+ł+":"+new String(
' ',Р-16-ł.Length);}string Ł(string ŀ){return ŀ+new String(' ',Р-22-ŀ.Length)+"[";}void Ŀ(){Л++;if(Л>=Й.Length)Л=0;int ľ=Л+
2;if(ľ>3)ľ-=4;string Ľ=Й[Л];string ļ=И[Л];string Ļ=Й[ľ];string ĺ=в+ļ+К;string Ĺ=б+ļ+К;string ň=а+ļ+К;string Ŋ=Я+ļ+К;
string ś=Ю+ļ+К;string Ŝ=Э+ļ+К;string Ś=ŵ(ɸ.ToUpper(),Р)+"\n"+"  "+Ľ+" "+ŵ(ð,Р-10)+" "+Ľ+"  \n";string ř="\n  "+Ļ+Е+Ļ+"  \n\n";
if(ͼ){ĺ+=Ж;Ĺ+=Ж;ň+=Ж;Ŋ+=Ж;ś+=Ж;}else{ʟ();double Ř=9.81,ŗ=Math.Round(Μ),Ŗ=Math.Round((ê/Ν/Ř),2),ŕ=Math.Round((é/Ν/Ř),2),Ŕ=
Math.Round(K+Ç,1),œ=Math.Round(Ê,1),Œ=Math.Round(100*(Ñ/Ò)),ő=Math.Round(100*(Æ/È)),Ő=Math.Round(100*(œ/Ŕ));string ŏ=Ь,Ŏ=
" Gs";if(ŗ<1){ŗ=500;ŏ=Ы;}if(ɽ){Ř=1;Ŏ=" m/s/s";}foreach(ō ō in Ϧ){if(ō.Ј!=0){ō.І=(100*((double)ō.Љ/(double)ō.Ј));string Ō=(ō.Љ
+"/"+ō.Ј).PadLeft(9);if(Ō.Length>9)Ō=Ō.Substring(0,9);ĺ+=ō.Ϣ+" ["+ſ(ō.І)+"] "+Ō+"\n";}}ĺ+="\n";if(é>0)Ĺ=У+Ə(é,ŗ)+Ш+(ŕ+Ŏ).
PadLeft(15)+"\n\n";else Ĺ=Ф+Ə(ê,ŗ,true)+Ч+(Ŗ+Ŏ).PadLeft(15)+"\n\n";Ґ=Math.Round(100*(Ú/Ü));ň+=Ȼ+ſ(Ґ)+"] "+(Ґ+" %").PadLeft(9)+
"\n"+ŉ+ſ(Œ)+"] "+(Œ+" %").PadLeft(9)+"\n"+à+ſ(ő)+"] "+(ő+" %").PadLeft(9)+"\n"+Ň+ſ(Ő)+"] "+(Ő+" %").PadLeft(9)+"\n"+
"Max Power:"+(œ+" MW / "+Ŕ+" MW").PadLeft(22)+"\n\n";List<ь>ŋ=new List<ь>();List<е>ķ=new List<е>();int Ħ=0;for(int Ę=0;Ę<у.Count;Ę++
){у[Ę].ш--;if(у[Ę].ш<1)у.RemoveAt(Ę);else ŋ.Add(у[Ę]);}if(!ƅ){ŋ.Add(new ь("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(ʹ){ŋ.Add(new ь("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int Ĥ=0;if(Ґ<5)
{ŋ.Add(new ь("FUEL CRITICAL!","FUEL CRITICAL!\nFuel Level < 5%!",3));Ĥ=3;}else if(Ґ<25){ŋ.Add(new ь("FUEL LOW!",
"FUEL LOW!\nFuel Level < 10%!",2));Ĥ=2;}if(Ā.ó!=ƽ.Off){if(Ͳ){if(Ĥ==0)Ĥ=1;ŋ.Add(new ь("No spare fuel tanks",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",Ĥ));}if(ͳ){if(Ĥ==0)Ĥ=1;ŋ.Add(new ь("No Extractor","Cannot refuel!\nNo functional extractor!",Ĥ));}}ķ.Add(new е("FUEL",Ĥ
,Л+Ħ));Ħ++;int ģ=0;if(Œ<5){ŋ.Add(new ь("OXYGEN CRITICAL!","OXYGEN CRITICAL!\nShip O2 Level < 5%!",3));ģ=3;}else if(Œ<10){
ŋ.Add(new ь("OXYGEN LOW!","OXYGEN LOW!\nShip O2 Level < 10%!",2));ģ=2;}else if(Œ<25){ŋ.Add(new ь("Oxygen Low",
"Oxygen Low!\nShip O2 Level < 25%!",1));ģ=1;}if(ϖ.Count>Ű){int Ģ=(ϖ.Count-Ű);ģ++;ŋ.Add(new ь(Ģ+" vents are unsealed",Ģ+" vents are unsealed",1));}if(Ҩ>0){ŋ
.Add(new ь(Ҩ+" doors are insecure",Ҩ+" doors are insecure",0));}if(Ώ>0){ŋ.Add(new ь(ʫ+" is active ("+Ώ+")",ʫ+
" is active ("+Ώ+")",0));}ķ.Add(new е("OXYG",ģ,Л+Ħ));Ħ++;int ġ=0;if(υ.Count>0){if(ő<5){ġ+=2;ŋ.Add(new ь("BATTERIES CRITICAL!",
"BATTERIES CRITICAL!\nBattery Level < 5%!",2));}else if(ő<10){ġ+=1;ŋ.Add(new ь("Batteries Low!","Batteries Low!\nBattery Level < 10%!",1));}}if(ϛ.Count>0){if(O>0)
{ġ+=2;ŋ.Add(new ь(O+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}if(Ϧ[0].Ј==0){if(Ϧ[0].Љ>0)
{ġ+=1;ŋ.Add(new ь("No Spare Fusion Fuel!","No spare fusion fuel detected in ships cargo!",2));}}else if(Ϧ[0].І<5){ġ+=2;ŋ.
Add(new ь("FUSION FUEL LEVEL CRITICAL!","Fusion fuel level is low!",3));}else if(Ϧ[0].І<10){ġ+=1;ŋ.Add(new ь(
"Fusion Fuel Level Low!","Fusion fuel level is low!",2));}}if(ġ>3)ġ=3;ķ.Add(new е("POWR",ġ,Л+Ħ));Ħ++;int Ġ=0;if(ˡ!=""){string[]ğ=ˡ.Split('\n');
foreach(string ĥ in ğ){string Ğ=ĥ;if(ĥ.Length>23)Ğ=ĥ.Substring(0,23);Ğ=Ğ.ToUpper();ŋ.Add(new ь("NEED "+Ğ+"!","NEED "+Ğ+
"!  Ammo Critical!",3));}Ġ=3;}if(Ġ>3)Ġ=3;ķ.Add(new е("WEAP",Ġ,Л+Ħ));Ħ++;if(ʾ){string Ĝ=ʷ;if(φ.Count>0)if(φ[0]!=null)Ĝ=(φ[0]as
IMyRadioAntenna).HudText;string ě="";if(ˊ<1000)ě=Math.Round(ˊ)+"m";else ě=Math.Round(ˊ/1000)+"km";ŋ.Add(new ь("Comms ("+ě+"): "+Ĝ,
"Antenna(s) are broadcasting at a range of "+ě+" with the message "+Ĝ,0));}if(Ύ>0){ŋ.Add(new ь(Ύ+" UNOWNED BLOCKS!","RSM detected "+Ύ+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(Ҫ>ҩ){int Ě=(Ҫ-ҩ);ŋ.Add(new ь(Ě+" doors are open",Ě+" doors are open",0));}ŋ=ŋ.OrderBy(ę=>ę.щ).Reverse().ToList(
);if(ŋ.Count<1)Ŋ+="No warnings\n";else Echo("\n\n WARNINGS:");for(int Ę=0;Ę<ŋ.Count;Ę++){Ŋ+=З[ŋ[Ę].щ]+ŋ[Ę].ы+"\n";Echo(
"-"+З[ŋ[Ę].щ]+ŋ[Ę].ъ);}Ŋ+="\n";string ė=Ā.Ï.ToString().ToUpper();if(ė.Length>3)ė=ė.Substring(0,3);string ĝ=Ā.ï.ToString().
ToUpper();if(ĝ.Length>3)ĝ=ĝ.Substring(0,3);string Ė=Ā.Ï.ToString().ToUpper();if(Ė.Length>3)Ė=Ė.Substring(0,3);string ħ=Ā.S.
ToString().ToUpper();if(ħ.Length>3)ħ=ħ.Substring(0,3);string Ķ=Ā.U.ToString().ToUpper();if(Ķ.Length>3)Ķ=Ķ.Substring(0,3);string
ĵ=Ā.p.ToString().ToUpper();if(ĵ.Length>3)ĵ=ĵ.Substring(0,3);try{if(è>0)ś+="Epstein   ["+ſ(ç)+"] "+(ç+"% ").PadLeft(5)+ė+
"\n";if(Ǻ>0)ś+="RCS       ["+ſ(ǹ)+"] "+(ǹ+"% ").PadLeft(5)+ĝ+"\n";if(K>0)ś+="Reactors  ["+ſ(H)+"] "+(H+"% ").PadLeft(5)+
"    \n";if(Ç>0)ś+="Batteries ["+ſ(Å)+"] "+(Å+"% ").PadLeft(5)+Ė+"\n";if(t>0)ś+="PDCs      ["+ſ(q)+"] "+(q+"% ").PadLeft(5)+ħ+
"\n";if(ȇ>0)ś+="Torpedoes ["+ſ(ȅ)+"] "+(ȅ+"% ").PadLeft(5)+Ķ+"\n";if(m>0)ś+="Railguns  ["+ſ(k)+"] "+(k+"% ").PadLeft(5)+ĵ+
"\n";if(Û>0)ś+="H2 Tanks  ["+ſ(Ù)+"] "+(Ù+"% ").PadLeft(5)+Ė+"\n";if(Õ>0)ś+="O2 Tanks  ["+ſ(Ð)+"] "+(Ð+"% ").PadLeft(5)+Ė+
"\n";if(Ҡ>0)ś+="Gyros     ["+ſ(Ҟ)+"] "+(Ҟ+"% ").PadLeft(5)+"    \n";if(ʞ>0)ś+="Cargo     ["+ſ(ʜ)+"] "+(ʜ+"% ").PadLeft(5)+
"    \n";if(ƣ>0)ś+="Welders   ["+ſ(ơ)+"] "+(ơ+"% ").PadLeft(5)+"    \n";}catch{}if(Ç+K+Û==0)ś+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+"\n\n";string Ĵ="";string ĳ="";foreach(е Ĳ in ķ){Ĵ+=Ĳ.С;ĳ+=Ĳ.г;}int ı=Л+2;if(ı>3)ı-=4;Ś+=Г+Ĵ+"\n"+Т;ř+=ĳ;if(!Θ){Ŝ+=
"\n\n";}else{if(ɼ)Echo("Building advanced thrust...");string İ="";if(ɿ){İ=Ъ+(Math.Round((Ν/1000000),2)+" Mkg").PadLeft(15)+ŏ+(
ŗ+" ms").PadLeft(15)+Щ+(Ŗ+Ŏ).PadLeft(15)+Ш+(ŕ+Ŏ).PadLeft(15)+Ц+((ê/1000000)+" MN").PadLeft(15)+Х+((é/1000000)+" MN").
PadLeft(15);}Ŝ+=İ+Ф+Ə(ê,ŗ,true)+У+Ə(é,ŗ);foreach(double į in ɾ){Ŝ+="\n"+("Decel ("+(į*100)+"%):").PadRight(17)+Ə((float)(ê*į),ŗ
);}Ŝ+="\n\n";}}foreach(з ī in Ω){string Į="";Color ĭ=Ā.ú;if(ī.т)Į+=Ś;if(ī.ђ){Į+=ř;ĭ=М;}if(ī.ѓ)Į+=Ŋ;if(ī.ё)Į+=ň;if(ī.ѐ)Į+=
ĺ;if(ī.я)Į+=Ĺ;if(ī.ю)Į+=ś;if(ī.э){Į+=Ŝ;Θ=true;}ī.ɒ.WriteText(Į,false);if(!ʀ)ī.ɒ.FontColor=ĭ;}}void Ĭ(){if(Ϊ.Count>0){
foreach(IMyTextPanel ī in Ϊ){ī.FontColor=Ā.ú;}foreach(з ī in Ω){ī.ɒ.FontColor=Ā.ú;}}}void Ī(string ĩ,string ĸ){ĩ=ĩ.ToLower();
List<IMyTextPanel>ŝ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ϋ);foreach(IMyTextPanel ī in Ϋ
){if(ĸ==""||ī.CustomName.Contains(ĸ)){string Ɓ=ī.CustomData;if(Ɓ.Contains("hudlcd")&&(ĩ=="off"||ĩ=="toggle"))ī.CustomData
=Ɓ.Replace("hudlcd","hudXlcd");if(Ɓ.Contains("hudXlcd")&&(ĩ=="on"||ĩ=="toggle"))ī.CustomData=Ɓ.Replace("hudXlcd","hudlcd"
);}}}string ſ(double Ŷ){try{int ž=0;if(Ŷ>0){int Ž=(int)Ŷ/10;if(Ž>10)return new string('=',10);if(Ž!=0)ž=Ž;}char ż=' ';if(
Ŷ<10){if(Л==0)return" ><    >< ";if(Л==1)return"  ><  ><  ";if(Л==2)return"   ><><   ";if(Л==3)return"<   ><   >";}string
Ż=new string('=',ž);string ź=new string(ż,10-ž);return Ż+ź;}catch{return"# ERROR! #";}}string Ź(string Ÿ){string ŷ;string
Ō="";double Ŷ=0;switch(Ÿ){case"H2":Ŷ=Math.Round(100*(Ú/Û));Ō=Ŷ.ToString()+" %";Ґ=Ŷ;break;case"O2":Ŷ=Math.Round(100*(Ñ/Õ))
;Ō=Ŷ.ToString()+" %";break;case"Battery":Ŷ=Math.Round(100*(Æ/È));Ō=Ŷ.ToString()+" %";break;}ŷ=ſ(Ŷ);return" ["+ŷ+"] "+Ō.
PadLeft(9);}string ŵ(string Ŵ,int ų){int ƀ=ų-Ŵ.Length;int Ƃ=ƀ/2+Ŵ.Length;return Ŵ.PadLeft(Ƃ).PadRight(ų);}string Ə(double Ɛ,
double Ǝ,bool ƍ=false){if(Ɛ<=0)return("N/A").PadLeft(15);if(ƍ)Ɛ=Ɛ*1.5;double ƌ=0.5*(Math.Pow(Ǝ,2)*(Ν/Ɛ));double Ƌ=Ǝ/(Ɛ/Ν);
string Ɗ="m";if(ƌ>1000){Ɗ="km";ƌ=ƌ/1000;}return(Math.Round(ƌ)+Ɗ+" "+Math.Round(Ƌ)+"s").PadLeft(15);}void Ɖ(){foreach(
IMyTextPanel Ɔ in Ϋ){Ɔ.Enabled=true;}}void ƈ(){foreach(з ī in Ω){ī.ɒ.Font="Monospace";ī.ɒ.ContentType=ContentType.TEXT_AND_IMAGE;if(
ī.ɒ.CustomName.Contains("HUD1")){ī.т=true;ī.ђ=false;ī.ѓ=false;ī.ё=false;ī.ѐ=false;ī.я=false;ī.ю=false;ī.э=false;Ʉ(ī,
"hudlcd:-0.55:0.99:0.7");continue;}if(ī.ɒ.CustomName.Contains("HUD2")){ī.т=false;ī.ђ=false;ī.ѓ=true;ī.ё=false;ī.ѐ=false;ī.я=false;ī.ю=false;ī.э
=false;Ʉ(ī,"hudlcd:0.22:0.99:0.55");continue;}if(ī.ɒ.CustomName.Contains("HUD3")){ī.т=false;ī.ђ=false;ī.ѓ=false;ī.ё=true;
ī.ѐ=false;ī.я=true;ī.ю=false;ī.э=false;Ʉ(ī,"hudlcd:0.48:0.99:0.55");continue;}if(ī.ɒ.CustomName.Contains("HUD4")){ī.т=
false;ī.ђ=false;ī.ѓ=false;ī.ё=false;ī.ѐ=false;ī.я=false;ī.ю=true;ī.э=false;Ʉ(ī,"hudlcd:0.74:0.99:0.55");continue;}if(ī.ɒ.
CustomName.Contains("HUD5")){ī.т=false;ī.ђ=false;ī.ѓ=false;ī.ё=false;ī.ѐ=true;ī.я=false;ī.ю=false;ī.э=true;Ʉ(ī,"hudlcd:0.75:0:.54"
);continue;}if(ī.ɒ.CustomName.Contains("HUD6")){ī.т=false;ī.ђ=true;ī.ѓ=false;ī.ё=false;ī.ѐ=false;ī.я=false;ī.ю=false;ī.э=
false;Ʉ(ī,"hudlcd:-0.55:0.99:0.7");continue;}}bool Ƈ=false;foreach(IMyTextPanel Ɔ in Ϋ){if(Ɔ==null)continue;if(!Ƈ&&(Ɔ.
CustomName.Contains(ʥ)||Ɔ.CustomName.ToUpper().Contains(ʤ))){Ƈ=true;Ɔ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool ƅ;void
Ƅ(bool Ì,bool Ů){ƅ=false;foreach(IMyConveyorSorter ƃ in ϔ){if(ƃ!=null&&ƃ.IsFunctional){ƅ=true;if(Ů)ƃ.Enabled=Ì;}}}void Ų(
Ǒ M){if(M==Ǒ.NoChange)return;foreach(IMyReflectorLight ű in Τ){if(ű==null)continue;if(M==Ǒ.Off)ű.Enabled=false;else{ű.
Enabled=false;if(M==Ǒ.OnMax)ű.Radius=9999;}}}void ť(Ǎ M,Color ĭ){if(M==Ǎ.NoChange)return;foreach(IMyLightingBlock ş in ί){if(ş
==null)continue;if(M==Ǎ.Off)ş.Enabled=false;else ş.Enabled=true;if(M!=Ǎ.OnNoColourChange)ş.SetValue("Color",ĭ);}}void Ť(Ǎ
M,Color ĭ){if(M==Ǎ.NoChange)return;foreach(IMyLightingBlock ş in ί){if(ş==null)continue;if(M==Ǎ.Off)ş.Enabled=false;else
ş.Enabled=true;if(M!=Ǎ.OnNoColourChange)ş.SetValue("Color",ĭ);}}Color ţ=new Color(255,0,0,255);Color Ţ=new Color(255,0,0,
255);Color š=new Color(255,0,0,255);void Š(Ǎ M){if(M==Ǎ.NoChange)return;foreach(IMyLightingBlock ş in Φ){Ş(ş,M,Ţ);}foreach(
IMyLightingBlock ş in Υ){Ş(ş,M,š);}}void Ş(IMyLightingBlock ş,Ǎ M,Color ĭ){if(ş==null)return;if(M==Ǎ.Off){ş.Enabled=false;ş.SetValue(
"Color",ţ);}else{ş.Enabled=true;if(M!=Ǎ.OnNoColourChange)ş.SetValue("Color",ĭ);}}int Ű=0;void ů(bool Ì,bool Ů){Ű=0;foreach(
IMyAirVent ŭ in ϖ){if(ŭ!=null){if(Ů)ŭ.Enabled=Ì;if(ŭ.CanPressurize)Ű++;}}}void Ŭ(bool Ì){foreach(IMyShipConnector ū in Ϗ){if(ū!=
null)ū.Enabled=Ì;}}void Ū(bool Ì){foreach(IMyCameraBlock ũ in τ){if(ũ!=null)ũ.Enabled=Ì;}}void Ũ(bool Ì){foreach(
IMySensorBlock ŧ in Ϛ){if(ŧ!=null)ŧ.Enabled=Ì;}}void Ŧ(){ʹ=true;foreach(IMyTerminalBlock Ĩ in ϙ){Ĩ.ApplyAction("OnOff_On");if(Ĩ.
IsFunctional)ʹ=false;}}bool ĕ=false;List<string>R=new List<string>();bool À=false;List<string>º=new List<string>();void µ(string w,
string v){bool ª=false;List<IMyProgrammableBlock>z=new List<IMyProgrammableBlock>();try{if(v=="EFC")z=έ;else if(v=="NavOS")z=ά
;foreach(IMyProgrammableBlock y in έ){if(y==null||!y.Enabled)continue;ª=(y as IMyProgrammableBlock).TryRun(w);if(ª&&ɼ)
Echo("Ran "+w+" on "+y.CustomName+" successfully.");else у.Add(new ь(v+" command failed!",v+" command "+w+" failed!",1));if(
v=="EFC")ĕ=true;else if(v=="NavOS")À=true;break;}}catch(Exception ex){у.Add(new ь(v+" command errored!",v+" command "+w+
" errored!\n"+ex.Message,3));}}void x(string w,string v){if(v=="EFC"){if(έ.Count<1)return;if(ĕ){R.Add(w);return;}}if(v=="NavOS"){if(ά
.Count<1)return;if(À){º.Add(w);return;}}µ(w,v);}void u(){if(R.Count>0&&!ĕ){µ(R[0],"EFC");R.RemoveAt(0);}if(º.Count>0&&!À)
{µ(º[0],"NavOS");º.RemoveAt(0);}ĕ=false;À=false;}int t=0;double s=0;double q=0;void Á(){s=0;foreach(IMyTerminalBlock Ã in
ϓ){Î(Ã,Ā.S!=Ǐ.Off&&Ā.S!=Ǐ.MinDefence);}foreach(IMyTerminalBlock Ã in ϒ){Î(Ã,Ā.S!=Ǐ.Off);}q=Math.Round(100*(s/t));}void Î(
IMyTerminalBlock Í,bool Ì){if(Í!=null&&Í.IsFunctional){s++;(Í as IMyConveyorSorter).Enabled=Ì;}}void Ë(Ǐ M){if(M==Ǐ.NoChange)return;
foreach(IMyTerminalBlock Ã in ϓ){if(Ã!=null&Ã.IsFunctional){switch(M){case Ǐ.Off:case Ǐ.MinDefence:(Ã as IMyConveyorSorter).
Enabled=false;break;case Ǐ.AllDefence:(Ã as IMyConveyorSorter).Enabled=true;if(ʣ){try{Ã.SetValue("WC_FocusFire",false);Ã.
SetValue("WC_Projectiles",true);Ã.SetValue("WC_Grids",true);Ã.SetValue("WC_LargeGrid",false);Ã.SetValue("WC_SmallGrid",true);Ã.
SetValue("WC_SubSystems",true);Ã.SetValue("WC_Biologicals",true);ɵ(Ã);}catch{Echo("Strange PDC config error! Possible WC crash!"
);}}break;case Ǐ.Offence:(Ã as IMyConveyorSorter).Enabled=true;if(ʣ){try{Ã.SetValue("WC_FocusFire",false);Ã.SetValue(
"WC_Projectiles",true);Ã.SetValue("WC_Grids",true);Ã.SetValue("WC_LargeGrid",true);Ã.SetValue("WC_SmallGrid",true);Ã.SetValue(
"WC_SubSystems",true);Ã.SetValue("WC_Biologicals",true);ɵ(Ã);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock Ã in ϒ){if(Ã!=null&Ã.IsFunctional){switch(M){case Ǐ.Off:(Ã as IMyConveyorSorter).Enabled=false;break;
case Ǐ.MinDefence:case Ǐ.AllDefence:case Ǐ.Offence:(Ã as IMyConveyorSorter).Enabled=true;if(ʣ){try{Ã.SetValue("WC_FocusFire"
,false);Ã.SetValue("WC_Projectiles",true);Ã.SetValue("WC_Grids",true);Ã.SetValue("WC_LargeGrid",false);Ã.SetValue(
"WC_SmallGrid",true);Ã.SetValue("WC_SubSystems",true);Ã.SetValue("WC_Biologicals",true);Ɍ(Ã);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double Ê;void É(ǌ M){Ê=0;Ä(M);G();}double È=0;double Ç=0;double Æ=0;double Å=0;void Ä(ǌ M){È=0;Æ=0;foreach
(IMyBatteryBlock L in υ){if(L!=null&&L.IsFunctional){Æ+=L.CurrentStoredPower;È+=L.MaxStoredPower;Ê+=L.MaxOutput;L.Enabled
=true;bool o=M==ǌ.Discharge;if(o&&ʵ){if(h)L.ChargeMode=ChargeMode.Discharge;else L.ChargeMode=ChargeMode.Recharge;}}}Å=
Math.Round(100*(Ê/Ç));}void P(){Ç=0;foreach(IMyBatteryBlock L in υ){Ç+=L.MaxOutput;}}void N(ǌ M){if(M==ǌ.NoChange)return;
foreach(IMyBatteryBlock L in υ){if(L!=null&L.IsFunctional){L.Enabled=true;if(M==ǌ.Auto)L.ChargeMode=ChargeMode.Auto;else if(M==
ǌ.StockpileRecharge)L.ChargeMode=ChargeMode.Recharge;else if(!ʵ)L.ChargeMode=ChargeMode.Recharge;}}}double K=0;double J=0
;double H=0;int O=0;void G(){J=0;O=0;foreach(IMyReactor E in ϛ){if(E!=null&&E.IsFunctional){E.Enabled=true;if(Ϭ(E))O++;
else J+=E.MaxOutput;}}H=Math.Round(100*(J/K));Ê+=J;}void F(){K=0;foreach(IMyReactor E in ϛ){K+=E.MaxOutput;}}void D(
IMyProjector C){C.CustomData=C.ProjectionOffset.X+"\n"+C.ProjectionOffset.Y+"\n"+C.ProjectionOffset.Z+"\n"+C.ProjectionRotation.X+
"\n"+C.ProjectionRotation.Y+"\n"+C.ProjectionRotation.Z+"\n";}void B(IMyProjector C){if(!C.IsFunctional)return;try{string[]A
=C.CustomData.Split('\n');Vector3I Q=new Vector3I(int.Parse(A[0]),int.Parse(A[1]),int.Parse(A[2]));Vector3I n=new
Vector3I(int.Parse(A[3]),int.Parse(A[4]),int.Parse(A[5]));C.Enabled=true;C.ProjectionOffset=Q;C.ProjectionRotation=n;C.
UpdateOffsetAndRotation();}catch{if(ɼ)Echo("Failed to load projector position for "+C.Name);}}int m=0;double l=0;double k=0;bool h=false;void f
(){h=false;l=0;foreach(IMyTerminalBlock X in ϑ){if(X!=null&&X.IsFunctional){l++;(X as IMyConveyorSorter).Enabled=Ā.p!=ǎ.
Off;if(!h){MyDetectedEntityInfo?e=ǵ.ȓ(X);if(e.HasValue){string Z=e.Value.Name;if(Z!=null&&Z!=""){if(ɼ)Echo(
"At least one rail has a target!");h=true;}}}}}k=Math.Round(100*(l/m));}void Y(ǎ M){if(M==ǎ.NoChange)return;foreach(IMyTerminalBlock X in ϑ){if(X!=null&X
.IsFunctional){if(M==ǎ.Off){(X as IMyConveyorSorter).Enabled=false;}else{(X as IMyConveyorSorter).Enabled=true;if(ʣ){X.
SetValue("WC_Grids",true);X.SetValue("WC_LargeGrid",true);X.SetValue("WC_SmallGrid",true);X.SetValue("WC_SubSystems",true);ɵ(X);
}if(ʴ){if(M==ǎ.OpenFire){ʠ(X);}else{ʡ(X);}}}}}}class W{public string V="";public ƞ U;public Ǐ S;public ǎ p;public ǐ Ï;
public ǒ ï;public Ǒ ā;public Ǎ ÿ;public Color þ;public Ǎ ý;public Color ü;public Ǎ û;public Color ú;public ǌ ù;public int ø;
public ƞ ö;public ƾ õ;public ƞ ô;public ƽ ó;public ƞ ò;public ƻ ñ;}string ð="N/A";W Ā;ƞ Ă=ƞ.On;Ǐ ē=Ǐ.Offence;ǎ Ĕ=ǎ.OpenFire;ǐ
Ē=ǐ.On;ǒ đ=ǒ.On;Ǒ Đ=Ǒ.On;Ǎ ď=Ǎ.On;Color Ď=new Color(33,144,255,255);Ǎ č=Ǎ.On;Color Č=new Color(255,214,170,255);Ǎ ċ=Ǎ.On;
Color Ċ=new Color(33,144,255,255);ǌ ĉ=ǌ.Auto;int Ĉ=-1;ƞ ć=ƞ.NoChange;ƾ Ć=ƾ.NoChange;ƞ ą=ƞ.NoChange;ƽ Ą=ƽ.KeepFull;ƞ ă=ƞ.On;ƻ
î=ƻ.NoChange;void Þ(string í){W Ý;if(!ѡ.TryGetValue(í,out Ý)){у.Add(new ь("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(ɼ)Echo("Setting stance '"+í+"'.");Ā=Ý;ð=í;ћ();if(ɼ)Echo("Setting "+ϑ.Count+" railguns to "+Ā.p);Y(Ā.p);
if(ɼ)Echo("Setting "+ϐ.Count+" torpedoes to "+Ā.U);Ȃ(Ā.U);if(ɼ)Echo("Setting "+ϓ.Count+" _normalPdcs, "+ϒ.Count+
" defence _normalPdcs to "+Ā.S);Ë(Ā.S);if(ɼ)Echo("Setting "+ς.Count+" epsteins, "+ρ.Count+" chems"+" to "+Ā.Ï);Ư(Ā.Ï,Ā.ï);if(ɼ)Echo("Setting "+ΰ.
Count+" rcs, "+ή.Count+" atmos"+" to "+Ā.ï);Ȍ(Ā.ï);if(ɼ)Echo("Setting "+υ.Count+" batteries to = "+Ā.ù);N(Ā.ù);if(ɼ)Echo(
"Setting "+Ϙ.Count+" H2 tanks to stockpile = "+Ā.ù);Ô(Ā.ù);if(ɼ)Echo("Setting "+ϗ.Count+" O2 tanks to stockpile = "+Ā.ù);ë(Ā.ù);if
(ʁ){if(ɼ)Echo("No lighting was set because lighting control is disabled.");}else{if(ɼ)Echo("Setting "+Τ.Count+
" spotlights to "+Ā.ā);Ų(Ā.ā);if(ɼ)Echo("Setting "+ί.Count+" exterior lights to "+Ā.ÿ);ť(Ā.ÿ,Ā.þ);if(ɼ)Echo("Setting "+Ψ.Count+
" exterior lights to "+Ā.ý);Ť(Ā.ý,Ā.ü);if(ɼ)Echo("Setting "+Φ.Count+" port nav lights, "+Υ.Count+" starboard nav lights to "+Ā.û);Š(Ā.û);}if(ɼ
)Echo("Setting "+Σ.Count+" aux block to "+Ā.ô);ψ(Ā.ô);if(ɼ)Echo("Setting "+ϟ.Count+" extrators to "+Ā.ó);ҏ(Ā.ó);if(ɼ)Echo
("Setting "+ϡ.Count+" hangar doors units to "+Ā.ñ);ҹ(Ā.ñ);if(Ā.p==ǎ.OpenFire){if(ɼ)Echo("Setting "+Ρ.Count+
" doors to locked because we are in combat (rails set to open fire).");ҷ("locked","");}if(ɼ)Echo("Setting "+Ϊ.Count+" colour sync Lcds.");Ĭ();if(Ā.õ==ƾ.Abort){x("Off","EFC");x("Abort",
"NavOS");}if(Ā.ø>0){x("Set Burn "+Ā.ø,"EFC");x("Thrust Set "+Ā.ø/100,"NavOS");}if(Ā.ö==ƞ.On)x("Boost On","EFC");else if(Ā.ö==ƞ.
Off)x("Boost Off","EFC");if(ɼ)Echo("Finished setting stance.");}double Ü=0;double Û=0;double Ú=0;double Ù=0;void Ø(){Ú=0;Ü=
0;foreach(IMyGasTank Ó in Ϙ){if(Ó.IsFunctional){Ó.Enabled=true;Ü+=Ó.Capacity;Ú+=(Ó.Capacity*Ó.FilledRatio);}}Ù=Math.Round
(100*(Ü/Û));}void Ö(){Û=0;foreach(IMyGasTank Ó in Ϙ){if(Ó!=null)Û+=Ó.Capacity;}}void Ô(ǌ M){if(M==ǌ.NoChange)return;
foreach(IMyGasTank Ó in Ϙ){if(Ó==null)continue;Ó.Enabled=true;if(M==ǌ.StockpileRecharge)Ó.Stockpile=true;else Ó.Stockpile=false
;}}double Ò=0;double Ñ=0;double Õ=0;double Ð=0;void ß(){Ñ=0;Ò=0;foreach(IMyGasTank Ó in ϗ){if(Ó.IsFunctional){Ó.Enabled=
true;Ò+=Ó.Capacity;Ñ+=(Ó.Capacity*Ó.FilledRatio);}}Ð=Math.Round(100*(Ò/Õ));}void ì(){Õ=0;foreach(IMyGasTank Ó in ϗ){if(Ó!=
null)Õ+=Ó.Capacity;}}void ë(ǌ M){if(M==ǌ.NoChange)return;foreach(IMyGasTank Ó in ϗ){if(Ó==null)continue;Ó.Enabled=true;if(M
==ǌ.StockpileRecharge)Ó.Stockpile=true;else Ó.Stockpile=false;}}float ê;float é;float è;double ç;void æ(){float å=0;float
ä=0;float ã=0;float â=0;foreach(IMyThrust á in ς){if(á!=null&&á.IsFunctional){å+=á.MaxThrust;ã+=á.CurrentThrust;if(á.
Enabled){ä+=á.MaxThrust;â+=á.CurrentThrust;}}}ç=Math.Round(100*(å/è));if(ä==0){ê=å;é=ã;}else{ê=ä;é=â;}}void Â(){è=0;foreach(
IMyThrust á in ς){if(á!=null)è+=á.MaxThrust;}}void Ư(ǐ M,ǒ ǿ){if(M==ǐ.NoChange)return;foreach(IMyThrust á in ς){Ȁ(á,M,ǿ);}foreach
(IMyThrust á in ρ){Ȁ(á,M,ǿ,true);}}void Ȁ(IMyThrust á,ǐ M,ǒ ǿ,bool Ǿ=false){bool ǽ=á.CustomName.Contains(ʨ);if(ǽ){if(ǿ!=ǒ
.Off&&ǿ!=ǒ.AtmoOnly)á.Enabled=true;else á.Enabled=false;}else{bool Ǽ=á.CustomName.Contains(ʩ);if((M==ǐ.On)||(M==ǐ.Minimum
&&Ǽ)||(M==ǐ.EpsteinOnly&&!Ǿ)||(M==ǐ.ChemOnly&&Ǿ)){á.Enabled=true;}else{á.Enabled=false;}}}float ǻ;float Ǻ;double ǹ;void Ǹ(
){ǻ=0;foreach(IMyThrust á in ΰ){if(á!=null&&á.IsFunctional){ǻ+=á.MaxThrust;}}ǹ=Math.Round(100*(ǻ/Ǻ));}void ȁ(){Ǻ=0;
foreach(IMyThrust á in ΰ){if(á!=null)Ǻ+=á.MaxThrust;}}void Ȍ(ǒ M){foreach(IMyThrust á in ΰ){if(á!=null)ȋ(á,M);}foreach(
IMyThrust á in ή){if(á!=null)ȋ(á,M,true);}}void ȋ(IMyThrust á,ǒ M,bool Ȋ=false){bool ȉ=á.GridThrustDirection==Vector3I.Backward;
bool Ȉ=á.GridThrustDirection==Vector3I.Forward;if((M==ǒ.On)||(M==ǒ.ForwardOff&&!ȉ)||(M==ǒ.ReverseOff&&!Ȉ)||(M==ǒ.RcsOnly&&!Ȋ
)||(M==ǒ.AtmoOnly&&Ȋ)){á.Enabled=true;}else{á.Enabled=false;}}int ȇ=0;double Ȇ=0;double ȅ=0;void Ȅ(){Ȇ=0;foreach(
IMyTerminalBlock Ǥ in ϐ){if(Ǥ!=null&&Ǥ.IsFunctional){Ȇ++;(Ǥ as IMyConveyorSorter).Enabled=Ā.U==ƞ.On;if(ʖ){string ȃ=ǵ.Ƴ(Ǥ,0);int ĥ=ϭ(ȃ);
if(ɼ)Echo("Launcher "+Ǥ.CustomName+" needs "+ȃ+"("+ĥ+")");ϣ(Ǥ,ĥ);}}}ȅ=Math.Round(100*(Ȇ/ȇ));}void Ȃ(ƞ M){if(M==ƞ.NoChange)
return;foreach(IMyTerminalBlock Ǥ in ϐ){if(Ǥ!=null&Ǥ.IsFunctional){if(M==ƞ.Off){(Ǥ as IMyConveyorSorter).Enabled=false;}else{(
Ǥ as IMyConveyorSorter).Enabled=true;if(ʣ){Ǥ.SetValue("WC_FocusFire",true);Ǥ.SetValue("WC_Grids",true);Ǥ.SetValue(
"WC_LargeGrid",true);Ǥ.SetValue("WC_SmallGrid",false);Ǥ.SetValue("WC_FocusFire",true);Ǥ.SetValue("WC_SubSystems",true);ɵ(Ǥ);}}}}}Ǣ ǵ;
class Ǣ{private Action<ICollection<MyDefinitionId>>ǡ;private Action<ICollection<MyDefinitionId>>Ǡ;private Action<ICollection<
MyDefinitionId>>ǟ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>Ǟ;private Func<long,MyTuple<bool,
int,int>>ǝ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>ǣ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>ǜ;private Func<long,int,
MyDetectedEntityInfo>ǚ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ǚ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>ǘ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>Ǘ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,bool,int>ǖ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>Ǖ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>Ǜ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>ǔ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>ǥ;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>Ƕ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ǵ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ǲ
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ǳ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int,Vector3D?>ǰ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ǯ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>Ǯ;private Func<MyDefinitionId,float>ǭ;private Func<long,bool>Ǭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool>ǫ;private Func<long,float>Ǫ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ǩ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ǩ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,
ulong,long,Vector3D,bool>>ǧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>Ǧ;private Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>Ƿ;private Func<long,float>ȍ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ƞ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȱ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ȯ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ȭ;
private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>Ȭ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,MyTuple<bool,bool>>ȫ;public bool Ȫ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȩ){var Ȩ=ȩ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(ȩ);if(Ȩ==null)throw new Exception("WcPbAPI failed to activate");return ȧ(Ȩ);}public bool ȧ
(IReadOnlyDictionary<string,Delegate>Ȥ){if(Ȥ==null)return false;Ȧ(Ȥ,"GetCoreWeapons",ref ǡ);Ȧ(Ȥ,"GetCoreStaticLaunchers",
ref Ǡ);Ȧ(Ȥ,"GetCoreTurrets",ref ǟ);Ȧ(Ȥ,"GetBlockWeaponMap",ref Ǟ);Ȧ(Ȥ,"GetProjectilesLockedOn",ref ǝ);Ȧ(Ȥ,
"GetSortedThreats",ref ǣ);Ȧ(Ȥ,"GetObstructions",ref ǜ);Ȧ(Ȥ,"GetAiFocus",ref ǚ);Ȧ(Ȥ,"SetAiFocus",ref Ǚ);Ȧ(Ȥ,"GetWeaponTarget",ref ǘ);Ȧ(Ȥ,
"SetWeaponTarget",ref Ǘ);Ȧ(Ȥ,"FireWeaponOnce",ref ǖ);Ȧ(Ȥ,"ToggleWeaponFire",ref Ǖ);Ȧ(Ȥ,"IsWeaponReadyToFire",ref Ǜ);Ȧ(Ȥ,
"GetMaxWeaponRange",ref ǔ);Ȧ(Ȥ,"GetTurretTargetTypes",ref ǥ);Ȧ(Ȥ,"SetTurretTargetTypes",ref Ƕ);Ȧ(Ȥ,"SetBlockTrackingRange",ref Ǵ);Ȧ(Ȥ,
"IsTargetAligned",ref ǳ);Ȧ(Ȥ,"IsTargetAlignedExtended",ref ǲ);Ȧ(Ȥ,"CanShootTarget",ref Ǳ);Ȧ(Ȥ,"GetPredictedTargetPosition",ref ǰ);Ȧ(Ȥ,
"GetHeatLevel",ref ǯ);Ȧ(Ȥ,"GetCurrentPower",ref Ǯ);Ȧ(Ȥ,"GetMaxPower",ref ǭ);Ȧ(Ȥ,"HasGridAi",ref Ǭ);Ȧ(Ȥ,"HasCoreWeapon",ref ǫ);Ȧ(Ȥ,
"GetOptimalDps",ref Ǫ);Ȧ(Ȥ,"GetActiveAmmo",ref ǩ);Ȧ(Ȥ,"SetActiveAmmo",ref Ǩ);Ȧ(Ȥ,"MonitorProjectile",ref ǧ);Ȧ(Ȥ,"UnMonitorProjectile",
ref Ǧ);Ȧ(Ȥ,"GetProjectileState",ref Ƿ);Ȧ(Ȥ,"GetConstructEffectiveDps",ref ȍ);Ȧ(Ȥ,"GetPlayerController",ref Ƞ);Ȧ(Ȥ,
"GetWeaponAzimuthMatrix",ref Ȱ);Ȧ(Ȥ,"GetWeaponElevationMatrix",ref Ȯ);Ȧ(Ȥ,"IsTargetValid",ref ȭ);Ȧ(Ȥ,"GetWeaponScope",ref Ȭ);Ȧ(Ȥ,"IsInRange",ref
ȫ);return true;}private void Ȧ<ȥ>(IReadOnlyDictionary<string,Delegate>Ȥ,string ȣ,ref ȥ Ȣ)where ȥ:class{if(Ȥ==null){Ȣ=null
;return;}Delegate ȡ;if(!Ȥ.TryGetValue(ȣ,out ȡ))throw new Exception(
$"{GetType().Name} :: Couldn't find {ȣ} delegate of type {typeof(ȥ)}");Ȣ=ȡ as ȥ;if(Ȣ==null)throw new Exception(
$"{GetType().Name} :: Delegate {ȣ} is not type {typeof(ȥ)}, instead it's: {ȡ.GetType()}");}public void ȯ(ICollection<MyDefinitionId>Ș)=>ǡ?.Invoke(Ș);public void Ⱥ(ICollection<MyDefinitionId>Ș)=>Ǡ?.Invoke(Ș);
public void ȹ(ICollection<MyDefinitionId>Ș)=>ǟ?.Invoke(Ș);public bool ȸ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ȷ,IDictionary<
string,int>Ș)=>Ǟ?.Invoke(ȷ,Ș)??false;public MyTuple<bool,int,int>ȶ(long ȵ)=>ǝ?.Invoke(ȵ)??new MyTuple<bool,int,int>();public
void ȴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȗ,IDictionary<MyDetectedEntityInfo,float>Ș)=>ǣ?.Invoke(Ȗ,Ș);public void ȳ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȗ,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ș)=>ǜ?.Invoke(Ȗ,Ș);public
MyDetectedEntityInfo?Ȳ(long ȱ,int Ȕ=0)=>ǚ?.Invoke(ȱ,Ȕ);public bool ȟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ȗ,long ȕ,int Ȕ=0)=>Ǚ?.Invoke(Ȗ,ȕ
,Ȕ)??false;public MyDetectedEntityInfo?ȓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ=0)=>ǘ?.Invoke(Ɠ,Ƒ);public void Ȓ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,long ȕ,int Ƒ=0)=>Ǘ?.Invoke(Ɠ,ȕ,Ƒ);public void Ȑ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Ɠ,bool Ȏ=true,int Ƒ=0)=>ǖ?.Invoke(Ɠ,Ȏ,Ƒ);public void ȏ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,bool ȑ,bool Ȏ,int Ƒ=0)=>Ǖ
?.Invoke(Ɠ,ȑ,Ȏ,Ƒ);public bool Ȟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ=0,bool ȝ=true,bool Ȝ=false)=>Ǜ?.Invoke(Ɠ,Ƒ
,ȝ,Ȝ)??false;public float ț(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ)=>ǔ?.Invoke(Ɠ,Ƒ)??0f;public bool Ț(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ɠ,IList<string>Ș,int Ƒ=0)=>ǥ?.Invoke(Ɠ,Ș,Ƒ)??false;public void ș(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɠ,IList<string>Ș,int Ƒ=0)=>Ƕ?.Invoke(Ɠ,Ș,Ƒ);public void ȗ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,float Ǔ)=>Ǵ?.Invoke(
Ɠ,Ǔ);public bool Ɲ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,long ƪ,int Ƒ)=>ǳ?.Invoke(Ɠ,ƪ,Ƒ)??false;public MyTuple<bool,
Vector3D?>ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,long ƪ,int Ƒ)=>ǲ?.Invoke(Ɠ,ƪ,Ƒ)??new MyTuple<bool,Vector3D?>();public bool
Ƭ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,long ƪ,int Ƒ)=>Ǳ?.Invoke(Ɠ,ƪ,Ƒ)??false;public Vector3D?ƫ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Ɠ,long ƪ,int Ƒ)=>ǰ?.Invoke(Ɠ,ƪ,Ƒ)??null;public float Ʈ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ)=>ǯ?.
Invoke(Ɠ)??0f;public float ƹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ)=>Ǯ?.Invoke(Ɠ)??0f;public float Ƹ(MyDefinitionId Ʒ)=>ǭ?.
Invoke(Ʒ)??0f;public bool ƶ(long Ɩ)=>Ǭ?.Invoke(Ɩ)??false;public bool Ƶ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ)=>ǫ?.Invoke(Ɠ)
??false;public float ƴ(long Ɩ)=>Ǫ?.Invoke(Ɩ)??0f;public string Ƴ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ)=>ǩ?.
Invoke(Ɠ,Ƒ)??null;public void Ʋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ,string Ʊ)=>Ǩ?.Invoke(Ɠ,Ƒ,Ʊ);public void ư(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ,Action<long,int,ulong,long,Vector3D,bool>ƙ)=>ǧ?.Invoke(Ɠ,Ƒ,ƙ);public void ƚ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ,Action<long,int,ulong,long,Vector3D,bool>ƙ)=>Ǧ?.Invoke(Ɠ,Ƒ,ƙ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ƙ(ulong Ɨ)=>Ƿ?.Invoke(Ɨ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ƛ(long Ɩ)=>ȍ?.Invoke(Ɩ)??0f;public long ƕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ)=>Ƞ?.Invoke(Ɠ)??-1;public
Matrix Ɣ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ)=>Ȱ?.Invoke(Ɠ,Ƒ)??Matrix.Zero;public Matrix ƒ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ɠ,int Ƒ)=>Ȯ?.Invoke(Ɠ,Ƒ)??Matrix.Zero;public bool Ɯ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,long Ʃ,bool ƨ,bool Ƨ)=>ȭ?.
Invoke(Ɠ,Ʃ,ƨ,Ƨ)??false;public MyTuple<Vector3D,Vector3D>Ʀ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ɠ,int Ƒ)=>Ȭ?.Invoke(Ɠ,Ƒ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>ƥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ƥ)=>ȫ?.Invoke(Ƥ)??new MyTuple<
bool,bool>();}int ƣ=0;double Ƣ=0;double ơ=0;void Ơ(){Ƣ=0;foreach(IMyTerminalBlock Ɵ in ϕ){if(Ɵ!=null&&Ɵ.IsFunctional)Ƣ++;}ơ=
Math.Round(100*(Ƣ/ƣ));}enum ƞ{
    Off, On, NoChange
    }enum Ǎ{
    Off, On, NoChange, OnNoColourChange
    }enum Ǐ{
    Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
    }enum ǎ{
    Off, HoldFire, OpenFire, NoChange
    }enum ǐ{
    Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
    }enum ǒ{
    Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
    }enum Ǒ{
    On, Off, OnMax, NoChange
    }enum ǌ{
    Auto, StockpileRecharge, Discharge, NoChange
    }enum ƾ{
    Abort, NoChange
    }enum ƽ{
    Off, On, FillWhenLow, KeepFull,
    }enum ƻ{
    Closed, Open, NoChange
    }
}sealed class Ƽ{public double ƺ{get;private set;}private double ƿ{get{double ǋ=ǃ[0];for(int Ę=1;Ę<ǅ;Ę++){ǋ+=ǃ[Ę];}return(
ǋ/ǅ);}}public double Ǌ{get{double ǉ=ǃ[0];for(int Ę=1;Ę<ǅ;Ę++){if(ǃ[Ę]>ǉ){ǉ=ǃ[Ę];}}return ǉ;}}public double ǈ{get;private
set;}public double Ǉ{get{double ǆ=ǃ[0];for(int Ę=1;Ę<ǅ;Ę++){if(ǃ[Ę]<ǆ){ǆ=ǃ[Ę];}}return ǆ;}}public int ǅ{get;}private double
Ǆ;private IMyGridProgramRuntimeInfo ǁ;private double[]ǃ;private int ǂ=0;public Ƽ(IMyGridProgramRuntimeInfo ǁ,int Ҙ=300){
this.ǁ=ǁ;this.ǈ=ǁ.LastRunTimeMs;this.ǅ=MathHelper.Clamp(Ҙ,1,int.MaxValue);this.Ǆ=1.0/ǅ;this.ǃ=new double[Ҙ];this.ǃ[ǂ]=ǁ.
LastRunTimeMs;this.ǂ++;}public void ǀ(){ƺ-=ǃ[ǂ]*Ǆ;ƺ+=ǁ.LastRunTimeMs*Ǆ;ǃ[ǂ]=ǁ.LastRunTimeMs;if(ǁ.LastRunTimeMs>ǈ){ǈ=ǁ.LastRunTimeMs;}
ǂ++;if(ǂ>=ǅ){ǂ=0;ƺ=ƿ;ǈ=ǁ.LastRunTimeMs;}}