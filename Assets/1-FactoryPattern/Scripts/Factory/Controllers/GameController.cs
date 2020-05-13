using UnityEngine;

namespace DesignPattern.FactoryPattern.Controllers
{
    /**/
    public class GameController : Controller
    {
        public void PrintMsg(string msg)
        {
            Debug.Log(msg);
        }
    }
}
