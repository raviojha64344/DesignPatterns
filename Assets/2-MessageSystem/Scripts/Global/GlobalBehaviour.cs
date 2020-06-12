using DesignPattern.MessagePattern.Global.Interfaces;
using UnityEngine;

namespace DesignPattern.MessagePattern.Global
{
    /**/
    public abstract class GlobalBehaviour : MonoBehaviour, IGlobalBehaviour
    {
        #region MonoLifeCycle

        protected virtual void Awake()
        {
            GlobalContext.Process(this);
            CollectComponent();
        }

        protected virtual void OnEnable()
        {
            AddListeners();
        }

        protected virtual void OnDisable()
        {
            RemoveListeners();
        }

        protected virtual void Start()
        {
            //Start
        }

        protected virtual void OnDestroy()
        {
            RemoveListeners();
        }

        #endregion

        #region Listeners

        protected virtual void AddListeners()
        {
            RemoveListeners();
            // Add Listeners
        }

        protected virtual void RemoveListeners()
        {
            //Remove Listeners
        }

        #endregion

        #region Collect

        protected virtual void CollectComponent()
        {
            //Collect Component here
        }

        #endregion
    }
}
