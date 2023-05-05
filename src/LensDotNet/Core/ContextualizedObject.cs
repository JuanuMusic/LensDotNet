using System;
using LensDotNet.Contexts;

namespace LensDotNet.Core
{
    /// <summary>
    /// Describes an object that depends on the <see cref="LensContext"/>.
    /// </summary>
    public abstract class ContextualizedObject
    {
        private LensContext _context;
        /// <summary>
        /// The context this object live on.
        /// </summary>
        public LensContext Context { get => _context; }

        /// <summary>
        /// Initialize a new instance of this contextualized object, by passing the context to use.
        /// </summary>
        /// <param name="context"></param>
        public ContextualizedObject(LensContext context)
            => _context = context;

        /// <summary>
        /// Initialize a new instance of this contextualized object, by passing the context to use.
        /// </summary>
        /// <param name="context"></param>
        public ContextualizedObject(Network network)
        {
            _context = new LensContext(network);
        }
    }
}

