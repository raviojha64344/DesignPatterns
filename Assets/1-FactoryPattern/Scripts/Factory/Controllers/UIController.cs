using System.Collections;
using System.Collections.Generic;
using DesignPattern.FactoryPattern.Factory;
using DesignPattern.FactoryPattern.Interfaces;
using UnityEngine;

namespace DesignPattern.FactoryPattern.Controllers
{
    /**/
    public class UIController : Controller
    {
        void Start()
        {
            GameController controller = ControllerFactory.Get(typeof(GameController)) as GameController;
            controller.PrintMsg("Hey Its Working!!!");
        }
    }
}
