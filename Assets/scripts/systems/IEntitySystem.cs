using UnityEngine;
using System.Collections.Generic;

namespace strange.examples.signals
{
    /*
     * Entity systems keep track of entities that contain specified components, and update these entities every frame.
     */
    public interface IEntitySystem
    {
        /*
         * Updates active list of entities this system is acting on (should be called somehow whenever a new gameobject is made)
         */
        void updateEntityList();

        /**
         * Called by our system manager every frame, delegates to appropriate update method to loop over entity list.
         */
        void update(float deltaTime);
    }
}
