/*
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 *                                                        -  R E E D I T  -  S H I P  -  M A N A G E M E N T  -
 * 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 * A Reedit Solutions Group script written by Chris Reed intended for use on the Sigma Draconis Expanse Server 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 * 
 * > Introduction
 *     This script has several different commands intended to simplify the setup and control of an Expanse-style ship 
 * 
 * > Init:<string Name>
 *     This command renames all blocks on the current construct to my prefered syntax with custom padded numeration
 *     and some custom handling of certain block types   It uses block names, and should be run on a ship with default,
 *     unaltered names.  Some Tips:
 * 
 *     > Name your servers first to just Server: <name>
 *     > For interior lights, add the word 'interior' to the name somewhere or they will be processed as nav lights.
 *     > Connectors, cameras won't be numbered, just add a useful name after each one.
 * 
 * > Stance:<string Stance>
 *     This sets the ship to the provided stance   The complete list of each stance and the settings can be found in
 *     the code below, search for 'switch (stance)'.
 *     
 *     Here's the current list of stances...
 * 
 *         > Docking
 *         > Docked
 *         > Cruise
 *         > MaxCruise
 *         > Combat
 *         > Torpedoes
 *         > Coast
 *         > NoAttack
 * 
 *     Each stance has the following settings..
 * 
 *         torpedoes = 0;                                  // Fire torpedoes; 0: off, 1: on, 2: shoot
 *         pdcs = 0;                                       // PDC status; 0: off, 1: min, 2: all 
 *         railgun = 0;                                    // railgun; 0: off, 1: on
 *         epstein = 0;                                    // epstein; 0: off, 1: on
 *         rcs = 0;                                        // rcs thrusters;  0: off, 1: on
 *         spotlights = 0;                                 // spotlights; 0: off, 1: on
 *         navlights = 1;                                  // stockpile tanks, recharge batts; 0: off, 1: on
 *         interiorlights = new Color(255, 240, 225, 255); // colour to set interior lights to.
 *         stockpilerecharge = 1;                          // stockpile tanks, recharge batts; 0: off, 1: on
 *         speedboost = 0;                                 // EFC boost; 0: off, 1: on
 *         burn = 0;                                       // EFC burn %; 0: no change, 1: 5%, 2: 25%, 3: 100%
 * 
 * > Comms:<string Message>
 *     Work in progress...
 * 
 * > Evade:<int Evade>
 *     Work in progress...
 * 
 * ----------------------------------------------------------------------------------------------------------------------------------------------------
 */






public Program()
{
}

public void Save()
{
}



public void Main(string argument)
{




    if (argument == "")
    {
        Echo("Argument Required!\ne.g.\nStance:Docked\nEvade:1\nComms:Whatsup?");
        return;
    }

    string[] args = argument.Split(':');

    if (args.Length != 2)
    {
        Echo("Syntax Error!\nWTF is that?\n" + argument);
        return;
    }

    switch (args[0].ToLower())
    {
        case "init":
            initShip(args[1]);
            break;
        case "stance":
            setStance(args[1]);
            break;
        case "evade":
            setEvade(args[1]);
            break;
        case "comms":
            setComms(args[1]);
            break;
        default:
            Echo("Syntax Error!\nCommand not recognised\n" + args[0].ToLower());
            return;
    }




}

