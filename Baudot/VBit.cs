﻿namespace nl.gn.Baudot
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
                throw new ArgumentException("Value cannot be higher than 31.");

            this.Value = value;
        }


        // Assignment.
        public static explicit operator VBit(byte value)
        {
            return new VBit(value);
        }


        public override bool Equals(object obj)
        {
            if (obj is VBit)
            {
                return Equals((VBit)obj);
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


        // Byte equality.
        public static bool operator ==(VBit first, byte second)
        {
            return first.Equals(second);
        }
        public static bool operator !=(VBit first, byte second)
        {
            return !first.Equals(second);
        }
    }
}
