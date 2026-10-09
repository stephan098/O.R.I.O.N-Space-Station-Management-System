using System;

namespace PRG2781_Project
{
    internal class RandomModuleGenerator
    {
        private Random rand = new Random();

        public StationModule GenerateRandomModule()
        {
            int choice = rand.Next(1, 4);

            string id = rand.Next(1000, 9999).ToString();

            switch (choice)
            {
                case 1:
                    return new LifeSupportModule(
                        "LS-" + id,
                        true,
                        0,
                        0);

                case 2:
                    return new ResearchLab(
                        "LAB-" + id,
                        true,
                        rand.Next(40, 100),
                        rand.Next(70, 100),
                        rand.Next(1, 6));

                default:
                    return new SolarArray(
                        "SOL-" + id,
                        true,
                        0,
                        0);
            }
        }
    }
}