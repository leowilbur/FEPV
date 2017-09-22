namespace MIS.Utility
{
    using System;
    using System.Data;
    using System.IO;
    using System.IO.Compression;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public class DataFormatter
    {
        public static byte[] Compress(byte[] data)
        {
            MemoryStream stream = new MemoryStream();
            GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress, true);
            stream2.Write(data, 0, data.Length);
            stream2.Close();
            stream2.Dispose();
            byte[] buffer = stream.ToArray();
            stream.Close();
            stream.Dispose();
            return buffer;
        }

        public static byte[] Decompress(byte[] data)
        {
            MemoryStream stream = new MemoryStream();
            stream.Write(data, 0, data.Length);
            stream.Position = 0L;
            GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress, true);
            byte[] buffer2 = new byte[0x400];
            MemoryStream stream3 = new MemoryStream();
            for (int i = stream2.Read(buffer2, 0, buffer2.Length); i > 0; i = stream2.Read(buffer2, 0, buffer2.Length))
            {
                stream3.Write(buffer2, 0, i);
            }
            stream2.Close();
            stream2.Dispose();
            stream.Close();
            stream.Dispose();
            byte[] buffer = stream3.ToArray();
            stream3.Close();
            stream3.Dispose();
            return buffer;
        }

        public static byte[] GetBinaryFormatData(DataSet dsOriginal)
        {
            byte[] buffer = null;
            MemoryStream serializationStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            dsOriginal.RemotingFormat = SerializationFormat.Binary;
            formatter.Serialize(serializationStream, dsOriginal);
            buffer = serializationStream.ToArray();
            serializationStream.Close();
            serializationStream.Dispose();
            return buffer;
        }

        public static byte[] GetBinaryFormatData(object dsOriginal)
        {
            byte[] buffer = null;
            MemoryStream serializationStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, dsOriginal);
            buffer = serializationStream.ToArray();
            serializationStream.Close();
            serializationStream.Dispose();
            return buffer;
        }

        public static byte[] GetBinaryFormatDataCompress(DataSet dsOriginal)
        {
            byte[] data = null;
            MemoryStream serializationStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            dsOriginal.RemotingFormat = SerializationFormat.Binary;
            formatter.Serialize(serializationStream, dsOriginal);
            data = serializationStream.ToArray();
            serializationStream.Close();
            serializationStream.Dispose();
            return Compress(data);
        }

        public static byte[] GetBinaryFormatDataCompress(object dsOriginal)
        {
            byte[] data = null;
            MemoryStream serializationStream = new MemoryStream();
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(serializationStream, dsOriginal);
            data = serializationStream.ToArray();
            serializationStream.Close();
            serializationStream.Dispose();
            return Compress(data);
        }

        public static DataSet RetrieveDataSet(byte[] binaryData)
        {
            MemoryStream serializationStream = new MemoryStream(binaryData, true);
            IFormatter formatter = new BinaryFormatter();
            return (DataSet) formatter.Deserialize(serializationStream);
        }

        public static DataSet RetrieveDataSetDecompress(byte[] binaryData)
        {
            MemoryStream serializationStream = new MemoryStream(Decompress(binaryData));
            IFormatter formatter = new BinaryFormatter();
            return (DataSet) formatter.Deserialize(serializationStream);
        }

        public static object RetrieveObject(byte[] binaryData)
        {
            MemoryStream serializationStream = new MemoryStream(binaryData);
            IFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(serializationStream);
        }

        public static object RetrieveObjectDecompress(byte[] binaryData)
        {
            MemoryStream serializationStream = new MemoryStream(Decompress(binaryData));
            IFormatter formatter = new BinaryFormatter();
            return formatter.Deserialize(serializationStream);
        }
    }
}

