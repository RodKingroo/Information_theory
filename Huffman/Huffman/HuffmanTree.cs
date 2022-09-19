using System.Collections;
using System.Text;

namespace Huffman
{
    class HuffmanTree
    {
        public static HuffmanTree? Root;
        public HuffmanTree? LeftBranch;
        public HuffmanTree? RightBranch;
        private HuffmanTree? parent;
        public byte Value;
        private int weight;
        private static HuffmanTree[]? _nodes;

        public static void CreateHuffmanTree(int[] byteMap)
        {
            List<HuffmanTree> nodes = new(256);
            for (int i = 0; i < 256; i++)
                if (byteMap[i] > 0) nodes.Add(new HuffmanTree { Value = (byte)i, weight = byteMap[i] }); //узлы
            _nodes = nodes.ToArray();

            while (nodes.Count > 1)
            {
                var first = nodes[0];
                var index = 0;
                for (int i = 1; i < nodes.Count; i++)
                {
                    if (first.weight <= nodes[i].weight) continue;
                    first = nodes[i];
                    index = i;
                    
                }
                nodes.RemoveAt(index);
                var second = nodes[0];
                index = 0;
                for (int i = 1; i < nodes.Count; i++)
                {
                    if (second.weight <= nodes[i].weight) continue;
                    second = nodes[i];
                    index = i;
                    //Поиск "легких" элементов - 2
                }
                nodes.RemoveAt(index);
                var newNode = new HuffmanTree { LeftBranch = first, RightBranch = second, weight = first.weight + second.weight };
                first.parent = newNode;
                second.parent = newNode;
                nodes.Add(newNode);
                //замена легких элементов весом равным сумме
            }
            Root = nodes[0];
            //Дерево - корень в Root
        }

        private static void ShowTree(RichTextBox outputTextBox, int i, HuffmanTree node)
        {
            if (node.LeftBranch == null) outputTextBox.AppendText(" Value: " + node.Value + " Count: " + node.weight + "\n");
            else
            {
                outputTextBox.AppendText("\n");
                for (int j = 0; j < i; j++) outputTextBox.AppendText("\t");

                outputTextBox.AppendText("(" + (i + 1) + ")");
                ShowTree(outputTextBox, i + 1, node.LeftBranch);
                outputTextBox.AppendText("\n");
                for (int j = 0; j < i; j++) outputTextBox.AppendText("\t");

                outputTextBox.AppendText("(" + (i + 1) + ")");
                ShowTree(outputTextBox, i + 1, node: node.RightBranch);
            }
        }

        public static void ShowTree(RichTextBox outputTextBox) => ShowTree(outputTextBox, 0, node: Root);

        public static Dictionary<byte, BitArray> GetMap()
        {
            Dictionary<byte, BitArray> output = new (capacity: _nodes.Length);
            StringBuilder sb = new();
            foreach (HuffmanTree t in _nodes)
            {
                var huffmanTree = t;
                sb.Clear();

                while (huffmanTree.parent != null)
                {
                    sb.Append(huffmanTree == huffmanTree.parent.LeftBranch ? "0" : "1");
                    huffmanTree = huffmanTree.parent;
                }
                BitArray bitArray = new(sb.Length);
                for (int j = 0; j < sb.Length; j++) bitArray[j] = sb[j] - '0' == 1;
                output.Add(t.Value, bitArray);
            }

            return output;
        }
    }
}
