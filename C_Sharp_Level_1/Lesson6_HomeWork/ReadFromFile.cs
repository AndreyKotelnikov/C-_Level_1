using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6_HomeWork
{
    class ReadFromFile
    {
        static long kbyte = 1024;
        static long mbyte = 1024 * kbyte;
        static long gbyte = 1024 * mbyte;
        static long size = mbyte;
        //Write FileStream
        //Write BinaryStream
        //Write StreamReader/StreamWriter
        //Write BufferedStream

        public static void LoadFromFile()
        {
            Console.WriteLine("FileStream. Milliseconds:{0}", FileStreamSample(@"..\..\bigdata0.bin", size, out List<byte> fileStream));
            //foreach (var item in fileStream)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();

            Console.WriteLine("BinaryStream. Milliseconds:{0}", BinaryStreamSample(@"..\..\bigdata1.bin", size, out List<int> binaryStream));
            //foreach (var item in binaryStream)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();

            Console.WriteLine("StreamReader. Milliseconds:{0}", StreamReaderSample(@"..\..\bigdata2.bin", size, out string streamReader));
            //foreach (var item in streamReader)
            //{
            //    Console.Write($"{item} ");
            //}
            //Console.WriteLine();

            Console.WriteLine("BufferedStream. Milliseconds:{0}", BufferedStreamSample(@"..\..\bigdata3.bin", size, out List<byte[]> bufferedStream));
            //foreach (var item in bufferedStream)
            //{
            //    foreach (var b in item)
            //    {
            //        Console.Write($"{b} ");
            //    }
            //}
            //Console.WriteLine();

        }

        static long FileStreamSample(string filename, long size, out List<byte> array)
        {
            array = new List<byte>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //FileStream fs = new FileStream("D:\\temp\\bigdata.bin", FileMode.CreateNew, FileAccess.Write);
            int temp;
            while (true)
            {
                temp = fs.ReadByte();
                if (temp == -1) { break; }
                array.Add((byte)temp);
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long BinaryStreamSample(string filename, long size, out List<int> array)
        {
            array = new List<int>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //BinaryWriter bw = new BinaryWriter(fs);
            BinaryReader br = new BinaryReader(fs);
            while (fs.Length > array.Count)
            {
                array.Add(br.ReadByte());
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long StreamReaderSample(string filename, long size, out string str)
        {
            str = string.Empty;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            //StreamWriter sw = new StreamWriter(fs);
            StreamReader sr = new StreamReader(fs);
            while (!sr.EndOfStream)
            {
                str += sr.ReadLine();
            }

            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        static long BufferedStreamSample(string filename, long size, out List<byte[]> array)
        {
            array = new List<byte[]>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            FileStream fs = new FileStream(filename, FileMode.Open, FileAccess.Read);
            int countPart = 4;//количество частей
            int bufsize = (int)(size / countPart);
            byte[] buffer = new byte[bufsize];
            BufferedStream bs = new BufferedStream(fs, bufsize);
            //bs.Write(buffer, 0, (int)size);//Error!
            int count = 1;
            while (countPart >= count)
            {
                bs.Read(buffer, 0, bufsize);
                array.Add(buffer);
                count++;
            }
            fs.Close();
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }
    }
}