void setStance(string stance)
{
    Echo("Setting stance to " + stance);

    int torpedoes;
    int torpedoes_count = 0;
    int pdcs;
    int pdcs_count = 0;
    int pdcs_on_count = 0;
    int railgun;
    int railgun_count = 0;
    int epstein;
    int epstein_count = 0;
    int rcs;
    int rcs_count = 0;
    int spotlights;
    int spotlights_count = 0;
    int navlights;
    int navlights_count = 0;
    Color interiorlights;
    int interiorlights_count = 0;
    int stockpilerecharge;
    int hydrogentank_count = 0;
    int oxygentank_count = 0;
    int battery_count = 0;
    int speedboost;
    int burn;
    int efc_found = 0;


    switch (stance)
    {
        case "Docked":
            torpedoes = 0;
            pdcs = 0;
            railgun = 0;
            epstein = 0;
            rcs = 0;
            spotlights = 0;
            navlights = 1;
            interiorlights = new Color(255, 240, 225, 255);
            stockpilerecharge = 1;
            speedboost = 0;
            burn = 0;
            break;
        case "Docking":
            torpedoes = 0;
            pdcs = 1;
            railgun = 0;
            epstein = 0;
            rcs = 1;
            spotlights = 1;
            navlights = 1;
            interiorlights = new Color(158, 26, 219, 255);
            stockpilerecharge = 0;
            speedboost = 0;
            burn = 0;
            break;
        case "NoAttack":
            torpedoes = 0;
            pdcs = 0;
            railgun = 0;
            epstein = 1;
            rcs = 1;
            spotlights = 0;
            navlights = 1;
            interiorlights = new Color(255, 255, 255, 255);
            stockpilerecharge = 0;
            speedboost = 0;
            burn = 0;
            break;
        case "Cruise":
            torpedoes = 0;
            pdcs = 1;
            railgun = 0;
            epstein = 1;
            rcs = 1;
            spotlights = 0;
            navlights = 1;
            interiorlights = new Color(33, 144, 255, 255);
            stockpilerecharge = 0;
            speedboost = 0;
            burn = 2;
            break;
        case "MaxCruise":
            torpedoes = 0;
            pdcs = 1;
            railgun = 0;
            epstein = 1;
            rcs = 1;
            spotlights = 0;
            navlights = 1;
            interiorlights = new Color(36, 17, 242, 255);
            stockpilerecharge = 0;
            speedboost = 1;
            burn = 3;
            break;
        case "Coast":
            torpedoes = 1;
            pdcs = 2;
            railgun = 1;
            epstein = 0;
            rcs = 0;
            spotlights = 0;
            navlights = 0;
            interiorlights = new Color(33, 144, 255, 50);
            stockpilerecharge = 0;
            speedboost = 0;
            burn = 0;
            break;
        case "Combat":
            torpedoes = 1;
            pdcs = 2;
            railgun = 1;
            epstein = 1;
            rcs = 1;
            spotlights = 0;
            navlights = 0;
            interiorlights = new Color(232, 55, 16, 255);
            stockpilerecharge = 0;
            speedboost = 1;
            burn = 3;
            break;
        case "Torpedoes":
            torpedoes = 2;
            pdcs = 2;
            railgun = 1;
            epstein = 1;
            rcs = 1;
            spotlights = 0;
            navlights = 0;
            interiorlights = new Color(242, 17, 125, 255);
            stockpilerecharge = 0;
            speedboost = 1;
            burn = 3;


            break;

        default:
            Echo("Syntax Error!\nStance not recognised\n" + stance);
            return;


    }


    List<IMyTerminalBlock> allBlocks = new List<IMyTerminalBlock>();
    GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(allBlocks);

    for (int i = 0; i < allBlocks.Count; i++)
    {
        if (Me.IsSameConstructAs(allBlocks[i]))
        {
            if (allBlocks[i].DisplayNameText.Contains(".Torpedo"))
            {
                torpedoes_count++;
                switch (torpedoes)
                {
                    case 0:
                        setBlockShootOff(allBlocks[i]);
                        setBlockOff(allBlocks[i]);
                        break;

                    case 1:
                        setBlockShootOff(allBlocks[i]);
                        setBlockOn(allBlocks[i]);
                        break;

                    case 2:
                        setBlockOn(allBlocks[i]);
                        setBlockShootOn(allBlocks[i]);
                        break;
                }
            }
            if (allBlocks[i].DisplayNameText.Contains(".PDC"))
            {
                pdcs_count++;
                switch (pdcs)
                {
                    case 0:
                        setBlockOff(allBlocks[i]);
                        pdcs_on_count = 0;
                        break;

                    case 1:
                        if (allBlocks[i].DisplayNameText.Contains("min"))
                        {
                            setBlockOn(allBlocks[i]);
                            pdcs_on_count++;
                        }
                        else
                            setBlockOff(allBlocks[i]);
                        break;

                    case 2:
                        setBlockOn(allBlocks[i]);
                        pdcs_on_count++;
                        break;
                }
            }

            if (allBlocks[i].DisplayNameText.Contains(".Railgun"))
            {
                railgun_count++;
                if (railgun == 1)
                    setBlockOn(allBlocks[i]);
                else
                    setBlockOff(allBlocks[i]);
            }

            if (allBlocks[i].DisplayNameText.Contains(".Epstein"))
            {
                epstein_count++;
                if (epstein == 1)
                    setBlockOn(allBlocks[i]);
                else
                    setBlockOff(allBlocks[i]);
            }

            if (allBlocks[i].DisplayNameText.Contains(".RCS"))
            {
                rcs_count++;
                if (rcs == 1)
                    setBlockOn(allBlocks[i]);
                else
                    setBlockOff(allBlocks[i]);
            }

            if (allBlocks[i].DisplayNameText.Contains(".Spotlight"))
            {
                spotlights_count++;
                if (spotlights == 1)
                    setBlockOn(allBlocks[i]);
                else
                    setBlockOff(allBlocks[i]);
            }

            if (allBlocks[i].DisplayNameText.Contains(".Light.Nav"))
            {
                navlights_count++;
                if (navlights == 1)
                    setBlockOn(allBlocks[i]);
                else
                    setBlockOff(allBlocks[i]);
            }

            if (allBlocks[i].DisplayNameText.Contains(".Light.Interior"))
            {
                interiorlights_count++;
                setBlockOn(allBlocks[i]);
                allBlocks[i].SetValue("Color", interiorlights);
            }

            if (allBlocks[i].DisplayNameText.Contains(".Tank"))
            {
                setBlockOn(allBlocks[i]);

                if (stockpilerecharge == 1)
                    setBlockStockpileOn(allBlocks[i]);
                else
                    setBlockStockpileOff(allBlocks[i]);

                if (allBlocks[i].DisplayNameText.Contains(".Hydrogen"))
                    hydrogentank_count++;

                if (allBlocks[i].DisplayNameText.Contains(".Oxygen"))
                    oxygentank_count++;
            }

            if (allBlocks[i].DisplayNameText.Contains(".Battery"))
            {
                battery_count++;
                setBlockOn(allBlocks[i]);
                if (stockpilerecharge == 1)
                    setBlockRechargeOn(allBlocks[i]);
                else
                    setBlockRechargeOff(allBlocks[i]);

            }

            if (allBlocks[i].DisplayNameText.Contains(".Server") && allBlocks[i].DisplayNameText.Contains("EFC"))
            {
                efc_found++;

                if (speedboost == 1)
                    setSpeedBoostOn(allBlocks[i]);
                else
                    setSpeedBoostOff(allBlocks[i]);


                string burnt = "";

                if (burn == 1)
                    burnt = "5";
                else if (burn == 2)
                    burnt = "25";
                else if (burn == 3)
                    burnt = "100";

                if (allBlocks[i] is IMyProgrammableBlock)
                    (allBlocks[i] as IMyProgrammableBlock).TryRun("Set Burn " + burnt);

            }
        }


    }

    Echo("Finished setting stance '" + stance + "'"
        + "\n Found EFC Server: " + efc_found.ToString()
        + "\n EFC Speedboost = " + speedboost.ToString()
        + "\n EFC Burn = " + burn.ToString()
        + "\n Torpedoes to " + torpedoes + ": " + torpedoes_count.ToString()
        + "\n PDCs to " + pdcs + ": " + pdcs_on_count.ToString() + "/" + pdcs_count.ToString()
        + "\n Railguns to " + railgun + ": " + railgun_count.ToString()
        + "\n Epsteins to " + epstein + ": " + epstein_count.ToString()
        + "\n RCS to " + rcs + ": " + rcs_count.ToString()
        + "\n Spotlights to " + spotlights + ": " + spotlights_count.ToString()
        + "\n Navlights to " + navlights + ": " + navlights_count.ToString()
        + "\n Interior Lights:  " + interiorlights_count.ToString()
        + "\n H2 Tanks to " + stockpilerecharge + ": " + hydrogentank_count.ToString()
        + "\n 02 Tanks to " + stockpilerecharge + ": " + oxygentank_count.ToString()
        + "\n Batteries to " + stockpilerecharge + ": " + battery_count.ToString()
    );

}


