﻿using ConsoleTesting.Models.Base;
using DB.Models.Characters;
using DB.Models.TextSwitcher;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTesting.Models.Scenes
{
    /// <summary>
    /// Represents a scene with text, characters, background. Nothing which influences a story.
    /// </summary>
    /// <remarks>
    /// Imagine a scene in Everlasting Summer with no choice.
    /// </remarks>
    public class StandardScene : SwitchableScene
    {
        public Dialogue Dialogue { get; set; }
        public IEnumerable<SpriteCharacter>? Characters { get; set; }

        public override void Show()
        {
            Console.WriteLine(Dialogue);
        }
    }
}
