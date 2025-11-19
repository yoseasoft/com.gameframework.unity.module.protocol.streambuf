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
            if (typeof(DataFabricEntry.Runtime.IServerAPI).IsAssignableFrom(targetType) ||
                typeof(DataFabricEntry.Runtime.IClientAPI).IsAssignableFrom(targetType))
            {
                return true;
            }

            return false;
        }

        public void Resolve(SymClass symbol)
        {
            SystemType targetType = symbol.ClassType;

            int opcode = 0, responseCode = 0;

            opcode = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetRequest(targetType);

            SystemType responseType = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetResponse(opcode);
            // responseCode = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetRequest(responseType);

            // Debugger.Warn("search protocol class '{%t}' has opcode = {%d}.", targetType, opcode);

            MessageObjectAttribute attribute = new MessageObjectAttribute(opcode, responseCode);
            symbol.AddFeatureObject(attribute);
        }
    }
}