void initShip(string ship)
{
    Echo("Initialising a new ship named " + ship);

    int blockCount = 0;

    int nav_lights = 0;
    int interior_lights = 0;

    List<int> blockCounts = new List<int>();
    List<string> blockTypes = new List<string>();
    blockTypes.Add("Torpedo"); blockCounts.Add(0);
    blockTypes.Add("Railgun"); blockCounts.Add(0);
    blockTypes.Add("Battery"); blockCounts.Add(0);
    blockTypes.Add("RCS"); blockCounts.Add(0);
    blockTypes.Add("Epstein"); blockCounts.Add(0);
    blockTypes.Add("Gyroscope"); blockCounts.Add(0);
    blockTypes.Add("Flak"); blockCounts.Add(0);
    blockTypes.Add("PDC"); blockCounts.Add(0);
    blockTypes.Add("Oxygen Tank"); blockCounts.Add(0);
    blockTypes.Add("Hydrogen Tank"); blockCounts.Add(0);
    blockTypes.Add("Fusion Reactor"); blockCounts.Add(0);
    blockTypes.Add("Supercooled Reactor"); blockCounts.Add(0);
    blockTypes.Add("Small Reactor"); blockCounts.Add(0);
    blockTypes.Add("Door"); blockCounts.Add(0);
    blockTypes.Add("Light"); blockCounts.Add(0);
    blockTypes.Add("Spotlight"); blockCounts.Add(0);
    blockTypes.Add("LCD"); blockCounts.Add(0);
    blockTypes.Add("Vent"); blockCounts.Add(0);
    blockTypes.Add("Antenna"); blockCounts.Add(0);
    blockTypes.Add("Cargo"); blockCounts.Add(0);
    blockTypes.Add("Beacon"); blockCounts.Add(0);
    blockTypes.Add("Welder"); blockCounts.Add(0);

    List<IMyTerminalBlock> allBlocks = new List<IMyTerminalBlock>();
    GridTerminalSystem.GetBlocksOfType<IMyTerminalBlock>(allBlocks);

    for (int i = 0; i < allBlocks.Count; i++)
    {
        if (Me.IsSameConstructAs(allBlocks[i]))
        {
            blockCount++;
            bool found = false;

            for (int j = 0; j < blockTypes.Count; j++)
            {
                if (allBlocks[i].CustomName.Contains(blockTypes[j]))
                {
                    found = true;

                    string thisType = blockTypes[j];
                    string formattedCount;

                    if (thisType == "Flak") thisType = "PDC";
                    if (thisType == "Epstein") thisType = "Epstein." + allBlocks[i].CustomName.Split('"')[1];
                    if (thisType == "Oxygen Tank") thisType = "Tank.Oxygen";
                    if (thisType == "Hydrogen Tank") thisType = "Tank.Hydrogen";
                    if (thisType == "Fusion Reactor") thisType = "Reactor.Primary";
                    if (thisType == "Supercooled Reactor") thisType = "Reactor.SCSmall";
                    if (thisType == "Small Reactor") thisType = "Reactor.Small";
                    if (thisType == "Cargo" && allBlocks[i].CustomName.Contains("Small")) thisType = "Cargo.Sm";

                    blockCounts[j]++;

                    if (thisType == "Light")
                    {
                        if (allBlocks[i].CustomName.Contains("Interior"))
                        {
                            interior_lights++;
                            thisType = "Light.Interior";
                            formattedCount = interior_lights.ToString().PadLeft(2, '0');
                        }
                        else
                        {
                            nav_lights++;
                            thisType = "Light.Nav";
                            formattedCount = nav_lights.ToString().PadLeft(2, '0');
                        }
                    }
                    else if (thisType == "Connector" || thisType == "Camera" || thisType == "Door") formattedCount = "";
                    else formattedCount = blockCounts[j].ToString().PadLeft(2, '0');

                    allBlocks[i].CustomName = ship + "." + thisType + "." + formattedCount;
                }
            }

            if (!found) allBlocks[i].CustomName = ship + "." + allBlocks[i].CustomName;

        }
    }

    string msg = "Done!\n";
    for (int i = 0; i < blockTypes.Count; i++) msg += " " + blockTypes[i] + "=" + blockCounts[i] + "\n";
    Echo(msg + "\nGood Hunting!");

}


