using SingularityLathe.RadLibs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SingularityLathe.Forge.AdventureForge
{
    public class AdventureGeneratorService
    {
        private readonly Random rnd = null;
        private readonly RadLibService _radLibService = null;
        private readonly List<string> templates = new List<string>();


        public AdventureGeneratorService(Random random, RadLibService radLibService)
        {
            rnd = random;
            _radLibService = radLibService;
            templates.Add("The Adventurers must [[VERB]] the [[SUBJECT]] in the [[PLACE]], while dealing with a [[HINDRANCE]] and opposing the [[ANTAGONIST]].");
            templates.Add("The Adventurers must [[VERB]], while dealing with a [[HINDRANCE]] and opposing [[ANTAGONIST]].");
            templates.Add("[[ANTAGONIST]] has stolen the [[SUBJECT]] and the Adventurers must get it back.");
            templates.Add("[[SUBJECT]] have lost their [[PLACE]] to the [[ANTAGONIST]] and the Adventurers must [[VERB]] to get it back.");
            //templates.Add("");


            var verbs = new RadLibTagDictionary()
            {
                Name = "VERB"
            };

            verbs.Values.Add("Rescue");
            verbs.Values.Add("Escort");
            verbs.Values.Add("Attack");
            verbs.Values.Add("Investigate");
            verbs.Values.Add("Aid");
            verbs.Values.Add("Transport");
            verbs.Values.Add("Steal");
            verbs.Values.Add("Fight");
            verbs.Values.Add("Blackmail");
            verbs.Values.Add("Hide");
            verbs.Values.Add("Shelter");
            verbs.Values.Add("Trick");
            verbs.Values.Add("Negotiate");
            verbs.Values.Add("Defend");
            verbs.Values.Add("Retrieve");
            verbs.Values.Add("Overcome");
            verbs.Values.Add("Invade");
            verbs.Values.Add("Kill");
            verbs.Values.Add("Capture");
            verbs.Values.Add("Free");
            verbs.Values.Add("Secure");
            verbs.Values.Add("Heal");
            verbs.Values.Add("Trade");
            verbs.Values.Add("Scare");
            verbs.Values.Add("Hunt");
            verbs.Values.Add("Find");
            verbs.Values.Add("Defend");
            verbs.Values.Add("Prevent");
            verbs.Values.Add("Cause");
            verbs.Values.Add("Serve");
            verbs.Values.Add("Take");
            verbs.Values.Add("Bargain");
            verbs.Values.Add("Explore");
            verbs.Values.Add("Sabotage");
            verbs.Values.Add("Kidnap");
            verbs.Values.Add("Lead");

            var subjects = new RadLibTagDictionary()
            {
                Name = "SUBJECT"
            };

            subjects.Values.Add("Human");
            subjects.Values.Add("Fey");
            subjects.Values.Add("Dwarf");
            subjects.Values.Add("Goblin");
            subjects.Values.Add("Salimar");
            subjects.Values.Add("Treefolk");
            subjects.Values.Add("Karhu");
            subjects.Values.Add("Lizardfolk");
            subjects.Values.Add("Royalty");
            subjects.Values.Add("Priest");
            subjects.Values.Add("Wizard");
            subjects.Values.Add("Scribe");
            subjects.Values.Add("Monster");
            subjects.Values.Add("Animal");
            subjects.Values.Add("Pirate");
            subjects.Values.Add("Bandit");
            subjects.Values.Add("Magic Item");
            subjects.Values.Add("Enemy");
            subjects.Values.Add("Passenger");
            subjects.Values.Add("Riddle");
            subjects.Values.Add("Merchandise");
            subjects.Values.Add("Contraband");
            subjects.Values.Add("Performer");
            subjects.Values.Add("Caravan");
            subjects.Values.Add("Merchant");
            subjects.Values.Add("Thief");
            subjects.Values.Add("Warrior");
            subjects.Values.Add("Healer");
            subjects.Values.Add("Peasant");
            subjects.Values.Add("Begger");
            subjects.Values.Add("Traveler");
            subjects.Values.Add("Inkeeper");
            subjects.Values.Add("Ghost");
            subjects.Values.Add("City Watch");
            subjects.Values.Add("Witness");
            subjects.Values.Add("Alchemist");

            var places = new RadLibTagDictionary()
            {
                Name = "PLACE"
            };
            places.Values.Add("Mountain Top");
            places.Values.Add("Ruins");
            places.Values.Add("Ocean");
            places.Values.Add("Desert");
            places.Values.Add("Island");
            places.Values.Add("Canyon");
            places.Values.Add("Mountain Pass");
            places.Values.Add("Temple");
            places.Values.Add("Ice Cave");
            places.Values.Add("Volcano");
            places.Values.Add("Forest");
            places.Values.Add("Whirlpool");
            places.Values.Add("Sunken City");
            places.Values.Add("Subterranean City");
            places.Values.Add("Floating Fortress");
            places.Values.Add("Airship");
            places.Values.Add("Fortress");
            places.Values.Add("Market");
            places.Values.Add("Tower");
            places.Values.Add("City Jail");
            places.Values.Add("Bridge");
            places.Values.Add("Sewers");
            places.Values.Add("Docks");
            places.Values.Add("Dungeon");
            places.Values.Add("Graveyard");
            places.Values.Add("Gambling House");
            places.Values.Add("Faerie Realm");
            places.Values.Add("Land of Dreams");
            places.Values.Add("Other Dimension");
            places.Values.Add("Castle");
            places.Values.Add("Monastery");
            places.Values.Add("Mine");
            places.Values.Add("Enemy Territory");
            places.Values.Add("Dragon's Den");
            places.Values.Add("Labyrinth");

            var hindrances = new RadLibTagDictionary()
            {
                Name = "HINDRANCE"
            };

            hindrances.Values.Add("Ally");
            hindrances.Values.Add("Betrayal");
            hindrances.Values.Add("Love");
            hindrances.Values.Add("Broken Promise");
            hindrances.Values.Add("Deception");
            hindrances.Values.Add("Rival");
            hindrances.Values.Add("Mentor");
            hindrances.Values.Add("Family");
            hindrances.Values.Add("Attack");
            hindrances.Values.Add("Trap");
            hindrances.Values.Add("Physical Illness");
            hindrances.Values.Add("Weather");
            hindrances.Values.Add("Finances");
            hindrances.Values.Add("Theft");
            hindrances.Values.Add("Spy");
            hindrances.Values.Add("Double Agent");
            hindrances.Values.Add("Revenge");
            hindrances.Values.Add("Mental Illness");
            hindrances.Values.Add("Red Herring");
            hindrances.Values.Add("Transportation");
            hindrances.Values.Add("Hostage");
            hindrances.Values.Add("Kidnapping");
            hindrances.Values.Add("Assassination");
            hindrances.Values.Add("City Watch");
            hindrances.Values.Add("Greed");
            hindrances.Values.Add("Trust");
            hindrances.Values.Add("Hatred");
            hindrances.Values.Add("Jealousy");
            hindrances.Values.Add("Bad Luck");
            hindrances.Values.Add("Pride");
            hindrances.Values.Add("Laziness");
            hindrances.Values.Add("Lust");
            hindrances.Values.Add("Gluttony");
            hindrances.Values.Add("Neglect");
            hindrances.Values.Add("Forgetfulness");
            hindrances.Values.Add("Ignorance");

            var antagonists = new RadLibTagDictionary()
            {
                Name = "ANTAGONIST"
            };
            antagonists.Values.Add("City Watch");
            antagonists.Values.Add("City Leader");
            antagonists.Values.Add("Spy");
            antagonists.Values.Add("Politics");
            antagonists.Values.Add("Moneylender");
            antagonists.Values.Add("Scandal");
            antagonists.Values.Add("Bandits");
            antagonists.Values.Add("Pirates");
            antagonists.Values.Add("Secret Society");
            antagonists.Values.Add("Wizard's Guild");
            antagonists.Values.Add("Thieve's Guild");
            antagonists.Values.Add("Army");
            antagonists.Values.Add("Monster");
            antagonists.Values.Add("Flora");
            antagonists.Values.Add("Fauna");
            antagonists.Values.Add("Undead");
            antagonists.Values.Add("Magic");
            antagonists.Values.Add("Disease");
            antagonists.Values.Add("Wizard");
            antagonists.Values.Add("Necromancer");
            antagonists.Values.Add("Cultists");
            antagonists.Values.Add("Merchants");
            antagonists.Values.Add("Alchemist");
            antagonists.Values.Add("Murderer");
            antagonists.Values.Add("Assassin");
            antagonists.Values.Add("Time");
            antagonists.Values.Add("Demon");
            antagonists.Values.Add("Invasion");
            antagonists.Values.Add("Evil Genius");
            antagonists.Values.Add("Dragon");
            antagonists.Values.Add("Robber");
            antagonists.Values.Add("Imposter");
            antagonists.Values.Add("Faerie");
            antagonists.Values.Add("Curse");
            antagonists.Values.Add("Parasite");
            antagonists.Values.Add("Adventurers");

            _radLibService.RadLibTagDictionaries.Add(subjects);
            _radLibService.RadLibTagDictionaries.Add(verbs);
            _radLibService.RadLibTagDictionaries.Add(antagonists);
            _radLibService.RadLibTagDictionaries.Add(places);
            _radLibService.RadLibTagDictionaries.Add(hindrances);
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

            var processedAdventure = _radLibService.ProcessMadLibRandom(adventure);

            return processedAdventure;
        }

    }

    
}
