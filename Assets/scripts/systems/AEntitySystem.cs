using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace strange.examples.signals
{
    /*
     * Contains methods and fields relevant to all EntitySystem types.
     */
    public abstract class AEntitySystem : IEntitySystem
    {

        //list of entities we will loop over in the update method
        public List<GameObject> entities = new List<GameObject>();

        //list of components used to determine if an entity belongs to us
        public List<Type> components;

        /**
         * Loop through all GameObjects that are children of "Entities", adding them to this system's "entities" if they have all components
         * required by this system.
         */
        public void updateEntityList()
        {
            //clear our list of entities
            entities.Clear();

            //get our main parent, "Entities"
            GameObject entitiesGO = GameObject.Find("Entities");

            //foreach child of "Entities"
            foreach (Transform child in entitiesGO.transform)
            {
                //get the entity as a game object
                GameObject entityGO = child.gameObject;

                Boolean hasAllComponents = true;

                //foreach component we need our GO to have
                foreach (Type component in components)
                {
                    //if it doesn't have the component, break to next child without doing anything
                    if (entityGO.GetComponent(component) == null)
                    {
                        hasAllComponents = false;
                        break;
                    }
                }

                //we've looped through all components...is hasAllComponents is still true, add this GO to our active list
                if (hasAllComponents == true)
                {
                    entities.Add(entityGO);
                }
            }
        }

        //subclasses must implement update
        public abstract void update(float deltaTime);
    }
}
