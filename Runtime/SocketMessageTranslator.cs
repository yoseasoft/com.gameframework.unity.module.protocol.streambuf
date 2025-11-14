/// <summary>
/// Game Framework
/// 
/// 创建者：Hurley
/// 创建时间：2025-11-12
/// 功能描述：
/// </summary>

using GameEngine;

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
            byte[] buff = { 0x2C, 0x00, 0x00, 0x00, 0x01, 0x00, 0x00, 0x00, 0x7D, 0x2A,
                            0xE1, 0x42, 0x01, 0x00, 0x00, 0x00, 0x0B, 0x00, 0x01, 0x00, 0x08, 0x00, 0x72, 0x6F, 0x62, 0x6F,
                            0x74, 0x5F, 0x5F, 0x31, 0x01, 0x00, 0x00, 0x00, 0x0A, 0x00, 0x00, 0x00, 0x81, 0xA2, 0x6F, 0x73,
                            0xA5, 0x72, 0x6F, 0x62, 0x6F, 0x74};
            GameEngine.Debugger.Info("encode = {%i}", buff);
            return buff;
        }

        /// <summary>
        /// 将指定的消息字节流解码成消息内容
        /// </summary>
        /// <param name="buffer">消息字节流</param>
        /// <returns>返回解码后的消息内容，若解码失败则返回null</returns>
        public object Decode(byte[] buffer)
        {
            GameEngine.Debugger.Info("decode = {%i}", buffer);
            return null;
        }
    }
}
