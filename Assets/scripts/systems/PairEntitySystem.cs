using System;
using UnityEngine;
using System.Collections.Generic;

namespace strange.examples.signals
{
    /**
     * EntitySystem that loops over single entities every frame.
     */
    public abstract class PairEntitySystem : AEntitySystem
    {

        /**
         * Called every frame from the SystemView. Calls the PairEntitySystem update for each pair of game objects.
         */
        public override void update(float deltaTime)
        {
            foreach (GameObject e1 in entities)
            {
                foreach (GameObject e2 in entities)
                {
                    update(deltaTime, e1, e2);
                }
            }
        }

        /**
         * Enforces that PairEntitySystem implementations must loop over pairs of entities.
         * 
         * e1 and e2 can be the same GameObject, so a check is needed to alter this.
         */
        public abstract void update(float deltaTime, GameObject e1, GameObject e2);

    }
}
