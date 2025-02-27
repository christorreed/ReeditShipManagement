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

string Version = "2.1.0 (2025-02-18)";
A B;int C=0;int D=0;int E=0;int F;int G=0;bool H=true;bool I=true;bool J=false;bool K=false;bool L=false;bool M=false;
bool N=false;bool O=false;bool P=false;string Q="";int R=0;int S=0;double T;float U;string V;string W;string X;bool Y=false;
int Z=0;int a=0;bool b;bool c;bool d;public
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
in ú){IMyRadioAntenna ģ=Ħ as IMyRadioAntenna;if(ģ!=null)ģ.HudText=ĥ;}}void ê(){if(!ħ)return;foreach(var ĩ in Ĩ){if(!ĩ.Ī&&!
ĩ.ī)continue;if(n)Echo("Checking "+ĩ.Ĭ);List<ĭ>İ=ĩ.Į.Concat(ĩ.į).ToList();List<ĭ>ı=new List<ĭ>();List<ĭ>Ĳ=new List<ĭ>();
List<ĭ>ĳ=new List<ĭ>();List<ĭ>Ĵ=new List<ĭ>();List<ĭ>ĵ=new List<ĭ>();int Ķ=0;int ķ=0;double ĸ=.97;if(ĩ.Ĺ<1)ĸ=ĩ.Ĺ*.97;foreach
(ĭ ĺ in İ){if(ĺ==null)continue;if(ĺ.Ļ){ķ++;Ķ+=ĺ.ļ;if(ĺ.Ľ<ĸ)ĳ.Add(ĺ);else if(ĩ.Ĺ<1&&ĺ.Ľ>ĩ.Ĺ*1.03)Ĵ.Add(ĺ);if(ĺ.Ľ!=0)Ĳ.Add(
ĺ);}else{ĵ.Add(ĺ);if(ĺ.ļ>0){ı.Add(ĺ);}}}if(ĳ.Count>0){int ľ=(int)(Ķ/ķ);ĳ=ĳ.OrderBy(Ŀ=>Ŀ.ļ).ToList();if(ĩ.ŀ>0){if(n)Echo(
"Loading "+ĩ.Ł.SubtypeId+"...");ı=ı.OrderByDescending(Ŀ=>Ŀ.ļ).ToList();ł(ı,ĳ,ĩ.Ł,-1,ĩ.Ĺ);}else{if(n)Echo("Balancing "+ĩ.Ł.
SubtypeId+"...");Ĳ=Ĳ.OrderByDescending(Ŀ=>Ŀ.ļ).ToList();ł(Ĳ,ĳ,ĩ.Ł,ľ);}}else if(Ĵ.Count>0){if(n)Echo("Unloading "+ĩ.Ł.SubtypeId+
"...");List<ĭ>Ń=new List<ĭ>();if(ı.Count>0)Ń=ı;else Ń=ĵ;ł(Ĵ,Ń,ĩ.Ł,-1,1,ĩ.Ĺ);}else{if(n)Echo("No loading required "+ĩ.Ł.
SubtypeId+"...");}}}void ā(){S=0;foreach(IMyTerminalBlock Ħ in Ā){if(Ħ==null)continue;if(Ħ.IsWorking)S++;}}void ŉ(Ð ń){if(ń==Ð.
NoChange)return;foreach(IMyTerminalBlock Ħ in Ā){if(Ħ==null)continue;try{bool Ņ=Ħ.BlockDefinition.ToString().Contains("ToolCore"
);if(ń==Ð.On||Ņ)Ħ.ApplyAction("OnOff_On");else if(!Ņ)Ħ.ApplyAction("OnOff_Off");if(Ņ){ITerminalAction ņ=Ħ.
GetActionWithName("ToolCore_Shoot_Action");if(ņ!=null){StringBuilder Ň=new StringBuilder();ņ.WriteValue(Ħ,Ň);string ň=Ň.ToString();if(n)
Echo(ň);if(ň=="Active"&&ń==Ð.Off)ņ.Apply(Ħ);else if(ň=="Inactive"&&ń==Ð.On)ņ.Apply(Ħ);}}}catch{if(n)Echo(
"Failed to set aux block "+Ħ.CustomName);}}}IMyShipController đ;List<IMyRadioAntenna>ú=new List<IMyRadioAntenna>();List<IMyBatteryBlock>Ú=new List
<IMyBatteryBlock>();List<IMyCameraBlock>Ċ=new List<IMyCameraBlock>();List<IMyCargoContainer>ü=new List<IMyCargoContainer>
();List<IMyShipConnector>Ĉ=new List<IMyShipConnector>();List<IMyShipController>Ē=new List<IMyShipController>();List<
IMyAirtightHangarDoor>Ŋ=new List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>ŋ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ō=new
List<IMyTerminalBlock>();List<IMyGyro>õ=new List<IMyGyro>();List<IMyProjector>À=new List<IMyProjector>();List<IMyReactor>Ù=
new List<IMyReactor>();List<IMySensorBlock>Č=new List<IMySensorBlock>();List<IMyTerminalBlock>Ć=new List<IMyTerminalBlock>(
);List<IMyGasTank>ë=new List<IMyGasTank>();List<IMyGasTank>ø=new List<IMyGasTank>();List<IMyAirVent>þ=new List<IMyAirVent
>();List<IMyTerminalBlock>Ă=new List<IMyTerminalBlock>();List<IMyConveyorSorter>ß=new List<IMyConveyorSorter>();List<
IMyTerminalBlock>ò=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ó=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Õ=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>Ö=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ç=new List<IMyTerminalBlock>();List<
IMyThrust>Ý=new List<IMyThrust>();List<IMyThrust>ð=new List<IMyThrust>();List<IMyThrust>ō=new List<IMyThrust>();List<IMyThrust>Ŏ=
new List<IMyThrust>();List<IMyProgrammableBlock>ŏ=new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>Ő=new List<
IMyProgrammableBlock>();List<IMyTextPanel>Ą=new List<IMyTextPanel>();List<IMyTextPanel>ő=new List<IMyTextPanel>();List<Œ>Ë=new List<Œ>();
List<IMyLightingBlock>œ=new List<IMyLightingBlock>();List<IMyLightingBlock>Ŕ=new List<IMyLightingBlock>();List<
IMyLightingBlock>ŕ=new List<IMyLightingBlock>();List<IMyLightingBlock>Ŗ=new List<IMyLightingBlock>();List<IMyReflectorLight>ŗ=new List<
IMyReflectorLight>();List<IMyTerminalBlock>Ā=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ř=new List<IMyTerminalBlock>();List<ř>â=
new List<ř>();List<Ś>ä=new List<Ś>();Dictionary<IMyTerminalBlock,string>ś=new Dictionary<IMyTerminalBlock,string>();bool ď(
IMyTerminalBlock Ŝ){try{if(!Me.IsSameConstructAs(Ŝ))return false;string ŝ=Ŝ.GetOwnerFactionTag();if(ŝ!=V&&ŝ!=""){Echo("!"+ŝ+": "+Ŝ.
CustomName);R++;return false;}if(Ŝ.CustomName.Contains(Ş))return false;if(!J&&ş&&!Ŝ.CustomName.Contains(Ę))return false;string Š=Ŝ
.BlockDefinition.ToString();if(Ŝ.CustomName.Contains(š)){Ā.Add(Ŝ);}if(Š.Contains("MedicalRoom/")){if(N)Ŝ.CustomData=X;
else Ŝ.CustomData=W;Ć.Add(Ŝ);if(J)ś.Add(Ŝ,"Medical Room");return false;}if(Š.Contains("SurvivalKit/")){if(N)Ŝ.CustomData=X;
else Ŝ.CustomData=W;Ć.Add(Ŝ);if(J)ś.Add(Ŝ,"Survival Kit");return false;}if(Š==
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
);œ.Clear();Ŕ.Clear();ŕ.Clear();Ŗ.Clear();ŗ.Clear();Ā.Clear();foreach(var ĩ in Ĩ)ĩ.Į.Clear();if(J)ś.Clear();}bool Ũ(
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
Message);}}}double Ǉ=0;double ǈ=0;double ǉ=0;void ý(){ǈ=0;foreach(IMyCargoContainer Ǌ in ü){if(Ǌ!=null&&!Ǌ.Closed&&Ǌ.
IsFunctional){try{ǈ+=Ǌ.GetInventory().MaxVolume.RawValue;}catch(Exception Ė){if(n)Echo("Cargo integrity error!\n"+Ė.Message);throw Ė
;}}}ǉ=Math.Round(100*(ǈ/Ǉ));}void ǋ(){Ǉ=0;foreach(IMyCargoContainer Ǌ in ü){if(Ǌ!=null)Ǉ+=Ǌ.GetInventory().MaxVolume.
RawValue;}}MyIni ǌ=new MyIni();bool ş=false;bool ħ=true;bool Ǎ=true;bool ǎ=true;bool Ǐ=true;bool ǐ=false;string Ǒ="";bool ǒ=true
;int Ǔ=3;int ǔ=6;string Ş="[I]";string ţ="[RSM]";string ŧ="[CS]";string š="Autorepair";string Ɯ="Repel";string Ǖ="Min";
string ǖ="Docking";string Ÿ="Nav";string ſ="Airlock";string Ǘ="[EFC]";string ǘ="[NavOS]";char Ů='.';bool Ɲ=true;bool ŭ=true;
List<string>Ǚ=new List<string>();bool ǚ=false;bool Ŧ=false;bool Ǜ=true;List<double>h=new List<double>();bool ǜ=false;double
ǝ=0.5;bool n=false;bool Ç=false;int È=0;int f=100;string Ę="";bool ȶ(){string ƥ=Me.CustomData;string Ʀ="";bool Ǟ=true;
MyIniParseResult Ʃ;if(!ǌ.TryParse(ƥ,out Ʃ)){string[]ǟ=ƥ.Split('\n');if(ǟ[1]=="Reedit Ship Management"){Echo("Legacy config detected...")
;Ǡ(ƥ);return false;}else{Echo("Could not parse custom data!\n"+Ʃ.ToString());return false;}}try{Ʀ="RSM.Main";Echo(Ʀ);ş=ǌ.
Get(Ʀ,"RequireShipName").ToBoolean(ş);ħ=ǌ.Get(Ʀ,"EnableAutoload").ToBoolean(ħ);Ǎ=ǌ.Get(Ʀ,"AutoloadReactors").ToBoolean(Ǎ);ǎ
=ǌ.Get(Ʀ,"AutoConfigWeapons").ToBoolean(ǎ);Ǐ=ǌ.Get(Ʀ,"SetTurretFireMode").ToBoolean(Ǐ);Ʀ="RSM.Spawns";Echo(Ʀ);ǐ=ǌ.Get(Ʀ,
"PrivateSpawns").ToBoolean(ǐ);Ǒ=ǌ.Get(Ʀ,"FriendlyTags").ToString(Ǒ);Ʀ="RSM.Doors";Echo(Ʀ);ǒ=ǌ.Get(Ʀ,"EnableDoorManagement").ToBoolean(ǒ
);Ǔ=ǌ.Get(Ʀ,"DoorCloseTimer").ToInt32(Ǔ);Ǔ=ǌ.Get(Ʀ,"AirlockDoorDisableTimer").ToInt32(Ǔ);Ʀ="RSM.Keywords";Echo(Ʀ);Ş=ǌ.Get
(Ʀ,"Ignore").ToString(Ş);ţ=ǌ.Get(Ʀ,"RsmLcds").ToString(ţ);ŧ=ǌ.Get(Ʀ,"ColourSyncLcds").ToString(ŧ);š=ǌ.Get(Ʀ,
"AuxiliaryBlocks").ToString(š);Ɯ=ǌ.Get(Ʀ,"DefensivePdcs").ToString(Ɯ);Ǖ=ǌ.Get(Ʀ,"MinimumThrusters").ToString(Ǖ);ǖ=ǌ.Get(Ʀ,
"DockingThrusters").ToString(ǖ);Ÿ=ǌ.Get(Ʀ,"NavLights").ToString(Ÿ);ſ=ǌ.Get(Ʀ,"Airlock").ToString(ſ);Ʀ="RSM.InitNaming";Echo(Ʀ);string ǡ=ǌ.
Get(Ʀ,"NameDelimiter").ToString(Ů.ToString());int Ǣ=0;if(ǡ.Length>1)Ǣ=1;Ů=char.Parse(ǡ.Substring(Ǣ,1));Ɲ=ǌ.Get(Ʀ,
"NameWeaponTypes").ToBoolean(Ɲ);ŭ=ǌ.Get(Ʀ,"NameDriveTypes").ToBoolean(ŭ);string ǣ=ǌ.Get(Ʀ,"BlocksToNumber").ToString("");string[]Ǥ=ǣ.
Split(',');Ǚ.Clear();foreach(string Ƹ in Ǥ)if(Ƹ!="")Ǚ.Add(Ƹ);Ʀ="RSM.Misc";Echo(Ʀ);ǚ=ǌ.Get(Ʀ,"DisableLightingControl").
ToBoolean(ǚ);Ŧ=ǌ.Get(Ʀ,"DisableLcdColourControl").ToBoolean(Ŧ);Ǜ=ǌ.Get(Ʀ,"ShowBasicTelemetry").ToBoolean(Ǜ);string ǥ=ǌ.Get(Ʀ,
"DecelerationPercentages").ToString("");string[]Ǧ=ǥ.Split(',');if(Ǧ.Length>1){h.Clear();foreach(string ǧ in Ǧ){h.Add(double.Parse(ǧ)/100);}}ǜ=ǌ.
Get(Ʀ,"ShowThrustInMetric").ToBoolean(ǜ);ǝ=ǌ.Get(Ʀ,"ReactorFillRatio").ToDouble(ǝ);Ĩ[0].Ĺ=ǝ;Ʀ="RSM.Debug";Echo(Ʀ);n=ǌ.Get(Ʀ
,"VerboseDebugging").ToBoolean(n);Ç=ǌ.Get(Ʀ,"RuntimeProfiling").ToBoolean(Ç);f=ǌ.Get(Ʀ,"BlockRefreshFreq").ToInt32(f);È=ǌ
.Get(Ʀ,"StallCount").ToInt32(È);Ʀ="RSM.System";Echo(Ʀ);Ę=ǌ.Get(Ʀ,"ShipName").ToString(Ę);Ʀ="RSM.InitItems";Echo(Ʀ);
foreach(ĩ Ǩ in Ĩ){Ǩ.ǩ=ǌ.Get(Ʀ,Ǩ.Ł.SubtypeId).ToInt32(Ǩ.ǩ);}Ʀ="RSM.InitSubSystems";Echo(Ʀ);Ǫ=ǌ.Get(Ʀ,"Reactors").ToDouble(Ǫ);ǫ=ǌ
.Get(Ʀ,"Batteries").ToDouble(ǫ);Ǭ=ǌ.Get(Ʀ,"Pdcs").ToInt32(Ǭ);ǭ=ǌ.Get(Ʀ,"TorpLaunchers").ToInt32(ǭ);Ǯ=ǌ.Get(Ʀ,
"KineticWeapons").ToInt32(Ǯ);ǯ=ǌ.Get(Ʀ,"H2Storage").ToDouble(ǯ);ǰ=ǌ.Get(Ʀ,"O2Storage").ToDouble(ǰ);Ǳ=ǌ.Get(Ʀ,"MainThrust").ToSingle(Ǳ);ǲ
=ǌ.Get(Ʀ,"RCSThrust").ToSingle(ǲ);ǳ=ǌ.Get(Ʀ,"Gyros").ToDouble(ǳ);Ǉ=ǌ.Get(Ʀ,"CargoStorage").ToDouble(Ǉ);Ǵ=ǌ.Get(Ʀ,
"Welders").ToInt32(Ǵ);}catch(Exception Ė){ǵ(Ė,"Failed to parse section\n"+Ʀ);}Echo("Parsing stances...");Dictionary<string,Ƕ>Ƿ=
new Dictionary<string,Ƕ>();List<string>Ǹ=new List<string>();ǌ.GetSections(Ǹ);foreach(string ǹ in Ǹ){if(ǹ.Contains(
"RSM.Stance.")){string Ǻ=ǹ.Substring(11);Echo(Ǻ);Ƕ ǻ=new Ƕ();string Ǽ,ǽ="";string[]Ǿ;int ǿ=33,Ȁ=144,Ŝ=255,Ŀ=255;bool ȁ=false;Ƕ Ȃ=null
;ǽ="Inherits";if(ǌ.ContainsKey(ǹ,ǽ)){ȁ=true;try{Ȃ=Ƿ[ǌ.Get(ǹ,ǽ).ToString()];Echo("Inherits "+ǌ.Get(ǹ,ǽ).ToString());}catch
(Exception Ė){ǵ(Ė,"Failed to find inheritee for\n"+ǹ+"\nEnsure inheritee stances are\nlisted before their heirs");}}try{
if(ȁ)Echo(Ȃ.ȃ.ToString());ǽ="Torps";if(ǌ.ContainsKey(ǹ,ǽ)){ǻ.ȃ=(Ȅ)Enum.Parse(typeof(Ȅ),ǌ.Get(ǹ,ǽ).ToString());}else if(ȁ){
ǻ.ȃ=Ȃ.ȃ;}else{ǻ.ȃ=ȅ;}ǽ="Pdcs";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȇ=(ȇ)Enum.Parse(typeof(ȇ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ȇ=Ȃ.Ȇ;
else ǻ.Ȇ=Ȉ;ǽ="Kinetics";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȉ=(Ȋ)Enum.Parse(typeof(Ȋ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȉ=Ȃ.ȉ;else ǻ.ȉ=
ȋ;ǽ="MainThrust";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȍ=(ȍ)Enum.Parse(typeof(ȍ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ȍ=Ȃ.Ȍ;else ǻ.Ȍ=Ȏ;ǽ=
"ManeuveringThrust";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȏ=(Ȑ)Enum.Parse(typeof(Ȑ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȏ=Ȃ.ȏ;else ǻ.ȏ=ȑ;ǽ="Spotlights";if
(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȓ=(ȓ)Enum.Parse(typeof(ȓ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ȓ=Ȃ.Ȓ;else ǻ.Ȓ=Ȕ;ǽ="ExteriorLights";if
(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȕ=(Ȗ)Enum.Parse(typeof(Ȗ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȕ=Ȃ.ȕ;else ǻ.ȕ=ȗ;ǽ=
"ExteriorLightColour";if(ǌ.ContainsKey(ǹ,ǽ)){Ǽ=ǌ.Get(ǹ,ǽ).ToString();Ǿ=Ǽ.Split(',');ǿ=int.Parse(Ǿ[0]);Ȁ=int.Parse(Ǿ[1]);Ŝ=int.Parse(Ǿ[2]);Ŀ=
int.Parse(Ǿ[3]);ǻ.Ș=new Color(ǿ,Ȁ,Ŝ,Ŀ);}else if(ȁ)ǻ.Ș=Ȃ.Ș;else ǻ.Ș=ș;ǽ="InteriorLights";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ț=(Ȗ)Enum.
Parse(typeof(Ȗ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ț=Ȃ.Ț;else ǻ.Ț=ț;ǽ="InteriorLightColour";if(ǌ.ContainsKey(ǹ,ǽ)){Ǽ=ǌ.Get(ǹ,
ǽ).ToString();Ǿ=Ǽ.Split(',');ǿ=int.Parse(Ǿ[0]);Ȁ=int.Parse(Ǿ[1]);Ŝ=int.Parse(Ǿ[2]);Ŀ=int.Parse(Ǿ[3]);ǻ.Ȝ=new Color(ǿ,Ȁ,Ŝ,
Ŀ);}else if(ȁ)ǻ.Ȝ=Ȃ.Ȝ;else ǻ.Ȝ=ȝ;ǽ="NavLights";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȟ=(Ȗ)Enum.Parse(typeof(Ȗ),ǌ.Get(ǹ,ǽ).ToString());
else if(ȁ)ǻ.Ȟ=Ȃ.Ȟ;else ǻ.Ȟ=ȟ;ǽ="LcdTextColour";if(ǌ.ContainsKey(ǹ,ǽ)){Ǽ=ǌ.Get(ǹ,ǽ).ToString();Ǿ=Ǽ.Split(',');ǿ=int.Parse(Ǿ[0
]);Ȁ=int.Parse(Ǿ[1]);Ŝ=int.Parse(Ǿ[2]);Ŀ=int.Parse(Ǿ[3]);ǻ.Ƞ=new Color(ǿ,Ȁ,Ŝ,Ŀ);}else if(ȁ)ǻ.Ƞ=Ȃ.Ƞ;else ǻ.Ƞ=ȡ;ǽ=
"TanksAndBatteries";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ü=(Ȣ)Enum.Parse(typeof(Ȣ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ü=Ȃ.Ü;else ǻ.Ü=ȣ;ǽ=
"NavOsEfcBurnPercentage";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ȥ=ǌ.Get(ǹ,"NavOsEfcBurnPercentage").ToInt32(ȥ);else if(ȁ)ǻ.Ȥ=Ȃ.Ȥ;else ǻ.Ȥ=ȥ;ǽ="EfcBoost";if(ǌ.
ContainsKey(ǹ,ǽ))ǻ.Ȧ=(Ð)Enum.Parse(typeof(Ð),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ȧ=Ȃ.Ȧ;else ǻ.Ȧ=ȧ;ǽ="NavOsAbortEfcOff";if(ǌ.
ContainsKey(ǹ,ǽ))ǻ.Ȩ=(ȩ)Enum.Parse(typeof(ȩ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ȩ=Ȃ.Ȩ;else ǻ.Ȩ=Ȫ;ǽ="NavOsAbortEfcOff";if(ǌ.
ContainsKey(ǹ,ǽ))ǻ.Ȩ=(ȩ)Enum.Parse(typeof(ȩ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ȩ=Ȃ.Ȩ;else ǻ.Ȩ=Ȫ;ǽ="AuxMode";if(ǌ.ContainsKey(ǹ,ǽ))
ǻ.ȫ=(Ð)Enum.Parse(typeof(Ð),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȫ=Ȃ.ȫ;else ǻ.ȫ=Ȭ;ǽ="Extractor";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȭ=(
Ȯ)Enum.Parse(typeof(Ȯ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȭ=Ȃ.ȭ;else ǻ.ȭ=ȯ;ǽ="KeepAlives";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.Ï=(Ð)
Enum.Parse(typeof(Ð),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.Ï=Ȃ.Ï;else ǻ.Ï=Ȱ;ǽ="HangarDoors";if(ǌ.ContainsKey(ǹ,ǽ))ǻ.ȱ=(Ȳ)Enum.
Parse(typeof(Ȳ),ǌ.Get(ǹ,ǽ).ToString());else if(ȁ)ǻ.ȱ=Ȃ.ȱ;else ǻ.ȱ=ȳ;Ƿ.Add(Ǻ,ǻ);}catch(Exception Ė){ǵ(Ė,
"Failed to parse stance\n"+Ǻ+"\nproperty\n"+ǽ);}}}if(Ƿ.Count<1){Echo("Failed to parse any stances!\nStances reset to default!");Ǟ=false;}else{Echo
("Finished parsing "+Ƿ.Count+" stances.");ȴ=Ƿ;}Ʀ="RSM.Stance";Echo(Ʀ);ę=ǌ.Get(Ʀ,"CurrentStance").ToString(ę);Ƕ ȵ;if(!ȴ.
TryGetValue(ę,out ȵ)){ę="N/A";Î=null;}else Î=ȵ;return Ǟ;}void ɂ(){ǌ.Clear();string Ʀ,Ƹ;Ʀ="RSM.Main";Ƹ="RequireShipName";ǌ.Set(Ʀ,Ƹ,ş
);ǌ.SetComment(Ʀ,Ƹ,"limit to blocks with the ship name in their name");Ƹ="EnableAutoload";ǌ.Set(Ʀ,Ƹ,ħ);ǌ.SetComment(Ʀ,Ƹ,
"enable RSM loading & balancing functionality for weapons");Ƹ="AutoloadReactors";ǌ.Set(Ʀ,Ƹ,Ǎ);ǌ.SetComment(Ʀ,Ƹ,"enable loading and balancing for reactors");Ƹ="AutoConfigWeapons";
ǌ.Set(Ʀ,Ƹ,ǎ);ǌ.SetComment(Ʀ,Ƹ,"automatically configure weapon on stance set");Ƹ="SetTurretFireMode";ǌ.Set(Ʀ,Ƹ,Ǐ);ǌ.
SetComment(Ʀ,Ƹ,"set turret fire mode based on stance");ǌ.SetSectionComment(Ʀ,ȷ+" Reedit Ship Management\n"+ȷ+
" Config.ini\n Recompile to apply changes!\n"+ȷ);Ʀ="RSM.Spawns";Ƹ="PrivateSpawns";ǌ.Set(Ʀ,Ƹ,ǐ);ǌ.SetComment(Ʀ,Ƹ,"don't inject faction tag into spawn custom data");Ƹ=
"FriendlyTags";ǌ.Set(Ʀ,Ƹ,Ǒ);ǌ.SetComment(Ʀ,Ƹ,"Comma seperated friendly factions or steam ids");Ʀ="RSM.Doors";Ƹ="EnableDoorManagement";
ǌ.Set(Ʀ,Ƹ,ǒ);ǌ.SetComment(Ʀ,Ƹ,"enable door management functionality");Ƹ="DoorCloseTimer";ǌ.Set(Ʀ,Ƹ,Ǔ);ǌ.SetComment(Ʀ,Ƹ,
"door open timer (x100 ticks)");Ƹ="AirlockDoorDisableTimer";ǌ.Set(Ʀ,Ƹ,ǔ);ǌ.SetComment(Ʀ,Ƹ,"airlock door disable timer (x100 ticks)");Ʀ="RSM.Keywords";
Ƹ="Ignore";ǌ.Set(Ʀ,Ƹ,Ş);ǌ.SetComment(Ʀ,Ƹ,"to identify blocks which RSM should ignore");Ƹ="RsmLcds";ǌ.Set(Ʀ,Ƹ,ţ);ǌ.
SetComment(Ʀ,Ƹ,"to identify RSM lcds");Ƹ="ColourSyncLcds";ǌ.Set(Ʀ,Ƹ,ŧ);ǌ.SetComment(Ʀ,Ƹ,"to identify non RSM lcds for colour sync"
);Ƹ="AuxiliaryBlocks";ǌ.Set(Ʀ,Ƹ,š);ǌ.SetComment(Ʀ,Ƹ,"to identify aux blocks");Ƹ="DefensivePdcs";ǌ.Set(Ʀ,Ƹ,Ɯ);ǌ.SetComment
(Ʀ,Ƹ,"to identify defensive _normalPdcs");Ƹ="MinimumThrusters";ǌ.Set(Ʀ,Ƹ,Ǖ);ǌ.SetComment(Ʀ,Ƹ,
"to identify minimum epsteins");Ƹ="DockingThrusters";ǌ.Set(Ʀ,Ƹ,ǖ);ǌ.SetComment(Ʀ,Ƹ,"to identify docking epsteins");Ƹ="NavLights";ǌ.Set(Ʀ,Ƹ,Ÿ);ǌ.
SetComment(Ʀ,Ƹ,"to identify navigational lights");Ƹ="Airlock";ǌ.Set(Ʀ,Ƹ,ſ);ǌ.SetComment(Ʀ,Ƹ,"to identify airlock doors and vents")
;Ʀ="RSM.InitNaming";Ƹ="NameDelimiter";ǌ.Set(Ʀ,Ƹ,'"'+Ů.ToString()+'"');ǌ.SetComment(Ʀ,Ƹ,"single char delimiter for names")
;Ƹ="NameWeaponTypes";ǌ.Set(Ʀ,Ƹ,Ɲ);ǌ.SetComment(Ʀ,Ƹ,"append type names to all weapons on init");Ƹ="NameDriveTypes";ǌ.Set(Ʀ
,Ƹ,ŭ);ǌ.SetComment(Ʀ,Ƹ,"append type names to all drives on init");string ȸ="";foreach(string ȹ in Ǚ){if(ȸ!="")ȸ+=",";ȸ+=ȹ
;}Ƹ="BlocksToNumber";ǌ.Set(Ʀ,Ƹ,ŭ);ǌ.SetComment(Ʀ,Ƹ,"comma seperated list of block names to be numbered at init");Ʀ=
"RSM.Misc";Ƹ="DisableLightingControl";ǌ.Set(Ʀ,Ƹ,ǚ);ǌ.SetComment(Ʀ,Ƹ,"disable all lighting control");Ƹ="DisableLcdColourControl";ǌ.
Set(Ʀ,Ƹ,Ŧ);ǌ.SetComment(Ʀ,Ƹ,"disable text colour control for all lcds");Ƹ="ShowBasicTelemetry";ǌ.Set(Ʀ,Ƹ,Ǜ);ǌ.SetComment(Ʀ,
Ƹ,"show basic telemetry data on advanced thrust lcds");string Ⱥ="";foreach(double Ȼ in h){if(Ⱥ!="")Ⱥ+=",";Ⱥ+=(Ȼ*100).
ToString();}Ƹ="DecelerationPercentages";ǌ.Set(Ʀ,Ƹ,Ⱥ);ǌ.SetComment(Ʀ,Ƹ,"thrust percentages to show on advanced thrust lcds");Ƹ=
"ShowThrustInMetric";ǌ.Set(Ʀ,Ƹ,ǜ);ǌ.SetComment(Ʀ,Ƹ,"show basic telemetry data on advanced thrust lcds");Ƹ="ReactorFillRatio";ǌ.Set(Ʀ,Ƹ,ǝ);ǌ.
SetComment(Ʀ,Ƹ,"0-1, fill ratio for reactors");Ʀ="RSM.Debug";Ƹ="VerboseDebugging";ǌ.Set(Ʀ,Ƹ,n);ǌ.SetComment(Ʀ,Ƹ,
"prints more logging info to PB details");Ƹ="RuntimeProfiling";ǌ.Set(Ʀ,Ƹ,Ç);ǌ.SetComment(Ʀ,Ƹ,"prints script runtime profiling info to PB details");Ƹ=
"BlockRefreshFreq";ǌ.Set(Ʀ,Ƹ,f);ǌ.SetComment(Ʀ,Ƹ,"ticks x100 between block refreshes");Ƹ="StallCount";ǌ.Set(Ʀ,Ƹ,È);ǌ.SetComment(Ʀ,Ƹ,
"ticks x100 to stall between runs");Ʀ="RSM.Stance";Ƹ="CurrentStance";ǌ.Set(Ʀ,Ƹ,ę);ǌ.SetSectionComment(Ʀ,ȷ+" Stances\n Add or remove as required\n"+ȷ);
string ȼ="Red, Green, Blue, Alpha";foreach(var Ƚ in ȴ){Ʀ="RSM.Stance."+Ƚ.Key;Ƕ Ⱦ=Ƚ.Value;Ƕ Ȃ=null;if(Ⱦ.ȿ!=""){Ȃ=ȴ[Ⱦ.ȿ];Ƹ=
"Inherits";ǌ.Set(Ʀ,Ƹ,Ⱦ.ȿ);ǌ.SetComment(Ʀ,Ƹ,"Use stance of this name as a template for settings");}Ƹ="Torps";if(Ȃ!=null&&Ⱦ.ȃ==Ȃ.ȃ){
if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.ȃ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȅ)));}Ƹ="Pdcs";if(Ȃ!=null&&Ⱦ
.Ȇ==Ȃ.Ȇ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ȇ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(ȇ)));}Ƹ="Kinetics"
;if(Ȃ!=null&&Ⱦ.ȉ==Ȃ.ȉ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.ȉ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȋ)))
;}Ƹ="MainThrust";if(Ȃ!=null&&Ⱦ.Ȍ==Ȃ.Ȍ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ȍ.ToString());ǌ.SetComment(Ʀ
,"MainThrust",ɀ(typeof(ȍ)));}Ƹ="ManeuveringThrust";if(Ȃ!=null&&Ⱦ.ȏ==Ȃ.ȏ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(
Ʀ,Ƹ,Ⱦ.ȏ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȑ)));}Ƹ="Spotlights";if(Ȃ!=null&&Ⱦ.Ȓ==Ȃ.Ȓ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ
,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ȓ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(ȓ)));}Ƹ="ExteriorLights";if(Ȃ!=null&&Ⱦ.ȕ==Ȃ.ȕ){if(ǌ.
ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.ȕ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȗ)));}Ƹ="ExteriorLightColour";if(Ȃ!=null&&
Ⱦ.Ș==Ȃ.Ș){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ɂ(Ⱦ.Ș));ǌ.SetComment(Ʀ,Ƹ,ȼ);}Ƹ="InteriorLights";if(Ȃ!=null
&&Ⱦ.Ț==Ȃ.Ț){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ț.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȗ)));}Ƹ=
"InteriorLightColour";if(Ȃ!=null&&Ⱦ.Ȝ==Ȃ.Ȝ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ɂ(Ⱦ.Ȝ));ǌ.SetComment(Ʀ,Ƹ,ȼ);}Ƹ="NavLights";if
(Ȃ!=null&&Ⱦ.Ȟ==Ȃ.Ȟ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ȟ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȗ)));}Ƹ
="LcdTextColour";if(Ȃ!=null&&Ⱦ.Ƞ==Ȃ.Ƞ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ɂ(Ⱦ.Ƞ));ǌ.SetComment(Ʀ,Ƹ,ȼ);}Ƹ
="TanksAndBatteries";if(Ȃ!=null&&Ⱦ.Ü==Ȃ.Ü){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ü.ToString());ǌ.
SetComment(Ʀ,Ƹ,ɀ(typeof(Ȣ)));}Ƹ="NavOsEfcBurnPercentage";if(Ȃ!=null&&Ⱦ.Ȥ==Ȃ.Ȥ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ
,Ⱦ.Ȥ.ToString());ǌ.SetComment(Ʀ,Ƹ,"Burn % 0-100, -1 for no change");}Ƹ="EfcBoost";if(Ȃ!=null&&Ⱦ.Ȧ==Ȃ.Ȧ){if(ǌ.ContainsKey(
Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ȧ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ð)));}Ƹ="NavOsAbortEfcOff";if(Ȃ!=null&&Ⱦ.Ȩ==
Ȃ.Ȩ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ȩ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(ȩ)));}Ƹ="AuxMode";if(Ȃ
!=null&&Ⱦ.ȫ==Ȃ.ȫ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.ȫ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ð)));}Ƹ=
"Extractor";if(Ȃ!=null&&Ⱦ.ȭ==Ȃ.ȭ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.ȭ.ToString());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȯ))
);}Ƹ="KeepAlives";if(Ȃ!=null&&Ⱦ.Ï==Ȃ.Ï){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.Ï.ToString());ǌ.SetComment(
Ʀ,Ƹ,ɀ(typeof(Ð)));}Ƹ="HangarDoors";if(Ȃ!=null&&Ⱦ.ȱ==Ȃ.ȱ){if(ǌ.ContainsKey(Ʀ,Ƹ))ǌ.Delete(Ʀ,Ƹ);}else{ǌ.Set(Ʀ,Ƹ,Ⱦ.ȱ.ToString
());ǌ.SetComment(Ʀ,Ƹ,ɀ(typeof(Ȳ)));}}Ʀ="RSM.System";Ƹ="ShipName";ǌ.Set(Ʀ,Ƹ,Ę);ǌ.SetSectionComment(Ʀ,ȷ+
" System\n All items below this point are\n set automatically when running init\n"+ȷ);Ʀ="RSM.InitItems";foreach(ĩ Ǩ in Ĩ){Ƹ=Ǩ.Ł.SubtypeId;ǌ.Set(Ʀ,Ƹ,Ǩ.ǩ);}Ʀ="RSM.InitSubSystems";ǌ.Set(Ʀ,"Reactors",Ǫ);ǌ.
Set(Ʀ,"Batteries",ǫ);ǌ.Set(Ʀ,"Pdcs",Ǭ);ǌ.Set(Ʀ,"TorpLaunchers",ǭ);ǌ.Set(Ʀ,"KineticWeapons",Ǯ);ǌ.Set(Ʀ,"H2Storage",ǯ);ǌ.Set(
Ʀ,"O2Storage",ǰ);ǌ.Set(Ʀ,"MainThrust",Ǳ);ǌ.Set(Ʀ,"RCSThrust",ǲ);ǌ.Set(Ʀ,"Gyros",ǳ);ǌ.Set(Ʀ,"CargoStorage",Ǉ);ǌ.Set(Ʀ,
"Welders",Ǵ);Me.CustomData=ǌ.ToString();}void Ǡ(string ƥ){string[]Ǹ=ƥ.Split(new string[]{"[Stances]"},StringSplitOptions.None);
string[]Ƀ=Ǹ[0].Split('\n');string Ʉ=Ǹ[1];try{for(int Ʌ=1;Ʌ<Ƀ.Length;Ʌ++){if(Ƀ[Ʌ].Contains("=")){string Ɇ=Ƀ[Ʌ].Substring(1);
switch(Ƀ[(Ʌ-1)]){case"Ship name. Blocks without this name will be ignored":Ę=Ɇ;break;case
"Block name delimiter, used by init. One character only!":Ů=char.Parse(Ɇ.Substring(0,1));break;case"Keyword used to identify RSM _allLcds.":ţ=Ɇ;break;case
"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":š=Ɇ;break;case"Keyword used to identify defence _normalPdcs.":Ɯ=Ɇ;break
;case"Keyword used to identify minimum epstein drives.":Ǖ=Ɇ;break;case"Keyword used to identify docking epstein drives.":
ǖ=Ɇ;break;case"Keyword to ignore block.":Ş=Ɇ;break;case"Automatically configure _normalPdcs, Railguns, Torpedoes.":ǎ=bool
.Parse(Ɇ);break;case"Disable lighting all control.":ǚ=bool.Parse(Ɇ);break;case"Disable LCD Text Colour Enforcement.":Ŧ=
bool.Parse(Ɇ);break;case"Enable Weapon Autoload Functionality.":ħ=bool.Parse(Ɇ);break;case"Number these blocks at init.":Ǚ.
Clear();string[]ɇ=Ɇ.Split(',');foreach(string ȹ in ɇ){if(ȹ!="")Ǚ.Add(ȹ);}break;case"Show basic telemetry.":Ǜ=bool.Parse(Ɇ);
break;case"Show Decel Percentages (comma seperated).":h.Clear();string[]Ɉ=Ɇ.Split(',');foreach(string Ȼ in Ɉ){h.Add(double.
Parse(Ȼ)/100);}break;case"Fusion Fuel count":Ĩ[0].ǩ=int.Parse(Ɇ);break;case"Fuel tank count":Ĩ[1].ǩ=int.Parse(Ɇ);break;case
"Jerry can count":Ĩ[2].ǩ=int.Parse(Ɇ);break;case"40mm PDC Magazine count":Ĩ[3].ǩ=int.Parse(Ɇ);break;case
"40mm Teflon Tungsten PDC Magazine count":Ĩ[4].ǩ=int.Parse(Ɇ);break;case"220mm Torpedo count":case"Torpedo count":Ĩ[5].ǩ=int.Parse(Ɇ);break;case
"220mm MCRN torpedo count":Ĩ[6].ǩ=int.Parse(Ɇ);break;case"220mm UNN torpedo count":Ĩ[7].ǩ=int.Parse(Ɇ);break;case"Ramshackle torpedo count":case
"Ramshackle torpedo Count":Ĩ[8].ǩ=int.Parse(Ɇ);break;case"Large ramshacke torpedo count":Ĩ[9].ǩ=int.Parse(Ɇ);break;case
"Zako 120mm Railgun rounds count":case"Railgun rounds count":Ĩ[10].ǩ=int.Parse(Ɇ);break;case"Dawson 100mm UNN Railgun rounds count":Ĩ[11].ǩ=int.Parse(Ɇ);
break;case"Stiletto 100mm MCRN Railgun rounds count":Ĩ[12].ǩ=int.Parse(Ɇ);break;case"T-47 80mm Railgun rounds count":Ĩ[13].ǩ=
int.Parse(Ɇ);break;case"Foehammer 120mm MCRN rounds count":Ĩ[14].ǩ=int.Parse(Ɇ);break;case
"Farren 120mm UNN Railgun rounds count":Ĩ[15].ǩ=int.Parse(Ɇ);break;case"Kess 180mm rounds count":Ĩ[16].ǩ=int.Parse(Ɇ);break;case"Steel plate count":Ĩ[17].ǩ=int
.Parse(Ɇ);break;case"Doors open timer (x100 ticks, default 3)":Ǔ=int.Parse(Ɇ);break;case
"Airlock doors disabled timer (x100 ticks, default 6)":ǔ=int.Parse(Ɇ);break;case"Throttle script (x100 ticks pause between loops, default 0)":È=int.Parse(Ɇ);break;case
"Full refresh frequency (x100 ticks, default 50)":f=int.Parse(Ɇ);break;case"Verbose script debugging. Prints more logging info to PB details.":n=bool.Parse(Ɇ);break;case
"Private spawn (don't inject faction tag into SK custom data).":ǐ=bool.Parse(Ɇ);break;case"Comma seperated friendly factions or steam ids for survival kits.":Ǒ=string.Join("\n",Ɇ.
Split(','));break;case"Current Stance":ę=Ɇ;Ƕ ȵ;if(!ȴ.TryGetValue(ę,out ȵ)){ę="N/A";Î=null;}else Î=ȵ;break;case
"Reactor Integrity":Ǫ=float.Parse(Ɇ);break;case"Battery Integrity":ǫ=float.Parse(Ɇ);break;case"PDC Integrity":Ǭ=int.Parse(Ɇ);break;case
"Torpedo Integrity":ǭ=int.Parse(Ɇ);break;case"Railgun Integrity":Ǯ=int.Parse(Ɇ);break;case"H2 Tank Integrity":ǯ=double.Parse(Ɇ);break;case
"O2 Tank Integrity":ǰ=double.Parse(Ɇ);break;case"Epstein Integrity":Ǳ=float.Parse(Ɇ);break;case"RCS Integrity":ǲ=float.Parse(Ɇ);break;case
"Gyro Integrity":ǳ=int.Parse(Ɇ);break;case"Cargo Integrity":Ǉ=double.Parse(Ɇ);break;case"Welder Integrity":Ǵ=int.Parse(Ɇ);break;}}}}
catch(Exception Ė){Echo("Custom Data Error (vars)\n"+Ė.Message);}try{string[]ɉ=Ʉ.Split(new string[]{"Stance:"},
StringSplitOptions.None);if(n)Echo("Parsing "+(ɉ.Length-1)+" stances");int Ɋ=24;Dictionary<string,Ƕ>Ƿ=new Dictionary<string,Ƕ>();int[]ɋ=
new int[]{0,5,25,50,75,100};for(int Ʌ=1;Ʌ<ɉ.Length;Ʌ++){string[]Ɍ=ɉ[Ʌ].Split('=');string Ǻ="";int[]ɍ=new int[Ɋ];Ǻ=Ɍ[0].
Split(' ')[0];if(n)Echo("Parsing '"+Ǻ+"'");for(int Ɏ=0;Ɏ<ɍ.Length;Ɏ++){string[]ɏ=Ɍ[(Ɏ+1)].Split('\n');ɍ[Ɏ]=int.Parse(ɏ[0]);}Ƕ
ǻ=new Ƕ();if(ɍ[0]==0)ǻ.ȃ=Ȅ.Off;else ǻ.ȃ=Ȅ.On;if(ɍ[1]==0)ǻ.Ȇ=ȇ.Off;else if(ɍ[1]==1)ǻ.Ȇ=ȇ.MinDefence;else if(ɍ[1]==2)ǻ.Ȇ=ȇ.
AllDefence;else if(ɍ[1]==3)ǻ.Ȇ=ȇ.Offence;else if(ɍ[1]==4)ǻ.Ȇ=ȇ.AllOnOnly;if(ɍ[2]==0)ǻ.ȉ=Ȋ.Off;else if(ɍ[2]==1)ǻ.ȉ=Ȋ.HoldFire;else
if(ɍ[2]==2)ǻ.ȉ=Ȋ.OpenFire;if(ɍ[3]==0)ǻ.Ȍ=ȍ.Off;else if(ɍ[3]==1)ǻ.Ȍ=ȍ.On;else if(ɍ[3]==2)ǻ.Ȍ=ȍ.Minimum;if(ɍ[4]==0)ǻ.ȏ=Ȑ.Off
;else if(ɍ[4]==1)ǻ.ȏ=Ȑ.On;else if(ɍ[4]==2)ǻ.ȏ=Ȑ.ForwardOff;else if(ɍ[4]==3)ǻ.ȏ=Ȑ.ReverseOff;if(ɍ[5]==0)ǻ.Ȓ=ȓ.Off;else if(
ɍ[5]==1)ǻ.Ȓ=ȓ.On;else if(ɍ[5]==2)ǻ.Ȓ=ȓ.OnMax;if(ɍ[6]==0)ǻ.ȕ=Ȗ.Off;else ǻ.ȕ=Ȗ.On;ǻ.Ș=new Color(ɍ[7],ɍ[8],ɍ[9],ɍ[10]);if(ɍ[
11]==0)ǻ.Ț=Ȗ.Off;else ǻ.Ț=Ȗ.On;ǻ.Ȝ=new Color(ɍ[12],ɍ[13],ɍ[14],ɍ[15]);if(ɍ[16]==0)ǻ.Ü=Ȣ.Auto;else if(ɍ[16]==1)ǻ.Ü=Ȣ.
StockpileRecharge;else if(ɍ[16]==2)ǻ.Ü=Ȣ.Discharge;if(ɍ[17]==0)ǻ.Ȧ=Ð.Off;else ǻ.Ȧ=Ð.On;ǻ.Ȥ=ɋ[ɍ[18]];if(ɍ[19]==0)ǻ.Ȩ=ȩ.NoChange;else ǻ.Ȩ=ȩ
.Abort;if(ɍ[20]==0)ǻ.ȫ=Ð.Off;else ǻ.ȫ=Ð.On;if(ɍ[21]==0)ǻ.ȭ=Ȯ.Off;else if(ɍ[21]==1)ǻ.ȭ=Ȯ.On;else if(ɍ[21]==2)ǻ.ȭ=Ȯ.
FillWhenLow;else if(ɍ[21]==3)ǻ.ȭ=Ȯ.KeepFull;if(ɍ[22]==0)ǻ.Ï=Ð.Off;else ǻ.Ï=Ð.On;if(ɍ[23]==0)ǻ.ȱ=Ȳ.Closed;else if(ɍ[23]==1)ǻ.ȱ=Ȳ.
Open;else ǻ.ȱ=Ȳ.NoChange;Ƿ.Add(Ǻ,ǻ);}if(Ƿ.Count>=1){if(n)Echo("Finished parsing "+Ƿ.Count+" stances.");ȴ=Ƿ;}else{Echo(
"Didn't find any stances!");}}catch(Exception Ė){Echo("Custom Data Error (stances)\n"+Ė.Message);}}void É(){bool ɐ=ȶ();if(!ɐ){ɑ();ɂ();}if(Î==null)
{Î=ȴ.First().Value;}string ɒ="";string ɓ="";if(!ǐ){ɒ=" ".PadRight(129,' ')+V+"\n";ɓ="\n".PadRight(19,'\n');}W=ɒ+ɓ;X=ɒ+
string.Join("\n",Ǒ.Split(','))+ɓ;if(Ę==""){if(n)Echo("No ship name, trying to pull it from PB name...");string ɔ=
"Untitled Ship";try{string[]ɕ=Me.CustomName.Split(Ů);if(ɕ.Length>1){Ę=ɕ[0];if(n)Echo(Ę);}else Ę=ɔ;}catch{Ę=ɔ;}}}void ɗ(bool v=true,bool
ɖ=false,bool s=false){MyIni ƨ=new MyIni();string ƥ=Me.CustomData;MyIniParseResult Ʃ;if(!ƨ.TryParse(ƥ,out Ʃ)){Ã.Add(new Ä(
"CONFIG ERROR!!","Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string Ʀ,Ƹ;if(v){Ʀ="RSM.Stance"
;Ƹ="CurrentStance";ƨ.Set(Ʀ,Ƹ,ę);}else{Ʀ="RSM.System";Ƹ="ShipName";ƨ.Set(Ʀ,Ƹ,Ę);}if(ɖ){Ʀ="RSM.InitSubSystems";ƨ.Set(Ʀ,
"Reactors",Ǫ);ƨ.Set(Ʀ,"Batteries",ǫ);ƨ.Set(Ʀ,"Pdcs",Ǭ);ƨ.Set(Ʀ,"TorpLaunchers",ǭ);ƨ.Set(Ʀ,"KineticWeapons",Ǯ);ƨ.Set(Ʀ,"H2Storage",
ǯ);ƨ.Set(Ʀ,"O2Storage",ǰ);ƨ.Set(Ʀ,"MainThrust",Ǳ);ƨ.Set(Ʀ,"RCSThrust",ǲ);ƨ.Set(Ʀ,"Gyros",ǳ);ƨ.Set(Ʀ,"CargoStorage",Ǉ);ƨ.
Set(Ʀ,"Welders",Ǵ);}if(s){Ʀ="RSM.InitItems";foreach(ĩ Ǩ in Ĩ){Ƹ=Ǩ.Ł.SubtypeId;ƨ.Set(Ʀ,Ƹ,Ǩ.ǩ);}}Me.CustomData=ƨ.ToString();}
string ɀ(Type ɘ){string ə="";foreach(var ɚ in Enum.GetValues(ɘ)){if(ə!="")ə+=", ";ə+=ɚ.ToString();}return ə;}string Ɂ(Color ɛ)
{return ɛ.R+", "+ɛ.G+", "+ɛ.B+", "+ɛ.A;}void ǵ(Exception Ė,string ɜ){Runtime.UpdateFrequency=UpdateFrequency.None;string
ɝ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ɜ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ɝ);List<IMyTextPanel>ɞ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ɞ,Ŝ=>Ŝ.CustomName
.Contains(ţ));foreach(IMyTextPanel ɟ in ɞ){ɟ.WriteText(ɝ);ɟ.FontColor=new Color(193,0,197,255);}throw Ė;}Dictionary<
string,Ƕ>ȴ=new Dictionary<string,Ƕ>();void ɑ(){ȴ=new Dictionary<string,Ƕ>{{"Cruise",new Ƕ{ȃ=Ȅ.On,Ȇ=ȇ.AllDefence,ȉ=Ȋ.HoldFire,Ȍ
=ȍ.EpsteinOnly,ȏ=Ȑ.ForwardOff,Ȓ=ȓ.Off,ȕ=Ȗ.On,Ș=new Color(33,144,255,255),Ț=Ȗ.On,Ȝ=new Color(255,214,170,255),Ȟ=Ȗ.On,Ƞ=new
Color(33,144,255,255),Ü=Ȣ.Auto,Ȥ=50,Ȧ=Ð.NoChange,Ȩ=ȩ.Abort,ȫ=Ð.NoChange,ȭ=Ȯ.KeepFull,Ï=Ð.On,ȱ=Ȳ.NoChange,}},{"StealthCruise",
new Ƕ{ȿ="Cruise",ȃ=Ȅ.On,Ȇ=ȇ.AllDefence,ȉ=Ȋ.HoldFire,Ȍ=ȍ.Minimum,ȏ=Ȑ.ForwardOff,Ȓ=ȓ.Off,ȕ=Ȗ.Off,Ș=new Color(0,0,0,255),Ț=Ȗ.
On,Ȝ=new Color(23,73,186,255),Ȟ=Ȗ.Off,Ƞ=new Color(23,73,186,255),Ü=Ȣ.Auto,Ȥ=5,Ȧ=Ð.Off,Ȩ=ȩ.Abort,ȫ=Ð.NoChange,ȭ=Ȯ.KeepFull,
Ï=Ð.On,ȱ=Ȳ.NoChange}},{"Docked",new Ƕ{ȿ="Cruise",ȃ=Ȅ.On,Ȇ=ȇ.AllDefence,ȉ=Ȋ.HoldFire,Ȍ=ȍ.Off,ȏ=Ȑ.Off,Ȓ=ȓ.Off,ȕ=Ȗ.On,Ș=new
Color(33,144,255,255),Ț=Ȗ.On,Ȝ=new Color(255,240,225,255),Ȟ=Ȗ.On,Ƞ=new Color(255,255,255,255),Ü=Ȣ.StockpileRecharge,Ȥ=-1,Ȧ=Ð.
NoChange,Ȩ=ȩ.Abort,ȫ=Ð.Off,ȭ=Ȯ.On,Ï=Ð.On,ȱ=Ȳ.NoChange}},{"Docking",new Ƕ{ȿ="Docked",ȃ=Ȅ.On,Ȇ=ȇ.AllDefence,ȉ=Ȋ.HoldFire,Ȍ=ȍ.Off,ȏ
=Ȑ.On,Ȓ=ȓ.OnMax,ȕ=Ȗ.On,Ș=new Color(33,144,255,255),Ț=Ȗ.On,Ȝ=new Color(212,170,83,255),Ȟ=Ȗ.On,Ƞ=new Color(212,170,83,255),
Ü=Ȣ.Auto,Ȥ=-1,Ȧ=Ð.NoChange,Ȩ=ȩ.Abort,ȫ=Ð.Off,ȭ=Ȯ.KeepFull,Ï=Ð.On,ȱ=Ȳ.NoChange}},{"NoAttack",new Ƕ{ȿ="Docked",ȃ=Ȅ.Off,Ȇ=ȇ.
Off,ȉ=Ȋ.Off,Ȍ=ȍ.On,ȏ=Ȑ.On,Ȓ=ȓ.Off,ȕ=Ȗ.On,Ș=new Color(255,255,255,255),Ț=Ȗ.On,Ȝ=new Color(84,157,82,255),Ȟ=Ȗ.NoChange,Ƞ=new
Color(84,157,82,255),Ü=Ȣ.NoChange,Ȥ=-1,Ȧ=Ð.NoChange,Ȩ=ȩ.NoChange,ȫ=Ð.NoChange,ȭ=Ȯ.KeepFull,Ï=Ð.On,ȱ=Ȳ.NoChange}},{"Combat",
new Ƕ{ȿ="Cruise",ȃ=Ȅ.On,Ȇ=ȇ.AllDefence,ȉ=Ȋ.OpenFire,Ȍ=ȍ.On,ȏ=Ȑ.On,Ȓ=ȓ.Off,ȕ=Ȗ.Off,Ș=new Color(0,0,0,255),Ț=Ȗ.On,Ȝ=new Color
(210,98,17,255),Ȟ=Ȗ.Off,Ƞ=new Color(210,98,17,255),Ü=Ȣ.ManagedDischarge,Ȥ=100,Ȧ=Ð.On,Ȩ=ȩ.Abort,ȫ=Ð.On,ȭ=Ȯ.KeepFull,Ï=Ð.On
,ȱ=Ȳ.NoChange}},{"CQB",new Ƕ{ȿ="Combat",ȃ=Ȅ.On,Ȇ=ȇ.Offence,ȉ=Ȋ.OpenFire,Ȍ=ȍ.On,ȏ=Ȑ.On,Ȓ=ȓ.Off,ȕ=Ȗ.Off,Ș=new Color(0,0,0,
255),Ț=Ȗ.On,Ȝ=new Color(243,18,18,255),Ȟ=Ȗ.Off,Ƞ=new Color(243,18,18,255),Ü=Ȣ.ManagedDischarge,Ȥ=100,Ȧ=Ð.On,Ȩ=ȩ.Abort,ȫ=Ð.
On,ȭ=Ȯ.KeepFull,Ï=Ð.On,ȱ=Ȳ.NoChange}},{"WeaponsHot",new Ƕ{ȿ="CQB",ȃ=Ȅ.On,Ȇ=ȇ.Offence,ȉ=Ȋ.OpenFire,Ȍ=ȍ.NoChange,ȏ=Ȑ.
NoChange,Ȓ=ȓ.NoChange,ȕ=Ȗ.NoChange,Ș=new Color(0,0,0,255),Ț=Ȗ.NoChange,Ȝ=new Color(243,18,18,255),Ȟ=Ȗ.NoChange,Ƞ=new Color(243,
18,18,255),Ü=Ȣ.ManagedDischarge,Ȥ=-1,Ȧ=Ð.NoChange,Ȩ=ȩ.NoChange,ȫ=Ð.NoChange,ȭ=Ȯ.KeepFull,Ï=Ð.On,ȱ=Ȳ.NoChange}}};}class ř{
public IMyDoor Ħ;public int ɠ=0;public int ɡ=0;public bool Ɓ=false;public bool ɢ=false;}class Ś{public string Ƅ;public bool ɣ=
false;public int ɤ=0;public bool ɥ=false;public List<ř>ƅ=new List<ř>();public List<IMyAirVent>ƈ=new List<IMyAirVent>();}int ɦ
=0;int ɧ=0;int ɨ=0;int ɯ(ř ɩ,bool ƃ=false){bool ɪ=false;bool ɫ=false;if(ɩ.Ħ==null)return 0;bool ɬ=ɩ.Ħ.OpenRatio>0;ɦ++;if(
ɭ(ɩ.Ħ))ɨ++;if(!ƃ||ɬ)ɩ.Ħ.Enabled=true;if(ɬ){if(ɩ.ɠ==0){ɫ=true;}ɩ.ɠ++;if(ɩ.ɠ>=Ǔ){ɩ.ɠ=0;ɩ.Ħ.CloseDoor();ɪ=true;}}else{ɧ++;if
(ɩ.ɠ!=0){ɪ=true;ɩ.ɠ=0;}}int ɮ=0;if(ɪ)ɮ=1;else if(ɫ)ɮ=2;return ɮ;}void å(){if(!ǒ){if(n)Echo("Door management is disabled."
);return;}foreach(Ś ƃ in ä){bool ɰ=false;foreach(ř ɩ in ƃ.ƅ){if(ɩ.Ħ==null)continue;int ɱ=ɯ(ɩ,true);if(ɱ==1){if(n)Echo(
"Airlock door "+ɩ.Ħ.CustomName+" just closed");if(ƃ.ɥ)ƃ.ɥ=false;else{ƃ.ɣ=true;ɩ.ɢ=true;if(n)Echo("Airlock "+ƃ.Ƅ+" needs to cycle");}}
else if(ɱ==2){if(n)Echo("Airlock door "+ɩ.Ħ.CustomName+" just opened");ɰ=true;}}bool ɲ=true;if(ƃ.ɣ){foreach(ř ɩ in ƃ.ƅ){if(ɩ
.Ħ==null)continue;if(ɩ.Ħ.OpenRatio>0){ɩ.Ħ.CloseDoor();ɲ=false;}else ɩ.Ħ.Enabled=false;}bool ɳ=false;foreach(IMyAirVent ɴ
in ƃ.ƈ){if(ɴ==null)continue;if(!ɴ.Enabled)ɴ.Enabled=true;if(!ɴ.Depressurize)ɴ.Depressurize=true;if(ɴ.CanPressurize&&ɴ.
GetOxygenLevel()<.01&&ƃ.ɣ&&ɲ)ɳ=true;}ƃ.ɤ++;bool ɵ=true;if(ƃ.ɤ>=ǔ){ɵ=false;ɳ=true;}if(ɳ){ƃ.ɣ=false;ƃ.ɤ=0;ƃ.ɥ=true;foreach(ř ɩ in ƃ.ƅ){
if(ɩ.Ħ==null)continue;ɩ.Ħ.Enabled=true;if(ɩ.ɢ)ɩ.ɢ=false;else if(ɵ)ɩ.Ħ.OpenDoor();}}}else if(ɰ){foreach(ř ɩ in ƃ.ƅ){if(ɩ.Ħ
==null)continue;if(ɩ.Ħ.OpenRatio==0)ɩ.Ħ.Enabled=false;}}else{foreach(ř ɩ in ƃ.ƅ){ɩ.Ħ.Enabled=true;}}}}void ã(){if(!ǒ){if(n
)Echo("Door management is disabled.");return;}ɦ=0;ɧ=0;ɨ=0;foreach(ř ɩ in â)ɯ(ɩ);}void ɷ(Ȳ ń){if(ń==Ȳ.NoChange)return;
foreach(IMyAirtightHangarDoor ɶ in Ŋ){if(ɶ==null)continue;if(ń==Ȳ.Closed)ɶ.CloseDoor();else ɶ.OpenDoor();}}void z(string ɸ,
string ɹ){ɸ=ɸ.ToLower();foreach(ř ɩ in â){if(ɹ==""||ɩ.Ħ.CustomName.Contains(ɹ)){bool ɺ=ɭ(ɩ.Ħ);if(ɺ&&(ɸ=="locked"||ɸ=="toggle")
)ɩ.Ħ.ApplyAction("AnyoneCanUse");if(!ɺ&&(ɸ=="unlocked"||ɸ=="toggle"))ɩ.Ħ.ApplyAction("AnyoneCanUse");}}}bool ɭ(IMyDoor ɩ)
{var ņ=ɩ.GetActionWithName("AnyoneCanUse");StringBuilder ɻ=new StringBuilder();ņ.WriteValue(ɩ,ɻ);return(ɻ.ToString()==
"On");}double ɼ;int ɽ=10;double ɾ=3;double ɿ=245000;double ʀ=50000;double ʁ=100;void ʃ(Ȯ ń){foreach(IMyTerminalBlock ʂ in ŋ)
{if(ʂ==null)continue;if(ń==Ȯ.Off)ʂ.ApplyAction("OnOff_Off");else ʂ.ApplyAction("OnOff_On");}}void Đ(){if(ŋ.Count<1&&Ō.
Count>0)ɼ=(ɾ*ʀ);else ɼ=(ɾ*ɿ);}void í(){if(Î.ȭ==Ȯ.Off||Î.ȭ==Ȯ.On){if(n)Echo("Extractor management disabled.");}else if(ë.Count
<1){if(n)Echo("No tanks!");}else if(Î.ȭ==Ȯ.FillWhenLow&&ʁ<ɽ){M=true;if(n)Echo("Fuel low! ("+ʁ+"% / "+ɽ+"%)");}else if(Î.ȭ
==Ȯ.KeepFull&&ʄ<(ʅ-ɼ)){M=true;if(n)Echo("Fuel ready for top up ("+ʄ+" < "+(ʅ-ɼ)+")");}else if(n){Echo("Fuel level OK ("+ʁ+
"%).");if(Î.ȭ==Ȯ.KeepFull)Echo("Keeping tanks full\n("+ʄ+" < "+(ʅ-ɼ)+")");}}void î(){M=false;IMyTerminalBlock ʆ=null;int ĩ=1;
foreach(IMyTerminalBlock ʂ in ŋ){if(ʂ.IsFunctional){ʆ=ʂ;break;}}if(ʆ==null||Ĩ[ĩ].ʇ<1){ĩ=2;foreach(IMyTerminalBlock ʂ in Ō){if(ʂ
.IsFunctional){ʆ=ʂ;ĩ=2;if(Ĩ[ĩ].ʇ<1)break;}}if(ʆ==null){P=true;return;}}P=false;if(Ĩ[ĩ].ʇ<1){Q=Ĩ[ĩ].Ĭ;return;}Q="";ĭ ĺ=new
ĭ();ĺ.Ħ=ʆ;ĺ.ĺ=ʆ.GetInventory();if(ĺ.ĺ.VolumeFillFactor>0){if(n)Echo("Extractor already loaded, waiting...");ʆ.ApplyAction
("OnOff_On");return;}List<ĭ>ʈ=new List<ĭ>();ʈ.Add(ĺ);if(n)Echo("Attempting to load extractor "+ʆ.CustomName);bool Ǟ=ł(Ĩ[ĩ
].Į,ʈ,Ĩ[ĩ].Ł,1);string Ơ="fuel tank";if(ĩ==2)Ơ="jerry can";if(Ǟ)Ã.Add(new Ä("Loaded a "+Ơ,"Sucessfully loaded a "+Ơ+
" into an extractor.",0));}double ǳ=0;int ʉ=0;double ʊ=0;void ö(bool ʋ,bool ʌ){ʉ=0;foreach(IMyGyro ʍ in õ){if(ʍ!=null&&ʍ.IsFunctional){ʉ++;if
(ʌ)ʍ.Enabled=ʋ;}}ʊ=Math.Round(100*(ʉ/ǳ));}void u(string ʎ,bool q=true,bool r=true,bool s=true){if(n)Echo(
"Initialising a ship as '"+ʎ+"'...");J=true;Ę=ʎ;d=q;b=r;c=s;Ê();}void Ê(){switch(G){case 0:Ñ();F=0;if(Ç)Echo("Took "+e());break;case 1:é();if(Ç)
Echo("Took "+e());break;case 2:if(n)Echo("Initialising lcds...");ʏ();if(b){if(n)Echo("Initialising subsystem values...");ʐ()
;ʑ();ʒ();ʓ();ʔ();ʕ();ǋ();Ǭ=ò.Count+ó.Count;ǭ=ç.Count;Ǯ=Õ.Count;ǳ=õ.Count;Ǵ=Ă.Count;}if(c){if(n)Echo(
"Initialising item values...");ʖ();}if(d){if(n)Echo("Initialising block names...");ʗ();}ɗ(false,b,c);Ã.Add(new Ä("Init:"+Ę,"Initialised '"+Ę+
"'\nGood Hunting!",3));G=0;J=false;if(Ç)Echo("Took "+e());return;}G++;}class ʛ{public int ʘ=0;public int ʙ=0;public int ʚ=0;}void ʗ(){
Dictionary<string,ʛ>ʜ=new Dictionary<string,ʛ>();if(Ǚ.Count>0){foreach(string ʝ in Ǚ){if(n)Echo("Numbering "+ʝ);ʜ.Add(ʝ,new ʛ());}
foreach(var ʟ in ś){ʛ ʞ;if(ʜ.TryGetValue(ʟ.Value,out ʞ)){ʜ[ʟ.Value].ʙ++;}}foreach(var ʠ in ʜ){if(ʠ.Value.ʙ<10)ʠ.Value.ʚ=1;else
if(ʠ.Value.ʙ>99)ʠ.Value.ʚ=3;else ʠ.Value.ʚ=2;}}foreach(var ʟ in ś){string ʡ="";string ʢ=ʟ.Value;ʛ ʣ;if(ʜ.TryGetValue(ʟ.
Value,out ʣ)){if(ʣ.ʙ>1){ʣ.ʘ++;ʡ=Ů+ʣ.ʘ.ToString().PadLeft(ʣ.ʚ,'0');}}ʟ.Key.CustomName=Ę+Ů+ʢ+ʡ+ʤ(ʟ.Key.CustomName,ʢ);}}string ʤ
(string Ƹ,string ʥ=""){try{string[]ʦ=Ƹ.Split(Ů);string[]ʧ=ʥ.Split(Ů);string Ʃ="";if(ʦ.Length<3)return"";for(int Ʌ=2;Ʌ<ʦ.
Length;Ʌ++){int ʨ=0;bool ʩ=int.TryParse(ʦ[Ʌ],out ʨ);if(ʩ)ʦ[Ʌ]="";foreach(string ʪ in ʧ){if(ʪ==ʦ[Ʌ])ʦ[Ʌ]="";}if(ʦ[Ʌ]!="")Ʃ+=Ů+ʦ
[Ʌ];}return Ʃ;}catch{return"";}}class ĭ{public IMyTerminalBlock Ħ{get;set;}public IMyInventory ĺ{get;set;}List<
MyInventoryItem>ʫ=new List<MyInventoryItem>();public int ļ=0;public bool Ļ=false;public float Ľ;}class ĩ{public int ʇ=0;public int ǩ=0;
public int ŀ=0;public double ʬ;public List<ĭ>Į=new List<ĭ>();public List<ĭ>į=new List<ĭ>();public MyItemType Ł;public bool Ī=
false;public bool ī=false;public string Ĭ;public string ʭ;public double Ĺ=1;}List<ĩ>Ĩ=new List<ĩ>();void ű(IMyTerminalBlock Ŝ
,int Ǩ=99){if(Ǩ==99){foreach(var ĩ in Ĩ){ĭ ĺ=new ĭ();ĺ.Ħ=Ŝ;ĺ.ĺ=Ŝ.GetInventory();ĩ.Į.Add(ĺ);}}else{ĭ ĺ=new ĭ();ĺ.Ħ=Ŝ;ĺ.ĺ=Ŝ
.GetInventory();ĺ.Ļ=ħ;if(Ǩ==0&&!Ǎ)ĺ.Ļ=false;Ĩ[Ǩ].Į.Add(ĺ);}}void ʮ(IMyTerminalBlock Ŝ,int Ǩ){ĭ ĺ=new ĭ();ĺ.Ħ=Ŝ;ĺ.ĺ=Ŝ.
GetInventory();ĺ.Ļ=ħ;if(Ǩ!=99)Ĩ[Ǩ].į.Add(ĺ);}void ʱ(string Ĭ,string ʯ,string ʰ,bool ī=false,bool Ī=false){ĩ ĩ=new ĩ();ĩ.Ł=new
MyItemType(ʯ,ʰ);ĩ.ī=ī;ĩ.Ī=Ī;ĩ.Ĭ=Ĭ;string ʭ;if(Ĭ.Length>9)ʭ=Ĭ.Substring(0,9);else ʭ=Ĭ.PadRight(9);ĩ.ʭ=ʭ;Ĩ.Add(ĩ);}void g(){try{ʱ(
"Fusion Fuel","MyObjectBuilder_Ingot","FusionFuel",true);ʱ("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");ʱ("Jerry Can",
"MyObjectBuilder_Component","SG_Fuel_Tank");ʱ("PDC","MyObjectBuilder_AmmoMagazine","40mmLeadSteelPDCBoxMagazine",true);ʱ("PDC Tefl",
"MyObjectBuilder_AmmoMagazine","40mmTungstenTeflonPDCBoxMagazine",true);ʱ("220 Torp ","MyObjectBuilder_AmmoMagazine","220mmExplosiveTorpedoMagazine",
true,true);ʱ("220 MCRN","MyObjectBuilder_AmmoMagazine","220mmMCRNTorpedoMagazine",true,true);ʱ("220 UNN",
"MyObjectBuilder_AmmoMagazine","220mmUNNTorpedoMagazine",true,true);ʱ("RS Torp","MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);
ʱ("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",true,true);ʱ("120mm RG",
"MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);ʱ("Dawson","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true
);ʱ("Stiletto","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugMCRNMagazine",true);ʱ("80mm",
"MyObjectBuilder_AmmoMagazine","80mmTungstenUraniumSabotMagazine",true);ʱ("Foehammr","MyObjectBuilder_AmmoMagazine",
"120mmTungstenUraniumSlugMCRNMagazine",true);ʱ("Farren","MyObjectBuilder_AmmoMagazine","120mmTungstenUraniumSlugUNNMagazine",true);ʱ("Kess",
"MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);ʱ("Steel Pla","MyObjectBuilder_Component","SteelPlate");ʱ("Reactor C",
"MyObjectBuilder_Component","Reactor");Ĩ[0].Ĺ=ǝ;}catch(Exception Ė){Echo("Failed to build item lists!");Echo(Ė.Message);return;}}void æ(){foreach(
var ĩ in Ĩ){ĩ.į.Clear();}}void é(){foreach(var ĩ in Ĩ){ĩ.ʇ=0;ĩ.ŀ=0;List<ĭ>İ=ĩ.Į.Concat(ĩ.į).ToList();foreach(ĭ ĺ in İ){ĺ.ļ=
ĺ.ĺ.GetItemAmount(ĩ.Ł).ToIntSafe();ĩ.ʇ+=ĺ.ļ;if(ĺ.Ļ){ĺ.Ľ=ĺ.ĺ.VolumeFillFactor;}else{ĩ.ŀ+=ĺ.ļ;}}}}void ʖ(){foreach(ĩ ĩ in Ĩ
){ĩ.ǩ=ĩ.ʇ;}}int ʳ(string ʲ){switch(ʲ){case"220mm Explosive Torpedo":case"220mm Decoy Torpedo":case
"220mm Explosive Anti-Torp Torpedo":return 5;case"MCRN Anti-Torp Torpedo":case"MCRN Torpedo High Spread":case"MCRN Torpedo Low Spread":return 6;case
"UNN Anti-Torp Torpedo":case"UNN Torpedo High Spread":case"UNN Torpedo Low Spread":return 7;case"40mm Tungsten-Teflon Ammo":return 4;case
"40mm Lead-Steel PDC Box Ammo":return 4;case"Ramshackle Torpedo Magazine":return 8;case"120mm Lead-Steel Slug Ammo":return 10;case
"100mm Tungsten-Uranium Slug UNN Ammo":return 7;case"100mm Tungsten-Uranium Slug MCRN Ammo":return 6;case"80mm Tungsten-Uranium Sabot Ammo":return 13;case
"120mm Tungsten-Uranium Slug MCRN Ammo":return 14;case"120mm Tungsten-Uranium Slug UNN Ammo":return 15;case"180mm Lead-Steel Sabot Ammo":return 16;case
"Large Ramshackle Torpedo Magazine":return 9;default:if(n)Echo("Unknown AmmoType = "+ʲ);return 99;}}bool ʵ(IMyTerminalBlock Ħ){IMyInventory ʴ=Ħ.
GetInventory();return ʴ.VolumeFillFactor==0;}bool ł(List<ĭ>ı,List<ĭ>ĳ,MyItemType Ł,int ʶ=-1,double ʷ=1,double ʸ=1){if(n)Echo(
"Loading "+ĳ.Count+" inventories from "+ı.Count+" sources.");bool ʹ=false;bool ʺ=ʸ<1;foreach(ĭ ʼ in ĳ){int ʻ=3;foreach(ĭ ʽ in ı){
if(ʻ<0)break;if(ʶ!=-1&&ʼ.ļ>=(ʶ*.95))break;if(!ʼ.ĺ.IsConnectedTo(ʽ.ĺ))continue;List<MyInventoryItem>ʾ=new List<
MyInventoryItem>();ʽ.ĺ.GetItems(ʾ);foreach(MyInventoryItem ʿ in ʾ){if(ʿ.Type==Ł){int ļ=ʿ.Amount.ToIntSafe();if(ļ==0&&!ʺ)break;ʻ--;if(ʺ)
{ʻ=-1;try{ļ=ʽ.ļ-Convert.ToInt32(ʽ.ļ/ʽ.Ľ*ʸ);if(n)Echo("Unload "+ļ+"\n"+ʽ.ļ+"\n"+Convert.ToInt32(ʽ.ļ/ʽ.Ľ*ʸ));}catch(
Exception Ė){if(n)Echo("Int conversion error at unload\n"+Ė.Message);ļ=1;}}else if(ʷ<1){try{int ˀ=Convert.ToInt32(ʼ.ļ/ʼ.Ľ*ʷ)-ʼ.ļ;
if(ˀ<ļ)ļ=ˀ;}catch(Exception Ė){if(n)Echo("Int conversion error at load\n"+Ė.Message);ļ=1;}}else if(ʶ!=-1){if(ļ<=ʶ){break;}
ļ=ʶ-ʼ.ļ;}ʹ=ʼ.ĺ.TransferItemFrom(ʽ.ĺ,ʿ,ļ);if(ʹ)ʻ=-1;if(ʺ&&ʹ)return(ʹ);break;}}}}return ʹ;}class Œ{public IMyTextPanel Ħ;
public bool ƭ=true;public bool Ʈ=false;public bool Ư=false;public bool Ƭ=true;public bool ư=true;public bool Ʊ=true;public
bool Ʋ=false;public bool Ƴ=false;}class Ä{public string ˁ,ˆ;public int ˇ,ˈ;public Ä(string ˉ,string ˊ,int ˋ=0,int ˌ=20){if(ˉ
.Length>ˍ-3)ˉ=ˉ.Substring(0,ˍ-3);ˁ=ˉ.PadRight(ˍ-3);ˆ=ˊ;ˇ=ˋ;ˈ=ˌ;}}List<Ä>Ã=new List<Ä>();class ˡ{public string ˎ,ˏ;public
ˡ(string ʝ,int ː,int ˑ){string ˠ="    ";while(ˑ>3){ˑ-=4;}if(ː==0){ˎ="║ "+ʝ.PadRight(4)+" ║";ˏ="  "+ˠ+"  ";}else if(ː==1){
if(ˑ==0||ˑ==2)ˎ="║─"+ʝ.PadRight(4)+" ║";else ˎ="║ "+ʝ.PadRight(4)+"─║";ˏ=" ░"+ˠ+"░ ";}else if(ː==2){if(ˑ==0||ˑ==2){ˎ="║ "+
ʝ.PadRight(4)+"═║";ˏ="║▒"+ˠ+"░║";}else{ˎ="║═"+ʝ.PadRight(4)+" ║";ˏ="║░"+ˠ+"▒║";}}else if(ː==3){if(ˑ==0||ˑ==2){ˎ="║!"+ʝ.
PadRight(4)+"!║";ˏ="║▓"+ˠ+"▓║";}else{ˎ="║ "+ˠ+" ║";ˏ="║!"+ʝ.PadRight(4)+"!║";}}}}Color ˢ=new Color(255,116,33,255);const int ˍ=
32;int ˣ=0;string[]ˤ=new string[]{"▄ "," ▄"," ▀","▀ "},ˬ=new string[]{"─","\\","│","/"},ˮ=new string[]{"- ","= ","x ","! "
};string Ͱ,ͱ,Ͳ,ͳ,ʹ="\n\n",Ͷ,ͷ="╔══════╗",ͺ="╚══════╝",ȷ,ͻ,ͼ,ͽ,Ά,Έ,Ή,Ί,Ό,Ύ,Ώ,ΐ,Α,Β,Γ,Δ,Ε,Ζ,Η,Θ,Ι;void i(){ͷ=ͷ+ͷ+ͷ+ͷ+"\n";ͺ
=ͺ+ͺ+ͺ+ͺ+"\n";Ͱ=Κ("Welcome to")+ʹ+Κ("R S M")+ʹ;ͱ=Κ("Initialising")+ʹ;Ͳ=new String(' ',ˍ-8);ͳ="└"+new String('─',ˍ-2)+"┘";
ȷ=new String('-',26)+"\n";Ͷ="──"+ʹ;ͻ=Λ("Inventory");ͼ=Λ("Thrust");ͽ=Λ("Power & Tanks");Ά=Λ("Warnings");Έ=Λ(
"Subsystem Integrity");Ή=Λ("Telemetry & Thrust");Ί=Μ("Velocity");Ό=Μ("Velocity (Max)");Ύ=Μ("Mass");Ώ=Μ("Max Accel");ΐ=Μ("Actual Accel");Α=Μ(
"Accel (Best)");Β=Μ("Max Thrust");Γ=Μ("Actual Thrust");Δ=Μ("Decel (Dampener)");Ε=Μ("Decel (Actual)");Ζ=Ν("Fuel");Η=Ν("Oxygen");Θ=Ν(
"Battery");Ι=Ν("Capacity");}string Λ(string Ξ){return"──┤ "+Ξ+" ├"+new String('─',ˍ-9-Ξ.Length);}string Μ(string Ο){return Ο+":"+
new String(' ',ˍ-16-Ο.Length);}string Ν(string Π){return Π+new String(' ',ˍ-22-Π.Length)+"[";}void Ì(){ˣ++;if(ˣ>=ˤ.Length)ˣ
=0;int Ρ=ˣ+2;if(Ρ>3)Ρ-=4;string Σ=ˤ[ˣ];string Τ=ˬ[ˣ];string Υ=ˤ[Ρ];string Φ=ͻ+Τ+Ͷ;string Χ=ͼ+Τ+Ͷ;string Ψ=ͽ+Τ+Ͷ;string Ω=
Ά+Τ+Ͷ;string Ϊ=Έ+Τ+Ͷ;string Ϋ=Ή+Τ+Ͷ;string ά=Κ(Ę.ToUpper())+"\n"+"  "+Σ+" "+Κ(ę,ˍ-10)+" "+Σ+"  \n";string έ="\n  "+Υ+Ͳ+Υ+
"  "+ʹ;if(I){string ή=Ͱ+Κ("Booting"+new string('.',C))+ʹ;Φ+=ή;Χ+=ή;Ψ+=ή;Ω+=ή;Ϊ+=ή;}else if(J){string ƚ=ͱ+Κ(Ę)+ʹ;Φ+=ƚ;Χ+=ƚ;Ψ
+=ƚ;Ω+=ƚ;Ϊ+=ƚ;}else{ǆ();double ί=9.81,ΰ=Math.Round(T),β=Math.Round((α/U/ί),2),δ=Math.Round((γ/U/ί),2),ε=Math.Round(Ǫ+ǫ,1),
η=Math.Round(ζ,1),κ=Math.Round(100*(θ/ι)),ν=Math.Round(100*(λ/μ)),ξ=Math.Round(100*(η/ε));string ο=Ί,π=" Gs",Ǽ;List<
string>ρ=new List<string>();if(ΰ<1){ΰ=500;ο=Ό;}if(ǜ){ί=1;π=" m/s/s";}for(int Ʌ=0;Ʌ<Ĩ.Count;Ʌ++){if(Ĩ[Ʌ].ǩ!=0){Ĩ[Ʌ].ʬ=(100*((
double)Ĩ[Ʌ].ʇ/(double)Ĩ[Ʌ].ǩ));string ɚ=(Ĩ[Ʌ].ʇ+"/"+Ĩ[Ʌ].ǩ).PadLeft(9);if(ɚ.Length>9)ɚ=ɚ.Substring(0,9);Φ+=Ĩ[Ʌ].ʭ+" ["+ς(Ĩ[Ʌ].
ʬ)+"] "+ɚ+"\n";if(Ʌ>2&&Ĩ[Ʌ].ŀ<1)ρ.Add(Ĩ[Ʌ].Ĭ);}}Φ+="\n";if(γ>0)Χ+=Ε+σ(γ,ΰ)+"\n"+ΐ+(δ+π).PadLeft(15)+ʹ;else Χ+=Δ+σ(α,ΰ,
true)+"\n"+Α+(β+π).PadLeft(15)+ʹ;ʁ=Math.Round(100*(ʄ/ʅ));Ψ+=Ζ+ς(ʁ)+"] "+(ʁ+" %").PadLeft(9)+"\n"+Η+ς(κ)+"] "+(κ+" %").
PadLeft(9)+"\n"+Θ+ς(ν)+"] "+(ν+" %").PadLeft(9)+"\n"+Ι+ς(ξ)+"] "+(ξ+" %").PadLeft(9)+"\n"+"Max Power:"+(η+" MW / "+ε+" MW").
PadLeft(22)+ʹ;List<Ä>τ=new List<Ä>();List<ˡ>υ=new List<ˡ>();int φ=0;for(int Ʌ=0;Ʌ<Ã.Count;Ʌ++){Ã[Ʌ].ˈ--;if(Ã[Ʌ].ˈ<1)Ã.RemoveAt(
Ʌ);else τ.Add(Ã[Ʌ]);}if(!χ){τ.Add(new Ä("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(O){τ.Add(new Ä("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int ψ=0;if(ʁ<5)
{Ǽ="FUEL CRITICAL!";τ.Add(new Ä(Ǽ,Ǽ+"\nFuel Level < 5%!",3));ψ=3;}else if(ʁ<25){Ǽ="FUEL LOW!";τ.Add(new Ä(Ǽ,Ǽ+
"\nFuel Level < 10%!",2));ψ=2;}if(Î.ȭ!=Ȯ.Off){if(Q!=""){if(ψ==0)ψ=1;τ.Add(new Ä("NO SPARE "+Q.ToUpper()+"!",
"Cannot refuel!\nNo spare fuel tanks or failed to load fuel tanks.",ψ));}if(P){if(ψ==0)ψ=1;τ.Add(new Ä("NO EXTRACTOR!","Cannot refuel!\nNo functional extractor!",ψ));}}υ.Add(new ˡ("FUEL",
ψ,ˣ+φ));φ++;if(N){Ǽ=Ć.Count+" spawns are open to friends";τ.Add(new Ä(Ǽ,Ǽ,0));}int ω=0;if(κ<5){Ǽ="OXYGEN CRITICAL!";τ.Add
(new Ä(Ǽ,Ǽ+"\nShip O2 Level < 5%!",3));ω=3;}else if(κ<10){Ǽ="OXYGEN LOW!";τ.Add(new Ä(Ǽ,Ǽ+"\nShip O2 Level < 10%!",2));ω=
2;}else if(κ<25){Ǽ="Oxygen Low!";τ.Add(new Ä(Ǽ,Ǽ+"\nShip O2 Level < 25%!",1));ω=1;}if(þ.Count>ϊ){int ϋ=(þ.Count-ϊ);ω++;Ǽ=
ϋ+" vents are unsealed";τ.Add(new Ä(Ǽ,Ǽ,1));}if(ɨ>0){Ǽ=ɨ+" doors are insecure";τ.Add(new Ä(Ǽ,Ǽ,0));}if(S>0){Ǽ=š+
" is active ("+S+")";τ.Add(new Ä(Ǽ,Ǽ,0));}υ.Add(new ˡ("OXYG",ω,ˣ+φ));φ++;int ό=0;if(Ú.Count>0){if(ν<5){ό+=2;Ǽ="BATTERIES CRITICAL!";τ.
Add(new Ä(Ǽ,Ǽ+"\nBattery Level < 5%!",2));}else if(ν<10){ό+=1;Ǽ="Batteries Low!";τ.Add(new Ä(Ǽ,Ǽ+"\nBattery Level < 10%!",1
));}}if(Ù.Count>0){if(ύ>0){ό+=2;τ.Add(new Ä(ύ+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}
if(Ĩ[0].ʇ<1){ό+=3;Ǽ="NO FUSION FUEL!";τ.Add(new Ä(Ǽ,Ǽ,2));}else if(Ĩ[0].ʇ<50){ό+=2;Ǽ="FUSION FUEL CRITICAL! ("+Ĩ[0].ʇ+")";
τ.Add(new Ä(Ǽ,Ǽ,2));}else if(Ĩ[0].ǩ>0&&Ĩ[0].ʬ<5){ό+=2;Ǽ="FUSION FUEL CRITICAL!";τ.Add(new Ä(Ǽ,Ǽ,3));}else if(Ĩ[0].ǩ>0&&Ĩ[
0].ʬ<10){ό+=1;Ǽ="Fusion Fuel Level Low!";τ.Add(new Ä(Ǽ,Ǽ,2));}}if(ό>3)ό=3;υ.Add(new ˡ("POWR",ό,ˣ+φ));φ++;int ώ=0;if(ρ.
Count>0){foreach(string Ϗ in ρ){string ϐ=Ϗ;if(Ϗ.Length>23)ϐ=Ϗ.Substring(0,23);ϐ=ϐ.ToUpper();Ǽ="NO SPARE "+ϐ+"!";τ.Add(new Ä(Ǽ
,Ǽ,3));}ώ=3;}if(ώ>3)ώ=3;υ.Add(new ˡ("WEAP",ώ,ˣ+φ));φ++;if(Ġ){string ϑ=ġ;if(ú.Count>0)if(ú[0]!=null)ϑ=(ú[0]as
IMyRadioAntenna).HudText;string ϒ="";if(Ģ<1000)ϒ=Math.Round(Ģ)+"m";else ϒ=Math.Round(Ģ/1000)+"km";τ.Add(new Ä("Comms ("+ϒ+"): "+ϑ,
"Antenna(s) are broadcasting at a range of "+ϒ+" with the message "+ϑ,0));}if(R>0){Ǽ=R+" UNOWNED BLOCKS!";τ.Add(new Ä(Ǽ,Ǽ+"\nRSM detected "+R+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ɦ>ɧ){int ɬ=(ɦ-ɧ);Ǽ=ɬ+" doors are open";τ.Add(new Ä(Ǽ,Ǽ,0));}τ=τ.OrderBy(Ŀ=>Ŀ.ˇ).Reverse().ToList();if(τ.Count<1
)Ω+="No warnings\n";else Echo(ʹ+" WARNINGS:");for(int Ʌ=0;Ʌ<τ.Count;Ʌ++){Ω+=ˮ[τ[Ʌ].ˇ]+τ[Ʌ].ˁ+"\n";Echo("-"+ˮ[τ[Ʌ].ˇ]+τ[Ʌ]
.ˆ);}Ω+="\n";string ϓ=Î.Ȍ.ToString().ToUpper();if(ϓ.Length>3)ϓ=ϓ.Substring(0,3);string ϔ=Î.ȏ.ToString().ToUpper();if(ϔ.
Length>3)ϔ=ϔ.Substring(0,3);string ϕ=Î.Ȍ.ToString().ToUpper();if(ϕ.Length>3)ϕ=ϕ.Substring(0,3);string ϖ=Î.Ȇ.ToString().ToUpper
();if(ϖ.Length>3)ϖ=ϖ.Substring(0,3);string ϗ=Î.ȃ.ToString().ToUpper();if(ϗ.Length>3)ϗ=ϗ.Substring(0,3);string Ϙ=Î.ȉ.
ToString().ToUpper();if(Ϙ.Length>3)Ϙ=Ϙ.Substring(0,3);try{if(Ǳ>0)Ϊ+="Epstein   ["+ς(ϙ)+"] "+(ϙ+"% ").PadLeft(5)+ϓ+"\n";if(ǲ>0)Ϊ
+="RCS       ["+ς(Ϛ)+"] "+(Ϛ+"% ").PadLeft(5)+ϔ+"\n";if(Ǫ>0)Ϊ+="Reactors  ["+ς(ϛ)+"] "+(ϛ+"% ").PadLeft(5)+"    \n";if(ǫ>0
)Ϊ+="Batteries ["+ς(Ϝ)+"] "+(Ϝ+"% ").PadLeft(5)+ϕ+"\n";if(Ǭ>0)Ϊ+="PDCs      ["+ς(ϝ)+"] "+(ϝ+"% ").PadLeft(5)+ϖ+"\n";if(ǭ>
0)Ϊ+="Torpedoes ["+ς(Ϟ)+"] "+(Ϟ+"% ").PadLeft(5)+ϗ+"\n";if(Ǯ>0)Ϊ+="Railguns  ["+ς(ϟ)+"] "+(ϟ+"% ").PadLeft(5)+Ϙ+"\n";if(ǯ
>0)Ϊ+="H2 Tanks  ["+ς(Ϡ)+"] "+(Ϡ+"% ").PadLeft(5)+ϕ+"\n";if(ǰ>0)Ϊ+="O2 Tanks  ["+ς(ϡ)+"] "+(ϡ+"% ").PadLeft(5)+ϕ+"\n";if(
ǳ>0)Ϊ+="Gyros     ["+ς(ʊ)+"] "+(ʊ+"% ").PadLeft(5)+"    \n";if(Ǉ>0)Ϊ+="Cargo     ["+ς(ǉ)+"] "+(ǉ+"% ").PadLeft(5)+
"    \n";if(Ǵ>0)Ϊ+="Welders   ["+ς(Ϣ)+"] "+(Ϣ+"% ").PadLeft(5)+"    \n";}catch{}if(ǫ+Ǫ+ǯ==0)Ϊ+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+ʹ;string ϣ="";string Ϥ="";foreach(ˡ ϥ in υ){ϣ+=ϥ.ˎ;Ϥ+=ϥ.ˏ;}int Ϧ=ˣ+2;if(Ϧ>3)Ϧ-=4;ά+=ͷ+ϣ+"\n"+ͺ;έ+=Ϥ;if(!Y){Ϋ+=ʹ;}else{
if(n)Echo("Building advanced thrust...");string ϧ="";if(Ǜ){ϧ=Ύ+(Math.Round((U/1000000),2)+" Mkg").PadLeft(15)+"\n"+ο+(ΰ+
" ms").PadLeft(15)+"\n"+Ώ+(β+π).PadLeft(15)+"\n"+ΐ+(δ+π).PadLeft(15)+"\n"+Β+((α/1000000)+" MN").PadLeft(15)+"\n"+Γ+((γ/
1000000)+" MN").PadLeft(15)+"\n";}Ϋ+=ϧ+Δ+σ(α,ΰ,true)+"\n"+Ε+σ(γ,ΰ)+"\n";foreach(double Ȼ in h){Ϋ+=("Decel ("+(Ȼ*100)+"%):").
PadRight(17)+σ((float)(α*Ȼ),ΰ)+"\n";}Ϋ+=ʹ;}}foreach(Œ ơ in Ë){string ɮ="";Color ɛ=Î.Ƞ;if(ơ.ƭ)ɮ+=ά;if(ơ.Ʈ){ɮ+=έ;ɛ=ˢ;}if(ơ.Ư)ɮ+=Ω;
if(ơ.Ƭ)ɮ+=Ψ;if(ơ.ư)ɮ+=Φ;if(ơ.Ʊ)ɮ+=Χ;if(ơ.Ʋ)ɮ+=Ϊ;if(ơ.Ƴ){ɮ+=Ϋ;Y=true;}ơ.Ħ.WriteText(ɮ,false);if(!Ŧ)ơ.Ħ.FontColor=ɛ;}}void Ϩ
(){if(ő.Count>0){foreach(IMyTextPanel ơ in ő){ơ.FontColor=Î.Ƞ;}foreach(Œ ơ in Ë){ơ.Ħ.FontColor=Î.Ƞ;}}}void x(string ϩ,
string Ϫ){ϩ=ϩ.ToLower();List<IMyTextPanel>ϫ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ą);
foreach(IMyTextPanel ơ in Ą){if(Ϫ==""||ơ.CustomName.Contains(Ϫ)){string Ϭ=ơ.CustomData;if(Ϭ.Contains("hudlcd")&&(ϩ=="off"||ϩ==
"toggle"))ơ.CustomData=Ϭ.Replace("hudlcd","hudXlcd");if(Ϭ.Contains("hudXlcd")&&(ϩ=="on"||ϩ=="toggle"))ơ.CustomData=Ϭ.Replace(
"hudXlcd","hudlcd");}}}string ς(double ϭ){try{int Ϯ=0;if(ϭ>0){int ϯ=(int)ϭ/10;if(ϯ>10)return new string('=',10);if(ϯ!=0)Ϯ=ϯ;}char
ϰ=' ';if(ϭ<10){if(ˣ==0)return" ><    >< ";if(ˣ==1)return"  ><  ><  ";if(ˣ==2)return"   ><><   ";if(ˣ==3)return
"<   ><   >";}string ϱ=new string('=',Ϯ);string ϲ=new string(ϰ,10-Ϯ);return ϱ+ϲ;}catch{return"# ERROR! #";}}string ϵ(string ϳ){
string ϴ;string ɚ="";double ϭ=0;switch(ϳ){case"H2":ϭ=Math.Round(100*(ʄ/ǯ));ɚ=ϭ.ToString()+" %";ʁ=ϭ;break;case"O2":ϭ=Math.Round
(100*(θ/ǰ));ɚ=ϭ.ToString()+" %";break;case"Battery":ϭ=Math.Round(100*(λ/μ));ɚ=ϭ.ToString()+" %";break;}ϴ=ς(ϭ);return" ["+
ϴ+"] "+ɚ.PadLeft(9);}string Κ(string Ϸ,int ϸ=ˍ){int Ϲ=ϸ-Ϸ.Length;int Ϻ=Ϲ/2+Ϸ.Length;return Ϸ.PadLeft(Ϻ).PadRight(ϸ);}
string σ(double ϻ,double ϼ,bool Ͻ=false){if(ϻ<=0)return("N/A").PadLeft(15);if(Ͻ)ϻ=ϻ*1.5;double Ʃ=0.5*(Math.Pow(ϼ,2)*(U/ϻ));
double Ͼ=ϼ/(ϻ/U);string Ͽ="m";if(Ʃ>1000){Ͽ="km";Ʃ=Ʃ/1000;}return(Math.Round(Ʃ)+Ͽ+" "+Math.Round(Ͼ)+"s").PadLeft(15);}void ą(){
foreach(IMyTextPanel ɟ in Ą){ɟ.Enabled=true;}}void ʏ(){foreach(Œ ơ in Ë){ơ.Ħ.Font="Monospace";ơ.Ħ.ContentType=ContentType.
TEXT_AND_IMAGE;if(ơ.Ħ.CustomName.Contains("HUD1")){ơ.ƭ=true;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ=false;ť(ơ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ơ.Ħ.CustomName.Contains("HUD2")){ơ.ƭ=false;ơ.Ʈ=false;ơ.Ư=true;ơ.Ƭ=false;ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ
=false;ť(ơ,"hudlcd:0.22:0.99:0.55");continue;}if(ơ.Ħ.CustomName.Contains("HUD3")){ơ.ƭ=false;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=true;
ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ=false;ť(ơ,"hudlcd:0.48:0.99:0.55");continue;}if(ơ.Ħ.CustomName.Contains("HUD4")){ơ.ƭ=
false;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=true;ơ.Ƴ=false;ť(ơ,"hudlcd:0.74:0.99:0.55");continue;}if(ơ.Ħ.
CustomName.Contains("HUD5")){ơ.ƭ=false;ơ.Ʈ=false;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=true;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ=true;ť(ơ,"hudlcd:0.75:0:.54"
);continue;}if(ơ.Ħ.CustomName.Contains("HUD6")){ơ.ƭ=false;ơ.Ʈ=true;ơ.Ư=false;ơ.Ƭ=false;ơ.ư=false;ơ.Ʊ=false;ơ.Ʋ=false;ơ.Ƴ=
false;ť(ơ,"hudlcd:-0.55:0.99:0.7");continue;}}bool Ѐ=false;foreach(IMyTextPanel ɟ in Ą){if(ɟ==null)continue;if(!Ѐ&&(ɟ.
CustomName.Contains(Ǘ)||ɟ.CustomName.ToUpper().Contains(ǘ))){Ѐ=true;ɟ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool χ;bool
Ё;void à(bool ʋ,bool ʌ){χ=false;foreach(IMyConveyorSorter Ђ in ß){if(Ђ!=null&&Ђ.IsFunctional){χ=true;if(ʌ)Ђ.Enabled=ʋ;if(
!Ё){MyDetectedEntityInfo?Є=ē.Ѓ(Ђ);if(Є.HasValue){string ʝ=Є.Value.Name;if(ʝ!=null&&ʝ!=""){if(n)Echo(
"At least one lidar  has a target!");Ё=true;}}}}}if(!χ){Ё=true;}}void І(ȓ ń){if(ń==ȓ.NoChange)return;foreach(IMyReflectorLight Ѕ in ŗ){if(Ѕ==null)continue;
if(ń==ȓ.Off)Ѕ.Enabled=false;else{Ѕ.Enabled=true;if(ń==ȓ.OnMax)Ѕ.Radius=9999;}}}void Ј(Ȗ ń,Color ɛ){if(ń==Ȗ.NoChange)return
;foreach(IMyLightingBlock Ї in œ){if(Ї==null)continue;if(ń==Ȗ.Off)Ї.Enabled=false;else Ї.Enabled=true;if(ń!=Ȗ.
OnNoColourChange)Ї.SetValue("Color",ɛ);}}void Љ(Ȗ ń,Color ɛ){if(ń==Ȗ.NoChange)return;foreach(IMyLightingBlock Ї in Ŕ){if(Ї==null)
continue;if(ń==Ȗ.Off)Ї.Enabled=false;else Ї.Enabled=true;if(ń!=Ȗ.OnNoColourChange)Ї.SetValue("Color",ɛ);}}Color Њ=new Color(255,
0,0,255);Color Ћ=new Color(255,0,0,255);Color Ќ=new Color(0,255,0,255);void Ў(Ȗ ń){if(ń==Ȗ.NoChange)return;foreach(
IMyLightingBlock Ї in ŕ){Ѝ(Ї,ń,Ћ);}foreach(IMyLightingBlock Ї in Ŗ){Ѝ(Ї,ń,Ќ);}}void Ѝ(IMyLightingBlock Ї,Ȗ ń,Color ɛ){if(Ї==null)return;
if(ń==Ȗ.Off){Ї.Enabled=false;Ї.SetValue("Color",Њ);}else{Ї.Enabled=true;if(ń!=Ȗ.OnNoColourChange)Ї.SetValue("Color",ɛ);}}
int ϊ=0;void ÿ(bool ʋ,bool ʌ){ϊ=0;foreach(IMyAirVent Џ in þ){if(Џ!=null){if(ʌ)Џ.Enabled=ʋ;if(Џ.CanPressurize)ϊ++;}}}void ĉ(
bool ʋ){foreach(IMyShipConnector А in Ĉ){if(А!=null)А.Enabled=ʋ;}}void ċ(bool ʋ){foreach(IMyCameraBlock Б in Ċ){if(Б!=null)Б
.Enabled=ʋ;}}void č(bool ʋ){foreach(IMySensorBlock В in Č){if(В!=null)В.Enabled=ʋ;}}void ć(){O=true;foreach(
IMyTerminalBlock Г in Ć){Г.ApplyAction("OnOff_On");if(Г.IsFunctional)O=false;}}bool Д=false;List<string>Е=new List<string>();bool Ж=
false;List<string>З=new List<string>();void Л(string j,string И){bool ʹ=false;List<IMyProgrammableBlock>Й=new List<
IMyProgrammableBlock>();try{if(И=="EFC")Й=ŏ;else if(И=="NavOS")Й=Ő;foreach(IMyProgrammableBlock К in Й){if(К==null||!К.Enabled)continue;ʹ=(К
as IMyProgrammableBlock).TryRun(j);if(n)Echo("Ran "+j+" on "+К.CustomName+" successfully.");Ã.Add(new Ä("Ran "+И+" ("+j+
")","Ran "+И+" ("+j+")",0));if(И=="EFC")Д=true;else if(И=="NavOS")Ж=true;break;}}catch(Exception Ė){Ã.Add(new Ä(И+
" command errored!",И+" command "+j+" errored!\n"+Ė.Message,3));}}void М(string j,string И){if(И=="EFC"){if(ŏ.Count<1)return;if(Д){Е.Add(j)
;return;}}if(И=="NavOS"){if(Ő.Count<1)return;if(Ж){З.Add(j);return;}}Л(j,И);}void á(){if(Е.Count>0&&!Д){Л(Е[0],"EFC");Е.
RemoveAt(0);}if(З.Count>0&&!Ж){Л(З[0],"NavOS");З.RemoveAt(0);}Д=false;Ж=false;}int Ǭ=0;double Н=0;double ϝ=0;void ô(){Н=0;
foreach(IMyTerminalBlock П in ò){О(П,Î.Ȇ!=ȇ.Off&&Î.Ȇ!=ȇ.MinDefence);}foreach(IMyTerminalBlock П in ó){О(П,Î.Ȇ!=ȇ.Off);}ϝ=Math.
Round(100*(Н/Ǭ));}void О(IMyTerminalBlock Р,bool ʋ){if(Р!=null&&Р.IsFunctional){Н++;(Р as IMyConveyorSorter).Enabled=ʋ;}}void
С(ȇ ń){if(ń==ȇ.NoChange)return;foreach(IMyTerminalBlock П in ò){if(П!=null&П.IsFunctional){switch(ń){case ȇ.Off:case ȇ.
MinDefence:(П as IMyConveyorSorter).Enabled=false;break;case ȇ.AllDefence:(П as IMyConveyorSorter).Enabled=true;if(ǎ){try{П.
SetValue("WC_FocusFire",false);П.SetValue("WC_Projectiles",true);П.SetValue("WC_Grids",true);П.SetValue("WC_LargeGrid",false);П.
SetValue("WC_SmallGrid",true);П.SetValue("WC_SubSystems",true);П.SetValue("WC_Biologicals",true);ǁ(П);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;case ȇ.Offence:(П as IMyConveyorSorter).Enabled=true;if(ǎ){try{П.SetValue("WC_FocusFire",false);П.SetValue(
"WC_Projectiles",true);П.SetValue("WC_Grids",true);П.SetValue("WC_LargeGrid",true);П.SetValue("WC_SmallGrid",true);П.SetValue(
"WC_SubSystems",true);П.SetValue("WC_Biologicals",true);ǁ(П);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock П in ó){if(П!=null&П.IsFunctional){switch(ń){case ȇ.Off:(П as IMyConveyorSorter).Enabled=false;break;
case ȇ.MinDefence:case ȇ.AllDefence:case ȇ.Offence:(П as IMyConveyorSorter).Enabled=true;if(ǎ){try{П.SetValue("WC_FocusFire"
,false);П.SetValue("WC_Projectiles",true);П.SetValue("WC_Grids",true);П.SetValue("WC_LargeGrid",false);П.SetValue(
"WC_SmallGrid",true);П.SetValue("WC_SubSystems",true);П.SetValue("WC_Biologicals",true);ǀ(П);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double ζ;void Û(Ȣ ń){ζ=0;Т();У(ń);}double μ=0;double ǫ=0;double λ=0;double Ϝ=0;void У(Ȣ ń){μ=0;λ=0;double
Ф=0;foreach(IMyBatteryBlock Х in Ú){if(Х!=null&&Х.IsFunctional){λ+=Х.CurrentStoredPower;μ+=Х.MaxStoredPower;Ф+=Х.
MaxOutput;Х.Enabled=true;if(ń==Ȣ.ManagedDischarge){if(Ц||Ч<=0)Х.ChargeMode=ChargeMode.Discharge;else Х.ChargeMode=ChargeMode.
Recharge;}}}Ϝ=Math.Round(100*(Ф/ǫ));ζ+=Ф;}void ʒ(){ǫ=0;foreach(IMyBatteryBlock Х in Ú){ChargeMode Ш=Х.ChargeMode;Х.ChargeMode=
ChargeMode.Auto;ǫ+=Х.MaxOutput;Х.ChargeMode=Ш;}}void Щ(Ȣ ń){if(ń==Ȣ.NoChange)return;foreach(IMyBatteryBlock Х in Ú){if(Х!=null&&!Х
.Closed&&Х.IsFunctional){Х.Enabled=true;if(ń==Ȣ.Auto)Х.ChargeMode=ChargeMode.Auto;else if(ń==Ȣ.StockpileRecharge)Х.
ChargeMode=ChargeMode.Recharge;else if(ń==Ȣ.Discharge)Х.ChargeMode=ChargeMode.Discharge;}}}double Ǫ=0;double Ч=0;double ϛ=0;int ύ=
0;void Т(){Ч=0;ύ=0;foreach(IMyReactor Ъ in Ù){if(Ъ!=null&&!Ъ.Closed&&Ъ.IsFunctional){Ъ.Enabled=true;if(ʵ(Ъ))ύ++;else Ч+=Ъ
.MaxOutput;}}ϛ=Math.Round(100*(Ч/Ǫ));ζ+=Ч;}void ʓ(){Ǫ=0;foreach(IMyReactor Ъ in Ù){Ǫ+=Ъ.MaxOutput;}}void Á(IMyProjector Â
){Â.CustomData=Â.ProjectionOffset.X+"\n"+Â.ProjectionOffset.Y+"\n"+Â.ProjectionOffset.Z+"\n"+Â.ProjectionRotation.X+"\n"+
Â.ProjectionRotation.Y+"\n"+Â.ProjectionRotation.Z+"\n";}void Å(IMyProjector Â){if(!Â.IsFunctional)return;try{string[]Ы=Â
.CustomData.Split('\n');Vector3I Ь=new Vector3I(int.Parse(Ы[0]),int.Parse(Ы[1]),int.Parse(Ы[2]));Vector3I Э=new Vector3I(
int.Parse(Ы[3]),int.Parse(Ы[4]),int.Parse(Ы[5]));Â.Enabled=true;Â.ProjectionOffset=Ь;Â.ProjectionRotation=Э;Â.
UpdateOffsetAndRotation();}catch{if(n)Echo("Failed to load projector position for "+Â.Name);}}int Ǯ=0;double Ю=0;double ϟ=0;bool Ц=false;void Ø
(){Ц=false;Ю=0;foreach(IMyTerminalBlock Я in Õ){if(Я!=null&&Я.IsFunctional){Ю++;(Я as IMyConveyorSorter).Enabled=Î.ȉ!=Ȋ.
Off;if(!Ц){MyDetectedEntityInfo?а=ē.Ѓ(Я);if(а.HasValue){string ʝ=а.Value.Name;if(ʝ!=null&&ʝ!=""){if(n)Echo(
"At least one rail has a target!");Ц=true;}}}}}foreach(IMyTerminalBlock Я in Ö){if(Я!=null&&Я.IsFunctional){Ю++;(Я as IMyConveyorSorter).Enabled=Î.ȉ!=Ȋ.
Off;}}ϟ=Math.Round(100*(Ю/Ǯ));}void г(Ȋ ń){if(ń==Ȋ.NoChange)return;foreach(IMyTerminalBlock в in Õ){б(в,ń,false);}foreach(
IMyTerminalBlock в in Ö){б(в,ń,true);}}void б(IMyTerminalBlock в,Ȋ ń,bool Ɵ){if(в!=null&в.IsFunctional){if(ń==Ȋ.Off){(в as
IMyConveyorSorter).Enabled=false;}else{(в as IMyConveyorSorter).Enabled=true;if(!Ɵ){if(ǎ){в.SetValue("WC_Grids",true);в.SetValue(
"WC_LargeGrid",true);в.SetValue("WC_SmallGrid",true);в.SetValue("WC_SubSystems",true);ǁ(в);}if(Ǐ){if(ń==Ȋ.OpenFire){Ǆ(в);}else{ǃ(в);}}
}}}}class Ƕ{public string ȿ="";public Ȅ ȃ;public ȇ Ȇ;public Ȋ ȉ;public ȍ Ȍ;public Ȑ ȏ;public ȓ Ȓ;public Ȗ ȕ;public Color
Ș;public Ȗ Ț;public Color Ȝ;public Ȗ Ȟ;public Color Ƞ;public Ȣ Ü;public int Ȥ;public Ð Ȧ;public ȩ Ȩ;public Ð ȫ;public Ȯ ȭ
;public Ð Ï;public Ȳ ȱ;}string ę="N/A";Ƕ Î;Ȅ ȅ=Ȅ.On;ȇ Ȉ=ȇ.Offence;Ȋ ȋ=Ȋ.OpenFire;ȍ Ȏ=ȍ.On;Ȑ ȑ=Ȑ.On;ȓ Ȕ=ȓ.On;Ȗ ȗ=Ȗ.On;
Color ș=new Color(33,144,255,255);Ȗ ț=Ȗ.On;Color ȝ=new Color(255,214,170,255);Ȗ ȟ=Ȗ.On;Color ȡ=new Color(33,144,255,255);Ȣ ȣ=
Ȣ.Auto;int ȥ=-1;Ð ȧ=Ð.NoChange;ȩ Ȫ=ȩ.NoChange;Ð Ȭ=Ð.NoChange;Ȯ ȯ=Ȯ.KeepFull;Ð Ȱ=Ð.On;Ȳ ȳ=Ȳ.NoChange;void v(string Ⱦ){Ƕ ǻ;
if(!ȴ.TryGetValue(Ⱦ,out ǻ)){Ã.Add(new Ä("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(n)Echo("Setting stance '"+Ⱦ+"'.");if(Î.Ȩ==ȩ.Abort){М("Off","EFC");М("Abort","NavOS");}Î=ǻ;ę=Ⱦ;ɗ();if(n)
Echo("Setting "+Õ.Count+" railguns to "+Î.ȉ);г(Î.ȉ);if(n)Echo("Setting "+ç.Count+" torpedoes to "+Î.ȃ);д(Î.ȃ);if(n)Echo(
"Setting "+ò.Count+" _normalPdcs, "+ó.Count+" defence _normalPdcs to "+Î.Ȇ);С(Î.Ȇ);if(n)Echo("Setting "+Ý.Count+" epsteins, "+ō.
Count+" chems"+" to "+Î.Ȍ);е(Î.Ȍ,Î.ȏ);if(n)Echo("Setting "+ð.Count+" rcs, "+Ŏ.Count+" atmos"+" to "+Î.ȏ);ж(Î.ȏ);if(n)Echo(
"Setting "+Ú.Count+" batteries to = "+Î.Ü);Щ(Î.Ü);if(n)Echo("Setting "+ë.Count+" H2 tanks to stockpile = "+Î.Ü);з(Î.Ü);if(n)Echo(
"Setting "+ø.Count+" O2 tanks to stockpile = "+Î.Ü);и(Î.Ü);if(ǚ){if(n)Echo(
"No lighting was set because lighting control is disabled.");}else{if(n)Echo("Setting "+ŗ.Count+" spotlights to "+Î.Ȓ);І(Î.Ȓ);if(n)Echo("Setting "+œ.Count+" exterior lights to "+Î
.ȕ);Ј(Î.ȕ,Î.Ș);if(n)Echo("Setting "+Ŕ.Count+" exterior lights to "+Î.Ț);Љ(Î.Ț,Î.Ȝ);if(n)Echo("Setting "+ŕ.Count+
" port nav lights, "+Ŗ.Count+" starboard nav lights to "+Î.Ȟ);Ў(Î.Ȟ);}if(n)Echo("Setting "+Ā.Count+" aux block to "+Î.ȫ);ŉ(Î.ȫ);if(n)Echo(
"Setting "+ŋ.Count+" extrators to "+Î.ȭ);ʃ(Î.ȭ);if(n)Echo("Setting "+Ŋ.Count+" hangar doors units to "+Î.ȱ);ɷ(Î.ȱ);if(Î.ȉ==Ȋ.
OpenFire){if(n)Echo("Setting "+â.Count+" doors to locked because we are in combat (rails set to open fire).");z("locked","");}if
(n)Echo("Setting "+ő.Count+" colour sync Lcds.");Ϩ();if(Î.Ȥ>0){М("Set Burn "+Î.Ȥ,"EFC");float й=Convert.ToSingle(Î.Ȥ)/100
;М("ThrustRatio "+й,"NavOS");}if(Î.Ȧ==Ð.On)М("Boost On","EFC");else if(Î.Ȧ==Ð.Off)М("Boost Off","EFC");if(n)Echo(
"Finished setting stance.");}double ʅ=0;double ǯ=0;double ʄ=0;double Ϡ=0;void ì(){ʄ=0;ʅ=0;foreach(IMyGasTank к in ë){if(к.IsFunctional){к.Enabled=
true;ʅ+=к.Capacity;ʄ+=(к.Capacity*к.FilledRatio);}}Ϡ=Math.Round(100*(ʅ/ǯ));}void ʔ(){ǯ=0;foreach(IMyGasTank к in ë){if(к!=
null)ǯ+=к.Capacity;}}void з(Ȣ ń){if(ń==Ȣ.NoChange)return;foreach(IMyGasTank к in ë){if(к==null)continue;к.Enabled=true;if(ń
==Ȣ.StockpileRecharge)к.Stockpile=true;else к.Stockpile=false;}}double ι=0;double θ=0;double ǰ=0;double ϡ=0;void ù(){θ=0;ι
=0;foreach(IMyGasTank к in ø){if(к.IsFunctional){к.Enabled=true;ι+=к.Capacity;θ+=(к.Capacity*к.FilledRatio);}}ϡ=Math.
Round(100*(ι/ǰ));}void ʕ(){ǰ=0;foreach(IMyGasTank к in ø){if(к!=null)ǰ+=к.Capacity;}}void и(Ȣ ń){if(ń==Ȣ.NoChange)return;
foreach(IMyGasTank к in ø){if(к==null)continue;к.Enabled=true;if(ń==Ȣ.StockpileRecharge)к.Stockpile=true;else к.Stockpile=false
;}}float α;float γ;float Ǳ;double ϙ;void Þ(){float л=0;float м=0;float н=0;float о=0;foreach(IMyThrust п in Ý){if(п!=null
&&п.IsFunctional){л+=п.MaxThrust;н+=п.CurrentThrust;if(п.Enabled){м+=п.MaxThrust;о+=п.CurrentThrust;}}}ϙ=Math.Round(100*(л
/Ǳ));if(м==0){α=л;γ=н;}else{α=м;γ=о;}}void ʐ(){Ǳ=0;foreach(IMyThrust п in Ý){if(п!=null)Ǳ+=п.MaxThrust;}}void е(ȍ ń,Ȑ р){
if(ń==ȍ.NoChange)return;foreach(IMyThrust п in Ý){с(п,ń,р);}foreach(IMyThrust п in ō){с(п,ń,р,true);}}void с(IMyThrust п,ȍ
ń,Ȑ р,bool т=false){bool у=п.CustomName.Contains(ǖ);if(у){if(р!=Ȑ.Off&&р!=Ȑ.AtmoOnly)п.Enabled=true;else п.Enabled=false;
}else{bool ф=п.CustomName.Contains(Ǖ);if((ń==ȍ.On)||(ń==ȍ.Minimum&&ф)||(ń==ȍ.EpsteinOnly&&!т)||(ń==ȍ.ChemOnly&&т)){п.
Enabled=true;}else{п.Enabled=false;}}}float х;float ǲ;double Ϛ;void ñ(){х=0;foreach(IMyThrust п in ð){if(п!=null&&п.
IsFunctional){х+=п.MaxThrust;}}Ϛ=Math.Round(100*(х/ǲ));}void ʑ(){ǲ=0;foreach(IMyThrust п in ð){if(п!=null)ǲ+=п.MaxThrust;}}void ж(Ȑ
ń){if(ń==Ȑ.NoChange)return;foreach(IMyThrust п in ð){if(п!=null)ц(п,ń);}foreach(IMyThrust п in Ŏ){if(п!=null)ц(п,ń,true);
}}void ц(IMyThrust п,Ȑ ń,bool ч=false){bool ш=п.GridThrustDirection==Vector3I.Backward;bool щ=п.GridThrustDirection==
Vector3I.Forward;if((ń==Ȑ.On)||(ń==Ȑ.ForwardOff&&!ш)||(ń==Ȑ.ReverseOff&&!щ)||(ń==Ȑ.RcsOnly&&!ч)||(ń==Ȑ.AtmoOnly&&ч)){п.Enabled=
true;}else{п.Enabled=false;}}int ǭ=0;double ъ=0;double Ϟ=0;void è(){ъ=0;foreach(IMyTerminalBlock ы in ç){if(ы!=null&&ы.
IsFunctional){ъ++;(ы as IMyConveyorSorter).Enabled=(Î.ȃ==Ȅ.On||(Î.ȃ==Ȅ.OnWhenLidarTarget&&Ё));if(ħ){string ʲ=ē.ь(ы,0);int Ϗ=ʳ(ʲ);if(
n)Echo("Launcher "+ы.CustomName+" needs "+ʲ+"("+Ϗ+")");ʮ(ы,Ϗ);}}}Ϟ=Math.Round(100*(ъ/ǭ));}void д(Ȅ ń){if(ń==Ȅ.NoChange)
return;foreach(IMyTerminalBlock ы in ç){if(ы!=null&ы.IsFunctional){if(ń==Ȅ.OnWhenLidarTarget){}bool э=(ń==Ȅ.On||(ń==Ȅ.
OnWhenLidarTarget&&Ё));if(!э){(ы as IMyConveyorSorter).Enabled=false;}else{(ы as IMyConveyorSorter).Enabled=true;if(ǎ){ы.SetValue(
"WC_FocusFire",true);ы.SetValue("WC_Grids",true);ы.SetValue("WC_LargeGrid",true);ы.SetValue("WC_SmallGrid",false);ы.SetValue(
"WC_FocusFire",true);ы.SetValue("WC_SubSystems",true);ǁ(ы);}}}}}Ĕ ē;public class Ĕ{Action<ICollection<MyDefinitionId>>ю;Action<
ICollection<MyDefinitionId>>я;Action<ICollection<MyDefinitionId>>ѐ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,
int>,bool>ё;Func<long,MyTuple<bool,int,int>>ђ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<
MyDetectedEntityInfo,float>>ѓ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>є;Func<
long,int,MyDetectedEntityInfo>ѕ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>і;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>ї;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>ј;Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool,int>љ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>њ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
int,bool,bool,bool>ћ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>ќ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
ICollection<string>,int,bool>ѝ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int>ў;Action<Sandbox.ModAPI.Ingame
.IMyTerminalBlock,float>џ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ѡ;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ѡ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ѣ;Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,Vector3D?>ѣ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ѥ;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>ѥ;Func<MyDefinitionId,float>Ѧ;Func<long,bool>ѧ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool>Ѩ;Func<long,float
>ѩ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ѫ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ѫ;
Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,bool>>Ѭ;Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,bool>>ѭ;Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>Ѯ;Func<
long,float>ѯ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ѱ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ѱ;
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ѳ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ѳ;
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>Ѵ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
MyTuple<bool,bool>>ѵ;public bool ĕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ѷ){var ѷ=Ѷ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(Ѷ);if(ѷ==null)throw new Exception("WcPbAPI failed to activate");return Ѹ(ѷ);}public bool Ѹ
(IReadOnlyDictionary<string,Delegate>ѹ){if(ѹ==null)return false;Ѻ(ѹ,"GetCoreWeapons",ref ю);Ѻ(ѹ,"GetCoreStaticLaunchers",
ref я);Ѻ(ѹ,"GetCoreTurrets",ref ѐ);Ѻ(ѹ,"GetBlockWeaponMap",ref ё);Ѻ(ѹ,"GetProjectilesLockedOn",ref ђ);Ѻ(ѹ,
"GetSortedThreats",ref ѓ);Ѻ(ѹ,"GetObstructions",ref є);Ѻ(ѹ,"GetAiFocus",ref ѕ);Ѻ(ѹ,"SetAiFocus",ref і);Ѻ(ѹ,"GetWeaponTarget",ref ї);Ѻ(ѹ,
"SetWeaponTarget",ref ј);Ѻ(ѹ,"FireWeaponOnce",ref љ);Ѻ(ѹ,"ToggleWeaponFire",ref њ);Ѻ(ѹ,"IsWeaponReadyToFire",ref ћ);Ѻ(ѹ,
"GetMaxWeaponRange",ref ќ);Ѻ(ѹ,"GetTurretTargetTypes",ref ѝ);Ѻ(ѹ,"SetTurretTargetTypes",ref ў);Ѻ(ѹ,"SetBlockTrackingRange",ref џ);Ѻ(ѹ,
"IsTargetAligned",ref Ѡ);Ѻ(ѹ,"IsTargetAlignedExtended",ref ѡ);Ѻ(ѹ,"CanShootTarget",ref Ѣ);Ѻ(ѹ,"GetPredictedTargetPosition",ref ѣ);Ѻ(ѹ,
"GetHeatLevel",ref Ѥ);Ѻ(ѹ,"GetCurrentPower",ref ѥ);Ѻ(ѹ,"GetMaxPower",ref Ѧ);Ѻ(ѹ,"HasGridAi",ref ѧ);Ѻ(ѹ,"HasCoreWeapon",ref Ѩ);Ѻ(ѹ,
"GetOptimalDps",ref ѩ);Ѻ(ѹ,"GetActiveAmmo",ref Ѫ);Ѻ(ѹ,"SetActiveAmmo",ref ѫ);Ѻ(ѹ,"MonitorProjectile",ref Ѭ);Ѻ(ѹ,"UnMonitorProjectile",
ref ѭ);Ѻ(ѹ,"GetProjectileState",ref Ѯ);Ѻ(ѹ,"GetConstructEffectiveDps",ref ѯ);Ѻ(ѹ,"GetPlayerController",ref Ѱ);Ѻ(ѹ,
"GetWeaponAzimuthMatrix",ref ѱ);Ѻ(ѹ,"GetWeaponElevationMatrix",ref Ѳ);Ѻ(ѹ,"IsTargetValid",ref ѳ);Ѻ(ѹ,"GetWeaponScope",ref Ѵ);Ѻ(ѹ,"IsInRange",ref
ѵ);return true;}void Ѻ<ѻ>(IReadOnlyDictionary<string,Delegate>ѹ,string Ƹ,ref ѻ Ѽ)where ѻ:class{if(ѹ==null){Ѽ=null;return;
}Delegate ѽ;if(!ѹ.TryGetValue(Ƹ,out ѽ))throw new Exception(
$"{GetType().Name} :: Couldn't find {Ƹ} delegate of type {typeof(ѻ)}");Ѽ=ѽ as ѻ;if(Ѽ==null)throw new Exception(
$"{GetType().Name} :: Delegate {Ƹ} is not type {typeof(ѻ)}, instead it's: {ѽ.GetType()}");}public void ѿ(ICollection<MyDefinitionId>Ѿ)=>ю?.Invoke(Ѿ);public void Ҁ(ICollection<MyDefinitionId>Ѿ)=>я?.Invoke(Ѿ);
public void ҁ(ICollection<MyDefinitionId>Ѿ)=>ѐ?.Invoke(Ѿ);public bool ҋ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҋ,IDictionary<
string,int>Ѿ)=>ё?.Invoke(Ҋ,Ѿ)??false;public MyTuple<bool,int,int>ҍ(long Ҍ)=>ђ?.Invoke(Ҍ)??new MyTuple<bool,int,int>();public
void ҏ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҏ,IDictionary<MyDetectedEntityInfo,float>Ѿ)=>ѓ?.Invoke(Ҏ,Ѿ);public void Ґ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҏ,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ѿ)=>є?.Invoke(Ҏ,Ѿ);public
MyDetectedEntityInfo?ғ(long ґ,int Ғ=0)=>ѕ?.Invoke(ґ,Ғ);public bool ҕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҏ,long Ҕ,int Ғ=0)=>і?.Invoke(Ҏ,Ҕ
,Ғ)??false;public MyDetectedEntityInfo?Ѓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ=0)=>ї?.Invoke(Җ,җ);public void Ҙ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,long Ҕ,int җ=0)=>ј?.Invoke(Җ,Ҕ,җ);public void Қ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Җ,bool ҙ=true,int җ=0)=>љ?.Invoke(Җ,ҙ,җ);public void Ҝ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,bool қ,bool ҙ,int җ=0)=>њ
?.Invoke(Җ,қ,ҙ,җ);public bool ҟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ=0,bool ҝ=true,bool Ҟ=false)=>ћ?.Invoke(Җ,җ
,ҝ,Ҟ)??false;public float Ҡ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ)=>ќ?.Invoke(Җ,җ)??0f;public bool ҡ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Җ,IList<string>Ѿ,int җ=0)=>ѝ?.Invoke(Җ,Ѿ,җ)??false;public void Ң(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Җ,IList<string>Ѿ,int җ=0)=>ў?.Invoke(Җ,Ѿ,җ);public void ң(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,float Ĥ)=>џ?.Invoke(
Җ,Ĥ);public bool ҥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,long Ҥ,int җ)=>Ѡ?.Invoke(Җ,Ҥ,җ)??false;public MyTuple<bool,
Vector3D?>Ҧ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,long Ҥ,int җ)=>ѡ?.Invoke(Җ,Ҥ,җ)??new MyTuple<bool,Vector3D?>();public bool
ҧ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,long Ҥ,int җ)=>Ѣ?.Invoke(Җ,Ҥ,җ)??false;public Vector3D?Ҩ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Җ,long Ҥ,int җ)=>ѣ?.Invoke(Җ,Ҥ,җ)??null;public float ҩ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ)=>Ѥ?.
Invoke(Җ)??0f;public float Ҫ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ)=>ѥ?.Invoke(Җ)??0f;public float Ҭ(MyDefinitionId ҫ)=>Ѧ?.
Invoke(ҫ)??0f;public bool Ү(long ҭ)=>ѧ?.Invoke(ҭ)??false;public bool ү(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ)=>Ѩ?.Invoke(Җ)
??false;public float Ұ(long ҭ)=>ѩ?.Invoke(ҭ)??0f;public string ь(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ)=>Ѫ?.
Invoke(Җ,җ)??null;public void Ҳ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ,string ұ)=>ѫ?.Invoke(Җ,җ,ұ);public void ҳ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ,Action<long,int,ulong,long,Vector3D,bool>ņ)=>Ѭ?.Invoke(Җ,җ,ņ);public void Ҵ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ,Action<long,int,ulong,long,Vector3D,bool>ņ)=>ѭ?.Invoke(Җ,җ,ņ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ҷ(ulong ҵ)=>Ѯ?.Invoke(ҵ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ҷ(long ҭ)=>ѯ?.Invoke(ҭ)??0f;public long Ҹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ)=>Ѱ?.Invoke(Җ)??-1;public
Matrix ǂ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ)=>ѱ?.Invoke(Җ,җ)??Matrix.Zero;public Matrix ҹ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Җ,int җ)=>Ѳ?.Invoke(Җ,җ)??Matrix.Zero;public bool ҽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,long Һ,bool һ,bool Ҽ)=>ѳ?.
Invoke(Җ,Һ,һ,Ҽ)??false;public MyTuple<Vector3D,Vector3D>Ҿ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Җ,int җ)=>Ѵ?.Invoke(Җ,җ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>ҿ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƾ)=>ѵ?.Invoke(ƾ)??new MyTuple<
bool,bool>();}int Ǵ=0;double Ӏ=0;double Ϣ=0;void ă(){Ӏ=0;foreach(IMyTerminalBlock Ӂ in Ă){if(Ӂ!=null&&Ӂ.IsFunctional)Ӏ++;}Ϣ=
Math.Round(100*(Ӏ/Ǵ));}enum Ð{
Off, On, NoChange
}enum Ȗ{
Off, On, NoChange, OnNoColourChange
}enum ȇ{
Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
}enum Ȋ{
Off, HoldFire, OpenFire, NoChange
}enum ȍ{
Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
}enum Ȑ{
Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
}enum ȓ{
On, Off, OnMax, NoChange
}enum Ȣ{
Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
}enum ȩ{
Abort, NoChange
}enum Ȯ{
Off, On, FillWhenLow, KeepFull,
}enum Ȳ{
Closed, Open, NoChange
}enum Ȅ{
            Off, On, NoChange, OnWhenLidarTarget
            }
}
internal sealed class A{public double ě{get;private set;}double Ӆ{get{double Ӄ=ӂ[0];for(int Ʌ=1;Ʌ<ӄ;Ʌ++){Ӄ+=ӂ[Ʌ];}return
(Ӄ/ӄ);}}public double Ĝ{get{double ӆ=ӂ[0];for(int Ʌ=1;Ʌ<ӄ;Ʌ++){if(ӂ[Ʌ]>ӆ){ӆ=ӂ[Ʌ];}}return ӆ;}}public double Ӈ{get;private
set;}public double Ӊ{get{double ӈ=ӂ[0];for(int Ʌ=1;Ʌ<ӄ;Ʌ++){if(ӂ[Ʌ]<ӈ){ӈ=ӂ[Ʌ];}}return ӈ;}}public int ӄ{get;}double ӊ;
IMyGridProgramRuntimeInfo Ӌ;double[]ӂ;int ӌ=0;public A(IMyGridProgramRuntimeInfo Ӌ,int Ӎ=300){this.Ӌ=Ӌ;this.Ӈ=Ӌ.LastRunTimeMs;this.ӄ=MathHelper.
Clamp(Ӎ,1,int.MaxValue);this.ӊ=1.0/ӄ;this.ӂ=new double[Ӎ];this.ӂ[ӌ]=Ӌ.LastRunTimeMs;this.ӌ++;}public void Ě(){ě-=ӂ[ӌ]*ӊ;ě+=Ӌ.
LastRunTimeMs*ӊ;ӂ[ӌ]=Ӌ.LastRunTimeMs;if(Ӌ.LastRunTimeMs>Ӈ){Ӈ=Ӌ.LastRunTimeMs;}ӌ++;if(ӌ>=ӄ){ӌ=0;ě=Ӆ;Ӈ=Ӌ.LastRunTimeMs;}}