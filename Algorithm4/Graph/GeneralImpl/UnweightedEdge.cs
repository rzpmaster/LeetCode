using System;

namespace Graph.GeneralImpl
{
    public class WeightedEdge<TVertex> : UnweightedEdge<TVertex> where TVertex : IComparable<TVertex>
    {
        public WeightedEdge(TVertex src, TVertex dst) : base(src, dst)
        {
        }

        public override bool IsWeighted => true;

        public override double Weight { get; set; }
    }

    public class UnweightedEdge<TVertex> : IEdge<TVertex> where TVertex : IComparable<TVertex>
    {
        /// <summary>
        /// Gets or sets the weight.
        /// </summary>
        public virtual bool IsWeighted => false;
        /// <summary>
        /// [ABSTRACT MEMBER] Gets or sets the weight.
        /// </summary>
        public virtual double Weight { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <summary>
        /// Gets or sets the source vertex.
        /// </summary>
        public TVertex Source { get; set; }

        /// <summary>
        /// Gets or sets the destination vertex.
        /// </summary>
        public TVertex Destination { get; set; }

        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public UnweightedEdge(TVertex src, TVertex dst)
        {
            Source = src;
            Destination = dst;
        }

        #region IComparable implementation

        public int CompareTo(IEdge<TVertex> other)
        {
            if (other == null)
                return -1;

            bool areNodesEqual = Source.IsEqualTo<TVertex>(other.Source) && Destination.IsEqualTo<TVertex>(other.Destination);

            if (!areNodesEqual)
                return -1;
            return 0;
        }

        #endregion
    }
}
