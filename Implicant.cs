using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuineMcCluskeySolver.Core
{
    
    public class Implicant : IEquatable<Implicant>
    {
        
        public int NumVars { get; }

        public int Value { get; }

        public int Mask { get; }

        public HashSet<int> MinTerms { get; }
        public bool WasCombined { get; set; } = false;

        public Implicant(int minterm, int numVars)
        {
            if (minterm < 0 || minterm >= (1 << numVars))
                throw new ArgumentOutOfRangeException(nameof(minterm),
                    $"Minterm {minterm} vượt quá phạm vi biểu diễn của {numVars} biến.");

            NumVars = numVars;
            Value = minterm;   
            Mask = 0;         
            MinTerms = new HashSet<int> { minterm };
        }

        private Implicant(int value, int mask, int numVars, HashSet<int> minTerms)
        {
            NumVars = numVars;
            Mask = mask;
         
            Value = value & ~mask;
            MinTerms = minTerms;
        }

        public bool CanCombineWith(Implicant other)
        {
            if (other == null) return false;
            if (NumVars != other.NumVars) return false;
            if (Mask != other.Mask) return false; 

            int diff = Value ^ other.Value; 
            return PopCount(diff) == 1;     
        }

        public static Implicant Combine(Implicant a, Implicant b)
        {
            if (!a.CanCombineWith(b))
                throw new InvalidOperationException("Hai implicant không thể ghép với nhau.");

            int diffBit = a.Value ^ b.Value;   
            int newMask = a.Mask | diffBit;    

            var newMinTerms = new HashSet<int>(a.MinTerms);
            newMinTerms.UnionWith(b.MinTerms);

            a.WasCombined = true;
            b.WasCombined = true;

            return new Implicant(a.Value, newMask, a.NumVars, newMinTerms);
        }

        public int CountOnes() => PopCount(Value);

        public int CountDontCares() => PopCount(Mask);
        private static int PopCount(int n)
        {
            int count = 0;
            uint u = (uint)n;
            while (u != 0)
            {
                u &= (u - 1); 
                count++;
            }
            return count;
        }

        public bool Equals(Implicant other)
        {
            if (other == null) return false;
            return Value == other.Value && Mask == other.Mask && NumVars == other.NumVars;
        }

        public override bool Equals(object obj) => Equals(obj as Implicant);

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 31 + Value;
                hash = hash * 31 + Mask;
                hash = hash * 31 + NumVars;
                return hash;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(NumVars);
            for (int i = NumVars - 1; i >= 0; i--)
            {
                int bit = 1 << i;
                if ((Mask & bit) != 0)
                    sb.Append('-');
                else
                    sb.Append((Value & bit) != 0 ? '1' : '0');
            }
            return sb.ToString();
        }
    }
}