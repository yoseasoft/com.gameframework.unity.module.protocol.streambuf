/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-12
/// 功能描述：
/// </summary>

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
            if (// typeof(DataFabricEntry.Runtime.IServerAPI).IsAssignableFrom(targetType) ||
                typeof(DataFabricEntry.Runtime.IClientAPI).IsAssignableFrom(targetType))
            {
                return true;
            }

            return false;
        }

        public void Resolve(SymClass symbol)
        {
            SystemType targetType = symbol.ClassType;

            int opcode = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetMessageOpcode(targetType);

            int responseCode = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetMessageResponseCode(targetType);

            // Debugger.Warn("search protocol class '{%t}' has opcode = {%d}, response code = {%d}.", targetType, opcode, responseCode);

            GameEngine.MessageObjectAttribute attribute = new GameEngine.MessageObjectAttribute(opcode, responseCode);
            symbol.AddFeatureObject(attribute);
        }
    }
}
