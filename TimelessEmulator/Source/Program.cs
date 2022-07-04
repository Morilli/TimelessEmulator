using System;
using System.Collections.Generic;
using System.Linq;
using Spectre.Console;
using TimelessEmulator.Data;
using TimelessEmulator.Data.Models;
using TimelessEmulator.Game;

namespace TimelessEmulator;

public static class Program
{

    static Program()
    {

    }

    public static void Main(string[] arguments)
    {
        Console.Title = $"{Settings.ApplicationName} Ver. {Settings.ApplicationVersion}";

        AnsiConsole.MarkupLine("Hello, [green]exile[/]!");
        AnsiConsole.MarkupLine("Loading [green]data files[/]...");

        if (!DataManager.Initialize())
            ExitWithError("Failed to initialize the [yellow]data manager[/].");

        // string[] notableNames =
        // {
        // "Master of the Arena", "Mana Flows", "Bravery", "Defiance", "Dervish", "Art of the Gladiator", "Vigour", "Savagery", "Cloth and Chain",
        // "Golem's Blood"
        // };
        // string[] notableNames = { "Harrier", "Foresight", "Potency of Will" };
        // string[] notableNames =
        // {
            // "Revenge of The Hunted", "Void Barrier", "Taste for Blood", "Dire Torment", "Master Sapper", "Charisma", "Wasting", "Replenishing Remedies",
            // "Ballistics", "Adder's Touch"
        // };
        string[][] jewelSocketNotables = {
            new[] {
                "Soul Thief", "Saboteur", "Coldhearted Calculation", "Elemental focus", "Mind drinker", "One with evil", "Flaying", "Backstabbing", "Infused",
                "Resourcefulness", "Frenetic", "Depth perception", "Blood Drinker", "Claws of the magpie", "Claws of the hawk", "Clever Thief",
                "From the shadows", "Master of Blades", "Fangs of the Viper", "Will of Blades", "Sleight of hand"
            },
            new[] {
                "Profane Chemistry", "Avatar of the Hunt", "Crystal Skin", "Gladiator's Perseverance", "Burning Brutality", "Weathered Hunter", "Heavy Draw",
                "Deadly Draw", "Art of the Gladiator"
            },
            new[] {
                "Anointed Flesh", "Asylum", "Essence Infusion", "Enduring Bond", "Annihilation", "Fire Walker", "Arcanist's Dominion", "Essence Extraction",
                "Quick Recovery"
            },
            new[] {
                "Elder Power", "Disintegration", "Fusillade", "Utmost Intellect", "Light Eater", "Searing Heat", "Efficient Explosives", "Throatseeker",
                "Mysticism", "Alacrity", "Physique", "Successive Detonations", "Influence", "Whispers of Doom", "Arcing Blows"
            },
            new[] {
                "Clever Thief", "Hunter's Gambit", "From the shadows", "Fatal toxins", "Careful conservationist", "Forces of nature", "Silent steps",
                "Inveterate", "Survivalist", "Heartseeker", "Trick Shot", "Split Shot", "Piercing Shots"
            },
            new[] {
                "Feller of Foes", "Dazzling Strikes", "Blade Barrier", "Bladedancer", "Marked for Death", "Fangs of Frost", "Thick Skin", "Utmost Swiftness",
                "Twin Terrors", "Longshot"
            },
            new[] { "Steadfast", "Tribal fury", "Bastion breaker", "Lava lash", "Blade of cunning", "Executioner" },
            new[] {
                "Smashing Strikes", "Counterweight", "Whirling Barrier", "Sanctum of thought", "Shamanistic fury", "Vanquisher", "Disemboweling", "Bone Breaker",
                "Skull Cracking"
            },
            new[] {
                "Fearsome Force", "Blunt Trauma", "Serpent stance", "Agility", "Might", "Arcane guarding", "Hex master", "Death Attunement", "Corruption",
                "Prism weave", "Enigmatic reach", "Acrimony", "Unnatural Calm"
            },
            new[] {
                "Instability", "Breath of Flames", "Heart of Thunder", "Breath of Lightning", "Breath of Rime", "Heart of Ice", "Infused Flesh",
                "Discord Artisan", "Presage", "Skittering Runes", "Golem Commander", "Cruel Preparation", "Deep Thoughts", "Essence Surge", "Mental Rapidity",
                "Prodigal Perfection", "Enigmatic Defence", "Mystic Bulwark", "Wandslinger", "Frost Walker", "Lord of the Dead", "Arcane Will"
            },
            new[] { "Melding", "Deep Wisdom", "Grave Intentions", "Vampirism", "Nimbleness", "Undertaker", "Tolerance" },
            new[] {
                "Wasting", "Dire Torment", "Taste for Blood", "Adder's Touch", "Void Barrier", "Revenge of the Hunted", "Master Sapper",
                "Replenishing Remedies", "Charisma", "Ballistics", "Overcharged"
            },
            new[] {
                "Gravepact", "Dynamo", "Sanctity", "Steelwood Stance", "Powerful Bond", "Combat Stamina", "Sanctuary", "Expertise", "Ancestral Knowledge",
                "Deep Breaths", "Blacksmith's Clout"
            },
            new[] {
                "Runesmith", "Arcane Capacitor", "Faith and Steel", "Overcharge", "Endurance", "Devotion", "Smashing Strikes", "Divine Judgement",
                "Divine Wrath", "Divine Fury", "Holy Dominion", "Light of Divinity", "Divine Fervour", "Sanctum of Thought"
            },
            new[] {
                "Stamina", "Disemboweling", "Hearty", "Savage Wounds", "Barbarism", "Harpooner", "Cleaving", "Slaughter", "Strong Arm", "Spiked Bulwark",
                "Diamond Skin", "Robust", "Lust for Carnage", "Cannibalistic Rite", "Juggernaut", "Aggressive Bastion", "Warrior Training"
            },
            new[] { "Martial Experience", "Command of Steel", "Admonisher", "Bloodletting", "Prismatic Skin", "Eagle Eye" },
            new[] {
                "Art of the Gladiator", "Bravery", "Master of the Arena", "Mana Flows", "Defiance", "Dervish", "Destroyer", "Fury Bolts", "Measured Fury", "Vigour",
                "Savagery", "Titanic Impacts", "Ribcage Crusher", "Revelry", "Assured Strike", "Deflection", "Dirty Techniques", "Adamant", "Cloth and Chain",
                "Golem's Blood", "Surveillance", "Testudo"
            },
            new[] {
                "Foresight", "Decay Ward", "Forethought", "Dreamer", "Potency of Will", "Ash, Frost and Storm", "Shaper", "Inspiring Bond", "Totemic Zeal",
                "Path of the Warrior", "Malicious Intent", "Constitution", "Relentless", "Veteran Soldier", "Path of the Savant"
            },
            new[] {
                "Destructive Apparatus", "Thrill Killer", "Foresight", "Path of the Savant", "Inspiring Bond", "Harrier", "True Strike", "Hired Killer",
                "Path of the Hunter", "Reflexes", "Window of Opportunity", "Exceptional Performance", "Potency of Will", "Leadership"
            },
            new[] {
                "Hired Killer", "Reflexes", "Path of the Hunter", "Window of Opportunity", "Exceptional Performance", "Sentinel", "Arcane Chemistry",
                "Battle Rouse", "Constitution", "Totemic Zeal", "Path of the Warrior", "Malicious Intent"
            },
            new[] {
                "Careful Conservationist", "Inveterate", "Survivalist", "Heartseeker", "Acuity", "Herbalism", "Swift Venoms", "Flash Freeze", "Winter Spirit",
                "Fervour", "Quickstep", "Intuition", "Weapon Artistry", "Aspect of the Lynx", "Silent Steps", "King of the Hill", "Master Fletcher",
                "Trick Shot"
            }
        };
        PassiveSkill[][] passiveSkills = jewelSocketNotables.Select(array => array.Select(DataManager.GetPassiveSkillByFuzzyValue).ToArray()).ToArray();

        AlternateTreeVersion alternateTreeVersion = DataManager.AlternateTreeVersions
            .First(q => q.Index == 2); // lethal pride
            // .First(q => q.Index == 5); // elegant hubris
        TimelessJewelConqueror irrelevant = new TimelessJewelConqueror(0, 0);
        for (uint seed = 10000; seed <= 18000; seed ++)
        {
            List<PassiveSkill>[] haveDoubleDamage = new List<PassiveSkill>[passiveSkills.Length];
            List<PassiveSkill>[] haveRarity = new List<PassiveSkill>[passiveSkills.Length];
            List<PassiveSkill>[] havePercentStrength = new List<PassiveSkill>[passiveSkills.Length];
            Dictionary<string, List<PassiveSkill>>[] singleNotableLists = new Dictionary<string, List<PassiveSkill>>[passiveSkills.Length];
            // List<PassiveSkill>[] haveFlatStrength = new List<PassiveSkill>[passiveSkills.Length];
            for (int i = 0; i < passiveSkills.Length; i++)
            {
                singleNotableLists[i] = new Dictionary<string, List<PassiveSkill>>();
                haveDoubleDamage[i] = new List<PassiveSkill>();
                havePercentStrength[i] = new List<PassiveSkill>();
                foreach (PassiveSkill skill in passiveSkills[i])
                {
                    TimelessJewel toTest = new TimelessJewel(alternateTreeVersion, irrelevant, seed);
                    AlternateTreeManager treeManager = new AlternateTreeManager(skill, toTest);

                    bool isReplaced = treeManager.IsPassiveSkillReplaced();
                    if (isReplaced)
                    {
                        AlternatePassiveSkillInformation replacedInformation = treeManager.ReplacePassiveSkill();
                        if (replacedInformation.AlternatePassiveSkill.Name == "Discerning Taste")
                        {
                            haveRarity[i].Add(skill);
                        }
                    }
                    else
                    {
                        IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations = treeManager.AugmentPassiveSkill();
                        foreach (AlternatePassiveAdditionInformation addedPassive in alternatePassiveAdditionInformations)
                        {
                            if (!singleNotableLists[i].ContainsKey(addedPassive.AlternatePassiveAddition.Identifier))
                                singleNotableLists[i][addedPassive.AlternatePassiveAddition.Identifier] = new List<PassiveSkill>();
                            singleNotableLists[i][addedPassive.AlternatePassiveAddition.Identifier].Add(skill);
                        }
                        if (alternatePassiveAdditionInformations.Any(additionInformation =>
                                additionInformation.AlternatePassiveAddition.Identifier == "karui_notable_add_double_damage"))
                        {
                            haveDoubleDamage[i].Add(skill);
                        }

                        if (alternatePassiveAdditionInformations.Any(additionInformation =>
                                additionInformation.AlternatePassiveAddition.Identifier == "karui_notable_add_percent_strength"))
                        {
                            havePercentStrength[i].Add(skill);
                        }

                        if (alternatePassiveAdditionInformations.Any(additionInformation =>
                                additionInformation.AlternatePassiveAddition.Identifier == "karui_notable_add_strength"))
                        {
                            // haveFlatStrength.Add(skill);
                        }
                    }
                }
            }

            foreach (Dictionary<string, List<PassiveSkill>> singleNotableList in singleNotableLists)
            {
                foreach ((string notableIdentifier, List<PassiveSkill> changedSkills) in singleNotableList)
                {
                    if (notableIdentifier == "karui_notable_add_percent_strength" && changedSkills.Count > 3 &&
                        changedSkills.FindAll(skill => skill.Name is "Mana Flows" or "Revenge of the Hunteds" or "Ballisticss").Count > 0)
                    {
                        Console.WriteLine($"seed: {seed}, added notable identifier: {notableIdentifier}");
                        Console.WriteLine($"{notableIdentifier} count: {changedSkills.Count}, notables: {string.Join(", ", changedSkills.Select(skill => skill.Name))}");
                        Console.WriteLine();
                    }
                }
            }
            // foreach (List<PassiveSkill> skills in havePercentStrength)
            // {
            //     if (skills.Count > 3)
            //     {
            //         Console.WriteLine($"seed: {seed}");
            //         // Console.WriteLine($"flat strength count: {haveFlatStrength.Count}, notables: {string.Join(", ", haveFlatStrength.Select(skill => skill.Name))}");
            //         Console.WriteLine($"percent strength count: {skills.Count}, notables: {string.Join(", ", skills.Select(skill => skill.Name))}");
            //         // Console.WriteLine($"double damage count: {skills.Count}, notables: {string.Join(", ", skills.Select(skill => skill.Name))}");
            //         Console.WriteLine();
            //     }
            // }
        }

        return;
        PassiveSkill passiveSkill = GetPassiveSkillFromInput();

        if (passiveSkill == null)
            ExitWithError("Failed to get the [yellow]passive skill[/] from input.");

        TimelessJewel timelessJewel = GetTimelessJewelFromInput();

        if (timelessJewel == null)
            ExitWithError("Failed to get the [yellow]timeless jewel[/] from input.");

        AnsiConsole.WriteLine();

        AlternateTreeManager alternateTreeManager = new AlternateTreeManager(passiveSkill, timelessJewel);

        bool isPassiveSkillReplaced = alternateTreeManager.IsPassiveSkillReplaced();

        AnsiConsole.MarkupLine($"[green]Is Passive Skill Replaced[/]: {isPassiveSkillReplaced}");

        if (isPassiveSkillReplaced)
        {
            AlternatePassiveSkillInformation alternatePassiveSkillInformation = alternateTreeManager.ReplacePassiveSkill();

            AnsiConsole.MarkupLine($"[green]Alternate Passive Skill[/]: [yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Name}[/] ([yellow]{alternatePassiveSkillInformation.AlternatePassiveSkill.Identifier}[/])");

            for (int i = 0; i < alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.Count; i++)
            {
                uint statIndex = alternatePassiveSkillInformation.AlternatePassiveSkill.StatIndices.ElementAt(i);
                uint statRoll = alternatePassiveSkillInformation.StatRolls.ElementAt(i).Value;

                AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
            }

            PrintAlternatePassiveAdditionInformations(alternatePassiveSkillInformation.AlternatePassiveAdditionInformations);
        }
        else
        {
            IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations = alternateTreeManager.AugmentPassiveSkill();

            PrintAlternatePassiveAdditionInformations(alternatePassiveAdditionInformations);
        }

        WaitForExit();
    }

