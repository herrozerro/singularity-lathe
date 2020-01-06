using System;
using System.Collections.Generic;
using System.Text;
using SingularityLathe.Forge.StellarForge.Services;

namespace SingularityLathe.Forge.StellarForge
{
    public class StellarForgeService
    {
        private readonly StarSystemBuilderService starSystemBuilderService = null;

        public StellarForgeService(StarSystemBuilderService starSystemBuilderService)
        {
            this.starSystemBuilderService = starSystemBuilderService;
        }
    }
}
