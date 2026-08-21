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

string Version = "3.0.1 (2026-08-12)";
A B;int C=0;int D=0;int E=0;int F;int G=0;bool H=true;bool I=true;bool J=false;bool K=false;bool L=false;bool M=false;
bool N=false;int O=0;int P=0;double Q;float R;string S;string T;string U;bool V=false;int W=0;int X=0;bool Y;bool Z;bool a;
public
 Program
(){Echo("Welcome to RSM\nV "+Version);b();F=c;S=Me.GetOwnerFactionTag();B=new A(Runtime);d();e.Add(0.5);e.Add(0.25);e.Add
(0.1);e.Add(0.05);f();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo("Took "+b());}public void
 Main
(string g,UpdateType h){if(h==UpdateType.Update100)i();else j(g);}void j(string g){if(k)Echo("Processing command '"+g+
"'...");if(I){l(g,"RSM is still booting");return;}if(J){l(g,"RSM is still initialising");return;}if(g==""){l(g,
"the argument was blank");return;}string[]m=g.Split(':');if(m.Length<2){l(g,"the argument wasn't recognised");return;}if(m[0].ToLower()!="comms"
)m[1]=m[1].Replace(" ",string.Empty);switch(m[0].ToLower()){case"init":bool n=true,o=true,p=true;if(m.Length>2){foreach(
string q in m){if(q.ToLower()=="nonames")n=false;else if(q.ToLower()=="nosubs")o=false;else if(q.ToLower()=="noinv")p=false;}}
r(m[1],n,o,p);return;case"stance":s(m[1]);return;case"hudlcd":string t="";if(m.Length>2)t=m[2];u(m[1],t);return;case
"doors":string v="";if(m.Length>2)v=m[2];w(m[1],v);return;case"comms":x(m[1]);return;case"printblockids":y();return;case
"printblockprops":z(m[1]);return;case"spawn":if(m[1].ToLower()=="open"){M=true;F=c;}else{M=false;F=c;}return;case"projectors":if(m[1].
ToLower()=="save"){foreach(IMyProjector º in ª)µ(º);À.Add(new Á("Projector positions saved",
"Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector º in ª)Â(º);À.Add(new Á("Projector positions loaded",
"Projector positions were loaded from custom data.",2));return;}default:l(g,"the argument wasn't recognised");return;}}void l(string g,string Ã){À.Add(new Á(
"COMMAND FAILED!","Command '"+g+"' was ignored because "+Ã,3));}void i(){if(Ä)b();if(D<Å){D++;return;}D=0;if(H){Echo(
"Parsing custom data...");Æ();H=false;return;}else if(J){Ç();if(k)Echo("Updating "+È.Count+" RSM Lcds");É();}Ê();W=Runtime.
CurrentInstructionCount;if(W>X)X=Runtime.CurrentInstructionCount;if(Ë.Ì==Í.On){K=true;L=true;}else if(Ë.Ì==Í.Off){K=true;}if(F>=c){F=0;Î();
return;}F++;Ï();Ð();if(Ä)Echo("Took "+b());if(k)Echo("Updating "+È.Count+" RSM Lcds");É();if(Ä)Echo("Took "+b());}void Ï(){Ñ()
;switch(C){case 0:if(k)Echo("Refreshing "+(Ò.Count+Ó.Count)+" kinetics...");Ô();if(Ä)Echo("Took "+b());if(I)break;else
goto case 1;case 1:if(k)Echo("Refreshing "+Õ.Count+" reactors & "+Ö.Count+" batteries...");Ø(Ë.Ù);if(Ä)Echo("Took "+b());if(
I)break;else goto case 2;case 2:if(k)Echo("Refreshing "+Ú.Count+" epsteins...");Û();if(Ä)Echo("Took "+b());if(I)break;
else goto case 3;case 3:if(k)Echo("Refreshing "+Ü.Count+" lidars...");Ý(L,K);if(Ä)Echo("Took "+b());if(k)Echo(
"Refreshing pb servers...");Þ();if(Ä)Echo("Took "+b());if(I)break;else goto case 4;case 4:if(k)Echo("Refreshing "+ß.Count+" doors...");à();if(Ä)
Echo("Took "+b());if(k)Echo("Refreshing "+á.Count+" airlocks...");â();if(Ä)Echo("Took "+b());break;default:if(k)Echo(
"Booting complete");I=false;C=0;return;}if(I)C++;}void Ð(){switch(E){case 0:if(k)Echo("Clearing temp inventories...");ã();if(Ä)Echo(
"Took "+b());if(k)Echo("Refreshing "+ä.Count+" torpedo launchers...");å();if(Ä)Echo("Took "+b());if(k)Echo(
"Refreshing items...");æ();if(Ä)Echo("Took "+b());break;case 1:if(k)Echo("Running autoload...");ç();if(Ä)Echo("Took "+b());E=0;return;}E++;}
void Ĉ(){if(k)Echo("Refreshing "+è.Count+" rcs...");é();if(k)Echo("Refreshing "+ê.Count+" Pdcs & "+ë.Count+
" defensive Pdcs...");ì();if(k)Echo("Refreshing "+í.Count+" gyros...");î(L,K);if(k)Echo("Refreshing "+ï.Count+" RCS gyros...");ð();if(k)Echo
("Refreshing "+ñ.Count+" O2 tanks...");ò();if(k)Echo("Refreshing "+ó.Count+" antennas...");ô();if(k)Echo("Refreshing "+õ.
Count+" cargos...");ö();if(k)Echo("Refreshing "+ø.Count+" vents...");ù(L,K);if(k)Echo("Refreshing "+ú.Count+
" auxiliary blocks...");û();if(k)Echo("Refreshing "+ü.Count+" welders...");ý();if(k)Echo("Refreshing "+þ.Count+" lcds...");ÿ();if(k)Echo(
"Refreshing "+Ā.Count+" lcds...");ā();if(K){if(k)Echo("Refreshing "+Ă.Count+" connectors...");ă(L);if(k)Echo("Refreshing "+Ą.Count+
" cameras...");ą(L);if(k)Echo("Refreshing "+Ć.Count+" sensors...");ć(L);}}void Î(){if(k)Echo("Clearing block lists...");ĉ();if(Ä)Echo
("Took "+b());if(k)Echo("Refreshing block lists...");GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,Ċ);
if(Ä)Echo("Took "+b());if(ċ==null){if(Č.Count>0)ċ=Č[0];else À.Add(new Á("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(k)Echo("Finished block refresh.");if(Ä)Echo("Took "+b());}void Ñ(){try{č=new Ď();č.ď(Me);}catch(Exception Đ){č=
null;À.Add(new Á("WcPbApi Error!","WcPbApi failed to start!\n"+Đ.Message,1));Echo("WcPbAPI failed to activate!");Echo(Đ.
Message);return;}}void Ê(){string đ="REEDIT SHIP MANAGEMENT \n\n";if(I)đ+="Booting, please wait ("+C+"/5)...\n\n";đ+="|- V "+
Version+"\n|- Ship Name: "+Ē+"\n|- Stance: "+ē+"\n|- Step: "+F+"/"+c+" ("+E+")";if(Ä){B.Ĕ();đ+="\n|- Runtime Av/Tick: "+(Math.
Round(B.ĕ,2)/100)+" ms"+"\n|- Runtime Max: "+Math.Round(B.Ė,4)+" ms"+"\n|- Instructions: "+W+" ("+X+")";}Echo(đ+"\n");}long ė
=0;string b(){long Ę=DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;if(ė==0){ė=Ę;return"0 ms";}long ę=Ę-ė;ė=Ę;return ę+
" ms";}bool Ě=false;string ě="";double Ĝ=0;void ô(){Ě=false;Ĝ=0;foreach(IMyRadioAntenna ĝ in ó){if(ĝ!=null&&!ĝ.Closed&&ĝ.
IsFunctional){float Ğ=ĝ.Radius;if(Ğ>Ĝ)Ĝ=Ğ;if(ĝ.IsBroadcasting&&ĝ.Enabled)Ě=true;}}}void x(string ğ){ě=ğ;foreach(IMyTerminalBlock Ġ
in ó){IMyRadioAntenna ĝ=Ġ as IMyRadioAntenna;if(ĝ!=null)ĝ.HudText=ğ;}}void ç(){if(!ġ)return;foreach(var ģ in Ģ){if(!ģ.Ĥ&&!
ģ.ĥ)continue;if(k)Echo("Checking "+ģ.Ħ);List<ħ>Ī=ģ.Ĩ.Concat(ģ.ĩ).ToList();List<ħ>ī=new List<ħ>();List<ħ>Ĭ=new List<ħ>();
List<ħ>ĭ=new List<ħ>();List<ħ>Į=new List<ħ>();List<ħ>į=new List<ħ>();int İ=0;int ı=0;double Ĳ=.97;if(ģ.ĳ<1)Ĳ=ģ.ĳ*.97;foreach
(ħ Ĵ in Ī){if(Ĵ==null)continue;if(Ĵ.ĵ){ı++;İ+=Ĵ.Ķ;if(Ĵ.ķ<Ĳ)ĭ.Add(Ĵ);else if(ģ.ĳ<1&&Ĵ.ķ>ģ.ĳ*1.03)Į.Add(Ĵ);if(Ĵ.ķ!=0)Ĭ.Add(
Ĵ);}else{į.Add(Ĵ);if(Ĵ.Ķ>0){ī.Add(Ĵ);}}}if(ĭ.Count>0){int ĸ=(int)(İ/ı);ĭ=ĭ.OrderBy(Ĺ=>Ĺ.Ķ).ToList();if(ģ.ĺ>0){if(k)Echo(
"Loading "+ģ.Ļ.SubtypeId+"...");ī=ī.OrderByDescending(Ĺ=>Ĺ.Ķ).ToList();ļ(ī,ĭ,ģ.Ļ,-1,ģ.ĳ);}else{if(k)Echo("Balancing "+ģ.Ļ.
SubtypeId+"...");Ĭ=Ĭ.OrderByDescending(Ĺ=>Ĺ.Ķ).ToList();ļ(Ĭ,ĭ,ģ.Ļ,ĸ);}}else if(Į.Count>0){if(k)Echo("Unloading "+ģ.Ļ.SubtypeId+
"...");List<ħ>Ľ=new List<ħ>();if(ī.Count>0)Ľ=ī;else Ľ=į;ļ(Į,Ľ,ģ.Ļ,-1,1,ģ.ĳ);}else{if(k)Echo("No loading required "+ģ.Ļ.
SubtypeId+"...");}}}void û(){P=0;foreach(IMyTerminalBlock Ġ in ú){if(Ġ==null)continue;if(Ġ.IsWorking)P++;}}void Ń(Í ľ){if(ľ==Í.
NoChange)return;foreach(IMyTerminalBlock Ġ in ú){if(Ġ==null)continue;try{bool Ŀ=Ġ.BlockDefinition.ToString().Contains("ToolCore"
);if(ľ==Í.On||Ŀ)Ġ.ApplyAction("OnOff_On");else if(!Ŀ)Ġ.ApplyAction("OnOff_Off");if(Ŀ){ITerminalAction ŀ=Ġ.
GetActionWithName("ToolCore_Shoot_Action");if(ŀ!=null){StringBuilder Ł=new StringBuilder();ŀ.WriteValue(Ġ,Ł);string ł=Ł.ToString();if(k)
Echo(ł);if(ł=="Active"&&ľ==Í.Off)ŀ.Apply(Ġ);else if(ł=="Inactive"&&ľ==Í.On)ŀ.Apply(Ġ);}}}catch{if(k)Echo(
"Failed to set aux block "+Ġ.CustomName);}}}IMyShipController ċ;List<IMyRadioAntenna>ó=new List<IMyRadioAntenna>();List<IMyBatteryBlock>Ö=new List
<IMyBatteryBlock>();List<IMyCameraBlock>Ą=new List<IMyCameraBlock>();List<IMyCargoContainer>õ=new List<IMyCargoContainer>
();List<IMyShipConnector>Ă=new List<IMyShipConnector>();List<IMyShipController>Č=new List<IMyShipController>();List<
IMyAirtightHangarDoor>ń=new List<IMyAirtightHangarDoor>();List<IMyTerminalBlock>Ņ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ņ=new
List<IMyTerminalBlock>();List<IMyGyro>í=new List<IMyGyro>();List<IMyGyro>ï=new List<IMyGyro>();List<IMyProjector>ª=new List<
IMyProjector>();List<IMyReactor>Õ=new List<IMyReactor>();List<IMySensorBlock>Ć=new List<IMySensorBlock>();List<IMyTerminalBlock>Ā=
new List<IMyTerminalBlock>();List<IMyGasTank>Ň=new List<IMyGasTank>();List<IMyGasTank>ñ=new List<IMyGasTank>();List<
IMyAirVent>ø=new List<IMyAirVent>();List<IMyTerminalBlock>ü=new List<IMyTerminalBlock>();List<IMyConveyorSorter>Ü=new List<
IMyConveyorSorter>();List<IMyTerminalBlock>ê=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ë=new List<IMyTerminalBlock>();List<
IMyTerminalBlock>Ò=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ó=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ä=new List<
IMyTerminalBlock>();List<IMyThrust>Ú=new List<IMyThrust>();List<IMyThrust>è=new List<IMyThrust>();List<IMyThrust>ň=new List<IMyThrust>()
;List<IMyThrust>ŉ=new List<IMyThrust>();List<IMyProgrammableBlock>Ŋ=new List<IMyProgrammableBlock>();List<
IMyProgrammableBlock>ŋ=new List<IMyProgrammableBlock>();List<IMyTextPanel>þ=new List<IMyTextPanel>();List<IMyTextPanel>Ō=new List<
IMyTextPanel>();List<ō>È=new List<ō>();List<IMyLightingBlock>Ŏ=new List<IMyLightingBlock>();List<IMyLightingBlock>ŏ=new List<
IMyLightingBlock>();List<IMyLightingBlock>Ő=new List<IMyLightingBlock>();List<IMyLightingBlock>ő=new List<IMyLightingBlock>();List<
IMyReflectorLight>Œ=new List<IMyReflectorLight>();List<IMyTerminalBlock>ú=new List<IMyTerminalBlock>();List<IMyTerminalBlock>œ=new List<
IMyTerminalBlock>();List<Ŕ>ß=new List<Ŕ>();List<ŕ>á=new List<ŕ>();Dictionary<IMyTerminalBlock,string>Ŗ=new Dictionary<IMyTerminalBlock,
string>();bool Ċ(IMyTerminalBlock ŗ){try{if(!Me.IsSameConstructAs(ŗ))return false;string Ř=ŗ.GetOwnerFactionTag();if(Ř!=S&&Ř!=
""){Echo("!"+Ř+": "+ŗ.CustomName);O++;return false;}if(ŗ.CustomName.Contains(ř))return false;if(!J&&Ś&&!ŗ.CustomName.
Contains(Ē))return false;string ś=ŗ.BlockDefinition.ToString();if(ŗ.CustomName.Contains(Ŝ)){ú.Add(ŗ);}if(ś.Contains(
"MedicalRoom/")){if(M)ŗ.CustomData=U;else ŗ.CustomData=T;Ā.Add(ŗ);if(J)Ŗ.Add(ŗ,"Medical Room");return false;}if(ś.Contains(
"SurvivalKit/")){if(M)ŗ.CustomData=U;else ŗ.CustomData=T;Ā.Add(ŗ);if(J)Ŗ.Add(ŗ,"Survival Kit");return false;}if(ś==
"MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(J)Ŗ.Add(ŗ,"Refill Station");return false;}var ŝ=ŗ as IMyTextPanel;if(ŝ!=null){þ.Add(ŝ);if(J)Ŗ.Add(ŗ,"LCD");if(ŝ.
CustomName.Contains(Ş)){ō ş=new ō();ş.Ġ=ŝ;È.Add(Š(ş));}else if(!š&&ŝ.CustomName.Contains(Ţ))Ō.Add(ŝ);return false;}if(ś.Contains(
"sdx_pdc")){if(ś.Contains("sdx_pdcImprovised"))return ţ(ŗ,"Improv",3);if(ś.Contains("sdx_pdcMcrnAdv"))return ţ(ŗ,"Maegnus",2);if(
ś.Contains("sdx_pdcOpaAdv"))return ţ(ŗ,"Fragmanta",2);if(ś.Contains("sdx_pdcUnnAdv"))return ţ(ŗ,"Redfield",4);if(ś.
Contains("sdx_pdcMcrn"))return ţ(ŗ,"Nariman",4);if(ś.Contains("sdx_pdcOpa"))return ţ(ŗ,"Kess",4);if(ś.Contains("sdx_pdcUnn"))
return ţ(ŗ,"Mikazuki",4);}if(ś.Contains("sdx_torpedoLauncher")){string Ť="Unknown";if(ś.Contains("Improvised"))Ť="Improv";else
if(ś.Contains("Light"))Ť="Light";else if(ś.Contains("Medium"))Ť="Medium";if(ś.Contains("Single"))Ť+="x1";else if(ś.
Contains("Double"))Ť+="x2";else if(ś.Contains("Triple"))Ť+="x3";return ť(ŗ,Ť);}if(ś.Contains("sdx_railgun")){string Ť="Unknown";
int Ŧ=13;if(ś.Contains("Fixed"))Ť="Fixed";if(ś.Contains("Improvised")){Ť+="Improv";}else if(ś.Contains("Light")){Ť+="Light"
;Ŧ=14;}else if(ś.Contains("Medium")){Ť+="Medium";Ŧ=15;}return ŧ(ŗ,Ť,Ŧ);}var Ũ=ŗ as IMyThrust;if(Ũ!=null){if(ś.ToUpper().
Contains("RCS")){è.Add(Ũ);if(J)Ŗ.Add(ŗ,"RCS");}else if(ś.Contains("Hydro")){ň.Add(Ũ);if(J)Ŗ.Add(ŗ,"Chem");}else if(ś.Contains(
"Atmospheric")){ŉ.Add(Ũ);if(J)Ŗ.Add(ŗ,"Atmo");}else{Ú.Add(Ũ);if(J){string ũ="";if(Ū){try{ũ=ŗ.DefinitionDisplayNameText.Split('"')[1];
ũ=ū+ũ[0].ToString().ToUpper()+ũ.Substring(1).ToLower();}catch{if(k)Echo("Failed to get drive type from "+ŗ.
DefinitionDisplayNameText);}}Ŗ.Add(ŗ,"Epstein"+ũ);}}return false;}var Ŭ=ŗ as IMyCargoContainer;if(Ŭ!=null){string ŭ=ś.Split('/')[1];if(ŭ.Contains
("Container")||ŭ.Contains("Cargo")){õ.Add(Ŭ);Ů(ŗ);if(J){double ů=ŗ.GetInventory().MaxVolume.RawValue;double Ű=Math.Round(
ů/1265625024,1);if(Ű==0)Ű=0.1;Ŗ.Add(ŗ,"Cargo ["+Ű+"]");}return false;}}var ű=ŗ as IMyGyro;if(ű!=null){string Ų=
"Gyroscope";if(ś.Contains("rcsGyroComputer")){Ų="RCS.GyroscopeComputer";ï.Add(ű);}else í.Add(ű);if(J)Ŗ.Add(ŗ,Ų);return false;}var ų
=ŗ as IMyBatteryBlock;if(ų!=null){Ö.Add(ų);if(J)Ŗ.Add(ŗ,"Power"+ū+"Battery");return false;}var Ŵ=ŗ as IMyReflectorLight;
if(Ŵ!=null){Œ.Add(Ŵ);if(J)Ŗ.Add(ŗ,"Spotlight");return false;}var ŵ=ŗ as IMyLightingBlock;if(ŵ!=null){if(ŗ.CustomName.
ToUpper().Contains("INTERIOR")){ŏ.Add(ŵ);if(J)Ŗ.Add(ŗ,"Light"+ū+"Interior");}else if(ś.Contains("Kitchen")||ś.Contains(
"Aquarium")){ŏ.Add(ŵ);if(J)Ŗ.Add(ŗ,"Light"+ū+"Interior"+ū+ŗ.DefinitionDisplayNameText);}else if(ŗ.CustomName.Contains(Ŷ)){if(ŗ.
CustomName.ToUpper().Contains("STARBOARD")){ő.Add(ŵ);if(J)Ŗ.Add(ŗ,"Light"+ū+"Nav"+ū+"Starboard");}else{Ő.Add(ŵ);if(J)Ŗ.Add(ŗ,
"Light"+ū+"Nav"+ū+"Port");}}else{Ŏ.Add(ŵ);if(J)Ŗ.Add(ŗ,"Light"+ū+"Exterior");}return false;}var ŷ=ŗ as IMyGasTank;if(ŷ!=null){
if(ś.Contains("Hydro")){Ň.Add(ŷ);if(J)Ŗ.Add(ŗ,"Tank"+ū+"Hydrogen");}else{ñ.Add(ŷ);if(J)Ŗ.Add(ŗ,"Tank"+ū+"Oxygen");}return
false;}var Ÿ=ŗ as IMyReactor;if(Ÿ!=null){Õ.Add(Ÿ);Ů(ŗ,0);if(J){string Ź="Lg";if(ś.Contains("SmallGenerator"))Ź="Sm";else if(ś
.Contains("MCRN"))Ź="MCRN";Ŗ.Add(ŗ,"Power"+ū+"Reactor"+ū+Ź);}return false;}var ź=ŗ as IMyShipController;if(ź!=null){Č.Add
(ź);if(ċ==null&&ŗ.CustomName.Contains("Nav"))ċ=ź;if(ź.HasInventory)Ů(ŗ);if(J&&ś.Contains("Cockpit/")){if(ś.Contains(
"StandingCockpit")||ś.Contains("Console")){Ŗ.Add(ŗ,"Console");return false;}else if(ś.Contains("Cockpit")){Ŗ.Add(ŗ,"Cockpit");return
false;}}}var Ż=ŗ as IMyDoor;if(Ż!=null){Ŕ ż=new Ŕ();ż.Ġ=Ż;if(ŗ.CustomName.Contains(Ž)){try{string ž=ŗ.CustomName.Split(ū)[3];
ż.ſ=true;bool ƀ=false;foreach(ŕ Ɓ in á){if(ž==Ɓ.Ƃ){Ɓ.ƃ.Add(ż);ƀ=true;break;}}if(!ƀ){ŕ Ƅ=new ŕ();Ƅ.Ƃ=ž;Ƅ.ƃ.Add(ż);á.Add(Ƅ)
;}}catch{if(k)Echo("Error with airlock door name "+ŗ.CustomName);ß.Add(ż);}}else{ß.Add(ż);}if(J)Ŗ.Add(ŗ,"Door");return
false;}var ƅ=ŗ as IMyAirVent;if(ƅ!=null){ø.Add(ƅ);if(ŗ.CustomName.Contains(Ž)){try{string ž=ŗ.CustomName.Split(ū)[3];bool ƀ=
false;foreach(ŕ Ɓ in á){if(ž==Ɓ.Ƃ){Ɓ.Ɔ.Add(ƅ);ƀ=true;break;}}if(!ƀ){ŕ Ƅ=new ŕ();Ƅ.Ƃ=ž;Ƅ.Ɔ.Add(ƅ);á.Add(Ƅ);}}catch{if(k)Echo(
"Error with airlock vent name "+ŗ.CustomName);}}if(J)Ŗ.Add(ŗ,"Vent");return false;}var Ƈ=ŗ as IMyCameraBlock;if(Ƈ!=null){Ą.Add(Ƈ);if(J)Ŗ.Add(ŗ,"Camera"
);return false;}var ƈ=ŗ as IMyShipConnector;if(ƈ!=null){Ă.Add(ƈ);Ů(ŗ);if(J){string Ɖ="";if(ś.Contains("Passageway"))Ɖ=ū+
"Passageway";Ŗ.Add(ŗ,"Connector"+Ɖ);}return false;}var Ɗ=ŗ as IMyAirtightHangarDoor;if(Ɗ!=null){ń.Add(Ɗ);if(J)Ŗ.Add(ŗ,"Door"+ū+
"Hangar");return false;}if(ś.Contains("sdx_detectorTargeted_lidar")){var Ƌ=ŗ as IMyConveyorSorter;if(Ƌ!=null){Ü.Add(Ƌ);if(J)Ŗ.
Add(ŗ,"LiDAR");return false;}}var ƌ=ŗ as IMyRadioAntenna;if(ƌ!=null){ó.Add(ƌ);if(J)Ŗ.Add(ŗ,"Antenna");return false;}var ƍ=ŗ
as IMyProgrammableBlock;if(ƍ!=null){if(J)Ŗ.Add(ŗ,"PB Server");if(ƍ==Me)return false;try{if(ŗ.CustomData.Contains(
"Sigma_Draconis_Expanse_Server "))Ŋ.Add(ƍ);else if(ŗ.CustomData.Contains("NavConfig"))ŋ.Add(ƍ);return false;}catch{}}var Ǝ=ŗ as IMyProjector;if(Ǝ!=null)
{ª.Add(Ǝ);if(J)Ŗ.Add(ŗ,"Projector");return false;}var Ə=ŗ as IMySensorBlock;if(Ə!=null){Ć.Add(Ə);if(J)Ŗ.Add(ŗ,"Sensor");
return false;}var Ɛ=ŗ as IMyCollector;if(Ɛ!=null){Ů(ŗ);if(J)Ŗ.Add(ŗ,"Collector");return false;}if(ś.Contains("Welder")){ü.Add(
ŗ);if(J)Ŗ.Add(ŗ,"Tool"+ū+"Welder");return false;}if(J){if(ś.Contains("LandingGear/")){if(ś.Contains("Clamp"))Ŗ.Add(ŗ,
"Clamp");else if(ś.Contains("Magnetic"))Ŗ.Add(ŗ,"Mag Lock");else Ŗ.Add(ŗ,"Gear");return false;}if(ś.Contains("Drill")){Ŗ.Add(ŗ,
"Tool"+ū+"Drill");return false;}if(ś.Contains("Grinder")||ś.Contains("grinder")){Ŗ.Add(ŗ,"Tool"+ū+"Grinder");return false;}if(
ś.Contains("Solar")){Ŗ.Add(ŗ,"Solar");return false;}if(ś.Contains("ButtonPanel")){Ŗ.Add(ŗ,"Button Panel");return false;}
var Ƒ=ŗ as IMyConveyorSorter;if(Ƒ!=null){Ŗ.Add(ŗ,"Sorter");return false;}var ƒ=ŗ as IMyMotorSuspension;if(ƒ!=null){Ŗ.Add(ŗ,
"Suspension");return false;}var Ɠ=ŗ as IMyGravityGenerator;if(Ɠ!=null){Ŗ.Add(ŗ,"Grav Gen");return false;}var Ɣ=ŗ as IMyTimerBlock;if
(Ɣ!=null){Ŗ.Add(ŗ,"Timer");return false;}var ƕ=ŗ as IMyGasGenerator;if(ƕ!=null){Ŗ.Add(ŗ,"H2 Engine");return false;}var Ɩ=
ŗ as IMyBeacon;if(Ɩ!=null){Ŗ.Add(ŗ,"Beacon");return false;}Ŗ.Add(ŗ,ŗ.DefinitionDisplayNameText);}return false;}catch(
Exception Ɨ){if(k){Echo("Failed to sort "+ŗ.CustomName+"\nAdded "+Ŗ.Count+" so far.");Echo(Ɨ.Message);}return false;}}void ĉ(){ċ=
null;ó.Clear();Ö.Clear();Ą.Clear();õ.Clear();Ă.Clear();Č.Clear();ß.Clear();á.Clear();ń.Clear();Ņ.Clear();ņ.Clear();í.Clear()
;ï.Clear();ª.Clear();Õ.Clear();Ć.Clear();Ň.Clear();ñ.Clear();ø.Clear();ü.Clear();Ü.Clear();ê.Clear();ë.Clear();Ò.Clear();
Ó.Clear();ä.Clear();Ú.Clear();è.Clear();ň.Clear();ŉ.Clear();Ŋ.Clear();ŋ.Clear();þ.Clear();È.Clear();Ō.Clear();Ŏ.Clear();ŏ
.Clear();Ő.Clear();ő.Clear();Œ.Clear();ú.Clear();foreach(var ģ in Ģ)ģ.Ĩ.Clear();if(J)Ŗ.Clear();}bool ţ(IMyTerminalBlock ŗ
,string Ƙ,int Ŧ){if(ŗ.CustomName.Contains(ƙ))ë.Add(ŗ);else ê.Add(ŗ);Ů(ŗ,Ŧ);if(J){string ũ="";if(ƚ)ũ=ū+Ƙ;Ŗ.Add(ŗ,"PDC"+ũ);
}return false;}bool ť(IMyTerminalBlock ŗ,string Ƙ){ä.Add(ŗ);if(J){string ƛ="";if(ƚ)ƛ=ū+Ƙ;Ŗ.Add(ŗ,"Torpedo"+ƛ);}return
false;}bool ŧ(IMyTerminalBlock ŗ,string Ƙ,int Ŧ,bool Ɯ=false,string Ɲ="Rail"){if(Ɯ)Ó.Add(ŗ);else Ò.Add(ŗ);Ů(ŗ,Ŧ);if(J){string
ƛ="";if(Ɲ!="")Ɲ=ū+Ɲ;if(ƚ)ƛ=ū+Ƙ;Ŗ.Add(ŗ,"Kinetic"+Ɲ+ƛ);}return false;}ō Š(ō ƞ,string Ɵ=""){bool Ơ=Ɵ=="",ơ=!Ơ;string Ƣ=ƞ.Ġ.
CustomData,ƣ="RSM.LCD";string[]Ƥ=null;MyIni ƥ=new MyIni();MyIniParseResult Ʀ;if(!Ơ||Ƣ=="")ơ=true;else{try{if(Ƣ.Substring(0,12)==
"Show Header="){Ƥ=Ƣ.Split('\n');foreach(string Ƨ in Ƥ){if(Ƨ.Contains("hud")){if(Ƨ.Contains("lcd")){Ɵ=Ƨ;break;}}else if(Ƨ.Contains("=")
){string[]ƨ=Ƨ.Split('=');if(ƨ[0]=="Show Tanks & Batteries")ƞ.Ʃ=bool.Parse(ƨ[1]);else if(ƨ[0]=="Show header"||ƨ[0]==
"Show Header")ƞ.ƪ=bool.Parse(ƨ[1]);else if(ƨ[0]=="Show Header Overlay")ƞ.ƫ=bool.Parse(ƨ[1]);else if(ƨ[0]=="Show Warnings")ƞ.Ƭ=bool.
Parse(ƨ[1]);else if(ƨ[0]=="Show Inventory")ƞ.ƭ=bool.Parse(ƨ[1]);else if(ƨ[0]=="Show Thrust")ƞ.Ʈ=bool.Parse(ƨ[1]);else if(ƨ[0]
=="Show Subsystem Integrity")ƞ.Ư=bool.Parse(ƨ[1]);else if(ƨ[0]=="Show Advanced Thrust")ƞ.ư=bool.Parse(ƨ[1]);}}}else if(!ƥ.
TryParse(Ƣ,out Ʀ)){ơ=true;}else{ƞ.ƪ=ƥ.Get(ƣ,"ShowHeader").ToBoolean(ƞ.ƪ);ƞ.ƫ=ƥ.Get(ƣ,"ShowHeaderOverlay").ToBoolean(ƞ.ƫ);ƞ.Ƭ=ƥ.
Get(ƣ,"ShowWarnings").ToBoolean(ƞ.Ƭ);ƞ.Ʃ=ƥ.Get(ƣ,"ShowPowerAndTanks").ToBoolean(ƞ.Ʃ);ƞ.ƭ=ƥ.Get(ƣ,"ShowInventory").ToBoolean
(ƞ.ƭ);ƞ.Ʈ=ƥ.Get(ƣ,"ShowThrust").ToBoolean(ƞ.Ʈ);ƞ.Ư=ƥ.Get(ƣ,"ShowIntegrity").ToBoolean(ƞ.Ư);ƞ.ư=ƥ.Get(ƣ,
"ShowAdvancedThrust").ToBoolean(ƞ.ư);}}catch(Exception Đ){if(k)Echo("LCD parsing error, resetting\n"+Đ.Message);ơ=true;}}if(ƞ.ƪ&&ƞ.ƫ){ƞ.ƪ=
false;ơ=true;}if(ơ){if(Ƥ==null)Ƥ=Ƣ.Split('\n');ƥ.Set(ƣ,"ShowHeader",ƞ.ƪ);ƥ.Set(ƣ,"ShowHeaderOverlay",ƞ.ƫ);ƥ.Set(ƣ,
"ShowWarnings",ƞ.Ƭ);ƥ.Set(ƣ,"ShowPowerAndTanks",ƞ.Ʃ);ƥ.Set(ƣ,"ShowInventory",ƞ.ƭ);ƥ.Set(ƣ,"ShowThrust",ƞ.Ʈ);ƥ.Set(ƣ,"ShowIntegrity",ƞ.
Ư);ƥ.Set(ƣ,"ShowAdvancedThrust",ƞ.ư);ƥ.Set(ƣ,"Hud",Ɵ);ƞ.Ġ.CustomData=ƥ.ToString();if(Ơ)À.Add(new Á("LCD CONFIG ERROR!!",
"Failed to parse LCD config for "+ƞ.Ġ.CustomName+"!\nLCD config was reset!",3));}return ƞ;}void Ʊ(IMyTerminalBlock Ġ,bool ď){Ġ.GetActionWithName(
"ToolCore_Shoot_Action").Apply(Ġ);(Ġ as IMyConveyorSorter).GetActionWithName("ToolCore_Shoot_Action").Apply(Ġ);}void y(){List<IMyTerminalBlock>
Ʋ=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(Ʋ);string Ƴ="";foreach(
IMyTerminalBlock ƴ in Ʋ){Ƴ+=ƴ.BlockDefinition+"\n";}if(ó.Count>0&&ó[0]!=null){ó[0].CustomData=Ƴ;}}void z(string Ť){IMyTerminalBlock Ġ=
GridTerminalSystem.GetBlockWithName(Ť);List<ITerminalAction>Ƶ=new List<ITerminalAction>();Ġ.GetActions(Ƶ);List<ITerminalProperty>ƶ=new
List<ITerminalProperty>();Ġ.GetProperties(ƶ);string Ʒ=Ġ.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction Ƹ in Ƶ){Ʒ+=Ƹ.
Id+" "+Ƹ.Name+"\n";}Ʒ+="\n\n**Properties**\n\n";foreach(ITerminalProperty ƹ in ƶ){Ʒ+=ƹ.Id+" "+ƹ.TypeName+"\n";}if(ó.Count>
0&&ó[0]!=null)ó[0].CustomData=Ʒ;Ġ.CustomData=Ʒ;}void Ƽ(IMyTerminalBlock ƺ){bool ƻ=ƺ.GetValue<bool>("WC_Repel");if(!ƻ)ƺ.
ApplyAction("WC_RepelMode");}void ƽ(IMyTerminalBlock ƺ){bool ƻ=ƺ.GetValue<bool>("WC_Repel");if(ƻ)ƺ.ApplyAction("WC_RepelMode");}
void ƿ(IMyTerminalBlock ƺ){try{if(č.ƾ(ƺ,0)==VRageMath.Matrix.Zero)return;ƺ.SetValue<Int64>("WC_Shoot Mode",3);if(k)Echo(
"Shoot mode = "+ƺ.GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to manual on "+ƺ.CustomName);}}void ǀ(
IMyTerminalBlock ƺ){try{if(č.ƾ(ƺ,0)==VRageMath.Matrix.Zero)return;ƺ.SetValue<Int64>("WC_Shoot Mode",0);if(k)Echo("Shoot mode = "+ƺ.
GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to auto on "+ƺ.CustomName);}}void ǂ(){if(ċ!=null){try{Q=ċ
.GetShipSpeed();R=ċ.CalculateShipMass().PhysicalMass;}catch(Exception ǁ){Echo("Failed to get velocity or mass!");Echo(ǁ.
Message);}}}double ǃ=0;double Ǆ=0;double ǅ=0;void ö(){Ǆ=0;foreach(IMyCargoContainer ǆ in õ){if(ǆ!=null&&!ǆ.Closed&&ǆ.
IsFunctional){try{Ǆ+=ǆ.GetInventory().MaxVolume.RawValue;}catch(Exception Đ){if(k)Echo("Cargo integrity error!\n"+Đ.Message);throw Đ
;}}}ǅ=Math.Round(100*(Ǆ/ǃ));}void Ǉ(){ǃ=0;foreach(IMyCargoContainer ǆ in õ){if(ǆ!=null)ǃ+=ǆ.GetInventory().MaxVolume.
RawValue;}}MyIni ǈ=new MyIni();bool Ś=false;bool ġ=true;bool ǉ=true;bool Ǌ=true;bool ǋ=true;bool ǌ=false;string Ǎ="";bool ǎ=true
;int Ǐ=3;int ǐ=6;string ř="[I]";string Ş="[RSM]";string Ţ="[CS]";string Ŝ="Autorepair";string ƙ="Repel";string Ǒ="Min";
string ǒ="Docking";string Ŷ="Nav";string Ž="Airlock";string Ǔ="[EFC]";string ǔ="[NavOS]";char ū='.';bool ƚ=true;bool Ū=true;
List<string>Ǖ=new List<string>();bool ǖ=false;bool š=false;bool Ǘ=true;List<double>e=new List<double>();bool ǘ=false;double
Ǚ=0.5;bool k=false;bool Ä=false;int Å=0;int c=100;string Ē="";bool ȵ(){string Ƣ=Me.CustomData;string ƣ="";bool ǚ=true;
MyIniParseResult Ʀ;if(!ǈ.TryParse(Ƣ,out Ʀ)){string[]Ǜ=Ƣ.Split('\n');if(Ǜ[1]=="Reedit Ship Management"){Echo("Legacy config detected...")
;ǜ(Ƣ);return false;}else{Echo("Could not parse custom data!\n"+Ʀ.ToString());return false;}}try{ƣ="RSM.Main";Echo(ƣ);Ś=ǈ.
Get(ƣ,"RequireShipName").ToBoolean(Ś);ġ=ǈ.Get(ƣ,"EnableAutoload").ToBoolean(ġ);ǉ=ǈ.Get(ƣ,"AutoloadReactors").ToBoolean(ǉ);Ǌ
=ǈ.Get(ƣ,"AutoConfigWeapons").ToBoolean(Ǌ);ǋ=ǈ.Get(ƣ,"SetTurretFireMode").ToBoolean(ǋ);ƣ="RSM.Spawns";Echo(ƣ);ǌ=ǈ.Get(ƣ,
"PrivateSpawns").ToBoolean(ǌ);Ǎ=ǈ.Get(ƣ,"FriendlyTags").ToString(Ǎ);ƣ="RSM.Doors";Echo(ƣ);ǎ=ǈ.Get(ƣ,"EnableDoorManagement").ToBoolean(ǎ
);Ǐ=ǈ.Get(ƣ,"DoorCloseTimer").ToInt32(Ǐ);Ǐ=ǈ.Get(ƣ,"AirlockDoorDisableTimer").ToInt32(Ǐ);ƣ="RSM.Keywords";Echo(ƣ);ř=ǈ.Get
(ƣ,"Ignore").ToString(ř);Ş=ǈ.Get(ƣ,"RsmLcds").ToString(Ş);Ţ=ǈ.Get(ƣ,"ColourSyncLcds").ToString(Ţ);Ŝ=ǈ.Get(ƣ,
"AuxiliaryBlocks").ToString(Ŝ);ƙ=ǈ.Get(ƣ,"DefensivePdcs").ToString(ƙ);Ǒ=ǈ.Get(ƣ,"MinimumThrusters").ToString(Ǒ);ǒ=ǈ.Get(ƣ,
"DockingThrusters").ToString(ǒ);Ŷ=ǈ.Get(ƣ,"NavLights").ToString(Ŷ);Ž=ǈ.Get(ƣ,"Airlock").ToString(Ž);ƣ="RSM.InitNaming";Echo(ƣ);string ǝ=ǈ.
Get(ƣ,"NameDelimiter").ToString(ū.ToString());int Ǟ=0;if(ǝ.Length>1)Ǟ=1;ū=char.Parse(ǝ.Substring(Ǟ,1));ƚ=ǈ.Get(ƣ,
"NameWeaponTypes").ToBoolean(ƚ);Ū=ǈ.Get(ƣ,"NameDriveTypes").ToBoolean(Ū);string ǟ=ǈ.Get(ƣ,"BlocksToNumber").ToString("");string[]Ǡ=ǟ.
Split(',');Ǖ.Clear();foreach(string Ť in Ǡ)if(Ť!="")Ǖ.Add(Ť);ƣ="RSM.Misc";Echo(ƣ);ǖ=ǈ.Get(ƣ,"DisableLightingControl").
ToBoolean(ǖ);š=ǈ.Get(ƣ,"DisableLcdColourControl").ToBoolean(š);Ǘ=ǈ.Get(ƣ,"ShowBasicTelemetry").ToBoolean(Ǘ);string ǡ=ǈ.Get(ƣ,
"DecelerationPercentages").ToString("");string[]Ǣ=ǡ.Split(',');if(Ǣ.Length>1){e.Clear();foreach(string ǣ in Ǣ){e.Add(double.Parse(ǣ)/100);}}ǘ=ǈ.
Get(ƣ,"ShowThrustInMetric").ToBoolean(ǘ);Ǚ=ǈ.Get(ƣ,"ReactorFillRatio").ToDouble(Ǚ);Ģ[0].ĳ=Ǚ;ƣ="RSM.Debug";Echo(ƣ);k=ǈ.Get(ƣ
,"VerboseDebugging").ToBoolean(k);Ä=ǈ.Get(ƣ,"RuntimeProfiling").ToBoolean(Ä);c=ǈ.Get(ƣ,"BlockRefreshFreq").ToInt32(c);Å=ǈ
.Get(ƣ,"StallCount").ToInt32(Å);ƣ="RSM.System";Echo(ƣ);Ē=ǈ.Get(ƣ,"ShipName").ToString(Ē);ƣ="RSM.InitItems";Echo(ƣ);
foreach(ģ Ǥ in Ģ){Ǥ.ǥ=ǈ.Get(ƣ,Ǥ.Ļ.SubtypeId).ToInt32(Ǥ.ǥ);}ƣ="RSM.InitSubSystems";Echo(ƣ);Ǧ=ǈ.Get(ƣ,"Reactors").ToDouble(Ǧ);ǧ=ǈ
.Get(ƣ,"Batteries").ToDouble(ǧ);Ǩ=ǈ.Get(ƣ,"Pdcs").ToInt32(Ǩ);ǩ=ǈ.Get(ƣ,"TorpLaunchers").ToInt32(ǩ);Ǫ=ǈ.Get(ƣ,
"KineticWeapons").ToInt32(Ǫ);ǫ=ǈ.Get(ƣ,"H2Storage").ToDouble(ǫ);Ǭ=ǈ.Get(ƣ,"O2Storage").ToDouble(Ǭ);ǭ=ǈ.Get(ƣ,"MainThrust").ToSingle(ǭ);Ǯ
=ǈ.Get(ƣ,"RCSThrust").ToSingle(Ǯ);ǯ=ǈ.Get(ƣ,"Gyros").ToDouble(ǯ);ǃ=ǈ.Get(ƣ,"CargoStorage").ToDouble(ǃ);ǰ=ǈ.Get(ƣ,
"Welders").ToInt32(ǰ);}catch(Exception Đ){Ǳ(Đ,"Failed to parse section\n"+ƣ);}Echo("Parsing stances...");Dictionary<string,ǲ>ǳ=
new Dictionary<string,ǲ>();List<string>Ǵ=new List<string>();ǈ.GetSections(Ǵ);foreach(string ǵ in Ǵ){if(ǵ.Contains(
"RSM.Stance.")){string Ƕ=ǵ.Substring(11);Echo(Ƕ);ǲ Ƿ=new ǲ();string Ǹ,ǹ="";string[]Ǻ;int ǻ=33,Ǽ=144,ŗ=255,Ĺ=255;bool ǽ=false;ǲ Ǿ=null
;ǹ="Inherits";if(ǈ.ContainsKey(ǵ,ǹ)){ǽ=true;try{Ǿ=ǳ[ǈ.Get(ǵ,ǹ).ToString()];Echo("Inherits "+ǈ.Get(ǵ,ǹ).ToString());}catch
(Exception Đ){Ǳ(Đ,"Failed to find inheritee for\n"+ǵ+"\nEnsure inheritee stances are\nlisted before their heirs");}}try{
if(ǽ)Echo(Ǿ.ǿ.ToString());ǹ="Torps";if(ǈ.ContainsKey(ǵ,ǹ)){Ƿ.ǿ=(Ȁ)Enum.Parse(typeof(Ȁ),ǈ.Get(ǵ,ǹ).ToString());}else if(ǽ){
Ƿ.ǿ=Ǿ.ǿ;}else{Ƿ.ǿ=ȁ;}ǹ="Pdcs";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ȃ=(ȃ)Enum.Parse(typeof(ȃ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȃ=Ǿ.Ȃ;
else Ƿ.Ȃ=Ȅ;ǹ="Kinetics";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.ȅ=(Ȇ)Enum.Parse(typeof(Ȇ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.ȅ=Ǿ.ȅ;else Ƿ.ȅ=
ȇ;ǹ="MainThrust";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ȉ=(ȉ)Enum.Parse(typeof(ȉ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȉ=Ǿ.Ȉ;else Ƿ.Ȉ=Ȋ;ǹ=
"ManeuveringThrust";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.ȋ=(Ȍ)Enum.Parse(typeof(Ȍ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.ȋ=Ǿ.ȋ;else Ƿ.ȋ=ȍ;ǹ="Spotlights";if
(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ȏ=(ȏ)Enum.Parse(typeof(ȏ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȏ=Ǿ.Ȏ;else Ƿ.Ȏ=Ȑ;ǹ="ExteriorLights";if
(ǈ.ContainsKey(ǵ,ǹ))Ƿ.ȑ=(Ȓ)Enum.Parse(typeof(Ȓ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.ȑ=Ǿ.ȑ;else Ƿ.ȑ=ȓ;ǹ=
"ExteriorLightColour";if(ǈ.ContainsKey(ǵ,ǹ)){Ǹ=ǈ.Get(ǵ,ǹ).ToString();Ǻ=Ǹ.Split(',');ǻ=int.Parse(Ǻ[0]);Ǽ=int.Parse(Ǻ[1]);ŗ=int.Parse(Ǻ[2]);Ĺ=
int.Parse(Ǻ[3]);Ƿ.Ȕ=new Color(ǻ,Ǽ,ŗ,Ĺ);}else if(ǽ)Ƿ.Ȕ=Ǿ.Ȕ;else Ƿ.Ȕ=ȕ;ǹ="InteriorLights";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ȗ=(Ȓ)Enum.
Parse(typeof(Ȓ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȗ=Ǿ.Ȗ;else Ƿ.Ȗ=ȗ;ǹ="InteriorLightColour";if(ǈ.ContainsKey(ǵ,ǹ)){Ǹ=ǈ.Get(ǵ,
ǹ).ToString();Ǻ=Ǹ.Split(',');ǻ=int.Parse(Ǻ[0]);Ǽ=int.Parse(Ǻ[1]);ŗ=int.Parse(Ǻ[2]);Ĺ=int.Parse(Ǻ[3]);Ƿ.Ș=new Color(ǻ,Ǽ,ŗ,
Ĺ);}else if(ǽ)Ƿ.Ș=Ǿ.Ș;else Ƿ.Ș=ș;ǹ="NavLights";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ț=(Ȓ)Enum.Parse(typeof(Ȓ),ǈ.Get(ǵ,ǹ).ToString());
else if(ǽ)Ƿ.Ț=Ǿ.Ț;else Ƿ.Ț=ț;ǹ="LcdTextColour";if(ǈ.ContainsKey(ǵ,ǹ)){Ǹ=ǈ.Get(ǵ,ǹ).ToString();Ǻ=Ǹ.Split(',');ǻ=int.Parse(Ǻ[0
]);Ǽ=int.Parse(Ǻ[1]);ŗ=int.Parse(Ǻ[2]);Ĺ=int.Parse(Ǻ[3]);Ƿ.Ȝ=new Color(ǻ,Ǽ,ŗ,Ĺ);}else if(ǽ)Ƿ.Ȝ=Ǿ.Ȝ;else Ƿ.Ȝ=ȝ;ǹ=
"TanksAndBatteries";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ù=(Ȟ)Enum.Parse(typeof(Ȟ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ù=Ǿ.Ù;else Ƿ.Ù=ȟ;ǹ=
"NavOsEfcBurnPercentage";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ƞ=ǈ.Get(ǵ,"NavOsEfcBurnPercentage").ToInt32(ȡ);else if(ǽ)Ƿ.Ƞ=Ǿ.Ƞ;else Ƿ.Ƞ=ȡ;ǹ="EfcBoost";if(ǈ.
ContainsKey(ǵ,ǹ))Ƿ.Ȣ=(Í)Enum.Parse(typeof(Í),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȣ=Ǿ.Ȣ;else Ƿ.Ȣ=ȣ;ǹ="NavOsAbortEfcOff";if(ǈ.
ContainsKey(ǵ,ǹ))Ƿ.Ȥ=(ȥ)Enum.Parse(typeof(ȥ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȥ=Ǿ.Ȥ;else Ƿ.Ȥ=Ȧ;ǹ="NavOsAbortEfcOff";if(ǈ.
ContainsKey(ǵ,ǹ))Ƿ.Ȥ=(ȥ)Enum.Parse(typeof(ȥ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȥ=Ǿ.Ȥ;else Ƿ.Ȥ=Ȧ;ǹ="AuxMode";if(ǈ.ContainsKey(ǵ,ǹ))
Ƿ.ȧ=(Í)Enum.Parse(typeof(Í),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.ȧ=Ǿ.ȧ;else Ƿ.ȧ=Ȩ;ǹ="Extractor";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.ȩ=(
Ȫ)Enum.Parse(typeof(Ȫ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.ȩ=Ǿ.ȩ;else Ƿ.ȩ=ȫ;ǹ="KeepAlives";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ì=(Í)
Enum.Parse(typeof(Í),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ì=Ǿ.Ì;else Ƿ.Ì=Ȭ;ǹ="HangarDoors";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.ȭ=(Ȯ)Enum.
Parse(typeof(Ȯ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.ȭ=Ǿ.ȭ;else Ƿ.ȭ=ȯ;ǹ="RcsGyroscopes";if(ǈ.ContainsKey(ǵ,ǹ))Ƿ.Ȱ=(ȱ)Enum.Parse
(typeof(ȱ),ǈ.Get(ǵ,ǹ).ToString());else if(ǽ)Ƿ.Ȱ=Ǿ.Ȱ;else Ƿ.Ȱ=Ȳ;ǳ.Add(Ƕ,Ƿ);}catch(Exception Đ){Ǳ(Đ,
"Failed to parse stance\n"+Ƕ+"\nproperty\n"+ǹ);}}}if(ǳ.Count<1){Echo("Failed to parse any stances!\nStances reset to default!");ǚ=false;}else{Echo
("Finished parsing "+ǳ.Count+" stances.");ȳ=ǳ;}ƣ="RSM.Stance";Echo(ƣ);ē=ǈ.Get(ƣ,"CurrentStance").ToString(ē);ǲ ȴ;if(!ȳ.
TryGetValue(ē,out ȴ)){ē="N/A";Ë=null;}else Ë=ȴ;return ǚ;}void Ɂ(){ǈ.Clear();string ƣ,Ť;ƣ="RSM.Main";Ť="RequireShipName";ǈ.Set(ƣ,Ť,Ś
);ǈ.SetComment(ƣ,Ť,"limit to blocks with the ship name in their name");Ť="EnableAutoload";ǈ.Set(ƣ,Ť,ġ);ǈ.SetComment(ƣ,Ť,
"enable RSM loading & balancing functionality for weapons");Ť="AutoloadReactors";ǈ.Set(ƣ,Ť,ǉ);ǈ.SetComment(ƣ,Ť,"enable loading and balancing for reactors");Ť="AutoConfigWeapons";
ǈ.Set(ƣ,Ť,Ǌ);ǈ.SetComment(ƣ,Ť,"automatically configure weapon on stance set");Ť="SetTurretFireMode";ǈ.Set(ƣ,Ť,ǋ);ǈ.
SetComment(ƣ,Ť,"set turret fire mode based on stance");ǈ.SetSectionComment(ƣ,ȶ+" Reedit Ship Management\n"+ȶ+
" Config.ini\n Recompile to apply changes!\n"+ȶ);ƣ="RSM.Spawns";Ť="PrivateSpawns";ǈ.Set(ƣ,Ť,ǌ);ǈ.SetComment(ƣ,Ť,"don't inject faction tag into spawn custom data");Ť=
"FriendlyTags";ǈ.Set(ƣ,Ť,Ǎ);ǈ.SetComment(ƣ,Ť,"Comma seperated friendly factions or steam ids");ƣ="RSM.Doors";Ť="EnableDoorManagement";
ǈ.Set(ƣ,Ť,ǎ);ǈ.SetComment(ƣ,Ť,"enable door management functionality");Ť="DoorCloseTimer";ǈ.Set(ƣ,Ť,Ǐ);ǈ.SetComment(ƣ,Ť,
"door open timer (x100 ticks)");Ť="AirlockDoorDisableTimer";ǈ.Set(ƣ,Ť,ǐ);ǈ.SetComment(ƣ,Ť,"airlock door disable timer (x100 ticks)");ƣ="RSM.Keywords";
Ť="Ignore";ǈ.Set(ƣ,Ť,ř);ǈ.SetComment(ƣ,Ť,"to identify blocks which RSM should ignore");Ť="RsmLcds";ǈ.Set(ƣ,Ť,Ş);ǈ.
SetComment(ƣ,Ť,"to identify RSM lcds");Ť="ColourSyncLcds";ǈ.Set(ƣ,Ť,Ţ);ǈ.SetComment(ƣ,Ť,"to identify non RSM lcds for colour sync"
);Ť="AuxiliaryBlocks";ǈ.Set(ƣ,Ť,Ŝ);ǈ.SetComment(ƣ,Ť,"to identify aux blocks");Ť="DefensivePdcs";ǈ.Set(ƣ,Ť,ƙ);ǈ.SetComment
(ƣ,Ť,"to identify defensive _normalPdcs");Ť="MinimumThrusters";ǈ.Set(ƣ,Ť,Ǒ);ǈ.SetComment(ƣ,Ť,
"to identify minimum epsteins");Ť="DockingThrusters";ǈ.Set(ƣ,Ť,ǒ);ǈ.SetComment(ƣ,Ť,"to identify docking epsteins");Ť="NavLights";ǈ.Set(ƣ,Ť,Ŷ);ǈ.
SetComment(ƣ,Ť,"to identify navigational lights");Ť="Airlock";ǈ.Set(ƣ,Ť,Ž);ǈ.SetComment(ƣ,Ť,"to identify airlock doors and vents")
;ƣ="RSM.InitNaming";Ť="NameDelimiter";ǈ.Set(ƣ,Ť,'"'+ū.ToString()+'"');ǈ.SetComment(ƣ,Ť,"single char delimiter for names")
;Ť="NameWeaponTypes";ǈ.Set(ƣ,Ť,ƚ);ǈ.SetComment(ƣ,Ť,"append type names to all weapons on init");Ť="NameDriveTypes";ǈ.Set(ƣ
,Ť,Ū);ǈ.SetComment(ƣ,Ť,"append type names to all drives on init");string ȷ="";foreach(string ȸ in Ǖ){if(ȷ!="")ȷ+=",";ȷ+=ȸ
;}Ť="BlocksToNumber";ǈ.Set(ƣ,Ť,Ū);ǈ.SetComment(ƣ,Ť,"comma seperated list of block names to be numbered at init");ƣ=
"RSM.Misc";Ť="DisableLightingControl";ǈ.Set(ƣ,Ť,ǖ);ǈ.SetComment(ƣ,Ť,"disable all lighting control");Ť="DisableLcdColourControl";ǈ.
Set(ƣ,Ť,š);ǈ.SetComment(ƣ,Ť,"disable text colour control for all lcds");Ť="ShowBasicTelemetry";ǈ.Set(ƣ,Ť,Ǘ);ǈ.SetComment(ƣ,
Ť,"show basic telemetry data on advanced thrust lcds");string ȹ="";foreach(double Ⱥ in e){if(ȹ!="")ȹ+=",";ȹ+=(Ⱥ*100).
ToString();}Ť="DecelerationPercentages";ǈ.Set(ƣ,Ť,ȹ);ǈ.SetComment(ƣ,Ť,"thrust percentages to show on advanced thrust lcds");Ť=
"ShowThrustInMetric";ǈ.Set(ƣ,Ť,ǘ);ǈ.SetComment(ƣ,Ť,"show basic telemetry data on advanced thrust lcds");Ť="ReactorFillRatio";ǈ.Set(ƣ,Ť,Ǚ);ǈ.
SetComment(ƣ,Ť,"0-1, fill ratio for reactors");ƣ="RSM.Debug";Ť="VerboseDebugging";ǈ.Set(ƣ,Ť,k);ǈ.SetComment(ƣ,Ť,
"prints more logging info to PB details");Ť="RuntimeProfiling";ǈ.Set(ƣ,Ť,Ä);ǈ.SetComment(ƣ,Ť,"prints script runtime profiling info to PB details");Ť=
"BlockRefreshFreq";ǈ.Set(ƣ,Ť,c);ǈ.SetComment(ƣ,Ť,"ticks x100 between block refreshes");Ť="StallCount";ǈ.Set(ƣ,Ť,Å);ǈ.SetComment(ƣ,Ť,
"ticks x100 to stall between runs");ƣ="RSM.Stance";Ť="CurrentStance";ǈ.Set(ƣ,Ť,ē);ǈ.SetSectionComment(ƣ,ȶ+" Stances\n Add or remove as required\n"+ȶ);
string Ȼ="Red, Green, Blue, Alpha";foreach(var ȼ in ȳ){ƣ="RSM.Stance."+ȼ.Key;ǲ Ƚ=ȼ.Value;ǲ Ǿ=null;if(Ƚ.Ⱦ!=""){Ǿ=ȳ[Ƚ.Ⱦ];Ť=
"Inherits";ǈ.Set(ƣ,Ť,Ƚ.Ⱦ);ǈ.SetComment(ƣ,Ť,"Use stance of this name as a template for settings");}Ť="Torps";if(Ǿ!=null&&Ƚ.ǿ==Ǿ.ǿ){
if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.ǿ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȁ)));}Ť="Pdcs";if(Ǿ!=null&&Ƚ
.Ȃ==Ǿ.Ȃ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ȃ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(ȃ)));}Ť="Kinetics"
;if(Ǿ!=null&&Ƚ.ȅ==Ǿ.ȅ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.ȅ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȇ)))
;}Ť="MainThrust";if(Ǿ!=null&&Ƚ.Ȉ==Ǿ.Ȉ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ȉ.ToString());ǈ.SetComment(ƣ
,"MainThrust",ȿ(typeof(ȉ)));}Ť="ManeuveringThrust";if(Ǿ!=null&&Ƚ.ȋ==Ǿ.ȋ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(
ƣ,Ť,Ƚ.ȋ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȍ)));}Ť="Spotlights";if(Ǿ!=null&&Ƚ.Ȏ==Ǿ.Ȏ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ
,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ȏ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(ȏ)));}Ť="ExteriorLights";if(Ǿ!=null&&Ƚ.ȑ==Ǿ.ȑ){if(ǈ.
ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.ȑ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȓ)));}Ť="ExteriorLightColour";if(Ǿ!=null&&
Ƚ.Ȕ==Ǿ.Ȕ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,ɀ(Ƚ.Ȕ));ǈ.SetComment(ƣ,Ť,Ȼ);}Ť="InteriorLights";if(Ǿ!=null
&&Ƚ.Ȗ==Ǿ.Ȗ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ȗ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȓ)));}Ť=
"InteriorLightColour";if(Ǿ!=null&&Ƚ.Ș==Ǿ.Ș){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,ɀ(Ƚ.Ș));ǈ.SetComment(ƣ,Ť,Ȼ);}Ť="NavLights";if
(Ǿ!=null&&Ƚ.Ț==Ǿ.Ț){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ț.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȓ)));}Ť
="LcdTextColour";if(Ǿ!=null&&Ƚ.Ȝ==Ǿ.Ȝ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,ɀ(Ƚ.Ȝ));ǈ.SetComment(ƣ,Ť,Ȼ);}Ť
="TanksAndBatteries";if(Ǿ!=null&&Ƚ.Ù==Ǿ.Ù){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ù.ToString());ǈ.
SetComment(ƣ,Ť,ȿ(typeof(Ȟ)));}Ť="NavOsEfcBurnPercentage";if(Ǿ!=null&&Ƚ.Ƞ==Ǿ.Ƞ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť
,Ƚ.Ƞ.ToString());ǈ.SetComment(ƣ,Ť,"Burn % 0-100, -1 for no change");}Ť="EfcBoost";if(Ǿ!=null&&Ƚ.Ȣ==Ǿ.Ȣ){if(ǈ.ContainsKey(
ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ȣ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Í)));}Ť="NavOsAbortEfcOff";if(Ǿ!=null&&Ƚ.Ȥ==
Ǿ.Ȥ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ȥ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(ȥ)));}Ť="AuxMode";if(Ǿ
!=null&&Ƚ.ȧ==Ǿ.ȧ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.ȧ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Í)));}Ť=
"Extractor";if(Ǿ!=null&&Ƚ.ȩ==Ǿ.ȩ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.ȩ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȫ))
);}Ť="KeepAlives";if(Ǿ!=null&&Ƚ.Ì==Ǿ.Ì){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.Ì.ToString());ǈ.SetComment(
ƣ,Ť,ȿ(typeof(Í)));}Ť="HangarDoors";if(Ǿ!=null&&Ƚ.ȭ==Ǿ.ȭ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.Set(ƣ,Ť,Ƚ.ȭ.ToString
());ǈ.SetComment(ƣ,Ť,ȿ(typeof(Ȯ)));}Ť="RcsGyroscopes";if(Ǿ!=null&&Ƚ.Ȱ==Ǿ.Ȱ){if(ǈ.ContainsKey(ƣ,Ť))ǈ.Delete(ƣ,Ť);}else{ǈ.
Set(ƣ,Ť,Ƚ.Ȱ.ToString());ǈ.SetComment(ƣ,Ť,ȿ(typeof(ȱ)));}}ƣ="RSM.System";Ť="ShipName";ǈ.Set(ƣ,Ť,Ē);ǈ.SetSectionComment(ƣ,ȶ+
" System\n All items below this point are\n set automatically when running init\n"+ȶ);ƣ="RSM.InitItems";foreach(ģ Ǥ in Ģ){Ť=Ǥ.Ļ.SubtypeId;ǈ.Set(ƣ,Ť,Ǥ.ǥ);}ƣ="RSM.InitSubSystems";ǈ.Set(ƣ,"Reactors",Ǧ);ǈ.
Set(ƣ,"Batteries",ǧ);ǈ.Set(ƣ,"Pdcs",Ǩ);ǈ.Set(ƣ,"TorpLaunchers",ǩ);ǈ.Set(ƣ,"KineticWeapons",Ǫ);ǈ.Set(ƣ,"H2Storage",ǫ);ǈ.Set(
ƣ,"O2Storage",Ǭ);ǈ.Set(ƣ,"MainThrust",ǭ);ǈ.Set(ƣ,"RCSThrust",Ǯ);ǈ.Set(ƣ,"Gyros",ǯ);ǈ.Set(ƣ,"CargoStorage",ǃ);ǈ.Set(ƣ,
"Welders",ǰ);Me.CustomData=ǈ.ToString();}void ǜ(string Ƣ){string[]Ǵ=Ƣ.Split(new string[]{"[Stances]"},StringSplitOptions.None);
string[]ɂ=Ǵ[0].Split('\n');string Ƀ=Ǵ[1];try{for(int Ʉ=1;Ʉ<ɂ.Length;Ʉ++){if(ɂ[Ʉ].Contains("=")){string Ʌ=ɂ[Ʉ].Substring(1);
switch(ɂ[(Ʉ-1)]){case"Ship name. Blocks without this name will be ignored":Ē=Ʌ;break;case
"Block name delimiter, used by init. One character only!":ū=char.Parse(Ʌ.Substring(0,1));break;case"Keyword used to identify RSM _allLcds.":Ş=Ʌ;break;case
"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":Ŝ=Ʌ;break;case"Keyword used to identify defence _normalPdcs.":ƙ=Ʌ;break
;case"Keyword used to identify minimum epstein drives.":Ǒ=Ʌ;break;case"Keyword used to identify docking epstein drives.":
ǒ=Ʌ;break;case"Keyword to ignore block.":ř=Ʌ;break;case"Automatically configure _normalPdcs, Railguns, Torpedoes.":Ǌ=bool
.Parse(Ʌ);break;case"Disable lighting all control.":ǖ=bool.Parse(Ʌ);break;case"Disable LCD Text Colour Enforcement.":š=
bool.Parse(Ʌ);break;case"Enable Weapon Autoload Functionality.":ġ=bool.Parse(Ʌ);break;case"Number these blocks at init.":Ǖ.
Clear();string[]Ɇ=Ʌ.Split(',');foreach(string ȸ in Ɇ){if(ȸ!="")Ǖ.Add(ȸ);}break;case"Show basic telemetry.":Ǘ=bool.Parse(Ʌ);
break;case"Show Decel Percentages (comma seperated).":e.Clear();string[]ɇ=Ʌ.Split(',');foreach(string Ⱥ in ɇ){e.Add(double.
Parse(Ⱥ)/100);}break;case"Fusion Fuel count":Ģ[0].ǥ=int.Parse(Ʌ);break;case"40mm PDC Magazine count":Ģ[3].ǥ=int.Parse(Ʌ);
break;case"40mm Teflon Tungsten PDC Magazine count":Ģ[4].ǥ=int.Parse(Ʌ);break;case"220mm Torpedo count":case"Torpedo count":Ģ
[5].ǥ=int.Parse(Ʌ);break;case"220mm MCRN torpedo count":Ģ[6].ǥ=int.Parse(Ʌ);break;case"220mm UNN torpedo count":Ģ[7].ǥ=
int.Parse(Ʌ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":Ģ[8].ǥ=int.Parse(Ʌ);break;case
"Large ramshacke torpedo count":Ģ[9].ǥ=int.Parse(Ʌ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":Ģ[10].ǥ=int.Parse(Ʌ);break;
case"Dawson 100mm UNN Railgun rounds count":Ģ[11].ǥ=int.Parse(Ʌ);break;case"Stiletto 100mm MCRN Railgun rounds count":Ģ[12].
ǥ=int.Parse(Ʌ);break;case"T-47 80mm Railgun rounds count":Ģ[13].ǥ=int.Parse(Ʌ);break;case
"Foehammer 120mm MCRN rounds count":Ģ[14].ǥ=int.Parse(Ʌ);break;case"Farren 120mm UNN Railgun rounds count":Ģ[15].ǥ=int.Parse(Ʌ);break;case
"Kess 180mm rounds count":Ģ[16].ǥ=int.Parse(Ʌ);break;case"Steel plate count":Ģ[17].ǥ=int.Parse(Ʌ);break;case
"Doors open timer (x100 ticks, default 3)":Ǐ=int.Parse(Ʌ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ǐ=int.Parse(Ʌ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":Å=int.Parse(Ʌ);break;case"Full refresh frequency (x100 ticks, default 50)":c=int.Parse(Ʌ);break;case
"Verbose script debugging. Prints more logging info to PB details.":k=bool.Parse(Ʌ);break;case"Private spawn (don't inject faction tag into SK custom data).":ǌ=bool.Parse(Ʌ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":Ǎ=string.Join("\n",Ʌ.Split(','));break;case"Current Stance":ē=Ʌ;ǲ ȴ;if(!ȳ.TryGetValue(ē,out ȴ)){ē="N/A";Ë=null;}else Ë=
ȴ;break;case"Reactor Integrity":Ǧ=float.Parse(Ʌ);break;case"Battery Integrity":ǧ=float.Parse(Ʌ);break;case"PDC Integrity"
:Ǩ=int.Parse(Ʌ);break;case"Torpedo Integrity":ǩ=int.Parse(Ʌ);break;case"Railgun Integrity":Ǫ=int.Parse(Ʌ);break;case
"H2 Tank Integrity":ǫ=double.Parse(Ʌ);break;case"O2 Tank Integrity":Ǭ=double.Parse(Ʌ);break;case"Epstein Integrity":ǭ=float.Parse(Ʌ);break;
case"RCS Integrity":Ǯ=float.Parse(Ʌ);break;case"Gyro Integrity":ǯ=int.Parse(Ʌ);break;case"Cargo Integrity":ǃ=double.Parse(Ʌ)
;break;case"Welder Integrity":ǰ=int.Parse(Ʌ);break;}}}}catch(Exception Đ){Echo("Custom Data Error (vars)\n"+Đ.Message);}
try{string[]Ɉ=Ƀ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(k)Echo("Parsing "+(Ɉ.Length-1)+" stances");int ɉ=
24;Dictionary<string,ǲ>ǳ=new Dictionary<string,ǲ>();int[]Ɋ=new int[]{0,5,25,50,75,100};for(int Ʉ=1;Ʉ<Ɉ.Length;Ʉ++){string[
]ɋ=Ɉ[Ʉ].Split('=');string Ƕ="";int[]Ɍ=new int[ɉ];Ƕ=ɋ[0].Split(' ')[0];if(k)Echo("Parsing '"+Ƕ+"'");for(int ɍ=0;ɍ<Ɍ.Length
;ɍ++){string[]Ɏ=ɋ[(ɍ+1)].Split('\n');Ɍ[ɍ]=int.Parse(Ɏ[0]);}ǲ Ƿ=new ǲ();if(Ɍ[0]==0)Ƿ.ǿ=Ȁ.Off;else Ƿ.ǿ=Ȁ.On;if(Ɍ[1]==0)Ƿ.Ȃ=
ȃ.Off;else if(Ɍ[1]==1)Ƿ.Ȃ=ȃ.MinDefence;else if(Ɍ[1]==2)Ƿ.Ȃ=ȃ.AllDefence;else if(Ɍ[1]==3)Ƿ.Ȃ=ȃ.Offence;else if(Ɍ[1]==4)Ƿ.Ȃ
=ȃ.AllOnOnly;if(Ɍ[2]==0)Ƿ.ȅ=Ȇ.Off;else if(Ɍ[2]==1)Ƿ.ȅ=Ȇ.HoldFire;else if(Ɍ[2]==2)Ƿ.ȅ=Ȇ.OpenFire;if(Ɍ[3]==0)Ƿ.Ȉ=ȉ.Off;else
if(Ɍ[3]==1)Ƿ.Ȉ=ȉ.On;else if(Ɍ[3]==2)Ƿ.Ȉ=ȉ.Minimum;if(Ɍ[4]==0)Ƿ.ȋ=Ȍ.Off;else if(Ɍ[4]==1)Ƿ.ȋ=Ȍ.On;else if(Ɍ[4]==2)Ƿ.ȋ=Ȍ.
ForwardOff;else if(Ɍ[4]==3)Ƿ.ȋ=Ȍ.ReverseOff;if(Ɍ[5]==0)Ƿ.Ȏ=ȏ.Off;else if(Ɍ[5]==1)Ƿ.Ȏ=ȏ.On;else if(Ɍ[5]==2)Ƿ.Ȏ=ȏ.OnMax;if(Ɍ[6]==0)Ƿ
.ȑ=Ȓ.Off;else Ƿ.ȑ=Ȓ.On;Ƿ.Ȕ=new Color(Ɍ[7],Ɍ[8],Ɍ[9],Ɍ[10]);if(Ɍ[11]==0)Ƿ.Ȗ=Ȓ.Off;else Ƿ.Ȗ=Ȓ.On;Ƿ.Ș=new Color(Ɍ[12],Ɍ[13],
Ɍ[14],Ɍ[15]);if(Ɍ[16]==0)Ƿ.Ù=Ȟ.Auto;else if(Ɍ[16]==1)Ƿ.Ù=Ȟ.StockpileRecharge;else if(Ɍ[16]==2)Ƿ.Ù=Ȟ.Discharge;if(Ɍ[17]==0
)Ƿ.Ȣ=Í.Off;else Ƿ.Ȣ=Í.On;Ƿ.Ƞ=Ɋ[Ɍ[18]];if(Ɍ[19]==0)Ƿ.Ȥ=ȥ.NoChange;else Ƿ.Ȥ=ȥ.Abort;if(Ɍ[20]==0)Ƿ.ȧ=Í.Off;else Ƿ.ȧ=Í.On;if(
Ɍ[21]==0)Ƿ.ȩ=Ȫ.Off;else if(Ɍ[21]==1)Ƿ.ȩ=Ȫ.On;else if(Ɍ[21]==2)Ƿ.ȩ=Ȫ.FillWhenLow;else if(Ɍ[21]==3)Ƿ.ȩ=Ȫ.KeepFull;if(Ɍ[22]
==0)Ƿ.Ì=Í.Off;else Ƿ.Ì=Í.On;if(Ɍ[23]==0)Ƿ.ȭ=Ȯ.Closed;else if(Ɍ[23]==1)Ƿ.ȭ=Ȯ.Open;else Ƿ.ȭ=Ȯ.NoChange;ǳ.Add(Ƕ,Ƿ);}if(ǳ.
Count>=1){if(k)Echo("Finished parsing "+ǳ.Count+" stances.");ȳ=ǳ;}else{Echo("Didn't find any stances!");}}catch(Exception Đ){
Echo("Custom Data Error (stances)\n"+Đ.Message);}}void Æ(){bool ɏ=ȵ();if(!ɏ){ɐ();Ɂ();}if(Ë==null){Ë=ȳ.First().Value;}string
ɑ="";string ɒ="";if(!ǌ){ɑ=" ".PadRight(129,' ')+S+"\n";ɒ="\n".PadRight(19,'\n');}T=ɑ+ɒ;U=ɑ+string.Join("\n",Ǎ.Split(','))
+ɒ;if(Ē==""){if(k)Echo("No ship name, trying to pull it from PB name...");string ɓ="Untitled Ship";try{string[]ɔ=Me.
CustomName.Split(ū);if(ɔ.Length>1){Ē=ɔ[0];if(k)Echo(Ē);}else Ē=ɓ;}catch{Ē=ɓ;}}}void ɖ(bool s=true,bool ɕ=false,bool p=false){MyIni
ƥ=new MyIni();string Ƣ=Me.CustomData;MyIniParseResult Ʀ;if(!ƥ.TryParse(Ƣ,out Ʀ)){À.Add(new Á("CONFIG ERROR!!",
"Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ƣ,Ť;if(s){ƣ="RSM.Stance";Ť="CurrentStance";ƥ.Set(ƣ,Ť,ē);}else{ƣ="RSM.System";Ť="ShipName";ƥ.Set(ƣ,Ť,
Ē);}if(ɕ){ƣ="RSM.InitSubSystems";ƥ.Set(ƣ,"Reactors",Ǧ);ƥ.Set(ƣ,"Batteries",ǧ);ƥ.Set(ƣ,"Pdcs",Ǩ);ƥ.Set(ƣ,"TorpLaunchers",ǩ
);ƥ.Set(ƣ,"KineticWeapons",Ǫ);ƥ.Set(ƣ,"H2Storage",ǫ);ƥ.Set(ƣ,"O2Storage",Ǭ);ƥ.Set(ƣ,"MainThrust",ǭ);ƥ.Set(ƣ,"RCSThrust",Ǯ
);ƥ.Set(ƣ,"Gyros",ǯ);ƥ.Set(ƣ,"CargoStorage",ǃ);ƥ.Set(ƣ,"Welders",ǰ);}if(p){ƣ="RSM.InitItems";foreach(ģ Ǥ in Ģ){Ť=Ǥ.Ļ.
SubtypeId;ƥ.Set(ƣ,Ť,Ǥ.ǥ);}}Me.CustomData=ƥ.ToString();}string ȿ(Type ɗ){string ɘ="";foreach(var ə in Enum.GetValues(ɗ)){if(ɘ!="")
ɘ+=", ";ɘ+=ə.ToString();}return ɘ;}string ɀ(Color ɚ){return ɚ.R+", "+ɚ.G+", "+ɚ.B+", "+ɚ.A;}void Ǳ(Exception Đ,string ɛ){
Runtime.UpdateFrequency=UpdateFrequency.None;string ɜ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ɛ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ɜ);List<IMyTextPanel>ɝ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ɝ,ŗ=>ŗ.CustomName
.Contains(Ş));foreach(IMyTextPanel ɞ in ɝ){ɞ.WriteText(ɜ);ɞ.FontColor=new Color(193,0,197,255);}throw Đ;}Dictionary<
string,ǲ>ȳ=new Dictionary<string,ǲ>();void ɐ(){ȳ=new Dictionary<string,ǲ>{{"Cruise",new ǲ{ǿ=Ȁ.On,Ȃ=ȃ.AllDefence,ȅ=Ȇ.HoldFire,Ȉ
=ȉ.EpsteinOnly,ȋ=Ȍ.ForwardOff,Ȏ=ȏ.Off,ȑ=Ȓ.On,Ȕ=new Color(33,144,255,255),Ȗ=Ȓ.On,Ș=new Color(255,214,170,255),Ț=Ȓ.On,Ȝ=new
Color(33,144,255,255),Ù=Ȟ.Auto,Ƞ=50,Ȣ=Í.NoChange,Ȥ=ȥ.Abort,ȧ=Í.NoChange,ȩ=Ȫ.KeepFull,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.On}},{
"StealthCruise",new ǲ{Ⱦ="Cruise",ǿ=Ȁ.On,Ȃ=ȃ.AllDefence,ȅ=Ȇ.HoldFire,Ȉ=ȉ.Minimum,ȋ=Ȍ.ForwardOff,Ȏ=ȏ.Off,ȑ=Ȓ.Off,Ȕ=new Color(0,0,0,255),Ȗ
=Ȓ.On,Ș=new Color(23,73,186,255),Ț=Ȓ.Off,Ȝ=new Color(23,73,186,255),Ù=Ȟ.Auto,Ƞ=5,Ȣ=Í.Off,Ȥ=ȥ.Abort,ȧ=Í.NoChange,ȩ=Ȫ.
KeepFull,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.On}},{"Docked",new ǲ{Ⱦ="Cruise",ǿ=Ȁ.On,Ȃ=ȃ.AllDefence,ȅ=Ȇ.HoldFire,Ȉ=ȉ.Off,ȋ=Ȍ.Off,Ȏ=ȏ.Off,ȑ=Ȓ.
On,Ȕ=new Color(33,144,255,255),Ȗ=Ȓ.On,Ș=new Color(255,240,225,255),Ț=Ȓ.On,Ȝ=new Color(255,255,255,255),Ù=Ȟ.
StockpileRecharge,Ƞ=-1,Ȣ=Í.NoChange,Ȥ=ȥ.Abort,ȧ=Í.Off,ȩ=Ȫ.On,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.Off}},{"Docking",new ǲ{Ⱦ="Docked",ǿ=Ȁ.On,Ȃ=ȃ.
AllDefence,ȅ=Ȇ.HoldFire,Ȉ=ȉ.Off,ȋ=Ȍ.On,Ȏ=ȏ.OnMax,ȑ=Ȓ.On,Ȕ=new Color(33,144,255,255),Ȗ=Ȓ.On,Ș=new Color(212,170,83,255),Ț=Ȓ.On,Ȝ=
new Color(212,170,83,255),Ù=Ȟ.Auto,Ƞ=-1,Ȣ=Í.NoChange,Ȥ=ȥ.Abort,ȧ=Í.Off,ȩ=Ȫ.KeepFull,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.On}},{
"NoAttack",new ǲ{Ⱦ="Docked",ǿ=Ȁ.Off,Ȃ=ȃ.Off,ȅ=Ȇ.Off,Ȉ=ȉ.On,ȋ=Ȍ.On,Ȏ=ȏ.Off,ȑ=Ȓ.On,Ȕ=new Color(255,255,255,255),Ȗ=Ȓ.On,Ș=new Color(
84,157,82,255),Ț=Ȓ.NoChange,Ȝ=new Color(84,157,82,255),Ù=Ȟ.NoChange,Ƞ=-1,Ȣ=Í.NoChange,Ȥ=ȥ.NoChange,ȧ=Í.NoChange,ȩ=Ȫ.
KeepFull,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.NoChange}},{"Combat",new ǲ{Ⱦ="Cruise",ǿ=Ȁ.On,Ȃ=ȃ.AllDefence,ȅ=Ȇ.OpenFire,Ȉ=ȉ.On,ȋ=Ȍ.On,Ȏ=ȏ.Off,
ȑ=Ȓ.Off,Ȕ=new Color(0,0,0,255),Ȗ=Ȓ.On,Ș=new Color(210,98,17,255),Ț=Ȓ.Off,Ȝ=new Color(210,98,17,255),Ù=Ȟ.ManagedDischarge,
Ƞ=100,Ȣ=Í.On,Ȥ=ȥ.Abort,ȧ=Í.On,ȩ=Ȫ.KeepFull,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.On}},{"CQB",new ǲ{Ⱦ="Combat",ǿ=Ȁ.On,Ȃ=ȃ.Offence,ȅ=Ȇ.
OpenFire,Ȉ=ȉ.On,ȋ=Ȍ.On,Ȏ=ȏ.Off,ȑ=Ȓ.Off,Ȕ=new Color(0,0,0,255),Ȗ=Ȓ.On,Ș=new Color(243,18,18,255),Ț=Ȓ.Off,Ȝ=new Color(243,18,18,
255),Ù=Ȟ.ManagedDischarge,Ƞ=100,Ȣ=Í.On,Ȥ=ȥ.Abort,ȧ=Í.On,ȩ=Ȫ.KeepFull,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.On}},{"WeaponsHot",new ǲ{Ⱦ=
"CQB",ǿ=Ȁ.On,Ȃ=ȃ.Offence,ȅ=Ȇ.OpenFire,Ȉ=ȉ.NoChange,ȋ=Ȍ.NoChange,Ȏ=ȏ.NoChange,ȑ=Ȓ.NoChange,Ȕ=new Color(0,0,0,255),Ȗ=Ȓ.NoChange
,Ș=new Color(243,18,18,255),Ț=Ȓ.NoChange,Ȝ=new Color(243,18,18,255),Ù=Ȟ.ManagedDischarge,Ƞ=-1,Ȣ=Í.NoChange,Ȥ=ȥ.NoChange,ȧ
=Í.NoChange,ȩ=Ȫ.KeepFull,Ì=Í.On,ȭ=Ȯ.NoChange,Ȱ=ȱ.On}}};}class Ŕ{public IMyDoor Ġ;public int ɟ=0;public int ɠ=0;public
bool ſ=false;public bool ɡ=false;}class ŕ{public string Ƃ;public bool ɢ=false;public int ɣ=0;public bool ɤ=false;public List
<Ŕ>ƃ=new List<Ŕ>();public List<IMyAirVent>Ɔ=new List<IMyAirVent>();}int ɥ=0;int ɦ=0;int ɧ=0;int ɮ(Ŕ ɨ,bool Ɓ=false){bool
ɩ=false;bool ɪ=false;if(ɨ.Ġ==null)return 0;bool ɫ=ɨ.Ġ.OpenRatio>0;ɥ++;if(ɬ(ɨ.Ġ))ɧ++;if(!Ɓ||ɫ)ɨ.Ġ.Enabled=true;if(ɫ){if(ɨ.
ɟ==0){ɪ=true;}ɨ.ɟ++;if(ɨ.ɟ>=Ǐ){ɨ.ɟ=0;ɨ.Ġ.CloseDoor();ɩ=true;}}else{ɦ++;if(ɨ.ɟ!=0){ɩ=true;ɨ.ɟ=0;}}int ɭ=0;if(ɩ)ɭ=1;else if
(ɪ)ɭ=2;return ɭ;}void â(){if(!ǎ){if(k)Echo("Door management is disabled.");return;}foreach(ŕ Ɓ in á){bool ɯ=false;foreach
(Ŕ ɨ in Ɓ.ƃ){if(ɨ.Ġ==null)continue;int ɰ=ɮ(ɨ,true);if(ɰ==1){if(k)Echo("Airlock door "+ɨ.Ġ.CustomName+" just closed");if(Ɓ
.ɤ)Ɓ.ɤ=false;else{Ɓ.ɢ=true;ɨ.ɡ=true;if(k)Echo("Airlock "+Ɓ.Ƃ+" needs to cycle");}}else if(ɰ==2){if(k)Echo("Airlock door "
+ɨ.Ġ.CustomName+" just opened");ɯ=true;}}bool ɱ=true;if(Ɓ.ɢ){foreach(Ŕ ɨ in Ɓ.ƃ){if(ɨ.Ġ==null)continue;if(ɨ.Ġ.OpenRatio>0
){ɨ.Ġ.CloseDoor();ɱ=false;}else ɨ.Ġ.Enabled=false;}bool ɲ=false;foreach(IMyAirVent ɳ in Ɓ.Ɔ){if(ɳ==null)continue;if(!ɳ.
Enabled)ɳ.Enabled=true;if(!ɳ.Depressurize)ɳ.Depressurize=true;if(ɳ.CanPressurize&&ɳ.GetOxygenLevel()<.01&&Ɓ.ɢ&&ɱ)ɲ=true;}Ɓ.ɣ++;
bool ɴ=true;if(Ɓ.ɣ>=ǐ){ɴ=false;ɲ=true;}if(ɲ){Ɓ.ɢ=false;Ɓ.ɣ=0;Ɓ.ɤ=true;foreach(Ŕ ɨ in Ɓ.ƃ){if(ɨ.Ġ==null)continue;ɨ.Ġ.Enabled=
true;if(ɨ.ɡ)ɨ.ɡ=false;else if(ɴ)ɨ.Ġ.OpenDoor();}}}else if(ɯ){foreach(Ŕ ɨ in Ɓ.ƃ){if(ɨ.Ġ==null)continue;if(ɨ.Ġ.OpenRatio==0)ɨ
.Ġ.Enabled=false;}}else{foreach(Ŕ ɨ in Ɓ.ƃ){ɨ.Ġ.Enabled=true;}}}}void à(){if(!ǎ){if(k)Echo("Door management is disabled."
);return;}ɥ=0;ɦ=0;ɧ=0;foreach(Ŕ ɨ in ß)ɮ(ɨ);}void ɶ(Ȯ ľ){if(ľ==Ȯ.NoChange)return;foreach(IMyAirtightHangarDoor ɵ in ń){if
(ɵ==null)continue;if(ľ==Ȯ.Closed)ɵ.CloseDoor();else ɵ.OpenDoor();}}void w(string ɷ,string ɸ){ɷ=ɷ.ToLower();foreach(Ŕ ɨ in
ß){if(ɸ==""||ɨ.Ġ.CustomName.Contains(ɸ)){bool ɹ=ɬ(ɨ.Ġ);if(ɹ&&(ɷ=="locked"||ɷ=="toggle"))ɨ.Ġ.ApplyAction("AnyoneCanUse");
if(!ɹ&&(ɷ=="unlocked"||ɷ=="toggle"))ɨ.Ġ.ApplyAction("AnyoneCanUse");}}}bool ɬ(IMyDoor ɨ){var ŀ=ɨ.GetActionWithName(
"AnyoneCanUse");StringBuilder ɺ=new StringBuilder();ŀ.WriteValue(ɨ,ɺ);return(ɺ.ToString()=="On");}double ɻ=100;double ǯ=0;int ɼ=0;
double ɽ=0;void î(bool ɾ,bool ɿ){ɼ=0;foreach(IMyGyro ʀ in í){if(ʀ!=null&&ʀ.IsFunctional){ɼ++;if(ɿ)ʀ.Enabled=ɾ;}}ɽ=Math.Round(
100*(ɼ/ǯ));}double ʁ=0;int ʂ=0;double ʃ=0;void ð(){ʂ=0;foreach(IMyGyro ʀ in ï){if(ʀ!=null&&ʀ.IsFunctional){ʂ++;if(Ë.Ȱ==ȱ.On
)ʀ.Enabled=true;else if(Ë.Ȱ==ȱ.Off)ʀ.Enabled=false;}}ʃ=Math.Round(100*(ʂ/ʁ));}void r(string ʄ,bool n=true,bool o=true,
bool p=true){if(k)Echo("Initialising a ship as '"+ʄ+"'...");J=true;Ē=ʄ;a=n;Y=o;Z=p;Ç();}void Ç(){switch(G){case 0:Î();F=0;if
(Ä)Echo("Took "+b());break;case 1:æ();if(Ä)Echo("Took "+b());break;case 2:if(k)Echo("Initialising lcds...");ʅ();if(Y){if(
k)Echo("Initialising subsystem values...");ʆ();ʇ();ʈ();ʉ();ʊ();ʋ();Ǉ();Ǩ=ê.Count+ë.Count;ǩ=ä.Count;Ǫ=Ò.Count;ǯ=í.Count;ʁ=
ï.Count;ǰ=ü.Count;}if(Z){if(k)Echo("Initialising item values...");ʌ();}if(a){if(k)Echo("Initialising block names...");ʍ()
;}ɖ(false,Y,Z);À.Add(new Á("Init:"+Ē,"Initialised '"+Ē+"'\nGood Hunting!",3));G=0;J=false;if(Ä)Echo("Took "+b());return;}
G++;}class ʑ{public int ʎ=0;public int ʏ=0;public int ʐ=0;}void ʍ(){Dictionary<string,ʑ>ʒ=new Dictionary<string,ʑ>();if(Ǖ
.Count>0){foreach(string Ų in Ǖ){if(k)Echo("Numbering "+Ų);ʒ.Add(Ų,new ʑ());}foreach(var ʔ in Ŗ){ʑ ʓ;if(ʒ.TryGetValue(ʔ.
Value,out ʓ)){ʒ[ʔ.Value].ʏ++;}}foreach(var ʕ in ʒ){if(ʕ.Value.ʏ<10)ʕ.Value.ʐ=1;else if(ʕ.Value.ʏ>99)ʕ.Value.ʐ=3;else ʕ.Value.
ʐ=2;}}foreach(var ʔ in Ŗ){string ʖ="";string ʗ=ʔ.Value;ʑ ʘ;if(ʒ.TryGetValue(ʔ.Value,out ʘ)){if(ʘ.ʏ>1){ʘ.ʎ++;ʖ=ū+ʘ.ʎ.
ToString().PadLeft(ʘ.ʐ,'0');}}ʔ.Key.CustomName=Ē+ū+ʗ+ʖ+ʙ(ʔ.Key.CustomName,ʗ);}}string ʙ(string Ť,string ʚ=""){try{string[]ʛ=Ť.
Split(ū);string[]ʜ=ʚ.Split(ū);string Ʀ="";if(ʛ.Length<3)return"";for(int Ʉ=2;Ʉ<ʛ.Length;Ʉ++){int ʝ=0;bool ʞ=int.TryParse(ʛ[Ʉ]
,out ʝ);if(ʞ)ʛ[Ʉ]="";foreach(string ʟ in ʜ){if(ʟ==ʛ[Ʉ])ʛ[Ʉ]="";}if(ʛ[Ʉ]!="")Ʀ+=ū+ʛ[Ʉ];}return Ʀ;}catch{return"";}}class ħ
{public IMyTerminalBlock Ġ{get;set;}public IMyInventory Ĵ{get;set;}List<MyInventoryItem>ʠ=new List<MyInventoryItem>();
public int Ķ=0;public bool ĵ=false;public float ķ;}class ģ{public int ʡ=0;public int ǥ=0;public int ĺ=0;public double ʢ;public
List<ħ>Ĩ=new List<ħ>();public List<ħ>ĩ=new List<ħ>();public MyItemType Ļ;public bool Ĥ=false;public bool ĥ=false;public
string Ħ;public string ʣ;public double ĳ=1;}List<ģ>Ģ=new List<ģ>();void Ů(IMyTerminalBlock ŗ,int Ǥ=99){if(Ǥ==99){foreach(var ģ
in Ģ){ħ Ĵ=new ħ();Ĵ.Ġ=ŗ;Ĵ.Ĵ=ŗ.GetInventory();ģ.Ĩ.Add(Ĵ);}}else{ħ Ĵ=new ħ();Ĵ.Ġ=ŗ;Ĵ.Ĵ=ŗ.GetInventory();Ĵ.ĵ=ġ;if(Ǥ==0&&!ǉ)Ĵ.
ĵ=false;Ģ[Ǥ].Ĩ.Add(Ĵ);}}void ʤ(IMyTerminalBlock ŗ,int Ǥ){ħ Ĵ=new ħ();Ĵ.Ġ=ŗ;Ĵ.Ĵ=ŗ.GetInventory();Ĵ.ĵ=ġ;if(Ǥ!=99)Ģ[Ǥ].ĩ.Add
(Ĵ);}void ʧ(string Ħ,string ʥ,string ʦ,bool ĥ=false,bool Ĥ=false){ģ ģ=new ģ();ģ.Ļ=new MyItemType(ʥ,ʦ);ģ.ĥ=ĥ;ģ.Ĥ=Ĥ;ģ.Ħ=Ħ;
string ʣ;if(Ħ.Length>9)ʣ=Ħ.Substring(0,9);else ʣ=Ħ.PadRight(9);ģ.ʣ=ʣ;Ģ.Add(ģ);}void d(){try{ʧ("Fusion Pellets",
"MyObjectBuilder_Ingot","sdx_itemReactorFuel",true);ʧ("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");ʧ("50mm PDC",
"MyObjectBuilder_AmmoMagazine","sdx_ammomagazinePdc50mm");ʧ("40mm Impv","MyObjectBuilder_AmmoMagazine","sdx_ammomagazinePdc40mmImprovised",true);ʧ(
"40mm PDC","MyObjectBuilder_AmmoMagazine","sdx_ammomagazinePdc40mm",true);ʧ("160mm Torp ","MyObjectBuilder_AmmoMagazine",
"sdx_ammomagazineTorpedo160mm",true,true);ʧ("190mm Torp","MyObjectBuilder_AmmoMagazine","sdx_ammomagazineTorpedo190mmImprovised",true,true);ʧ(
"220mm Torp","MyObjectBuilder_AmmoMagazine","sdx_ammomagazineTorpedo220mm",true,true);ʧ("RS Torp","MyObjectBuilder_AmmoMagazine",
"RamshackleTorpedoMagazine",true,true);ʧ("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",true,true);ʧ("120mm RG",
"MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);ʧ("Dawson","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true
);ʧ("Stiletto","MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugMCRNMagazine",true);ʧ("80mm Pb",
"MyObjectBuilder_AmmoMagazine","sdx_ammomagazineSabot80mmImprovised",true);ʧ("80mm W-U","MyObjectBuilder_AmmoMagazine","sdx_ammomagazineSabot80mm",
true);ʧ("100mm W-U","MyObjectBuilder_AmmoMagazine","sdx_ammomagazineSabot100mm",true);ʧ("Kess",
"MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);ʧ("Steel Pla","MyObjectBuilder_Component","SteelPlate");ʧ("Reactor C",
"MyObjectBuilder_Component","Reactor");Ģ[0].ĳ=Ǚ;}catch(Exception Đ){Echo("Failed to build item lists!");Echo(Đ.Message);return;}}void ã(){foreach(
var ģ in Ģ){ģ.ĩ.Clear();}}void æ(){foreach(var ģ in Ģ){ģ.ʡ=0;ģ.ĺ=0;List<ħ>Ī=ģ.Ĩ.Concat(ģ.ĩ).ToList();foreach(ħ Ĵ in Ī){Ĵ.Ķ=
Ĵ.Ĵ.GetItemAmount(ģ.Ļ).ToIntSafe();ģ.ʡ+=Ĵ.Ķ;if(Ĵ.ĵ){Ĵ.ķ=Ĵ.Ĵ.VolumeFillFactor;}else{ģ.ĺ+=Ĵ.Ķ;}}}}void ʌ(){foreach(ģ ģ in Ģ
){ģ.ǥ=ģ.ʡ;}}int ʩ(string ʨ){switch(ʨ){case"220mm Plasma Torpedo":return 7;case"190mm Improvised Torpedo":return 6;case
"160mm Plasma Torpedo":return 5;case"50mm PDC Ammo":return 2;case"40mm PDC Ammo":return 4;case"40mm PDC Ammo Improvised":return 3;case
"80mm Sabot Improvised":return 13;case"80mm Sabot":return 14;case"100mm Tungsten-Uranium Sabot":return 3;default:if(k)Echo(
"Unknown AmmoType = "+ʨ);return 99;}}bool ʫ(IMyTerminalBlock Ġ){IMyInventory ʪ=Ġ.GetInventory();return ʪ.VolumeFillFactor==0;}bool ļ(List<ħ>ī
,List<ħ>ĭ,MyItemType Ļ,int ʬ=-1,double ʭ=1,double ʮ=1){if(k)Echo("Loading "+ĭ.Count+" inventories from "+ī.Count+
" sources.");bool ʯ=false;bool ʰ=ʮ<1;foreach(ħ ʲ in ĭ){int ʱ=3;foreach(ħ ʳ in ī){if(ʱ<0)break;if(ʬ!=-1&&ʲ.Ķ>=(ʬ*.95))break;if(!ʲ.Ĵ.
IsConnectedTo(ʳ.Ĵ))continue;List<MyInventoryItem>ʴ=new List<MyInventoryItem>();ʳ.Ĵ.GetItems(ʴ);foreach(MyInventoryItem ʵ in ʴ){if(ʵ.
Type==Ļ){int Ķ=ʵ.Amount.ToIntSafe();if(Ķ==0&&!ʰ)break;ʱ--;if(ʰ){ʱ=-1;try{Ķ=ʳ.Ķ-Convert.ToInt32(ʳ.Ķ/ʳ.ķ*ʮ);if(k)Echo(
"Unload "+Ķ+"\n"+ʳ.Ķ+"\n"+Convert.ToInt32(ʳ.Ķ/ʳ.ķ*ʮ));}catch(Exception Đ){if(k)Echo("Int conversion error at unload\n"+Đ.Message)
;Ķ=1;}}else if(ʭ<1){try{int ʶ=Convert.ToInt32(ʲ.Ķ/ʲ.ķ*ʭ)-ʲ.Ķ;if(ʶ<Ķ)Ķ=ʶ;}catch(Exception Đ){if(k)Echo(
"Int conversion error at load\n"+Đ.Message);Ķ=1;}}else if(ʬ!=-1){if(Ķ<=ʬ){break;}Ķ=ʬ-ʲ.Ķ;}ʯ=ʲ.Ĵ.TransferItemFrom(ʳ.Ĵ,ʵ,Ķ);if(ʯ)ʱ=-1;if(ʰ&&ʯ)return(ʯ);
break;}}}}return ʯ;}class ō{public IMyTextPanel Ġ;public bool ƪ=true;public bool ƫ=false;public bool Ƭ=false;public bool Ʃ=
true;public bool ƭ=true;public bool Ʈ=true;public bool Ư=false;public bool ư=false;}class Á{public string ʷ,ʸ;public int ʹ,ʺ
;public Á(string ʻ,string ʼ,int ʽ=0,int ʾ=20){if(ʻ.Length>ʿ-3)ʻ=ʻ.Substring(0,ʿ-3);ʷ=ʻ.PadRight(ʿ-3);ʸ=ʼ;ʹ=ʽ;ʺ=ʾ;}}List<Á
>À=new List<Á>();class ˉ{public string ˀ,ˁ;public ˉ(string Ų,int ˆ,int ˇ){string ˈ="    ";while(ˇ>3){ˇ-=4;}if(ˆ==0){ˀ=
"║ "+Ų.PadRight(4)+" ║";ˁ="  "+ˈ+"  ";}else if(ˆ==1){if(ˇ==0||ˇ==2)ˀ="║─"+Ų.PadRight(4)+" ║";else ˀ="║ "+Ų.PadRight(4)+"─║";
ˁ=" ░"+ˈ+"░ ";}else if(ˆ==2){if(ˇ==0||ˇ==2){ˀ="║ "+Ų.PadRight(4)+"═║";ˁ="║▒"+ˈ+"░║";}else{ˀ="║═"+Ų.PadRight(4)+" ║";ˁ=
"║░"+ˈ+"▒║";}}else if(ˆ==3){if(ˇ==0||ˇ==2){ˀ="║!"+Ų.PadRight(4)+"!║";ˁ="║▓"+ˈ+"▓║";}else{ˀ="║ "+ˈ+" ║";ˁ="║!"+Ų.PadRight(4)+
"!║";}}}}Color ˊ=new Color(255,116,33,255);const int ʿ=32;int ˋ=0;string[]ˌ=new string[]{"▄ "," ▄"," ▀","▀ "},ˍ=new string[]
{"─","\\","│","/"},ˎ=new string[]{"- ","= ","x ","! "};string ˏ,ː,ˑ,ˠ,ˡ="\n\n",ˢ,ˣ="╔══════╗",ˤ="╚══════╝",ȶ,ˬ,ˮ,Ͱ,ͱ,Ͳ,ͳ,
ʹ,Ͷ,ͷ,ͺ,ͻ,ͼ,ͽ,Ά,Έ,Ή,Ί,Ό,Ύ,Ώ;void f(){ˣ=ˣ+ˣ+ˣ+ˣ+"\n";ˤ=ˤ+ˤ+ˤ+ˤ+"\n";ˏ=ΐ("Welcome to")+ˡ+ΐ("R S M")+ˡ;ː=ΐ("Initialising")+ˡ
;ˑ=new String(' ',ʿ-8);ˠ="└"+new String('─',ʿ-2)+"┘";ȶ=new String('-',26)+"\n";ˢ="──"+ˡ;ˬ=Α("Inventory");ˮ=Α("Thrust");Ͱ=
Α("Power & Tanks");ͱ=Α("Warnings");Ͳ=Α("Subsystem Integrity");ͳ=Α("Telemetry & Thrust");ʹ=Β("Velocity");Ͷ=Β(
"Velocity (Max)");ͷ=Β("Mass");ͺ=Β("Max Accel");ͻ=Β("Actual Accel");ͼ=Β("Accel (Best)");ͽ=Β("Max Thrust");Ά=Β("Actual Thrust");Έ=Β(
"Decel (Dampener)");Ή=Β("Decel (Actual)");Ί=Γ("Fuel");Ό=Γ("Oxygen");Ύ=Γ("Battery");Ώ=Γ("Capacity");}string Α(string Δ){return"──┤ "+Δ+" ├"
+new String('─',ʿ-9-Δ.Length);}string Β(string Ε){return Ε+":"+new String(' ',ʿ-16-Ε.Length);}string Γ(string Ζ){return Ζ
+new String(' ',ʿ-22-Ζ.Length)+"[";}void É(){ˋ++;if(ˋ>=ˌ.Length)ˋ=0;int Η=ˋ+2;if(Η>3)Η-=4;string Θ=ˌ[ˋ];string Ι=ˍ[ˋ];
string Κ=ˌ[Η];string Λ=ˬ+Ι+ˢ;string Μ=ˮ+Ι+ˢ;string Ν=Ͱ+Ι+ˢ;string Ξ=ͱ+Ι+ˢ;string Ο=Ͳ+Ι+ˢ;string Π=ͳ+Ι+ˢ;string Ρ=ΐ(Ē.ToUpper()
)+"\n"+"  "+Θ+" "+ΐ(ē,ʿ-10)+" "+Θ+"  \n";string Σ="\n  "+Κ+ˑ+Κ+"  "+ˡ;if(I){string Τ=ˏ+ΐ("Booting"+new string('.',C))+ˡ;Λ
+=Τ;Μ+=Τ;Ν+=Τ;Ξ+=Τ;Ο+=Τ;}else if(J){string Ƙ=ː+ΐ(Ē)+ˡ;Λ+=Ƙ;Μ+=Ƙ;Ν+=Ƙ;Ξ+=Ƙ;Ο+=Ƙ;}else{ǂ();double Υ=9.81,Φ=Math.Round(Q),Ψ=
Math.Round((Χ/R/Υ),2),Ϊ=Math.Round((Ω/R/Υ),2),Ϋ=Math.Round(Ǧ+ǧ,1),έ=Math.Round(ά,1),ΰ=Math.Round(100*(ή/ί)),γ=Math.Round(100
*(α/β)),δ=Math.Round(100*(έ/Ϋ));string ε=ʹ,ζ=" Gs",Ǹ;List<string>η=new List<string>();if(Φ<1){Φ=500;ε=Ͷ;}if(ǘ){Υ=1;ζ=
" m/s/s";}for(int Ʉ=0;Ʉ<Ģ.Count;Ʉ++){if(Ģ[Ʉ].ǥ!=0){Ģ[Ʉ].ʢ=(100*((double)Ģ[Ʉ].ʡ/(double)Ģ[Ʉ].ǥ));string ə=(Ģ[Ʉ].ʡ+"/"+Ģ[Ʉ].ǥ).
PadLeft(9);if(ə.Length>9)ə=ə.Substring(0,9);Λ+=Ģ[Ʉ].ʣ+" ["+θ(Ģ[Ʉ].ʢ)+"] "+ə+"\n";if(Ʉ>2&&Ģ[Ʉ].ĺ<1)η.Add(Ģ[Ʉ].Ħ);}}Λ+="\n";if(Ω>
0)Μ+=Ή+ι(Ω,Φ)+"\n"+ͻ+(Ϊ+ζ).PadLeft(15)+ˡ;else Μ+=Έ+ι(Χ,Φ,true)+"\n"+ͼ+(Ψ+ζ).PadLeft(15)+ˡ;ɻ=Math.Round(100*(κ/λ));Ν+=Ί+θ(
ɻ)+"] "+(ɻ+" %").PadLeft(9)+"\n"+Ό+θ(ΰ)+"] "+(ΰ+" %").PadLeft(9)+"\n"+Ύ+θ(γ)+"] "+(γ+" %").PadLeft(9)+"\n"+Ώ+θ(δ)+"] "+(δ
+" %").PadLeft(9)+"\n"+"Max Power:"+(έ+" MW / "+Ϋ+" MW").PadLeft(22)+ˡ;List<Á>μ=new List<Á>();List<ˉ>ν=new List<ˉ>();int
ξ=0;for(int Ʉ=0;Ʉ<À.Count;Ʉ++){À[Ʉ].ʺ--;if(À[Ʉ].ʺ<1)À.RemoveAt(Ʉ);else μ.Add(À[Ʉ]);}if(ʁ>0&&ʂ==0){μ.Add(new Á(
"RCS GYROS OFFLINE!","RCS Gyroscope Computers are no longer functional!. Ship will turn more slowly.",2));}if(!ο){μ.Add(new Á("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(N){μ.Add(new Á("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int π=0;if(ɻ<5)
{Ǹ="FUEL CRITICAL!";μ.Add(new Á(Ǹ,Ǹ+"\nFuel Level < 5%!",3));π=3;}else if(ɻ<25){Ǹ="FUEL LOW!";μ.Add(new Á(Ǹ,Ǹ+
"\nFuel Level < 10%!",2));π=2;}ν.Add(new ˉ("FUEL",π,ˋ+ξ));ξ++;if(M){Ǹ=Ā.Count+" spawns are open to friends";μ.Add(new Á(Ǹ,Ǹ,0));}int ρ=0;if(ΰ
<5){Ǹ="OXYGEN CRITICAL!";μ.Add(new Á(Ǹ,Ǹ+"\nShip O2 Level < 5%!",3));ρ=3;}else if(ΰ<10){Ǹ="OXYGEN LOW!";μ.Add(new Á(Ǹ,Ǹ+
"\nShip O2 Level < 10%!",2));ρ=2;}else if(ΰ<25){Ǹ="Oxygen Low!";μ.Add(new Á(Ǹ,Ǹ+"\nShip O2 Level < 25%!",1));ρ=1;}if(ø.Count>ς){int σ=(ø.Count-ς
);ρ++;Ǹ=σ+" vents are unsealed";μ.Add(new Á(Ǹ,Ǹ,1));}if(ɧ>0){Ǹ=ɧ+" doors are insecure";μ.Add(new Á(Ǹ,Ǹ,0));}if(P>0){Ǹ=Ŝ+
" is active ("+P+")";μ.Add(new Á(Ǹ,Ǹ,0));}ν.Add(new ˉ("OXYG",ρ,ˋ+ξ));ξ++;int τ=0;if(Ö.Count>0){if(γ<5){τ+=2;Ǹ="BATTERIES CRITICAL!";μ.
Add(new Á(Ǹ,Ǹ+"\nBattery Level < 5%!",2));}else if(γ<10){τ+=1;Ǹ="Batteries Low!";μ.Add(new Á(Ǹ,Ǹ+"\nBattery Level < 10%!",1
));}}if(Õ.Count>0){if(υ>0){τ+=2;μ.Add(new Á(υ+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}
if(Ģ[0].ʡ<1){τ+=3;Ǹ="NO FUSION FUEL!";μ.Add(new Á(Ǹ,Ǹ,2));}else if(Ģ[0].ʡ<50){τ+=2;Ǹ="FUSION FUEL CRITICAL! ("+Ģ[0].ʡ+")";
μ.Add(new Á(Ǹ,Ǹ,2));}else if(Ģ[0].ǥ>0&&Ģ[0].ʢ<5){τ+=2;Ǹ="FUSION FUEL CRITICAL!";μ.Add(new Á(Ǹ,Ǹ,3));}else if(Ģ[0].ǥ>0&&Ģ[
0].ʢ<10){τ+=1;Ǹ="Fusion Fuel Level Low!";μ.Add(new Á(Ǹ,Ǹ,2));}}if(τ>3)τ=3;ν.Add(new ˉ("POWR",τ,ˋ+ξ));ξ++;int φ=0;if(η.
Count>0){foreach(string χ in η){string ψ=χ;if(χ.Length>23)ψ=χ.Substring(0,23);ψ=ψ.ToUpper();Ǹ="NO SPARE "+ψ+"!";μ.Add(new Á(Ǹ
,Ǹ,3));}φ=3;}if(φ>3)φ=3;ν.Add(new ˉ("WEAP",φ,ˋ+ξ));ξ++;if(Ě){string ω=ě;if(ó.Count>0)if(ó[0]!=null)ω=(ó[0]as
IMyRadioAntenna).HudText;string ϊ="";if(Ĝ<1000)ϊ=Math.Round(Ĝ)+"m";else ϊ=Math.Round(Ĝ/1000)+"km";μ.Add(new Á("Comms ("+ϊ+"): "+ω,
"Antenna(s) are broadcasting at a range of "+ϊ+" with the message "+ω,0));}if(O>0){Ǹ=O+" UNOWNED BLOCKS!";μ.Add(new Á(Ǹ,Ǹ+"\nRSM detected "+O+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ɥ>ɦ){int ɫ=(ɥ-ɦ);Ǹ=ɫ+" doors are open";μ.Add(new Á(Ǹ,Ǹ,0));}μ=μ.OrderBy(Ĺ=>Ĺ.ʹ).Reverse().ToList();if(μ.Count<1
)Ξ+="No warnings\n";else Echo(ˡ+" WARNINGS:");for(int Ʉ=0;Ʉ<μ.Count;Ʉ++){Ξ+=ˎ[μ[Ʉ].ʹ]+μ[Ʉ].ʷ+"\n";Echo("-"+ˎ[μ[Ʉ].ʹ]+μ[Ʉ]
.ʸ);}Ξ+="\n";string ϋ=Ë.Ȉ.ToString().ToUpper();string ό=Ë.ȋ.ToString().ToUpper();string ύ=Ë.Ù.ToString().ToUpper();string
ώ=Ë.Ȃ.ToString().ToUpper();string Ϗ=Ë.ǿ.ToString().ToUpper();string ϐ=Ë.ȅ.ToString().ToUpper();if(ϋ.Length>3)ϋ=ϋ.
Substring(0,3);if(ό.Length>3)ό=ό.Substring(0,3);if(ύ.Length>3)ύ=ύ.Substring(0,3);if(ώ.Length>3)ώ=ώ.Substring(0,3);if(Ϗ.Length>3)Ϗ
=Ϗ.Substring(0,3);if(ϐ.Length>3)ϐ=ϐ.Substring(0,3);try{if(ǭ>0)Ο+="Epstein   ["+θ(ϑ)+"] "+(ϑ+"% ").PadLeft(5)+ϋ+"\n";if(Ǯ>
0)Ο+="RCS       ["+θ(ϒ)+"] "+(ϒ+"% ").PadLeft(5)+ό+"\n";if(Ǧ>0)Ο+="Reactors  ["+θ(ϓ)+"] "+(ϓ+"% ").PadLeft(5)+"    \n";if
(ǧ>0)Ο+="Batteries ["+θ(ϔ)+"] "+(ϔ+"% ").PadLeft(5)+ύ+"\n";if(Ǩ>0)Ο+="PDCs      ["+θ(ϕ)+"] "+(ϕ+"% ").PadLeft(5)+ώ+"\n";
if(ǩ>0)Ο+="Torpedoes ["+θ(ϖ)+"] "+(ϖ+"% ").PadLeft(5)+Ϗ+"\n";if(Ǫ>0)Ο+="Railguns  ["+θ(ϗ)+"] "+(ϗ+"% ").PadLeft(5)+ϐ+"\n";
if(ǫ>0)Ο+="H2 Tanks  ["+θ(Ϙ)+"] "+(Ϙ+"% ").PadLeft(5)+ύ+"\n";if(Ǭ>0)Ο+="O2 Tanks  ["+θ(ϙ)+"] "+(ϙ+"% ").PadLeft(5)+ύ+"\n";
if(ǯ>0)Ο+="Gyros     ["+θ(ɽ)+"] "+(ɽ+"% ").PadLeft(5)+"    \n";if(ǃ>0)Ο+="Cargo     ["+θ(ǅ)+"] "+(ǅ+"% ").PadLeft(5)+
"    \n";if(ǰ>0)Ο+="Welders   ["+θ(Ϛ)+"] "+(Ϛ+"% ").PadLeft(5)+"    \n";}catch{}if(ǧ+Ǧ+ǫ==0)Ο+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+ˡ;string ϛ="";string Ϝ="";foreach(ˉ ϝ in ν){ϛ+=ϝ.ˀ;Ϝ+=ϝ.ˁ;}int Ϟ=ˋ+2;if(Ϟ>3)Ϟ-=4;Ρ+=ˣ+ϛ+"\n"+ˤ;Σ+=Ϝ;if(!V){Π+=ˡ;}else{
if(k)Echo("Building advanced thrust...");string ϟ="";if(Ǘ){ϟ=ͷ+(Math.Round((R/1000000),2)+" Mkg").PadLeft(15)+"\n"+ε+(Φ+
" ms").PadLeft(15)+"\n"+ͺ+(Ψ+ζ).PadLeft(15)+"\n"+ͻ+(Ϊ+ζ).PadLeft(15)+"\n"+ͽ+((Χ/1000000)+" MN").PadLeft(15)+"\n"+Ά+((Ω/
1000000)+" MN").PadLeft(15)+"\n";}Π+=ϟ+Έ+ι(Χ,Φ,true)+"\n"+Ή+ι(Ω,Φ)+"\n";foreach(double Ⱥ in e){Π+=("Decel ("+(Ⱥ*100)+"%):").
PadRight(17)+ι((float)(Χ*Ⱥ),Φ)+"\n";}Π+=ˡ;}}foreach(ō ƞ in È){string ɭ="";Color ɚ=Ë.Ȝ;if(ƞ.ƪ)ɭ+=Ρ;if(ƞ.ƫ){ɭ+=Σ;ɚ=ˊ;}if(ƞ.Ƭ)ɭ+=Ξ;
if(ƞ.Ʃ)ɭ+=Ν;if(ƞ.ƭ)ɭ+=Λ;if(ƞ.Ʈ)ɭ+=Μ;if(ƞ.Ư)ɭ+=Ο;if(ƞ.ư){ɭ+=Π;V=true;}ƞ.Ġ.WriteText(ɭ,false);if(!š)ƞ.Ġ.FontColor=ɚ;}}void Ϡ
(){if(Ō.Count>0){foreach(IMyTextPanel ƞ in Ō){ƞ.FontColor=Ë.Ȝ;}foreach(ō ƞ in È){ƞ.Ġ.FontColor=Ë.Ȝ;}}}void u(string ϡ,
string Ϣ){ϡ=ϡ.ToLower();List<IMyTextPanel>ϣ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(þ);
foreach(IMyTextPanel ƞ in þ){if(Ϣ==""||ƞ.CustomName.Contains(Ϣ)){string Ϥ=ƞ.CustomData;if(Ϥ.Contains("hudlcd")&&(ϡ=="off"||ϡ==
"toggle"))ƞ.CustomData=Ϥ.Replace("hudlcd","hudXlcd");if(Ϥ.Contains("hudXlcd")&&(ϡ=="on"||ϡ=="toggle"))ƞ.CustomData=Ϥ.Replace(
"hudXlcd","hudlcd");}}}string θ(double ϥ){try{int Ϧ=0;if(ϥ>0){int ϧ=(int)ϥ/10;if(ϧ>10)return new string('=',10);if(ϧ!=0)Ϧ=ϧ;}char
Ϩ=' ';if(ϥ<10){if(ˋ==0)return" ><    >< ";if(ˋ==1)return"  ><  ><  ";if(ˋ==2)return"   ><><   ";if(ˋ==3)return
"<   ><   >";}string ϩ=new string('=',Ϧ);string Ϫ=new string(Ϩ,10-Ϧ);return ϩ+Ϫ;}catch{return"# ERROR! #";}}string ϭ(string ϫ){
string Ϭ;string ə="";double ϥ=0;switch(ϫ){case"H2":ϥ=Math.Round(100*(κ/ǫ));ə=ϥ.ToString()+" %";ɻ=ϥ;break;case"O2":ϥ=Math.Round
(100*(ή/Ǭ));ə=ϥ.ToString()+" %";break;case"Battery":ϥ=Math.Round(100*(α/β));ə=ϥ.ToString()+" %";break;}Ϭ=θ(ϥ);return" ["+
Ϭ+"] "+ə.PadLeft(9);}string ΐ(string Ϯ,int ϯ=ʿ){int ϰ=ϯ-Ϯ.Length;int ϱ=ϰ/2+Ϯ.Length;return Ϯ.PadLeft(ϱ).PadRight(ϯ);}
string ι(double ϲ,double ϳ,bool ϴ=false){if(ϲ<=0)return("N/A").PadLeft(15);if(ϴ)ϲ=ϲ*1.5;double Ʀ=0.5*(Math.Pow(ϳ,2)*(R/ϲ));
double ϵ=ϳ/(ϲ/R);string Ϸ="m";if(Ʀ>1000){Ϸ="km";Ʀ=Ʀ/1000;}return(Math.Round(Ʀ)+Ϸ+" "+Math.Round(ϵ)+"s").PadLeft(15);}void ÿ(){
foreach(IMyTextPanel ɞ in þ){ɞ.Enabled=true;}}void ʅ(){foreach(ō ƞ in È){ƞ.Ġ.Font="Monospace";ƞ.Ġ.ContentType=ContentType.
TEXT_AND_IMAGE;if(ƞ.Ġ.CustomName.Contains("HUD1")){ƞ.ƪ=true;ƞ.ƫ=false;ƞ.Ƭ=false;ƞ.Ʃ=false;ƞ.ƭ=false;ƞ.Ʈ=false;ƞ.Ư=false;ƞ.ư=false;Š(ƞ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ƞ.Ġ.CustomName.Contains("HUD2")){ƞ.ƪ=false;ƞ.ƫ=false;ƞ.Ƭ=true;ƞ.Ʃ=false;ƞ.ƭ=false;ƞ.Ʈ=false;ƞ.Ư=false;ƞ.ư
=false;Š(ƞ,"hudlcd:0.22:0.99:0.55");continue;}if(ƞ.Ġ.CustomName.Contains("HUD3")){ƞ.ƪ=false;ƞ.ƫ=false;ƞ.Ƭ=false;ƞ.Ʃ=true;
ƞ.ƭ=false;ƞ.Ʈ=false;ƞ.Ư=false;ƞ.ư=false;Š(ƞ,"hudlcd:0.48:0.99:0.55");continue;}if(ƞ.Ġ.CustomName.Contains("HUD4")){ƞ.ƪ=
false;ƞ.ƫ=false;ƞ.Ƭ=false;ƞ.Ʃ=false;ƞ.ƭ=false;ƞ.Ʈ=false;ƞ.Ư=true;ƞ.ư=false;Š(ƞ,"hudlcd:0.74:0.99:0.55");continue;}if(ƞ.Ġ.
CustomName.Contains("HUD5")){ƞ.ƪ=false;ƞ.ƫ=false;ƞ.Ƭ=false;ƞ.Ʃ=false;ƞ.ƭ=true;ƞ.Ʈ=false;ƞ.Ư=false;ƞ.ư=true;Š(ƞ,"hudlcd:0.75:0:.54"
);continue;}if(ƞ.Ġ.CustomName.Contains("HUD6")){ƞ.ƪ=false;ƞ.ƫ=true;ƞ.Ƭ=false;ƞ.Ʃ=false;ƞ.ƭ=false;ƞ.Ʈ=false;ƞ.Ư=false;ƞ.ư=
false;Š(ƞ,"hudlcd:-0.55:0.99:0.7");continue;}}bool ϸ=false;foreach(IMyTextPanel ɞ in þ){if(ɞ==null)continue;if(!ϸ&&(ɞ.
CustomName.Contains(Ǔ)||ɞ.CustomName.ToUpper().Contains(ǔ))){ϸ=true;ɞ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool ο;bool
Ϲ;void Ý(bool ɾ,bool ɿ){ο=false;foreach(IMyConveyorSorter Ϻ in Ü){if(Ϻ!=null&&Ϻ.IsFunctional){ο=true;if(ɿ)Ϻ.Enabled=ɾ;if(
!Ϲ){MyDetectedEntityInfo?ϼ=č.ϻ(Ϻ);if(ϼ.HasValue){string Ų=ϼ.Value.Name;if(Ų!=null&&Ų!=""){if(k)Echo(
"At least one lidar  has a target!");Ϲ=true;}}}}}if(!ο){Ϲ=true;}}void Ͼ(ȏ ľ){if(ľ==ȏ.NoChange)return;foreach(IMyReflectorLight Ͻ in Œ){if(Ͻ==null)continue;
if(ľ==ȏ.Off)Ͻ.Enabled=false;else{Ͻ.Enabled=true;if(ľ==ȏ.OnMax)Ͻ.Radius=9999;}}}void Ѐ(Ȓ ľ,Color ɚ){if(ľ==Ȓ.NoChange)return
;foreach(IMyLightingBlock Ͽ in Ŏ){if(Ͽ==null)continue;if(ľ==Ȓ.Off)Ͽ.Enabled=false;else Ͽ.Enabled=true;if(ľ!=Ȓ.
OnNoColourChange)Ͽ.SetValue("Color",ɚ);}}void Ё(Ȓ ľ,Color ɚ){if(ľ==Ȓ.NoChange)return;foreach(IMyLightingBlock Ͽ in ŏ){if(Ͽ==null)
continue;if(ľ==Ȓ.Off)Ͽ.Enabled=false;else Ͽ.Enabled=true;if(ľ!=Ȓ.OnNoColourChange)Ͽ.SetValue("Color",ɚ);}}Color Ђ=new Color(255,
0,0,255);Color Ѓ=new Color(255,0,0,255);Color Є=new Color(0,255,0,255);void І(Ȓ ľ){if(ľ==Ȓ.NoChange)return;foreach(
IMyLightingBlock Ͽ in Ő){Ѕ(Ͽ,ľ,Ѓ);}foreach(IMyLightingBlock Ͽ in ő){Ѕ(Ͽ,ľ,Є);}}void Ѕ(IMyLightingBlock Ͽ,Ȓ ľ,Color ɚ){if(Ͽ==null)return;
if(ľ==Ȓ.Off){Ͽ.Enabled=false;Ͽ.SetValue("Color",Ђ);}else{Ͽ.Enabled=true;if(ľ!=Ȓ.OnNoColourChange)Ͽ.SetValue("Color",ɚ);}}
int ς=0;void ù(bool ɾ,bool ɿ){ς=0;foreach(IMyAirVent Ї in ø){if(Ї!=null){if(ɿ)Ї.Enabled=ɾ;if(Ї.CanPressurize)ς++;}}}void ă(
bool ɾ){foreach(IMyShipConnector Ј in Ă){if(Ј!=null)Ј.Enabled=ɾ;}}void ą(bool ɾ){foreach(IMyCameraBlock Љ in Ą){if(Љ!=null)Љ
.Enabled=ɾ;}}void ć(bool ɾ){foreach(IMySensorBlock Њ in Ć){if(Њ!=null)Њ.Enabled=ɾ;}}void ā(){N=true;foreach(
IMyTerminalBlock Ћ in Ā){Ћ.ApplyAction("OnOff_On");if(Ћ.IsFunctional)N=false;}}bool Ќ=false;List<string>Ѝ=new List<string>();bool Ў=
false;List<string>Џ=new List<string>();void Г(string g,string А){bool ʯ=false;List<IMyProgrammableBlock>Б=new List<
IMyProgrammableBlock>();try{if(А=="EFC")Б=Ŋ;else if(А=="NavOS")Б=ŋ;foreach(IMyProgrammableBlock В in Б){if(В==null||!В.Enabled)continue;ʯ=(В
as IMyProgrammableBlock).TryRun(g);if(k)Echo("Ran "+g+" on "+В.CustomName+" successfully.");À.Add(new Á("Ran "+А+" ("+g+
")","Ran "+А+" ("+g+")",0));if(А=="EFC")Ќ=true;else if(А=="NavOS")Ў=true;break;}}catch(Exception Đ){À.Add(new Á(А+
" command errored!",А+" command "+g+" errored!\n"+Đ.Message,3));}}void Д(string g,string А){if(А=="EFC"){if(Ŋ.Count<1)return;if(Ќ){Ѝ.Add(g)
;return;}}if(А=="NavOS"){if(ŋ.Count<1)return;if(Ў){Џ.Add(g);return;}}Г(g,А);}void Þ(){if(Ѝ.Count>0&&!Ќ){Г(Ѝ[0],"EFC");Ѝ.
RemoveAt(0);}if(Џ.Count>0&&!Ў){Г(Џ[0],"NavOS");Џ.RemoveAt(0);}Ќ=false;Ў=false;}int Ǩ=0;double Е=0;double ϕ=0;void ì(){Е=0;
foreach(IMyTerminalBlock З in ê){Ж(З,Ë.Ȃ!=ȃ.Off&&Ë.Ȃ!=ȃ.MinDefence);}foreach(IMyTerminalBlock З in ë){Ж(З,Ë.Ȃ!=ȃ.Off);}ϕ=Math.
Round(100*(Е/Ǩ));}void Ж(IMyTerminalBlock И,bool ɾ){if(И!=null&&И.IsFunctional){Е++;(И as IMyConveyorSorter).Enabled=ɾ;}}void
Й(ȃ ľ){if(ľ==ȃ.NoChange)return;foreach(IMyTerminalBlock З in ê){if(З!=null&З.IsFunctional){switch(ľ){case ȃ.Off:case ȃ.
MinDefence:(З as IMyConveyorSorter).Enabled=false;break;case ȃ.AllDefence:(З as IMyConveyorSorter).Enabled=true;if(Ǌ){try{З.
SetValue("WC_FocusFire",false);З.SetValue("WC_Projectiles",true);З.SetValue("WC_Grids",true);З.SetValue("WC_LargeGrid",false);З.
SetValue("WC_SmallGrid",true);З.SetValue("WC_SubSystems",true);З.SetValue("WC_Biologicals",true);ƽ(З);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;case ȃ.Offence:(З as IMyConveyorSorter).Enabled=true;if(Ǌ){try{З.SetValue("WC_FocusFire",false);З.SetValue(
"WC_Projectiles",true);З.SetValue("WC_Grids",true);З.SetValue("WC_LargeGrid",true);З.SetValue("WC_SmallGrid",true);З.SetValue(
"WC_SubSystems",true);З.SetValue("WC_Biologicals",true);ƽ(З);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock З in ë){if(З!=null&З.IsFunctional){switch(ľ){case ȃ.Off:(З as IMyConveyorSorter).Enabled=false;break;
case ȃ.MinDefence:case ȃ.AllDefence:case ȃ.Offence:(З as IMyConveyorSorter).Enabled=true;if(Ǌ){try{З.SetValue("WC_FocusFire"
,false);З.SetValue("WC_Projectiles",true);З.SetValue("WC_Grids",true);З.SetValue("WC_LargeGrid",false);З.SetValue(
"WC_SmallGrid",true);З.SetValue("WC_SubSystems",true);З.SetValue("WC_Biologicals",true);Ƽ(З);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double ά;void Ø(Ȟ ľ){ά=0;К();Л(ľ);}double β=0;double ǧ=0;double α=0;double ϔ=0;void Л(Ȟ ľ){β=0;α=0;double
М=0;foreach(IMyBatteryBlock Н in Ö){if(Н!=null&&Н.IsFunctional){α+=Н.CurrentStoredPower;β+=Н.MaxStoredPower;М+=Н.
MaxOutput;Н.Enabled=true;if(ľ==Ȟ.ManagedDischarge){if(О||П<=0)Н.ChargeMode=ChargeMode.Discharge;else Н.ChargeMode=ChargeMode.
Recharge;}}}ϔ=Math.Round(100*(М/ǧ));ά+=М;}void ʈ(){ǧ=0;foreach(IMyBatteryBlock Н in Ö){ChargeMode Р=Н.ChargeMode;Н.ChargeMode=
ChargeMode.Auto;ǧ+=Н.MaxOutput;Н.ChargeMode=Р;}}void С(Ȟ ľ){if(ľ==Ȟ.NoChange)return;foreach(IMyBatteryBlock Н in Ö){if(Н!=null&&!Н
.Closed&&Н.IsFunctional){Н.Enabled=true;if(ľ==Ȟ.Auto)Н.ChargeMode=ChargeMode.Auto;else if(ľ==Ȟ.StockpileRecharge)Н.
ChargeMode=ChargeMode.Recharge;else if(ľ==Ȟ.Discharge)Н.ChargeMode=ChargeMode.Discharge;}}}double Ǧ=0;double П=0;double ϓ=0;int υ=
0;void К(){П=0;υ=0;foreach(IMyReactor Т in Õ){if(Т!=null&&!Т.Closed&&Т.IsFunctional){Т.Enabled=true;if(ʫ(Т))υ++;else П+=Т
.MaxOutput;}}ϓ=Math.Round(100*(П/Ǧ));ά+=П;}void ʉ(){Ǧ=0;foreach(IMyReactor Т in Õ){Ǧ+=Т.MaxOutput;}}void µ(IMyProjector º
){º.CustomData=º.ProjectionOffset.X+"\n"+º.ProjectionOffset.Y+"\n"+º.ProjectionOffset.Z+"\n"+º.ProjectionRotation.X+"\n"+
º.ProjectionRotation.Y+"\n"+º.ProjectionRotation.Z+"\n";}void Â(IMyProjector º){if(!º.IsFunctional)return;try{string[]У=º
.CustomData.Split('\n');Vector3I Ф=new Vector3I(int.Parse(У[0]),int.Parse(У[1]),int.Parse(У[2]));Vector3I Х=new Vector3I(
int.Parse(У[3]),int.Parse(У[4]),int.Parse(У[5]));º.Enabled=true;º.ProjectionOffset=Ф;º.ProjectionRotation=Х;º.
UpdateOffsetAndRotation();}catch{if(k)Echo("Failed to load projector position for "+º.Name);}}int Ǫ=0;double Ц=0;double ϗ=0;bool О=false;void Ô
(){О=false;Ц=0;foreach(IMyTerminalBlock Ч in Ò){if(Ч!=null&&Ч.IsFunctional){Ц++;(Ч as IMyConveyorSorter).Enabled=Ë.ȅ!=Ȇ.
Off;if(!О){MyDetectedEntityInfo?Ш=č.ϻ(Ч);if(Ш.HasValue){string Ų=Ш.Value.Name;if(Ų!=null&&Ų!=""){if(k)Echo(
"At least one rail has a target!");О=true;}}}}}foreach(IMyTerminalBlock Ч in Ó){if(Ч!=null&&Ч.IsFunctional){Ц++;(Ч as IMyConveyorSorter).Enabled=Ë.ȅ!=Ȇ.
Off;}}ϗ=Math.Round(100*(Ц/Ǫ));}void Ы(Ȇ ľ){if(ľ==Ȇ.NoChange)return;foreach(IMyTerminalBlock Ъ in Ò){Щ(Ъ,ľ,false);}foreach(
IMyTerminalBlock Ъ in Ó){Щ(Ъ,ľ,true);}}void Щ(IMyTerminalBlock Ъ,Ȇ ľ,bool Ɯ){if(Ъ!=null&Ъ.IsFunctional){if(ľ==Ȇ.Off){(Ъ as
IMyConveyorSorter).Enabled=false;}else{(Ъ as IMyConveyorSorter).Enabled=true;if(!Ɯ){if(Ǌ){Ъ.SetValue("WC_Grids",true);Ъ.SetValue(
"WC_LargeGrid",true);Ъ.SetValue("WC_SmallGrid",true);Ъ.SetValue("WC_SubSystems",true);ƽ(Ъ);}if(ǋ){if(ľ==Ȇ.OpenFire){ǀ(Ъ);}else{ƿ(Ъ);}}
}}}}class ǲ{public string Ⱦ="";public Ȁ ǿ;public ȃ Ȃ;public Ȇ ȅ;public ȉ Ȉ;public Ȍ ȋ;public ȏ Ȏ;public Ȓ ȑ;public Color
Ȕ;public Ȓ Ȗ;public Color Ș;public Ȓ Ț;public Color Ȝ;public Ȟ Ù;public int Ƞ;public Í Ȣ;public ȥ Ȥ;public Í ȧ;public Ȫ ȩ
;public Í Ì;public Ȯ ȭ;public ȱ Ȱ;}string ē="N/A";ǲ Ë;Ȁ ȁ=Ȁ.On;ȃ Ȅ=ȃ.Offence;Ȇ ȇ=Ȇ.OpenFire;ȉ Ȋ=ȉ.On;Ȍ ȍ=Ȍ.On;ȏ Ȑ=ȏ.On;Ȓ
ȓ=Ȓ.On;Color ȕ=new Color(33,144,255,255);Ȓ ȗ=Ȓ.On;Color ș=new Color(255,214,170,255);Ȓ ț=Ȓ.On;Color ȝ=new Color(33,144,
255,255);Ȟ ȟ=Ȟ.Auto;int ȡ=-1;Í ȣ=Í.NoChange;ȥ Ȧ=ȥ.NoChange;Í Ȩ=Í.NoChange;Ȫ ȫ=Ȫ.KeepFull;Í Ȭ=Í.On;Ȯ ȯ=Ȯ.NoChange;ȱ Ȳ=ȱ.
NoChange;void s(string Ƚ){ǲ Ƿ;if(!ȳ.TryGetValue(Ƚ,out Ƿ)){À.Add(new Á("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(k)Echo("Setting stance '"+Ƚ+"'.");if(Ë.Ȥ==ȥ.Abort){Д("Off","EFC");Д("Abort","NavOS");}Ë=Ƿ;ē=Ƚ;ɖ();if(k)
Echo("Setting "+Ò.Count+" railguns to "+Ë.ȅ);Ы(Ë.ȅ);if(k)Echo("Setting "+ä.Count+" torpedoes to "+Ë.ǿ);Ь(Ë.ǿ);if(k)Echo(
"Setting "+ê.Count+" _normalPdcs, "+ë.Count+" defence _normalPdcs to "+Ë.Ȃ);Й(Ë.Ȃ);if(k)Echo("Setting "+Ú.Count+" epsteins, "+ň.
Count+" chems"+" to "+Ë.Ȉ);Э(Ë.Ȉ,Ë.ȋ);if(k)Echo("Setting "+è.Count+" rcs, "+ŉ.Count+" atmos"+" to "+Ë.ȋ);Ю(Ë.ȋ);if(k)Echo(
"Setting "+Ö.Count+" batteries to = "+Ë.Ù);С(Ë.Ù);if(k)Echo("Setting "+Ň.Count+" H2 tanks to stockpile = "+Ë.Ù);Я(Ë.Ù);if(k)Echo(
"Setting "+ñ.Count+" O2 tanks to stockpile = "+Ë.Ù);а(Ë.Ù);if(ǖ){if(k)Echo(
"No lighting was set because lighting control is disabled.");}else{if(k)Echo("Setting "+Œ.Count+" spotlights to "+Ë.Ȏ);Ͼ(Ë.Ȏ);if(k)Echo("Setting "+Ŏ.Count+" exterior lights to "+Ë
.ȑ);Ѐ(Ë.ȑ,Ë.Ȕ);if(k)Echo("Setting "+ŏ.Count+" exterior lights to "+Ë.Ȗ);Ё(Ë.Ȗ,Ë.Ș);if(k)Echo("Setting "+Ő.Count+
" port nav lights, "+ő.Count+" starboard nav lights to "+Ë.Ț);І(Ë.Ț);}if(k)Echo("Setting "+ú.Count+" aux block to "+Ë.ȧ);Ń(Ë.ȧ);if(k)Echo(
"Setting "+ń.Count+" hangar doors units to "+Ë.ȭ);ɶ(Ë.ȭ);if(Ë.ȅ==Ȇ.OpenFire){if(k)Echo("Setting "+ß.Count+
" doors to locked because we are in combat (rails set to open fire).");w("locked","");}if(k)Echo("Setting "+Ō.Count+" colour sync Lcds.");Ϡ();if(Ë.Ƞ>0){Д("Set Burn "+Ë.Ƞ,"EFC");float б=
Convert.ToSingle(Ë.Ƞ)/100;Д("ThrustRatio "+б,"NavOS");}if(Ë.Ȣ==Í.On)Д("Boost On","EFC");else if(Ë.Ȣ==Í.Off)Д("Boost Off","EFC")
;if(k)Echo("Finished setting stance.");}double λ=0;double ǫ=0;double κ=0;double Ϙ=0;void г(){κ=0;λ=0;foreach(IMyGasTank в
in Ň){if(в.IsFunctional){в.Enabled=true;λ+=в.Capacity;κ+=(в.Capacity*в.FilledRatio);}}Ϙ=Math.Round(100*(λ/ǫ));}void ʊ(){ǫ=
0;foreach(IMyGasTank в in Ň){if(в!=null)ǫ+=в.Capacity;}}void Я(Ȟ ľ){if(ľ==Ȟ.NoChange)return;foreach(IMyGasTank в in Ň){if
(в==null)continue;в.Enabled=true;if(ľ==Ȟ.StockpileRecharge)в.Stockpile=true;else в.Stockpile=false;}}double ί=0;double ή=
0;double Ǭ=0;double ϙ=0;void ò(){ή=0;ί=0;foreach(IMyGasTank в in ñ){if(в.IsFunctional){в.Enabled=true;ί+=в.Capacity;ή+=(в
.Capacity*в.FilledRatio);}}ϙ=Math.Round(100*(ί/Ǭ));}void ʋ(){Ǭ=0;foreach(IMyGasTank в in ñ){if(в!=null)Ǭ+=в.Capacity;}}
void а(Ȟ ľ){if(ľ==Ȟ.NoChange)return;foreach(IMyGasTank в in ñ){if(в==null)continue;в.Enabled=true;if(ľ==Ȟ.StockpileRecharge)
в.Stockpile=true;else в.Stockpile=false;}}float Χ;float Ω;float ǭ;double ϑ;void Û(){float д=0;float е=0;float ж=0;float з
=0;foreach(IMyThrust и in Ú){if(и!=null&&и.IsFunctional){д+=и.MaxThrust;ж+=и.CurrentThrust;if(и.Enabled){е+=и.MaxThrust;з
+=и.CurrentThrust;}}}ϑ=Math.Round(100*(д/ǭ));if(е==0){Χ=д;Ω=ж;}else{Χ=е;Ω=з;}}void ʆ(){ǭ=0;foreach(IMyThrust и in Ú){if(и
!=null)ǭ+=и.MaxThrust;}}void Э(ȉ ľ,Ȍ й){if(ľ==ȉ.NoChange)return;foreach(IMyThrust и in Ú){к(и,ľ,й);}foreach(IMyThrust и in
ň){к(и,ľ,й,true);}}void к(IMyThrust и,ȉ ľ,Ȍ й,bool л=false){bool м=и.CustomName.Contains(ǒ);if(м){if(й!=Ȍ.Off&&й!=Ȍ.
AtmoOnly)и.Enabled=true;else и.Enabled=false;}else{bool н=и.CustomName.Contains(Ǒ);if((ľ==ȉ.On)||(ľ==ȉ.Minimum&&н)||(ľ==ȉ.
EpsteinOnly&&!л)||(ľ==ȉ.ChemOnly&&л)){и.Enabled=true;}else{и.Enabled=false;}}}float о;float Ǯ;double ϒ;void é(){о=0;foreach(
IMyThrust и in è){if(и!=null&&и.IsFunctional){о+=и.MaxThrust;}}ϒ=Math.Round(100*(о/Ǯ));}void ʇ(){Ǯ=0;foreach(IMyThrust и in è){if
(и!=null)Ǯ+=и.MaxThrust;}}void Ю(Ȍ ľ){if(ľ==Ȍ.NoChange)return;foreach(IMyThrust и in è){if(и!=null)п(и,ľ);}foreach(
IMyThrust и in ŉ){if(и!=null)п(и,ľ,true);}}void п(IMyThrust и,Ȍ ľ,bool р=false){bool с=и.GridThrustDirection==Vector3I.Backward;
bool т=и.GridThrustDirection==Vector3I.Forward;if((ľ==Ȍ.On)||(ľ==Ȍ.ForwardOff&&!с)||(ľ==Ȍ.ReverseOff&&!т)||(ľ==Ȍ.RcsOnly&&!р
)||(ľ==Ȍ.AtmoOnly&&р)){и.Enabled=true;}else{и.Enabled=false;}}int ǩ=0;double у=0;double ϖ=0;void å(){у=0;foreach(
IMyTerminalBlock ф in ä){if(ф!=null&&ф.IsFunctional){у++;(ф as IMyConveyorSorter).Enabled=(Ë.ǿ==Ȁ.On||(Ë.ǿ==Ȁ.OnWhenLidarTarget&&Ϲ));if(
ġ){string ʨ=č.х(ф,0);int χ=ʩ(ʨ);if(k)Echo("Launcher "+ф.CustomName+" needs "+ʨ+"("+χ+")");ʤ(ф,χ);}}}ϖ=Math.Round(100*(у/ǩ
));}void Ь(Ȁ ľ){if(ľ==Ȁ.NoChange)return;foreach(IMyTerminalBlock ф in ä){if(ф!=null&ф.IsFunctional){if(ľ==Ȁ.
OnWhenLidarTarget){}bool ц=(ľ==Ȁ.On||(ľ==Ȁ.OnWhenLidarTarget&&Ϲ));if(!ц){(ф as IMyConveyorSorter).Enabled=false;}else{(ф as
IMyConveyorSorter).Enabled=true;if(Ǌ){ф.SetValue("WC_FocusFire",true);ф.SetValue("WC_Grids",true);ф.SetValue("WC_LargeGrid",true);ф.
SetValue("WC_SmallGrid",false);ф.SetValue("WC_FocusFire",true);ф.SetValue("WC_SubSystems",true);ƽ(ф);}}}}}Ď č;public class Ď{
Action<ICollection<MyDefinitionId>>ч;Action<ICollection<MyDefinitionId>>ш;Action<ICollection<MyDefinitionId>>щ;Func<Sandbox.
ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,int>,bool>ъ;Func<long,MyTuple<bool,int,int>>ы;Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,IDictionary<MyDetectedEntityInfo,float>>ь;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.
Ingame.MyDetectedEntityInfo>>э;Func<long,int,MyDetectedEntityInfo>ю;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>
я;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyDetectedEntityInfo>ѐ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
long,int>ё;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,int>ђ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,
int>ѓ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,bool,bool,bool>є;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,
float>ѕ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int,bool>і;Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,ICollection<string>,int>ї;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ј;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,long,int,bool>љ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>њ;Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,bool>ћ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,Vector3D?>ќ;Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,float>ѝ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>ў;Func<MyDefinitionId,float>џ;Func<long,bool
>Ѡ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool>ѡ;Func<long,float>Ѣ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,
string>ѣ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ѥ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<
long,int,ulong,long,Vector3D,bool>>ѥ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,
bool>>Ѧ;Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>ѧ;Func<long,float>Ѩ;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,long>ѩ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ѫ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>
ѫ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>Ѭ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,
MyTuple<Vector3D,Vector3D>>ѭ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,MyTuple<bool,bool>>Ѯ;public bool ď(Sandbox.ModAPI.
Ingame.IMyTerminalBlock ѯ){var Ѱ=ѯ.GetProperty("WcPbAPI")?.As<IReadOnlyDictionary<string,Delegate>>().GetValue(ѯ);if(Ѱ==null)
throw new Exception("WcPbAPI failed to activate");return ѱ(Ѱ);}public bool ѱ(IReadOnlyDictionary<string,Delegate>Ѳ){if(Ѳ==
null)return false;ѳ(Ѳ,"GetCoreWeapons",ref ч);ѳ(Ѳ,"GetCoreStaticLaunchers",ref ш);ѳ(Ѳ,"GetCoreTurrets",ref щ);ѳ(Ѳ,
"GetBlockWeaponMap",ref ъ);ѳ(Ѳ,"GetProjectilesLockedOn",ref ы);ѳ(Ѳ,"GetSortedThreats",ref ь);ѳ(Ѳ,"GetObstructions",ref э);ѳ(Ѳ,"GetAiFocus",
ref ю);ѳ(Ѳ,"SetAiFocus",ref я);ѳ(Ѳ,"GetWeaponTarget",ref ѐ);ѳ(Ѳ,"SetWeaponTarget",ref ё);ѳ(Ѳ,"FireWeaponOnce",ref ђ);ѳ(Ѳ,
"ToggleWeaponFire",ref ѓ);ѳ(Ѳ,"IsWeaponReadyToFire",ref є);ѳ(Ѳ,"GetMaxWeaponRange",ref ѕ);ѳ(Ѳ,"GetTurretTargetTypes",ref і);ѳ(Ѳ,
"SetTurretTargetTypes",ref ї);ѳ(Ѳ,"SetBlockTrackingRange",ref ј);ѳ(Ѳ,"IsTargetAligned",ref љ);ѳ(Ѳ,"IsTargetAlignedExtended",ref њ);ѳ(Ѳ,
"CanShootTarget",ref ћ);ѳ(Ѳ,"GetPredictedTargetPosition",ref ќ);ѳ(Ѳ,"GetHeatLevel",ref ѝ);ѳ(Ѳ,"GetCurrentPower",ref ў);ѳ(Ѳ,"GetMaxPower"
,ref џ);ѳ(Ѳ,"HasGridAi",ref Ѡ);ѳ(Ѳ,"HasCoreWeapon",ref ѡ);ѳ(Ѳ,"GetOptimalDps",ref Ѣ);ѳ(Ѳ,"GetActiveAmmo",ref ѣ);ѳ(Ѳ,
"SetActiveAmmo",ref Ѥ);ѳ(Ѳ,"MonitorProjectile",ref ѥ);ѳ(Ѳ,"UnMonitorProjectile",ref Ѧ);ѳ(Ѳ,"GetProjectileState",ref ѧ);ѳ(Ѳ,
"GetConstructEffectiveDps",ref Ѩ);ѳ(Ѳ,"GetPlayerController",ref ѩ);ѳ(Ѳ,"GetWeaponAzimuthMatrix",ref Ѫ);ѳ(Ѳ,"GetWeaponElevationMatrix",ref ѫ);ѳ(Ѳ,
"IsTargetValid",ref Ѭ);ѳ(Ѳ,"GetWeaponScope",ref ѭ);ѳ(Ѳ,"IsInRange",ref Ѯ);return true;}void ѳ<Ѵ>(IReadOnlyDictionary<string,Delegate>Ѳ,
string Ť,ref Ѵ ѵ)where Ѵ:class{if(Ѳ==null){ѵ=null;return;}Delegate Ѷ;if(!Ѳ.TryGetValue(Ť,out Ѷ))throw new Exception(
$"{GetType().Name} :: Couldn't find {Ť} delegate of type {typeof(Ѵ)}");ѵ=Ѷ as Ѵ;if(ѵ==null)throw new Exception(
$"{GetType().Name} :: Delegate {Ť} is not type {typeof(Ѵ)}, instead it's: {Ѷ.GetType()}");}public void Ѹ(ICollection<MyDefinitionId>ѷ)=>ч?.Invoke(ѷ);public void ѹ(ICollection<MyDefinitionId>ѷ)=>ш?.Invoke(ѷ);
public void Ѻ(ICollection<MyDefinitionId>ѷ)=>щ?.Invoke(ѷ);public bool Ѽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ѻ,IDictionary<
string,int>ѷ)=>ъ?.Invoke(ѻ,ѷ)??false;public MyTuple<bool,int,int>Ѿ(long ѽ)=>ы?.Invoke(ѽ)??new MyTuple<bool,int,int>();public
void Ҁ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ѿ,IDictionary<MyDetectedEntityInfo,float>ѷ)=>ь?.Invoke(ѿ,ѷ);public void ҁ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ѿ,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>ѷ)=>э?.Invoke(ѿ,ѷ);public
MyDetectedEntityInfo?Ҍ(long Ҋ,int ҋ=0)=>ю?.Invoke(Ҋ,ҋ);public bool Ҏ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ѿ,long ҍ,int ҋ=0)=>я?.Invoke(ѿ,ҍ
,ҋ)??false;public MyDetectedEntityInfo?ϻ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ=0)=>ѐ?.Invoke(ҏ,Ґ);public void ґ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,long ҍ,int Ґ=0)=>ё?.Invoke(ҏ,ҍ,Ґ);public void ғ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
ҏ,bool Ғ=true,int Ґ=0)=>ђ?.Invoke(ҏ,Ғ,Ґ);public void ҕ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,bool Ҕ,bool Ғ,int Ґ=0)=>ѓ
?.Invoke(ҏ,Ҕ,Ғ,Ґ);public bool Ҙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ=0,bool Җ=true,bool җ=false)=>є?.Invoke(ҏ,Ґ
,Җ,җ)??false;public float ҙ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ)=>ѕ?.Invoke(ҏ,Ґ)??0f;public bool Қ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock ҏ,IList<string>ѷ,int Ґ=0)=>і?.Invoke(ҏ,ѷ,Ґ)??false;public void қ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ҏ,IList<string>ѷ,int Ґ=0)=>ї?.Invoke(ҏ,ѷ,Ґ);public void Ҝ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,float Ğ)=>ј?.Invoke(
ҏ,Ğ);public bool Ҟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,long ҝ,int Ґ)=>љ?.Invoke(ҏ,ҝ,Ґ)??false;public MyTuple<bool,
Vector3D?>ҟ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,long ҝ,int Ґ)=>њ?.Invoke(ҏ,ҝ,Ґ)??new MyTuple<bool,Vector3D?>();public bool
Ҡ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,long ҝ,int Ґ)=>ћ?.Invoke(ҏ,ҝ,Ґ)??false;public Vector3D?ҡ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock ҏ,long ҝ,int Ґ)=>ќ?.Invoke(ҏ,ҝ,Ґ)??null;public float Ң(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ)=>ѝ?.
Invoke(ҏ)??0f;public float ң(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ)=>ў?.Invoke(ҏ)??0f;public float ҥ(MyDefinitionId Ҥ)=>џ?.
Invoke(Ҥ)??0f;public bool ҧ(long Ҧ)=>Ѡ?.Invoke(Ҧ)??false;public bool Ҩ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ)=>ѡ?.Invoke(ҏ)
??false;public float ҩ(long Ҧ)=>Ѣ?.Invoke(Ҧ)??0f;public string х(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ)=>ѣ?.
Invoke(ҏ,Ґ)??null;public void ҫ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ,string Ҫ)=>Ѥ?.Invoke(ҏ,Ґ,Ҫ);public void Ҭ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ,Action<long,int,ulong,long,Vector3D,bool>ŀ)=>ѥ?.Invoke(ҏ,Ґ,ŀ);public void ҭ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ,Action<long,int,ulong,long,Vector3D,bool>ŀ)=>Ѧ?.Invoke(ҏ,Ґ,ŀ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>ү(ulong Ү)=>ѧ?.Invoke(Ү)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float Ұ(long Ҧ)=>Ѩ?.Invoke(Ҧ)??0f;public long ұ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ)=>ѩ?.Invoke(ҏ)??-1;public
Matrix ƾ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ)=>Ѫ?.Invoke(ҏ,Ґ)??Matrix.Zero;public Matrix Ҳ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock ҏ,int Ґ)=>ѫ?.Invoke(ҏ,Ґ)??Matrix.Zero;public bool Ҷ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,long ҳ,bool Ҵ,bool ҵ)=>Ѭ?.
Invoke(ҏ,ҳ,Ҵ,ҵ)??false;public MyTuple<Vector3D,Vector3D>ҷ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ҏ,int Ґ)=>ѭ?.Invoke(ҏ,Ґ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>Ҹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock ƺ)=>Ѯ?.Invoke(ƺ)??new MyTuple<
bool,bool>();}int ǰ=0;double ҹ=0;double Ϛ=0;void ý(){ҹ=0;foreach(IMyTerminalBlock Һ in ü){if(Һ!=null&&Һ.IsFunctional)ҹ++;}Ϛ=
Math.Round(100*(ҹ/ǰ));}enum Í{
Off, On, NoChange
}enum Ȓ{
Off, On, NoChange, OnNoColourChange
}enum ȃ{
Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
}enum Ȇ{
Off, HoldFire, OpenFire, NoChange
}enum ȉ{
Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
}enum Ȍ{
Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
}enum ȏ{
On, Off, OnMax, NoChange
}enum Ȟ{
Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
}enum ȥ{
Abort, NoChange
}enum Ȫ{
Off, On, FillWhenLow, KeepFull,
}enum Ȯ{
Closed, Open, NoChange
}enum ȱ{
On, Off, NoChange
}enum Ȁ{
Off, On, NoChange, OnWhenLidarTarget
}
}
internal sealed class A{public double ĕ{get;private set;}double Ҿ{get{double Ҽ=һ[0];for(int Ʉ=1;Ʉ<ҽ;Ʉ++){Ҽ+=һ[Ʉ];}return
(Ҽ/ҽ);}}public double Ė{get{double ҿ=һ[0];for(int Ʉ=1;Ʉ<ҽ;Ʉ++){if(һ[Ʉ]>ҿ){ҿ=һ[Ʉ];}}return ҿ;}}public double Ӏ{get;private
set;}public double ӂ{get{double Ӂ=һ[0];for(int Ʉ=1;Ʉ<ҽ;Ʉ++){if(һ[Ʉ]<Ӂ){Ӂ=һ[Ʉ];}}return Ӂ;}}public int ҽ{get;}double Ӄ;
IMyGridProgramRuntimeInfo ӄ;double[]һ;int Ӆ=0;public A(IMyGridProgramRuntimeInfo ӄ,int ӆ=300){this.ӄ=ӄ;this.Ӏ=ӄ.LastRunTimeMs;this.ҽ=MathHelper.
Clamp(ӆ,1,int.MaxValue);this.Ӄ=1.0/ҽ;this.һ=new double[ӆ];this.һ[Ӆ]=ӄ.LastRunTimeMs;this.Ӆ++;}public void Ĕ(){ĕ-=һ[Ӆ]*Ӄ;ĕ+=ӄ.
LastRunTimeMs*Ӄ;һ[Ӆ]=ӄ.LastRunTimeMs;if(ӄ.LastRunTimeMs>Ӏ){Ӏ=ӄ.LastRunTimeMs;}Ӆ++;if(Ӆ>=ҽ){Ӆ=0;ĕ=Ҿ;Ӏ=ӄ.LastRunTimeMs;}}