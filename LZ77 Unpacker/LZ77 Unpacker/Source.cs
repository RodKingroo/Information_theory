namespace LZ77_Unpacker
{
    public class LZ77Unpacked
    {
        public static void Unpack(string path)
        {
            byte[] file = File.ReadAllBytes(path);
            using StreamWriter fileOutput = new (path + ".txt");
            var W = Math.Pow(2, 16);
            string w = "";
            for (int i = 0; i < W; i++) w += "=";
            for(int i = 0; i<file.Length; i+=4)
            {
                int pos = 0xFFFF & ((Convert.ToInt32(file[i]) << 8) ^ (Convert.ToInt32(file[i+1])));
                int len = 0xFF & (Convert.ToInt32(file[i+2]));
                string c = Convert.ToChar(file[i + 3]).ToString();

                fileOutput.Write(string.Concat(w.AsSpan(pos, len), c));
                
                w = string.Concat(w[(len + 1)..], w.AsSpan(pos, len), c);

            }
            fileOutput.Close();
        }

        public static void Main(string[] args) => Unpack("file.lz77");
    }


}