    private static PassiveSkill GetPassiveSkillFromInput()
    {
        TextPrompt<string> passiveSkillTextPrompt = new TextPrompt<string>("[green]Passive Skill[/]:")
            .Validate((string input) =>
            {
                PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(input);

                if (passiveSkill == null)
                    return ValidationResult.Error($"[red]Error[/]: Unable to find [yellow]passive skill[/] `{input}`.");

                if (!DataManager.IsPassiveSkillValidForAlteration(passiveSkill))
                    return ValidationResult.Error($"[red]Error[/]: The [yellow]passive skill[/] `{input}` is not valid for alteration.");

                return ValidationResult.Success();
            });

        string passiveSkillInput = AnsiConsole.Prompt(passiveSkillTextPrompt);

        PassiveSkill passiveSkill = DataManager.GetPassiveSkillByFuzzyValue(passiveSkillInput);

        AnsiConsole.MarkupLine($"[green]Found Passive Skill[/]: [yellow]{passiveSkill.Name}[/] ([yellow]{passiveSkill.Identifier}[/])");

        return passiveSkill;
    }

    private static TimelessJewel GetTimelessJewelFromInput()
    {
        Dictionary<uint, string> timelessJewelTypes = new Dictionary<uint, string>()
        {
            { 1, "Glorious Vanity" },
            { 2, "Lethal Pride" },
            { 3, "Brutal Restraint" },
            { 4, "Militant Faith" },
            { 5, "Elegant Hubris" }
        };

        Dictionary<uint, Dictionary<string, TimelessJewelConqueror>> timelessJewelConquerors = new Dictionary<uint, Dictionary<string, TimelessJewelConqueror>>()
        {
            {
                1, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Xibaqua", new TimelessJewelConqueror(1, 0) },
                    { "[springgreen3]Zerphi (Legacy)[/]", new TimelessJewelConqueror(2, 0) },
                    { "Ahuana", new TimelessJewelConqueror(2, 1) },
                    { "Doryani", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                2, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Kaom", new TimelessJewelConqueror(1, 0) },
                    { "Rakiata", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Kiloava (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Akoya", new TimelessJewelConqueror(3, 1) }
                }
            },
            {
                3, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Deshret (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Balbala", new TimelessJewelConqueror(1, 1) },
                    { "Asenath", new TimelessJewelConqueror(2, 0) },
                    { "Nasima", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                4, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "[springgreen3]Venarius (Legacy)[/]", new TimelessJewelConqueror(1, 0) },
                    { "Maxarius", new TimelessJewelConqueror(1, 1) },
                    { "Dominus", new TimelessJewelConqueror(2, 0) },
                    { "Avarius", new TimelessJewelConqueror(3, 0) }
                }
            },
            {
                5, new Dictionary<string, TimelessJewelConqueror>()
                {
                    { "Cadiro", new TimelessJewelConqueror(1, 0) },
                    { "Victario", new TimelessJewelConqueror(2, 0) },
                    { "[springgreen3]Chitus (Legacy)[/]", new TimelessJewelConqueror(3, 0) },
                    { "Caspiro", new TimelessJewelConqueror(3, 1) }
                }
            }
        };

        Dictionary<uint, (uint minimumSeed, uint maximumSeed)> timelessJewelSeedRanges = new Dictionary<uint, (uint minimumSeed, uint maximumSeed)>()
        {
            { 1, (100, 8000) },
            { 2, (10000, 18000) },
            { 3, (500, 8000) },
            { 4, (2000, 10000) },
            { 5, (2000, 160000) }
        };

        SelectionPrompt<string> timelessJewelTypeSelectionPrompt = new SelectionPrompt<string>()
            .Title("[green]Timeless Jewel Type[/]:")
            .AddChoices(timelessJewelTypes.Values.ToArray());

        string timelessJewelTypeInput = AnsiConsole.Prompt(timelessJewelTypeSelectionPrompt);

        AnsiConsole.MarkupLine($"[green]Timeless Jewel Type[/]: {timelessJewelTypeInput}");

        uint alternateTreeVersionIndex = timelessJewelTypes
            .First(q => (q.Value == timelessJewelTypeInput))
            .Key;

        AlternateTreeVersion alternateTreeVersion = DataManager.AlternateTreeVersions
            .First(q => (q.Index == alternateTreeVersionIndex));

        SelectionPrompt<string> timelessJewelConquerorSelectionPrompt = new SelectionPrompt<string>()
            .Title("[green] Timeless Jewel Conqueror[/]:")
            .AddChoices(timelessJewelConquerors[alternateTreeVersionIndex].Keys.ToArray());

        string timelessJewelConquerorInput = AnsiConsole.Prompt(timelessJewelConquerorSelectionPrompt);

        AnsiConsole.MarkupLine($"[green]Timeless Jewel Conqueror[/]: {timelessJewelConquerorInput}");

        TimelessJewelConqueror timelessJewelConqueror = timelessJewelConquerors[alternateTreeVersionIndex]
            .First(q => (q.Key == timelessJewelConquerorInput))
            .Value;

        TextPrompt<uint> timelessJewelSeedTextPrompt = new TextPrompt<uint>($"[green]Timeless Jewel Seed ({timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed} - {timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed})[/]:")
            .Validate((uint input) =>
            {
                if ((input >= timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed) &&
                    (input <= timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed))
                {
                    return ValidationResult.Success();
                }

                return ValidationResult.Error($"[red]Error[/]: The [yellow]timeless jewel seed[/] must be between {timelessJewelSeedRanges[alternateTreeVersionIndex].minimumSeed} and {timelessJewelSeedRanges[alternateTreeVersionIndex].maximumSeed}.");
            });

        uint timelessJewelSeed = AnsiConsole.Prompt(timelessJewelSeedTextPrompt);

        return new TimelessJewel(alternateTreeVersion, timelessJewelConqueror, timelessJewelSeed);
    }

    private static void PrintAlternatePassiveAdditionInformations(IReadOnlyCollection<AlternatePassiveAdditionInformation> alternatePassiveAdditionInformations)
    {
        ArgumentNullException.ThrowIfNull(alternatePassiveAdditionInformations, nameof(alternatePassiveAdditionInformations));

        foreach (AlternatePassiveAdditionInformation alternatePassiveAdditionInformation in alternatePassiveAdditionInformations)
        {
            AnsiConsole.MarkupLine($"\t[green]Addition[/]: [yellow]{alternatePassiveAdditionInformation.AlternatePassiveAddition.Identifier}[/]");

            for (int i = 0; i < alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.Count; i++)
            {
                uint statIndex = alternatePassiveAdditionInformation.AlternatePassiveAddition.StatIndices.ElementAt(i);
                uint statRoll = alternatePassiveAdditionInformation.StatRolls.ElementAt(i).Value;

                AnsiConsole.MarkupLine($"\t\tStat [yellow]{i}[/] | [yellow]{DataManager.GetStatTextByIndex(statIndex)}[/] (Identifier: [yellow]{DataManager.GetStatIdentifierByIndex(statIndex)}[/], Index: [yellow]{statIndex}[/]), Roll: [yellow]{statRoll}[/]");
            }
        }
    }

    private static void WaitForExit()
    {
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("Press [yellow]any key[/] to exit.");

        try
        {
            Console.ReadKey();
        }
        catch { }

        Environment.Exit(0);
    }

    private static void PrintError(string error)
    {
        AnsiConsole.MarkupLine($"[red]Error[/]: {error}");
    }

    private static void ExitWithError(string error)
    {
        PrintError(error);
        WaitForExit();
    }

}
