namespace InfinityCalculations.InfinityArithmetic
{
    public partial struct InfinityInt
    {
        public string Number;
        public bool Negative = false;
        public int Length { get { return Number.Length; } }
        public int this[int i] { get { return Number[i] - '0'; } }
        public InfinityInt(string number = "0")
        {
            if (number[0] == '-')
            {
                Number = number[1..];
                Negative = true;
            }
            else
                Number = number;
        }
        public override string ToString()
        {
            return (Negative ? "-" : "") + Number;
        }
        private InfinityInt Add(InfinityInt num)
        {
            string result = "";
            Equalize(num, this, out InfinityInt first, out InfinityInt second);
            bool rem = false;
            for (int i = first.Length - 1; i >= 0; i--)
            {
                int c = first[i] + second[i];
                if (rem) c++;
                if (c >= 10)
                {
                    c -= 10;
                    rem = true;
                }
                else rem = false;
                result = c + result;
            }
            if (rem)
                result = '1' + result;
            return new InfinityInt(result);
        }
        private InfinityInt Multiply(InfinityInt num)
        {
            InfinityInt result = 0;
            for (int i = 0; i < num.Length; i++)
            {
                InfinityInt preResult = 0;
                for (int j = 0; j < Length; j++)
                {
                    string a = this[j] * num[i] + "";
                    for (int k = j; k < Length - 1; k++)
                        a += "0";
                    preResult += a;
                }
                for (int k = i; k < num.Length - 1; k++)
                    preResult.Number += "0";
                result += preResult;
            }
            return result;
        }
        private InfinityInt Substract(InfinityInt num)
        {
            Equalize(num, this, out InfinityInt first, out InfinityInt second);
            string reversedNum = "";
            for(int i = 0; i < second.Length; i++)
                reversedNum += 9 - second[i];
            InfinityInt comReverNum = reversedNum;
            comReverNum++;
            InfinityInt result = first + comReverNum;
            return CleanNumber(new InfinityInt(result.Number[1..]));
        }
        private static InfinityInt CleanNumber(InfinityInt num)
        {
            string result = "";
            int index = 0;
            if (num[0] == 0)
            {
                for (int i = 0; i < num.Length; i++)
                    if (num[i] == 0 && num[i + 1] != 0)
                    {
                        index = i;
                        break;
                    }
                for (int i = index + 1; i < num.Length; i++)
                    result += num[i];
                return result;
            }
            else
                return num;

        }
        public static void Equalize(InfinityInt fNum, InfinityInt sNum, out InfinityInt r1, out InfinityInt r2)
        {
            int n = fNum.Length - sNum.Length;
            if (n < 0)
            {
                for (int i = 0; i < -n; i++)
                    fNum.Number = "0" + fNum.Number;
            }
            else
                for (int i = 0; i < n; i++)
                    sNum.Number = "0" + sNum.Number;
            r1 = fNum;
            r2 = sNum;
        }
    }
}
