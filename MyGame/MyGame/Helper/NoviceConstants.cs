﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Helper
{
    class NoviceConstants:DifficultyConstants
    {
        public NoviceConstants()
        {
            INCREASED_HEALTH_BY_MEDKIT = 100;
            NUM_MEDKITS_IN_FIELD = 10;
            NUM_MONSTERS_IN_FIELD = 50;
        }
    }
}