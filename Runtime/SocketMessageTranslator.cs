/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-12
/// 功能描述：
/// </summary>

using GameEngine;
using NovaEngine;

namespace Game.Module.Protocol.Streambuf
{
    /// <summary>
    /// 套接字类型通道的消息解析器对象类，用于对套接字通道的网络消息数据进行加工
    /// </summary>
    public abstract class SocketMessageTranslator : IMessageTranslator
    {
        /// <summary>
        /// 消息操作码的长度，以字节为单位
        /// </summary>
        private const int OpcodeSize = 2;

        /// <summary>
        /// 将指定的消息内容编码为可发送的消息字节流
        /// </summary>
        /// <param name="message">消息内容</param>
        /// <returns>若编码有效的数据则返回其对应的字节流，否则返回null</returns>
        public byte[] Encode(object message)
        {
            int opcode = NetworkHandler.Instance.GetOpcodeByMessageType(message.GetType());

            DataFabricEntry.Runtime.ISerializable serial = message as DataFabricEntry.Runtime.ISerializable;
            GameEngine.Debugger.Assert(serial, NovaEngine.ErrorText.InvalidArguments);

            DataFabricEntry.Runtime.DFByteArray writer = new DataFabricEntry.Runtime.DFByteArray(256);
            writer.Write(1);
            writer.Write(opcode);
            serial.Serialize(writer);

            byte[] buff = writer.ToArray();
            writer.Dispose();

            return buff;
        }

        /// <summary>
        /// 将指定的消息字节流解码成消息内容
        /// </summary>
        /// <param name="buffer">消息字节流</param>
        /// <returns>返回解码后的消息内容，若解码失败则返回null</returns>
        public object Decode(byte[] buffer)
        {
            int serverId = buffer.ReadInt32(0);
            int opcode = buffer.ReadInt32(4);
            byte[] buff = new byte[buffer.Length - 8];
            System.Array.Copy(buffer, 8, buff, 0, buffer.Length - 8);
            object obj = CreateResponse(opcode, buff);
            return obj;
        }

        DataFabricEntry.Runtime.IClientAPI CreateResponse(int hashCode, byte[] data)
        {
            var type = DataFabricEntry.Runtime.MsgPackHelper.ProtoApi.GetRequestType(hashCode);
            var resp = (DataFabricEntry.Runtime.IClientAPI) System.Activator.CreateInstance(type);
            var reader = new DataFabricEntry.Runtime.DFByteArray(data);
            resp.DeSerialize(reader);
            return resp;
        }
    }
}
