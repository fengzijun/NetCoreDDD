using System.Runtime.CompilerServices;

namespace Yimi.PublishManage.Core.Infrastructure
{
    /// <summary>
    /// Provides access to the singleton instance of the Yimi engine.
    /// </summary>
    public class EngineContext
    {
        #region Methods

        /// <summary>
        /// Create a static instance of the Yimi engine.
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)] 
        public static IEngine Create()
        {
            //create YimiEngine as engine
            if (Singleton<IEngine>.Instance == null)
                Singleton<IEngine>.Instance = new YimiEngine();

            return Singleton<IEngine>.Instance;
        }

        /// <summary>
        /// Sets the static engine instance to the supplied engine. Use this method to supply your own engine implementation.
        /// </summary>
        /// <param name="engine">The engine to use.</param>
        /// <remarks>Only use this method if you know what you're doing.</remarks>
        public static void Replace(IEngine engine)
        {
            Singleton<IEngine>.Instance = engine;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the singleton Yimi engine used to access Nop services.
        /// </summary>
        public static IEngine Current
        {
            get
            {
                if (Singleton<IEngine>.Instance == null)
                {
                    Create();
                }

                return Singleton<IEngine>.Instance;
            }
        }

        #endregion
    }
}
