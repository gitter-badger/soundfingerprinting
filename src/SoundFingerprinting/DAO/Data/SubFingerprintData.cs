﻿namespace SoundFingerprinting.DAO.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using SoundFingerprinting.DAO;

    [Serializable]
    public class SubFingerprintData
    {
        public SubFingerprintData()
        {
            Clusters = Enumerable.Empty<string>();
        }

        public SubFingerprintData(long[] hashes, int sequenceNumber, double sequenceAt, IModelReference subFingerprintReference, IModelReference trackReference) : this()
        {
            Hashes = hashes;
            SubFingerprintReference = subFingerprintReference;
            TrackReference = trackReference;
            SequenceNumber = sequenceNumber;
            SequenceAt = sequenceAt;
        }

        [IgnoreBinding]
        public long[] Hashes { get; set; }

        public int SequenceNumber { get; set; }

        public double SequenceAt { get; set; }

        [IgnoreBinding]
        public IEnumerable<string> Clusters { get; set; }

        [IgnoreBinding]
        public IModelReference SubFingerprintReference { get; set; }

        [IgnoreBinding]
        public IModelReference TrackReference { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (!(obj is SubFingerprintData))
            {
                return false;
            }

            return ((SubFingerprintData)obj).SubFingerprintReference.Equals(SubFingerprintReference);
        }

        public override int GetHashCode()
        {
            return SubFingerprintReference.GetHashCode();
        }
    }
}
