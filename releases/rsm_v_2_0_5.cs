// ----------------------------------------------------------------------------------------------------------------------
//  REEDIT SHIP MANAGEMENT
// ----------------------------------------------------------------------------------------------------------------------
//  
//   Reedit Ship Management (RSM) is a broad, ship automation script tailor made for the Draconis Expanse server.
// 
//   • Read the guide...
//      https://github.com/christorreed/ReeditShipManagement
//   • Join the discussion...
//      https://discord.gg/tq3H4sem66
// 
// ----------------------------------------------------------------------------------------------------------------------

string Version = "2.0.5 (2024-11-03)";
private A B;int C=0;int D=0;int E=0;int F;int G=0;bool H=true;bool I=true;bool J=false;bool K=false;bool L=false;bool M=
false;bool N=false;bool O=false;bool P=false;string Q="";int R=0;int S=0;double T;float U;string V;string W;string X;bool Y=
false;int Z=0;int a=0;bool b;bool c;bool d;public
 Program
(){Echo("Welcome to RSM\nV "+Version);e();F=f;V=Me.GetOwnerFactionTag();B=new A(Runtime);g();h.Add(0.5);h.Add(0.25);h.Add
(0.1);h.Add(0.05);i();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo("Took "+e());}public void
 Main
(string j,UpdateType k){if(k==UpdateType.Update100)l();else m(j);}void m(string j){if(n)Echo("Processing command '"+j+
"'...");if(I){o(j,"RSM is still booting");return;}if(J){o(j,"RSM is still initialising");return;}if(j==""){o(j,
"the argument was blank");return;}string[]p=j.Split(':');if(p.Length<2){o(j,"the argument wasn't recognised");return;}if(p[0].ToLower()!="comms"
)p[1]=p[1].Replace(" ",string.Empty);switch(p[0].ToLower()){case"init":bool q=true,r=true,s=true;if(p.Length>2){foreach(
string t in p){if(t.ToLower()=="nonames")q=false;else if(t.ToLower()=="nosubs")r=false;else if(t.ToLower()=="noinv")s=false;}}
u(p[1],q,r,s);return;case"stance":v(p[1]);return;case"hudlcd":string w="";if(p.Length>2)w=p[2];x(p[1],w);return;case
"doors":string y="";if(p.Length>2)y=p[2];z(p[1],y);return;case"comms":ª(p[1]);return;case"printblockids":µ();return;case
"printblockprops":º(p[1]);return;case"spawn":if(p[1].ToLower()=="open"){N=true;F=f;}else{N=false;F=f;}return;case"projectors":if(p[1].
ToLower()=="save"){foreach(IMyProjector Â in À)Á(Â);Ã.Add(new Ä("Projector positions saved",
"Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector Â in À)Å(Â);Ã.Add(new Ä("Projector positions loaded",
"Projector positions were loaded from custom data.",2));return;}default:o(j,"the argument wasn't recognised");return;}}void o(string j,string Æ){Ã.Add(new Ä(
"COMMAND FAILED!","Command '"+j+"' was ignored because "+Æ,3));}void l(){if(Ç)e();if(D<È){D++;return;}D=0;if(H){Echo(
"Parsing custom data...");É();H=false;return;}else if(J){Ê();if(n)Echo("Updating "+Ë.Count+" RSM Lcds");Ì();}Í();Z=Runtime.
CurrentInstructionCount;if(Z>a)a=Runtime.CurrentInstructionCount;if(Î.Ï==Ð.On){K=true;L=true;}else if(Î.Ï==Ð.Off){K=true;}if(F>=f){F=0;Ñ();
return;}F++;Ò();Ó();if(Ç)Echo("Took "+e());if(n)Echo("Updating "+Ë.Count+" RSM Lcds");Ì();if(Ç)Echo("Took "+e());}void Ò(){Ô()
;switch(C){case 0:if(n)Echo("Refreshing "+(Õ.Count+Ö.Count)+" kinetics...");Ø();if(Ç)Echo("Took "+e());if(I)break;else
goto case 1;case 1:if(n)Echo("Refreshing "+Ù.Count+" reactors & "+Ú.Count+" batteries...");Û(Î.Ü);if(Ç)Echo("Took "+e());if(
I)break;else goto case 2;case 2:if(n)Echo("Refreshing "+Ý.Count+" epsteins...");Þ();if(Ç)Echo("Took "+e());if(I)break;
else goto case 3;case 3:if(n)Echo("Refreshing "+ß.Count+" lidars...");à(L,K);if(Ç)Echo("Took "+e());if(n)Echo(
"Refreshing pb servers...");á();if(Ç)Echo("Took "+e());if(I)break;else goto case 4;case 4:if(n)Echo("Refreshing "+â.Count+" doors...");ã();if(Ç)
Echo("Took "+e());if(n)Echo("Refreshing "+ä.Count+" airlocks...");å();if(Ç)Echo("Took "+e());break;default:if(n)Echo(
"Booting complete");I=false;C=0;return;}if(I)C++;}void Ó(){switch(E){case 0:if(n)Echo("Clearing temp inventories...");æ();if(Ç)Echo(
"Took "+e());if(n)Echo("Refreshing "+ç.Count+" torpedo launchers...");è();if(Ç)Echo("Took "+e());if(n)Echo(
"Refreshing items...");é();if(Ç)Echo("Took "+e());break;case 1:if(n)Echo("Running autoload...");ê();if(Ç)Echo("Took "+e());break;case 2:if(n)
Echo("Refreshing "+ë.Count+" H2 tanks...");ì();if(Ç)Echo("Took "+e());if(n)Echo("Refreshing refuel status...");í();if(M){if(
n)Echo("Fuel low, filling extractors...");î();if(Ç)Echo("Took "+e());return;}else{ï();if(Ç)Echo("Took "+e());}E=0;return;
}E++;}void ï(){if(n)Echo("Refreshing "+ð.Count+" rcs...");ñ();if(n)Echo("Refreshing "+ò.Count+" Pdcs & "+ó.Count+
" defensive Pdcs...");ô();if(n)Echo("Refreshing "+õ.Count+" gyros...");ö(L,K);if(n)Echo("Refreshing "+ø.Count+" O2 tanks...");ù();if(n)Echo(
"Refreshing "+ú.Count+" antennas...");û();if(n)Echo("Refreshing "+ü.Count+" cargos...");ý();if(n)Echo("Refreshing "+þ.Count+
" vents...");ÿ(L,K);if(n)Echo("Refreshing "+Ā.Count+" auxiliary blocks...");ā();if(n)Echo("Refreshing "+Ă.Count+" welders...");ă();
if(n)Echo("Refreshing "+Ą.Count+" lcds...");ą();if(n)Echo("Refreshing "+Ć.Count+" lcds...");ć();if(K){if(n)Echo(
"Refreshing "+Ĉ.Count+" connectors...");ĉ(L);if(n)Echo("Refreshing "+Ċ.Count+" cameras...");ċ(L);if(n)Echo("Refreshing "+Č.Count+
" sensors...");č(L);}}void Ñ(){if(n)Echo("Clearing block lists...");Ď();if(Ç)Echo("Took "+e());if(n)Echo("Refreshing block lists...")
;GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,ď);if(Ç)Echo("Took "+e());if(n)Echo(
"Setting KeepFull threshold");Đ();if(đ==null){if(Ē.Count>0)đ=Ē[0];else Ã.Add(new Ä("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(n)Echo("Finished block refresh.");if(Ç)Echo("Took "+e());}void Ô(){try{ē=new Ĕ();ē.ĕ(Me);}catch(Exception Ė){ē=
null;Ã.Add(new Ä("WcPbApi Error!","WcPbApi failed to start!\n"+Ė.Message,1));Echo("WcPbAPI failed to activate!");Echo(Ė.
Message);return;}}void Í(){string ė="REEDIT SHIP MANAGEMENT \n\n";if(I)ė+="Booting, please wait ("+C+"/5)...\n\n";ė+="|- V "+
Version+"\n|- Ship Name: "+Ę+"\n|- Stance: "+ę+"\n|- Step: "+F+"/"+f+" ("+E+")";if(Ç){B.Ě();ė+="\n|- Runtime Av/Tick: "+(Math.
Round(B.ě,2)/100)+" ms"+"\n|- Runtime Max: "+Math.Round(B.Ĝ,4)+" ms"+"\n|- Instructions: "+Z+" ("+a+")";}Echo(ė+"\n");}long ĝ
=0;string e(){long Ğ=DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;if(ĝ==0){ĝ=Ğ;return"0 ms";}long ğ=Ğ-ĝ;ĝ=Ğ;return ğ+
" ms";}bool Ġ=false;string ġ="";double Ģ=0;void û(){Ġ=false;Ģ=0;foreach(IMyRadioAntenna ģ in ú){if(ģ!=null&&!ģ.Closed&&ģ.
IsFunctional){float Ĥ=ģ.Radius;if(Ĥ>Ģ)Ģ=Ĥ;if(ģ.IsBroadcasting&&ģ.Enabled)Ġ=true;}}}void ª(string ĥ){ġ=ĥ;foreach(IMyTerminalBlock Ħ
in ú){IMyRadioAntenna ģ=Ħ as IMyRadioAntenna;if(ģ!=null)ģ.HudText=ĥ;}}void ê(){if(!ħ)return;foreach(Ĩ Ĩ in ĩ){if(!Ĩ.Ī&&!Ĩ.
ī)continue;if(n)Echo("Checking "+Ĩ.Ĭ);List<ĭ>İ=Ĩ.Į.Concat(Ĩ.į).ToList();List<ĭ>ı=new List<ĭ>();List<ĭ>Ĳ=new List<ĭ>();
List<ĭ>ĳ=new List<ĭ>();List<ĭ>Ĵ=new List<ĭ>();List<ĭ>ĵ=new List<ĭ>();int Ķ=0;int ķ=0;double ĸ=.97;if(Ĩ.Ĺ<1)ĸ=Ĩ.Ĺ*.97;foreach
(ĭ ĺ in İ){if(ĺ==null)continue;if(ĺ.Ļ){ķ++;Ķ+=ĺ.ļ;if(ĺ.Ľ<ĸ)ĳ.Add(ĺ);else if(Ĩ.Ĺ<1&&ĺ.Ľ>Ĩ.Ĺ*1.03)Ĵ.Add(ĺ);if(ĺ.Ľ!=0)Ĳ.Add(
ĺ);}else{ĵ.Add(ĺ);if(ĺ.ļ>0){ı.Add(ĺ);}}}if(ĳ.Count>0){int ľ=(int)(Ķ/ķ);ĳ=ĳ.OrderBy(Ŀ=>Ŀ.ļ).ToList();if(Ĩ.ŀ>0){if(n)Echo(
"Loading "+Ĩ.Ł.SubtypeId+"...");ı=ı.OrderByDescending(Ŀ=>Ŀ.ļ).ToList();ł(ı,ĳ,Ĩ.Ł,-1,Ĩ.Ĺ);}else{if(n)Echo("Balancing "+Ĩ.Ł.
SubtypeId+"...");Ĳ=Ĳ.OrderByDescending(Ŀ=>Ŀ.ļ).ToList();ł(Ĳ,ĳ,Ĩ.Ł,ľ);}}else if(Ĵ.Count>0){if(n)Echo("Unloading "+Ĩ.Ł.SubtypeId+
"...");List<ĭ>Ń=new List<ĭ>();if(ı.Count>0)Ń=ı;else Ń=ĵ;ł(Ĵ,Ń,Ĩ.Ł,-1,1,Ĩ.Ĺ);}else{if(n)Echo("No loading required "+Ĩ.Ł.
SubtypeId+"...");}}}void ā(){S=0;foreach(IMyTerminalBlock Ħ in Ā){if(Ħ==null)continue;if(Ħ.IsWorking)S++;}}void ŉ(Ð ń){if(ń==Ð.
NoChange)return;foreach(IMyTerminalBlock Ħ in Ā){if(Ħ==null)continue;try{bool Ņ=Ħ.BlockDefinition.ToString().Contains("ToolCore"
);if(ń==Ð.On||Ņ)Ħ.ApplyAction("OnOff_On");else if(!Ņ)Ħ.ApplyAction("OnOff_Off");if(Ņ){ITerminalAction ņ=Ħ.
GetActionWithName("ToolCore_Shoot_Action");if(ņ!=null){StringBuilder Ň=new StringBuilder();ņ.WriteValue(Ħ,Ň);string ň=Ň.ToString();if(n)
Echo(ň);if(ň=="Active"&&ń==Ð.Off)ņ.Apply(Ħ);else if(ň=="Inactive"&&ń==Ð.On)ņ.Apply(Ħ);}}}catch{if(n)Echo(
"Failed to set aux block "+Ħ.CustomName);}}}IMyShipController đ;private List<IMyRadioAntenna>ú=new List<IMyRadioAntenna>();private List<
IMyBatteryBlock>Ú=new List<IMyBatteryBlock>();private List<IMyCameraBlock>Ċ=new List<IMyCameraBlock>();private List<IMyCargoContainer>ü
=new List<IMyCargoContainer>();private List<IMyShipConnector>Ĉ=new List<IMyShipConnector>();private List<
IMyShipController>Ē=new List<IMyShipController>();private List<IMyAirtightHangarDoor>Ŋ=new List<IMyAirtightHangarDoor>();private List<
IMyTerminalBlock>ŋ=new List<IMyTerminalBlock>();private List<IMyTerminalBlock>Ō=new List<IMyTerminalBlock>();private List<IMyGyro>õ=new
List<IMyGyro>();private List<IMyProjector>À=new List<IMyProjector>();private List<IMyReactor>Ù=new List<IMyReactor>();
private List<IMySensorBlock>Č=new List<IMySensorBlock>();private List<IMyTerminalBlock>Ć=new List<IMyTerminalBlock>();private
List<IMyGasTank>ë=new List<IMyGasTank>();private List<IMyGasTank>ø=new List<IMyGasTank>();private List<IMyAirVent>þ=new List
<IMyAirVent>();private List<IMyTerminalBlock>Ă=new List<IMyTerminalBlock>();private List<IMyConveyorSorter>ß=new List<
IMyConveyorSorter>();private List<IMyTerminalBlock>ò=new List<IMyTerminalBlock>();private List<IMyTerminalBlock>ó=new List<
IMyTerminalBlock>();private List<IMyTerminalBlock>Õ=new List<IMyTerminalBlock>();private List<IMyTerminalBlock>Ö=new List<
IMyTerminalBlock>();private List<IMyTerminalBlock>ç=new List<IMyTerminalBlock>();private List<IMyThrust>Ý=new List<IMyThrust>();private
List<IMyThrust>ð=new List<IMyThrust>();private List<IMyThrust>ō=new List<IMyThrust>();private List<IMyThrust>Ŏ=new List<
IMyThrust>();private List<IMyProgrammableBlock>ŏ=new List<IMyProgrammableBlock>();private List<IMyProgrammableBlock>Ő=new List<
IMyProgrammableBlock>();private List<IMyTextPanel>Ą=new List<IMyTextPanel>();private List<IMyTextPanel>ő=new List<IMyTextPanel>();private
List<Œ>Ë=new List<Œ>();private List<IMyLightingBlock>œ=new List<IMyLightingBlock>();private List<IMyLightingBlock>Ŕ=new List
<IMyLightingBlock>();private List<IMyLightingBlock>ŕ=new List<IMyLightingBlock>();private List<IMyLightingBlock>Ŗ=new
List<IMyLightingBlock>();private List<IMyReflectorLight>ŗ=new List<IMyReflectorLight>();private List<IMyTerminalBlock>Ā=new
List<IMyTerminalBlock>();private List<IMyTerminalBlock>Ř=new List<IMyTerminalBlock>();private List<ř>â=new List<ř>();private
List<Ś>ä=new List<Ś>();private Dictionary<IMyTerminalBlock,string>ś=new Dictionary<IMyTerminalBlock,string>();private bool ď
(IMyTerminalBlock Ŝ){try{if(!Me.IsSameConstructAs(Ŝ))return false;string ŝ=Ŝ.GetOwnerFactionTag();if(ŝ!=V&&ŝ!=""){Echo(
"!"+ŝ+": "+Ŝ.CustomName);R++;return false;}if(Ŝ.CustomName.Contains(Ş))return false;if(!J&&ş&&!Ŝ.CustomName.Contains(Ę))
return false;string Š=Ŝ.BlockDefinition.ToString();if(Ŝ.CustomName.Contains(š)){Ā.Add(Ŝ);}if(Š.Contains("MedicalRoom/")){if(N)
Ŝ.CustomData=X;else Ŝ.CustomData=W;Ć.Add(Ŝ);if(J)ś.Add(Ŝ,"Medical Room");return false;}if(Š.Contains("SurvivalKit/")){if(
N)Ŝ.CustomData=X;else Ŝ.CustomData=W;Ć.Add(Ŝ);if(J)ś.Add(Ŝ,"Survival Kit");return false;}if(Š==
"MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(J)ś.Add(Ŝ,"Refill Station");return false;}var Ţ=Ŝ as IMyTextPanel;if(Ţ!=null){Ą.Add(Ţ);if(J)ś.Add(Ŝ,"LCD");if(Ţ.
CustomName.Contains(ţ)){Œ Ť=new Œ();Ť.Ħ=Ţ;Ë.Add(ť(Ť));}else if(!Ŧ&&Ţ.CustomName.Contains(ŧ))ő.Add(Ţ);return false;}if(Š==
"MyObjectBuilder_ConveyorSorter/Ostman-Jazinski Flak Cannon")return Ũ(Ŝ,"Flak",3);if(Š=="MyObjectBuilder_ConveyorSorter/Outer Planets Alliance Point Defence Cannon")return Ũ(Ŝ,
"OPA",3);if(Š=="MyObjectBuilder_ConveyorSorter/Voltaire Collective Anti Personnel PDC")return Ũ(Ŝ,"Voltaire",3);if(Š.Contains
("Nariman Dynamics PDC"))return Ũ(Ŝ,"Nari",4);if(Š.Contains("Redfields Ballistics PDC"))return Ũ(Ŝ,"Red",4);if(Š.Contains
("OPA Shotgun PDC"))return Ũ(Ŝ,"Shotgun",4);if(Š=="MyObjectBuilder_ConveyorSorter/Apollo Class Torpedo Launcher")return ũ
(Ŝ,"Apollo");if(Š=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ũ(Ŝ,"Tycho");if(Š==
"MyObjectBuilder_ConveyorSorter/ZeusClass_Rapid_Torpedo_Launcher")return ũ(Ŝ,"Zeus");if(Š=="MyObjectBuilder_ConveyorSorter/Tycho Class Torpedo Mount")return ũ(Ŝ,"Tycho");if(Š.Contains(
"Ares_Class"))return ũ(Ŝ,"Ares");if(Š.Contains("Artemis_Torpedo_Tube"))return ũ(Ŝ,"Artemis");if(Š==
"MyObjectBuilder_ConveyorSorter/Dawson-Pattern Medium Railgun")return Ū(Ŝ,"Dawson",11);if(Š=="MyObjectBuilder_ConveyorSorter/V-14 Stiletto Light Railgun")return Ū(Ŝ,"Stiletto",12);if
(Š=="MyObjectBuilder_ConveyorSorter/T-47 Roci Light Fixed Railgun")return Ū(Ŝ,"Roci",13,true);if(Š==
"MyObjectBuilder_ConveyorSorter/VX-12 Foehammer Ultra-Heavy Railgun")return Ū(Ŝ,"Foehammer",14);if(Š=="MyObjectBuilder_ConveyorSorter/Farren-Pattern Heavy Railgun")return Ū(Ŝ,"Farren",15);
if(Š=="MyObjectBuilder_ConveyorSorter/Zakosetara Heavy Railgun")return Ū(Ŝ,"Zako",10,true,"Fixed");if(Š==
"MyObjectBuilder_ConveyorSorter/Mounted Zakosetara Heavy Railgun")return Ū(Ŝ,"Zako",10);if(Š.Contains("Kess Hashari Cannon"))return Ū(Ŝ,"Kess",16,true,"Fixed");if(Š.Contains("Coilgun"))
return Ū(Ŝ,"Coilgun",13,false,"");if(Š.Contains("Glapion"))return Ū(Ŝ,"Glapion",3,true,"Fixed");var ū=Ŝ as IMyThrust;if(ū!=
null){if(Š.ToUpper().Contains("RCS")){ð.Add(ū);if(J)ś.Add(Ŝ,"RCS");}else if(Š.Contains("Hydro")){ō.Add(ū);if(J)ś.Add(Ŝ,
"Chem");}else if(Š.Contains("Atmospheric")){Ŏ.Add(ū);if(J)ś.Add(Ŝ,"Atmo");}else{Ý.Add(ū);if(J){string Ŭ="";if(ŭ){try{Ŭ=Ŝ.
DefinitionDisplayNameText.Split('"')[1];Ŭ=Ů+Ŭ[0].ToString().ToUpper()+Ŭ.Substring(1).ToLower();}catch{if(n)Echo("Failed to get drive type from "+
Ŝ.DefinitionDisplayNameText);}}ś.Add(Ŝ,"Epstein"+Ŭ);}}return false;}var ů=Ŝ as IMyCargoContainer;if(ů!=null){string Ű=Š.
Split('/')[1];if(Ű.Contains("Container")||Ű.Contains("Cargo")){ü.Add(ů);ű(Ŝ);if(J){double Ų=Ŝ.GetInventory().MaxVolume.
RawValue;double ų=Math.Round(Ų/1265625024,1);if(ų==0)ų=0.1;ś.Add(Ŝ,"Cargo ["+ų+"]");}return false;}}var Ŵ=Ŝ as IMyGyro;if(Ŵ!=
null){õ.Add(Ŵ);if(J)ś.Add(Ŝ,"Gyroscope");return false;}var ŵ=Ŝ as IMyBatteryBlock;if(ŵ!=null){Ú.Add(ŵ);if(J)ś.Add(Ŝ,"Power"+
Ů+"Battery");return false;}var Ŷ=Ŝ as IMyReflectorLight;if(Ŷ!=null){ŗ.Add(Ŷ);if(J)ś.Add(Ŝ,"Spotlight");return false;}var
ŷ=Ŝ as IMyLightingBlock;if(ŷ!=null){if(Ŝ.CustomName.ToUpper().Contains("INTERIOR")){Ŕ.Add(ŷ);if(J)ś.Add(Ŝ,"Light"+Ů+
"Interior");}else if(Š.Contains("Kitchen")||Š.Contains("Aquarium")){Ŕ.Add(ŷ);if(J)ś.Add(Ŝ,"Light"+Ů+"Interior"+Ů+Ŝ.
DefinitionDisplayNameText);}else if(Ŝ.CustomName.Contains(Ÿ)){if(Ŝ.CustomName.ToUpper().Contains("STARBOARD")){Ŗ.Add(ŷ);if(J)ś.Add(Ŝ,"Light"+Ů+
"Nav"+Ů+"Starboard");}else{ŕ.Add(ŷ);if(J)ś.Add(Ŝ,"Light"+Ů+"Nav"+Ů+"Port");}}else{œ.Add(ŷ);if(J)ś.Add(Ŝ,"Light"+Ů+"Exterior")
;}return false;}var Ź=Ŝ as IMyGasTank;if(Ź!=null){if(Š.Contains("Hydro")){ë.Add(Ź);if(J)ś.Add(Ŝ,"Tank"+Ů+"Hydrogen");}
else{ø.Add(Ź);if(J)ś.Add(Ŝ,"Tank"+Ů+"Oxygen");}return false;}var ź=Ŝ as IMyReactor;if(ź!=null){Ù.Add(ź);ű(Ŝ,0);if(J){string
Ż="Lg";if(Š.Contains("SmallGenerator"))Ż="Sm";else if(Š.Contains("MCRN"))Ż="MCRN";ś.Add(Ŝ,"Power"+Ů+"Reactor"+Ů+Ż);}
return false;}var ż=Ŝ as IMyShipController;if(ż!=null){Ē.Add(ż);if(đ==null&&Ŝ.CustomName.Contains("Nav"))đ=ż;if(ż.HasInventory
)ű(Ŝ);if(J&&Š.Contains("Cockpit/")){if(Š.Contains("StandingCockpit")||Š.Contains("Console")){ś.Add(Ŝ,"Console");return
false;}else if(Š.Contains("Cockpit")){ś.Add(Ŝ,"Cockpit");return false;}}}var Ž=Ŝ as IMyDoor;if(Ž!=null){ř ž=new ř();ž.Ħ=Ž;if(
Ŝ.CustomName.Contains(ſ)){try{string ƀ=Ŝ.CustomName.Split(Ů)[3];ž.Ɓ=true;bool Ƃ=false;foreach(Ś ƃ in ä){if(ƀ==ƃ.Ƅ){ƃ.ƅ.
Add(ž);Ƃ=true;break;}}if(!Ƃ){Ś Ɔ=new Ś();Ɔ.Ƅ=ƀ;Ɔ.ƅ.Add(ž);ä.Add(Ɔ);}}catch{if(n)Echo("Error with airlock door name "+Ŝ.
CustomName);â.Add(ž);}}else{â.Add(ž);}if(J)ś.Add(Ŝ,"Door");return false;}var Ƈ=Ŝ as IMyAirVent;if(Ƈ!=null){þ.Add(Ƈ);if(Ŝ.
CustomName.Contains(ſ)){try{string ƀ=Ŝ.CustomName.Split(Ů)[3];bool Ƃ=false;foreach(Ś ƃ in ä){if(ƀ==ƃ.Ƅ){ƃ.ƈ.Add(Ƈ);Ƃ=true;break;}}
if(!Ƃ){Ś Ɔ=new Ś();Ɔ.Ƅ=ƀ;Ɔ.ƈ.Add(Ƈ);ä.Add(Ɔ);}}catch{if(n)Echo("Error with airlock vent name "+Ŝ.CustomName);}}if(J)ś.Add(
Ŝ,"Vent");return false;}var Ɖ=Ŝ as IMyCameraBlock;if(Ɖ!=null){Ċ.Add(Ɖ);if(J)ś.Add(Ŝ,"Camera");return false;}var Ɗ=Ŝ as
IMyShipConnector;if(Ɗ!=null){Ĉ.Add(Ɗ);ű(Ŝ);if(J){string Ƌ="";if(Š.Contains("Passageway"))Ƌ=Ů+"Passageway";ś.Add(Ŝ,"Connector"+Ƌ);}return
false;}var ƌ=Ŝ as IMyAirtightHangarDoor;if(ƌ!=null){Ŋ.Add(ƌ);if(J)ś.Add(Ŝ,"Door"+Ů+"Hangar");return false;}if(Š.Contains(
"Lidar")){var ƍ=Ŝ as IMyConveyorSorter;if(ƍ!=null){ß.Add(ƍ);if(J)ś.Add(Ŝ,"LiDAR");return false;}}if(Š==
"MyObjectBuilder_OxygenGenerator/Extractor"){ŋ.Add(Ŝ);if(J)ś.Add(Ŝ,"Extractor");return false;}if(Š=="MyObjectBuilder_OxygenGenerator/ExtractorSmall"){Ō.Add(Ŝ);if(J
)ś.Add(Ŝ,"Extractor");return false;}var Ǝ=Ŝ as IMyRadioAntenna;if(Ǝ!=null){ú.Add(Ǝ);if(J)ś.Add(Ŝ,"Antenna");return false;
}var Ə=Ŝ as IMyProgrammableBlock;if(Ə!=null){if(J)ś.Add(Ŝ,"PB Server");if(Ə==Me)return false;try{if(Ŝ.CustomData.Contains
("Sigma_Draconis_Expanse_Server "))ŏ.Add(Ə);else if(Ŝ.CustomData.Contains("NavConfig"))Ő.Add(Ə);return false;}catch{}}var
Ɛ=Ŝ as IMyProjector;if(Ɛ!=null){À.Add(Ɛ);if(J)ś.Add(Ŝ,"Projectors");return false;}var Ƒ=Ŝ as IMySensorBlock;if(Ƒ!=null){Č
.Add(Ƒ);if(J)ś.Add(Ŝ,"Sensor");return false;}var ƒ=Ŝ as IMyCollector;if(ƒ!=null){ű(Ŝ);if(J)ś.Add(Ŝ,"Collector");return
false;}if(Š.Contains("Welder")){Ă.Add(Ŝ);if(J)ś.Add(Ŝ,"Tool"+Ů+"Welder");return false;}if(J){if(Š.Contains("LandingGear/")){
if(Š.Contains("Clamp"))ś.Add(Ŝ,"Clamp");else if(Š.Contains("Magnetic"))ś.Add(Ŝ,"Mag Lock");else ś.Add(Ŝ,"Gear");return
false;}if(Š.Contains("Drill")){ś.Add(Ŝ,"Tool"+Ů+"Drill");return false;}if(Š.Contains("Grinder")){ś.Add(Ŝ,"Tool"+Ů+"Grinder");
return false;}if(Š.Contains("Solar")){ś.Add(Ŝ,"Solar");return false;}if(Š.Contains("ButtonPanel")){ś.Add(Ŝ,"Button Panel");
return false;}var Ɠ=Ŝ as IMyConveyorSorter;if(Ɠ!=null){ś.Add(Ŝ,"Sorter");return false;}var Ɣ=Ŝ as IMyMotorSuspension;if(Ɣ!=
null){ś.Add(Ŝ,"Suspension");return false;}var ƕ=Ŝ as IMyGravityGenerator;if(ƕ!=null){ś.Add(Ŝ,"Grav Gen");return false;}var Ɩ
=Ŝ as IMyTimerBlock;if(Ɩ!=null){ś.Add(Ŝ,"Timer");return false;}var Ɨ=Ŝ as IMyGasGenerator;if(Ɨ!=null){ś.Add(Ŝ,"H2 Engine"
);return false;}var Ƙ=Ŝ as IMyBeacon;if(Ƙ!=null){ś.Add(Ŝ,"Beacon");return false;}ś.Add(Ŝ,Ŝ.DefinitionDisplayNameText);}
return false;}catch(Exception ƙ){if(n){Echo("Failed to sort "+Ŝ.CustomName+"\nAdded "+ś.Count+" so far.");Echo(ƙ.Message);}
return false;}}void Ď(){đ=null;ú.Clear();Ú.Clear();Ċ.Clear();ü.Clear();Ĉ.Clear();Ē.Clear();â.Clear();ä.Clear();Ŋ.Clear();ŋ.
Clear();Ō.Clear();õ.Clear();À.Clear();Ù.Clear();Č.Clear();ë.Clear();ø.Clear();þ.Clear();Ă.Clear();ß.Clear();ò.Clear();ó.Clear
();Õ.Clear();Ö.Clear();ç.Clear();Ý.Clear();ð.Clear();ō.Clear();Ŏ.Clear();ŏ.Clear();Ő.Clear();Ą.Clear();Ë.Clear();ő.Clear(
);œ.Clear();Ŕ.Clear();ŕ.Clear();Ŗ.Clear();ŗ.Clear();Ā.Clear();foreach(Ĩ Ĩ in ĩ)Ĩ.Į.Clear();if(J)ś.Clear();}bool Ũ(
IMyTerminalBlock Ŝ,string ƚ,int ƛ){if(Ŝ.CustomName.Contains(Ɯ))ó.Add(Ŝ);else ò.Add(Ŝ);ű(Ŝ,ƛ);if(J){string Ŭ="";if(Ɲ)Ŭ=Ů+ƚ;ś.Add(Ŝ,"PDC"+
Ŭ);}return false;}bool ũ(IMyTerminalBlock Ŝ,string ƚ){ç.Add(Ŝ);if(J){string ƞ="";if(Ɲ)ƞ=Ů+ƚ;ś.Add(Ŝ,"Torpedo"+ƞ);}return
false;}bool Ū(IMyTerminalBlock Ŝ,string ƚ,int ƛ,bool Ɵ=false,string Ơ="Rail"){if(Ɵ)Ö.Add(Ŝ);else Õ.Add(Ŝ);ű(Ŝ,ƛ);if(J){string
ƞ="";if(Ơ!="")Ơ=Ů+Ơ;if(Ɲ)ƞ=Ů+ƚ;ś.Add(Ŝ,"Kinetic"+Ơ+ƞ);}return false;}Œ ť(Œ ơ,string Ƣ=""){bool ƣ=Ƣ=="",Ƥ=!ƣ;string ƥ=ơ.Ħ.
CustomData,Ʀ="RSM.LCD";string[]Ƨ=null;MyIni ƨ=new MyIni();MyIniParseResult Ʃ;if(!ƣ||ƥ=="")Ƥ=true;else{try{if(ƥ.Substring(0,12)==
"Show Header="){Ƨ=ƥ.Split('\n');foreach(string ƪ in Ƨ){if(ƪ.Contains("hud")){if(ƪ.Contains("lcd")){Ƣ=ƪ;break;}}else if(ƪ.Contains("=")
){string[]ƫ=ƪ.Split('=');if(ƫ[0]=="Show Tanks & Batteries")ơ.Ƭ=bool.Parse(ƫ[1]);else if(ƫ[0]=="Show header"||ƫ[0]==
"Show Header")ơ.ƭ=bool.Parse(ƫ[1]);else if(ƫ[0]=="Show Header Overlay")ơ.Ʈ=bool.Parse(ƫ[1]);else if(ƫ[0]=="Show Warnings")ơ.Ư=bool.
Parse(ƫ[1]);else if(ƫ[0]=="Show Inventory")ơ.ư=bool.Parse(ƫ[1]);else if(ƫ[0]=="Show Thrust")ơ.Ʊ=bool.Parse(ƫ[1]);else if(ƫ[0]
=="Show Subsystem Integrity")ơ.Ʋ=bool.Parse(ƫ[1]);else if(ƫ[0]=="Show Advanced Thrust")ơ.Ƴ=bool.Parse(ƫ[1]);}}}else if(!ƨ.
TryParse(ƥ,out Ʃ)){Ƥ=true;}else{ơ.ƭ=ƨ.Get(Ʀ,"ShowHeader").ToBoolean(ơ.ƭ);ơ.Ʈ=ƨ.Get(Ʀ,"ShowHeaderOverlay").ToBoolean(ơ.Ʈ);ơ.Ư=ƨ.
Get(Ʀ,"ShowWarnings").ToBoolean(ơ.Ư);ơ.Ƭ=ƨ.Get(Ʀ,"ShowPowerAndTanks").ToBoolean(ơ.Ƭ);ơ.ư=ƨ.Get(Ʀ,"ShowInventory").ToBoolean
(ơ.ư);ơ.Ʊ=ƨ.Get(Ʀ,"ShowThrust").ToBoolean(ơ.Ʊ);ơ.Ʋ=ƨ.Get(Ʀ,"ShowIntegrity").ToBoolean(ơ.Ʋ);ơ.Ƴ=ƨ.Get(Ʀ,
"ShowAdvancedThrust").ToBoolean(ơ.Ƴ);}}catch(Exception Ė){if(n)Echo("LCD parsing error, resetting\n"+Ė.Message);Ƥ=true;}}if(ơ.ƭ&&ơ.Ʈ){ơ.ƭ=
false;Ƥ=true;}if(Ƥ){if(Ƨ==null)Ƨ=ƥ.Split('\n');ƨ.Set(Ʀ,"ShowHeader",ơ.ƭ);ƨ.Set(Ʀ,"ShowHeaderOverlay",ơ.Ʈ);ƨ.Set(Ʀ,
"ShowWarnings",ơ.Ư);ƨ.Set(Ʀ,"ShowPowerAndTanks",ơ.Ƭ);ƨ.Set(Ʀ,"ShowInventory",ơ.ư);ƨ.Set(Ʀ,"ShowThrust",ơ.Ʊ);ƨ.Set(Ʀ,"ShowIntegrity",ơ.
Ʋ);ƨ.Set(Ʀ,"ShowAdvancedThrust",ơ.Ƴ);ƨ.Set(Ʀ,"Hud",Ƣ);ơ.Ħ.CustomData=ƨ.ToString();if(ƣ)Ã.Add(new Ä("LCD CONFIG ERROR!!",
"Failed to parse LCD config for "+ơ.Ħ.CustomName+"!\nLCD config was reset!",3));}return ơ;}void ƴ(IMyTerminalBlock Ħ,bool ĕ){Ħ.GetActionWithName(
"ToolCore_Shoot_Action").Apply(Ħ);(Ħ as IMyConveyorSorter).GetActionWithName("ToolCore_Shoot_Action").Apply(Ħ);}void µ(){List<IMyTerminalBlock>
Ƶ=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(Ƶ);string ƶ="";foreach(
IMyTerminalBlock Ʒ in Ƶ){ƶ+=Ʒ.BlockDefinition+"\n";}if(ú.Count>0&&ú[0]!=null){ú[0].CustomData=ƶ;}}void º(string Ƹ){IMyTerminalBlock Ħ=
GridTerminalSystem.GetBlockWithName(Ƹ);List<ITerminalAction>ƹ=new List<ITerminalAction>();Ħ.GetActions(ƹ);List<ITerminalProperty>ƺ=new
List<ITerminalProperty>();Ħ.GetProperties(ƺ);string ƻ=Ħ.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction Ƽ in ƹ){ƻ+=Ƽ.
Id+" "+Ƽ.Name+"\n";}ƻ+="\n\n**Properties**\n\n";foreach(ITerminalProperty ƽ in ƺ){ƻ+=ƽ.Id+" "+ƽ.TypeName+"\n";}if(ú.Count>
0&&ú[0]!=null)ú[0].CustomData=ƻ;Ħ.CustomData=ƻ;}void ǀ(IMyTerminalBlock ƾ){bool ƿ=ƾ.GetValue<bool>("WC_Repel");if(!ƿ)ƾ.
ApplyAction("WC_RepelMode");}void ǁ(IMyTerminalBlock ƾ){bool ƿ=ƾ.GetValue<bool>("WC_Repel");if(ƿ)ƾ.ApplyAction("WC_RepelMode");}
void ǃ(IMyTerminalBlock ƾ){try{if(ē.ǂ(ƾ,0)==VRageMath.Matrix.Zero)return;ƾ.SetValue<Int64>("WC_Shoot Mode",3);if(n)Echo(
"Shoot mode = "+ƾ.GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to manual on "+ƾ.CustomName);}}void Ǆ(
IMyTerminalBlock ƾ){try{if(ē.ǂ(ƾ,0)==VRageMath.Matrix.Zero)return;ƾ.SetValue<Int64>("WC_Shoot Mode",0);if(n)Echo("Shoot mode = "+ƾ.
GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to auto on "+ƾ.CustomName);}}void ǆ(){if(đ!=null){try{T=đ
.GetShipSpeed();U=đ.CalculateShipMass().PhysicalMass;}catch(Exception ǅ){Echo("Failed to get velocity or mass!");Echo(ǅ.
Message);}}}private double Ǉ=0;private double ǈ=0;private double ǉ=0;private void ý(){ǈ=0;foreach(IMyCargoContainer Ǌ in ü){if(
Ǌ!=null&&!Ǌ.Closed&&Ǌ.IsFunctional){try{ǈ+=Ǌ.GetInventory().MaxVolume.RawValue;}catch(Exception Ė){if(n)Echo(
"Cargo integrity error!\n"+Ė.Message);throw Ė;}}}ǉ=Math.Round(100*(ǈ/Ǉ));}private void ǋ(){Ǉ=0;foreach(IMyCargoContainer Ǌ in ü){if(Ǌ!=null)Ǉ+=Ǌ.
GetInventory().MaxVolume.RawValue;}}MyIni ǌ=new MyIni();bool ş=false;bool ħ=true;bool Ǎ=true;bool ǎ=true;bool Ǐ=true;bool ǐ=false;
string Ǒ="";bool ǒ=true;int Ǔ=3;int ǔ=6;string Ş="[I]";string ţ="[RSM]";string ŧ="[CS]";string š="Autorepair";string Ɯ="Repel"
;string Ǖ="Min";string ǖ="Docking";string Ÿ="Nav";string ſ="Airlock";string Ǘ="[EFC]";string ǘ="[NavOS]";char Ů='.';bool
Ɲ=true;bool ŭ=true;List<string>Ǚ=new List<string>();bool ǚ=false;bool Ŧ=false;bool Ǜ=true;List<double>h=new List<double>(
);bool ǜ=false;double ǝ=0.5;bool n=false;bool Ç=false;int È=0;int f=100;string Ę="";bool ȵ(){string ƥ=Me.CustomData;
string Ʀ="";bool Ǟ=true;MyIniParseResult Ʃ;if(!ǌ.TryParse(ƥ,out Ʃ)){string[]ǟ=ƥ.Split('\n');if(ǟ[1]=="Reedit Ship Management")
{Echo("Legacy config detected...");Ǡ(ƥ);return false;}else{Echo("Could not parse custom data!\n"+Ʃ.ToString());return
false;}}try{Ʀ="RSM.Main";Echo(Ʀ);ş=ǌ.Get(Ʀ,"RequireShipName").ToBoolean(ş);ħ=ǌ.Get(Ʀ,"EnableAutoload").ToBoolean(ħ);Ǎ=ǌ.Get(Ʀ
,"AutoloadReactors").ToBoolean(Ǎ);ǎ=ǌ.Get(Ʀ,"AutoConfigWeapons").ToBoolean(ǎ);Ǐ=ǌ.Get(Ʀ,"SetTurretFireMode").ToBoolean(Ǐ)
;Ʀ="RSM.Spawns";Echo(Ʀ);ǐ=ǌ.Get(Ʀ,"PrivateSpawns").ToBoolean(ǐ);Ǒ=ǌ.Get(Ʀ,"FriendlyTags").ToString(Ǒ);Ʀ="RSM.Doors";Echo(
Ʀ);ǒ=ǌ.Get(Ʀ,"EnableDoorManagement").ToBoolean(ǒ);Ǔ=ǌ.Get(Ʀ,"DoorCloseTimer").ToInt32(Ǔ);Ǔ=ǌ.Get(Ʀ,
"AirlockDoorDisableTimer").ToInt32(Ǔ);Ʀ="RSM.Keywords";Echo(Ʀ);Ş=ǌ.Get(Ʀ,"Ignore").ToString(Ş);ţ=ǌ.Get(Ʀ,"RsmLcds").ToString(ţ);ŧ=ǌ.Get(Ʀ,
"ColourSyncLcds").ToString(ŧ);š=ǌ.Get(Ʀ,"AuxiliaryBlocks").ToString(š);Ɯ=ǌ.Get(Ʀ,"DefensivePdcs").ToString(Ɯ);Ǖ=ǌ.Get(Ʀ,
"MinimumThrusters").ToString(Ǖ);ǖ=ǌ.Get(Ʀ,"DockingThrusters").ToString(ǖ);Ÿ=ǌ.Get(Ʀ,"NavLights").ToString(Ÿ);ſ=ǌ.Get(Ʀ,"Airlock").ToString
(ſ);Ʀ="RSM.InitNaming";Echo(Ʀ);string ǡ=ǌ.Get(Ʀ,"NameDelimiter").ToString(Ů.ToString());int Ǣ=0;if(ǡ.Length>1)Ǣ=1;Ů=char.
Parse(ǡ.Substring(Ǣ,1));Ɲ=ǌ.Get(Ʀ,"NameWeaponTypes").ToBoolean(Ɲ);ŭ=ǌ.Get(Ʀ,"NameDriveTypes").ToBoolean(ŭ);string ǣ=ǌ.Get(Ʀ,
"BlocksToNumber").ToString("");string[]Ǥ=ǣ.Split(',');Ǚ.Clear();foreach(string Ƹ in Ǥ)if(Ƹ!="")Ǚ.Add(Ƹ);Ʀ="RSM.Misc";Echo(Ʀ);ǚ=ǌ.Get(Ʀ,
"DisableLightingControl").ToBoolean(ǚ);Ŧ=ǌ.Get(Ʀ,"DisableLcdColourControl").ToBoolean(Ŧ);Ǜ=ǌ.Get(Ʀ,"ShowBasicTelemetry").ToBoolean(Ǜ);string ǥ=ǌ
.Get(Ʀ,"DecelerationPercentages").ToString("");string[]Ǧ=ǥ.Split(',');if(Ǧ.Length>1){h.Clear();foreach(string ǧ in Ǧ){h.
Add(double.Parse(ǧ)/100);}}ǜ=ǌ.Get(Ʀ,"ShowThrustInMetric").ToBoolean(ǜ);ǝ=ǌ.Get(Ʀ,"ReactorFillRatio").ToDouble(ǝ);ĩ[0].Ĺ=ǝ;
Ʀ="RSM.Debug";Echo(Ʀ);n=ǌ.Get(Ʀ,"VerboseDebugging").ToBoolean(n);Ç=ǌ.Get(Ʀ,"RuntimeProfiling").ToBoolean(Ç);f=ǌ.Get(Ʀ,
"BlockRefreshFreq").ToInt32(f);È=ǌ.Get(Ʀ,"StallCount").ToInt32(È);Ʀ="RSM.System";Echo(Ʀ);Ę=ǌ.Get(Ʀ,"ShipName").ToString(Ę);Ʀ=
"RSM.InitItems";Echo(Ʀ);foreach(Ĩ Ǩ in ĩ){Ǩ.ǩ=ǌ.Get(Ʀ,Ǩ.Ł.SubtypeId).ToInt32(Ǩ.ǩ);}Ʀ="RSM.InitSubSystems";Echo(Ʀ);Ǫ=ǌ.Get(Ʀ,"Reactors")
.ToDouble(Ǫ);ǫ=ǌ.Get(Ʀ,"Batteries").ToDouble(ǫ);Ǭ=ǌ.Get(Ʀ,"Pdcs").ToInt32(Ǭ);ǭ=ǌ.Get(Ʀ,"TorpLaunchers").ToInt32(ǭ);Ǯ=ǌ.
Get(Ʀ,"KineticWeapons").ToInt32(Ǯ);ǯ=ǌ.Get(Ʀ,"H2Storage").ToDouble(ǯ);ǰ=ǌ.Get(Ʀ,"O2Storage").ToDouble(ǰ);Ǳ=ǌ.Get(Ʀ,
"MainThrust").ToSingle(Ǳ);ǲ=ǌ.Get(Ʀ,"RCSThrust").ToSingle(ǲ);ǳ=ǌ.Get(Ʀ,"Gyros").ToDouble(ǳ);Ǉ=ǌ.Get(Ʀ,"CargoStorage").ToDouble(Ǉ);Ǵ=
ǌ.Get(Ʀ,"Welders").ToInt32(Ǵ);}catch(Exception Ė){ǵ(Ė,"Failed to parse section\n"+Ʀ);}Echo("Parsing stances...");
Dictionary<string,Ƕ>Ƿ=new Dictionary<string,Ƕ>();List<string>Ǹ=new List<string>();ǌ.GetSections(Ǹ);foreach(string ǹ in Ǹ){if(ǹ.
Contains("RSM.Stance.")){string Ǻ=ǹ.Substring(11);Echo(Ǻ);Ƕ ǻ=new Ƕ();string Ǽ,ǽ="";string[]Ǿ;int ǿ=33,Ȁ=144,Ŝ=255,Ŀ=255;bool ȁ=
false;Ƕ Ȃ=null;ǽ="Inherits";if(ǌ.ContainsKey(ǹ,ǽ)){ȁ=true;try{Ȃ=Ƿ[ǌ.Get(ǹ,ǽ).ToString()];Echo("Inherits "+ǌ.Get(ǹ,ǽ).ToString
());}catch(Exception Ė){ǵ(Ė,"Failed to find inheritee for\n"+ǹ+
"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(ȁ)Echo(Ȃ.ȃ.ToString());ǽ="Torps";if(ǌ.ContainsKey(ǹ,ǽ)){ǻ.ȃ=(Ð)Enum.Parse(typeof(Ð),ǌ.Get(ǹ,ǽ).ToString());
Echo("1");}else if(ȁ){ǻ.ȃ=Ȃ.ȃ;Echo("2");}else{ǻ.ȃ=Ȅ;Echo("3");}ǽ="Pdcs";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȅ=(Ȇ)Enum.Parse(typeof(Ȇ),ǌ.
Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȅ=Ȃ.ȅ;else ǻ.ȅ=ȇ;ǽ="Kinetics";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȉ=(ȉ)Enum.Parse(typeof(ȉ),ǌ.Get(ǹ,ǽ)
.ToString());else if(ȁ)ǻ.Ȉ=Ȃ.Ȉ;else ǻ.Ȉ=Ȋ;ǽ="MainThrust";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȋ=(Ȍ)Enum.Parse(typeof(Ȍ),ǌ.Get(ǹ,ǽ).
ToString());else if(ȁ)ǻ.ȋ=Ȃ.ȋ;else ǻ.ȋ=ȍ;ǽ="ManeuveringThrust";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȏ=(ȏ)Enum.Parse(typeof(ȏ),ǌ.Get(ǹ,ǽ).
ToString());else if(ȁ)ǻ.Ȏ=Ȃ.Ȏ;else ǻ.Ȏ=Ȑ;ǽ="Spotlights";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȑ=(Ȓ)Enum.Parse(typeof(Ȓ),ǌ.Get(ǹ,ǽ).ToString())
;else if(ȁ)ǻ.ȑ=Ȃ.ȑ;else ǻ.ȑ=ȓ;ǽ="ExteriorLights";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȕ=(ȕ)Enum.Parse(typeof(ȕ),ǌ.Get(ǹ,ǽ).ToString())
;else if(ȁ)ǻ.Ȕ=Ȃ.Ȕ;else ǻ.Ȕ=Ȗ;ǽ="ExteriorLightColour";if(ǌ.ContainsKey(ǹ,ǽ)){Ǽ=ǌ.Get(ǹ,ǽ).ToString();Ǿ=Ǽ.Split(',');ǿ=int
.Parse(Ǿ[0]);Ȁ=int.Parse(Ǿ[1]);Ŝ=int.Parse(Ǿ[2]);Ŀ=int.Parse(Ǿ[3]);ǻ.ȗ=new Color(ǿ,Ȁ,Ŝ,Ŀ);}else if(ȁ)ǻ.ȗ=Ȃ.ȗ;else ǻ.ȗ=Ș;ǽ
="InteriorLights";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ș=(ȕ)Enum.Parse(typeof(ȕ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ș=Ȃ.ș;else ǻ.ș=Ț;ǽ
="InteriorLightColour";if(ǌ.ContainsKey(ǹ,ǽ)){Ǽ=ǌ.Get(ǹ,ǽ).ToString();Ǿ=Ǽ.Split(',');ǿ=int.Parse(Ǿ[0]);Ȁ=int.Parse(Ǿ[1]);
Ŝ=int.Parse(Ǿ[2]);Ŀ=int.Parse(Ǿ[3]);ǻ.ț=new Color(ǿ,Ȁ,Ŝ,Ŀ);}else if(ȁ)ǻ.ț=Ȃ.ț;else ǻ.ț=Ȝ;ǽ="NavLights";if(ǌ.ContainsKey(ǹ
,ǽ))ǻ.ȝ=(ȕ)Enum.Parse(typeof(ȕ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȝ=Ȃ.ȝ;else ǻ.ȝ=Ȟ;ǽ="LcdTextColour";if(ǌ.ContainsKey(ǹ,
ǽ)){Ǽ=ǌ.Get(ǹ,ǽ).ToString();Ǿ=Ǽ.Split(',');ǿ=int.Parse(Ǿ[0]);Ȁ=int.Parse(Ǿ[1]);Ŝ=int.Parse(Ǿ[2]);Ŀ=int.Parse(Ǿ[3]);ǻ.ȟ=
new Color(ǿ,Ȁ,Ŝ,Ŀ);}else if(ȁ)ǻ.ȟ=Ȃ.ȟ;else ǻ.ȟ=Ƞ;ǽ="TanksAndBatteries";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ü=(ȡ)Enum.Parse(typeof(ȡ),ǌ.
Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ü=Ȃ.Ü;else ǻ.Ü=Ȣ;ǽ="NavOsEfcBurnPercentage";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȣ=ǌ.Get(ǹ,
"NavOsEfcBurnPercentage").ToInt32(Ȥ);else if(ȁ)ǻ.ȣ=Ȃ.ȣ;else ǻ.ȣ=Ȥ;ǽ="EfcBoost";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȥ=(Ð)Enum.Parse(typeof(Ð),ǌ.Get(ǹ,ǽ).
ToString());else if(ȁ)ǻ.ȥ=Ȃ.ȥ;else ǻ.ȥ=Ȧ;ǽ="NavOsAbortEfcOff";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȧ=(Ȩ)Enum.Parse(typeof(Ȩ),ǌ.Get(ǹ,ǽ).
ToString());else if(ȁ)ǻ.ȧ=Ȃ.ȧ;else ǻ.ȧ=ȩ;ǽ="NavOsAbortEfcOff";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȧ=(Ȩ)Enum.Parse(typeof(Ȩ),ǌ.Get(ǹ,ǽ).
ToString());else if(ȁ)ǻ.ȧ=Ȃ.ȧ;else ǻ.ȧ=ȩ;ǽ="AuxMode";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȫ=(Ð)Enum.Parse(typeof(Ð),ǌ.Get(ǹ,ǽ).ToString());
else if(ȁ)ǻ.Ȫ=Ȃ.Ȫ;else ǻ.Ȫ=ȫ;ǽ="Extractor";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȭ=(ȭ)Enum.Parse(typeof(ȭ),ǌ.Get(ǹ,ǽ).ToString());else if(
ȁ)ǻ.Ȭ=Ȃ.Ȭ;else ǻ.Ȭ=Ȯ;ǽ="KeepAlives";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ï=(Ð)Enum.Parse(typeof(Ð),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.
Ï=Ȃ.Ï;else ǻ.Ï=ȯ;ǽ="HangarDoors";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȱ=(ȱ)Enum.Parse(typeof(ȱ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ȱ=Ȃ
.Ȱ;else ǻ.Ȱ=Ȳ;Ƿ.Add(Ǻ,ǻ);}catch(Exception Ė){ǵ(Ė,"Failed to parse stance\n"+Ǻ+"\nproperty\n"+ǽ);}}}if(Ƿ.Count<1){Echo(
"Failed to parse any stances!\nStances reset to default!");Ǟ=false;}else{Echo("Finished parsing "+Ƿ.Count+" stances.");ȳ=Ƿ;}Ʀ="RSM.Stance";Echo(Ʀ);ę=ǌ.Get(Ʀ,"CurrentStance").
ToString(ę);Ƕ ȴ;if(!ȳ.TryGetValue(ę,out ȴ)){ę="N/A";Î=null;}else Î=ȴ;return Ǟ;}void Ɂ(){ǌ.Clear();string Ʀ,Ƹ;Ʀ="RSM.Main";Ƹ=
"RequireShipName";ǌ.Set(Ʀ,Ƹ,ş);ǌ.SetComment(Ʀ,Ƹ,"limit to blocks with the ship name in their name");Ƹ="EnableAutoload";ǌ.Set(Ʀ,Ƹ,ħ);ǌ.
SetComment(Ʀ,Ƹ,"enable RSM loading & balancing functionality for weapons");Ƹ="AutoloadReactors";ǌ.Set(Ʀ,Ƹ,Ǎ);ǌ.SetComment(Ʀ,Ƹ,
"enable loading and balancing for reactors");Ƹ="AutoConfigWeapons";ǌ.Set(Ʀ,Ƹ,ǎ);ǌ.SetComment(Ʀ,Ƹ,"automatically configure weapon on stance set");Ƹ=
"SetTurretFireMode";ǌ.Set(Ʀ,Ƹ,Ǐ);ǌ.SetComment(Ʀ,Ƹ,"set turret fire mode based on stance");ǌ.SetSectionComment(Ʀ,ȶ+
" Reedit Ship Management\n"+ȶ+" Config.ini\n Recompile to apply changes!\n"+ȶ);Ʀ="RSM.Spawns";Ƹ="PrivateSpawns";ǌ.Set(Ʀ,Ƹ,ǐ);ǌ.SetComment(Ʀ,Ƹ,
"don't inject faction tag into spawn custom data");Ƹ="FriendlyTags";ǌ.Set(Ʀ,Ƹ,Ǒ);ǌ.SetComment(Ʀ,Ƹ,"Comma seperated friendly factions or steam ids");Ʀ="RSM.Doors";Ƹ=
"EnableDoorManagement";ǌ.Set(Ʀ,Ƹ,ǒ);ǌ.SetComment(Ʀ,Ƹ,"enable door management functionality");Ƹ="DoorCloseTimer";ǌ.Set(Ʀ,Ƹ,Ǔ);ǌ.SetComment(Ʀ,Ƹ,
"door open timer (x100 ticks)");Ƹ="AirlockDoorDisableTimer";ǌ.Set(Ʀ,Ƹ,ǔ);ǌ.SetComment(Ʀ,Ƹ,"airlock door disable timer (x100 ticks)");Ʀ="RSM.Keywords";
Ƹ="Ignore";ǌ.Set(Ʀ,Ƹ,Ş);ǌ.SetComment(Ʀ,Ƹ,"to identify blocks which RSM should ignore");Ƹ="RsmLcds";ǌ.Set(Ʀ,Ƹ,ţ);ǌ.
SetComment(Ʀ,Ƹ,"to identify RSM lcds");Ƹ="ColourSyncLcds";ǌ.Set(Ʀ,Ƹ,ŧ);ǌ.SetComment(Ʀ,Ƹ,"to identify non RSM lcds for colour sync"
);Ƹ="AuxiliaryBlocks";ǌ.Set(Ʀ,Ƹ,š);ǌ.SetComment(Ʀ,Ƹ,"to identify aux blocks");Ƹ="DefensivePdcs";ǌ.Set(Ʀ,Ƹ,Ɯ);ǌ.SetComment
(Ʀ,Ƹ,"to identify defensive _normalPdcs");Ƹ="MinimumThrusters";ǌ.Set(Ʀ,Ƹ,Ǖ);ǌ.SetComment(Ʀ,Ƹ,
"to identify minimum epsteins");Ƹ="DockingThrusters";ǌ.Set(Ʀ,Ƹ,ǖ);ǌ.SetComment(Ʀ,Ƹ,"to identify docking epsteins");Ƹ="NavLights";ǌ.Set(Ʀ,Ƹ,Ÿ);ǌ.
SetComment(Ʀ,Ƹ,"to identify navigational lights");Ƹ="Airlock";ǌ.Set(Ʀ,Ƹ,ſ);ǌ.SetComment(Ʀ,Ƹ,"to identify airlock doors and vents")
;Ʀ="RSM.InitNaming";Ƹ="NameDelimiter";ǌ.Set(Ʀ,Ƹ,'"'+Ů.ToString()+'"');ǌ.SetComment(Ʀ,Ƹ,"single char delimiter for names")
;Ƹ="NameWeaponTypes";ǌ.Set(Ʀ,Ƹ,Ɲ);ǌ.SetComment(Ʀ,Ƹ,"append type names to all weapons on init");Ƹ="NameDriveTypes";ǌ.Set(Ʀ
,Ƹ,ŭ);ǌ.SetComment(Ʀ,Ƹ,"append type names to all drives on init");string ȷ="";foreach(string ȸ in Ǚ){if(ȷ!="")ȷ+=",";ȷ+=ȸ
;}Ƹ="BlocksToNumber";ǌ.Set(Ʀ,Ƹ,ŭ);ǌ.SetComment(Ʀ,Ƹ,"comma seperated list of block names to be numbered at init");Ʀ=
"RSM.Misc";Ƹ="DisableLightingControl";ǌ.Set(Ʀ,Ƹ,ǚ);ǌ.SetComment(Ʀ,Ƹ,"disable all lighting control");Ƹ="DisableLcdColourControl";ǌ.
Set(Ʀ,Ƹ,Ŧ);ǌ.SetComment(Ʀ,Ƹ,"disable text colour control for all lcds");Ƹ="ShowBasicTelemetry";ǌ.Set(Ʀ,Ƹ,Ǜ);ǌ.SetComment(Ʀ,
Ƹ,"show basic telemetry data on advanced thrust lcds");string ȹ="";foreach(double Ⱥ in h){if(ȹ!="")ȹ+=",";ȹ+=(Ⱥ*100).
ToString();}Ƹ="DecelerationPercentages";ǌ.Set(Ʀ,Ƹ,ȹ);ǌ.SetComment(Ʀ,Ƹ,"thrust percentages to show on advanced thrust lcds");Ƹ=
"ShowThrustInMetric";ǌ.Set(Ʀ,Ƹ,ǜ);ǌ.SetComment(Ʀ,Ƹ,"show basic telemetry data on advanced thrust lcds");Ƹ="ReactorFillRatio";ǌ.Set(Ʀ,Ƹ,ǝ);ǌ.
SetComment(Ʀ,Ƹ,"0-1, fill ratio for reactors");Ʀ="RSM.Debug";Ƹ="VerboseDebugging";ǌ.Set(Ʀ,Ƹ,n);ǌ.SetComment(Ʀ,Ƹ,
"prints more logging info to PB details");Ƹ="RuntimeProfiling";ǌ.Set(Ʀ,Ƹ,Ç);ǌ.SetComment(Ʀ,Ƹ,"prints script runtime profiling info to PB details");Ƹ=
"BlockRefreshFreq";ǌ.Set(Ʀ,Ƹ,f);ǌ.SetComment(Ʀ,Ƹ,"ticks x100 between block refreshes");Ƹ="StallCount";ǌ.Set(Ʀ,Ƹ,È);ǌ.SetComment(Ʀ,Ƹ,
"ticks x100 to stall between runs");Ʀ="RSM.Stance";Ƹ="CurrentStance";ǌ.Set(Ʀ,Ƹ,ę);ǌ.SetSectionComment(Ʀ,ȶ+" Stances\n Add or remove as required\n"+ȶ);
string Ȼ="Red, Green, Blue, Alpha";foreach(var ȼ in ȳ){Ʀ="RSM.Stance."+ȼ.Key;Ƕ Ƚ=ȼ.Value;Ƕ Ȃ=null;if(Ƚ.Ⱦ!=""){Ȃ=ȳ[Ƚ.Ⱦ];Ƹ=
"Inherits";ǌ.Set(Ʀ,Ƹ,Ƚ.Ⱦ);ǌ.SetComment(Ʀ,Ƹ,"Use stance of this name as a template for settings");}Ƹ="Torps";if(Ȃ!=null&&Ƚ.ȃ==Ȃ.ȃ){
if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ȃ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(Ð)));}Ƹ="Pdcs";if(Ȃ!=null&&Ƚ
.ȅ==Ȃ.ȅ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ȅ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(Ȇ)));}Ƹ="Kinetics"
;if(Ȃ!=null&&Ƚ.Ȉ==Ȃ.Ȉ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.Ȉ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(ȉ)))
;}Ƹ="MainThrust";if(Ȃ!=null&&Ƚ.ȋ==Ȃ.ȋ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ȋ.ToString());ǌ.SetComment(Ʀ
,"MainThrust",ȿ(typeof(Ȍ)));}Ƹ="ManeuveringThrust";if(Ȃ!=null&&Ƚ.Ȏ==Ȃ.Ȏ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(
Ʀ,Ƹ,Ƚ.Ȏ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(ȏ)));}Ƹ="Spotlights";if(Ȃ!=null&&Ƚ.ȑ==Ȃ.ȑ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ
,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ȑ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(Ȓ)));}Ƹ="ExteriorLights";if(Ȃ!=null&&Ƚ.Ȕ==Ȃ.Ȕ){if(ǌ.
ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.Ȕ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(ȕ)));}Ƹ="ExteriorLightColour";if(Ȃ!=null&&
Ƚ.ȗ==Ȃ.ȗ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,ɀ(Ƚ.ȗ));ǌ.SetComment(Ʀ,Ƹ,Ȼ);}Ƹ="InteriorLights";if(Ȃ!=null
&&Ƚ.ș==Ȃ.ș){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ș.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(ȕ)));}Ƹ=
"InteriorLightColour";if(Ȃ!=null&&Ƚ.ț==Ȃ.ț){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,ɀ(Ƚ.ț));ǌ.SetComment(Ʀ,Ƹ,Ȼ);}Ƹ="NavLights";if
(Ȃ!=null&&Ƚ.ȝ==Ȃ.ȝ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ȝ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(ȕ)));}Ƹ
="LcdTextColour";if(Ȃ!=null&&Ƚ.ȟ==Ȃ.ȟ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,ɀ(Ƚ.ȟ));ǌ.SetComment(Ʀ,Ƹ,Ȼ);}Ƹ
="TanksAndBatteries";if(Ȃ!=null&&Ƚ.Ü==Ȃ.Ü){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.Ü.ToString());ǌ.
SetComment(Ʀ,Ƹ,ȿ(typeof(ȡ)));}Ƹ="NavOsEfcBurnPercentage";if(Ȃ!=null&&Ƚ.ȣ==Ȃ.ȣ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ
,Ƚ.ȣ.ToString());ǌ.SetComment(Ʀ,Ƹ,"Burn % 0-100, -1 for no change");}Ƹ="EfcBoost";if(Ȃ!=null&&Ƚ.ȥ==Ȃ.ȥ){if(ǌ.ContainsKey(
Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ȥ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(Ð)));}Ƹ="NavOsAbortEfcOff";if(Ȃ!=null&&Ƚ.ȧ==
Ȃ.ȧ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.ȧ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(Ȩ)));}Ƹ="AuxMode";if(Ȃ
!=null&&Ƚ.Ȫ==Ȃ.Ȫ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.Ȫ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(Ð)));}Ƹ=
"Extractor";if(Ȃ!=null&&Ƚ.Ȭ==Ȃ.Ȭ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.Ȭ.ToString());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(ȭ))
);}Ƹ="KeepAlives";if(Ȃ!=null&&Ƚ.Ï==Ȃ.Ï){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.Ï.ToString());ǌ.SetComment(
Ʀ,Ƹ,ȿ(typeof(Ð)));}Ƹ="HangarDoors";if(Ȃ!=null&&Ƚ.Ȱ==Ȃ.Ȱ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ƚ.Ȱ.ToString
());ǌ.SetComment(Ʀ,Ƹ,ȿ(typeof(ȱ)));}}Ʀ="RSM.System";Ƹ="ShipName";ǌ.Set(Ʀ,Ƹ,Ę);ǌ.SetSectionComment(Ʀ,ȶ+
" System\n All items below this point are\n set automatically when running init\n"+ȶ);Ʀ="RSM.InitItems";foreach(Ĩ Ǩ in ĩ){Ƹ=Ǩ.Ł.SubtypeId;ǌ.Set(Ʀ,Ƹ,Ǩ.ǩ);}Ʀ="RSM.InitSubSystems";ǌ.Set(Ʀ,"Reactors",Ǫ);ǌ.
Set(Ʀ,"Batteries",ǫ);ǌ.Set(Ʀ,"Pdcs",Ǭ);ǌ.Set(Ʀ,"TorpLaunchers",ǭ);ǌ.Set(Ʀ,"KineticWeapons",Ǯ);ǌ.Set(Ʀ,"H2Storage",ǯ);ǌ.Set(
Ʀ,"O2Storage",ǰ);ǌ.Set(Ʀ,"MainThrust",Ǳ);ǌ.Set(Ʀ,"RCSThrust",ǲ);ǌ.Set(Ʀ,"Gyros",ǳ);ǌ.Set(Ʀ,"CargoStorage",Ǉ);ǌ.Set(Ʀ,
"Welders",Ǵ);Me.CustomData=ǌ.ToString();}void Ǡ(string ƥ){string[]Ǹ=ƥ.Split(new string[]{"[Stances]"},StringSplitOptions.None);
string[]ɂ=Ǹ[0].Split('\n');string Ƀ=Ǹ[1];try{for(int Ʉ=1;Ʉ<ɂ.Length;Ʉ++){if(ɂ[Ʉ].Contains("=")){string Ʌ=ɂ[Ʉ].Substring(1);
switch(ɂ[(Ʉ-1)]){case"Ship name. Blocks without this name will be ignored":Ę=Ʌ;break;case
"Block name delimiter, used by init. One character only!":Ů=char.Parse(Ʌ.Substring(0,1));break;case"Keyword used to identify RSM _allLcds.":ţ=Ʌ;break;case
"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":š=Ʌ;break;case"Keyword used to identify defence _normalPdcs.":Ɯ=Ʌ;break
;case"Keyword used to identify minimum epstein drives.":Ǖ=Ʌ;break;case"Keyword used to identify docking epstein drives.":
ǖ=Ʌ;break;case"Keyword to ignore block.":Ş=Ʌ;break;case"Automatically configure _normalPdcs, Railguns, Torpedoes.":ǎ=bool
.Parse(Ʌ);break;case"Disable lighting all control.":ǚ=bool.Parse(Ʌ);break;case"Disable LCD Text Colour Enforcement.":Ŧ=
bool.Parse(Ʌ);break;case"Enable Weapon Autoload Functionality.":ħ=bool.Parse(Ʌ);break;case"Number these blocks at init.":Ǚ.
Clear();string[]Ɇ=Ʌ.Split(',');foreach(string ȸ in Ɇ){if(ȸ!="")Ǚ.Add(ȸ);}break;case"Show basic telemetry.":Ǜ=bool.Parse(Ʌ);
break;case"Show Decel Percentages (comma seperated).":h.Clear();string[]ɇ=Ʌ.Split(',');foreach(string Ⱥ in ɇ){h.Add(double.
Parse(Ⱥ)/100);}break;case"Fusion Fuel count":ĩ[0].ǩ=int.Parse(Ʌ);break;case"Fuel tank count":ĩ[1].ǩ=int.Parse(Ʌ);break;case
"Jerry can count":ĩ[2].ǩ=int.Parse(Ʌ);break;case"40mm PDC Magazine count":ĩ[3].ǩ=int.Parse(Ʌ);break;case
"40mm Teflon Tungsten PDC Magazine count":ĩ[4].ǩ=int.Parse(Ʌ);break;case"220mm Torpedo count":case"Torpedo count":ĩ[5].ǩ=int.Parse(Ʌ);break;case
"220mm MCRN torpedo count":ĩ[6].ǩ=int.Parse(Ʌ);break;case"220mm UNN torpedo count":ĩ[7].ǩ=int.Parse(Ʌ);break;case"Ramshackle torpedo count":case
"Ramshackle torpedo Count":ĩ[8].ǩ=int.Parse(Ʌ);break;case"Large ramshacke torpedo count":ĩ[9].ǩ=int.Parse(Ʌ);break;case
"Zako 120mm Railgun rounds count":case"Railgun rounds count":ĩ[10].ǩ=int.Parse(Ʌ);break;case"Dawson 100mm UNN Railgun rounds count":ĩ[11].ǩ=int.Parse(Ʌ);
break;case"Stiletto 100mm MCRN Railgun rounds count":ĩ[12].ǩ=int.Parse(Ʌ);break;case"T-47 80mm Railgun rounds count":ĩ[13].ǩ=
int.Parse(Ʌ);break;case"Foehammer 120mm MCRN rounds count":ĩ[14].ǩ=int.Parse(Ʌ);break;case
"Farren 120mm UNN Railgun rounds count":ĩ[15].ǩ=int.Parse(Ʌ);break;case"Kess 180mm rounds count":ĩ[16].ǩ=int.Parse(Ʌ);break;case"Steel plate count":ĩ[17].ǩ=int
.Parse(Ʌ);break;case"Doors open timer (x100 ticks, default 3)":Ǔ=int.Parse(Ʌ);break;case
"Airlock doors disabled timer (x100 ticks, default 6)":ǔ=int.Parse(Ʌ);break;case"Throttle script (x100 ticks pause between loops, default 0)":È=int.Parse(Ʌ);break;case
"Full refresh frequency (x100 ticks, default 50)":f=int.Parse(Ʌ);break;case"Verbose script debugging. Prints more logging info to PB details.":n=bool.Parse(Ʌ);break;case
"Private spawn (don't inject faction tag into SK custom data).":ǐ=bool.Parse(Ʌ);break;case"Comma seperated friendly factions or steam ids for survival kits.":Ǒ=string.Join("\n",Ʌ.
Split(','));break;case"Current Stance":ę=Ʌ;Ƕ ȴ;if(!ȳ.TryGetValue(ę,out ȴ)){ę="N/A";Î=null;}else Î=ȴ;break;case
"Reactor Integrity":Ǫ=float.Parse(Ʌ);break;case"Battery Integrity":ǫ=float.Parse(Ʌ);break;case"PDC Integrity":Ǭ=int.Parse(Ʌ);break;case
"Torpedo Integrity":ǭ=int.Parse(Ʌ);break;case"Railgun Integrity":Ǯ=int.Parse(Ʌ);break;case"H2 Tank Integrity":ǯ=double.Parse(Ʌ);break;case
"O2 Tank Integrity":ǰ=double.Parse(Ʌ);break;case"Epstein Integrity":Ǳ=float.Parse(Ʌ);break;case"RCS Integrity":ǲ=float.Parse(Ʌ);break;case
"Gyro Integrity":ǳ=int.Parse(Ʌ);break;case"Cargo Integrity":Ǉ=double.Parse(Ʌ);break;case"Welder Integrity":Ǵ=int.Parse(Ʌ);break;}}}}
catch(Exception Ė){Echo("Custom Data Error (vars)\n"+Ė.Message);}try{string[]Ɉ=Ƀ.Split(new string[]{"Stance:"},
StringSplitOptions.None);if(n)Echo("Parsing "+(Ɉ.Length-1)+" stances");int ɉ=24;Dictionary<string,Ƕ>Ƿ=new Dictionary<string,Ƕ>();int[]Ɋ=
new int[]{0,5,25,50,75,100};for(int Ʉ=1;Ʉ<Ɉ.Length;Ʉ++){string[]ɋ=Ɉ[Ʉ].Split('=');string Ǻ="";int[]Ɍ=new int[ɉ];Ǻ=ɋ[0].
Split(' ')[0];if(n)Echo("Parsing '"+Ǻ+"'");for(int ɍ=0;ɍ<Ɍ.Length;ɍ++){string[]Ɏ=ɋ[(ɍ+1)].Split('\n');Ɍ[ɍ]=int.Parse(Ɏ[0]);}Ƕ
ǻ=new Ƕ();if(Ɍ[0]==0)ǻ.ȃ=Ð.Off;else ǻ.ȃ=Ð.On;if(Ɍ[1]==0)ǻ.ȅ=Ȇ.Off;else if(Ɍ[1]==1)ǻ.ȅ=Ȇ.MinDefence;else if(Ɍ[1]==2)ǻ.ȅ=Ȇ.
AllDefence;else if(Ɍ[1]==3)ǻ.ȅ=Ȇ.Offence;else if(Ɍ[1]==4)ǻ.ȅ=Ȇ.AllOnOnly;if(Ɍ[2]==0)ǻ.Ȉ=ȉ.Off;else if(Ɍ[2]==1)ǻ.Ȉ=ȉ.HoldFire;else
if(Ɍ[2]==2)ǻ.Ȉ=ȉ.OpenFire;if(Ɍ[3]==0)ǻ.ȋ=Ȍ.Off;else if(Ɍ[3]==1)ǻ.ȋ=Ȍ.On;else if(Ɍ[3]==2)ǻ.ȋ=Ȍ.Minimum;if(Ɍ[4]==0)ǻ.Ȏ=ȏ.Off
;else if(Ɍ[4]==1)ǻ.Ȏ=ȏ.On;else if(Ɍ[4]==2)ǻ.Ȏ=ȏ.ForwardOff;else if(Ɍ[4]==3)ǻ.Ȏ=ȏ.ReverseOff;if(Ɍ[5]==0)ǻ.ȑ=Ȓ.Off;else if(
Ɍ[5]==1)ǻ.ȑ=Ȓ.On;else if(Ɍ[5]==2)ǻ.ȑ=Ȓ.OnMax;if(Ɍ[6]==0)ǻ.Ȕ=ȕ.Off;else ǻ.Ȕ=ȕ.On;ǻ.ȗ=new Color(Ɍ[7],Ɍ[8],Ɍ[9],Ɍ[10]);if(Ɍ[
11]==0)ǻ.ș=ȕ.Off;else ǻ.ș=ȕ.On;ǻ.ț=new Color(Ɍ[12],Ɍ[13],Ɍ[14],Ɍ[15]);if(Ɍ[16]==0)ǻ.Ü=ȡ.Auto;else if(Ɍ[16]==1)ǻ.Ü=ȡ.
StockpileRecharge;else if(Ɍ[16]==2)ǻ.Ü=ȡ.Discharge;if(Ɍ[17]==0)ǻ.ȥ=Ð.Off;else ǻ.ȥ=Ð.On;ǻ.ȣ=Ɋ[Ɍ[18]];if(Ɍ[19]==0)ǻ.ȧ=Ȩ.NoChange;else ǻ.ȧ=Ȩ
.Abort;if(Ɍ[20]==0)ǻ.Ȫ=Ð.Off;else ǻ.Ȫ=Ð.On;if(Ɍ[21]==0)ǻ.Ȭ=ȭ.Off;else if(Ɍ[21]==1)ǻ.Ȭ=ȭ.On;else if(Ɍ[21]==2)ǻ.Ȭ=ȭ.
FillWhenLow;else if(Ɍ[21]==3)ǻ.Ȭ=ȭ.KeepFull;if(Ɍ[22]==0)ǻ.Ï=Ð.Off;else ǻ.Ï=Ð.On;if(Ɍ[23]==0)ǻ.Ȱ=ȱ.Closed;else if(Ɍ[23]==1)ǻ.Ȱ=ȱ.
Open;else ǻ.Ȱ=ȱ.NoChange;Ƿ.Add(Ǻ,ǻ);}if(Ƿ.Count>=1){if(n)Echo("Finished parsing "+Ƿ.Count+" stances.");ȳ=Ƿ;}else{Echo(
"Didn't find any stances!");}}catch(Exception Ė){Echo("Custom Data Error (stances)\n"+Ė.Message);}}void É(){bool ɏ=ȵ();if(!ɏ){ɐ();Ɂ();}if(Î==null)
{Î=ȳ.First().Value;}string ɑ="";string ɒ="";if(!ǐ){ɑ=" ".PadRight(129,' ')+V+"\n";ɒ="\n".PadRight(19,'\n');}W=ɑ+ɒ;X=ɑ+
string.Join("\n",Ǒ.Split(','))+ɒ;if(Ę==""){if(n)Echo("No ship name, trying to pull it from PB name...");string ɓ=
"Untitled Ship";try{string[]ɔ=Me.CustomName.Split(Ů);if(ɔ.Length>1){Ę=ɔ[0];if(n)Echo(Ę);}else Ę=ɓ;}catch{Ę=ɓ;}}}void ɖ(bool v=true,bool
ɕ=false,bool s=false){MyIni ƨ=new MyIni();string ƥ=Me.CustomData;MyIniParseResult Ʃ;if(!ƨ.TryParse(ƥ,out Ʃ)){Ã.Add(new Ä(
"CONFIG ERROR!!","Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string Ʀ,Ƹ;if(v){Ʀ="RSM.Stance"
;Ƹ="CurrentStance";ƨ.Set(Ʀ,Ƹ,ę);}else{Ʀ="RSM.System";Ƹ="ShipName";ƨ.Set(Ʀ,Ƹ,Ę);}if(ɕ){Ʀ="RSM.InitSubSystems";ƨ.Set(Ʀ,
"Reactors",Ǫ);ƨ.Set(Ʀ,"Batteries",ǫ);ƨ.Set(Ʀ,"Pdcs",Ǭ);ƨ.Set(Ʀ,"TorpLaunchers",ǭ);ƨ.Set(Ʀ,"KineticWeapons",Ǯ);ƨ.Set(Ʀ,"H2Storage",
ǯ);ƨ.Set(Ʀ,"O2Storage",ǰ);ƨ.Set(Ʀ,"MainThrust",Ǳ);ƨ.Set(Ʀ,"RCSThrust",ǲ);ƨ.Set(Ʀ,"Gyros",ǳ);ƨ.Set(Ʀ,"CargoStorage",Ǉ);ƨ.
Set(Ʀ,"Welders",Ǵ);}if(s){Ʀ="RSM.InitItems";foreach(Ĩ Ǩ in ĩ){Ƹ=Ǩ.Ł.SubtypeId;ƨ.Set(Ʀ,Ƹ,Ǩ.ǩ);}}Me.CustomData=ƨ.ToString();}
string ȿ(Type ɗ){string ɘ="";foreach(var ə in Enum.GetValues(ɗ)){if(ɘ!="")ɘ+=", ";ɘ+=ə.ToString();}return ɘ;}string ɀ(Color ɚ)
{return ɚ.R+", "+ɚ.G+", "+ɚ.B+", "+ɚ.A;}void ǵ(Exception Ė,string ɛ){Runtime.UpdateFrequency=UpdateFrequency.None;string
ɜ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ɛ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ɜ);List<IMyTextPanel>ɝ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ɝ,Ŝ=>Ŝ.CustomName
.Contains(ţ));foreach(IMyTextPanel ɞ in ɝ){ɞ.WriteText(ɜ);ɞ.FontColor=new Color(193,0,197,255);}throw Ė;}Dictionary<
string,Ƕ>ȳ=new Dictionary<string,Ƕ>();void ɐ(){ȳ=new Dictionary<string,Ƕ>{{"Cruise",new Ƕ{ȃ=Ð.On,ȅ=Ȇ.AllDefence,Ȉ=ȉ.HoldFire,ȋ
=Ȍ.EpsteinOnly,Ȏ=ȏ.ForwardOff,ȑ=Ȓ.Off,Ȕ=ȕ.On,ȗ=new Color(33,144,255,255),ș=ȕ.On,ț=new Color(255,214,170,255),ȝ=ȕ.On,ȟ=new
Color(33,144,255,255),Ü=ȡ.Auto,ȣ=50,ȥ=Ð.NoChange,ȧ=Ȩ.Abort,Ȫ=Ð.NoChange,Ȭ=ȭ.KeepFull,Ï=Ð.On,Ȱ=ȱ.NoChange,}},{"StealthCruise",
new Ƕ{Ⱦ="Cruise",ȃ=Ð.On,ȅ=Ȇ.AllDefence,Ȉ=ȉ.HoldFire,ȋ=Ȍ.Minimum,Ȏ=ȏ.ForwardOff,ȑ=Ȓ.Off,Ȕ=ȕ.Off,ȗ=new Color(0,0,0,255),ș=ȕ.
On,ț=new Color(23,73,186,255),ȝ=ȕ.Off,ȟ=new Color(23,73,186,255),Ü=ȡ.Auto,ȣ=5,ȥ=Ð.Off,ȧ=Ȩ.Abort,Ȫ=Ð.NoChange,Ȭ=ȭ.KeepFull,
Ï=Ð.On,Ȱ=ȱ.NoChange}},{"Docked",new Ƕ{Ⱦ="Cruise",ȃ=Ð.On,ȅ=Ȇ.AllDefence,Ȉ=ȉ.HoldFire,ȋ=Ȍ.Off,Ȏ=ȏ.Off,ȑ=Ȓ.Off,Ȕ=ȕ.On,ȗ=new
Color(33,144,255,255),ș=ȕ.On,ț=new Color(255,240,225,255),ȝ=ȕ.On,ȟ=new Color(255,255,255,255),Ü=ȡ.StockpileRecharge,ȣ=-1,ȥ=Ð.
NoChange,ȧ=Ȩ.Abort,Ȫ=Ð.Off,Ȭ=ȭ.On,Ï=Ð.On,Ȱ=ȱ.NoChange}},{"Docking",new Ƕ{Ⱦ="Docked",ȃ=Ð.On,ȅ=Ȇ.AllDefence,Ȉ=ȉ.HoldFire,ȋ=Ȍ.Off,Ȏ
=ȏ.On,ȑ=Ȓ.OnMax,Ȕ=ȕ.On,ȗ=new Color(33,144,255,255),ș=ȕ.On,ț=new Color(212,170,83,255),ȝ=ȕ.On,ȟ=new Color(212,170,83,255),
Ü=ȡ.Auto,ȣ=-1,ȥ=Ð.NoChange,ȧ=Ȩ.Abort,Ȫ=Ð.Off,Ȭ=ȭ.KeepFull,Ï=Ð.On,Ȱ=ȱ.NoChange}},{"NoAttack",new Ƕ{Ⱦ="Docked",ȃ=Ð.Off,ȅ=Ȇ.
Off,Ȉ=ȉ.Off,ȋ=Ȍ.On,Ȏ=ȏ.On,ȑ=Ȓ.Off,Ȕ=ȕ.On,ȗ=new Color(255,255,255,255),ș=ȕ.On,ț=new Color(84,157,82,255),ȝ=ȕ.NoChange,ȟ=new
Color(84,157,82,255),Ü=ȡ.NoChange,ȣ=-1,ȥ=Ð.NoChange,ȧ=Ȩ.NoChange,Ȫ=Ð.NoChange,Ȭ=ȭ.KeepFull,Ï=Ð.On,Ȱ=ȱ.NoChange}},{"Combat",
new Ƕ{Ⱦ="Cruise",ȃ=Ð.On,ȅ=Ȇ.AllDefence,Ȉ=ȉ.OpenFire,ȋ=Ȍ.On,Ȏ=ȏ.On,ȑ=Ȓ.Off,Ȕ=ȕ.Off,ȗ=new Color(0,0,0,255),ș=ȕ.On,ț=new Color
(210,98,17,255),ȝ=ȕ.Off,ȟ=new Color(210,98,17,255),Ü=ȡ.ManagedDischarge,ȣ=100,ȥ=Ð.On,ȧ=Ȩ.Abort,Ȫ=Ð.On,Ȭ=ȭ.KeepFull,Ï=Ð.On
,Ȱ=ȱ.NoChange}},{"CQB",new Ƕ{Ⱦ="Combat",ȃ=Ð.On,ȅ=Ȇ.Offence,Ȉ=ȉ.OpenFire,ȋ=Ȍ.On,Ȏ=ȏ.On,ȑ=Ȓ.Off,Ȕ=ȕ.Off,ȗ=new Color(0,0,0,
255),ș=ȕ.On,ț=new Color(243,18,18,255),ȝ=ȕ.Off,ȟ=new Color(243,18,18,255),Ü=ȡ.ManagedDischarge,ȣ=100,ȥ=Ð.On,ȧ=Ȩ.Abort,Ȫ=Ð.
On,Ȭ=ȭ.KeepFull,Ï=Ð.On,Ȱ=ȱ.NoChange}},{"WeaponsHot",new Ƕ{Ⱦ="CQB",ȃ=Ð.On,ȅ=Ȇ.Offence,Ȉ=ȉ.OpenFire,ȋ=Ȍ.NoChange,Ȏ=ȏ.
NoChange,ȑ=Ȓ.NoChange,Ȕ=ȕ.NoChange,ȗ=new Color(0,0,0,255),ș=ȕ.NoChange,ț=new Color(243,18,18,255),ȝ=ȕ.NoChange,ȟ=new Color(243,
18,18,255),Ü=ȡ.ManagedDischarge,ȣ=-1,ȥ=Ð.NoChange,ȧ=Ȩ.NoChange,Ȫ=Ð.NoChange,Ȭ=ȭ.KeepFull,Ï=Ð.On,Ȱ=ȱ.NoChange}}};}class ř{
public IMyDoor Ħ;public int ɟ=0;public int ɠ=0;public bool Ɓ=false;public bool ɡ=false;}class Ś{public string Ƅ;public bool ɢ=
false;public int ɣ=0;public bool ɤ=false;public List<ř>ƅ=new List<ř>();public List<IMyAirVent>ƈ=new List<IMyAirVent>();}int ɥ
=0;int ɦ=0;int ɧ=0;int ɮ(ř ɨ,bool ƃ=false){bool ɩ=false;bool ɪ=false;if(ɨ.Ħ==null)return 0;bool ɫ=ɨ.Ħ.OpenRatio>0;ɥ++;if(
ɬ(ɨ.Ħ))ɧ++;if(!ƃ||ɫ)ɨ.Ħ.Enabled=true;if(ɫ){if(ɨ.ɟ==0){ɪ=true;}ɨ.ɟ++;if(ɨ.ɟ>=Ǔ){ɨ.ɟ=0;ɨ.Ħ.CloseDoor();ɩ=true;}}else{ɦ++;if
(ɨ.ɟ!=0){ɩ=true;ɨ.ɟ=0;}}int ɭ=0;if(ɩ)ɭ=1;else if(ɪ)ɭ=2;return ɭ;}void å(){if(!ǒ){if(n)Echo("Door management is disabled."
);return;}foreach(Ś ƃ in ä){bool ɯ=false;foreach(ř ɨ in ƃ.ƅ){if(ɨ.Ħ==null)continue;int ɰ=ɮ(ɨ,true);if(ɰ==1){if(n)Echo(
"Airlock door "+ɨ.Ħ.CustomName+" just closed");if(ƃ.ɤ)ƃ.ɤ=false;else{ƃ.ɢ=true;ɨ.ɡ=true;if(n)Echo("Airlock "+ƃ.Ƅ+" needs to cycle");}}
else if(ɰ==2){if(n)Echo("Airlock door "+ɨ.Ħ.CustomName+" just opened");ɯ=true;}}bool ɱ=true;if(ƃ.ɢ){foreach(ř ɨ in ƃ.ƅ){if(ɨ
.Ħ==null)continue;if(ɨ.Ħ.OpenRatio>0){ɨ.Ħ.CloseDoor();ɱ=false;}else ɨ.Ħ.Enabled=false;}bool ɲ=false;foreach(IMyAirVent ɳ
in ƃ.ƈ){if(ɳ==null)continue;if(!ɳ.Enabled)ɳ.Enabled=true;if(!ɳ.Depressurize)ɳ.Depressurize=true;if(ɳ.CanPressurize&&ɳ.
GetOxygenLevel()<.01&&ƃ.ɢ&&ɱ)ɲ=true;}ƃ.ɣ++;bool ɴ=true;if(ƃ.ɣ>=ǔ){ɴ=false;ɲ=true;}if(ɲ){ƃ.ɢ=false;ƃ.ɣ=0;ƃ.ɤ=true;foreach(ř ɨ in ƃ.ƅ){
if(ɨ.Ħ==null)continue;ɨ.Ħ.Enabled=true;if(ɨ.ɡ)ɨ.ɡ=false;else if(ɴ)ɨ.Ħ.OpenDoor();}}}else if(ɯ){foreach(ř ɨ in ƃ.ƅ){if(ɨ.Ħ
==null)continue;if(ɨ.Ħ.OpenRatio==0)ɨ.Ħ.Enabled=false;}}else{foreach(ř ɨ in ƃ.ƅ){ɨ.Ħ.Enabled=true;}}}}void ã(){if(!ǒ){if(n
)Echo("Door management is disabled.");return;}ɥ=0;ɦ=0;ɧ=0;foreach(ř ɨ in â)ɮ(ɨ);}void ɶ(ȱ ń){if(ń==ȱ.NoChange)return;
foreach(IMyAirtightHangarDoor ɵ in Ŋ){if(ɵ==null)continue;if(ń==ȱ.Closed)ɵ.CloseDoor();else ɵ.OpenDoor();}}void z(string ɷ,
string ɸ){ɷ=ɷ.ToLower();foreach(ř ɨ in â){if(ɸ==""||ɨ.Ħ.CustomName.Contains(ɸ)){bool ɹ=ɬ(ɨ.Ħ);if(ɹ&&(ɷ=="locked"||ɷ=="toggle")
)ɨ.Ħ.ApplyAction("AnyoneCanUse");if(!ɹ&&(ɷ=="unlocked"||ɷ=="toggle"))ɨ.Ħ.ApplyAction("AnyoneCanUse");}}}bool ɬ(IMyDoor ɨ)
{var ņ=ɨ.GetActionWithName("AnyoneCanUse");StringBuilder ɺ=new StringBuilder();ņ.WriteValue(ɨ,ɺ);return(ɺ.ToString()==
"On");}double ɻ;int ɼ=10;double ɽ=3;double ɾ=245000;double ɿ=50000;double ʀ=100;void ʂ(ȭ ń){foreach(IMyTerminalBlock ʁ in ŋ)
{if(ʁ==null)continue;if(ń==ȭ.Off)ʁ.ApplyAction("OnOff_Off");else ʁ.ApplyAction("OnOff_On");}}void Đ(){if(ŋ.Count<1&&Ō.
Count>0)ɻ=(ɽ*ɿ);else ɻ=(ɽ*ɾ);}void í(){if(Î.Ȭ==ȭ.Off||Î.Ȭ==ȭ.On){if(n)Echo("Extractor management disabled.");}else if(ë.Count
<1){if(n)Echo("No tanks!");}else if(Î.Ȭ==ȭ.FillWhenLow&&ʀ<ɼ){M=true;if(n)Echo("Fuel low! ("+ʀ+"% / "+ɼ+"%)");}else if(Î.Ȭ
==ȭ.KeepFull&&ʃ<(ʄ-ɻ)){M=true;if(n)Echo("Fuel ready for top up ("+ʃ+" < "+(ʄ-ɻ)+")");}else if(n){Echo("Fuel level OK ("+ʀ+
"%).");if(Î.Ȭ==ȭ.KeepFull)Echo("Keeping tanks full\n("+ʃ+" < "+(ʄ-ɻ)+")");}}void î(){M=false;IMyTerminalBlock ʅ=null;int Ĩ=1;
foreach(IMyTerminalBlock ʁ in ŋ){if(ʁ.IsFunctional){ʅ=ʁ;break;}}if(ʅ==null||ĩ[Ĩ].ʆ<1){Ĩ=2;foreach(IMyTerminalBlock ʁ in Ō){if(ʁ
.IsFunctional){ʅ=ʁ;Ĩ=2;if(ĩ[Ĩ].ʆ<1)break;}}if(ʅ==null){P=true;return;}}P=false;if(ĩ[Ĩ].ʆ<1){Q=ĩ[Ĩ].Ĭ;return;}Q="";ĭ ĺ=new
ĭ();ĺ.Ħ=ʅ;ĺ.ĺ=ʅ.GetInventory();if(ĺ.ĺ.VolumeFillFactor>0){if(n)Echo("Extractor already loaded, waiting...");ʅ.ApplyAction
("OnOff_On");return;}List<ĭ>ʇ=new List<ĭ>();ʇ.Add(ĺ);if(n)Echo("Attempting to load extractor "+ʅ.CustomName);bool Ǟ=ł(ĩ[Ĩ
].Į,ʇ,ĩ[Ĩ].Ł,1);string Ơ="fuel tank";if(Ĩ==2)Ơ="jerry can";if(Ǟ)Ã.Add(new Ä("Loaded a "+Ơ,"Sucessfully loaded a "+Ơ+
" into an extractor.",0));}private double ǳ=0;private int ʈ=0;private double ʉ=0;private void ö(bool ʊ,bool ʋ){ʈ=0;foreach(IMyGyro ʌ in õ){if
(ʌ!=null&&ʌ.IsFunctional){ʈ++;if(ʋ)ʌ.Enabled=ʊ;}}ʉ=Math.Round(100*(ʈ/ǳ));}void u(string ʍ,bool q=true,bool r=true,bool s=
true){if(n)Echo("Initialising a ship as '"+ʍ+"'...");J=true;Ę=ʍ;d=q;b=r;c=s;Ê();}void Ê(){switch(G){case 0:Ñ();F=0;if(Ç)Echo
("Took "+e());break;case 1:é();if(Ç)Echo("Took "+e());break;case 2:if(n)Echo("Initialising lcds...");ʎ();if(b){if(n)Echo(
"Initialising subsystem values...");ʏ();ʐ();ʑ();ʒ();ʓ();ʔ();ǋ();Ǭ=ò.Count+ó.Count;ǭ=ç.Count;Ǯ=Õ.Count;ǳ=õ.Count;Ǵ=Ă.Count;}if(c){if(n)Echo(
"Initialising item values...");ʕ();}if(d){if(n)Echo("Initialising block names...");ʖ();}ɖ(false,b,c);Ã.Add(new Ä("Init:"+Ę,"Initialised '"+Ę+
"'\nGood Hunting!",3));G=0;J=false;if(Ç)Echo("Took "+e());return;}G++;}class ʚ{public int ʗ=0;public int ʘ=0;public int ʙ=0;}void ʖ(){
Dictionary<string,ʚ>ʛ=new Dictionary<string,ʚ>();if(Ǚ.Count>0){foreach(string ʜ in Ǚ){if(n)Echo("Numbering "+ʜ);ʛ.Add(ʜ,new ʚ());}
foreach(var ʞ in ś){ʚ ʝ;if(ʛ.TryGetValue(ʞ.Value,out ʝ)){ʛ[ʞ.Value].ʘ++;}}foreach(var ʟ in ʛ){if(ʟ.Value.ʘ<10)ʟ.Value.ʙ=1;else
if(ʟ.Value.ʘ>99)ʟ.Value.ʙ=3;else ʟ.Value.ʙ=2;}}foreach(var ʞ in ś){string ʠ="";string ʡ=ʞ.Value;ʚ ʢ;if(ʛ.TryGetValue(ʞ.
Value,out ʢ)){if(ʢ.ʘ>1){ʢ.ʗ++;ʠ=Ů+ʢ.ʗ.ToString().PadLeft(ʢ.ʙ,'0');}}ʞ.Key.CustomName=Ę+Ů+ʡ+ʠ+ʣ(ʞ.Key.CustomName,ʡ);}}string ʣ
(string Ƹ,string ʤ=""){try{string[]ʥ=Ƹ.Split(Ů);string[]ʦ=ʤ.Split(Ů);string Ʃ="";if(ʥ.Length<3)return"";for(int Ʉ=2;Ʉ<ʥ.
Length;Ʉ++){int ʧ=0;bool ʨ=int.TryParse(ʥ[Ʉ],out ʧ);if(ʨ)ʥ[Ʉ]="";foreach(string ʩ in ʦ){if(ʩ==ʥ[Ʉ])ʥ[Ʉ]="";}if(ʥ[Ʉ]!="")Ʃ+=Ů+ʥ
[Ʉ];}return Ʃ;}catch{return"";}}class ĭ{public IMyTerminalBlock Ħ{get;set;}public IMyInventory ĺ{get;set;}List<
MyInventoryItem>ʪ=new List<MyInventoryItem>();public int ļ=0;public bool Ļ=false;public float Ľ;}class Ĩ{public int ʆ=0;public int ǩ=0;
public int ŀ=0;public double ʫ;public List<ĭ>Į=new List<ĭ>();public List<ĭ>į=new List<ĭ>();public MyItemType Ł;public bool Ī=
false;public bool ī=false;public string Ĭ;public string ʬ;public double Ĺ=1;}private List<Ĩ>ĩ=new List<Ĩ>();void ű(
IMyTerminalBlock Ŝ,int Ǩ=99){if(Ǩ==99){foreach(Ĩ Ĩ in ĩ){ĭ ĺ=new ĭ();ĺ.Ħ=Ŝ;ĺ.ĺ=Ŝ.GetInventory();Ĩ.Į.Add(ĺ);}}else{ĭ ĺ=new ĭ();ĺ.Ħ=Ŝ;ĺ.ĺ=
Ŝ.GetInventory();ĺ.Ļ=ħ;if(Ǩ==0&&!Ǎ)ĺ.Ļ=false;ĩ[Ǩ].Į.Add(ĺ);}}void ʭ(IMyTerminalBlock Ŝ,int Ǩ){ĭ ĺ=new ĭ();ĺ.Ħ=Ŝ;ĺ.ĺ=Ŝ.
GetInventory();ĺ.Ļ=ħ;if(Ǩ!=99)ĩ[Ǩ].į.Add(ĺ);}void ʰ(string Ĭ,string ʮ,string ʯ,bool ī=false,bool Ī=false){Ĩ Ĩ=new Ĩ();Ĩ.Ł=new
MyItemType(ʮ,ʯ);Ĩ.ī=ī;Ĩ.Ī=Ī;Ĩ.Ĭ=Ĭ;string ʬ;if(Ĭ.Length>9)ʬ=Ĭ.Substring(0,9);else ʬ=Ĭ.PadRight(9);Ĩ.ʬ=ʬ;ĩ.Add(Ĩ);}private void g(){
try{ʰ("Fusion Fuel","MyObjectBuilder_Ingot","FusionFuel",true);ʰ("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");ʰ(
"Jerry Can","MyObjectBuilder_Component","SG_Fuel_Tank");ʰ("PDC","MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine",true);
ʰ("PDC Tefl","MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);ʰ("220 Torp ",
"MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",true,true);ʰ("220 MCRN","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true,
true);ʰ("220 UNN","MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);ʰ("RS Torp",
"MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);ʰ("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",
true,true);ʰ("120mm RG","MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);ʰ("Dawson",
"MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true);ʰ("Stiletto","MyObjectBuilder_AmmoMagazine",
"100mmTungstenUraniumSlugMCRNMagazine",true);ʰ("80mm","MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);ʰ("Foehammr",
"MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugMCRNMagazine",true);ʰ("Farren","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugUNNMagazine",true);ʰ("Kess","MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);ʰ("Steel Pla",
"MyObjectBuilder_Component","SteelPlate");ĩ[0].Ĺ=ǝ;}catch(Exception Ė){Echo("Failed to build item lists!");Echo(Ė.Message);return;}}void æ(){
foreach(Ĩ Ĩ in ĩ){Ĩ.į.Clear();}}private void é(){foreach(Ĩ Ĩ in ĩ){Ĩ.ʆ=0;Ĩ.ŀ=0;List<ĭ>İ=Ĩ.Į.Concat(Ĩ.į).ToList();foreach(ĭ ĺ in
İ){ĺ.ļ=ĺ.ĺ.GetItemAmount(Ĩ.Ł).ToIntSafe();Ĩ.ʆ+=ĺ.ļ;if(ĺ.Ļ){ĺ.Ľ=ĺ.ĺ.VolumeFillFactor;}else{Ĩ.ŀ+=ĺ.ļ;}}}}private void ʕ(){
foreach(Ĩ Ĩ in ĩ){Ĩ.ǩ=Ĩ.ʆ;}}int ʲ(string ʱ){switch(ʱ){case"220mm Explosive Torpedo":return 5;case"MCRN Torpedo High Spread":
case"MCRN Torpedo Low Spread":return 6;case"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case
"40mm Tungsten-Teflon Ammo":return 4;case"40mm Lead-Steel PDC Box Ammo":return 4;case"Ramshackle Torpedo Magazine":return 8;case
"120mm Lead-Steel Slug Ammo":return 10;case"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case
"80mm Tungsten-Uranium Sabot Ammo":return 13;case"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;
case"180mm Lead-Steel Sabot Ammo":return 16;case"Large Ramshackle Torpedo Magazine":return 9;default:if(n)Echo(
"Unknown AmmoType = "+ʱ);return 99;}}bool ʴ(IMyTerminalBlock Ħ){IMyInventory ʳ=Ħ.GetInventory();return ʳ.VolumeFillFactor==0;}bool ł(List<ĭ>ı
,List<ĭ>ĳ,MyItemType Ł,int ʵ=-1,double ʶ=1,double ʷ=1){if(n)Echo("Loading "+ĳ.Count+" inventories from "+ı.Count+
" sources.");bool ʸ=false;bool ʹ=ʷ<1;foreach(ĭ ʻ in ĳ){int ʺ=3;foreach(ĭ ʼ in ı){if(ʺ<0)break;if(ʵ!=-1&&ʻ.ļ>=(ʵ*.95))break;if(!ʻ.ĺ.
IsConnectedTo(ʼ.ĺ))continue;List<MyInventoryItem>ʽ=new List<MyInventoryItem>();ʼ.ĺ.GetItems(ʽ);foreach(MyInventoryItem ʾ in ʽ){if(ʾ.
Type==Ł){int ļ=ʾ.Amount.ToIntSafe();if(ļ==0&&!ʹ)break;ʺ--;if(ʹ){ʺ=-1;try{ļ=ʼ.ļ-Convert.ToInt32(ʼ.ļ/ʼ.Ľ*ʷ);if(n)Echo(
"Unload "+ļ+"\n"+ʼ.ļ+"\n"+Convert.ToInt32(ʼ.ļ/ʼ.Ľ*ʷ));}catch(Exception Ė){if(n)Echo("Int conversion error at unload\n"+Ė.Message)
;ļ=1;}}else if(ʶ<1){try{int ʿ=Convert.ToInt32(ʻ.ļ/ʻ.Ľ*ʶ)-ʻ.ļ;if(ʿ<ļ)ļ=ʿ;}catch(Exception Ė){if(n)Echo(
"Int conversion error at load\n"+Ė.Message);ļ=1;}}else if(ʵ!=-1){if(ļ<=ʵ){break;}ļ=ʵ-ʻ.ļ;}ʸ=ʻ.ĺ.TransferItemFrom(ʼ.ĺ,ʾ,ļ);if(ʸ)ʺ=-1;if(ʹ&&ʸ)return(ʸ);
break;}}}}return ʸ;}class Œ{public IMyTextPanel Ħ;public bool ƭ=true;public bool Ʈ=false;public bool Ư=false;public bool Ƭ=
true;public bool ư=true;public bool Ʊ=true;public bool Ʋ=false;public bool Ƴ=false;}class Ä{public string ˀ,ˁ;public int ˆ,ˇ
;public Ä(string ˈ,string ˉ,int ˊ=0,int ˋ=20){if(ˈ.Length>ˌ-3)ˈ=ˈ.Substring(0,ˌ-3);ˀ=ˈ.PadRight(ˌ-3);ˁ=ˉ;ˆ=ˊ;ˇ=ˋ;}}List<Ä
>Ã=new List<Ä>();class ˠ{public string ˍ,ˎ;public ˠ(string ʜ,int ˏ,int ː){string ˑ="    ";while(ː>3){ː-=4;}if(ˏ==0){ˍ=
"║ "+ʜ.PadRight(4)+" ║";ˎ="  "+ˑ+"  ";}else if(ˏ==1){if(ː==0||ː==2)ˍ="║─"+ʜ.PadRight(4)+" ║";else ˍ="║ "+ʜ.PadRight(4)+"─║";
ˎ=" ░"+ˑ+"░ ";}else if(ˏ==2){if(ː==0||ː==2){ˍ="║ "+ʜ.PadRight(4)+"═║";ˎ="║▒"+ˑ+"░║";}else{ˍ="║═"+ʜ.PadRight(4)+" ║";ˎ=
"║░"+ˑ+"▒║";}}else if(ˏ==3){if(ː==0||ː==2){ˍ="║!"+ʜ.PadRight(4)+"!║";ˎ="║▓"+ˑ+"▓║";}else{ˍ="║ "+ˑ+" ║";ˎ="║!"+ʜ.PadRight(4)+
"!║";}}}}Color ˡ=new Color(255,116,33,255);const int ˌ=32;int ˢ=0;string[]ˣ=new string[]{"▄ "," ▄"," ▀","▀ "},ˤ=new string[]
{"─","\\","│","/"},ˬ=new string[]{"- ","= ","x ","! "};string ˮ,Ͱ,ͱ,Ͳ,ͳ="\n\n",ʹ,Ͷ="╔══════╗",ͷ="╚══════╝",ȶ,ͺ,ͻ,ͼ,ͽ,Ά,Έ,
Ή,Ί,Ό,Ύ,Ώ,ΐ,Α,Β,Γ,Δ,Ε,Ζ,Η,Θ;void i(){Ͷ=Ͷ+Ͷ+Ͷ+Ͷ+"\n";ͷ=ͷ+ͷ+ͷ+ͷ+"\n";ˮ=Ι("Welcome to")+ͳ+Ι("R S M")+ͳ;Ͱ=Ι("Initialising")+ͳ
;ͱ=new String(' ',ˌ-8);Ͳ="└"+new String('─',ˌ-2)+"┘";ȶ=new String('-',26)+"\n";ʹ="──"+ͳ;ͺ=Κ("Inventory");ͻ=Κ("Thrust");ͼ=
Κ("Power & Tanks");ͽ=Κ("Warnings");Ά=Κ("Subsystem Integrity");Έ=Κ("Telemetry & Thrust");Ή=Λ("Velocity");Ί=Λ(
"Velocity (Max)");Ό=Λ("Mass");Ύ=Λ("Max Accel");Ώ=Λ("Actual Accel");ΐ=Λ("Accel (Best)");Α=Λ("Max Thrust");Β=Λ("Actual Thrust");Γ=Λ(
"Decel (Dampener)");Δ=Λ("Decel (Actual)");Ε=Μ("Fuel");Ζ=Μ("Oxygen");Η=Μ("Battery");Θ=Μ("Capacity");}string Κ(string Ν){return"──┤ "+Ν+" ├"
+new String('─',ˌ-9-Ν.Length);}string Λ(string Ξ){return Ξ+":"+new String(' ',ˌ-16-Ξ.Length);}string Μ(string Ο){return Ο
+new String(' ',ˌ-22-Ο.Length)+"[";}void Ì(){ˢ++;if(ˢ>=ˣ.Length)ˢ=0;int Π=ˢ+2;if(Π>3)Π-=4;string Ρ=ˣ[ˢ];string Σ=ˤ[ˢ];
string Τ=ˣ[Π];string Υ=ͺ+Σ+ʹ;string Φ=ͻ+Σ+ʹ;string Χ=ͼ+Σ+ʹ;string Ψ=ͽ+Σ+ʹ;string Ω=Ά+Σ+ʹ;string Ϊ=Έ+Σ+ʹ;string Ϋ=Ι(Ę.ToUpper()
)+"\n"+"  "+Ρ+" "+Ι(ę,ˌ-10)+" "+Ρ+"  \n";string ά="\n  "+Τ+ͱ+Τ+"  "+ͳ;if(I){string έ=ˮ+Ι("Booting"+new string('.',C))+ͳ;Υ
+=έ;Φ+=έ;Χ+=έ;Ψ+=έ;Ω+=έ;}else if(J){string ƚ=Ͱ+Ι(Ę)+ͳ;Υ+=ƚ;Φ+=ƚ;Χ+=ƚ;Ψ+=ƚ;Ω+=ƚ;}else{ǆ();double ή=9.81,ί=Math.Round(T),α=
Math.Round((ΰ/U/ή),2),γ=Math.Round((β/U/ή),2),δ=Math.Round(Ǫ+ǫ,1),ζ=Math.Round(ε,1),ι=Math.Round(100*(η/θ)),μ=Math.Round(100
*(κ/λ)),ν=Math.Round(100*(ζ/δ));string ξ=Ή,ο=" Gs",Ǽ;List<string>π=new List<string>();if(ί<1){ί=500;ξ=Ί;}if(ǜ){ή=1;ο=
" m/s/s";}for(int Ʉ=0;Ʉ<ĩ.Count;Ʉ++){if(ĩ[Ʉ].ǩ!=0){ĩ[Ʉ].ʫ=(100*((double)ĩ[Ʉ].ʆ/(double)ĩ[Ʉ].ǩ));string ə=(ĩ[Ʉ].ʆ+"/"+ĩ[Ʉ].ǩ).
PadLeft(9);if(ə.Length>9)ə=ə.Substring(0,9);Υ+=ĩ[Ʉ].ʬ+" ["+ρ(ĩ[Ʉ].ʫ)+"] "+ə+"\n";if(Ʉ>2&&ĩ[Ʉ].ŀ<1)π.Add(ĩ[Ʉ].Ĭ);}}Υ+="\n";if(β>
0)Φ+=Δ+ς(β,ί)+"\n"+Ώ+(γ+ο).PadLeft(15)+ͳ;else Φ+=Γ+ς(ΰ,ί,true)+"\n"+ΐ+(α+ο).PadLeft(15)+ͳ;ʀ=Math.Round(100*(ʃ/ʄ));Χ+=Ε+ρ(
ʀ)+"] "+(ʀ+" %").PadLeft(9)+"\n"+Ζ+ρ(ι)+"] "+(ι+" %").PadLeft(9)+"\n"+Η+ρ(μ)+"] "+(μ+" %").PadLeft(9)+"\n"+Θ+ρ(ν)+"] "+(ν
+" %").PadLeft(9)+"\n"+"Max Power:"+(ζ+" MW / "+δ+" MW").PadLeft(22)+ͳ;List<Ä>σ=new List<Ä>();List<ˠ>τ=new List<ˠ>();int
υ=0;for(int Ʉ=0;Ʉ<Ã.Count;Ʉ++){Ã[Ʉ].ˇ--;if(Ã[Ʉ].ˇ<1)Ã.RemoveAt(Ʉ);else σ.Add(Ã[Ʉ]);}if(!φ){σ.Add(new Ä("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(O){σ.Add(new Ä("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int χ=0;if(ʀ<5)
{Ǽ="FUEL CRITICAL!";σ.Add(new Ä(Ǽ,Ǽ+"\nFuel Level < 5%!",3));χ=3;}else if(ʀ<25){Ǽ="FUEL LOW!";σ.Add(new Ä(Ǽ,Ǽ+
"\nFuel Level < 10%!",2));χ=2;}if(Î.Ȭ!=ȭ.Off){if(Q!=""){if(χ==0)χ=1;σ.Add(new Ä("NO SPARE "+Q.ToUpper()+"!",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",χ));}if(P){if(χ==0)χ=1;σ.Add(new Ä("NO EXTRACTOR!","Cannot refuel!\nNo functional extractor!",χ));}}τ.Add(new ˠ("FUEL",
χ,ˢ+υ));υ++;if(N){Ǽ=Ć.Count+" spawns are open to friends";σ.Add(new Ä(Ǽ,Ǽ,0));}int ψ=0;if(ι<5){Ǽ="OXYGEN CRITICAL!";σ.Add
(new Ä(Ǽ,Ǽ+"\nShip O2 Level < 5%!",3));ψ=3;}else if(ι<10){Ǽ="OXYGEN LOW!";σ.Add(new Ä(Ǽ,Ǽ+"\nShip O2 Level < 10%!",2));ψ=
2;}else if(ι<25){Ǽ="Oxygen Low!";σ.Add(new Ä(Ǽ,Ǽ+"\nShip O2 Level < 25%!",1));ψ=1;}if(þ.Count>ω){int ϊ=(þ.Count-ω);ψ++;Ǽ=
ϊ+" vents are unsealed";σ.Add(new Ä(Ǽ,Ǽ,1));}if(ɧ>0){Ǽ=ɧ+" doors are insecure";σ.Add(new Ä(Ǽ,Ǽ,0));}if(S>0){Ǽ=š+
" is active ("+S+")";σ.Add(new Ä(Ǽ,Ǽ,0));}τ.Add(new ˠ("OXYG",ψ,ˢ+υ));υ++;int ϋ=0;if(Ú.Count>0){if(μ<5){ϋ+=2;Ǽ="BATTERIES CRITICAL!";σ.
Add(new Ä(Ǽ,Ǽ+"\nBattery Level < 5%!",2));}else if(μ<10){ϋ+=1;Ǽ="Batteries Low!";σ.Add(new Ä(Ǽ,Ǽ+"\nBattery Level < 10%!",1
));}}if(Ù.Count>0){if(ό>0){ϋ+=2;σ.Add(new Ä(ό+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}
if(ĩ[0].ʆ<1){ϋ+=3;Ǽ="NO FUSION FUEL!";σ.Add(new Ä(Ǽ,Ǽ,2));}else if(ĩ[0].ʆ<50){ϋ+=2;Ǽ="FUSION FUEL CRITICAL! ("+ĩ[0].ʆ+")";
σ.Add(new Ä(Ǽ,Ǽ,2));}else if(ĩ[0].ǩ>0&&ĩ[0].ʫ<5){ϋ+=2;Ǽ="FUSION FUEL CRITICAL!";σ.Add(new Ä(Ǽ,Ǽ,3));}else if(ĩ[0].ǩ>0&&ĩ[
0].ʫ<10){ϋ+=1;Ǽ="Fusion Fuel Level Low!";σ.Add(new Ä(Ǽ,Ǽ,2));}}if(ϋ>3)ϋ=3;τ.Add(new ˠ("POWR",ϋ,ˢ+υ));υ++;int ύ=0;if(π.
Count>0){foreach(string ώ in π){string Ϗ=ώ;if(ώ.Length>23)Ϗ=ώ.Substring(0,23);Ϗ=Ϗ.ToUpper();Ǽ="NO SPARE "+Ϗ+"!";σ.Add(new Ä(Ǽ
,Ǽ,3));}ύ=3;}if(ύ>3)ύ=3;τ.Add(new ˠ("WEAP",ύ,ˢ+υ));υ++;if(Ġ){string ϐ=ġ;if(ú.Count>0)if(ú[0]!=null)ϐ=(ú[0]as
IMyRadioAntenna).HudText;string ϑ="";if(Ģ<1000)ϑ=Math.Round(Ģ)+"m";else ϑ=Math.Round(Ģ/1000)+"km";σ.Add(new Ä("Comms ("+ϑ+"): "+ϐ,
"Antenna(s) are broadcasting at a range of "+ϑ+" with the message "+ϐ,0));}if(R>0){Ǽ=R+" UNOWNED BLOCKS!";σ.Add(new Ä(Ǽ,Ǽ+"\nRSM detected "+R+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ɥ>ɦ){int ɫ=(ɥ-ɦ);Ǽ=ɫ+" doors are open";σ.Add(new Ä(Ǽ,Ǽ,0));}σ=σ.OrderBy(Ŀ=>Ŀ.ˆ).Reverse().ToList();if(σ.Count<1
)Ψ+="No warnings\n";else Echo(ͳ+" WARNINGS:");for(int Ʉ=0;Ʉ<σ.Count;Ʉ++){Ψ+=ˬ[σ[Ʉ].ˆ]+σ[Ʉ].ˀ+"\n";Echo("-"+ˬ[σ[Ʉ].ˆ]+σ[Ʉ]
.ˁ);}Ψ+="\n";string ϒ=Î.ȋ.ToString().ToUpper();if(ϒ.Length>3)ϒ=ϒ.Substring(0,3);string ϓ=Î.Ȏ.ToString().ToUpper();if(ϓ.
Length>3)ϓ=ϓ.Substring(0,3);string ϔ=Î.ȋ.ToString().ToUpper();if(ϔ.Length>3)ϔ=ϔ.Substring(0,3);string ϕ=Î.ȅ.ToString().ToUpper
();if(ϕ.Length>3)ϕ=ϕ.Substring(0,3);string ϖ=Î.ȃ.ToString().ToUpper();if(ϖ.Length>3)ϖ=ϖ.Substring(0,3);string ϗ=Î.Ȉ.
ToString().ToUpper();if(ϗ.Length>3)ϗ=ϗ.Substring(0,3);try{if(Ǳ>0)Ω+="Epstein   ["+ρ(Ϙ)+"] "+(Ϙ+"% ").PadLeft(5)+ϒ+"\n";if(ǲ>0)Ω
+="RCS       ["+ρ(ϙ)+"] "+(ϙ+"% ").PadLeft(5)+ϓ+"\n";if(Ǫ>0)Ω+="Reactors  ["+ρ(Ϛ)+"] "+(Ϛ+"% ").PadLeft(5)+"    \n";if(ǫ>0
)Ω+="Batteries ["+ρ(ϛ)+"] "+(ϛ+"% ").PadLeft(5)+ϔ+"\n";if(Ǭ>0)Ω+="PDCs      ["+ρ(Ϝ)+"] "+(Ϝ+"% ").PadLeft(5)+ϕ+"\n";if(ǭ>
0)Ω+="Torpedoes ["+ρ(ϝ)+"] "+(ϝ+"% ").PadLeft(5)+ϖ+"\n";if(Ǯ>0)Ω+="Railguns  ["+ρ(Ϟ)+"] "+(Ϟ+"% ").PadLeft(5)+ϗ+"\n";if(ǯ
>0)Ω+="H2 Tanks  ["+ρ(ϟ)+"] "+(ϟ+"% ").PadLeft(5)+ϔ+"\n";if(ǰ>0)Ω+="O2 Tanks  ["+ρ(Ϡ)+"] "+(Ϡ+"% ").PadLeft(5)+ϔ+"\n";if(
ǳ>0)Ω+="Gyros     ["+ρ(ʉ)+"] "+(ʉ+"% ").PadLeft(5)+"    \n";if(Ǉ>0)Ω+="Cargo     ["+ρ(ǉ)+"] "+(ǉ+"% ").PadLeft(5)+
"    \n";if(Ǵ>0)Ω+="Welders   ["+ρ(ϡ)+"] "+(ϡ+"% ").PadLeft(5)+"    \n";}catch{}if(ǫ+Ǫ+ǯ==0)Ω+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+ͳ;string Ϣ="";string ϣ="";foreach(ˠ Ϥ in τ){Ϣ+=Ϥ.ˍ;ϣ+=Ϥ.ˎ;}int ϥ=ˢ+2;if(ϥ>3)ϥ-=4;Ϋ+=Ͷ+Ϣ+"\n"+ͷ;ά+=ϣ;if(!Y){Ϊ+=ͳ;}else{
if(n)Echo("Building advanced thrust...");string Ϧ="";if(Ǜ){Ϧ=Ό+(Math.Round((U/1000000),2)+" Mkg").PadLeft(15)+"\n"+ξ+(ί+
" ms").PadLeft(15)+"\n"+Ύ+(α+ο).PadLeft(15)+"\n"+Ώ+(γ+ο).PadLeft(15)+"\n"+Α+((ΰ/1000000)+" MN").PadLeft(15)+"\n"+Β+((β/
1000000)+" MN").PadLeft(15)+"\n";}Ϊ+=Ϧ+Γ+ς(ΰ,ί,true)+"\n"+Δ+ς(β,ί)+"\n";foreach(double Ⱥ in h){Ϊ+=("Decel ("+(Ⱥ*100)+"%):").
PadRight(17)+ς((float)(ΰ*Ⱥ),ί)+"\n";}Ϊ+=ͳ;}}foreach(Œ ơ in Ë){string ɭ="";Color ɚ=Î.ȟ;if(ơ.ƭ)ɭ+=Ϋ;if(ơ.Ʈ){ɭ+=ά;ɚ=ˡ;}if(ơ.Ư)ɭ+=Ψ;
if(ơ.Ƭ)ɭ+=Χ;if(ơ.ư)ɭ+=Υ;if(ơ.Ʊ)ɭ+=Φ;if(ơ.Ʋ)ɭ+=Ω;if(ơ.Ƴ){ɭ+=Ϊ;Y=true;}ơ.Ħ.WriteText(ɭ,false);if(!Ŧ)ơ.Ħ.FontColor=ɚ;}}void ϧ
(){if(ő.Count>0){foreach(IMyTextPanel ơ in ő){ơ.FontColor=Î.ȟ;}foreach(Œ ơ in Ë){ơ.Ħ.FontColor=Î.ȟ;}}}void x(string Ϩ,
string ϩ){Ϩ=Ϩ.ToLower();List<IMyTextPanel>Ϫ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ą);
foreach(IMyTextPanel ơ in Ą){if(ϩ==""||ơ.CustomName.Contains(ϩ)){string ϫ=ơ.CustomData;if(ϫ.Contains("hudlcd")&&(Ϩ=="off"||Ϩ==
"toggle"))ơ.CustomData=ϫ.Replace("hudlcd","hudXlcd");if(ϫ.Contains("hudXlcd")&&(Ϩ=="on"||Ϩ=="toggle"))ơ.CustomData=ϫ.Replace(
"hudXlcd","hudlcd");}}}string ρ(double Ϭ){try{int ϭ=0;if(Ϭ>0){int Ϯ=(int)Ϭ/10;if(Ϯ>10)return new string('=',10);if(Ϯ!=0)ϭ=Ϯ;}char
ϯ=' ';if(Ϭ<10){if(ˢ==0)return" ><    >< ";if(ˢ==1)return"  ><  ><  ";if(ˢ==2)return"   ><><   ";if(ˢ==3)return
"<   ><   >";}string ϰ=new string('=',ϭ);string ϱ=new string(ϯ,10-ϭ);return ϰ+ϱ;}catch{return"# ERROR! #";}}string ϴ(string ϲ){
string ϳ;string ə="";double Ϭ=0;switch(ϲ){case"H2":Ϭ=Math.Round(100*(ʃ/ǯ));ə=Ϭ.ToString()+" %";ʀ=Ϭ;break;case"O2":Ϭ=Math.Round
(100*(η/ǰ));ə=Ϭ.ToString()+" %";break;case"Battery":Ϭ=Math.Round(100*(κ/λ));ə=Ϭ.ToString()+" %";break;}ϳ=ρ(Ϭ);return" ["+
ϳ+"] "+ə.PadLeft(9);}string Ι(string ϵ,int Ϸ=ˌ){int ϸ=Ϸ-ϵ.Length;int Ϲ=ϸ/2+ϵ.Length;return ϵ.PadLeft(Ϲ).PadRight(Ϸ);}
string ς(double Ϻ,double ϻ,bool ϼ=false){if(Ϻ<=0)return("N/A").PadLeft(15);if(ϼ)Ϻ=Ϻ*1.5;double Ʃ=0.5*(Math.Pow(ϻ,2)*(U/Ϻ));
double Ͻ=ϻ/(Ϻ/U);string Ͼ="m";if(Ʃ>1000){Ͼ="km";Ʃ=Ʃ/1000;}return(Math.Round(Ʃ)+Ͼ+" "+Math.Round(Ͻ)+"s").PadLeft(15);}private
void ą(){foreach(IMyTextPanel ɞ in Ą){ɞ.Enabled=true;}}private void ʎ(){foreach(Œ ơ in Ë){ơ.Ħ.Font="Monospace";ơ.Ħ.
ContentType=ContentType.TEXT_AND_IMAGE;if(ơ.Ħ.CustomName.Contains("HUD1")){ơ.ƭ=true;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=false;ơ.Ʊ=
false;ơ.Ʋ=false;ơ.Ƴ=false;ť(ơ,"hudlcd:-0.55:0.99:0.7");continue;}if(ơ.Ħ.CustomName.Contains("HUD2")){ơ.ƭ=false;ơ.Ʈ=false;ơ.Ư=
true;ơ.Ƭ=false;ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ=false;ť(ơ,"hudlcd:0.22:0.99:0.55");continue;}if(ơ.Ħ.CustomName.Contains(
"HUD3")){ơ.ƭ=false;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=true;ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ=false;ť(ơ,"hudlcd:0.48:0.99:0.55");continue;
}if(ơ.Ħ.CustomName.Contains("HUD4")){ơ.ƭ=false;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=true;ơ.Ƴ=false;ť(ơ,
"hudlcd:0.74:0.99:0.55");continue;}if(ơ.Ħ.CustomName.Contains("HUD5")){ơ.ƭ=false;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=true;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ
=true;ť(ơ,"hudlcd:0.75:0:.54");continue;}if(ơ.Ħ.CustomName.Contains("HUD6")){ơ.ƭ=false;ơ.Ʈ=true;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=
false;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ=false;ť(ơ,"hudlcd:-0.55:0.99:0.7");continue;}}bool Ͽ=false;foreach(IMyTextPanel ɞ in Ą){if(ɞ==
null)continue;if(!Ͽ&&(ɞ.CustomName.Contains(Ǘ)||ɞ.CustomName.ToUpper().Contains(ǘ))){Ͽ=true;ɞ.CustomData=
"hudlcd:-0.52:-0.7:0.52";continue;}}}private bool φ;private void à(bool ʊ,bool ʋ){φ=false;foreach(IMyConveyorSorter Ѐ in ß){if(Ѐ!=null&&Ѐ.
IsFunctional){φ=true;if(ʋ)Ѐ.Enabled=ʊ;}}}void Ђ(Ȓ ń){if(ń==Ȓ.NoChange)return;foreach(IMyReflectorLight Ё in ŗ){if(Ё==null)continue;
if(ń==Ȓ.Off)Ё.Enabled=false;else{Ё.Enabled=true;if(ń==Ȓ.OnMax)Ё.Radius=9999;}}}void Є(ȕ ń,Color ɚ){if(ń==ȕ.NoChange)return
;foreach(IMyLightingBlock Ѓ in œ){if(Ѓ==null)continue;if(ń==ȕ.Off)Ѓ.Enabled=false;else Ѓ.Enabled=true;if(ń!=ȕ.
OnNoColourChange)Ѓ.SetValue("Color",ɚ);}}void Ѕ(ȕ ń,Color ɚ){if(ń==ȕ.NoChange)return;foreach(IMyLightingBlock Ѓ in Ŕ){if(Ѓ==null)
continue;if(ń==ȕ.Off)Ѓ.Enabled=false;else Ѓ.Enabled=true;if(ń!=ȕ.OnNoColourChange)Ѓ.SetValue("Color",ɚ);}}Color І=new Color(255,
0,0,255);Color Ї=new Color(255,0,0,255);Color Ј=new Color(0,255,0,255);void Њ(ȕ ń){if(ń==ȕ.NoChange)return;foreach(
IMyLightingBlock Ѓ in ŕ){Љ(Ѓ,ń,Ї);}foreach(IMyLightingBlock Ѓ in Ŗ){Љ(Ѓ,ń,Ј);}}void Љ(IMyLightingBlock Ѓ,ȕ ń,Color ɚ){if(Ѓ==null)return;
if(ń==ȕ.Off){Ѓ.Enabled=false;Ѓ.SetValue("Color",І);}else{Ѓ.Enabled=true;if(ń!=ȕ.OnNoColourChange)Ѓ.SetValue("Color",ɚ);}}
private int ω=0;private void ÿ(bool ʊ,bool ʋ){ω=0;foreach(IMyAirVent Ћ in þ){if(Ћ!=null){if(ʋ)Ћ.Enabled=ʊ;if(Ћ.CanPressurize)ω
++;}}}private void ĉ(bool ʊ){foreach(IMyShipConnector Ќ in Ĉ){if(Ќ!=null)Ќ.Enabled=ʊ;}}private void ċ(bool ʊ){foreach(
IMyCameraBlock Ѝ in Ċ){if(Ѝ!=null)Ѝ.Enabled=ʊ;}}private void č(bool ʊ){foreach(IMySensorBlock Ў in Č){if(Ў!=null)Ў.Enabled=ʊ;}}private
void ć(){O=true;foreach(IMyTerminalBlock Џ in Ć){Џ.ApplyAction("OnOff_On");if(Џ.IsFunctional)O=false;}}bool А=false;List<
string>Б=new List<string>();bool В=false;List<string>Г=new List<string>();void З(string j,string Д){bool ʸ=false;List<
IMyProgrammableBlock>Е=new List<IMyProgrammableBlock>();try{if(Д=="EFC")Е=ŏ;else if(Д=="NavOS")Е=Ő;foreach(IMyProgrammableBlock Ж in Е){if(Ж
==null||!Ж.Enabled)continue;ʸ=(Ж as IMyProgrammableBlock).TryRun(j);if(n)Echo("Ran "+j+" on "+Ж.CustomName+
" successfully.");Ã.Add(new Ä("Ran "+Д+" ("+j+")","Ran "+Д+" ("+j+")",0));if(Д=="EFC")А=true;else if(Д=="NavOS")В=true;break;}}catch(
Exception Ė){Ã.Add(new Ä(Д+" command errored!",Д+" command "+j+" errored!\n"+Ė.Message,3));}}void И(string j,string Д){if(Д==
"EFC"){if(ŏ.Count<1)return;if(А){Б.Add(j);return;}}if(Д=="NavOS"){if(Ő.Count<1)return;if(В){Г.Add(j);return;}}З(j,Д);}void á(
){if(Б.Count>0&&!А){З(Б[0],"EFC");Б.RemoveAt(0);}if(Г.Count>0&&!В){З(Г[0],"NavOS");Г.RemoveAt(0);}А=false;В=false;}
private int Ǭ=0;private double Й=0;private double Ϝ=0;private void ô(){Й=0;foreach(IMyTerminalBlock Л in ò){К(Л,Î.ȅ!=Ȇ.Off&&Î.ȅ
!=Ȇ.MinDefence);}foreach(IMyTerminalBlock Л in ó){К(Л,Î.ȅ!=Ȇ.Off);}Ϝ=Math.Round(100*(Й/Ǭ));}private void К(
IMyTerminalBlock М,bool ʊ){if(М!=null&&М.IsFunctional){Й++;(М as IMyConveyorSorter).Enabled=ʊ;}}private void Н(Ȇ ń){if(ń==Ȇ.NoChange)
return;foreach(IMyTerminalBlock Л in ò){if(Л!=null&Л.IsFunctional){switch(ń){case Ȇ.Off:case Ȇ.MinDefence:(Л as
IMyConveyorSorter).Enabled=false;break;case Ȇ.AllDefence:(Л as IMyConveyorSorter).Enabled=true;if(ǎ){try{Л.SetValue("WC_FocusFire",false)
;Л.SetValue("WC_Projectiles",true);Л.SetValue("WC_Grids",true);Л.SetValue("WC_LargeGrid",false);Л.SetValue("WC_SmallGrid"
,true);Л.SetValue("WC_SubSystems",true);Л.SetValue("WC_Biologicals",true);ǁ(Л);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;case Ȇ.Offence:(Л as IMyConveyorSorter).Enabled=true;if(ǎ){try{Л.SetValue("WC_FocusFire",false);Л.SetValue(
"WC_Projectiles",true);Л.SetValue("WC_Grids",true);Л.SetValue("WC_LargeGrid",true);Л.SetValue("WC_SmallGrid",true);Л.SetValue(
"WC_SubSystems",true);Л.SetValue("WC_Biologicals",true);ǁ(Л);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock Л in ó){if(Л!=null&Л.IsFunctional){switch(ń){case Ȇ.Off:(Л as IMyConveyorSorter).Enabled=false;break;
case Ȇ.MinDefence:case Ȇ.AllDefence:case Ȇ.Offence:(Л as IMyConveyorSorter).Enabled=true;if(ǎ){try{Л.SetValue("WC_FocusFire"
,false);Л.SetValue("WC_Projectiles",true);Л.SetValue("WC_Grids",true);Л.SetValue("WC_LargeGrid",false);Л.SetValue(
"WC_SmallGrid",true);Л.SetValue("WC_SubSystems",true);Л.SetValue("WC_Biologicals",true);ǀ(Л);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double ε;private void Û(ȡ ń){ε=0;О();П(ń);}double λ=0;double ǫ=0;double κ=0;double ϛ=0;void П(ȡ ń){λ=0;κ=0
;double Р=0;foreach(IMyBatteryBlock С in Ú){if(С!=null&&С.IsFunctional){κ+=С.CurrentStoredPower;λ+=С.MaxStoredPower;Р+=С.
MaxOutput;С.Enabled=true;if(ń==ȡ.ManagedDischarge){if(Т||У<=0)С.ChargeMode=ChargeMode.Discharge;else С.ChargeMode=ChargeMode.
Recharge;}}}ϛ=Math.Round(100*(Р/ǫ));ε+=Р;}void ʑ(){ǫ=0;foreach(IMyBatteryBlock С in Ú){ChargeMode Ф=С.ChargeMode;С.ChargeMode=
ChargeMode.Auto;ǫ+=С.MaxOutput;С.ChargeMode=Ф;}}void Х(ȡ ń){if(ń==ȡ.NoChange)return;foreach(IMyBatteryBlock С in Ú){if(С!=null&&!С
.Closed&&С.IsFunctional){С.Enabled=true;if(ń==ȡ.Auto)С.ChargeMode=ChargeMode.Auto;else if(ń==ȡ.StockpileRecharge)С.
ChargeMode=ChargeMode.Recharge;else if(ń==ȡ.Discharge)С.ChargeMode=ChargeMode.Discharge;}}}double Ǫ=0;double У=0;double Ϛ=0;int ό=
0;void О(){У=0;ό=0;foreach(IMyReactor Ц in Ù){if(Ц!=null&&!Ц.Closed&&Ц.IsFunctional){Ц.Enabled=true;if(ʴ(Ц))ό++;else У+=Ц
.MaxOutput;}}Ϛ=Math.Round(100*(У/Ǫ));ε+=У;}void ʒ(){Ǫ=0;foreach(IMyReactor Ц in Ù){Ǫ+=Ц.MaxOutput;}}void Á(IMyProjector Â
){Â.CustomData=Â.ProjectionOffset.X+"\n"+Â.ProjectionOffset.Y+"\n"+Â.ProjectionOffset.Z+"\n"+Â.ProjectionRotation.X+"\n"+
Â.ProjectionRotation.Y+"\n"+Â.ProjectionRotation.Z+"\n";}void Å(IMyProjector Â){if(!Â.IsFunctional)return;try{string[]Ч=Â
.CustomData.Split('\n');Vector3I Ш=new Vector3I(int.Parse(Ч[0]),int.Parse(Ч[1]),int.Parse(Ч[2]));Vector3I Щ=new Vector3I(
int.Parse(Ч[3]),int.Parse(Ч[4]),int.Parse(Ч[5]));Â.Enabled=true;Â.ProjectionOffset=Ш;Â.ProjectionRotation=Щ;Â.
UpdateOffsetAndRotation();}catch{if(n)Echo("Failed to load projector position for "+Â.Name);}}private int Ǯ=0;private double Ъ=0;private double
Ϟ=0;private bool Т=false;private void Ø(){Т=false;Ъ=0;foreach(IMyTerminalBlock Ы in Õ){if(Ы!=null&&Ы.IsFunctional){Ъ++;(Ы
as IMyConveyorSorter).Enabled=Î.Ȉ!=ȉ.Off;if(!Т){MyDetectedEntityInfo?Э=ē.Ь(Ы);if(Э.HasValue){string ʜ=Э.Value.Name;if(ʜ!=
null&&ʜ!=""){if(n)Echo("At least one rail has a target!");Т=true;}}}}}foreach(IMyTerminalBlock Ы in Ö){if(Ы!=null&&Ы.
IsFunctional){Ъ++;(Ы as IMyConveyorSorter).Enabled=Î.Ȉ!=ȉ.Off;}}Ϟ=Math.Round(100*(Ъ/Ǯ));}private void а(ȉ ń){if(ń==ȉ.NoChange)return
;foreach(IMyTerminalBlock Я in Õ){Ю(Я,ń,false);}foreach(IMyTerminalBlock Я in Ö){Ю(Я,ń,true);}}private void Ю(
IMyTerminalBlock Я,ȉ ń,bool Ɵ){if(Я!=null&Я.IsFunctional){if(ń==ȉ.Off){(Я as IMyConveyorSorter).Enabled=false;}else{(Я as
IMyConveyorSorter).Enabled=true;if(!Ɵ){if(ǎ){Я.SetValue("WC_Grids",true);Я.SetValue("WC_LargeGrid",true);Я.SetValue("WC_SmallGrid",true);
Я.SetValue("WC_SubSystems",true);ǁ(Я);}if(Ǐ){if(ń==ȉ.OpenFire){Ǆ(Я);}else{ǃ(Я);}}}}}}class Ƕ{public string Ⱦ="";public Ð
ȃ;public Ȇ ȅ;public ȉ Ȉ;public Ȍ ȋ;public ȏ Ȏ;public Ȓ ȑ;public ȕ Ȕ;public Color ȗ;public ȕ ș;public Color ț;public ȕ ȝ;
public Color ȟ;public ȡ Ü;public int ȣ;public Ð ȥ;public Ȩ ȧ;public Ð Ȫ;public ȭ Ȭ;public Ð Ï;public ȱ Ȱ;}string ę="N/A";Ƕ Î;Ð
Ȅ=Ð.On;Ȇ ȇ=Ȇ.Offence;ȉ Ȋ=ȉ.OpenFire;Ȍ ȍ=Ȍ.On;ȏ Ȑ=ȏ.On;Ȓ ȓ=Ȓ.On;ȕ Ȗ=ȕ.On;Color Ș=new Color(33,144,255,255);ȕ Ț=ȕ.On;Color
Ȝ=new Color(255,214,170,255);ȕ Ȟ=ȕ.On;Color Ƞ=new Color(33,144,255,255);ȡ Ȣ=ȡ.Auto;int Ȥ=-1;Ð Ȧ=Ð.NoChange;Ȩ ȩ=Ȩ.NoChange
;Ð ȫ=Ð.NoChange;ȭ Ȯ=ȭ.KeepFull;Ð ȯ=Ð.On;ȱ Ȳ=ȱ.NoChange;void v(string Ƚ){Ƕ ǻ;if(!ȳ.TryGetValue(Ƚ,out ǻ)){Ã.Add(new Ä(
"NO SUCH STANCE!","A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(n)
Echo("Setting stance '"+Ƚ+"'.");if(Î.ȧ==Ȩ.Abort){И("Off","EFC");И("Abort","NavOS");}Î=ǻ;ę=Ƚ;ɖ();if(n)Echo("Setting "+Õ.Count
+" railguns to "+Î.Ȉ);а(Î.Ȉ);if(n)Echo("Setting "+ç.Count+" torpedoes to "+Î.ȃ);б(Î.ȃ);if(n)Echo("Setting "+ò.Count+
" _normalPdcs, "+ó.Count+" defence _normalPdcs to "+Î.ȅ);Н(Î.ȅ);if(n)Echo("Setting "+Ý.Count+" epsteins, "+ō.Count+" chems"+" to "+Î.ȋ);
в(Î.ȋ,Î.Ȏ);if(n)Echo("Setting "+ð.Count+" rcs, "+Ŏ.Count+" atmos"+" to "+Î.Ȏ);г(Î.Ȏ);if(n)Echo("Setting "+Ú.Count+
" batteries to = "+Î.Ü);Х(Î.Ü);if(n)Echo("Setting "+ë.Count+" H2 tanks to stockpile = "+Î.Ü);д(Î.Ü);if(n)Echo("Setting "+ø.Count+
" O2 tanks to stockpile = "+Î.Ü);е(Î.Ü);if(ǚ){if(n)Echo("No lighting was set because lighting control is disabled.");}else{if(n)Echo("Setting "+ŗ.
Count+" spotlights to "+Î.ȑ);Ђ(Î.ȑ);if(n)Echo("Setting "+œ.Count+" exterior lights to "+Î.Ȕ);Є(Î.Ȕ,Î.ȗ);if(n)Echo("Setting "+
Ŕ.Count+" exterior lights to "+Î.ș);Ѕ(Î.ș,Î.ț);if(n)Echo("Setting "+ŕ.Count+" port nav lights, "+Ŗ.Count+
" starboard nav lights to "+Î.ȝ);Њ(Î.ȝ);}if(n)Echo("Setting "+Ā.Count+" aux block to "+Î.Ȫ);ŉ(Î.Ȫ);if(n)Echo("Setting "+ŋ.Count+" extrators to "+Î.
Ȭ);ʂ(Î.Ȭ);if(n)Echo("Setting "+Ŋ.Count+" hangar doors units to "+Î.Ȱ);ɶ(Î.Ȱ);if(Î.Ȉ==ȉ.OpenFire){if(n)Echo("Setting "+â.
Count+" doors to locked because we are in combat (rails set to open fire).");z("locked","");}if(n)Echo("Setting "+ő.Count+
" colour sync Lcds.");ϧ();if(Î.ȣ>0){И("Set Burn "+Î.ȣ,"EFC");float ж=Convert.ToSingle(Î.ȣ)/100;И("ThrustRatio "+ж,"NavOS");}if(Î.ȥ==Ð.On)И(
"Boost On","EFC");else if(Î.ȥ==Ð.Off)И("Boost Off","EFC");if(n)Echo("Finished setting stance.");}private double ʄ=0;private double
ǯ=0;private double ʃ=0;private double ϟ=0;private void ì(){ʃ=0;ʄ=0;foreach(IMyGasTank з in ë){if(з.IsFunctional){з.
Enabled=true;ʄ+=з.Capacity;ʃ+=(з.Capacity*з.FilledRatio);}}ϟ=Math.Round(100*(ʄ/ǯ));}private void ʓ(){ǯ=0;foreach(IMyGasTank з
in ë){if(з!=null)ǯ+=з.Capacity;}}private void д(ȡ ń){if(ń==ȡ.NoChange)return;foreach(IMyGasTank з in ë){if(з==null)
continue;з.Enabled=true;if(ń==ȡ.StockpileRecharge)з.Stockpile=true;else з.Stockpile=false;}}private double θ=0;private double η=
0;private double ǰ=0;private double Ϡ=0;private void ù(){η=0;θ=0;foreach(IMyGasTank з in ø){if(з.IsFunctional){з.Enabled=
true;θ+=з.Capacity;η+=(з.Capacity*з.FilledRatio);}}Ϡ=Math.Round(100*(θ/ǰ));}private void ʔ(){ǰ=0;foreach(IMyGasTank з in ø){
if(з!=null)ǰ+=з.Capacity;}}private void е(ȡ ń){if(ń==ȡ.NoChange)return;foreach(IMyGasTank з in ø){if(з==null)continue;з.
Enabled=true;if(ń==ȡ.StockpileRecharge)з.Stockpile=true;else з.Stockpile=false;}}private float ΰ;private float β;private float
Ǳ;private double Ϙ;private void Þ(){float и=0;float й=0;float к=0;float л=0;foreach(IMyThrust м in Ý){if(м!=null&&м.
IsFunctional){и+=м.MaxThrust;к+=м.CurrentThrust;if(м.Enabled){й+=м.MaxThrust;л+=м.CurrentThrust;}}}Ϙ=Math.Round(100*(и/Ǳ));if(й==0){
ΰ=и;β=к;}else{ΰ=й;β=л;}}private void ʏ(){Ǳ=0;foreach(IMyThrust м in Ý){if(м!=null)Ǳ+=м.MaxThrust;}}private void в(Ȍ ń,ȏ н
){if(ń==Ȍ.NoChange)return;foreach(IMyThrust м in Ý){о(м,ń,н);}foreach(IMyThrust м in ō){о(м,ń,н,true);}}private void о(
IMyThrust м,Ȍ ń,ȏ н,bool п=false){bool р=м.CustomName.Contains(ǖ);if(р){if(н!=ȏ.Off&&н!=ȏ.AtmoOnly)м.Enabled=true;else м.Enabled=
false;}else{bool с=м.CustomName.Contains(Ǖ);if((ń==Ȍ.On)||(ń==Ȍ.Minimum&&с)||(ń==Ȍ.EpsteinOnly&&!п)||(ń==Ȍ.ChemOnly&&п)){м.
Enabled=true;}else{м.Enabled=false;}}}private float т;private float ǲ;private double ϙ;private void ñ(){т=0;foreach(IMyThrust м
in ð){if(м!=null&&м.IsFunctional){т+=м.MaxThrust;}}ϙ=Math.Round(100*(т/ǲ));}private void ʐ(){ǲ=0;foreach(IMyThrust м in ð)
{if(м!=null)ǲ+=м.MaxThrust;}}private void г(ȏ ń){foreach(IMyThrust м in ð){if(м!=null)у(м,ń);}foreach(IMyThrust м in Ŏ){
if(м!=null)у(м,ń,true);}}private void у(IMyThrust м,ȏ ń,bool ф=false){bool х=м.GridThrustDirection==Vector3I.Backward;bool
ц=м.GridThrustDirection==Vector3I.Forward;if((ń==ȏ.On)||(ń==ȏ.ForwardOff&&!х)||(ń==ȏ.ReverseOff&&!ц)||(ń==ȏ.RcsOnly&&!ф)
||(ń==ȏ.AtmoOnly&&ф)){м.Enabled=true;}else{м.Enabled=false;}}private int ǭ=0;private double ч=0;private double ϝ=0;private
void è(){ч=0;foreach(IMyTerminalBlock ш in ç){if(ш!=null&&ш.IsFunctional){ч++;(ш as IMyConveyorSorter).Enabled=Î.ȃ==Ð.On;if(
ħ){string ʱ=ē.щ(ш,0);int ώ=ʲ(ʱ);if(n)Echo("Launcher "+ш.CustomName+" needs "+ʱ+"("+ώ+")");ʭ(ш,ώ);}}}ϝ=Math.Round(100*(ч/ǭ
));}private void б(Ð ń){if(ń==Ð.NoChange)return;foreach(IMyTerminalBlock ш in ç){if(ш!=null&ш.IsFunctional){if(ń==Ð.Off){
(ш as IMyConveyorSorter).Enabled=false;}else{(ш as IMyConveyorSorter).Enabled=true;if(ǎ){ш.SetValue("WC_FocusFire",true);
ш.SetValue("WC_Grids",true);ш.SetValue("WC_LargeGrid",true);ш.SetValue("WC_SmallGrid",false);ш.SetValue("WC_FocusFire",
true);ш.SetValue("WC_SubSystems",true);ǁ(ш);}}}}}Ĕ ē;public class Ĕ{private Action<ICollection<MyDefinitionId>>ъ;private
Action<ICollection<MyDefinitionId>>ы;private Action<ICollection<MyDefinitionId>>ь;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,IDictionary<string,int>,bool>э;private Func<long,MyTuple<bool,int,int>>ю;private Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>я;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.
ModAPI.Ingame.MyDetectedEntityInfo>>ѐ;private Func<long,int,MyDetectedEntityInfo>ё;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,long,int,bool>ђ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyDetectedEntityInfo>ѓ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,long,int>є;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,int>ѕ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>і;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>ї
;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>ј;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
ICollection<string>,int,bool>љ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int>њ;private Action<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ћ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>ќ;private Func
<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ѝ;private Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,long,int,bool>ў;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,Vector3D?>џ;private Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,float>Ѡ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ѡ;private Func<MyDefinitionId,float>
Ѣ;private Func<long,bool>ѣ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool>Ѥ;private Func<long,float>ѥ;private
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ѧ;private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ѧ;
private Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,bool>>Ѩ;private Action<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,bool>>ѩ;private Func<ulong,MyTuple<Vector3D,Vector3D,
float,float,long,string>>Ѫ;private Func<long,float>ѫ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ѭ;private Func<
Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ѭ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ѯ;private
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ѯ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,
MyTuple<Vector3D,Vector3D>>Ѱ;private Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,MyTuple<bool,bool>>ѱ;public bool ĕ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ѳ){var ѳ=Ѳ.GetProperty("WcPbAPI")?.As<IReadOnlyDictionary<string,Delegate>>().GetValue(Ѳ);if(ѳ
==null)throw new Exception("WcPbAPI failed to activate");return Ѵ(ѳ);}public bool Ѵ(IReadOnlyDictionary<string,Delegate>ѵ)
{if(ѵ==null)return false;Ѷ(ѵ,"GetCoreWeapons",ref ъ);Ѷ(ѵ,"GetCoreStaticLaunchers",ref ы);Ѷ(ѵ,"GetCoreTurrets",ref ь);Ѷ(ѵ,
"GetBlockWeaponMap",ref э);Ѷ(ѵ,"GetProjectilesLockedOn",ref ю);Ѷ(ѵ,"GetSortedThreats",ref я);Ѷ(ѵ,"GetObstructions",ref ѐ);Ѷ(ѵ,"GetAiFocus",
ref ё);Ѷ(ѵ,"SetAiFocus",ref ђ);Ѷ(ѵ,"GetWeaponTarget",ref ѓ);Ѷ(ѵ,"SetWeaponTarget",ref є);Ѷ(ѵ,"FireWeaponOnce",ref ѕ);Ѷ(ѵ,
"ToggleWeaponFire",ref і);Ѷ(ѵ,"IsWeaponReadyToFire",ref ї);Ѷ(ѵ,"GetMaxWeaponRange",ref ј);Ѷ(ѵ,"GetTurretTargetTypes",ref љ);Ѷ(ѵ,
"SetTurretTargetTypes",ref њ);Ѷ(ѵ,"SetBlockTrackingRange",ref ћ);Ѷ(ѵ,"IsTargetAligned",ref ќ);Ѷ(ѵ,"IsTargetAlignedExtended",ref ѝ);Ѷ(ѵ,
"CanShootTarget",ref ў);Ѷ(ѵ,"GetPredictedTargetPosition",ref џ);Ѷ(ѵ,"GetHeatLevel",ref Ѡ);Ѷ(ѵ,"GetCurrentPower",ref ѡ);Ѷ(ѵ,"GetMaxPower"
,ref Ѣ);Ѷ(ѵ,"HasGridAi",ref ѣ);Ѷ(ѵ,"HasCoreWeapon",ref Ѥ);Ѷ(ѵ,"GetOptimalDps",ref ѥ);Ѷ(ѵ,"GetActiveAmmo",ref Ѧ);Ѷ(ѵ,
"SetActiveAmmo",ref ѧ);Ѷ(ѵ,"MonitorProjectile",ref Ѩ);Ѷ(ѵ,"UnMonitorProjectile",ref ѩ);Ѷ(ѵ,"GetProjectileState",ref Ѫ);Ѷ(ѵ,
"GetConstructEffectiveDps",ref ѫ);Ѷ(ѵ,"GetPlayerController",ref Ѭ);Ѷ(ѵ,"GetWeaponAzimuthMatrix",ref ѭ);Ѷ(ѵ,"GetWeaponElevationMatrix",ref Ѯ);Ѷ(ѵ,
"IsTargetValid",ref ѯ);Ѷ(ѵ,"GetWeaponScope",ref Ѱ);Ѷ(ѵ,"IsInRange",ref ѱ);return true;}private void Ѷ<ѷ>(IReadOnlyDictionary<string,
Delegate>ѵ,string Ƹ,ref ѷ Ѹ)where ѷ:class{if(ѵ==null){Ѹ=null;return;}Delegate ѹ;if(!ѵ.TryGetValue(Ƹ,out ѹ))throw new Exception(
$"{GetType().Name} :: Couldn't find {Ƹ} delegate of type {typeof(ѷ)}");Ѹ=ѹ as ѷ;if(Ѹ==null)throw new Exception(
$"{GetType().Name} :: Delegate {Ƹ} is not type {typeof(ѷ)}, instead it's: {ѹ.GetType()}");}public void ѻ(ICollection<MyDefinitionId>Ѻ)=>ъ?.Invoke(Ѻ);public void Ѽ(ICollection<MyDefinitionId>Ѻ)=>ы?.Invoke(Ѻ);
public void ѽ(ICollection<MyDefinitionId>Ѻ)=>ь?.Invoke(Ѻ);public bool ѿ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ѿ,IDictionary<
string,int>Ѻ)=>э?.Invoke(Ѿ,Ѻ)??false;public MyTuple<bool,int,int>ҁ(long Ҁ)=>ю?.Invoke(Ҁ)??new MyTuple<bool,int,int>();public
void ҋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҋ,IDictionary<MyDetectedEntityInfo,float>Ѻ)=>я?.Invoke(Ҋ,Ѻ);public void Ҍ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҋ,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ѻ)=>ѐ?.Invoke(Ҋ,Ѻ);public
MyDetectedEntityInfo?ҏ(long ҍ,int Ҏ=0)=>ё?.Invoke(ҍ,Ҏ);public bool ґ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҋ,long Ґ,int Ҏ=0)=>ђ?.Invoke(Ҋ,Ґ
,Ҏ)??false;public MyDetectedEntityInfo?Ь(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ=0)=>ѓ?.Invoke(Ғ,ғ);public void Ҕ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,long Ґ,int ғ=0)=>є?.Invoke(Ғ,Ґ,ғ);public void Җ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Ғ,bool ҕ=true,int ғ=0)=>ѕ?.Invoke(Ғ,ҕ,ғ);public void Ҙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,bool җ,bool ҕ,int ғ=0)=>і
?.Invoke(Ғ,җ,ҕ,ғ);public bool қ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ=0,bool ҙ=true,bool Қ=false)=>ї?.Invoke(Ғ,ғ
,ҙ,Қ)??false;public float Ҝ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ)=>ј?.Invoke(Ғ,ғ)??0f;public bool ҝ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ғ,IList<string>Ѻ,int ғ=0)=>љ?.Invoke(Ғ,Ѻ,ғ)??false;public void Ҟ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ғ,IList<string>Ѻ,int ғ=0)=>њ?.Invoke(Ғ,Ѻ,ғ);public void ҟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,float Ĥ)=>ћ?.Invoke(
Ғ,Ĥ);public bool ҡ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,long Ҡ,int ғ)=>ќ?.Invoke(Ғ,Ҡ,ғ)??false;public MyTuple<bool,
Vector3D?>Ң(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,long Ҡ,int ғ)=>ѝ?.Invoke(Ғ,Ҡ,ғ)??new MyTuple<bool,Vector3D?>();public bool
ң(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,long Ҡ,int ғ)=>ў?.Invoke(Ғ,Ҡ,ғ)??false;public Vector3D?Ҥ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Ғ,long Ҡ,int ғ)=>џ?.Invoke(Ғ,Ҡ,ғ)??null;public float ҥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ)=>Ѡ?.
Invoke(Ғ)??0f;public float Ҧ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ)=>ѡ?.Invoke(Ғ)??0f;public float Ҩ(MyDefinitionId ҧ)=>Ѣ?.
Invoke(ҧ)??0f;public bool Ҫ(long ҩ)=>ѣ?.Invoke(ҩ)??false;public bool ҫ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ)=>Ѥ?.Invoke(Ғ)
??false;public float Ҭ(long ҩ)=>ѥ?.Invoke(ҩ)??0f;public string щ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ)=>Ѧ?.
Invoke(Ғ,ғ)??null;public void Ү(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ,string ҭ)=>ѧ?.Invoke(Ғ,ғ,ҭ);public void ү(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ,Action<long,int,ulong,long,Vector3D,bool>ņ)=>Ѩ?.Invoke(Ғ,ғ,ņ);public void Ұ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ,Action<long,int,ulong,long,Vector3D,bool>ņ)=>ѩ?.Invoke(Ғ,ғ,ņ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ҳ(ulong ұ)=>Ѫ?.Invoke(ұ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ҳ(long ҩ)=>ѫ?.Invoke(ҩ)??0f;public long Ҵ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ)=>Ѭ?.Invoke(Ғ)??-1;public
Matrix ǂ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ)=>ѭ?.Invoke(Ғ,ғ)??Matrix.Zero;public Matrix ҵ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ғ,int ғ)=>Ѯ?.Invoke(Ғ,ғ)??Matrix.Zero;public bool ҹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,long Ҷ,bool ҷ,bool Ҹ)=>ѯ?.
Invoke(Ғ,Ҷ,ҷ,Ҹ)??false;public MyTuple<Vector3D,Vector3D>Һ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ғ,int ғ)=>Ѱ?.Invoke(Ғ,ғ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>һ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƾ)=>ѱ?.Invoke(ƾ)??new MyTuple<
bool,bool>();}int Ǵ=0;double Ҽ=0;double ϡ=0;void ă(){Ҽ=0;foreach(IMyTerminalBlock ҽ in Ă){if(ҽ!=null&&ҽ.IsFunctional)Ҽ++;}ϡ=
Math.Round(100*(Ҽ/Ǵ));}enum Ð{
Off, On, NoChange
}enum ȕ{
Off, On, NoChange, OnNoColourChange
}enum Ȇ{
Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
}enum ȉ{
Off, HoldFire, OpenFire, NoChange
}enum Ȍ{
Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
}enum ȏ{
Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
}enum Ȓ{
On, Off, OnMax, NoChange
}enum ȡ{
Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
}enum Ȩ{
Abort, NoChange
}enum ȭ{
Off, On, FillWhenLow, KeepFull,
}enum ȱ{
Closed, Open, NoChange
}
}
internal sealed class A{public double ě{get;private set;}private double Ӂ{get{double ҿ=Ҿ[0];for(int Ʉ=1;Ʉ<Ӏ;Ʉ++){ҿ+=Ҿ[Ʉ]
;}return(ҿ/Ӏ);}}public double Ĝ{get{double ӂ=Ҿ[0];for(int Ʉ=1;Ʉ<Ӏ;Ʉ++){if(Ҿ[Ʉ]>ӂ){ӂ=Ҿ[Ʉ];}}return ӂ;}}public double Ӄ{get
;private set;}public double Ӆ{get{double ӄ=Ҿ[0];for(int Ʉ=1;Ʉ<Ӏ;Ʉ++){if(Ҿ[Ʉ]<ӄ){ӄ=Ҿ[Ʉ];}}return ӄ;}}public int Ӏ{get;}
private double ӆ;private IMyGridProgramRuntimeInfo Ӈ;private double[]Ҿ;private int ӈ=0;public A(IMyGridProgramRuntimeInfo Ӈ,int
Ӊ=300){this.Ӈ=Ӈ;this.Ӄ=Ӈ.LastRunTimeMs;this.Ӏ=MathHelper.Clamp(Ӊ,1,int.MaxValue);this.ӆ=1.0/Ӏ;this.Ҿ=new double[Ӊ];this.Ҿ
[ӈ]=Ӈ.LastRunTimeMs;this.ӈ++;}public void Ě(){ě-=Ҿ[ӈ]*ӆ;ě+=Ӈ.LastRunTimeMs*ӆ;Ҿ[ӈ]=Ӈ.LastRunTimeMs;if(Ӈ.LastRunTimeMs>Ӄ){Ӄ
=Ӈ.LastRunTimeMs;}ӈ++;if(ӈ>=Ӏ){ӈ=0;ě=Ӂ;Ӄ=Ӈ.LastRunTimeMs;}}