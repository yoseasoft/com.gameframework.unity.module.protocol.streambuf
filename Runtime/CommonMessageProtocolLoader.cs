/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-12
/// 功能描述：
/// </summary>

using GameEngine;

using SystemType = System.Type;

namespace Game.Module.Protocol.Streambuf
{
    /// <summary>
    /// 消息对象类型加载器通用对象类
    /// </summary>
    public class CommonMessageProtocolLoader : IMessageProtocolLoader
    {
        public SystemType MessageProtocolType => typeof(object);

        public IMessageProtocolLoader.MessageObjectTypeInfo Parse(SystemType messageType)
        {
            IMessageProtocolLoader.MessageObjectTypeInfo typeInfo = new IMessageProtocolLoader.MessageObjectTypeInfo();

            return typeInfo;
        }
    }
}
