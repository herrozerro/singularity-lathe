using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SingularityLathe.Forge.AdventureForge
{
    public class AdventureGeneratorService
    {
        private Random rnd = new Random();

        private List<string> verbs = new List<string>();
        private List<string> subjcts = new List<string>();
        private List<string> places = new List<string>();
        private List<string> hindrances = new List<string>();
        private List<string> antagonists = new List<string>();
        private List<string> templates = new List<string>();

        public AdventureGeneratorService()
        {
            verbs.Add("Attack");
            verbs.Add("Rescue");
            verbs.Add("Escort");
            verbs.Add("Investigate");
            verbs.Add("Aid");
            verbs.Add("Transport");
            verbs.Add("Steal");
            verbs.Add("Fight");
            verbs.Add("Blackmail");
            verbs.Add("Hide");
            verbs.Add("Shelter");
            verbs.Add("Trick");
            verbs.Add("Negotiate");
            verbs.Add("Defend");
            verbs.Add("Retrieve");
            verbs.Add("Overcome");
            verbs.Add("Invade");
            verbs.Add("Kill");
            verbs.Add("Capture");
            verbs.Add("Free");
            verbs.Add("Secure");
            verbs.Add("Heal");
            verbs.Add("Trade");
            verbs.Add("Scare");
            verbs.Add("Hunt");
            verbs.Add("Find");
            verbs.Add("Defend");
            verbs.Add("Prevent");
            verbs.Add("Cause");
            verbs.Add("Serve");
            verbs.Add("Take");
            verbs.Add("Bargain");
            verbs.Add("Explore");
            verbs.Add("Sabotage");
            verbs.Add("Kidnap");
            verbs.Add("Lead");

            subjcts.Add("Human");
            subjcts.Add("Fey");
            subjcts.Add("Dwarf");
            subjcts.Add("Goblin");
            subjcts.Add("Salimar");
            subjcts.Add("Treefolk");
            subjcts.Add("Karhu");
            subjcts.Add("Lizardfolk");
            subjcts.Add("Royalty");
            subjcts.Add("Priest");
            subjcts.Add("Wizard");
            subjcts.Add("Scribe");
            subjcts.Add("Monster");
            subjcts.Add("Animal");
            subjcts.Add("Pirate");
            subjcts.Add("Bandit");
            subjcts.Add("Magic Item");
            subjcts.Add("Enemy");
            subjcts.Add("Passenger");
            subjcts.Add("Riddle");
            subjcts.Add("Merchandise");
            subjcts.Add("Contraband");
            subjcts.Add("Performer");
            subjcts.Add("Caravan");
            subjcts.Add("Merchant");
            subjcts.Add("Thief");
            subjcts.Add("Warrior");
            subjcts.Add("Healer");
            subjcts.Add("Peasant");
            subjcts.Add("Begger");
            subjcts.Add("Traveler");
            subjcts.Add("Inkeeper");
            subjcts.Add("Ghost");
            subjcts.Add("City Watch");
            subjcts.Add("Witness");
            subjcts.Add("Alchemist");

            places.Add("Mountain Top");
            places.Add("Ruins");
            places.Add("Ocean");
            places.Add("Desert");
            places.Add("Island");
            places.Add("Canyon");
            places.Add("Mountain Pass");
            places.Add("Temple");
            places.Add("Ice Cave");
            places.Add("Volcano");
            places.Add("Forest");
            places.Add("Whirlpool");
            places.Add("Sunken City");
            places.Add("Subterranean City");
            places.Add("Floating Fortress");
            places.Add("Airship");
            places.Add("Fortress");
            places.Add("Market");
            places.Add("Tower");
            places.Add("City Jail");
            places.Add("Bridge");
            places.Add("Sewers");
            places.Add("Docks");
            places.Add("Dungeon");
            places.Add("Graveyard");
            places.Add("Gambling House");
            places.Add("Faerie Realm");
            places.Add("Land of Dreams");
            places.Add("Other Dimension");
            places.Add("Castle");
            places.Add("Monastery");
            places.Add("Mine");
            places.Add("Enemy Territory");
            places.Add("Dragon's Den");
            places.Add("Labyrinth");

            hindrances.Add("Ally");
            hindrances.Add("Betrayal");
            hindrances.Add("Love");
            hindrances.Add("Broken Promise");
            hindrances.Add("Deception");
            hindrances.Add("Rival");
            hindrances.Add("Mentor");
            hindrances.Add("Family");
            hindrances.Add("Attack");
            hindrances.Add("Trap");
            hindrances.Add("Physical Illness");
            hindrances.Add("Weather");
            hindrances.Add("Finances");
            hindrances.Add("Theft");
            hindrances.Add("Spy");
            hindrances.Add("Double Agent");
            hindrances.Add("Revenge");
            hindrances.Add("Mental Illness");
            hindrances.Add("Red Herring");
            hindrances.Add("Transportation");
            hindrances.Add("Hostage");
            hindrances.Add("Kidnapping");
            hindrances.Add("Assassination");
            hindrances.Add("City Watch");
            hindrances.Add("Greed");
            hindrances.Add("Trust");
            hindrances.Add("Hatred");
            hindrances.Add("Jealousy");
            hindrances.Add("Bad Luck");
            hindrances.Add("Pride");
            hindrances.Add("Laziness");
            hindrances.Add("Lust");
            hindrances.Add("Gluttony");
            hindrances.Add("Neglect");
            hindrances.Add("Forgetfulness");
            hindrances.Add("Ignorance");

            antagonists.Add("City Watch");
            antagonists.Add("City Leader");
            antagonists.Add("Spy");
            antagonists.Add("Politics");
            antagonists.Add("Moneylender");
            antagonists.Add("Scandal");
            antagonists.Add("Bandits");
            antagonists.Add("Pirates");
            antagonists.Add("Secret Society");
            antagonists.Add("Wizard's Guild");
            antagonists.Add("Thieve's Guild");
            antagonists.Add("Army");
            antagonists.Add("Monster");
            antagonists.Add("Flora");
            antagonists.Add("Fauna");
            antagonists.Add("Undead");
            antagonists.Add("Magic");
            antagonists.Add("Disease");
            antagonists.Add("Wizard");
            antagonists.Add("Necromancer");
            antagonists.Add("Cultists");
            antagonists.Add("Merchants");
            antagonists.Add("Alchemist");
            antagonists.Add("Murderer");
            antagonists.Add("Assassin");
            antagonists.Add("Time");
            antagonists.Add("Demon");
            antagonists.Add("Invasion");
            antagonists.Add("Evil Genius");
            antagonists.Add("Dragon");
            antagonists.Add("Robber");
            antagonists.Add("Imposter");
            antagonists.Add("Faerie");
            antagonists.Add("Curse");
            antagonists.Add("Parasite");
            antagonists.Add("Adventurers");

            templates.Add("The Adventurers must [[VERB]] the [[SUBJECT]] in the [[PLACE]], while dealing with a [[HINDRANCE]] and opposing the [[ANTAGONIST]].");
            templates.Add("The Adventurers must [[VERB]], while dealing with a [[HINDRANCE]] and opposing [[ANTAGONIST]].");
            templates.Add("[[ANTAGONIST]] has stolen the [[SUBJECT]] and the Adventurers must get it back.");
            templates.Add("[[SUBJECT]] have lost their [[PLACE]] to the [[ANTAGONIST]] and the Adventurers must [[VERB]] to get it back.");
            //templates.Add("");
        }

        public string GetRandomTemplate()
        {
            return templates[rnd.Next(templates.Count())];
        }

        public string GenerateAdventure()
        {
            return GenerateAdventure(GetRandomTemplate());
        }

        public string GenerateAdventure(string adventure)
        {

            var regex = new Regex(@"\[\[.*?\]\]");

            var matches = regex.Matches(adventure);

            foreach (Match m in matches)
            {
                var replacer = new Regex(m.Value);

                string replace = "";

                switch (m.Value)
                {
                    case "[[VERB]]":
                        replace = verbs[rnd.Next(verbs.Count())];
                        break;
                    case "[[SUBJECT]]":
                        replace = subjcts[rnd.Next(subjcts.Count())];
                        break;
                    case "[[PLACE]]":
                        replace = places[rnd.Next(places.Count())];
                        break;
                    case "[[HINDRANCE]]":
                        replace = hindrances[rnd.Next(hindrances.Count())];
                        break;
                    case "[[ANTAGONIST]]":
                        replace = antagonists[rnd.Next(antagonists.Count())];
                        break;
                }

                adventure = regex.Replace(adventure, replace, 1);
            }

            return adventure;
        }

    }
}
