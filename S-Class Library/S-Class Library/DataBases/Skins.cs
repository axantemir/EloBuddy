﻿using System.Collections.Generic;
using EloBuddy;

namespace S_Class_Library.DataBases
{
    public class Skin
    {
        public Champion Champ;
        public List<string> Skins;

        public Skin(Champion champ, List<string> skins)
        {
            Champ = champ;
            Skins = skins;
        }
    }

    public static class Skins
    {
        //A really big thanks to SlyShyOne for helping me he did the most of the work
        public static List<Skin> SkinsDB = new List<Skin>
        {
            new Skin(Champion.Aatrox, new List<string> {"Basic Skin", "Justicar Aatrox", "Mecha Aatrox", "Sea Hunter Aatrox"}),
            new Skin(Champion.Ahri,
                new List<string> {"Basic Skin", "Dynasty Ahri", "Midnight Ahri", "Foxfire Ahri", "Popstar Ahri", "Challenger Ahri", "Academy Ahri"}),
            new Skin(Champion.Akali, new List<string> {"Basic Skin", "Stinger Akali", "Crimson Akali",}),
            new Skin(Champion.Alistar, new List<string> {"Basic Skin","Black Alistar", "Golden Alistar", "El Matador Alistar", "LongHorn Alistar", "Unchained Alistar", "Infernal Alistar" , "Sweeeper Alistar", "Marauder Alistar"}),
            new Skin(Champion.Amumu, new List<string> {"Basic Skin", "Pharaoh Amumu", "Vancouver Amumu", "Emumu", "Re-Gifted Amumu" , "Almost Prom king Amumu", "Little Knight Amumu", "Sad Robot Amumu", "Surprise party amumu"}),
            new Skin(Champion.Anivia, new List<string> {"Basic Skin","Team Spirit Anivia", "Bird Of Prey Anivia", "Noxus Hunter Anivia", "Hextech Anivia", "Blackfrost Anivia", "Prehistoric Anivia"}),
            new Skin(Champion.Annie, new List<string> {"Basic Skin",}),
            new Skin(Champion.Ashe, new List<string> {"Basic Skin","Freljord Ashe", "Sherwood Forest Ashe", "Woad Ashe", "Queen Ashe", "Amethyst Ashe", "HeartSeeker Ashe", "Marauder Ashe"}),
            new Skin(Champion.AurelionSol, new List<string> {"Basic Skin","Ashen Lord Aurelion Sol"}),
            new Skin(Champion.Azir, new List<string> {"Basic Skin",}),
            new Skin(Champion.Bard, new List<string> {"Basic Skin",}),
            new Skin(Champion.Blitzcrank, new List<string> {"Basic Skin",}),
            new Skin(Champion.Brand, new List<string> {"Basic Skin",}),
            new Skin(Champion.Braum, new List<string> {"Basic Skin",}),
            new Skin(Champion.Caitlyn, new List<string> {"Basic Skin",}),
            new Skin(Champion.Cassiopeia, new List<string> {"Basic Skin",}),
            new Skin(Champion.Chogath, new List<string> {"Basic Skin",}),
            new Skin(Champion.Corki, new List<string> {"Basic Skin",}),
            new Skin(Champion.Darius, new List<string> {"Basic Skin",}),
            new Skin(Champion.Diana, new List<string> {"Basic Skin",}),
            new Skin(Champion.DrMundo, new List<string> {"Basic Skin",}),
            new Skin(Champion.Draven, new List<string> {"Basic Skin",}),
            new Skin(Champion.Ekko, new List<string> {"Basic Skin",}),
            new Skin(Champion.Elise, new List<string> {"Basic Skin",}),
            new Skin(Champion.Evelynn, new List<string> {"Basic Skin",}),
            new Skin(Champion.Ezreal, new List<string> {"Basic Skin",}),
            new Skin(Champion.FiddleSticks, new List<string> {"Basic Skin",}),
            new Skin(Champion.Fiora, new List<string> {"Basic Skin",}),
            new Skin(Champion.Fizz, new List<string> {"Basic Skin",}),
            new Skin(Champion.Galio, new List<string> {"Basic Skin",}),
            new Skin(Champion.Gangplank, new List<string> {"Basic Skin",}),
            new Skin(Champion.Garen, new List<string> {"Basic Skin",}),
            new Skin(Champion.Gnar, new List<string> {"Basic Skin",}),
            new Skin(Champion.Gragas, new List<string> {"Basic Skin","Gragas "}),
            new Skin(Champion.Graves,
                new List<string>
                {
                    "Basic Skin",
                    "Hired Gun Graves",
                    "Jailbreak Graves",
                    "Mafia Graves",
                    "Riot Graves",
                    "Pool Party Graves",
                    "Cutthroat Graves"
                }),
            new Skin(Champion.Hecarim,
                new List<string> {"Basic Skin", "Blood Knight Hecarim", "Reaper Hecarim", "Headless Hecarim", "Arcade Hecarim", "Elderwood Hecarim"}),
            new Skin(Champion.Heimerdinger,
                new List<string>
                {
                    "Basic Skin",
                    "Alien Invader Heimerdinger",
                    "Blast Zone Heimerdinger",
                    "Piltover Customs Heimerdinger",
                    "Snowmerdinger",
                    "Hazmat Heimerdinger"
                }),
            new Skin(Champion.Illaoi, new List<string> {"Basic Skin", "Void Bringer Illaoi"}),
            new Skin(Champion.Irelia,
                new List<string>
                {
                    "Basic Skin",
                    "Nightblade Irelia",
                    "Aviator Irelia",
                    "Infiltrator Irelia",
                    "Frostblade Irelia",
                    "Order of the Lotus Irelia"
                }),
            new Skin(Champion.Janna,
                new List<string>
                {
                    "Basic Skin",
                    "Tempest Janna",
                    "Hextech Janna",
                    "Frost Queen Janna",
                    "Victorious Janna",
                    "Forecast Janna",
                    "Fnatic Janna"
                }),
            new Skin(Champion.JarvanIV,
                new List<string>
                {
                    "Basic Skin",
                    "Commando Jarvan",
                    "Dragon Slayer Jarvan",
                    "Darkforge Jarvan",
                    "Victorious Jarvan",
                    "Warring Kingdoms Jarvan IV",
                    "Fnatic Jarvan IV"
                }),
            new Skin(Champion.Jax,
                new List<string>
                {
                    "Basic Skin",
                    "The Mighty Jax",
                    "Vandal Jax",
                    "Angler Jax",
                    "PAX Jax",
                    "Jaximus",
                    "Temple Jax",
                    "Nemesis Jax",
                    "SKT Jax",
                    "Warden Jax"
                }),
            new Skin(Champion.Jayce, new List<string> {"Basic Skin", "Full Metal Jayce", "Debonair Jayce", "Forsaken Jayce"}),
            new Skin(Champion.Jhin, new List<string> {"Basic Skin", "High Noon Jhin"}),
            new Skin(Champion.Jinx, new List<string> {"Basic Skin", "Mafia Jinx", "Firecracker Jinx", "Slayer Jinx"}),
            new Skin(Champion.Kalista, new List<string> {"Basic Skin", "Blood Moon Kalista", "Championship Kalista"}),
            new Skin(Champion.Karma,
                new List<string> {"Basic Skin", "Sakura Karma", "Sun Goddess Karma", "Traditional Karma", "Order of the Lotus Karma", "Warden Karma"}),
            new Skin(Champion.Karthus,
                new List<string> {"Basic Skin", "Phantom Karthus", "Statue of Karthus", "Grim Reaper Karthus", "Pentakill Karthus", "Fnatic Karthus"}),
            new Skin(Champion.Kassadin,
                new List<string>
                {
                    "Basic Skin",
                    "Festival Kassadin",
                    "Deep One Kassadin",
                    "Pre-Void Kassadin",
                    "Harbinger Kassadin",
                    "Cosmic Reaver Kassadin"
                }),
            new Skin(Champion.Katarina,
                new List<string>
                {
                    "Basic Skin",
                    "Mercenary Katarina",
                    "Red Card Katarina",
                    "Bilgewater Katarina",
                    "Kitty Cat Katarina",
                    "High Command Katarina",
                    "Sandstorm Katarina",
                    "Slay Belle Katarina",
                    "Warring Kingdoms Katarina"
                }),
            new Skin(Champion.Kayle,
                new List<string>
                {
                    "Basic Skin",
                    "Silver Kayle",
                    "Viridian Kayle",
                    "Unmasked Kayle",
                    "Battleborn Kayle",
                    "Judgement Kayle",
                    "Aether Wing Kayle",
                    "Riot Kayle"
                }),
            new Skin(Champion.Kennen,
                new List<string>
                {
                    "Basic Skin",
                    "Deadly Kennen",
                    "Swamp Master Kennen",
                    "Karate Kennen",
                    "Kennen M.D.",
                    "Arctic Ops Kennen",
                    "Blood Moon Kennen"
                }),
            new Skin(Champion.Khazix, new List<string> {"Basic Skin", "Mecha Kha'Zix", "Guardian of the Sands Kha'Zix", "Death Blossom Kha'Zix"}),
            new Skin(Champion.Kindred, new List<string> {"Basic Skin", "Shadowfire Kindred"}),
            new Skin(Champion.KogMaw,
                new List<string>
                {
                    "Basic Skin",
                    "Caterpillar Kog'Maw",
                    "Sonoran Kog'Maw",
                    "Monarch Kog'Maw",
                    "Reindeer Kog'Maw",
                    "Lion Dance Kog'Maw",
                    "Deep Sea Kog'Maw",
                    "Jurassic Kog'Maw",
                    "Battlecast Kog'Maw"
                }),
            new Skin(Champion.Leblanc,
                new List<string>
                {
                    "Basic Skin",
                    "Prestigious LeBlanc",
                    "Wicked LeBlanc",
                    "Mistletoe LeBlanc",
                    "Ravenborn Leblanc",
                    "Elderwood Leblanc"
                }),
            new Skin(Champion.LeeSin,
                new List<string>
                {
                    "Basic Skin",
                    "Traditional Lee Sin",
                    "Acolyte Lee Sin",
                    "Dragon Fist Lee Sin",
                    "Muay Thai Lee Sin",
                    "Pool Party Lee Sin",
                    "SKT Lee Sin",
                    "Knockout Lee Sin"
                }),
            new Skin(Champion.Leona,
                new List<string> {"Basic Skin", "Defender Leona", "Valkyrie Leona", "Iron Solari Leona", "Pool Party Leona", "PROJECT: Leona"}),
            new Skin(Champion.Lissandra, new List<string> {"Basic Skin", "Bloodstone Lissandra", "Blade Queen Lissandra"}),
            new Skin(Champion.Lucian, new List<string> {"Basic Skin", "PROJECT: Lucian", "Striker Lucian", "Hired Gun Lucian"}),
            new Skin(Champion.Lulu,
                new List<string> {"Basic Skin", "Bittersweet Lulu", "Wicked Lulu", "Dragon Trainer Lulu", "Winter Wonder Lulu", "Pool Party Lulu"}),
            new Skin(Champion.Lux,
                new List<string>
                {
                    "Basic Skin",
                    "Spellthief Lux",
                    "Sorceress Lux",
                    "Commando Lux",
                    "Imperial Lux",
                    "Steel Legion Lux",
                    "Star Guardian Lux"
                }),
            new Skin(Champion.Malphite,
                new List<string>
                {
                    "Basic Skin",
                    "Shamrock Malphite",
                    "Coral Reef Malphite",
                    "Marble Malphite",
                    "Obsidian Malphite",
                    "Glacial Malphite",
                    "Mecha Malphite",
                    "Ironside Malphite"
                }),
            new Skin(Champion.Malzahar,
                new List<string>
                {
                    "Basic Skin",
                    "Snow Day Malzahar",
                    "Overlord Malzahar",
                    "Djinn Malzahar",
                    "Vizier Malzahar",
                    "Shadow Prince Malzahar"
                }),
            new Skin(Champion.Maokai,
                new List<string>
                {
                    "Basic Skin",
                    "Totemic Maokai",
                    "Charred Maokai",
                    "Festive Maokai",
                    "Haunted Maokai",
                    "Goalkeeper Maokai",
                    "Meowkai"
                }),
            new Skin(Champion.MasterYi,
                new List<string>
                {
                    "Basic Skin",
                    "Assassin Master Yi",
                    "Chosen Master Yi",
                    "Ionia Master Yi",
                    "Samurai Yi",
                    "Headhunter Master Yi",
                    "PROJECT: Yi"
                }),
            new Skin(Champion.MissFortune,
                new List<string>
                {
                    "Basic Skin",
                    "Cowgirl Miss Fortune",
                    "Waterloo Miss Fortune",
                    "Secret Agent Miss Fortune",
                    "Candy Cane Miss Fortune",
                    "Road Warrior Miss Fortune",
                    "Mafia Miss Fortune",
                    "Arcade Miss Fortune",
                    "Captain Fortune"
                }),
            new Skin(Champion.Mordekaiser,
                new List<string>
                {
                    "Basic Skin",
                    "Dragon Knight Mordekaiser",
                    "Infernal Mordekaiser",
                    "Pentakill Mordekaiser",
                    "Lord Mordekaiser",
                    "King of Clubs Mordekaiser"
                }),
            new Skin(Champion.Morgana,
                new List<string>
                {
                    "Basic Skin",
                    "Exiled Morgana",
                    "Sinful Succulence Morgana",
                    "Blade Mistress Morgana",
                    "Blackthorn Morgana",
                    "Ghost Bride Morgana",
                    "Victorious Morgana",
                    "Lunar Wraith Morgana"
                }),
            new Skin(Champion.Nami, new List<string> {"Basic Skin", "Koi Nami", "River Spirit Nami", "Urf the Nami-tee"}),
            new Skin(Champion.Nasus,
                new List<string>
                {
                    "Basic Skin",
                    "Galactic Nasus",
                    "Pharaoh Nasus",
                    "Dreadknight Nasus",
                    "Riot K-9 Nasus",
                    "Infernal Nasus",
                    "Archduke Nasus"
                }),
            new Skin(Champion.Nautilus,
                new List<string> {"Basic Skin", "Abyssal Nautilus", "Subterranean Nautilus", "AstroNautilus", "Warden Nautilus"}),
            new Skin(Champion.Nidalee,
                new List<string>
                {
                    "Basic Skin",
                    "Snow Bunny Nidalee",
                    "Leopard Nidalee",
                    "French Maid Nidalee",
                    "Pharaoh Nidalee",
                    "Bewitching Nidalee",
                    "Headhunter Nidalee",
                    "Warring Kingdoms Nidalee",
                    "Challenger Nidalee"
                }),
            new Skin(Champion.Nocturne,
                new List<string>
                {
                    "Basic Skin",
                    "Frozen Terror Nocturne",
                    "Void Nocturne",
                    "Ravager Nocturne",
                    "Haunting Nocturne",
                    "Eternum Nocturne"
                }),
            new Skin(Champion.Nunu,
                new List<string>
                {
                    "Basic Skin",
                    "Sasquatch Nunu",
                    "Workshop Nunu",
                    "Workshop Nunu",
                    "Grungy Nunu",
                    "Nunu Bot",
                    "TPA Nunu",
                    "Zombie Nunu"
                }),
            new Skin(Champion.Olaf, new List<string> {"Basic Skin", "Forsaken Olaf", "Glacial Olaf", "Brolaf", "Pentakill Olaf", "Marauder Olaf"}),
            new Skin(Champion.Orianna,
                new List<string>
                {
                    "Basic Skin",
                    "Gothic Orianna",
                    "Sewn Chaos Orianna",
                    "Bladecraft Orianna",
                    "TPA Orianna",
                    "Winter Wonder Orianna",
                    "Heartseeker Orianna"
                }),
            new Skin(Champion.Pantheon,
                new List<string>
                {
                    "Basic Skin",
                    "Myrmidon Pantheon",
                    "Ruthless Pantheon",
                    "Perseus Pantheon",
                    "Full Metal Pantheon",
                    "Glaive Warrior Pantheon",
                    "Dragonslayer Pantheon",
                    "Slayer Pantheon"
                }),
            new Skin(Champion.Poppy,
                new List<string>
                {
                    "Basic Skin",
                    "Noxus Poppy",
                    "Blacksmith Poppy",
                    "Lollipoppy",
                    "Ragdoll Poppy",
                    "Battle Regalia Poppy",
                    "Scarlet Hammer Poppy"
                }),
            new Skin(Champion.Quinn, new List<string> {"Basic Skin", "Phoenix Quinn", "Woad Scout Quinn", "Corsair Quinn"}),
            new Skin(Champion.Rammus,
                new List<string>
                {
                    "Basic Skin",
                    "King Rammus",
                    "Chrome Rammus",
                    "Molten Rammus",
                    "Freljord Rammus",
                    "Ninja Rammus",
                    "Full Metal Rammus",
                    "Guardian of the Sands Rammus"
                }),
            new Skin(Champion.RekSai, new List<string> {"Basic Skin", "Eternum Rek'Sai", "Pool Party Rek'Sai"}),
            new Skin(Champion.Renekton,
                new List<string>
                {
                    "Basic Skin",
                    "Galactic Renekton",
                    "Outback Renekton",
                    "Bloodfury Renekton",
                    "Rune Wars Renekton",
                    "Pool Party Renekton",
                    "Scorched Earth Renekton",
                    "Prehistoric Renekton"
                }),
            new Skin(Champion.Rengar, new List<string> {"Basic Skin", "Headhunter Rengar", "Night Hunter Rengar", "SSW Rengar"}),
            new Skin(Champion.Riven,
                new List<string>
                {
                    "Basic Skin",
                    "Crimson Elite Riven",
                    "Redeemed Riven",
                    "Battle Bunny Riven",
                    "Championship Riven",
                    "Dragonblade Riven",
                    "Arcade Riven"
                }),
            new Skin(Champion.Rumble, new List<string> {"Basic Skin", "Rumble in the Jungle", "Bilgerat Rumble", "Super Galaxy Rumble"}),
            new Skin(Champion.Ryze,
                new List<string>
                {
                    "Basic Skin",
                    "Human Ryze",
                    "Tribal Ryze",
                    "Uncle Ryze",
                    "Triumphant Ryze",
                    "Professor Ryze",
                    "Zombie Ryze",
                    "Dark Crystal Ryze",
                    "Pirate Ryze",
                    "Ryze Whitebeard"
                }),
            new Skin(Champion.Sejuani,
                new List<string>
                {
                    "Basic Skin",
                    "Sabretusk Sejuani",
                    "Darkrider Sejuani",
                    "Traditional Sejuani",
                    "Bear Cavalry Sejuani",
                    "Poro Rider Sejuani",
                    "Beast Hunter Sejuani"
                }),
            new Skin(Champion.Shaco,
                new List<string>
                {
                    "Basic Skin",
                    "Mad Hatter Shaco",
                    "Royal Shaco",
                    "Nutcracko",
                    "Workshop Shaco",
                    "Asylum Shaco",
                    "Masked Shaco",
                    "Wild Card Shaco"
                }),
            new Skin(Champion.Shen,
                new List<string> {"Basic Skin", "Yellow Jacket Shen", "Frozen Shen", "Surgeon Shen", "Blood Moon Shen", "Warlord Shen", "TPA Shen"}),
            new Skin(Champion.Shyvana,
                new List<string>
                {
                    "Basic Skin",
                    "Boneclaw Shyvana",
                    "Ironscale Shyvana",
                    "Darkflame Shyvana",
                    "Ice Drake Shyvana",
                    "Championship Shyvana"
                }),
            new Skin(Champion.Singed,
                new List<string>
                {
                    "Basic Skin",
                    "Riot Squad Singed",
                    "Hextech Singed",
                    "Surfer Singed",
                    "Mad Scientist Singed",
                    "Augmented Singed",
                    "Snow Day Singed",
                    "SSW Singed"
                }),
            new Skin(Champion.Sion, new List<string> {"Basic Skin", "Warmonger Sion", "Lumberjack Sion", "Barbarian Sion", "Hextech  Sion"}),
            new Skin(Champion.Sivir,
                new List<string>
                {
                    "Basic Skin",
                    "Warrior Princess Sivir",
                    "Spectacular Sivir",
                    "Huntress Sivir",
                    "Bandit Sivir",
                    "PAX Sivir",
                    "Snowstorm Sivir",
                    "Warden Sivir",
                    "Victorious Sivir"
                }),
            new Skin(Champion.Skarner,
                new List<string>
                {
                    "Basic Skin",
                    "Sandscourge Skarner",
                    "Earthrune Skarner",
                    "Battlecast Alpha Skarner",
                    "Guardian of the Sands Skarner"
                }),
            new Skin(Champion.Sona,
                new List<string>
                {
                    "Basic Skin",
                    "Muse Sona",
                    "Pentakill Sona",
                    "Silent Night Sona",
                    "Guqin Sona",
                    "Arcade Sona",
                    "DJ Sona",
                    "Sweetheart Sona"
                }),
            new Skin(Champion.Soraka,
                new List<string> {"Basic Skin", "Dryad Soraka", "Divine Soraka", "Celestine Soraka", "Reaper Soraka", "Order of the Banana Soraka"}),
            new Skin(Champion.Swain, new List<string> {"Basic Skin", "Northern Front Swain", "Bilgewater Swain", "Tyrant Swain"}),
            new Skin(Champion.Syndra,
                new List<string> {"Basic Skin", "Justicar Syndra", "Atlantean Syndra", "Queen of Diamonds Syndra", "Snow Day Syndra"}),
            new Skin(Champion.TahmKench, new List<string> {"Basic Skin", "Master Chef Tahm Kench", "Urf Kench"}),
            new Skin(Champion.Talon, new List<string> {"Basic Skin", "Renegade Talon", "Crimson Elite Talon", "Dragonblade Talon", "SSW Talon"}),
            new Skin(Champion.Taric, new List<string> {"Basic Skin", "Emerald Taric", "Armor of the Fifth Age Taric", "Bloodstone Taric"}),
            new Skin(Champion.Teemo,
                new List<string>
                {
                    "Basic Skin",
                    "Happy Elf Teemo",
                    "Recon Teemo",
                    "Badger Teemo",
                    "Astronaut Teemo",
                    "Cottontail Teemo",
                    "Super Teemo",
                    "Panda Teemo"
                }),
            new Skin(Champion.Thresh, new List<string> {"Basic Skin", "Deep Terror Thresh", "Championship Thresh", "Blood Moon Thresh", "SSW Thresh"}),
            new Skin(Champion.Tristana,
                new List<string>
                {
                    "Basic Skin",
                    "Riot Girl Tristana",
                    "Earnest Elf Tristana",
                    "Firefighter Tristana",
                    "Guerilla Tristana",
                    "Buccaneer Tristana",
                    "Rocket Girl Tristana",
                    "Dragon Trainer Tristana",
                }),
            new Skin(Champion.Trundle,
                new List<string> {"Basic Skin", "Lil Slugger Trundle", "Junkyard Trundle", "Traditional Trundle", "Constable Trundle"}),
            new Skin(Champion.Tryndamere,
                new List<string>
                {
                    "Basic Skin",
                    "Highland Tryndamere",
                    "King Tryndamere",
                    "Viking Tryndamere",
                    "Demonblade Tryndamere",
                    "Sultan Tryndamere",
                    "Warring Kingdoms Tryndamere",
                    "Nightmare Tryndamere",
                    "Beast Hunter Tryndamere"
                }),
            new Skin(Champion.TwistedFate,
                new List<string>
                {
                    "Basic Skin",
                    "PAX Twisted Fate",
                    "The Magnificent Twisted Fate",
                    "Tango Twisted Fate",
                    "Musketeer Twisted Fate",
                    "Underworld Twisted Fate",
                    "Red Card Twisted Fate",
                    "Cutpurse Twisted Fate"
                }),
            new Skin(Champion.Twitch,
                new List<string>
                {
                    "Basic Skin",
                    "Kingpin Twitch",
                    "Whisler Village Twitch",
                    "Medieval Twitch",
                    "Gangster Twitch",
                    "Vandal Twitch",
                    "Pickpocket Twitch",
                    "SSW Twitch"
                }),
            new Skin(Champion.Udyr, new List<string> {"Basic Skin", "Black Belt Udyr", "Primal Udyr", "Spirit Guard Udyr", "Definitely Not Udyr"}),
            new Skin(Champion.Urgot, new List<string> {"Basic Skin", "Giant Enemy Crabgot", "Butcher Urgot", "Battlecast Urgot"}),
            new Skin(Champion.Varus,
                new List<string> {"Basic Skin", "Blight Crystal Varus", "Archlight Varus", "Artic Ops Varus", "Heartseeker Varus", "Varus Swiftbolt"}),
            new Skin(Champion.Vayne,
                new List<string>
                {
                    "Basic Skin",
                    "Vindicator Vayne",
                    "Aristocrat Vayne",
                    "Dragonslayer Vayne",
                    "Heartseeker Vayne",
                    "SKT T1 Vayne",
                    "Archlight Vayne"
                }),
            new Skin(Champion.Veigar,
                new List<string>
                {
                    "Basic Skin",
                    "White Mage Veigar",
                    "Curling Veigar",
                    "Veigar GreyBeard",
                    "Leprechaun Veigar",
                    "Baron Von Veigar",
                    "Superb Villain Veigar",
                    "Bad Santa Veigar",
                    "Final Boss Veigar"
                }),
            new Skin(Champion.Velkoz, new List<string> {"Basic Skin", "Battlecast Vel'Koz", "Arclight Vel'Koz", "Definitely Not Vel'Koz"}),
            new Skin(Champion.Vi, new List<string> {"Basic Skin", "Neon Strik Vi", "Officer Vi", "Debonair Vi", "Demon Vi"}),
            new Skin(Champion.Viktor, new List<string> {"Basic Skin", "Full Machine Viktor", "Prototype Viktor", "Creator Viktor"}),
            new Skin(Champion.Vladimir,
                new List<string>
                {
                    "Basic Skin",
                    "Count Vladimir",
                    "Marquis Vladimir",
                    "Nosferatu Vladimir",
                    "Vandal Vladimir",
                    "Blood Lord Vladimir",
                    "Soulstealer Vladimir",
                    "Academy Vladimir"
                }),
            new Skin(Champion.Volibear,
                new List<string> {"Basic Skin", "Thunder Lord Volibear", "Northern Storm Volibear", "Runeguard Volibear", "Captain Volibear"}),
            new Skin(Champion.Warwick,
                new List<string>
                {
                    "Basic Skin",
                    "Grey Warwick",
                    "Urf the Manatee",
                    "Big Bad Warwick",
                    "Tundra Hunter Warwick",
                    "Feral Warwick",
                    "Firefant Warwick",
                    "Hyena Warwick",
                    "Marauder Warwick"
                }),
            new Skin(Champion.MonkeyKing,
                new List<string> {"Basic Skin", "Volcanic Wukong", "General Wukong", "Jade Dragon Wukong", "Underworld  Wukong", "Radiant Wukong"}),
            new Skin(Champion.Xerath,
                new List<string> {"Basic Skin", "Runeborn Xerath", "Scorched Earth Xerath", "Battlecast Xerath", "Guardian of the Sands Xerath"}),
            new Skin(Champion.XinZhao,
                new List<string>
                {
                    "Basic Skin",
                    "Commando Xin Zhao",
                    "Imperial Xin Zhao",
                    "Viscero Xin Zhao",
                    "Winged Hussar Xin Zhao",
                    "Warring Kingdoms Xin Zhao",
                    "Secret Agent Xin Zhao"
                }),
            new Skin(Champion.Yasuo, new List<string> {"Basic Skin", "High Noon Yasuo", "PROJECT: Yasuo", "Blood Moon Yasuo"}),
            new Skin(Champion.Yorick, new List<string> {"Basic Skin", "Undertaker Yorick", "Pentakill Yorick"}),
            new Skin(Champion.Zac, new List<string> {"Basic Skin", "Special Weapon Zac", "Pool Party Zac"}),
            new Skin(Champion.Zed, new List<string> {"Basic Skin", "Shockblade Zed", "SKT T1 Zed", "PROJECT: Zed"}),
            new Skin(Champion.Ziggs,
                new List<string> {"Basic Skin", "Mad Scientist Ziggs", "Major Ziggs", "Pool Party Ziggs", "Snow Day Ziggs", "Master Arcanist Ziggs"}),
            new Skin(Champion.Zilean,
                new List<string>
                {
                    "Basic Skin",
                    "Old Saint Zilean",
                    "Groovy Zilean",
                    "Shurima Desert Zilean",
                    "Time Machine Zilean",
                    "Blood Moon Zilean"
                }),
            new Skin(Champion.Zyra, new List<string> {"Basic Skin", "WildFire Zyra", "Haunted Zyra", "SKT T1 Zyra"}),
        };
    }
}
