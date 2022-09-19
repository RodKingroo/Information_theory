using System.Collections;
using System.Diagnostics;


namespace Huffman
{
    public partial class FHuffman : Form
    {
        public static float a, ba, c;

        public FHuffman()
        {
            InitializeComponent();

        }

        readonly int[] byteMap = new int[256];

        private void CodeBtn_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FillByteMap(ofd.FileName);

                HuffmanTree.CreateHuffmanTree(byteMap);
                HuffmanTree.ShowTree(OutputTextBox);
                var huffmapMap = HuffmanTree.GetMap();

                CodeFile(ofd.FileName, ofd.FileName + "huf", huffmapMap, byteMap);
                OutputTextBox.AppendText("\nФайл успешно зашифрован. Новое имя файла: " + ofd.FileName + "5huf\n");
                
            }

        }

        private static void CodeFile(string fileName, string newFileName, Dictionary<byte, BitArray> huffmapMap, IEnumerable<int> map)
        {

            byte myByte;
            List<BitArray> code = new();
            using (FileStream fs = new(fileName, FileMode.Open))
            {
                a = new FileInfo(fileName).Length;
                for (int i = 0; i < fs.Length; i++)
                {
                    myByte = (byte)fs.ReadByte();
                    code.Add(huffmapMap[myByte]);
                }
            }
            var count = code.Sum(bitArray => bitArray.Count);


            var additionBits = (byte)((8 - count % 8) % 8);
            var bitCount = (count + 7) / 8;

            BitArray bitarr = new(count + additionBits, false);
            var add = 0;
            foreach (var t in code)
            {
                for (var j = 0; j < t.Count; j++) bitarr[add + j] = t[t.Count - 1 - j]; 

                add += t.Count;
            }
            var bytes = new byte[bitCount];
            bitarr.CopyTo(bytes, 0);

            using FileStream sw = new(newFileName, FileMode.Create);
            using BinaryWriter bw = new(sw);
            foreach (var b in map) bw.Write(b);

            bw.Write(additionBits);
            foreach (var b in bytes) bw.Write(b);

            sw.Close();

            using FileStream size_file = new("Debug.config", FileMode.Create);
            using BinaryWriter bsf = new(size_file);
            ba = new FileInfo(newFileName).Length;
            bsf.Write("Original file size: " + a + "Byte; After encoding: " + ba + "Bytes; The file has become smaller by " + ba / a + "%");
        }

        private void FillByteMap(string fileName)
        {
            byte myByte;
            for (int i = 0; i < byteMap.Length; i++) byteMap[i] = 0;
            using FileStream fs = new(fileName, FileMode.Open);
            for (int i = 0; i < fs.Length; i++)
            {
                myByte = (byte)fs.ReadByte();
                byteMap[myByte]++;
            }

        }
    }
}
