using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DesignPattern.FactoryPattern.Interfaces;
using UnityEngine;

namespace DesignPattern.FactoryPattern.Factory
{
    /**/
    public static class ControllerFactory
    {
        private static bool isInitialized = false;
        private readonly static Dictionary<Type, IController> _controllers = new Dictionary<Type, IController>();

        private static void Initialize()
		{
            var types = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(IController)) && !type.IsInterface && !type.IsAbstract);

            foreach(Type type in types)
            {
                var instance = Activator.CreateInstance(type) as IController;
                _controllers.Add(type, instance);
            }

            isInitialized = true;
		}

        public static IController Get(Type type)
		{
            if (!isInitialized)
            {
                Initialize();
            }

            if(_controllers.TryGetValue(type, out IController controller))
            { 
                return controller;
            }
			else
			{
                Debug.Log("Error : Can not find controller.");
                return default;
			}

		}
    }
}
