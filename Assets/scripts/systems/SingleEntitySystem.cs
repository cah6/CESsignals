using System;
using UnityEngine;
using System.Collections.Generic;

namespace strange.examples.signals
{
    /**
     * EntitySystem that loops over single entities every frame.
     */
    public abstract class SingleEntitySystem : AEntitySystem
    {

        /**
         * Called every frame from the SystemView.
         */
        public override void update(float deltaTime)
        {
            foreach (GameObject entity in entities){
                update(deltaTime, entity);
            }
        }

        /**
         * Enforces that SingleEntitySystem implementations must loop over single entities.
         */
        public abstract void update(float deltaTime, GameObject entity);

    }
}
