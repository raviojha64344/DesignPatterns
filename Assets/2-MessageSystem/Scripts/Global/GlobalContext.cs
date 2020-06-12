using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DesignPattern.MessagePattern.Attributes;
using DesignPattern.MessagePattern.Global.Interfaces;
using UnityEngine;

namespace DesignPattern.MessagePattern.Global
{
    /**/
    public class GlobalContext
    {
        #region Fields

        public static readonly List<IGlobalBehaviour> globalBehaviours = new List<IGlobalBehaviour>();
        public static readonly Dictionary<Type, List<MethodInfo>> messageDictionary = new Dictionary<Type, List<MethodInfo>>();

        #endregion

        public static void Process(IGlobalBehaviour globalBehaviour)
        {
            globalBehaviours.Add(globalBehaviour);
            GetAttributes(globalBehaviour.GetType());
        }

        private static void GetAttributes(Type type)
        {
            MethodInfo[] methods = type.GetMethods();
            foreach(var m in methods)
            {
                var attributes = m.GetCustomAttributes();

                foreach (var attr in attributes)
                {
                    if (attr is MessageHandler)
                    {
                        MessageHandler msgHandler = attr as MessageHandler;
                        if (!messageDictionary.ContainsKey(msgHandler.Type))
                        { 
                            messageDictionary.Add(msgHandler.Type, new List<MethodInfo>());
                        }
                        messageDictionary[msgHandler.Type].Add(m);
                    }
                }
            }
        }

        public static void Call(object obj)
        {
            Type type = obj.GetType();
            if (messageDictionary.ContainsKey(type) && messageDictionary[type] != null && messageDictionary[type].Count > 0)
            {
                foreach(MethodInfo methodInfo in messageDictionary[type])
                {
                    IGlobalBehaviour globalBehaviour = globalBehaviours.FirstOrDefault(gb => gb.GetType().Name == methodInfo.DeclaringType.Name);
                    if(globalBehaviour != null)
                        methodInfo.Invoke(globalBehaviour, new object[] { obj });
                }
            }
        }
    }
}
