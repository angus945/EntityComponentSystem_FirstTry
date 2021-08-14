using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EntityComponentSystem;

public class GameWorld : MonoBehaviour
{

    [SerializeField] EntityInstantiater instantiater = null;
    [SerializeField] GameEntities gameEntities = null;

    void Start()
    {
        EntityBase[] entities = instantiater.InstantiateEntities();
        gameEntities.Initial(entities);
    }
    void Update()
    {
        gameEntities.EntitiesUpdate(Time.deltaTime);
    }
}


