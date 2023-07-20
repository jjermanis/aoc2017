
namespace AoC2017
{
    internal class KnotHash
    {
        private const int LIST_LEN = 256;

        private readonly List<int> ASCII_INPUT_END =
            new List<int>() { 17, 31, 73, 47, 23 };

        private readonly List<byte> _list;
        private readonly List<byte> _denseHash;

        public KnotHash(string input)
        {
            _list = InitList();
            var lengths = AsciiInput(input);
            int curr = 0;
            int skipSize = 0;
            for (var c = 0; c < 64; c++)
            {
                foreach (var len in lengths)
                {
                    ReverseSegment(_list, curr, len);
                    curr += skipSize++;
                    curr += len;
                    curr %= 256;
                }
            }
            _denseHash = DenseHash(_list);
        }

        private static List<byte> InitList()
        {
            var result = new List<byte>(LIST_LEN);
            for (int i = 0; i < LIST_LEN; i++)
                result.Add((byte)i);
            return result;
        }

        private IList<int> AsciiInput(string line)
        {
            var result = line.ToCharArray().Select(x => (int)x).ToList();
            foreach (var x in ASCII_INPUT_END)
                result.Add(x);
            return result;
        }

        private void ReverseSegment(
            List<byte> list,
            int curr,
            int len)
        {
            var temp = new List<byte>(len);
            for (int i = 0; i < len; i++)
                temp.Add(list[(curr + i) % LIST_LEN]);
            temp.Reverse();
            for (int i = 0; i < len; i++)
                list[(curr + i) % LIST_LEN] = temp[i];
        }

        private List<byte> DenseHash(List<byte> list)
        {
            var result = new List<byte>();
            for (var s = 0; s < 255; s += 16)
            {
                byte curr = 0;
                for (var x = 0; x < 16; x++)
                {
                    curr ^= list[s + x];
                }
                result.Add(curr);
            }
            return result;
        }

        internal List<byte> DenseHash()
            => _denseHash;

        internal string DenseHashHexString()
        {
            var result = "";
            foreach (var curr in _denseHash)
                result += curr.ToString("x2");
            return result;
        }
    }
}
