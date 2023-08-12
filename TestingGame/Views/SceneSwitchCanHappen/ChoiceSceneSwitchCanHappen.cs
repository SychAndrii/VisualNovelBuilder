﻿using ConsoleTesting.Models.Player;
using ConsoleTesting.Models.Scenes;
using GameConsumer.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisualNovelModels.Models.Choices;

namespace GameConsumer.Views.SceneSwitchCanHappen
{
    internal class ChoiceSceneSwitchCanHappen : SceneSwitchCanHappenStrategy<ChoiceScene>
    {
        public event Func<Choice, Task> OnChoiceMade;
        public async Task<bool> CanSwitch(string userInput, ChoiceScene scene)
        {
            if (int.TryParse(userInput, out int choiceNumber))
            {
                var canSwitch = choiceNumber >= 1 && choiceNumber <= scene.Choices.Count();

                if(canSwitch)
                {
                    await OnChoiceMade?.Invoke(scene.Choices.ElementAt(choiceNumber - 1));
                }

                return canSwitch;
            }
            return false;
        }
    }
}