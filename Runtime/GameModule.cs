/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-12
/// 功能描述：
/// </summary>

namespace Game.Module.Protocol.Streambuf
{
    /// <summary>
    /// 程序集的管理模块对象类
    /// </summary>
    public static class GameModule
    {
        /// <summary>
        /// 初始化回调函数
        /// </summary>
        public static void OnInitialize()
        {
            GameEngine.NetworkHandler.Instance.SetMessageProtocolType(typeof(object));
            GameEngine.NetworkHandler.Instance.RegMessageTranslator<WebSocketMessageTranslator>((int) NovaEngine.NetworkServiceType.WebSocket);

            GameEngine.Loader.CodeLoader.RegisterSymbolResolverOfInstantiationClass<CommonMessageObjectClassResolver>();
        }

        /// <summary>
        /// 清理回调函数
        /// </summary>
        public static void OnCleanup()
        {
            GameEngine.NetworkHandler.Instance.UnregMessageTranslator((int) NovaEngine.NetworkServiceType.WebSocket);

            GameEngine.Loader.CodeLoader.UnregisterSymbolResolverOfInstantiationClass<CommonMessageObjectClassResolver>();
        }
    }
}
