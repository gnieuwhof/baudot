namespace nl.gn.BaudotPortable
{
    using System;

    /// <summary>
    /// Represents a 5-bit unsinged integer.
    /// Note: technically this type is immutable.
    /// </summary>
    public struct VBit : IEquatable<VBit>
    {
        public readonly byte Value;

        // The minimum value that a VBit may represent: 0.
        public const byte MinValue = 0;

        // The maximum value that a VBit may represent: 31.
        public const byte MaxValue = (byte)0x1F;


        /// <summary>
        /// Constructs a VBit given a 0-31 (5-bit) value.
        /// </summary>
        /// <param name="value">Value of the VBit</param>
        public VBit(byte value)
        {
            if (value > 31)
                throw new ArgumentOutOfRangeException(
                    nameof(value),
                    "Value cannot be negative or higher than 31."
                    );

            this.Value = value;
        }


        // Assignment.
        // Note: This must be explicit, because
        // we cannot hold the enire byte range.
        // (the contructor will throw if the value > 31)
        // (negative will overflow to 255)
        public static explicit operator VBit(byte value)
        {
            return new VBit(value);
        }

        public override bool Equals(object obj)
        {
            if (obj is VBit)
            {
                return this.Equals((VBit)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Value;
        }


        /// <summary>
        /// Returns whether the passed in VBit is equal to this.
        /// </summary>
        public bool Equals(VBit other)
        {
            return (this.Value == other.Value);
        }


        // VBit equality.
        public static bool operator ==(VBit first, VBit second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(VBit first, VBit second)
        {
            return !first.Equals(second);
        }
    }
}
