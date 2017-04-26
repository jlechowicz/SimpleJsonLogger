using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleJsonLogger.Util
{
    public static class Unity
    {
        private static IUnityContainer _container;

        static Unity()
        {
            if (_container == null)
            {
                _container = new UnityContainer();
            }
        }

        public static IUnityContainer Instance { get { return _container; } }
    }
}
