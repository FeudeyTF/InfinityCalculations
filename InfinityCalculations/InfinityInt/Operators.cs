namespace InfinityCalculations.InfinityArithmetic
{
    public partial struct InfinityInt
    {
        public static InfinityInt operator +(InfinityInt fNum, InfinityInt sNum)
        {
            return fNum.Add(sNum);
        }
        public static InfinityInt operator +(InfinityInt fNum, int sNum)
        {
            return fNum.Add(sNum);
        }
        public static InfinityInt operator +(InfinityInt fNum, string sNum)
        {
            return fNum.Add(sNum);
        }
        public static InfinityInt operator -(InfinityInt fNum, InfinityInt sNum)
        {
            return sNum.Substract(fNum);
        }
        public static InfinityInt operator *(InfinityInt fNum, InfinityInt sNum)
        {
            return fNum.Multiply(sNum);
        }
        public static InfinityInt operator ++(InfinityInt value)
        {
            return value.Add(1);
        }

        public static bool operator >(InfinityInt fNum, InfinityInt sNum)
        {
            if (fNum.Length != sNum.Length)
                return fNum.Length > sNum.Length && !fNum.Negative;
            else if (fNum.Negative && !sNum.Negative)
                return !fNum.Negative && sNum.Negative;
            else
            {
                for (int i = 0; i < fNum.Length; i++)
                    if (fNum[i] > sNum[i])
                        return !fNum.Negative;
                return fNum.Negative;
            }
        }
        public static bool operator <(InfinityInt fNum, InfinityInt sNum)
        {
            return sNum > fNum;
        }
        public static implicit operator InfinityInt(int value)
        {
            return new InfinityInt(value.ToString());
        }
        public static implicit operator InfinityInt(long value)
        {
            return new InfinityInt(value.ToString());
        }

        public static implicit operator InfinityInt(string value)
        {
            return new InfinityInt(value);
        }
    }
}
