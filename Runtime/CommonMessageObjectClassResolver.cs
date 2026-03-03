/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-12
/// 功能描述：
/// </summary>

using System;

namespace GameFramework.Protocol.Streambuf
{
    /// <summary>
    /// 消息对象类解析器通用对象类
    /// </summary>
    public class CommonMessageObjectClassResolver : GameEngine.Loader.Symbolling.ISymbolResolverOfInstantiationClass
    {
        public bool IsMatched(Type targetType)
        {
            if (// typeof(DataFabricEntry.Runtime.IServerAPI).IsAssignableFrom(targetType) ||
                typeof(DataFabricEntry.Runtime.IClientAPI).IsAssignableFrom(targetType))
            {
                return true;
            }

            return false;
        }

        public void Resolve(GameEngine.Loader.Symbolling.SymClass symbol)
        {
            Type targetType = symbol.ClassType;

            int opcode = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetMessageOpcode(targetType);

            int responseCode = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetMessageResponseCode(targetType);

            // Debugger.Warn("search protocol class '{%t}' has opcode = {%d}, response code = {%d}.", targetType, opcode, responseCode);

            GameEngine.MessageObjectAttribute attribute = new GameEngine.MessageObjectAttribute(opcode, responseCode);
            symbol.AddFeatureObject(attribute);
        }
    }
}
