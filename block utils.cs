using Sandbox.Game.EntityComponents;
using Sandbox.ModAPI.Ingame;
using Sandbox.ModAPI.Interfaces;
using SpaceEngineers.Game.ModAPI.Ingame;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using VRage;
using VRage.Collections;
using VRage.Game;
using VRage.Game.Components;
using VRage.Game.GUI.TextPanel;
using VRage.Game.ModAPI.Ingame;
using VRage.Game.ModAPI.Ingame.Utilities;
using VRage.Game.ObjectBuilders.Definitions;
using VRageMath;

namespace IngameScript
{
    partial class Program
    {

        // todo
        // review this
        // use it to manage toolcore welders
        // leave welders on all of the time, toggle them on with activate
        // if they are a toolcore welder.
        void setToolActivate(IMyTerminalBlock Block, bool Activate)
        {
            Block.GetActionWithName("ToolCore_Shoot_Action").Apply(Block);

            (Block as IMyConveyorSorter).GetActionWithName("ToolCore_Shoot_Action").Apply(Block);

        }

        void setBlockRepelOn(IMyTerminalBlock block)
        {
            bool repelStatus = block.GetValue<bool>("WC_Repel");
            //Echo("Repel status=" + repelStatus);
            if (!repelStatus)
                block.ApplyAction("WC_RepelMode");
        }

        void setBlockRepelOff(IMyTerminalBlock block)
        {
            bool repelStatus = block.GetValue<bool>("WC_Repel");
            //Echo("Repel status=" + repelStatus);
            if (repelStatus)
                block.ApplyAction("WC_RepelMode");
        }

        void setBlockFireModeManual(IMyTerminalBlock block)
        {
            try
            {
                block.SetValue<Int64>("WC_Shoot Mode", 3);
                if (D) Echo("Shoot mode = " + block.GetValue<Int64>("WC_Shoot Mode"));
            }
            catch
            {
                Echo("Failed to set fire mode to manual on " + block.CustomName);
            }
        }

        void setBlockFireModeAuto(IMyTerminalBlock block)
        {
            try
            {
                block.SetValue<Int64>("WC_Shoot Mode", 0);
                if (D) Echo("Shoot mode = " + block.GetValue<Int64>("WC_Shoot Mode"));
            }
            catch
            {
                Echo("Failed to set fire mode to auto on " + block.CustomName);
            }
        }
    }
}

/*
ALL PDC PROPERTIES
OnOff
ShowInTerminal
ShowInInventory
ShowInToolbarConfig
Name
ShowOnHUD
Content
ScriptForegroundColor
ScriptBackgroundColor
Font
FontSize
FontColor
alignment
TextPaddingSlider
BackgroundColor
ChangeIntervalSlider
PreserveAspectRatio
Shoot
Range
EnableIdleMovement
TargetMeteors
TargetMissiles
TargetSmallShips
TargetLargeShips
TargetCharacters
TargetStations
TargetNeutrals
TargetFriends
TargetEnemies
EnableTargetLocking
TargetingGroup_Selector
UseConveyor
WC_Advanced
WC_Debug
WC_ShareFireControlEnabled
WC_Shoot
WC_Override
WC_Shoot Mode
Weapon ROF
WC_Overload
Detonation
WC_Arm
WC_ControlModes
WC_PickAmmo
WC_PickSubSystem
WC_TrackingMode
Weapon Range
WC_ReportTarget
WC_Neutrals
WC_Unowned
WC_Biologicals
WC_Projectiles
WC_Meteors
WC_Grids
WC_FocusFire
WC_SubSystems
WC_Repel
WC_LargeGrid
WC_SmallGrid
Burst Count
Burst Delay
Sequence Id
Weapon Group Id
Target Group
Camera Channel


ALL PDC ACTIONS
OnOff
OnOff_On
OnOff_Off
ShowOnHUD
ShowOnHUD_On
ShowOnHUD_Off
IncreaseFontSize
DecreaseFontSize
IncreaseTextPaddingSlider
DecreaseTextPaddingSlider
IncreaseChangeIntervalSlider
DecreaseChangeIntervalSlider
PreserveAspectRatio
ShootOnce
Shoot
Shoot_On
Shoot_Off
Control
IncreaseRange
DecreaseRange
EnableIdleMovement
EnableIdleMovement_On
EnableIdleMovement_Off
TargetMeteors
TargetMeteors_On
TargetMeteors_Off
TargetMissiles
TargetMissiles_On
TargetMissiles_Off
TargetSmallShips
TargetSmallShips_On
TargetSmallShips_Off
TargetLargeShips
TargetLargeShips_On
TargetLargeShips_Off
TargetCharacters
TargetCharacters_On
TargetCharacters_Off
TargetStations
TargetStations_On
TargetStations_Off
TargetNeutrals
TargetNeutrals_On
TargetNeutrals_Off
TargetFriends
TargetFriends_On
TargetFriends_Off
TargetEnemies
TargetEnemies_On
TargetEnemies_Off
EnableTargetLocking
TargetingGroup_Weapons
TargetingGroup_Propulsion
TargetingGroup_PowerSystems
TargetingGroup_MES-TargetingGroup-Communications
TargetingGroup_MES-TargetingGroup-Production
TargetingGroup_CycleSubsystems
CopyTarget
ForgetTarget
UseConveyor
WC_Weapon ROF_Increase
WC_Weapon ROF_Decrease
WC_Overload_Toggle
WC_Overload_Toggle_On
WC_Overload_Toggle_Off
ShootToggle
Shoot_On
Shoot_Off
WCShootMode
ActionFire
WCMouseToggle
SubSystems
ControlModes
WC_CycleAmmo
TrackingMode
ForceReload
FocusTargets
FocusSubSystem
Grids
Neutrals
Friendly
Unowned
Projectiles
Biologicals
Meteors
WC_Increase_CameraChannel
WC_Decrease_CameraChannel
WC_Increase_LeadGroup
WC_Decrease_LeadGroup
WC_RepelMode
MaxSize Increase
MaxSize Decrease
MinSize Increase
MinSize Decrease
ActionFriend
ActionEnemy
LargeGrid
SmallGrid
 */
