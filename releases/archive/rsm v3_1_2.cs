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

string Version = "3.1.2 (2026-08-22)";
A B;int C=0;int D=0;int E=0;int F;int G=0;bool H=true;bool I=true;bool J=false;bool K=false;bool L=false;bool M=false;
bool N=false;double O=100;int P=0;int Q=0;double R;float S;string T;string U;string V;bool W=false;int X=0;int Y=0;bool Z;
bool a;bool b;public
 Program
(){Echo("Welcome to RSM\nV "+Version);c();F=d;T=Me.GetOwnerFactionTag();B=new A(Runtime);e();f.Add(0.5);f.Add(0.25);f.Add
(0.1);f.Add(0.05);g();Runtime.UpdateFrequency=UpdateFrequency.Update100;Echo("Took "+c());}public void
 Main
(string h,UpdateType i){if(i==UpdateType.Update100)j();else k(h);}void k(string h){if(l)Echo("Processing command '"+h+
"'...");if(I){m(h,"RSM is still booting");return;}if(J){m(h,"RSM is still initialising");return;}if(h==""){m(h,
"the argument was blank");return;}string[]n=h.Split(':');if(n.Length<2){m(h,"the argument wasn't recognised");return;}if(n[0].ToLower()!="comms"
)n[1]=n[1].Replace(" ",string.Empty);switch(n[0].ToLower()){case"init":bool o=true,p=true,q=true;if(n.Length>2){foreach(
string r in n){if(r.ToLower()=="nonames")o=false;else if(r.ToLower()=="nosubs")p=false;else if(r.ToLower()=="noinv")q=false;}}
s(n[1],o,p,q);return;case"stance":t(n[1]);return;case"hudlcd":string u="";if(n.Length>2)u=n[2];v(n[1],u);return;case
"doors":string w="";if(n.Length>2)w=n[2];x(n[1],w);return;case"comms":y(n[1]);return;case"printblockids":z();return;case
"printblockprops":ª(n[1]);return;case"spawn":if(n[1].ToLower()=="open"){M=true;F=d;}else{M=false;F=d;}return;case"projectors":if(n[1].
ToLower()=="save"){foreach(IMyProjector À in µ)º(À);Á.Add(new Â("Projector positions saved",
"Projector positions were saved and stored to their custom data.",2));return;}else{foreach(IMyProjector À in µ)Ã(À);Á.Add(new Â("Projector positions loaded",
"Projector positions were loaded from custom data.",2));return;}default:m(h,"the argument wasn't recognised");return;}}void m(string h,string Ä){Á.Add(new Â(
"COMMAND FAILED!","Command '"+h+"' was ignored because "+Ä,3));}void j(){if(Å)c();if(D<Æ){D++;return;}D=0;if(H){Echo(
"Parsing custom data...");Ç();H=false;return;}else if(J){È();if(l)Echo("Updating "+É.Count+" RSM Lcds");Ê();}Ë();X=Runtime.
CurrentInstructionCount;if(X>Y)Y=Runtime.CurrentInstructionCount;if(Ì.Í==Î.On){K=true;L=true;}else if(Ì.Í==Î.Off){K=true;}if(F>=d){F=0;Ï();
return;}F++;Ð();Ñ();if(Å)Echo("Took "+c());if(l)Echo("Updating "+É.Count+" RSM Lcds");Ê();if(Å)Echo("Took "+c());}void Ð(){Ò()
;switch(C){case 0:if(l)Echo("Refreshing "+(Ó.Count+Ô.Count)+" kinetics...");Õ();if(Å)Echo("Took "+c());if(I)break;else
goto case 1;case 1:if(l)Echo("Refreshing "+Ö.Count+" reactors & "+Ø.Count+" batteries...");Ù(Ì.Ú);if(Å)Echo("Took "+c());if(
I)break;else goto case 2;case 2:if(l)Echo("Refreshing "+Û.Count+" epsteins...");Ü();if(Å)Echo("Took "+c());if(I)break;
else goto case 3;case 3:if(l)Echo("Refreshing "+Ý.Count+" lidars...");Þ(L,K);if(Å)Echo("Took "+c());if(l)Echo(
"Refreshing pb servers...");ß();if(Å)Echo("Took "+c());if(I)break;else goto case 4;case 4:if(l)Echo("Refreshing "+à.Count+" doors...");á();if(Å)
Echo("Took "+c());if(l)Echo("Refreshing "+â.Count+" airlocks...");ã();if(Å)Echo("Took "+c());break;default:if(l)Echo(
"Booting complete");I=false;C=0;return;}if(I)C++;}void Ñ(){switch(E){case 0:if(l)Echo("Clearing temp inventories...");ä();if(Å)Echo(
"Took "+c());if(l)Echo("Refreshing "+å.Count+" torpedo launchers...");æ();if(Å)Echo("Took "+c());if(l)Echo(
"Refreshing items...");ç();if(Å)Echo("Took "+c());break;case 1:if(l)Echo("Running autoload...");è();if(Å)Echo("Took "+c());break;case 2:if(l)
Echo("Refreshing "+é.Count+" H2 tanks...");ê();if(Å)Echo("Took "+c());ë();if(Å)Echo("Took "+c());E=0;return;}E++;}void ë(){
if(l)Echo("Refreshing "+ì.Count+" rcs...");í();if(l)Echo("Refreshing "+î.Count+" Pdcs & "+ï.Count+" defensive Pdcs...");ð(
);if(l)Echo("Refreshing "+ñ.Count+" gyros...");ò(L,K);if(l)Echo("Refreshing "+ó.Count+" RCS gyros...");ô();if(l)Echo(
"Refreshing "+õ.Count+" O2 tanks...");ö();if(l)Echo("Refreshing "+ø.Count+" antennas...");ù();if(l)Echo("Refreshing "+ú.Count+
" cargos...");û();if(l)Echo("Refreshing "+ü.Count+" hangar pads...");ý();if(l)Echo("Refreshing "+þ.Count+" ship cores...");ÿ();if(l)
Echo("Refreshing "+Ā.Count+" vents...");ā(L,K);if(l)Echo("Refreshing "+Ă.Count+" auxiliary blocks...");ă();if(l)Echo(
"Refreshing "+Ą.Count+" welders...");ą();if(l)Echo("Refreshing "+Ć.Count+" lcds...");ć();if(l)Echo("Refreshing "+Ĉ.Count+" lcds...");
ĉ();if(K){if(l)Echo("Refreshing "+Ċ.Count+" connectors...");ċ(L);if(l)Echo("Refreshing "+Č.Count+" cameras...");č(L);if(l
)Echo("Refreshing "+Ď.Count+" sensors...");ď(L);}}void Ï(){if(l)Echo("Clearing block lists...");Đ();if(Å)Echo("Took "+c()
);if(l)Echo("Refreshing block lists...");GridTerminalSystem.GetBlocksOfType((List<IMyTerminalBlock>)null,đ);if(Å)Echo(
"Took "+c());if(Ē==null){if(ē.Count>0)Ē=ē[0];else Á.Add(new Â("NO SHIP _shipController!",
"No ship controller was found on this grid. Some functionality will not operate correctly.",3));}if(l)Echo("Finished block refresh.");if(Å)Echo("Took "+c());}void Ò(){try{Ĕ=new ĕ();Ĕ.Ė(Me);}catch(Exception ė){Ĕ=
null;Á.Add(new Â("WcPbApi Error!","WcPbApi failed to start!\n"+ė.Message,1));Echo("WcPbAPI failed to activate!");Echo(ė.
Message);return;}}void Ë(){string Ę="REEDIT SHIP MANAGEMENT \n\n";if(I)Ę+="Booting, please wait ("+C+"/5)...\n\n";Ę+="|- V "+
Version+"\n|- Ship Name: "+ę+"\n|- Stance: "+Ě+"\n|- Step: "+F+"/"+d+" ("+E+")";if(Å){B.ě();Ę+="\n|- Runtime Av/Tick: "+(Math.
Round(B.Ĝ,2)/100)+" ms"+"\n|- Runtime Max: "+Math.Round(B.ĝ,4)+" ms"+"\n|- Instructions: "+X+" ("+Y+")";}Echo(Ę+"\n");}long Ğ
=0;string c(){long ğ=DateTime.Now.Ticks/TimeSpan.TicksPerMillisecond;if(Ğ==0){Ğ=ğ;return"0 ms";}long Ġ=ğ-Ğ;Ğ=ğ;return Ġ+
" ms";}bool ġ=false;string Ģ="";double ģ=0;void ù(){ġ=false;ģ=0;foreach(IMyRadioAntenna Ĥ in ø){if(Ĥ!=null&&!Ĥ.Closed&&Ĥ.
IsFunctional){float ĥ=Ĥ.Radius;if(ĥ>ģ)ģ=ĥ;if(Ĥ.IsBroadcasting&&Ĥ.Enabled)ġ=true;}}}void y(string Ħ){Ģ=Ħ;foreach(IMyTerminalBlock ħ
in ø){IMyRadioAntenna Ĥ=ħ as IMyRadioAntenna;if(Ĥ!=null)Ĥ.HudText=Ħ;}}void è(){if(!Ĩ)return;foreach(var Ī in ĩ){if(!Ī.ī&&!
Ī.Ĭ)continue;if(l)Echo("Checking "+Ī.ĭ);List<Į>ı=Ī.į.Concat(Ī.İ).ToList();List<Į>Ĳ=new List<Į>();List<Į>ĳ=new List<Į>();
List<Į>Ĵ=new List<Į>();List<Į>ĵ=new List<Į>();List<Į>Ķ=new List<Į>();double ķ=0;double ĸ=0;bool Ĺ=true;double ĺ=.97;if(Ī.Ļ<1
)ĺ=Ī.Ļ*.97;foreach(Į ļ in ı){if(ļ==null)continue;if(ļ.Ľ){ķ+=ļ.ľ;if(ļ.Ŀ>0)ĸ+=ļ.Ŀ;else Ĺ=false;if(ļ.ŀ<ĺ)Ĵ.Add(ļ);else if(Ī.
Ļ<1&&ļ.ŀ>Ī.Ļ*1.03)ĵ.Add(ļ);if(ļ.ŀ!=0)ĳ.Add(ļ);}else{Ķ.Add(ļ);if(ļ.ľ>0){Ĳ.Add(ļ);}}}if(Ĵ.Count>0){double Ł=-1;if(Ĺ&&ĸ>0){Ł
=ķ/ĸ;if(Ł>Ī.Ļ)Ł=Ī.Ļ;}Ĵ=Ĵ.OrderBy(ł=>ł.ŀ).ToList();if(Ī.Ń>0){if(l)Echo("Loading "+Ī.ń.SubtypeId+"...");Ĳ=Ĳ.
OrderByDescending(ł=>ł.ľ).ToList();Ņ(Ĳ,Ĵ,Ī.ń,-1,Ī.Ļ);}else{if(l)Echo("Balancing "+Ī.ń.SubtypeId+"...");ĳ=ĳ.OrderByDescending(ł=>ł.ŀ).
ToList();Ņ(ĳ,Ĵ,Ī.ń,Ł,Ī.Ļ);}}else if(ĵ.Count>0){if(l)Echo("Unloading "+Ī.ń.SubtypeId+"...");List<Į>ņ=new List<Į>();if(Ĳ.Count>0
)ņ=Ĳ;else ņ=Ķ;Ņ(ĵ,ņ,Ī.ń,-1,1,Ī.Ļ);}else{if(l)Echo("No loading required "+Ī.ń.SubtypeId+"...");}}}void ă(){Q=0;foreach(
IMyTerminalBlock ħ in Ă){if(ħ==null)continue;if(ħ.IsWorking)Q++;}}void Ō(Î Ň){if(Ň==Î.NoChange)return;foreach(IMyTerminalBlock ħ in Ă){
if(ħ==null)continue;try{bool ň=ħ.BlockDefinition.ToString().Contains("ToolCore");if(Ň==Î.On||ň)ħ.ApplyAction("OnOff_On");
else if(!ň)ħ.ApplyAction("OnOff_Off");if(ň){ITerminalAction ŉ=ħ.GetActionWithName("ToolCore_Shoot_Action");if(ŉ!=null){
StringBuilder Ŋ=new StringBuilder();ŉ.WriteValue(ħ,Ŋ);string ŋ=Ŋ.ToString();if(l)Echo(ŋ);if(ŋ=="Active"&&Ň==Î.Off)ŉ.Apply(ħ);else if(
ŋ=="Inactive"&&Ň==Î.On)ŉ.Apply(ħ);}}}catch{if(l)Echo("Failed to set aux block "+ħ.CustomName);}}}IMyShipController Ē;List
<IMyRadioAntenna>ø=new List<IMyRadioAntenna>();List<IMyBatteryBlock>Ø=new List<IMyBatteryBlock>();List<IMyCameraBlock>Č=
new List<IMyCameraBlock>();List<IMyCargoContainer>ú=new List<IMyCargoContainer>();List<IMyShipConnector>Ċ=new List<
IMyShipConnector>();List<IMyShipController>ē=new List<IMyShipController>();List<IMyAirtightHangarDoor>ō=new List<IMyAirtightHangarDoor>(
);List<IMyFunctionalBlock>ü=new List<IMyFunctionalBlock>();List<IMyTerminalBlock>þ=new List<IMyTerminalBlock>();List<
IMyTerminalBlock>Ŏ=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ŏ=new List<IMyTerminalBlock>();List<IMyGyro>ñ=new List<IMyGyro>();
List<IMyGyro>ó=new List<IMyGyro>();List<IMyProjector>µ=new List<IMyProjector>();List<IMyReactor>Ö=new List<IMyReactor>();
List<IMySensorBlock>Ď=new List<IMySensorBlock>();List<IMyTerminalBlock>Ĉ=new List<IMyTerminalBlock>();List<IMyGasTank>é=new
List<IMyGasTank>();List<IMyGasTank>õ=new List<IMyGasTank>();List<IMyAirVent>Ā=new List<IMyAirVent>();List<IMyTerminalBlock>Ą
=new List<IMyTerminalBlock>();List<IMyConveyorSorter>Ý=new List<IMyConveyorSorter>();List<IMyTerminalBlock>î=new List<
IMyTerminalBlock>();List<IMyTerminalBlock>ï=new List<IMyTerminalBlock>();List<IMyTerminalBlock>Ó=new List<IMyTerminalBlock>();List<
IMyTerminalBlock>Ô=new List<IMyTerminalBlock>();List<IMyTerminalBlock>å=new List<IMyTerminalBlock>();List<IMyThrust>Û=new List<IMyThrust
>();List<IMyThrust>ì=new List<IMyThrust>();List<IMyThrust>Ő=new List<IMyThrust>();List<IMyThrust>ő=new List<IMyThrust>();
List<IMyProgrammableBlock>Œ=new List<IMyProgrammableBlock>();List<IMyProgrammableBlock>œ=new List<IMyProgrammableBlock>();
List<IMyTextPanel>Ć=new List<IMyTextPanel>();List<IMyTextPanel>Ŕ=new List<IMyTextPanel>();List<ŕ>É=new List<ŕ>();List<
IMyLightingBlock>Ŗ=new List<IMyLightingBlock>();List<IMyLightingBlock>ŗ=new List<IMyLightingBlock>();List<IMyLightingBlock>Ř=new List<
IMyLightingBlock>();List<IMyLightingBlock>ř=new List<IMyLightingBlock>();List<IMyReflectorLight>Ś=new List<IMyReflectorLight>();List<
IMyTerminalBlock>Ă=new List<IMyTerminalBlock>();List<IMyTerminalBlock>ś=new List<IMyTerminalBlock>();List<Ŝ>à=new List<Ŝ>();List<ŝ>â=new
List<ŝ>();Dictionary<IMyTerminalBlock,string>Ş=new Dictionary<IMyTerminalBlock,string>();bool đ(IMyTerminalBlock ş){try{if(!
Me.IsSameConstructAs(ş))return false;string Š=ş.GetOwnerFactionTag();if(Š!=T&&Š!=""){Echo("!"+Š+": "+ş.CustomName);P++;
return false;}if(ş.CustomName.Contains(š))return false;if(!J&&Ţ&&!ş.CustomName.Contains(ę))return false;string ţ=ş.
BlockDefinition.ToString();if(ş.CustomName.Contains(Ť)){Ă.Add(ş);}if(ţ.Contains("MedicalRoom/")){if(M)ş.CustomData=V;else ş.CustomData=
U;Ĉ.Add(ş);if(J)Ş.Add(ş,"Medical Room");return false;}if(ţ.Contains("SurvivalKit/")){if(M)ş.CustomData=V;else ş.
CustomData=U;Ĉ.Add(ş);if(J)Ş.Add(ş,"Survival Kit");return false;}if(ţ=="MyObjectBuilder_MedicalRoom/LargeRefillStation"){if(J)Ş.
Add(ş,"Refill Station");return false;}var ť=ş as IMyTextPanel;if(ť!=null){Ć.Add(ť);if(J)Ş.Add(ş,"LCD");if(ť.CustomName.
Contains(Ŧ)){ŕ ŧ=new ŕ();ŧ.ħ=ť;É.Add(Ũ(ŧ));}else if(!ũ&&ť.CustomName.Contains(Ū))Ŕ.Add(ť);return false;}if(ţ.Contains("sdx_pdc")
){if(ţ.Contains("sdx_pdcImprovised"))return ū(ş,"Improv",3);if(ţ.Contains("sdx_pdcMcrnAdv"))return ū(ş,"Maegnus",2);if(ţ.
Contains("sdx_pdcOpaAdv"))return ū(ş,"Fragmanta",2);if(ţ.Contains("sdx_pdcUnnAdv"))return ū(ş,"Redfield",4);if(ţ.Contains(
"sdx_pdcMcrn"))return ū(ş,"Nariman",4);if(ţ.Contains("sdx_pdcOpa"))return ū(ş,"Kess",4);if(ţ.Contains("sdx_pdcUnn"))return ū(ş,
"Mikazuki",4);}if(ţ.Contains("sdx_torpedoLauncher")){string Ŭ="Unknown";if(ţ.Contains("Improvised"))Ŭ="Improv";else if(ţ.Contains(
"Light"))Ŭ="Light";else if(ţ.Contains("Medium"))Ŭ="Medium";if(ţ.Contains("Single"))Ŭ+="x1";else if(ţ.Contains("Double"))Ŭ+="x2"
;else if(ţ.Contains("Triple"))Ŭ+="x3";return ŭ(ş,Ŭ);}if(ţ.Contains("sdx_railgun")){string Ŭ="Unknown";int Ů=13;if(ţ.
Contains("Fixed"))Ŭ="Fixed";if(ţ.Contains("Improvised")){Ŭ+="Improv";}else if(ţ.Contains("Light")){Ŭ+="Light";Ů=14;}else if(ţ.
Contains("Medium")){Ŭ+="Medium";Ů=15;}return ů(ş,Ŭ,Ů);}var Ű=ş as IMyThrust;if(Ű!=null){if(ţ.ToUpper().Contains("RCS")){ì.Add(Ű)
;if(J)Ş.Add(ş,"RCS");}else if(ţ.Contains("Hydro")){Ő.Add(Ű);if(J)Ş.Add(ş,"Chem");}else if(ţ.Contains("Atmospheric")){ő.
Add(Ű);if(J)Ş.Add(ş,"Atmo");}else{Û.Add(Ű);if(J){string ű="";if(Ų){try{string ų=ş.DefinitionDisplayNameText.Replace(
'\u201C','"').Replace('\u201D','"').Replace('\u201E','"').Replace('\u201F','"').Replace('\u00AB','"').Replace('\u00BB','"');ű=ų.
Split('"')[1];ű=Ŵ+ű[0].ToString().ToUpper()+ű.Substring(1).ToLower();}catch{if(l)Echo("Failed to get drive type from "+ş.
DefinitionDisplayNameText);}}Ş.Add(ş,"Epstein"+ű);}}return false;}var ŵ=ş as IMyCargoContainer;if(ŵ!=null){string Ŷ=ţ.Split('/')[1].ToUpper();if(
Ŷ.Contains("CONTAINER")||Ŷ.Contains("CARGO")){ú.Add(ŵ);ŷ(ş);if(J){double Ÿ=ş.GetInventory().MaxVolume.RawValue;double Ź=
Math.Round(Ÿ/421875000,1);if(Ź==0)Ź=0.1;Ş.Add(ş,"Cargo ["+Ź+"]");}return false;}}var ź=ş as IMyGyro;if(ź!=null){string Ż=
"Gyroscope";if(ţ.Contains("rcsGyroComputer")){Ż="Gyroscope.RCSComp";ó.Add(ź);}else ñ.Add(ź);if(J)Ş.Add(ş,Ż);return false;}var ż=ş
as IMyBatteryBlock;if(ż!=null){Ø.Add(ż);if(J)Ş.Add(ş,"Power"+Ŵ+"Battery");return false;}var Ž=ş as IMyReflectorLight;if(Ž
!=null){Ś.Add(Ž);if(J)Ş.Add(ş,"Spotlight");return false;}var ž=ş as IMyLightingBlock;if(ž!=null){if(ş.CustomName.ToUpper()
.Contains("INTERIOR")){ŗ.Add(ž);if(J)Ş.Add(ş,"Light"+Ŵ+"Interior");}else if(ţ.Contains("Kitchen")||ţ.Contains("Aquarium")
){ŗ.Add(ž);if(J)Ş.Add(ş,"Light"+Ŵ+"Interior"+Ŵ+ş.DefinitionDisplayNameText);}else if(ş.CustomName.Contains(ſ)){if(ş.
CustomName.ToUpper().Contains("STARBOARD")){ř.Add(ž);if(J)Ş.Add(ş,"Light"+Ŵ+"Nav"+Ŵ+"Starboard");}else{Ř.Add(ž);if(J)Ş.Add(ş,
"Light"+Ŵ+"Nav"+Ŵ+"Port");}}else{Ŗ.Add(ž);if(J)Ş.Add(ş,"Light"+Ŵ+"Exterior");}return false;}var ƀ=ş as IMyGasTank;if(ƀ!=null){
if(ţ.Contains("Hydro")){é.Add(ƀ);if(J)Ş.Add(ş,"Tank"+Ŵ+"Hydrogen");}else{õ.Add(ƀ);if(J)Ş.Add(ş,"Tank"+Ŵ+"Oxygen");}return
false;}var Ɓ=ş as IMyReactor;if(Ɓ!=null){Ö.Add(Ɓ);ŷ(ş,0);if(J){string Ƃ="Lg";if(ţ.Contains("SmallGenerator"))Ƃ="Sm";else if(ţ
.Contains("MCRN"))Ƃ="MCRN";Ş.Add(ş,"Power"+Ŵ+"Reactor"+Ŵ+Ƃ);}return false;}var ƃ=ş as IMyShipController;if(ƃ!=null){ē.Add
(ƃ);if(Ē==null&&ş.CustomName.Contains("Nav"))Ē=ƃ;if(ƃ.HasInventory)ŷ(ş);if(J&&ţ.Contains("Cockpit/")){if(ţ.Contains(
"StandingCockpit")||ţ.Contains("Console")){Ş.Add(ş,"Console");return false;}else if(ţ.Contains("Cockpit")){Ş.Add(ş,"Cockpit");return
false;}}}var Ƅ=ş as IMyDoor;if(Ƅ!=null){Ŝ ƅ=new Ŝ();ƅ.ħ=Ƅ;if(ş.CustomName.Contains(Ɔ)){try{string Ƈ=ş.CustomName.Split(Ŵ)[3];
ƅ.ƈ=true;bool Ɖ=false;foreach(ŝ Ɗ in â){if(Ƈ==Ɗ.Ƌ){Ɗ.ƌ.Add(ƅ);Ɖ=true;break;}}if(!Ɖ){ŝ ƍ=new ŝ();ƍ.Ƌ=Ƈ;ƍ.ƌ.Add(ƅ);â.Add(ƍ)
;}}catch{if(l)Echo("Error with airlock door name "+ş.CustomName);à.Add(ƅ);}}else{à.Add(ƅ);}if(J)Ş.Add(ş,"Door");return
false;}var Ǝ=ş as IMyAirVent;if(Ǝ!=null){Ā.Add(Ǝ);if(ş.CustomName.Contains(Ɔ)){try{string Ƈ=ş.CustomName.Split(Ŵ)[3];bool Ɖ=
false;foreach(ŝ Ɗ in â){if(Ƈ==Ɗ.Ƌ){Ɗ.Ə.Add(Ǝ);Ɖ=true;break;}}if(!Ɖ){ŝ ƍ=new ŝ();ƍ.Ƌ=Ƈ;ƍ.Ə.Add(Ǝ);â.Add(ƍ);}}catch{if(l)Echo(
"Error with airlock vent name "+ş.CustomName);}}if(J)Ş.Add(ş,"Vent");return false;}var Ɛ=ş as IMyCameraBlock;if(Ɛ!=null){Č.Add(Ɛ);if(J)Ş.Add(ş,"Camera"
);return false;}var Ƒ=ş as IMyShipConnector;if(Ƒ!=null){Ċ.Add(Ƒ);ŷ(ş);if(J){string ƒ="";if(ţ.Contains("Passageway"))ƒ=Ŵ+
"Passageway";Ş.Add(ş,"Connector"+ƒ);}return false;}var Ɠ=ş as IMyAirtightHangarDoor;if(Ɠ!=null){ō.Add(Ɠ);if(J)Ş.Add(ş,"Door"+Ŵ+
"Hangar");return false;}if(ţ.Contains("sdx_hangar")&&!ţ.Contains("sdx_hangardoor")){var Ɣ=ş as IMyFunctionalBlock;if(Ɣ!=null){ü.
Add(Ɣ);if(J)Ş.Add(ş,"Hangar");return false;}}if(ţ.Contains("sdx_shipcore")){þ.Add(ş);if(J)Ş.Add(ş,"Core");return false;}if(
ţ.Contains("sdx_detectorTargeted_lidar")){var ƕ=ş as IMyConveyorSorter;if(ƕ!=null){Ý.Add(ƕ);if(J)Ş.Add(ş,"LiDAR");return
false;}}var Ɩ=ş as IMyRadioAntenna;if(Ɩ!=null){ø.Add(Ɩ);if(J)Ş.Add(ş,"Antenna");return false;}var Ɨ=ş as IMyProgrammableBlock
;if(Ɨ!=null){if(J)Ş.Add(ş,"PB Server");if(Ɨ==Me)return false;try{if(ş.CustomData.Contains(
"Sigma_Draconis_Expanse_Server "))Œ.Add(Ɨ);else if(ş.CustomData.Contains("NavConfig"))œ.Add(Ɨ);return false;}catch{}}var Ƙ=ş as IMyProjector;if(Ƙ!=null)
{µ.Add(Ƙ);if(J)Ş.Add(ş,"Projector");return false;}var ƙ=ş as IMySensorBlock;if(ƙ!=null){Ď.Add(ƙ);if(J)Ş.Add(ş,"Sensor");
return false;}var ƚ=ş as IMyCollector;if(ƚ!=null){ŷ(ş);if(J)Ş.Add(ş,"Collector");return false;}if(ţ.Contains("Welder")){Ą.Add(
ş);if(J)Ş.Add(ş,"Tool"+Ŵ+"Welder");return false;}if(J){if(ţ.Contains("LandingGear/")){if(ţ.Contains("Clamp"))Ş.Add(ş,
"Clamp");else if(ţ.Contains("Magnetic"))Ş.Add(ş,"Mag Lock");else Ş.Add(ş,"Gear");return false;}if(ţ.Contains("Drill")){Ş.Add(ş,
"Tool"+Ŵ+"Drill");return false;}if(ţ.Contains("Grinder")||ţ.Contains("grinder")){Ş.Add(ş,"Tool"+Ŵ+"Grinder");return false;}if(
ţ.Contains("Solar")){Ş.Add(ş,"Solar");return false;}if(ţ.Contains("ButtonPanel")){Ş.Add(ş,"Button Panel");return false;}
var ƛ=ş as IMyConveyorSorter;if(ƛ!=null){Ş.Add(ş,"Sorter");return false;}var Ɯ=ş as IMyMotorSuspension;if(Ɯ!=null){Ş.Add(ş,
"Suspension");return false;}var Ɲ=ş as IMyGravityGenerator;if(Ɲ!=null){Ş.Add(ş,"Grav Gen");return false;}var ƞ=ş as IMyTimerBlock;if
(ƞ!=null){Ş.Add(ş,"Timer");return false;}var Ɵ=ş as IMyGasGenerator;if(Ɵ!=null){Ş.Add(ş,"H2 Engine");return false;}var Ơ=
ş as IMyBeacon;if(Ơ!=null){Ş.Add(ş,"Beacon");return false;}Ş.Add(ş,ş.DefinitionDisplayNameText);}return false;}catch(
Exception ơ){if(l){Echo("Failed to sort "+ş.CustomName+"\nAdded "+Ş.Count+" so far.");Echo(ơ.Message);}return false;}}void Đ(){Ē=
null;ø.Clear();Ø.Clear();Č.Clear();ú.Clear();Ċ.Clear();ē.Clear();à.Clear();â.Clear();ō.Clear();ü.Clear();þ.Clear();Ŏ.Clear()
;ŏ.Clear();ñ.Clear();ó.Clear();µ.Clear();Ö.Clear();Ď.Clear();é.Clear();õ.Clear();Ā.Clear();Ą.Clear();Ý.Clear();î.Clear();
ï.Clear();Ó.Clear();Ô.Clear();å.Clear();Û.Clear();ì.Clear();Ő.Clear();ő.Clear();Œ.Clear();œ.Clear();Ć.Clear();É.Clear();Ŕ
.Clear();Ŗ.Clear();ŗ.Clear();Ř.Clear();ř.Clear();Ś.Clear();Ă.Clear();foreach(var Ī in ĩ)Ī.į.Clear();if(J)Ş.Clear();}bool
ū(IMyTerminalBlock ş,string Ƣ,int Ů){if(ş.CustomName.Contains(ƣ))ï.Add(ş);else î.Add(ş);ŷ(ş,Ů);if(J){string ű="";if(Ƥ)ű=Ŵ
+Ƣ;Ş.Add(ş,"PDC"+ű);}return false;}bool ŭ(IMyTerminalBlock ş,string Ƣ){å.Add(ş);if(J){string ƥ="";if(Ƥ)ƥ=Ŵ+Ƣ;Ş.Add(ş,
"Torpedo"+ƥ);}return false;}bool ů(IMyTerminalBlock ş,string Ƣ,int Ů,bool Ʀ=false,string Ƨ="Rail"){if(Ʀ)Ô.Add(ş);else Ó.Add(ş);ŷ(
ş,Ů);if(J){string ƥ="";if(Ƨ!="")Ƨ=Ŵ+Ƨ;if(Ƥ)ƥ=Ŵ+Ƣ;Ş.Add(ş,"Kinetic"+Ƨ+ƥ);}return false;}ŕ Ũ(ŕ ƨ,string Ʃ=""){bool ƪ=Ʃ=="",
ƫ=!ƪ;string Ƭ=ƨ.ħ.CustomData,ƭ="RSM.LCD";string[]Ʈ=null;MyIni Ư=new MyIni();MyIniParseResult ư;if(!ƪ||Ƭ=="")ƫ=true;else{
try{if(Ƭ.Substring(0,12)=="Show Header="){Ʈ=Ƭ.Split('\n');foreach(string Ʊ in Ʈ){if(Ʊ.Contains("hud")){if(Ʊ.Contains("lcd")
){Ʃ=Ʊ;break;}}else if(Ʊ.Contains("=")){string[]Ʋ=Ʊ.Split('=');if(Ʋ[0]=="Show Tanks & Batteries")ƨ.Ƴ=bool.Parse(Ʋ[1]);else
if(Ʋ[0]=="Show header"||Ʋ[0]=="Show Header")ƨ.ƴ=bool.Parse(Ʋ[1]);else if(Ʋ[0]=="Show Header Overlay")ƨ.Ƶ=bool.Parse(Ʋ[1]);
else if(Ʋ[0]=="Show Warnings")ƨ.ƶ=bool.Parse(Ʋ[1]);else if(Ʋ[0]=="Show Inventory")ƨ.Ʒ=bool.Parse(Ʋ[1]);else if(Ʋ[0]==
"Show Thrust")ƨ.Ƹ=bool.Parse(Ʋ[1]);else if(Ʋ[0]=="Show Subsystem Integrity")ƨ.ƹ=bool.Parse(Ʋ[1]);else if(Ʋ[0]=="Show Advanced Thrust"
)ƨ.ƺ=bool.Parse(Ʋ[1]);}}}else if(!Ư.TryParse(Ƭ,out ư)){ƫ=true;}else{ƨ.ƴ=Ư.Get(ƭ,"ShowHeader").ToBoolean(ƨ.ƴ);ƨ.Ƶ=Ư.Get(ƭ,
"ShowHeaderOverlay").ToBoolean(ƨ.Ƶ);ƨ.ƶ=Ư.Get(ƭ,"ShowWarnings").ToBoolean(ƨ.ƶ);ƨ.Ƴ=Ư.Get(ƭ,"ShowPowerAndTanks").ToBoolean(ƨ.Ƴ);ƨ.Ʒ=Ư.Get(ƭ,
"ShowInventory").ToBoolean(ƨ.Ʒ);ƨ.Ƹ=Ư.Get(ƭ,"ShowThrust").ToBoolean(ƨ.Ƹ);ƨ.ƹ=Ư.Get(ƭ,"ShowIntegrity").ToBoolean(ƨ.ƹ);ƨ.ƺ=Ư.Get(ƭ,
"ShowAdvancedThrust").ToBoolean(ƨ.ƺ);}}catch(Exception ė){if(l)Echo("LCD parsing error, resetting\n"+ė.Message);ƫ=true;}}if(ƨ.ƴ&&ƨ.Ƶ){ƨ.ƴ=
false;ƫ=true;}if(ƫ){if(Ʈ==null)Ʈ=Ƭ.Split('\n');Ư.Set(ƭ,"ShowHeader",ƨ.ƴ);Ư.Set(ƭ,"ShowHeaderOverlay",ƨ.Ƶ);Ư.Set(ƭ,
"ShowWarnings",ƨ.ƶ);Ư.Set(ƭ,"ShowPowerAndTanks",ƨ.Ƴ);Ư.Set(ƭ,"ShowInventory",ƨ.Ʒ);Ư.Set(ƭ,"ShowThrust",ƨ.Ƹ);Ư.Set(ƭ,"ShowIntegrity",ƨ.
ƹ);Ư.Set(ƭ,"ShowAdvancedThrust",ƨ.ƺ);Ư.Set(ƭ,"Hud",Ʃ);ƨ.ħ.CustomData=Ư.ToString();if(ƪ)Á.Add(new Â("LCD CONFIG ERROR!!",
"Failed to parse LCD config for "+ƨ.ħ.CustomName+"!\nLCD config was reset!",3));}return ƨ;}void ƻ(IMyTerminalBlock ħ,bool Ė){ħ.GetActionWithName(
"ToolCore_Shoot_Action").Apply(ħ);(ħ as IMyConveyorSorter).GetActionWithName("ToolCore_Shoot_Action").Apply(ħ);}void z(){List<IMyTerminalBlock>
Ƽ=new List<IMyTerminalBlock>();GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(Ƽ);string ƽ="";foreach(
IMyTerminalBlock ƾ in Ƽ){ƽ+=ƾ.BlockDefinition+"\n";}if(ø.Count>0&&ø[0]!=null){ø[0].CustomData=ƽ;}}void ª(string Ŭ){IMyTerminalBlock ħ=
GridTerminalSystem.GetBlockWithName(Ŭ);List<ITerminalAction>ƿ=new List<ITerminalAction>();ħ.GetActions(ƿ);List<ITerminalProperty>ǀ=new
List<ITerminalProperty>();ħ.GetProperties(ǀ);string ǁ=ħ.CustomName+"\n**Actions**\n\n";foreach(ITerminalAction ǂ in ƿ){ǁ+=ǂ.
Id+" "+ǂ.Name+"\n";}ǁ+="\n\n**Properties**\n\n";foreach(ITerminalProperty ǃ in ǀ){ǁ+=ǃ.Id+" "+ǃ.TypeName+"\n";}if(ø.Count>
0&&ø[0]!=null)ø[0].CustomData=ǁ;ħ.CustomData=ǁ;}void ǆ(IMyTerminalBlock Ǆ){bool ǅ=Ǆ.GetValue<bool>("WC_Repel");if(!ǅ)Ǆ.
ApplyAction("WC_RepelMode");}void Ǉ(IMyTerminalBlock Ǆ){bool ǅ=Ǆ.GetValue<bool>("WC_Repel");if(ǅ)Ǆ.ApplyAction("WC_RepelMode");}
void ǉ(IMyTerminalBlock Ǆ){try{if(Ĕ.ǈ(Ǆ,0)==VRageMath.Matrix.Zero)return;Ǆ.SetValue<Int64>("WC_Shoot Mode",3);if(l)Echo(
"Shoot mode = "+Ǆ.GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to manual on "+Ǆ.CustomName);}}void Ǌ(
IMyTerminalBlock Ǆ){try{if(Ĕ.ǈ(Ǆ,0)==VRageMath.Matrix.Zero)return;Ǆ.SetValue<Int64>("WC_Shoot Mode",0);if(l)Echo("Shoot mode = "+Ǆ.
GetValue<Int64>("WC_Shoot Mode"));}catch{Echo("Failed to set fire mode to auto on "+Ǆ.CustomName);}}void ǌ(){if(Ē!=null){try{R=Ē
.GetShipSpeed();S=Ē.CalculateShipMass().PhysicalMass;}catch(Exception ǋ){Echo("Failed to get velocity or mass!");Echo(ǋ.
Message);}}}double Ǎ=0;double ǎ=0;double Ǐ=0;void û(){ǎ=0;foreach(IMyCargoContainer ǐ in ú){if(ǐ!=null&&!ǐ.Closed&&ǐ.
IsFunctional){try{ǎ+=ǐ.GetInventory().MaxVolume.RawValue;}catch(Exception ė){if(l)Echo("Cargo integrity error!\n"+ė.Message);throw ė
;}}}Ǐ=Math.Round(100*(ǎ/Ǎ));}void Ǒ(){Ǎ=0;foreach(IMyCargoContainer ǐ in ú){if(ǐ!=null)Ǎ+=ǐ.GetInventory().MaxVolume.
RawValue;}}MyIni ǒ=new MyIni();bool Ţ=false;bool Ĩ=true;bool Ǔ=true;bool ǔ=true;bool Ǖ=true;bool ǖ=false;string Ǘ="";bool ǘ=true
;int Ǚ=3;int ǚ=6;string š="[I]";string Ŧ="[RSM]";string Ū="[CS]";string Ť="Autorepair";string ƣ="Repel";string Ǜ="Min";
string ǜ="Docking";string ſ="Nav";string Ɔ="Airlock";string ǝ="[EFC]";string Ǟ="[NavOS]";char Ŵ='.';bool Ƥ=true;bool Ų=true;
List<string>ǟ=new List<string>();bool Ǡ=false;bool ũ=false;bool ǡ=true;List<double>f=new List<double>();bool Ǣ=false;double
ǣ=0.5;bool l=false;bool Å=false;int Æ=0;int d=100;string ę="";bool Ʉ(){string Ƭ=Me.CustomData;string ƭ="";bool Ǥ=true;
MyIniParseResult ư;if(!ǒ.TryParse(Ƭ,out ư)){string[]ǥ=Ƭ.Split('\n');if(ǥ[1]=="Reedit Ship Management"){Echo("Legacy config detected...")
;Ǧ(Ƭ);return false;}else{Echo("Could not parse custom data!\n"+ư.ToString());return false;}}try{ƭ="RSM.Main";Echo(ƭ);Ţ=ǒ.
Get(ƭ,"RequireShipName").ToBoolean(Ţ);Ĩ=ǒ.Get(ƭ,"EnableAutoload").ToBoolean(Ĩ);Ǔ=ǒ.Get(ƭ,"AutoloadReactors").ToBoolean(Ǔ);ǔ
=ǒ.Get(ƭ,"AutoConfigWeapons").ToBoolean(ǔ);Ǖ=ǒ.Get(ƭ,"SetTurretFireMode").ToBoolean(Ǖ);ƭ="RSM.Spawns";Echo(ƭ);ǖ=ǒ.Get(ƭ,
"PrivateSpawns").ToBoolean(ǖ);Ǘ=ǒ.Get(ƭ,"FriendlyTags").ToString(Ǘ);ƭ="RSM.Doors";Echo(ƭ);ǘ=ǒ.Get(ƭ,"EnableDoorManagement").ToBoolean(ǘ
);Ǚ=ǒ.Get(ƭ,"DoorCloseTimer").ToInt32(Ǚ);Ǚ=ǒ.Get(ƭ,"AirlockDoorDisableTimer").ToInt32(Ǚ);ƭ="RSM.Keywords";Echo(ƭ);š=ǒ.Get
(ƭ,"Ignore").ToString(š);Ŧ=ǒ.Get(ƭ,"RsmLcds").ToString(Ŧ);Ū=ǒ.Get(ƭ,"ColourSyncLcds").ToString(Ū);Ť=ǒ.Get(ƭ,
"AuxiliaryBlocks").ToString(Ť);ƣ=ǒ.Get(ƭ,"DefensivePdcs").ToString(ƣ);Ǜ=ǒ.Get(ƭ,"MinimumThrusters").ToString(Ǜ);ǜ=ǒ.Get(ƭ,
"DockingThrusters").ToString(ǜ);ſ=ǒ.Get(ƭ,"NavLights").ToString(ſ);Ɔ=ǒ.Get(ƭ,"Airlock").ToString(Ɔ);ƭ="RSM.InitNaming";Echo(ƭ);string ǧ=ǒ.
Get(ƭ,"NameDelimiter").ToString(Ŵ.ToString());int Ǩ=0;if(ǧ.Length>1)Ǩ=1;Ŵ=char.Parse(ǧ.Substring(Ǩ,1));Ƥ=ǒ.Get(ƭ,
"NameWeaponTypes").ToBoolean(Ƥ);Ų=ǒ.Get(ƭ,"NameDriveTypes").ToBoolean(Ų);string ǩ=ǒ.Get(ƭ,"BlocksToNumber").ToString("");string[]Ǫ=ǩ.
Split(',');ǟ.Clear();foreach(string Ŭ in Ǫ)if(Ŭ!="")ǟ.Add(Ŭ);ƭ="RSM.Misc";Echo(ƭ);Ǡ=ǒ.Get(ƭ,"DisableLightingControl").
ToBoolean(Ǡ);ũ=ǒ.Get(ƭ,"DisableLcdColourControl").ToBoolean(ũ);ǡ=ǒ.Get(ƭ,"ShowBasicTelemetry").ToBoolean(ǡ);string ǫ=ǒ.Get(ƭ,
"DecelerationPercentages").ToString("");string[]Ǭ=ǫ.Split(',');if(Ǭ.Length>1){f.Clear();foreach(string ǭ in Ǭ){f.Add(double.Parse(ǭ)/100);}}Ǣ=ǒ.
Get(ƭ,"ShowThrustInMetric").ToBoolean(Ǣ);ǣ=ǒ.Get(ƭ,"ReactorFillRatio").ToDouble(ǣ);ĩ[0].Ļ=ǣ;ƭ="RSM.Debug";Echo(ƭ);l=ǒ.Get(ƭ
,"VerboseDebugging").ToBoolean(l);Å=ǒ.Get(ƭ,"RuntimeProfiling").ToBoolean(Å);d=ǒ.Get(ƭ,"BlockRefreshFreq").ToInt32(d);Æ=ǒ
.Get(ƭ,"StallCount").ToInt32(Æ);ƭ="RSM.System";Echo(ƭ);ę=ǒ.Get(ƭ,"ShipName").ToString(ę);ƭ="RSM.InitItems";Echo(ƭ);
foreach(Ī Ǯ in ĩ){Ǯ.ǯ=ǒ.Get(ƭ,Ǯ.ń.SubtypeId).ToInt32(Ǯ.ǯ);}ƭ="RSM.InitSubSystems";Echo(ƭ);ǰ=ǒ.Get(ƭ,"Reactors").ToDouble(ǰ);Ǳ=ǒ
.Get(ƭ,"Batteries").ToDouble(Ǳ);ǲ=ǒ.Get(ƭ,"BatteryStorage").ToDouble(ǲ);ǳ=ǒ.Get(ƭ,"Pdcs").ToInt32(ǳ);Ǵ=ǒ.Get(ƭ,
"TorpLaunchers").ToInt32(Ǵ);ǵ=ǒ.Get(ƭ,"KineticWeapons").ToInt32(ǵ);Ƕ=ǒ.Get(ƭ,"H2Storage").ToDouble(Ƕ);Ƿ=ǒ.Get(ƭ,"O2Storage").ToDouble(Ƿ
);Ǹ=ǒ.Get(ƭ,"MainThrust").ToSingle(Ǹ);ǹ=ǒ.Get(ƭ,"RCSThrust").ToSingle(ǹ);Ǻ=ǒ.Get(ƭ,"Gyros").ToDouble(Ǻ);Ǎ=ǒ.Get(ƭ,
"CargoStorage").ToDouble(Ǎ);ǻ=ǒ.Get(ƭ,"Welders").ToInt32(ǻ);}catch(Exception ė){Ǽ(ė,"Failed to parse section\n"+ƭ);}Echo(
"Parsing stances...");Dictionary<string,ǽ>Ǿ=new Dictionary<string,ǽ>();bool ǿ=false;List<string>Ȁ=new List<string>();ǒ.GetSections(Ȁ);
foreach(string ȁ in Ȁ){if(ȁ.Contains("RSM.Stance.")){string Ȃ=ȁ.Substring(11);Echo(Ȃ);ǽ ȃ=new ǽ();string Ȅ,ȅ="";string[]Ȇ;int ȇ
=33,Ȉ=144,ş=255,ł=255;bool ȉ=false;ǽ Ȋ=null;ȅ="Inherits";if(ǒ.ContainsKey(ȁ,ȅ)){ȉ=true;try{Ȋ=Ǿ[ǒ.Get(ȁ,ȅ).ToString()];
Echo("Inherits "+ǒ.Get(ȁ,ȅ).ToString());}catch(Exception ė){Ǽ(ė,"Failed to find inheritee for\n"+ȁ+
"\nEnsure inheritee stances are\nlisted before their heirs");}}try{if(ȉ)Echo(Ȋ.ȋ.ToString());ȅ="Torps";if(ǒ.ContainsKey(ȁ,ȅ)){ȃ.ȋ=(Ȍ)Enum.Parse(typeof(Ȍ),ǒ.Get(ȁ,ȅ).ToString());}
else if(ȉ){ȃ.ȋ=Ȋ.ȋ;}else{ȃ.ȋ=ȍ;}ȅ="Pdcs";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ȏ=(ȏ)Enum.Parse(typeof(ȏ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)
ȃ.Ȏ=Ȋ.Ȏ;else ȃ.Ȏ=Ȑ;ȅ="Kinetics";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.ȑ=(Ȓ)Enum.Parse(typeof(Ȓ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.ȑ=Ȋ.
ȑ;else ȃ.ȑ=ȓ;ȅ="MainThrust";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ȕ=(ȕ)Enum.Parse(typeof(ȕ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Ȕ=Ȋ.Ȕ;
else ȃ.Ȕ=Ȗ;ȅ="ManeuveringThrust";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.ȗ=(Ș)Enum.Parse(typeof(Ș),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.ȗ=Ȋ.ȗ;
else ȃ.ȗ=ș;ȅ="Spotlights";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ț=(ț)Enum.Parse(typeof(ț),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Ț=Ȋ.Ț;else ȃ.
Ț=Ȝ;ȅ="ExteriorLights";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.ȝ=(Ȟ)Enum.Parse(typeof(Ȟ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.ȝ=Ȋ.ȝ;else ȃ.
ȝ=ȟ;ȅ="ExteriorLightColour";if(ǒ.ContainsKey(ȁ,ȅ)){Ȅ=ǒ.Get(ȁ,ȅ).ToString();Ȇ=Ȅ.Split(',');ȇ=int.Parse(Ȇ[0]);Ȉ=int.Parse(Ȇ
[1]);ş=int.Parse(Ȇ[2]);ł=int.Parse(Ȇ[3]);ȃ.Ƞ=new Color(ȇ,Ȉ,ş,ł);}else if(ȉ)ȃ.Ƞ=Ȋ.Ƞ;else ȃ.Ƞ=ȡ;ȅ="InteriorLights";if(ǒ.
ContainsKey(ȁ,ȅ))ȃ.Ȣ=(Ȟ)Enum.Parse(typeof(Ȟ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Ȣ=Ȋ.Ȣ;else ȃ.Ȣ=ȣ;ȅ="InteriorLightColour";if(ǒ.
ContainsKey(ȁ,ȅ)){Ȅ=ǒ.Get(ȁ,ȅ).ToString();Ȇ=Ȅ.Split(',');ȇ=int.Parse(Ȇ[0]);Ȉ=int.Parse(Ȇ[1]);ş=int.Parse(Ȇ[2]);ł=int.Parse(Ȇ[3]);ȃ.
Ȥ=new Color(ȇ,Ȉ,ş,ł);}else if(ȉ)ȃ.Ȥ=Ȋ.Ȥ;else ȃ.Ȥ=ȥ;ȅ="NavLights";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ȧ=(Ȟ)Enum.Parse(typeof(Ȟ),ǒ.Get(
ȁ,ȅ).ToString());else if(ȉ)ȃ.Ȧ=Ȋ.Ȧ;else ȃ.Ȧ=ȧ;ȅ="LcdTextColour";if(ǒ.ContainsKey(ȁ,ȅ)){Ȅ=ǒ.Get(ȁ,ȅ).ToString();Ȇ=Ȅ.Split(
',');ȇ=int.Parse(Ȇ[0]);Ȉ=int.Parse(Ȇ[1]);ş=int.Parse(Ȇ[2]);ł=int.Parse(Ȇ[3]);ȃ.Ȩ=new Color(ȇ,Ȉ,ş,ł);}else if(ȉ)ȃ.Ȩ=Ȋ.Ȩ;else
ȃ.Ȩ=ȩ;ȅ="TanksAndBatteries";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ú=(Ȫ)Enum.Parse(typeof(Ȫ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Ú=Ȋ.Ú;
else ȃ.Ú=ȫ;ȅ="NavOsEfcBurnPercentage";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ȭ=ǒ.Get(ȁ,"NavOsEfcBurnPercentage").ToInt32(ȭ);else if(ȉ)ȃ.Ȭ=Ȋ
.Ȭ;else ȃ.Ȭ=ȭ;ȅ="EfcBoost";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ȯ=(Î)Enum.Parse(typeof(Î),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Ȯ=Ȋ.Ȯ;
else ȃ.Ȯ=ȯ;ȅ="NavOsAbortEfcOff";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ȱ=(ȱ)Enum.Parse(typeof(ȱ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Ȱ=Ȋ.Ȱ;
else ȃ.Ȱ=Ȳ;ȅ="NavOsAbortEfcOff";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Ȱ=(ȱ)Enum.Parse(typeof(ȱ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Ȱ=Ȋ.Ȱ;
else ȃ.Ȱ=Ȳ;ȅ="AuxMode";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.ȳ=(Î)Enum.Parse(typeof(Î),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.ȳ=Ȋ.ȳ;else ȃ.ȳ=ȴ
;ȅ="Extractor";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.ȵ=(ȶ)Enum.Parse(typeof(ȶ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.ȵ=Ȋ.ȵ;else ȃ.ȵ=ȷ;ȅ=
"KeepAlives";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.Í=(Î)Enum.Parse(typeof(Î),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.Í=Ȋ.Í;else ȃ.Í=ȸ;ȅ="HangarDoors";
if(ǒ.ContainsKey(ȁ,ȅ))ȃ.ȹ=(Ⱥ)Enum.Parse(typeof(Ⱥ),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.ȹ=Ȋ.ȹ;else ȃ.ȹ=Ȼ;ȅ="Hangars";if(ǒ.
ContainsKey(ȁ,ȅ))ȃ.ȼ=(Î)Enum.Parse(typeof(Î),ǒ.Get(ȁ,ȅ).ToString());else if(ȉ)ȃ.ȼ=Ȋ.ȼ;else{ȃ.ȼ=Ƚ;ǒ.Set(ȁ,ȅ,ȃ.ȼ.ToString());ǒ.
SetComment(ȁ,ȅ,Ⱦ(typeof(Î)));ǿ=true;}ȅ="RcsGyroscopes";if(ǒ.ContainsKey(ȁ,ȅ))ȃ.ȿ=(ɀ)Enum.Parse(typeof(ɀ),ǒ.Get(ȁ,ȅ).ToString());
else if(ȉ)ȃ.ȿ=Ȋ.ȿ;else{ȃ.ȿ=Ɂ;ǒ.Set(ȁ,ȅ,ȃ.ȿ.ToString());ǒ.SetComment(ȁ,ȅ,Ⱦ(typeof(ɀ)));ǿ=true;}Ǿ.Add(Ȃ,ȃ);}catch(Exception ė)
{Ǽ(ė,"Failed to parse stance\n"+Ȃ+"\nproperty\n"+ȅ);}}}if(Ǿ.Count<1){Echo(
"Failed to parse any stances!\nStances reset to default!");Ǥ=false;}else{Echo("Finished parsing "+Ǿ.Count+" stances.");ɂ=Ǿ;}ƭ="RSM.Stance";Echo(ƭ);Ě=ǒ.Get(ƭ,"CurrentStance").
ToString(Ě);ǽ Ƀ;if(!ɂ.TryGetValue(Ě,out Ƀ)){Ě="N/A";Ì=null;}else Ì=Ƀ;if(Ǥ&&ǿ){Echo("Added new settings to custom data.");Me.
CustomData=ǒ.ToString();}return Ǥ;}void ɏ(){ǒ.Clear();string ƭ,Ŭ;ƭ="RSM.Main";Ŭ="RequireShipName";ǒ.Set(ƭ,Ŭ,Ţ);ǒ.SetComment(ƭ,Ŭ,
"limit to blocks with the ship name in their name");Ŭ="EnableAutoload";ǒ.Set(ƭ,Ŭ,Ĩ);ǒ.SetComment(ƭ,Ŭ,"enable RSM loading & balancing functionality for weapons");Ŭ=
"AutoloadReactors";ǒ.Set(ƭ,Ŭ,Ǔ);ǒ.SetComment(ƭ,Ŭ,"enable loading and balancing for reactors");Ŭ="AutoConfigWeapons";ǒ.Set(ƭ,Ŭ,ǔ);ǒ.
SetComment(ƭ,Ŭ,"automatically configure weapon on stance set");Ŭ="SetTurretFireMode";ǒ.Set(ƭ,Ŭ,Ǖ);ǒ.SetComment(ƭ,Ŭ,
"set turret fire mode based on stance");ǒ.SetSectionComment(ƭ,Ʌ+" Reedit Ship Management\n"+Ʌ+" Config.ini\n Recompile to apply changes!\n"+Ʌ);ƭ="RSM.Spawns";
Ŭ="PrivateSpawns";ǒ.Set(ƭ,Ŭ,ǖ);ǒ.SetComment(ƭ,Ŭ,"don't inject faction tag into spawn custom data");Ŭ="FriendlyTags";ǒ.Set
(ƭ,Ŭ,Ǘ);ǒ.SetComment(ƭ,Ŭ,"Comma seperated friendly factions or steam ids");ƭ="RSM.Doors";Ŭ="EnableDoorManagement";ǒ.Set(ƭ
,Ŭ,ǘ);ǒ.SetComment(ƭ,Ŭ,"enable door management functionality");Ŭ="DoorCloseTimer";ǒ.Set(ƭ,Ŭ,Ǚ);ǒ.SetComment(ƭ,Ŭ,
"door open timer (x100 ticks)");Ŭ="AirlockDoorDisableTimer";ǒ.Set(ƭ,Ŭ,ǚ);ǒ.SetComment(ƭ,Ŭ,"airlock door disable timer (x100 ticks)");ƭ="RSM.Keywords";
Ŭ="Ignore";ǒ.Set(ƭ,Ŭ,š);ǒ.SetComment(ƭ,Ŭ,"to identify blocks which RSM should ignore");Ŭ="RsmLcds";ǒ.Set(ƭ,Ŭ,Ŧ);ǒ.
SetComment(ƭ,Ŭ,"to identify RSM lcds");Ŭ="ColourSyncLcds";ǒ.Set(ƭ,Ŭ,Ū);ǒ.SetComment(ƭ,Ŭ,"to identify non RSM lcds for colour sync"
);Ŭ="AuxiliaryBlocks";ǒ.Set(ƭ,Ŭ,Ť);ǒ.SetComment(ƭ,Ŭ,"to identify aux blocks");Ŭ="DefensivePdcs";ǒ.Set(ƭ,Ŭ,ƣ);ǒ.SetComment
(ƭ,Ŭ,"to identify defensive _normalPdcs");Ŭ="MinimumThrusters";ǒ.Set(ƭ,Ŭ,Ǜ);ǒ.SetComment(ƭ,Ŭ,
"to identify minimum epsteins");Ŭ="DockingThrusters";ǒ.Set(ƭ,Ŭ,ǜ);ǒ.SetComment(ƭ,Ŭ,"to identify docking epsteins");Ŭ="NavLights";ǒ.Set(ƭ,Ŭ,ſ);ǒ.
SetComment(ƭ,Ŭ,"to identify navigational lights");Ŭ="Airlock";ǒ.Set(ƭ,Ŭ,Ɔ);ǒ.SetComment(ƭ,Ŭ,"to identify airlock doors and vents")
;ƭ="RSM.InitNaming";Ŭ="NameDelimiter";ǒ.Set(ƭ,Ŭ,'"'+Ŵ.ToString()+'"');ǒ.SetComment(ƭ,Ŭ,"single char delimiter for names")
;Ŭ="NameWeaponTypes";ǒ.Set(ƭ,Ŭ,Ƥ);ǒ.SetComment(ƭ,Ŭ,"append type names to all weapons on init");Ŭ="NameDriveTypes";ǒ.Set(ƭ
,Ŭ,Ų);ǒ.SetComment(ƭ,Ŭ,"append type names to all drives on init");string Ɇ="";foreach(string ɇ in ǟ){if(Ɇ!="")Ɇ+=",";Ɇ+=ɇ
;}Ŭ="BlocksToNumber";ǒ.Set(ƭ,Ŭ,Ų);ǒ.SetComment(ƭ,Ŭ,"comma seperated list of block names to be numbered at init");ƭ=
"RSM.Misc";Ŭ="DisableLightingControl";ǒ.Set(ƭ,Ŭ,Ǡ);ǒ.SetComment(ƭ,Ŭ,"disable all lighting control");Ŭ="DisableLcdColourControl";ǒ.
Set(ƭ,Ŭ,ũ);ǒ.SetComment(ƭ,Ŭ,"disable text colour control for all lcds");Ŭ="ShowBasicTelemetry";ǒ.Set(ƭ,Ŭ,ǡ);ǒ.SetComment(ƭ,
Ŭ,"show basic telemetry data on advanced thrust lcds");string Ɉ="";foreach(double ɉ in f){if(Ɉ!="")Ɉ+=",";Ɉ+=(ɉ*100).
ToString();}Ŭ="DecelerationPercentages";ǒ.Set(ƭ,Ŭ,Ɉ);ǒ.SetComment(ƭ,Ŭ,"thrust percentages to show on advanced thrust lcds");Ŭ=
"ShowThrustInMetric";ǒ.Set(ƭ,Ŭ,Ǣ);ǒ.SetComment(ƭ,Ŭ,"show basic telemetry data on advanced thrust lcds");Ŭ="ReactorFillRatio";ǒ.Set(ƭ,Ŭ,ǣ);ǒ.
SetComment(ƭ,Ŭ,"0-1, fill ratio for reactors");ƭ="RSM.Debug";Ŭ="VerboseDebugging";ǒ.Set(ƭ,Ŭ,l);ǒ.SetComment(ƭ,Ŭ,
"prints more logging info to PB details");Ŭ="RuntimeProfiling";ǒ.Set(ƭ,Ŭ,Å);ǒ.SetComment(ƭ,Ŭ,"prints script runtime profiling info to PB details");Ŭ=
"BlockRefreshFreq";ǒ.Set(ƭ,Ŭ,d);ǒ.SetComment(ƭ,Ŭ,"ticks x100 between block refreshes");Ŭ="StallCount";ǒ.Set(ƭ,Ŭ,Æ);ǒ.SetComment(ƭ,Ŭ,
"ticks x100 to stall between runs");ƭ="RSM.Stance";Ŭ="CurrentStance";ǒ.Set(ƭ,Ŭ,Ě);ǒ.SetSectionComment(ƭ,Ʌ+" Stances\n Add or remove as required\n"+Ʌ);
string Ɋ="Red, Green, Blue, Alpha";foreach(var ɋ in ɂ){ƭ="RSM.Stance."+ɋ.Key;ǽ Ɍ=ɋ.Value;ǽ Ȋ=null;if(Ɍ.ɍ!=""){Ȋ=ɂ[Ɍ.ɍ];Ŭ=
"Inherits";ǒ.Set(ƭ,Ŭ,Ɍ.ɍ);ǒ.SetComment(ƭ,Ŭ,"Use stance of this name as a template for settings");}Ŭ="Torps";if(Ȋ!=null&&Ɍ.ȋ==Ȋ.ȋ){
if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.ȋ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Ȍ)));}Ŭ="Pdcs";if(Ȋ!=null&&Ɍ
.Ȏ==Ȋ.Ȏ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ȏ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(ȏ)));}Ŭ="Kinetics"
;if(Ȋ!=null&&Ɍ.ȑ==Ȋ.ȑ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.ȑ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Ȓ)))
;}Ŭ="MainThrust";if(Ȋ!=null&&Ɍ.Ȕ==Ȋ.Ȕ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ȕ.ToString());ǒ.SetComment(ƭ
,"MainThrust",Ⱦ(typeof(ȕ)));}Ŭ="ManeuveringThrust";if(Ȋ!=null&&Ɍ.ȗ==Ȋ.ȗ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(
ƭ,Ŭ,Ɍ.ȗ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Ș)));}Ŭ="Spotlights";if(Ȋ!=null&&Ɍ.Ț==Ȋ.Ț){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ
,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ț.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(ț)));}Ŭ="ExteriorLights";if(Ȋ!=null&&Ɍ.ȝ==Ȋ.ȝ){if(ǒ.
ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.ȝ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Ȟ)));}Ŭ="ExteriorLightColour";if(Ȋ!=null&&
Ɍ.Ƞ==Ȋ.Ƞ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɏ(Ɍ.Ƞ));ǒ.SetComment(ƭ,Ŭ,Ɋ);}Ŭ="InteriorLights";if(Ȋ!=null
&&Ɍ.Ȣ==Ȋ.Ȣ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ȣ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Ȟ)));}Ŭ=
"InteriorLightColour";if(Ȋ!=null&&Ɍ.Ȥ==Ȋ.Ȥ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɏ(Ɍ.Ȥ));ǒ.SetComment(ƭ,Ŭ,Ɋ);}Ŭ="NavLights";if
(Ȋ!=null&&Ɍ.Ȧ==Ȋ.Ȧ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ȧ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Ȟ)));}Ŭ
="LcdTextColour";if(Ȋ!=null&&Ɍ.Ȩ==Ȋ.Ȩ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɏ(Ɍ.Ȩ));ǒ.SetComment(ƭ,Ŭ,Ɋ);}Ŭ
="TanksAndBatteries";if(Ȋ!=null&&Ɍ.Ú==Ȋ.Ú){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ú.ToString());ǒ.
SetComment(ƭ,Ŭ,Ⱦ(typeof(Ȫ)));}Ŭ="NavOsEfcBurnPercentage";if(Ȋ!=null&&Ɍ.Ȭ==Ȋ.Ȭ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ
,Ɍ.Ȭ.ToString());ǒ.SetComment(ƭ,Ŭ,"Burn % 0-100, -1 for no change");}Ŭ="EfcBoost";if(Ȋ!=null&&Ɍ.Ȯ==Ȋ.Ȯ){if(ǒ.ContainsKey(
ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ȯ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Î)));}Ŭ="NavOsAbortEfcOff";if(Ȋ!=null&&Ɍ.Ȱ==
Ȋ.Ȱ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Ȱ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(ȱ)));}Ŭ="AuxMode";if(Ȋ
!=null&&Ɍ.ȳ==Ȋ.ȳ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.ȳ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Î)));}Ŭ=
"Extractor";if(Ȋ!=null&&Ɍ.ȵ==Ȋ.ȵ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.ȵ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(ȶ))
);}Ŭ="KeepAlives";if(Ȋ!=null&&Ɍ.Í==Ȋ.Í){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.Í.ToString());ǒ.SetComment(
ƭ,Ŭ,Ⱦ(typeof(Î)));}Ŭ="HangarDoors";if(Ȋ!=null&&Ɍ.ȹ==Ȋ.ȹ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.ȹ.ToString
());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Ⱥ)));}Ŭ="Hangars";if(Ȋ!=null&&Ɍ.ȼ==Ȋ.ȼ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ,Ŭ);}else{ǒ.Set(ƭ,Ŭ
,Ɍ.ȼ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(Î)));}Ŭ="RcsGyroscopes";if(Ȋ!=null&&Ɍ.ȿ==Ȋ.ȿ){if(ǒ.ContainsKey(ƭ,Ŭ))ǒ.Delete(ƭ
,Ŭ);}else{ǒ.Set(ƭ,Ŭ,Ɍ.ȿ.ToString());ǒ.SetComment(ƭ,Ŭ,Ⱦ(typeof(ɀ)));}}ƭ="RSM.System";Ŭ="ShipName";ǒ.Set(ƭ,Ŭ,ę);ǒ.
SetSectionComment(ƭ,Ʌ+" System\n All items below this point are\n set automatically when running init\n"+Ʌ);ƭ="RSM.InitItems";foreach(Ī Ǯ
in ĩ){Ŭ=Ǯ.ń.SubtypeId;ǒ.Set(ƭ,Ŭ,Ǯ.ǯ);}ƭ="RSM.InitSubSystems";ǒ.Set(ƭ,"Reactors",ǰ);ǒ.Set(ƭ,"Batteries",Ǳ);ǒ.Set(ƭ,
"BatteryStorage",ǲ);ǒ.Set(ƭ,"Pdcs",ǳ);ǒ.Set(ƭ,"TorpLaunchers",Ǵ);ǒ.Set(ƭ,"KineticWeapons",ǵ);ǒ.Set(ƭ,"H2Storage",Ƕ);ǒ.Set(ƭ,"O2Storage",
Ƿ);ǒ.Set(ƭ,"MainThrust",Ǹ);ǒ.Set(ƭ,"RCSThrust",ǹ);ǒ.Set(ƭ,"Gyros",Ǻ);ǒ.Set(ƭ,"CargoStorage",Ǎ);ǒ.Set(ƭ,"Welders",ǻ);Me.
CustomData=ǒ.ToString();}void Ǧ(string Ƭ){string[]Ȁ=Ƭ.Split(new string[]{"[Stances]"},StringSplitOptions.None);string[]ɐ=Ȁ[0].
Split('\n');string ɑ=Ȁ[1];try{for(int ɒ=1;ɒ<ɐ.Length;ɒ++){if(ɐ[ɒ].Contains("=")){string ɓ=ɐ[ɒ].Substring(1);switch(ɐ[(ɒ-1)]){
case"Ship name. Blocks without this name will be ignored":ę=ɓ;break;case
"Block name delimiter, used by init. One character only!":Ŵ=char.Parse(ɓ.Substring(0,1));break;case"Keyword used to identify RSM _allLcds.":Ŧ=ɓ;break;case
"Keyword used to identify autorepair systems":case"Keyword used to identify auxiliary blocks":Ť=ɓ;break;case"Keyword used to identify defence _normalPdcs.":ƣ=ɓ;break
;case"Keyword used to identify minimum epstein drives.":Ǜ=ɓ;break;case"Keyword used to identify docking epstein drives.":
ǜ=ɓ;break;case"Keyword to ignore block.":š=ɓ;break;case"Automatically configure _normalPdcs, Railguns, Torpedoes.":ǔ=bool
.Parse(ɓ);break;case"Disable lighting all control.":Ǡ=bool.Parse(ɓ);break;case"Disable LCD Text Colour Enforcement.":ũ=
bool.Parse(ɓ);break;case"Enable Weapon Autoload Functionality.":Ĩ=bool.Parse(ɓ);break;case"Number these blocks at init.":ǟ.
Clear();string[]ɔ=ɓ.Split(',');foreach(string ɇ in ɔ){if(ɇ!="")ǟ.Add(ɇ);}break;case"Show basic telemetry.":ǡ=bool.Parse(ɓ);
break;case"Show Decel Percentages (comma seperated).":f.Clear();string[]ɕ=ɓ.Split(',');foreach(string ɉ in ɕ){f.Add(double.
Parse(ɉ)/100);}break;case"Fusion Fuel count":ĩ[0].ǯ=int.Parse(ɓ);break;case"40mm PDC Magazine count":ĩ[3].ǯ=int.Parse(ɓ);
break;case"40mm Teflon Tungsten PDC Magazine count":ĩ[4].ǯ=int.Parse(ɓ);break;case"220mm Torpedo count":case"Torpedo count":ĩ
[5].ǯ=int.Parse(ɓ);break;case"220mm MCRN torpedo count":ĩ[6].ǯ=int.Parse(ɓ);break;case"220mm UNN torpedo count":ĩ[7].ǯ=
int.Parse(ɓ);break;case"Ramshackle torpedo count":case"Ramshackle torpedo Count":ĩ[8].ǯ=int.Parse(ɓ);break;case
"Large ramshacke torpedo count":ĩ[9].ǯ=int.Parse(ɓ);break;case"Zako 120mm Railgun rounds count":case"Railgun rounds count":ĩ[10].ǯ=int.Parse(ɓ);break;
case"Dawson 100mm UNN Railgun rounds count":ĩ[11].ǯ=int.Parse(ɓ);break;case"Stiletto 100mm MCRN Railgun rounds count":ĩ[12].
ǯ=int.Parse(ɓ);break;case"T-47 80mm Railgun rounds count":ĩ[13].ǯ=int.Parse(ɓ);break;case
"Foehammer 120mm MCRN rounds count":ĩ[14].ǯ=int.Parse(ɓ);break;case"Farren 120mm UNN Railgun rounds count":ĩ[15].ǯ=int.Parse(ɓ);break;case
"Kess 180mm rounds count":ĩ[16].ǯ=int.Parse(ɓ);break;case"Steel plate count":ĩ[17].ǯ=int.Parse(ɓ);break;case
"Doors open timer (x100 ticks, default 3)":Ǚ=int.Parse(ɓ);break;case"Airlock doors disabled timer (x100 ticks, default 6)":ǚ=int.Parse(ɓ);break;case
"Throttle script (x100 ticks pause between loops, default 0)":Æ=int.Parse(ɓ);break;case"Full refresh frequency (x100 ticks, default 50)":d=int.Parse(ɓ);break;case
"Verbose script debugging. Prints more logging info to PB details.":l=bool.Parse(ɓ);break;case"Private spawn (don't inject faction tag into SK custom data).":ǖ=bool.Parse(ɓ);break;case
"Comma seperated friendly factions or steam ids for survival kits.":Ǘ=string.Join("\n",ɓ.Split(','));break;case"Current Stance":Ě=ɓ;ǽ Ƀ;if(!ɂ.TryGetValue(Ě,out Ƀ)){Ě="N/A";Ì=null;}else Ì=
Ƀ;break;case"Reactor Integrity":ǰ=float.Parse(ɓ);break;case"Battery Integrity":Ǳ=float.Parse(ɓ);break;case"PDC Integrity"
:ǳ=int.Parse(ɓ);break;case"Torpedo Integrity":Ǵ=int.Parse(ɓ);break;case"Railgun Integrity":ǵ=int.Parse(ɓ);break;case
"H2 Tank Integrity":Ƕ=double.Parse(ɓ);break;case"O2 Tank Integrity":Ƿ=double.Parse(ɓ);break;case"Epstein Integrity":Ǹ=float.Parse(ɓ);break;
case"RCS Integrity":ǹ=float.Parse(ɓ);break;case"Gyro Integrity":Ǻ=int.Parse(ɓ);break;case"Cargo Integrity":Ǎ=double.Parse(ɓ)
;break;case"Welder Integrity":ǻ=int.Parse(ɓ);break;}}}}catch(Exception ė){Echo("Custom Data Error (vars)\n"+ė.Message);}
try{string[]ɖ=ɑ.Split(new string[]{"Stance:"},StringSplitOptions.None);if(l)Echo("Parsing "+(ɖ.Length-1)+" stances");int ɗ=
24;Dictionary<string,ǽ>Ǿ=new Dictionary<string,ǽ>();int[]ɘ=new int[]{0,5,25,50,75,100};for(int ɒ=1;ɒ<ɖ.Length;ɒ++){string[
]ə=ɖ[ɒ].Split('=');string Ȃ="";int[]ɚ=new int[ɗ];Ȃ=ə[0].Split(' ')[0];if(l)Echo("Parsing '"+Ȃ+"'");for(int ɛ=0;ɛ<ɚ.Length
;ɛ++){string[]ɜ=ə[(ɛ+1)].Split('\n');ɚ[ɛ]=int.Parse(ɜ[0]);}ǽ ȃ=new ǽ();if(ɚ[0]==0)ȃ.ȋ=Ȍ.Off;else ȃ.ȋ=Ȍ.On;if(ɚ[1]==0)ȃ.Ȏ=
ȏ.Off;else if(ɚ[1]==1)ȃ.Ȏ=ȏ.MinDefence;else if(ɚ[1]==2)ȃ.Ȏ=ȏ.AllDefence;else if(ɚ[1]==3)ȃ.Ȏ=ȏ.Offence;else if(ɚ[1]==4)ȃ.Ȏ
=ȏ.AllOnOnly;if(ɚ[2]==0)ȃ.ȑ=Ȓ.Off;else if(ɚ[2]==1)ȃ.ȑ=Ȓ.HoldFire;else if(ɚ[2]==2)ȃ.ȑ=Ȓ.OpenFire;if(ɚ[3]==0)ȃ.Ȕ=ȕ.Off;else
if(ɚ[3]==1)ȃ.Ȕ=ȕ.On;else if(ɚ[3]==2)ȃ.Ȕ=ȕ.Minimum;if(ɚ[4]==0)ȃ.ȗ=Ș.Off;else if(ɚ[4]==1)ȃ.ȗ=Ș.On;else if(ɚ[4]==2)ȃ.ȗ=Ș.
ForwardOff;else if(ɚ[4]==3)ȃ.ȗ=Ș.ReverseOff;if(ɚ[5]==0)ȃ.Ț=ț.Off;else if(ɚ[5]==1)ȃ.Ț=ț.On;else if(ɚ[5]==2)ȃ.Ț=ț.OnMax;if(ɚ[6]==0)ȃ
.ȝ=Ȟ.Off;else ȃ.ȝ=Ȟ.On;ȃ.Ƞ=new Color(ɚ[7],ɚ[8],ɚ[9],ɚ[10]);if(ɚ[11]==0)ȃ.Ȣ=Ȟ.Off;else ȃ.Ȣ=Ȟ.On;ȃ.Ȥ=new Color(ɚ[12],ɚ[13],
ɚ[14],ɚ[15]);if(ɚ[16]==0)ȃ.Ú=Ȫ.Auto;else if(ɚ[16]==1)ȃ.Ú=Ȫ.StockpileRecharge;else if(ɚ[16]==2)ȃ.Ú=Ȫ.Discharge;if(ɚ[17]==0
)ȃ.Ȯ=Î.Off;else ȃ.Ȯ=Î.On;ȃ.Ȭ=ɘ[ɚ[18]];if(ɚ[19]==0)ȃ.Ȱ=ȱ.NoChange;else ȃ.Ȱ=ȱ.Abort;if(ɚ[20]==0)ȃ.ȳ=Î.Off;else ȃ.ȳ=Î.On;if(
ɚ[21]==0)ȃ.ȵ=ȶ.Off;else if(ɚ[21]==1)ȃ.ȵ=ȶ.On;else if(ɚ[21]==2)ȃ.ȵ=ȶ.FillWhenLow;else if(ɚ[21]==3)ȃ.ȵ=ȶ.KeepFull;if(ɚ[22]
==0)ȃ.Í=Î.Off;else ȃ.Í=Î.On;if(ɚ[23]==0)ȃ.ȹ=Ⱥ.Closed;else if(ɚ[23]==1)ȃ.ȹ=Ⱥ.Open;else ȃ.ȹ=Ⱥ.NoChange;ȃ.ȼ=Î.NoChange;Ǿ.Add(
Ȃ,ȃ);}if(Ǿ.Count>=1){if(l)Echo("Finished parsing "+Ǿ.Count+" stances.");ɂ=Ǿ;}else{Echo("Didn't find any stances!");}}
catch(Exception ė){Echo("Custom Data Error (stances)\n"+ė.Message);}}void Ç(){bool ɝ=Ʉ();if(!ɝ){ɞ();ɏ();}if(Ì==null){Ì=ɂ.
First().Value;}string ɟ="";string ɠ="";if(!ǖ){ɟ=" ".PadRight(129,' ')+T+"\n";ɠ="\n".PadRight(19,'\n');}U=ɟ+ɠ;V=ɟ+string.Join(
"\n",Ǘ.Split(','))+ɠ;if(ę==""){if(l)Echo("No ship name, trying to pull it from PB name...");string ɡ="Untitled Ship";try{
string[]ɢ=Me.CustomName.Split(Ŵ);if(ɢ.Length>1){ę=ɢ[0];if(l)Echo(ę);}else ę=ɡ;}catch{ę=ɡ;}}}void ɤ(bool t=true,bool ɣ=false,
bool q=false){MyIni Ư=new MyIni();string Ƭ=Me.CustomData;MyIniParseResult ư;if(!Ư.TryParse(Ƭ,out ư)){Á.Add(new Â(
"CONFIG ERROR!!","Failed to save to custom data due to a parsing error!\nFix and recompile!",3));return;}string ƭ,Ŭ;if(t){ƭ="RSM.Stance"
;Ŭ="CurrentStance";Ư.Set(ƭ,Ŭ,Ě);}else{ƭ="RSM.System";Ŭ="ShipName";Ư.Set(ƭ,Ŭ,ę);}if(ɣ){ƭ="RSM.InitSubSystems";Ư.Set(ƭ,
"Reactors",ǰ);Ư.Set(ƭ,"Batteries",Ǳ);Ư.Set(ƭ,"BatteryStorage",ǲ);Ư.Set(ƭ,"Pdcs",ǳ);Ư.Set(ƭ,"TorpLaunchers",Ǵ);Ư.Set(ƭ,
"KineticWeapons",ǵ);Ư.Set(ƭ,"H2Storage",Ƕ);Ư.Set(ƭ,"O2Storage",Ƿ);Ư.Set(ƭ,"MainThrust",Ǹ);Ư.Set(ƭ,"RCSThrust",ǹ);Ư.Set(ƭ,"Gyros",Ǻ);Ư.
Set(ƭ,"CargoStorage",Ǎ);Ư.Set(ƭ,"Welders",ǻ);}if(q){ƭ="RSM.InitItems";foreach(Ī Ǯ in ĩ){Ŭ=Ǯ.ń.SubtypeId;Ư.Set(ƭ,Ŭ,Ǯ.ǯ);}}Me
.CustomData=Ư.ToString();}string Ⱦ(Type ɥ){string ɦ="";foreach(var ɧ in Enum.GetValues(ɥ)){if(ɦ!="")ɦ+=", ";ɦ+=ɧ.ToString
();}return ɦ;}string Ɏ(Color ɨ){return ɨ.R+", "+ɨ.G+", "+ɨ.B+", "+ɨ.A;}void Ǽ(Exception ė,string ɩ){Runtime.
UpdateFrequency=UpdateFrequency.None;string ɪ="\nRSM FAILED TO START\nDUE TO A CONFIG ERROR!\n\n"+ɩ+
"\n\nFix error in custom data\nor clear custom data\nand recompile!\n\n";Echo(ɪ);List<IMyTextPanel>ɫ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(ɫ,ş=>ş.CustomName
.Contains(Ŧ));foreach(IMyTextPanel ɬ in ɫ){ɬ.WriteText(ɪ);ɬ.FontColor=new Color(193,0,197,255);}throw ė;}Dictionary<
string,ǽ>ɂ=new Dictionary<string,ǽ>();void ɞ(){ɂ=new Dictionary<string,ǽ>{{"Cruise",new ǽ{ȋ=Ȍ.On,Ȏ=ȏ.AllDefence,ȑ=Ȓ.HoldFire,Ȕ
=ȕ.EpsteinOnly,ȗ=Ș.ForwardOff,Ț=ț.Off,ȝ=Ȟ.On,Ƞ=new Color(33,144,255,255),Ȣ=Ȟ.On,Ȥ=new Color(255,214,170,255),Ȧ=Ȟ.On,Ȩ=new
Color(33,144,255,255),Ú=Ȫ.Auto,Ȭ=50,Ȯ=Î.NoChange,Ȱ=ȱ.Abort,ȳ=Î.NoChange,ȵ=ȶ.KeepFull,Í=Î.On,ȹ=Ⱥ.NoChange,ȼ=Î.NoChange,ȿ=ɀ.On}
},{"StealthCruise",new ǽ{ɍ="Cruise",ȋ=Ȍ.On,Ȏ=ȏ.AllDefence,ȑ=Ȓ.HoldFire,Ȕ=ȕ.Minimum,ȗ=Ș.ForwardOff,Ț=ț.Off,ȝ=Ȟ.Off,Ƞ=new
Color(0,0,0,255),Ȣ=Ȟ.On,Ȥ=new Color(23,73,186,255),Ȧ=Ȟ.Off,Ȩ=new Color(23,73,186,255),Ú=Ȫ.Auto,Ȭ=5,Ȯ=Î.Off,Ȱ=ȱ.Abort,ȳ=Î.
NoChange,ȵ=ȶ.KeepFull,Í=Î.On,ȹ=Ⱥ.NoChange,ȼ=Î.NoChange,ȿ=ɀ.On}},{"Docked",new ǽ{ɍ="Cruise",ȋ=Ȍ.On,Ȏ=ȏ.AllDefence,ȑ=Ȓ.HoldFire,Ȕ=
ȕ.Off,ȗ=Ș.Off,Ț=ț.Off,ȝ=Ȟ.On,Ƞ=new Color(33,144,255,255),Ȣ=Ȟ.On,Ȥ=new Color(255,240,225,255),Ȧ=Ȟ.On,Ȩ=new Color(255,255,
255,255),Ú=Ȫ.StockpileRecharge,Ȭ=-1,Ȯ=Î.NoChange,Ȱ=ȱ.Abort,ȳ=Î.Off,ȵ=ȶ.On,Í=Î.On,ȹ=Ⱥ.NoChange,ȼ=Î.NoChange,ȿ=ɀ.Off}},{
"Docking",new ǽ{ɍ="Docked",ȋ=Ȍ.On,Ȏ=ȏ.AllDefence,ȑ=Ȓ.HoldFire,Ȕ=ȕ.Off,ȗ=Ș.On,Ț=ț.OnMax,ȝ=Ȟ.On,Ƞ=new Color(33,144,255,255),Ȣ=Ȟ.On,
Ȥ=new Color(212,170,83,255),Ȧ=Ȟ.On,Ȩ=new Color(212,170,83,255),Ú=Ȫ.Auto,Ȭ=-1,Ȯ=Î.NoChange,Ȱ=ȱ.Abort,ȳ=Î.Off,ȵ=ȶ.KeepFull,
Í=Î.On,ȹ=Ⱥ.NoChange,ȼ=Î.NoChange,ȿ=ɀ.On}},{"NoAttack",new ǽ{ɍ="Docked",ȋ=Ȍ.Off,Ȏ=ȏ.Off,ȑ=Ȓ.Off,Ȕ=ȕ.On,ȗ=Ș.On,Ț=ț.Off,ȝ=Ȟ.
On,Ƞ=new Color(255,255,255,255),Ȣ=Ȟ.On,Ȥ=new Color(84,157,82,255),Ȧ=Ȟ.NoChange,Ȩ=new Color(84,157,82,255),Ú=Ȫ.NoChange,Ȭ=-
1,Ȯ=Î.NoChange,Ȱ=ȱ.NoChange,ȳ=Î.NoChange,ȵ=ȶ.KeepFull,Í=Î.On,ȹ=Ⱥ.NoChange,ȼ=Î.NoChange,ȿ=ɀ.NoChange}},{"Combat",new ǽ{ɍ=
"Cruise",ȋ=Ȍ.On,Ȏ=ȏ.AllDefence,ȑ=Ȓ.OpenFire,Ȕ=ȕ.On,ȗ=Ș.On,Ț=ț.Off,ȝ=Ȟ.Off,Ƞ=new Color(0,0,0,255),Ȣ=Ȟ.On,Ȥ=new Color(210,98,17,
255),Ȧ=Ȟ.Off,Ȩ=new Color(210,98,17,255),Ú=Ȫ.ManagedDischarge,Ȭ=100,Ȯ=Î.On,Ȱ=ȱ.Abort,ȳ=Î.On,ȵ=ȶ.KeepFull,Í=Î.On,ȹ=Ⱥ.NoChange
,ȼ=Î.NoChange,ȿ=ɀ.On}},{"CQB",new ǽ{ɍ="Combat",ȋ=Ȍ.On,Ȏ=ȏ.Offence,ȑ=Ȓ.OpenFire,Ȕ=ȕ.On,ȗ=Ș.On,Ț=ț.Off,ȝ=Ȟ.Off,Ƞ=new Color(
0,0,0,255),Ȣ=Ȟ.On,Ȥ=new Color(243,18,18,255),Ȧ=Ȟ.Off,Ȩ=new Color(243,18,18,255),Ú=Ȫ.ManagedDischarge,Ȭ=100,Ȯ=Î.On,Ȱ=ȱ.
Abort,ȳ=Î.On,ȵ=ȶ.KeepFull,Í=Î.On,ȹ=Ⱥ.NoChange,ȼ=Î.NoChange,ȿ=ɀ.On}},{"WeaponsHot",new ǽ{ɍ="CQB",ȋ=Ȍ.On,Ȏ=ȏ.Offence,ȑ=Ȓ.
OpenFire,Ȕ=ȕ.NoChange,ȗ=Ș.NoChange,Ț=ț.NoChange,ȝ=Ȟ.NoChange,Ƞ=new Color(0,0,0,255),Ȣ=Ȟ.NoChange,Ȥ=new Color(243,18,18,255),Ȧ=Ȟ.
NoChange,Ȩ=new Color(243,18,18,255),Ú=Ȫ.ManagedDischarge,Ȭ=-1,Ȯ=Î.NoChange,Ȱ=ȱ.NoChange,ȳ=Î.NoChange,ȵ=ȶ.KeepFull,Í=Î.On,ȹ=Ⱥ.
NoChange,ȼ=Î.NoChange,ȿ=ɀ.On}}};}class Ŝ{public IMyDoor ħ;public int ɭ=0;public int ɮ=0;public bool ƈ=false;public bool ɯ=false;
}class ŝ{public string Ƌ;public bool ɰ=false;public int ɱ=0;public bool ɲ=false;public List<Ŝ>ƌ=new List<Ŝ>();public List
<IMyAirVent>Ə=new List<IMyAirVent>();}int ɳ=0;int ɴ=0;int ɵ=0;int ɼ(Ŝ ɶ,bool Ɗ=false){bool ɷ=false;bool ɸ=false;if(ɶ.ħ==
null)return 0;bool ɹ=ɶ.ħ.OpenRatio>0;ɳ++;if(ɺ(ɶ.ħ))ɵ++;if(!Ɗ||ɹ)ɶ.ħ.Enabled=true;if(ɹ){if(ɶ.ɭ==0){ɸ=true;}ɶ.ɭ++;if(ɶ.ɭ>=Ǚ){ɶ
.ɭ=0;ɶ.ħ.CloseDoor();ɷ=true;}}else{ɴ++;if(ɶ.ɭ!=0){ɷ=true;ɶ.ɭ=0;}}int ɻ=0;if(ɷ)ɻ=1;else if(ɸ)ɻ=2;return ɻ;}void ã(){if(!ǘ)
{if(l)Echo("Door management is disabled.");return;}foreach(ŝ Ɗ in â){bool ɽ=false;foreach(Ŝ ɶ in Ɗ.ƌ){if(ɶ.ħ==null)
continue;int ɾ=ɼ(ɶ,true);if(ɾ==1){if(l)Echo("Airlock door "+ɶ.ħ.CustomName+" just closed");if(Ɗ.ɲ)Ɗ.ɲ=false;else{Ɗ.ɰ=true;ɶ.ɯ=
true;if(l)Echo("Airlock "+Ɗ.Ƌ+" needs to cycle");}}else if(ɾ==2){if(l)Echo("Airlock door "+ɶ.ħ.CustomName+" just opened");ɽ=
true;}}bool ɿ=true;if(Ɗ.ɰ){foreach(Ŝ ɶ in Ɗ.ƌ){if(ɶ.ħ==null)continue;if(ɶ.ħ.OpenRatio>0){ɶ.ħ.CloseDoor();ɿ=false;}else ɶ.ħ.
Enabled=false;}bool ʀ=false;foreach(IMyAirVent ʁ in Ɗ.Ə){if(ʁ==null)continue;if(!ʁ.Enabled)ʁ.Enabled=true;if(!ʁ.Depressurize)ʁ.
Depressurize=true;if(ʁ.CanPressurize&&ʁ.GetOxygenLevel()<.01&&Ɗ.ɰ&&ɿ)ʀ=true;}Ɗ.ɱ++;bool ʂ=true;if(Ɗ.ɱ>=ǚ){ʂ=false;ʀ=true;}if(ʀ){Ɗ.ɰ=
false;Ɗ.ɱ=0;Ɗ.ɲ=true;foreach(Ŝ ɶ in Ɗ.ƌ){if(ɶ.ħ==null)continue;ɶ.ħ.Enabled=true;if(ɶ.ɯ)ɶ.ɯ=false;else if(ʂ)ɶ.ħ.OpenDoor();}}}
else if(ɽ){foreach(Ŝ ɶ in Ɗ.ƌ){if(ɶ.ħ==null)continue;if(ɶ.ħ.OpenRatio==0)ɶ.ħ.Enabled=false;}}else{foreach(Ŝ ɶ in Ɗ.ƌ){ɶ.ħ.
Enabled=true;}}}}void á(){if(!ǘ){if(l)Echo("Door management is disabled.");return;}ɳ=0;ɴ=0;ɵ=0;foreach(Ŝ ɶ in à)ɼ(ɶ);}void ʄ(Ⱥ
Ň){if(Ň==Ⱥ.NoChange)return;foreach(IMyAirtightHangarDoor ʃ in ō){if(ʃ==null)continue;if(Ň==Ⱥ.Closed)ʃ.CloseDoor();else ʃ.
OpenDoor();}}void x(string ʅ,string ʆ){ʅ=ʅ.ToLower();foreach(Ŝ ɶ in à){if(ʆ==""||ɶ.ħ.CustomName.Contains(ʆ)){bool ʇ=ɺ(ɶ.ħ);if(ʇ
&&(ʅ=="locked"||ʅ=="toggle"))ɶ.ħ.ApplyAction("AnyoneCanUse");if(!ʇ&&(ʅ=="unlocked"||ʅ=="toggle"))ɶ.ħ.ApplyAction(
"AnyoneCanUse");}}}bool ɺ(IMyDoor ɶ){var ŉ=ɶ.GetActionWithName("AnyoneCanUse");StringBuilder ʈ=new StringBuilder();ŉ.WriteValue(ɶ,ʈ);
return(ʈ.ToString()=="On");}double Ǻ=0;int ʉ=0;double ʊ=0;void ò(bool ʋ,bool ʌ){ʉ=0;foreach(IMyGyro ʍ in ñ){if(ʍ!=null&&ʍ.
IsFunctional){ʉ++;if(ʌ)ʍ.Enabled=ʋ;}}ʊ=Math.Round(100*(ʉ/Ǻ));}double ʎ=0;int ʏ=0;double ʐ=0;void ô(){ʏ=0;foreach(IMyGyro ʍ in ó){if(
ʍ!=null&&ʍ.IsFunctional){ʏ++;if(Ì.ȿ==ɀ.On)ʍ.Enabled=true;else if(Ì.ȿ==ɀ.Off)ʍ.Enabled=false;}}ʐ=Math.Round(100*(ʏ/ʎ));}
int ʑ=0;void ʒ(Î Ň){if(Ň==Î.NoChange)return;foreach(IMyFunctionalBlock ʃ in ü){if(ʃ==null)continue;ʃ.Enabled=(Ň==Î.On);}}
void ý(){ʑ=0;foreach(IMyFunctionalBlock ʃ in ü){if(ʃ==null||!ʃ.IsFunctional)continue;ʑ++;}}void s(string ʓ,bool o=true,bool
p=true,bool q=true){if(l)Echo("Initialising a ship as '"+ʓ+"'...");J=true;ę=ʓ;b=o;Z=p;a=q;È();}void È(){switch(G){case 0:
Ï();F=0;if(Å)Echo("Took "+c());break;case 1:ç();if(Å)Echo("Took "+c());break;case 2:if(l)Echo("Initialising lcds...");ʔ()
;if(Z){if(l)Echo("Initialising subsystem values...");ʕ();ʖ();ʗ();ʘ();ʙ();ʚ();Ǒ();ǳ=î.Count+ï.Count;Ǵ=å.Count;ǵ=Ó.Count;Ǻ=
ñ.Count;ʎ=ó.Count;ǻ=Ą.Count;}if(a){if(l)Echo("Initialising item values...");ʛ();}if(b){if(l)Echo(
"Initialising block names...");ʜ();}ɤ(false,Z,a);Á.Add(new Â("Init:"+ę,"Initialised '"+ę+"'\nGood Hunting!",3));G=0;J=false;if(Å)Echo("Took "+c());
return;}G++;}class ʠ{public int ʝ=0;public int ʞ=0;public int ʟ=0;}void ʜ(){Dictionary<string,ʠ>ʡ=new Dictionary<string,ʠ>();
if(ǟ.Count>0){foreach(string Ż in ǟ){if(l)Echo("Numbering "+Ż);ʡ.Add(Ż,new ʠ());}foreach(var ʣ in Ş){ʠ ʢ;if(ʡ.TryGetValue(
ʣ.Value,out ʢ)){ʡ[ʣ.Value].ʞ++;}}foreach(var ʤ in ʡ){if(ʤ.Value.ʞ<10)ʤ.Value.ʟ=1;else if(ʤ.Value.ʞ>99)ʤ.Value.ʟ=3;else ʤ.
Value.ʟ=2;}}foreach(var ʣ in Ş){string ʥ="";string ʦ=ʣ.Value;ʠ ʧ;if(ʡ.TryGetValue(ʣ.Value,out ʧ)){if(ʧ.ʞ>1){ʧ.ʝ++;ʥ=Ŵ+ʧ.ʝ.
ToString().PadLeft(ʧ.ʟ,'0');}}ʣ.Key.CustomName=ę+Ŵ+ʦ+ʥ+ʨ(ʣ.Key.CustomName,ʦ);}}string ʨ(string Ŭ,string ʩ=""){try{string[]ʪ=Ŭ.
Split(Ŵ);string[]ʫ=ʩ.Split(Ŵ);string ư="";if(ʪ.Length<3)return"";for(int ɒ=2;ɒ<ʪ.Length;ɒ++){int ʬ=0;bool ʭ=int.TryParse(ʪ[ɒ]
,out ʬ);if(ʭ)ʪ[ɒ]="";foreach(string ʮ in ʫ){if(ʮ==ʪ[ɒ])ʪ[ɒ]="";}if(ʪ[ɒ]!="")ư+=Ŵ+ʪ[ɒ];}return ư;}catch{return"";}}class Į
{public IMyTerminalBlock ħ{get;set;}public IMyInventory ļ{get;set;}List<MyInventoryItem>ʯ=new List<MyInventoryItem>();
public int ľ=0;public bool Ľ=false;public float ŀ;public int Ŀ=0;}class Ī{public int ʰ=0;public int ǯ=0;public int Ń=0;public
double ʱ;public List<Į>į=new List<Į>();public List<Į>İ=new List<Į>();public MyItemType ń;public bool ī=false;public bool Ĭ=
false;public string ĭ;public string ʲ;public double Ļ=1;public double ʳ=0;}List<Ī>ĩ=new List<Ī>();void ŷ(IMyTerminalBlock ş,
int Ǯ=99){if(Ǯ==99){foreach(var Ī in ĩ){Į ļ=new Į();ļ.ħ=ş;ļ.ļ=ş.GetInventory();Ī.į.Add(ļ);}}else{Į ļ=new Į();ļ.ħ=ş;ļ.ļ=ş.
GetInventory();ļ.Ľ=Ĩ;if(Ǯ==0&&!Ǔ)ļ.Ľ=false;ĩ[Ǯ].į.Add(ļ);}}void ʴ(IMyTerminalBlock ş,int Ǯ){Į ļ=new Į();ļ.ħ=ş;ļ.ļ=ş.GetInventory();ļ
.Ľ=Ĩ;if(Ǯ!=99)ĩ[Ǯ].İ.Add(ļ);}void ʷ(string ĭ,string ʵ,string ʶ,bool Ĭ=false,bool ī=false){Ī Ī=new Ī();Ī.ń=new MyItemType(
ʵ,ʶ);Ī.Ĭ=Ĭ;Ī.ī=ī;Ī.ĭ=ĭ;string ʲ;if(ĭ.Length>9)ʲ=ĭ.Substring(0,9);else ʲ=ĭ.PadRight(9);Ī.ʲ=ʲ;ĩ.Add(Ī);}void e(){try{ʷ(
"Fusion Pellets","MyObjectBuilder_Ingot","sdx_itemReactorFuel",true);ʷ("Fuel Can ","MyObjectBuilder_Component","Fuel_Tank");ʷ("50mm PDC"
,"MyObjectBuilder_AmmoMagazine","sdx_ammomagazinePdc50mm");ʷ("40mm Impv","MyObjectBuilder_AmmoMagazine",
"sdx_ammomagazinePdc40mmImprovised",true);ʷ("40mm PDC","MyObjectBuilder_AmmoMagazine","sdx_ammomagazinePdc40mm",true);ʷ("160mm Torp ",
"MyObjectBuilder_AmmoMagazine","sdx_ammomagazineTorpedo160mm",true,true);ʷ("190mm Torp","MyObjectBuilder_AmmoMagazine",
"sdx_ammomagazineTorpedo190mmImprovised",true,true);ʷ("220mm Torp","MyObjectBuilder_AmmoMagazine","sdx_ammomagazineTorpedo220mm",true,true);ʷ("RS Torp",
"MyObjectBuilder_AmmoMagazine","RamshackleTorpedoMagazine",true,true);ʷ("LRS Torp","MyObjectBuilder_AmmoMagazine","LargeRamshackleTorpedoMagazine",
true,true);ʷ("120mm RG","MyObjectBuilder_AmmoMagazine","120mmLeadSteelSlugMagazine",true);ʷ("Dawson",
"MyObjectBuilder_AmmoMagazine","100mmTungstenUraniumSlugUNNMagazine",true);ʷ("Stiletto","MyObjectBuilder_AmmoMagazine",
"100mmTungstenUraniumSlugMCRNMagazine",true);ʷ("80mm Pb","MyObjectBuilder_AmmoMagazine","sdx_ammomagazineSabot80mmImprovised",true);ʷ("80mm W-U",
"MyObjectBuilder_AmmoMagazine","sdx_ammomagazineSabot80mm",true);ʷ("100mm W-U","MyObjectBuilder_AmmoMagazine","sdx_ammomagazineSabot100mm",true);ʷ(
"Kess","MyObjectBuilder_AmmoMagazine","180mmLeadSteelSabotMagazine",true);ʷ("Steel Pla","MyObjectBuilder_Component",
"SteelPlate");ʷ("Reactor C","MyObjectBuilder_Component","Reactor");ĩ[0].Ļ=ǣ;}catch(Exception ė){Echo("Failed to build item lists!");
Echo(ė.Message);return;}}void ä(){foreach(var Ī in ĩ){Ī.İ.Clear();}}void ç(){foreach(var Ī in ĩ){Ī.ʰ=0;Ī.Ń=0;List<Į>ı=Ī.į.
Concat(Ī.İ).ToList();foreach(Į ļ in ı){ļ.ľ=ļ.ļ.GetItemAmount(Ī.ń).ToIntSafe();Ī.ʰ+=ļ.ľ;if(ļ.Ľ){ļ.ŀ=ļ.ļ.VolumeFillFactor;if(ļ.ľ
>0&&ļ.ŀ>0){double ʸ=ļ.ļ.MaxVolume.RawValue;if(ʸ>0)Ī.ʳ=ļ.ľ/(ļ.ŀ*ʸ);}}else{Ī.Ń+=ļ.ľ;}}if(Ī.ʳ>0){foreach(Į ļ in ı){if(!ļ.Ľ)
continue;double ʹ=Ī.ʳ*ļ.ļ.MaxVolume.RawValue;if(ʹ>int.MaxValue)ʹ=int.MaxValue;if(ʹ<0)ʹ=0;ļ.Ŀ=Convert.ToInt32(ʹ);}}}}void ʛ(){
foreach(Ī Ī in ĩ){Ī.ǯ=Ī.ʰ;}}int ʻ(string ʺ){switch(ʺ){case"220mm Plasma Torpedo":return 7;case"190mm Improvised Torpedo":return
6;case"160mm Plasma Torpedo":return 5;case"50mm PDC Ammo":return 2;case"40mm PDC Ammo":return 4;case
"40mm PDC Ammo Improvised":return 3;case"80mm Sabot Improvised":return 13;case"80mm Sabot":return 14;case"100mm Tungsten-Uranium Sabot":return 15;
default:if(l)Echo("Unknown AmmoType = "+ʺ);return 99;}}bool ʽ(IMyTerminalBlock ħ){IMyInventory ʼ=ħ.GetInventory();return ʼ.
VolumeFillFactor==0;}bool Ņ(List<Į>Ĳ,List<Į>Ĵ,MyItemType ń,double ʾ=-1,double ʿ=1,double ˀ=1){if(l)Echo("Loading "+Ĵ.Count+
" inventories from "+Ĳ.Count+" sources.");bool ˁ=false;bool ˆ=ˀ<1;double ˇ=ʿ;if(ʾ>=0&&ʾ<ˇ)ˇ=ʾ;foreach(Į ˊ in Ĵ){int ˈ=3;int ˉ=-1;if(ˇ<1){if(
ˊ.Ŀ>0)ˉ=Convert.ToInt32(ˊ.Ŀ*ˇ);else ˉ=ˊ.ľ+10;}if(!ˆ&&ˉ>=0&&ˊ.ľ>=ˉ)continue;foreach(Į ˋ in Ĳ){if(ˈ<0)break;if(ˉ>=0&&ˊ.ľ>=(
ˉ*.95))break;if(!ˊ.ļ.IsConnectedTo(ˋ.ļ))continue;List<MyInventoryItem>ˌ=new List<MyInventoryItem>();ˋ.ļ.GetItems(ˌ);
foreach(MyInventoryItem ˍ in ˌ){if(ˍ.Type==ń){int ľ=ˍ.Amount.ToIntSafe();if(ľ==0&&!ˆ)break;ˈ--;if(ˆ){ˈ=-1;int ˎ;if(ˋ.Ŀ>0)ˎ=
Convert.ToInt32(ˋ.Ŀ*ˀ);else if(ˋ.ŀ>0)ˎ=Convert.ToInt32(ˋ.ľ/ˋ.ŀ*ˀ);else ˎ=ˋ.ľ;if(ˎ<0)ˎ=0;if(ˎ>ˋ.ľ)ˎ=ˋ.ľ;ľ=ˋ.ľ-ˎ;if(l)Echo(
"Unload "+ľ+" of "+ˋ.ľ+", keeping "+ˎ);if(ľ<1)break;}else if(ˉ>=0){int ˏ=ˉ-ˊ.ľ;if(ˏ<1)break;if(ˏ<ľ)ľ=ˏ;if(ʾ>=0&&ˋ.Ľ){int ː=ˋ.ľ-ˊ.
ľ;if(ː<2)break;int ˑ=ː/2;if(ˑ<ľ)ľ=ˑ;}}ˁ=ˊ.ļ.TransferItemFrom(ˋ.ļ,ˍ,ľ);if(ˁ){ˋ.ľ-=ľ;if(ˋ.ľ<0)ˋ.ľ=0;ˊ.ľ+=ľ;ˈ=-1;}if(ˆ&&ˁ)
return(ˁ);break;}}}}return ˁ;}class ŕ{public IMyTextPanel ħ;public bool ƴ=true;public bool Ƶ=false;public bool ƶ=false;public
bool Ƴ=true;public bool Ʒ=true;public bool Ƹ=true;public bool ƹ=false;public bool ƺ=false;}class Â{public string ˠ,ˡ;public
int ˢ,ˣ;public Â(string ˤ,string ˬ,int ˮ=0,int Ͱ=20){if(ˤ.Length>ͱ-3)ˤ=ˤ.Substring(0,ͱ-3);ˠ=ˤ.PadRight(ͱ-3);ˡ=ˬ;ˢ=ˮ;ˣ=Ͱ;}}
List<Â>Á=new List<Â>();class ͺ{public string Ͳ,ͳ;public ͺ(string Ż,int ʹ,int Ͷ){string ͷ="    ";while(Ͷ>3){Ͷ-=4;}if(ʹ==0){Ͳ=
"║ "+Ż.PadRight(4)+" ║";ͳ="  "+ͷ+"  ";}else if(ʹ==1){if(Ͷ==0||Ͷ==2)Ͳ="║─"+Ż.PadRight(4)+" ║";else Ͳ="║ "+Ż.PadRight(4)+"─║";
ͳ=" ░"+ͷ+"░ ";}else if(ʹ==2){if(Ͷ==0||Ͷ==2){Ͳ="║ "+Ż.PadRight(4)+"═║";ͳ="║▒"+ͷ+"░║";}else{Ͳ="║═"+Ż.PadRight(4)+" ║";ͳ=
"║░"+ͷ+"▒║";}}else if(ʹ==3){if(Ͷ==0||Ͷ==2){Ͳ="║!"+Ż.PadRight(4)+"!║";ͳ="║▓"+ͷ+"▓║";}else{Ͳ="║ "+ͷ+" ║";ͳ="║!"+Ż.PadRight(4)+
"!║";}}}}Color ͻ=new Color(255,116,33,255);const int ͱ=32;int ͼ=0;string[]ͽ=new string[]{"▄ "," ▄"," ▀","▀ "},Ά=new string[]
{"─","\\","│","/"},Έ=new string[]{"- ","= ","x ","! "};string Ή,Ί,Ό,Ύ,Ώ="\n\n",ΐ,Α="╔══════╗",Β="╚══════╝",Ʌ,Γ,Δ,Ε,Ζ,Η,Θ,
Ι,Κ,Λ,Μ,Ν,Ξ,Ο,Π,Ρ,Σ,Τ,Υ,Φ,Χ;void g(){Α=Α+Α+Α+Α+"\n";Β=Β+Β+Β+Β+"\n";Ή=Ψ("Welcome to")+Ώ+Ψ("R S M")+Ώ;Ί=Ψ("Initialising")+Ώ
;Ό=new String(' ',ͱ-8);Ύ="└"+new String('─',ͱ-2)+"┘";Ʌ=new String('-',26)+"\n";ΐ="──"+Ώ;Γ=Ω("Inventory");Δ=Ω("Thrust");Ε=
Ω("Power & Tanks");Ζ=Ω("Warnings");Η=Ω("Subsystem Integrity");Θ=Ω("Telemetry & Thrust");Ι=Ϊ("Velocity");Κ=Ϊ(
"Velocity (Max)");Λ=Ϊ("Mass");Μ=Ϊ("Max Accel");Ν=Ϊ("Actual Accel");Ξ=Ϊ("Accel (Best)");Ο=Ϊ("Max Thrust");Π=Ϊ("Actual Thrust");Ρ=Ϊ(
"Decel (Dampener)");Σ=Ϊ("Decel (Actual)");Τ=Ϋ("Fuel");Υ=Ϋ("Oxygen");Φ=Ϋ("Battery");Χ=Ϋ("Capacity");}string Ω(string ά){return"──┤ "+ά+" ├"
+new String('─',ͱ-9-ά.Length);}string Ϊ(string έ){return έ+":"+new String(' ',ͱ-16-έ.Length);}string Ϋ(string ή){return ή
+new String(' ',ͱ-22-ή.Length)+"[";}void Ê(){ͼ++;if(ͼ>=ͽ.Length)ͼ=0;int ί=ͼ+2;if(ί>3)ί-=4;string ΰ=ͽ[ͼ];string α=Ά[ͼ];
string β=ͽ[ί];string γ=Γ+α+ΐ;string δ=Δ+α+ΐ;string ε=Ε+α+ΐ;string ζ=Ζ+α+ΐ;string η=Η+α+ΐ;string θ=Θ+α+ΐ;string ι=Ψ(ę.ToUpper()
)+"\n"+"  "+ΰ+" "+Ψ(Ě,ͱ-10)+" "+ΰ+"  \n";string κ="\n  "+β+Ό+β+"  "+Ώ;if(I){string λ=Ή+Ψ("Booting"+new string('.',C))+Ώ;γ
+=λ;δ+=λ;ε+=λ;ζ+=λ;η+=λ;}else if(J){string Ƣ=Ί+Ψ(ę)+Ώ;γ+=Ƣ;δ+=Ƣ;ε+=Ƣ;ζ+=Ƣ;η+=Ƣ;}else{ǌ();double μ=9.81,ν=Math.Round(R),ο=
Math.Round((ξ/S/μ),2),ρ=Math.Round((π/S/μ),2),ς=Math.Round(ǰ+Ǳ,1),τ=Math.Round(σ,1),χ=Math.Round(100*(υ/φ)),ϊ=Math.Round(100
*(ψ/ω)),ϋ=Math.Round(100*(τ/ς));string ό=Ι,ύ=" Gs",Ȅ;List<string>ώ=new List<string>();if(ν<1){ν=500;ό=Κ;}if(Ǣ){μ=1;ύ=
" m/s/s";}for(int ɒ=0;ɒ<ĩ.Count;ɒ++){if(ĩ[ɒ].ǯ!=0){ĩ[ɒ].ʱ=(100*((double)ĩ[ɒ].ʰ/(double)ĩ[ɒ].ǯ));string ɧ=(ĩ[ɒ].ʰ+"/"+ĩ[ɒ].ǯ).
PadLeft(9);if(ɧ.Length>9)ɧ=ɧ.Substring(0,9);γ+=ĩ[ɒ].ʲ+" ["+Ϗ(ĩ[ɒ].ʱ)+"] "+ɧ+"\n";if(ɒ>2&&ĩ[ɒ].Ń<1)ώ.Add(ĩ[ɒ].ĭ);}}γ+="\n";if(π>
0)δ+=Σ+ϐ(π,ν)+"\n"+Ν+(ρ+ύ).PadLeft(15)+Ώ;else δ+=Ρ+ϐ(ξ,ν,true)+"\n"+Ξ+(ο+ύ).PadLeft(15)+Ώ;O=Math.Round(100*(ϑ/ϒ));ε+=Τ+Ϗ(
O)+"] "+(O+" %").PadLeft(9)+"\n"+Υ+Ϗ(χ)+"] "+(χ+" %").PadLeft(9)+"\n"+Φ+Ϗ(ϊ)+"] "+(ϊ+" %").PadLeft(9)+"\n"+Χ+Ϗ(ϋ)+"] "+(ϋ
+" %").PadLeft(9)+"\n"+"Max Power:"+(τ+" MW / "+ς+" MW").PadLeft(22)+Ώ;List<Â>ϓ=new List<Â>();List<ͺ>ϔ=new List<ͺ>();int
ϕ=0;for(int ɒ=0;ɒ<Á.Count;ɒ++){Á[ɒ].ˣ--;if(Á[ɒ].ˣ<1)Á.RemoveAt(ɒ);else ϓ.Add(Á[ɒ]);}if(ʎ>0&&ʏ==0){ϓ.Add(new Â(
"RCS GYROS OFFLINE!","RCS Gyroscope Computers are no longer functional!. Ship will turn more slowly.",2));}for(int ɒ=0;ɒ<ϖ.Count;ɒ++){string
ϗ="The ship core is applying a '"+ϖ[ɒ].Ż+"' punishment to this grid.";if(ϖ[ɒ].Ϙ.Length>0)ϗ+="\n"+ϖ[ɒ].Ϙ;else ϗ+=
"\nCheck the core for details.";ϓ.Add(new Â("CORE PUNISH: "+ϖ[ɒ].Ż.ToUpper()+"!",ϗ,2));}if(!ϙ){ϓ.Add(new Â("NO LiDAR!",
"No LiDARs are currently working. Ship is blind to enemy contacts at long range.",2));}if(N){ϓ.Add(new Â("NO SPAWNS!","NO FUNCTIONAL SPAWNS!\nNo functional spawns detected by RSM!",3));}int Ϛ=0;if(O<5)
{Ȅ="FUEL CRITICAL!";ϓ.Add(new Â(Ȅ,Ȅ+"\nFuel Level < 5%!",3));Ϛ=3;}else if(O<25){Ȅ="FUEL LOW!";ϓ.Add(new Â(Ȅ,Ȅ+
"\nFuel Level < 10%!",2));Ϛ=2;}ϔ.Add(new ͺ("FUEL",Ϛ,ͼ+ϕ));ϕ++;if(M){Ȅ=Ĉ.Count+" spawns are open to friends";ϓ.Add(new Â(Ȅ,Ȅ,0));}int ϛ=0;if(χ
<5){Ȅ="OXYGEN CRITICAL!";ϓ.Add(new Â(Ȅ,Ȅ+"\nShip O2 Level < 5%!",3));ϛ=3;}else if(χ<10){Ȅ="OXYGEN LOW!";ϓ.Add(new Â(Ȅ,Ȅ+
"\nShip O2 Level < 10%!",2));ϛ=2;}else if(χ<25){Ȅ="Oxygen Low!";ϓ.Add(new Â(Ȅ,Ȅ+"\nShip O2 Level < 25%!",1));ϛ=1;}if(Ā.Count>Ϝ){int ϝ=(Ā.Count-Ϝ
);ϛ++;Ȅ=ϝ+" vents are unsealed";ϓ.Add(new Â(Ȅ,Ȅ,1));}if(ɵ>0){Ȅ=ɵ+" doors are insecure";ϓ.Add(new Â(Ȅ,Ȅ,0));}if(Q>0){Ȅ=Ť+
" is active ("+Q+")";ϓ.Add(new Â(Ȅ,Ȅ,0));}ϔ.Add(new ͺ("OXYG",ϛ,ͼ+ϕ));ϕ++;int Ϟ=0;if(Ø.Count>0){if(ϊ<5){Ϟ+=2;Ȅ="BATTERIES CRITICAL!";ϓ.
Add(new Â(Ȅ,Ȅ+"\nBattery Level < 5%!",2));}else if(ϊ<10){Ϟ+=1;Ȅ="Batteries Low!";ϓ.Add(new Â(Ȅ,Ȅ+"\nBattery Level < 10%!",1
));}}if(Ö.Count>0){if(ϟ>0){Ϟ+=2;ϓ.Add(new Â(ϟ+" REACTORS NEED FUS. FUEL!","At least one reactor needs Fusion Fuel!",3));}
if(ĩ[0].ʰ<1){Ϟ+=3;Ȅ="NO FUSION FUEL!";ϓ.Add(new Â(Ȅ,Ȅ,2));}else if(ĩ[0].ʰ<50){Ϟ+=2;Ȅ="FUSION FUEL CRITICAL! ("+ĩ[0].ʰ+")";
ϓ.Add(new Â(Ȅ,Ȅ,2));}else if(ĩ[0].ǯ>0&&ĩ[0].ʱ<5){Ϟ+=2;Ȅ="FUSION FUEL CRITICAL!";ϓ.Add(new Â(Ȅ,Ȅ,3));}else if(ĩ[0].ǯ>0&&ĩ[
0].ʱ<10){Ϟ+=1;Ȅ="Fusion Fuel Level Low!";ϓ.Add(new Â(Ȅ,Ȅ,2));}}if(Ϟ>3)Ϟ=3;ϔ.Add(new ͺ("POWR",Ϟ,ͼ+ϕ));ϕ++;int Ϡ=0;if(ώ.
Count>0){foreach(string ϡ in ώ){string Ϣ=ϡ;if(ϡ.Length>23)Ϣ=ϡ.Substring(0,23);Ϣ=Ϣ.ToUpper();Ȅ="NO SPARE "+Ϣ+"!";ϓ.Add(new Â(Ȅ
,Ȅ,3));}Ϡ=3;}if(Ϡ>3)Ϡ=3;ϔ.Add(new ͺ("WEAP",Ϡ,ͼ+ϕ));ϕ++;if(ġ){string ϣ=Ģ;if(ø.Count>0)if(ø[0]!=null)ϣ=(ø[0]as
IMyRadioAntenna).HudText;string Ϥ="";if(ģ<1000)Ϥ=Math.Round(ģ)+"m";else Ϥ=Math.Round(ģ/1000)+"km";ϓ.Add(new Â("Comms ("+Ϥ+"): "+ϣ,
"Antenna(s) are broadcasting at a range of "+Ϥ+" with the message "+ϣ,0));}if(P>0){Ȅ=P+" UNOWNED BLOCKS!";ϓ.Add(new Â(Ȅ,Ȅ+"\nRSM detected "+P+
" terminal blocks on this grid owned by a player with a different faction tag.",3));}if(ɳ>ɴ){int ɹ=(ɳ-ɴ);Ȅ=ɹ+" doors are open";ϓ.Add(new Â(Ȅ,Ȅ,0));}ϓ=ϓ.OrderBy(ł=>ł.ˢ).Reverse().ToList();if(ϓ.Count<1
)ζ+="No warnings\n";else Echo(Ώ+" WARNINGS:");for(int ɒ=0;ɒ<ϓ.Count;ɒ++){ζ+=Έ[ϓ[ɒ].ˢ]+ϓ[ɒ].ˠ+"\n";Echo("-"+Έ[ϓ[ɒ].ˢ]+ϓ[ɒ]
.ˡ);}ζ+="\n";string ϥ=Ì.Ȕ.ToString().ToUpper();string Ϧ=Ì.ȗ.ToString().ToUpper();string ϧ=Ì.Ú.ToString().ToUpper();string
Ϩ=Ì.Ȏ.ToString().ToUpper();string ϩ=Ì.ȋ.ToString().ToUpper();string Ϫ=Ì.ȑ.ToString().ToUpper();if(ϥ.Length>3)ϥ=ϥ.
Substring(0,3);if(Ϧ.Length>3)Ϧ=Ϧ.Substring(0,3);if(ϧ.Length>3)ϧ=ϧ.Substring(0,3);if(Ϩ.Length>3)Ϩ=Ϩ.Substring(0,3);if(ϩ.Length>3)ϩ
=ϩ.Substring(0,3);if(Ϫ.Length>3)Ϫ=Ϫ.Substring(0,3);try{if(Ǹ>0)η+="Epstein   ["+Ϗ(ϫ)+"] "+(ϫ+"% ").PadLeft(5)+ϥ+"\n";if(ǹ>
0)η+="RCS       ["+Ϗ(Ϭ)+"] "+(Ϭ+"% ").PadLeft(5)+Ϧ+"\n";if(ǰ>0)η+="Reactors  ["+Ϗ(ϭ)+"] "+(ϭ+"% ").PadLeft(5)+"    \n";if
(Ǳ>0)η+="Batteries ["+Ϗ(Ϯ)+"] "+(Ϯ+"% ").PadLeft(5)+ϧ+"\n";if(ǳ>0)η+="PDCs      ["+Ϗ(ϯ)+"] "+(ϯ+"% ").PadLeft(5)+Ϩ+"\n";
if(Ǵ>0)η+="Torpedoes ["+Ϗ(ϰ)+"] "+(ϰ+"% ").PadLeft(5)+ϩ+"\n";if(ǵ>0)η+="Railguns  ["+Ϗ(ϱ)+"] "+(ϱ+"% ").PadLeft(5)+Ϫ+"\n";
if(Ƕ>0)η+="H2 Tanks  ["+Ϗ(ϲ)+"] "+(ϲ+"% ").PadLeft(5)+ϧ+"\n";if(Ƿ>0)η+="O2 Tanks  ["+Ϗ(ϳ)+"] "+(ϳ+"% ").PadLeft(5)+ϧ+"\n";
if(Ǻ>0)η+="Gyros     ["+Ϗ(ʊ)+"] "+(ʊ+"% ").PadLeft(5)+"    \n";if(Ǎ>0)η+="Cargo     ["+Ϗ(Ǐ)+"] "+(Ǐ+"% ").PadLeft(5)+
"    \n";if(ǻ>0)η+="Welders   ["+Ϗ(ϴ)+"] "+(ϴ+"% ").PadLeft(5)+"    \n";}catch{}if(Ǳ+ǰ+Ƕ==0)η+=
"Run init when ship is\nfully repaired to display\nsubsystem integrity!"+Ώ;string ϵ="";string Ϸ="";foreach(ͺ ϸ in ϔ){ϵ+=ϸ.Ͳ;Ϸ+=ϸ.ͳ;}int Ϲ=ͼ+2;if(Ϲ>3)Ϲ-=4;ι+=Α+ϵ+"\n"+Β;κ+=Ϸ;if(!W){θ+=Ώ;}else{
if(l)Echo("Building advanced thrust...");string Ϻ="";if(ǡ){Ϻ=Λ+(Math.Round((S/1000000),2)+" Mkg").PadLeft(15)+"\n"+ό+(ν+
" ms").PadLeft(15)+"\n"+Μ+(ο+ύ).PadLeft(15)+"\n"+Ν+(ρ+ύ).PadLeft(15)+"\n"+Ο+((ξ/1000000)+" MN").PadLeft(15)+"\n"+Π+((π/
1000000)+" MN").PadLeft(15)+"\n";}θ+=Ϻ+Ρ+ϐ(ξ,ν,true)+"\n"+Σ+ϐ(π,ν)+"\n";foreach(double ɉ in f){θ+=("Decel ("+(ɉ*100)+"%):").
PadRight(17)+ϐ((float)(ξ*ɉ),ν)+"\n";}θ+=Ώ;}}foreach(ŕ ƨ in É){string ɻ="";Color ɨ=Ì.Ȩ;if(ƨ.ƴ)ɻ+=ι;if(ƨ.Ƶ){ɻ+=κ;ɨ=ͻ;}if(ƨ.ƶ)ɻ+=ζ;
if(ƨ.Ƴ)ɻ+=ε;if(ƨ.Ʒ)ɻ+=γ;if(ƨ.Ƹ)ɻ+=δ;if(ƨ.ƹ)ɻ+=η;if(ƨ.ƺ){ɻ+=θ;W=true;}ƨ.ħ.WriteText(ɻ,false);if(!ũ)ƨ.ħ.FontColor=ɨ;}}void ϻ
(){if(Ŕ.Count>0){foreach(IMyTextPanel ƨ in Ŕ){ƨ.FontColor=Ì.Ȩ;}foreach(ŕ ƨ in É){ƨ.ħ.FontColor=Ì.Ȩ;}}}void v(string ϼ,
string Ͻ){ϼ=ϼ.ToLower();List<IMyTextPanel>Ͼ=new List<IMyTextPanel>();GridTerminalSystem.GetBlocksOfType<IMyTextPanel>(Ć);
foreach(IMyTextPanel ƨ in Ć){if(Ͻ==""||ƨ.CustomName.Contains(Ͻ)){string Ͽ=ƨ.CustomData;if(Ͽ.Contains("hudlcd")&&(ϼ=="off"||ϼ==
"toggle"))ƨ.CustomData=Ͽ.Replace("hudlcd","hudXlcd");if(Ͽ.Contains("hudXlcd")&&(ϼ=="on"||ϼ=="toggle"))ƨ.CustomData=Ͽ.Replace(
"hudXlcd","hudlcd");}}}string Ϗ(double Ѐ){try{int Ё=0;if(Ѐ>0){int Ђ=(int)Ѐ/10;if(Ђ>10)return new string('=',10);if(Ђ!=0)Ё=Ђ;}char
Ѓ=' ';if(Ѐ<10){if(ͼ==0)return" ><    >< ";if(ͼ==1)return"  ><  ><  ";if(ͼ==2)return"   ><><   ";if(ͼ==3)return
"<   ><   >";}string Є=new string('=',Ё);string Ѕ=new string(Ѓ,10-Ё);return Є+Ѕ;}catch{return"# ERROR! #";}}string Ј(string І){
string Ї;string ɧ="";double Ѐ=0;switch(І){case"H2":Ѐ=Math.Round(100*(ϑ/Ƕ));ɧ=Ѐ.ToString()+" %";O=Ѐ;break;case"O2":Ѐ=Math.Round
(100*(υ/Ƿ));ɧ=Ѐ.ToString()+" %";break;case"Battery":Ѐ=Math.Round(100*(ψ/ω));ɧ=Ѐ.ToString()+" %";break;}Ї=Ϗ(Ѐ);return" ["+
Ї+"] "+ɧ.PadLeft(9);}string Ψ(string Љ,int Њ=ͱ){int Ћ=Њ-Љ.Length;int Ќ=Ћ/2+Љ.Length;return Љ.PadLeft(Ќ).PadRight(Њ);}
string ϐ(double Ѝ,double Ў,bool Џ=false){if(Ѝ<=0)return("N/A").PadLeft(15);if(Џ)Ѝ=Ѝ*1.5;double ư=0.5*(Math.Pow(Ў,2)*(S/Ѝ));
double А=Ў/(Ѝ/S);string Б="m";if(ư>1000){Б="km";ư=ư/1000;}return(Math.Round(ư)+Б+" "+Math.Round(А)+"s").PadLeft(15);}void ć(){
foreach(IMyTextPanel ɬ in Ć){ɬ.Enabled=true;}}void ʔ(){foreach(ŕ ƨ in É){ƨ.ħ.Font="Monospace";ƨ.ħ.ContentType=ContentType.
TEXT_AND_IMAGE;if(ƨ.ħ.CustomName.Contains("HUD1")){ƨ.ƴ=true;ƨ.Ƶ=false;ƨ.ƶ=false;ƨ.Ƴ=false;ƨ.Ʒ=false;ƨ.Ƹ=false;ƨ.ƹ=false;ƨ.ƺ=false;Ũ(ƨ,
"hudlcd:-0.55:0.99:0.7");continue;}if(ƨ.ħ.CustomName.Contains("HUD2")){ƨ.ƴ=false;ƨ.Ƶ=false;ƨ.ƶ=true;ƨ.Ƴ=false;ƨ.Ʒ=false;ƨ.Ƹ=false;ƨ.ƹ=false;ƨ.ƺ
=false;Ũ(ƨ,"hudlcd:0.22:0.99:0.55");continue;}if(ƨ.ħ.CustomName.Contains("HUD3")){ƨ.ƴ=false;ƨ.Ƶ=false;ƨ.ƶ=false;ƨ.Ƴ=true;
ƨ.Ʒ=false;ƨ.Ƹ=false;ƨ.ƹ=false;ƨ.ƺ=false;Ũ(ƨ,"hudlcd:0.48:0.99:0.55");continue;}if(ƨ.ħ.CustomName.Contains("HUD4")){ƨ.ƴ=
false;ƨ.Ƶ=false;ƨ.ƶ=false;ƨ.Ƴ=false;ƨ.Ʒ=false;ƨ.Ƹ=false;ƨ.ƹ=true;ƨ.ƺ=false;Ũ(ƨ,"hudlcd:0.74:0.99:0.55");continue;}if(ƨ.ħ.
CustomName.Contains("HUD5")){ƨ.ƴ=false;ƨ.Ƶ=false;ƨ.ƶ=false;ƨ.Ƴ=false;ƨ.Ʒ=true;ƨ.Ƹ=false;ƨ.ƹ=false;ƨ.ƺ=true;Ũ(ƨ,"hudlcd:0.75:0:.54"
);continue;}if(ƨ.ħ.CustomName.Contains("HUD6")){ƨ.ƴ=false;ƨ.Ƶ=true;ƨ.ƶ=false;ƨ.Ƴ=false;ƨ.Ʒ=false;ƨ.Ƹ=false;ƨ.ƹ=false;ƨ.ƺ=
false;Ũ(ƨ,"hudlcd:-0.55:0.99:0.7");continue;}}bool В=false;foreach(IMyTextPanel ɬ in Ć){if(ɬ==null)continue;if(!В&&(ɬ.
CustomName.Contains(ǝ)||ɬ.CustomName.ToUpper().Contains(Ǟ))){В=true;ɬ.CustomData="hudlcd:-0.52:-0.7:0.52";continue;}}}bool ϙ;bool
Г;void Þ(bool ʋ,bool ʌ){ϙ=false;foreach(IMyConveyorSorter Д in Ý){if(Д!=null&&Д.IsFunctional){ϙ=true;if(ʌ)Д.Enabled=ʋ;if(
!Г){MyDetectedEntityInfo?Ж=Ĕ.Е(Д);if(Ж.HasValue){string Ż=Ж.Value.Name;if(Ż!=null&&Ż!=""){if(l)Echo(
"At least one lidar  has a target!");Г=true;}}}}}if(!ϙ){Г=true;}}void И(ț Ň){if(Ň==ț.NoChange)return;foreach(IMyReflectorLight З in Ś){if(З==null)continue;
if(Ň==ț.Off)З.Enabled=false;else{З.Enabled=true;if(Ň==ț.OnMax)З.Radius=9999;}}}void К(Ȟ Ň,Color ɨ){if(Ň==Ȟ.NoChange)return
;foreach(IMyLightingBlock Й in Ŗ){if(Й==null)continue;if(Ň==Ȟ.Off)Й.Enabled=false;else Й.Enabled=true;if(Ň!=Ȟ.
OnNoColourChange)Й.SetValue("Color",ɨ);}}void Л(Ȟ Ň,Color ɨ){if(Ň==Ȟ.NoChange)return;foreach(IMyLightingBlock Й in ŗ){if(Й==null)
continue;if(Ň==Ȟ.Off)Й.Enabled=false;else Й.Enabled=true;if(Ň!=Ȟ.OnNoColourChange)Й.SetValue("Color",ɨ);}}Color М=new Color(255,
0,0,255);Color Н=new Color(255,0,0,255);Color О=new Color(0,255,0,255);void Р(Ȟ Ň){if(Ň==Ȟ.NoChange)return;foreach(
IMyLightingBlock Й in Ř){П(Й,Ň,Н);}foreach(IMyLightingBlock Й in ř){П(Й,Ň,О);}}void П(IMyLightingBlock Й,Ȟ Ň,Color ɨ){if(Й==null)return;
if(Ň==Ȟ.Off){Й.Enabled=false;Й.SetValue("Color",М);}else{Й.Enabled=true;if(Ň!=Ȟ.OnNoColourChange)Й.SetValue("Color",ɨ);}}
int Ϝ=0;void ā(bool ʋ,bool ʌ){Ϝ=0;foreach(IMyAirVent С in Ā){if(С!=null){if(ʌ)С.Enabled=ʋ;if(С.CanPressurize)Ϝ++;}}}void ċ(
bool ʋ){foreach(IMyShipConnector Т in Ċ){if(Т!=null)Т.Enabled=ʋ;}}void č(bool ʋ){foreach(IMyCameraBlock У in Č){if(У!=null)У
.Enabled=ʋ;}}void ď(bool ʋ){foreach(IMySensorBlock Ф in Ď){if(Ф!=null)Ф.Enabled=ʋ;}}void ĉ(){N=true;foreach(
IMyTerminalBlock Х in Ĉ){Х.ApplyAction("OnOff_On");if(Х.IsFunctional)N=false;}}bool Ц=false;List<string>Ч=new List<string>();bool Ш=
false;List<string>Щ=new List<string>();void Э(string h,string Ъ){bool ˁ=false;List<IMyProgrammableBlock>Ы=new List<
IMyProgrammableBlock>();try{if(Ъ=="EFC")Ы=Œ;else if(Ъ=="NavOS")Ы=œ;foreach(IMyProgrammableBlock Ь in Ы){if(Ь==null||!Ь.Enabled)continue;ˁ=(Ь
as IMyProgrammableBlock).TryRun(h);if(l)Echo("Ran "+h+" on "+Ь.CustomName+" successfully.");Á.Add(new Â("Ran "+Ъ+" ("+h+
")","Ran "+Ъ+" ("+h+")",0));if(Ъ=="EFC")Ц=true;else if(Ъ=="NavOS")Ш=true;break;}}catch(Exception ė){Á.Add(new Â(Ъ+
" command errored!",Ъ+" command "+h+" errored!\n"+ė.Message,3));}}void Ю(string h,string Ъ){if(Ъ=="EFC"){if(Œ.Count<1)return;if(Ц){Ч.Add(h)
;return;}}if(Ъ=="NavOS"){if(œ.Count<1)return;if(Ш){Щ.Add(h);return;}}Э(h,Ъ);}void ß(){if(Ч.Count>0&&!Ц){Э(Ч[0],"EFC");Ч.
RemoveAt(0);}if(Щ.Count>0&&!Ш){Э(Щ[0],"NavOS");Щ.RemoveAt(0);}Ц=false;Ш=false;}int ǳ=0;double Я=0;double ϯ=0;void ð(){Я=0;
foreach(IMyTerminalBlock б in î){а(б,Ì.Ȏ!=ȏ.Off&&Ì.Ȏ!=ȏ.MinDefence);}foreach(IMyTerminalBlock б in ï){а(б,Ì.Ȏ!=ȏ.Off);}ϯ=Math.
Round(100*(Я/ǳ));}void а(IMyTerminalBlock в,bool ʋ){if(в!=null&&в.IsFunctional){Я++;(в as IMyConveyorSorter).Enabled=ʋ;}}void
г(ȏ Ň){if(Ň==ȏ.NoChange)return;foreach(IMyTerminalBlock б in î){if(б!=null&б.IsFunctional){switch(Ň){case ȏ.Off:case ȏ.
MinDefence:(б as IMyConveyorSorter).Enabled=false;break;case ȏ.AllDefence:(б as IMyConveyorSorter).Enabled=true;if(ǔ){try{б.
SetValue("WC_FocusFire",false);б.SetValue("WC_Projectiles",true);б.SetValue("WC_Grids",true);б.SetValue("WC_LargeGrid",false);б.
SetValue("WC_SmallGrid",true);б.SetValue("WC_SubSystems",true);б.SetValue("WC_Biologicals",true);Ǉ(б);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;case ȏ.Offence:(б as IMyConveyorSorter).Enabled=true;if(ǔ){try{б.SetValue("WC_FocusFire",false);б.SetValue(
"WC_Projectiles",true);б.SetValue("WC_Grids",true);б.SetValue("WC_LargeGrid",true);б.SetValue("WC_SmallGrid",true);б.SetValue(
"WC_SubSystems",true);б.SetValue("WC_Biologicals",true);Ǉ(б);}catch{Echo("Strange PDC config error! Possible WC crash!");}}break;}}}
foreach(IMyTerminalBlock б in ï){if(б!=null&б.IsFunctional){switch(Ň){case ȏ.Off:(б as IMyConveyorSorter).Enabled=false;break;
case ȏ.MinDefence:case ȏ.AllDefence:case ȏ.Offence:(б as IMyConveyorSorter).Enabled=true;if(ǔ){try{б.SetValue("WC_FocusFire"
,false);б.SetValue("WC_Projectiles",true);б.SetValue("WC_Grids",true);б.SetValue("WC_LargeGrid",false);б.SetValue(
"WC_SmallGrid",true);б.SetValue("WC_SubSystems",true);б.SetValue("WC_Biologicals",true);ǆ(б);}catch{Echo(
"Strange PDC config error! Possible WC crash!");}}break;}}}}double σ;void Ù(Ȫ Ň){σ=0;д();е(Ň);}double ω=0;double Ǳ=0;double ψ=0;double Ϯ=0;double ǲ=0;void е(Ȫ Ň){ω=0;
ψ=0;double ж=0;foreach(IMyBatteryBlock з in Ø){if(з!=null&&з.IsFunctional){ψ+=з.CurrentStoredPower;ω+=з.MaxStoredPower;ж
+=з.MaxOutput;з.Enabled=true;if(Ň==Ȫ.ManagedDischarge){if(и||й<=0)з.ChargeMode=ChargeMode.Discharge;else з.ChargeMode=
ChargeMode.Recharge;}}}if(ǲ<=0)ǲ=ω;if(ǲ>0)Ϯ=Math.Round(100*(ω/ǲ));else Ϯ=0;σ+=ж;}void ʗ(){Ǳ=0;ǲ=0;foreach(IMyBatteryBlock з in Ø){
ChargeMode к=з.ChargeMode;з.ChargeMode=ChargeMode.Auto;Ǳ+=з.MaxOutput;з.ChargeMode=к;ǲ+=з.MaxStoredPower;}}void л(Ȫ Ň){if(Ň==Ȫ.
NoChange)return;foreach(IMyBatteryBlock з in Ø){if(з!=null&&!з.Closed&&з.IsFunctional){з.Enabled=true;if(Ň==Ȫ.Auto)з.ChargeMode=
ChargeMode.Auto;else if(Ň==Ȫ.StockpileRecharge)з.ChargeMode=ChargeMode.Recharge;else if(Ň==Ȫ.Discharge)з.ChargeMode=ChargeMode.
Discharge;}}}double ǰ=0;double й=0;double ϭ=0;int ϟ=0;void д(){й=0;ϟ=0;foreach(IMyReactor м in Ö){if(м!=null&&!м.Closed&&м.
IsFunctional){м.Enabled=true;if(ʽ(м))ϟ++;else й+=м.MaxOutput;}}ϭ=Math.Round(100*(й/ǰ));σ+=й;}void ʘ(){ǰ=0;foreach(IMyReactor м in Ö)
{ǰ+=м.MaxOutput;}}void º(IMyProjector À){À.CustomData=À.ProjectionOffset.X+"\n"+À.ProjectionOffset.Y+"\n"+À.
ProjectionOffset.Z+"\n"+À.ProjectionRotation.X+"\n"+À.ProjectionRotation.Y+"\n"+À.ProjectionRotation.Z+"\n";}void Ã(IMyProjector À){if(!
À.IsFunctional)return;try{string[]н=À.CustomData.Split('\n');Vector3I о=new Vector3I(int.Parse(н[0]),int.Parse(н[1]),int.
Parse(н[2]));Vector3I п=new Vector3I(int.Parse(н[3]),int.Parse(н[4]),int.Parse(н[5]));À.Enabled=true;À.ProjectionOffset=о;À.
ProjectionRotation=п;À.UpdateOffsetAndRotation();}catch{if(l)Echo("Failed to load projector position for "+À.Name);}}int ǵ=0;double р=0;
double ϱ=0;bool и=false;void Õ(){и=false;р=0;foreach(IMyTerminalBlock с in Ó){if(с!=null&&с.IsFunctional){р++;(с as
IMyConveyorSorter).Enabled=Ì.ȑ!=Ȓ.Off;if(!и){MyDetectedEntityInfo?т=Ĕ.Е(с);if(т.HasValue){string Ż=т.Value.Name;if(Ż!=null&&Ż!=""){if(l)
Echo("At least one rail has a target!");и=true;}}}}}foreach(IMyTerminalBlock с in Ô){if(с!=null&&с.IsFunctional){р++;(с as
IMyConveyorSorter).Enabled=Ì.ȑ!=Ȓ.Off;}}ϱ=Math.Round(100*(р/ǵ));}void х(Ȓ Ň){if(Ň==Ȓ.NoChange)return;foreach(IMyTerminalBlock ф in Ó){у(ф
,Ň,false);}foreach(IMyTerminalBlock ф in Ô){у(ф,Ň,true);}}void у(IMyTerminalBlock ф,Ȓ Ň,bool Ʀ){if(ф!=null&ф.IsFunctional
){if(Ň==Ȓ.Off){(ф as IMyConveyorSorter).Enabled=false;}else{(ф as IMyConveyorSorter).Enabled=true;if(!Ʀ){if(ǔ){ф.SetValue
("WC_Grids",true);ф.SetValue("WC_LargeGrid",true);ф.SetValue("WC_SmallGrid",true);ф.SetValue("WC_SubSystems",true);Ǉ(ф);}
if(Ǖ){if(Ň==Ȓ.OpenFire){Ǌ(ф);}else{ǉ(ф);}}}}}}class ц{public string Ż="";public string Ϙ="";}List<ц>ϖ=new List<ц>();void ÿ
(){ϖ.Clear();foreach(IMyTerminalBlock ч in þ){if(ч==null)continue;if(ш(ч))break;}}bool ш(IMyTerminalBlock ч){string щ;try
{щ=ч.CustomInfo;}catch(Exception ė){if(l)Echo("Failed to read core info!\n"+ė.Message);return false;}if(string.
IsNullOrEmpty(щ))return false;int ɟ=щ.IndexOf("Punishments:");if(ɟ<0)return false;string[]ъ=щ.Substring(ɟ).Split('\n');ц ы=null;for(
int ɒ=1;ɒ<ъ.Length;ɒ++){string ь=ъ[ɒ].TrimEnd();string Ʊ=ь.Trim();if(Ʊ.Length==0)continue;if(ь.Length==Ʊ.Length)break;if(Ʊ[
0]=='-'){if(ы==null)continue;string Ä=Ʊ.Substring(1).Trim();if(Ä.Length==0)continue;if(ы.Ϙ.Length>0)ы.Ϙ+="\n";ы.Ϙ+=Ä;
continue;}ы=null;int э=Ʊ.IndexOf(':');if(э<1)continue;string Ŭ=Ʊ.Substring(0,э).Trim();string ɓ=Ʊ.Substring(э+1).Trim();if(Ŭ.
Length==0)continue;if(ɓ.ToUpper()!="YES")continue;ы=new ц();ы.Ż=Ŭ;ϖ.Add(ы);}return true;}class ǽ{public string ɍ="";public Ȍ ȋ
;public ȏ Ȏ;public Ȓ ȑ;public ȕ Ȕ;public Ș ȗ;public ț Ț;public Ȟ ȝ;public Color Ƞ;public Ȟ Ȣ;public Color Ȥ;public Ȟ Ȧ;
public Color Ȩ;public Ȫ Ú;public int Ȭ;public Î Ȯ;public ȱ Ȱ;public Î ȳ;public ȶ ȵ;public Î Í;public Ⱥ ȹ;public Î ȼ;public ɀ ȿ
;}string Ě="N/A";ǽ Ì;Ȍ ȍ=Ȍ.On;ȏ Ȑ=ȏ.Offence;Ȓ ȓ=Ȓ.OpenFire;ȕ Ȗ=ȕ.On;Ș ș=Ș.On;ț Ȝ=ț.On;Ȟ ȟ=Ȟ.On;Color ȡ=new Color(33,144,
255,255);Ȟ ȣ=Ȟ.On;Color ȥ=new Color(255,214,170,255);Ȟ ȧ=Ȟ.On;Color ȩ=new Color(33,144,255,255);Ȫ ȫ=Ȫ.Auto;int ȭ=-1;Î ȯ=Î.
NoChange;ȱ Ȳ=ȱ.NoChange;Î ȴ=Î.NoChange;ȶ ȷ=ȶ.KeepFull;Î ȸ=Î.On;Ⱥ Ȼ=Ⱥ.NoChange;Î Ƚ=Î.NoChange;ɀ Ɂ=ɀ.NoChange;void t(string Ɍ){ǽ ȃ
;if(!ɂ.TryGetValue(Ɍ,out ȃ)){Á.Add(new Â("NO SUCH STANCE!",
"A command was ignored because the provided stance doens't exist. Stance names are case sensitive!",3));return;}if(l)Echo("Setting stance '"+Ɍ+"'.");if(Ì.Ȱ==ȱ.Abort){Ю("Off","EFC");Ю("Abort","NavOS");}Ì=ȃ;Ě=Ɍ;ɤ();if(l)
Echo("Setting "+Ó.Count+" railguns to "+Ì.ȑ);х(Ì.ȑ);if(l)Echo("Setting "+å.Count+" torpedoes to "+Ì.ȋ);ю(Ì.ȋ);if(l)Echo(
"Setting "+î.Count+" _normalPdcs, "+ï.Count+" defence _normalPdcs to "+Ì.Ȏ);г(Ì.Ȏ);if(l)Echo("Setting "+Û.Count+" epsteins, "+Ő.
Count+" chems"+" to "+Ì.Ȕ);я(Ì.Ȕ,Ì.ȗ);if(l)Echo("Setting "+ì.Count+" rcs, "+ő.Count+" atmos"+" to "+Ì.ȗ);ѐ(Ì.ȗ);if(l)Echo(
"Setting "+Ø.Count+" batteries to = "+Ì.Ú);л(Ì.Ú);if(l)Echo("Setting "+é.Count+" H2 tanks to stockpile = "+Ì.Ú);ё(Ì.Ú);if(l)Echo(
"Setting "+õ.Count+" O2 tanks to stockpile = "+Ì.Ú);ђ(Ì.Ú);if(Ǡ){if(l)Echo(
"No lighting was set because lighting control is disabled.");}else{if(l)Echo("Setting "+Ś.Count+" spotlights to "+Ì.Ț);И(Ì.Ț);if(l)Echo("Setting "+Ŗ.Count+" exterior lights to "+Ì
.ȝ);К(Ì.ȝ,Ì.Ƞ);if(l)Echo("Setting "+ŗ.Count+" exterior lights to "+Ì.Ȣ);Л(Ì.Ȣ,Ì.Ȥ);if(l)Echo("Setting "+Ř.Count+
" port nav lights, "+ř.Count+" starboard nav lights to "+Ì.Ȧ);Р(Ì.Ȧ);}if(l)Echo("Setting "+Ă.Count+" aux block to "+Ì.ȳ);Ō(Ì.ȳ);if(l)Echo(
"Setting "+ō.Count+" hangar doors units to "+Ì.ȹ);ʄ(Ì.ȹ);if(l)Echo("Setting "+ü.Count+" hangar pads to "+Ì.ȼ);ʒ(Ì.ȼ);if(Ì.ȑ==Ȓ.
OpenFire){if(l)Echo("Setting "+à.Count+" doors to locked because we are in combat (rails set to open fire).");x("locked","");}if
(l)Echo("Setting "+Ŕ.Count+" colour sync Lcds.");ϻ();if(Ì.Ȭ>0){Ю("Set Burn "+Ì.Ȭ,"EFC");float ѓ=Convert.ToSingle(Ì.Ȭ)/100
;Ю("ThrustRatio "+ѓ,"NavOS");}if(Ì.Ȯ==Î.On)Ю("Boost On","EFC");else if(Ì.Ȯ==Î.Off)Ю("Boost Off","EFC");if(l)Echo(
"Finished setting stance.");}double ϒ=0;double Ƕ=0;double ϑ=0;double ϲ=0;void ê(){ϑ=0;ϒ=0;foreach(IMyGasTank є in é){if(є.IsFunctional){є.Enabled=
true;ϒ+=є.Capacity;ϑ+=(є.Capacity*є.FilledRatio);}}ϲ=Math.Round(100*(ϒ/Ƕ));}void ʙ(){Ƕ=0;foreach(IMyGasTank є in é){if(є!=
null)Ƕ+=є.Capacity;}}void ё(Ȫ Ň){if(Ň==Ȫ.NoChange)return;foreach(IMyGasTank є in é){if(є==null)continue;є.Enabled=true;if(Ň
==Ȫ.StockpileRecharge)є.Stockpile=true;else є.Stockpile=false;}}double φ=0;double υ=0;double Ƿ=0;double ϳ=0;void ö(){υ=0;φ
=0;foreach(IMyGasTank є in õ){if(є.IsFunctional){є.Enabled=true;φ+=є.Capacity;υ+=(є.Capacity*є.FilledRatio);}}ϳ=Math.
Round(100*(φ/Ƿ));}void ʚ(){Ƿ=0;foreach(IMyGasTank є in õ){if(є!=null)Ƿ+=є.Capacity;}}void ђ(Ȫ Ň){if(Ň==Ȫ.NoChange)return;
foreach(IMyGasTank є in õ){if(є==null)continue;є.Enabled=true;if(Ň==Ȫ.StockpileRecharge)є.Stockpile=true;else є.Stockpile=false
;}}float ξ;float π;float Ǹ;double ϫ;void Ü(){float ѕ=0;float і=0;float ї=0;float ј=0;foreach(IMyThrust љ in Û){if(љ!=null
&&љ.IsFunctional){ѕ+=љ.MaxThrust;ї+=љ.CurrentThrust;if(љ.Enabled){і+=љ.MaxThrust;ј+=љ.CurrentThrust;}}}ϫ=Math.Round(100*(ѕ
/Ǹ));if(і==0){ξ=ѕ;π=ї;}else{ξ=і;π=ј;}}void ʕ(){Ǹ=0;foreach(IMyThrust љ in Û){if(љ!=null)Ǹ+=љ.MaxThrust;}}void я(ȕ Ň,Ș њ){
if(Ň==ȕ.NoChange)return;foreach(IMyThrust љ in Û){ћ(љ,Ň,њ);}foreach(IMyThrust љ in Ő){ћ(љ,Ň,њ,true);}}void ћ(IMyThrust љ,ȕ
Ň,Ș њ,bool ќ=false){bool ѝ=љ.CustomName.Contains(ǜ);if(ѝ){if(њ!=Ș.Off&&њ!=Ș.AtmoOnly)љ.Enabled=true;else љ.Enabled=false;
}else{bool ў=љ.CustomName.Contains(Ǜ);if((Ň==ȕ.On)||(Ň==ȕ.Minimum&&ў)||(Ň==ȕ.EpsteinOnly&&!ќ)||(Ň==ȕ.ChemOnly&&ќ)){љ.
Enabled=true;}else{љ.Enabled=false;}}}float џ;float ǹ;double Ϭ;void í(){џ=0;foreach(IMyThrust љ in ì){if(љ!=null&&љ.
IsFunctional){џ+=љ.MaxThrust;}}Ϭ=Math.Round(100*(џ/ǹ));}void ʖ(){ǹ=0;foreach(IMyThrust љ in ì){if(љ!=null)ǹ+=љ.MaxThrust;}}void ѐ(Ș
Ň){if(Ň==Ș.NoChange)return;foreach(IMyThrust љ in ì){if(љ!=null)Ѡ(љ,Ň);}foreach(IMyThrust љ in ő){if(љ!=null)Ѡ(љ,Ň,true);
}}void Ѡ(IMyThrust љ,Ș Ň,bool ѡ=false){bool Ѣ=љ.GridThrustDirection==Vector3I.Backward;bool ѣ=љ.GridThrustDirection==
Vector3I.Forward;if((Ň==Ș.On)||(Ň==Ș.ForwardOff&&!Ѣ)||(Ň==Ș.ReverseOff&&!ѣ)||(Ň==Ș.RcsOnly&&!ѡ)||(Ň==Ș.AtmoOnly&&ѡ)){љ.Enabled=
true;}else{љ.Enabled=false;}}int Ǵ=0;double Ѥ=0;double ϰ=0;void æ(){Ѥ=0;foreach(IMyTerminalBlock ѥ in å){if(ѥ!=null&&ѥ.
IsFunctional){Ѥ++;(ѥ as IMyConveyorSorter).Enabled=(Ì.ȋ==Ȍ.On||(Ì.ȋ==Ȍ.OnWhenLidarTarget&&Г));if(Ĩ){string ʺ=Ĕ.Ѧ(ѥ,0);int ϡ=ʻ(ʺ);if(
l)Echo("Launcher "+ѥ.CustomName+" needs "+ʺ+"("+ϡ+")");ʴ(ѥ,ϡ);}}}ϰ=Math.Round(100*(Ѥ/Ǵ));}void ю(Ȍ Ň){if(Ň==Ȍ.NoChange)
return;foreach(IMyTerminalBlock ѥ in å){if(ѥ!=null&ѥ.IsFunctional){if(Ň==Ȍ.OnWhenLidarTarget){}bool ѧ=(Ň==Ȍ.On||(Ň==Ȍ.
OnWhenLidarTarget&&Г));if(!ѧ){(ѥ as IMyConveyorSorter).Enabled=false;}else{(ѥ as IMyConveyorSorter).Enabled=true;if(ǔ){ѥ.SetValue(
"WC_FocusFire",true);ѥ.SetValue("WC_Grids",true);ѥ.SetValue("WC_LargeGrid",true);ѥ.SetValue("WC_SmallGrid",false);ѥ.SetValue(
"WC_FocusFire",true);ѥ.SetValue("WC_SubSystems",true);Ǉ(ѥ);}}}}}ĕ Ĕ;public class ĕ{Action<ICollection<MyDefinitionId>>Ѩ;Action<
ICollection<MyDefinitionId>>ѩ;Action<ICollection<MyDefinitionId>>Ѫ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<string,
int>,bool>ѫ;Func<long,MyTuple<bool,int,int>>Ѭ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,IDictionary<
MyDetectedEntityInfo,float>>ѭ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>>Ѯ;Func<
long,int,MyDetectedEntityInfo>ѯ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ѱ;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,MyDetectedEntityInfo>ѱ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int>Ѳ;Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,bool,int>ѳ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool,bool,int>Ѵ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
int,bool,bool,bool>ѵ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,float>Ѷ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
ICollection<string>,int,bool>ѷ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,ICollection<string>,int>Ѹ;Action<Sandbox.ModAPI.Ingame
.IMyTerminalBlock,float>ѹ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ѻ;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,long,int,MyTuple<bool,Vector3D?>>ѻ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,int,bool>Ѽ;Func<Sandbox.ModAPI.
Ingame.IMyTerminalBlock,long,int,Vector3D?>ѽ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,float>Ѿ;Func<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,float>ѿ;Func<MyDefinitionId,float>Ҁ;Func<long,bool>ҁ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,bool>Ҋ;Func<long,float
>ҋ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>Ҍ;Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,string>ҍ;
Action<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,bool>>Ҏ;Action<Sandbox.ModAPI.Ingame.
IMyTerminalBlock,int,Action<long,int,ulong,long,Vector3D,bool>>ҏ;Func<ulong,MyTuple<Vector3D,Vector3D,float,float,long,string>>Ґ;Func<
long,float>ґ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long>Ғ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>ғ;
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,Matrix>Ҕ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,long,bool,bool,bool>ҕ;
Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,int,MyTuple<Vector3D,Vector3D>>Җ;Func<Sandbox.ModAPI.Ingame.IMyTerminalBlock,
MyTuple<bool,bool>>җ;public bool Ė(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҙ){var ҙ=Ҙ.GetProperty("WcPbAPI")?.As<
IReadOnlyDictionary<string,Delegate>>().GetValue(Ҙ);if(ҙ==null)throw new Exception("WcPbAPI failed to activate");return Қ(ҙ);}public bool Қ
(IReadOnlyDictionary<string,Delegate>қ){if(қ==null)return false;Ҝ(қ,"GetCoreWeapons",ref Ѩ);Ҝ(қ,"GetCoreStaticLaunchers",
ref ѩ);Ҝ(қ,"GetCoreTurrets",ref Ѫ);Ҝ(қ,"GetBlockWeaponMap",ref ѫ);Ҝ(қ,"GetProjectilesLockedOn",ref Ѭ);Ҝ(қ,
"GetSortedThreats",ref ѭ);Ҝ(қ,"GetObstructions",ref Ѯ);Ҝ(қ,"GetAiFocus",ref ѯ);Ҝ(қ,"SetAiFocus",ref Ѱ);Ҝ(қ,"GetWeaponTarget",ref ѱ);Ҝ(қ,
"SetWeaponTarget",ref Ѳ);Ҝ(қ,"FireWeaponOnce",ref ѳ);Ҝ(қ,"ToggleWeaponFire",ref Ѵ);Ҝ(қ,"IsWeaponReadyToFire",ref ѵ);Ҝ(қ,
"GetMaxWeaponRange",ref Ѷ);Ҝ(қ,"GetTurretTargetTypes",ref ѷ);Ҝ(қ,"SetTurretTargetTypes",ref Ѹ);Ҝ(қ,"SetBlockTrackingRange",ref ѹ);Ҝ(қ,
"IsTargetAligned",ref Ѻ);Ҝ(қ,"IsTargetAlignedExtended",ref ѻ);Ҝ(қ,"CanShootTarget",ref Ѽ);Ҝ(қ,"GetPredictedTargetPosition",ref ѽ);Ҝ(қ,
"GetHeatLevel",ref Ѿ);Ҝ(қ,"GetCurrentPower",ref ѿ);Ҝ(қ,"GetMaxPower",ref Ҁ);Ҝ(қ,"HasGridAi",ref ҁ);Ҝ(қ,"HasCoreWeapon",ref Ҋ);Ҝ(қ,
"GetOptimalDps",ref ҋ);Ҝ(қ,"GetActiveAmmo",ref Ҍ);Ҝ(қ,"SetActiveAmmo",ref ҍ);Ҝ(қ,"MonitorProjectile",ref Ҏ);Ҝ(қ,"UnMonitorProjectile",
ref ҏ);Ҝ(қ,"GetProjectileState",ref Ґ);Ҝ(қ,"GetConstructEffectiveDps",ref ґ);Ҝ(қ,"GetPlayerController",ref Ғ);Ҝ(қ,
"GetWeaponAzimuthMatrix",ref ғ);Ҝ(қ,"GetWeaponElevationMatrix",ref Ҕ);Ҝ(қ,"IsTargetValid",ref ҕ);Ҝ(қ,"GetWeaponScope",ref Җ);Ҝ(қ,"IsInRange",ref
җ);return true;}void Ҝ<ҝ>(IReadOnlyDictionary<string,Delegate>қ,string Ŭ,ref ҝ Ҟ)where ҝ:class{if(қ==null){Ҟ=null;return;
}Delegate ҟ;if(!қ.TryGetValue(Ŭ,out ҟ))throw new Exception(
$"{GetType().Name} :: Couldn't find {Ŭ} delegate of type {typeof(ҝ)}");Ҟ=ҟ as ҝ;if(Ҟ==null)throw new Exception(
$"{GetType().Name} :: Delegate {Ŭ} is not type {typeof(ҝ)}, instead it's: {ҟ.GetType()}");}public void ҡ(ICollection<MyDefinitionId>Ҡ)=>Ѩ?.Invoke(Ҡ);public void Ң(ICollection<MyDefinitionId>Ҡ)=>ѩ?.Invoke(Ҡ);
public void ң(ICollection<MyDefinitionId>Ҡ)=>Ѫ?.Invoke(Ҡ);public bool ҥ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҥ,IDictionary<
string,int>Ҡ)=>ѫ?.Invoke(Ҥ,Ҡ)??false;public MyTuple<bool,int,int>ҧ(long Ҧ)=>Ѭ?.Invoke(Ҧ)??new MyTuple<bool,int,int>();public
void ҩ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҩ,IDictionary<MyDetectedEntityInfo,float>Ҡ)=>ѭ?.Invoke(Ҩ,Ҡ);public void Ҫ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҩ,ICollection<Sandbox.ModAPI.Ingame.MyDetectedEntityInfo>Ҡ)=>Ѯ?.Invoke(Ҩ,Ҡ);public
MyDetectedEntityInfo?ҭ(long ҫ,int Ҭ=0)=>ѯ?.Invoke(ҫ,Ҭ);public bool ү(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ҩ,long Ү,int Ҭ=0)=>Ѱ?.Invoke(Ҩ,Ү
,Ҭ)??false;public MyDetectedEntityInfo?Е(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ=0)=>ѱ?.Invoke(Ұ,ұ);public void Ҳ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,long Ү,int ұ=0)=>Ѳ?.Invoke(Ұ,Ү,ұ);public void Ҵ(Sandbox.ModAPI.Ingame.IMyTerminalBlock
Ұ,bool ҳ=true,int ұ=0)=>ѳ?.Invoke(Ұ,ҳ,ұ);public void Ҷ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,bool ҵ,bool ҳ,int ұ=0)=>Ѵ
?.Invoke(Ұ,ҵ,ҳ,ұ);public bool ҹ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ=0,bool ҷ=true,bool Ҹ=false)=>ѵ?.Invoke(Ұ,ұ
,ҷ,Ҹ)??false;public float Һ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ)=>Ѷ?.Invoke(Ұ,ұ)??0f;public bool һ(Sandbox.
ModAPI.Ingame.IMyTerminalBlock Ұ,IList<string>Ҡ,int ұ=0)=>ѷ?.Invoke(Ұ,Ҡ,ұ)??false;public void Ҽ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ұ,IList<string>Ҡ,int ұ=0)=>Ѹ?.Invoke(Ұ,Ҡ,ұ);public void ҽ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,float ĥ)=>ѹ?.Invoke(
Ұ,ĥ);public bool ҿ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,long Ҿ,int ұ)=>Ѻ?.Invoke(Ұ,Ҿ,ұ)??false;public MyTuple<bool,
Vector3D?>Ӏ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,long Ҿ,int ұ)=>ѻ?.Invoke(Ұ,Ҿ,ұ)??new MyTuple<bool,Vector3D?>();public bool
Ӂ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,long Ҿ,int ұ)=>Ѽ?.Invoke(Ұ,Ҿ,ұ)??false;public Vector3D?ӂ(Sandbox.ModAPI.Ingame
.IMyTerminalBlock Ұ,long Ҿ,int ұ)=>ѽ?.Invoke(Ұ,Ҿ,ұ)??null;public float Ӄ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ)=>Ѿ?.
Invoke(Ұ)??0f;public float ӄ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ)=>ѿ?.Invoke(Ұ)??0f;public float ӆ(MyDefinitionId Ӆ)=>Ҁ?.
Invoke(Ӆ)??0f;public bool ӈ(long Ӈ)=>ҁ?.Invoke(Ӈ)??false;public bool Ӊ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ)=>Ҋ?.Invoke(Ұ)
??false;public float ӊ(long Ӈ)=>ҋ?.Invoke(Ӈ)??0f;public string Ѧ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ)=>Ҍ?.
Invoke(Ұ,ұ)??null;public void ӌ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ,string Ӌ)=>ҍ?.Invoke(Ұ,ұ,Ӌ);public void Ӎ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ,Action<long,int,ulong,long,Vector3D,bool>ŉ)=>Ҏ?.Invoke(Ұ,ұ,ŉ);public void ӎ(
Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ,Action<long,int,ulong,long,Vector3D,bool>ŉ)=>ҏ?.Invoke(Ұ,ұ,ŉ);public MyTuple<
Vector3D,Vector3D,float,float,long,string>Ӑ(ulong ӏ)=>Ґ?.Invoke(ӏ)??new MyTuple<Vector3D,Vector3D,float,float,long,string>();
public float ӑ(long Ӈ)=>ґ?.Invoke(Ӈ)??0f;public long Ӓ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ)=>Ғ?.Invoke(Ұ)??-1;public
Matrix ǈ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ)=>ғ?.Invoke(Ұ,ұ)??Matrix.Zero;public Matrix ӓ(Sandbox.ModAPI.Ingame.
IMyTerminalBlock Ұ,int ұ)=>Ҕ?.Invoke(Ұ,ұ)??Matrix.Zero;public bool ӗ(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,long Ӕ,bool ӕ,bool Ӗ)=>ҕ?.
Invoke(Ұ,Ӕ,ӕ,Ӗ)??false;public MyTuple<Vector3D,Vector3D>Ә(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ұ,int ұ)=>Җ?.Invoke(Ұ,ұ)??new
MyTuple<Vector3D,Vector3D>();public MyTuple<bool,bool>ә(Sandbox.ModAPI.Ingame.IMyTerminalBlock Ǆ)=>җ?.Invoke(Ǆ)??new MyTuple<
bool,bool>();}int ǻ=0;double Ӛ=0;double ϴ=0;void ą(){Ӛ=0;foreach(IMyTerminalBlock ӛ in Ą){if(ӛ!=null&&ӛ.IsFunctional)Ӛ++;}ϴ=
Math.Round(100*(Ӛ/ǻ));}enum Î{
Off, On, NoChange
}enum Ȟ{
Off, On, NoChange, OnNoColourChange
}enum ȏ{
Off, MinDefence, AllDefence, Offence, AllOnOnly, NoChange
}enum Ȓ{
Off, HoldFire, OpenFire, NoChange
}enum ȕ{
Off, On, Minimum, EpsteinOnly, ChemOnly, NoChange
}enum Ș{
Off, On, ForwardOff, ReverseOff, RcsOnly, AtmoOnly, NoChange
}enum ț{
On, Off, OnMax, NoChange
}enum Ȫ{
Auto, StockpileRecharge, Discharge, ManagedDischarge, NoChange
}enum ȱ{
Abort, NoChange
}enum ȶ{
Off, On, FillWhenLow, KeepFull,
}enum Ⱥ{
Closed, Open, NoChange
}enum ɀ{
On, Off, NoChange
}enum Ȍ{
Off, On, NoChange, OnWhenLidarTarget
}
}
internal sealed class A{public double Ĝ{get;private set;}double ӟ{get{double ӝ=Ӝ[0];for(int ɒ=1;ɒ<Ӟ;ɒ++){ӝ+=Ӝ[ɒ];}return
(ӝ/Ӟ);}}public double ĝ{get{double Ӡ=Ӝ[0];for(int ɒ=1;ɒ<Ӟ;ɒ++){if(Ӝ[ɒ]>Ӡ){Ӡ=Ӝ[ɒ];}}return Ӡ;}}public double ӡ{get;private
set;}public double ӣ{get{double Ӣ=Ӝ[0];for(int ɒ=1;ɒ<Ӟ;ɒ++){if(Ӝ[ɒ]<Ӣ){Ӣ=Ӝ[ɒ];}}return Ӣ;}}public int Ӟ{get;}double Ӥ;
IMyGridProgramRuntimeInfo ӥ;double[]Ӝ;int Ӧ=0;public A(IMyGridProgramRuntimeInfo ӥ,int ӧ=300){this.ӥ=ӥ;this.ӡ=ӥ.LastRunTimeMs;this.Ӟ=MathHelper.
Clamp(ӧ,1,int.MaxValue);this.Ӥ=1.0/Ӟ;this.Ӝ=new double[ӧ];this.Ӝ[Ӧ]=ӥ.LastRunTimeMs;this.Ӧ++;}public void ě(){Ĝ-=Ӝ[Ӧ]*Ӥ;Ĝ+=ӥ.
LastRunTimeMs*Ӥ;Ӝ[Ӧ]=ӥ.LastRunTimeMs;if(ӥ.LastRunTimeMs>ӡ){ӡ=ӥ.LastRunTimeMs;}Ӧ++;if(Ӧ>=Ӟ){Ӧ=0;Ĝ=ӟ;ӡ=ӥ.LastRunTimeMs;}}