void setEvade(string state)
{
    Echo("Setting evade to " + state);
}

void setComms(string comms)
{
    Echo("Setting comms to " + comms);
}

void setBlockOff(IMyTerminalBlock block)
{
    List<ITerminalAction> actions = new List<ITerminalAction>();
    block.GetActions(actions, (x) => x.Id.Equals("OnOff_Off"));
    if (actions.Count > 0)
        actions[0].Apply(block);
}

void setBlockOn(IMyTerminalBlock block)
{
    List<ITerminalAction> actions = new List<ITerminalAction>();
    block.GetActions(actions, (x) => x.Id.Equals("OnOff_On"));
    if (actions.Count > 0)
        actions[0].Apply(block);
}

void setBlockShootOn(IMyTerminalBlock block)
{
    List<ITerminalAction> actions = new List<ITerminalAction>();
    block.GetActions(actions, (x) => x.Id.Equals("Shoot_On"));
    if (actions.Count > 0)
        actions[0].Apply(block);
}
void setBlockShootOff(IMyTerminalBlock block)
{
    List<ITerminalAction> actions = new List<ITerminalAction>();
    block.GetActions(actions, (x) => x.Id.Equals("Shoot_Off"));
    if (actions.Count > 0)
        actions[0].Apply(block);
}
void setBlockStockpileOn(IMyTerminalBlock block)
{
    List<ITerminalAction> actions = new List<ITerminalAction>();
    block.GetActions(actions, (x) => x.Id.Equals("Stockpile_On"));
    if (actions.Count > 0)
        actions[0].Apply(block);
}
void setBlockStockpileOff(IMyTerminalBlock block)
{
    List<ITerminalAction> actions = new List<ITerminalAction>();
    block.GetActions(actions, (x) => x.Id.Equals("Stockpile_Off"));
    if (actions.Count > 0)
        actions[0].Apply(block);
}

void setBlockRechargeOn(IMyTerminalBlock block)
{

    long status = block.GetValue<long>("ChargeMode");
    if (status != 1)
    {
        List<ITerminalAction> actions = new List<ITerminalAction>();
        block.GetActions(actions, (x) => x.Id.Equals("Recharge"));
        if (actions.Count > 0)
            actions[0].Apply(block);
    }
}

void setBlockRechargeOff(IMyTerminalBlock block)
{
    List<ITerminalAction> actions = new List<ITerminalAction>();
    block.GetActions(actions, (x) => x.Id.Equals("Auto"));
    if (actions.Count > 0)
        actions[0].Apply(block);
}

void setSpeedBoostOn(IMyTerminalBlock block)
{
    if (block is IMyProgrammableBlock)
        (block as IMyProgrammableBlock).TryRun("Boost On");
}

void setSpeedBoostOff(IMyTerminalBlock block)
{
    if (block is IMyProgrammableBlock)
        (block as IMyProgrammableBlock).TryRun("Boost Off");
}