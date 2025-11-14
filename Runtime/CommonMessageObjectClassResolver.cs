/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-12
/// 功能描述：
/// </summary>

using GameEngine;
using GameEngine.Loader.Symboling;

using SystemType = System.Type;

namespace Game.Module.Protocol.Streambuf
{
    /// <summary>
    /// 消息对象类解析器通用对象类
    /// </summary>
    public class CommonMessageObjectClassResolver : ISymbolResolverOfInstantiationClass
    {
        public bool Matches(SystemType targetType)
        {
            return false;
        }

        public void Resolve(SymClass symbol)
        {
        }
    }
}
