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
    public class GameModule : GameEngine.IHotModule
    {
        /// <summary>
        /// 初始化回调函数
        /// </summary>
        public void Startup()
        {
            GameEngine.GameApi.SetMessageProtocolType(typeof(object));
            GameEngine.GameApi.RegisterMessageTranslator<WebSocketMessageTranslator>((int) NovaEngine.NetworkServiceType.WebSocket);

            GameEngine.Loader.CodeLoader.RegisterSymbolResolverOfInstantiationClass<CommonMessageObjectClassResolver>();
        }

        /// <summary>
        /// 清理回调函数
        /// </summary>
        public void Shutdown()
        {
            GameEngine.GameApi.UnregisterMessageTranslator((int) NovaEngine.NetworkServiceType.WebSocket);

            GameEngine.Loader.CodeLoader.UnregisterSymbolResolverOfInstantiationClass<CommonMessageObjectClassResolver>();
        }
    }
}
