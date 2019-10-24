using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SingularityLathe.Forge.AdventureForge;

namespace SingularityLathe.WPF.AdventureGen
{
    public class AdventureGenViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private AdventureGeneratorService adventureGeneratorService { get; set; }
        private string _adventureTemplate;
        private string _advntureOutput;

        public ICommand GenerateAdventureTempalate { get; }

        public string AdventureTemplate
        {
            get { return _adventureTemplate; } 
            set
            {
                _adventureTemplate = value;
                OnPropertyChanged("AdventureTemplate");
            }
        }
        public string AdventureOutput {
            get { return _advntureOutput; }
            set
            {
                _advntureOutput = value;
                OnPropertyChanged("AdventureOutput");
            }
        }

        public async Task GenerateAdventure()
        {
            AdventureOutput = adventureGeneratorService.GenerateAdventure(AdventureTemplate);
        }


        public AdventureGenViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(
                new System.Windows.DependencyObject()))
            {
                return;
            }

            adventureGeneratorService = new AdventureGeneratorService(new RadLibs.RadLibService(new RadLibs.RadLibConfiguration() { RandomSeed = 1}));
            AdventureTemplate = adventureGeneratorService.GetRandomTemplate();
        }

        public void OnPropertyChanged(string propertyName) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
