﻿using System;

namespace Vd2.NeoDemo
{
    public struct RenderOrderKey : IComparable<RenderOrderKey>, IComparable
    {
        public readonly ulong Value;

        public RenderOrderKey(ulong value)
        {
            Value = value;
        }

        public static RenderOrderKey Create(int materialID, float cameraDistance)
            => Create((uint)materialID, cameraDistance);
        public static RenderOrderKey Create(uint materialID, float cameraDistance)
        {
            uint cameraDistanceInt = (uint)Math.Min(uint.MaxValue, (cameraDistance * 1000f));

            return new RenderOrderKey(
                ((ulong)materialID << 32) +
                cameraDistanceInt);
        }

        public int CompareTo(RenderOrderKey other)
        {
            return Value.CompareTo(other.Value);
        }

        int IComparable.CompareTo(object obj)
        {
            return Value.CompareTo(obj);
        }
    }
}